using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using openPDCManager.Web.Data.BusinessObjects;

namespace openPDCManager.Pages.Adapters
{
    public class DeviceMeasurementDataForBinding
    {
        public ObservableCollection<DeviceMeasurementData> DeviceMeasurementDataList { get; set; }
        public bool IsExpanded { get; set; }        
    }

    public class StatisticMeasurementDataForBinding
    {
        public ObservableCollection<StatisticMeasurementData> StatisticMeasurementDataList { get; set; }
        public bool IsExpanded { get; set; }
    }
}
