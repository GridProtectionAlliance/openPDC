//******************************************************************************************************
//  HistoriansUserControl.cs - Gbtc
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
//  07/09/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Windows;
using openPDCManager.Data;
using openPDCManager.Data.Entities;
using openPDCManager.Data.ServiceCommunication;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;

namespace openPDCManager.UserControls.CommonControls
{
    public partial class HistoriansUserControl
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
            try
            {
                if (serviceClient != null && serviceClient.Helper.RemotingClient.CurrentState == TVA.Communication.ClientState.Connected)
                {
                    string result = CommonFunctions.SendCommandToWindowsService(serviceClient, "Initialize " + TextBlockRuntimeID.Text);
                    sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = "", UserMessageType = MessageType.Success }, ButtonType.OkOnly);
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

        void GetHistorians()
        {
            try
            {
                ListBoxHistorianList.ItemsSource = CommonFunctions.GetHistorianList(null, m_nodeID);
                if (ListBoxHistorianList.Items.Count > 0 && ListBoxHistorianList.SelectedIndex < 0)
                    ListBoxHistorianList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetHistorianList", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Historian Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }
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
                sm.ShowPopup();
            }
        }

        void SaveHistorian(Historian historian, bool isNew)
        {
            try
            {
                bool continueSave = true;

                if (!isNew)
                {
                    if ((m_typeName == "HistorianAdapters.LocalOutputAdapter" && historian.TypeName != m_typeName) ||
                        (m_isLocal && !historian.IsLocal))
                    {
                        SystemMessages sm = new SystemMessages(new Message() { UserMessage = "You are changing your historian type.", SystemMessage = "You are changing your historian type from an in-process local historian to another historian provider. Please note that once the changes are applied, any customizations you may have made to the in-process local historian in the openPDC configuration file will be lost." + Environment.NewLine + "Do you want to continue?", UserMessageType = MessageType.Confirmation }, ButtonType.YesNo);
                        sm.Closed += new EventHandler(delegate(object popupWindow, EventArgs eargs)
                        {
                            if ((bool)sm.DialogResult)
                                continueSave = true;
                            else
                                continueSave = false;
                        });
                        sm.Owner = Window.GetWindow(this);
                        sm.ShowPopup();
                    }
                }

                if (continueSave)
                {
                    string result = CommonFunctions.SaveHistorian(null, historian, isNew);
                    SystemMessages sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                            ButtonType.OkOnly);
                    sm.Owner = Window.GetWindow(this);
                    sm.ShowPopup();
                    GetHistorians();
                    //make this newly added or updated item as default selected. So user can click initialize right away.
                    ListBoxHistorianList.SelectedItem = ((List<Historian>)ListBoxHistorianList.ItemsSource).Find(c => c.Acronym == historian.Acronym);
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.SaveHistorian", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Historian Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }
        }

        void DisplayRuntimeID()
        {
            TextBlockRuntimeID.Text = CommonFunctions.GetRuntimeID(null, "Historian", m_historianID);
        }

        #endregion
    }
}
