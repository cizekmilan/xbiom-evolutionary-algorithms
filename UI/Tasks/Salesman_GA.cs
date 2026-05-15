using XBIOM.Algorithms.Genetic;
using XBIOM.Algorithms.Tsp;
using GAF;
using GAF.Operators;

namespace XBIOM
{
    partial class frmMain
    {
        /// <summary>
        /// Průběžná informace o nejlepší trase v aktuální generaci TSP GA.
        /// </summary>
        private sealed record TspGaGenerationProgress(int Generation, double Fitness, double RouteDistance);

        /// <summary>
        /// Výsledek jednoho běhu TSP GA před uložením do UI a CSV.
        /// </summary>
        private sealed record TspGaRunResult(
            string Route,
            double RouteDistance,
            double Fitness,
            int ChromosomeLength,
            int GenerationsTotal,
            bool Interrupted);

        private async void btnTspGaRun_Click(object sender, EventArgs e)
        {
            if (!ValidateTspGaInputs())
                return;

            const string csvFile = "salesman_ga.csv";
            int populationSize = (int)nuTspGaPopulationSize.Value;
            int maxGenerations = (int)nuTspGaGenerationCount.Value;
            double crossoverProbability = (double)nuTspGaCrossoverProbability.Value;
            double mutationProbability = (double)nuTspGaMutationProbability.Value;
            int elitismPercent = (int)nuTspGaElitismPercent.Value;

            DisableOtherTabPages(tabPageTspGa);
            tspGaInterrupted = false;
            btnTspGaRun.Enabled = false;
            btnTspGaInterrupt.Enabled = true;
            gbTspGaParameters.Enabled = false;

            dgvTspGaResults.Rows.Clear();
            dgvTspGaResults.Refresh();
            pbTspGaProgress.Maximum = maxGenerations;
            pbTspGaProgress.Value = 0;
            tbTspGaResult.Text = TspGaProblem.KnownOptimalRouteDescription;
            tbTspGaResult.Refresh();
            calculationStopwatch.Restart();

            var progress = new Progress<TspGaGenerationProgress>(progressInfo =>
            {
                dgvTspGaResults.Rows.Add(new object[] { progressInfo.Generation, progressInfo.Fitness, progressInfo.RouteDistance });
                dgvTspGaResults.CurrentCell = dgvTspGaResults.Rows[dgvTspGaResults.Rows.Count - 1].Cells[0];
                if (dgvTspGaResults.Rows.Count < 20)
                    dgvTspGaResults.Refresh();

                pbTspGaProgress.Value = System.Math.Min(progressInfo.Generation, pbTspGaProgress.Maximum);
                lblTspGaElapsedTime.Text = FormatTime(calculationStopwatch.Elapsed);
                lblTspGaElapsedTime.Refresh();
            });

            TspGaRunResult? runResult = null;
            try
            {
                runResult = await Task.Run(() => RunTspGa(
                    populationSize,
                    maxGenerations,
                    crossoverProbability,
                    mutationProbability,
                    elitismPercent,
                    progress,
                    () => tspGaInterrupted));
            }
            catch (Exception exc)
            {
                ShowErrorMessage("Výjimka: " + exc.Message);
            }
            finally
            {
                calculationStopwatch.Stop();
                lblTspGaElapsedTime.Text = FormatTime(calculationStopwatch.Elapsed);
                btnTspGaRun.Enabled = true;
                btnTspGaInterrupt.Enabled = false;
                gbTspGaParameters.Enabled = true;
                EnableAllTabPages();
                tspGaInterrupted = false;
            }

            if (runResult == null)
                return;

            tbTspGaResult.Text += runResult.Route;
            tbTspGaResult.Text += Environment.NewLine + "Celkem " + runResult.RouteDistance.ToString("0.###") + " km";

            // nejlepší řešení uložíme do souboru
            SalesmanGAResults salesmanResults = new();
            salesmanResults.Solution = runResult.Route;
            salesmanResults.RouteDistance = runResult.RouteDistance;
            salesmanResults.DistanceMetric = "Haversine km";
            salesmanResults.ClosedRoute = false;
            salesmanResults.MutationProbability = mutationProbability;
            salesmanResults.FitnessValue = runResult.Fitness;
            salesmanResults.GenerationsTotal = runResult.GenerationsTotal;
            salesmanResults.CalculationTime = lblTspGaElapsedTime.Text;
            salesmanResults.CalculationSeconds = calculationStopwatch.Elapsed.TotalSeconds;
            salesmanResults.RunStatus = runResult.Interrupted ? "INT" : "OK";
            salesmanResults.ChromosomeLength = runResult.ChromosomeLength;
            salesmanResults.PopulationSize = populationSize;
            salesmanResults.ElitismPercent = elitismPercent;
            salesmanResults.CrossoverProbability = crossoverProbability;
            ResultSaver.SaveResultToCSV(csvFile, salesmanResults);

            string message = runResult.Interrupted ? "Výpočet byl přerušen." : "Hotovo.";
            ShowInfoMessage($"{message}\nNejlepší výsledek byl zaznamenán do souboru: {csvFile}");
        }

