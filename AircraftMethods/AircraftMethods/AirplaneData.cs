using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AircraftMethods
{
    //Class used for constructing an object which holds all the relevant aircraft data. This to prevent clutter in the Airplane abstract class.
    public class AirplaneData
    {
        private const double DEG_TO_RAD = Math.PI / 180;

        #region: Variables
        //Declare string name
        private string aircraftName;

        //Declare initial variables
        private double MaxPower;
        private double Weight;

        //Aerodynamic specific parameters
        private double AR;
        private double S;
        private double CLMax;
        private double dCL;
        private double e;
        private double ZeroLiftAngle;

        //Drag
        private double CD0_RunningEngines;

        //Brake parameters
        private double MuRoll;
        private double MuBrake;

        //Height parameters
        private double Screenheight;

        //Rotaional parameters
        private double dTheta;
        private double thetaMax;

        //Engine paramters
        private int nrOfEngines;
        private bool isJetPlane;
        #endregion

        #region: Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="airCraftname"></param>
        /// <param name="PowerMax"></param>
        /// <param name="Weight"></param>
        /// <param name="AR"></param>
        /// <param name="S"></param>
        /// <param name="CLMax"></param>
        /// <param name="dCL"></param>
        /// <param name="e"></param>
        /// <param name="ZeroLift"></param>
        /// <param name="CD0_RunningEngines"></param>
        /// <param name="MuBrake"></param>
        /// <param name="muRoll"></param>
        /// <param name="Screenheight"></param>
        /// <param name="dTheta"></param>
        /// <param name="thetaMax"></param>
        /// <param name="nrOfEngines"></param>
        /// <param name="isJetplane"></param>
        public AirplaneData(string airCraftname,
            double MaxPower, double Weight,
            double AR, double S, double CLMax, double dCL, double e, double ZeroLiftAngle,
            double CD0_RunningEngines, 
            double MuBrake, double MuRoll,
            double Screenheight,
            double dTheta, double thetaMax,
            int nrOfEngines, bool isJetplane)
        {
            this.aircraftName = airCraftname;

            this.MaxPower = MaxPower;
            this.Weight = Weight;

            this.AR = AR;
            this.S = S;
            this.CLMax = CLMax;
            this.dCL = dCL;
            this.e = e;
            this.ZeroLiftAngle = ZeroLiftAngle / DEG_TO_RAD;

            this.CD0_RunningEngines = CD0_RunningEngines;

            this.MuBrake = MuBrake;
            this.MuRoll = MuRoll;

            this.Screenheight = Screenheight;

            this.dTheta = dTheta;
            this.thetaMax = thetaMax;

            this.nrOfEngines = nrOfEngines;
            this.isJetPlane = isJetplane ;
        }
        #endregion:

        #region: Methods to return aircraft values 
        public string getAircraftName()
        {
            return aircraftName;
        }

        public double getPowerMax()
        {
            return MaxPower;
        }

        public double getWeight()
        {
            return Weight;
        }

        public double getAspectRatio()
        {
            return AR;
        }

        public double getSurface()
        {
            return S;
        }

        public double getCLMax()
        {
            return CLMax;
        }

        public double getdCL()
        {
            return dCL;
        }

        public double getOswaldFactor()
        {
            return e;
        }

        public double getZeroLift()
        {
            return ZeroLiftAngle;
        }

        public double getCD0_RunningEngine()
        {
            return CD0_RunningEngines;
        }

        public double getmuRoll()
        {
            return MuRoll;
        }

        public double getMuBrake()
        {
            return MuBrake;
        }

        public double getScreenHeight()
        {
            return Screenheight;
        }

        public double getdTheta()
        {
            return dTheta;
        }

        public double getThetaMax()
        {
            return thetaMax;
        }

        public int getNRofEngines()
        {
            return nrOfEngines;
        }

        #endregion:

        /// <summary>
        /// Method to summarize al the aircraft data in a dictionary object
        /// </summary>
        /// <returns>A dictionary object containing the parameter name, value and unit</returns>
        private Dictionary<String, ParameterType> getAircraftData()
        {
            Dictionary<String, ParameterType> AircraftData = new Dictionary<string, ParameterType>();

            AircraftData.Add("Aircraftname", new ParameterType("Aircraftname", aircraftName, " "));

            AircraftData.Add("Weight", new ParameterType("Weight", Weight, "N"));

            //Thrust data
            if (isJetPlane)
            {
                AircraftData.Add("Maximum thrust", new ParameterType("Maximum thrust", MaxPower, "N"));
            }
            else
            {
                AircraftData.Add("Maximum power", new ParameterType("Maximum power", MaxPower, "W"));
            }
            AircraftData.Add("Nr of Engines", new ParameterType("Nr. of engines", nrOfEngines, "-"));

            //Aerodynamic properties
            AircraftData.Add("Maximum liftcoefficient", new ParameterType("Maximum liftcoefficient", CLMax, "-"));
            AircraftData.Add("dCL/dAlpha", new ParameterType("dCL/dAlpha", dCL, "-"));
            AircraftData.Add("Zero Lift Angle", new ParameterType("Zero Lift Angle", ZeroLiftAngle, "-"));

            AircraftData.Add("CD0 Running Engines", new ParameterType("CD0 Running Engines", CD0_RunningEngines, "-"));
            AircraftData.Add("Oswald Factor" , new ParameterType("Oswald Factor", e, "-")); 
            AircraftData.Add("Aspect Ratio", new ParameterType("Aspect ratio", AR, "-"));
            AircraftData.Add("Surface Area", new ParameterType("Surface area", S, "m^2"));

            //Angular properties
            AircraftData.Add("Maximum Pitch Angle", new ParameterType("Maximum Pitch Angle", thetaMax, "-"));           
            AircraftData.Add("dTheta/dT", new ParameterType("dTheta/dT", dTheta, "-"));  

            AircraftData.Add("Screenheight", new ParameterType("Screenheight", Screenheight, "m"));

            //Friction properties
            AircraftData.Add("Kinematic friction coefficient, roll", new ParameterType("Kinematic friction coefficient, roll", MuRoll, "-"));
            AircraftData.Add("Kinematic friction coefficient, brake", new ParameterType("Kinematic friction coefficient, brake", MuBrake, "-"));
            return AircraftData;
        }
    }
}
