//******************************************************************************************************
//  InputMonitoringUserControl.xaml.cs - Gbtc
//
//  Copyright © 2010, Grid Protection Alliance.  All Rights Reserved.
//
//  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
//  the NOTICE file distributed with this work for additional information regarding copyright ownership.
//  The GPA licenses this file to you under the Eclipse Public License -v 1.0 (the "License"); you may
//  not use this file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://www.opensource.org/licenses/eclipse-1.0.php
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  08/06/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using Microsoft.Win32;
using openPDCManager.Data;
using openPDCManager.Data.BusinessObjects;
using openPDCManager.Data.Entities;
using openPDCManager.ModalDialogs;
using openPDCManager.Pages.Adapters;
using openPDCManager.UserControls.CommonControls;
using openPDCManager.Utilities;
using TVA.Configuration;

namespace openPDCManager.Pages.Monitoring
{
    /// <summary>
    /// Interaction logic for InputMonitoringUserControl.xaml
    /// </summary>
    public partial class InputMonitoringUserControl : UserControl
    {
        #region [ Members ]

        ActivityWindow m_activityWindow;
        ObservableCollection<DeviceMeasurementData> m_deviceMeasurementDataList;
        DeviceMeasurementDataForBinding m_dataForBinding;
        DispatcherTimer m_thirtySecondsTimer;
        KeyValuePair<int, int> m_minMaxPointIDs;
        Dictionary<int, int> m_deviceIDsWithStatusPointIDs;
        string m_urlForTree, m_timeSeriesDataServiceUrl, m_urlForStatistics, m_realTimeStatisticsServiceUrl;
        bool m_retrievingData, m_refreshingChart;

        //Chart related fields        
        EnumerableDataSource<int> m_xAxisSource;
        DispatcherTimer m_chartRefreshTimer;
        Dictionary<int, EnumerableDataSource<Double>> m_yAxisSourceCollection; //this will contain PointID and corresponding data plotted on Y-axis
        Dictionary<int, List<double>> m_yAxisDataCollection;    //this will contain PointID and corresponding List<double> from the openPDC
        Dictionary<int, LineGraph> m_lineGraphCollection;                
        Dictionary<int, MeasurementInfo> m_pointsToPlot; //this will contain a list of PointIDs and MeasurementInfo
        Dictionary<int, InputMonitorData> m_currentValuesList; //this will contain PointIDs selected and corresponding current data.

        #endregion

        #region [ Constructor ]
                
        public InputMonitoringUserControl()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(InputMonitoringUserControl_Loaded);
            this.Unloaded += new RoutedEventHandler(InputMonitoringUserControl_Unloaded);
            m_dataForBinding = new DeviceMeasurementDataForBinding();
            m_deviceMeasurementDataList = new ObservableCollection<DeviceMeasurementData>();
            m_minMaxPointIDs = new KeyValuePair<int, int>();
            m_deviceIDsWithStatusPointIDs = new Dictionary<int, int>();
            UserControlDeviceDetailInfo.Visibility = Visibility.Hidden;

            //Chart related fields initializer.
            m_yAxisSourceCollection = new Dictionary<int, EnumerableDataSource<double>>();
            m_yAxisDataCollection = new Dictionary<int, List<double>>();
            m_lineGraphCollection = new Dictionary<int, LineGraph>();
            m_pointsToPlot = new Dictionary<int, MeasurementInfo>();
            m_currentValuesList = new Dictionary<int, InputMonitorData>();
        }

        #endregion

        #region [ Page Events Handlers ]

