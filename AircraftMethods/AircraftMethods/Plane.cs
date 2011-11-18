using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AircraftMethods
{
    abstract class AirplaneFailedEngine
    {
        #region: Variables
        protected AirplaneData planeData;
                
        protected double Weight;

        protected double AR;
        protected double S;
        protected double CLMax;
        protected double dCL;
        protected double e;
        protected double ZeroLiftAngle;

        protected double CD0_RunningEngines;
        protected double CD0_FailedEngines;

        protected double MuBrake;
        protected double MuRoll;

        protected double Screenheight;

        protected double dTheta;
        protected double thetaMax;

        protected double nrOfEngines;
        protected int nrOfEnginesFailed;

        //Declare constants
        protected const double RHO = 1.225;
        protected const double G_0 = 9.81;
        protected const double DEG_TO_RAD = Math.PI / 180;

        //Time variables
        protected double Time = 0;
        protected double dTime = 0.1;
        
        //Declare variables, which are needed for the calculation
        private double VFail = 0;
        private double dVFail = 0.1;
        #endregion:

        //Constructor
        public AirplaneFailedEngine(AirplaneData planeData, double CD0_FailedEngines, int nrOfEnginesFailed)
        {
            this.planeData = planeData;

        }

        protected double calculateVmin()
        {
            return Math.Sqrt(planeData.getWeight() / (0.5 * RHO * planeData.getCLMax() * planeData.getSurface()));
        }

        protected double calculateCL(double Alpha)
        {
            return (planeData.getdCL() * (Alpha - planeData.getZeroLift());
        }

        protected double calculateCD(double V, double VFail, double LiftCoefficient)
        {
            double CD;

            if (V > VFail)
            {
                CD = CD0_FailedEngines + ((Math.Pow(LiftCoefficient, 2)) / (Math.PI * planeData.getAspectRatio() * planeData.getOswaldFactor()));
            }
            else
            {
                CD = planeData.getCD0_RunningEngine() + ((Math.Pow(LiftCoefficient, 2)) / (Math.PI * planeData.getAspectRatio() * planeData.getOswaldFactor()));
            }

            return CD;
        }

        protected double calculateVrot()
        {
            return 1.2 * calculateVmin();
        }

        protected virtual double calculateThrust()
        {
            throw new ImplementMethodException("Calculate thrust method is not implemented");
        }

        protected virtual Dictionary<string, ParameterType> getAircraftData()
        {
            throw new ImplementMethodException("Get aircraftdata method is not implemented");
        }
    }
}
