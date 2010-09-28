//******************************************************************************************************
//  VendorDevicesUserControl.cs - Gbtc
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
using System.ServiceModel;
using openPDCManager.ModalDialogs;
using openPDCManager.PhasorDataServiceProxy;
using openPDCManager.Utilities;

namespace openPDCManager.UserControls.CommonControls
{
    public partial class VendorDevicesUserControl
    {
        #region [ Members ]

        PhasorDataServiceClient m_client;
        bool m_selectFirst = true;

        #endregion

        #region [ Methods ]

        void Initialize()
        {
            m_client = ProxyClient.GetPhasorDataServiceProxyClient();
            m_client.GetVendorDeviceListCompleted += new EventHandler<GetVendorDeviceListCompletedEventArgs>(client_GetVendorDeviceListCompleted);
            m_client.GetVendorsCompleted += new EventHandler<GetVendorsCompletedEventArgs>(client_GetVendorsCompleted);
            m_client.SaveVendorDeviceCompleted += new EventHandler<SaveVendorDeviceCompletedEventArgs>(client_SaveVendorDeviceCompleted);
        }

        void SaveVendorDevice(VendorDevice vendorDevice, bool isNew)
        {
            m_client.SaveVendorDeviceAsync(vendorDevice, isNew);
        }

        void GetVendors()
        {
            m_client.GetVendorsAsync(false);            
        }

        void GetVendorDevices()
        {
            m_client.GetVendorDeviceListAsync();
        }

        #endregion

        #region [ Service Event Handlers ]

        void client_SaveVendorDeviceCompleted(object sender, SaveVendorDeviceCompletedEventArgs e)
        {
            SystemMessages sm;
            if (e.Error == null)
            {
                m_client.GetVendorDeviceListAsync(); //Refresh data to reflect changes on the current screen.
                ClearForm();
                sm = new SystemMessages(new Message() { UserMessage = e.Result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Vendor Device Information", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
            }
            sm.ShowPopup();           
        }

        void client_GetVendorsCompleted(object sender, GetVendorsCompletedEventArgs e)
        {
            if (e.Error == null)
                ComboBoxVendor.ItemsSource = e.Result;
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Vendors", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
            if (ComboBoxVendor.Items.Count > 0)
                ComboBoxVendor.SelectedIndex = 0;
        }

        void client_GetVendorDeviceListCompleted(object sender, GetVendorDeviceListCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                ListBoxVendorDeviceList.ItemsSource = e.Result;
                if (ListBoxVendorDeviceList.Items.Count > 0 && m_selectFirst)
                {
                    ListBoxVendorDeviceList.SelectedIndex = 0;
                    m_selectFirst = false;
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Vendor Device List", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
        }

        #endregion
    }
}
