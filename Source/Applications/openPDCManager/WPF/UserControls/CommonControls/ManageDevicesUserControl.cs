//******************************************************************************************************
//  ManageDevicesUserControl.cs - Gbtc
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
//  07/14/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using openPDCManager.Data;
using openPDCManager.Data.Entities;
using openPDCManager.Data.ServiceCommunication;
using openPDCManager.ModalDialogs;
using openPDCManager.Pages.Devices;
using openPDCManager.Utilities;

namespace openPDCManager.UserControls.CommonControls
{
    public partial class ManageDevicesUserControl
    {
        #region [ Members ]

        WindowsServiceClient serviceClient;
        string m_oldDeviceName;

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
                    string result = CommonFunctions.SendCommandToWindowsService(serviceClient, "Initialize " + Convert.ToInt32(TextBlockRuntimeID.Text));
                    sm = new SystemMessages(new Message()
                    {
                        UserMessage = result, SystemMessage = "", UserMessageType = MessageType.Success
                    }, ButtonType.OkOnly);
                    CommonFunctions.SendCommandToWindowsService(serviceClient, "Invoke 0 ReloadStatistics");
                }
                else
                    sm = new SystemMessages(new Message()
                    {
                        UserMessage = "Application is disconnected", SystemMessage = "Connection String: " + ((App)Application.Current).RemoteStatusServiceUrl, UserMessageType = MessageType.Error
                    }, ButtonType.OkOnly);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.SendInitialize", ex);
                sm = new SystemMessages(new Message()
                {
                    UserMessage = "Failed to Send Initialize Command", SystemMessage = ex.Message, UserMessageType = MessageType.Error
                },
                        ButtonType.OkOnly);
            }
            sm.Owner = Window.GetWindow(this);
            sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            sm.ShowPopup();
        }

        public void GetDeviceByDeviceID(int deviceID)
        {
            try
            {
                m_deviceToEdit = new Device();
                m_deviceToEdit = CommonFunctions.GetDeviceByDeviceID(null, deviceID);
                m_oldDeviceName = m_deviceToEdit.Name;
                m_oldAcronym = m_deviceToEdit.Acronym;
                PopulateFormFields(m_deviceToEdit);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetDeviceByDeviceID", ex);
                SystemMessages sm = new SystemMessages(new Message()
                {
                    UserMessage = "Failed to Retrieve Device Information by ID", SystemMessage = ex.Message, UserMessageType = MessageType.Error
                },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
            if (m_activityWindow != null)
                m_activityWindow.Close();
        }

        void PopulateFormFields(Device device)
        {
            GridDeviceDetail.DataContext = device;

            if (ComboboxNode.Items.Count > 0)
                ComboboxNode.SelectedItem = new KeyValuePair<string, string>(device.NodeID, device.NodeName);

            if (device.CompanyID.HasValue)
                ComboboxCompany.SelectedItem = new KeyValuePair<int, string>((int)device.CompanyID, device.CompanyName);
            else if (ComboboxCompany.Items.Count > 0)
                ComboboxCompany.SelectedIndex = 0;

            if (device.HistorianID.HasValue)
                ComboboxHistorian.SelectedItem = new KeyValuePair<int, string>((int)device.HistorianID, device.HistorianAcronym);
            else if (ComboboxHistorian.Items.Count > 0)
                ComboboxHistorian.SelectedIndex = 0;

            if (device.InterconnectionID.HasValue)
                ComboboxInterconnection.SelectedItem = new KeyValuePair<int, string>((int)device.InterconnectionID, device.InterconnectionName);
            else if (ComboboxInterconnection.Items.Count > 0)
                ComboboxInterconnection.SelectedIndex = 0;

            if (device.ParentID.HasValue)
                ComboboxParent.SelectedItem = new KeyValuePair<int, string>((int)device.ParentID, device.ParentAcronym);
            else if (ComboboxParent.Items.Count > 0)
                ComboboxParent.SelectedIndex = 0;

            if (device.ProtocolID.HasValue)
                ComboboxProtocol.SelectedItem = new KeyValuePair<int, string>((int)device.ProtocolID, device.ProtocolName);
            else if (ComboboxProtocol.Items.Count > 0)
                ComboboxProtocol.SelectedIndex = 0;

            if (string.IsNullOrEmpty(device.TimeZone) && ComboboxTimeZone.Items.Count > 0)
                ComboboxTimeZone.SelectedIndex = 0;
            else
            {
                foreach (KeyValuePair<string, string> item in ComboboxTimeZone.Items)
                {
                    if (item.Key == device.TimeZone)
                    {
                        ComboboxTimeZone.SelectedItem = item;
                        break;
                    }
                }
            }
            if (device.VendorDeviceID.HasValue)
                ComboboxVendorDevice.SelectedItem = new KeyValuePair<int, string>((int)device.VendorDeviceID, device.VendorDeviceName);
            else if (ComboboxVendorDevice.Items.Count > 0)
                ComboboxVendorDevice.SelectedIndex = 0;

            if (device.IsConcentrator)	//then display list of devices.
            {
                GetDeviceListByParentID(device.ID);
                StackPanelDeviceList.Visibility = Visibility.Visible;
                StackPanelPhasorsMeassurements.Visibility = Visibility.Collapsed;
                TextBlockTitle.Text = "Devices For Concentrator: " + device.Acronym;
            }
            else
            {
                StackPanelPhasorsMeassurements.Visibility = Visibility.Visible;
                StackPanelDeviceList.Visibility = Visibility.Collapsed;
            }

            //Get rid of alternate command channel from connection string to display it in it's own textbox.
            int indexOfCommandChannel = device.ConnectionString.ToLower().IndexOf("commandchannel");

            if (indexOfCommandChannel > 0)
            {
                TextBoxConnectionString.Text = device.ConnectionString.Substring(0, indexOfCommandChannel);
                TextBoxAlternateCommandChannel.Text = device.ConnectionString.Substring(indexOfCommandChannel + 15).Replace("{", "").Replace("}", "");
            }
            else
                TextBoxConnectionString.Text = device.ConnectionString;

            TextBlockRuntimeID.Text = CommonFunctions.GetRuntimeID(null, "Device", device.ID);

            TextBoxAcronym.SelectAll();
            TextBoxAcronym.Focus();
        }

        public void GetConcentratorDevice(int deviceID)
        {
            try
            {
                Device device = new Device();
                device = CommonFunctions.GetConcentratorDevice(null, deviceID);
                ToolTip toolTip = new ToolTip();
                toolTip.DataContext = device;
                toolTip.Template = Application.Current.Resources["PdcInfoToolTipTemplate"] as ControlTemplate;
                ToolTipService.SetToolTip(ButtonView, toolTip);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetConcentratorDevice", ex);
            }
        }

        public void GetDeviceListByParentID(int parentID)
        {
            try
            {
                ListBoxDeviceList.ItemsSource = CommonFunctions.GetDeviceListByParentID(null, parentID);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetDeviceListByParentID", ex);
                SystemMessages sm = new SystemMessages(new Message()
                {
                    UserMessage = "Failed to Retrieve Device List By Parent ID", SystemMessage = ex.Message, UserMessageType = MessageType.Error
                },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        public void GetDevices(DeviceType deviceType, string nodeID, bool isOptional)
        {
            try
            {
                ComboboxParent.ItemsSource = CommonFunctions.GetDevices(null, deviceType, nodeID, isOptional);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetDevices", ex);
                SystemMessages sm = new SystemMessages(new Message()
                {
                    UserMessage = "Failed to Retrieve Devices", SystemMessage = ex.Message, UserMessageType = MessageType.Error
                },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
            if (ComboboxParent.Items.Count > 0)
                ComboboxParent.SelectedIndex = 0;
        }

        public void GetCompanies()
        {
            try
            {
                ComboboxCompany.ItemsSource = CommonFunctions.GetCompanies(null, true);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetCompanies", ex);
                SystemMessages sm = new SystemMessages(new Message()
                {
                    UserMessage = "Failed to Retrieve Companies", SystemMessage = ex.Message, UserMessageType = MessageType.Error
                },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
            if (ComboboxCompany.Items.Count > 0)
                ComboboxCompany.SelectedIndex = 0;
        }

        public void GetNodes()
        {
            try
            {
                ComboboxNode.ItemsSource = CommonFunctions.GetNodes(null, true, false);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetNodes", ex);
                SystemMessages sm = new SystemMessages(new Message()
                {
                    UserMessage = "Failed to Retrieve Nodes", SystemMessage = ex.Message, UserMessageType = MessageType.Error
                },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
            if (ComboboxNode.Items.Count > 0)
                ComboboxNode.SelectedIndex = 0;
        }

        public void GetHistorians()
        {
            try
            {
                ComboboxHistorian.ItemsSource = CommonFunctions.GetHistorians(null, true, true, false);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetHistorians", ex);
                SystemMessages sm = new SystemMessages(new Message()
                {
                    UserMessage = "Failed to Retrieve Historians", SystemMessage = ex.Message, UserMessageType = MessageType.Error
                },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
            if (ComboboxHistorian.Items.Count > 0)
                ComboboxHistorian.SelectedIndex = 0;
        }

        public void GetInterconnections()
        {
            try
            {
                ComboboxInterconnection.ItemsSource = CommonFunctions.GetInterconnections(null, true);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetInterconnections", ex);
                SystemMessages sm = new SystemMessages(new Message()
                {
                    UserMessage = "Failed to Retrieve Interconnections", SystemMessage = ex.Message, UserMessageType = MessageType.Error
                },
                       ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
            if (ComboboxInterconnection.Items.Count > 0)
                ComboboxInterconnection.SelectedIndex = 0;
        }

        public void GetVendorDevices()
        {
            try
            {
                ComboboxVendorDevice.ItemsSource = CommonFunctions.GetVendorDevices(null, true);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetVendorDevices", ex);
                SystemMessages sm = new SystemMessages(new Message()
                {
                    UserMessage = "Failed to Retrieve Vendor Devices", SystemMessage = ex.Message, UserMessageType = MessageType.Error
                },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
            if (ComboboxVendorDevice.Items.Count > 0)
                ComboboxVendorDevice.SelectedIndex = 0;
        }

        public void GetProtocols()
        {
            try
            {
                ComboboxProtocol.ItemsSource = CommonFunctions.GetProtocols(null, true);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetProtocols", ex);
                SystemMessages sm = new SystemMessages(new Message()
                {
                    UserMessage = "Failed to Retrieve Protocols", SystemMessage = ex.Message, UserMessageType = MessageType.Error
                },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
            if (ComboboxProtocol.Items.Count > 0)
                ComboboxProtocol.SelectedIndex = 0;
        }

        public void GetTimeZones()
        {
            try
            {
                ComboboxTimeZone.ItemsSource = CommonFunctions.GetTimeZones(true);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetTimeZones", ex);
                SystemMessages sm = new SystemMessages(new Message()
                {
                    UserMessage = "Failed to Retrieve Time Zones", SystemMessage = ex.Message, UserMessageType = MessageType.Error
                },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
            if (ComboboxTimeZone.Items.Count > 0)
                ComboboxTimeZone.SelectedIndex = 0;
        }

        public void SaveDevice(Device device, bool isNew, int digitalCount, int analogCount)
        {
            SystemMessages sm;
            DataConnection connection = new DataConnection();
            try
            {
                string result = CommonFunctions.SaveDevice(connection, device, isNew, digitalCount, analogCount);

                //get the ID of the new device added to the system so we can associate that ID to the phasors of the original device.
                int deviceID;
                if (isNew)
                    deviceID = CommonFunctions.GetDeviceByAcronym(connection, device.Acronym).ID;
                else
                    deviceID = device.ID;

                if (m_deviceToCopy != null && isNew) //if we are copying device then make sure we copy phasors also.
                {
                    List<Phasor> phasorList = CommonFunctions.GetPhasorList(connection, m_deviceToCopy.ID);
                    foreach (Phasor phasor in phasorList)
                    {
                        phasor.DeviceID = deviceID;
                        CommonFunctions.SavePhasor(connection, phasor, true);
                    }
                }

                sm = new SystemMessages(new Message()
                {
                    UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success
                },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();

                //update statistic measurement for a device if device is being updated and acronym has changed.
                try
                {
                    if (!isNew && !string.IsNullOrEmpty(m_oldAcronym) && m_oldAcronym != device.Acronym)
                    {
                        CommonFunctions.UpdateDeviceStatistics(connection, deviceID, m_oldAcronym, device.Acronym, m_oldDeviceName, device.Name);

                        //also if acronym has changed then make those changes
                    }
                }
                catch (Exception ex)
                {
                    CommonFunctions.LogException(connection, "WPF.UpdateDeviceStatistics", ex);
                    sm = new SystemMessages(new Message()
                    {
                        UserMessage = "Failed to Update Device Statistics", SystemMessage = ex.Message, UserMessageType = MessageType.Error
                    },
                           ButtonType.OkOnly);
                    sm.Owner = Window.GetWindow(this);
                    sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    sm.ShowPopup();
                }


                //Update Metadata in the openPDC Service.                
                try
                {
                    if (serviceClient != null && serviceClient.Helper.RemotingClient.CurrentState == TVA.Communication.ClientState.Connected)
                    {
                        if (device.Enabled) //if device is enabled then send initialize command otherwise send reloadconfig command.
                            CommonFunctions.SendCommandToWindowsService(serviceClient, "Initialize " + CommonFunctions.GetRuntimeID(connection, "Device", deviceID)); // Convert.ToInt32(TextBlockRuntimeID.Text));
                        else
                            CommonFunctions.SendCommandToWindowsService(serviceClient, "ReloadConfig"); //we do this to make sure all statistical measurements are in the system.

                        if (device.HistorianID != null) //Update historian metadata
                        {
                            string runtimeID = CommonFunctions.GetRuntimeID(connection, "Historian", (int)device.HistorianID);
                            CommonFunctions.SendCommandToWindowsService(serviceClient, "Invoke " + runtimeID + " RefreshMetadata");
                        }

                        //now also update Stat historian metadata.
                        Historian statHistorian = CommonFunctions.GetHistorianByAcronym(connection, "STAT");
                        if (statHistorian != null)
                        {
                            string statRuntimeID = CommonFunctions.GetRuntimeID(connection, "Historian", statHistorian.ID);
                            CommonFunctions.SendCommandToWindowsService(serviceClient, "Invoke " + statRuntimeID + " RefreshMetadata");
                        }

                        CommonFunctions.SendCommandToWindowsService(serviceClient, "Invoke 0 ReloadStatistics");
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
                    CommonFunctions.LogException(connection, "SaveDevice.RefreshMetadata", ex);
                }

                ClearForm();
                //Navigate to Browse screen upon successful save.
                BrowseDevicesUserControl browseDevices = new BrowseDevicesUserControl();
                ((MasterLayoutWindow)Window.GetWindow(this)).ContentFrame.Navigate(browseDevices);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(connection, "WPF.SaveDevice", ex);
                sm = new SystemMessages(new Message()
                {
                    UserMessage = "Failed to Save Device Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error
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


        #endregion
    }
}
