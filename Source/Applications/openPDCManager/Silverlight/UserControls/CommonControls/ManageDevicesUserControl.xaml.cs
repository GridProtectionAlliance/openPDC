//******************************************************************************************************
//  ManageDevicesUserControl.xaml.cs - Gbtc
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
using openPDCManager.Data.Entities;
using System.Windows.Media.Imaging;
using openPDCManager.Pages.Manage;
using openPDCManager.Pages.Devices;
#endif

namespace openPDCManager.UserControls.CommonControls
{
    public partial class ManageDevicesUserControl : UserControl
    {
        #region [ Members ]
                
        ActivityWindow m_activityWindow;
        bool m_inEditMode = false;
        public int m_deviceID;
        Device m_deviceToEdit;
        public string m_oldAcronym;
        public bool hasQueryString;
        Device m_deviceToCopy;

        #endregion

        public ManageDevicesUserControl()
        {
            InitializeComponent();
#if !SILVERLIGHT
            ButtonSave.Content = new BitmapImage(new Uri(@"images/save.png", UriKind.Relative));
            ButtonClear.Content = new BitmapImage(new Uri(@"images/cancel.png", UriKind.Relative));
            ButtonView.Content = new BitmapImage(new Uri(@"images/next.png", UriKind.Relative));
            ButtonBuildConnectionString.Content = new BitmapImage(new Uri(@"images/add.png", UriKind.Relative));
            ButtonBuildAlternateCommandChannel.Content = new BitmapImage(new Uri(@"images/add.png", UriKind.Relative));
            UpdateLayout();
#else
            ButtonDevicesList.Visibility = Visibility.Collapsed;
#endif
            Loaded += new RoutedEventHandler(AddNew_Loaded);
            Initialize();
            ButtonInitialize.Visibility = System.Windows.Visibility.Collapsed;
            ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
            ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
            ButtonView.Click += new RoutedEventHandler(ButtonView_Click);
            ComboboxParent.SelectionChanged += new SelectionChangedEventHandler(ComboboxParent_SelectionChanged);
            ButtonBuildConnectionString.Click += new RoutedEventHandler(ButtonBuildConnectionString_Click);
            ButtonBuildAlternateCommandChannel.Click += new RoutedEventHandler(ButtonBuildAlternateCommandChannel_Click);
        }

        public ManageDevicesUserControl(Device device) : this()
        {
            m_deviceToCopy = device;
        }

        #region [ Control Event Handlers ]

        void ButtonView_Click(object sender, RoutedEventArgs e)
        {
            if (((KeyValuePair<int, string>)ComboboxParent.SelectedItem).Key != 0)
            {
#if SILVERLIGHT
                System.Windows.Browser.HtmlPage.Window.Navigate(new Uri("/Default.aspx#/Pages/Devices/AddNew.xaml?did=" +  ((KeyValuePair<int, string>)ComboboxParent.SelectedItem).Key.ToString(), UriKind.Relative));         
#else
                ManageDevicesUserControl manageDevicesUserControl = new ManageDevicesUserControl();
                manageDevicesUserControl.m_deviceID = Convert.ToInt32(((KeyValuePair<int, string>)ComboboxParent.SelectedItem).Key);
                ((MasterLayoutWindow)Window.GetWindow(this)).ContentFrame.Navigate(manageDevicesUserControl);
#endif
            }
        }

