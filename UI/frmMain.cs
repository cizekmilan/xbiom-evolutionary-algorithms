using XBIOM.Algorithms.SymbolicRegression;
using ScottPlot;
using System.Diagnostics;


namespace XBIOM
{
    public partial class frmMain
    {
        Stopwatch calculationStopwatch = new Stopwatch();

        double[] symRegXs = Array.Empty<double>();
        double[] symRegYs = Array.Empty<double>();

        ScottPlot.Plottables.Scatter? symRegScatter;
        ScottPlot.IPlottable? symRegReferenceFunction;
        List<SymbolicRegressionChromosome> symRegSteps = new();  // jednotlivé kroky, každý odpovídá jednomu řádku gridu
        int? symRegDraggedPointIndex = null;
        volatile bool symRegInterrupted = false;
        volatile bool tspGaInterrupted = false;
        volatile bool diophantineInterrupted = false;
        int symRegPointsCount = 5;  // počet uzlových bodů v grafu
        bool symRegPointsCleared = false;
        ScottPlot.Color symRegResultColor = Colors.Magenta;
        List<Tuple<double, double>> symRegData = new List<Tuple<double, double>>();
        Func<double, double> symRegDemoFunction3 = new(x => x * x / 10 - 2 * System.Math.Sin(x));
        Func<double, double> symRegDemoFunction2 = new(x => (6 * System.Math.Sin(x * 0.4) + 0.5) * 0.75);
        Func<double, double> symRegDemoFunction1 = new(x => -(x - 2) * (x - 2) / 8.0 + 9);
        bool taskRunning = false;

        public frmMain()
        {
            InitializeComponent();
            LoadTabIcons();
            SetupCustomContextMenu();
            CreateRandomSymRegPoints();
            LoadSOMForm();
        }

        private void LoadTabIcons()
        {
            imageListTabIcons.Images.Clear();

            AddEmbeddedTabIcon("XBIOM.Resources.TabIcons.neural.png", "neural.png");
            AddEmbeddedTabIcon("XBIOM.Resources.TabIcons.map.png", "map.png");
            AddEmbeddedTabIcon("XBIOM.Resources.TabIcons.function.png", "function.png");
            AddEmbeddedTabIcon("XBIOM.Resources.TabIcons.math.png", "math.png");
        }

        private void AddEmbeddedTabIcon(string resourceName, string imageKey)
        {
            using Stream? stream = typeof(frmMain).Assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
                return;

            // Ikony zůstávají zabalené v aplikaci, ale už nejsou uložené jako binární ImageList stream ve frmMain.resx.
            using System.Drawing.Image sourceImage = System.Drawing.Image.FromStream(stream);
            imageListTabIcons.Images.Add(imageKey, new System.Drawing.Bitmap(sourceImage));
        }

        private bool ValidateCommonGaInputs(string taskName, int populationSize, int maxGenerations,
            double crossoverProbability, double mutationProbability, int elitismPercent)
        {
            if (populationSize < 2)
                return ShowInputValidationError($"{taskName}: populace musí obsahovat alespoň 2 jedince.");

            if (maxGenerations < 1)
                return ShowInputValidationError($"{taskName}: počet generací musí být alespoň 1.");

            if (!IsProbability(crossoverProbability))
                return ShowInputValidationError($"{taskName}: pravděpodobnost křížení musí být v rozsahu 0 až 1.");

            if (!IsProbability(mutationProbability))
                return ShowInputValidationError($"{taskName}: pravděpodobnost mutace musí být v rozsahu 0 až 1.");

            if (elitismPercent < 0 || elitismPercent >= 100)
                return ShowInputValidationError($"{taskName}: elitismus musí být v rozsahu 0 až 99 %.");

            return true;
        }

        private bool ValidateTspGaInputs()
        {
            return ValidateCommonGaInputs(
                "TSP GA",
                (int)nuTspGaPopulationSize.Value,
                (int)nuTspGaGenerationCount.Value,
                (double)nuTspGaCrossoverProbability.Value,
                (double)nuTspGaMutationProbability.Value,
                (int)nuTspGaElitismPercent.Value);
        }

        private bool ValidateDiophantineInputs()
        {
            return ValidateCommonGaInputs(
                "Diofantická rovnice",
                (int)nuDiophantinePopulationSize.Value,
                (int)nuDiophantineGenerationCount.Value,
                (double)nuDiophantineCrossoverProbability.Value,
                (double)nuDiophantineMutationProbability.Value,
                (int)nuDiophantineElitismPercent.Value);
        }

