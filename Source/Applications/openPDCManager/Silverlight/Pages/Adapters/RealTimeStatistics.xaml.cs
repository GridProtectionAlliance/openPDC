//******************************************************************************************************
//  RealTimeStatistics.xaml.cs - Gbtc
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
//  07/23/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using openPDCManager.LivePhasorDataServiceProxy;
using openPDCManager.ModalDialogs;
using openPDCManager.PhasorDataServiceProxy;
using openPDCManager.Utilities;

namespace openPDCManager.Pages.Adapters
{
    public partial class RealTimeStatistics : Page
    {
        #region [ Members ]

        PhasorDataServiceClient m_client;
        DuplexServiceClient m_duplexClient;
        ActivityWindow m_activityWindow;
        ObservableCollection<StatisticMeasurementData> m_statisticMeasurementDataList;
        bool m_connected = false;

        #endregion

        #region [ Contructor ]

        public RealTimeStatistics()
        {
            InitializeComponent();
            m_client = ProxyClient.GetPhasorDataServiceProxyClient();
            m_client.GetStatisticMeasurementDataCompleted += new EventHandler<GetStatisticMeasurementDataCompletedEventArgs>(m_client_GetStatisticMeasurementDataCompleted);
            this.Loaded += new RoutedEventHandler(RealTimeStatistics_Loaded);

            m_duplexClient = ProxyClient.GetDuplexServiceProxyClient();
            m_duplexClient.SendToServiceCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(m_duplexClient_SendToServiceCompleted);
            m_duplexClient.SendToClientReceived += new EventHandler<SendToClientReceivedEventArgs>(m_duplexClient_SendToClientReceived);
        }
        
        #endregion

        #region [ Methods ]

        void ReconnectToService()
        {
            ConnectMessage msg = new ConnectMessage();
            msg.NodeID = ((App)Application.Current).NodeValue;
            msg.TimeSeriesDataRootUrl = ((App)Application.Current).TimeSeriesDataServiceUrl;
            msg.RealTimeStatisticRootUrl = ((App)Application.Current).RealTimeStatisticServiceUrl;
            msg.CurrentDisplayType = DisplayType.RealTimeStatistics;
            msg.DataPointID = 0;
            m_duplexClient.SendToServiceAsync(msg);
        }

        #endregion

        #region [ Service Event Handlers ]

        void m_client_GetStatisticMeasurementDataCompleted(object sender, GetStatisticMeasurementDataCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                m_statisticMeasurementDataList = e.Result;
                TreeViewRealTimeStatistics.ItemsSource = m_statisticMeasurementDataList;                
            }
            else
            {
                SystemMessages sm;
                if (e.Error is FaultException<CustomServiceFault>)
                {
                    FaultException<CustomServiceFault> fault = e.Error as FaultException<CustomServiceFault>;
                    sm = new SystemMessages(new Message() { UserMessage = fault.Detail.UserMessage, SystemMessage = fault.Detail.SystemMessage, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                }
                else
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to RetrieveStatistics Measurements Data", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }

            if (m_activityWindow != null)
                m_activityWindow.Close();

            ReconnectToService();
        }

        void m_duplexClient_SendToClientReceived(object sender, SendToClientReceivedEventArgs e)
        {
            if (e.msg is TimeTaggedDataMessage)
            {                
                Dictionary<int, TimeTaggedMeasurement> timeTaggedMeasurements = new Dictionary<int, TimeTaggedMeasurement>();
                timeTaggedMeasurements = (e.msg as TimeTaggedDataMessage).TimeTaggedMeasurements;

                if (timeTaggedMeasurements != null)
                {
                    TextBlockLastRefresh.Text = "Last Refresh: " + DateTime.Now.ToString();
                    foreach (StatisticMeasurementData statisticMeasurement in m_statisticMeasurementDataList)
                    {
                        foreach (StreamInfo streamInfo in statisticMeasurement.SourceStreamInfoList)
                        {
                            foreach (DeviceStatistic deviceStatistic in streamInfo.DeviceStatisticList)
                            {
                                foreach (DetailStatisticInfo detailStatistic in deviceStatistic.StatisticList)
                                {
                                    TimeTaggedMeasurement timeTaggedMeasurement;
                                    if (timeTaggedMeasurements.TryGetValue(detailStatistic.PointID, out timeTaggedMeasurement))
                                    {
                                        if (detailStatistic.Statistics.IsConnectedState == true)
                                        {
                                            if (Convert.ToBoolean(timeTaggedMeasurement.CurrentValue))
                                                streamInfo.StatusColor = "Green";
                                            else
                                                streamInfo.StatusColor = "Red";
                                        }
                                        detailStatistic.Statistics.Value = timeTaggedMeasurement.CurrentValue;
                                        detailStatistic.Statistics.TimeTag = timeTaggedMeasurement.TimeTag;
                                        detailStatistic.Statistics.Quality = timeTaggedMeasurement.Quality;
                                    }
                                }
                            }
                        }
                    }
                }
                TreeViewRealTimeStatistics.ItemsSource = m_statisticMeasurementDataList;                
            }
        }

        void m_duplexClient_SendToServiceCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
                m_connected = true;
        }

        #endregion

        #region [ Page Event Handlers ]

        void RealTimeStatistics_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            m_statisticMeasurementDataList = new ObservableCollection<StatisticMeasurementData>();
            m_activityWindow = new ActivityWindow("Loading Data... Please Wait...");
            m_activityWindow.Show();            
            m_client.GetStatisticMeasurementDataAsync(((App)Application.Current).NodeValue);
        }

        // Executes just before a page is no longer the active page in a frame.
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            if (m_connected)
                m_duplexClient.SendToServiceAsync(new DisconnectMessage());
            base.OnNavigatingFrom(e);
        }

        #endregion

    }
}
