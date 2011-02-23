//******************************************************************************************************
//  OutputStreamsUserControl.xaml.cs - Gbtc
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
//  07/28/2010 - Mehulbhai P Thakkar
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
using openPDCManager.ModalDialogs.OutputStreamWizard;
#if SILVERLIGHT
using openPDCManager.PhasorDataServiceProxy;
#else
using openPDCManager.Data.Entities;
using System.Windows.Media.Imaging;
using openPDCManager.Data;
using System.Threading;
#endif

namespace openPDCManager.UserControls.OutputStreamControls
{
    public partial class OutputStreamsUserControl : UserControl
    {
        #region [ Members ]
                
        bool m_inEditMode = false;
        int m_outputStreamID = 0;
        string m_nodeValue;
        string m_oldAcronym;
        string m_oldName;

        #endregion

        public OutputStreamsUserControl()
        {
            InitializeComponent();
            Initialize();
            ButtonInitialize.Visibility = System.Windows.Visibility.Collapsed;
#if !SILVERLIGHT
            ButtonSave.Content = new BitmapImage(new Uri(@"images/Save.png", UriKind.Relative));
            ButtonClear.Content = new BitmapImage(new Uri(@"images/Cancel.png", UriKind.Relative));
            ButtonBuildCommandChannel.Content = new BitmapImage(new Uri(@"images/Add.png", UriKind.Relative));
            ButtonBuildDataChannel.Content = new BitmapImage(new Uri(@"images/Add.png", UriKind.Relative));
            UpdateLayout();
#else
            ButtonAllowPreemptivePublishingHelp.Visibility = Visibility.Collapsed;
            ButtonAllowSortsByArrivalHelp.Visibility = Visibility.Collapsed;
            ButtonAutoPublishConfigFrameHelp.Visibility = Visibility.Collapsed;
            ButtonDownsamplingMethodHelp.Visibility = Visibility.Collapsed;
            ButtonIgnoreBadTimeStampsHelp.Visibility = Visibility.Collapsed;
            ButtonStartDataChannelHelp.Visibility = Visibility.Collapsed;
            ButtonTimeResolutionHelp.Visibility = Visibility.Collapsed;
            ButtonUseLocalClockAsRealTimeHelp.Visibility = Visibility.Collapsed;
            ButtonLagTimeHelp.Visibility = Visibility.Collapsed;
            ButtonLeadTimeHelp.Visibility = Visibility.Collapsed;
#endif
            ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
            ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
            ListBoxOutputStreamList.SelectionChanged += new SelectionChangedEventHandler(ListBoxOutputStreamList_SelectionChanged);
            Loaded += new RoutedEventHandler(OutputStreams_Loaded);
            ButtonBuildCommandChannel.Click += new RoutedEventHandler(ButtonBuildCommandChannel_Click);
            ButtonBuildDataChannel.Click += new RoutedEventHandler(ButtonBuildDataChannel_Click);
        }

        #region [ Page Event Handlers ]

        void OutputStreams_Loaded(object sender, RoutedEventArgs e)
        {
            m_nodeValue = ((App)Application.Current).NodeValue;
            GetNodes();
            ComboBoxType.Items.Add(new KeyValuePair<int, string>(0, "IEEE C37.118"));
            ComboBoxType.Items.Add(new KeyValuePair<int, string>(1, "BPA"));
            ComboBoxType.SelectedIndex = 0;
            ComboboxDownsamplingMethod.Items.Add("LastReceived");
            ComboboxDownsamplingMethod.Items.Add("Closest");
            ComboboxDownsamplingMethod.Items.Add("Filtered");
            ComboboxDownsamplingMethod.Items.Add("BestQuality");
            ComboboxDownsamplingMethod.SelectedIndex = 0;
            ComboboxDataFormat.Items.Add("FloatingPoint");
            ComboboxDataFormat.Items.Add("FixedInteger");
            ComboboxDataFormat.SelectedIndex = 0;
            ComboboxCoordinateFormat.Items.Add("Polar");
            ComboboxCoordinateFormat.Items.Add("Rectangular");
            ComboboxCoordinateFormat.SelectedIndex = 0;
            ClearForm();
            GetOutputStreamList();
            ChangeAdvancedOptionsVisibility(Visibility.Collapsed);
              
        }

