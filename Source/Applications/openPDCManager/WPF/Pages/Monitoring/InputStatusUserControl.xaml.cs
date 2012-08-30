//******************************************************************************************************
//  InputStatusUserControl.xaml.cs - Gbtc
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
//  11/02/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//  04/25/2011 - Mehulbhai P Thakkar
//       Changes to the format of date time display on the screen suggested by Ryan Zuo from Alstom.
//  05/09/2011 - Mehulbhai P Thakkar
//       Modified timestamp displayed on the chart's lower corner to 24-Hour format as suggested by Ryan Zuo from Alstom.
//
//******************************************************************************************************

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.Charts;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using Microsoft.Win32;
using openPDCManager.Data;
using openPDCManager.Data.BusinessObjects;
using openPDCManager.Data.Entities;
using openPDCManager.ModalDialogs;
using openPDCManager.Pages.Adapters;
using openPDCManager.UserControls.CommonControls;
using openPDCManager.Utilities;
using TimeSeriesFramework;
using TimeSeriesFramework.Transport;
using TVA;

namespace openPDCManager.Pages.Monitoring
{
    /// <summary>
    /// Interaction logic for InputStatusUserControl.xaml
    /// </summary>
    public partial class InputStatusUserControl : UserControl
    {
        #region [ Members ]

        #region [ Members for Dynamic Data Display ]

        int[] m_xAxisDataCollection;                                                            //contains source data for the binding collection.
        EnumerableDataSource<int> m_xAxisBindingCollection;                                     //contains values plotted on X-Axis.
        ConcurrentDictionary<string, ConcurrentQueue<double>> m_yAxisDataCollection;            //contains source data for the binding collection. Format is <signalID, collection of values from subscription API>.
        ConcurrentDictionary<string, EnumerableDataSource<double>> m_yAxisBindingCollection;    //contains values plotted on Y-Axis.
        ConcurrentDictionary<string, LineGraph> m_lineGraphCollection;                          //contains list of graphs plotted on the chart.
        DispatcherTimer m_chartRefreshTimer;                                                    //timer to refresh chart on an interval.        
        int m_numberOfDataPointsToPlot = 150;                                                   //number of data points to plot on the chart.
        int m_framesPerSecond = 30;                                                             //sample rate of the data from subscription API.
        int m_refreshInterval = 250;                                                            //miliseconds interval to refresh chart.
        List<Color> m_lineColors;                                                               //stores list of colors to draw line chart.
        int m_processingNewMeasurementsForChart = 0;
        bool m_displayFrequencyAxis, m_displayPhaseAngleAxis, m_displayVoltageAxis, m_displayCurrentAxis, m_displayXAxis;
        ConcurrentQueue<string> m_timeStampList;
        DataSubscriber m_chartSubscriber;
        ConcurrentDictionary<string, MeasurementInfo> m_selectedMeasurements;                   //this will contain a list of SignalIDs and MeasurementInfo.
        bool m_subscribedForChart;                                                              //indicates if connection to subscription API is set or not.
        bool m_useLocalClockAsRealtime;
        bool m_ignoreBadTimestamps;
        double m_leadTime = 1.0;
        double m_lagTime = 3.0;

        #endregion

        ActivityWindow m_activityWindow;
        ObservableCollection<DeviceMeasurementData> m_deviceMeasurementDataList;
        DeviceMeasurementDataForBinding m_dataForBinding;
        Dictionary<string, InputMonitorData> m_currentValuesList;
        int m_measurementsDataRefreshInterval = 30;
        DataSubscriber m_measurementDataSubscriber;                                             //this subscription will be used to refresh tree values.
        string m_measurementDataPointsForSubscription;                                          //this measurements IDs will be used for subscribing data for tree.
        bool m_subscribedForTree;
        int m_processingNewMeasurementsForTree = 0;
        bool m_restartConnectionCycle = true;
        bool m_displayLegend = true;
        string m_urlForStatistics;
        KeyValuePair<int, int> m_minMaxPointIDs;
        Dictionary<int, int> m_deviceIDsWithStatusPointIDs;
        bool m_retrievingData;

        #endregion

        #region [ Constructor ]

        public InputStatusUserControl()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(InputStatusUserControl_Loaded);
            this.Unloaded += new RoutedEventHandler(InputStatusUserControl_Unloaded);
            m_yAxisDataCollection = new ConcurrentDictionary<string, ConcurrentQueue<double>>();
            m_yAxisBindingCollection = new ConcurrentDictionary<string, EnumerableDataSource<double>>();
            m_dataForBinding = new DeviceMeasurementDataForBinding();
            m_deviceMeasurementDataList = new ObservableCollection<DeviceMeasurementData>();
            m_selectedMeasurements = new ConcurrentDictionary<string, MeasurementInfo>();
            m_lineGraphCollection = new ConcurrentDictionary<string, LineGraph>();
            m_currentValuesList = new Dictionary<string, InputMonitorData>();
            m_timeStampList = new ConcurrentQueue<string>();
            m_minMaxPointIDs = new KeyValuePair<int, int>();
            m_deviceIDsWithStatusPointIDs = new Dictionary<int, int>();
        }

