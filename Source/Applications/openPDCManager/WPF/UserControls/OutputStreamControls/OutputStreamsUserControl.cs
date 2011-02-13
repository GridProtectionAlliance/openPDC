//******************************************************************************************************
//  OutputStreamsUserControl.cs - Gbtc
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
//  07/29/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Windows;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
using openPDCManager.Data;
using openPDCManager.Data.Entities;
using openPDCManager.Data.ServiceCommunication;
using System.Collections.Generic;
using System.Threading;

namespace openPDCManager.UserControls.OutputStreamControls
{
    public partial class OutputStreamsUserControl
    {
        #region [ Members ]

        WindowsServiceClient serviceClient;

        #endregion

        #region [ Methods ]

        void Initialize()
        {            
            serviceClient = ((App)Application.Current).ServiceClient;
            if (((App)Application.Current).Principal.IsInRole("Administrator, Editor"))
            {
                ButtonSave.IsEnabled = true;
                ButtonInitialize.IsEnabled = true;
            }
            else
            {
                ButtonSave.IsEnabled = false;
                ButtonInitialize.IsEnabled = false;
            }
        }

        void SendInitialize()
        {
            SystemMessages sm;
            if (((App)Application.Current).Principal.IsInRole("Administrator, Editor"))
            {
                try
                {
                    if (serviceClient != null && serviceClient.Helper.RemotingClient.CurrentState == TVA.Communication.ClientState.Connected)
                    {
                        string result = CommonFunctions.SendCommandToWindowsService(serviceClient, "Initialize " + TextBlockRuntimeID.Text);
                        sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = "", UserMessageType = MessageType.Success }, ButtonType.OkOnly);
                        CommonFunctions.SendCommandToWindowsService(serviceClient, "Invoke 0 ReloadStatistics");
                    }
                    else
                        sm = new SystemMessages(new Message() { UserMessage = "Application is disconnected", SystemMessage = "Connection String: " + ((App)Application.Current).RemoteStatusServiceUrl, UserMessageType = MessageType.Error }, ButtonType.OkOnly);
                }
                catch (Exception ex)
                {
                    CommonFunctions.LogException(null, "WPF.SendInitialize", ex);
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Send Initialize Command", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                            ButtonType.OkOnly);
                }
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
            else
            {
                sm = new SystemMessages(new Message() { UserMessage = "Unauthorized Access", SystemMessage = "You are not authorized to perform this operation.", UserMessageType = MessageType.Error },
                            ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        void SendUpdateConfiguration(int outputStreamID)
        {
            SystemMessages sm;
            if (((App)Application.Current).Principal.IsInRole("Administrator, Editor"))
            {
                try
                {
                    if (serviceClient != null && serviceClient.Helper.RemotingClient.CurrentState == TVA.Communication.ClientState.Connected)
                    {
                        string runtimeID = CommonFunctions.GetRuntimeID(null, "OutputStream", outputStreamID);
                        string result = CommonFunctions.SendCommandToWindowsService(serviceClient, "reloadconfig");
                        result = CommonFunctions.SendCommandToWindowsService(serviceClient, "Invoke " + runtimeID + " UpdateConfiguration");
                        sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = "", UserMessageType = MessageType.Success }, ButtonType.OkOnly);
                    }
                    else
                        sm = new SystemMessages(new Message() { UserMessage = "Application is disconnected", SystemMessage = "Connection String: " + ((App)Application.Current).RemoteStatusServiceUrl, UserMessageType = MessageType.Error }, ButtonType.OkOnly);
                }
                catch (Exception ex)
                {
                    CommonFunctions.LogException(null, "WPF.SendUpdateConfiguration", ex);
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Update Configuration", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                            ButtonType.OkOnly);
                }
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
            else
            {
                sm = new SystemMessages(new Message() { UserMessage = "Unauthorized Access", SystemMessage = "You are not authorized to perform this operation.", UserMessageType = MessageType.Error },
                            ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        void DisplayRuntimeID()
        {
            TextBlockRuntimeID.Text = CommonFunctions.GetRuntimeID(null, "OutputStream", m_outputStreamID);
        }

        void GetNodes()
        {
            try
            {
                ComboBoxNode.ItemsSource = CommonFunctions.GetNodes(null, true, false);
                if (ComboBoxNode.Items.Count > 0)
                    ComboBoxNode.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetNodes", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Nodes", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }            
        }

        void GetOutputStreamList()
        {
            try
            {
                ListBoxOutputStreamList.ItemsSource = CommonFunctions.GetOutputStreamList(null, false, m_nodeValue);
                if (ListBoxOutputStreamList.Items.Count > 0)
                    ListBoxOutputStreamList.SelectedIndex = 0;
                else
                    ClearForm();
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetOutputStreamList", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Output Stream List", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        void SaveOutputStream(OutputStream outputStream, bool isNew)
        {
            SystemMessages sm;
            try
            {
                string result = CommonFunctions.SaveOutputStream(null, outputStream, isNew);
                
                sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();

                //if acronym is updated then update related statistics measurements too.
                if (!isNew)
                {
                    try
                    {
                        CommonFunctions.UpdateOutputStreamStatistics(null, ((App)Application.Current).NodeValue, m_oldAcronym, outputStream.Acronym, m_oldName, outputStream.Name);
                    }
                    catch (Exception ex)
                    {
                        sm = new SystemMessages(new openPDCManager.Utilities.Message() { UserMessage = "Failed to Update Output Stream Statistics", SystemMessage = ex.Message, UserMessageType = openPDCManager.Utilities.MessageType.Information }, ButtonType.OkOnly);
                        sm.Owner = Window.GetWindow(this);
                        sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        sm.ShowPopup();
                        CommonFunctions.LogException(null, "UpdateOutputStreamStatistics", ex);
                    }
                }

                GetOutputStreamList();
                //ClearForm();

                //make this newly added or updated item as default selected. So user can click initialize right away.
                ListBoxOutputStreamList.SelectedItem = ((List<OutputStream>)ListBoxOutputStreamList.ItemsSource).Find(c => c.Acronym == outputStream.Acronym);
                
                //Update Metadata in the openPDC Service.
                try
                {
                    if (serviceClient != null && serviceClient.Helper.RemotingClient.CurrentState == TVA.Communication.ClientState.Connected)
                        CommonFunctions.SendCommandToWindowsService(serviceClient, "ReloadConfig"); //we do this to make sure all statistical measurements are in the system.
                    else
                    {
                        sm = new SystemMessages(new openPDCManager.Utilities.Message() { UserMessage = "Failed to Perform Configuration Changes", SystemMessage = "Application is disconnected from the openPDC Service.", UserMessageType = openPDCManager.Utilities.MessageType.Information }, ButtonType.OkOnly);
                        sm.Owner = Window.GetWindow(this);
                        sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        sm.ShowPopup();
                    }
                }
                catch (Exception ex)
                {
                    sm = new SystemMessages(new openPDCManager.Utilities.Message() { UserMessage = "Failed to Perform Configuration Changes", SystemMessage = ex.Message, UserMessageType = openPDCManager.Utilities.MessageType.Information }, ButtonType.OkOnly);
                    sm.Owner = Window.GetWindow(this);
                    sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    sm.ShowPopup();
                    CommonFunctions.LogException(null, "SaveOutputStream.RefreshMetadata", ex);
                }

            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.SaveOutputStream", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Output Stream Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }                        
        }

        void DeleteOutputStream(int outputStreamID)
        {
            SystemMessages sm;
            try
            {
                string result = CommonFunctions.DeleteOutputStream(null, outputStreamID);
                sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.DeleteOutputStream", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Delete Output Stream Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
            }
            sm.Owner = Window.GetWindow(this);
            sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            sm.ShowPopup();
            GetOutputStreamList();
        }

        #endregion
    }
}
