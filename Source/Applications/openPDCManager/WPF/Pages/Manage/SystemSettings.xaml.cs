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
using System.Threading;

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
            //Load Default Settings.
            IsolatedStorageManager.SetDefaultStorage(true);
            
            LoadSettingsFromIsolatedStorage();

            SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Successfully Restored Default System Settings", SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
            sm.Owner = Window.GetWindow(this);
            sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            sm.ShowPopup();
        }

        void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid())
            { 
                IsolatedStorageManager.SaveIntoIsolatedStorage("ForceIPv4", (bool)CheckboxForceIPv4.IsChecked);
                IsolatedStorageManager.SaveIntoIsolatedStorage("NumberOfMessages", TextBoxNumberOfMessagesOnMonitor.Text);
                IsolatedStorageManager.SaveIntoIsolatedStorage("InputMonitoringPoints", TextBoxLastSettings.Text);
                IsolatedStorageManager.SaveIntoIsolatedStorage("NumberOfDataPointsToPlot", TextBoxNumberOfDataPoints.Text);
                IsolatedStorageManager.SaveIntoIsolatedStorage("DataResolution", TextBoxFramesPerSecond.Text);
                IsolatedStorageManager.SaveIntoIsolatedStorage("LagTime", TextBoxLagTime.Text);
                IsolatedStorageManager.SaveIntoIsolatedStorage("LeadTime", TextBoxLeadTime.Text);
                IsolatedStorageManager.SaveIntoIsolatedStorage("UseLocalClockAsRealtime", (bool)CheckboxUseLocalClockAsRealtime.IsChecked);
                IsolatedStorageManager.SaveIntoIsolatedStorage("IgnoreBadTimestamps", (bool)CheckboxIngnoreBadTimestamps.IsChecked);
                IsolatedStorageManager.SaveIntoIsolatedStorage("ChartRefreshInterval", TextBoxChartRefreshInterval.Text);
                IsolatedStorageManager.SaveIntoIsolatedStorage("StatisticsDataRefreshInterval", TextBoxStatisticsDataRefreshInterval.Text);
                IsolatedStorageManager.SaveIntoIsolatedStorage("MeasurementsDataRefreshInterval", TextBoxMeasurementsDataRefreshInterval.Text);                
                IsolatedStorageManager.SaveIntoIsolatedStorage("DisplayXAxis", (bool)CheckboxDisplayXAxis.IsChecked);                
                IsolatedStorageManager.SaveIntoIsolatedStorage("DisplayFrequencyYAxis", (bool)CheckboxDisplayFrequencyAxis.IsChecked);                
                IsolatedStorageManager.SaveIntoIsolatedStorage("DisplayPhaseAngleYAxis", (bool)CheckboxDisplayPhaseAngleAxis.IsChecked);                
                IsolatedStorageManager.SaveIntoIsolatedStorage("DisplayVoltageYAxis", (bool)CheckboxDisplayVoltageAxis.IsChecked);                
                IsolatedStorageManager.SaveIntoIsolatedStorage("DisplayCurrentYAxis", (bool)CheckboxDisplayCurrentAxis.IsChecked);
                IsolatedStorageManager.SaveIntoIsolatedStorage("FrequencyRangeMin", TextBoxFrequencyRangeMin.Text);
                IsolatedStorageManager.SaveIntoIsolatedStorage("FrequencyRangeMax", TextBoxFrequencyRangeMax.Text);
                IsolatedStorageManager.SaveIntoIsolatedStorage("DisplayLegend", (bool)CheckboxDisplayLegend.IsChecked);

                LoadSettingsFromIsolatedStorage();

                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Successfully Saved System Settings", SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                            ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        void ButtonHelp_Click(object sender, RoutedEventArgs e)
        {
#if !SILVERLIGHT
            HelpMeChoose hmc = new HelpMeChoose(((Button)sender).Tag.ToString());
            hmc.Owner = Window.GetWindow(this);
            hmc.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            hmc.ShowDialog();
#endif
        }

        #endregion

        #region [ Page Event Handlers ]

        void SystemSettings_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSettingsFromIsolatedStorage();
            if (((App)Application.Current).Principal.IsInRole("Administrator, Editor"))
            {
                ButtonSave.IsEnabled = true;
                ButtonClear.IsEnabled = true;
            }
            else
            {
                ButtonSave.IsEnabled = false;
                ButtonClear.IsEnabled = false;
            }
        }
        
        #endregion

        #region [ Methods ]

        void LoadSettingsFromIsolatedStorage()
        {
            TextBoxNumberOfMessagesOnMonitor.Text = IsolatedStorageManager.ReadFromIsolatedStorage("NumberOfMessages").ToString();            
            CheckboxForceIPv4.IsChecked = Convert.ToBoolean(IsolatedStorageManager.ReadFromIsolatedStorage("ForceIPv4"));
            TextBoxLastSettings.Text = IsolatedStorageManager.ReadFromIsolatedStorage("InputMonitoringPoints").ToString();
            TextBoxNumberOfDataPoints.Text = IsolatedStorageManager.ReadFromIsolatedStorage("NumberOfDataPointsToPlot").ToString();
            TextBoxFramesPerSecond.Text = IsolatedStorageManager.ReadFromIsolatedStorage("DataResolution").ToString();
            TextBoxLagTime.Text = IsolatedStorageManager.ReadFromIsolatedStorage("LagTime").ToString();
            TextBoxLeadTime.Text = IsolatedStorageManager.ReadFromIsolatedStorage("LeadTime").ToString();
            CheckboxUseLocalClockAsRealtime.IsChecked = Convert.ToBoolean(IsolatedStorageManager.ReadFromIsolatedStorage("UseLocalClockAsRealtime"));
            CheckboxIngnoreBadTimestamps.IsChecked = Convert.ToBoolean(IsolatedStorageManager.ReadFromIsolatedStorage("IgnoreBadTimestamps"));
            TextBoxChartRefreshInterval.Text = IsolatedStorageManager.ReadFromIsolatedStorage("ChartRefreshInterval").ToString();
            TextBoxStatisticsDataRefreshInterval.Text = IsolatedStorageManager.ReadFromIsolatedStorage("StatisticsDataRefreshInterval").ToString();
            TextBoxMeasurementsDataRefreshInterval.Text = IsolatedStorageManager.ReadFromIsolatedStorage("MeasurementsDataRefreshInterval").ToString();
            CheckboxDisplayXAxis.IsChecked = Convert.ToBoolean(IsolatedStorageManager.ReadFromIsolatedStorage("DisplayXAxis"));
            CheckboxDisplayFrequencyAxis.IsChecked = Convert.ToBoolean(IsolatedStorageManager.ReadFromIsolatedStorage("DisplayFrequencyYAxis"));
            CheckboxDisplayPhaseAngleAxis.IsChecked = Convert.ToBoolean(IsolatedStorageManager.ReadFromIsolatedStorage("DisplayPhaseAngleYAxis"));
            CheckboxDisplayVoltageAxis.IsChecked = Convert.ToBoolean(IsolatedStorageManager.ReadFromIsolatedStorage("DisplayVoltageYAxis"));
            CheckboxDisplayCurrentAxis.IsChecked = Convert.ToBoolean(IsolatedStorageManager.ReadFromIsolatedStorage("DisplayCurrentYAxis"));
            CheckboxDisplayLegend.IsChecked = Convert.ToBoolean(IsolatedStorageManager.ReadFromIsolatedStorage("DisplayLegend"));
            TextBoxFrequencyRangeMin.Text = IsolatedStorageManager.ReadFromIsolatedStorage("FrequencyRangeMin").ToString();
            TextBoxFrequencyRangeMax.Text = IsolatedStorageManager.ReadFromIsolatedStorage("FrequencyRangeMax").ToString();
        }

        bool IsValid()
        {
            bool isValid = true;

            if (!TextBoxNumberOfMessagesOnMonitor.Text.IsInteger())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Value for Number of Messages on Console", SystemMessage = "Please provide valid integer value for Number of Messages on Console.", UserMessageType = MessageType.Error },
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

            if (!TextBoxNumberOfDataPoints.Text.IsInteger())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Value for Number of Data Points to Plot", SystemMessage = "Please provide valid integer value for Number of Data Points to Plot.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxNumberOfDataPoints.Text = "150";
                    TextBoxNumberOfDataPoints.Focus();
                });
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxFramesPerSecond.Text.IsInteger())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Value for Data Resolution", SystemMessage = "Please provide valid integer value for Deta Resolution (Frames Per Second).", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxFramesPerSecond.Text = "30";
                    TextBoxFramesPerSecond.Focus();
                });
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxLagTime.Text.IsDouble())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Value for Lag Time", SystemMessage = "Please provide valid numeric value for Lag Time.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxLagTime.Text = "3";
                    TextBoxLagTime.Focus();
                });
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxLeadTime.Text.IsDouble())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Value for Lead Time", SystemMessage = "Please provide valid numeric value for Lead Time.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxLeadTime.Text = "1";
                    TextBoxLeadTime.Focus();
                });
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxChartRefreshInterval.Text.IsInteger())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Value for Chart Refresh Interval", SystemMessage = "Please provide valid integer value for Chart Refresh Interval (in miliseconds).", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxChartRefreshInterval.Text = "250";
                    TextBoxChartRefreshInterval.Focus();
                });
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxStatisticsDataRefreshInterval.Text.IsInteger())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Value for Statistics Data Refresh Interval", SystemMessage = "Please provide valid integer value for Statistics Data Refresh Interval (in seconds).", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxStatisticsDataRefreshInterval.Text = "30";
                    TextBoxStatisticsDataRefreshInterval.Focus();
                });
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxMeasurementsDataRefreshInterval.Text.IsInteger())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Value for Measurements Data Refresh Interval", SystemMessage = "Please provide valid integer value for Measurements Data Refresh Interval (in seconds).", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxMeasurementsDataRefreshInterval.Text = "30";
                    TextBoxMeasurementsDataRefreshInterval.Focus();
                });
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
                return isValid;
            }


            if (!TextBoxFrequencyRangeMin.Text.IsDouble())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Value for Frequency Range Min", SystemMessage = "Please provide valid numeric value for Frequency Range Min.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxFrequencyRangeMin.Text = "59.95";
                    TextBoxFrequencyRangeMin.Focus();
                });
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxFrequencyRangeMax.Text.IsDouble())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Value for Frequency Range Max", SystemMessage = "Please provide valid numeric value for Frequency Range Max.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxFrequencyRangeMax.Text = "60.05";
                    TextBoxFrequencyRangeMax.Focus();
                });
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
                return isValid;
            }

            if (Convert.ToDouble(TextBoxFrequencyRangeMax.Text) <= Convert.ToDouble(TextBoxFrequencyRangeMin.Text))
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Frequency Range Max must be higher than Frequency Range Min", SystemMessage = "Please provide higher numeric value for Frequency Range Max.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {                    
                    TextBoxFrequencyRangeMax.Focus();
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
