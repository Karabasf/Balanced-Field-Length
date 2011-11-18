using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AircraftMethods
{
    /// <summary>
    /// A class to construct a plane object. Currently it is possible to construct another object, however it is not verified whether it works
    /// </summary>
    class JetPlane : AirplaneFailedEngine
    {
        #region: Calculation Methods for crucial parameters
        //Method to calculate the rotational speed
        private double calculateVRot(double VMin)
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
                CD = CD0_FailedEngine + ((Math.Pow(LiftCoefficient, 2)) / (Math.PI * AR * e));
            }
            else
            {
                CD = CD0_RunningEngine + ((Math.Pow(LiftCoefficient, 2)) / (Math.PI * AR * e));
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
            double Velocity = 0;

            nrElements = (int)(Vmax / dVFail);

            double[] VelocityRange = new double[nrElements + 1];

            for (i = 0; i < VelocityRange.Length; i++)
            {
                VelocityRange[i] = Velocity;
                Velocity = Velocity + dVFail;
            }

            return VelocityRange;
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

            double[,] array = new double[4, Timearray.Length];

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
            double Vrotation = calculateVRot(Vminimum);

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
            double Vrotation = calculateVRot(Vminimum);

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
            double Vrotation = calculateVRot(Vminimum);

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
            double Vrotation = calculateVRot(Vminimum);

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
