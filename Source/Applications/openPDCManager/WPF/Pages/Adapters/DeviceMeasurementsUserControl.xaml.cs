//******************************************************************************************************
//  DeviceMeasurementsUserControl.xaml.cs - Gbtc
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
//  07/22/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using openPDCManager.Data;
using openPDCManager.Data.BusinessObjects;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
using TimeSeriesFramework;
using TimeSeriesFramework.Transport;
using TVA;

namespace openPDCManager.Pages.Adapters
{
    /// <summary>
    /// Interaction logic for DeviceMeasurementsUserControl.xaml
    /// </summary>
    public partial class DeviceMeasurementsUserControl : UserControl
    {
        #region [ Members ]

        ActivityWindow m_activityWindow;
        ObservableCollection<DeviceMeasurementData> m_deviceMeasurementDataList;
        DeviceMeasurementDataForBinding m_dataForBinding;
        int m_refreshInterval = 10;

        //Subscription API related declarations.
        DataSubscriber m_dataSubscriber;
        bool m_subscribed;
        int m_processing;
        bool m_restartConnectionCycle = true;
        string m_measurementForSubscription;

        #endregion

        #region [ Constructor ]

        public DeviceMeasurementsUserControl()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(DeviceMeasurementsUserControl_Loaded);
            this.Unloaded += new RoutedEventHandler(DeviceMeasurementsUserControl_Unloaded);
            m_dataForBinding = new DeviceMeasurementDataForBinding();
            m_deviceMeasurementDataList = new ObservableCollection<DeviceMeasurementData>();
        }

        #endregion

        #region [ Page Event Handlers ]

        void DeviceMeasurementsUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            m_activityWindow = new ActivityWindow("Loading Data... Please Wait...");
            m_activityWindow.Owner = Window.GetWindow(this);
            m_activityWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            m_activityWindow.Show();
            GetDeviceMeasurementData();
            int.TryParse(IsolatedStorageManager.ReadFromIsolatedStorage("MeasurementsDataRefreshInterval").ToString(), out m_refreshInterval);
            TextBlockRefreshInterval.Text = "Refresh Interval: " + m_refreshInterval.ToString() + " sec";
        }

        void DeviceMeasurementsUserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            m_restartConnectionCycle = false;
            UnsubscribeData();
        }

        #endregion

        #region [ Methods ]

        void GetDeviceMeasurementData()
        {
            try
            {
                m_deviceMeasurementDataList = CommonFunctions.GetDeviceMeasurementData(null, ((App)Application.Current).NodeValue);
                m_dataForBinding.DeviceMeasurementDataList = m_deviceMeasurementDataList;

                StringBuilder sb = new StringBuilder();
                foreach (DeviceMeasurementData deviceMeasurementData in m_deviceMeasurementDataList)
                {
                    foreach (DeviceInfo deviceInfo in deviceMeasurementData.DeviceList)
                    {
                        foreach (MeasurementInfo measurementInfo in deviceInfo.MeasurementList)
                            sb.Append(measurementInfo.HistorianAcronym + ":" + measurementInfo.PointID + ";");
                    }
                }

                m_measurementForSubscription = sb.ToString();
                if (m_measurementForSubscription.Length > 0)
                    m_measurementForSubscription = m_measurementForSubscription.Substring(0, m_measurementForSubscription.Length - 1);

                m_dataForBinding.IsExpanded = false;
                TreeViewDeviceMeasurements.DataContext = m_dataForBinding;

                SubscribeData();
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
                m_dataSubscriber.UnsynchronizedSubscribe(true, true, m_measurementForSubscription, null, true, (double)m_refreshInterval);
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
                    foreach (DeviceMeasurementData deviceMeasurementData in m_deviceMeasurementDataList)
                    {
                        foreach (DeviceInfo deviceInfo in deviceMeasurementData.DeviceList)
                        {
                            foreach (MeasurementInfo measurementInfo in deviceInfo.MeasurementList)
                            {
                                foreach (IMeasurement measurement in e.Argument)
                                {
                                    if (measurement.ID.ToString().ToUpper() == measurementInfo.SignalID.ToUpper())
                                    {
                                        measurementInfo.CurrentQuality = measurement.ValueQualityIsGood() ? "GOOD" : "BAD";
                                        measurementInfo.CurrentTimeTag = measurement.Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                        measurementInfo.CurrentValue = measurement.Value.ToString("0.###");
                                    }
                                }
                            }
                        }
                    }
                    TreeViewDeviceMeasurements.Dispatcher.BeginInvoke((Action)delegate()
                    {
                        TreeViewDeviceMeasurements.Items.Refresh();
                        m_dataForBinding.IsExpanded = true;
                        m_dataForBinding.DeviceMeasurementDataList = m_deviceMeasurementDataList;
                        TreeViewDeviceMeasurements.DataContext = m_dataForBinding;
                    });
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

    }
}
