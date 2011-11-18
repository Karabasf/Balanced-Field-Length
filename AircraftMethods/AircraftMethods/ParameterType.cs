using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AircraftMethods
{
    public class ParameterType
    {
        private string parameterName;
        private object parameterValue;
        private string parameterUnit;

        /// <summary>
        /// Constructor for parameters to hold data as name, value and unit of the parameter
        /// </summary>
        /// <param name="parameterName">Name of the parameter</param>
        /// <param name="parameterValue">Value of the parameter</param>
        /// <param name="parameterUnit">Unit of the parameter value</param>
        public ParameterType(string parameterName, object parameterValue, string parameterUnit)
        {
            this.parameterName = parameterName;
            this.parameterValue = parameterValue;
            this.parameterUnit = parameterUnit;
        }

        public string ParameterName
        {
            get { return parameterName; }
            set { parameterName = value; }
        }

        public object ParameterValue
        {
            get { return parameterValue; }
            set { parameterValue = value; }
        }

        public string ParameterUnit
        {
            get { return ParameterUnit; }
            set { parameterUnit = value; }
        }

        /// <summary>
        /// Method to return a formatted string of the parameter
        /// </summary>
        /// <returns>Formatted string in the form of Parametername: Parametervalue [Unit]</returns>
        public override string ToString()
        {
            return String.Format("{0}: {1} [{2}]", parameterName, parameterValue.ToString(), parameterUnit); 
        }
    }
}