        #endregion

        #region [ Control Event Handlers ]

        void ListBoxOutputStreamList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxOutputStreamList.SelectedIndex >= 0)
            {
                OutputStream selectedOutputStream = ListBoxOutputStreamList.SelectedItem as OutputStream;                
                m_outputStreamID = selectedOutputStream.ID;
                m_inEditMode = true;
                PopulateFormFields(selectedOutputStream);
                DisplayRuntimeID();
                ButtonSave.Tag = "Update";
            }
        }

        void PopulateFormFields(OutputStream selectedOutputStream)
        {
            GridOutputStreamDetail.DataContext = selectedOutputStream;
            ComboBoxNode.SelectedItem = new KeyValuePair<string, string>(selectedOutputStream.NodeID, selectedOutputStream.NodeName);
            if (selectedOutputStream.Type == 0)
                ComboBoxType.SelectedItem = new KeyValuePair<int, string>(0, "IEEE C37.118");
            else
                ComboBoxType.SelectedItem = new KeyValuePair<int, string>(1, "BPA");
            ComboboxCoordinateFormat.SelectedItem = selectedOutputStream.CoordinateFormat;
            ComboboxDownsamplingMethod.SelectedItem = selectedOutputStream.DownsamplingMethod;
            ComboboxDataFormat.SelectedItem = selectedOutputStream.DataFormat;
            CheckBoxAllowSortsByArrival.IsChecked = selectedOutputStream.AllowSortsByArrival;
            CheckBoxAutoPublishConfigFrame.IsChecked = selectedOutputStream.AutoPublishConfigFrame;
            CheckBoxAutoStartDataChannel.IsChecked = selectedOutputStream.AutoStartDataChannel;
            CheckBoxEnabled.IsChecked = selectedOutputStream.Enabled;
            CheckBoxUseLocalClockAsRealTime.IsChecked = selectedOutputStream.UseLocalClockAsRealTime;
            CheckBoxPerformTimestampCheck.IsChecked = selectedOutputStream.PerformTimestampReasonabilityCheck;

            m_oldAcronym = selectedOutputStream.Acronym;
            m_oldName = selectedOutputStream.Name;
            
#if !SILVERLIGHT
            if (m_inEditMode)
                ButtonInitialize.Visibility = System.Windows.Visibility.Visible;
#endif
            TextBoxAcronym.SelectAll();
            TextBoxAcronym.Focus();
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
                OutputStream outputStream = new OutputStream();
                outputStream.NodeID = ((KeyValuePair<string, string>)ComboBoxNode.SelectedItem).Key;
                outputStream.Acronym = TextBoxAcronym.Text.CleanText();
                outputStream.Name = TextBoxName.Text.CleanText();
                outputStream.Type = ((KeyValuePair<int, string>)ComboBoxType.SelectedItem).Key;
                outputStream.ConnectionString = TextBoxConnectionString.Text.CleanText();
                outputStream.IDCode = TextBoxIDCode.Text.ToInteger();
                outputStream.CommandChannel = TextBoxCommandChannel.Text.CleanText();
                outputStream.DataChannel = TextBoxDataChannel.Text.CleanText();
                outputStream.AutoPublishConfigFrame = (bool)CheckBoxAutoPublishConfigFrame.IsChecked;
                outputStream.AutoStartDataChannel = (bool)CheckBoxAutoStartDataChannel.IsChecked;
                outputStream.NominalFrequency = TextBoxNominalFrequency.Text.ToInteger();
                outputStream.FramesPerSecond = TextBoxFramesPerSecond.Text.ToInteger();
                outputStream.LagTime = TextBoxLagTime.Text.ToDouble();
                outputStream.LeadTime = TextBoxLeadTime.Text.ToDouble();
                outputStream.UseLocalClockAsRealTime = (bool)CheckBoxUseLocalClockAsRealTime.IsChecked;
                outputStream.AllowSortsByArrival = (bool)CheckBoxAllowSortsByArrival.IsChecked;
                outputStream.LoadOrder = TextBoxLoadOrder.Text.ToInteger();
                outputStream.Enabled = (bool)CheckBoxEnabled.IsChecked;
                outputStream.IgnoreBadTimeStamps = (bool)CheckBoxIgnoreBadTimeStamps.IsChecked;
                outputStream.TimeResolution = TextBoxTimeResolution.Text.ToInteger();
                outputStream.AllowPreemptivePublishing = (bool)CheckBoxAllowPreemptivePublishing.IsChecked;
                outputStream.DownsamplingMethod = ComboboxDownsamplingMethod.SelectedItem.ToString();
                outputStream.DataFormat = ComboboxDataFormat.SelectedItem.ToString();
                outputStream.CoordinateFormat = ComboboxCoordinateFormat.SelectedItem.ToString();
                outputStream.CurrentScalingValue = TextBoxCurrentScalingValue.Text.ToInteger();
                outputStream.VoltageScalingValue = TextBoxVoltageScalingValue.Text.ToInteger();
                outputStream.AnalogScalingValue = TextBoxAnalogScalingValue.Text.ToInteger();
                outputStream.DigitalMaskValue = TextBoxDigitalMaskValue.Text.ToInteger();
                outputStream.PerformTimestampReasonabilityCheck = (bool)CheckBoxPerformTimestampCheck.IsChecked;

                if (m_inEditMode == true && m_outputStreamID > 0)
                {
                    outputStream.ID = m_outputStreamID;
                    SaveOutputStream(outputStream, false);                    
                }
                else
                    SaveOutputStream(outputStream, true);                    
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

        void ButtonDevices_Click(object sender, RoutedEventArgs e)
        {
            int outputStreamId = Convert.ToInt32(((Button)sender).Tag.ToString());
            string acronym = ToolTipService.GetToolTip((Button)sender).ToString();
            OutputStreamDevices osd = new OutputStreamDevices(outputStreamId, acronym);

#if SILVERLIGHT
            osd.Show();
#else
            osd.Owner = Window.GetWindow(this);
            osd.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            osd.ShowDialog();
#endif      
        }

        void ButtonMeasurements_Click(object sender, RoutedEventArgs e)
        {
            int outputStreamId = Convert.ToInt32(((Button)sender).Tag.ToString());

            string acronym = ToolTipService.GetToolTip((Button)sender).ToString();      //((Button)sender).Name;
            OutputStreamMeasurements osm = new OutputStreamMeasurements(outputStreamId, acronym);
#if SILVERLIGHT
            osm.Show();
#else
            osm.Owner = Window.GetWindow(this);
            osm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            osm.ShowDialog();
#endif
        }

        void ButtonWizard_Click(object sender, RoutedEventArgs e)
        {
            int outputStreamId = Convert.ToInt32(((Button)sender).Tag.ToString());
            string acronym = ToolTipService.GetToolTip((Button)sender).ToString();
            CurrentDevices currentDevices = new CurrentDevices(outputStreamId, acronym);
#if SILVERLIGHT
            currentDevices.Show();
#else
            currentDevices.Owner = Window.GetWindow(this);
            currentDevices.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            currentDevices.ShowDialog();
#endif
        }

        void ButtonBuildDataChannel_Click(object sender, RoutedEventArgs e)
        {
            ConnectionStringBuilder csb = new ConnectionStringBuilder(ConnectionStringBuilder.ConnectionType.DataChannel);
            if (!string.IsNullOrEmpty(TextBoxDataChannel.Text))
                csb.ConnectionString = TextBoxDataChannel.Text;
            csb.Closed += new EventHandler(delegate(object popupWindow, EventArgs eargs)
            {
                if ((bool)csb.DialogResult)
                    TextBoxDataChannel.Text = csb.ConnectionString;
            });
#if !SILVERLIGHT
            csb.Owner = Window.GetWindow(this);
            csb.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            csb.ShowDialog();
#else
            csb.Show();
#endif

        }

        void ButtonBuildCommandChannel_Click(object sender, RoutedEventArgs e)
        {
            ConnectionStringBuilder csb = new ConnectionStringBuilder(ConnectionStringBuilder.ConnectionType.CommandChannel);
            if (!string.IsNullOrEmpty(TextBoxCommandChannel.Text))
                csb.ConnectionString = TextBoxCommandChannel.Text;
            csb.Closed += new EventHandler(delegate(object popupWindow, EventArgs eargs)
            {
                if ((bool)csb.DialogResult)
                    TextBoxCommandChannel.Text = csb.ConnectionString;
            });
#if !SILVERLIGHT
            csb.Owner = Window.GetWindow(this);
            csb.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            csb.ShowDialog();
#else
            csb.Show();
#endif
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

        void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            bool continueAllowed = true;

#if !SILVERLIGHT
            if (!((App)Application.Current).Principal.IsInRole("Administrator, Editor"))
            {
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Unauthorized Access", SystemMessage = "You are not authorized to perform this operation.", UserMessageType = MessageType.Error },
                            ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
                continueAllowed = false;
            }
#endif
            if (continueAllowed)
            {
                try
                {
                    int outputStreamId;
                    Button deleteButton = (Button)sender;

                    SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Do you want to delete output stream?", SystemMessage = "Output Stream Acronym: " + ToolTipService.GetToolTip(deleteButton).ToString(), UserMessageType = MessageType.Confirmation }, ButtonType.YesNo);
                    sm.Closed += new EventHandler(delegate(object popupWindow, EventArgs eargs)
                    {
                        if ((bool)sm.DialogResult)
                        {
                            try
                            {
                                if (int.TryParse(((Button)sender).Tag.ToString(), out outputStreamId))
                                    DeleteOutputStream(outputStreamId);

                                ClearForm();
                            }
                            catch (Exception ex)
                            {
                                SystemMessages sm1 = new SystemMessages(new Message() { UserMessage = "Failed to delete output stream.", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                                    ButtonType.OkOnly);
#if !SILVERLIGHT
                                CommonFunctions.LogException(null, "ButtonDelete_Click", ex);
                                sm1.Owner = Window.GetWindow(this);
                                sm1.WindowStartupLocation = WindowStartupLocation.CenterOwner;
#endif
                                sm1.ShowPopup();
                                
                            }
                        }
                    });
#if !SILVERLIGHT
                    sm.Owner = Window.GetWindow(this);
                    sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
#endif
                    sm.ShowPopup();
                }
                catch (Exception ex)
                {
                    SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to delete output stream.", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                            ButtonType.OkOnly);
#if !SILVERLIGHT
                    sm.Owner = Window.GetWindow(this);
                    sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
#endif
                    sm.ShowPopup();
                }
            }
        }

        void ButtonInitialize_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Do you want to send Initialize command?", SystemMessage = "Output Stream Acronym: " + ((Button)sender).Tag.ToString(), UserMessageType = MessageType.Confirmation }, ButtonType.YesNo);
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

        void ButtonUpdateConfig_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Do you want to update configuration?", SystemMessage = "", UserMessageType = MessageType.Confirmation }, ButtonType.YesNo);
                sm.Closed += new EventHandler(delegate(object popupWindow, EventArgs eargs)
                {
                    if ((bool)sm.DialogResult)
                        SendUpdateConfiguration(Convert.ToInt32(((Button) sender).Tag));
                });

#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
#endif
                sm.ShowPopup();
            }
            catch (Exception ex)
            {
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to send Update Configuration command.", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
#endif
                sm.ShowPopup();
            }
        }

        void ButtonMakeCopy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearForm();
                OutputStream outputStreamToCopy = (OutputStream)((Button)sender).DataContext;
                
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Do you want to make a copy of " + outputStreamToCopy.Acronym + " output stream?", SystemMessage = "This will only copy the output stream configuration, not associated devices.", UserMessageType = MessageType.Confirmation }, ButtonType.YesNo);
                sm.Closed += new EventHandler(delegate(object popupWindow, EventArgs eargs)
                {
                    if ((bool)sm.DialogResult)
                    {
                        outputStreamToCopy.Name = "Copy of " + outputStreamToCopy.Name;
                        outputStreamToCopy.Enabled = false;
#if SILVERLIGHT
                        outputStreamToCopy.Acronym = outputStreamToCopy.Acronym + "1";                        
                        PopulateFormFields(outputStreamToCopy);
#else
                        string originalAcronym = outputStreamToCopy.Acronym;
                        string nodeID = ((App)Application.Current).NodeValue;
                        int i = 1;
                        do
                        {
                            outputStreamToCopy.Acronym = originalAcronym + i.ToString();
                            i++;
                        } while (CommonFunctions.GetOutputStreamByAcronym(null, outputStreamToCopy.Acronym, nodeID) != null);
                                                                        
                        PopulateFormFields(outputStreamToCopy);
#endif
                    }
                });
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
#endif
                sm.ShowPopup();
            }
            catch (Exception ex)
            {
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to delete output stream.", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
#endif
                sm.ShowPopup();
            }
        }

        private void ButtonAdvancedOptions_Click(object sender, RoutedEventArgs e)
        {
            if (StackPanelTimeResolution.Visibility == System.Windows.Visibility.Visible)
            {
                ChangeAdvancedOptionsVisibility(Visibility.Collapsed);
                ScrollViewerList.Height = 450;
            }
            else
            {
                ChangeAdvancedOptionsVisibility(Visibility.Visible);
                ScrollViewerList.Height = 265;
            }
        }

        #endregion

        #region [ Methods ]

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

