//******************************************************************************************************
//  OutputStreamDevicesUserControl.xaml.cs - Gbtc
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
//  07/29/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
#if SILVERLIGHT
using openPDCManager.PhasorDataServiceProxy;
using openPDCManager.ModalDialogs.OutputStreamWizard;
#else
using openPDCManager.Data;
using openPDCManager.Data.Entities;
using System.Windows.Media.Imaging;
using openPDCManager.ModalDialogs.OutputStreamWizard;
#endif

namespace openPDCManager.UserControls.PopupControls
{
    public partial class OutputStreamDevicesUserControl : UserControl
    {
        #region [ Members ]

        public int m_sourceOutputStreamID;
        public string m_sourceOutputStreamAcronym;
        bool m_inEditMode = false;
        int m_outputStreamDeviceID = 0;
        OutputStreamDevice m_selectedOutputStreamDevice;
        string m_originalAcronym;
        
        #endregion

        #region [ Constructor ]

        public OutputStreamDevicesUserControl()
        {
            InitializeComponent();
            Initialize();
#if !SILVERLIGHT
            ButtonSave.Content = new BitmapImage(new Uri(@"images/Save.png", UriKind.Relative));
            ButtonClear.Content = new BitmapImage(new Uri(@"images/Cancel.png", UriKind.Relative));
            UpdateLayout();
#endif
            Loaded += new RoutedEventHandler(OutputStreamDevices_Loaded);            
            ListBoxOutputStreamDeviceList.SelectionChanged += new SelectionChangedEventHandler(ListBoxOutputStreamDeviceList_SelectionChanged);
            ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
            ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
        }

        #endregion

        #region [ Controls Event Handlers ]

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
                OutputStreamDevice outputStreamDevice = new OutputStreamDevice();
                App app = (App)Application.Current;
                outputStreamDevice.NodeID = app.NodeValue;
                outputStreamDevice.AdapterID = m_sourceOutputStreamID;
                outputStreamDevice.Acronym = TextBoxAcronym.Text.CleanText();
                outputStreamDevice.BpaAcronym = TextBoxBPAAcronym.Text.CleanText();
                outputStreamDevice.Name = TextBoxName.Text.CleanText();
                outputStreamDevice.LoadOrder = TextBoxLoadOrder.Text.ToInteger();
                outputStreamDevice.Enabled = (bool)CheckBoxEnabled.IsChecked;
                outputStreamDevice.PhasorDataFormat = ComboboxPhasorDataFormat.SelectedIndex == 0 ? string.Empty : ComboboxPhasorDataFormat.SelectedItem.ToString();
                outputStreamDevice.FrequencyDataFormat = ComboboxFrequencyDataFormat.SelectedIndex == 0 ? string.Empty : ComboboxFrequencyDataFormat.SelectedItem.ToString();
                outputStreamDevice.AnalogDataFormat = ComboboxAnalogDataFormat.SelectedIndex == 0 ? string.Empty : ComboboxAnalogDataFormat.SelectedItem.ToString();
                outputStreamDevice.CoordinateFormat = ComboboxCoordinateFormat.SelectedIndex == 0 ? string.Empty : ComboboxCoordinateFormat.SelectedItem.ToString();
                outputStreamDevice.IdCode = TextBoxIDCode.Text.ToInteger();

                if (m_inEditMode == true && m_outputStreamDeviceID > 0)
                {
                    outputStreamDevice.ID = m_outputStreamDeviceID;
                    SaveOutputStreamDevice(outputStreamDevice, false, m_originalAcronym);
                }
                else
                    SaveOutputStreamDevice(outputStreamDevice, true, string.Empty);
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

