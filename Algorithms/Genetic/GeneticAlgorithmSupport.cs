using GAF;
using GAF.Operators;
using static GAF.GeneticAlgorithm;

namespace XBIOM.Algorithms.Genetic
{
    /// <summary>
    /// Seskupuje operátory genetického algoritmu používané knihovnou GAF.
    /// </summary>
    public class GeneticAlgorithmParameters
    {
        public Crossover Crossover { get; private set; }
        public SwapMutate Mutate { get; private set; }
        public Elite Elite { get; private set; }

        /// <summary>
        /// Vytvoří výchozí nastavení křížení, mutace a elitismu.
        /// </summary>
        public GeneticAlgorithmParameters()
        {
            Crossover = new Crossover(0.8, false, CrossoverType.DoublePointOrdered);
            Mutate = new SwapMutate(0.05);
            Elite = new Elite(5);
        }

        /// <summary>
        /// Vytvoří nastavení genetického algoritmu z konkrétních operátorů.
        /// </summary>
        public GeneticAlgorithmParameters(Crossover crossover, SwapMutate mutate, Elite elite)
        {
            Crossover = crossover;
            Mutate = mutate;
            Elite = elite;
        }
    }

    /// <summary>
    /// Zapouzdřuje společné spuštění genetického algoritmu nad připravenou populací a handlery z UI.
    /// </summary>
    public class GeneticAlgorithmSupport
    {
        private readonly GeneticAlgorithmParameters gaParameters;
        private readonly Population initialPopulation;
        private readonly FitnessFunction fitnessFunction;
        private readonly GenerationCompleteHandler onGenerationComplete;
        private readonly RunCompleteHandler onRunComplete;
        private readonly TerminateFunction terminateFunction;
        private readonly RunExceptionHandler onRunException;

        /// <summary>
        /// Připraví běh genetického algoritmu včetně fitness funkce a událostí pro průběh výpočtu.
        /// </summary>
        public GeneticAlgorithmSupport(GeneticAlgorithmParameters gaParameters, Population initialPopulation, FitnessFunction fitnessFunction,
                                       GenerationCompleteHandler onGenerationComplete, RunCompleteHandler onRunComplete,
                                       RunExceptionHandler onRunException, TerminateFunction terminateFunction)
        {
            this.gaParameters = gaParameters;
            this.initialPopulation = initialPopulation;
            this.fitnessFunction = fitnessFunction;
            this.onGenerationComplete = onGenerationComplete;
            this.onRunComplete = onRunComplete;
            this.terminateFunction = terminateFunction;
            this.onRunException = onRunException;
        }

        /// <summary>
        /// Sestaví instanci GAF, připojí operátory a spustí evoluci do splnění ukončovací podmínky.
        /// </summary>
        public void Run()
        {
            var ga = new GeneticAlgorithm(initialPopulation, fitnessFunction);
            ga.OnGenerationComplete += onGenerationComplete;
            ga.OnRunComplete += onRunComplete;
            ga.OnRunException += onRunException;
            ga.Operators.Add(gaParameters.Elite);
            ga.Operators.Add(gaParameters.Crossover);
            ga.Operators.Add(gaParameters.Mutate);

            ga.Run(terminateFunction);
        }
    }
}
