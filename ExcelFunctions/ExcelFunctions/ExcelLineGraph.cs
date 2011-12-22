using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelGenerator
{
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
    }
}
