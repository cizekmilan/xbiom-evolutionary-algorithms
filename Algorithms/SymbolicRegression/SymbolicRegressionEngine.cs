namespace XBIOM.Algorithms.SymbolicRegression
{
    /// <summary>
    /// Průběžná informace o nejlepší nalezené aproximaci v konkrétní generaci.
    /// </summary>
    public sealed class SymbolicRegressionGenerationProgress
    {
        /// <summary>
        /// Vytvoří záznam průběhu pro vykreslení a tabulku výsledků.
        /// </summary>
        public SymbolicRegressionGenerationProgress(int generation, SymbolicRegressionChromosome bestChromosome, double bestError)
        {
            Generation = generation;
            BestChromosome = bestChromosome;
            BestError = bestError;
        }

        public int Generation { get; }
        public SymbolicRegressionChromosome BestChromosome { get; }
        public double BestError { get; }
    }

    /// <summary>
    /// Výsledek jednoho běhu symbolické regrese.
    /// </summary>
    public sealed class SymbolicRegressionSearchResult
    {
        /// <summary>
        /// Vytvoří výsledek hledání včetně informace o přerušení uživatelem.
        /// </summary>
        public SymbolicRegressionSearchResult(SymbolicRegressionChromosome bestChromosome, double bestError, int generationsTotal, bool interrupted)
        {
            BestChromosome = bestChromosome;
            BestError = bestError;
            GenerationsTotal = generationsTotal;
            Interrupted = interrupted;
        }

        public SymbolicRegressionChromosome BestChromosome { get; }
        public double BestError { get; }
        public int GenerationsTotal { get; }
        public bool Interrupted { get; }
    }

    /// <summary>
    /// Implementuje vlastní genetický algoritmus pro symbolickou regresi.
    /// </summary>
    public static class SymbolicRegressionEngine
    {
        /// <summary>
        /// Podíl nejlepších jedinců, kteří jsou beze změny převedeni do další generace.
        /// </summary>
        public const double EliteRate = 0.1;

        /// <summary>
        /// Počet náhodných kandidátů porovnávaných při turnajovém výběru rodiče.
        /// </summary>
        public const int TournamentSize = 3;

        /// <summary>
        /// Spustí evoluci symbolické regrese nad trénovacími body a průběžně hlásí nejlepší řešení.
        /// </summary>
        public static SymbolicRegressionSearchResult Run(
            List<Tuple<double, double>> trainingData,
            int chromosomeLength,
            int populationSize,
            int maxGenerations,
            double crossoverProbability,
            double mutationProbability,
            bool stopOnTargetFitness,
            double targetFitness,
            IProgress<SymbolicRegressionGenerationProgress> progress,
            Func<bool> shouldInterrupt)
        {
            int generation = 0;
            int eliteCount = GetEliteCount(populationSize);
            int progressReportInterval = Math.Max(1, maxGenerations / 500);
            List<SymbolicRegressionChromosome> population = CreateInitialPopulation(populationSize, chromosomeLength);
            List<EvaluatedChromosome> evaluatedPopulation = EvaluatePopulation(population, trainingData);
            EvaluatedChromosome best = new(evaluatedPopulation[0].Chromosome.Clone(), evaluatedPopulation[0].Error);
            progress.Report(new SymbolicRegressionGenerationProgress(0, best.Chromosome.Clone(), best.Error));

            if (stopOnTargetFitness && best.Error <= targetFitness)
                return new SymbolicRegressionSearchResult(best.Chromosome.Clone(), best.Error, generation, shouldInterrupt());

            for (generation = 1; generation <= maxGenerations; generation++)
            {
                if (shouldInterrupt()) break;

                List<SymbolicRegressionChromosome> nextPopulation = new(populationSize);

                // Elitismus ponechá část nejlepších jedinců beze změny do další generace.
                for (int i = 0; i < eliteCount && i < evaluatedPopulation.Count; i++)
                {
                    nextPopulation.Add(evaluatedPopulation[i].Chromosome.Clone());
                }

                while (nextPopulation.Count < populationSize)
                {
                    SymbolicRegressionChromosome firstParent = SelectParent(evaluatedPopulation);
                    SymbolicRegressionChromosome secondParent = SelectParent(evaluatedPopulation);

                    SymbolicRegressionChromosome child = Random.Shared.NextDouble() < crossoverProbability
                        ? firstParent.Crossover(secondParent)
                        : firstParent.Clone();

                    child.Mutate(mutationProbability);
                    nextPopulation.Add(child);
                }

                evaluatedPopulation = EvaluatePopulation(nextPopulation, trainingData);
                bool bestImproved = evaluatedPopulation[0].Error < best.Error;
                if (bestImproved)
                    best = new EvaluatedChromosome(evaluatedPopulation[0].Chromosome.Clone(), evaluatedPopulation[0].Error);

                if (bestImproved || generation % progressReportInterval == 0 || generation == maxGenerations)
                    progress.Report(new SymbolicRegressionGenerationProgress(generation, best.Chromosome.Clone(), best.Error));

                if (stopOnTargetFitness && best.Error <= targetFitness) break;
            }

            int generationsTotal = Math.Min(generation, maxGenerations);
            return new SymbolicRegressionSearchResult(best.Chromosome.Clone(), best.Error, generationsTotal, shouldInterrupt());
        }

        /// <summary>
        /// Určí počet elitních jedinců podle velikosti populace.
        /// </summary>
        public static int GetEliteCount(int populationSize)
        {
            return Math.Max(1, (int)Math.Round(populationSize * EliteRate));
        }

        /// <summary>
        /// Vytvoří náhodnou počáteční populaci chromozomů se stejnou délkou.
        /// </summary>
        private static List<SymbolicRegressionChromosome> CreateInitialPopulation(int populationSize, int chromosomeLength)
        {
            List<SymbolicRegressionChromosome> population = new(populationSize);

            for (int i = 0; i < populationSize; i++)
            {
                SymbolicRegressionChromosome chromosome = new();
                chromosome.GenerateParent(chromosomeLength);
                population.Add(chromosome);
            }

            return population;
        }

        /// <summary>
        /// Ohodnotí populaci podle chyby a seřadí ji od nejlepšího jedince.
        /// </summary>
        private static List<EvaluatedChromosome> EvaluatePopulation(IEnumerable<SymbolicRegressionChromosome> population, List<Tuple<double, double>> trainingData)
        {
            return population
                .Select(chromosome => new EvaluatedChromosome(chromosome, chromosome.GetError(trainingData)))
                .OrderBy(chromosome => chromosome.Error)
                .ToList();
        }

        /// <summary>
        /// Vybere rodiče turnajovým výběrem ze seřazené ohodnocené populace.
        /// </summary>
        private static SymbolicRegressionChromosome SelectParent(IReadOnlyList<EvaluatedChromosome> evaluatedPopulation)
        {
            // Turnajový výběr náhodně porovná několik kandidátů a vrátí nejlepšího z nich.
            EvaluatedChromosome best = evaluatedPopulation[Random.Shared.Next(evaluatedPopulation.Count)];

            for (int i = 1; i < TournamentSize; i++)
            {
                EvaluatedChromosome candidate = evaluatedPopulation[Random.Shared.Next(evaluatedPopulation.Count)];
                if (candidate.Error < best.Error)
                    best = candidate;
            }

            return best.Chromosome;
        }

        /// <summary>
        /// Interní dvojice chromozomu a jeho chyby používaná při řazení populace.
        /// </summary>
        private sealed class EvaluatedChromosome
        {
            /// <summary>
            /// Vytvoří ohodnocený chromozom.
            /// </summary>
            public EvaluatedChromosome(SymbolicRegressionChromosome chromosome, double error)
            {
                Chromosome = chromosome;
                Error = error;
            }

            public SymbolicRegressionChromosome Chromosome { get; }
            public double Error { get; }
        }
    }
}
