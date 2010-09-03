//******************************************************************************************************
//  MonitorUserControl.cs - Gbtc
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
//  07/26/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using openPDCManager.LivePhasorDataServiceProxy;
using openPDCManager.Utilities;

namespace openPDCManager.UserControls.CommonControls
{
    public partial class MonitorUserControl
    {
        #region [ Members ]

        DuplexServiceClient m_duplexClient;
        bool m_connected = false;

        #endregion

        #region [ Methods ]

        void Initialize()
        {
            m_duplexClient = ProxyClient.GetDuplexServiceProxyClient();
            m_duplexClient.SendToServiceCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(m_duplexClient_SendToServiceCompleted);
            m_duplexClient.SendToClientReceived += new EventHandler<SendToClientReceivedEventArgs>(m_duplexClient_SendToClientReceived);
            m_numberOfMessagesOnMonitor = IsolatedStorageManager.LoadFromIsolatedStorage("NumberOfMessagesOnMonitor") == null ? 50 : Convert.ToInt32(IsolatedStorageManager.LoadFromIsolatedStorage("NumberOfMessagesOnMonitor"));
        }

        void SendRequest()
        {
            ServiceRequestMessage message = new ServiceRequestMessage() { Request = TextBoxServiceRequest.Text };
            SendToService(message);
        }

        void SendToService(DuplexMessage message)
        {
            m_duplexClient.SendToServiceAsync(message);
        }

        void ReconnectToService()
        {
            ConnectMessage msg = new ConnectMessage();
            msg.NodeID = ((App)Application.Current).NodeValue;
            msg.TimeSeriesDataRootUrl = ((App)Application.Current).TimeSeriesDataServiceUrl;	// "http://localhost:6152/historian/timeseriesdata/read/";
            msg.RealTimeStatisticRootUrl = ((App)Application.Current).RealTimeStatisticServiceUrl;
            msg.CurrentDisplayType = DisplayType.ServiceClient;
            msg.DataPointID = 0;
            m_duplexClient.SendToServiceAsync(msg);
        }

        public void Disconnect()
        {
            if (m_connected)
            {
                try
                {
                    m_duplexClient.SendToServiceAsync(new DisconnectMessage());
                }
                catch { }
            }
        }

        #endregion

        #region [ Service Event Handlers ]

        void m_duplexClient_SendToClientReceived(object sender, SendToClientReceivedEventArgs e)
        {
            if (e.msg is ServiceUpdateMessage)
            {
                string message = ((ServiceUpdateMessage)e.msg).ServiceUpdate;

                if (((ServiceUpdateMessage)e.msg).ServiceUpdateType == UpdateType.Information)
                {
                    //	TextBoxServiceStatus.Text += ((ServiceUpdateMessage)e.msg).ServiceUpdate;
                    Run run = new Run();
                    run.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    run.Text = message;
                    TextBoxServiceStatus.Inlines.Add(run);
                }
                else if (((ServiceUpdateMessage)e.msg).ServiceUpdateType == UpdateType.Warning)
                {
                    Run run = new Run();
                    run.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 0));
                    run.Text = message;
                    TextBoxServiceStatus.Inlines.Add(run);
                }
                else
                {
                    Run run = new Run();
                    run.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 10, 10));
                    run.Text = message;
                    TextBoxServiceStatus.Inlines.Add(run);
                }
            }

            if (TextBoxServiceStatus.Inlines.Count > m_numberOfMessagesOnMonitor)
                TextBoxServiceStatus.Inlines.RemoveAt(0);

            if (m_activityWindow != null)
                m_activityWindow.Close();

            ScrollViewerMonitor.UpdateLayout();	//this is required to keep scroll-bar at the bottom.
            ScrollViewerMonitor.ScrollToVerticalOffset(TextBoxServiceStatus.ActualHeight * 2);
            //ScrollViewerMonitor.ScrollToBottom();
        }

        void m_duplexClient_SendToServiceCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
                m_connected = true;
        }

        #endregion
    }
}
