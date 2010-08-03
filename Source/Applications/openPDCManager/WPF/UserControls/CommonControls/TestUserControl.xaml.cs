using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using openPDCManager.Web.Data;
using openPDCManager.Web.Data.BusinessObjects;
using System.Windows.Threading;

namespace openPDCManager.UserControls.CommonControls
{
    /// <summary>
    /// Interaction logic for TestUserControl.xaml
    /// </summary>
    public partial class TestUserControl : UserControl
    {
        ObservableCollection<DeviceMeasurementData> m_deviceMeasurementDataList;
        DispatcherTimer m_thirtySecondsTimer;
        KeyValuePair<int, int> m_minMaxPointIDs;

        public TestUserControl()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(TestUserControl_Loaded);
            //m_thirtySecondsTimer = new DispatcherTimer();
            //m_thirtySecondsTimer.Interval = TimeSpan.FromSeconds(30);
            //m_thirtySecondsTimer.Tick += new EventHandler(thirtySecondsTimer_Tick);
            //m_thirtySecondsTimer.Start();
        }

        void thirtySecondsTimer_Tick(object sender, EventArgs e)
        {
            App app = (App)Application.Current;
            GetTimeTaggesMeasurements(app.TimeSeriesDataServiceUrl + "/timeseriesdata/read/current/" + m_minMaxPointIDs.Key.ToString() + "-" + m_minMaxPointIDs.Value.ToString() + "/XML");
            
        }

        void TestUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            GetMinMaxPointIDs();
            m_deviceMeasurementDataList = new ObservableCollection<DeviceMeasurementData>(CommonFunctions.GetDeviceMeasurementData(((App)Application.Current).NodeValue));
            ListBoxDeviceList.ItemsSource = m_deviceMeasurementDataList;
            App app = (App)Application.Current;
            GetTimeTaggesMeasurements(app.TimeSeriesDataServiceUrl + "/timeseriesdata/read/current/" + m_minMaxPointIDs.Key.ToString() + "-" + m_minMaxPointIDs.Value.ToString() + "/XML");
        }

        void GetMinMaxPointIDs()
        {
            m_minMaxPointIDs = CommonFunctions.GetMinMaxPointIDs(((App)Application.Current).NodeValue);
        }

        void GetTimeTaggesMeasurements(string url)
        {
            try
            {
                Dictionary<int, TimeTaggedMeasurement> timeTaggedMeasurements = new Dictionary<int, TimeTaggedMeasurement>();
                timeTaggedMeasurements = CommonFunctions.GetTimeTaggedMeasurements(url);
                //TextBlockLastRefresh.Text = "Last Refresh: " + DateTime.Now.ToString();
                foreach (DeviceMeasurementData deviceMeasurement in m_deviceMeasurementDataList)
                {
                    foreach (DeviceInfo device in deviceMeasurement.DeviceList)
                    {
                        foreach (MeasurementInfo measurement in device.MeasurementList)
                        {
                            TimeTaggedMeasurement timeTaggedMeasurement;
                            if (timeTaggedMeasurements.TryGetValue(measurement.PointID, out timeTaggedMeasurement))
                            {
                                measurement.CurrentValue = timeTaggedMeasurement.CurrentValue;
                                measurement.CurrentTimeTag = timeTaggedMeasurement.TimeTag;
                                measurement.CurrentQuality = timeTaggedMeasurement.Quality;
                            }
                        }
                    }
                }
                ListBoxDeviceList.ItemsSource = m_deviceMeasurementDataList;
                ListBoxDeviceList.Items.Refresh();
                //TreeViewDeviceMeasurements.Items.Refresh();
                //TreeViewDeviceMeasurements.ItemsSource = m_deviceMeasurementDataList;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
