//******************************************************************************************************
//  ManageOtherDevicesUserControl.xaml.cs - Gbtc
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
#if SILVERLIGHT
using openPDCManager.PhasorDataServiceProxy;
#else
using System.Windows.Media.Imaging;
using openPDCManager.Data.Entities;
using System.Diagnostics;
#endif

namespace openPDCManager.UserControls.CommonControls
{
    public partial class ManageOtherDevicesUserControl : UserControl
    {
        #region [ Members ]
                
        bool m_inEditMode = false;
        public int m_deviceID = 0;
        public bool hasQueryString;

        #endregion

        public ManageOtherDevicesUserControl()
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
        }

        #region [ Control Event Handlers ]

        void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            Storyboard sb = new Storyboard();
            sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            Storyboard.SetTarget(sb, ButtonClearTransform);
            sb.Begin();
#endif
            ClearForm();
        }

        void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            Storyboard sb = new Storyboard();
            sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            Storyboard.SetTarget(sb, ButtonSaveTransform);
            sb.Begin();
#endif
            if (IsValid())
            {
                OtherDevice otherDevice = new OtherDevice();
                otherDevice.Acronym = TextBoxAcronym.Text.CleanText();
                otherDevice.Name = TextBoxName.Text.CleanText();
                otherDevice.IsConcentrator = (bool)CheckboxConcentrator.IsChecked;
                otherDevice.CompanyID = ((KeyValuePair<int, string>)ComboboxCompany.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboboxCompany.SelectedItem).Key;
                otherDevice.VendorDeviceID = ((KeyValuePair<int, string>)ComboboxVendorDevice.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboboxVendorDevice.SelectedItem).Key;
                otherDevice.Longitude = TextBoxLongitude.Text.ToNullableDecimal();
                otherDevice.Latitude = TextBoxLatitude.Text.ToNullableDecimal();
                otherDevice.InterconnectionID = ((KeyValuePair<int, string>)ComboboxInterconnection.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboboxInterconnection.SelectedItem).Key;
                otherDevice.Planned = (bool)CheckboxPlanned.IsChecked;
                otherDevice.Desired = (bool)CheckboxDesired.IsChecked;
                otherDevice.InProgress = (bool)CheckboxInProgress.IsChecked;
                if (m_inEditMode == false && m_deviceID == 0)
                    SaveOtherDevice(otherDevice, true);
                else
                {
                    otherDevice.ID = m_deviceID;
                    SaveOtherDevice(otherDevice, false);
                }
            }
        }

        #endregion

        #region [ Page Event Handlers ]

        void ManageOtherDevices_Loaded(object sender, RoutedEventArgs e)
        {
            if (hasQueryString)
                m_inEditMode = true;
        }

        #endregion

        #region [ Methods ]

        bool IsValid()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(TextBoxAcronym.Text.CleanText()))
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Acronym", SystemMessage = "Please provide valid Acronym for a device.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxAcronym.Focus();
                });
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
#endif
                sm.ShowPopup();
                return isValid;
            }

            return isValid;
        }

        public void ClearForm()
        {
            GridOtherDeviceDetail.DataContext = new OtherDevice() { Longitude = -98.6m, Latitude = 37.5m };
            if (ComboboxCompany.Items.Count > 0)
                ComboboxCompany.SelectedIndex = 0;
            if (ComboboxInterconnection.Items.Count > 0)
                ComboboxInterconnection.SelectedIndex = 0;
            if (ComboboxVendorDevice.Items.Count > 0)
                ComboboxVendorDevice.SelectedIndex = 0;
            m_inEditMode = false;
            m_deviceID = 0;
        }

        #endregion
    }
}
