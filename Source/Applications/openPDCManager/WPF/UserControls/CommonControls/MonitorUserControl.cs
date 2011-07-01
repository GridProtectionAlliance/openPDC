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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using openPDCManager.Data.ServiceCommunication;
using System.Windows;
using System.Threading;
using TVA.ServiceProcess;
using TVA;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
using System.Windows.Threading;
using openPDCManager.Data;

namespace openPDCManager.UserControls.CommonControls
{
    public partial class MonitorUserControl
    {
        #region [ Members ]

        WindowsServiceClient m_serviceClient;

        #endregion

        #region [ Methods ]

        void Initialize()
        {
            m_numberOfMessagesOnMonitor = IsolatedStorageManager.ReadFromIsolatedStorage("NumberOfMessages") == null ? 50 : Convert.ToInt32(IsolatedStorageManager.ReadFromIsolatedStorage("NumberOfMessages"));
            this.Unloaded += new RoutedEventHandler(MonitorUserControl_Unloaded);
            if (((App)Application.Current).Principal.IsInRole("Administrator"))
                ButtonSendServiceRequest.IsEnabled = true;
            else
                ButtonSendServiceRequest.IsEnabled = false;
        }

        void MonitorUserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            if (m_serviceClient != null)
            {
                m_serviceClient.Helper.ReceivedServiceUpdate -= Helper_ReceivedServiceUpdate;
                m_serviceClient.Helper.ReceivedServiceResponse -= Helper_ReceivedServiceResponse;
            }
            //m_serviceClient.Dispose();
        }

        void SendRequest()
        {            
            if (m_serviceClient.Helper.RemotingClient.CurrentState == TVA.Communication.ClientState.Connected)
                m_serviceClient.Helper.SendRequest(TextBoxServiceRequest.Text);            
        }

        public void ReconnectToService()
        {
            //m_serviceClient = new WindowsServiceClient(((App)Application.Current).RemoteStatusServiceUrl);
            //m_serviceClient.Helper.RemotingClient.MaxConnectionAttempts = 10;
            
            m_serviceClient = ((App)Application.Current).ServiceClient;
            if (m_serviceClient != null)
            {
                m_serviceClient.Helper.ReceivedServiceUpdate += new EventHandler<TVA.EventArgs<UpdateType, string>>(Helper_ReceivedServiceUpdate);        // += ClientHelper_ReceivedServiceUpdate;
                m_serviceClient.Helper.ReceivedServiceResponse += new EventHandler<TVA.EventArgs<ServiceResponse>>(Helper_ReceivedServiceResponse);          //+= ClientHelper_ReceivedServiceResponse;
                ConnectWindowsServiceClient(m_serviceClient);
            }
        }

        void Helper_ReceivedServiceResponse(object sender, TVA.EventArgs<ServiceResponse> e)
        {
            string response = e.Argument.Type;
            string message = e.Argument.Message;
            string responseToClient = string.Empty;
            UpdateType responseType = UpdateType.Information;                        

            if (!string.IsNullOrEmpty(response))
            {
                // Reponse types are formatted as "Command:Success" or "Command:Failure"
                string[] parts = response.Split(':');
                string action;
                bool success;

                if (parts.Length > 1)
                {
                    action = parts[0].Trim().ToTitleCase();
                    success = (string.Compare(parts[1].Trim(), "Success", true) == 0);
                }
                else
                {
                    action = response;
                    success = true;
                }

                if (success)
                {
                    if (string.IsNullOrEmpty(message))
                        responseToClient = string.Format("{0} command processed successfully.\r\n\r\n", action);
                    else
                        responseToClient = string.Format("{0}\r\n\r\n", message);
                }
                else
                {
                    responseType = UpdateType.Alarm;
                    if (string.IsNullOrEmpty(message))
                        responseToClient = string.Format("{0} failure.\r\n\r\n", action);
                    else
                        responseToClient = string.Format("{0} failure: {1}\r\n\r\n", action, message);
                }

                DisplayMessage(responseType, responseToClient);
            }
        }

        void Helper_ReceivedServiceUpdate(object sender, TVA.EventArgs<UpdateType, string> e)
        {
            DisplayMessage(e.Argument1, e.Argument2);
        }

        void ConnectWindowsServiceClient(object state)
        {
            //try
            //{
            //    ((WindowsServiceClient)state).Helper.Connect();
            //}
            //catch (Exception ex)
            //{
            //    CommonFunctions.LogException(null, "WPF.ConnectWindowsServiceClient", ex);
            //    SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Connect to Windows Service (" + ((App)Application.Current).RemoteStatusServiceUrl + ").", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
            //            ButtonType.OkOnly);                
            //    sm.Owner = Window.GetWindow(this);
            //    sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;                
            //    sm.ShowPopup();
            //}

            if (((WindowsServiceClient)state).Helper.RemotingClient.CurrentState == TVA.Communication.ClientState.Connected)
                DisplayMessage(UpdateType.Information, ((WindowsServiceClient)state).CachedStatus);
            else
                DisplayMessage(UpdateType.Alarm, "Failed to Connect to openPDC Windows Service (" + ((App)Application.Current).RemoteStatusServiceUrl + ").");

            if (m_activityWindow != null)
                m_activityWindow.Close();
        }

        void DisplayMessage(UpdateType updateType, string message)
        {
            TextBoxServiceStatus.Dispatcher.BeginInvoke(new DisplayHelper(RefreshTextBlock), new object[] { updateType, message });
        }

        private delegate void DisplayHelper(UpdateType updateType, string message);

        void RefreshTextBlock(UpdateType updateType, string message)
        {
            //TextBoxServiceStatus.Text += message;
            Run run;
            if (updateType == UpdateType.Information)
            {
                run = new Run();
                run.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                run.Text = message;
            }
            else if (updateType == UpdateType.Warning)
            {
                run = new Run();
                run.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 0));
                run.Text = message;
            }
            else
            {
                run = new Run();
                run.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 10, 10));
                run.Text = message;
            }

            TextBoxServiceStatus.Inlines.Add(run);
            if (m_activityWindow != null)
                m_activityWindow.Close();

            if (TextBoxServiceStatus.Inlines.Count > m_numberOfMessagesOnMonitor)
                TextBoxServiceStatus.Inlines.Remove(TextBoxServiceStatus.Inlines.FirstInline);

            TextBoxServiceStatus.UpdateLayout();
            ScrollViewerMonitor.UpdateLayout();	//this is required to keep scroll-bar at the bottom.
            ScrollViewerMonitor.ScrollToVerticalOffset(TextBoxServiceStatus.ActualHeight * 2);
        }

        #endregion

    }
}