        void ListBoxOutputStreamDeviceList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxOutputStreamDeviceList.SelectedIndex >= 0)
            {
                m_selectedOutputStreamDevice = ListBoxOutputStreamDeviceList.SelectedItem as OutputStreamDevice;
                m_originalAcronym = m_selectedOutputStreamDevice.Acronym;
                GridOutputStreamDeviceDetail.DataContext = m_selectedOutputStreamDevice;
                CheckBoxEnabled.IsChecked = m_selectedOutputStreamDevice.Enabled;

                if (string.IsNullOrEmpty(m_selectedOutputStreamDevice.AnalogDataFormat))
                    ComboboxAnalogDataFormat.SelectedIndex = 0;
                else
                    ComboboxAnalogDataFormat.SelectedItem = m_selectedOutputStreamDevice.AnalogDataFormat;

                if (string.IsNullOrEmpty(m_selectedOutputStreamDevice.CoordinateFormat))
                    ComboboxCoordinateFormat.SelectedIndex = 0;
                else
                    ComboboxCoordinateFormat.SelectedItem = m_selectedOutputStreamDevice.CoordinateFormat;

                if (string.IsNullOrEmpty(m_selectedOutputStreamDevice.FrequencyDataFormat))
                    ComboboxFrequencyDataFormat.SelectedIndex = 0;
                else
                    ComboboxFrequencyDataFormat.SelectedItem = m_selectedOutputStreamDevice.FrequencyDataFormat;

                if (string.IsNullOrEmpty(m_selectedOutputStreamDevice.PhasorDataFormat))
                    ComboboxPhasorDataFormat.SelectedIndex = 0;
                else
                    ComboboxPhasorDataFormat.SelectedItem = m_selectedOutputStreamDevice.PhasorDataFormat;
                m_inEditMode = true;
                m_outputStreamDeviceID = m_selectedOutputStreamDevice.ID;

                ButtonSave.Tag = "Update";
            }
        }

        private void HyperlinkButtonPhasors_Click(object sender, RoutedEventArgs e)
        {
            int outputStreamDeviceId = Convert.ToInt32(((Button)sender).Tag.ToString());
            string acronym = ToolTipService.GetToolTip((Button)sender).ToString();  // ((HyperlinkButton)sender).Name;
            OutputStreamDevicePhasors osdp = new OutputStreamDevicePhasors(outputStreamDeviceId, acronym);
#if SILVERLIGHT
            osdp.Show();
#else
            osdp.Owner = Window.GetWindow(this);
            osdp.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            osdp.ShowDialog();
#endif

        }

        private void HyperlinkButtonAnalogs_Click(object sender, RoutedEventArgs e)
        {
            int outputStreamDeviceId = Convert.ToInt32(((Button)sender).Tag.ToString());
            string acronym = ToolTipService.GetToolTip((Button)sender).ToString();  // ((HyperlinkButton)sender).Name;
            OutputStreamDeviceAnalogs osda = new OutputStreamDeviceAnalogs(outputStreamDeviceId, acronym);
#if SILVERLIGHT            
            osda.Show();
#else
            osda.Owner = Window.GetWindow(this);
            osda.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            osda.ShowDialog();
#endif
        }

        private void HyperlinkButtonDigitals_Click(object sender, RoutedEventArgs e)
        {
            int outputStreamDeviceId = Convert.ToInt32(((Button)sender).Tag.ToString());
            string acronym = ToolTipService.GetToolTip((Button)sender).ToString();  // ((HyperlinkButton)sender).Name;
            OutputStreamDeviceDigitals osdd = new OutputStreamDeviceDigitals(outputStreamDeviceId, acronym);
      #if SILVERLIGHT            
            osdd.Show();
#else
            osdd.Owner = Window.GetWindow(this);
            osdd.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            osdd.ShowDialog();
#endif
        }

        private void HyperlinkButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
                {
                    int outputStreamDeviceId = Convert.ToInt32(((Button)sender).Tag.ToString());
                    string acronym = ToolTipService.GetToolTip((Button)sender).ToString();  // ((HyperlinkButton)sender).Name;

                    SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Do you want to delete output stream device?", SystemMessage = "Output Stream  Device Acronym: " + acronym, UserMessageType = MessageType.Confirmation }, ButtonType.YesNo);
                    sm.Closed += new EventHandler(delegate(object popupWindow, EventArgs eargs)
                    {
                        if ((bool)sm.DialogResult)
                        {
                            try
                            {
                                DeleteOutputStreamDevice(m_sourceOutputStreamID, new ObservableCollection<string>() { acronym });
                                ClearForm();
                            }
                            catch (Exception ex)
                            {
                                SystemMessages sm1 = new SystemMessages(new Message() { UserMessage = "Failed to delete output stream device.", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
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
                    SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to delete output stream device.", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                            ButtonType.OkOnly);
#if !SILVERLIGHT
                    sm.Owner = Window.GetWindow(this);
                    sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
#endif
                    sm.ShowPopup();
                }

            
            
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
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

        #endregion

        #region [ Page Event Handlers ]

        void OutputStreamDevices_Loaded(object sender, RoutedEventArgs e)
        {
            GetOutputStreamDeviceList();
            ComboboxPhasorDataFormat.Items.Add("Select Phasor Data Format");
            ComboboxPhasorDataFormat.Items.Add("FloatingPoint");
            ComboboxPhasorDataFormat.Items.Add("FixedInteger");
            ComboboxPhasorDataFormat.SelectedIndex = 0;

            ComboboxFrequencyDataFormat.Items.Add("Select Frequency Data Format");
            ComboboxFrequencyDataFormat.Items.Add("FloatingPoint");
            ComboboxFrequencyDataFormat.Items.Add("FixedInteger");
            ComboboxFrequencyDataFormat.SelectedIndex = 0;


            ComboboxAnalogDataFormat.Items.Add("Select Analog Data Format");
            ComboboxAnalogDataFormat.Items.Add("FloatingPoint");
            ComboboxAnalogDataFormat.Items.Add("FixedInteger");
            ComboboxAnalogDataFormat.SelectedIndex = 0;

            ComboboxCoordinateFormat.Items.Add("Select Coordinate Format");
            ComboboxCoordinateFormat.Items.Add("Polar");
            ComboboxCoordinateFormat.Items.Add("Rectangular");
            ComboboxCoordinateFormat.SelectedIndex = 0;
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
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
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
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
#endif
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxIDCode.Text.IsInteger())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid ID Code", SystemMessage = "Please provide valid integer value for ID Code.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxIDCode.Focus();
                    TextBoxIDCode.Text = "0";
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
            GridOutputStreamDeviceDetail.DataContext = new OutputStreamDevice();
            ComboboxCoordinateFormat.SelectedIndex = 0;
            ComboboxAnalogDataFormat.SelectedIndex = 0;
            ComboboxFrequencyDataFormat.SelectedIndex = 0;
            ComboboxPhasorDataFormat.SelectedIndex = 0;
            CheckBoxEnabled.IsChecked = true;            
            m_inEditMode = false;
            m_outputStreamDeviceID = 0;
            ListBoxOutputStreamDeviceList.SelectedIndex = -1;
            ButtonSave.Tag = "Add";
        }

        void addDevices_Closed(object sender, EventArgs e)
        {
            GetOutputStreamDeviceList();            
        }

        #endregion		
    }
}
