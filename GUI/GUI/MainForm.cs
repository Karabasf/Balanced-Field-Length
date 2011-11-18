using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace API
{
    public partial class MainForm : Form
    {
        //Enumerator for the combobox
        enum airplaneType {Custom, TwoEnginesJet, ThreeEnginesJet, FourEnginesJet};

        private string [] comboBoxItems = {"Custom..", "Two Engine Jetplane", "Three Engine Jetplane", "Four Engine Jetplane"};
        private int comboBoxSelectedIndex = 0;

        ToolTip errorTooltip = new ToolTip();

        public MainForm()
        {
            InitializeComponent();
            SetFormProperties();
            SetErrorTooltipProperties();
        }

        private void SetFormProperties()
        {           
            //Combobox properties
            comboBox1.Items.AddRange(comboBoxItems);
            comboBox1.SelectedIndex = 0;

            //Textbox value
            simulationSpeed.Text = "100";

            //Tooltip properties for the header items
            SetToolTipProperties(this.comboBox1, "Contains a list with preset airplane configurations");
            SetToolTipProperties(this.aircraftName, "The name of the airplane");

            //Tooltips for the Simulation tab
            SetToolTipProperties(this.simulationVelocityLabel, "The maximum simulationspeed which needs to be evaluated");

            //Tooltips for the Thrust tab
            SetToolTipProperties(this.maxThrustLabel, "Maximum available thrust of the airplane");
            SetToolTipProperties(this.maxEngineLabel, "Total available engines of the airplane");
            SetToolTipProperties(this.engineFailureLabel, "The amount of failed engines after take-off procedure");
            SetToolTipProperties(this.propellerProperty, "Indicates whether the plane is a propellor plane");

            this.propellerProperty.Visible = false;
            this.propellerProperty.Enabled = false;
            this.propellerProperty.Checked = false;

            //Tooltips for the frictiontab
            SetToolTipProperties(this.muRollLabel, "Kinematic friction coefficient for the airplane simulation");
            SetToolTipProperties(this.muBrakeLabel, "Kinematic friction coefficient when brakes of the airplane are activated");

            //Tooltips for the misc.tab
            SetToolTipProperties(this.weightLabel, "Take off weight of the airplane");
            SetToolTipProperties(this.pitchGradientLabel, "Pitch angle gradient during the rotation of the airplane");
            SetToolTipProperties(this.maxPitchAngleLabel, "The maximum pitch angle during the rotation of the airplane");

            //Tooltip for the buttons
            SetToolTipProperties(this.clearAll, "Clears all user input");
        }

        #region: Tooltip settings
        //Tooltip settings
        private void SetToolTipProperties(Control control, string text)
        {
            customToolTip tooltip = new customToolTip();

            //Variables
            tooltip.AssignedControl = control;
            tooltip.TooltipText = text;
            
            //Time settings
            tooltip.AutoShow = 5000;
            tooltip.InitialDelay = 1000;
            tooltip.ReshowDelay = 500;

            tooltip.setTooltip(true);
        }

        //Initial error tooltip settings
        private void SetErrorTooltipProperties()
        {
            errorTooltip.ReshowDelay = 500;
            errorTooltip.InitialDelay = 1000;
            errorTooltip.AutoPopDelay = 5000;
            errorTooltip.IsBalloon = false;
        }
        #endregion:

        #region: Properties of Textboxes with 'double' validation
        private void setPropertiesDoubleValidation(TextBox textBox)
        {
            textBox.BackColor = Color.White;

            errorTooltip.Hide(textBox);
            errorTooltip.Active = false;

            ValidationMethods.ValidateDouble(textBox);
        }

        private void setPropertiesDoubleMouseHover(TextBox textbox)
        {
            errorTooltip.Hide(nrFailedEngines);
            errorTooltip.Active = false;

            ValidationMethods.ValidateDouble(textbox, errorTooltip);
        }
        #endregion:

        private void DetermineChoice(airplaneType airplaneChoice)
        {
            switch (airplaneChoice)
            {
                case airplaneType.TwoEnginesJet:
                    this.aircraftName.Text = "Two Engine Jetplane";
                    this.comboBox1.SelectedIndex = 1;
                                        
                    this.maxAvailableThrust.Text = "150e3";
                    this.nrFailedEngines.Text = "1";
                    this.nrEngines.Text = "2";

                    this.muRoll.Text = "0.02";
                    this.muBrake.Text = "0.2";

                    this.weight.Text = "500e3";
                    this.maxPitch.Text = "16";
                    this.pitchGradient.Text = "6";

                    break;
                case airplaneType.ThreeEnginesJet:
                    this.aircraftName.Text = "Three Engine Jetplane";
                    this.comboBox1.SelectedIndex = 2;
                                        
                    this.maxAvailableThrust.Text = "360e3";
                    this.nrFailedEngines.Text = "1";
                    this.nrEngines.Text = "3";

                    this.muRoll.Text = "0.02";
                    this.muBrake.Text = "0.2";

                    this.weight.Text = "1200e3";
                    this.maxPitch.Text = "15";
                    this.pitchGradient.Text = "5";

                    break;
                case airplaneType.FourEnginesJet:
                    this.aircraftName.Text = "Four Engine Jetplane";
                    this.comboBox1.SelectedIndex = 3;
                    
                    this.maxAvailableThrust.Text = "1200e3";
                    this.nrFailedEngines.Text = "1";
                    this.nrEngines.Text = "4";

                    this.muRoll.Text = "0.02";
                    this.muBrake.Text = "0.2";

                    this.weight.Text = "3500e3";
                    this.maxPitch.Text = "14";
                    this.pitchGradient.Text = "4";
                    
                    break;
                case airplaneType.Custom:
                    this.aircraftName.Clear();
                    this.comboBox1.SelectedIndex = 0;
                    break;
                default:
                    MessageBox.Show("Could not determine the user choice", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        #region: Events

        #region: Header events
        //Menustrip events
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not available yet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        //ComboboxEvents
        private void comboBox1_Enter(object sender, EventArgs e)
        {
            comboBoxSelectedIndex = this.comboBox1.SelectedIndex;
        }

        private void comboBox1_SelectionChangeCommited(object sender, EventArgs e)
        {
            int userChoice = comboBox1.SelectedIndex;

            if (userChoice != 0)
            {
                DialogResult result = MessageBox.Show("Changing the configuration will override ALL custom user input.\n\nAre you sure you want to continue?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    airplaneType airplaneChoice = (airplaneType)userChoice;
                    DetermineChoice(airplaneChoice);
                }
                else
                {
                    this.comboBox1.SelectedIndex = comboBoxSelectedIndex;
                }
            }
        }
        #endregion:

        #region: Simulation tab events
        //Simulationspeed textbox
        private void simulationSpeed_TextChanged(object sender, EventArgs e)
        {
            simulationSpeed.BackColor = Color.White;

            errorTooltip.Active = false;
            errorTooltip.Hide(simulationSpeed);

            ValidationMethods.ValidateInteger(simulationSpeed);
        }

        private void simulationSpeed_MouseHover(object sender, EventArgs e)
        {
            errorTooltip.Active = false;
            errorTooltip.Hide(simulationSpeed);

            ValidationMethods.ValidateInteger(simulationSpeed, errorTooltip);
        }
        #endregion:

        #region: Thrust tab events
        //Thrust events
        private void maxAvailableThrust_TextChanged(object sender, EventArgs e)
        {
            setPropertiesDoubleValidation(maxAvailableThrust);
        }

        private void maxAvailableThrust_MouseHover(object sender, EventArgs e)
        {
            setPropertiesDoubleMouseHover(maxAvailableThrust);
        }

        //NrofEngines events
        private void nrEngines_MouseHover(object sender, EventArgs e)
        {
            errorTooltip.Hide(nrEngines);
            ValidationMethods.ValidateInteger(nrEngines, errorTooltip);
        }

        private void nrEngines_TextChanged(object sender, EventArgs e)
        {
            nrEngines.BackColor = Color.White;
            
            errorTooltip.Hide(nrEngines);
            errorTooltip.Active = false;

            int nrOfEngines = ValidationMethods.ValidateInteger(nrEngines);

            if (nrOfEngines == 2)
            {
                this.comboBox1.SelectedIndex = 1;
            }
            else if (nrOfEngines == 3)
            {
                this.comboBox1.SelectedIndex = 2;
            }
            else if (nrOfEngines == 4)
            {
                this.comboBox1.SelectedIndex = 3;
            }
            else
            {
                this.comboBox1.SelectedIndex = 0;
            }

            if (ValidationMethods.ValidateInteger(nrFailedEngines) < nrOfEngines)
            {
                nrFailedEngines.BackColor = Color.White;
            }
            else
            {
                nrFailedEngines.BackColor = Color.Red;
            }
        }

        //Nr of failed engines events
        private void nrFailedEngines_MouseHover(object sender, EventArgs e)
        {
            errorTooltip.Hide(nrFailedEngines);
            errorTooltip.Active = false;

            int nrOfFailedEngines = ValidationMethods.ValidateInteger(nrFailedEngines, errorTooltip);

            if (nrOfFailedEngines > ValidationMethods.ValidateInteger(nrEngines))
            {
                errorTooltip.SetToolTip(nrFailedEngines, "The number of failed engines is bigger than the total number of engines");
                errorTooltip.Active = true;
            }
        }

        private void nrFailedEngines_TextChanged(object sender, EventArgs e)
        {
            nrFailedEngines.BackColor = Color.White;

            errorTooltip.Hide(nrFailedEngines);
            errorTooltip.Active = false;
            
            int nrOfFailedEngines = ValidationMethods.ValidateInteger(nrFailedEngines);
            
            if (nrOfFailedEngines > ValidationMethods.ValidateInteger(nrEngines))
            {
               nrFailedEngines.BackColor = Color.Red;
            }
        }
        #endregion:

        #region: Friction tab events
        //Brake events
        private void muRoll_TextChanged(object sender, EventArgs e)
        {
            setPropertiesDoubleValidation(muRoll);
        }

        private void muRoll_MouseHover(object sender, EventArgs e)
        {
            setPropertiesDoubleMouseHover(muRoll);
        }
        #endregion:

        #region: Misc. Tab events
        //Weight events
        private void weight_TextChanged(object sender, EventArgs e)
        {
            setPropertiesDoubleValidation(weight);
        }

        //PitchEvents
        private void maxPitch_TextChanged(object sender, EventArgs e)
        {
            setPropertiesDoubleValidation(maxPitch);
        }

        private void maxPitch_MouseHover(object sender, EventArgs e)
        {
            setPropertiesDoubleMouseHover(maxPitch);
        }

        private void pitchGradient_TextChanged(object sender, EventArgs e)
        {
            setPropertiesDoubleValidation(pitchGradient);
        }

        private void pitchGradient_MouseHover(object sender, EventArgs e)
        {
            setPropertiesDoubleMouseHover(pitchGradient);
        }


        private void weight_MouseHover(object sender, EventArgs e)
        {
            setPropertiesDoubleMouseHover(weight);
        }
        #endregion:

        #region: Button events
        //Clear all button
        private void clearAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Warning, continuing this operation will clear ALL user input. \n\nAre you sure you want to continue?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                aircraftName.Clear();

                //Thrust tab
                maxAvailableThrust.Clear();
                nrEngines.Clear();
                nrFailedEngines.Clear();

                //Aerodynamics tab

                //Friction tab
                muRoll.Clear();
                muBrake.Clear();

                //Misc. tab
                weight.Clear();
                maxPitch.Clear();
                pitchGradient.Clear();
            }
        }

        //Quit button
        private void quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion:

        #endregion:
    }
}
