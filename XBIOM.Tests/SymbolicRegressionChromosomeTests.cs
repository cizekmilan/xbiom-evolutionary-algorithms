using XBIOM.Algorithms.SymbolicRegression;

namespace XBIOM.Tests;

public class SymbolicRegressionChromosomeTests
{
    [Fact]
    public void GetError_ReturnsZeroForExactLinearExpression()
    {
        SymbolicRegressionChromosome chromosome = new()
        {
            Genes =
            [
                new(SymbolicRegressionOperation.AddX, 0),
            ]
        };
        List<Tuple<double, double>> trainingData =
        [
            Tuple.Create(1.0, 1.0),
            Tuple.Create(2.0, 2.0),
            Tuple.Create(3.0, 3.0),
        ];

        Assert.Equal(0, chromosome.GetError(trainingData), precision: 10);
        Assert.Equal(0, chromosome.GetMeanAbsoluteError(trainingData), precision: 10);
    }

    [Fact]
    public void GetMeanAbsoluteError_ReturnsMaxValueForEmptyTrainingData()
    {
        SymbolicRegressionChromosome chromosome = new()
        {
            Genes =
            [
                new(SymbolicRegressionOperation.AddX, 0),
            ]
        };

        Assert.Equal(double.MaxValue, chromosome.GetMeanAbsoluteError([]));
    }

    [Fact]
    public void GetComplexityScore_UsesConfiguredOperationWeights()
    {
        SymbolicRegressionChromosome chromosome = new()
        {
            Genes =
            [
                new(SymbolicRegressionOperation.Add, 1),
                new(SymbolicRegressionOperation.MultiplyX, 0),
                new(SymbolicRegressionOperation.Sine, 1),
                new(SymbolicRegressionOperation.Exp, 1),
            ]
        };

        Assert.Equal(10, chromosome.GetComplexityScore());
    }

    [Fact]
    public void Clone_CreatesIndependentGeneCopies()
    {
        SymbolicRegressionChromosome chromosome = new()
        {
            Genes =
            [
                new(SymbolicRegressionOperation.Add, 1),
            ]
        };

        SymbolicRegressionChromosome clone = chromosome.Clone();
        clone.Genes[0].Value = 9;

        Assert.Equal(1, chromosome.Genes[0].Value);
        Assert.Equal(9, clone.Genes[0].Value);
        Assert.NotSame(chromosome.Genes[0], clone.Genes[0]);
    }

    [Fact]
    public void Display_FormatsExpressionWithOperationOrderParentheses()
    {
        SymbolicRegressionChromosome chromosome = new()
        {
            Genes =
            [
                new(SymbolicRegressionOperation.Add, 2),
                new(SymbolicRegressionOperation.Multiply, 3),
                new(SymbolicRegressionOperation.AddX, 0),
            ]
        };

        string expression = chromosome.Display("0");

        Assert.Equal("(0+2)*3+x", expression);
    }
}
