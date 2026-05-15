using NeuronDotNet.Core;
using NeuronDotNet.Core.Backpropagation;
using NeuronDotNet.Core.Initializers;
using NeuronDotNet.Core.LearningRateFunctions;
using NeuronDotNet.Core.SOM;
using ScottPlot;
using ZedGraph;

namespace XBIOM
{
    public partial class frmMain
    {
        private double[] xValues = Array.Empty<double>();
        private double[] yValues = Array.Empty<double>();
        private int citiesCount = 25;
        private int neuronCount = 50;  // výchozí hodnota, po vygenerování mapy se nastaví na 2*citiesCount
        private bool showVisualization = true;
        private int trainingCycles = 1000;
        private float tspSomCityMarkerSize = 5f;  // velikost puntíku města
        private System.Drawing.Color tspSomMapColor = System.Drawing.Color.Chocolate;
        private const double TspSomFinalLearningRate = 0.1;
        private bool tspSomInterrupted = false;

        private static readonly Random randomGenerator = new Random();
        private TrainingSet trainingSet = null!;
        private KohonenNetwork network = null!;

        /// <summary>
        /// Sestaví Kohonenovu síť, provede trénink nad vygenerovanými městy a uloží výslednou trasu.
        /// </summary>
        private void SolveSOM()
        {
            trainingCycles = Math.Max(1, (int)nuTspSomTrainingCycles.Value);  // jeden tréninkový cyklus odpovídá jedné epoše
            DisableOtherTabPages(tabPageTspSom);

            KohonenLayer inputLayer = new KohonenLayer(2);  // vstupní vrstva má 2 neurony: [x,y] souřadnice města
            KohonenLayer outputLayer = new KohonenLayer(new NeuronDotNet.Core.SOM.Size(neuronCount, 1));  // 1D výstupní vrstva s větším počtem neuronů než měst
            outputLayer.IsRowCircular = true;

            // Každý výstupní neuron má dvě váhy odpovídající souřadnicím [x,y], které se během učení posouvají k městům.
            KohonenConnector connector = new KohonenConnector(inputLayer, outputLayer);
            // Počáteční váhy volíme ve stejném rozsahu jako souřadnice měst na mapě.
            connector.Initializer = new RandomFunction(0, 100);

            // SOM hledá pro každý vstup nejbližší výstupní neuron (BMU) a posouvá jeho okolí směrem ke vstupním datům.
            network = new KohonenNetwork(inputLayer, outputLayer);

            // Learning rate v průběhu tréninku klesá, aby síť nejdřív rychle hledala tvar a později jemně dolaďovala váhy.
            double initialLearningRate = (double)nuTspSomInitialLearningRate.Value;
            var learningFunction = new LinearFunction(initialLearningRate: initialLearningRate, finalLearningRate: TspSomFinalLearningRate);
            network.SetLearningRate(learningFunction);

            int progress = 0;

            network.EndEpochEvent += new TrainingEpochEventHandler(
               delegate (object senderNetwork, TrainingEpochEventArgs args)
               {
                   // Průměrná chyba říká, jak daleko jsou města od svých nejbližších neuronů.
                   double averageError = CalculateSOMAverageError();
                   if (progress == 0)
                   {
                       formsPlotTspSomError.Plot.Axes.SetLimitsY(0, averageError);
                       formsPlotTspSomError.Refresh();
                   }

                   var line = formsPlotTspSomError.Plot.Add.Scatter((double)args.TrainingIteration + 1, averageError);
                   line.MarkerSize = 3;
                   line.Color = Colors.Red;
                   formsPlotTspSomError.Refresh();

                   pbTspSomTraining.Value = Math.Min(100, ((progress++) * 100) / trainingCycles);
                   
                   if (showVisualization)
                   {
                       ShowMap();
                       int pause = GetTspSomVisualizationPause();
                       if (pause > 0) Thread.Sleep(pause);
                   }

                   // Trénink SOM běží synchronně, proto zde necháváme UI zpracovat kliknutí na tlačítko Přerušit.
                   Application.DoEvents();
                   lblTspSomElapsedTime.Text = FormatTime(calculationStopwatch.Elapsed);
                   lblTspSomElapsedTime.Refresh();
               });


            network.Learn(trainingSet, trainingCycles);

            ShowMap();
            SaveSOMResult(initialLearningRate);
            EnableAllTabPages();
        }

