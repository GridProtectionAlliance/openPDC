//******************************************************************************************************
//  SystemSettings.xaml.cs - Gbtc
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
//  09/03/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Windows;
using System.Windows.Controls;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
using System.Windows.Media.Imaging;
using System.Collections.Generic;

namespace openPDCManager.Pages.Manage
{
    /// <summary>
    /// Interaction logic for SystemSettings.xaml
    /// </summary>
    public partial class SystemSettings : UserControl
    {
        #region [ Constructor ]
        
        public SystemSettings()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(SystemSettings_Loaded);
            ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
            ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
            ButtonSave.Content = new BitmapImage(new Uri(@"images/Save.png", UriKind.Relative));
            ButtonClear.Content = new BitmapImage(new Uri(@"images/Cancel.png", UriKind.Relative));
        }

        #endregion

        #region [ Controls Event Handlers ]

        void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            //Storyboard sb = new Storyboard();
            //sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            //sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            //Storyboard.SetTarget(sb, ButtonClearTransform);
            //sb.Begin();

            //Load Default Settings.
            IsolatedStorageManager.SetDefuaultStorage(true);
            //Clear values for Input Status & Monitoring Screen.
            IsolatedStorageManager.SaveIntoIsolatedStorage("InputMonitoringPoints", string.Empty);

            LoadSettingsFromIsolatedStorage();

            SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Successfully Restored Default System Settings", SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
            sm.Owner = Window.GetWindow(this);
            sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            sm.ShowPopup();
        }

        void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            //Storyboard sb = new Storyboard();
            //sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            //sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            //Storyboard.SetTarget(sb, ButtonSaveTransform);
            //sb.Begin();

            if (IsValid())
            { 
                IsolatedStorageManager.SaveIntoIsolatedStorage("ForceIPv4", (bool)CheckboxForceIPv4.IsChecked);

                if (!string.IsNullOrEmpty(TextBoxNumberOfMessagesOnMonitor.Text))
                    IsolatedStorageManager.SaveIntoIsolatedStorage("NumberOfMessages", Convert.ToInt32(TextBoxNumberOfMessagesOnMonitor.Text));

                IsolatedStorageManager.SaveIntoIsolatedStorage("InputMonitoringPoints", TextBoxLastSettings.Text);
                    
                LoadSettingsFromIsolatedStorage();

                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Successfully Saved System Settings", SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                            ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        #endregion

        #region [ Page Event Handlers ]

        void SystemSettings_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSettingsFromIsolatedStorage();
        }
        
        #endregion

        #region [ Methods ]

        void LoadSettingsFromIsolatedStorage()
        {
            TextBoxNumberOfMessagesOnMonitor.Text = IsolatedStorageManager.ReadFromIsolatedStorage("NumberOfMessages") == null ? "50" : IsolatedStorageManager.ReadFromIsolatedStorage("NumberOfMessages").ToString();            
            CheckboxForceIPv4.IsChecked = IsolatedStorageManager.ReadFromIsolatedStorage("ForceIPv4") == null ? true : Convert.ToBoolean(IsolatedStorageManager.ReadFromIsolatedStorage("ForceIPv4"));
            TextBoxLastSettings.Text = IsolatedStorageManager.ReadFromIsolatedStorage("InputMonitoringPoints").ToString();
        }

        bool IsValid()
        {
            bool isValid = true;

            if (!TextBoxNumberOfMessagesOnMonitor.Text.IsInteger())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Load Order", SystemMessage = "Please provide valid integer value for Load Order.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxNumberOfMessagesOnMonitor.Text = "50";
                    TextBoxNumberOfMessagesOnMonitor.Focus();
                });
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
                return isValid;
            }

            return isValid;
        }

        #endregion
    }
}