        void ComboboxParent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((KeyValuePair<int, string>)ComboboxParent.SelectedItem).Key != 0)
                GetConcentratorDevice(((KeyValuePair<int, string>)ComboboxParent.SelectedItem).Key);                
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
                Device device = new Device();
                device.NodeID = ((KeyValuePair<string, string>)ComboboxNode.SelectedItem).Key;
                device.ParentID = ((KeyValuePair<int, string>)ComboboxParent.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboboxParent.SelectedItem).Key;
                device.Acronym = TextBoxAcronym.Text.CleanText();
                device.Name = TextBoxName.Text.CleanText();
                device.IsConcentrator = (bool)CheckboxConcentrator.IsChecked;
                device.CompanyID = ((KeyValuePair<int, string>)ComboboxCompany.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboboxCompany.SelectedItem).Key;
                device.HistorianID = ((KeyValuePair<int, string>)ComboboxHistorian.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboboxHistorian.SelectedItem).Key;
                device.AccessID = TextBoxAccessID.Text.ToInteger();
                device.VendorDeviceID = ((KeyValuePair<int, string>)ComboboxVendorDevice.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboboxVendorDevice.SelectedItem).Key;
                device.ProtocolID = ((KeyValuePair<int, string>)ComboboxProtocol.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboboxProtocol.SelectedItem).Key;
                device.Longitude = TextBoxLongitude.Text.ToNullableDecimal(); //string.IsNullOrEmpty(TextBoxLongitude.Text) ? (decimal?)null : Convert.ToDecimal(TextBoxLongitude.Text);
                device.Latitude = TextBoxLatitude.Text.ToNullableDecimal(); //string.IsNullOrEmpty(TextBoxLatitude.Text) ? (decimal?)null : Convert.ToDecimal(TextBoxLatitude.Text);
                device.InterconnectionID = ((KeyValuePair<int, string>)ComboboxInterconnection.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboboxInterconnection.SelectedItem).Key;
                device.ConnectionString = TextBoxConnectionString.Text.CleanText();

                if (!string.IsNullOrEmpty(TextBoxAlternateCommandChannel.Text))
                {
                    if (!device.ConnectionString.EndsWith(";"))
                        device.ConnectionString += ";";

                    device.ConnectionString += "commandchannel={" + TextBoxAlternateCommandChannel.Text.CleanText() + "}";
                }

                device.TimeZone = ((KeyValuePair<string, string>)ComboboxTimeZone.SelectedItem).Key;
                device.FramesPerSecond = string.IsNullOrEmpty(TextBoxFramesPerSecond.Text.CleanText()) ? 30 : TextBoxFramesPerSecond.Text.ToInteger();
                device.TimeAdjustmentTicks = TextBoxTimeAdjustmentTicks.Text.ToLong();
                device.DataLossInterval = TextBoxDataLossInterval.Text.ToDouble() == 0 ? 5 : TextBoxDataLossInterval.Text.ToDouble();
                device.ContactList = TextBoxContactList.Text.CleanText();
                device.MeasuredLines = TextBoxMeasuredLines.Text.ToNullableInteger(); //string.IsNullOrEmpty(TextBoxMeasuredLines.Text) ? (int?)null : Convert.ToInt32(TextBoxMeasuredLines.Text);
                device.LoadOrder = TextBoxLoadOrder.Text.ToInteger();
                device.Enabled = (bool)CheckboxEnabled.IsChecked;
                device.AllowedParsingExceptions = TextBoxAllowedParsingExceptions.Text.ToInteger();
                device.ParsingExceptionWindow = TextBoxParsingExceptionWindow.Text.ToDouble();
                device.DelayedConnectionInterval = TextBoxDelayedConnectionInterval.Text.ToDouble();
                device.AllowUseOfCachedConfiguration = (bool)CheckboxAllowUseOfCachedConfiguration.IsChecked;
                device.AutoStartDataParsingSequence = (bool)CheckboxAutoStartDataParsingSequence.IsChecked;
                device.SkipDisableRealTimeData = (bool)CheckboxSkipDisableRealTimeData.IsChecked;
                device.MeasurementReportingInterval = TextBoxMeasurementReportingInterval.Text.ToInteger();

