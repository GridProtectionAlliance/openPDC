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
using System.Windows;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
using openPDCManager.Data;
using openPDCManager.Data.Entities;
using System.Collections.Generic;
using System.Threading;

namespace openPDCManager.UserControls.CommonControls
{
    public partial class VendorDevicesUserControl
    {
        #region [ Methods ]

        void Initialize()
        {
            if (((App)Application.Current).Principal.IsInRole("Administrator, Editor"))
                ButtonSave.IsEnabled = true;
            else
                ButtonSave.IsEnabled = false;
        }

        void SaveVendorDevice(VendorDevice vendorDevice, bool isNew)
        {
            SystemMessages sm;
            try
            {
                string result = CommonFunctions.SaveVendorDevice(null, vendorDevice, isNew);
                
                sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();

                GetVendorDevices();
                //ClearForm();

                //make this newly added or updated item as default selected. So user can click initialize right away.                
                ListBoxVendorDeviceList.SelectedItem = ((List<VendorDevice>)ListBoxVendorDeviceList.ItemsSource).Find(c => c.Name == vendorDevice.Name);                
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.SaveVendorDevice", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Vendor Device Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        void GetVendors()
        {
            try
            {
                ComboBoxVendor.ItemsSource = CommonFunctions.GetVendors(null, false);
                if (ComboBoxVendor.Items.Count > 0)
                    ComboBoxVendor.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetVendors", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Vendors", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        void GetVendorDevices()
        {
            try
            {
                ListBoxVendorDeviceList.ItemsSource = CommonFunctions.GetVendorDeviceList(null);
                if (ListBoxVendorDeviceList.Items.Count > 0)
                    ListBoxVendorDeviceList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetVendorDevices", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Vendor Device List", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        #endregion
    }
}