        private bool ValidateSymbolicRegressionInputs()
        {
            int populationSize = (int)nuSymRegPopulationSize.Value;
            int eliteCount = SymbolicRegressionEngine.GetEliteCount(populationSize);

            if (symRegPointsCleared || symRegXs.Length < 2 || symRegYs.Length != symRegXs.Length)
                return ShowInputValidationError("Symbolická regrese: je nutné mít alespoň dva platné uzlové body.");

            if (symRegXs.Any(value => !IsFiniteNumber(value)) || symRegYs.Any(value => !IsFiniteNumber(value)))
                return ShowInputValidationError("Symbolická regrese: souřadnice uzlových bodů musí být konečná čísla.");

            if ((int)nuSymRegChromosomeLength.Value < 1)
                return ShowInputValidationError("Symbolická regrese: délka chromozomu musí být alespoň 1.");

            if ((int)nuSymRegGenerationCount.Value < 1)
                return ShowInputValidationError("Symbolická regrese: počet generací musí být alespoň 1.");

            if (populationSize < SymbolicRegressionEngine.TournamentSize)
                return ShowInputValidationError($"Symbolická regrese: populace musí mít alespoň {SymbolicRegressionEngine.TournamentSize} jedince kvůli turnajovému výběru.");

            if (eliteCount >= populationSize)
                return ShowInputValidationError("Symbolická regrese: počet elit musí být menší než velikost populace.");

            if (!IsProbability((double)nuSymRegCrossoverProbability.Value))
                return ShowInputValidationError("Symbolická regrese: pravděpodobnost křížení musí být v rozsahu 0 až 1.");

            if (!IsProbability((double)nuSymRegMutationProbability.Value))
                return ShowInputValidationError("Symbolická regrese: pravděpodobnost mutace musí být v rozsahu 0 až 1.");

            if (cbSymRegAllowEndOnFitness.Checked && (double)nuSymRegMinFitness.Value < 0)
                return ShowInputValidationError("Symbolická regrese: cílová chyba nesmí být záporná.");

            return true;
        }

        private bool ValidateTspSomInputs()
        {
            int requestedCitiesCount = (int)nuTspSomCitiesCount.Value;
            int requestedTrainingCycles = (int)nuTspSomTrainingCycles.Value;
            double initialLearningRate = (double)nuTspSomInitialLearningRate.Value;

            if (!ValidateTspSomCitiesCount())
                return false;

            if (xValues.Length != requestedCitiesCount || yValues.Length != requestedCitiesCount || trainingSet == null)
                return ShowInputValidationError("TSP SOM: po změně počtu měst nejdříve vygenerujte novou mapu.");

            if (requestedTrainingCycles < 1)
                return ShowInputValidationError("TSP SOM: počet tréninkových cyklů musí být alespoň 1.");

            if (initialLearningRate <= TspSomFinalLearningRate)
                return ShowInputValidationError($"TSP SOM: počáteční learning rate musí být větší než koncová hodnota {TspSomFinalLearningRate:0.###}.");

            return true;
        }

        private bool ValidateTspSomCitiesCount()
        {
            if ((int)nuTspSomCitiesCount.Value < 2)
                return ShowInputValidationError("TSP SOM: mapa musí obsahovat alespoň 2 města.");

            return true;
        }

        private static bool IsProbability(double value)
        {
            return IsFiniteNumber(value) && value >= 0 && value <= 1;
        }

        private static bool IsFiniteNumber(double value)
        {
            return !double.IsNaN(value) && !double.IsInfinity(value);
        }

        private static bool ShowInputValidationError(string message)
        {
            ShowWarningMessage(message, "Neplatné parametry");
            return false;
        }

        private static void ShowInfoMessage(string message)
        {
            MessageBox.Show(message, "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void ShowWarningMessage(string message, string title = "Upozornění")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void DisableOtherTabPages(TabPage currentTabPage)
        {
            foreach (TabPage t in tabControlMain.TabPages)
            {
                if (t != currentTabPage)
                    t.Enabled = false;
            }

            taskRunning = true;
        }

        private void EnableAllTabPages()
        {
            foreach (TabPage t in tabControlMain.TabPages)
                t.Enabled = true;

            taskRunning = false;
        }

        private string FormatTime(TimeSpan elapsed)
        {
            double totalSeconds = elapsed.TotalSeconds;

            if (totalSeconds < 60)
            {
                return $"{totalSeconds:0.###} s";
            }

            int minutes = (int)(totalSeconds / 60);
            double remainingSeconds = totalSeconds % 60;

            if (remainingSeconds == (int)remainingSeconds)
                return $"{minutes} min {(int)remainingSeconds} s";

            return $"{minutes} min {remainingSeconds:0.###} s";
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (taskRunning) e.Cancel = true;
        }

    }
}
