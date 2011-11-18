using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace API
{
    static class ValidationMethods
    {
        #region: Validation Methods
        //Integer validation methods
        public static int ValidateInteger(TextBox textBox)
        {
            int number;

            if (Int32.TryParse(textBox.Text, out number))
            {
                if (number <= 0)
                {
                    textBox.BackColor = Color.Red;
                }
            }
            else
            {
                textBox.BackColor = Color.Red;
            }
            return number;
        }

        public static int ValidateInteger(TextBox textBox, ToolTip tooltip)
        {
            int number;
            tooltip.Hide(textBox);

            if (Int32.TryParse(textBox.Text, out number))
            {
                if (number < 0)
                {
                    tooltip.SetToolTip(textBox, "Value cannot be smaller than 0");
                    tooltip.Active = true;
                }
                if (number == 0)
                {
                    tooltip.SetToolTip(textBox, "Value cannot be equal to 0");
                    tooltip.Active = true;
                }
            }
            else
            {
                tooltip.SetToolTip(textBox, "User input is an invalid integer");
                tooltip.Active = true;
            }
            return number;
        }

        ///ToDO: write seperate method for the if statements
        //Doubles validation methods
        public static double ValidateDouble(TextBox textBox)
        {
            double number;
            string formattedString = textBox.Text.Replace(" ", "");

            if (Double.TryParse(formattedString, out number))
            {
                if (number <= 0)
                {
                    textBox.BackColor = Color.Red;
                }
            }
            else
            {
                number = -1;
                textBox.BackColor = Color.Red;
            }
            return number;
        }

        public static double ValidateDouble(TextBox textBox, ToolTip toolTip)
        {
            double number;
            string formattedString = textBox.Text.Replace(" ", "");
            toolTip.Hide(textBox);

            if (Double.TryParse(formattedString, out number))
            {
                if (number < 0)
                {
                    toolTip.SetToolTip(textBox, "Value cannot be smaller than 0");
                    toolTip.Active = true;
                }
                if (number == 0)
                {
                    toolTip.SetToolTip(textBox, "Value cannot be equal to 0");
                    toolTip.Active = true;
                }
            }
            else
            {
                toolTip.SetToolTip(textBox, "User input is an invalid integer");
                toolTip.Active = true;
            }
            return number;
        }
        #endregion:
    }
}
