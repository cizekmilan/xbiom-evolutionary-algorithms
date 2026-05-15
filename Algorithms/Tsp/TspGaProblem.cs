using GAF;
using GAF.Extensions;

namespace XBIOM.Algorithms.Tsp
{
    /// <summary>
    /// Obsahuje datovou přípravu a výpočty pro variantu TSP řešenou genetickým algoritmem.
    /// </summary>
    public static class TspGaProblem
    {
        /// <summary>
        /// Text známého referenčního řešení, se kterým lze orientačně porovnat nejlepší nalezenou trasu.
        /// </summary>
        public const string KnownOptimalRouteDescription =
            "Optimální (známé) řešení: Chvalšiny ---> Č. Krumlov ---> Č. Budějovice ---> Tábor ---> Praha ---> Kolín ---> Pardubice ---> Olomouc ---> Ostrava [446.5 km]\r\n\r\n";

        /// <summary>
        /// Vytvoří počáteční populaci náhodně zamíchaných tras přes všechna definovaná města.
        /// </summary>
        public static Population PreparePopulation(int populationSize)
        {
            List<City> cities = CreateCities();
            Population population = new();

            for (int p = 0; p < populationSize; p++)
            {
                Chromosome chromosome = new();
                foreach (City city in cities)
                {
                    chromosome.Genes.Add(new Gene(city));
                }

                var random = GAF.Threading.RandomProvider.GetThreadRandom();
                chromosome.Genes.ShuffleFast(random);
                population.Solutions.Add(chromosome);
            }

            return population;
        }

        /// <summary>
        /// Převede délku trasy na fitness hodnotu používanou knihovnou GAF.
        /// </summary>
        public static double CalculateFitness(Chromosome chromosome)
        {
            double distanceToTravel = CalculateDistance(chromosome);
            // GAF maximalizuje fitness, proto kratší trasu převádíme na vyšší hodnotu fitness.
            return 1 - distanceToTravel / 10000;
        }

        /// <summary>
        /// Spočítá celkovou délku otevřené trasy v pořadí daném geny chromozomu.
        /// </summary>
        public static double CalculateDistance(Chromosome chromosome)
        {
            double distanceToTravel = 0.0;
            City? previousCity = null;

            // Projdeme města v pořadí daném chromozomem a sečteme délku otevřené trasy.
            foreach (Gene gene in chromosome.Genes)
            {
                City currentCity = (City)gene.ObjectValue;

                if (previousCity != null)
                {
                    distanceToTravel += previousCity.GetDistanceFromPosition(currentCity.Latitude,
                                                                              currentCity.Longitude);
                }

                previousCity = currentCity;
            }

            return distanceToTravel;
        }

        /// <summary>
        /// Vrátí textovou reprezentaci pořadí měst ve výsledné trase.
        /// </summary>
        public static string FormatRoute(Chromosome chromosome)
        {
            return string.Join(" ---> ", chromosome.Genes.Select(gene => ((City)gene.ObjectValue).Name));
        }

        /// <summary>
        /// Vrátí pevnou množinu měst použitou v ukázkové úloze obchodního cestujícího.
        /// Souřadnice jsou GPS hodnoty v desetinných stupních v pořadí latitude, longitude.
        /// </summary>
        private static List<City> CreateCities()
        {
            return new List<City>
            {
                new("Olomouc", 49.593778, 17.250879),
                new("Chvalšiny", 48.854019, 14.211139),
                new("Č. Budějovice", 48.975658, 14.480255),
                new("Tábor", 49.412989, 14.677466),
                new("Č. Krumlov", 48.812735, 14.317466),
                new("Pardubice", 50.034309, 15.781199),
                new("Praha", 50.075538, 14.437800),
                new("Kolín", 50.027329, 15.202728),
                new("Ostrava", 49.820923, 18.262524),
            };
        }
    }
}
