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
using System.Collections.Concurrent;
using System.Collections.Generic;
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
        private ConcurrentDictionary<Guid, MeasurementInfo> m_currentSelection;
        private string m_lastRefresh;

        // Unsynchronized Subscription Fields.
        private DataSubscriber m_unsynchronizedSubscriber;
        private bool m_subscribedUnsynchronized;
        private string m_allSignalIDs;  // string of GUIDs used for subscription.
        private int m_processingUnsynchronizedMeasurements = 0;

        #endregion

        #region [ Constructors ]

        public RealTimeStreams(int itemsPerPage, bool autoSave = false)
            : base(itemsPerPage, autoSave)
        {
            // Perform initialization here.
            InitializeUnsynchronizedSubscription();
            m_restartConnectionCycle = true;
        }

        #endregion

        #region [ Properties ]

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
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        public void GetStatistics(object device)
        {

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
                    foreach (RealTimeStream stream in ItemsSource)
                    {
                        foreach (RealTimeDevice device in stream.DeviceList)
                        {
                            foreach (RealTimeMeasurement measurement in device.MeasurementList)
                            {
                                foreach (IMeasurement newMeasurement in e.Argument)
                                {
                                    if (measurement.SignalID == newMeasurement.ID)
                                    {
                                        measurement.Quality = newMeasurement.ValueQualityIsGood() ? "GOOD" : "BAD";
                                        measurement.TimeTag = newMeasurement.Timestamp.ToString("HH:mm:ss.fff");
                                        measurement.Value = newMeasurement.Value.ToString("0.###");

                                        if (measurement.SignalAcronym == "FLAG")
                                        {
                                            if (stream.Enabled && stream.StatusColor != "Transparent")
                                            {
                                                stream.StatusColor = "Gray";
                                                device.StatusColor = "Gray";
                                            }
                                        }
                                        else if (!device.Enabled)
                                        {
                                            device.StatusColor = "Gray";
                                        }
                                        else if (stream.StatusColor == "Red")
                                        {
                                            device.StatusColor = "Red";
                                        }
                                        else if (newMeasurement.ValueQualityIsGood())
                                        {
                                            device.StatusColor = "Green";
                                        }
                                        else
                                        {
                                            device.StatusColor = "Yellow";
                                        }
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
            if (m_unsynchronizedSubscriber == null)
                InitializeUnsynchronizedSubscription();

            if (m_subscribedUnsynchronized && !string.IsNullOrEmpty(m_allSignalIDs))
                m_unsynchronizedSubscriber.UnsynchronizedSubscribe(true, true, m_allSignalIDs, null, true);
        }

        public void UnsubscribeUnsynchronizedData()
        {
            try
            {
                if (m_unsynchronizedSubscriber != null)
                {
                    m_unsynchronizedSubscriber.Unsubscribe();
                    StopUnsynchronizedSubscription();
                }
            }
            catch
            {
                m_unsynchronizedSubscriber = null;
            }
        }

        #endregion

        #endregion
    }
}
