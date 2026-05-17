using XBIOM.Algorithms.SymbolicRegression;

namespace XBIOM.Tests;

public class SymbolicRegressionEvaluatorTests
{
    [Fact]
    public void Compute_AppliesBasicOperationsInOrder()
    {
        List<SymbolicRegressionGene> genes =
        [
            new(SymbolicRegressionOperation.Add, 2),
            new(SymbolicRegressionOperation.AddX, 0),
            new(SymbolicRegressionOperation.Multiply, 3),
            new(SymbolicRegressionOperation.Subtract, 1),
            new(SymbolicRegressionOperation.SubtractX, 0),
        ];

        double result = SymbolicRegressionEvaluator.Compute(genes, x: 4);

        Assert.Equal(13, result, precision: 10);
    }

    [Fact]
    public void Compute_AppliesNonLinearOperations()
    {
        List<SymbolicRegressionGene> genes =
        [
            new(SymbolicRegressionOperation.Sine, Math.PI / 2),
            new(SymbolicRegressionOperation.Cosine, 0),
            new(SymbolicRegressionOperation.Abs, -3),
            new(SymbolicRegressionOperation.Exp, 0),
        ];

        double result = SymbolicRegressionEvaluator.Compute(genes, x: 1);

        Assert.Equal(6, result, precision: 10);
    }
}
