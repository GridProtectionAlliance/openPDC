//******************************************************************************************************
//  ManageOtherDevicesUserControl.cs - Gbtc
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
//  07/15/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.ServiceModel;
using openPDCManager.ModalDialogs;
using openPDCManager.PhasorDataServiceProxy;
using openPDCManager.Utilities;

namespace openPDCManager.UserControls.CommonControls
{
    public partial class ManageOtherDevicesUserControl
    {
        #region [ Members ]

        PhasorDataServiceClient m_client;
        OtherDevice deviceToEdit;

        #endregion

        #region [ Methods ]

        void Initialize()
        {
            m_client = ProxyClient.GetPhasorDataServiceProxyClient();
            m_client.GetCompaniesCompleted += new EventHandler<GetCompaniesCompletedEventArgs>(client_GetCompaniesCompleted);
            m_client.GetVendorDevicesCompleted += new EventHandler<GetVendorDevicesCompletedEventArgs>(client_GetVendorDevicesCompleted);
            m_client.GetInterconnectionsCompleted += new EventHandler<GetInterconnectionsCompletedEventArgs>(client_GetInterconnectionsCompleted);
            m_client.SaveOtherDeviceCompleted += new EventHandler<SaveOtherDeviceCompletedEventArgs>(client_SaveOtherDeviceCompleted);
            m_client.GetOtherDeviceByDeviceIDCompleted += new EventHandler<GetOtherDeviceByDeviceIDCompletedEventArgs>(client_GetOtherDeviceByDeviceIDCompleted);            
        }

        public void GetCompanies()
        {
            m_client.GetCompaniesAsync(true);
        }

        public void GetVendorDevices()
        {
            m_client.GetVendorDevicesAsync(true);
        }

        public void GetInterconnections()
        {
            m_client.GetInterconnectionsAsync(true);
        }

        public void SaveOtherDevice(OtherDevice otherDevice, bool isNew)
        {
            m_client.SaveOtherDeviceAsync(otherDevice, isNew);
        }

        public void GetOtherDeviceByDeviceID(int deviceID)
        {
            m_client.GetOtherDeviceByDeviceIDAsync(deviceID);
        }

        #endregion

        #region [ Service Event Handlers ]

        void client_GetOtherDeviceByDeviceIDCompleted(object sender, GetOtherDeviceByDeviceIDCompletedEventArgs e)
        {
            deviceToEdit = new OtherDevice();
            if (e.Error == null)
            {
                deviceToEdit = e.Result;
                GridOtherDeviceDetail.DataContext = deviceToEdit;
                if (deviceToEdit.CompanyID.HasValue)
                    ComboboxCompany.SelectedItem = new KeyValuePair<int, string>((int)deviceToEdit.CompanyID, deviceToEdit.CompanyName);
                else
                    ComboboxCompany.SelectedIndex = 0;
                if (deviceToEdit.InterconnectionID.HasValue)
                    ComboboxInterconnection.SelectedItem = new KeyValuePair<int, string>((int)deviceToEdit.InterconnectionID, deviceToEdit.InterconnectionName);
                else
                    ComboboxInterconnection.SelectedIndex = 0;
                if (deviceToEdit.VendorDeviceID.HasValue)
                    ComboboxVendorDevice.SelectedItem = new KeyValuePair<int, string>((int)deviceToEdit.VendorDeviceID, deviceToEdit.VendorDeviceName);
                else
                    ComboboxVendorDevice.SelectedIndex = 0;
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Other Device Information by ID", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
        }

        void client_SaveOtherDeviceCompleted(object sender, SaveOtherDeviceCompletedEventArgs e)
        {
            SystemMessages sm;
            if (e.Error == null)
            {
                ClearForm();
                sm = new SystemMessages(new Message() { UserMessage = e.Result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
                System.Windows.Browser.HtmlPage.Window.Navigate(new Uri("/Default.aspx#/Pages/Devices/OtherDevices.xaml", UriKind.Relative));
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Other Device Information", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
            }
            sm.ShowPopup();
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

            if (deviceToEdit != null && deviceToEdit.InterconnectionID.HasValue)
                    ComboboxInterconnection.SelectedItem = new KeyValuePair<int, string>((int)deviceToEdit.InterconnectionID, deviceToEdit.InterconnectionName);
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

            if (deviceToEdit != null && deviceToEdit.VendorDeviceID.HasValue)
                ComboboxVendorDevice.SelectedItem = new KeyValuePair<int, string>((int)deviceToEdit.VendorDeviceID, deviceToEdit.VendorDeviceName);
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

            if (deviceToEdit != null && deviceToEdit.CompanyID.HasValue)
                ComboboxCompany.SelectedItem = new KeyValuePair<int, string>((int)deviceToEdit.CompanyID, deviceToEdit.CompanyName);
        }

        #endregion
    }
}
