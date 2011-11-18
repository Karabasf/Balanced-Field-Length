using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AircraftMethods
{
    class ImplementMethodException:Exception
    {
        public ImplementMethodException() :base()
        {
        }

        public ImplementMethodException(string message)
            : base(message)
        {

        }
    }
}