        private static TspGaRunResult RunTspGa(
            int populationSize,
            int maxGenerations,
            double crossoverProbability,
            double mutationProbability,
            int elitismPercent,
            IProgress<TspGaGenerationProgress> progress,
            Func<bool> shouldInterrupt)
        {
            Population population = TspGaProblem.PreparePopulation(populationSize);
            Crossover crossover = new(crossoverProbability, false, CrossoverType.DoublePointOrdered);
            SwapMutate mutate = new(mutationProbability);
            Elite elite = new(elitismPercent);
            GeneticAlgorithmParameters gaParameters = new(crossover, mutate, elite);

            TspGaRunResult? runResult = null;
            string? runExceptionMessage = null;
            int lastGeneration = 0;

            GeneticAlgorithmSupport ga = new(
                gaParameters,
                population,
                TspGaProblem.CalculateFitness,
                onGenerationComplete: (_, args) =>
                {
                    lastGeneration = args.Generation;
                    Chromosome fittest = args.Population.GetTop(1)[0];
                    progress.Report(new TspGaGenerationProgress(
                        args.Generation,
                        fittest.Fitness,
                        TspGaProblem.CalculateDistance(fittest)));
                },
                onRunComplete: (_, args) =>
                {
                    runResult = CreateTspGaRunResult(args.Population, args.Generation, shouldInterrupt());
                },
                onRunException: (_, args) =>
                {
                    runExceptionMessage = args.Message;
                },
                terminateFunction: (_, currentGeneration, _) => shouldInterrupt() || currentGeneration >= maxGenerations);

            ga.Run();

            if (runExceptionMessage != null)
                throw new InvalidOperationException(runExceptionMessage);

            return runResult ?? CreateTspGaRunResult(population, lastGeneration, shouldInterrupt());
        }

        private static TspGaRunResult CreateTspGaRunResult(Population population, int generation, bool interrupted)
        {
            Chromosome fittest = population.GetTop(1)[0];
            return new TspGaRunResult(
                TspGaProblem.FormatRoute(fittest),
                TspGaProblem.CalculateDistance(fittest),
                fittest.Fitness,
                fittest.Genes.Count,
                generation,
                interrupted);
        }

        private void cbTspGaUseElites_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTspGaUseElites.Checked)
            {
                nuTspGaElitismPercent.Minimum = 1;
                nuTspGaElitismPercent.Value = 10;
                nuTspGaElitismPercent.Enabled = true;
            }
            else
            {
                nuTspGaElitismPercent.Minimum = 0;
                nuTspGaElitismPercent.Value = 0;
                nuTspGaElitismPercent.Enabled = false;
            }
        }

        private void btnTspGaInterrupt_Click(object sender, EventArgs e)
        {
            tspGaInterrupted = true;
            btnTspGaInterrupt.Enabled = false;
        }
    }
}
