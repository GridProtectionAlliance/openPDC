using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace openPDCManager.Pages.Monitoring
{
    public class InputMonitorData
    {
        public int PointID { get; set; }
        public string SignalReference { get; set; }
        public string Description { get; set; }
        public string TimeStamp { get; set; }
        public double Value { get; set; }
        public string EngineeringUnit { get; set; }
        public string Quality { get; set; }
        public SolidColorBrush Background { get; set; }
    }
}
