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
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using openPDCManager.ModalDialogs;
using openPDCManager.PhasorDataServiceProxy;
using openPDCManager.Utilities;
using System.Windows.Navigation;

namespace openPDCManager.UserControls.CommonControls
{
    public partial class ManageDevicesUserControl
    {
        #region [ Members ]

        PhasorDataServiceClient m_client;

        #endregion

        #region [ Methods ]

        void Initialize()
        {
            m_client = ProxyClient.GetPhasorDataServiceProxyClient();
            m_client.GetDevicesCompleted += new EventHandler<GetDevicesCompletedEventArgs>(client_GetDevicesCompleted);
            m_client.GetCompaniesCompleted += new EventHandler<GetCompaniesCompletedEventArgs>(client_GetCompaniesCompleted);
            m_client.GetNodesCompleted += new EventHandler<GetNodesCompletedEventArgs>(client_GetNodesCompleted);
            m_client.GetHistoriansCompleted += new EventHandler<GetHistoriansCompletedEventArgs>(client_GetHistoriansCompleted);
            m_client.GetInterconnectionsCompleted += new EventHandler<GetInterconnectionsCompletedEventArgs>(client_GetInterconnectionsCompleted);
            m_client.GetVendorDevicesCompleted += new EventHandler<GetVendorDevicesCompletedEventArgs>(client_GetVendorDevicesCompleted);
            m_client.GetProtocolsCompleted += new EventHandler<GetProtocolsCompletedEventArgs>(client_GetProtocolsCompleted);
            m_client.GetTimeZonesCompleted += new EventHandler<GetTimeZonesCompletedEventArgs>(client_GetTimeZonesCompleted);
            m_client.SaveDeviceCompleted += new EventHandler<SaveDeviceCompletedEventArgs>(client_SaveDeviceCompleted);
            m_client.GetDeviceByDeviceIDCompleted += new EventHandler<GetDeviceByDeviceIDCompletedEventArgs>(client_GetDeviceByDeviceIDCompleted);
            m_client.GetConcentratorDeviceCompleted += new EventHandler<GetConcentratorDeviceCompletedEventArgs>(client_GetConcentratorDeviceCompleted);
            m_client.GetDeviceListByParentIDCompleted += new EventHandler<GetDeviceListByParentIDCompletedEventArgs>(client_GetDeviceListByParentIDCompleted);
        }

        public void GetDeviceByDeviceID(int deviceID)
        {
            m_client.GetDeviceByDeviceIDAsync(deviceID);
        }

        public void GetConcentratorDevice(int deviceID)
        {
            m_client.GetConcentratorDeviceAsync(deviceID);
        }

        public void GetDeviceListByParentID(int parentID)
        {
            m_client.GetDeviceListByParentIDAsync(parentID);
        }

        public void GetDevices(DeviceType deviceType, string nodeID, bool isOptional)
        {
            m_client.GetDevicesAsync(deviceType, nodeID, isOptional);
        }

        public void GetCompanies()
        {
            m_client.GetCompaniesAsync(true);
        }

        public void GetNodes()
        {
            m_client.GetNodesAsync(true, false);
        }

        public void GetHistorians()
        {
            m_client.GetHistoriansAsync(true, true);
        }

        public void GetInterconnections()
        {
            m_client.GetInterconnectionsAsync(true);
        }

        public void GetVendorDevices()
        {
            m_client.GetVendorDevicesAsync(true);
        }

        public void GetProtocols()
        {
            m_client.GetProtocolsAsync(true);
        }

        public void GetTimeZones()
        {
            m_client.GetTimeZonesAsync(true);
        }

        public void SaveDevice(Device device, bool isNew, int digitalCount, int analogCount)
        {
            m_client.SaveDeviceAsync(device, isNew, digitalCount, analogCount);
        }


        #endregion

        #region [ Service Event Handlers ]

        void client_GetDeviceListByParentIDCompleted(object sender, GetDeviceListByParentIDCompletedEventArgs e)
        {
            if (e.Error == null)
                ListBoxDeviceList.ItemsSource = e.Result;
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Device List By Parent ID", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
        }

        void client_GetConcentratorDeviceCompleted(object sender, GetConcentratorDeviceCompletedEventArgs e)
        {
            if (e.Error == null && e.Result != null)
            {
                Device device = new Device();
                device = e.Result;
                ToolTip toolTip = new ToolTip();
                toolTip.DataContext = device;
                toolTip.Template = Application.Current.Resources["PdcInfoToolTipTemplate"] as ControlTemplate;
                ToolTipService.SetToolTip(ButtonView, toolTip);
            }
        }

