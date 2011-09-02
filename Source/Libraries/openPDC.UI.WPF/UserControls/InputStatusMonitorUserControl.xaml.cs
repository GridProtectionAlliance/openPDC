//******************************************************************************************************
//  InputStatusMonitorUserControl.xaml.cs - Gbtc
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
//  08/15/2011 - Mehulbhai P Thakkar
//       Generated original version of source code.
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
using openPDC.UI.DataModels;
using openPDC.UI.ViewModels;
using TimeSeriesFramework;
using TimeSeriesFramework.Transport;
using TimeSeriesFramework.UI;
using TVA;
using TVA.Data;

namespace openPDC.UI.UserControls
{
    /// <summary>
    /// Interaction logic for InputStatusMonitorUserControl.xaml
    /// </summary>
    public partial class InputStatusMonitorUserControl : UserControl
    {

        #region [ Members ]

        // Fields
        private RealTimeStreams m_dataContext;
        private List<Color> m_lineColors;

        // Synchronized Subscription Fields.
        private bool m_restartConnectionCycle;
        private int[] m_xAxisDataCollection;    //contains source data for the binding collection.
        private EnumerableDataSource<int> m_xAxisBindingCollection;     //contains values plotted on X-Axis.
        private DataSubscriber m_synchronizedSubscriber;
        private bool m_subscribedSynchronized;
        private DispatcherTimer m_refreshTimer;
        private ConcurrentQueue<string> m_timeStampList;
        private ConcurrentDictionary<Guid, ConcurrentQueue<double>> m_yAxisDataCollection;            //contains source data for the binding collection. Format is <signalID, collection of values from subscription API>.
        private ConcurrentDictionary<Guid, EnumerableDataSource<double>> m_yAxisBindingCollection;    //contains values plotted on Y-Axis.
        private ConcurrentDictionary<Guid, LineGraph> m_lineGraphCollection;                          //contains list of graphs plotted on the chart.
        private ConcurrentDictionary<Guid, RealTimeMeasurement> m_selectedMeasurements;                  //measurements user have selected to plot.
        private ObservableCollection<RealTimeMeasurement> m_displayedMeasurement;
        private string m_selectedSignalIDs;
        private int m_processingSynchronizedMeasurements = 0;
        private int m_numberOfDataPointsToPlot = 30;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates an instance of <see cref="InputStatusMonitorUserControl"/>.
        /// </summary>
        public InputStatusMonitorUserControl()
        {
            InitializeComponent();
            m_timeStampList = new ConcurrentQueue<string>();
            m_xAxisDataCollection = new int[m_numberOfDataPointsToPlot];
            m_yAxisDataCollection = new ConcurrentDictionary<Guid, ConcurrentQueue<double>>();
            m_yAxisBindingCollection = new ConcurrentDictionary<Guid, EnumerableDataSource<double>>();
            m_lineGraphCollection = new ConcurrentDictionary<Guid, LineGraph>();
            m_selectedMeasurements = new ConcurrentDictionary<Guid, RealTimeMeasurement>();
            m_displayedMeasurement = new ObservableCollection<RealTimeMeasurement>();
            m_restartConnectionCycle = true;
            this.Loaded += new System.Windows.RoutedEventHandler(InputStatusMonitorUserControl_Loaded);
            this.Unloaded += new RoutedEventHandler(InputStatusMonitorUserControl_Unloaded);
        }

        #endregion

        #region [ Methods ]

        #region [ Controls Event Handlers ]

        private void InputStatusMonitorUserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            m_restartConnectionCycle = false;
            UnsubscribeSynchronizedData();
            m_dataContext.UnsubscribeUnsynchronizedData();

            // TODO: Store current selection into Isolated Storage.
        }

        /// <summary>
        /// Handles loaded event.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void InputStatusMonitorUserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            m_dataContext = new RealTimeStreams(1);
            this.DataContext = m_dataContext;
            ListBoxCurrentValues.ItemsSource = m_displayedMeasurement;

