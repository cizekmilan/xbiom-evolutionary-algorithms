using ScottPlot;
using ScottPlot.Plottables;
using XBIOM.Algorithms.SymbolicRegression;

namespace XBIOM
{
    partial class frmMain
    {
        private void formsPlotSymReg_MouseDown(object sender, MouseEventArgs e)
        {
            if (symRegScatter == null) return;
            Pixel mousePixel = new(e.Location.X, e.Location.Y);
            Coordinates mouseLocation = formsPlotSymReg.Plot.GetCoordinates(mousePixel);
            DataPoint nearest = symRegScatter.Data.GetNearest(mouseLocation, formsPlotSymReg.Plot.LastRender);
            symRegDraggedPointIndex = nearest.IsReal ? nearest.Index : null;
            if (symRegDraggedPointIndex.HasValue)
                formsPlotSymReg.UserInputProcessor.Disable();
        }

        private void formsPlotSymReg_MouseMove(object sender, MouseEventArgs e)
        {
            if (symRegScatter == null) return;
            Pixel mousePixel = new(e.Location.X, e.Location.Y);
            Coordinates mouseLocation = formsPlotSymReg.Plot.GetCoordinates(mousePixel);
            DataPoint nearest = symRegScatter.Data.GetNearest(mouseLocation, formsPlotSymReg.Plot.LastRender);
            formsPlotSymReg.Cursor = nearest.IsReal ? Cursors.Hand : Cursors.Arrow;

            if (symRegDraggedPointIndex.HasValue)
            {
                ClearSymRegDerivedCurves();
                symRegXs[symRegDraggedPointIndex.Value] = mouseLocation.X;
                symRegYs[symRegDraggedPointIndex.Value] = mouseLocation.Y;
                formsPlotSymReg.Refresh();
            }
        }

        private void formsPlotSymReg_MouseUp(object sender, MouseEventArgs e)
        {
            bool pointWasDragged = symRegDraggedPointIndex.HasValue;
            symRegDraggedPointIndex = null;
            formsPlotSymReg.UserInputProcessor.Enable();
            if (pointWasDragged)
                UpdateSymRegDataFromPoints();
            formsPlotSymReg.Refresh();
        }

        private void ClearSymRegDerivedCurves()
        {
            if (symRegReferenceFunction != null)
            {
                formsPlotSymReg.Plot.Remove(symRegReferenceFunction);
                symRegReferenceFunction = null;
            }

            formsPlotSymReg.Plot.Remove<Scatter>(x => x.Color == symRegResultColor);
        }

        void UpdateSymRegDataFromPoints()
        {
            symRegData.Clear();
            for (int i = 0; i < symRegXs.Length; i += 1)
            {
                symRegData.Add(new Tuple<double, double>(symRegXs[i], symRegYs[i]));
            }
            symRegPointsCleared = false;
        }

