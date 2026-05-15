namespace XBIOM.Algorithms.SymbolicRegression
{
    /// <summary>
    /// Operace, které může jeden gen symbolické regrese přidat do výsledného předpisu funkce.
    /// </summary>
    public enum SymbolicRegressionOperation
    {
        Add,
        AddX,
        Subtract,
        SubtractX,
        Multiply,
        MultiplyX,
        Sine,
        Cosine,
        Exp,
        Abs
    }

    /// <summary>
    /// Jeden krok ve výsledném předpisu symbolické regrese: operace a její číselná konstanta.
    /// </summary>
    public class SymbolicRegressionGene
    {
        /// <summary>
        /// Vytvoří gen s vybranou operací a hodnotou používanou touto operací.
        /// </summary>
        public SymbolicRegressionGene(SymbolicRegressionOperation operation, double value)
        {
            Operation = operation;
            Value = value;
        }

        public SymbolicRegressionOperation Operation { get; set; }
        public double Value { get; set; }

        /// <summary>
        /// Vytvoří nezávislou kopii genu pro křížení, mutaci a elitismus.
        /// </summary>
        public SymbolicRegressionGene Clone()
        {
            return new SymbolicRegressionGene(Operation, Value);
        }
    }
}
