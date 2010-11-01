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
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls.DataVisualization.Charting;
using openPDCManager.LivePhasorDataServiceProxy;
using openPDCManager.ModalDialogs;
using openPDCManager.PhasorDataServiceProxy;
using openPDCManager.Utilities;
using System.Windows.Controls;

namespace openPDCManager.UserControls.CommonControls
{
    public partial class HomePageUserControl
    {
        #region [ Members ]

        DuplexServiceClient m_duplexClient;
        PhasorDataServiceClient m_client;
        bool m_connected = false;
        ObservableCollection<InterconnectionStatus> interconnectionStatusList = new ObservableCollection<InterconnectionStatus>();
        ObservableCollection<TimeSeriesDataPoint> timeSeriesDataList = new ObservableCollection<TimeSeriesDataPoint>();
        public Page ParentPage;

        #endregion

        #region [ Methods ]

        void Initialize()
        {
            m_duplexClient = ProxyClient.GetDuplexServiceProxyClient();
            m_duplexClient.SendToServiceCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(duplexClient_SendToServiceCompleted);
            m_duplexClient.SendToClientReceived += new EventHandler<SendToClientReceivedEventArgs>(duplexClient_SendToClientReceived);

            m_client = ProxyClient.GetPhasorDataServiceProxyClient();
            m_client.GetDevicesCompleted += new EventHandler<GetDevicesCompletedEventArgs>(m_client_GetDevicesCompleted);
            m_client.GetFilteredMeasurementsByDeviceCompleted += new EventHandler<GetFilteredMeasurementsByDeviceCompletedEventArgs>(m_client_GetFilteredMeasurementsByDeviceCompleted);
        }

        void GetFilteredMeasurementsByDevice()
        {
            m_client.GetFilteredMeasurementsByDeviceAsync(((KeyValuePair<int, string>)ComboBoxDevice.SelectedItem).Key);
        }

        void GetDevices()
        {
            m_client.GetDevicesAsync(DeviceType.NonConcentrator, ((App)Application.Current).NodeValue, false);            
        }

        void ReconnectToService()
        {
            //if (m_connected)
            //    m_duplexClient.SendToServiceAsync(new DisconnectMessage());

            ConnectMessage msg = new ConnectMessage();
            msg.NodeID = ((App)Application.Current).NodeValue;
            msg.TimeSeriesDataRootUrl = ((App)Application.Current).TimeSeriesDataServiceUrl;	// "http://localhost:6152/historian/timeseriesdata/read/";		
            msg.RealTimeStatisticRootUrl = ((App)Application.Current).RealTimeStatisticServiceUrl;
            msg.CurrentDisplayType = DisplayType.Home;
            if (ComboBoxMeasurements.Items.Count > 0)
            {
                msg.DataPointID = ((Measurement)ComboBoxMeasurements.SelectedItem).PointID;
                m_framesPerSecond = (int)((Measurement)ComboBoxMeasurements.SelectedItem).FramesPerSecond;
                LinearAxis yAxis = (LinearAxis)ChartRealTimeData.Axes[1];
                if (((Measurement)ComboBoxMeasurements.SelectedItem).SignalSuffix == "PA")
                {
                    yAxis.Minimum = -180;
                    yAxis.Maximum = 180;
                    yAxis.Interval = 60;
                }
                else
                {
                    yAxis.Minimum = 59.95;
                    yAxis.Maximum = 60.05;
                    yAxis.Interval = 0.02;
                }
            }
            else
                msg.DataPointID = 0;

            SendToService(msg);

            //reset time series data list
            timeSeriesDataList = new ObservableCollection<TimeSeriesDataPoint>();
        }

        void SendToService(DuplexMessage message)
        {
            m_duplexClient.SendToServiceAsync(message);
        }
        
        #endregion

        #region [ Service Event Handlers ]

