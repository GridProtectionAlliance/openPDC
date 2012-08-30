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
using System.Linq;
using System.Text;
using openPDCManager.Data;
using openPDCManager.Data.Entities;
using System.Windows.Media.Imaging;
using System.Windows;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
using System.Threading;

namespace openPDCManager.UserControls.CommonControls
{
    public partial class ManageOtherDevicesUserControl
    {
        public ManageOtherDevicesUserControl(int deviceID)
        {
            InitializeComponent();
            Initialize();
#if !SILVERLIGHT
            ButtonSave.Content = new BitmapImage(new Uri(@"images/Save.png", UriKind.Relative));
            ButtonClear.Content = new BitmapImage(new Uri(@"images/Cancel.png", UriKind.Relative));
            UpdateLayout();
#endif
            Loaded += new RoutedEventHandler(ManageOtherDevices_Loaded);
            ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
            ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
            this.hasQueryString = true;
            m_deviceID = deviceID;
            GetOtherDeviceByDeviceID(m_deviceID);
        }

        #region [ Methods ]

        void Initialize()
        {
            GetCompanies();
            GetVendorDevices();
            GetInterconnections();
            ClearForm();
            if (((App)Application.Current).Principal.IsInRole("Administrator, Editor"))
                ButtonSave.IsEnabled = true;
            else
                ButtonSave.IsEnabled = false;
        }

        public void GetCompanies()
        {
            try
            {
                ComboboxCompany.ItemsSource = CommonFunctions.GetCompanies(null, true);
                if (ComboboxCompany.Items.Count > 0)
                    ComboboxCompany.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetCompanies", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Companies", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }            
        }

        public void GetVendorDevices()
        {
            try
            {
                ComboboxVendorDevice.ItemsSource = CommonFunctions.GetVendorDevices(null, true);
                if (ComboboxVendorDevice.Items.Count > 0)
                    ComboboxVendorDevice.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetVendorDevices", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Vendor Devices", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }            
        }

        public void GetInterconnections()
        {
            try
            {
                ComboboxInterconnection.ItemsSource = CommonFunctions.GetInterconnections(null, true);
                if (ComboboxInterconnection.Items.Count > 0)
                    ComboboxInterconnection.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetInterconnections", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Interconnections", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();

            }
        }

        public void SaveOtherDevice(OtherDevice otherDevice, bool isNew)
        {
            SystemMessages sm;
            try
            {
                string result = CommonFunctions.SaveOtherDevice(null, otherDevice, isNew);
                ClearForm();
                sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
                OtherDevicesUserControl otherDevicesUserControl = new OtherDevicesUserControl();
                ((MasterLayoutWindow)Window.GetWindow(this)).ContentFrame.Navigate(otherDevicesUserControl);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.SaveOtherDevice", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Other Device Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }            
        }

        public void GetOtherDeviceByDeviceID(int deviceID)
        {
            try
            {
                OtherDevice deviceToEdit = new OtherDevice();
                deviceToEdit = CommonFunctions.GetOtherDeviceByDeviceID(null, deviceID);
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
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetOtherDeviceByDeviceID", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Other Device Information by ID", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        #endregion
    }
}
