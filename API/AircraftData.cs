using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API
{
    class AircraftData
    {
        //Properties
        private string maxAvailableThrust;
        private string nrFailedEngines;
        private string nrEngines;
        private string muRoll;
        private string muBrake;
        private string weight;
        private string maxPitch;
        private string pitchGradient;
        private string aircraftName;
        private Boolean propellerAircraft;

        /// <summary>
        /// Default constructor; is not accesible by others
        /// </summary>
        private AircraftData()
        {
        }

        /// <summary>
        /// Constructur for the class aircraftdata. This class holds predefined aircraftdata of the user
        /// </summary>
        /// <param name="aircraftName">The name of the aircraft</param>
        /// <param name="maxAvailableThrust">Maximum available thrust of the aircraft</param>
        /// <param name="nrFailedEngines">Amount of engines failed during takeoff procedure</param>
        /// <param name="nrEngines">Amount of engines</param>
        /// <param name="muRoll">Kinematic friction coefficient when rolling</param>
        /// <param name="muBrake">Kinematic friction coefficient when braking</param>
        /// <param name="weight">Maximum takeoff weight of the aircraft</param>
        /// <param name="maxPitch">Maximum pitch angle of the aircraft</param>
        /// <param name="pitchGradient">Pitch gradient</param>
        /// <param name="propellerAircraft">Indicates whether the plane is a propeller aircraft</param>
        public AircraftData(string aircraftName,
            string maxAvailableThrust, string nrFailedEngines, string nrEngines,
            string muRoll, string muBrake,
            string weight,
            string maxPitch, string pitchGradient,
            Boolean propellerAircraft)
        {
            this.aircraftName = aircraftName;

            this.maxAvailableThrust = maxAvailableThrust;
            this.nrEngines = nrEngines;
            this.nrFailedEngines = nrFailedEngines;
            
            this.muRoll = muRoll;
            this.muBrake = muBrake;
            
            this.weight = weight;

            this.maxPitch = maxPitch;
            this.pitchGradient = pitchGradient;

            this.propellerAircraft = propellerAircraft;
        }

        /// <summary>
        /// Property to determine whether the plane is a propeller aircraft
        /// </summary>
        public Boolean IsPropellerAircraft
        {
            get { return propellerAircraft; }
        }

        /// <summary>
        /// Method to return all the aircraft data as a dictionary
        /// </summary>
        /// <returns>A dictionary containing the aircraftdata</returns>
        public Dictionary<string, string> GetAircraftData()
        {
            Dictionary<string, string> aircraftDictionary = new Dictionary<string,string>();
            aircraftDictionary.Add("aircraftname", aircraftName);

            aircraftDictionary.Add("maxavailablethrust", maxAvailableThrust);
            aircraftDictionary.Add("nrengines", nrEngines);
            aircraftDictionary.Add("nrfailedengines", nrFailedEngines);

            aircraftDictionary.Add("muroll", muRoll);
            aircraftDictionary.Add("mubrake", muBrake);

            aircraftDictionary.Add("weight", weight);

            aircraftDictionary.Add("maxpitch", maxPitch);
            aircraftDictionary.Add("pitchgradient", pitchGradient);

            return aircraftDictionary;
        }
    }
}
