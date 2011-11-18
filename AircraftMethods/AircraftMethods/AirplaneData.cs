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

        //Variables
        //Declare string name
        private string aircraftName;

        //Declare initial variables
        private double ThrustMax;
        private double PowerMax;
        private double Weight;

        //Aerodynamic specific parameters
        private double AR;
        private double S;
        private double CLMax;
        private double dCL;
        private double e;
        private double ZeroLift;

        //Drag
        private double CD0_RunningEngine;
        private double CD0_FailedEngine;

        //Brake parameters
        private double muRoll;
        private double MuBrake;

        //Height parameters
        private double Screenheight;

        //Rotaional parameters
        private double dTheta;
        private double thetaMax;

        //Engine paramters
        private int nrOfEngines;

        //Declare variables, which are needed for the calculation
        private double VFail = 0;
        private double dVFail = 0.1;

        //The constructor for the Plane Class
        public AirplaneData(string airCraftname,
            double ThrustMax, double Weight,
            double AR, double S, double CLMax, double dCL, double e, double ZeroLift,
            double CD0_RunningEngine, double CD0_FailedEngine,
            double MuBrake, double muRoll,
            double Screenheight,
            double dTheta, double thetaMax,
            int nrOfEngines)
        {
            this.aircraftName = airCraftname;

            this.ThrustMax = ThrustMax;
            this.Weight = Weight;

            this.AR = AR;
            this.S = S;
            this.CLMax = CLMax;
            this.dCL = dCL;
            this.e = e;
            this.ZeroLift = ZeroLift / DEG_TO_RAD;

            this.CD0_RunningEngine = CD0_RunningEngine;
            this.CD0_FailedEngine = CD0_FailedEngine;

            this.MuBrake = MuBrake;
            this.muRoll = muRoll;

            this.Screenheight = Screenheight;

            this.dTheta = dTheta;
            this.thetaMax = thetaMax;

            this.nrOfEngines = nrOfEngines;
        }

        #region: Methods to return aircraft values (Probably later needed) [Strings]
        public string getAircraftName()
        {
            return aircraftName;
        }

        public string getThrustMax()
        {
            return ThrustMax.ToString();
        }

        public string getWeight()
        {
            return Weight.ToString();
        }

        public string getAspectRatio()
        {
            return AR.ToString();
        }

        public string getSurface()
        {
            return S.ToString();
        }

        public string getCLMax()
        {
            return CLMax.ToString();
        }

        public string getdCL()
        {
            return dCL.ToString();
        }

        public string getOswaldFactor()
        {
            return e.ToString();
        }

        public string getZeroLift()
        {
            return ZeroLift.ToString();
        }

        public string getCD0_RunningEngine()
        {
            return CD0_RunningEngine.ToString();
        }

        public string getCD1()
        {
            return CD0_FailedEngine.ToString();
        }

        public string getmuRoll()
        {
            return muRoll.ToString();
        }

        public string getMuBrake()
        {
            return MuBrake.ToString();
        }

        public string getScreenHeight()
        {
            return Screenheight.ToString();
        }

        public string getdTheta()
        {
            return dTheta.ToString();
        }

        public string getThetaMax()
        {
            return thetaMax.ToString();
        }

        public string getNRofEngines()
        {
            return nrOfEngines.ToString();
        }

        #endregion:
    }
}
