using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace XBIOM
{
    /// <summary>
    /// Zajišťuje jednotné ukládání výsledků jednotlivých úloh do CSV souborů.
    /// </summary>
    public class ResultSaver
    {
        private const string CsvDelimiter = ";";

        /// <summary>
        /// Určuje pořadí sloupců pro CSV výstup diofantické rovnice.
        /// </summary>
        private sealed class DiophantineResultsMap : ClassMap<DiophantineResults>
        {
            public DiophantineResultsMap()
            {
                Map(result => result.A).Index(0);
                Map(result => result.B).Index(1);
                Map(result => result.C).Index(2);
                Map(result => result.D).Index(3);
                Map(result => result.Result).Index(4);
                Map(result => result.FitnessValue).Index(5);
                Map(result => result.ChromosomeLength).Index(6);
                Map(result => result.PopulationSize).Index(7);
                Map(result => result.GenerationsTotal).Index(8);
                Map(result => result.MutationProbability).Index(9);
                Map(result => result.CrossoverProbability).Index(10);
                Map(result => result.ElitismPercent).Index(11);
                Map(result => result.CalculationTime).Index(12);
                Map(result => result.CalculationSeconds).Index(13);
                Map(result => result.RunStatus).Index(14);
            }
        }

        /// <summary>
        /// Určuje pořadí sloupců pro CSV výstup TSP řešeného genetickým algoritmem.
        /// </summary>
        private sealed class SalesmanGAResultsMap : ClassMap<SalesmanGAResults>
        {
            public SalesmanGAResultsMap()
            {
                Map(result => result.RouteDistance).Index(0);
                Map(result => result.FitnessValue).Index(1);
                Map(result => result.DistanceMetric).Index(2);
                Map(result => result.ClosedRoute).Index(3);
                Map(result => result.ChromosomeLength).Index(4);
                Map(result => result.PopulationSize).Index(5);
                Map(result => result.GenerationsTotal).Index(6);
                Map(result => result.MutationProbability).Index(7);
                Map(result => result.CrossoverProbability).Index(8);
                Map(result => result.ElitismPercent).Index(9);
                Map(result => result.CalculationTime).Index(10);
                Map(result => result.CalculationSeconds).Index(11);
                Map(result => result.RunStatus).Index(12);
            }
        }

        /// <summary>
        /// Určuje pořadí sloupců pro CSV výstup symbolické regrese.
        /// </summary>
        private sealed class SymbolicRegressionResultsMap : ClassMap<SymbolicRegressionResults>
        {
            public SymbolicRegressionResultsMap()
            {
                Map(result => result.Solution).Index(0);
                Map(result => result.FitnessValue).Name("ErrorSumAbs").Index(1);
                Map(result => result.MeanAbsoluteError).Index(2);
                Map(result => result.ComplexityScore).Index(3);
                Map(result => result.ChromosomeLength).Index(4);
                Map(result => result.PopulationSize).Index(5);
                Map(result => result.GenerationsTotal).Index(6);
                Map(result => result.MutationProbability).Index(7);
                Map(result => result.CrossoverProbability).Index(8);
                Map(result => result.ElitismPercent).Index(9);
                Map(result => result.ElitesCount).Index(10);
                Map(result => result.CalculationTime).Index(11);
                Map(result => result.CalculationSeconds).Index(12);
                Map(result => result.RunStatus).Index(13);
            }
        }

        /// <summary>
        /// Určuje pořadí sloupců pro CSV výstup TSP řešeného SOM.
        /// </summary>
        private sealed class SalesmanSOMResultsMap : ClassMap<SalesmanSOMResults>
        {
            public SalesmanSOMResultsMap()
            {
                Map(result => result.RouteDistance).Index(0);
                Map(result => result.AverageError).Index(1);
                Map(result => result.DistanceMetric).Index(2);
                Map(result => result.ClosedRoute).Index(3);
                Map(result => result.CitiesCount).Index(4);
                Map(result => result.NeuronCount).Index(5);
                Map(result => result.TrainingCycles).Index(6);
                Map(result => result.InitialLearningRate).Index(7);
                Map(result => result.FinalLearningRate).Index(8);
                Map(result => result.CalculationTime).Index(9);
                Map(result => result.CalculationSeconds).Index(10);
                Map(result => result.RunStatus).Index(11);
            }
        }

        /// <summary>
        /// Zapíše jeden řádek výsledků do CSV a v případě potřeby vytvoří hlavičku souboru.
        /// </summary>
        private static void SaveResults<TResults, TMap>(string fileName, TResults results)
            where TResults : Results
            where TMap : ClassMap<TResults>, new()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = CsvDelimiter
            };

            bool fileExists = PrepareCsvFile<TResults, TMap>(fileName, config);

            using (var writer = new StreamWriter(fileName, append: true))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.Context.RegisterClassMap<TMap>();

                if (!fileExists)
                {
                    csv.WriteHeader<TResults>();
                    csv.NextRecord();
                }

                csv.WriteRecord(results);
                csv.NextRecord();
            }
        }

        /// <summary>
        /// Zkontroluje existující CSV hlavičku a při změně struktury odloží starý soubor do zálohy.
        /// </summary>
        private static bool PrepareCsvFile<TResults, TMap>(string fileName, CsvConfiguration config)
            where TMap : ClassMap<TResults>, new()
        {
            if (!File.Exists(fileName) || new FileInfo(fileName).Length == 0)
                return false;

            string? currentHeader = File.ReadLines(fileName).FirstOrDefault();
            string expectedHeader = CreateCsvHeader<TResults, TMap>(config);
            if (currentHeader == expectedHeader)
                return true;

            // Pokud se změnila struktura CSV, starý soubor ponecháme jako zálohu a nový založíme s aktuální hlavičkou.
            File.Move(fileName, CreateBackupFileName(fileName));
            return false;
        }

        /// <summary>
        /// Vytvoří očekávanou CSV hlavičku podle mapování pro daný typ výsledků.
        /// </summary>
        private static string CreateCsvHeader<TResults, TMap>(CsvConfiguration config)
            where TMap : ClassMap<TResults>, new()
        {
            using var writer = new StringWriter(CultureInfo.InvariantCulture);
            using var csv = new CsvWriter(writer, config);
            csv.Context.RegisterClassMap<TMap>();
            csv.WriteHeader<TResults>();
            csv.Flush();
            return writer.ToString().TrimEnd('\r', '\n');
        }

        /// <summary>
        /// Sestaví unikátní název záložního CSV souboru se starší strukturou.
        /// </summary>
        private static string CreateBackupFileName(string fileName)
        {
            string directory = Path.GetDirectoryName(fileName) ?? "";
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            string extension = Path.GetExtension(fileName);
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture);
            string backupFileName = Path.Combine(directory, $"{fileNameWithoutExtension}_old_{timestamp}{extension}");
            int counter = 1;

            while (File.Exists(backupFileName))
            {
                backupFileName = Path.Combine(directory, $"{fileNameWithoutExtension}_old_{timestamp}_{counter}{extension}");
                counter++;
            }

            return backupFileName;
        }

        /// <summary>
        /// Uloží výsledek diofantické rovnice do CSV.
        /// </summary>
        public static void SaveResultToCSV(string fileName, DiophantineResults results)
        {
            SaveResults<DiophantineResults, DiophantineResultsMap>(fileName, results);
        }

        /// <summary>
        /// Uloží výsledek TSP řešeného genetickým algoritmem do CSV.
        /// </summary>
        public static void SaveResultToCSV(string fileName, SalesmanGAResults results)
        {
            SaveResults<SalesmanGAResults, SalesmanGAResultsMap>(fileName, results);
        }

        /// <summary>
        /// Uloží výsledek symbolické regrese do CSV.
        /// </summary>
        public static void SaveResultToCSV(string fileName, SymbolicRegressionResults results)
        {
            SaveResults<SymbolicRegressionResults, SymbolicRegressionResultsMap>(fileName, results);
        }

        /// <summary>
        /// Uloží výsledek TSP řešeného SOM do CSV.
        /// </summary>
        public static void SaveResultToCSV(string fileName, SalesmanSOMResults results)
        {
            SaveResults<SalesmanSOMResults, SalesmanSOMResultsMap>(fileName, results);
        }
    }

    /// <summary>
    /// Společné hodnoty, které se ukládají u více typů výpočetních úloh.
    /// </summary>
    public class Results
    {
        public double FitnessValue { get; set; }
        public string? CalculationTime { get; set; }
        public double CalculationSeconds { get; set; }
        public string? RunStatus { get; set; }
        public int ChromosomeLength {  get; set; }
        public int GenerationsTotal { get; set; }
        public double MutationProbability { get; set; }
    }

    /// <summary>
    /// Výsledek jednoho běhu genetického algoritmu pro diofantickou rovnici.
    /// </summary>
    public class DiophantineResults : Results
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int D { get; set; }
        public double Result { get; set; }

        public int PopulationSize { get; set; }
        public int ElitismPercent { get; set; }
        public double CrossoverProbability { get; set; }
    }

    /// <summary>
    /// Výsledek jednoho běhu genetického algoritmu pro úlohu obchodního cestujícího.
    /// </summary>
    public class SalesmanGAResults : Results
    {
        public string? Solution { get; set; } //trasa
        public double RouteDistance { get; set; }
        public string? DistanceMetric { get; set; }
        public bool ClosedRoute { get; set; }
        public int PopulationSize { get; set; }
        public int ElitismPercent { get; set; }
        public double CrossoverProbability { get; set; }
    }

    /// <summary>
    /// Výsledek jednoho běhu SOM varianty úlohy obchodního cestujícího.
    /// </summary>
    public class SalesmanSOMResults : Results
    {
        public string? Solution { get; set; } //trasa
        public double RouteDistance { get; set; }
        public int CitiesCount { get; set; }
        public int NeuronCount { get; set; }
        public int TrainingCycles { get; set; }
        public double InitialLearningRate { get; set; }
        public double FinalLearningRate { get; set; }
        public double AverageError { get; set; }
        public string? DistanceMetric { get; set; }
        public bool ClosedRoute { get; set; }
    }

    /// <summary>
    /// Výsledek jednoho běhu symbolické regrese včetně chyby a složitosti rovnice.
    /// </summary>
    public class SymbolicRegressionResults : Results
    {
        public string? Solution { get; set; } //předpis funkce
        public double MeanAbsoluteError { get; set; }
        public int ComplexityScore { get; set; }
        public int PopulationSize { get; set; }
        public double CrossoverProbability { get; set; }
        public double ElitismPercent { get; set; }
        public int ElitesCount { get; set; }
    }
}
