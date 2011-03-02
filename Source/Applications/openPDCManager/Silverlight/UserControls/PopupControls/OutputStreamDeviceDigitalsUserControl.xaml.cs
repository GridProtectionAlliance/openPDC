//******************************************************************************************************
//  OutputStreamDeviceDigitalsUserControl.xaml.cs - Gbtc
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

using System.Windows;
using System.Windows.Controls;
using openPDCManager.Utilities;
using System.Windows.Media.Animation;
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
    public partial class OutputStreamDeviceDigitalsUserControl : UserControl
    {
        #region [ Members ]

        public int m_sourceOutputStreamDeviceID;
        public string m_sourceOutputStreamDeviceAcronym;
        bool m_inEditMode = false;
        int m_outputStreamDeviceDigitalID = 0;        

        #endregion

        #region [ Constructor ]
        
        public OutputStreamDeviceDigitalsUserControl()
        {
            InitializeComponent();
            Initialize();
            Loaded += new RoutedEventHandler(OutputStreamDeviceDigitals_Loaded);
#if !SILVERLIGHT
            ButtonSave.Content = new BitmapImage(new Uri(@"images/Save.png", UriKind.Relative));
            ButtonClear.Content = new BitmapImage(new Uri(@"images/Cancel.png", UriKind.Relative));
#endif
            ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
            ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);            
            ListBoxOutputStreamDeviceDigitalList.SelectionChanged += new SelectionChangedEventHandler(ListBoxOutputStreamDeviceDigitalList_SelectionChanged);
        }

        #endregion

        #region [ Controls Event Handlers ]

        void ListBoxOutputStreamDeviceDigitalList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxOutputStreamDeviceDigitalList.SelectedIndex >= 0)
            {
                OutputStreamDeviceDigital selectedOutputStreamDeviceDigital = ListBoxOutputStreamDeviceDigitalList.SelectedItem as OutputStreamDeviceDigital;
                GridOutputStreamDeviceDigitalDetail.DataContext = selectedOutputStreamDeviceDigital;
                m_inEditMode = true;
                m_outputStreamDeviceDigitalID = selectedOutputStreamDeviceDigital.ID;
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
                OutputStreamDeviceDigital outputStreamDeviceDigital = new OutputStreamDeviceDigital();
                App app = (App)Application.Current;

                outputStreamDeviceDigital.NodeID = app.NodeValue;
                outputStreamDeviceDigital.OutputStreamDeviceID = m_sourceOutputStreamDeviceID;
                outputStreamDeviceDigital.Label = TextBoxLabel.Text.CleanText();
                outputStreamDeviceDigital.LoadOrder = TextBoxLoadOrder.Text.ToInteger();
                outputStreamDeviceDigital.MaskValue = TextBoxMaskValue.Text.ToInteger();
                if (m_inEditMode == true && m_outputStreamDeviceDigitalID > 0)
                {
                    outputStreamDeviceDigital.ID = m_outputStreamDeviceDigitalID;
                    SaveOutputStreamDeviceDigital(outputStreamDeviceDigital, false);
                }
                else
                    SaveOutputStreamDeviceDigital(outputStreamDeviceDigital, true);
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
                int outputStreamDeviceDigitalId = Convert.ToInt32(((Button)sender).Tag.ToString());
                string label = ToolTipService.GetToolTip((Button)sender).ToString();  // ((HyperlinkButton)sender).Name;

                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Do you want to delete output stream device digital?", SystemMessage = "Output Stream  Device Digital: " + label, UserMessageType = MessageType.Confirmation }, ButtonType.YesNo);
                sm.Closed += new EventHandler(delegate(object popupWindow, EventArgs eargs)
                {
                    if ((bool)sm.DialogResult)
                    {
                        try
                        {
                            DeleteOutputStreamDeviceDigital(outputStreamDeviceDigitalId);
                            ClearForm();
                        }
                        catch (Exception ex)
                        {
                            SystemMessages sm1 = new SystemMessages(new Message() { UserMessage = "Failed to delete output stream device digital.", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
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
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to delete output stream device digital.", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
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

        void OutputStreamDeviceDigitals_Loaded(object sender, RoutedEventArgs e)
        {
            ClearForm();
            GetOutputStreamDeviceDigitalList();            
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

            if (!TextBoxMaskValue.Text.IsInteger())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Mask Value", SystemMessage = "Please provide valid integer value for Mask Value.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxMaskValue.Text = "0";
                    TextBoxMaskValue.Focus();
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
            GridOutputStreamDeviceDigitalDetail.DataContext = new OutputStreamDeviceDigital();
            m_inEditMode = false;
            m_outputStreamDeviceDigitalID = 0;
            ListBoxOutputStreamDeviceDigitalList.SelectedIndex = -1;
            ButtonSave.Tag = "Add";
        }

        #endregion

        
    }
}