        void client_GetDeviceByDeviceIDCompleted(object sender, GetDeviceByDeviceIDCompletedEventArgs e)
        {
            m_deviceToEdit = new Device();
            if (e.Error == null)
            {
                //System.Threading.Thread.Sleep(3000);
                m_deviceToEdit = e.Result;
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Device Information by ID", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
            if (m_activityWindow != null)
                m_activityWindow.Close();
        }

        void client_SaveDeviceCompleted(object sender, SaveDeviceCompletedEventArgs e)
        {
            SystemMessages sm;
            if (e.Error == null)
            {
                ClearForm();
                sm = new SystemMessages(new Message() { UserMessage = e.Result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
                System.Windows.Browser.HtmlPage.Window.Navigate(new Uri("/Default.aspx#/Pages/Devices/Browse.xaml", UriKind.Relative));
            }
            else
            {
                if (e.Error is FaultException<CustomServiceFault>)
                {
                    FaultException<CustomServiceFault> fault = e.Error as FaultException<CustomServiceFault>;
                    sm = new SystemMessages(new Message() { UserMessage = fault.Detail.UserMessage, SystemMessage = fault.Detail.SystemMessage, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                }
                else
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Device Information", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
            }
            sm.ShowPopup();            
        }

        void client_GetTimeZonesCompleted(object sender, GetTimeZonesCompletedEventArgs e)
        {
            if (e.Error == null)
                ComboboxTimeZone.ItemsSource = e.Result;
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Time Zones", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
            if (ComboboxTimeZone.Items.Count > 0)
                ComboboxTimeZone.SelectedIndex = 0;

            if (m_deviceToEdit != null)
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
        }

        void client_GetProtocolsCompleted(object sender, GetProtocolsCompletedEventArgs e)
        {
            if (e.Error == null)
                ComboboxProtocol.ItemsSource = e.Result;
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Protocols", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
            if (ComboboxProtocol.Items.Count > 0)
                ComboboxProtocol.SelectedIndex = 0;

            if (m_deviceToEdit != null && m_deviceToEdit.ProtocolID.HasValue)
                ComboboxProtocol.SelectedItem = new KeyValuePair<int, string>((int)m_deviceToEdit.ProtocolID, m_deviceToEdit.ProtocolName);

        }

        void client_GetVendorDevicesCompleted(object sender, GetVendorDevicesCompletedEventArgs e)
        {
            if (e.Error == null)
                ComboboxVendorDevice.ItemsSource = e.Result;
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Vendor Devices", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
            if (ComboboxVendorDevice.Items.Count > 0)
                ComboboxVendorDevice.SelectedIndex = 0;

            if (m_deviceToEdit != null && m_deviceToEdit.VendorDeviceID.HasValue)
                ComboboxVendorDevice.SelectedItem = new KeyValuePair<int, string>((int)m_deviceToEdit.VendorDeviceID, m_deviceToEdit.VendorDeviceName);
        }

        void client_GetInterconnectionsCompleted(object sender, GetInterconnectionsCompletedEventArgs e)
        {
            if (e.Error == null)
                ComboboxInterconnection.ItemsSource = e.Result;
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Interconnections", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
            if (ComboboxInterconnection.Items.Count > 0)
                ComboboxInterconnection.SelectedIndex = 0;

            if (m_deviceToEdit != null && m_deviceToEdit.InterconnectionID.HasValue)
                ComboboxInterconnection.SelectedItem = new KeyValuePair<int, string>((int)m_deviceToEdit.InterconnectionID, m_deviceToEdit.InterconnectionName);
        }

        void client_GetHistoriansCompleted(object sender, GetHistoriansCompletedEventArgs e)
        {
            if (e.Error == null)
                ComboboxHistorian.ItemsSource = e.Result;
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Historians", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
            if (ComboboxHistorian.Items.Count > 0)
                ComboboxHistorian.SelectedIndex = 0;

            if (m_deviceToEdit != null && m_deviceToEdit.HistorianID.HasValue)
                ComboboxHistorian.SelectedItem = new KeyValuePair<int, string>((int)m_deviceToEdit.HistorianID, m_deviceToEdit.HistorianAcronym);
        }

        void client_GetNodesCompleted(object sender, GetNodesCompletedEventArgs e)
        {
            if (e.Error == null)
                ComboboxNode.ItemsSource = e.Result;
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Nodes", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
            if (ComboboxNode.Items.Count > 0)
                ComboboxNode.SelectedIndex = 0;

            if (m_deviceToEdit != null)
                ComboboxNode.SelectedItem = new KeyValuePair<string, string>(m_deviceToEdit.NodeID, m_deviceToEdit.NodeName);
        }

        void client_GetCompaniesCompleted(object sender, GetCompaniesCompletedEventArgs e)
        {
            if (e.Error == null)
                ComboboxCompany.ItemsSource = e.Result;
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Companies", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
            if (ComboboxCompany.Items.Count > 0)
                ComboboxCompany.SelectedIndex = 0;

            if (m_deviceToEdit != null && m_deviceToEdit.CompanyID.HasValue)
                ComboboxCompany.SelectedItem = new KeyValuePair<int, string>((int)m_deviceToEdit.CompanyID, m_deviceToEdit.CompanyName);
        }

        void client_GetDevicesCompleted(object sender, GetDevicesCompletedEventArgs e)
        {
            if (e.Error == null)
                ComboboxParent.ItemsSource = e.Result;
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Devices", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
            if (ComboboxParent.Items.Count > 0)
                ComboboxParent.SelectedIndex = 0;

            if (m_deviceToEdit != null && m_deviceToEdit.ParentID.HasValue)
                ComboboxParent.SelectedItem = new KeyValuePair<int, string>((int)m_deviceToEdit.ParentID, m_deviceToEdit.ParentAcronym);
        }

        #endregion
    }
}