        /// <summary>
        /// Vrátí délku pauzy mezi vizualizačními kroky podle nastavené rychlosti.
        /// </summary>
        private int GetTspSomVisualizationPause()
        {
            return trkTspSomVisualizationSpeed.Value switch
            {
                0 => 128,
                1 => 64,
                2 => 32,
                3 => 16,
                _ => 0
            };
        }

        /// <summary>
        /// Vykreslí aktuální polohu měst a neuronů tvořících kruhovou SOM mapu.
        /// </summary>
        private void ShowMap()
        {
            if (network == null)
            {
                return;
            }

            double[] xVal = new double[neuronCount + 1];
            double[] yVal = new double[neuronCount + 1];

            for (int i = 0; i < neuronCount; i++)
            {
                IList<ISynapse> synapses = ((KohonenLayer)network.OutputLayer)[i].SourceSynapses;
                xVal[i] = synapses[0].Weight;
                yVal[i] = synapses[1].Weight;
            }
            xVal[neuronCount] = xVal[0];
            yVal[neuronCount] = yVal[0];

            GraphPane pane = zedTspSomCitiesGraph.GraphPane;
            pane.CurveList.Clear();

            // Zobrazíme města jako samostatné body.
            LineItem lineItem = zedTspSomCitiesGraph.GraphPane.AddCurve("", xValues, yValues, tspSomMapColor, SymbolType.Circle);
            lineItem.Line.IsVisible = false;
            lineItem.Symbol.Fill.Type = FillType.Solid;
            lineItem.Symbol.Size = tspSomCityMarkerSize;

            // Výstupní neurony vykreslíme jako křivku, která aproximuje výslednou trasu.
            lineItem = zedTspSomCitiesGraph.GraphPane.AddCurve("", xVal, yVal, tspSomMapColor, SymbolType.None);

            zedTspSomCitiesGraph.Refresh();
        }

        /// <summary>
        /// Spočítá srovnatelné metriky SOM řešení a uloží je do CSV.
        /// </summary>
        private void SaveSOMResult(double initialLearningRate)
        {
            string csvFile = "salesman_som.csv";
            var route = GetSOMRoute();
            double routeDistance = CalculateSOMRouteDistance(route, closedRoute: true);
            double averageError = CalculateSOMAverageError();

            SalesmanSOMResults salesmanSOMResults = new SalesmanSOMResults();
            salesmanSOMResults.Solution = FormatSOMRoute(route, closedRoute: true);
            salesmanSOMResults.RouteDistance = routeDistance;
            salesmanSOMResults.CalculationTime = FormatTime(calculationStopwatch.Elapsed);
            salesmanSOMResults.CalculationSeconds = calculationStopwatch.Elapsed.TotalSeconds;
            salesmanSOMResults.RunStatus = tspSomInterrupted ? "INT" : "OK";
            salesmanSOMResults.CitiesCount = citiesCount;
            salesmanSOMResults.NeuronCount = neuronCount;
            salesmanSOMResults.TrainingCycles = trainingCycles;
            salesmanSOMResults.InitialLearningRate = initialLearningRate;
            salesmanSOMResults.FinalLearningRate = TspSomFinalLearningRate;
            salesmanSOMResults.AverageError = averageError;
            salesmanSOMResults.DistanceMetric = "Euclidean 2D";
            salesmanSOMResults.ClosedRoute = true;

            ResultSaver.SaveResultToCSV(csvFile, salesmanSOMResults);
            ShowInfoMessage($"Hotovo.\nVýsledek byl zaznamenán do souboru: {csvFile}");
        }

        /// <summary>
        /// Odvodí pořadí měst podle nejbližších neuronů na kruhové SOM mapě.
        /// </summary>
        private List<int> GetSOMRoute()
        {
            // Trasu odvodíme seřazením měst podle indexu nejbližšího neuronu na kruhové SOM mapě.
            var route = Enumerable.Range(0, citiesCount)
                                  .Select(cityIndex => new
                                  {
                                      CityIndex = cityIndex,
                                      NeuronIndex = FindNearestNeuronIndex(xValues[cityIndex], yValues[cityIndex])
                                  })
                                  .OrderBy(item => item.NeuronIndex)
                                  .ThenBy(item => item.CityIndex)
                                  .Select(item => item.CityIndex)
                                  .ToList();

            return route;
        }