        private async void btnSymRegRun_Click(object sender, EventArgs e)
        {
            if (!ValidateSymbolicRegressionInputs())
                return;

            DisableOtherTabPages(tabPageSymReg);
            string csvFile = "symbolic_regression.csv";
            calculationStopwatch.Restart();
            int outputPrecision = (int)nuSymRegOutputPrecision.Value;
            string outputFormat = $"F{outputPrecision}";
            btnSymRegInterrupt.Enabled = true;
            btnSymRegRun.Enabled = false;
            gbSymRegParameters.Enabled = false;
            formsPlotSymReg.Enabled = false;
            tbSymRegResult.Text = "";
            UpdateSymRegDataFromPoints();
            formsPlotSymReg.Plot.Remove<Scatter>(x => x.Color == symRegResultColor);
            dgvSymRegResults.Rows.Clear();
            symRegSteps.Clear();
            formsPlotSymReg.Refresh();
            double targetFitness = (double)nuSymRegMinFitness.Value;
            bool stopOnTargetFitness = cbSymRegAllowEndOnFitness.Checked;
            int chromosomeLength = (int)nuSymRegChromosomeLength.Value;
            int populationSize = (int)nuSymRegPopulationSize.Value;
            int maxGenerations = (int)nuSymRegGenerationCount.Value;
            double mutationProbability = (double)nuSymRegMutationProbability.Value;
            double crossoverProbability = (double)nuSymRegCrossoverProbability.Value;
            int eliteCount = SymbolicRegressionEngine.GetEliteCount(populationSize);
            pbSymRegProgress.Maximum = maxGenerations;
            pbSymRegProgress.Value = 0;
            double lastDisplayedError = double.PositiveInfinity;
            List<Tuple<double, double>> trainingData = symRegData.ToList();

            var progress = new Progress<SymbolicRegressionGenerationProgress>(progressInfo =>
            {
                pbSymRegProgress.Value = Math.Min(progressInfo.Generation, pbSymRegProgress.Maximum);
                lblSymRegElapsedTime.Text = FormatTime(calculationStopwatch.Elapsed);
                lblSymRegElapsedTime.Refresh();

                if (progressInfo.BestError < lastDisplayedError)
                {
                    lastDisplayedError = progressInfo.BestError;
                    symRegSteps.Add(progressInfo.BestChromosome.Clone());
                    // Přidáme nejlepší nalezené řešení včetně jeho složitosti na konec DataGridView a vybereme ho.
                    dgvSymRegResults.Rows.Add([
                        progressInfo.Generation,
                        FormatSymRegError(progressInfo.BestError, outputFormat),
                        progressInfo.BestChromosome.GetComplexityScore()
                    ]);
                    dgvSymRegResults.CurrentCell = dgvSymRegResults.Rows[dgvSymRegResults.Rows.Count - 1].Cells[0];
                }
            });

            SymbolicRegressionSearchResult? searchResult = null;
            try
            {
                searchResult = await Task.Run(() => SymbolicRegressionEngine.Run(
                    trainingData,
                    chromosomeLength,
                    populationSize,
                    maxGenerations,
                    crossoverProbability,
                    mutationProbability,
                    stopOnTargetFitness,
                    targetFitness,
                    progress,
                    () => symRegInterrupted));
            }
            catch (Exception exc)
            {
                ShowErrorMessage("Výjimka: " + exc.Message);
            }
            finally
            {
                calculationStopwatch.Stop();
                lblSymRegElapsedTime.Text = FormatTime(calculationStopwatch.Elapsed);
                symRegInterrupted = false;
                btnSymRegRun.Enabled = true;
                gbSymRegParameters.Enabled = true;
                formsPlotSymReg.Enabled = true;
                btnSymRegInterrupt.Enabled = false;
                EnableAllTabPages();
            }

            if (searchResult == null) return;

            DrawChromosomeResult(searchResult.BestChromosome);

            // Uložení nejlepšího nalezeného řešení a parametrů běhu.
            SymbolicRegressionResults symRegResults = new();
            symRegResults.FitnessValue = searchResult.BestError;
            symRegResults.MeanAbsoluteError = searchResult.BestChromosome.GetMeanAbsoluteError(trainingData);
            symRegResults.ComplexityScore = searchResult.BestChromosome.GetComplexityScore();
            symRegResults.Solution = searchResult.BestChromosome.Display(outputFormat);
            symRegResults.CalculationTime = lblSymRegElapsedTime.Text;
            symRegResults.CalculationSeconds = calculationStopwatch.Elapsed.TotalSeconds;
            symRegResults.RunStatus = searchResult.Interrupted ? "INT" : "OK";
            symRegResults.ChromosomeLength = chromosomeLength;
            symRegResults.MutationProbability = mutationProbability;
            symRegResults.CrossoverProbability = crossoverProbability;
            symRegResults.PopulationSize = populationSize;
            symRegResults.ElitismPercent = SymbolicRegressionEngine.EliteRate * 100;
            symRegResults.ElitesCount = eliteCount;
            symRegResults.GenerationsTotal = searchResult.GenerationsTotal;
            ResultSaver.SaveResultToCSV(csvFile, symRegResults);
            formsPlotSymReg.Refresh();
            tbSymRegResult.Text = searchResult.BestChromosome.Display(outputFormat);
            string message = searchResult.Interrupted ? "Výpočet byl přerušen." : "Hotovo.";
            ShowInfoMessage($"{message}\nVýsledek byl zaznamenán do souboru: {csvFile}");
        }

