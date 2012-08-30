//******************************************************************************************************
//  AdapterUserControl.cs - Gbtc
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
//  07/08/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//  06/30/2011 - Stephen C. Wills - applying changes from Jian (Ryan) Zuo
//       Modified SaveAdapter() to send the ReloadConfig command to the Windows service.
//
//******************************************************************************************************

using System;
using System.Windows;
using openPDCManager.Data;
using openPDCManager.Data.Entities;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
using openPDCManager.Data.ServiceCommunication;
using System.Collections.Generic;
using System.Threading;

namespace openPDCManager.UserControls.CommonControls
{
    public partial class AdapterUserControl
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
               
        void GetNodes()
        {
            try
            {
                ComboboxNode.ItemsSource = CommonFunctions.GetNodes(null, true, false);
              if (ComboboxNode.Items.Count > 0)
                  ComboboxNode.SelectedIndex = 0;
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

        void GetAdapterList()
        {
            try
            {
                ListBoxAdapterList.ItemsSource = CommonFunctions.GetAdapterList(null, false, m_adapterType, m_nodeID);
                if (ListBoxAdapterList.Items.Count > 0)
                    ListBoxAdapterList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetAdapterList", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Adapter List", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                         ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }
        }

        void SaveAdapter(Adapter adapter, bool isNew)
        {
            SystemMessages sm;
            try
            {
                string result = CommonFunctions.SaveAdapter(null, adapter, isNew);                              
                sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                       ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
                GetAdapterList();  
                //ClearForm();

                //make this newly added or updated item as default selected. So user can click initialize right away.                
                ListBoxAdapterList.SelectedItem = ((List<Adapter>)ListBoxAdapterList.ItemsSource).Find(c => c.AdapterName == adapter.AdapterName);

                // Update Metadata in the openPDC Service.
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
                    CommonFunctions.LogException(null, "SaveAdapter.RefreshMetadata", ex);
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.SaveAdapter", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Adapter Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }                        
        }

        void DisplayRuntimeID()
        {
            if (m_adapterType == AdapterType.Action)
                TextBlockRuntimeID.Text = CommonFunctions.GetRuntimeID(null, "CustomActionAdapter", m_adapterID);
            else if (m_adapterType == AdapterType.Input)
                TextBlockRuntimeID.Text = CommonFunctions.GetRuntimeID(null, "CustomInputAdapter", m_adapterID);
            else if (m_adapterType == AdapterType.Output)
                TextBlockRuntimeID.Text = CommonFunctions.GetRuntimeID(null, "CustomOutputAdapter", m_adapterID);
        }

        #endregion
    }
}
