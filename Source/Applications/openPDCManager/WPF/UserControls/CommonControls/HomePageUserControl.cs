//******************************************************************************************************
//  HomePageUserControl.cs - Gbtc
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
//  07/20/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Threading;
using openPDCManager.Data;
using openPDCManager.Data.BusinessObjects;
using openPDCManager.Data.Entities;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
using TimeSeriesFramework;
using TimeSeriesFramework.Transport;
using TVA;

namespace openPDCManager.UserControls.CommonControls
{
    public partial class HomePageUserControl
    {
        #region [ Members ]

        bool m_connected = false;
        DispatcherTimer m_thirtySecondsTimer;
        List<InterconnectionStatus> interconnectionStatusList = new List<InterconnectionStatus>();
        ObservableCollection<TimeSeriesDataPoint> timeSeriesDataList = new ObservableCollection<TimeSeriesDataPoint>();

        //Subscription API related declarations.
        DataSubscriber m_dataSubscriber;
        bool m_subscribed;
        int m_processing;
        bool m_restartConnectionCycle = true;
        string m_measurementForSubscription;

        #endregion

        #region [ Subscription API Code ]

        #region [ Methods ]

        void StartSubscription()
        {
            string server = openPDCManager.Utilities.Common.GetDataPublisherServer();
            string port = openPDCManager.Utilities.Common.GetDataPublisherPort();

            m_dataSubscriber = new DataSubscriber();
            m_dataSubscriber.StatusMessage += dataSubscriber_StatusMessage;
            m_dataSubscriber.ProcessException += dataSubscriber_ProcessException;
            m_dataSubscriber.ConnectionEstablished += dataSubscriber_ConnectionEstablished;
            m_dataSubscriber.NewMeasurements += dataSubscriber_NewMeasurements;
            m_dataSubscriber.ConnectionTerminated += dataSubscriber_ConnectionTerminated;
            m_dataSubscriber.ConnectionString = "server=" + server + ":" + port;
            m_dataSubscriber.Initialize();
            m_dataSubscriber.Start();
        }

        void SubscribeData()
        {
            if (m_dataSubscriber == null)
                StartSubscription();

            if (m_subscribed && !string.IsNullOrEmpty(m_measurementForSubscription))
            {
                //string password = openPDCManager.Utilities.Common.GetDataPublisherPassword();
                m_dataSubscriber.UnsynchronizedSubscribe(true, true, m_measurementForSubscription, null, true, 1.0D);
            }
        }

        void UnsubscribeData()
        {
            try
            {
                if (m_dataSubscriber != null)
                {
                    m_dataSubscriber.Unsubscribe();
                    StopSubscription();
                }
            }
            catch
            {
                m_dataSubscriber = null;
            }
        }

        void StopSubscription()
        {
            if (m_dataSubscriber != null)
            {
                m_dataSubscriber.StatusMessage -= dataSubscriber_StatusMessage;
                m_dataSubscriber.ProcessException -= dataSubscriber_ProcessException;
                m_dataSubscriber.ConnectionEstablished -= dataSubscriber_ConnectionEstablished;
                m_dataSubscriber.NewMeasurements -= dataSubscriber_NewMeasurements;
                m_dataSubscriber.Stop();
                m_dataSubscriber.Dispose();
                m_dataSubscriber = null;
            }
        }

        #endregion

        #region [ Event Handlers ]

        void dataSubscriber_NewMeasurements(object sender, EventArgs<ICollection<IMeasurement>> e)
        {
            if (0 == Interlocked.Exchange(ref m_processing, 1))
            {
                try
                {
                    foreach (IMeasurement measurement in e.Argument)
                    {
                        ChartRealTimeData.Dispatcher.BeginInvoke((Action)delegate()
                        {
                            if (timeSeriesDataList.Count == 0)
                                timeSeriesDataList.Add(new TimeSeriesDataPoint()
                                {
                                    Index = 0, Value = measurement.Value
                                });
                            else
                                timeSeriesDataList.Add(new TimeSeriesDataPoint()
                                {
                                    Index = timeSeriesDataList[timeSeriesDataList.Count - 1].Index + 1, Value = measurement.Value
                                });

                            if (timeSeriesDataList.Count > 30)
                                timeSeriesDataList.RemoveAt(0);

                            ChartRealTimeData.DataContext = timeSeriesDataList;
                        });
                    }
                }
                finally
                {
                    Interlocked.Exchange(ref m_processing, 0);
                }
            }
        }

        void dataSubscriber_ConnectionEstablished(object sender, EventArgs e)
        {
            m_subscribed = true;
            SubscribeData();
        }

        void dataSubscriber_ConnectionTerminated(object sender, EventArgs e)
        {
            m_subscribed = false;
            UnsubscribeData();
            if (m_restartConnectionCycle)
                StartSubscription();
        }

        void dataSubscriber_ProcessException(object sender, TVA.EventArgs<Exception> e)
        {
            //System.Diagnostics.Debug.WriteLine("SUBSCRIPTION: EXCEPTION: " + e.Argument.Message);
        }

        void dataSubscriber_StatusMessage(object sender, TVA.EventArgs<string> e)
        {
            //System.Diagnostics.Debug.WriteLine("SUBSCRIPTION: " + e.Argument);
        }

        #endregion

        #endregion

        #region [ Methods ]

