using GAF;

namespace XBIOM.Algorithms.Diophantine
{
    /// <summary>
    /// Hodnoty proměnných a, b, c, d získané z chromozomu diofantické úlohy.
    /// </summary>
    public readonly record struct DiophantineValues(int A, int B, int C, int D);

    /// <summary>
    /// Obsahuje přípravu populace a výpočet fitness pro řešení rovnice genetickým algoritmem.
    /// </summary>
    public static class DiophantineProblem
    {
        /// <summary>
        /// Vytvoří počáteční populaci chromozomů se čtyřmi celočíselnými hodnotami.
        /// </summary>
        public static Population PreparePopulation(int populationSize)
        {
            Population population = new();

            for (int p = 0; p < populationSize; p++)
            {
                Chromosome chromosome = new();

                for (int i = 0; i < 4; i++)
                {
                    int value = Random.Shared.Next(100);
                    chromosome.Genes.Add(new Gene(value));
                }

                population.Solutions.Add(chromosome);
            }

            return population;
        }

        /// <summary>
        /// Přečte z chromozomu hodnoty proměnných a, b, c, d v pořadí jednotlivých genů.
        /// </summary>
        public static DiophantineValues GetValues(Chromosome chromosome)
        {
            return new DiophantineValues(
                (int)chromosome.Genes[0].ObjectValue,
                (int)chromosome.Genes[1].ObjectValue,
                (int)chromosome.Genes[2].ObjectValue,
                (int)chromosome.Genes[3].ObjectValue);
        }

        /// <summary>
        /// Vyhodnotí levou stranu rovnice převedenou do tvaru, kde správné řešení dává nulu.
        /// </summary>
        public static double EvaluateEquation(int a, int b, int c, int d)
        {
            return a + 2 * b + 3 * c + 4 * d - 30;
        }

        /// <summary>
        /// Spočítá fitness podle absolutní odchylky od správného výsledku rovnice.
        /// </summary>
        public static double CalculateFitness(Chromosome chromosome)
        {
            DiophantineValues values = GetValues(chromosome);

            // Čím blíže je rovnice nule, tím vyšší fitness GA dostane.
            return 1 - System.Math.Abs(EvaluateEquation(values.A, values.B, values.C, values.D)) / 10000;
        }
    }
}
