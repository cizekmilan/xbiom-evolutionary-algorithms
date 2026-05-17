using GAF;
using XBIOM.Algorithms.Diophantine;

namespace XBIOM.Tests;

public class DiophantineProblemTests
{
    [Fact]
    public void EvaluateEquation_ReturnsZeroForValidSolution()
    {
        double result = DiophantineProblem.EvaluateEquation(a: 0, b: 1, c: 4, d: 4);

        Assert.Equal(0, result);
    }

    [Fact]
    public void GetValues_ReadsChromosomeGenesInEquationOrder()
    {
        Chromosome chromosome = CreateChromosome(1, 2, 3, 4);

        DiophantineValues values = DiophantineProblem.GetValues(chromosome);

        Assert.Equal(new DiophantineValues(1, 2, 3, 4), values);
    }

    [Fact]
    public void CalculateFitness_ReturnsOneForValidSolution()
    {
        Chromosome chromosome = CreateChromosome(0, 1, 4, 4);

        double fitness = DiophantineProblem.CalculateFitness(chromosome);

        Assert.Equal(1, fitness, precision: 10);
    }

    [Fact]
    public void CalculateFitness_DecreasesWithEquationError()
    {
        Chromosome chromosome = CreateChromosome(0, 0, 0, 0);

        double fitness = DiophantineProblem.CalculateFitness(chromosome);

        Assert.Equal(0.997, fitness, precision: 10);
    }

    private static Chromosome CreateChromosome(params int[] values)
    {
        Chromosome chromosome = new();
        foreach (int value in values)
        {
            chromosome.Genes.Add(new Gene(value));
        }

        return chromosome;
    }
}
