namespace API
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.simulationTab = new System.Windows.Forms.TabPage();
            this.gravityLabel = new System.Windows.Forms.Label();
            this.pressureLabel = new System.Windows.Forms.Label();
            this.densityLabel = new System.Windows.Forms.Label();
            this.isaLabel = new System.Windows.Forms.Label();
            this.unitMaxSimV = new System.Windows.Forms.Label();
            this.simulationVelocityLabel = new System.Windows.Forms.Label();
            this.simulationSpeed = new System.Windows.Forms.TextBox();
            this.thrustTab = new System.Windows.Forms.TabPage();
            this.propellerProperty = new System.Windows.Forms.CheckBox();
            this.failedEngineUnitLabel = new System.Windows.Forms.Label();
            this.maxEngineUnitLabel = new System.Windows.Forms.Label();
            this.nrFailedEngines = new System.Windows.Forms.TextBox();
            this.nrEngines = new System.Windows.Forms.TextBox();
            this.engineFailureLabel = new System.Windows.Forms.Label();
            this.maxEngineLabel = new System.Windows.Forms.Label();
            this.unitThrustLabel = new System.Windows.Forms.Label();
            this.maxAvailableThrust = new System.Windows.Forms.TextBox();
            this.maxThrustLabel = new System.Windows.Forms.Label();
            this.aeroTab = new System.Windows.Forms.TabPage();
            this.frictionTab = new System.Windows.Forms.TabPage();
            this.muBrakeUnitLabel = new System.Windows.Forms.Label();
            this.muRollUnitLabel = new System.Windows.Forms.Label();
            this.muBrake = new System.Windows.Forms.TextBox();
            this.muBrakeLabel = new System.Windows.Forms.Label();
            this.muRoll = new System.Windows.Forms.TextBox();
            this.muRollLabel = new System.Windows.Forms.Label();
            this.miscTab = new System.Windows.Forms.TabPage();
            this.maxPitcUnitLabel = new System.Windows.Forms.Label();
            this.pitchGradientUnitLabel = new System.Windows.Forms.Label();
            this.weightUnitLabel = new System.Windows.Forms.Label();
            this.pitchGradient = new System.Windows.Forms.TextBox();
            this.maxPitch = new System.Windows.Forms.TextBox();
            this.weight = new System.Windows.Forms.TextBox();
            this.pitchGradientLabel = new System.Windows.Forms.Label();
            this.maxPitchAngleLabel = new System.Windows.Forms.Label();
            this.weightLabel = new System.Windows.Forms.Label();
            this.configLabel = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aircraftNameLabel = new System.Windows.Forms.Label();
            this.aircraftName = new System.Windows.Forms.TextBox();
            this.quitButton = new System.Windows.Forms.Button();
            this.clearAll = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.simulationTab.SuspendLayout();
            this.thrustTab.SuspendLayout();
            this.frictionTab.SuspendLayout();
            this.miscTab.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(100, 40);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(177, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommited);
            this.comboBox1.Enter += new System.EventHandler(this.comboBox1_Enter);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.simulationTab);
            this.tabControl1.Controls.Add(this.thrustTab);
            this.tabControl1.Controls.Add(this.aeroTab);
            this.tabControl1.Controls.Add(this.frictionTab);
            this.tabControl1.Controls.Add(this.miscTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 122);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(341, 231);
            this.tabControl1.TabIndex = 1;
            // 
            // simulationTab
            // 
            this.simulationTab.Controls.Add(this.gravityLabel);
            this.simulationTab.Controls.Add(this.pressureLabel);
            this.simulationTab.Controls.Add(this.densityLabel);
            this.simulationTab.Controls.Add(this.isaLabel);
            this.simulationTab.Controls.Add(this.unitMaxSimV);
            this.simulationTab.Controls.Add(this.simulationVelocityLabel);
            this.simulationTab.Controls.Add(this.simulationSpeed);
            this.simulationTab.Location = new System.Drawing.Point(4, 22);
            this.simulationTab.Name = "simulationTab";
            this.simulationTab.Padding = new System.Windows.Forms.Padding(3);
            this.simulationTab.Size = new System.Drawing.Size(333, 205);
            this.simulationTab.TabIndex = 0;
            this.simulationTab.Text = "Simulation";
            this.simulationTab.ToolTipText = "Contains simulation parameters";
            this.simulationTab.UseVisualStyleBackColor = true;
            // 
            // gravityLabel
            // 
            this.gravityLabel.AutoSize = true;
            this.gravityLabel.Location = new System.Drawing.Point(6, 97);
            this.gravityLabel.Name = "gravityLabel";
            this.gravityLabel.Size = new System.Drawing.Size(70, 13);
            this.gravityLabel.TabIndex = 6;
            this.gravityLabel.Text = "g0: 9.8 [m/s²]";
            // 
            // pressureLabel
            // 
            this.pressureLabel.AutoSize = true;
            this.pressureLabel.Location = new System.Drawing.Point(6, 84);
            this.pressureLabel.Name = "pressureLabel";
            this.pressureLabel.Size = new System.Drawing.Size(186, 13);
            this.pressureLabel.TabIndex = 5;
            this.pressureLabel.Text = "Atmospheric pressure: 1.01325 [N/m²]";
            // 
            // densityLabel
            // 
            this.densityLabel.AutoSize = true;
            this.densityLabel.Location = new System.Drawing.Point(6, 71);
            this.densityLabel.Name = "densityLabel";
            this.densityLabel.Size = new System.Drawing.Size(118, 13);
            this.densityLabel.TabIndex = 4;
            this.densityLabel.Text = "Density: 1.1225 [kg/m³]";
            // 
            // isaLabel
            // 
            this.isaLabel.AutoSize = true;
            this.isaLabel.Location = new System.Drawing.Point(6, 58);
            this.isaLabel.Name = "isaLabel";
            this.isaLabel.Size = new System.Drawing.Size(53, 13);
            this.isaLabel.TabIndex = 3;
            this.isaLabel.Text = "ISA: 0 [m]";
            // 
            // unitMaxSimV
            // 
            this.unitMaxSimV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.unitMaxSimV.AutoSize = true;
            this.unitMaxSimV.Location = new System.Drawing.Point(220, 12);
            this.unitMaxSimV.Name = "unitMaxSimV";
            this.unitMaxSimV.Size = new System.Drawing.Size(31, 13);
            this.unitMaxSimV.TabIndex = 2;
            this.unitMaxSimV.Text = "[m/s]";
            // 
            // simulationVelocityLabel
            // 
            this.simulationVelocityLabel.Location = new System.Drawing.Point(6, 9);
            this.simulationVelocityLabel.Name = "simulationVelocityLabel";
            this.simulationVelocityLabel.Size = new System.Drawing.Size(101, 30);
            this.simulationVelocityLabel.TabIndex = 1;
            this.simulationVelocityLabel.Text = "Maximum simulation velocity";
            // 
            // simulationSpeed
            // 
            this.simulationSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.simulationSpeed.Location = new System.Drawing.Point(114, 6);
            this.simulationSpeed.Name = "simulationSpeed";
            this.simulationSpeed.Size = new System.Drawing.Size(100, 20);
            this.simulationSpeed.TabIndex = 0;
            this.simulationSpeed.TextChanged += new System.EventHandler(this.simulationSpeed_TextChanged);
            this.simulationSpeed.MouseHover += new System.EventHandler(this.simulationSpeed_MouseHover);
            // 
            // thrustTab
            // 
            this.thrustTab.Controls.Add(this.propellerProperty);
            this.thrustTab.Controls.Add(this.failedEngineUnitLabel);
            this.thrustTab.Controls.Add(this.maxEngineUnitLabel);
            this.thrustTab.Controls.Add(this.nrFailedEngines);
            this.thrustTab.Controls.Add(this.nrEngines);
            this.thrustTab.Controls.Add(this.engineFailureLabel);
            this.thrustTab.Controls.Add(this.maxEngineLabel);
            this.thrustTab.Controls.Add(this.unitThrustLabel);
            this.thrustTab.Controls.Add(this.maxAvailableThrust);
            this.thrustTab.Controls.Add(this.maxThrustLabel);
            this.thrustTab.Location = new System.Drawing.Point(4, 22);
            this.thrustTab.Name = "thrustTab";
            this.thrustTab.Padding = new System.Windows.Forms.Padding(3);
            this.thrustTab.Size = new System.Drawing.Size(333, 205);
            this.thrustTab.TabIndex = 1;
            this.thrustTab.Text = "Thrust";
            this.thrustTab.ToolTipText = "Contains thrust properties of the airplane";
            this.thrustTab.UseVisualStyleBackColor = true;
            // 
            // propellerProperty
            // 
            this.propellerProperty.AutoSize = true;
            this.propellerProperty.Location = new System.Drawing.Point(10, 182);
            this.propellerProperty.Name = "propellerProperty";
            this.propellerProperty.Size = new System.Drawing.Size(97, 17);
            this.propellerProperty.TabIndex = 7;
            this.propellerProperty.Text = "Propellor Plane";
            this.propellerProperty.UseVisualStyleBackColor = true;
            // 
            // failedEngineUnitLabel
            // 
            this.failedEngineUnitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.failedEngineUnitLabel.AutoSize = true;
            this.failedEngineUnitLabel.Location = new System.Drawing.Point(230, 63);
            this.failedEngineUnitLabel.Name = "failedEngineUnitLabel";
            this.failedEngineUnitLabel.Size = new System.Drawing.Size(16, 13);
            this.failedEngineUnitLabel.TabIndex = 6;
            this.failedEngineUnitLabel.Text = "[-]";
            // 
            // maxEngineUnitLabel
            // 
            this.maxEngineUnitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxEngineUnitLabel.AutoSize = true;
            this.maxEngineUnitLabel.Location = new System.Drawing.Point(230, 36);
            this.maxEngineUnitLabel.Name = "maxEngineUnitLabel";
            this.maxEngineUnitLabel.Size = new System.Drawing.Size(16, 13);
            this.maxEngineUnitLabel.TabIndex = 5;
            this.maxEngineUnitLabel.Text = "[-]";
            // 
            // nrFailedEngines
            // 
            this.nrFailedEngines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nrFailedEngines.Location = new System.Drawing.Point(124, 60);
            this.nrFailedEngines.Name = "nrFailedEngines";
            this.nrFailedEngines.Size = new System.Drawing.Size(100, 20);
            this.nrFailedEngines.TabIndex = 4;
            this.nrFailedEngines.TextChanged += new System.EventHandler(this.nrFailedEngines_TextChanged);
            this.nrFailedEngines.MouseHover += new System.EventHandler(this.nrFailedEngines_MouseHover);
            // 
            // nrEngines
            // 
            this.nrEngines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nrEngines.Location = new System.Drawing.Point(124, 33);
            this.nrEngines.Name = "nrEngines";
            this.nrEngines.Size = new System.Drawing.Size(100, 20);
            this.nrEngines.TabIndex = 3;
            this.nrEngines.TextChanged += new System.EventHandler(this.nrEngines_TextChanged);
            this.nrEngines.MouseHover += new System.EventHandler(this.nrEngines_MouseHover);
            // 
            // engineFailureLabel
            // 
            this.engineFailureLabel.AutoSize = true;
            this.engineFailureLabel.Location = new System.Drawing.Point(7, 63);
            this.engineFailureLabel.Name = "engineFailureLabel";
            this.engineFailureLabel.Size = new System.Drawing.Size(104, 13);
            this.engineFailureLabel.TabIndex = 1;
            this.engineFailureLabel.Text = "Nr. of engines failed:";
            // 
            // maxEngineLabel
            // 
            this.maxEngineLabel.AutoSize = true;
            this.maxEngineLabel.Location = new System.Drawing.Point(7, 36);
            this.maxEngineLabel.Name = "maxEngineLabel";
            this.maxEngineLabel.Size = new System.Drawing.Size(79, 13);
            this.maxEngineLabel.TabIndex = 0;
            this.maxEngineLabel.Text = "Nr. of engines: ";
            // 
            // unitThrustLabel
            // 
            this.unitThrustLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.unitThrustLabel.AutoSize = true;
            this.unitThrustLabel.Location = new System.Drawing.Point(230, 9);
            this.unitThrustLabel.Name = "unitThrustLabel";
            this.unitThrustLabel.Size = new System.Drawing.Size(21, 13);
            this.unitThrustLabel.TabIndex = 2;
            this.unitThrustLabel.Text = "[N]";
            // 
            // maxAvailableThrust
            // 
            this.maxAvailableThrust.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.maxAvailableThrust.Location = new System.Drawing.Point(124, 6);
            this.maxAvailableThrust.Name = "maxAvailableThrust";
            this.maxAvailableThrust.Size = new System.Drawing.Size(100, 20);
            this.maxAvailableThrust.TabIndex = 1;
            this.maxAvailableThrust.TextChanged += new System.EventHandler(this.maxAvailableThrust_TextChanged);
            this.maxAvailableThrust.MouseHover += new System.EventHandler(this.maxAvailableThrust_MouseHover);
            // 
            // maxThrustLabel
            // 
            this.maxThrustLabel.AutoSize = true;
            this.maxThrustLabel.Location = new System.Drawing.Point(7, 9);
            this.maxThrustLabel.Name = "maxThrustLabel";
            this.maxThrustLabel.Size = new System.Drawing.Size(86, 13);
            this.maxThrustLabel.TabIndex = 0;
            this.maxThrustLabel.Text = "Maximum thrust: ";
            // 
            // aeroTab
            // 
            this.aeroTab.Location = new System.Drawing.Point(4, 22);
            this.aeroTab.Name = "aeroTab";
            this.aeroTab.Padding = new System.Windows.Forms.Padding(3);
            this.aeroTab.Size = new System.Drawing.Size(333, 205);
            this.aeroTab.TabIndex = 2;
            this.aeroTab.Text = "Aerodynamics";
            this.aeroTab.ToolTipText = "Contains aerodynamic properties of the airplane";
            this.aeroTab.UseVisualStyleBackColor = true;
            // 
            // frictionTab
            // 
            this.frictionTab.Controls.Add(this.muBrakeUnitLabel);
            this.frictionTab.Controls.Add(this.muRollUnitLabel);
            this.frictionTab.Controls.Add(this.muBrake);
            this.frictionTab.Controls.Add(this.muBrakeLabel);
            this.frictionTab.Controls.Add(this.muRoll);
            this.frictionTab.Controls.Add(this.muRollLabel);
            this.frictionTab.Location = new System.Drawing.Point(4, 22);
            this.frictionTab.Name = "frictionTab";
            this.frictionTab.Padding = new System.Windows.Forms.Padding(3);
            this.frictionTab.Size = new System.Drawing.Size(333, 205);
            this.frictionTab.TabIndex = 3;
            this.frictionTab.Text = "Friction";
            this.frictionTab.ToolTipText = "Contains roll friction coefficients for the airplane";
            this.frictionTab.UseVisualStyleBackColor = true;
            // 
            // muBrakeUnitLabel
            // 
            this.muBrakeUnitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.muBrakeUnitLabel.AutoSize = true;
            this.muBrakeUnitLabel.Location = new System.Drawing.Point(155, 37);
            this.muBrakeUnitLabel.Name = "muBrakeUnitLabel";
            this.muBrakeUnitLabel.Size = new System.Drawing.Size(16, 13);
            this.muBrakeUnitLabel.TabIndex = 5;
            this.muBrakeUnitLabel.Text = "[-]";
            // 
            // muRollUnitLabel
            // 
            this.muRollUnitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.muRollUnitLabel.AutoSize = true;
            this.muRollUnitLabel.Location = new System.Drawing.Point(155, 10);
            this.muRollUnitLabel.Name = "muRollUnitLabel";
            this.muRollUnitLabel.Size = new System.Drawing.Size(16, 13);
            this.muRollUnitLabel.TabIndex = 4;
            this.muRollUnitLabel.Text = "[-]";
            // 
            // muBrake
            // 
            this.muBrake.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.muBrake.Location = new System.Drawing.Point(49, 34);
            this.muBrake.Name = "muBrake";
            this.muBrake.Size = new System.Drawing.Size(100, 20);
            this.muBrake.TabIndex = 3;
            // 
            // muBrakeLabel
            // 
            this.muBrakeLabel.AutoSize = true;
            this.muBrakeLabel.Location = new System.Drawing.Point(6, 37);
            this.muBrakeLabel.Name = "muBrakeLabel";
            this.muBrakeLabel.Size = new System.Drawing.Size(47, 13);
            this.muBrakeLabel.TabIndex = 2;
            this.muBrakeLabel.Text = "μBrake: ";
            // 
            // muRoll
            // 
            this.muRoll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.muRoll.Location = new System.Drawing.Point(49, 7);
            this.muRoll.Name = "muRoll";
            this.muRoll.Size = new System.Drawing.Size(100, 20);
            this.muRoll.TabIndex = 1;
            this.muRoll.TextChanged += new System.EventHandler(this.muRoll_TextChanged);
            this.muRoll.MouseHover += new System.EventHandler(this.muRoll_MouseHover);
            // 
            // muRollLabel
            // 
            this.muRollLabel.AutoSize = true;
            this.muRollLabel.Location = new System.Drawing.Point(6, 10);
            this.muRollLabel.Name = "muRollLabel";
            this.muRollLabel.Size = new System.Drawing.Size(37, 13);
            this.muRollLabel.TabIndex = 0;
            this.muRollLabel.Text = "μRoll: ";
            // 
            // miscTab
            // 
            this.miscTab.Controls.Add(this.maxPitcUnitLabel);
            this.miscTab.Controls.Add(this.pitchGradientUnitLabel);
            this.miscTab.Controls.Add(this.weightUnitLabel);
            this.miscTab.Controls.Add(this.pitchGradient);
            this.miscTab.Controls.Add(this.maxPitch);
            this.miscTab.Controls.Add(this.weight);
            this.miscTab.Controls.Add(this.pitchGradientLabel);
            this.miscTab.Controls.Add(this.maxPitchAngleLabel);
            this.miscTab.Controls.Add(this.weightLabel);
            this.miscTab.Location = new System.Drawing.Point(4, 22);
            this.miscTab.Name = "miscTab";
            this.miscTab.Padding = new System.Windows.Forms.Padding(3);
            this.miscTab.Size = new System.Drawing.Size(333, 205);
            this.miscTab.TabIndex = 4;
            this.miscTab.Text = "Misc.";
            this.miscTab.ToolTipText = "Contains miscallenous properties of the airplane";
            this.miscTab.UseVisualStyleBackColor = true;
            // 
            // maxPitcUnitLabel
            // 
            this.maxPitcUnitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxPitcUnitLabel.AutoSize = true;
            this.maxPitcUnitLabel.Location = new System.Drawing.Point(207, 37);
            this.maxPitcUnitLabel.Name = "maxPitcUnitLabel";
            this.maxPitcUnitLabel.Size = new System.Drawing.Size(33, 13);
            this.maxPitcUnitLabel.TabIndex = 8;
            this.maxPitcUnitLabel.Text = "[Deg]";
            // 
            // pitchGradientUnitLabel
            // 
            this.pitchGradientUnitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pitchGradientUnitLabel.AutoSize = true;
            this.pitchGradientUnitLabel.Location = new System.Drawing.Point(207, 63);
            this.pitchGradientUnitLabel.Name = "pitchGradientUnitLabel";
            this.pitchGradientUnitLabel.Size = new System.Drawing.Size(55, 13);
            this.pitchGradientUnitLabel.TabIndex = 7;
            this.pitchGradientUnitLabel.Text = "[Deg/sec]";
            // 
            // weightUnitLabel
            // 
            this.weightUnitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.weightUnitLabel.AutoSize = true;
            this.weightUnitLabel.Location = new System.Drawing.Point(208, 7);
            this.weightUnitLabel.Name = "weightUnitLabel";
            this.weightUnitLabel.Size = new System.Drawing.Size(21, 13);
            this.weightUnitLabel.TabIndex = 6;
            this.weightUnitLabel.Text = "[N]";
            // 
            // pitchGradient
            // 
            this.pitchGradient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pitchGradient.Location = new System.Drawing.Point(101, 60);
            this.pitchGradient.Name = "pitchGradient";
            this.pitchGradient.Size = new System.Drawing.Size(100, 20);
            this.pitchGradient.TabIndex = 5;
            this.pitchGradient.TextChanged += new System.EventHandler(this.pitchGradient_TextChanged);
            this.pitchGradient.MouseHover += new System.EventHandler(this.pitchGradient_MouseHover);
            // 
            // maxPitch
            // 
            this.maxPitch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.maxPitch.Location = new System.Drawing.Point(101, 34);
            this.maxPitch.Name = "maxPitch";
            this.maxPitch.Size = new System.Drawing.Size(100, 20);
            this.maxPitch.TabIndex = 4;
            this.maxPitch.TextChanged += new System.EventHandler(this.maxPitch_TextChanged);
            this.maxPitch.MouseHover += new System.EventHandler(this.maxPitch_MouseHover);
            // 
            // weight
            // 
            this.weight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.weight.Location = new System.Drawing.Point(101, 4);
            this.weight.Name = "weight";
            this.weight.Size = new System.Drawing.Size(100, 20);
            this.weight.TabIndex = 3;
            this.weight.TextChanged += new System.EventHandler(this.weight_TextChanged);
            this.weight.MouseHover += new System.EventHandler(this.weight_MouseHover);
            // 
            // pitchGradientLabel
            // 
            this.pitchGradientLabel.AutoSize = true;
            this.pitchGradientLabel.Location = new System.Drawing.Point(7, 63);
            this.pitchGradientLabel.Name = "pitchGradientLabel";
            this.pitchGradientLabel.Size = new System.Drawing.Size(36, 13);
            this.pitchGradientLabel.TabIndex = 2;
            this.pitchGradientLabel.Text = "dθ/dt:";
            // 
            // maxPitchAngleLabel
            // 
            this.maxPitchAngleLabel.AutoSize = true;
            this.maxPitchAngleLabel.Location = new System.Drawing.Point(7, 36);
            this.maxPitchAngleLabel.Name = "maxPitchAngleLabel";
            this.maxPitchAngleLabel.Size = new System.Drawing.Size(88, 13);
            this.maxPitchAngleLabel.TabIndex = 1;
            this.maxPitchAngleLabel.Text = "Max. pitch angle:";
            // 
            // weightLabel
            // 
            this.weightLabel.AutoSize = true;
            this.weightLabel.Location = new System.Drawing.Point(7, 7);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(44, 13);
            this.weightLabel.TabIndex = 0;
            this.weightLabel.Text = "Weight:";
            // 
            // configLabel
            // 
            this.configLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.configLabel.AutoSize = true;
            this.configLabel.Location = new System.Drawing.Point(9, 40);
            this.configLabel.Name = "configLabel";
            this.configLabel.Size = new System.Drawing.Size(72, 13);
            this.configLabel.TabIndex = 2;
            this.configLabel.Text = "Configuration:";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(446, 24);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aircraftNameLabel
            // 
            this.aircraftNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.aircraftNameLabel.AutoSize = true;
            this.aircraftNameLabel.Location = new System.Drawing.Point(9, 76);
            this.aircraftNameLabel.Name = "aircraftNameLabel";
            this.aircraftNameLabel.Size = new System.Drawing.Size(72, 13);
            this.aircraftNameLabel.TabIndex = 4;
            this.aircraftNameLabel.Text = "Aircraft name:";
            // 
            // aircraftName
            // 
            this.aircraftName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.aircraftName.Location = new System.Drawing.Point(100, 73);
            this.aircraftName.Name = "aircraftName";
            this.aircraftName.Size = new System.Drawing.Size(177, 20);
            this.aircraftName.TabIndex = 5;
            // 
            // quitButton
            // 
            this.quitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.quitButton.Location = new System.Drawing.Point(359, 330);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(75, 23);
            this.quitButton.TabIndex = 6;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quit_Click);
            // 
            // clearAll
            // 
            this.clearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearAll.Location = new System.Drawing.Point(360, 144);
            this.clearAll.Name = "clearAll";
            this.clearAll.Size = new System.Drawing.Size(75, 23);
            this.clearAll.TabIndex = 7;
            this.clearAll.Text = "Clear";
            this.clearAll.UseVisualStyleBackColor = true;
            this.clearAll.Click += new System.EventHandler(this.clearAll_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 369);
            this.Controls.Add(this.clearAll);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.aircraftName);
            this.Controls.Add(this.aircraftNameLabel);
            this.Controls.Add(this.configLabel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Main";
            this.tabControl1.ResumeLayout(false);
            this.simulationTab.ResumeLayout(false);
            this.simulationTab.PerformLayout();
            this.thrustTab.ResumeLayout(false);
            this.thrustTab.PerformLayout();
            this.frictionTab.ResumeLayout(false);
            this.frictionTab.PerformLayout();
            this.miscTab.ResumeLayout(false);
            this.miscTab.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region: Form items
        //Headers
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox aircraftName;

        private System.Windows.Forms.Label configLabel;
        private System.Windows.Forms.Label aircraftNameLabel;
        
        //Toolstrip items
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;

        //Tabpage items
        private System.Windows.Forms.TabPage simulationTab;
        private System.Windows.Forms.Label simulationVelocityLabel;
        private System.Windows.Forms.Label unitMaxSimV;
        private System.Windows.Forms.Label gravityLabel;
        private System.Windows.Forms.Label pressureLabel;
        private System.Windows.Forms.Label densityLabel;
        private System.Windows.Forms.Label isaLabel;
        private System.Windows.Forms.TextBox simulationSpeed;
        
        private System.Windows.Forms.TabPage thrustTab;
        private System.Windows.Forms.Label maxThrustLabel;
        private System.Windows.Forms.Label unitThrustLabel;
        private System.Windows.Forms.Label engineFailureLabel;
        private System.Windows.Forms.Label maxEngineLabel;
        private System.Windows.Forms.Label failedEngineUnitLabel;
        private System.Windows.Forms.Label maxEngineUnitLabel;
        private System.Windows.Forms.TextBox maxAvailableThrust;
        private System.Windows.Forms.TextBox nrEngines;
        private System.Windows.Forms.TextBox nrFailedEngines;
        private System.Windows.Forms.CheckBox propellerProperty;        

        private System.Windows.Forms.TabPage aeroTab;


        private System.Windows.Forms.TabPage frictionTab;
        private System.Windows.Forms.Label muBrakeLabel;
        private System.Windows.Forms.Label muRollLabel;
        private System.Windows.Forms.Label muBrakeUnitLabel;
        private System.Windows.Forms.Label muRollUnitLabel;
        private System.Windows.Forms.TextBox muRoll;
        private System.Windows.Forms.TextBox muBrake;

        private System.Windows.Forms.TabPage miscTab;
        private System.Windows.Forms.Label pitchGradientLabel;
        private System.Windows.Forms.Label maxPitchAngleLabel;
        private System.Windows.Forms.Label weightLabel;
        private System.Windows.Forms.Label maxPitcUnitLabel;
        private System.Windows.Forms.Label pitchGradientUnitLabel;
        private System.Windows.Forms.Label weightUnitLabel;
        private System.Windows.Forms.TextBox pitchGradient;
        private System.Windows.Forms.TextBox maxPitch;
        private System.Windows.Forms.TextBox weight;

        private System.Windows.Forms.Button clearAll;

        private System.Windows.Forms.Button quitButton;

        #endregion:
    }
}