        void Initialize()
        {
            this.Unloaded += new RoutedEventHandler(HomePageUserControl_Unloaded);
            ComboBoxMeasurements.SelectionChanged += new SelectionChangedEventHandler(ComboBoxMeasurements_SelectionChanged);
            if (((App)Application.Current).Principal.IsInRole("Administrator, Editor"))
                ButtonAddDevice.IsEnabled = true;
            else
                ButtonAddDevice.IsEnabled = false;
        }

        void StartThirtySecondsTimer()
        {
            m_thirtySecondsTimer = new DispatcherTimer();
            m_thirtySecondsTimer.Interval = TimeSpan.FromSeconds(10);
            m_thirtySecondsTimer.Tick += new EventHandler(thirtySecondsTimer_Tick);
            m_thirtySecondsTimer.Start();
        }

        void GetDeviceDistributionList()
        {
            try
            {
                Dictionary<string, int> temp = CommonFunctions.GetVendorDeviceDistribution(null, ((App)Application.Current).NodeValue);
                foreach (KeyValuePair<string, int> pair in temp)
                {
                    if (m_deviceDistributionList.ContainsKey(pair.Key))
                        m_deviceDistributionList[pair.Key] = pair.Value;
                    else
                        m_deviceDistributionList.Add(pair.Key, pair.Value);
                }

                ChartDeviceDistribution.DataContext = m_deviceDistributionList;               //CommonFunctions.GetVendorDeviceDistribution(null, ((App)Application.Current).NodeValue);
                ChartDeviceDistribution.UpdateLayout();
                if (m_thirtySecondsTimer == null)
                    StartThirtySecondsTimer();
            }
            catch
            {

            }
            if (m_activityWindow != null)
                m_activityWindow.Close();
        }

        void GetInterconnectionStatus()
        {
            try
            {
                ItemControlInterconnectionStatus.ItemsSource = CommonFunctions.GetInterconnectionStatus(null, ((App)Application.Current).NodeValue);
                if (m_thirtySecondsTimer == null)
                    StartThirtySecondsTimer();
            }
            catch
            {

            }
            if (m_activityWindow != null)
                m_activityWindow.Close();
        }

        void GetFilteredMeasurementsByDevice()
        {
            try
            {
                ComboBoxMeasurements.ItemsSource = CommonFunctions.GetFilteredMeasurementsByDevice(null, ((KeyValuePair<int, string>)ComboBoxDevice.SelectedItem).Key);
                if (ComboBoxMeasurements.Items.Count > 0)
                    ComboBoxMeasurements.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetFilteredMeasurementsByDevice", ex);
                SystemMessages sm = new SystemMessages(new openPDCManager.Utilities.Message()
                {
                    UserMessage = "Failed to Retrieve Measurements for Device", SystemMessage = ex.Message, UserMessageType = openPDCManager.Utilities.MessageType.Error
                },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        void GetDevices()
        {
            try
            {
                ComboBoxDevice.ItemsSource = CommonFunctions.GetDevices(null, DeviceType.NonConcentrator, ((App)Application.Current).NodeValue, false);
                if (ComboBoxDevice.Items.Count > 0)
                    ComboBoxDevice.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetDevices", ex);
                SystemMessages sm = new SystemMessages(new openPDCManager.Utilities.Message()
                {
                    UserMessage = "Failed to Retrieve Devices", SystemMessage = ex.Message, UserMessageType = openPDCManager.Utilities.MessageType.Error
                },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        void ReconnectToService()
        {
            //reset time series data list
            timeSeriesDataList = new ObservableCollection<TimeSeriesDataPoint>();
            SubscribeData();
        }

        #endregion

        #region [ Control Event Handlers ]

        void ComboBoxMeasurements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxMeasurements.Items.Count > 0 && ComboBoxMeasurements.SelectedIndex >= 0)
            {
                openPDCManager.Data.Entities.Measurement measurement = (openPDCManager.Data.Entities.Measurement)ComboBoxMeasurements.SelectedItem;

                //This was done for WPF to make sure there are measurements available in the dropdown before calling time series data service. Otherwise ComboboxMeasurements.SelectedItem returned NULL.
                m_measurementForSubscription = measurement.HistorianAcronym + ":" + measurement.PointID;
                ReconnectToService();

                m_framesPerSecond = (int)measurement.FramesPerSecond;
                LinearAxis yAxis = (LinearAxis)ChartRealTimeData.Axes[1];
                if (measurement.SignalSuffix == "PA")
                {
                    yAxis.Minimum = -180;
                    yAxis.Maximum = 180;
                    yAxis.Interval = 60;
                }
                else
                {
                    yAxis.Minimum = Convert.ToDouble(IsolatedStorageManager.ReadFromIsolatedStorage("FrequencyRangeMin"));  // 59.95;
                    yAxis.Maximum = Convert.ToDouble(IsolatedStorageManager.ReadFromIsolatedStorage("FrequencyRangeMax"));  // 60.05;
                    yAxis.Interval = (yAxis.Maximum - yAxis.Minimum) / 5.0; // 0.02;
                }
            }
        }

        void HomePageUserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            m_restartConnectionCycle = false;
            UnsubscribeData();

            try
            {
                m_thirtySecondsTimer.Stop();
                m_thirtySecondsTimer = null;
            }
            catch
            {
            }
        }

        void thirtySecondsTimer_Tick(object sender, EventArgs e)
        {
            GetInterconnectionStatus();
            GetDeviceDistributionList();
        }

        #endregion
    }
}
