using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AP1
{
    /// <summary>
    /// A class to construct a plane object. Currently it is possible to construct another object, however it is not verified whether it works
    /// </summary>
    class JetPlane
    {
        #region: Variables
        //Declare string name
        private string aircraftName;

        //Declare initial variables
        private double ThrustMax;
        private double Weight;

        //Aerodynamic specific parameters
        private double AR;
        private double S;
        private double CLMax;
        private double dCL;
        private double e;
        private double ZeroLift;

        //Drag
        private double CD0;
        private double CD1;

        //Brake parameters
        private double muRoll;
        private double MuBrake;

        //Height parameters
        private double Screenheight;

        //Rotaional parameters
        private double dTheta;
        private double thetaMax;

        //Declare constants
        private const double RHO = 1.225;
        private const double G_0 = 9.81;
        private const double DEG_TO_RAD = Math.PI / 180;

        //Engine paramters
        private int nrOfEngines;
        private int nrOfEnginesFailed;

        //Declare variables, which are needed for the calculation
        private double VFail = 0;
        private double dVFail = 0.1;

        //Time variables
        private double Time = 0;
        private double dTime = 0.1;

        #endregion:

        #region: Contructors
        //Default constructor
        public JetPlane()
        {
            aircraftName = "2 jet engine powered aircraft";

            ThrustMax = 150000;
            Weight = 500000;

            AR = 15;
            S = 100;
            CLMax = 1.6;
            dCL = 4.85;
            e = 0.85;
            ZeroLift = -3 * DEG_TO_RAD;

            CD0 = 0.021;
            CD1 = 0.026;

            MuBrake = 0.2;
            muRoll = 0.02;

            Screenheight = 10.7;

            dTheta = 6 * DEG_TO_RAD;
            thetaMax = 16 * DEG_TO_RAD;

            nrOfEngines = 2;
            nrOfEnginesFailed = 1;
        }

        //The constructor for the Plane Class
        public JetPlane(string airCraftname,
            double ThrustMax, double Weight,
            double AR, double S, double CLMax, double dCL, double e, double ZeroLift,
            double CD0, double CD1,
            double MuBrake, double muRoll,
            double Screenheight,
            double dTheta, double thetaMax,
            int nrOfEngines, int nrOfEnginesFailed)
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

            this.CD0 = CD0;
            this.CD1 = CD1;

            this.MuBrake = MuBrake;
            this.muRoll = muRoll;

            this.Screenheight = Screenheight;

            this.dTheta = dTheta;
            this.thetaMax = thetaMax;

            this.nrOfEngines = nrOfEngines;
            this.nrOfEnginesFailed = nrOfEnginesFailed;
        }
        #endregion:

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

        public string getCD0()
        {
            return CD0.ToString();
        }

        public string getCD1()
        {
            return CD1.ToString();
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

        public int getFailedEngines()
        {
            return nrOfEnginesFailed;
        }

        //Method to calculate the thrust after failure
        public string getFailedThrust()
        {
            double newThrust;

            newThrust = ThrustMax * (1 - ((double)nrOfEnginesFailed / (double)nrOfEngines));

            return newThrust.ToString();
        }

        #endregion:

        #region: Methods to retrieve simulation parameters

        public string getRho()
        {
            return RHO.ToString();
        }

        public string getGravity()
        {
            return G_0.ToString();
        }

        #endregion:

        #region: Calculation Methods for crucial parameters

        //method to calculate the Minimum Airspeed
        public double Vmin()
        {
            double VMin;

            VMin = Math.Sqrt((2 * Weight) / (RHO * S * CLMax));

            return VMin;
        }

        //Method to calculate the rotational speed
        public double Vrot(double VMin)
        {
            return 1.2 * VMin;
        }

        #endregion:

        #region: Methods to calculate forces

        //Method to calculate the Drag Coefficient
        private double CD(double V, double VFail, double LiftCoefficient)
        {
            double CD;

            if (V > VFail)
            {
                CD = CD1 + ((Math.Pow(LiftCoefficient, 2)) / (Math.PI * AR * e));
            }
            else
            {
                CD = CD0 + ((Math.Pow(LiftCoefficient, 2)) / (Math.PI * AR * e));
            }

            return CD;
        }

        //Method to calculate CL. Note that Alpha0 is the zero lift angle
        private double CL(double Alpha)
        {
            return (dCL * (Alpha - ZeroLift));
        }

        //Method to calculate the lift
        private double Lift(double V, double CL)
        {
            double Lift;

            Lift = 0.5 * RHO * Math.Pow(V, 2) * S * CL;

            return Lift;
        }

        //Method to calculate the normal force
        private double NormalForce(double Lift, double Height)
        {
            double NormalForce;

            if ((Lift < Weight) && (Height < 0.01))
            {
                NormalForce = Weight - Lift;
            }
            else
            {
                NormalForce = 0;
            }

            return NormalForce;
        }

        //Method to calculate the drag
        private double Drag(double CD, double V, double mu, double N)
        {
            double Drag;

            Drag = (0.5 * CD * RHO * Math.Pow(V, 2) * S) + (mu * N);

            return Drag;
        }
        #endregion:

        #region: Methods to calculate the increments
        //Method to calculate dV/dt
        private double dV(double Thrust, double Drag, double gamma)
        {
            double dV;

            dV = (G_0 / Weight) * (Thrust - Drag - (Weight * Math.Sin(gamma)));

            return dV;
        }

        //Method to calculate dGamma/dt
        private double dGamma(double V, double Lift, double NormalForce)
        {
            double dGamma;

            if (V < 1)
            {
                dGamma = 0;
            }
            else
            {
                dGamma = (G_0 / (Weight * V)) * (Lift - Weight + NormalForce);
            }

            return dGamma * DEG_TO_RAD;
        }

        #endregion:

        #region: Misc.
        //Method to return the array of VFail ranges
        public double[] VFailRange(double Vmax)
        {
            //Declare parameters
            int nrElements;
            int i;
            double Velocity = 0 ;

            nrElements = (int)(Vmax / dVFail);

            double[] VelocityRange = new double[nrElements+1];

            for (i = 0; i < VelocityRange.Length ; i++)
            {
                VelocityRange[i] = Velocity;
                Velocity = Velocity + dVFail;
            }

            return VelocityRange;
        }

        //Method to create a string Array for excel functions
        public string[,] getStringArray()
        {
            string[,] DataSheet = new string[31, 3];

            //Column items:
            DataSheet[0, 0] = "Aircraftname";
            DataSheet[0, 1] = this.getAircraftName();
            DataSheet[0, 2] = " ";

            DataSheet[1, 0] = "Weight";
            DataSheet[1, 1] = this.getWeight();
            DataSheet[1, 2] = "[N]";

            DataSheet[2, 0] = DataSheet[2, 1] = DataSheet[2, 2] = " ";

            DataSheet[3, 0] = "Thrustdata";
            DataSheet[3, 1] = DataSheet[3, 2] = " ";

            DataSheet[4, 0] = "Maximum thrust";
            DataSheet[4, 1] = this.getThrustMax();
            DataSheet[4, 2] = "[N]";

            DataSheet[5, 0] = "Nr. of engines";
            DataSheet[5, 1] = this.getNRofEngines();
            DataSheet[5, 2] = "[-]";

            DataSheet[6, 0] = "Nr of failed engines";
            DataSheet[6, 1] = this.getFailedEngines().ToString();
            DataSheet[6, 2] = "[-]";

            DataSheet[7, 0] = "Thrust after failure";
            DataSheet[7, 1] = this.getFailedThrust();
            DataSheet[7, 2] = "[N]";

            DataSheet[8, 0] = DataSheet[8, 1] = DataSheet[8, 2] = " ";

            DataSheet[9, 0] = "Aerodynamic properties: Lift";
            DataSheet[9, 1] = DataSheet[9, 2] = " ";

            DataSheet[10, 0] = "Maximum liftcoefficient";
            DataSheet[10, 1] = this.getCLMax();
            DataSheet[10, 2] = "[-]";

            DataSheet[11, 0] = "dCL/dAlpha";
            DataSheet[11, 1] = this.getdCL();
            DataSheet[11, 2] = "[-]";

            DataSheet[12, 0] = "Zero lift angle";
            DataSheet[12, 1] = this.getZeroLift();
            DataSheet[12, 2] = "[-]";

            DataSheet[13, 0] = DataSheet[13, 0] = DataSheet[13, 0] = " ";

            DataSheet[14, 0] = "Aerodynamic properties: Drag";
            DataSheet[14, 1] = DataSheet[14, 2] = " ";

            DataSheet[15, 0] = "CD before failure";
            DataSheet[15, 1] = this.getCD0();
            DataSheet[15, 2] = "[-]";

            DataSheet[16, 0] = "CD after failure";
            DataSheet[16, 1] = this.getCD1();
            DataSheet[16, 2] = "[-]";

            DataSheet[17, 0] = "Oswald Factor";
            DataSheet[17, 1] = this.getOswaldFactor();
            DataSheet[17, 2] = "[-]";

            DataSheet[18, 0] = "Aspect ratio";
            DataSheet[18, 1] = this.getAspectRatio();
            DataSheet[18, 2] = "[-]";

            DataSheet[19, 0] = "Surface area";
            DataSheet[19, 1] = this.getSurface();
            DataSheet[19, 2] = "[m^2]";

            DataSheet[20, 0] = DataSheet[20, 1] = DataSheet[20, 2] = " ";

            DataSheet[21, 0] = "Flight properties";
            DataSheet[21, 1] = DataSheet[21, 2] = " ";

            DataSheet[22, 0] = "Minimum airspeed";
            DataSheet[22, 1] = this.Vmin().ToString();
            DataSheet[22, 2] = "[m/s]";

            DataSheet[23, 0] = "Rotational airspeed";
            DataSheet[23, 1] = this.Vrot(this.Vmin()).ToString();
            DataSheet[23, 2] = "[m/s]";

            DataSheet[24, 0] = "Maximum pitch angle";
            DataSheet[24, 1] = this.getThetaMax();
            DataSheet[24, 2] = "[-]";

            DataSheet[25, 0] = "dTheta/dT";
            DataSheet[25, 1] = this.getdTheta();
            DataSheet[25, 2] = "[-]";

            DataSheet[26, 0] = "Screenheight";
            DataSheet[26, 1] = this.getScreenHeight();
            DataSheet[26, 2] = "[m]";

            DataSheet[27, 0] = DataSheet[27, 1] = DataSheet[27, 2] = " ";

            DataSheet[28, 0] = "Ground resistance";
            DataSheet[28, 1] = DataSheet[29, 2] = " ";

            DataSheet[29, 0] = "Kinematic friction coefficient, roll";
            DataSheet[29, 1] = this.getmuRoll();
            DataSheet[29, 2] = "[-]";

            DataSheet[30, 0] = "Kinematic friction coefficient, brake";
            DataSheet[30, 1] = this.getMuBrake();
            DataSheet[30, 2] = "[-]";

            return DataSheet;
        }

        //Method to build string data
        public string getStringData()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Aircraft name: " + this.getAircraftName());
            sb.AppendLine();
            sb.AppendLine("Weight: " + this.getWeight() + " [N]");
            sb.AppendLine();
            sb.AppendLine("Thrust data");
            sb.AppendLine("Maximum thrust: " + this.getThrustMax() + " [N]");
            sb.AppendLine("Nr. of Engines: " + this.getNRofEngines());
            sb.AppendLine("Nr. of failed Engines: " + this.getFailedEngines().ToString());
            sb.AppendLine("Thrust after failure: " + this.getFailedThrust());
            sb.AppendLine();
            sb.AppendLine("Aerodynamic properties: Lift");
            sb.AppendLine("Maximum liftcoefficient: " + this.getCLMax());
            sb.AppendLine("dCL/dAlpha: " + this.getdCL());
            sb.AppendLine("Zero lift angle: " + this.getZeroLift() + " [rad]");
            sb.AppendLine();
            sb.AppendLine("Aerodynamic properties: Drag");
            sb.AppendLine("Drag coefficient before failure: " + this.getCD0());
            sb.AppendLine("Drag coefficient after failure: " + this.getCD1());
            sb.AppendLine("Oswald factor: " + this.getOswaldFactor());
            sb.AppendLine("Aspect ratio: " + this.getAspectRatio());
            sb.AppendLine("Aerodynamic surface area: " + this.getSurface() + " [m^2]");
            sb.AppendLine();
            sb.AppendLine("Flight properties");
            sb.AppendLine("Minimum airspeed: " + this.Vmin() + " [m/s]");
            sb.AppendLine("Rotational airspeed: " + this.Vrot(this.Vmin()) + " [m/s]");
            sb.AppendLine("Maximum pitch angle (theta): " + this.getThetaMax() + " [rad]");
            sb.AppendLine("dTheta/dT: " + this.getdTheta() + " [rad/s]");
            sb.AppendLine("ScreenHeight: " + this.getScreenHeight() + " [m]");
            sb.AppendLine();
            sb.AppendLine("Ground resistance");
            sb.AppendLine("Kinematic friction coefficient, roll: " + this.getmuRoll());
            sb.AppendLine("Kinematic friction coefficient, brake: " + this.getMuBrake());
            sb.AppendLine();
            sb.AppendLine("SimulationData ");
            sb.AppendLine("Gravitational acceleration: " + this.getGravity() + " [m/s^2]");
            sb.AppendLine("Density [ISA, 0 m]: " + this.getRho() + " [kg/m^3]");

            return sb.ToString();
        }

        //Method to convert one list to an array
        private double[] convertListToArray(ArrayList list)
        {
            double[] array = new double[list.Count];
            int i = 0;

            foreach (object obj in list)
            {
                array[i] = (double)obj;
                i++;
            }

            return array;
        }

        //Method to convert all datalistst to one array
        private double[,] convertListsToArray(ArrayList Timelist, ArrayList VelocityList, ArrayList DistanceList, ArrayList HeightList)
        {
            double[] Timearray = convertListToArray(Timelist);
            double[] Velocityarray = convertListToArray(VelocityList);
            double[] Distancearray = convertListToArray(DistanceList);
            double[] Heightarray = convertListToArray(HeightList);

            double[,] array= new double [4, Timearray.Length];

            for (int i = 0; i < Timearray.Length; i++)
            {
                array[0, i] = Timearray[i];
                array[1, i] = Velocityarray[i];
                array[2, i] = Distancearray[i];
                array[3, i] = Heightarray[i];
            }

            return array;
        }

        #endregion:

        #region: Methods to calculate the decisions (BFL evaluation will be made in a .dLL)
        //Method for aborted take off
        public double[] AbortTakeOff(double Vmax)
        {
            //Declare parameters
            //Length parameters (e.g. height, length, and so on)
            double Height;
            double Distance;

            //Angle parameters (e.g. gamma, theta, and so on)
            double Gamma;
            double Alpha;

            //Coefficients (e.g. CL, CD)
            double LiftCoefficient;
            double DragCoefficient;

            //Forces (e.g. Lift, Drag, and so on)
            double L;
            double D;
            double Thrust;
            double N;

            //Misc.
            double Velocity;
            double deltaV;
            double Mu;
            double Vminimum = Vmin();
            double Vrotation = Vrot(Vminimum);

            //Array to store distance vs. velocity
            int nrElements;
            nrElements = (int)(Vmax / dVFail);
            double[] Array = new double[nrElements + 1];
            int i = 0;

            while (VFail <= Vmax)
            {
                //Increment failure speed by 1
                VFail = VFail + dVFail;

                //Reset the values
                Time = 0;
                Distance = 0;
                Alpha = 0;
                LiftCoefficient = 0;
                DragCoefficient = 0;
                L = 0;
                D = 0;
                Gamma = 0;
                Thrust = ThrustMax;
                Velocity = 0;
                Mu = muRoll;
                Height = 0;

                while (Velocity >= 0)
                {
                    Time = Time + dTime;

                    LiftCoefficient = CL(Alpha);
                    DragCoefficient = CD(Velocity, VFail, LiftCoefficient);

                    L = Lift(Velocity, LiftCoefficient);
                    N = NormalForce(L, Height);
                    D = Drag(DragCoefficient, Velocity, Mu, N);
                    deltaV = dV(Thrust, D, Gamma);

                    Velocity = Velocity + deltaV * dTime;
                    Distance = Distance + Velocity * dTime;

                    //Condition for surpassing failure speed
                    if (Velocity > VFail)
                    {
                        Thrust = 0;
                        Mu = MuBrake;
                    }
                }

                //Store the found distance
                Array[i] = Distance;
                i++;
            }

            VFail = 0;
            return Array;
        }

        //Method for continued take off
        public double[] ContinueTakeOff(double Vmax)
        {
            //Declare parameters
            //Length parameters (e.g. height, length, and so on)
            double Height;
            double Distance;

            //Angle parameters (e.g. gamma, theta, and so on)
            double Gamma;
            double Alpha;
            double Theta;
            double deltaG;

            //Coefficients (e.g. CL, CD)
            double LiftCoefficient;
            double DragCoefficient;

            //Forces (e.g. Lift, Drag, and so on)
            double L;
            double D;
            double Thrust;
            double N;

            //Misc.
            double Velocity;
            double deltaV;
            double Vminimum = Vmin();
            double Vrotation = Vrot(Vminimum);

            //integer for the array
            int i = 0;

            //Array to store distance vs. velocity
            int nrElements;
            nrElements = (int)(Vmax / dVFail);
            double[] ContArray = new double[nrElements + 1];

            while (VFail <= Vmax)
            {
                //Increment the failure speed with 1
                VFail = VFail + dVFail;

                //Reset the values
                Time = 0;
                Height = 0;
                Distance = 0;
                Alpha = 0;
                LiftCoefficient = 0;
                DragCoefficient = 0;
                L = 0;
                D = 0;
                Theta = 0;
                Gamma = 0;
                Thrust = ThrustMax;
                Velocity = 0;

                while (Height <= Screenheight)
                {
                    Time = Time + dTime;
                    Alpha = Theta - Gamma;
                    LiftCoefficient = CL(Alpha);
                    L = Lift(Velocity, LiftCoefficient);
                    DragCoefficient = CD(Velocity, VFail, LiftCoefficient);
                    N = NormalForce(L, Height);
                    D = Drag(DragCoefficient, Velocity, muRoll, N);
                    deltaV = dV(Thrust, D, Gamma);
                    deltaG = dGamma(Velocity, L, N);

                    Gamma = Gamma + deltaG * dTime;
                    Velocity = Velocity + deltaV * dTime;
                    Distance = Distance + Velocity * dTime;
                    Height = Height + Velocity * Math.Sin(Gamma);

                    //Condition to set theta (occurs after rotational speed)
                    if (Velocity > Vrotation)
                    {
                        if (Theta < thetaMax)
                        {
                            Theta = Theta + dTheta * dTime;
                        }
                        else
                        {
                            Theta = thetaMax;
                        }
                    }

                    //Condition to set reduced engine
                    if (Velocity >= VFail)
                    {
                        Thrust = ThrustMax * (1 - ((double)nrOfEnginesFailed / (double)nrOfEngines));
                    }
                }
                //Store found value
                ContArray[i] = Distance;
                i++;
            }

            VFail = 0;
            return ContArray;
        }

        //Method for BFL calculation [aborted takeoff]
        public double[,] VFailAbortTakeOff(double VDecision)
        {
            //Declare parameters
            //Length parameters (e.g. height, length, and so on)
            double Height = 0;
            double Distance = 0;

            //Angle parameters (e.g. gamma, theta, and so on)
            double Gamma = 0;
            double Alpha = 0;

            //Coefficients (e.g. CL, CD)
            double LiftCoefficient;
            double DragCoefficient;

            //Forces (e.g. Lift, Drag, and so on)
            double L;
            double D;
            double Thrust = ThrustMax;
            double N;

            //Misc.
            double Velocity = 0;
            double deltaV;
            double Mu = muRoll;
            double Vminimum = Vmin();
            double Vrotation = Vrot(Vminimum);

            Time = 0;

            //Create arraylist
            ArrayList TimeList = new ArrayList();
            ArrayList VelocityList = new ArrayList();
            ArrayList DistanceList = new ArrayList();
            ArrayList HeightList = new ArrayList();

            while (Velocity >= 0)
            {
                Time = Time + dTime;

                LiftCoefficient = CL(Alpha);
                DragCoefficient = CD(Velocity, VFail, LiftCoefficient);

                L = Lift(Velocity, LiftCoefficient);
                N = NormalForce(L, Height);
                D = Drag(DragCoefficient, Velocity, Mu, N);
                deltaV = dV(Thrust, D, Gamma);

                Velocity = Velocity + deltaV * dTime;
                Distance = Distance + Velocity * dTime;

                //Condition for surpassing failure speed
                if (Velocity > VDecision)
                {
                    Thrust = 0;
                    Mu = MuBrake;
                }

                TimeList.Add(Time);
                VelocityList.Add(Velocity);
                DistanceList.Add(Distance);
                HeightList.Add(Height);
            }

            //Array
            double[,] Array = convertListsToArray(TimeList, VelocityList, DistanceList, HeightList);

            //Return the array with the stored values
            return Array;
        }

        //Method for BFL calculation [continued takeoff]
        public double[,] VFailContinueTakeOff(double VDecision)
        {
            //Declare parameters
            //Length parameters (e.g. height, length, and so on)
            double Height;
            double Distance;

            //Angle parameters (e.g. gamma, theta, and so on)
            double Gamma;
            double Alpha;
            double Theta;
            double deltaG;

            //Coefficients (e.g. CL, CD)
            double LiftCoefficient;
            double DragCoefficient;

            //Forces (e.g. Lift, Drag, and so on)
            double L;
            double D;
            double Thrust;
            double N;

            //Misc.
            double Velocity;
            double deltaV;
            double Vminimum = Vmin();
            double Vrotation = Vrot(Vminimum);

            //Create arraylists
            ArrayList TimeList = new ArrayList();
            ArrayList VelocityList = new ArrayList();
            ArrayList DistanceList = new ArrayList();
            ArrayList HeightList = new ArrayList();


            //Initial Conditions
            Time = 0;
            Height = 0;
            Distance = 0;
            Alpha = 0;
            LiftCoefficient = 0;
            DragCoefficient = 0;
            L = 0;
            D = 0;
            Theta = 0;
            Gamma = 0;
            Thrust = ThrustMax;
            Velocity = 0;

            while (Height <= Screenheight)
            {
                Time = Time + dTime;
                Alpha = Theta - Gamma;
                LiftCoefficient = CL(Alpha);
                L = Lift(Velocity, LiftCoefficient);
                DragCoefficient = CD(Velocity, VFail, LiftCoefficient);
                N = NormalForce(L, Height);
                D = Drag(DragCoefficient, Velocity, muRoll, N);
                deltaV = dV(Thrust, D, Gamma);
                deltaG = dGamma(Velocity, L, N);

                Gamma = Gamma + deltaG * dTime;
                Velocity = Velocity + deltaV * dTime;
                Distance = Distance + Velocity * dTime;
                Height = Height + Velocity * Math.Sin(Gamma);

                //Condition to set theta (occurs after rotational speed)
                if (Velocity > Vrotation)
                {
                    if (Theta < thetaMax)
                    {
                        Theta = Theta + dTheta * dTime;
                    }
                    else
                    {
                        Theta = thetaMax;
                    }
                }

                //Condition to set reduced engine
                if (Velocity >= VDecision)
                {
                    Thrust = ThrustMax * (1 - ((double)nrOfEnginesFailed / (double)nrOfEngines));
                }

                TimeList.Add(Time);
                VelocityList.Add(Velocity);
                DistanceList.Add(Distance);
                HeightList.Add(Height);
            }

            //Array
            double[,] Array = convertListsToArray(TimeList, VelocityList, DistanceList, HeightList);

            return Array;
        }
        #endregion:

    }
}
