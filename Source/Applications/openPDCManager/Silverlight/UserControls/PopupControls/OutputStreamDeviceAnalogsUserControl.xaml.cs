//******************************************************************************************************
//  OutputStreamDeviceAnalogsUserControl.xaml.cs - Gbtc
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
//  08/23/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using openPDCManager.Utilities;
using openPDCManager.ModalDialogs;
#if SILVERLIGHT
using openPDCManager.PhasorDataServiceProxy;
#else
using openPDCManager.Data.Entities;
using System.Windows.Media.Imaging;
using openPDCManager.Data;
#endif

namespace openPDCManager.UserControls.PopupControls
{
    public partial class OutputStreamDeviceAnalogsUserControl : UserControl
    {
        #region [ Members ]

        public int m_sourceOutputStreamDeviceID;
        public string m_sourceOutputStreamDeviceAcronym;
        bool m_inEditMode = false;
        int m_outputStreamDeviceAnalogID = 0;
        
        #endregion

        #region [ Constructor ]
        
        public OutputStreamDeviceAnalogsUserControl()
        {
            InitializeComponent();
            Initialize();
            Loaded += new RoutedEventHandler(OutputStreamDeviceAnalogs_Loaded);
#if !SILVERLIGHT
            ButtonSave.Content = new BitmapImage(new Uri(@"images/Save.png", UriKind.Relative));
            ButtonClear.Content = new BitmapImage(new Uri(@"images/Cancel.png", UriKind.Relative));
#endif
            ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
            ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);            
            ListBoxOutputStreamDeviceAnalogList.SelectionChanged += new SelectionChangedEventHandler(ListBoxOutputStreamDeviceAnalogList_SelectionChanged);
        }

        #endregion

        #region [ Controls Event Handlers ]

        void ListBoxOutputStreamDeviceAnalogList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxOutputStreamDeviceAnalogList.SelectedIndex >= 0)
            {
                OutputStreamDeviceAnalog selectedOutputStreamDeviceAnalog = ListBoxOutputStreamDeviceAnalogList.SelectedItem as OutputStreamDeviceAnalog;
                GridOutputStreamDeviceAnalogDetail.DataContext = selectedOutputStreamDeviceAnalog;
                ComboBoxType.SelectedItem = new KeyValuePair<int, string>(selectedOutputStreamDeviceAnalog.Type, selectedOutputStreamDeviceAnalog.TypeName);
                m_inEditMode = true;
                m_outputStreamDeviceAnalogID = selectedOutputStreamDeviceAnalog.ID;
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
                OutputStreamDeviceAnalog outputStreamDeviceAnalog = new OutputStreamDeviceAnalog();
                App app = (App)Application.Current;

                outputStreamDeviceAnalog.NodeID = app.NodeValue;
                outputStreamDeviceAnalog.OutputStreamDeviceID = m_sourceOutputStreamDeviceID;
                outputStreamDeviceAnalog.Type = ((KeyValuePair<int, string>)ComboBoxType.SelectedItem).Key;
                outputStreamDeviceAnalog.Label = TextBoxLabel.Text.CleanText();
                outputStreamDeviceAnalog.LoadOrder = TextBoxLoadOrder.Text.ToInteger();
                outputStreamDeviceAnalog.ScalingValue = TextBoxScalingValue.Text.ToInteger();
                if (m_inEditMode == true && m_outputStreamDeviceAnalogID > 0)
                {
                    outputStreamDeviceAnalog.ID = m_outputStreamDeviceAnalogID;
                    SaveOutputStreamDeviceAnalog(outputStreamDeviceAnalog, false);
                }
                else
                    SaveOutputStreamDeviceAnalog(outputStreamDeviceAnalog, true);
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

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int outputStreamDeviceAnalogId = Convert.ToInt32(((Button)sender).Tag.ToString());
                string label = ToolTipService.GetToolTip((Button)sender).ToString();  // ((HyperlinkButton)sender).Name;

                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Do you want to delete output stream device analog?", SystemMessage = "Output Stream  Device Analog: " + label, UserMessageType = MessageType.Confirmation }, ButtonType.YesNo);
                sm.Closed += new EventHandler(delegate(object popupWindow, EventArgs eargs)
                {
                    if ((bool)sm.DialogResult)
                    {
                        try
                        {
                            DeleteOutputStreamDeviceAnalog(outputStreamDeviceAnalogId);
                            ClearForm();
                        }
                        catch (Exception ex)
                        {
                            SystemMessages sm1 = new SystemMessages(new Message() { UserMessage = "Failed to delete output stream device analog.", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
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
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to delete output stream device analog.", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
#endif
                sm.ShowPopup();
            }
        }

        #endregion
        
        #region [ Page Event Handlers ]

        void OutputStreamDeviceAnalogs_Loaded(object sender, RoutedEventArgs e)
        {            
            ComboBoxType.Items.Add(new KeyValuePair<int, string>(0, "Single point-on-wave"));
            ComboBoxType.Items.Add(new KeyValuePair<int, string>(1, "RMS of analog input"));
            ComboBoxType.Items.Add(new KeyValuePair<int, string>(1, "Peak of analog input"));
            ComboBoxType.SelectedIndex = 0;
            ClearForm();
            GetOutputStreamDeviceAnalogList();
        }

        #endregion

        #region [ Methods ]

        bool IsValid()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(TextBoxLabel.Text.CleanText()))
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Label", SystemMessage = "Please provide valid Label.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxLabel.Focus();
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
                    TextBoxLoadOrder.Text = "0";
                    TextBoxLoadOrder.Focus();
                });
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
#endif
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxScalingValue.Text.IsInteger())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Scaling Value", SystemMessage = "Please provide valid integer value for Scaling Value.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxScalingValue.Text = "0";
                    TextBoxScalingValue.Focus();
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
            GridOutputStreamDeviceAnalogDetail.DataContext = new OutputStreamDeviceAnalog();
            if (ComboBoxType.Items.Count > 0)
                ComboBoxType.SelectedIndex = 0;
            m_inEditMode = false;
            m_outputStreamDeviceAnalogID = 0;
            ListBoxOutputStreamDeviceAnalogList.SelectedIndex = -1;
            ButtonSave.Tag = "Add";
        }

        #endregion

    }
}
