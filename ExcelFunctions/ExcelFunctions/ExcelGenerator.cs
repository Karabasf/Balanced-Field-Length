using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelGenerator
{
    public class ExcelGenerator
    {
        //Define attributes
        private Excel.Application ExcelDocument;
        private Excel._Workbook WorkBook;
        private Excel.Sheets ExcelSheets;           //Used to add Excel sheets
        private Excel._Worksheet ActiveSheet;
        private string AircraftName;

        /// <summary>
        /// Constructor for the ExcelGenerator to generate an Excelsheet
        /// </summary>
        /// <param name="AircraftName">The name of the aircraft, used for saving the excel file</param>
        /// <param name="DocumentVisible">Boolean to determine whether the document should be visible during the generation of the Excel document</param>
        /// <param name="ActiveUserControl">Boolean to determine whether user control is active during the generation of the Excel document</param>
        public ExcelGenerator(string AircraftName, bool DocumentVisible, bool ActiveUserControl)
        {
            this.AircraftName = AircraftName;

            try
            {
                //Start Excel and get Application object.
                this.ExcelDocument = new Excel.Application();

                //The standard active sheet is the first sheet
                ActiveSheet = (Excel._Worksheet)WorkBook.Sheets[1];

                //Visibility of excel app.
                ExcelDocument.Visible = DocumentVisible;

                //Maintain input of the user (which should be false during generation)
                ExcelDocument.UserControl = ActiveUserControl;

                //Get a new workbook
                WorkBook = (Excel._Workbook)(ExcelDocument.Workbooks.Add(Missing.Value));

                //Instantiate an Excelsheet object
                ExcelSheets = WorkBook.Sheets as Excel.Sheets;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method to add an sheet in the workbook behind the specified position. Directly assigns an worksheet
        /// </summary>
        /// <param name="sheetName">The name of the sheet</param>
        /// <param name="position">The position should be between 1 and the maximum amount of sheets in the workbook. If not, an ArgumentException is thrown</param>
        /// <returns>An Excel._Worksheet object</returns>
        public Excel._Worksheet addSheet(string sheetName, int position) 
        {
            //Check if the position argument is valid. If not, throw an argument exception
            if (position <= 0)
            {
                throw new ArgumentException("Argument position cannot be equal or smaller than 0");
            }
            else if (position > WorkBook.Sheets.Count)
            {
                throw new ArgumentException(String.Format("Argument position is bigger than the amount of sheets, maximum is {0}", WorkBook.Sheets.Count));
            }

            //Create the new worksheet at the user specified position and rename it 
            Excel._Worksheet newSheet = (Excel._Worksheet)ExcelSheets.Add(ExcelSheets[position], Missing.Value, Missing.Value, Missing.Value);
            newSheet.Name = sheetName;
            
            return newSheet;
        }

        /// <summary>
        /// Method to set an active Excel sheet on basis of a position
        /// </summary>
        /// <param name="position">The position of the sheet</param>
        public void setActiveSheet(int position)
        {
            //Check if the position argument is valid. If not, throw an argument exception
            if (position <= 0)
            {
                throw new ArgumentException("Argument position cannot be equal or smaller than 0");
            }
            else if (position > WorkBook.Sheets.Count)
            {
                throw new ArgumentException(String.Format("Argument position is bigger than the amount of sheets, maximum is {0}", WorkBook.Sheets.Count));
            }

            //Set the active sheet and select it (in order to display it in the Excel screen if visible)
            ActiveSheet = (Excel._Worksheet)WorkBook.Sheets[position];
            ActiveSheet.Select(Missing.Value);
        }

        /// <summary>
        /// Method to set an active Excel sheet on basis of a sheet name
        /// </summary>
        /// <param name="sheetName">The neem of the sheet which needs to be returned</param>
        /// <returns>If the sheet is found, an Excel._Worksheet object is returned; else null</returns>
        public void setActiveSheet(string sheetName)
        {
            Excel._Worksheet returnSheet = null;

            foreach (Excel._Worksheet sheet in WorkBook.Sheets)
            {
                if(sheet.Name.Equals(sheetName))
                {
                    returnSheet = sheet;
                    break;
                }
            }

            //If the sheet could not be found on basis of the name, throw an Argument exception.
            //If the returnsheet could be found, assign it to the activesheet and select it (in order to make to display it)
            if (returnSheet == null)
            {
                throw new ArgumentException("Invalid sheet name, sheet does not exist");
            }
            else
            {
                ActiveSheet = returnSheet;
                ActiveSheet.Select(Missing.Value);
            }

        }

        //Method to save the file
        private static void saveExcel(Excel._Workbook WorkBook, string AircraftName)
        {
            //Initiate save file dialog
            SaveFileDialog sdi = new SaveFileDialog();
            sdi.CheckPathExists = true;

            sdi.Filter = "Excel (*.xls)|*.xls";
            sdi.InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            sdi.FileName = AircraftName + " - Datasheet";
            sdi.RestoreDirectory = true;
            sdi.AddExtension = true;
            sdi.CheckFileExists = false;

            DialogResult messageBoxResult = DialogResult.No;

            while (messageBoxResult == DialogResult.No)
            {
                DialogResult sdiResult = sdi.ShowDialog();

                if (sdiResult == DialogResult.OK)
                {
                    object fileFormat = Excel.XlFileFormat.xlWorkbookNormal;
                    string fileName = sdi.FileName;

                    //Save the document
                    WorkBook.SaveAs(fileName, fileFormat,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                    //Break out the loop if the user decides to save
                    break;
                }
                else
                {
                    messageBoxResult = MessageBox.Show("Warning - The excel document will not be saved! \nContinue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
            }
        }

        #region: Methods to set data in the sheets
        //Method to set the aircraftdata in the workbook in the corresponding sheet
        private static void AircraftData(Excel._Worksheet AircraftDataSheet, string[,] AircraftDataArray)
        {
            //Set sheetname
            AircraftDataSheet.Name = "AircraftData";

            //Used for the graphical representation of cells
            AircraftDataSheet.get_Range("A1", "C1").Font.Bold = true;
            AircraftDataSheet.get_Range("A2", "A32").Font.Bold = true;
            AircraftDataSheet.get_Range("A1", "C1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            AircraftDataSheet.get_Range("A1", "C32").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            AircraftDataSheet.get_Range("A2", "A32").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            //Header items:
            AircraftDataSheet.Cells[1, 1] = "Property";
            AircraftDataSheet.Cells[1, 2] = "Value";
            AircraftDataSheet.Cells[1, 3] = "Unit";

            //Get the length [rank 1] of the string array
            int ArrayLength;
            ArrayLength = AircraftDataArray.GetLength(0) + 1;
            string EndRange;

            //Fill cells
            EndRange = String.Concat("C", ArrayLength.ToString());
            AircraftDataSheet.get_Range("A2", EndRange).Value2 = AircraftDataArray;

            //Configure autofit
            Excel.Range WorkSheetRange = AircraftDataSheet.get_Range("A1", "C32");
            WorkSheetRange.EntireColumn.AutoFit();
        }

        //Method for the calculationdata
        private static void DistanceVSFailureSpeed(Excel._Worksheet Calculationdata, double[] VFail, double[] ContinuedTakeOffDist, double[] AbortedTakeOffDist)
        {
            //Set loop parameter
            int i;

            //Set sheetname
            Calculationdata.Name = "CalculationData";

            //Header items:
            Calculationdata.Cells[1, 1] = "Velocity [m/s]";
            Calculationdata.Cells[1, 2] = "Continued Takeoff [m]";
            Calculationdata.Cells[1, 3] = "Aborted Takeoff [m]";

            //Used for the graphical representation of cells
            Calculationdata.get_Range("A1", "C1").Font.Bold = true;
            Calculationdata.get_Range("A1", "C1").VerticalAlignment = Excel.XlVAlign.xlVAlignJustify;
            Calculationdata.get_Range("A1", "C1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            Calculationdata.get_Range("A1", "C1").EntireColumn.AutoFit();
            Calculationdata.get_Range("A1", "C1").EntireRow.AutoFit();

            //A 'for' loop to insert data in the corresponding cells
            for (i = 2; i < VFail.Length + 2; i++)
            {
                Calculationdata.Cells[i, 1] = VFail[i - 2];
                Calculationdata.Cells[i, 2] = ContinuedTakeOffDist[i - 2];
                Calculationdata.Cells[i, 3] = AbortedTakeOffDist[i - 2];
            }

            //format cells
            string str = (VFail.Length + 1).ToString();
            string Range = String.Concat("C", str);
            Excel.Range WorksheetRange = Calculationdata.get_Range("A1", Range);
            WorksheetRange.NumberFormat = "0.00";

            int Length = VFail.Length + 2;

            //Plot method
            PlotVDGraphs(Calculationdata, Length);
        }

        //Method to insert the BFL values
        private static void BFLParameters(Excel._Worksheet VDecisionSheet, double VDecision, double BFL)
        {
            VDecisionSheet.Name = "VDecision properties";
            
            //Headers
            VDecisionSheet.Cells[1, 11] = "Property";
            VDecisionSheet.Cells[1, 12] = "Value";
            VDecisionSheet.Cells[1, 13] = "Unit";

            //Row items
            VDecisionSheet.Cells[2, 11] = "Decision Speed";
            VDecisionSheet.Cells[3, 11] = "BFL";

            VDecisionSheet.Cells[2, 13] = "[m/s]";
            VDecisionSheet.Cells[3, 13] = "[m]";

            
            //Used for the graphical representation of cells
            VDecisionSheet.get_Range("K1", "M3").Font.Bold = true;
            VDecisionSheet.get_Range("L2", "M3").Font.Bold = false;
            VDecisionSheet.get_Range("K1", "M1").VerticalAlignment = Excel.XlVAlign.xlVAlignJustify;
            VDecisionSheet.get_Range("K1", "M3").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            VDecisionSheet.get_Range("K2", "K3").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            VDecisionSheet.get_Range("L2", "L3").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
            VDecisionSheet.get_Range("K1", "K3").EntireColumn.AutoFit();
             

            //Fill the corresponding data
            VDecisionSheet.Cells[2, 12] = VDecision;
            VDecisionSheet.Cells[3, 12] = BFL;
        }

        //Method for the calculations for VDecision
        private static void BFLVelocity(Excel._Worksheet VDecisionSheet, double[,] ArrayVATO, double[,] ArrayVCTO)
        {
            //Headers
            VDecisionSheet.Cells[1, 1] = "ATO";
            VDecisionSheet.Cells[2, 1] = "Time [s]";
            VDecisionSheet.Cells[2, 2] = "Velocity [m/s]";
            VDecisionSheet.Cells[2, 3] = "Distance [m]";
            VDecisionSheet.Cells[2, 4] = "Height [m]";

            VDecisionSheet.Cells[1, 6] = "CTO";
            VDecisionSheet.Cells[2, 6] = "Time [s]";
            VDecisionSheet.Cells[2, 7] = "Velocity [m/s]";
            VDecisionSheet.Cells[2, 8] = "Distance [m]";
            VDecisionSheet.Cells[2, 9] = "Height [m]";

            //Fill cells
            int RangeATO;
            int RangeCTO;

            RangeATO = ArrayVATO.GetLength(1);
            RangeCTO = ArrayVCTO.GetLength(1);
            
            //Fill cells with ATO data
            for (int i = 3; i < RangeATO + 3; i++)
            {
                VDecisionSheet.Cells[i, 1] = ArrayVATO[0, i - 3];
                VDecisionSheet.Cells[i, 2] = ArrayVATO[1, i - 3];
                VDecisionSheet.Cells[i, 3] = ArrayVATO[2, i - 3];
                VDecisionSheet.Cells[i, 4] = ArrayVATO[3, i - 3];
            }

            //Fill cells with CTO data
            for (int i = 3; i < RangeCTO + 3; i++)
            {
                VDecisionSheet.Cells[i, 6] = ArrayVCTO[0, i - 3];
                VDecisionSheet.Cells[i, 7] = ArrayVCTO[1, i - 3];
                VDecisionSheet.Cells[i, 8] = ArrayVCTO[2, i - 3];
                VDecisionSheet.Cells[i, 9] = ArrayVCTO[3, i - 3];
            }
            
        }
        #endregion:

        #region: Methods to plot data
        //Plot the graph with Distance vs. VFail
        private static void PlotVDGraphs(Excel._Worksheet CalculationData, int Length)
        {
            try
            {
                //Create an chartobject in the worksheet
                Excel.ChartObjects xlCharts = (Excel.ChartObjects)CalculationData.ChartObjects(Missing.Value);
                Excel.ChartObject DistanceVChart = (Excel.ChartObject)xlCharts.Add(200, 20, 750, 500);
                Excel.Chart Chart = DistanceVChart.Chart;

                //Create a series and a series collector
                Excel.SeriesCollection seriecollector;
                Excel.Series AbortedTakeOff;
                Excel.Series ContinuedTakeOff;

                seriecollector = Chart.SeriesCollection(Missing.Value);

                //Define series
                AbortedTakeOff = seriecollector.NewSeries();
                ContinuedTakeOff = seriecollector.NewSeries();

                //Concat some strings
                string VFailRange = String.Concat("A", Length.ToString());
                string CTORange = String.Concat("B", Length.ToString());
                string ATORange = String.Concat("C", Length.ToString());

                //Set values for continued takeoff
                ContinuedTakeOff.XValues = CalculationData.get_Range("A2", VFailRange);
                ContinuedTakeOff.Values = CalculationData.get_Range("B2", CTORange);
                ContinuedTakeOff.Name = "Continued take off";

                //Set values for Aborted takeoff
                AbortedTakeOff.XValues = CalculationData.get_Range("A2", VFailRange);
                AbortedTakeOff.Values = CalculationData.get_Range("C2", ATORange);
                AbortedTakeOff.Name = "Aborted take off";

                //Set chart properties
                //set charttype
                Chart.ChartType = Excel.XlChartType.xlLine;

                //set title
                Chart.HasTitle = true;
                Chart.ChartTitle.Text = "Distance vs. Velocity";

                //Set Axis names
                //X- axis
                Excel.Axis axis;
                axis = (Excel.Axis)Chart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary);
                axis.HasTitle = true;
                axis.AxisTitle.Text = "Velocity [m/s]";
                axis.TickLabelSpacing = 50;
                axis.TickMarkSpacing = 50;
                axis.HasMajorGridlines = false;
                axis.HasMinorGridlines = false;

                //Y-axis
                axis = (Excel.Axis)Chart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary);
                axis.HasTitle = true;
                axis.AxisTitle.Text = "Distance [m]";
                axis.HasMajorGridlines = true;
                axis.HasMinorGridlines = false;

                DumpResource(xlCharts);
                DumpResource(DistanceVChart);
                DumpResource(Chart);
                DumpResource(seriecollector);
                DumpResource(AbortedTakeOff);
                DumpResource(ContinuedTakeOff);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //General 'generator' for plots based on the VDecisionSheet
        //To be constructed
        private static void Plot(Excel._Worksheet DataSheet, Excel._Worksheet TargetSheet,
            string XRangeBegin1, string XRangeEnd1, string YRangeBegin1, string YRangeEnd1, string Name1,
            string XRangeBegin2, string XRangeEnd2, string YRangeBegin2, string YRangeEnd2, string Name2,
            int xTickmarkSpacing, int xLabelSpacing,
            string ChartTitle,
            string xAxisName, string yAxisName,
            double xLocation, double yLocation)
        {
            
            //Create a chart object in the Targetsheet
            Excel.ChartObjects xlChart = (Excel.ChartObjects)TargetSheet.ChartObjects(Missing.Value);
            Excel.ChartObject chartObject = (Excel.ChartObject)xlChart.Add(xLocation, yLocation, 750, 500);
            Excel.Chart chart = chartObject.Chart;

            //Set the charttype
            chart.ChartType = Excel.XlChartType.xlLine;
            
            try
            {
                //Create the series and the serie collector
                Excel.SeriesCollection serieCollector = chart.SeriesCollection(Missing.Value);
                Excel.Series serie1 = serieCollector.NewSeries();
                Excel.Series serie2 = serieCollector.NewSeries();

                //set values for serie 1
                serie1.XValues = DataSheet.get_Range(XRangeBegin1, XRangeBegin2);
                serie1.Values = DataSheet.get_Range(YRangeBegin1, YRangeBegin2);
                serie1.Name = Name1;

                //Set values for serie 2
                serie2.XValues = DataSheet.get_Range(XRangeBegin1, XRangeBegin2);
                serie2.Values = DataSheet.get_Range(YRangeBegin1, YRangeBegin2);
                serie2.Name = Name2;

                //Set Chartproperties
                //Set title properties
                chart.HasTitle = true;
                chart.ChartTitle.Text = ChartTitle;

                //Axis properties
                //X-axis
                Excel.Axis xAxis = (Excel.Axis)chart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary);
                xAxis.HasTitle = true;
                xAxis.AxisTitle.Text = xAxisName;
                xAxis.TickLabelSpacing = xLabelSpacing;
                xAxis.TickMarkSpacing = xTickmarkSpacing;
                xAxis.HasMajorGridlines = false;
                xAxis.HasMinorGridlines = false;

                //Y-axis
                Excel.Axis yAxis = (Excel.Axis)chart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary);
                yAxis.HasTitle = true;
                yAxis.AxisTitle.Text = yAxisName;
                xAxis.HasMajorGridlines = true;
                xAxis.HasMinorGridlines = false;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                DumpResource(chartObject);
                DumpResource(chart);
            }
        }

        #endregion:

        /// <summary>
        /// Method to finalize the generation of the Excel document
        /// </summary>
        public void Quit()
        {
            //Close the workbook and quit Excel 
            WorkBook.Close(true, Missing.Value, Missing.Value);
            ExcelDocument.Quit();

            //Release the used resources
            DumpResource(WorkBook);
            DumpResource(ExcelDocument);
            DumpResource(ExcelSheets);
            DumpResource(ActiveSheet);
        }


        //Garbage collector and releases used resources
        //To be implemented later
        private static void DumpResource(object Obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Obj);
                Obj = null;
            }

            catch (Exception)
            {
                Obj = null;
            }
            finally
            {
                //Run the garbagecollector to free up system resources
                GC.GetTotalMemory(false);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.GetTotalMemory(true);
            }
        }
    }
}