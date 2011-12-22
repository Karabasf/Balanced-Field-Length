using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelGenerator
{
    /// <summary>
    /// Baseclass for each derived excelgraph objects
    /// </summary>
    abstract class ExcelGraph
    {
        private Excel.ChartObjects ExcelChartObjects;
        protected Excel.Chart ExcelChart;

        /// <summary>
        /// Base class for each excel graph. Default
        /// </summary>
        /// <param name="targetSheet">The sheet where the graph should be put on</param>
        /// <param name="xLocation">The X Location (from the left) of the graph</param>
        /// <param name="yLocation">The Y location (from the top) of the graph</param>
        /// <param name="xSize">The width of the graph</param>
        /// <param name="ySize">The height of the graph</param>
        protected virtual ExcelGraph(Excel._Worksheet targetSheet, double xLocation, double yLocation, 
            double xSize, double ySize)
        {
            this.ExcelChartObjects = (Excel.ChartObjects)targetSheet.ChartObjects(Missing.Value);
            this.ExcelChart = ExcelChartObjects.Add(xLocation, yLocation, xSize, ySize).Chart;
        }

        /// <summary>
        /// Method to set the title of a graph
        /// </summary>
        /// <param name="ChartTitle">The title of the graph</param>
        protected sealed void setChartTitle(string ChartTitle)
        {
            ExcelChart.HasTitle = true;
            ExcelChart.ChartTitle.Text = ChartTitle;
        }


        //TODO
        abstract void setXAxis();

        abstract void setYAxis();
        
        
    }
}
