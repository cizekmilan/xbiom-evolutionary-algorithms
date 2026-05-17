using GAF;
using XBIOM.Algorithms.Tsp;

namespace XBIOM.Tests;

public class TspGaProblemTests
{
    [Fact]
    public void CalculateDistance_SumsOpenRouteDistance()
    {
        City first = new("A", 0, 0);
        City second = new("B", 0, 1);
        City third = new("C", 1, 1);
        Chromosome chromosome = CreateChromosome(first, second, third);

        double expectedDistance =
            first.GetDistanceFromPosition(second.Latitude, second.Longitude) +
            second.GetDistanceFromPosition(third.Latitude, third.Longitude);

        double distance = TspGaProblem.CalculateDistance(chromosome);

        Assert.Equal(expectedDistance, distance, precision: 10);
    }

    [Fact]
    public void CalculateFitness_ConvertsRouteDistanceToMaximizedFitness()
    {
        City first = new("A", 0, 0);
        City second = new("B", 0, 1);
        Chromosome chromosome = CreateChromosome(first, second);
        double distance = TspGaProblem.CalculateDistance(chromosome);

        double fitness = TspGaProblem.CalculateFitness(chromosome);

        Assert.Equal(1 - distance / 10000, fitness, precision: 10);
    }

    [Fact]
    public void FormatRoute_JoinsCityNamesInChromosomeOrder()
    {
        Chromosome chromosome = CreateChromosome(
            new City("A", 0, 0),
            new City("B", 0, 1),
            new City("C", 1, 1));

        string route = TspGaProblem.FormatRoute(chromosome);

        Assert.Equal("A ---> B ---> C", route);
    }

    private static Chromosome CreateChromosome(params City[] cities)
    {
        Chromosome chromosome = new();
        foreach (City city in cities)
        {
            chromosome.Genes.Add(new Gene(city));
        }

        return chromosome;
    }
}
