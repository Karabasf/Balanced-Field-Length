using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AircraftMethods
{
    class Jetplane: AirplaneFailedEngine
    {
        public Jetplane(AirplaneData planeData, double CD0_FailedEngines, int nrOfFailedEngines)
            : base(planeData, CD0_FailedEngines, nrOfFailedEngines)
        {

        }


    }
}