        #endregion

        #region [ Page Event Handlers ]

        void InputStatusUserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            m_restartConnectionCycle = false;
            UnsubscribeDataForChart();
            UnsubscribeDataForTree();

            //Save selected points to Isolated Storage before exiting this page.
            List<string> pointList = new List<string>();
            foreach (KeyValuePair<string, MeasurementInfo> selectedMeasurement in m_selectedMeasurements)
                pointList.Add(selectedMeasurement.Value.SignalReference);

            IsolatedStorageManager.SaveInputMonitoringPoints(pointList);
        }

        void InputStatusUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            m_activityWindow = new ActivityWindow("Loading Data... Please Wait...");
            m_activityWindow.Owner = Window.GetWindow(this);
            m_activityWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            m_activityWindow.Show();

            GetMinMaxPointIDs();
            string statisticServiceUrl = ((App)Application.Current).RealTimeStatisticServiceUrl;
            if (!string.IsNullOrEmpty(statisticServiceUrl))
                m_urlForStatistics = statisticServiceUrl + "/timeseriesdata/read/current/" + m_minMaxPointIDs.Key.ToString() + "-" + m_minMaxPointIDs.Value.ToString() + "/XML";

            InitializeColors();
            GetDeviceMeasurementData();
            m_deviceIDsWithStatusPointIDs = CommonFunctions.GetDeviceIDsWithStatusPointIDs(null, ((App)Application.Current).NodeValue);
            GetTimeTaggedMeasurementsForStatus(m_urlForStatistics);
            InitializeChart();
        }

        #endregion

        #region [ Subscription API Code for Chart ]

        void chartSubscriber_NewMeasurements(object sender, EventArgs<ICollection<IMeasurement>> e)
        {
            if (0 == Interlocked.Exchange(ref m_processingNewMeasurementsForChart, 1))
            {
                try
                {
                    bool timestampProcessed = false;
                    foreach (IMeasurement measurement in e.Argument)
                    {
                        if (!timestampProcessed)
                        {
                            timestampProcessed = true;
                            m_timeStampList.Enqueue(measurement.Timestamp.ToString("HH:mm:ss.fff"));
                            if (m_timeStampList.Count > m_numberOfDataPointsToPlot)
                            {
                                string oldValue;
                                m_timeStampList.TryDequeue(out oldValue);
                            }
                        }
                        double tempValue = measurement.Value;
                        string tempSignalID = measurement.ID.ToString().ToUpper();
                        if (!double.IsNaN(tempValue) && !double.IsInfinity(tempValue))      //process data only if it is not NaN or Infinity.
                        {
                            ConcurrentQueue<double> tempCollection;
                            if (m_yAxisDataCollection.TryGetValue(tempSignalID, out tempCollection))
                            {
                                double oldValue;
                                if (tempCollection.TryDequeue(out oldValue))
                                    tempCollection.Enqueue(tempValue);

                                //Update Current Values List
                                InputMonitorData inputMonitorData;
                                lock (m_currentValuesList)
                                {
                                    if (m_currentValuesList.TryGetValue(tempSignalID, out inputMonitorData))
                                    {
                                        inputMonitorData.Value = tempValue.ToString("0.###");
                                        inputMonitorData.TimeStamp = measurement.Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                        inputMonitorData.Quality = measurement.ValueQualityIsGood() ? "GOOD" : "UNKNOWN";
                                    }
                                }
                            }
                            else
                            {
                                MeasurementInfo measurementInfo;
                                if (m_selectedMeasurements.TryGetValue(tempSignalID, out measurementInfo)) // We check this because user may have unchecked a checkbox but processing may not have completed so we may still continue to receive data.
                                {
                                    //System.Diagnostics.Debug.WriteLine("SUBSCRIPTION: Adding a new chart.");
                                    tempCollection = new ConcurrentQueue<double>();
                                    for (int i = 0; i < m_numberOfDataPointsToPlot; i++)
                                        tempCollection.Enqueue(tempValue);

                                    m_yAxisDataCollection.TryAdd(tempSignalID, tempCollection);
                                    EnumerableDataSource<double> tempDataSource = new EnumerableDataSource<double>(tempCollection);
                                    m_yAxisBindingCollection.TryAdd(tempSignalID, tempDataSource);
                                    tempDataSource.SetYMapping(y => y);

                                    ChartPlotterDynamic.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate()
                                    {
                                        int colorIndex;
                                        Math.DivRem(m_yAxisBindingCollection.Count, 10, out colorIndex);
                                        LineGraph lineGraph = null;

                                        if (measurementInfo.SignalAcronym == "FREQ")
                                            lineGraph = ChartPlotterDynamic.AddLineGraph(new CompositeDataSource(m_xAxisBindingCollection, tempDataSource), m_lineColors[colorIndex], 1, measurementInfo.SignalReference);
                                        else if (measurementInfo.SignalAcronym == "IPHA" || measurementInfo.SignalAcronym == "VPHA")
                                            lineGraph = PhaseAnglePlotter.AddLineGraph(new CompositeDataSource(m_xAxisBindingCollection, tempDataSource), m_lineColors[colorIndex], 1, measurementInfo.SignalReference);
                                        else if (measurementInfo.SignalAcronym == "VPHM")
                                            lineGraph = VoltagePlotter.AddLineGraph(new CompositeDataSource(m_xAxisBindingCollection, tempDataSource), m_lineColors[colorIndex], 1, measurementInfo.SignalReference);
                                        else if (measurementInfo.SignalAcronym == "IPHM")
                                            lineGraph = CurrentPlotter.AddLineGraph(new CompositeDataSource(m_xAxisBindingCollection, tempDataSource), m_lineColors[colorIndex], 1, measurementInfo.SignalReference);

                                        if (lineGraph != null)
                                            m_lineGraphCollection.TryAdd(tempSignalID, lineGraph);

                                        //Update Current Values List
                                        InputMonitorData inputMonitorData;
                                        lock (m_currentValuesList)
                                        {
                                            if (m_currentValuesList.TryGetValue(tempSignalID, out inputMonitorData))
                                            {
                                                inputMonitorData.Value = tempValue.ToString("0.###");
                                                inputMonitorData.TimeStamp = measurement.Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                                inputMonitorData.Quality = measurement.ValueQualityIsGood() ? "GOOD" : "UNKNOWN";
                                                inputMonitorData.Background = (SolidColorBrush)lineGraph.LinePen.Brush;
                                            }
                                        }

                                        //System.Diagnostics.Debug.WriteLine("SUBSCRIPTION: Added a new chart for: " + measurementInfo.SignalAcronym);
                                    });
                                }
                            }
                        }
                    }
                }
                catch
                { //System.Diagnostics.Debug.WriteLine("Exception Occured"); 
                }
                finally
                {
                    Interlocked.Exchange(ref m_processingNewMeasurementsForChart, 0);
                }
            }
        }

        void chartSubscriber_ConnectionEstablished(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("SUBSCRIPTION: Subscription Connection Established.");
            m_subscribedForChart = true;
            SubscribeDataForChart();
        }

        void chartSubscriber_ConnectionTerminated(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("SUBSCRIPTION: Subscription Connection Terminated.");
            m_subscribedForChart = false;
            UnsubscribeDataForChart();
            if (m_restartConnectionCycle)
                StartSubscriptionForChart();    //Restart connection cycle.
        }

        void chartSubscriber_ProcessException(object sender, TVA.EventArgs<Exception> e)
        {
            System.Diagnostics.Debug.WriteLine("SUBSCRIPTION: EXCEPTION: " + e.Argument.Message);
        }

        void chartSubscriber_StatusMessage(object sender, TVA.EventArgs<string> e)
        {
            System.Diagnostics.Debug.WriteLine("SUBSCRIPTION: " + e.Argument);
        }

        #endregion

        #region [ Subscription API Code for Tree ]

        void measurementDataSubscriber_NewMeasurements(object sender, EventArgs<ICollection<IMeasurement>> e)
        {
            if (0 == Interlocked.Exchange(ref m_processingNewMeasurementsForTree, 1))
            {
                try
                {
                    //System.Diagnostics.Debug.WriteLine("*************************************");
                    foreach (DeviceMeasurementData deviceMeasurementData in m_deviceMeasurementDataList)
                    {
                        //if (deviceMeasurementData.IsExpanded)
                        //{
                        foreach (DeviceInfo deviceInfo in deviceMeasurementData.DeviceList)
                        {
                            //if (deviceInfo.IsExpanded)
                            //{
                            foreach (MeasurementInfo measurementInfo in deviceInfo.MeasurementList)
                            {
                                foreach (IMeasurement measurement in e.Argument)
                                {
                                    if (measurement.ID.ToString().ToUpper() == measurementInfo.SignalID.ToUpper())
                                    {
                                        measurementInfo.CurrentQuality = measurement.ValueQualityIsGood() ? "GOOD" : "BAD";
                                        measurementInfo.CurrentTimeTag = measurement.Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                        measurementInfo.CurrentValue = measurement.Value.ToString("0.###");

                                        if (measurementInfo.SignalAcronym == "FLAG")
                                        {
                                            if (!deviceMeasurementData.Enabled && deviceMeasurementData.StatusColor != "Transparent")
                                            {
                                                deviceMeasurementData.StatusColor = "Gray";
                                                deviceInfo.StatusColor = "Gray";
                                            }
                                            else if (!deviceInfo.Enabled)
                                                deviceInfo.StatusColor = "Gray";
                                            else if (deviceMeasurementData.StatusColor == "Red")
                                                deviceInfo.StatusColor = "Red";
                                            else if (measurement.ValueQualityIsGood())
                                                deviceInfo.StatusColor = "Green";
                                            else
                                                deviceInfo.StatusColor = "Yellow";
                                        }
                                    }
                                }
                            }
                            //}
                        }
                        //}
                    }
                    GetTimeTaggedMeasurementsForStatus(m_urlForStatistics);
                    RefreshDeviceMeasurementData();
                }
                catch
                {
                    //System.Diagnostics.Debug.WriteLine("Exception Occured"); 
                }
                finally
                {
                    Interlocked.Exchange(ref m_processingNewMeasurementsForTree, 0);
                }
            }
        }

        void measurementDataSubscriber_ConnectionEstablished(object sender, EventArgs e)
        {
            m_subscribedForTree = true;
            SubscribeDataForTree();
        }

        void measurementDataSubscriber_ConnectionTerminated(object sender, EventArgs e)
        {
            m_subscribedForTree = false;
            UnsubscribeDataForTree();
            if (m_restartConnectionCycle)
                StartSubscriptionForTreeData();     //Restart connection cycle.            
        }

        void measurementDataSubscriber_ProcessException(object sender, TVA.EventArgs<Exception> e)
        {
            //System.Diagnostics.Debug.WriteLine("SUBSCRIPTION: EXCEPTION: " + e.Argument.Message);
        }

        void measurementDataSubscriber_StatusMessage(object sender, TVA.EventArgs<string> e)
        {
            //System.Diagnostics.Debug.WriteLine("SUBSCRIPTION: " + e.Argument);
        }

        #endregion

        #region [ Methods ]

        void GetMinMaxPointIDs()
        {
            m_minMaxPointIDs = CommonFunctions.GetMinMaxPointIDs(null, ((App)Application.Current).NodeValue);
        }

        void GetSettingsFromIsolatedStorage()
        {
            m_displayFrequencyAxis = Convert.ToBoolean(IsolatedStorageManager.ReadFromIsolatedStorage("DisplayFrequencyYAxis"));
            m_displayPhaseAngleAxis = Convert.ToBoolean(IsolatedStorageManager.ReadFromIsolatedStorage("DisplayPhaseAngleYAxis"));
            m_displayVoltageAxis = Convert.ToBoolean(IsolatedStorageManager.ReadFromIsolatedStorage("DisplayVoltageYAxis"));
            m_displayCurrentAxis = Convert.ToBoolean(IsolatedStorageManager.ReadFromIsolatedStorage("DisplayCurrentYAxis"));
            m_displayXAxis = Convert.ToBoolean(IsolatedStorageManager.ReadFromIsolatedStorage("DisplayXAxis"));
            m_useLocalClockAsRealtime = Convert.ToBoolean(IsolatedStorageManager.ReadFromIsolatedStorage("UseLocalClockAsRealtime"));
            m_ignoreBadTimestamps = Convert.ToBoolean(IsolatedStorageManager.ReadFromIsolatedStorage("IgnoreBadTimestamps"));
            m_displayLegend = Convert.ToBoolean(IsolatedStorageManager.ReadFromIsolatedStorage("DisplayLegend"));
            int.TryParse(IsolatedStorageManager.ReadFromIsolatedStorage("DataResolution").ToString(), out m_framesPerSecond);
            int.TryParse(IsolatedStorageManager.ReadFromIsolatedStorage("NumberOfDataPointsToPlot").ToString(), out m_numberOfDataPointsToPlot);
            int.TryParse(IsolatedStorageManager.ReadFromIsolatedStorage("ChartRefreshInterval").ToString(), out m_refreshInterval);
            int.TryParse(IsolatedStorageManager.ReadFromIsolatedStorage("MeasurementsDataRefreshInterval").ToString(), out m_measurementsDataRefreshInterval);
            double.TryParse(IsolatedStorageManager.ReadFromIsolatedStorage("LagTime").ToString(), out m_lagTime);
            double.TryParse(IsolatedStorageManager.ReadFromIsolatedStorage("LeadTime").ToString(), out m_leadTime);

            TextBlockRefreshInterval.Text = "Refresh Interval: " + m_measurementsDataRefreshInterval + " sec";
            ChartPlotterDynamic.NewLegendVisible = m_displayLegend;

            m_xAxisDataCollection = new int[m_numberOfDataPointsToPlot];

            //Get last selected measurements to plot on the chart during first load of the page.
            List<string> pointList = IsolatedStorageManager.ReadInputMonitoringPoints();
            if (pointList.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                foreach (DeviceMeasurementData deviceMeasurementData in m_deviceMeasurementDataList)
                {
                    foreach (DeviceInfo deviceInfo in deviceMeasurementData.DeviceList)
                    {
                        foreach (MeasurementInfo measurementInfo in deviceInfo.MeasurementList)
                        {
                            //create a string of measurements to subscribe for real time data
                            sb.Append(measurementInfo.HistorianAcronym + ":" + measurementInfo.PointID + ";");

                            if (pointList.Contains(measurementInfo.SignalReference))
                            {
                                measurementInfo.IsSelected = true;
                                deviceInfo.IsExpanded = true;
                                deviceMeasurementData.IsExpanded = true;
                                m_selectedMeasurements.TryAdd(measurementInfo.SignalID.ToUpper(), measurementInfo);
                                AddToCurrentValuesList(measurementInfo);
                            }
                        }
                    }
                }

                m_measurementDataPointsForSubscription = sb.ToString();
                if (m_measurementDataPointsForSubscription.Length > 0)
                    m_measurementDataPointsForSubscription = m_measurementDataPointsForSubscription.Substring(0, m_measurementDataPointsForSubscription.Length - 1);

            }

            RefreshDeviceMeasurementData();
            if (m_selectedMeasurements.Count > 0)
                SubscribeDataForChart();

        }

        #region [ Methods related to chart data refresh ]

        void StartChartRefreshTimer()
        {
            if (m_chartRefreshTimer == null)
            {
                m_chartRefreshTimer = new DispatcherTimer();
                m_chartRefreshTimer.Interval = TimeSpan.FromMilliseconds(m_refreshInterval);
                m_chartRefreshTimer.Tick += m_chartRefreshTimer_Tick;
                m_chartRefreshTimer.Start();
            }
        }

        void m_chartRefreshTimer_Tick(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, EnumerableDataSource<double>> keyValuePair in m_yAxisBindingCollection)
            {
                lock (keyValuePair.Value)
                {
                    try
                    {
                        keyValuePair.Value.RaiseDataChanged();
                    }
                    catch
                    {
                    }
                }
            }

            if (m_timeStampList.Count > 0)
            {
                TextBlockLeft.Text = m_timeStampList.First();
                TextBlockRight.Text = m_timeStampList.Last();
            }

            ListBoxCurrentValues.Items.Refresh();
            lock (m_currentValuesList)
                ListBoxCurrentValues.ItemsSource = m_currentValuesList;
        }

        void StopChartRefreshTimer()
        {
            try
            {
                if (m_chartRefreshTimer != null)
                {
                    m_chartRefreshTimer.Stop();
                    m_chartRefreshTimer.Tick -= m_chartRefreshTimer_Tick;
                }
                m_chartRefreshTimer = null;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "StopChartRefreshTimer", ex);
                m_chartRefreshTimer = null;
            }
        }

        void InitializeColors()
        {
            m_lineColors = new List<Color>();
            m_lineColors.Add(Colors.DarkGoldenrod);
            m_lineColors.Add(Colors.Blue);
            m_lineColors.Add(Colors.Green);
            m_lineColors.Add(Colors.Red);
            m_lineColors.Add(Colors.Purple);
            m_lineColors.Add(Colors.Brown);
            m_lineColors.Add(Colors.Magenta);
            m_lineColors.Add(Colors.Black);
            m_lineColors.Add(Colors.DarkCyan);
            m_lineColors.Add(Colors.Coral);
        }

        void InitializeChart()
        {
            //Remove labels on X-Axis.
            ((HorizontalAxis)ChartPlotterDynamic.MainHorizontalAxis).LabelProvider.LabelStringFormat = "";

            //Remove legend on the right.
            //Panel legendParent = (Panel)ChartPlotterDynamic.Legend.ContentGrid.Parent;
            //legendParent.Children.Remove(ChartPlotterDynamic.Legend.ContentGrid);

            ChartPlotterDynamic.LegendVisibility = Visibility.Collapsed;


            //Set Y-Axis and X-Axis Visibility.
            ChartPlotterDynamic.MainVerticalAxisVisibility = FrequencyAxisTitle.Visibility = m_displayFrequencyAxis ? Visibility.Visible : Visibility.Collapsed;
            ChartPlotterDynamic.MainHorizontalAxisVisibility = m_displayXAxis ? Visibility.Visible : Visibility.Collapsed;
            TextBlockLeft.Visibility = TextBlockRight.Visibility = ChartPlotterDynamic.MainHorizontalAxisVisibility;
            PhaseAngleYAxis.Visibility = PhaseAngleAxisTitle.Visibility = m_displayPhaseAngleAxis ? Visibility.Visible : Visibility.Collapsed;
            VoltageYAxis.Visibility = VoltageAxisTitle.Visibility = m_displayVoltageAxis ? Visibility.Visible : Visibility.Collapsed;
            CurrentYAxis.Visibility = CurrentAxisTitle.Visibility = m_displayCurrentAxis ? Visibility.Visible : Visibility.Collapsed;

            //Set viewport rectangle for Frequency and PhaseAngle axis.
            ChartPlotterDynamic.Visible = DataRect.Create(0, Convert.ToDouble(IsolatedStorageManager.ReadFromIsolatedStorage("FrequencyRangeMin")), m_numberOfDataPointsToPlot, Convert.ToDouble(IsolatedStorageManager.ReadFromIsolatedStorage("FrequencyRangeMax")));
            PhaseAnglePlotter.Visible = DataRect.Create(0, -180, m_numberOfDataPointsToPlot, 180);

            //Assign x-axis binding collection to x-axis.            
            for (int i = 0; i < m_numberOfDataPointsToPlot; i++)
                m_xAxisDataCollection[i] = i;
            m_xAxisBindingCollection = new EnumerableDataSource<int>(m_xAxisDataCollection);
            m_xAxisBindingCollection.SetXMapping(x => x);
        }

        void StartSubscriptionForChart()
        {
            string server = openPDCManager.Utilities.Common.GetDataPublisherServer();
            string port = openPDCManager.Utilities.Common.GetDataPublisherPort();

            m_chartSubscriber = new DataSubscriber();
            m_chartSubscriber.StatusMessage += chartSubscriber_StatusMessage;
            m_chartSubscriber.ProcessException += chartSubscriber_ProcessException;
            m_chartSubscriber.ConnectionEstablished += chartSubscriber_ConnectionEstablished;
            m_chartSubscriber.NewMeasurements += chartSubscriber_NewMeasurements;
            m_chartSubscriber.ConnectionTerminated += chartSubscriber_ConnectionTerminated;
            m_chartSubscriber.ConnectionString = "server=" + server + ":" + port;
            m_chartSubscriber.Initialize();
            m_chartSubscriber.Start();
        }

        void SubscribeDataForChart()
        {
            //System.Diagnostics.Debug.WriteLine("SUBSCRIPTION: Subscribing Data.");

            if (m_selectedMeasurements.Count == 0)
                UnsubscribeDataForChart();
            else
            {
                if (m_chartSubscriber == null)
                    StartSubscriptionForChart();

                if (m_subscribedForChart)
                {
                    //StopChartRefreshTimer();
                    StringBuilder sb = new StringBuilder();
                    foreach (KeyValuePair<string, MeasurementInfo> keyValuePair in m_selectedMeasurements)
                        sb.Append(keyValuePair.Value.HistorianAcronym + ":" + keyValuePair.Value.PointID + ";");

                    string subscriptionPoints = sb.ToString();
                    if (subscriptionPoints.Length > 0)
                        subscriptionPoints = subscriptionPoints.Substring(0, subscriptionPoints.Length - 1);

                    //string password = openPDCManager.Utilities.Common.GetDataPublisherPassword();
                    m_chartSubscriber.SynchronizedSubscribe(true, m_framesPerSecond, m_lagTime, m_leadTime, subscriptionPoints, null, m_useLocalClockAsRealtime, m_ignoreBadTimestamps);
                    ChartPlotterDynamic.Dispatcher.BeginInvoke((Action)delegate()
                    {
                        StartChartRefreshTimer();
                    });
                }
            }
        }

        void UnsubscribeDataForChart()
        {
            try
            {
                if (m_chartSubscriber != null)
                {
                    //System.Diagnostics.Debug.WriteLine("SUBSCRIPTION: Un-Subscribing Data.");
                    m_chartSubscriber.Unsubscribe();
                    StopSubscriptionForChart();
                }
            }
            catch
            {
                m_chartSubscriber = null;
            }

            StopChartRefreshTimer();
        }

        void StopSubscriptionForChart()
        {
            if (m_chartSubscriber != null)
            {
                m_chartSubscriber.StatusMessage -= chartSubscriber_StatusMessage;
                m_chartSubscriber.ProcessException -= chartSubscriber_ProcessException;
                m_chartSubscriber.ConnectionEstablished -= chartSubscriber_ConnectionEstablished;
                m_chartSubscriber.NewMeasurements -= chartSubscriber_NewMeasurements;
                m_chartSubscriber.Stop();
                m_chartSubscriber.Dispose();
                m_chartSubscriber = null;
            }
        }

        void RemoveLineGraph(MeasurementInfo measurementInfo)
        {
            MeasurementInfo measurementToBeRemoved;
            LineGraph lineGraphToBeRemoved;
            EnumerableDataSource<double> bindingCollectionToBeRemoved;
            ConcurrentQueue<double> dataCollectionToBeRemoved;

            m_selectedMeasurements.TryRemove(measurementInfo.SignalID.ToUpper(), out measurementToBeRemoved);
            SubscribeDataForChart();
            m_yAxisBindingCollection.TryRemove(measurementInfo.SignalID.ToUpper(), out bindingCollectionToBeRemoved);
            m_yAxisDataCollection.TryRemove(measurementInfo.SignalID.ToUpper(), out dataCollectionToBeRemoved);

            m_lineGraphCollection.TryRemove(measurementInfo.SignalID.ToUpper(), out lineGraphToBeRemoved);
            if (measurementInfo.SignalAcronym == "FREQ")
                ChartPlotterDynamic.Children.Remove((IPlotterElement)lineGraphToBeRemoved);
            else if (measurementInfo.SignalAcronym == "IPHA" || measurementInfo.SignalAcronym == "VPHA")
                PhaseAnglePlotter.Children.Remove((IPlotterElement)lineGraphToBeRemoved);
            else if (measurementInfo.SignalAcronym == "VPHM")
                VoltagePlotter.Children.Remove((IPlotterElement)lineGraphToBeRemoved);
            else if (measurementInfo.SignalAcronym == "IPHM")
                CurrentPlotter.Children.Remove((IPlotterElement)lineGraphToBeRemoved);
        }

        void AddToCurrentValuesList(object state)
        {
            MeasurementInfo measurementInfo = (MeasurementInfo)state;
            InputMonitorData inputMonitorData = new InputMonitorData();
            inputMonitorData.PointID = measurementInfo.PointID;
            inputMonitorData.SignalID = measurementInfo.SignalID.ToUpper();
            inputMonitorData.SignalReference = measurementInfo.SignalReference;
            inputMonitorData.EngineeringUnit = measurementInfo.EngineeringUnits;
            inputMonitorData.Description = measurementInfo.Description;
            inputMonitorData.TimeStamp = measurementInfo.CurrentTimeTag;
            inputMonitorData.Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            //ListBoxCurrentValues.Dispatcher.Invoke((Action)delegate()
            //{
            lock (m_currentValuesList)
            {
                if (m_currentValuesList.ContainsKey(measurementInfo.SignalID.ToUpper()))
                    m_currentValuesList[measurementInfo.SignalID.ToUpper()] = inputMonitorData;
                else
                    m_currentValuesList.Add(measurementInfo.SignalID.ToUpper(), inputMonitorData);
                ListBoxCurrentValues.Items.Refresh();
                ListBoxCurrentValues.ItemsSource = m_currentValuesList;
            }
            //});            
        }

        void RemoveFromCurrentValuesList(object state)
        {
            MeasurementInfo measurementInfo = (MeasurementInfo)state;
            ListBoxCurrentValues.Dispatcher.Invoke((Action)delegate()
            {
                lock (m_currentValuesList)
                {
                    if (m_currentValuesList.ContainsKey(measurementInfo.SignalID.ToUpper()))
                    {
                        m_currentValuesList.Remove(measurementInfo.SignalID.ToUpper());
                        ListBoxCurrentValues.Items.Refresh();
                        ListBoxCurrentValues.ItemsSource = m_currentValuesList;
                    }
                }
            });
        }

        #endregion

        #region [ Methods releated to tree data display ]

        void GetDeviceMeasurementData()
        {
            try
            {
                m_deviceMeasurementDataList = CommonFunctions.GetDeviceMeasurementData(null, ((App)Application.Current).NodeValue);
                GetSettingsFromIsolatedStorage();
                if (m_deviceMeasurementDataList.Count > 0 && !string.IsNullOrEmpty(m_measurementDataPointsForSubscription))
                    SubscribeDataForTree();
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetDeviceMeasurementsData", ex);
                SystemMessages sm = new SystemMessages(new openPDCManager.Utilities.Message()
                {
                    UserMessage = "Failed to Retrieve Current Device Measurements Tree Data", SystemMessage = ex.Message, UserMessageType = openPDCManager.Utilities.MessageType.Error
                },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
            if (m_activityWindow != null)
                m_activityWindow.Close();
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

                        if (!deviceMeasurement.Enabled && deviceMeasurement.StatusColor != "Transparent")
                            deviceMeasurement.StatusColor = "Gray";
                        else if (m_deviceIDsWithStatusPointIDs.TryGetValue(deviceMeasurement.ID, out statusPointID))
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
                            if (!deviceMeasurement.Enabled && deviceMeasurement.StatusColor != "Transparent")
                                device.StatusColor = "Gray";
                            else if (device.ID != null)
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
                    CommonFunctions.LogException(null, "WPF.GetTimeTaggedMeasurements", ex);
                }
                finally
                {
                    m_retrievingData = false;
                }
            }
        }

        void RefreshDeviceMeasurementData()
        {
            TreeViewDeviceMeasurements.Dispatcher.BeginInvoke((Action)delegate()
            {
                m_dataForBinding.DeviceMeasurementDataList = m_deviceMeasurementDataList;
                m_dataForBinding.IsExpanded = false;
                TreeViewDeviceMeasurements.DataContext = m_dataForBinding;
                TreeViewDeviceMeasurements.Items.Refresh();
                TextBlockLastRefresh.Text = "Last Refresh: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            });
        }

        void StartSubscriptionForTreeData()
        {
            string server = openPDCManager.Utilities.Common.GetDataPublisherServer();
            string port = openPDCManager.Utilities.Common.GetDataPublisherPort();

            m_measurementDataSubscriber = new DataSubscriber();
            m_measurementDataSubscriber.StatusMessage += measurementDataSubscriber_StatusMessage;
            m_measurementDataSubscriber.ProcessException += measurementDataSubscriber_ProcessException;
            m_measurementDataSubscriber.ConnectionEstablished += measurementDataSubscriber_ConnectionEstablished;
            m_measurementDataSubscriber.NewMeasurements += measurementDataSubscriber_NewMeasurements;
            m_measurementDataSubscriber.ConnectionTerminated += measurementDataSubscriber_ConnectionTerminated;
            m_measurementDataSubscriber.ConnectionString = "server=" + server + ":" + port;
            m_measurementDataSubscriber.Initialize();
            m_measurementDataSubscriber.Start();
        }

        void SubscribeDataForTree()
        {
            if (m_measurementDataSubscriber == null)
                StartSubscriptionForTreeData();

            if (m_subscribedForTree && !string.IsNullOrEmpty(m_measurementDataPointsForSubscription))
            {
                //string password = openPDCManager.Utilities.Common.GetDataPublisherPassword();
                m_measurementDataSubscriber.UnsynchronizedSubscribe(true, true, m_measurementDataPointsForSubscription, null, true, (double)m_measurementsDataRefreshInterval);
            }
        }

        void UnsubscribeDataForTree()
        {
            try
            {
                if (m_measurementDataSubscriber != null)
                {
                    m_measurementDataSubscriber.Unsubscribe();
                    StopSubscriptionForTree();
                }
            }
            catch
            {
                m_measurementDataSubscriber = null;
            }
        }

        void StopSubscriptionForTree()
        {
            if (m_measurementDataSubscriber != null)
            {
                m_measurementDataSubscriber.StatusMessage -= measurementDataSubscriber_StatusMessage;
                m_measurementDataSubscriber.ProcessException -= measurementDataSubscriber_ProcessException;
                m_measurementDataSubscriber.ConnectionEstablished -= measurementDataSubscriber_ConnectionEstablished;
                m_measurementDataSubscriber.NewMeasurements -= measurementDataSubscriber_NewMeasurements;
                m_measurementDataSubscriber.Stop();
                m_measurementDataSubscriber.Dispose();
                m_measurementDataSubscriber = null;
            }
        }

        #endregion

        #endregion

        #region [ Controls Event Handlers ]

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Title = "Save Current Display Settings";
                saveDialog.Filter = "Input Status Monitoring Display Settings (*.ismsettings)|*.ismsettings|All Files (*.*)|*.*";
                bool? result = saveDialog.ShowDialog(Window.GetWindow(this));
                if (result != null && (bool)result == true)
                {
                    using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (KeyValuePair<string, MeasurementInfo> selectedMeasurement in m_selectedMeasurements)
                        {
                            sb.Append(selectedMeasurement.Value.SignalReference + ";");
                        }
                        writer.Write(sb.ToString());
                    }
                }
            }
            catch (Exception)
            {
                //System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

        }

        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openDialog = new OpenFileDialog();
                openDialog.Multiselect = false;
                openDialog.Filter = "Input Status Monitoring Display Settings (*.ismsettings)|*.ismsettings|All Files (*.*)|*.*";
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
                                        m_selectedMeasurements.TryAdd(measurementInfo.SignalID.ToUpper(), measurementInfo);
                                        AddToCurrentValuesList(measurementInfo);
                                    }
                                    else
                                    {
                                        measurementInfo.IsSelected = false;
                                        if (m_selectedMeasurements.ContainsKey(measurementInfo.SignalID.ToUpper()))
                                            RemoveLineGraph(measurementInfo);
                                        RemoveFromCurrentValuesList(measurementInfo);
                                    }
                                }
                            }
                        }
                        m_dataForBinding.IsExpanded = false;
                        TreeViewDeviceMeasurements.Items.Refresh();
                        TreeViewDeviceMeasurements.DataContext = m_dataForBinding;
                    }

                    if (m_selectedMeasurements.Count > 0)
                        SubscribeDataForChart();
                }
            }
            catch (Exception)
            {
                //System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckBox checkBox = ((CheckBox)sender);
                RemoveLineGraph((MeasurementInfo)checkBox.DataContext);
                //ThreadPool.QueueUserWorkItem(RemoveFromCurrentValuesList, (MeasurementInfo)checkBox.DataContext);
                RemoveFromCurrentValuesList((MeasurementInfo)checkBox.DataContext);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                MeasurementInfo measurementInfo = (MeasurementInfo)((CheckBox)sender).DataContext;
                //ThreadPool.QueueUserWorkItem(AddToCurrentValuesList, measurementInfo);
                AddToCurrentValuesList(measurementInfo);
                if (!m_selectedMeasurements.ContainsKey(measurementInfo.SignalID.ToUpper()))
                    m_selectedMeasurements.TryAdd(measurementInfo.SignalID.ToUpper(), measurementInfo);
                SubscribeDataForChart();
            }
            catch (Exception)
            {
                //stem.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        private void ButtonGetStatistics_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string deviceAcronym = ((Button)sender).Content.ToString();
                Device deviceInfo = CommonFunctions.GetDeviceByAcronym(null, deviceAcronym);
                UserControlDeviceDetailInfo.Initialize(deviceInfo);
                UserControlDeviceDetailInfo.Visibility = Visibility.Visible;
            }
            catch (Exception)
            {
                //stem.Diagnostics.Debug.WriteLine(ex.ToString());
            }

        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            try
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
                        SystemMessages sm = new SystemMessages(new openPDCManager.Utilities.Message()
                        {
                            UserMessage = "Invalid or Dummy Device Selected", SystemMessage = string.Empty, UserMessageType = openPDCManager.Utilities.MessageType.Information
                        },
                            ButtonType.OkOnly);
                        sm.Owner = Window.GetWindow(this);
                        sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        sm.ShowPopup();
                    }
                }
                else
                {
                    SystemMessages sm = new SystemMessages(new openPDCManager.Utilities.Message()
                    {
                        UserMessage = "Invalid or Dummy Device Selected", SystemMessage = string.Empty, UserMessageType = openPDCManager.Utilities.MessageType.Information
                    },
                            ButtonType.OkOnly);
                    sm.Owner = Window.GetWindow(this);
                    sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    sm.ShowPopup();
                }
            }
            catch (Exception)
            {

                //stem.Diagnostics.Debug.WriteLine(ex.ToString());
            }

        }

        #endregion

    }
}
