using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelGenerator
{
    //An enumoerator for the axis types
    enum LineAxisTypes { XAxis, YAxis };


    /// <summary>
    /// A derived class from Excelgraph in order to draw a linegraph
    /// </summary>
    sealed class ExcelLineGraph : ExcelGraph
    {
        public ExcelLineGraph(Excel._Worksheet targetSheet, double xLocation, double yLocation,
            double xSize, double ySize) : base(targetSheet, xLocation, yLocation, xSize, ySize)
        {
            ExcelChart.ChartType = Excel.XlChartType.xlLine;
        }

        /// <summary>
        /// Method to set the title of the Excel line graph
        /// </summary>
        /// <param name="titleName">The title of the graph</param>
        public void setGraphTitle(string titleName)
        {
            base.setChartTitle(titleName);
        }

        /// <summary>
        /// Method to set the properties of an axis of a line graph
        /// </summary>
        /// <param name="AxisParameters">An AxisProperty object which hold the relevant data to set an axis</param>
        /// <param name="AxisType">The type of axis. Takes the LineAxisTypes enumerator as an input</param>
        public override void setAxis(IAxisProperties AxisParameters, LineAxisTypes AxisType)
        {
            Excel.Axis Axis;
            //Determine whether the axis is an Y or an X axis. This is done by using the enumerator
            if (AxisType == LineAxisTypes.XAxis)
            {
                 Axis = (Excel.Axis)ExcelChart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary);
            }
            else
            {
                Axis = (Excel.Axis)ExcelChart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary);
            }

            //Set the axis properties. If the axis title is null, no title is set
            if (!String.IsNullOrEmpty(AxisParameters.getAxisName()))
            {
                Axis.HasTitle = true;
                Axis.AxisTitle.Text = AxisParameters.getAxisName();
            }

            //Set the labelspacing. If labelspacing < 0 , then no labelspacing is necessary (see Axisproperty)
            if (AxisParameters.getLabelSpacing() > 0)
            {
                Axis.TickLabelSpacing = AxisParameters.getLabelSpacing();
            }

            //Set the labelspacing. If tickspacing < 0 , then no tickmarkspacing is necessary (see Axisproperty)
            if (AxisParameters.getTickmarkSpacing() > 0)
            {
                Axis.TickMarkSpacing = AxisParameters.getTickmarkSpacing();
            }

            //Set the gridline properties of the axis
            Axis.HasMajorGridlines = AxisParameters.hasMajorGridLines();
            Axis.HasMinorGridlines = AxisParameters.hasMinorGridLines();
        }
    }
}
