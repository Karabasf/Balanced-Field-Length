using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelGenerator
{
    /// <summary>
    /// A readonly class to hold relevant axis parameters. Implements the interface IAxis properties
    /// </summary>
    class AxisProperty: IAxisProperties 
    {
        private string AxisName;
        private int LabelSpacing;
        private int TickMarkSpacing;
        private bool MajorGridlines;
        private bool MinorGridlines;

        /// <summary>
        /// Constructor to instatiate an Axisproperty class. Class is used to hold relevant axis parameters
        /// </summary>
        /// <param name="AxisName">The title of the axis</param>
        /// <param name="LabelSpacing">An integer specifying the spacing between the labels</param>
        /// <param name="TickMarkSpacing">An integer specifying the spacing between the tickmarks</param>
        /// <param name="MajorGridlines">Defines whether the axis has majorgridlines</param>
        /// <param name="MinorGridlines">Defines whether the axis has minorgridlines</param>
        public AxisProperty(string AxisName, int LabelSpacing, int TickMarkSpacing,
            bool MajorGridlines, bool MinorGridlines)
        {
            this.AxisName = AxisName;
            
            this.LabelSpacing = LabelSpacing;
            this.TickMarkSpacing = TickMarkSpacing;

            this.MajorGridlines = MajorGridlines;
            this.MinorGridlines = MinorGridlines;
        }

        /// <summary>
        /// Constructor to instantiate an Axisproperty class. Class is used to hold relevant axis parameters. Tickmarks and LabelSpacing are not included
        /// </summary>
        /// <param name="AxisName">The title of the axis</param>
        /// <param name="MajorGridlines">Defines whether the axis has majorgridlines</param>
        /// <param name="MinorGridlines">Defines whether the axis has minorgridlines</param>
        public AxisProperty(string AxisName, bool MajorGridlines, bool MinorGridlines)
        {
            this.AxisName = AxisName;

            this.TickMarkSpacing = -1;
            this.LabelSpacing = -1;

            this.MajorGridlines = MajorGridlines;
            this.MinorGridlines = MinorGridlines;
        }

        #region: Readonly properties (interface properties)
        public string getAxisName()
        {
            return AxisName;
        }

        public int getLabelSpacing()
        {
            return LabelSpacing;
        }

        public int getTickmarkSpacing()
        {
            return TickMarkSpacing;
        }

        public bool hasMajorGridLines()
        {
            return MajorGridlines;
        }

        public bool hasMinorGridLines()
        {
            return MinorGridlines;
        }
        #endregion:

        #region: Methods to retrieve properties

        /// <summary>
        /// The name of the axis
        /// </summary>
        public string Name
        {
            get { return AxisName; }
            set { this.AxisName = value; }
        }

        /// <summary>
        /// The amount of labelspacing (in pixels)
        /// </summary>
        public int LabelSpace
        {
            get { return LabelSpacing; }
            set { this.LabelSpacing = value; }
        }

        /// <summary>
        /// The tickmarkspacing (in pixels)
        /// </summary>
        public int TickmarkSpace
        {
            get { return TickMarkSpacing; }
            set { this.TickMarkSpacing = value; }
        }

        /// <summary>
        /// Has major gridlines
        /// </summary>
        public bool MajorGridLines
        {
            get { return MajorGridlines; }
            set { this.MajorGridlines = value; }
        }

        /// <summary>
        /// Has minor gridlines
        /// </summary>
        public bool MinorGridLines
        {
            get { return MinorGridlines; }
            set { this.MinorGridlines = value; }
        }
        #endregion

    }
}
