using Math = System.Math;

namespace XBIOM.Algorithms.SymbolicRegression
{
    /// <summary>
    /// Vyhodnocuje chromozom symbolické regrese jako funkci jedné proměnné x.
    /// </summary>
    public class SymbolicRegressionEvaluator
    {
        /// <summary>
        /// Vytvoří evaluator symbolické regrese.
        /// </summary>
        public SymbolicRegressionEvaluator() { }

        /// <summary>
        /// Postupně aplikuje geny na počáteční hodnotu 0 a vrátí výsledné y pro zadané x.
        /// </summary>
        public static double Compute(List<SymbolicRegressionGene> genes, double x)
        {
            double y = 0;

            foreach (SymbolicRegressionGene g in genes)
            {
                switch (g.Operation)
                {
                    case SymbolicRegressionOperation.Add:
                        y += g.Value;
                        break;
                    case SymbolicRegressionOperation.AddX:
                        y += x;
                        break;
                    case SymbolicRegressionOperation.Subtract:
                        y -= g.Value;
                        break;
                    case SymbolicRegressionOperation.SubtractX:
                        y -= x;
                        break;
                    case SymbolicRegressionOperation.Multiply:
                        y *= g.Value;
                        break;
                    case SymbolicRegressionOperation.MultiplyX:
                        y *= x;
                        break;
                    case SymbolicRegressionOperation.Cosine:
                        y += Math.Cos((x * g.Value));
                        break;
                    case SymbolicRegressionOperation.Sine:
                        y += Math.Sin((x * g.Value));
                        break;
                    case SymbolicRegressionOperation.Abs:
                        y += Math.Abs((x * g.Value));
                        break;
                    case SymbolicRegressionOperation.Exp:
                        y += Math.Exp((x * g.Value));
                        break;
                    default:
                        break;
                }
            }

            return y;
        }
    }
}
