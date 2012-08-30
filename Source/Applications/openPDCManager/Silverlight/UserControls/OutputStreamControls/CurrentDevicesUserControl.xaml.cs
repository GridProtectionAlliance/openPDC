//******************************************************************************************************
//  CurrentDevicesUserControl.xaml.cs - Gbtc
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
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using openPDCManager.ModalDialogs;
using openPDCManager.ModalDialogs.OutputStreamWizard;
using openPDCManager.Utilities;
using System.Windows.Media.Imaging;
using System.Collections.Generic;

namespace openPDCManager.UserControls.OutputStreamControls
{
    public partial class CurrentDevicesUserControl : UserControl
    {
        #region [ Members ]

        public int m_sourceOutputStreamID;
        public string m_sourceOutputStreamAcronym;
        ObservableCollection<string> m_devicesToBeDeleted;        

        #endregion

        #region [ Constructor ]

        public CurrentDevicesUserControl()
        {
            InitializeComponent();
            Initialize();
            Loaded += new RoutedEventHandler(CurrentDevices_Loaded);
#if !SILVERLIGHT
            ButtonAdd.Content = new BitmapImage(new Uri(@"images/Add.png", UriKind.Relative));
            ButtonDelete.Content = new BitmapImage(new Uri(@"images/Cancel.png", UriKind.Relative));            
            UpdateLayout();
#endif
            ButtonAdd.Click += new RoutedEventHandler(ButtonAdd_Click);
            ButtonDelete.Click += new RoutedEventHandler(ButtonDelete_Click);
        }

        #endregion

        #region [ Control Event Handlers ]

        void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            Storyboard sb = new Storyboard();
            sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            Storyboard.SetTarget(sb, ButtonDeleteTransform);
            sb.Begin();
#endif
            if (m_devicesToBeDeleted.Count > 0)
            {
                DeleteOutputStreamDevice();
                if ((bool)CheckAll.IsChecked)
                    CheckAll.IsChecked = false;
            }
            else
            {
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Please select device(s) to delete", SystemMessage = string.Empty, UserMessageType = MessageType.Information }, ButtonType.OkOnly);
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
#endif
                sm.ShowPopup();
            }
        }

        void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)CheckAll.IsChecked)
                CheckAll.IsChecked = false;
#if SILVERLIGHT
            Storyboard sb = new Storyboard();
            sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            Storyboard.SetTarget(sb, ButtonAddTransform);
            sb.Begin();
#endif
            AddDevices addDevices = new AddDevices(m_sourceOutputStreamID, m_sourceOutputStreamAcronym);
            addDevices.Closed += new EventHandler(addDevices_Closed);
#if SILVERLIGHT
            addDevices.Show();
#else
            addDevices.Owner = Window.GetWindow(this);
            addDevices.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            addDevices.ShowDialog();
#endif
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            string deviceAcronym = ((CheckBox)sender).Content.ToString();
            if (m_devicesToBeDeleted.Contains(deviceAcronym))
                m_devicesToBeDeleted.Remove(deviceAcronym);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            string deviceAcronym = ((CheckBox)sender).Content.ToString();
            if (!m_devicesToBeDeleted.Contains(deviceAcronym))
                m_devicesToBeDeleted.Add(deviceAcronym);
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

        void addDevices_Closed(object sender, EventArgs e)
        {
            GetOutputStreamDeviceList();            
        }

        void CurrentDevices_Loaded(object sender, RoutedEventArgs e)
        {
            m_devicesToBeDeleted = new ObservableCollection<string>();
            GetOutputStreamDeviceList();
        }

        #endregion

        private void CheckAllCheckBoxes()
        {
            List<UIElement> checkboxlist = new List<UIElement>();
            Common.GetChildren(ListBoxOutputStreamDeviceList, typeof(CheckBox), ref checkboxlist);

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
            Common.GetChildren(ListBoxOutputStreamDeviceList, typeof(CheckBox), ref checkboxlist);

            if (checkboxlist.Count > 0)
            {
                foreach (UIElement element in checkboxlist)
                {
                    ((CheckBox)element).IsChecked = false;
                }
            }
        }
    
    }
}
