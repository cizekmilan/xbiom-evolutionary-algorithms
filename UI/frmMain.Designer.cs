using System.Resources;

namespace XBIOM
{
    partial class frmMain : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            tabControlMain = new TabControl();
            tabPageTspSom = new TabPage();
            lblTspSomVisualizationSpeed = new Label();
            trkTspSomVisualizationSpeed = new TrackBar();
            chkTspSomShowVisualization = new CheckBox();
            formsPlotTspSomError = new ScottPlot.WinForms.FormsPlot();
            btnTspSomStop = new Button();
            btnTspSomRun = new Button();
            lblTspSomElapsedTimeTitle = new Label();
            pbTspSomTraining = new ProgressBar();
            lblTspSomElapsedTime = new Label();
            gbTspSomParameters = new GroupBox();
            nuTspSomTrainingCycles = new NumericUpDown();
            btnTspSomRandomizeMap = new Button();
            lblTspSomInitialLearningRate = new Label();
            nuTspSomInitialLearningRate = new NumericUpDown();
            nuTspSomCitiesCount = new NumericUpDown();
            lblTspSomTrainingCycles = new Label();
            lblTspSomCitiesCount = new Label();
            panelTspSomDescription = new Panel();
            lblTspSomDescription = new Label();
            zedTspSomCitiesGraph = new ZedGraph.ZedGraphControl();
            tabPageSymReg = new TabPage();
            lblSymRegElapsedTimeTitle = new Label();
            lblSymRegElapsedTime = new Label();
            btnSymRegInterrupt = new Button();
            pbSymRegProgress = new ProgressBar();
            dgvSymRegResults = new DataGridView();
            colSymRegGeneration = new DataGridViewTextBoxColumn();
            colSymRegFitness = new DataGridViewTextBoxColumn();
            colSymRegComplexity = new DataGridViewTextBoxColumn();
            gbSymRegParameters = new GroupBox();
            lblSymRegPopulationSize = new Label();
            nuSymRegPopulationSize = new NumericUpDown();
            lblSymRegCrossoverProbability = new Label();
            nuSymRegCrossoverProbability = new NumericUpDown();
            lblSymRegMutationProbability = new Label();
            nuSymRegMutationProbability = new NumericUpDown();
            nuSymRegPointsCount = new NumericUpDown();
            lblSymRegPointsCount = new Label();
            nuSymRegOutputPrecision = new NumericUpDown();
            lblSymRegOutputPrecision = new Label();
            nuSymRegMinFitness = new NumericUpDown();
            cbSymRegAllowEndOnFitness = new CheckBox();
            lblSymRegGenerationsSuffix = new Label();
            nuSymRegGenerationCount = new NumericUpDown();
            lblSymRegGenerationCount = new Label();
            nuSymRegChromosomeLength = new NumericUpDown();
            lblSymRegChromosomeLength = new Label();
            btnSymRegRun = new Button();
            formsPlotSymReg = new ScottPlot.WinForms.FormsPlot();
            tbSymRegResult = new TextBox();
            panelSymRegDescription = new Panel();
            lblSymRegDescription = new Label();
            tabPageTspGa = new TabPage();
            panelTspGaDescription = new Panel();
            lblTspGaDescription = new Label();
            lblTspGaElapsedTimeTitle = new Label();
            tbTspGaResult = new TextBox();
            pbTspGaProgress = new ProgressBar();
            dgvTspGaResults = new DataGridView();
            colTspGaGeneration = new DataGridViewTextBoxColumn();
            colTspGaFitness = new DataGridViewTextBoxColumn();
            colTspGaDistance = new DataGridViewTextBoxColumn();
            lblTspGaElapsedTime = new Label();
            gbTspGaParameters = new GroupBox();
            cbTspGaUseElites = new CheckBox();
            lblTspGaGenerationsSuffix = new Label();
            lblTspGaElitismPercent = new Label();
            lblTspGaMutationProbability = new Label();
            nuTspGaMutationProbability = new NumericUpDown();
            nuTspGaCrossoverProbability = new NumericUpDown();
            lblTspGaCrossoverProbability = new Label();
            nuTspGaElitismPercent = new NumericUpDown();
            nuTspGaGenerationCount = new NumericUpDown();
            lblTspGaGenerationCount = new Label();
            nuTspGaPopulationSize = new NumericUpDown();
            lblTspGaPopulationSize = new Label();
            btnTspGaRun = new Button();
            btnTspGaInterrupt = new Button();
            tabPageDiophantine = new TabPage();
            panelDiophantineDescription = new Panel();
            lblDiophantineDescription = new Label();
            lblDiophantineElapsedTimeTitle = new Label();
            tbDiophantineResult = new TextBox();
            pbDiophantineProgress = new ProgressBar();
            dgvDiophantineResults = new DataGridView();
            colDiophantineGeneration = new DataGridViewTextBoxColumn();
            colDiophantineFitness = new DataGridViewTextBoxColumn();
            colDiophantineA = new DataGridViewTextBoxColumn();
            colDiophantineB = new DataGridViewTextBoxColumn();
            colDiophantineC = new DataGridViewTextBoxColumn();
            colDiophantineD = new DataGridViewTextBoxColumn();
            colDiophantineResult = new DataGridViewTextBoxColumn();
            lblDiophantineElapsedTime = new Label();
            gbDiophantineParameters = new GroupBox();
            cbDiophantineEndOnPerfectFitness = new CheckBox();
            cbDiophantineUseElites = new CheckBox();
            lblDiophantineGenerationsSuffix = new Label();
            lblDiophantineElitismPercent = new Label();
            lblDiophantineMutationProbability = new Label();
            nuDiophantineMutationProbability = new NumericUpDown();
            nuDiophantineCrossoverProbability = new NumericUpDown();
            lblDiophantineCrossoverProbability = new Label();
            nuDiophantineElitismPercent = new NumericUpDown();
            nuDiophantineGenerationCount = new NumericUpDown();
            lblDiophantineGenerationCount = new Label();
            nuDiophantinePopulationSize = new NumericUpDown();
            lblDiophantinePopulationSize = new Label();
            btnDiophantineRun = new Button();
            btnDiophantineInterrupt = new Button();
            imageListTabIcons = new ImageList(components);
            tabControlMain.SuspendLayout();
            tabPageTspSom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trkTspSomVisualizationSpeed).BeginInit();
            gbTspSomParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nuTspSomTrainingCycles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nuTspSomInitialLearningRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nuTspSomCitiesCount).BeginInit();
            panelTspSomDescription.SuspendLayout();
            tabPageSymReg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSymRegResults).BeginInit();
            gbSymRegParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nuSymRegPopulationSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nuSymRegCrossoverProbability).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nuSymRegMutationProbability).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nuSymRegPointsCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nuSymRegOutputPrecision).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nuSymRegMinFitness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nuSymRegGenerationCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nuSymRegChromosomeLength).BeginInit();
            panelSymRegDescription.SuspendLayout();
            tabPageTspGa.SuspendLayout();
            panelTspGaDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTspGaResults).BeginInit();
            gbTspGaParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nuTspGaMutationProbability).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nuTspGaCrossoverProbability).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nuTspGaElitismPercent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nuTspGaGenerationCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nuTspGaPopulationSize).BeginInit();
            tabPageDiophantine.SuspendLayout();
            panelDiophantineDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDiophantineResults).BeginInit();
            gbDiophantineParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nuDiophantineMutationProbability).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nuDiophantineCrossoverProbability).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nuDiophantineElitismPercent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nuDiophantineGenerationCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nuDiophantinePopulationSize).BeginInit();
            SuspendLayout();
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabPageTspSom);
            tabControlMain.Controls.Add(tabPageSymReg);
            tabControlMain.Controls.Add(tabPageTspGa);
            tabControlMain.Controls.Add(tabPageDiophantine);
            tabControlMain.ImageList = imageListTabIcons;
            tabControlMain.Location = new Point(7, 4);
            tabControlMain.Margin = new Padding(4);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(1144, 568);
            tabControlMain.TabIndex = 0;
            tabControlMain.Selecting += tabControlMain_Selecting;
            // 
            // tabPageTspSom
            // 
            tabPageTspSom.Controls.Add(lblTspSomVisualizationSpeed);
            tabPageTspSom.Controls.Add(trkTspSomVisualizationSpeed);
            tabPageTspSom.Controls.Add(chkTspSomShowVisualization);
            tabPageTspSom.Controls.Add(formsPlotTspSomError);
            tabPageTspSom.Controls.Add(btnTspSomStop);
            tabPageTspSom.Controls.Add(btnTspSomRun);
            tabPageTspSom.Controls.Add(lblTspSomElapsedTimeTitle);
            tabPageTspSom.Controls.Add(pbTspSomTraining);
            tabPageTspSom.Controls.Add(lblTspSomElapsedTime);
            tabPageTspSom.Controls.Add(gbTspSomParameters);
            tabPageTspSom.Controls.Add(panelTspSomDescription);
            tabPageTspSom.Controls.Add(zedTspSomCitiesGraph);
            tabPageTspSom.ImageIndex = 0;
            tabPageTspSom.Location = new Point(4, 24);
            tabPageTspSom.Name = "tabPageTspSom";
            tabPageTspSom.Size = new Size(1136, 540);
            tabPageTspSom.TabIndex = 3;
            tabPageTspSom.Text = "Problém obchodního cestujícího [SOM]";
            tabPageTspSom.UseVisualStyleBackColor = true;
            // 
            // lblTspSomVisualizationSpeed
            // 
            lblTspSomVisualizationSpeed.AutoSize = true;
            lblTspSomVisualizationSpeed.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTspSomVisualizationSpeed.Location = new Point(14, 286);
            lblTspSomVisualizationSpeed.Margin = new Padding(4, 0, 4, 0);
            lblTspSomVisualizationSpeed.Name = "lblTspSomVisualizationSpeed";
            lblTspSomVisualizationSpeed.Size = new Size(51, 13);
            lblTspSomVisualizationSpeed.TabIndex = 38;
            lblTspSomVisualizationSpeed.Text = "Rychlost:";
            // 
            // trkTspSomVisualizationSpeed
            // 
            trkTspSomVisualizationSpeed.BackColor = SystemColors.Window;
            trkTspSomVisualizationSpeed.Location = new Point(79, 286);
            trkTspSomVisualizationSpeed.Maximum = 4;
            trkTspSomVisualizationSpeed.Name = "trkTspSomVisualizationSpeed";
            trkTspSomVisualizationSpeed.Size = new Size(204, 45);
            trkTspSomVisualizationSpeed.TabIndex = 37;
            trkTspSomVisualizationSpeed.Value = 2;
            // 
            // chkTspSomShowVisualization
            // 
            chkTspSomShowVisualization.AutoSize = true;
            chkTspSomShowVisualization.Checked = true;
            chkTspSomShowVisualization.CheckState = CheckState.Checked;
            chkTspSomShowVisualization.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkTspSomShowVisualization.Location = new Point(366, 284);
            chkTspSomShowVisualization.Margin = new Padding(4, 3, 4, 3);
            chkTspSomShowVisualization.Name = "chkTspSomShowVisualization";
            chkTspSomShowVisualization.RightToLeft = RightToLeft.Yes;
            chkTspSomShowVisualization.Size = new Size(126, 17);
            chkTspSomShowVisualization.TabIndex = 36;
            chkTspSomShowVisualization.Text = "Průběžná vizualizace";
            chkTspSomShowVisualization.UseVisualStyleBackColor = true;
            chkTspSomShowVisualization.Click += chkTspSomShowVisualization_Click;
            // 
            // formsPlotTspSomError
            // 
            formsPlotTspSomError.Enabled = false;
            formsPlotTspSomError.Location = new Point(12, 403);
            formsPlotTspSomError.Name = "formsPlotTspSomError";
            formsPlotTspSomError.Size = new Size(498, 132);
            formsPlotTspSomError.TabIndex = 35;
            // 
            // btnTspSomStop
            // 
            btnTspSomStop.Enabled = false;
            btnTspSomStop.Location = new Point(421, 326);
            btnTspSomStop.Name = "btnTspSomStop";
            btnTspSomStop.Size = new Size(88, 28);
            btnTspSomStop.TabIndex = 24;
            btnTspSomStop.Text = "Přerušit";
            btnTspSomStop.UseVisualStyleBackColor = true;
            btnTspSomStop.Click += btnTspSomStop_Click;
            // 
            // btnTspSomRun
            // 
            btnTspSomRun.Location = new Point(326, 326);
            btnTspSomRun.Margin = new Padding(3, 2, 3, 2);
            btnTspSomRun.Name = "btnTspSomRun";
            btnTspSomRun.Size = new Size(88, 28);
            btnTspSomRun.TabIndex = 10;
            btnTspSomRun.Text = "Spustit!";
            btnTspSomRun.UseVisualStyleBackColor = true;
            btnTspSomRun.Click += btnTspSomRun_Click;
            // 
            // lblTspSomElapsedTimeTitle
            // 
            lblTspSomElapsedTimeTitle.AutoSize = true;
            lblTspSomElapsedTimeTitle.Location = new Point(25, 334);
            lblTspSomElapsedTimeTitle.Margin = new Padding(4, 0, 4, 0);
            lblTspSomElapsedTimeTitle.Name = "lblTspSomElapsedTimeTitle";
            lblTspSomElapsedTimeTitle.Size = new Size(77, 15);
            lblTspSomElapsedTimeTitle.TabIndex = 34;
            lblTspSomElapsedTimeTitle.Text = "Uplynulý čas:";
            // 
            // pbTspSomTraining
            // 
            pbTspSomTraining.Location = new Point(14, 370);
            pbTspSomTraining.Margin = new Padding(4);
            pbTspSomTraining.Maximum = 99;
            pbTspSomTraining.Name = "pbTspSomTraining";
            pbTspSomTraining.Size = new Size(495, 26);
            pbTspSomTraining.Style = ProgressBarStyle.Continuous;
            pbTspSomTraining.TabIndex = 32;
            // 
            // lblTspSomElapsedTime
            // 
            lblTspSomElapsedTime.AutoSize = true;
            lblTspSomElapsedTime.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblTspSomElapsedTime.Location = new Point(116, 334);
            lblTspSomElapsedTime.Margin = new Padding(4, 0, 4, 0);
            lblTspSomElapsedTime.Name = "lblTspSomElapsedTime";
            lblTspSomElapsedTime.Size = new Size(55, 16);
            lblTspSomElapsedTime.TabIndex = 33;
            lblTspSomElapsedTime.Text = "0,000 s";
            // 
            // gbTspSomParameters
            // 
            gbTspSomParameters.Controls.Add(nuTspSomTrainingCycles);
            gbTspSomParameters.Controls.Add(btnTspSomRandomizeMap);
            gbTspSomParameters.Controls.Add(lblTspSomInitialLearningRate);
            gbTspSomParameters.Controls.Add(nuTspSomInitialLearningRate);
            gbTspSomParameters.Controls.Add(nuTspSomCitiesCount);
            gbTspSomParameters.Controls.Add(lblTspSomTrainingCycles);
            gbTspSomParameters.Controls.Add(lblTspSomCitiesCount);
            gbTspSomParameters.Location = new Point(14, 154);
            gbTspSomParameters.Margin = new Padding(4);
            gbTspSomParameters.Name = "gbTspSomParameters";
            gbTspSomParameters.Padding = new Padding(4);
            gbTspSomParameters.Size = new Size(496, 113);
            gbTspSomParameters.TabIndex = 30;
            gbTspSomParameters.TabStop = false;
            gbTspSomParameters.Text = " Parametry programu";
            // 
            // nuTspSomTrainingCycles
            // 
            nuTspSomTrainingCycles.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            nuTspSomTrainingCycles.Location = new Point(384, 37);
            nuTspSomTrainingCycles.Margin = new Padding(4);
            nuTspSomTrainingCycles.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nuTspSomTrainingCycles.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            nuTspSomTrainingCycles.Name = "nuTspSomTrainingCycles";
            nuTspSomTrainingCycles.Size = new Size(67, 23);
            nuTspSomTrainingCycles.TabIndex = 14;
            nuTspSomTrainingCycles.Value = new decimal(new int[] { 10000, 0, 0, 0 });
            // 
            // btnTspSomRandomizeMap
            // 
            btnTspSomRandomizeMap.Location = new Point(26, 73);
            btnTspSomRandomizeMap.Margin = new Padding(4, 3, 4, 3);
            btnTspSomRandomizeMap.Name = "btnTspSomRandomizeMap";
            btnTspSomRandomizeMap.Size = new Size(194, 26);
            btnTspSomRandomizeMap.TabIndex = 7;
            btnTspSomRandomizeMap.Text = "Vygenerovat mapu";
            btnTspSomRandomizeMap.UseVisualStyleBackColor = true;
            btnTspSomRandomizeMap.Click += btnTspSomRandomizeMap_Click;
            // 
            // lblTspSomInitialLearningRate
            // 
            lblTspSomInitialLearningRate.AutoSize = true;
            lblTspSomInitialLearningRate.Location = new Point(262, 84);
            lblTspSomInitialLearningRate.Margin = new Padding(4, 0, 4, 0);
            lblTspSomInitialLearningRate.Name = "lblTspSomInitialLearningRate";
            lblTspSomInitialLearningRate.Size = new Size(105, 15);
            lblTspSomInitialLearningRate.TabIndex = 28;
            lblTspSomInitialLearningRate.Text = "Max. learning rate:";
            lblTspSomInitialLearningRate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nuTspSomInitialLearningRate
            // 
            nuTspSomInitialLearningRate.DecimalPlaces = 3;
            nuTspSomInitialLearningRate.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nuTspSomInitialLearningRate.Location = new Point(384, 81);
            nuTspSomInitialLearningRate.Margin = new Padding(4);
            nuTspSomInitialLearningRate.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            nuTspSomInitialLearningRate.Minimum = new decimal(new int[] { 1, 0, 0, 196608 });
            nuTspSomInitialLearningRate.Name = "nuTspSomInitialLearningRate";
            nuTspSomInitialLearningRate.Size = new Size(67, 23);
            nuTspSomInitialLearningRate.TabIndex = 27;
            nuTspSomInitialLearningRate.Value = new decimal(new int[] { 3, 0, 0, 65536 });
            // 
            // nuTspSomCitiesCount
            // 
            nuTspSomCitiesCount.Location = new Point(144, 34);
            nuTspSomCitiesCount.Margin = new Padding(4);
            nuTspSomCitiesCount.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nuTspSomCitiesCount.Minimum = new decimal(new int[] { 20, 0, 0, 0 });
            nuTspSomCitiesCount.Name = "nuTspSomCitiesCount";
            nuTspSomCitiesCount.Size = new Size(67, 23);
            nuTspSomCitiesCount.TabIndex = 8;
            nuTspSomCitiesCount.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // lblTspSomTrainingCycles
            // 
            lblTspSomTrainingCycles.AutoSize = true;
            lblTspSomTrainingCycles.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTspSomTrainingCycles.Location = new Point(262, 34);
            lblTspSomTrainingCycles.Margin = new Padding(4, 0, 4, 0);
            lblTspSomTrainingCycles.Name = "lblTspSomTrainingCycles";
            lblTspSomTrainingCycles.Size = new Size(97, 26);
            lblTspSomTrainingCycles.TabIndex = 5;
            lblTspSomTrainingCycles.Text = "Trénovacích cyklů\r\n(epoch):";
            // 
            // lblTspSomCitiesCount
            // 
            lblTspSomCitiesCount.AutoSize = true;
            lblTspSomCitiesCount.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTspSomCitiesCount.Location = new Point(17, 37);
            lblTspSomCitiesCount.Margin = new Padding(4, 0, 4, 0);
            lblTspSomCitiesCount.Name = "lblTspSomCitiesCount";
            lblTspSomCitiesCount.Size = new Size(96, 13);
            lblTspSomCitiesCount.TabIndex = 5;
            lblTspSomCitiesCount.Text = "Počet (bodů) měst:";
            // 
            // panelTspSomDescription
            // 
            panelTspSomDescription.BorderStyle = BorderStyle.Fixed3D;
            panelTspSomDescription.Controls.Add(lblTspSomDescription);
            panelTspSomDescription.Location = new Point(14, 17);
            panelTspSomDescription.Margin = new Padding(4);
            panelTspSomDescription.Name = "panelTspSomDescription";
            panelTspSomDescription.Size = new Size(496, 128);
            panelTspSomDescription.TabIndex = 29;
            // 
            // lblTspSomDescription
            // 
            lblTspSomDescription.Location = new Point(-2, -2);
            lblTspSomDescription.Name = "lblTspSomDescription";
            lblTspSomDescription.Padding = new Padding(3, 2, 3, 2);
            lblTspSomDescription.Size = new Size(496, 128);
            lblTspSomDescription.TabIndex = 18;
            lblTspSomDescription.Text = resources.GetString("lblTspSomDescription.Text");
            lblTspSomDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // zedTspSomCitiesGraph
            // 
            zedTspSomCitiesGraph.BackColor = Color.Transparent;
            zedTspSomCitiesGraph.Enabled = false;
            zedTspSomCitiesGraph.Location = new Point(522, 17);
            zedTspSomCitiesGraph.Margin = new Padding(5, 3, 5, 3);
            zedTspSomCitiesGraph.Name = "zedTspSomCitiesGraph";
            zedTspSomCitiesGraph.ScrollGrace = 0D;
            zedTspSomCitiesGraph.ScrollMaxX = 0D;
            zedTspSomCitiesGraph.ScrollMaxY = 0D;
            zedTspSomCitiesGraph.ScrollMaxY2 = 0D;
            zedTspSomCitiesGraph.ScrollMinX = 0D;
            zedTspSomCitiesGraph.ScrollMinY = 0D;
            zedTspSomCitiesGraph.ScrollMinY2 = 0D;
            zedTspSomCitiesGraph.Size = new Size(609, 518);
            zedTspSomCitiesGraph.TabIndex = 11;
            zedTspSomCitiesGraph.UseExtendedPrintDialog = true;
            // 
            // tabPageSymReg
            // 
            tabPageSymReg.Controls.Add(lblSymRegElapsedTimeTitle);
            tabPageSymReg.Controls.Add(lblSymRegElapsedTime);
            tabPageSymReg.Controls.Add(btnSymRegInterrupt);
            tabPageSymReg.Controls.Add(pbSymRegProgress);
            tabPageSymReg.Controls.Add(dgvSymRegResults);
            tabPageSymReg.Controls.Add(gbSymRegParameters);
            tabPageSymReg.Controls.Add(btnSymRegRun);
            tabPageSymReg.Controls.Add(formsPlotSymReg);
            tabPageSymReg.Controls.Add(tbSymRegResult);
            tabPageSymReg.Controls.Add(panelSymRegDescription);
            tabPageSymReg.ImageIndex = 2;
            tabPageSymReg.Location = new Point(4, 24);
            tabPageSymReg.Margin = new Padding(4);
            tabPageSymReg.Name = "tabPageSymReg";
            tabPageSymReg.Padding = new Padding(4);
            tabPageSymReg.Size = new Size(1136, 540);
            tabPageSymReg.TabIndex = 2;
            tabPageSymReg.Text = "Hledání předpisu funkce [GA]";
            tabPageSymReg.UseVisualStyleBackColor = true;
            // 
            // lblSymRegElapsedTimeTitle
            // 
            lblSymRegElapsedTimeTitle.AutoSize = true;
            lblSymRegElapsedTimeTitle.Location = new Point(747, 512);
            lblSymRegElapsedTimeTitle.Margin = new Padding(4, 0, 4, 0);
            lblSymRegElapsedTimeTitle.Name = "lblSymRegElapsedTimeTitle";
            lblSymRegElapsedTimeTitle.Size = new Size(77, 15);
            lblSymRegElapsedTimeTitle.TabIndex = 22;
            lblSymRegElapsedTimeTitle.Text = "Uplynulý čas:";
            // 
            // lblSymRegElapsedTime
            // 
            lblSymRegElapsedTime.AutoSize = true;
            lblSymRegElapsedTime.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblSymRegElapsedTime.Location = new Point(838, 512);
            lblSymRegElapsedTime.Margin = new Padding(4, 0, 4, 0);
            lblSymRegElapsedTime.Name = "lblSymRegElapsedTime";
            lblSymRegElapsedTime.Size = new Size(55, 16);
            lblSymRegElapsedTime.TabIndex = 21;
            lblSymRegElapsedTime.Text = "0,000 s";
            // 
            // btnSymRegInterrupt
            // 
            btnSymRegInterrupt.Location = new Point(1032, 507);
            btnSymRegInterrupt.Name = "btnSymRegInterrupt";
            btnSymRegInterrupt.Size = new Size(88, 28);
            btnSymRegInterrupt.TabIndex = 20;
            btnSymRegInterrupt.Text = "Přerušit";
            btnSymRegInterrupt.UseVisualStyleBackColor = true;
            btnSymRegInterrupt.Click += btnSymRegInterrupt_Click;
            // 
            // pbSymRegProgress
            // 
            pbSymRegProgress.Location = new Point(747, 473);
            pbSymRegProgress.Margin = new Padding(4);
            pbSymRegProgress.Name = "pbSymRegProgress";
            pbSymRegProgress.Size = new Size(372, 26);
            pbSymRegProgress.Style = ProgressBarStyle.Continuous;
            pbSymRegProgress.TabIndex = 19;
            // 
            // dgvSymRegResults
            // 
            dgvSymRegResults.AllowUserToAddRows = false;
            dgvSymRegResults.AllowUserToDeleteRows = false;
            dgvSymRegResults.AllowUserToResizeRows = false;
            dgvSymRegResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSymRegResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSymRegResults.Columns.AddRange(new DataGridViewColumn[] { colSymRegGeneration, colSymRegFitness, colSymRegComplexity });
            dgvSymRegResults.Location = new Point(14, 277);
            dgvSymRegResults.Margin = new Padding(4);
            dgvSymRegResults.Name = "dgvSymRegResults";
            dgvSymRegResults.ReadOnly = true;
            dgvSymRegResults.RowHeadersWidth = 25;
            dgvSymRegResults.ScrollBars = ScrollBars.Vertical;
            dgvSymRegResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSymRegResults.Size = new Size(339, 188);
            dgvSymRegResults.TabIndex = 18;
            dgvSymRegResults.CellFormatting += dgvSymRegResults_CellFormatting;
            dgvSymRegResults.CellMouseDoubleClick += dgvSymRegResults_CellMouseDoubleClick;
            // 
            // colSymRegGeneration
            // 
            colSymRegGeneration.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colSymRegGeneration.FillWeight = 1F;
            colSymRegGeneration.HeaderText = "Generace";
            colSymRegGeneration.MinimumWidth = 80;
            colSymRegGeneration.Name = "colSymRegGeneration";
            colSymRegGeneration.ReadOnly = true;
            colSymRegGeneration.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colSymRegFitness
            // 
            colSymRegFitness.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colSymRegFitness.FillWeight = 1F;
            colSymRegFitness.HeaderText = "Chyba";
            colSymRegFitness.MinimumWidth = 80;
            colSymRegFitness.Name = "colSymRegFitness";
            colSymRegFitness.ReadOnly = true;
            colSymRegFitness.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colSymRegComplexity
            // 
            colSymRegComplexity.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colSymRegComplexity.FillWeight = 1F;
            colSymRegComplexity.HeaderText = "Složitost";
            colSymRegComplexity.MinimumWidth = 80;
            colSymRegComplexity.Name = "colSymRegComplexity";
            colSymRegComplexity.ReadOnly = true;
            colSymRegComplexity.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // gbSymRegParameters
            // 
            gbSymRegParameters.Controls.Add(lblSymRegPopulationSize);
            gbSymRegParameters.Controls.Add(nuSymRegPopulationSize);
            gbSymRegParameters.Controls.Add(lblSymRegCrossoverProbability);
            gbSymRegParameters.Controls.Add(nuSymRegCrossoverProbability);
            gbSymRegParameters.Controls.Add(lblSymRegMutationProbability);
            gbSymRegParameters.Controls.Add(nuSymRegMutationProbability);
            gbSymRegParameters.Controls.Add(nuSymRegPointsCount);
            gbSymRegParameters.Controls.Add(lblSymRegPointsCount);
            gbSymRegParameters.Controls.Add(nuSymRegOutputPrecision);
            gbSymRegParameters.Controls.Add(lblSymRegOutputPrecision);
            gbSymRegParameters.Controls.Add(nuSymRegMinFitness);
            gbSymRegParameters.Controls.Add(cbSymRegAllowEndOnFitness);
            gbSymRegParameters.Controls.Add(lblSymRegGenerationsSuffix);
            gbSymRegParameters.Controls.Add(nuSymRegGenerationCount);
            gbSymRegParameters.Controls.Add(lblSymRegGenerationCount);
            gbSymRegParameters.Controls.Add(nuSymRegChromosomeLength);
            gbSymRegParameters.Controls.Add(lblSymRegChromosomeLength);
            gbSymRegParameters.Location = new Point(14, 100);
            gbSymRegParameters.Margin = new Padding(4);
            gbSymRegParameters.Name = "gbSymRegParameters";
            gbSymRegParameters.Padding = new Padding(4);
            gbSymRegParameters.Size = new Size(339, 170);
            gbSymRegParameters.TabIndex = 17;
            gbSymRegParameters.TabStop = false;
            gbSymRegParameters.Text = " Parametry programu";
            // 
            // lblSymRegPopulationSize
            // 
            lblSymRegPopulationSize.Location = new Point(200, 55);
            lblSymRegPopulationSize.Margin = new Padding(4, 0, 4, 0);
            lblSymRegPopulationSize.Name = "lblSymRegPopulationSize";
            lblSymRegPopulationSize.Size = new Size(72, 32);
            lblSymRegPopulationSize.TabIndex = 18;
            lblSymRegPopulationSize.Text = "Velikost populace:";
            lblSymRegPopulationSize.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nuSymRegPopulationSize
            // 
            nuSymRegPopulationSize.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            nuSymRegPopulationSize.Location = new Point(275, 63);
            nuSymRegPopulationSize.Margin = new Padding(4);
            nuSymRegPopulationSize.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            nuSymRegPopulationSize.Minimum = new decimal(new int[] { 20, 0, 0, 0 });
            nuSymRegPopulationSize.Name = "nuSymRegPopulationSize";
            nuSymRegPopulationSize.Size = new Size(54, 23);
            nuSymRegPopulationSize.TabIndex = 17;
            nuSymRegPopulationSize.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // lblSymRegCrossoverProbability
            // 
            lblSymRegCrossoverProbability.Location = new Point(200, 132);
            lblSymRegCrossoverProbability.Margin = new Padding(4, 0, 4, 0);
            lblSymRegCrossoverProbability.Name = "lblSymRegCrossoverProbability";
            lblSymRegCrossoverProbability.Size = new Size(72, 32);
            lblSymRegCrossoverProbability.TabIndex = 16;
            lblSymRegCrossoverProbability.Text = "Pravděp. křížení:";
            lblSymRegCrossoverProbability.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nuSymRegCrossoverProbability
            // 
            nuSymRegCrossoverProbability.DecimalPlaces = 2;
            nuSymRegCrossoverProbability.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            nuSymRegCrossoverProbability.Location = new Point(275, 137);
            nuSymRegCrossoverProbability.Margin = new Padding(4);
            nuSymRegCrossoverProbability.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            nuSymRegCrossoverProbability.Name = "nuSymRegCrossoverProbability";
            nuSymRegCrossoverProbability.Size = new Size(54, 23);
            nuSymRegCrossoverProbability.TabIndex = 15;
            nuSymRegCrossoverProbability.Value = new decimal(new int[] { 8, 0, 0, 65536 });
            // 
            // lblSymRegMutationProbability
            // 
            lblSymRegMutationProbability.Location = new Point(200, 20);
            lblSymRegMutationProbability.Margin = new Padding(4, 0, 4, 0);
            lblSymRegMutationProbability.Name = "lblSymRegMutationProbability";
            lblSymRegMutationProbability.Size = new Size(60, 32);
            lblSymRegMutationProbability.TabIndex = 14;
            lblSymRegMutationProbability.Text = "Pravděp. mutace:";
            lblSymRegMutationProbability.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nuSymRegMutationProbability
            // 
            nuSymRegMutationProbability.DecimalPlaces = 3;
            nuSymRegMutationProbability.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nuSymRegMutationProbability.Location = new Point(275, 25);
            nuSymRegMutationProbability.Margin = new Padding(4);
            nuSymRegMutationProbability.Maximum = new decimal(new int[] { 2, 0, 0, 65536 });
            nuSymRegMutationProbability.Minimum = new decimal(new int[] { 1, 0, 0, 196608 });
            nuSymRegMutationProbability.Name = "nuSymRegMutationProbability";
            nuSymRegMutationProbability.Size = new Size(54, 23);
            nuSymRegMutationProbability.TabIndex = 13;
            nuSymRegMutationProbability.Value = new decimal(new int[] { 5, 0, 0, 131072 });
            // 
            // nuSymRegPointsCount
            // 
            nuSymRegPointsCount.Location = new Point(150, 137);
            nuSymRegPointsCount.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            nuSymRegPointsCount.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
            nuSymRegPointsCount.Name = "nuSymRegPointsCount";
            nuSymRegPointsCount.Size = new Size(40, 23);
            nuSymRegPointsCount.TabIndex = 12;
            nuSymRegPointsCount.Value = new decimal(new int[] { 5, 0, 0, 0 });
            nuSymRegPointsCount.ValueChanged += nuSymRegPointsCount_ValueChanged;
            // 
            // lblSymRegPointsCount
            // 
            lblSymRegPointsCount.AutoSize = true;
            lblSymRegPointsCount.Location = new Point(6, 141);
            lblSymRegPointsCount.Name = "lblSymRegPointsCount";
            lblSymRegPointsCount.Size = new Size(121, 15);
            lblSymRegPointsCount.TabIndex = 11;
            lblSymRegPointsCount.Text = "Počet uzlových bodů:";
            // 
            // nuSymRegOutputPrecision
            // 
            nuSymRegOutputPrecision.Location = new Point(284, 108);
            nuSymRegOutputPrecision.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nuSymRegOutputPrecision.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nuSymRegOutputPrecision.Name = "nuSymRegOutputPrecision";
            nuSymRegOutputPrecision.Size = new Size(45, 23);
            nuSymRegOutputPrecision.TabIndex = 10;
            nuSymRegOutputPrecision.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // lblSymRegOutputPrecision
            // 
            lblSymRegOutputPrecision.Location = new Point(200, 100);
            lblSymRegOutputPrecision.Name = "lblSymRegOutputPrecision";
            lblSymRegOutputPrecision.Size = new Size(81, 39);
            lblSymRegOutputPrecision.TabIndex = 9;
            lblSymRegOutputPrecision.Text = "Počet des. míst výstupu:";
            lblSymRegOutputPrecision.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nuSymRegMinFitness
            // 
            nuSymRegMinFitness.Enabled = false;
            nuSymRegMinFitness.Location = new Point(150, 108);
            nuSymRegMinFitness.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nuSymRegMinFitness.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nuSymRegMinFitness.Name = "nuSymRegMinFitness";
            nuSymRegMinFitness.Size = new Size(40, 23);
            nuSymRegMinFitness.TabIndex = 8;
            nuSymRegMinFitness.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cbSymRegAllowEndOnFitness
            // 
            cbSymRegAllowEndOnFitness.Location = new Point(8, 100);
            cbSymRegAllowEndOnFitness.Name = "cbSymRegAllowEndOnFitness";
            cbSymRegAllowEndOnFitness.Size = new Size(136, 39);
            cbSymRegAllowEndOnFitness.TabIndex = 7;
            cbSymRegAllowEndOnFitness.Text = "povolit ukončení pro chybu menší než: ";
            cbSymRegAllowEndOnFitness.UseVisualStyleBackColor = true;
            cbSymRegAllowEndOnFitness.CheckedChanged += cbSymRegAllowEndOnFitness_CheckedChanged;
            // 
            // lblSymRegGenerationsSuffix
            // 
            lblSymRegGenerationsSuffix.AutoSize = true;
            lblSymRegGenerationsSuffix.Location = new Point(166, 65);
            lblSymRegGenerationsSuffix.Margin = new Padding(4, 0, 4, 0);
            lblSymRegGenerationsSuffix.Name = "lblSymRegGenerationsSuffix";
            lblSymRegGenerationsSuffix.Size = new Size(65, 15);
            lblSymRegGenerationsSuffix.TabIndex = 6;
            lblSymRegGenerationsSuffix.Text = "generacích";
            // 
            // nuSymRegGenerationCount
            // 
            nuSymRegGenerationCount.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            nuSymRegGenerationCount.Location = new Point(100, 63);
            nuSymRegGenerationCount.Margin = new Padding(4);
            nuSymRegGenerationCount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nuSymRegGenerationCount.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            nuSymRegGenerationCount.Name = "nuSymRegGenerationCount";
            nuSymRegGenerationCount.Size = new Size(60, 23);
            nuSymRegGenerationCount.TabIndex = 1;
            nuSymRegGenerationCount.Value = new decimal(new int[] { 10000, 0, 0, 0 });
            // 
            // lblSymRegGenerationCount
            // 
            lblSymRegGenerationCount.AutoSize = true;
            lblSymRegGenerationCount.Location = new Point(8, 65);
            lblSymRegGenerationCount.Margin = new Padding(4, 0, 4, 0);
            lblSymRegGenerationCount.Name = "lblSymRegGenerationCount";
            lblSymRegGenerationCount.Size = new Size(68, 15);
            lblSymRegGenerationCount.TabIndex = 0;
            lblSymRegGenerationCount.Text = "Ukončit po:";
            // 
            // nuSymRegChromosomeLength
            // 
            nuSymRegChromosomeLength.Location = new Point(100, 25);
            nuSymRegChromosomeLength.Margin = new Padding(4);
            nuSymRegChromosomeLength.Minimum = new decimal(new int[] { 6, 0, 0, 0 });
            nuSymRegChromosomeLength.Name = "nuSymRegChromosomeLength";
            nuSymRegChromosomeLength.Size = new Size(60, 23);
            nuSymRegChromosomeLength.TabIndex = 1;
            nuSymRegChromosomeLength.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblSymRegChromosomeLength
            // 
            lblSymRegChromosomeLength.Location = new Point(8, 20);
            lblSymRegChromosomeLength.Margin = new Padding(4, 0, 4, 0);
            lblSymRegChromosomeLength.Name = "lblSymRegChromosomeLength";
            lblSymRegChromosomeLength.Size = new Size(84, 32);
            lblSymRegChromosomeLength.TabIndex = 0;
            lblSymRegChromosomeLength.Text = "Velikost chromozomu:";
            // 
            // btnSymRegRun
            // 
            btnSymRegRun.Location = new Point(937, 507);
            btnSymRegRun.Margin = new Padding(3, 2, 3, 2);
            btnSymRegRun.Name = "btnSymRegRun";
            btnSymRegRun.Size = new Size(88, 28);
            btnSymRegRun.TabIndex = 10;
            btnSymRegRun.Text = "Spustit!";
            btnSymRegRun.UseVisualStyleBackColor = true;
            btnSymRegRun.Click += btnSymRegRun_Click;
            // 
            // formsPlotSymReg
            // 
            formsPlotSymReg.ForeColor = SystemColors.ControlText;
            formsPlotSymReg.Location = new Point(360, 17);
            formsPlotSymReg.Margin = new Padding(3, 2, 3, 2);
            formsPlotSymReg.Name = "formsPlotSymReg";
            formsPlotSymReg.Size = new Size(759, 448);
            formsPlotSymReg.TabIndex = 15;
            formsPlotSymReg.MouseDown += formsPlotSymReg_MouseDown;
            formsPlotSymReg.MouseMove += formsPlotSymReg_MouseMove;
            formsPlotSymReg.MouseUp += formsPlotSymReg_MouseUp;
            // 
            // tbSymRegResult
            // 
            tbSymRegResult.Location = new Point(14, 473);
            tbSymRegResult.Margin = new Padding(4);
            tbSymRegResult.Multiline = true;
            tbSymRegResult.Name = "tbSymRegResult";
            tbSymRegResult.ReadOnly = true;
            tbSymRegResult.ScrollBars = ScrollBars.Vertical;
            tbSymRegResult.Size = new Size(725, 63);
            tbSymRegResult.TabIndex = 14;
            // 
            // panelSymRegDescription
            // 
            panelSymRegDescription.BorderStyle = BorderStyle.Fixed3D;
            panelSymRegDescription.Controls.Add(lblSymRegDescription);
            panelSymRegDescription.Location = new Point(14, 17);
            panelSymRegDescription.Margin = new Padding(4);
            panelSymRegDescription.Name = "panelSymRegDescription";
            panelSymRegDescription.Size = new Size(339, 74);
            panelSymRegDescription.TabIndex = 9;
            // 
            // lblSymRegDescription
            // 
            lblSymRegDescription.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lblSymRegDescription.Location = new Point(4, 0);
            lblSymRegDescription.Margin = new Padding(4, 0, 4, 0);
            lblSymRegDescription.Name = "lblSymRegDescription";
            lblSymRegDescription.Size = new Size(328, 65);
            lblSymRegDescription.TabIndex = 0;
            lblSymRegDescription.Text = "Symbolická regrese pomocí genetických algoritmů (GA) hledá matematický předpis funkce, která v ideálním případě přímo prochází zadanými body nebo je alespoň\r\ns co nejmenší možnou chybou aproximuje.";
            lblSymRegDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tabPageTspGa
            // 
            tabPageTspGa.Controls.Add(panelTspGaDescription);
            tabPageTspGa.Controls.Add(lblTspGaElapsedTimeTitle);
            tabPageTspGa.Controls.Add(tbTspGaResult);
            tabPageTspGa.Controls.Add(pbTspGaProgress);
            tabPageTspGa.Controls.Add(dgvTspGaResults);
            tabPageTspGa.Controls.Add(lblTspGaElapsedTime);
            tabPageTspGa.Controls.Add(gbTspGaParameters);
            tabPageTspGa.Controls.Add(btnTspGaRun);
            tabPageTspGa.Controls.Add(btnTspGaInterrupt);
            tabPageTspGa.ImageIndex = 1;
            tabPageTspGa.Location = new Point(4, 24);
            tabPageTspGa.Margin = new Padding(4);
            tabPageTspGa.Name = "tabPageTspGa";
            tabPageTspGa.Padding = new Padding(4);
            tabPageTspGa.Size = new Size(1136, 540);
            tabPageTspGa.TabIndex = 0;
            tabPageTspGa.Text = "Problém obchodního cestujícího [GA]";
            tabPageTspGa.UseVisualStyleBackColor = true;
            // 
            // panelTspGaDescription
            // 
            panelTspGaDescription.BorderStyle = BorderStyle.Fixed3D;
            panelTspGaDescription.Controls.Add(lblTspGaDescription);
            panelTspGaDescription.Location = new Point(14, 17);
            panelTspGaDescription.Margin = new Padding(4);
            panelTspGaDescription.Name = "panelTspGaDescription";
            panelTspGaDescription.Size = new Size(496, 128);
            panelTspGaDescription.TabIndex = 18;
            // 
            // lblTspGaDescription
            // 
            lblTspGaDescription.Location = new Point(-2, -2);
            lblTspGaDescription.Name = "lblTspGaDescription";
            lblTspGaDescription.Padding = new Padding(3, 2, 3, 2);
            lblTspGaDescription.Size = new Size(496, 128);
            lblTspGaDescription.TabIndex = 18;
            lblTspGaDescription.Text = resources.GetString("lblTspGaDescription.Text");
            lblTspGaDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTspGaElapsedTimeTitle
            // 
            lblTspGaElapsedTimeTitle.AutoSize = true;
            lblTspGaElapsedTimeTitle.Location = new Point(25, 356);
            lblTspGaElapsedTimeTitle.Margin = new Padding(4, 0, 4, 0);
            lblTspGaElapsedTimeTitle.Name = "lblTspGaElapsedTimeTitle";
            lblTspGaElapsedTimeTitle.Size = new Size(77, 15);
            lblTspGaElapsedTimeTitle.TabIndex = 16;
            lblTspGaElapsedTimeTitle.Text = "Uplynulý čas:";
            // 
            // tbTspGaResult
            // 
            tbTspGaResult.Location = new Point(14, 428);
            tbTspGaResult.Margin = new Padding(4);
            tbTspGaResult.Multiline = true;
            tbTspGaResult.Name = "tbTspGaResult";
            tbTspGaResult.ReadOnly = true;
            tbTspGaResult.Size = new Size(1106, 96);
            tbTspGaResult.TabIndex = 13;
            // 
            // pbTspGaProgress
            // 
            pbTspGaProgress.Location = new Point(14, 394);
            pbTspGaProgress.Margin = new Padding(4);
            pbTspGaProgress.Name = "pbTspGaProgress";
            pbTspGaProgress.Size = new Size(496, 26);
            pbTspGaProgress.Style = ProgressBarStyle.Continuous;
            pbTspGaProgress.TabIndex = 12;
            // 
            // dgvTspGaResults
            // 
            dgvTspGaResults.AllowUserToAddRows = false;
            dgvTspGaResults.AllowUserToDeleteRows = false;
            dgvTspGaResults.AllowUserToResizeRows = false;
            dgvTspGaResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTspGaResults.Columns.AddRange(new DataGridViewColumn[] { colTspGaGeneration, colTspGaFitness, colTspGaDistance });
            dgvTspGaResults.Location = new Point(531, 17);
            dgvTspGaResults.Margin = new Padding(4);
            dgvTspGaResults.Name = "dgvTspGaResults";
            dgvTspGaResults.ReadOnly = true;
            dgvTspGaResults.RowHeadersWidth = 25;
            dgvTspGaResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTspGaResults.Size = new Size(589, 403);
            dgvTspGaResults.TabIndex = 11;
            // 
            // colTspGaGeneration
            // 
            colTspGaGeneration.HeaderText = "Generace";
            colTspGaGeneration.MinimumWidth = 6;
            colTspGaGeneration.Name = "colTspGaGeneration";
            colTspGaGeneration.ReadOnly = true;
            colTspGaGeneration.Width = 125;
            // 
            // colTspGaFitness
            // 
            colTspGaFitness.HeaderText = "Fitness";
            colTspGaFitness.MinimumWidth = 6;
            colTspGaFitness.Name = "colTspGaFitness";
            colTspGaFitness.ReadOnly = true;
            colTspGaFitness.Width = 150;
            // 
            // colTspGaDistance
            // 
            colTspGaDistance.HeaderText = "Vzdálenost";
            colTspGaDistance.MinimumWidth = 6;
            colTspGaDistance.Name = "colTspGaDistance";
            colTspGaDistance.ReadOnly = true;
            colTspGaDistance.Width = 180;
            // 
            // lblTspGaElapsedTime
            // 
            lblTspGaElapsedTime.AutoSize = true;
            lblTspGaElapsedTime.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblTspGaElapsedTime.Location = new Point(116, 356);
            lblTspGaElapsedTime.Margin = new Padding(4, 0, 4, 0);
            lblTspGaElapsedTime.Name = "lblTspGaElapsedTime";
            lblTspGaElapsedTime.Size = new Size(55, 16);
            lblTspGaElapsedTime.TabIndex = 14;
            lblTspGaElapsedTime.Text = "0,000 s";
            // 
            // gbTspGaParameters
            // 
            gbTspGaParameters.Controls.Add(cbTspGaUseElites);
            gbTspGaParameters.Controls.Add(lblTspGaGenerationsSuffix);
            gbTspGaParameters.Controls.Add(lblTspGaElitismPercent);
            gbTspGaParameters.Controls.Add(lblTspGaMutationProbability);
            gbTspGaParameters.Controls.Add(nuTspGaMutationProbability);
            gbTspGaParameters.Controls.Add(nuTspGaCrossoverProbability);
            gbTspGaParameters.Controls.Add(lblTspGaCrossoverProbability);
            gbTspGaParameters.Controls.Add(nuTspGaElitismPercent);
            gbTspGaParameters.Controls.Add(nuTspGaGenerationCount);
            gbTspGaParameters.Controls.Add(lblTspGaGenerationCount);
            gbTspGaParameters.Controls.Add(nuTspGaPopulationSize);
            gbTspGaParameters.Controls.Add(lblTspGaPopulationSize);
            gbTspGaParameters.Location = new Point(14, 154);
            gbTspGaParameters.Margin = new Padding(4);
            gbTspGaParameters.Name = "gbTspGaParameters";
            gbTspGaParameters.Padding = new Padding(4);
            gbTspGaParameters.Size = new Size(496, 182);
            gbTspGaParameters.TabIndex = 9;
            gbTspGaParameters.TabStop = false;
            gbTspGaParameters.Text = " Parametry programu";
            // 
            // cbTspGaUseElites
            // 
            cbTspGaUseElites.Checked = true;
            cbTspGaUseElites.CheckState = CheckState.Checked;
            cbTspGaUseElites.Location = new Point(325, 127);
            cbTspGaUseElites.Margin = new Padding(4);
            cbTspGaUseElites.Name = "cbTspGaUseElites";
            cbTspGaUseElites.RightToLeft = RightToLeft.Yes;
            cbTspGaUseElites.Size = new Size(127, 21);
            cbTspGaUseElites.TabIndex = 7;
            cbTspGaUseElites.Text = "Elitismus (Elite)";
            cbTspGaUseElites.TextAlign = ContentAlignment.TopLeft;
            cbTspGaUseElites.UseVisualStyleBackColor = true;
            cbTspGaUseElites.CheckedChanged += cbTspGaUseElites_CheckedChanged;
            // 
            // lblTspGaGenerationsSuffix
            // 
            lblTspGaGenerationsSuffix.AutoSize = true;
            lblTspGaGenerationsSuffix.Location = new Point(218, 127);
            lblTspGaGenerationsSuffix.Margin = new Padding(4, 0, 4, 0);
            lblTspGaGenerationsSuffix.Name = "lblTspGaGenerationsSuffix";
            lblTspGaGenerationsSuffix.Size = new Size(65, 15);
            lblTspGaGenerationsSuffix.TabIndex = 6;
            lblTspGaGenerationsSuffix.Text = "generacích";
            // 
            // lblTspGaElitismPercent
            // 
            lblTspGaElitismPercent.AutoSize = true;
            lblTspGaElitismPercent.Location = new Point(262, 84);
            lblTspGaElitismPercent.Margin = new Padding(4, 0, 4, 0);
            lblTspGaElitismPercent.Name = "lblTspGaElitismPercent";
            lblTspGaElitismPercent.Size = new Size(77, 15);
            lblTspGaElitismPercent.TabIndex = 5;
            lblTspGaElitismPercent.Text = "Procento elit:";
            // 
            // lblTspGaMutationProbability
            // 
            lblTspGaMutationProbability.AutoSize = true;
            lblTspGaMutationProbability.Location = new Point(262, 34);
            lblTspGaMutationProbability.Margin = new Padding(4, 0, 4, 0);
            lblTspGaMutationProbability.Name = "lblTspGaMutationProbability";
            lblTspGaMutationProbability.Size = new Size(101, 30);
            lblTspGaMutationProbability.TabIndex = 4;
            lblTspGaMutationProbability.Text = "Pravděpodobnost\r\nmutace:";
            // 
            // nuTspGaMutationProbability
            // 
            nuTspGaMutationProbability.DecimalPlaces = 3;
            nuTspGaMutationProbability.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nuTspGaMutationProbability.Location = new Point(384, 37);
            nuTspGaMutationProbability.Margin = new Padding(4);
            nuTspGaMutationProbability.Maximum = new decimal(new int[] { 2, 0, 0, 65536 });
            nuTspGaMutationProbability.Minimum = new decimal(new int[] { 1, 0, 0, 196608 });
            nuTspGaMutationProbability.Name = "nuTspGaMutationProbability";
            nuTspGaMutationProbability.Size = new Size(67, 23);
            nuTspGaMutationProbability.TabIndex = 3;
            nuTspGaMutationProbability.Value = new decimal(new int[] { 5, 0, 0, 131072 });
            // 
            // nuTspGaCrossoverProbability
            // 
            nuTspGaCrossoverProbability.DecimalPlaces = 2;
            nuTspGaCrossoverProbability.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            nuTspGaCrossoverProbability.Location = new Point(144, 81);
            nuTspGaCrossoverProbability.Margin = new Padding(4);
            nuTspGaCrossoverProbability.Maximum = new decimal(new int[] { 99, 0, 0, 131072 });
            nuTspGaCrossoverProbability.Minimum = new decimal(new int[] { 5, 0, 0, 65536 });
            nuTspGaCrossoverProbability.Name = "nuTspGaCrossoverProbability";
            nuTspGaCrossoverProbability.Size = new Size(67, 23);
            nuTspGaCrossoverProbability.TabIndex = 3;
            nuTspGaCrossoverProbability.Value = new decimal(new int[] { 8, 0, 0, 65536 });
            // 
            // lblTspGaCrossoverProbability
            // 
            lblTspGaCrossoverProbability.Location = new Point(25, 76);
            lblTspGaCrossoverProbability.Margin = new Padding(4, 0, 4, 0);
            lblTspGaCrossoverProbability.Name = "lblTspGaCrossoverProbability";
            lblTspGaCrossoverProbability.Size = new Size(111, 37);
            lblTspGaCrossoverProbability.TabIndex = 2;
            lblTspGaCrossoverProbability.Text = "Pravděpodobnost křížení:";
            // 
            // nuTspGaElitismPercent
            // 
            nuTspGaElitismPercent.Location = new Point(384, 81);
            nuTspGaElitismPercent.Margin = new Padding(4);
            nuTspGaElitismPercent.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nuTspGaElitismPercent.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nuTspGaElitismPercent.Name = "nuTspGaElitismPercent";
            nuTspGaElitismPercent.Size = new Size(67, 23);
            nuTspGaElitismPercent.TabIndex = 1;
            nuTspGaElitismPercent.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // nuTspGaGenerationCount
            // 
            nuTspGaGenerationCount.Location = new Point(144, 124);
            nuTspGaGenerationCount.Margin = new Padding(4);
            nuTspGaGenerationCount.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nuTspGaGenerationCount.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            nuTspGaGenerationCount.Name = "nuTspGaGenerationCount";
            nuTspGaGenerationCount.Size = new Size(67, 23);
            nuTspGaGenerationCount.TabIndex = 1;
            nuTspGaGenerationCount.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // lblTspGaGenerationCount
            // 
            lblTspGaGenerationCount.AutoSize = true;
            lblTspGaGenerationCount.Location = new Point(25, 127);
            lblTspGaGenerationCount.Margin = new Padding(4, 0, 4, 0);
            lblTspGaGenerationCount.Name = "lblTspGaGenerationCount";
            lblTspGaGenerationCount.Size = new Size(68, 15);
            lblTspGaGenerationCount.TabIndex = 0;
            lblTspGaGenerationCount.Text = "Ukončit po:";
            // 
            // nuTspGaPopulationSize
            // 
            nuTspGaPopulationSize.Location = new Point(144, 34);
            nuTspGaPopulationSize.Margin = new Padding(4);
            nuTspGaPopulationSize.Maximum = new decimal(new int[] { 800, 0, 0, 0 });
            nuTspGaPopulationSize.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            nuTspGaPopulationSize.Name = "nuTspGaPopulationSize";
            nuTspGaPopulationSize.Size = new Size(67, 23);
            nuTspGaPopulationSize.TabIndex = 1;
            nuTspGaPopulationSize.Value = new decimal(new int[] { 250, 0, 0, 0 });
            // 
            // lblTspGaPopulationSize
            // 
            lblTspGaPopulationSize.AutoSize = true;
            lblTspGaPopulationSize.Location = new Point(25, 36);
            lblTspGaPopulationSize.Margin = new Padding(4, 0, 4, 0);
            lblTspGaPopulationSize.Name = "lblTspGaPopulationSize";
            lblTspGaPopulationSize.Size = new Size(102, 15);
            lblTspGaPopulationSize.TabIndex = 0;
            lblTspGaPopulationSize.Text = "Velikost populace:";
            // 
            // btnTspGaRun
            // 
            btnTspGaRun.Location = new Point(326, 350);
            btnTspGaRun.Margin = new Padding(4);
            btnTspGaRun.Name = "btnTspGaRun";
            btnTspGaRun.Size = new Size(88, 28);
            btnTspGaRun.TabIndex = 10;
            btnTspGaRun.Text = "Spustit!";
            btnTspGaRun.UseVisualStyleBackColor = true;
            btnTspGaRun.Click += btnTspGaRun_Click;
            // 
            // btnTspGaInterrupt
            // 
            btnTspGaInterrupt.Enabled = false;
            btnTspGaInterrupt.Location = new Point(422, 350);
            btnTspGaInterrupt.Margin = new Padding(4);
            btnTspGaInterrupt.Name = "btnTspGaInterrupt";
            btnTspGaInterrupt.Size = new Size(88, 28);
            btnTspGaInterrupt.TabIndex = 20;
            btnTspGaInterrupt.Text = "Přerušit";
            btnTspGaInterrupt.UseVisualStyleBackColor = true;
            btnTspGaInterrupt.Click += btnTspGaInterrupt_Click;
            // 
            // tabPageDiophantine
            // 
            tabPageDiophantine.Controls.Add(panelDiophantineDescription);
            tabPageDiophantine.Controls.Add(lblDiophantineElapsedTimeTitle);
            tabPageDiophantine.Controls.Add(tbDiophantineResult);
            tabPageDiophantine.Controls.Add(pbDiophantineProgress);
            tabPageDiophantine.Controls.Add(dgvDiophantineResults);
            tabPageDiophantine.Controls.Add(lblDiophantineElapsedTime);
            tabPageDiophantine.Controls.Add(gbDiophantineParameters);
            tabPageDiophantine.Controls.Add(btnDiophantineRun);
            tabPageDiophantine.Controls.Add(btnDiophantineInterrupt);
            tabPageDiophantine.ImageIndex = 3;
            tabPageDiophantine.Location = new Point(4, 24);
            tabPageDiophantine.Margin = new Padding(4);
            tabPageDiophantine.Name = "tabPageDiophantine";
            tabPageDiophantine.Padding = new Padding(4);
            tabPageDiophantine.Size = new Size(1136, 540);
            tabPageDiophantine.TabIndex = 1;
            tabPageDiophantine.Text = "Řešení diofantické rovnice [GA]";
            tabPageDiophantine.UseVisualStyleBackColor = true;
            // 
            // panelDiophantineDescription
            // 
            panelDiophantineDescription.BorderStyle = BorderStyle.Fixed3D;
            panelDiophantineDescription.Controls.Add(lblDiophantineDescription);
            panelDiophantineDescription.Location = new Point(14, 30);
            panelDiophantineDescription.Margin = new Padding(4);
            panelDiophantineDescription.Name = "panelDiophantineDescription";
            panelDiophantineDescription.Size = new Size(496, 82);
            panelDiophantineDescription.TabIndex = 19;
            // 
            // lblDiophantineDescription
            // 
            lblDiophantineDescription.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lblDiophantineDescription.Location = new Point(-2, 4);
            lblDiophantineDescription.Margin = new Padding(4, 0, 4, 0);
            lblDiophantineDescription.Name = "lblDiophantineDescription";
            lblDiophantineDescription.Padding = new Padding(3, 2, 3, 2);
            lblDiophantineDescription.Size = new Size(472, 64);
            lblDiophantineDescription.TabIndex = 17;
            lblDiophantineDescription.Text = resources.GetString("lblDiophantineDescription.Text");
            lblDiophantineDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDiophantineElapsedTimeTitle
            // 
            lblDiophantineElapsedTimeTitle.AutoSize = true;
            lblDiophantineElapsedTimeTitle.Location = new Point(25, 356);
            lblDiophantineElapsedTimeTitle.Margin = new Padding(4, 0, 4, 0);
            lblDiophantineElapsedTimeTitle.Name = "lblDiophantineElapsedTimeTitle";
            lblDiophantineElapsedTimeTitle.Size = new Size(77, 15);
            lblDiophantineElapsedTimeTitle.TabIndex = 15;
            lblDiophantineElapsedTimeTitle.Text = "Uplynulý čas:";
            // 
            // tbDiophantineResult
            // 
            tbDiophantineResult.Location = new Point(14, 428);
            tbDiophantineResult.Margin = new Padding(4);
            tbDiophantineResult.Multiline = true;
            tbDiophantineResult.Name = "tbDiophantineResult";
            tbDiophantineResult.ReadOnly = true;
            tbDiophantineResult.ScrollBars = ScrollBars.Vertical;
            tbDiophantineResult.Size = new Size(1106, 96);
            tbDiophantineResult.TabIndex = 13;
            // 
            // pbDiophantineProgress
            // 
            pbDiophantineProgress.Location = new Point(14, 394);
            pbDiophantineProgress.Margin = new Padding(4);
            pbDiophantineProgress.Name = "pbDiophantineProgress";
            pbDiophantineProgress.Size = new Size(496, 26);
            pbDiophantineProgress.Style = ProgressBarStyle.Continuous;
            pbDiophantineProgress.TabIndex = 12;
            // 
            // dgvDiophantineResults
            // 
            dgvDiophantineResults.AllowUserToAddRows = false;
            dgvDiophantineResults.AllowUserToDeleteRows = false;
            dgvDiophantineResults.AllowUserToResizeRows = false;
            dgvDiophantineResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDiophantineResults.Columns.AddRange(new DataGridViewColumn[] { colDiophantineGeneration, colDiophantineFitness, colDiophantineA, colDiophantineB, colDiophantineC, colDiophantineD, colDiophantineResult });
            dgvDiophantineResults.Location = new Point(531, 17);
            dgvDiophantineResults.Margin = new Padding(4);
            dgvDiophantineResults.Name = "dgvDiophantineResults";
            dgvDiophantineResults.ReadOnly = true;
            dgvDiophantineResults.RowHeadersWidth = 25;
            dgvDiophantineResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDiophantineResults.Size = new Size(589, 403);
            dgvDiophantineResults.TabIndex = 11;
            // 
            // colDiophantineGeneration
            // 
            colDiophantineGeneration.HeaderText = "Generace";
            colDiophantineGeneration.MinimumWidth = 6;
            colDiophantineGeneration.Name = "colDiophantineGeneration";
            colDiophantineGeneration.ReadOnly = true;
            colDiophantineGeneration.Width = 80;
            // 
            // colDiophantineFitness
            // 
            colDiophantineFitness.HeaderText = "Fitness";
            colDiophantineFitness.MinimumWidth = 6;
            colDiophantineFitness.Name = "colDiophantineFitness";
            colDiophantineFitness.ReadOnly = true;
            colDiophantineFitness.Width = 150;
            // 
            // colDiophantineA
            // 
            colDiophantineA.HeaderText = "a";
            colDiophantineA.MinimumWidth = 6;
            colDiophantineA.Name = "colDiophantineA";
            colDiophantineA.ReadOnly = true;
            colDiophantineA.Width = 30;
            // 
            // colDiophantineB
            // 
            colDiophantineB.HeaderText = "b";
            colDiophantineB.MinimumWidth = 6;
            colDiophantineB.Name = "colDiophantineB";
            colDiophantineB.ReadOnly = true;
            colDiophantineB.Width = 30;
            // 
            // colDiophantineC
            // 
            colDiophantineC.HeaderText = "c";
            colDiophantineC.MinimumWidth = 6;
            colDiophantineC.Name = "colDiophantineC";
            colDiophantineC.ReadOnly = true;
            colDiophantineC.Width = 30;
            // 
            // colDiophantineD
            // 
            colDiophantineD.HeaderText = "d";
            colDiophantineD.MinimumWidth = 6;
            colDiophantineD.Name = "colDiophantineD";
            colDiophantineD.ReadOnly = true;
            colDiophantineD.Width = 30;
            // 
            // colDiophantineResult
            // 
            colDiophantineResult.HeaderText = "Výsledek";
            colDiophantineResult.MinimumWidth = 6;
            colDiophantineResult.Name = "colDiophantineResult";
            colDiophantineResult.ReadOnly = true;
            colDiophantineResult.Width = 180;
            // 
            // lblDiophantineElapsedTime
            // 
            lblDiophantineElapsedTime.AutoSize = true;
            lblDiophantineElapsedTime.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblDiophantineElapsedTime.Location = new Point(116, 356);
            lblDiophantineElapsedTime.Margin = new Padding(4, 0, 4, 0);
            lblDiophantineElapsedTime.Name = "lblDiophantineElapsedTime";
            lblDiophantineElapsedTime.Size = new Size(55, 16);
            lblDiophantineElapsedTime.TabIndex = 14;
            lblDiophantineElapsedTime.Text = "0,000 s";
            // 
            // gbDiophantineParameters
            // 
            gbDiophantineParameters.Controls.Add(cbDiophantineEndOnPerfectFitness);
            gbDiophantineParameters.Controls.Add(cbDiophantineUseElites);
            gbDiophantineParameters.Controls.Add(lblDiophantineGenerationsSuffix);
            gbDiophantineParameters.Controls.Add(lblDiophantineElitismPercent);
            gbDiophantineParameters.Controls.Add(lblDiophantineMutationProbability);
            gbDiophantineParameters.Controls.Add(nuDiophantineMutationProbability);
            gbDiophantineParameters.Controls.Add(nuDiophantineCrossoverProbability);
            gbDiophantineParameters.Controls.Add(lblDiophantineCrossoverProbability);
            gbDiophantineParameters.Controls.Add(nuDiophantineElitismPercent);
            gbDiophantineParameters.Controls.Add(nuDiophantineGenerationCount);
            gbDiophantineParameters.Controls.Add(lblDiophantineGenerationCount);
            gbDiophantineParameters.Controls.Add(nuDiophantinePopulationSize);
            gbDiophantineParameters.Controls.Add(lblDiophantinePopulationSize);
            gbDiophantineParameters.Location = new Point(14, 139);
            gbDiophantineParameters.Margin = new Padding(4);
            gbDiophantineParameters.Name = "gbDiophantineParameters";
            gbDiophantineParameters.Padding = new Padding(4);
            gbDiophantineParameters.Size = new Size(496, 196);
            gbDiophantineParameters.TabIndex = 9;
            gbDiophantineParameters.TabStop = false;
            gbDiophantineParameters.Text = " Parametry programu";
            // 
            // cbDiophantineEndOnPerfectFitness
            // 
            cbDiophantineEndOnPerfectFitness.AutoSize = true;
            cbDiophantineEndOnPerfectFitness.Checked = true;
            cbDiophantineEndOnPerfectFitness.CheckState = CheckState.Checked;
            cbDiophantineEndOnPerfectFitness.Location = new Point(29, 161);
            cbDiophantineEndOnPerfectFitness.Margin = new Padding(4);
            cbDiophantineEndOnPerfectFitness.Name = "cbDiophantineEndOnPerfectFitness";
            cbDiophantineEndOnPerfectFitness.Size = new Size(188, 19);
            cbDiophantineEndOnPerfectFitness.TabIndex = 8;
            cbDiophantineEndOnPerfectFitness.Text = "povolit ukočení i při fitness = 1";
            cbDiophantineEndOnPerfectFitness.UseVisualStyleBackColor = true;
            // 
            // cbDiophantineUseElites
            // 
            cbDiophantineUseElites.Location = new Point(332, 127);
            cbDiophantineUseElites.Margin = new Padding(4);
            cbDiophantineUseElites.Name = "cbDiophantineUseElites";
            cbDiophantineUseElites.RightToLeft = RightToLeft.Yes;
            cbDiophantineUseElites.Size = new Size(120, 21);
            cbDiophantineUseElites.TabIndex = 7;
            cbDiophantineUseElites.Text = "Elitismus (Elite)";
            cbDiophantineUseElites.TextAlign = ContentAlignment.TopLeft;
            cbDiophantineUseElites.UseVisualStyleBackColor = true;
            cbDiophantineUseElites.CheckedChanged += cbDiophantineUseElites_CheckedChanged;
            // 
            // lblDiophantineGenerationsSuffix
            // 
            lblDiophantineGenerationsSuffix.AutoSize = true;
            lblDiophantineGenerationsSuffix.Location = new Point(218, 127);
            lblDiophantineGenerationsSuffix.Margin = new Padding(4, 0, 4, 0);
            lblDiophantineGenerationsSuffix.Name = "lblDiophantineGenerationsSuffix";
            lblDiophantineGenerationsSuffix.Size = new Size(65, 15);
            lblDiophantineGenerationsSuffix.TabIndex = 6;
            lblDiophantineGenerationsSuffix.Text = "generacích";
            // 
            // lblDiophantineElitismPercent
            // 
            lblDiophantineElitismPercent.AutoSize = true;
            lblDiophantineElitismPercent.Location = new Point(262, 84);
            lblDiophantineElitismPercent.Margin = new Padding(4, 0, 4, 0);
            lblDiophantineElitismPercent.Name = "lblDiophantineElitismPercent";
            lblDiophantineElitismPercent.Size = new Size(77, 15);
            lblDiophantineElitismPercent.TabIndex = 5;
            lblDiophantineElitismPercent.Text = "Procento elit:";
            // 
            // lblDiophantineMutationProbability
            // 
            lblDiophantineMutationProbability.Location = new Point(262, 34);
            lblDiophantineMutationProbability.Margin = new Padding(4, 0, 4, 0);
            lblDiophantineMutationProbability.Name = "lblDiophantineMutationProbability";
            lblDiophantineMutationProbability.Size = new Size(115, 44);
            lblDiophantineMutationProbability.TabIndex = 4;
            lblDiophantineMutationProbability.Text = "Pravděpodobnost mutace:";
            // 
            // nuDiophantineMutationProbability
            // 
            nuDiophantineMutationProbability.DecimalPlaces = 3;
            nuDiophantineMutationProbability.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nuDiophantineMutationProbability.Location = new Point(384, 37);
            nuDiophantineMutationProbability.Margin = new Padding(4);
            nuDiophantineMutationProbability.Maximum = new decimal(new int[] { 2, 0, 0, 65536 });
            nuDiophantineMutationProbability.Minimum = new decimal(new int[] { 1, 0, 0, 196608 });
            nuDiophantineMutationProbability.Name = "nuDiophantineMutationProbability";
            nuDiophantineMutationProbability.Size = new Size(67, 23);
            nuDiophantineMutationProbability.TabIndex = 3;
            nuDiophantineMutationProbability.Value = new decimal(new int[] { 5, 0, 0, 131072 });
            // 
            // nuDiophantineCrossoverProbability
            // 
            nuDiophantineCrossoverProbability.DecimalPlaces = 2;
            nuDiophantineCrossoverProbability.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            nuDiophantineCrossoverProbability.Location = new Point(144, 81);
            nuDiophantineCrossoverProbability.Margin = new Padding(4);
            nuDiophantineCrossoverProbability.Maximum = new decimal(new int[] { 99, 0, 0, 131072 });
            nuDiophantineCrossoverProbability.Minimum = new decimal(new int[] { 5, 0, 0, 65536 });
            nuDiophantineCrossoverProbability.Name = "nuDiophantineCrossoverProbability";
            nuDiophantineCrossoverProbability.Size = new Size(67, 23);
            nuDiophantineCrossoverProbability.TabIndex = 3;
            nuDiophantineCrossoverProbability.Value = new decimal(new int[] { 8, 0, 0, 65536 });
            // 
            // lblDiophantineCrossoverProbability
            // 
            lblDiophantineCrossoverProbability.Location = new Point(25, 76);
            lblDiophantineCrossoverProbability.Margin = new Padding(4, 0, 4, 0);
            lblDiophantineCrossoverProbability.Name = "lblDiophantineCrossoverProbability";
            lblDiophantineCrossoverProbability.Size = new Size(111, 37);
            lblDiophantineCrossoverProbability.TabIndex = 2;
            lblDiophantineCrossoverProbability.Text = "Pravděpodobnost křížení:";
            // 
            // nuDiophantineElitismPercent
            // 
            nuDiophantineElitismPercent.Enabled = false;
            nuDiophantineElitismPercent.Location = new Point(384, 81);
            nuDiophantineElitismPercent.Margin = new Padding(4);
            nuDiophantineElitismPercent.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nuDiophantineElitismPercent.Name = "nuDiophantineElitismPercent";
            nuDiophantineElitismPercent.Size = new Size(67, 23);
            nuDiophantineElitismPercent.TabIndex = 1;
            // 
            // nuDiophantineGenerationCount
            // 
            nuDiophantineGenerationCount.Location = new Point(144, 124);
            nuDiophantineGenerationCount.Margin = new Padding(4);
            nuDiophantineGenerationCount.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nuDiophantineGenerationCount.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            nuDiophantineGenerationCount.Name = "nuDiophantineGenerationCount";
            nuDiophantineGenerationCount.Size = new Size(67, 23);
            nuDiophantineGenerationCount.TabIndex = 1;
            nuDiophantineGenerationCount.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // lblDiophantineGenerationCount
            // 
            lblDiophantineGenerationCount.AutoSize = true;
            lblDiophantineGenerationCount.Location = new Point(25, 127);
            lblDiophantineGenerationCount.Margin = new Padding(4, 0, 4, 0);
            lblDiophantineGenerationCount.Name = "lblDiophantineGenerationCount";
            lblDiophantineGenerationCount.Size = new Size(68, 15);
            lblDiophantineGenerationCount.TabIndex = 0;
            lblDiophantineGenerationCount.Text = "Ukončit po:";
            // 
            // nuDiophantinePopulationSize
            // 
            nuDiophantinePopulationSize.Location = new Point(144, 34);
            nuDiophantinePopulationSize.Margin = new Padding(4);
            nuDiophantinePopulationSize.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            nuDiophantinePopulationSize.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            nuDiophantinePopulationSize.Name = "nuDiophantinePopulationSize";
            nuDiophantinePopulationSize.Size = new Size(67, 23);
            nuDiophantinePopulationSize.TabIndex = 1;
            nuDiophantinePopulationSize.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // lblDiophantinePopulationSize
            // 
            lblDiophantinePopulationSize.AutoSize = true;
            lblDiophantinePopulationSize.Location = new Point(25, 36);
            lblDiophantinePopulationSize.Margin = new Padding(4, 0, 4, 0);
            lblDiophantinePopulationSize.Name = "lblDiophantinePopulationSize";
            lblDiophantinePopulationSize.Size = new Size(102, 15);
            lblDiophantinePopulationSize.TabIndex = 0;
            lblDiophantinePopulationSize.Text = "Velikost populace:";
            // 
            // btnDiophantineRun
            // 
            btnDiophantineRun.Location = new Point(326, 350);
            btnDiophantineRun.Margin = new Padding(4);
            btnDiophantineRun.Name = "btnDiophantineRun";
            btnDiophantineRun.Size = new Size(88, 28);
            btnDiophantineRun.TabIndex = 10;
            btnDiophantineRun.Text = "Spustit!";
            btnDiophantineRun.UseVisualStyleBackColor = true;
            btnDiophantineRun.Click += btnDiophantineRun_Click;
            // 
            // btnDiophantineInterrupt
            // 
            btnDiophantineInterrupt.Enabled = false;
            btnDiophantineInterrupt.Location = new Point(422, 350);
            btnDiophantineInterrupt.Margin = new Padding(4);
            btnDiophantineInterrupt.Name = "btnDiophantineInterrupt";
            btnDiophantineInterrupt.Size = new Size(88, 28);
            btnDiophantineInterrupt.TabIndex = 20;
            btnDiophantineInterrupt.Text = "Přerušit";
            btnDiophantineInterrupt.UseVisualStyleBackColor = true;
            btnDiophantineInterrupt.Click += btnDiophantineInterrupt_Click;
            // 
            // imageListTabIcons
            // 
            imageListTabIcons.ColorDepth = ColorDepth.Depth32Bit;
            imageListTabIcons.ImageSize = new Size(16, 16);
            imageListTabIcons.TransparentColor = Color.Transparent;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1166, 586);
            Controls.Add(tabControlMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "XBIOM - NEURAL/GA DEMO, Mgr. Milan Čížek 2025";
            FormClosing += frmMain_FormClosing;
            tabControlMain.ResumeLayout(false);
            tabPageTspSom.ResumeLayout(false);
            tabPageTspSom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trkTspSomVisualizationSpeed).EndInit();
            gbTspSomParameters.ResumeLayout(false);
            gbTspSomParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nuTspSomTrainingCycles).EndInit();
            ((System.ComponentModel.ISupportInitialize)nuTspSomInitialLearningRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)nuTspSomCitiesCount).EndInit();
            panelTspSomDescription.ResumeLayout(false);
            tabPageSymReg.ResumeLayout(false);
            tabPageSymReg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSymRegResults).EndInit();
            gbSymRegParameters.ResumeLayout(false);
            gbSymRegParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nuSymRegPopulationSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)nuSymRegCrossoverProbability).EndInit();
            ((System.ComponentModel.ISupportInitialize)nuSymRegMutationProbability).EndInit();
            ((System.ComponentModel.ISupportInitialize)nuSymRegPointsCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)nuSymRegOutputPrecision).EndInit();
            ((System.ComponentModel.ISupportInitialize)nuSymRegMinFitness).EndInit();
            ((System.ComponentModel.ISupportInitialize)nuSymRegGenerationCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)nuSymRegChromosomeLength).EndInit();
            panelSymRegDescription.ResumeLayout(false);
            tabPageTspGa.ResumeLayout(false);
            tabPageTspGa.PerformLayout();
            panelTspGaDescription.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTspGaResults).EndInit();
            gbTspGaParameters.ResumeLayout(false);
            gbTspGaParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nuTspGaMutationProbability).EndInit();
            ((System.ComponentModel.ISupportInitialize)nuTspGaCrossoverProbability).EndInit();
            ((System.ComponentModel.ISupportInitialize)nuTspGaElitismPercent).EndInit();
            ((System.ComponentModel.ISupportInitialize)nuTspGaGenerationCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)nuTspGaPopulationSize).EndInit();
            tabPageDiophantine.ResumeLayout(false);
            tabPageDiophantine.PerformLayout();
            panelDiophantineDescription.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDiophantineResults).EndInit();
            gbDiophantineParameters.ResumeLayout(false);
            gbDiophantineParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nuDiophantineMutationProbability).EndInit();
            ((System.ComponentModel.ISupportInitialize)nuDiophantineCrossoverProbability).EndInit();
            ((System.ComponentModel.ISupportInitialize)nuDiophantineElitismPercent).EndInit();
            ((System.ComponentModel.ISupportInitialize)nuDiophantineGenerationCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)nuDiophantinePopulationSize).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageTspGa;
        private System.Windows.Forms.TabPage tabPageDiophantine;
        private System.Windows.Forms.TextBox tbTspGaResult;
        private System.Windows.Forms.ProgressBar pbTspGaProgress;
        private System.Windows.Forms.DataGridView dgvTspGaResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTspGaGeneration;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTspGaFitness;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTspGaDistance;
        private System.Windows.Forms.Label lblTspGaElapsedTime;
        private System.Windows.Forms.GroupBox gbTspGaParameters;
        private System.Windows.Forms.CheckBox cbTspGaUseElites;
        private System.Windows.Forms.Label lblTspGaGenerationsSuffix;
        private System.Windows.Forms.Label lblTspGaElitismPercent;
        private System.Windows.Forms.Label lblTspGaMutationProbability;
        private System.Windows.Forms.NumericUpDown nuTspGaMutationProbability;
        private System.Windows.Forms.NumericUpDown nuTspGaCrossoverProbability;
        private System.Windows.Forms.Label lblTspGaCrossoverProbability;
        private System.Windows.Forms.NumericUpDown nuTspGaElitismPercent;
        private System.Windows.Forms.NumericUpDown nuTspGaGenerationCount;
        private System.Windows.Forms.Label lblTspGaGenerationCount;
        private System.Windows.Forms.NumericUpDown nuTspGaPopulationSize;
        private System.Windows.Forms.Label lblTspGaPopulationSize;
        private System.Windows.Forms.Button btnTspGaRun;
        private System.Windows.Forms.Button btnTspGaInterrupt;
        private System.Windows.Forms.Label lblDiophantineElapsedTimeTitle;
        private System.Windows.Forms.TextBox tbDiophantineResult;
        private System.Windows.Forms.ProgressBar pbDiophantineProgress;
        private System.Windows.Forms.DataGridView dgvDiophantineResults;
        private System.Windows.Forms.Label lblDiophantineElapsedTime;
        private System.Windows.Forms.GroupBox gbDiophantineParameters;
        private System.Windows.Forms.CheckBox cbDiophantineUseElites;
        private System.Windows.Forms.Label lblDiophantineGenerationsSuffix;
        private System.Windows.Forms.Label lblDiophantineElitismPercent;
        private System.Windows.Forms.Label lblDiophantineMutationProbability;
        private System.Windows.Forms.NumericUpDown nuDiophantineMutationProbability;
        private System.Windows.Forms.NumericUpDown nuDiophantineCrossoverProbability;
        private System.Windows.Forms.Label lblDiophantineCrossoverProbability;
        private System.Windows.Forms.NumericUpDown nuDiophantineElitismPercent;
        private System.Windows.Forms.NumericUpDown nuDiophantineGenerationCount;
        private System.Windows.Forms.Label lblDiophantineGenerationCount;
        private System.Windows.Forms.NumericUpDown nuDiophantinePopulationSize;
        private System.Windows.Forms.Label lblDiophantinePopulationSize;
        private System.Windows.Forms.Button btnDiophantineRun;
        private System.Windows.Forms.Button btnDiophantineInterrupt;
        private System.Windows.Forms.Label lblTspGaElapsedTimeTitle;
        private System.Windows.Forms.CheckBox cbDiophantineEndOnPerfectFitness;
        private System.Windows.Forms.TabPage tabPageSymReg;
        private System.Windows.Forms.Panel panelSymRegDescription;
        private System.Windows.Forms.Label lblSymRegDescription;

        private System.Windows.Forms.TextBox tbSymRegResult;
        private ScottPlot.WinForms.FormsPlot formsPlotSymReg;
        private Button btnSymRegRun;
        private GroupBox gbSymRegParameters;
        private Label lblSymRegGenerationsSuffix;
        private NumericUpDown nuSymRegGenerationCount;
        private Label lblSymRegGenerationCount;
        private NumericUpDown nuSymRegChromosomeLength;
        private Label lblSymRegChromosomeLength;
        private DataGridView dgvSymRegResults;
        private ProgressBar pbSymRegProgress;
        private Button btnSymRegInterrupt;
        private CheckBox cbSymRegAllowEndOnFitness;
        private NumericUpDown nuSymRegMinFitness;
        private Label lblSymRegElapsedTimeTitle;
        private Label lblSymRegElapsedTime;
        private NumericUpDown nuSymRegOutputPrecision;
        private Label lblSymRegOutputPrecision;
        private NumericUpDown nuSymRegPointsCount;
        private Label lblSymRegPointsCount;
        private Label lblSymRegMutationProbability;
        private NumericUpDown nuSymRegMutationProbability;
        private Label lblSymRegPopulationSize;
        private NumericUpDown nuSymRegPopulationSize;
        private Label lblSymRegCrossoverProbability;
        private NumericUpDown nuSymRegCrossoverProbability;
        private Panel panelTspGaDescription;
        private Label lblTspGaDescription;
        private Panel panelDiophantineDescription;
        private Label lblDiophantineDescription;
        private DataGridViewTextBoxColumn colDiophantineGeneration;
        private DataGridViewTextBoxColumn colDiophantineFitness;
        private DataGridViewTextBoxColumn colDiophantineA;
        private DataGridViewTextBoxColumn colDiophantineB;
        private DataGridViewTextBoxColumn colDiophantineC;
        private DataGridViewTextBoxColumn colDiophantineD;
        private DataGridViewTextBoxColumn colDiophantineResult;
        private DataGridViewTextBoxColumn colSymRegGeneration;
        private DataGridViewTextBoxColumn colSymRegFitness;
        private DataGridViewTextBoxColumn colSymRegComplexity;
        private TabPage tabPageTspSom;
        private Label lblTspSomTrainingCycles;
        private Button btnTspSomRandomizeMap;
        private Label lblTspSomCitiesCount;
        private ZedGraph.ZedGraphControl zedTspSomCitiesGraph;
        private NumericUpDown nuTspSomTrainingCycles;
        private NumericUpDown nuTspSomCitiesCount;
        private Button btnTspSomStop;
        private Button btnTspSomRun;
        private Label lblTspSomInitialLearningRate;
        private NumericUpDown nuTspSomInitialLearningRate;
        private Panel panelTspSomDescription;
        private Label lblTspSomDescription;
        private GroupBox gbTspSomParameters;
        private Label lblTspSomElapsedTimeTitle;
        private ProgressBar pbTspSomTraining;
        private Label lblTspSomElapsedTime;
        private ScottPlot.WinForms.FormsPlot formsPlotTspSomError;
        private ImageList imageListTabIcons;
        private Label lblTspSomVisualizationSpeed;
        private TrackBar trkTspSomVisualizationSpeed;
        private CheckBox chkTspSomShowVisualization;
    }
}