#endif
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxIDCode.Text.IsInteger() || Convert.ToInt32(TextBoxIDCode.Text) < 0)
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid ID Code", SystemMessage = "Please provide valid integer value for ID Code.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxIDCode.Focus();
                });
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxNominalFrequency.Text.IsInteger())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Nominal Frequency", SystemMessage = "Please provide valid integer value for Nominal Frequency.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxNominalFrequency.Focus();
                });
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
                    TextBoxTimeResolution.Focus();
                });
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxCurrentScalingValue.Text.IsInteger())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Current Scaling Value", SystemMessage = "Please provide valid integer value for Current Scaling Value.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxCurrentScalingValue.Focus();
                });
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxVoltageScalingValue.Text.IsInteger())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Voltage Scaling Value", SystemMessage = "Please provide valid integer value for Voltage Scaling Value.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxVoltageScalingValue.Focus();
                });
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxAnalogScalingValue.Text.IsInteger())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Analog Scaling Value", SystemMessage = "Please provide valid integer value for Analog Scaling Value.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxAnalogScalingValue.Focus();
                });
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxDigitalMaskValue.Text.IsInteger())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Digital Mask Value", SystemMessage = "Please provide valid integer value for Digital Mask Value.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxDigitalMaskValue.Focus();
                });
                sm.ShowPopup();
                return isValid;
            }

            return isValid;
        }

        void ClearForm()
        {
            GridOutputStreamDetail.DataContext = new OutputStream()
            {
                AutoStartDataChannel = true,
                NominalFrequency = 60,
                FramesPerSecond = 30,
                LagTime = 3,
                LeadTime = 1,
                AllowSortsByArrival = true,
                TimeResolution = 330000,
                AllowPreemptivePublishing = true,
                CurrentScalingValue = 2423,
                VoltageScalingValue = 2725785,
                AnalogScalingValue = 1373291,
                DigitalMaskValue = -65536
            };
            if (ComboBoxNode.Items.Count > 0)
                ComboBoxNode.SelectedIndex = 0;
            if (ComboBoxType.Items.Count > 0)
                ComboBoxType.SelectedIndex = 0;
            if (ComboboxDownsamplingMethod.Items.Count > 0)
                ComboboxDownsamplingMethod.SelectedIndex = 0;
            if (ComboboxCoordinateFormat.Items.Count > 0)
                ComboboxCoordinateFormat.SelectedIndex = 0;
            if (ComboboxDataFormat.Items.Count > 0)
                ComboboxDataFormat.SelectedIndex = 0;
            CheckBoxAllowSortsByArrival.IsChecked = false;
            CheckBoxAutoPublishConfigFrame.IsChecked = false;
            CheckBoxAutoStartDataChannel.IsChecked = false;
            CheckBoxEnabled.IsChecked = false;
            CheckBoxUseLocalClockAsRealTime.IsChecked = false;
            CheckBoxPerformTimestampCheck.IsChecked = false;
            m_inEditMode = false;
            m_outputStreamID = 0;
            ListBoxOutputStreamList.SelectedIndex = -1;
            TextBlockRuntimeID.Text = string.Empty;
            ButtonInitialize.Visibility = System.Windows.Visibility.Collapsed;
            ButtonSave.Tag = "Add";
        }

        void ChangeAdvancedOptionsVisibility(Visibility visibility)
        {            
            StackPanelTimeResolution.Visibility = visibility;
            TextBoxTimeResolution.Visibility = visibility;
            StackPanelDownsamplingMethod.Visibility = visibility;
            ComboboxDownsamplingMethod.Visibility = visibility;
            StackPanelDataFormat.Visibility = visibility;
            ComboboxDataFormat.Visibility = visibility;
            StackPanelCoordinateFormat.Visibility = visibility;
            ComboboxCoordinateFormat.Visibility = visibility;
            StackPanelCurrentScalingValue.Visibility = visibility;
            TextBoxCurrentScalingValue.Visibility = visibility;
            StackPanelVoltageScalingValue.Visibility = visibility;
            TextBoxVoltageScalingValue.Visibility = visibility;
            StackPanelAnalogScalingValue.Visibility = visibility;
            TextBoxAnalogScalingValue.Visibility = visibility;
            StackPanelDigitalMaskValue.Visibility = visibility;
            TextBoxDigitalMaskValue.Visibility = visibility;
            CheckBoxAutoStartDataChannel.Visibility = visibility;
            CheckBoxAutoPublishConfigFrame.Visibility = visibility;
            CheckBoxAllowSortsByArrival.Visibility = visibility;
            CheckBoxUseLocalClockAsRealTime.Visibility = visibility;
            CheckBoxAllowPreemptivePublishing.Visibility = visibility;
            CheckBoxIgnoreBadTimeStamps.Visibility = visibility;
            CheckBoxPerformTimestampCheck.Visibility = visibility;

#if !SILVERLIGHT
            ButtonAllowPreemptivePublishingHelp.Visibility = visibility;
            ButtonAllowSortsByArrivalHelp.Visibility = visibility;
            ButtonAutoPublishConfigFrameHelp.Visibility = visibility;
            ButtonDownsamplingMethodHelp.Visibility = visibility;
            ButtonIgnoreBadTimeStampsHelp.Visibility = visibility;
            ButtonStartDataChannelHelp.Visibility = visibility;
            ButtonTimeResolutionHelp.Visibility = visibility;
            ButtonUseLocalClockAsRealTimeHelp.Visibility = visibility;
#endif
            
        }

        #endregion

    }
}
