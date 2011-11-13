using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace API
{
    public partial class MainForm : Form
    {
        #region: Members
        //Combobox related items
        enum airplaneType {Custom, TwoEnginesJet, ThreeEnginesJet, FourEnginesJet};
        private string [] comboBoxItems = {"Custom..", "Two Engine Jetplane", "Three Engine Jetplane", "Four Engine Jetplane"};
        private int comboBoxSelectedIndex = 0;

        //Instatiation of an error tooltip
        private ToolTip errorTooltip = new ToolTip();

        //Create a list to hold every textbox in this form
        List<TextBox> allTextBoxes = new List<TextBox>();

        //The selected aircraft class
        AircraftData selectedAircraftData;
        //Instantiate the predefined aircraft data
        AircraftData twoJetEnginePlane = new AircraftData("Two Engine Jetplane", "150e3", "1", "2", "0.02", "0.2", "500e3", "16", "6", false);
        AircraftData threeJetEnginePlane = new AircraftData("Three Engine Jetplane", "360e3", "1", "3", "0.02", "0.2", "1200e3", "15", "5", false);
        AircraftData fourJetEnginePlane = new AircraftData("Four Engine Jetplane", "1200e3", "1", "4", "0.02", "0.2", "3500e3", "14", "4", false);
        #endregion:

        public MainForm()
        {
            InitializeComponent();
            SetFormProperties();
            SetErrorTooltipProperties();
            GetAllTextBoxes();
        }

        /// <summary>
        /// Method to set the tooltips of the form
        /// </summary>
        private void SetFormProperties()
        {           
            //Combobox properties
            AircraftList.Items.AddRange(comboBoxItems);
            AircraftList.SelectedIndex = 0;

            //Textbox value
            simulationSpeed.Text = "100";

            //Tooltip properties for the header items
            SetToolTipProperties(this.AircraftList, "Contains a list with preset airplane configurations");
            SetToolTipProperties(this.aircraftName, "The name of the airplane");

            //Tooltips for the Simulation tab
            SetToolTipProperties(this.simulationVelocityLabel, "The maximum simulationspeed which needs to be evaluated");

            //Tooltips for the Thrust tab
            SetToolTipProperties(this.maxThrustLabel, "Maximum available thrust of the airplane");
            SetToolTipProperties(this.maxEngineLabel, "Total available engines of the airplane");
            SetToolTipProperties(this.engineFailureLabel, "The amount of failed engines after take-off procedure");
            SetToolTipProperties(this.propellerProperty, "Indicates whether the plane is a propellor plane");

            //TODO
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
            about.Show();
        }
        #endregion:

        #region: Combobox Events
        //ComboboxEvents
        private void aircraftList_Enter(object sender, EventArgs e)
        {
            comboBoxSelectedIndex = this.AircraftList.SelectedIndex;
        }

        private void aircraftList_SelectionChangeCommited(object sender, EventArgs e)
        {
            int userChoice = AircraftList.SelectedIndex;

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
                    this.AircraftList.SelectedIndex = comboBoxSelectedIndex;
                }
            }
        }
        #endregion:

        #region: Textbox events
        private void TextChangedInteger(object sender, EventArgs e)
        {
            simulationSpeed.BackColor = Color.White;

            errorTooltip.Active = false;
            errorTooltip.Hide(sender as TextBox);

            ValidationMethods.ValidateInteger(sender as TextBox);

            if (selectedAircraftData != null)
            {
                CompareData();
            }
        }

        private void MouseHoverInteger(object sender, EventArgs e)
        {
            errorTooltip.Active = false;
            errorTooltip.Hide(sender as TextBox);

            ValidationMethods.ValidateInteger(sender as TextBox, errorTooltip);
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
                foreach (TextBox tb in allTextBoxes)
                {
                    tb.Clear();
                }
            }
        }

        //Quit button
        private void quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion:

        #endregion:

        #region: Form methods
        /// <summary>
        /// Method to retrieve all the textboxes of the mainform
        /// </summary>
        private void GetAllTextBoxes()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    allTextBoxes.Add(ctrl as TextBox);
                    continue;
                }
                else if (ctrl is TabControl)
                {
                    foreach (TabPage tabPage in (ctrl as TabControl).TabPages)
                    {
                        foreach (Control cntrl in tabPage.Controls)
                        {
                            if (cntrl is TextBox)
                            {
                                allTextBoxes.Add(cntrl as TextBox);
                            }
                        }
                    }
                }
                
            }
        }

        /// <summary>
        /// Method to fill the textboxes of the mainform
        /// </summary>
        /// <param name="aircraftDataclass">The aircraftdataclass containing the parameters which need to be filled</param>
        private void FillTextBoxes(AircraftData aircraftDataclass)
        {
            //Get the dictionary for the textbox
            Dictionary<string, string> airCraftData = aircraftDataclass.GetAircraftData();

            foreach (TextBox tb in allTextBoxes)
            {
                try
                {
                    if (tb.Name.ToLower().Equals("simulationspeed"))
                    {
                        continue;
                    }
                    else
                    {
                        tb.Text = airCraftData[tb.Name.ToLower()];
                    }
                }
                catch (KeyNotFoundException)
                {
                    MessageBox.Show(String.Format("An error occured. Please provide the coder the following message: Dictionary does not contain a key {0}", tb.Name.ToLower()),
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                catch (Exception e)
                {
                    MessageBox.Show(String.Format("An error occured. Please provide the coder the following message: {0}", e.Message),
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
        }

        /// <summary>
        /// Method to compare the data of the textboxes with the predefined aircraftdata
        /// </summary>
        private void CompareData()
        {
            //Get dictionary
            Dictionary<string, string> aircraftData = selectedAircraftData.GetAircraftData();
            foreach (TextBox tb in allTextBoxes)
            {
                try
                {
                    if (tb.Name.ToLower().Equals("simulationspeed")||(tb.Name.ToLower().Equals("aircraftname")))
                    {
                        continue;
                    }
                    if (!tb.Text.Equals(aircraftData[tb.Name.ToLower()]))
                    {
                        this.AircraftList.SelectedIndex = 0;
                        break;
                    }
                }
                catch (KeyNotFoundException)
                {
                    MessageBox.Show(String.Format("An error occured. Please provide the coder the following message: Dictionary does not contain a key {0}", tb.Name.ToLower()),
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                catch (Exception e)
                {
                    MessageBox.Show(String.Format("An error occured. Please provide the coder the following message: {0}", e.Message),
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
        }

        private void DetermineChoice(airplaneType airplaneChoice)
        {
            switch (airplaneChoice)
            {
                case airplaneType.TwoEnginesJet:
                    FillTextBoxes(twoJetEnginePlane);
                    selectedAircraftData = twoJetEnginePlane;
                    break;
                case airplaneType.ThreeEnginesJet:
                    FillTextBoxes(threeJetEnginePlane);
                    selectedAircraftData = threeJetEnginePlane;
                    break;
                case airplaneType.FourEnginesJet:
                    FillTextBoxes(fourJetEnginePlane);
                    selectedAircraftData = fourJetEnginePlane;
                    break;
                case airplaneType.Custom:
                    this.AircraftList.SelectedIndex = 0;
                    break;
                default:
                    selectedAircraftData = null;
                    MessageBox.Show("Could not determine the user choice", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
        #endregion:
    }
}
