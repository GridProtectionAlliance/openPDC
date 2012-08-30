//******************************************************************************************************
//  AddDevicesUserControl.xaml.cs - Gbtc
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
//  08/02/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
using System.Windows.Media.Animation;

#if SILVERLIGHT

#else

#endif

namespace openPDCManager.UserControls.OutputStreamControls
{
    public partial class AddDevicesUserControl : UserControl
    {
        #region [ Members ]

        public int m_sourceOutputStreamID;
        public string m_sourceOutputStreamAcronym;
        Dictionary<int, string> m_devicesToBeAdded;        
        Dictionary<int, string> m_deviceList;
        string m_nodeValue;

        #endregion

        #region [ Constructor ]

        public AddDevicesUserControl()
        {
            InitializeComponent();
            Initialize();
#if !SILVERLIGHT
            ButtonSearch.Content = new BitmapImage(new Uri(@"images/Search.png", UriKind.Relative));
            ButtonShowAll.Content = new BitmapImage(new Uri(@"images/CancelSearch.png", UriKind.Relative));
            ButtonAdd.Content = new BitmapImage(new Uri(@"images/Add.png", UriKind.Relative));
            UpdateLayout();
#endif
            Loaded += new RoutedEventHandler(AddDevices_Loaded);            
            ButtonAdd.Click += new RoutedEventHandler(ButtonAdd_Click);
            ButtonSearch.Click += new RoutedEventHandler(ButtonSearch_Click);
            ButtonShowAll.Click += new RoutedEventHandler(ButtonShowAll_Click);            
        }

        #endregion

        #region [ Controls Event Handlers ]

        void ButtonShowAll_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            Storyboard sb = new Storyboard();
            sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            Storyboard.SetTarget(sb, ButtonShowAllTransform);
            sb.Begin();
#endif
            ListBoxDeviceList.ItemsSource = m_deviceList;
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
            ListBoxDeviceList.ItemsSource = (from item in m_deviceList.AsEnumerable()
                                             where item.Value.ToUpper().Contains(searchText)
                                             select item).ToList();
        }

        void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            Storyboard sb = new Storyboard();
            sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            Storyboard.SetTarget(sb, ButtonAddTransform);
            sb.Begin();
#endif
            if (m_devicesToBeAdded.Count > 0)
            {
                AddDevices();
                if ((bool)CheckAll.IsChecked)
                    CheckAll.IsChecked = false;
            }
            else
            {
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Please Select Device(s) to Add", SystemMessage = string.Empty, UserMessageType = MessageType.Information },
                         ButtonType.OkOnly);
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
#endif
                sm.ShowPopup();
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            string deviceAcronym = ((CheckBox)sender).Content.ToString();
            int deviceID = Convert.ToInt32(((CheckBox)sender).Tag.ToString());
            if (m_devicesToBeAdded.ContainsKey(deviceID))
                m_devicesToBeAdded.Remove(deviceID);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {            
            string deviceAcronym = ((CheckBox)sender).Content.ToString();
            int deviceID = Convert.ToInt32(((CheckBox)sender).Tag.ToString());
            if (!m_devicesToBeAdded.ContainsKey(deviceID))
                m_devicesToBeAdded.Add(deviceID, deviceAcronym);
        }

        private void CheckAll_Checked(object sender, RoutedEventArgs e)
        {
            CheckAllCheckBoxes();
        }

        private void CheckAll_Unchecked(object sender, RoutedEventArgs e)
        {
            UncheckAllCheckBoxes();
        }

        #endregion

        #region [ Page Event Handlers ]

        void AddDevices_Loaded(object sender, RoutedEventArgs e)
        {
            m_devicesToBeAdded = new Dictionary<int, string>();
            m_deviceList = new Dictionary<int, string>();
            m_nodeValue = ((App)Application.Current).NodeValue;
            GetDevicesForOutputStream();
        }

        #endregion

        #region [ Methods ]
                
        private void CheckAllCheckBoxes()
        {
            List<UIElement> checkboxlist = new List<UIElement>();
            Common.GetChildren(ListBoxDeviceList, typeof(CheckBox), ref checkboxlist);

            if (checkboxlist.Count > 0)
            {
                foreach (UIElement element in checkboxlist)
                {
                    ((CheckBox)element).IsChecked = true;
                }
            }
        }

        private void UncheckAllCheckBoxes()
        {
            List<UIElement> checkboxlist = new List<UIElement>();
            Common.GetChildren(ListBoxDeviceList, typeof(CheckBox), ref checkboxlist);

            if (checkboxlist.Count > 0)
            {
                foreach (UIElement element in checkboxlist)
                {
                    ((CheckBox)element).IsChecked = false;
                }
            }
        }

        #endregion

    }
}
