//******************************************************************************************************
//  CalculatedMeasurementsUserControl.xaml.cs - Gbtc
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
//  07/09/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using openPDCManager.Utilities;
#if SILVERLIGHT
using openPDCManager.PhasorDataServiceProxy;
using openPDCManager.ModalDialogs;
using System.Windows.Media.Animation;
#else
using openPDCManager.Data.Entities;
using openPDCManager.ModalDialogs;
using System.Windows.Media.Imaging;
#endif

namespace openPDCManager.UserControls.CommonControls
{
    public partial class CalculatedMeasurementsUserControl : UserControl
    {
        #region [ Members ]
                
        bool m_inEditMode = false;
        int m_calculatedMeasurementID = 0;
        string m_nodeID;

        #endregion

        #region [ Constructor ]

        public CalculatedMeasurementsUserControl()
        {            
            InitializeComponent();
            Initialize();
#if !SILVERLIGHT
            ButtonSave.Content = new BitmapImage(new Uri("images/Save.png", UriKind.Relative));
            ButtonClear.Content = new BitmapImage(new Uri("images/Cancel.png", UriKind.Relative));            
            UpdateLayout();
#else
            ButtonDownsamplingMethodHelp.Visibility = Visibility.Collapsed;
            ButtonLagTimeHelp.Visibility = Visibility.Collapsed;
            ButtonLeadTimeHelp.Visibility = Visibility.Collapsed;
            ButtonTimeResolutionHelp.Visibility = Visibility.Collapsed;
#endif
            Loaded += new RoutedEventHandler(CalculatedMeasurementsUserControl_Loaded);
            ButtonInitialize.Visibility = System.Windows.Visibility.Collapsed;
            ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
            ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
            ListBoxCalculatedMeasurementList.SelectionChanged += new SelectionChangedEventHandler(ListBoxCalculatedMeasurementList_SelectionChanged);
        }

        #endregion
               
        #region [ Methods ]

        void ClearForm()
        {
            GridCalculatedMeasurementDetail.DataContext = new CalculatedMeasurement()
            {
                AllowPreemptivePublishing = true,
                TimeResolution = 330000,
                AllowSortsByArrival = true,
                LeadTime = 1.0,
                LagTime = 3.0,
                FramesPerSecond = 30,
                MinimumMeasurementsToUse = -1
            };
            if (ComboBoxNode.Items.Count > 0)
                ComboBoxNode.SelectedIndex = 0;
            if (ComboboxDownsamplingMethod.Items.Count > 0)
                ComboboxDownsamplingMethod.SelectedIndex = 0;
            m_inEditMode = false;
            m_calculatedMeasurementID = 0;
            ListBoxCalculatedMeasurementList.SelectedIndex = -1;
            TextBlockRuntimeID.Text = string.Empty;
            ButtonInitialize.Visibility = System.Windows.Visibility.Collapsed;
            ButtonSave.Tag = "Add";
        }

        bool IsValid()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(TextBoxAcronym.Text.CleanText()))
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Acronym", SystemMessage = "Please provide valid Acronym.", UserMessageType = MessageType.Error },
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