                if (m_inEditMode == false && m_deviceID == 0)
                    SaveDevice(device, true, 0, 0);                    
                else
                {
                    device.ID = m_deviceID;
                    SaveDevice(device, false, 0, 0);
                }
            }
        }

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

            if (!TextBoxAccessID.Text.IsInteger())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Access ID", SystemMessage = "Please provide valid integer value for Access ID.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxAccessID.Focus();
                });
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
#endif
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxTimeAdjustmentTicks.Text.IsLong())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Time Adjustment Ticks", SystemMessage = "Please provide valid integer value for Time Adjustment Ticks.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxTimeAdjustmentTicks.Focus();
                });
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
#endif
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxDataLossInterval.Text.IsDouble())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Data Loss Interval", SystemMessage = "Please provide valid numeric value for Data Loss Interval.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxDataLossInterval.Focus();
                });
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
#endif
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxLoadOrder.Text.IsInteger())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Load Order", SystemMessage = "Please provide valid integer value for Load Order.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxLoadOrder.Focus();
                });
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
#endif
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxAllowedParsingExceptions.Text.IsInteger())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Allowed Parsing Exceptions", SystemMessage = "Please provide valid integer value for Allowed Parsing Exceptions.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxAllowedParsingExceptions.Focus();
                });
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
#endif
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxParsingExceptionWindow.Text.IsDouble())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Parsing Exception Window", SystemMessage = "Please provide valid numeric value for Parsing Exception Window.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxParsingExceptionWindow.Focus();
                });
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
#endif
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxDelayedConnectionInterval.Text.IsDouble())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Delayed Connection Interval", SystemMessage = "Please provide valid numeric value for Delayed Connection Interval.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxDelayedConnectionInterval.Focus();
                });
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
#endif
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxMeasurementReportingInterval.Text.IsInteger())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Measurement Reporting Interval", SystemMessage = "Please provide valid integer value for Measurement Reporting Interval.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxMeasurementReportingInterval.Focus();
                });
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
#endif
                sm.ShowPopup();
                return isValid;
            }

            return isValid;
        }

        void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            string deviceId = ((Button)sender).Tag.ToString();
#if SILVERLIGHT
            System.Windows.Browser.HtmlPage.Window.Navigate(new Uri("/Default.aspx#/Pages/Devices/AddNew.xaml?did=" + deviceId, UriKind.Relative));
#else
            ManageDevicesUserControl manageDevicesUserControl = new ManageDevicesUserControl();
            manageDevicesUserControl.m_deviceID = Convert.ToInt32(deviceId);
            ((MasterLayoutWindow)Window.GetWindow(this)).ContentFrame.Navigate(manageDevicesUserControl);
#endif            
        }

        void HyperlinkButtonPhasors_Click(object sender, RoutedEventArgs e)
        {
            int deviceId = Convert.ToInt32(((Button)sender).Tag.ToString());
            string acronym = ToolTipService.GetToolTip((Button)sender).ToString();
            Phasors phasors = new Phasors(deviceId, acronym);
#if SILVERLIGHT
            phasors.Show();           
#else
            phasors.Owner = Window.GetWindow(this);
            phasors.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            phasors.ShowDialog();
#endif
        }

        void HyperlinkButtonMeasurements_Click(object sender, RoutedEventArgs e)
        {
            string deviceId = ((Button)sender).Tag.ToString();
#if SILVERLIGHT
            System.Windows.Browser.HtmlPage.Window.Navigate(new Uri("/Default.aspx#/Pages/Manage/Measurements.xaml?did=" + deviceId, UriKind.Relative));
#else            
            Measurements measurements = new Measurements(Convert.ToInt32(deviceId));
            ((MasterLayoutWindow)Window.GetWindow(this)).ContentFrame.Navigate(measurements);
#endif      
        }

        void ButtonBuildConnectionString_Click(object sender, RoutedEventArgs e)
        {
            ConnectionStringBuilder csb = new ConnectionStringBuilder(ConnectionStringBuilder.ConnectionType.DeviceConnection);
            if (!string.IsNullOrEmpty(TextBoxConnectionString.Text))
                csb.ConnectionString = TextBoxConnectionString.Text;
            csb.Closed += new EventHandler(delegate(object popupWindow, EventArgs eargs)
            {
                if ((bool)csb.DialogResult)
                    TextBoxConnectionString.Text = csb.ConnectionString;
            });
#if SILVERLIGHT
            csb.Show();
#else
            csb.Owner = Window.GetWindow(this);
            csb.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            csb.ShowDialog();
#endif
        }

        void ButtonBuildAlternateCommandChannel_Click(object sender, RoutedEventArgs e)
        {
            ConnectionStringBuilder csb = new ConnectionStringBuilder(ConnectionStringBuilder.ConnectionType.AlternateCommandChannel);
            if (!string.IsNullOrEmpty(TextBoxAlternateCommandChannel.Text))
                csb.ConnectionString = TextBoxAlternateCommandChannel.Text;
            csb.Closed += new EventHandler(delegate(object popupWindow, EventArgs eargs)
            {
                if ((bool)csb.DialogResult)
                    TextBoxAlternateCommandChannel.Text = csb.ConnectionString;
            });
#if SILVERLIGHT
            csb.Show();
#else
            csb.Owner = Window.GetWindow(this);
            csb.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            csb.ShowDialog();
#endif
        }

        void ButtonInitialize_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Do you want to send Initialize command?", SystemMessage = "Device Acronym: " + ((Button)sender).Tag.ToString(), UserMessageType = MessageType.Confirmation }, ButtonType.YesNo);
                sm.Closed += new EventHandler(delegate(object popupWindow, EventArgs eargs)
                {
                    if ((bool)sm.DialogResult)
                        SendInitialize();
                });

