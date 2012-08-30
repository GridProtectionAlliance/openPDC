//******************************************************************************************************
//  VendorDevicesUserControl.xaml.cs - Gbtc
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
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
#if SILVERLIGHT
using openPDCManager.PhasorDataServiceProxy;
using System.Windows.Media.Animation;
#else
using System.Windows.Media.Imaging;
using openPDCManager.Data.Entities;
using System.Diagnostics;
#endif


namespace openPDCManager.UserControls.CommonControls
{
    public partial class VendorDevicesUserControl : UserControl
    {
        #region [ Members ]
                
        bool m_inEditMode = false;
        int m_vendorDeviceID = 0;

        #endregion

        #region [ Contructor ]

        public VendorDevicesUserControl()
        {
            InitializeComponent();
            Initialize();
#if !SILVERLIGHT
            ButtonSave.Content = new BitmapImage(new Uri(@"images/Save.png", UriKind.Relative));
            ButtonClear.Content = new BitmapImage(new Uri(@"images/Cancel.png", UriKind.Relative));
            UpdateLayout();
#endif
            Loaded += new RoutedEventHandler(VendorDevices_Loaded);            
            ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
            ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
            ListBoxVendorDeviceList.SelectionChanged += new SelectionChangedEventHandler(ListBoxVendorDeviceList_SelectionChanged);
        }

        #endregion

        #region [ Control Event Handlers ]

        void ListBoxVendorDeviceList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxVendorDeviceList.SelectedIndex >= 0)
            {
                VendorDevice selectedVendorDevice = ListBoxVendorDeviceList.SelectedItem as VendorDevice;
                GridVendorDeviceDetail.DataContext = selectedVendorDevice;
                ComboBoxVendor.SelectedItem = new KeyValuePair<int, string>(selectedVendorDevice.VendorID, selectedVendorDevice.VendorName);
                m_vendorDeviceID = selectedVendorDevice.ID;
                m_inEditMode = true;
                ButtonSave.Tag = "Update";
            }
        }

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
                VendorDevice vendorDevice = new VendorDevice();
                KeyValuePair<int, string> selectedVendor = (KeyValuePair<int, string>)ComboBoxVendor.SelectedItem;
                vendorDevice.VendorID = selectedVendor.Key;
                vendorDevice.Name = TextBoxName.Text.CleanText();
                vendorDevice.Description = TextBoxDescription.Text.CleanText();
                vendorDevice.URL = TextBoxUrl.Text.CleanText();

                if (m_vendorDeviceID != 0 && m_inEditMode == true)
                {
                    vendorDevice.ID = m_vendorDeviceID;
                    SaveVendorDevice(vendorDevice, false);
                }
                else
                    SaveVendorDevice(vendorDevice, true);
            }
        }

        void ButtonURL_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(((Button)sender).Content.ToString()))
            {
#if SILVERLIGHT
                System.Windows.Browser.HtmlPage.Window.Navigate(new Uri(((Button)sender).Content.ToString()), "_blank");
#else
                Process.Start(((Button)sender).Content.ToString());
#endif
            }
        }

        #endregion

        #region [ Page Event Handlers ]

        void VendorDevices_Loaded(object sender, RoutedEventArgs e)
        {
            GetVendors();
            GetVendorDevices();            
        }            

        #endregion

        #region [ Methods ]

        bool IsValid()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(TextBoxName.Text.CleanText()))
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Name", SystemMessage = "Please provide valid Name.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxName.Focus();
                });
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
#endif
                sm.ShowPopup();
                return isValid;
            }

            return isValid;
        }

        void ClearForm()
        {
            if (ComboBoxVendor.Items.Count > 0)
                ComboBoxVendor.SelectedIndex = 0;
            GridVendorDeviceDetail.DataContext = new VendorDevice();	//Bind an empty element.	
            m_inEditMode = false;
            m_vendorDeviceID = 0;
            ListBoxVendorDeviceList.SelectedIndex = -1;
            ButtonSave.Tag = "Add";
        }

        #endregion
    }
}
