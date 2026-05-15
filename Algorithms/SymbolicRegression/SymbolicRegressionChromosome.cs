using Math = System.Math;

namespace XBIOM.Algorithms.SymbolicRegression
{
    /// <summary>
    /// Kandidátní řešení symbolické regrese složené z posloupnosti jednoduchých operací.
    /// </summary>
    public class SymbolicRegressionChromosome
    {
        public List<SymbolicRegressionGene> Genes { get; set; } = new();

        /// <summary>
        /// Naplní chromozom náhodnými geny požadované délky.
        /// </summary>
        // Délka chromozomu odpovídá počtu operací ve výsledném předpisu funkce.
        public void GenerateParent(int length)
        {
            Genes = new List<SymbolicRegressionGene>();
            for (int i = 0; i < length; i++)
            {
                Genes.Add(GenerateGene());
            }
        }
        /// <summary>
        /// Vytvoří hlubokou kopii chromozomu včetně kopií jednotlivých genů.
        /// </summary>
        public SymbolicRegressionChromosome Clone()
        {
            SymbolicRegressionChromosome chromosome = new SymbolicRegressionChromosome();
            chromosome.Genes = new List<SymbolicRegressionGene>();
            foreach (SymbolicRegressionGene g in Genes)
                chromosome.Genes.Add(g.Clone());
            return chromosome;
        }

        /// <summary>
        /// Vygeneruje náhodný gen z dostupné množiny operací.
        /// </summary>
        public SymbolicRegressionGene GenerateGene()
        {
            int genesetCount = Enum.GetNames(typeof(SymbolicRegressionOperation)).Length;

            // Gen se skládá z náhodně vybrané operace a konstanty používané danou operací.
            double geneValue = Random.Shared.NextDouble() * 2;
            SymbolicRegressionOperation geneset = (SymbolicRegressionOperation)Random.Shared.Next(0, genesetCount);
            return new SymbolicRegressionGene(geneset, geneValue);
        }

        /// <summary>
        /// Náhodně nahradí jednotlivé geny podle pravděpodobnosti mutace a vrátí jejich počet.
        /// </summary>
        public int Mutate(double mutationProbability)
        {
            int mutatedGenes = 0;

            // Každý gen má vlastní šanci na mutaci.
            for (int index = 0; index < Genes.Count; index++)
            {
                if (Random.Shared.NextDouble() < mutationProbability)
                {
                    Genes[index] = GenerateGene();
                    mutatedGenes++;
                }
            }

            return mutatedGenes;
        }

        /// <summary>
        /// Vytvoří potomka jednobodovým křížením aktuálního chromozomu s druhým rodičem.
        /// </summary>
        public SymbolicRegressionChromosome Crossover(SymbolicRegressionChromosome secondParent)
        {
            int chromosomeLength = Math.Min(Genes.Count, secondParent.Genes.Count);
            if (chromosomeLength < 2) return Clone();

            int splitIndex = Random.Shared.Next(1, chromosomeLength);
            SymbolicRegressionChromosome child = new SymbolicRegressionChromosome();

            for (int i = 0; i < chromosomeLength; i++)
            {
                SymbolicRegressionGene gene = i < splitIndex ? Genes[i] : secondParent.Genes[i];
                child.Genes.Add(gene.Clone());
            }

            return child;
        }

        /// <summary>
        /// Spočítá součet absolutních odchylek kandidátní funkce od trénovacích hodnot.
        /// </summary>
        public double GetError(List<Tuple<double, double>> lineValues)
        {
            double error = 0;
            foreach (var item in lineValues)
            {
                double y = SymbolicRegressionEvaluator.Compute(Genes, item.Item1);
                if (double.IsNaN(y) || double.IsInfinity(y)) return double.MaxValue;

                error += Math.Abs(item.Item2 - y);
                if (double.IsNaN(error) || double.IsInfinity(error)) return double.MaxValue;
            }
            return error;
        }

        /// <summary>
        /// Spočítá průměrnou absolutní chybu, aby bylo možné porovnávat běhy s různým počtem bodů.
        /// </summary>
        public double GetMeanAbsoluteError(List<Tuple<double, double>> lineValues)
        {
            if (lineValues.Count == 0) return double.MaxValue;
            return GetError(lineValues) / lineValues.Count;
        }

        /// <summary>
        /// Vrátí orientační skóre složitosti výsledné rovnice podle typů použitých operací.
        /// </summary>
        public int GetComplexityScore()
        {
            int complexity = 0;

            // Nelineární operace mají vyšší váhu, protože zvyšují složitost a horší čitelnost výsledné rovnice.
            foreach (SymbolicRegressionGene gene in Genes)
            {
                complexity += gene.Operation switch
                {
                    SymbolicRegressionOperation.Add or SymbolicRegressionOperation.AddX or SymbolicRegressionOperation.Subtract or SymbolicRegressionOperation.SubtractX => 1,
                    SymbolicRegressionOperation.Multiply or SymbolicRegressionOperation.MultiplyX => 2,
                    SymbolicRegressionOperation.Sine or SymbolicRegressionOperation.Cosine or SymbolicRegressionOperation.Abs => 3,
                    SymbolicRegressionOperation.Exp => 4,
                    _ => 1
                };
            }

            return complexity;
        }

        /// <summary>
        /// Sestaví čitelný textový předpis funkce odpovídající posloupnosti genů.
        /// </summary>
        public string Display(string format)
        {
            string result = "";
            // prefix umožňuje použití závorek, které zohledňují pořadí operací v příkazu.
            string prefix = "";
            foreach (SymbolicRegressionGene g in Genes)
            {
                switch (g.Operation)
                {
                    case SymbolicRegressionOperation.Add:
                        result += "+" + g.Value.ToString(format);
                        break;
                    case SymbolicRegressionOperation.AddX:
                        result += "+x";
                        break;
                    case SymbolicRegressionOperation.Subtract:
                        result += "-" + g.Value.ToString(format);
                        break;
                    case SymbolicRegressionOperation.SubtractX:
                        result += "-x";
                        break;
                    case SymbolicRegressionOperation.Multiply:
                        prefix += "(";
                        result += ")*" + g.Value.ToString(format);
                        break;
                    case SymbolicRegressionOperation.MultiplyX:
                        prefix += "(";
                        result += ")*x";
                        break;
                    case SymbolicRegressionOperation.Cosine:
                        result += "+cos((x * " + g.Value.ToString(format) + "))";
                        break;
                    case SymbolicRegressionOperation.Sine:
                        result += "+sin((x * " + g.Value.ToString(format) + "))";
                        break;
                    case SymbolicRegressionOperation.Abs:
                        result += "+abs((x * " + g.Value.ToString(format) + "))";
                        break;
                    case SymbolicRegressionOperation.Exp:
                        result += "+exp((x * " + g.Value.ToString(format) + "))";
                        break;


                    default:
                        break;
                }
            }

            return prefix + "0" + result;
        }
    }
}