        /// <summary>
        /// Najde index výstupního neuronu, který je nejblíže zadanému bodu v mapě.
        /// </summary>
        private int FindNearestNeuronIndex(double x, double y)
        {
            int nearestNeuronIndex = 0;
            double nearestDistance = double.MaxValue;

            for (int i = 0; i < neuronCount; i++)
            {
                IList<ISynapse> synapses = ((KohonenLayer)network.OutputLayer)[i].SourceSynapses;
                double distance = GetEuclideanDistance(x, y, synapses[0].Weight, synapses[1].Weight);

                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestNeuronIndex = i;
                }
            }

            return nearestNeuronIndex;
        }

        /// <summary>
        /// Spočítá délku výsledné trasy v rastru, ve kterém byla SOM úloha trénována.
        /// </summary>
        private double CalculateSOMRouteDistance(List<int> route, bool closedRoute)
        {
            double distance = 0.0;

            for (int i = 1; i < route.Count; i++)
            {
                distance += GetCityDistance(route[i - 1], route[i]);
            }

            // SOMA vytváří kruhovou mapu, proto pro výslednou TSP trasu započítáme i návrat do výchozího města.
            if (closedRoute && route.Count > 1)
            {
                distance += GetCityDistance(route[^1], route[0]);
            }

            return distance;
        }

        /// <summary>
        /// Spočítá eukleidovskou vzdálenost mezi dvěma městy podle jejich indexů.
        /// </summary>
        private double GetCityDistance(int firstCityIndex, int secondCityIndex)
        {
            return GetEuclideanDistance(xValues[firstCityIndex], yValues[firstCityIndex],
                                        xValues[secondCityIndex], yValues[secondCityIndex]);
        }

