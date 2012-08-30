//******************************************************************************************************
//  OtherDevicesUserControl.xaml.cs - Gbtc
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
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
#if SILVERLIGHT
using openPDCManager.PhasorDataServiceProxy;
using System.Windows.Media.Animation;
#else
using openPDCManager.Data.Entities;
#endif

namespace openPDCManager.UserControls.CommonControls
{
    public partial class OtherDevicesUserControl : UserControl
    {
        #region [ Members ]
                
        ObservableCollection<OtherDevice> m_otherDeviceList = new ObservableCollection<OtherDevice>();

        #endregion

        public OtherDevicesUserControl()
        {
            InitializeComponent();
            Initialize();
            Loaded += new RoutedEventHandler(OtherDevices_Loaded);
            ButtonSearch.Click += new RoutedEventHandler(ButtonSearch_Click);
            ButtonShowAll.Click += new RoutedEventHandler(ButtonShowAll_Click);
        }

        #region [ Control Event Handlers ]

        void ButtonShowAll_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            Storyboard sb = new Storyboard();
            sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            Storyboard.SetTarget(sb, ButtonShowAllTransform);
            sb.Begin();
#endif
            ListBoxOtherDeviceList.ItemsSource = m_otherDeviceList;
        }

        void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            Storyboard sb = new Storyboard();
            sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            Storyboard.SetTarget(sb, ButtonSearchTransform);
            sb.Begin();
#endif
            string searchText = TextBoxSearch.Text.ToUpper();
            ListBoxOtherDeviceList.ItemsSource = (from item in m_otherDeviceList
                                                  where item.Acronym.ToUpper().Contains(searchText) || item.Name.ToUpper().Contains(searchText) || item.InterconnectionName.ToUpper().Contains(searchText)
                                                         || item.CompanyName.ToUpper().Contains(searchText) || item.VendorDeviceName.ToUpper().Contains(searchText)
                                                  select item).ToList();
        }

        void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            string deviceId = ((Button)sender).Tag.ToString();
#if SILVERLIGHT
            System.Windows.Browser.HtmlPage.Window.Navigate(new Uri("/Default.aspx#/Pages/Devices/ManageOtherDevices.xaml?did=" + deviceId, UriKind.Relative));            
#else
            ManageOtherDevicesUserControl manageOtherDevicesUserControl = new ManageOtherDevicesUserControl(Convert.ToInt32(deviceId));
            ((MasterLayoutWindow)Window.GetWindow(this)).ContentFrame.Navigate(manageOtherDevicesUserControl);
#endif
        }

        #endregion

        #region [ Page Event Handlers ]

        void OtherDevices_Loaded(object sender, RoutedEventArgs e)
        {
            GetOtherDeviceList();
        }

        #endregion
    }
}