        void InputMonitoringUserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                List<string> pointList = new List<string>();
                foreach (KeyValuePair<int, MeasurementInfo> pointToPlot in m_pointsToPlot)
                {
                    pointList.Add(pointToPlot.Value.SignalReference);
                }
                IsolatedStorageManager.SaveInputMonitoringPoints(pointList);
            }
            catch { }

            try
            {
                if (m_thirtySecondsTimer != null)
                    m_thirtySecondsTimer.Stop();
                m_thirtySecondsTimer = null;
            }
            catch { }

            try
            {
                if (m_chartRefreshTimer != null)
                    m_chartRefreshTimer.Stop();
                m_chartRefreshTimer = null;
            }
            catch { }
        }

        void InputMonitoringUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            m_activityWindow = new ActivityWindow("Loading Data... Please Wait...");
            m_activityWindow.Owner = Window.GetWindow(this);
            m_activityWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            m_activityWindow.Show();            
            GetMinMaxPointIDs();            
            
            App app = (App)Application.Current;

            m_realTimeStatisticsServiceUrl = app.RealTimeStatisticServiceUrl;
            if (string.IsNullOrEmpty(m_realTimeStatisticsServiceUrl))
                m_urlForStatistics = string.Empty;
            else
                m_urlForStatistics = m_realTimeStatisticsServiceUrl + "/timeseriesdata/read/current/" + m_minMaxPointIDs.Key.ToString() + "-" + m_minMaxPointIDs.Value.ToString() + "/XML";

            m_timeSeriesDataServiceUrl = app.TimeSeriesDataServiceUrl;
            if (string.IsNullOrEmpty(m_timeSeriesDataServiceUrl))
                m_urlForTree = string.Empty;
            else
                m_urlForTree = m_timeSeriesDataServiceUrl + "/timeseriesdata/read/current/" + m_minMaxPointIDs.Key.ToString() + "-" + m_minMaxPointIDs.Value.ToString() + "/XML";
                                   
            //Chart related settings.
            //Remove legend on the right.
            Panel legendParent = (Panel)ChartPlotterDynamic.Legend.ContentGrid.Parent;
            legendParent.Children.Remove(ChartPlotterDynamic.Legend.ContentGrid);
            List<int> m_xAxisValuesList = new List<int>();            

            //Create 300 values array for x-axis.
            for (int i = 0; i < 300; i++)
            {
                m_xAxisValuesList.Add(i);
            }
            m_xAxisSource = new EnumerableDataSource<int>(m_xAxisValuesList);
            m_xAxisSource.SetXMapping(x => x);

            GetDeviceMeasurementData();
            m_deviceIDsWithStatusPointIDs = CommonFunctions.GetDeviceIDsWithStatusPointIDs(app.NodeValue);
            GetTimeTaggedMeasurementsForStatus(m_urlForStatistics);
            GetTimeTaggedMeasurements(m_urlForTree);
        }

        #endregion

        #region [ Controls Event Handlers ]

        void thirtySecondsTimer_Tick(object sender, EventArgs e)
        {
            GetTimeTaggedMeasurementsForStatus(m_urlForStatistics);
            GetTimeTaggedMeasurements(m_urlForTree);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = ((CheckBox)sender);
            string signalReference = checkBox.Content.ToString();
            int pointID;
            
            if (int.TryParse(checkBox.Tag.ToString(), out pointID))
            {
                RemoveLineGraph(checkBox.DataContext);
            }         
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = ((CheckBox)sender);
            MeasurementInfo measurementInfo = (MeasurementInfo)checkBox.DataContext;
            string signalReference = checkBox.Content.ToString();
            int pointID;

            if (int.TryParse(checkBox.Tag.ToString(), out pointID))
            {
                if (!m_pointsToPlot.ContainsKey(pointID))
                {
                    lock (m_pointsToPlot)
                    {
                        if (!m_pointsToPlot.ContainsKey(pointID))
                            m_pointsToPlot.Add(pointID, measurementInfo);
                    }
                }                    

                ThreadPool.QueueUserWorkItem(GetChartData, measurementInfo);
            }

            StartChartRefreshTimer();
        }

        void StartChartRefreshTimer()
        {
            if (m_pointsToPlot.Count > 0 && m_chartRefreshTimer == null)
            {
                m_chartRefreshTimer = new DispatcherTimer();
                m_chartRefreshTimer.Interval = TimeSpan.FromMilliseconds(1000);
                m_chartRefreshTimer.Tick += new EventHandler(m_chartRefreshTimer_Tick);
                m_chartRefreshTimer.Start();
            }
        }

        void m_chartRefreshTimer_Tick(object sender, EventArgs e)
        {
            //ThreadPool.QueueUserWorkItem(RefreshChart, null);
            RefreshChart(null);
        }

        void RefreshChart(object state)
        {
            if (!m_refreshingChart)
            {
                try
                {
                    m_refreshingChart = true;
                    Dictionary<int, MeasurementInfo> temp;
                    lock (m_pointsToPlot)
                    {
                        temp = new Dictionary<int, MeasurementInfo>(m_pointsToPlot);
                    }
                    foreach (KeyValuePair<int, MeasurementInfo> item in temp)
                    {
                        try
                        {
                            GetChartData(item.Value);
                        }
                        catch (Exception ex)
                        {
                            CommonFunctions.LogException("WPF.GetChartData", ex);
                        }
                    }
                }
                catch (Exception ex)
                {
                    CommonFunctions.LogException("WPF.m_chartRefreshTimer_Tick", ex);
                }
                finally
                {
                    m_refreshingChart = false;
                }
            }
        }
        
        private void ButtonGetStatistics_Click(object sender, RoutedEventArgs e)
        {
            string deviceAcronym = ((Button)sender).Content.ToString();
            Device deviceInfo = CommonFunctions.GetDeviceByAcronym(deviceAcronym);
            UserControlDeviceDetailInfo.Initialize(deviceInfo);
            UserControlDeviceDetailInfo.Visibility = Visibility.Visible;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Tag != null)
            {
                int deviceId = Convert.ToInt32(((Button)sender).Tag);
                if (deviceId > 0)
                {
                    ManageDevicesUserControl manageDevicesUserControl = new ManageDevicesUserControl();
                    manageDevicesUserControl.m_deviceID = deviceId;
                    ((MasterLayoutWindow)Window.GetWindow(this)).ContentFrame.Navigate(manageDevicesUserControl);
                }
                else
                {
                    SystemMessages sm = new SystemMessages(new openPDCManager.Utilities.Message() { UserMessage = "Invalid or Dummy Device Selected", SystemMessage = string.Empty, UserMessageType = openPDCManager.Utilities.MessageType.Information },
                        ButtonType.OkOnly);
                    sm.Owner = Window.GetWindow(this);
                    sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    sm.ShowPopup();
                }
            }
            else
            {
                SystemMessages sm = new SystemMessages(new openPDCManager.Utilities.Message() { UserMessage = "Invalid or Dummy Device Selected", SystemMessage = string.Empty, UserMessageType = openPDCManager.Utilities.MessageType.Information },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }
        
        #endregion

        #region [ Methods ]

        void GetMinMaxPointIDs()
        {
            m_minMaxPointIDs = CommonFunctions.GetMinMaxPointIDs(((App)Application.Current).NodeValue);
        }

        void GetTimeTaggedMeasurementsForStatus(string url)
        {
            if (!string.IsNullOrEmpty(url) && !m_retrievingData)
            {
                try
                {
                    m_retrievingData = true;
                    Dictionary<int, TimeTaggedMeasurement> timeTaggedMeasurements = new Dictionary<int, TimeTaggedMeasurement>();
                    timeTaggedMeasurements = CommonFunctions.GetTimeTaggedMeasurements(url);
                    foreach (DeviceMeasurementData deviceMeasurement in m_deviceMeasurementDataList)
                    {
                        int statusPointID;
                        if (m_deviceIDsWithStatusPointIDs.TryGetValue(deviceMeasurement.ID, out statusPointID))
                        {
                            if (timeTaggedMeasurements.ContainsKey(statusPointID))
                            {
                                if (Convert.ToBoolean(Convert.ToInt32(timeTaggedMeasurements[statusPointID].CurrentValue)))
                                    deviceMeasurement.StatusColor = "Green";
                                else
                                    deviceMeasurement.StatusColor = "Red";
                            }
                        }

                        foreach (DeviceInfo device in deviceMeasurement.DeviceList)
                        {
                            if (device.ID != null)
                            {
                                if (m_deviceIDsWithStatusPointIDs.TryGetValue((int)device.ID, out statusPointID))
                                {
                                    if (timeTaggedMeasurements.ContainsKey(statusPointID))
                                    {
                                        if (Convert.ToBoolean(Convert.ToInt32(timeTaggedMeasurements[statusPointID].CurrentValue)))
                                            device.StatusColor = "Green";
                                        else
                                            device.StatusColor = "Red";
                                    }
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    CommonFunctions.LogException("WPF.GetTimeTaggedMeasurements", ex);
                }
                finally
                {
                    m_retrievingData = false;
                }
            }
        }

        void GetTimeTaggedMeasurements(string url)
        {
            if (!string.IsNullOrEmpty(url) && !m_retrievingData)
            {
                try
                {
                    m_retrievingData = true;
                    Dictionary<int, TimeTaggedMeasurement> timeTaggedMeasurements = new Dictionary<int, TimeTaggedMeasurement>();
                    timeTaggedMeasurements = CommonFunctions.GetTimeTaggedMeasurements(url);
                    TextBlockLastRefresh.Text = "Last Refresh: " + DateTime.Now.ToString();
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
                                    if (measurement.SignalAcronym == "FLAG")
                                    {
                                        if (deviceMeasurement.StatusColor == "Red")
                                            device.StatusColor = "Red";
                                        else if (timeTaggedMeasurement.Quality.ToUpper() == "GOOD")
                                            device.StatusColor = "Green";
                                        else
                                            device.StatusColor = "Yellow";
                                    }
                                }
                            }
                        }
                    }

                    TreeViewDeviceMeasurements.Items.Refresh();
                    m_dataForBinding.IsExpanded = true;
                    m_dataForBinding.DeviceMeasurementDataList = m_deviceMeasurementDataList;
                    TreeViewDeviceMeasurements.DataContext = m_dataForBinding;
                }
                catch (Exception ex)
                {
                    CommonFunctions.LogException("WPF.GetTimeTaggedMeasurements", ex);
                }
                finally
                {
                    m_retrievingData = false;
                }
            }
        }

        void GetDeviceMeasurementData()
        {
            try
            {
                m_deviceMeasurementDataList = CommonFunctions.GetDeviceMeasurementData(((App)Application.Current).NodeValue);

                List<string> pointList = IsolatedStorageManager.ReadInputMonitoringPoints();

                if (pointList.Count > 0)
                { 
                    foreach (DeviceMeasurementData deviceMeasurementData in m_deviceMeasurementDataList)
                    {
                        foreach (DeviceInfo deviceInfo in deviceMeasurementData.DeviceList)
                        {
                            foreach (MeasurementInfo measurementInfo in deviceInfo.MeasurementList)
                            {
                                if (pointList.Contains(measurementInfo.SignalReference))
                                {
                                    measurementInfo.IsSelected = true;
                                    deviceInfo.IsExpanded = true;
                                    deviceMeasurementData.IsExpanded = true;

                                    // Add measurement info to m_pointsToPlot collection.
                                    if (!m_pointsToPlot.ContainsKey(measurementInfo.PointID))
                                    {
                                        lock (m_pointsToPlot)
                                        {
                                            if (!m_pointsToPlot.ContainsKey(measurementInfo.PointID))
                                                m_pointsToPlot.Add(measurementInfo.PointID, measurementInfo);
                                        }
                                        //start chart
                                        //ThreadPool.QueueUserWorkItem(GetChartData, measurementInfo);
                                        StartChartRefreshTimer();
                                    }                                     
                                }
                            }
                        }
                    }
                }

                m_dataForBinding.DeviceMeasurementDataList = m_deviceMeasurementDataList;
                m_dataForBinding.IsExpanded = false;
                TreeViewDeviceMeasurements.DataContext = m_dataForBinding;
                if (m_thirtySecondsTimer == null)
                    StartTimer();
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.GetDeviceMeasurementsData", ex);
                SystemMessages sm = new SystemMessages(new openPDCManager.Utilities.Message() { UserMessage = "Failed to Retrieve Current Device Measurements Tree Data", SystemMessage = ex.Message, UserMessageType = openPDCManager.Utilities.MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
            if (m_activityWindow != null)
                m_activityWindow.Close();
        }

        void StartTimer()
        {
            ConfigurationFile config = ConfigurationFile.Current;
            CategorizedSettingsElementCollection configSettings = config.Settings["systemSettings"];

            string timerInterval = configSettings["RealTimeMeasurementRefreshInterval"].Value;
            int interval = 10;

            if (!string.IsNullOrEmpty(timerInterval))
            {
                if (!int.TryParse(timerInterval, out interval))
                    interval = 10;
            }

            m_thirtySecondsTimer = new DispatcherTimer();
            m_thirtySecondsTimer.Interval = TimeSpan.FromSeconds(interval);
            TextBlockRefreshInterval.Text = "Refresh Interval: " + interval.ToString() + " sec";
            m_thirtySecondsTimer.Tick += new EventHandler(thirtySecondsTimer_Tick);
            m_thirtySecondsTimer.Start();
        }

        void GetChartData(object state)
        {
            try
            {
                MeasurementInfo measurementInfo = (MeasurementInfo)state;

                int pointID = measurementInfo.PointID;
                string signalReference = measurementInfo.SignalReference;

                List<TimeSeriesDataPointDetail> measurements;
                EnumerableDataSource<double> yDataSource;
                if (!m_yAxisSourceCollection.TryGetValue(pointID, out yDataSource))
                {
                    measurements = CommonFunctions.GetTimeSeriesDataDetail(m_timeSeriesDataServiceUrl + "/timeseriesdata/read/historic/" + pointID.ToString() + "/*-10S/*/XML");
                    
                    List<double> values = new List<double>();
                    InputMonitorData inputMonitorData = new InputMonitorData();
                    double lastValue = 0;
                    
                    foreach (TimeSeriesDataPointDetail point in measurements)
                    {
                        System.Diagnostics.Debug.WriteLine("10 seconds measurements count = " + measurements.Count.ToString());

                        if (point.Value != double.NaN)
                            lastValue = point.Value;

                        values.Add(lastValue);

                        if (values.Count == measurements.Count)
                        {
                            inputMonitorData.PointID = pointID;
                            inputMonitorData.SignalReference = signalReference;
                            inputMonitorData.EngineeringUnit = measurementInfo.EngineeringUnits;
                            inputMonitorData.Description = measurementInfo.Description;
                            inputMonitorData.TimeStamp = point.TimeStamp;
                            inputMonitorData.Value = point.Value;
                            inputMonitorData.Quality = point.Quality;
                            break;
                        }
                    }
                    if (values.Count > 0)
                    {
                        System.Diagnostics.Debug.WriteLine("values count is = " + values.Count.ToString());

                        if (values.Count < 300)
                        {
                            while (values.Count < 300)
                                values.Add(lastValue);
                        }

                        if (m_yAxisDataCollection.ContainsKey(pointID))
                            m_yAxisDataCollection[pointID] = values;
                        else
                            m_yAxisDataCollection.Add(pointID, values);
                        
                        if (m_yAxisSourceCollection.ContainsKey(pointID))
                            m_yAxisSourceCollection[pointID] = new EnumerableDataSource<double>(m_yAxisDataCollection.Last().Value);
                        else
                            m_yAxisSourceCollection.Add(pointID, new EnumerableDataSource<double>(m_yAxisDataCollection.Last().Value));
                        
                        
                        m_yAxisSourceCollection[pointID].SetYMapping(y => y);

                        ChartPlotterDynamic.Dispatcher.BeginInvoke((Action)delegate()
                        {
                            LineGraph line = null;
                            if (measurementInfo.SignalAcronym == "FREQ")
                                line = FrequencyPlotter.AddLineGraph(new CompositeDataSource(m_xAxisSource, m_yAxisSourceCollection[pointID]), 2, signalReference);
                            else if (measurementInfo.SignalAcronym == "IPHA" || measurementInfo.SignalAcronym == "VPHA")
                                line = PhaseAnglePlotter.AddLineGraph(new CompositeDataSource(m_xAxisSource, m_yAxisSourceCollection[pointID]), 2, signalReference);
                            else if (measurementInfo.SignalAcronym == "VPHM")
                                line = VoltageMagnitudePlotter.AddLineGraph(new CompositeDataSource(m_xAxisSource, m_yAxisSourceCollection[pointID]), 2, signalReference);
                            else if (measurementInfo.SignalAcronym == "IPHM")
                                line = CurrentMagnitudePlotter.AddLineGraph(new CompositeDataSource(m_xAxisSource, m_yAxisSourceCollection[pointID]), 2, signalReference);

                            if (line != null)
                            {
                                if (!m_lineGraphCollection.ContainsKey(pointID))
                                    m_lineGraphCollection.Add(pointID, line);
                                inputMonitorData.Background = (SolidColorBrush)line.LinePen.Brush;
                            }
                        });

                        if (m_currentValuesList.ContainsKey(pointID))
                            m_currentValuesList[pointID] = inputMonitorData;
                        else
                            m_currentValuesList.Add(pointID, inputMonitorData);

                        ListBoxCurrentValues.Dispatcher.BeginInvoke((Action)delegate()
                        {
                            ListBoxCurrentValues.ItemsSource = m_currentValuesList;
                        });
                    }
                }
                else
                {
                    measurements = CommonFunctions.GetTimeSeriesDataDetail(m_timeSeriesDataServiceUrl + "/timeseriesdata/read/historic/" + pointID.ToString() + "/*-1S/*/XML");

                    System.Diagnostics.Debug.WriteLine("1 seconds measurements are = " + measurements.Count.ToString());

                    List<double> yData = m_yAxisDataCollection[pointID];
                    InputMonitorData inputMonitorData = m_currentValuesList[pointID];
                    foreach (TimeSeriesDataPointDetail point in measurements)
                    {
                        if (point.Value != double.NaN)
                        {
                            if (yData.Count >= 300)
                                yData.RemoveAt(0);
                            yData.Insert(yData.Count - 1, point.Value);
                            inputMonitorData.Value = point.Value;
                            inputMonitorData.TimeStamp = point.TimeStamp;
                            inputMonitorData.Quality = point.Quality;
                        }
                    }

                    ChartPlotterDynamic.Dispatcher.BeginInvoke((Action)delegate()
                    {
                        try
                        {
                            lock (m_yAxisSourceCollection)
                                m_yAxisSourceCollection[pointID].RaiseDataChanged();
                        }
                        catch { }
                    });

                    ListBoxCurrentValues.Dispatcher.BeginInvoke((Action)delegate()
                    {
                        ListBoxCurrentValues.Items.Refresh();
                        ListBoxCurrentValues.ItemsSource = m_currentValuesList;
                    });
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.GetChartData", ex);
            }
        }

        void RemoveLineGraph(object state)
        {
            MeasurementInfo measurementInfo = (MeasurementInfo)state;
            int pointID = measurementInfo.PointID;

            if (m_pointsToPlot.ContainsKey(pointID))
            {
                lock(m_pointsToPlot)
                    m_pointsToPlot.Remove(pointID);
            }

            if (m_yAxisSourceCollection.ContainsKey(pointID))
            {
                lock(m_yAxisSourceCollection)
                    m_yAxisSourceCollection.Remove(pointID);
            }

            if (m_yAxisDataCollection.ContainsKey(pointID))
            {
                lock (m_yAxisDataCollection)
                    m_yAxisDataCollection.Remove(pointID);
            }

            if (m_currentValuesList.ContainsKey(pointID))
            {
                lock (m_currentValuesList)
                    m_currentValuesList.Remove(pointID);

                ListBoxCurrentValues.Items.Refresh();
                ListBoxCurrentValues.ItemsSource = m_currentValuesList;
            }

            if (m_lineGraphCollection.ContainsKey(pointID))
            {
                LineGraph lineGraphToBeRemoved = m_lineGraphCollection[pointID];
                try
                {
                    if (measurementInfo.SignalAcronym == "FREQ")
                        FrequencyPlotter.Children.Remove((IPlotterElement)lineGraphToBeRemoved);
                    else if (measurementInfo.SignalAcronym == "IPHA" || measurementInfo.SignalAcronym == "VPHA")
                        PhaseAnglePlotter.Children.Remove((IPlotterElement)lineGraphToBeRemoved);
                    else if (measurementInfo.SignalAcronym == "VPHM")
                        VoltageMagnitudePlotter.Children.Remove((IPlotterElement)lineGraphToBeRemoved);
                    else if (measurementInfo.SignalAcronym == "IPHM")
                        CurrentMagnitudePlotter.Children.Remove((IPlotterElement)lineGraphToBeRemoved);                    
                }
                catch 
                { 
                
                }

                lock(m_lineGraphCollection)
                    m_lineGraphCollection.Remove(pointID);
            }

            if (m_pointsToPlot.Count == 0 && m_chartRefreshTimer != null)
            {
                m_chartRefreshTimer.Stop();
                m_chartRefreshTimer.Tick -= new EventHandler(m_chartRefreshTimer_Tick);
                m_chartRefreshTimer = null;
            }  
        }

        #endregion

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Save Current Display Settings";
            saveDialog.Filter = "Input Monitoring Display Settings (*.imsettings)|*.imsettings|All Files (*.*)|*.*";
            bool? result = saveDialog.ShowDialog(Window.GetWindow(this));
            if (result != null && (bool)result == true)
            {                
                using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (KeyValuePair<int, MeasurementInfo> pointToPlot in m_pointsToPlot)
                    {
                        sb.Append(pointToPlot.Value.SignalReference + ";");
                    }
                    writer.Write(sb.ToString());
                }
            }
        }

        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Multiselect = false;
            openDialog.Filter = "Input Monitoring Display Settings (*.imsettings)|*.imsettings|All Files (*.*)|*.*";
            bool? result = openDialog.ShowDialog(Window.GetWindow(this));
            if (result != null && (bool)result == true)
            {
                using (StreamReader reader = new StreamReader(openDialog.OpenFile()))
                {
                    string selection = reader.ReadLine();
                    string[] signalReferences = selection.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (DeviceMeasurementData deviceMeasurementData in m_dataForBinding.DeviceMeasurementDataList)
                    {
                        deviceMeasurementData.IsExpanded = false;
                        foreach (DeviceInfo deviceInfo in deviceMeasurementData.DeviceList)
                        {
                            deviceInfo.IsExpanded = false;
                            foreach (MeasurementInfo measurementInfo in deviceInfo.MeasurementList)
                            {
                                if (signalReferences.Contains(measurementInfo.SignalReference))
                                {
                                    measurementInfo.IsSelected = true;
                                    deviceInfo.IsExpanded = true;
                                    deviceMeasurementData.IsExpanded = true;

                                    // Add measurement info to m_pointsToPlot collection.
                                    if (!m_pointsToPlot.ContainsKey(measurementInfo.PointID))
                                    {
                                        lock (m_pointsToPlot)
                                        {
                                            if (!m_pointsToPlot.ContainsKey(measurementInfo.PointID))
                                                m_pointsToPlot.Add(measurementInfo.PointID, measurementInfo);
                                        }
                                        StartChartRefreshTimer();
                                    }
                                }
                                else
                                {
                                    measurementInfo.IsSelected = false;
                                    if (m_pointsToPlot.ContainsKey(measurementInfo.PointID))
                                        RemoveLineGraph(measurementInfo);
                                }                                    
                            }
                        }
                    }
                    m_dataForBinding.IsExpanded = false;
                    TreeViewDeviceMeasurements.Items.Refresh();
                    TreeViewDeviceMeasurements.DataContext = m_dataForBinding;
                }
            }
        }                
    }
}