        /// <summary>
        /// Spočítá eukleidovskou vzdálenost dvou bodů v rovině.
        /// </summary>
        private static double GetEuclideanDistance(double x1, double y1, double x2, double y2)
        {
            double dx = x1 - x2;
            double dy = y1 - y2;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        /// <summary>
        /// Spočítá průměrnou vzdálenost měst od jejich nejbližších neuronů.
        /// </summary>
        private double CalculateSOMAverageError()
        {
            double totalError = 0.0;

            for (int i = 0; i < citiesCount; i++)
            {
                int nearestNeuronIndex = FindNearestNeuronIndex(xValues[i], yValues[i]);
                IList<ISynapse> synapses = ((KohonenLayer)network.OutputLayer)[nearestNeuronIndex].SourceSynapses;
                totalError += GetEuclideanDistance(xValues[i], yValues[i], synapses[0].Weight, synapses[1].Weight);
            }

            return totalError / citiesCount;
        }

        /// <summary>
        /// Připraví textový zápis trasy podle indexů a souřadnic vygenerovaných měst.
        /// </summary>
        private string FormatSOMRoute(List<int> route, bool closedRoute)
        {
            var points = route.Select(cityIndex => $"#{cityIndex + 1} ({xValues[cityIndex]:F0}; {yValues[cityIndex]:F0})").ToList();

            if (closedRoute && route.Count > 0)
            {
                int firstCityIndex = route[0];
                points.Add($"#{firstCityIndex + 1} ({xValues[firstCityIndex]:F0}; {yValues[firstCityIndex]:F0})");
            }

            return string.Join(" ---> ", points);
        }

        /// <summary>
        /// Vygeneruje novou sadu měst a z ní trénovací množinu pro Kohonenovu síť.
        /// </summary>
        private void RandomizeSOMCities()
        {
            citiesCount = (int)nuTspSomCitiesCount.Value;

            // Pro SOM se běžně používá více neuronů než měst, aby měla kruhová mapa prostor se vytvarovat.
            neuronCount = 2 * citiesCount;

            xValues = new double[citiesCount];
            yValues = new double[citiesCount];

            trainingSet = new TrainingSet(2);
            for (int i = 0; i < citiesCount; i++)
            {
                xValues[i] = randomGenerator.Next(1, 99);
                yValues[i] = randomGenerator.Next(1, 99);
                trainingSet.Add(new TrainingSample(new double[] { xValues[i], yValues[i] }));
            }

            zedTspSomCitiesGraph.GraphPane.CurveList.Clear();
            // Zobrazíme nově vygenerovaná města jako body v mapě.
            LineItem lineItem = zedTspSomCitiesGraph.GraphPane.AddCurve("", xValues, yValues, tspSomMapColor, SymbolType.Circle);
            lineItem.Line.IsVisible = false;
            lineItem.Symbol.Fill.Type = FillType.Solid;
            lineItem.Symbol.Size = tspSomCityMarkerSize;
            zedTspSomCitiesGraph.Refresh();
        }

        private void LoadSOMForm()
        {
            GraphPane pane = zedTspSomCitiesGraph.GraphPane;
            pane.XAxis.Title.IsVisible = false;
            pane.YAxis.Title.IsVisible = false;
            pane.Legend.IsVisible = false;
            pane.Chart.Fill = new Fill(System.Drawing.Color.Linen, System.Drawing.Color.MintCream, -45F);
            pane.CurveList.Clear();
            pane.XAxis.Scale.Min = 0;
            pane.XAxis.Scale.Max = 100;
            pane.YAxis.Scale.Min = 0;
            pane.YAxis.Scale.Max = 100;
            pane.Title.Text = "Mapa obchodního cestujícího";
            pane.XAxis.MajorTic.IsOutside = false;
            pane.XAxis.MinorTic.IsOutside = false;
            pane.YAxis.MajorTic.IsOutside = false;
            pane.YAxis.MinorTic.IsOutside = false;
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.IsVisible = true;
            pane.XAxis.MajorGrid.Color = System.Drawing.Color.LightGray;
            pane.YAxis.MajorGrid.Color = System.Drawing.Color.LightGray;
            zedTspSomCitiesGraph.AxisChange();

            formsPlotTspSomError.Plot.XLabel("Tréninkových cyklů / epoch");
            formsPlotTspSomError.Plot.YLabel("Chyba");
            formsPlotTspSomError.Plot.Axes.Left.Label.FontSize = 14;
            formsPlotTspSomError.Refresh();
            formsPlotTspSomError.Menu?.Clear();

            RandomizeSOMCities();
        }

        private void StopTraining()
        {
            if (network != null)
            {
                network.StopLearning();
                ShowMap();
            }
            EnableAllTabPages();
        }

        private void btnTspSomRandomizeMap_Click(object sender, EventArgs e)
        {
            if (!ValidateTspSomCitiesCount())
                return;

            RandomizeSOMCities();
        }

        private void btnTspSomRun_Click(object sender, EventArgs e)
        {
            if (!ValidateTspSomInputs())
                return;

            btnTspSomRun.Enabled = false;
            btnTspSomStop.Enabled = true;
            zedTspSomCitiesGraph.Refresh();

            formsPlotTspSomError.Plot.Clear();
            double maxX = Convert.ToDouble(nuTspSomTrainingCycles.Value);  // epoch

            // Graf chyby připravíme před tréninkem, samotný rozsah osy Y nastaví první epocha podle naměřené chyby.
            formsPlotTspSomError.Plot.Axes.SetLimitsX(0, maxX);
            formsPlotTspSomError.Plot.Axes.Margins(0, 0);

            // Pro větší počet epoch zkracujeme popisky osy X na hodnoty typu 10k nebo 1M.
            double minX = 0;
            double range = maxX - minX;
            Func<double, string> labelFormatter = value =>
            {
                if (value >= 1000000)
                    return (value / 1000000).ToString("0.##") + "M";
                else if (value >= 1000)
                    return (value / 1000).ToString("0.##") + "k";
                else
                    return value.ToString("0");
            };

            double tickSpacing = range / 10;
            List<double> ticks = new List<double>();
            for (double tick = Math.Ceiling(minX / tickSpacing) * tickSpacing; tick <= maxX; tick += tickSpacing)
            {
                ticks.Add(tick);
            }

            string[] labels = ticks.Select(t => labelFormatter(t)).ToArray();
            formsPlotTspSomError.Plot.Axes.Bottom.SetTicks(ticks.ToArray(), labels);

            gbTspSomParameters.Enabled = false;
            tspSomInterrupted = false;
            calculationStopwatch.Restart();
            SolveSOM();
            btnTspSomRun.Enabled = true;
            btnTspSomStop.Enabled = false;
            calculationStopwatch.Stop();
            gbTspSomParameters.Enabled = true;
        }

        private void btnTspSomStop_Click(object sender, EventArgs e)
        {
            tspSomInterrupted = true;
            StopTraining();
            calculationStopwatch.Stop();
            gbTspSomParameters.Enabled = true;
            btnTspSomRun.Enabled = true;
            btnTspSomStop.Enabled = false;
        }

        private void tabControlMain_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!taskRunning)
                return;
            e.Cancel = true;
        }

        private void chkTspSomShowVisualization_Click(object sender, EventArgs e)
        {
            showVisualization = chkTspSomShowVisualization.Checked;
            trkTspSomVisualizationSpeed.Enabled = showVisualization;
        }

    }
}
