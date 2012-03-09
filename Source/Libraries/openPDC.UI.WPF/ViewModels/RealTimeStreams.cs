//******************************************************************************************************
//  RealTimeStreams.cs - Gbtc
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
//  08/18/2011 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using openPDC.UI.DataModels;
using TimeSeriesFramework;
using TimeSeriesFramework.Transport;
using TimeSeriesFramework.UI;
using TVA;
using TVA.Data;
using TVA.ServiceProcess;

namespace openPDC.UI.ViewModels
{
    /// <summary>
    /// Class to hold bindable <see cref="RealTimeStream"/> collection and current selection information for UI.
    /// </summary>
    internal class RealTimeStreams : PagedViewModelBase<RealTimeStream, int>
    {
        #region [ Members ]

        // Fields
        private bool m_expanded;
        private bool m_restartConnectionCycle;
        private string m_lastRefresh;
        private ObservableCollection<StatisticMeasurement> m_statisticMeasurements;
        private RealTimeStatistics m_statistics;
        private int m_statisticRefreshInterval = 10;
        private bool m_temporalSupportEnabled;
        private string m_startTime = "*-10m";
        private string m_stopTime = "*";

        // Unsynchronized Subscription Fields.
        private DataSubscriber m_unsynchronizedSubscriber;
        private bool m_subscribedUnsynchronized;
        private string m_allSignalIDs;  // string of GUIDs used for subscription.
        private int m_processingUnsynchronizedMeasurements = 0;
        private int m_refreshInterval = 10;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates an instance of <see cref="RealTimeStreams"/>.
        /// </summary>
        /// <param name="itemsPerPage"></param>
        /// <param name="refreshInterval">Interval to refresh measurement in a tree.</param>
        /// <param name="autoSave"></param>        
        public RealTimeStreams(int itemsPerPage, int refreshInterval, bool autoSave = false)
            : base(itemsPerPage, autoSave)
        {
            // Perform initialization here. 
            m_refreshInterval = refreshInterval;
            InitializeUnsynchronizedSubscription();
            m_restartConnectionCycle = true;
            StatisticMeasurements = new ObservableCollection<StatisticMeasurement>();

            int.TryParse(TimeSeriesFramework.UI.IsolatedStorageManager.ReadFromIsolatedStorage("StatisticsDataRefreshInterval").ToString(), out m_statisticRefreshInterval);
            m_statistics = new RealTimeStatistics(1, m_statisticRefreshInterval);

            CheckTemporalSupport();
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets start time for this <see cref="RealTimeStream"/>.
        /// </summary>
        public string StartTime
        {
            get
            {
                return m_startTime;
            }
            set
            {
                m_startTime = value;
            }
        }

        /// <summary>
        /// Gets or sets stop for this <see cref="RealTimeStream"/>.
        /// </summary>
        public string StopTime
        {
            get
            {
                return m_stopTime;
            }
            set
            {
                m_stopTime = value;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if temporal support is enabled.
        /// </summary>
        public bool TemporalSupportEnabled
        {
            get
            {
                return m_temporalSupportEnabled;
            }
            set
            {
                m_temporalSupportEnabled = value;
                OnPropertyChanged("TemporalSupportEnabled");
            }
        }

        /// <summary>
        /// Gets flag that determines if <see cref="PagedViewModelBase{T1, T2}.CurrentItem"/> is a new record.
        /// </summary>
        public override bool IsNewRecord
        {
            get
            {
                return CurrentItem.ID == 0;
            }
        }

        /// <summary>
        /// Gets or sets a boolean flag <see cref="RealTimeStreams"/> expanded flag.
        /// </summary>
        public bool Expanded
        {
            get
            {
                return m_expanded;
            }
            set
            {
                m_expanded = value;
                OnPropertyChanged("Expanded");
            }
        }

        /// <summary>
        /// Gets or sets a boolean flag indicating if connection to backend windows service needs to be reestablished upon disconnection.
        /// </summary>
        public bool RestartConnectionCycle
        {
            get
            {
                return m_restartConnectionCycle;
            }
            set
            {
                m_restartConnectionCycle = value;
            }
        }

        /// <summary>
        /// Gets or sets a last refresh time to display on UI.
        /// </summary>
        public string LastRefresh
        {
            get
            {
                return m_lastRefresh;
            }
            set
            {
                m_lastRefresh = value;
                OnPropertyChanged("LastRefresh");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="RealTimeStreams"/> StatisticMeasurements.
        /// </summary>
        public ObservableCollection<StatisticMeasurement> StatisticMeasurements
        {
            get
            {
                return m_statisticMeasurements;
            }
            set
            {
                m_statisticMeasurements = value;
                OnPropertyChanged("StatisticMeasurements");
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Gets the primary key value of the <see cref="PagedViewModelBase{T1, T2}.CurrentItem"/>.
        /// </summary>
        /// <returns>The primary key value of the <see cref="PagedViewModelBase{T1, T2}.CurrentItem"/>.</returns>
        public override int GetCurrentItemKey()
        {
            return CurrentItem.ID;
        }

        /// <summary>
        /// Gets the string based named identifier of the <see cref="PagedViewModelBase{T1, T2}.CurrentItem"/>.
        /// </summary>
        /// <returns>The string based named identifier of the <see cref="PagedViewModelBase{T1, T2}.CurrentItem"/>.</returns>
        public override string GetCurrentItemName()
        {
            return CurrentItem.Name;
        }

        /// <summary>
        /// Overrides Load() method from the base class to add aditional functionalities.
        /// </summary>
        public override void Load()
        {
            try
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                base.Load();

                // Build a string of measurement GUIDs to pass into subscription request to retrieve data for tree.
                StringBuilder sb = new StringBuilder();

                foreach (RealTimeStream stream in ItemsSource)
                {
                    foreach (RealTimeDevice device in stream.DeviceList)
                    {
                        foreach (RealTimeMeasurement measurement in device.MeasurementList)
                        {
                            sb.Append(measurement.SignalID.ToString());
                            sb.Append(";");
                        }
                    }
                }

                m_allSignalIDs = sb.ToString();
                if (m_allSignalIDs.Length > 0)
                    m_allSignalIDs = m_allSignalIDs.Substring(0, m_allSignalIDs.Length - 1);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Popup(ex.Message + Environment.NewLine + "Inner Exception: " + ex.InnerException.Message, "Load " + DataModelName + " Exception:", MessageBoxImage.Error);
                    CommonFunctions.LogException(null, "Load " + DataModelName, ex.InnerException);
                }
                else
                {
                    Popup(ex.Message, "Load " + DataModelName + " Exception:", MessageBoxImage.Error);
                    CommonFunctions.LogException(null, "Load " + DataModelName, ex);
                }
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        public void GetStatistics(Device device)
        {
            try
            {
                StatisticMeasurements.Clear();
                ObservableCollection<StatisticMeasurement> tempMeasurements = new ObservableCollection<StatisticMeasurement>(
                        RealTimeStatistic.GetStatisticMeasurements(null).Where(sm => sm.DeviceID == device.ID)
                    );

                foreach (StatisticMeasurement measurement in tempMeasurements)
                {
                    StatisticMeasurement tempMeasurement;
                    if (RealTimeStatistic.StatisticMeasurements.TryGetValue(measurement.PointID, out tempMeasurement))
                        StatisticMeasurements.Add(tempMeasurement);
                }

            }
            catch (Exception ex)
            {
                Popup("Failed to retrieve statistics." + Environment.NewLine + ex.Message, "ERROR! Get Statistics", MessageBoxImage.Error);
            }
        }

        #region [ Unsynchronized Subscription ]

        private void m_unsynchronizedSubscriber_ConnectionTerminated(object sender, EventArgs e)
        {
            m_subscribedUnsynchronized = false;
            UnsubscribeUnsynchronizedData();
            if (RestartConnectionCycle)
                InitializeUnsynchronizedSubscription();
        }

        private void m_unsynchronizedSubscriber_NewMeasurements(object sender, EventArgs<ICollection<IMeasurement>> e)
        {
            if (0 == Interlocked.Exchange(ref m_processingUnsynchronizedMeasurements, 1))
            {
                try
                {
                    ObservableCollection<StatisticMeasurement> statisticMeasurements;
                    StreamStatistic streamStatistic;

                    foreach (RealTimeStream stream in ItemsSource)
                    {
                        if (stream.ID > 0 && RealTimeStatistic.InputStreamStatistics.TryGetValue(stream.ID, out streamStatistic))
                        {
                            stream.StatusColor = streamStatistic.StatusColor;
                        }

                        foreach (RealTimeDevice device in stream.DeviceList)
                        {
                            if (device.ID != null && device.ID > 0)
                            {
                                if (RealTimeStatistic.InputStreamStatistics.TryGetValue((int)device.ID, out streamStatistic))
                                {
                                    device.StatusColor = streamStatistic.StatusColor;
                                }
                                else if (RealTimeStatistic.DevicesWithStatisticMeasurements.TryGetValue((int)device.ID, out statisticMeasurements))
                                {
                                    device.StatusColor = "Green";
                                    foreach (StatisticMeasurement statisticMeasurement in statisticMeasurements)
                                    {
                                        int value;
                                        if (int.TryParse(statisticMeasurement.Value, out value) && value > 0)
                                        {
                                            device.StatusColor = "Yellow";
                                        }
                                    }
                                }
                            }

                            foreach (RealTimeMeasurement measurement in device.MeasurementList)
                            {
                                foreach (IMeasurement newMeasurement in e.Argument)
                                {
                                    if (measurement.SignalID == newMeasurement.ID)
                                    {
                                        measurement.Quality = newMeasurement.ValueQualityIsGood() ? "GOOD" : "BAD";
                                        measurement.TimeTag = newMeasurement.Timestamp.ToString("HH:mm:ss.fff");
                                        measurement.Value = newMeasurement.Value.ToString("0.###");

                                        //if (measurement.SignalAcronym == "FLAG")
                                        //{
                                        //    if (stream.Enabled && stream.StatusColor != "Transparent")
                                        //    {
                                        //        stream.StatusColor = "Gray";
                                        //        device.StatusColor = "Gray";
                                        //    }
                                        //}
                                        //else if (!device.Enabled)
                                        //{
                                        //    device.StatusColor = "Gray";
                                        //}
                                        //else if (stream.StatusColor == "Red")
                                        //{
                                        //    device.StatusColor = "Red";
                                        //}
                                        //else if (newMeasurement.ValueQualityIsGood())
                                        //{
                                        //    device.StatusColor = "Green";
                                        //}
                                        //else
                                        //{
                                        //    device.StatusColor = "Yellow";
                                        //}
                                    }
                                }
                            }
                        }
                    }

                    LastRefresh = "Last Refresh: " + DateTime.Now.ToString("HH:mm:ss.fff");
                }
                finally
                {
                    Interlocked.Exchange(ref m_processingUnsynchronizedMeasurements, 0);
                }
            }
        }

        private void m_unsynchronizedSubscriber_ConnectionEstablished(object sender, EventArgs e)
        {
            m_subscribedUnsynchronized = true;
            SubscribeUnsynchronizedData();
        }

        private void m_unsynchronizedSubscriber_ProcessException(object sender, EventArgs<Exception> e)
        {

        }

        private void m_unsynchronizedSubscriber_StatusMessage(object sender, EventArgs<string> e)
        {

        }

        private void InitializeUnsynchronizedSubscription()
        {
            try
            {
                using (AdoDataConnection database = new AdoDataConnection(CommonFunctions.DefaultSettingsCategory))
                {
                    m_unsynchronizedSubscriber = new DataSubscriber();
                    m_unsynchronizedSubscriber.StatusMessage += m_unsynchronizedSubscriber_StatusMessage;
                    m_unsynchronizedSubscriber.ProcessException += m_unsynchronizedSubscriber_ProcessException;
                    m_unsynchronizedSubscriber.ConnectionEstablished += m_unsynchronizedSubscriber_ConnectionEstablished;
                    m_unsynchronizedSubscriber.NewMeasurements += m_unsynchronizedSubscriber_NewMeasurements;
                    m_unsynchronizedSubscriber.ConnectionTerminated += m_unsynchronizedSubscriber_ConnectionTerminated;
                    m_unsynchronizedSubscriber.ConnectionString = database.DataPublisherConnectionString();
                    m_unsynchronizedSubscriber.Initialize();
                    m_unsynchronizedSubscriber.Start();
                }
            }
            catch (Exception ex)
            {
                Popup("Failed to initialize subscription." + Environment.NewLine + ex.Message, "Failed to Subscribe", MessageBoxImage.Error);
            }
        }

        private void StopUnsynchronizedSubscription()
        {
            if (m_unsynchronizedSubscriber != null)
            {
                m_unsynchronizedSubscriber.StatusMessage -= m_unsynchronizedSubscriber_StatusMessage;
                m_unsynchronizedSubscriber.ProcessException -= m_unsynchronizedSubscriber_ProcessException;
                m_unsynchronizedSubscriber.ConnectionEstablished -= m_unsynchronizedSubscriber_ConnectionEstablished;
                m_unsynchronizedSubscriber.NewMeasurements -= m_unsynchronizedSubscriber_NewMeasurements;
                m_unsynchronizedSubscriber.ConnectionTerminated -= m_unsynchronizedSubscriber_ConnectionTerminated;
                m_unsynchronizedSubscriber.Stop();
                m_unsynchronizedSubscriber.Dispose();
                m_unsynchronizedSubscriber = null;
            }
        }

        private void SubscribeUnsynchronizedData()
        {
            SubscribeUnsynchronizedData(false);
        }

        public void SubscribeUnsynchronizedData(bool historical)
        {
            if (m_unsynchronizedSubscriber == null)
                InitializeUnsynchronizedSubscription();

            if (m_subscribedUnsynchronized && !string.IsNullOrEmpty(m_allSignalIDs))
            {
                if (!historical)
                    m_unsynchronizedSubscriber.UnsynchronizedSubscribe(true, true, m_allSignalIDs, null, true, m_refreshInterval);
                else
                    m_unsynchronizedSubscriber.UnsynchronizedSubscribe(true, true, m_allSignalIDs, null, true, m_refreshInterval, startTime: StartTime, stopTime: StopTime, processingInterval: m_refreshInterval * 1000);
            }

            if (m_statistics == null)
                m_statistics = new RealTimeStatistics(1, m_statisticRefreshInterval);
        }

        /// <summary>
        /// Unsubscribes data from the service.
        /// </summary>
        public void UnsubscribeUnsynchronizedData()
        {
            try
            {
                if (m_unsynchronizedSubscriber != null)
                {
                    m_unsynchronizedSubscriber.Unsubscribe();
                    StopUnsynchronizedSubscription();
                    if (m_statistics != null)
                    {
                        m_statistics.Stop();
                        m_statistics = null;
                    }
                }
            }
            catch
            {
                m_unsynchronizedSubscriber = null;
            }
        }

        #endregion

        private void CheckTemporalSupport()
        {
            WindowsServiceClient windowsServiceClient = null;
            try
            {
                s_responseWaitHandle = new ManualResetEvent(false);

                windowsServiceClient = TimeSeriesFramework.UI.CommonFunctions.GetWindowsServiceClient();
                if (windowsServiceClient != null && windowsServiceClient.Helper != null &&
                   windowsServiceClient.Helper.RemotingClient != null && windowsServiceClient.Helper.RemotingClient.CurrentState == TVA.Communication.ClientState.Connected)
                {
                    windowsServiceClient.Helper.ReceivedServiceResponse += Helper_ReceivedServiceResponse;

                    CommonFunctions.SendCommandToService("TemporalSupport -system");

                    if (!s_responseWaitHandle.WaitOne(10000))
                    {
                        TemporalSupportEnabled = false;
                        //throw new ApplicationException("Response timeout occured. Waited 10 seconds for response.");
                    }
                }
                else
                {
                    //throw new ApplicationException("Connection timeout occured. Tried 10 times to connect to windows service.");
                }
            }
            catch (Exception ex)
            {
                Popup("ERROR: " + ex.Message, "Request Configuration", MessageBoxImage.Error);
            }
            finally
            {
                if (windowsServiceClient != null)
                {
                    windowsServiceClient.Helper.ReceivedServiceResponse -= Helper_ReceivedServiceResponse;
                }
            }
        }

        /// <summary>
        /// Handles ReceivedServiceResponse event.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void Helper_ReceivedServiceResponse(object sender, EventArgs<ServiceResponse> e)
        {
            bool temporalSupportEnabled = false;
            string sourceCommand;
            bool responseSuccess;

            if (ClientHelper.TryParseActionableResponse(e.Argument, out sourceCommand, out responseSuccess))
            {
                if (responseSuccess && bool.TryParse(e.Argument.Attachments[0].ToString(), out temporalSupportEnabled))
                    TemporalSupportEnabled = temporalSupportEnabled;

                s_responseWaitHandle.Set();
            }
        }

        #endregion

        #region [ Static ]

        // Fields

        private static ManualResetEvent s_responseWaitHandle;

        #endregion
    }
}