            // Initialize Chart Properties.
            InitializeColors();
            InitializeChart();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            RealTimeMeasurement measurement = (RealTimeMeasurement)((CheckBox)sender).DataContext;
            m_selectedMeasurements.TryAdd(measurement.SignalID, measurement);
            RefreshSelectedMeasurements();
            AddToDisplayedMeasurements(measurement);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            RealTimeMeasurement measurement = (RealTimeMeasurement)((CheckBox)sender).DataContext;
            m_selectedMeasurements.TryRemove(measurement.SignalID, out measurement);
            RemoveLineGraph(measurement);
            RefreshSelectedMeasurements();
            RemoveFromDisplayedMeasurements(measurement);
        }

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
                        foreach (KeyValuePair<Guid, RealTimeMeasurement> selectedMeasurement in m_selectedMeasurements)
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
                        string[] signalIDs = selection.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (RealTimeStream stream in m_dataContext.ItemsSource)
                        {
                            stream.Expanded = false;
                            foreach (RealTimeDevice device in stream.DeviceList)
                            {
                                device.Expanded = false;
                                foreach (RealTimeMeasurement measurement in device.MeasurementList)
                                {
                                    if (signalIDs.Contains(measurement.SignalID.ToString()))
                                    {
                                        measurement.Selected = true;
                                        device.Expanded = true;
                                        stream.Expanded = true;
                                        m_selectedMeasurements.TryAdd(measurement.SignalID, measurement);
                                        AddToDisplayedMeasurements(measurement);
                                    }
                                    else
                                    {
                                        measurement.Selected = false;
                                        if (m_selectedMeasurements.ContainsKey(measurement.SignalID))
                                        {
                                            //TODO: Remove graph.
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (m_selectedMeasurements.Count > 0)
                        SubscribeSynchronizedData();
                }
            }
            catch (Exception)
            {
                //System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        private void AddToDisplayedMeasurements(RealTimeMeasurement measurement)
        {
            bool addMeasurement = true;
            foreach (RealTimeMeasurement m in m_displayedMeasurement)
            {
                if (m.SignalID == measurement.SignalID)
                {
                    addMeasurement = false;
                    break;
                }
            }

            if (addMeasurement)
                m_displayedMeasurement.Add(measurement);
        }

        private void RemoveFromDisplayedMeasurements(RealTimeMeasurement measurement)
        {
            bool removeMeasurement = false;
            foreach (RealTimeMeasurement m in m_displayedMeasurement)
            {
                if (m.SignalID == measurement.SignalID)
                {
                    removeMeasurement = true;
                    break;
                }
            }

            if (removeMeasurement)
                m_displayedMeasurement.Remove(measurement);
        }

        #endregion

        private void RefreshSelectedMeasurements()
        {
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<Guid, RealTimeMeasurement> measurement in m_selectedMeasurements)
            {
                sb.Append(measurement.Value.SignalID.ToString());
                sb.Append(";");
            }

            m_selectedSignalIDs = sb.ToString();
            if (m_selectedSignalIDs.Length > 0)
                m_selectedSignalIDs = m_selectedSignalIDs.Substring(0, m_selectedSignalIDs.Length - 1);

            // once user has changed selection, resubscribe with new values.
            SubscribeSynchronizedData();
        }

        private void InitializeColors()
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

        private void InitializeChart()
        {
            ((HorizontalAxis)ChartPlotterDynamic.MainHorizontalAxis).LabelProvider.LabelStringFormat = "";
            ChartPlotterDynamic.LegendVisibility = Visibility.Collapsed;

            for (int i = 0; i < m_numberOfDataPointsToPlot; i++)
                m_xAxisDataCollection[i] = i;
            m_xAxisBindingCollection = new EnumerableDataSource<int>(m_xAxisDataCollection);
            m_xAxisBindingCollection.SetXMapping(x => x);

            ChartPlotterDynamic.Visible = DataRect.Create(0, 59.95, m_numberOfDataPointsToPlot, 60.05);
            PhaseAnglePlotter.Visible = DataRect.Create(0, -180, m_numberOfDataPointsToPlot, 180);
        }

        private void StartRefreshTimer()
        {
            if (m_refreshTimer == null)
            {
                m_refreshTimer = new DispatcherTimer();
                m_refreshTimer.Interval = TimeSpan.FromMilliseconds(250);
                m_refreshTimer.Tick += new EventHandler(m_refreshTimer_Tick);
                m_refreshTimer.Start();
            }
        }

        private void m_refreshTimer_Tick(object sender, EventArgs e)
        {
            foreach (KeyValuePair<Guid, EnumerableDataSource<double>> keyValuePair in m_yAxisBindingCollection)
            {
                try
                {
                    lock (keyValuePair.Value)
                        keyValuePair.Value.RaiseDataChanged();
                }
                catch
                {
                }
            }

            if (m_timeStampList.Count > 0)
            {
                TextBlockLeft.Text = m_timeStampList.First();
                TextBlockRight.Text = m_timeStampList.Last();
            }
        }

        private void StopRefreshTimer()
        {
            try
            {
                if (m_refreshTimer != null)
                {
                    m_refreshTimer.Stop();
                    m_refreshTimer.Tick -= m_refreshTimer_Tick;
                }
            }
            finally
            {
                m_refreshTimer = null;
            }
        }

        private void RemoveLineGraph(RealTimeMeasurement measurement)
        {
            LineGraph lineGraphToBeRemoved;
            EnumerableDataSource<double> bindingCollectionToBeRemoved;
            ConcurrentQueue<double> dataCollectionToBeRemoved;

            m_yAxisBindingCollection.TryRemove(measurement.SignalID, out bindingCollectionToBeRemoved);
            m_yAxisDataCollection.TryRemove(measurement.SignalID, out dataCollectionToBeRemoved);
            m_lineGraphCollection.TryRemove(measurement.SignalID, out lineGraphToBeRemoved);

            if (measurement.SignalAcronym == "FREQ")
                ChartPlotterDynamic.Children.Remove((IPlotterElement)lineGraphToBeRemoved);
            else if (measurement.SignalAcronym == "IPHA" || measurement.SignalAcronym == "VPHA")
                PhaseAnglePlotter.Children.Remove((IPlotterElement)lineGraphToBeRemoved);
            else if (measurement.SignalAcronym == "VPHM")
                VoltagePlotter.Children.Remove((IPlotterElement)lineGraphToBeRemoved);
            else if (measurement.SignalAcronym == "IPHM")
                CurrentPlotter.Children.Remove((IPlotterElement)lineGraphToBeRemoved);
        }

        #region [ Synchronized Subscription ]

        private void m_synchronizedSubscriber_ConnectionTerminated(object sender, EventArgs e)
        {
            m_subscribedSynchronized = false;
            UnsubscribeSynchronizedData();
            if (m_restartConnectionCycle)
                InitializeSynchronizedSubscription();
        }

        private void m_synchronizedSubscriber_NewMeasurements(object sender, EventArgs<ICollection<IMeasurement>> e)
        {
            if (0 == Interlocked.Exchange(ref m_processingSynchronizedMeasurements, 1))
            {
                try
                {
                    bool processedTimestamp = false;
                    foreach (IMeasurement newMeasurement in e.Argument)
                    {
                        if (!processedTimestamp)
                        {
                            m_timeStampList.Enqueue(newMeasurement.Timestamp.ToString("HH:mm:ss.fff"));
                            if (m_timeStampList.Count > m_numberOfDataPointsToPlot)
                            {
                                string oldValue;
                                m_timeStampList.TryDequeue(out oldValue);
                            }
                        }

                        double tempValue = newMeasurement.Value;
                        Guid tempSignalID = newMeasurement.ID;
                        if (!double.IsNaN(tempValue) && !double.IsInfinity(tempValue)) // Process data only if it is not NaN or infinity.
                        {
                            ConcurrentQueue<double> tempValueCollection;
                            if (m_yAxisDataCollection.TryGetValue(tempSignalID, out tempValueCollection)) // If value collection already exists, then just replace oldest value with newest.
                            {
                                double oldValue;
                                if (tempValueCollection.TryDequeue(out oldValue))
                                    tempValueCollection.Enqueue(tempValue);
                            }
                            else // It is probably a new measurement user wants to subscribe to.
                            {
                                RealTimeMeasurement measurement;

                                // Check if user has selected this measurement. Because user may have unselected this but request may not have been processed completely.
                                if (m_selectedMeasurements.TryGetValue(tempSignalID, out measurement))
                                {
                                    tempValueCollection = new ConcurrentQueue<double>();
                                    for (int i = 0; i < m_numberOfDataPointsToPlot; i++)
                                        tempValueCollection.Enqueue(tempValue);

                                    m_yAxisDataCollection.TryAdd(tempSignalID, tempValueCollection);
                                    EnumerableDataSource<double> tempDataSource = new EnumerableDataSource<double>(tempValueCollection);
                                    m_yAxisBindingCollection.TryAdd(tempSignalID, tempDataSource);
                                    tempDataSource.SetYMapping(y => y);

                                    ChartPlotterDynamic.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate()
                                    {
                                        int colorIndex;
                                        Math.DivRem(m_yAxisBindingCollection.Count, 10, out colorIndex);
                                        LineGraph lineGraph = null;

                                        if (measurement.SignalAcronym == "FREQ")
                                            lineGraph = ChartPlotterDynamic.AddLineGraph(new CompositeDataSource(m_xAxisBindingCollection, tempDataSource), m_lineColors[colorIndex], 1, measurement.SignalReference);
                                        else if (measurement.SignalAcronym == "IPHA" || measurement.SignalAcronym == "VPHA")
                                            lineGraph = PhaseAnglePlotter.AddLineGraph(new CompositeDataSource(m_xAxisBindingCollection, tempDataSource), m_lineColors[colorIndex], 1, measurement.SignalReference);
                                        else if (measurement.SignalAcronym == "VPHM")
                                            lineGraph = VoltagePlotter.AddLineGraph(new CompositeDataSource(m_xAxisBindingCollection, tempDataSource), m_lineColors[colorIndex], 1, measurement.SignalReference);
                                        else if (measurement.SignalAcronym == "IPHM")
                                            lineGraph = CurrentPlotter.AddLineGraph(new CompositeDataSource(m_xAxisBindingCollection, tempDataSource), m_lineColors[colorIndex], 1, measurement.SignalReference);

                                        if (lineGraph != null)
                                            m_lineGraphCollection.TryAdd(tempSignalID, lineGraph);

                                        measurement.Foreground = (SolidColorBrush)lineGraph.LinePen.Brush;
                                    });
                                }
                            }

                            if (DateTime.UtcNow.Ticks - m_lastRefreshTime > m_refreshRate)
                            {
                                m_lastRefreshTime = DateTime.UtcNow.Ticks;

                                lock (m_selectedMeasurements)
                                {
                                    RealTimeMeasurement measurement;
                                    if (m_selectedMeasurements.TryGetValue(tempSignalID, out measurement))
                                    {
                                        measurement.Value = tempValue.ToString("0.###");
                                        measurement.TimeTag = newMeasurement.Timestamp.ToString("HH:mm:ss.fff");
                                        measurement.Quality = newMeasurement.ValueQualityIsGood() ? "GOOD" : "UNKNOWN";
                                    }
                                }
                            }
                        }
                    }
                }
                finally
                {
                    Interlocked.Exchange(ref m_processingSynchronizedMeasurements, 0);
                }
            }
        }

        private long m_refreshRate = Ticks.FromMilliseconds(500);
        private long m_lastRefreshTime;

        private void m_synchronizedSubscriber_ConnectionEstablished(object sender, EventArgs e)
        {
            m_subscribedSynchronized = true;
            SubscribeSynchronizedData();
        }

        private void m_synchronizedSubscriber_ProcessException(object sender, EventArgs<Exception> e)
        {

        }

        private void m_synchronizedSubscriber_StatusMessage(object sender, EventArgs<string> e)
        {

        }

        private void InitializeSynchronizedSubscription()
        {
            try
            {
                using (AdoDataConnection database = new AdoDataConnection(CommonFunctions.DefaultSettingsCategory))
                {

                    m_synchronizedSubscriber = new DataSubscriber();
                    m_synchronizedSubscriber.StatusMessage += m_synchronizedSubscriber_StatusMessage;
                    m_synchronizedSubscriber.ProcessException += m_synchronizedSubscriber_ProcessException;
                    m_synchronizedSubscriber.ConnectionEstablished += m_synchronizedSubscriber_ConnectionEstablished;
                    m_synchronizedSubscriber.NewMeasurements += m_synchronizedSubscriber_NewMeasurements;
                    m_synchronizedSubscriber.ConnectionTerminated += m_synchronizedSubscriber_ConnectionTerminated;
                    m_synchronizedSubscriber.ConnectionString = database.DataPublisherConnectionString();
                    m_synchronizedSubscriber.Initialize();
                    m_synchronizedSubscriber.Start();
                }
            }
            catch (Exception ex)
            {
                //Popup("Failed to initialize subscription." + Environment.NewLine + ex.Message, "Failed to Subscribe", MessageBoxImage.Error);
            }
        }

        private void StopSynchronizedSubscription()
        {
            if (m_synchronizedSubscriber != null)
            {
                m_synchronizedSubscriber.StatusMessage -= m_synchronizedSubscriber_StatusMessage;
                m_synchronizedSubscriber.ProcessException -= m_synchronizedSubscriber_ProcessException;
                m_synchronizedSubscriber.ConnectionEstablished -= m_synchronizedSubscriber_ConnectionEstablished;
                m_synchronizedSubscriber.NewMeasurements -= m_synchronizedSubscriber_NewMeasurements;
                m_synchronizedSubscriber.ConnectionTerminated -= m_synchronizedSubscriber_ConnectionTerminated;
                m_synchronizedSubscriber.Stop();
                m_synchronizedSubscriber.Dispose();
                m_synchronizedSubscriber = null;
            }
        }

        private void SubscribeSynchronizedData()
        {
            if (m_selectedMeasurements.Count == 0)
            {
                UnsubscribeSynchronizedData();
            }
            else
            {
                if (m_synchronizedSubscriber == null)
                    InitializeSynchronizedSubscription();

                if (m_subscribedSynchronized && !string.IsNullOrEmpty(m_selectedSignalIDs))
                    m_synchronizedSubscriber.SynchronizedSubscribe(true, 30, 4, 10, m_selectedSignalIDs);

                ChartPlotterDynamic.Dispatcher.BeginInvoke((Action)delegate()
                    {
                        StartRefreshTimer();
                    });
            }
        }

        private void UnsubscribeSynchronizedData()
        {
            try
            {
                if (m_synchronizedSubscriber != null)
                {
                    m_synchronizedSubscriber.Unsubscribe();
                    StopSynchronizedSubscription();
                }
            }
            catch
            {
                m_synchronizedSubscriber = null;
            }

            StopRefreshTimer();
        }

        #endregion

        #endregion
    }
}