#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
#endif
                sm.ShowPopup();
            }
            catch (Exception ex)
            {
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to send Initialize command.", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
#endif
                sm.ShowPopup();
            }
        }

        void HyperlinkBrowseDevices_Click(object sender, RoutedEventArgs e)
        {
#if !SILVERLIGHT
            BrowseDevicesUserControl devices = new BrowseDevicesUserControl();
            ((MasterLayoutWindow)Window.GetWindow(this)).ContentFrame.Navigate(devices);
#endif
        }

        #endregion

        #region [ Page Event Handlers ]

        void AddNew_Loaded(object sender, RoutedEventArgs e)
        {            
#if !SILVERLIGHT
            GetDevices(DeviceType.Concentrator, ((App)Application.Current).NodeValue, true);
            GetCompanies();
            GetNodes();
            GetHistorians();
            GetInterconnections();
            GetVendorDevices();
            GetProtocols();
            GetTimeZones();
#endif                        
            if (hasQueryString || m_deviceID > 0)
            {
                m_activityWindow = new ActivityWindow("Loading Data... Please Wait...");
#if SILVERLIGHT
                m_activityWindow.Show();
#else
                m_activityWindow.Owner = Window.GetWindow(this);
                m_activityWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                m_activityWindow.Show();
                ButtonInitialize.Visibility = System.Windows.Visibility.Visible;
#endif
                m_inEditMode = true;
                GetDeviceByDeviceID(m_deviceID);
            }
            else if (m_deviceToCopy == null)
                ClearForm();
            else
            {
                PopulateFormFields(m_deviceToCopy);
                //TextBoxAcronym.Focus();
                TextBoxAcronym.SelectAll();
            }            
        }

        #endregion

        #region [ Methods ]

        void ClearForm()
        {
            GridDeviceDetail.DataContext = new Device()
            {
                Longitude = -98.6m,
                Latitude = 37.5m,
                FramesPerSecond = 30,
                DataLossInterval = 5,
                AllowedParsingExceptions = 10,
                ParsingExceptionWindow = 5,
                DelayedConnectionInterval = 5,
                AllowUseOfCachedConfiguration = true,
                AutoStartDataParsingSequence = true,
                MeasurementReportingInterval = 100000,
                MeasuredLines = 1
            };

            if (ComboboxCompany.Items.Count > 0)
                ComboboxCompany.SelectedIndex = 0;

            if (ComboboxHistorian.Items.Count > 0)
                ComboboxHistorian.SelectedIndex = 0;

            if (ComboboxInterconnection.Items.Count > 0)
                ComboboxInterconnection.SelectedIndex = 0;

            if (ComboboxNode.Items.Count > 0)
                ComboboxNode.SelectedIndex = 0;

            if (ComboboxParent.Items.Count > 0)
                ComboboxParent.SelectedIndex = 0;

            if (ComboboxProtocol.Items.Count > 0)
                ComboboxProtocol.SelectedIndex = 0;

            if (ComboboxTimeZone.Items.Count > 0)
                ComboboxTimeZone.SelectedIndex = 0;

            if (ComboboxVendorDevice.Items.Count > 0)
                ComboboxVendorDevice.SelectedIndex = 0;

            TextBlockRuntimeID.Text = string.Empty;
            ButtonInitialize.Visibility = System.Windows.Visibility.Collapsed;

            m_inEditMode = false;
            m_deviceID = 0;

            StackPanelDeviceList.Visibility = Visibility.Collapsed;
            StackPanelPhasorsMeassurements.Visibility = Visibility.Collapsed;
        }

        #endregion
    }
}
