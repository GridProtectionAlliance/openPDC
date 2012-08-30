//******************************************************************************************************
//  PhasorsUserControl.cs - Gbtc
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
//  08/31/2010 - Mehulbhai P Thakkar
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
    public partial class PhasorsUserControl
    {
        #region [ Methods ]

        void Initialize()
        {
            if (((App)Application.Current).Principal.IsInRole("Administrator, Editor"))
                ButtonSave.IsEnabled = true;
            else
                ButtonSave.IsEnabled = false;
        }

        void SavePhasor(Phasor phasor, bool isNew)
        {
            SystemMessages sm;
            DataConnection connection = new DataConnection();
            ;
            try
            {
                string result = CommonFunctions.SavePhasor(connection, phasor, isNew);
                //ClearForm();
                sm = new SystemMessages(new Message()
                {
                    UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success
                },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();

                GetPhasors();
                GetPhasorList();

                //make this newly added or updated item as default selected. So user can click initialize right away.
                ListBoxPhasorList.SelectedItem = ((List<Phasor>)ListBoxPhasorList.ItemsSource).Find(c => c.Label == phasor.Label);

                //Update Metadata in the openPDC Service.
                try
                {
                    Device device = CommonFunctions.GetDeviceByDeviceID(connection, phasor.DeviceID);
                    WindowsServiceClient serviceClient = ((App)Application.Current).ServiceClient;

                    if (serviceClient != null && serviceClient.Helper.RemotingClient.CurrentState == TVA.Communication.ClientState.Connected)
                    {
                        if (device.HistorianID != null)
                        {
                            string runtimeID = CommonFunctions.GetRuntimeID(connection, "Historian", (int)device.HistorianID);
                            CommonFunctions.SendCommandToWindowsService(serviceClient, "Invoke " + runtimeID + " RefreshMetadata");
                        }

                        if (device.Enabled) //if device is enabled then send initialize command otherwise send reloadconfig command.
                        {
                            if (device.ParentID == null)
                                CommonFunctions.SendCommandToWindowsService(serviceClient, "Initialize " + CommonFunctions.GetRuntimeID(connection, "Device", device.ID));
                            else
                                CommonFunctions.SendCommandToWindowsService(serviceClient, "Initialize " + CommonFunctions.GetRuntimeID(connection, "Device", (int)device.ParentID));
                        }
                        else
                            CommonFunctions.SendCommandToWindowsService(serviceClient, "ReloadConfig"); //we do this to make sure all statistical measurements are in the system.

                        CommonFunctions.SendCommandToWindowsService(serviceClient, "RefreshRoutes");
                    }
                    else
                    {
                        sm = new SystemMessages(new openPDCManager.Utilities.Message()
                        {
                            UserMessage = "Failed to Perform Configuration Changes", SystemMessage = "Application is disconnected from the openPDC Service.", UserMessageType = openPDCManager.Utilities.MessageType.Information
                        }, ButtonType.OkOnly);
                        sm.Owner = Window.GetWindow(this);
                        sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        sm.ShowPopup();
                    }
                }
                catch (Exception ex)
                {
                    sm = new SystemMessages(new openPDCManager.Utilities.Message()
                    {
                        UserMessage = "Failed to Perform Configuration Changes", SystemMessage = ex.Message, UserMessageType = openPDCManager.Utilities.MessageType.Information
                    }, ButtonType.OkOnly);
                    sm.Owner = Window.GetWindow(this);
                    sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    sm.ShowPopup();
                    CommonFunctions.LogException(null, "SavePhasor.RefreshMetadata", ex);
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(connection, "WPF.SavePhasor", ex);
                sm = new SystemMessages(new Message()
                {
                    UserMessage = "Failed to Save Phasor Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error
                },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }
        }

        void GetPhasors()
        {
            try
            {
                ComboboxDestinationPhasor.ItemsSource = CommonFunctions.GetPhasors(null, m_sourceDeviceID, true);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetPhasors", ex);
                SystemMessages sm = new SystemMessages(new Message()
                {
                    UserMessage = "Failed to Retrieve Phasors", SystemMessage = ex.Message, UserMessageType = MessageType.Error
                },
                       ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
            if (ComboboxDestinationPhasor.Items.Count > 0)
                ComboboxDestinationPhasor.SelectedIndex = 0;
        }

        void GetPhasorList()
        {
            try
            {
                ListBoxPhasorList.ItemsSource = CommonFunctions.GetPhasorList(null, m_sourceDeviceID);
                if (ListBoxPhasorList.Items.Count > 0)
                    ListBoxPhasorList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetPhasorList", ex);
                SystemMessages sm = new SystemMessages(new Message()
                {
                    UserMessage = "Failed to Retrieve Phasor List", SystemMessage = ex.Message, UserMessageType = MessageType.Error
                },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        #endregion
    }
}
