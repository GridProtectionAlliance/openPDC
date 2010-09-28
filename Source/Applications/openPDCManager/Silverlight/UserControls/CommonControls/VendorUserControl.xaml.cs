//******************************************************************************************************
//  VendorUserControl.xaml.cs - Gbtc
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
//  07/13/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using openPDCManager.ModalDialogs;
#if SILVERLIGHT
using openPDCManager.PhasorDataServiceProxy;
#else
using openPDCManager.Data;
using openPDCManager.Data.Entities;
using System.Windows.Media.Imaging;
using System.Diagnostics;
#endif
using openPDCManager.Utilities;

namespace openPDCManager.UserControls.CommonControls
{
    public partial class VendorUserControl : UserControl
    {
        #region [ Members ]
                
        bool m_inEditMode = false;
        int m_vendorID = 0;

        #endregion

        #region [ Constructor ]

        public VendorUserControl()
        {            
            InitializeComponent();
#if !SILVERLIGHT
            ButtonSave.Content = new BitmapImage(new Uri(@"images/Save.png", UriKind.Relative));
            ButtonClear.Content = new BitmapImage(new Uri(@"images/Cancel.png", UriKind.Relative));
            UpdateLayout();
#endif
            Initialize();
            Loaded += new RoutedEventHandler(VendorUserControl_Loaded);
            ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
            ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
            ListBoxVendorList.SelectionChanged += new SelectionChangedEventHandler(ListBoxVendorList_SelectionChanged);
        }

        #endregion

        #region [ Page Event Handlers ]

        void VendorUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ClearForm();
            GetVendors();
        }

        #endregion

        #region [ Control Event Handlers ]

        void ListBoxVendorList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxVendorList.SelectedIndex >= 0)
            {
                Vendor selectedVendor = ListBoxVendorList.SelectedItem as Vendor;
                GridVendorDetail.DataContext = selectedVendor;
                m_inEditMode = true;
                m_vendorID = selectedVendor.ID;
                ButtonSave.Tag = "Update";
            }
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
                Vendor vendor = new Vendor();
                vendor.Acronym = TextBoxAcronym.Text.CleanText();
                vendor.Name = TextBoxName.Text.CleanText();
                vendor.PhoneNumber = TextBoxPhoneNumber.Text.CleanText();
                vendor.ContactEmail = TextBoxContactEmail.Text.CleanText();
                vendor.URL = TextBoxUrl.Text.CleanText();

                if (m_vendorID != 0 && m_inEditMode == true)		//i.e. It is an update to existing item.
                {
                    vendor.ID = m_vendorID;
                    SaveVendor(vendor, false);
                }
                else	//i.e. It is a new item			
                    SaveVendor(vendor, true);
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
#endif
                sm.ShowPopup();
                return isValid;
            }

            return isValid;
        }

        void ClearForm()
        {
            GridVendorDetail.DataContext = new Vendor();		//this is done to clear all the textboxes and to retain binding information. Please do not set empty strings as textboxes' vaues.
            m_inEditMode = false;
            m_vendorID = 0;
            ListBoxVendorList.SelectedIndex = -1;
            ButtonSave.Tag = "Add";
        }

        #endregion

    }
}
