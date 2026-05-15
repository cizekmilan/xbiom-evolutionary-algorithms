using XBIOM.Algorithms.Diophantine;
using XBIOM.Algorithms.Genetic;
using GAF;
using GAF.Operators;

namespace XBIOM
{
    partial class frmMain
    {
        /// <summary>
        /// Průběžná informace o nejlepším kandidátovi v aktuální generaci diofantické úlohy.
        /// </summary>
        private sealed record DiophantineGenerationProgress(
            int Generation,
            double Fitness,
            int A,
            int B,
            int C,
            int D,
            double Result);

        /// <summary>
        /// Výsledek jednoho běhu diofantické úlohy před uložením do UI a CSV.
        /// </summary>
        private sealed record DiophantineRunResult(
            int A,
            int B,
            int C,
            int D,
            double Result,
            double Fitness,
            int ChromosomeLength,
            int GenerationsTotal,
            bool Interrupted);

        private void cbDiophantineUseElites_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDiophantineUseElites.Checked)
            {
                nuDiophantineElitismPercent.Value = 1;
                nuDiophantineElitismPercent.Minimum = 1;
                nuDiophantineElitismPercent.Enabled = true;
            }
            else
            {
                nuDiophantineElitismPercent.Minimum = 0;
                nuDiophantineElitismPercent.Value = 0;
                nuDiophantineElitismPercent.Enabled = false;
            }
        }

        private async void btnDiophantineRun_Click(object sender, EventArgs e)
        {
            if (!ValidateDiophantineInputs())
                return;

            const string csvFile = "diophantine.csv";
            int populationSize = (int)nuDiophantinePopulationSize.Value;
            int maxGenerations = (int)nuDiophantineGenerationCount.Value;
            double crossoverProbability = (double)nuDiophantineCrossoverProbability.Value;
            double mutationProbability = (double)nuDiophantineMutationProbability.Value;
            int elitismPercent = (int)nuDiophantineElitismPercent.Value;
            bool endOnPerfectFitness = cbDiophantineEndOnPerfectFitness.Checked;

            DisableOtherTabPages(tabPageDiophantine);
            diophantineInterrupted = false;
            btnDiophantineRun.Enabled = false;
            btnDiophantineInterrupt.Enabled = true;
            gbDiophantineParameters.Enabled = false;

            dgvDiophantineResults.Rows.Clear();
            dgvDiophantineResults.Refresh();
            pbDiophantineProgress.Maximum = maxGenerations;
            pbDiophantineProgress.Value = 0;
            tbDiophantineResult.Refresh();
            calculationStopwatch.Restart();

            var progress = new Progress<DiophantineGenerationProgress>(progressInfo =>
            {
                dgvDiophantineResults.Rows.Add(new object[] {
                    progressInfo.Generation,
                    progressInfo.Fitness,
                    progressInfo.A,
                    progressInfo.B,
                    progressInfo.C,
                    progressInfo.D,
                    progressInfo.Result
                });

                if (dgvDiophantineResults.Rows.Count < 20)
                    dgvDiophantineResults.Refresh();

                pbDiophantineProgress.Value = System.Math.Min(progressInfo.Generation, pbDiophantineProgress.Maximum);
                lblDiophantineElapsedTime.Text = FormatTime(calculationStopwatch.Elapsed);
                lblDiophantineElapsedTime.Refresh();
            });

            DiophantineRunResult? runResult = null;
            try
            {
                runResult = await Task.Run(() => RunDiophantineGa(
                    populationSize,
                    maxGenerations,
                    crossoverProbability,
                    mutationProbability,
                    elitismPercent,
                    endOnPerfectFitness,
                    progress,
                    () => diophantineInterrupted));
            }
            catch (Exception exc)
            {
                ShowErrorMessage("Výjimka: " + exc.Message);
            }
            finally
            {
                calculationStopwatch.Stop();
                lblDiophantineElapsedTime.Text = FormatTime(calculationStopwatch.Elapsed);
                btnDiophantineRun.Enabled = true;
                btnDiophantineInterrupt.Enabled = false;
                gbDiophantineParameters.Enabled = true;
                EnableAllTabPages();
                diophantineInterrupted = false;
            }

            if (runResult == null)
                return;

            string result = $"a = {runResult.A}, b = {runResult.B}, c = {runResult.C}, d = {runResult.D}";

            DiophantineResults diophantineResults = new();
            diophantineResults.CalculationTime = lblDiophantineElapsedTime.Text;
            diophantineResults.CalculationSeconds = calculationStopwatch.Elapsed.TotalSeconds;
            diophantineResults.RunStatus = runResult.Interrupted ? "INT" : "OK";
            diophantineResults.ChromosomeLength = runResult.ChromosomeLength;
            diophantineResults.PopulationSize = populationSize;
            diophantineResults.GenerationsTotal = runResult.GenerationsTotal;
            diophantineResults.CrossoverProbability = crossoverProbability;
            diophantineResults.MutationProbability = mutationProbability;
            diophantineResults.ElitismPercent = elitismPercent;
            diophantineResults.FitnessValue = runResult.Fitness;
            diophantineResults.A = runResult.A;
            diophantineResults.B = runResult.B;
            diophantineResults.C = runResult.C;
            diophantineResults.D = runResult.D;
            diophantineResults.Result = runResult.Result;

            ResultSaver.SaveResultToCSV(csvFile, diophantineResults);

            if (tbDiophantineResult.TextLength > 0)
                tbDiophantineResult.AppendText(Environment.NewLine);
            tbDiophantineResult.AppendText(result);
            string message = runResult.Interrupted ? "Výpočet byl přerušen." : "Hotovo.";
            ShowInfoMessage($"{message}\nVýsledek byl zaznamenán do souboru: {csvFile}");
        }

        private static DiophantineRunResult RunDiophantineGa(
            int populationSize,
            int maxGenerations,
            double crossoverProbability,
            double mutationProbability,
            int elitismPercent,
            bool endOnPerfectFitness,
            IProgress<DiophantineGenerationProgress> progress,
            Func<bool> shouldInterrupt)
        {
            Population population = DiophantineProblem.PreparePopulation(populationSize);
            Crossover crossover = new(crossoverProbability, true, CrossoverType.SinglePoint);
            SwapMutate mutate = new(mutationProbability);
            Elite elite = new(elitismPercent);
            GeneticAlgorithmParameters gaParameters = new(crossover, mutate, elite);

            DiophantineRunResult? runResult = null;
            string? runExceptionMessage = null;
            int lastGeneration = 0;

            GeneticAlgorithmSupport ga = new(
                gaParameters,
                population,
                DiophantineProblem.CalculateFitness,
                onGenerationComplete: (_, args) =>
                {
                    lastGeneration = args.Generation;
                    Chromosome fittest = args.Population.GetTop(1)[0];
                    DiophantineValues values = DiophantineProblem.GetValues(fittest);
                    progress.Report(new DiophantineGenerationProgress(
                        args.Generation,
                        fittest.Fitness,
                        values.A,
                        values.B,
                        values.C,
                        values.D,
                        DiophantineProblem.EvaluateEquation(values.A, values.B, values.C, values.D)));
                },
                onRunComplete: (_, args) =>
                {
                    runResult = CreateDiophantineRunResult(args.Population, args.Generation, shouldInterrupt());
                },
                onRunException: (_, args) =>
                {
                    runExceptionMessage = args.Message;
                },
                terminateFunction: (currentPopulation, currentGeneration, _) =>
                {
                    bool reachedPerfectFitness = endOnPerfectFitness && currentPopulation.GetTop(1)[0].Fitness == 1;
                    return shouldInterrupt() || currentGeneration >= maxGenerations || reachedPerfectFitness;
                });

            ga.Run();

            if (runExceptionMessage != null)
                throw new InvalidOperationException(runExceptionMessage);

            return runResult ?? CreateDiophantineRunResult(population, lastGeneration, shouldInterrupt());
        }

        private static DiophantineRunResult CreateDiophantineRunResult(Population population, int generation, bool interrupted)
        {
            Chromosome fittest = population.GetTop(1)[0];
            DiophantineValues values = DiophantineProblem.GetValues(fittest);

            return new DiophantineRunResult(
                values.A,
                values.B,
                values.C,
                values.D,
                DiophantineProblem.EvaluateEquation(values.A, values.B, values.C, values.D),
                fittest.Fitness,
                fittest.Genes.Count,
                generation,
                interrupted);
        }

        private void btnDiophantineInterrupt_Click(object sender, EventArgs e)
        {
            diophantineInterrupted = true;
            btnDiophantineInterrupt.Enabled = false;
        }
    }
}