            if (string.IsNullOrEmpty(TextBoxAssemblyName.Text.CleanText()))
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Assembly Name", SystemMessage = "Please provide valid Assembly Name.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxAssemblyName.Focus();
                });
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
#endif
                sm.ShowPopup();
                return isValid;
            }

            if (string.IsNullOrEmpty(TextBoxTypeName.Text.CleanText()))
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Type Name", SystemMessage = "Please provide valid Type Name.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxTypeName.Focus();
                });
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
#endif
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxMinMeasurements.Text.IsInteger())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Minimum Measurements to Use", SystemMessage = "Please provide valid integer value for Minimum Measurements to Use.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxMinMeasurements.Focus();
                });
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
#endif
                sm.ShowPopup();

                return isValid;
            }

            if (!TextBoxFramesPerSecond.Text.IsInteger())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Frames Per Second", SystemMessage = "Please provide valid integer value for Frames Per Second.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxFramesPerSecond.Focus();
                });
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
#endif
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxLagTime.Text.IsDouble())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Lag Time", SystemMessage = "Please provide valid numeric value for Lag Time.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxLagTime.Focus();
                });
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
#endif
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxLeadTime.Text.IsDouble())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Lead Time", SystemMessage = "Please provide valid numeric value for Lead Time.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxLeadTime.Focus();
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

            if (!TextBoxTimeResolution.Text.IsInteger())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Time Resolution", SystemMessage = "Please provide valid integer value for Time Resolution.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxTimeResolution.Text = "330000";
                    TextBoxTimeResolution.Focus();
                });
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
#endif
                sm.ShowPopup();
                return isValid;
            }

            return isValid;
        }

        #endregion

        #region [ Control Event Handlers ]

        void CalculatedMeasurementsUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ClearForm();
            App app = (App)Application.Current;
            m_nodeID = app.NodeValue;            
            GetNodes();
            ComboboxDownsamplingMethod.Items.Add("LastReceived");
            ComboboxDownsamplingMethod.Items.Add("Closest");
            ComboboxDownsamplingMethod.Items.Add("Filtered");
            ComboboxDownsamplingMethod.Items.Add("BestQuality");
            ComboboxDownsamplingMethod.SelectedIndex = 0;
            GetCalculatedMeasurements();
        }

        void ListBoxCalculatedMeasurementList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxCalculatedMeasurementList.SelectedIndex >= 0)
            {
                CalculatedMeasurement selectedCalculatedMeasurement = ListBoxCalculatedMeasurementList.SelectedItem as CalculatedMeasurement;
                GridCalculatedMeasurementDetail.DataContext = selectedCalculatedMeasurement;
                ComboBoxNode.SelectedItem = new KeyValuePair<string, string>(selectedCalculatedMeasurement.NodeId, selectedCalculatedMeasurement.NodeName);
                ComboboxDownsamplingMethod.SelectedItem = selectedCalculatedMeasurement.DownsamplingMethod;
                m_calculatedMeasurementID = selectedCalculatedMeasurement.ID;
                m_inEditMode = true;
                DisplayRuntimeID();
                ButtonInitialize.Visibility = System.Windows.Visibility.Visible;
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
                CalculatedMeasurement calculatedMeasurement = new CalculatedMeasurement();
                calculatedMeasurement.NodeId = ((KeyValuePair<string, string>)ComboBoxNode.SelectedItem).Key;
                calculatedMeasurement.Acronym = TextBoxAcronym.Text.CleanText();
                calculatedMeasurement.Name = TextBoxName.Text.CleanText();
                calculatedMeasurement.AssemblyName = TextBoxAssemblyName.Text.CleanText();
                calculatedMeasurement.TypeName = TextBoxTypeName.Text.CleanText();
                calculatedMeasurement.ConnectionString = TextBoxConnectionString.Text.CleanText();
                calculatedMeasurement.ConfigSection = TextBoxConfigSection.Text.CleanText();
                calculatedMeasurement.InputMeasurements = TextBoxInputMeasurements.Text.CleanText();
                calculatedMeasurement.OutputMeasurements = TextBoxOutputMeasurements.Text.CleanText();
                calculatedMeasurement.MinimumMeasurementsToUse = TextBoxMinMeasurements.Text.ToInteger();
                calculatedMeasurement.FramesPerSecond = TextBoxFramesPerSecond.Text.ToInteger();
                calculatedMeasurement.LagTime = TextBoxLagTime.Text.ToDouble();
                calculatedMeasurement.LeadTime = TextBoxLeadTime.Text.ToDouble();
                calculatedMeasurement.UseLocalClockAsRealTime = (bool)CheckBoxUseLocalClock.IsChecked;
                calculatedMeasurement.AllowSortsByArrival = (bool)CheckBoxAllowSorts.IsChecked;
                calculatedMeasurement.LoadOrder = TextBoxLoadOrder.Text.ToInteger();
                calculatedMeasurement.Enabled = (bool)CheckBoxEnabled.IsChecked;
                calculatedMeasurement.IgnoreBadTimeStamps = (bool)CheckBoxIgnoreBadTimeStamps.IsChecked;
                calculatedMeasurement.TimeResolution = TextBoxTimeResolution.Text.ToInteger();
                calculatedMeasurement.AllowPreemptivePublishing = (bool)CheckBoxAllowPreemptivePublishing.IsChecked;
                calculatedMeasurement.DownsamplingMethod = ComboboxDownsamplingMethod.SelectedItem.ToString();
                calculatedMeasurement.PerformTimestampReasonabilityCheck = (bool)CheckBoxPerformTimestampCheck.IsChecked;

                if (m_inEditMode == true && m_calculatedMeasurementID > 0)
                {
                    calculatedMeasurement.ID = m_calculatedMeasurementID;
                    SaveCalculatedMeasurement(calculatedMeasurement, false);                    
                }
                else
                    SaveCalculatedMeasurement(calculatedMeasurement, true);
            }
        }

        void ButtonInitialize_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Do you want to send Initialize command?", SystemMessage = "Calculated Measurement Acronym: " + ((Button)sender).Tag.ToString(), UserMessageType = MessageType.Confirmation }, ButtonType.YesNo);
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
    }
}
