using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelGenerator
{
    interface IAxisProperties
    {
        string getAxisName();

        int getLabelSpacing();
        int getTickmarkSpacing();

        bool hasMajorGridLines();
        bool hasMinorGridLines();
    }
}