        void m_client_GetFilteredMeasurementsByDeviceCompleted(object sender, GetFilteredMeasurementsByDeviceCompletedEventArgs e)
        {
            if (e.Error == null)
                ComboBoxMeasurements.ItemsSource = e.Result;
            else
            {
                SystemMessages sm;
                if (e.Error is FaultException<CustomServiceFault>)
                {
                    FaultException<CustomServiceFault> fault = e.Error as FaultException<CustomServiceFault>;
                    sm = new SystemMessages(new openPDCManager.Utilities.Message() { UserMessage = fault.Detail.UserMessage, SystemMessage = fault.Detail.SystemMessage, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                }
                else
                    sm = new SystemMessages(new openPDCManager.Utilities.Message() { UserMessage = "Failed to Retrieve Measurements for Device", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.ShowPopup();
            }

            if (ComboBoxMeasurements.Items.Count > 0)
            {
                ComboBoxMeasurements.SelectedIndex = 0;

            }
            ReconnectToService();
        }

        void m_client_GetDevicesCompleted(object sender, GetDevicesCompletedEventArgs e)
        {
            if (e.Error == null)
                ComboBoxDevice.ItemsSource = e.Result;
            else
            {
                SystemMessages sm;
                if (e.Error is FaultException<CustomServiceFault>)
                {
                    FaultException<CustomServiceFault> fault = e.Error as FaultException<CustomServiceFault>;
                    sm = new SystemMessages(new openPDCManager.Utilities.Message() { UserMessage = fault.Detail.UserMessage, SystemMessage = fault.Detail.SystemMessage, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                }
                else
                    sm = new SystemMessages(new openPDCManager.Utilities.Message() { UserMessage = "Failed to Retrieve Devices", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.ShowPopup();
            }

            if (ComboBoxDevice.Items.Count > 0)
                ComboBoxDevice.SelectedIndex = 0;
            else	//If devices are not available then we will send connect message to service as device selection changed and measurements received events dont fire.
                ReconnectToService();
        }

        void duplexClient_SendToServiceCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
                m_connected = true;
        }

        void duplexClient_SendToClientReceived(object sender, SendToClientReceivedEventArgs e)
        {
            if (e.msg is LivePhasorDataMessage)
            {
                LivePhasorDataMessage livePhasorData = (LivePhasorDataMessage)e.msg;

                //pmuDistributionList = livePhasorData.PmuDistributionList;		        				
                interconnectionStatusList = livePhasorData.InterconnectionStatusList;

                Dictionary<string, int> temp = livePhasorData.DeviceDistributionList;
                foreach (KeyValuePair<string, int> pair in temp)
                {
                    if (m_deviceDistributionList.ContainsKey(pair.Key))
                        m_deviceDistributionList[pair.Key] = pair.Value;
                    else
                        m_deviceDistributionList.Add(pair.Key, pair.Value);
                }

                //ItemsControlPmuDistribution.ItemsSource = pmuDistributionList;
                ChartDeviceDistribution.DataContext = m_deviceDistributionList;
                ChartDeviceDistribution.UpdateLayout();
                ItemControlInterconnectionStatus.ItemsSource = interconnectionStatusList;
            }
            else if (e.msg is TimeSeriesDataMessage)
            {
                if (((TimeSeriesDataMessage)e.msg).TimeSeriesData.Count > m_framesPerSecond)
                {
                    for (int i = 0; i < (int)((TimeSeriesDataMessage)e.msg).TimeSeriesData.Count / m_framesPerSecond; i++)
                    {
                        if (timeSeriesDataList.Count == 0)
                            timeSeriesDataList.Add(new TimeSeriesDataPoint() { Index = 0, Value = ((TimeSeriesDataMessage)e.msg).TimeSeriesData[(i * m_framesPerSecond)].Value });
                        else
                            timeSeriesDataList.Add(new TimeSeriesDataPoint() { Index = timeSeriesDataList[timeSeriesDataList.Count - 1].Index + 1, Value = ((TimeSeriesDataMessage)e.msg).TimeSeriesData[(i * m_framesPerSecond)].Value });
                    }
                }
                else if (((TimeSeriesDataMessage)e.msg).TimeSeriesData.Count > 0)
                {
                    if (timeSeriesDataList.Count == 0)
                        timeSeriesDataList.Add(new TimeSeriesDataPoint() { Index = 0, Value = ((TimeSeriesDataMessage)e.msg).TimeSeriesData[0].Value });
                    else
                        timeSeriesDataList.Add(new TimeSeriesDataPoint() { Index = timeSeriesDataList[timeSeriesDataList.Count - 1].Index + 1, Value = ((TimeSeriesDataMessage)e.msg).TimeSeriesData[0].Value });
                }
                if (timeSeriesDataList.Count > 30)
                    timeSeriesDataList.RemoveAt(0);

                ChartRealTimeData.DataContext = timeSeriesDataList;
            }
            if (m_activityWindow != null)
                m_activityWindow.Close();
        }

        #endregion
    }
}