        private string FormatSymRegError(double error, string outputFormat)
        {
            if (double.IsNaN(error) || double.IsInfinity(error) || error == double.MaxValue)
                return "∞";

            return error.ToString(outputFormat);
        }

        private void CheckMenuItem(ToolStripMenuItem menu, ToolStripMenuItem checkedItem)
        {
            // Položky v submenu se chovají jako radio buttony, aktivní má být vždy jen jedna.
            foreach (ToolStripItem item in menu.DropDownItems)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.Checked = menuItem == checkedItem;
                }
            }
        }

        /// <summary>
        /// Generujeme x od -9 do +9 v rovnoměrném odstupu.
        /// </summary>
        private double[] GenerateSymRegXs()
        {
            double x = -9;
            double[] result = new double[symRegPointsCount];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = x + i * (18.0 / (symRegPointsCount - 1));
            }
            return result;
        }

        void CreateRandomSymRegPoints()
        {
            formsPlotSymReg.Plot.Clear();
            formsPlotSymReg.Plot.Clear<Scatter>();
            formsPlotSymReg.Plot.Clear<Marker>();
            symRegReferenceFunction = null;
            symRegXs = GenerateSymRegXs();
            symRegYs = Generate.RandomSample(symRegPointsCount, -7, 7);

            UpdateSymRegDataFromPoints();

            symRegScatter = formsPlotSymReg.Plot.Add.Scatter(symRegXs, symRegYs);
            symRegScatter.LineWidth = 2;
            symRegScatter.MarkerSize = 10;
            symRegScatter.Smooth = false;
            symRegScatter.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Green);
            symRegScatter.PathStrategy = new ScottPlot.PathStrategies.CubicSpline();
            formsPlotSymReg.Plot.Axes.SetLimits(-10, 10, -10, 10);
            formsPlotSymReg.Refresh();
        }

        private void DisplayDemoFunction(Func<double, double> fnc)
        {
            symRegXs = GenerateSymRegXs();
            symRegYs = new double[symRegPointsCount];
            int i = 0;
            foreach (var x in symRegXs)
            {
                symRegYs[i++] = fnc(x);
            }
            UpdateSymRegDataFromPoints();
            formsPlotSymReg.Plot.Clear();
            symRegReferenceFunction = null;
            symRegScatter = formsPlotSymReg.Plot.Add.Scatter(symRegXs, symRegYs);
            symRegScatter.LineWidth = 2;
            symRegScatter.MarkerSize = 10;
            symRegScatter.Smooth = false;
            symRegScatter.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Green);
            formsPlotSymReg.Plot.Axes.SetLimits(-10, 10, -10, 10);
            var referenceFunction = formsPlotSymReg.Plot.Add.Function(fnc);
            referenceFunction.LineWidth = 2;
            symRegReferenceFunction = referenceFunction;
            formsPlotSymReg.Refresh();
        }

        private void SetupCustomContextMenu()
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            // Náhodně vygenerovaná funkce slouží jako rychlý vstup pro nový běh regrese.
            ToolStripMenuItem randomFunctionItem = new ToolStripMenuItem("Vytvoř náhodnou funkci");
            randomFunctionItem.Click += (s, e) =>
            {
                CreateRandomSymRegPoints();
            };
            menu.Items.Add(randomFunctionItem);

            ToolStripMenuItem demoFunction1 = new ToolStripMenuItem("Demonstrační funkce 1");
            demoFunction1.Click += (s, e) =>
            {
                DisplayDemoFunction(symRegDemoFunction1);
            };
            menu.Items.Add(demoFunction1);
            ToolStripMenuItem demoFunction2 = new ToolStripMenuItem("Demonstrační funkce 2");
            demoFunction2.Click += (s, e) =>
            {
                DisplayDemoFunction(symRegDemoFunction2);
            };
            menu.Items.Add(demoFunction2);
            ToolStripMenuItem demoFunction3 = new ToolStripMenuItem("Demonstrační funkce 3");
            demoFunction3.Click += (s, e) =>
            {
                DisplayDemoFunction(symRegDemoFunction3);
            };
            menu.Items.Add(demoFunction3);

            // Vymazání všech bodů z grafu.
            ToolStripMenuItem clearPlotItem = new ToolStripMenuItem("Odstranit všechny body");
            clearPlotItem.Click += (s, e) =>
            {
                formsPlotSymReg.Plot.Clear();
                symRegScatter = null;
                symRegReferenceFunction = null;
                formsPlotSymReg.Refresh();
                symRegPointsCleared = true;
            };
            menu.Items.Add(clearPlotItem);

            menu.Items.Add(new ToolStripSeparator());

            // Přizpůsobení velikosti a měřítka (automatické škálování)
            ToolStripMenuItem autoScaleItem = new ToolStripMenuItem("Přizpůsobit zobrazení");
            autoScaleItem.Click += (s, e) =>
            {
                formsPlotSymReg.Plot.Axes.AutoScale();
                formsPlotSymReg.Refresh();
            };
            menu.Items.Add(autoScaleItem);

            // Submenu pro změnu stylu propojení
            ToolStripMenuItem plotStyleMenu = new ToolStripMenuItem("Styl propojení (Path strategy)");

            // Lomená čára
            ToolStripMenuItem lineStyleItem = new ToolStripMenuItem("Lomená čára (Polygonal chain)");
            lineStyleItem.Click += (s, e) =>
            {
                // označí jen tuto volbu, ostatní odškrtne (radio button styl)
                CheckMenuItem(plotStyleMenu, lineStyleItem);

                formsPlotSymReg.Plot.Clear();
                symRegReferenceFunction = null;
                symRegScatter = formsPlotSymReg.Plot.Add.Scatter(symRegXs, symRegYs);
                symRegScatter.LineWidth = 2;
                symRegScatter.MarkerSize = 10;
                symRegScatter.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Green);
                symRegScatter.PathStrategy = new ScottPlot.PathStrategies.Straight();
                symRegScatter.Smooth = false;
                formsPlotSymReg.Refresh();
            };

            // Kvadratická polovina bodu
            ToolStripMenuItem quadHalfPointStyleItem = new ToolStripMenuItem("Kvadratické propojení (Quadratic half point)");
            quadHalfPointStyleItem.Click += (s, e) =>
            {
                // označí jen tuto volbu, ostatní odškrtne (radio button styl)
                CheckMenuItem(plotStyleMenu, quadHalfPointStyleItem);

                formsPlotSymReg.Plot.Clear();
                symRegReferenceFunction = null;
                symRegScatter = formsPlotSymReg.Plot.Add.Scatter(symRegXs, symRegYs);
                symRegScatter.LineWidth = 2;
                symRegScatter.MarkerSize = 10;
                symRegScatter.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Green);
                symRegScatter.PathStrategy = new ScottPlot.PathStrategies.QuadHalfPoint();
                formsPlotSymReg.Refresh();
            };

            // Kubický spline
            ToolStripMenuItem cubicSplineStyleItem = new ToolStripMenuItem("Kubický spline (Cubic spline interpolation)");
            cubicSplineStyleItem.Click += (s, e) =>
            {
                // označí jen tuto volbu, ostatní odškrtne (radio button styl)
                CheckMenuItem(plotStyleMenu, cubicSplineStyleItem);

                formsPlotSymReg.Plot.Clear();
                symRegReferenceFunction = null;
                symRegScatter = formsPlotSymReg.Plot.Add.Scatter(symRegXs, symRegYs);
                symRegScatter.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Green);
                symRegScatter.LineWidth = 2;
                symRegScatter.MarkerSize = 10;
                symRegScatter.PathStrategy = new ScottPlot.PathStrategies.CubicSpline();
                formsPlotSymReg.Refresh();
            };

            plotStyleMenu.DropDownItems.Add(lineStyleItem);
            plotStyleMenu.DropDownItems.Add(quadHalfPointStyleItem);
            plotStyleMenu.DropDownItems.Add(cubicSplineStyleItem);

            menu.Items.Add(plotStyleMenu);

            menu.Items.Add(new ToolStripSeparator());

            // Uložit jako obrázek
            ToolStripMenuItem saveAsImageItem = new ToolStripMenuItem("Uložit jako obrázek");
            saveAsImageItem.Click += (s, e) =>
            {
                try
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "PNG Image (.png)|*.png";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        string file = sfd.FileName;

                        if (!string.IsNullOrEmpty(file))
                        {
                            formsPlotSymReg.Plot.SavePng(file, formsPlotSymReg.Width, formsPlotSymReg.Height);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(ex.Message);
                }
            };
            menu.Items.Add(saveAsImageItem);

            // Kopírování do schránky
            ToolStripMenuItem copyToClipboardItem = new ToolStripMenuItem("Kopírovat do schránky");
            copyToClipboardItem.Click += (s, e) =>
            {
                var spImage = formsPlotSymReg.Plot.GetImage(formsPlotSymReg.Width, formsPlotSymReg.Height);
                using var ms = new MemoryStream(spImage.GetImageBytes(ImageFormat.Png));
                using var png = new Bitmap(ms);

                Clipboard.SetImage(png);
            };
            menu.Items.Add(copyToClipboardItem);

            formsPlotSymReg.Menu?.Clear();
            formsPlotSymReg.ContextMenuStrip = menu;
        }

        private void cbSymRegAllowEndOnFitness_CheckedChanged(object sender, EventArgs e)
        {
            nuSymRegMinFitness.Enabled = cbSymRegAllowEndOnFitness.Checked;
        }

        private void nuSymRegPointsCount_ValueChanged(object sender, EventArgs e)
        {
            symRegPointsCount = (int)nuSymRegPointsCount.Value;
        }

        private void DrawChromosomeResult(SymbolicRegressionChromosome chromosome)
        {
            formsPlotSymReg.Plot.Remove<Scatter>(x => x.Color == symRegResultColor);

            List<double> resultXs = new();
            List<double> resultYs = new();
            for (double x = -10; x <= 10; x += 0.05)
            {
                double y = SymbolicRegressionEvaluator.Compute(chromosome.Genes, x);
                if (!double.IsFinite(y))
                    continue;

                resultXs.Add(x);
                resultYs.Add(y);
            }

            if (resultXs.Count > 0)
            {
                var resultLine = formsPlotSymReg.Plot.Add.Scatter(resultXs.ToArray(), resultYs.ToArray());
                resultLine.Color = symRegResultColor;
                resultLine.LineWidth = 2;
                resultLine.MarkerSize = 0;
            }

            formsPlotSymReg.Refresh();
        }

        private void dgvSymRegResults_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SymbolicRegressionChromosome ch = symRegSteps[e.RowIndex];
                DrawChromosomeResult(ch);
                tbSymRegResult.Text = ch.Display($"F{nuSymRegOutputPrecision.Value.ToString()}");
            }
        }

        private void dgvSymRegResults_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var cell = dgvSymRegResults.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "Pro zobrazení daného řešení proveďte dvojité kliknutí.";
            }

        }

        private void btnSymRegInterrupt_Click(object sender, EventArgs e)
        {
            symRegInterrupted = true;
        }
    }
}
