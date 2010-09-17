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
using System.Linq;
using System.Text;
using openPDCManager.Data;
using openPDCManager.Data.Entities;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
using System.Windows.Controls;
using System.Windows;
using openPDCManager.Data.ServiceCommunication;
using openPDCManager.Pages.Devices;

namespace openPDCManager.UserControls.CommonControls
{
    public partial class ManageDevicesUserControl
    {
        #region [ Members ]

        WindowsServiceClient serviceClient;

        #endregion

        #region [ Methods ]

        void Initialize()
        {            
            serviceClient = ((App)Application.Current).ServiceClient;         
        }

        void SendInitialize()
        {
            SystemMessages sm;
            try
            {                
                if (serviceClient != null && serviceClient.Helper.RemotingClient.CurrentState == TVA.Communication.ClientState.Connected)
                {
                    string result = CommonFunctions.SendCommandToWindowsService(serviceClient, "Initialize " + Convert.ToInt32(TextBlockRuntimeID.Text));
                    sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = "", UserMessageType = MessageType.Success }, ButtonType.OkOnly);
                    CommonFunctions.SendCommandToWindowsService(serviceClient, "Invoke 0 ReloadStatistics");
                }
                else
                    sm = new SystemMessages(new Message() { UserMessage = "Application is disconnected", SystemMessage = "Connection String: " + ((App)Application.Current).RemoteStatusServiceUrl, UserMessageType = MessageType.Error }, ButtonType.OkOnly);             
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.SendInitialize", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Send Initialize Command", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
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
                m_deviceToEdit = CommonFunctions.GetDeviceByDeviceID(deviceID);
                GridDeviceDetail.DataContext = m_deviceToEdit;

                if (ComboboxNode.Items.Count > 0)
                    ComboboxNode.SelectedItem = new KeyValuePair<string, string>(m_deviceToEdit.NodeID, m_deviceToEdit.NodeName);

                if (m_deviceToEdit.CompanyID.HasValue)
                    ComboboxCompany.SelectedItem = new KeyValuePair<int, string>((int)m_deviceToEdit.CompanyID, m_deviceToEdit.CompanyName);
                else if (ComboboxCompany.Items.Count > 0)
                    ComboboxCompany.SelectedIndex = 0;

                if (m_deviceToEdit.HistorianID.HasValue)
                    ComboboxHistorian.SelectedItem = new KeyValuePair<int, string>((int)m_deviceToEdit.HistorianID, m_deviceToEdit.HistorianAcronym);
                else if (ComboboxHistorian.Items.Count > 0)
                    ComboboxHistorian.SelectedIndex = 0;

                if (m_deviceToEdit.InterconnectionID.HasValue)
                    ComboboxInterconnection.SelectedItem = new KeyValuePair<int, string>((int)m_deviceToEdit.InterconnectionID, m_deviceToEdit.InterconnectionName);
                else if (ComboboxInterconnection.Items.Count > 0)
                    ComboboxInterconnection.SelectedIndex = 0;

                if (m_deviceToEdit.ParentID.HasValue)
                    ComboboxParent.SelectedItem = new KeyValuePair<int, string>((int)m_deviceToEdit.ParentID, m_deviceToEdit.ParentAcronym);
                else if (ComboboxParent.Items.Count > 0)
                    ComboboxParent.SelectedIndex = 0;

                if (m_deviceToEdit.ProtocolID.HasValue)
                    ComboboxProtocol.SelectedItem = new KeyValuePair<int, string>((int)m_deviceToEdit.ProtocolID, m_deviceToEdit.ProtocolName);
                else if (ComboboxProtocol.Items.Count > 0)
                    ComboboxProtocol.SelectedIndex = 0;

                if (string.IsNullOrEmpty(m_deviceToEdit.TimeZone) && ComboboxTimeZone.Items.Count > 0)
                    ComboboxTimeZone.SelectedIndex = 0;
                else
                {
                    foreach (KeyValuePair<string, string> item in ComboboxTimeZone.Items)
                    {
                        if (item.Key == m_deviceToEdit.TimeZone)
                        {
                            ComboboxTimeZone.SelectedItem = item;
                            break;
                        }
                    }
                }
                if (m_deviceToEdit.VendorDeviceID.HasValue)
                    ComboboxVendorDevice.SelectedItem = new KeyValuePair<int, string>((int)m_deviceToEdit.VendorDeviceID, m_deviceToEdit.VendorDeviceName);
                else if (ComboboxVendorDevice.Items.Count > 0)
                    ComboboxVendorDevice.SelectedIndex = 0;

