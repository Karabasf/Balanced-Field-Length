using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace API
{
    class customToolTip
    {
        private string tooltipText;
        private Control assignedControl;

        private int autoShow;
        private int initialDelay;
        private int reshowDelay;

        //Declare a private tooltip
        private ToolTip tooltip = new ToolTip();

        //Properties for the tooltip
        public string TooltipText
        {
            set { tooltipText = value; }
        }

        public Control AssignedControl
        {
            set { assignedControl = value; }
        }

        public int AutoShow
        {
            set { autoShow = value; }
        }

        public int InitialDelay
        {
            set { initialDelay = value; }
        }

        public int ReshowDelay
        {
            set { reshowDelay = value; }
        }

        public void setTooltip(Boolean active)
        {
            tooltip.AutoPopDelay = autoShow;
            tooltip.InitialDelay = initialDelay;
            tooltip.ReshowDelay = reshowDelay;

            tooltip.SetToolTip(assignedControl, tooltipText);
            tooltip.Active = active;
        }
    }
}