                if (m_deviceToEdit.IsConcentrator)	//then display list of devices.
                {
                    GetDeviceListByParentID(m_deviceToEdit.ID);
                    StackPanelDeviceList.Visibility = Visibility.Visible;
                    StackPanelPhasorsMeassurements.Visibility = Visibility.Collapsed;
                    TextBlockTitle.Text = "Devices For Concentrator: " + m_deviceToEdit.Acronym;
                }
                else
                {
                    StackPanelPhasorsMeassurements.Visibility = Visibility.Visible;
                    StackPanelDeviceList.Visibility = Visibility.Collapsed;
                }

                TextBlockRuntimeID.Text = CommonFunctions.GetRuntimeID("Device", deviceID);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.GetDeviceByDeviceID", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Device Information by ID", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
            if (m_activityWindow != null)
                m_activityWindow.Close();
        }

        public void GetConcentratorDevice(int deviceID)
        {
            try
            {
                Device device = new Device();
                device = CommonFunctions.GetConcentratorDevice(deviceID);                 
                ToolTip toolTip = new ToolTip();
                toolTip.DataContext = device;
                toolTip.Template = Application.Current.Resources["PdcInfoToolTipTemplate"] as ControlTemplate;
                ToolTipService.SetToolTip(ButtonView, toolTip);               
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.GetConcentratorDevice", ex);
            }
        }

        public void GetDeviceListByParentID(int parentID)
        {
            try
            {
                ListBoxDeviceList.ItemsSource = CommonFunctions.GetDeviceListByParentID(parentID);     
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.GetDeviceListByParentID", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Device List By Parent ID", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
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
                ComboboxParent.ItemsSource = CommonFunctions.GetDevices(deviceType, nodeID, isOptional);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.GetDevices", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Devices", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
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
                ComboboxCompany.ItemsSource = CommonFunctions.GetCompanies(true);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.GetCompanies", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Companies", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
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
                ComboboxNode.ItemsSource = CommonFunctions.GetNodes(true, false);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.GetNodes", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Nodes", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
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
                ComboboxHistorian.ItemsSource = CommonFunctions.GetHistorians(true, true, false);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.GetHistorians", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Historians", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
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
                ComboboxInterconnection.ItemsSource = CommonFunctions.GetInterconnections(true);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.GetInterconnections", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Interconnections", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
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
                ComboboxVendorDevice.ItemsSource = CommonFunctions.GetVendorDevices(true);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.GetVendorDevices", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Vendor Devices", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
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
                ComboboxProtocol.ItemsSource = CommonFunctions.GetProtocols(true);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.GetProtocols", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Protocols", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
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
                CommonFunctions.LogException("WPF.GetTimeZones", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Time Zones", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
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
            try
            {
                string result = CommonFunctions.SaveDevice(device, isNew, digitalCount, analogCount);
                
                sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();

                //Update Metadata in the openPDC Service.                
                try
                {                    
                    if (serviceClient != null && serviceClient.Helper.RemotingClient.CurrentState == TVA.Communication.ClientState.Connected)
                    {
                        if (device.HistorianID != null) //Update historian metadata
                        {
                            string runtimeID = CommonFunctions.GetRuntimeID("Historian", (int)device.HistorianID);
                            CommonFunctions.SendCommandToWindowsService(serviceClient, "Invoke " + runtimeID + " refreshmetadata");
                        }

                        //now also update Stat historian metadata.
                        Historian statHistorian = CommonFunctions.GetHistorianByAcronym("STAT");
                        if (statHistorian != null)
                        {
                            string statRuntimeID = CommonFunctions.GetRuntimeID("Historian", statHistorian.ID);
                            CommonFunctions.SendCommandToWindowsService(serviceClient, "Invoke " + statRuntimeID + " refreshmetadata");
                        }

                        if (device.Enabled) //if device is enabled then send initialize command otherwise send reloadconfig command.
                            CommonFunctions.SendCommandToWindowsService(serviceClient, "Initialize " + Convert.ToInt32(TextBlockRuntimeID.Text));
                        else 
                            CommonFunctions.SendCommandToWindowsService(serviceClient, "ReloadConfig"); //we do this to make sure all statistical measurements are in the system.

                        CommonFunctions.SendCommandToWindowsService(serviceClient, "Invoke 0 ReloadStatistics");
                    }
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
                    CommonFunctions.LogException("SaveDevice.RefreshMetadata", ex);
                }

                ClearForm();
                //Navigate to Browse screen upon successful save.
                BrowseDevicesUserControl browseDevices = new BrowseDevicesUserControl();
                ((MasterLayoutWindow)Window.GetWindow(this)).ContentFrame.Navigate(browseDevices);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.SaveDevice", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Device Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                       ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }


        #endregion
    }
}
