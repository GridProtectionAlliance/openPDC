//******************************************************************************************************
//  HistoriansUserControl.xaml.cs - Gbtc
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
#if SILVERLIGHT
using openPDCManager.PhasorDataServiceProxy;
#else
using openPDCManager.Data.Entities;
using System.Windows.Media.Imaging;
#endif
using openPDCManager.Utilities;
using openPDCManager.ModalDialogs;
using System.Windows.Media.Animation;

namespace openPDCManager.UserControls.CommonControls
{
    public partial class HistoriansUserControl : UserControl
    {
        #region [ Members ]

        bool m_inEditMode;
        int m_historianID;
        string m_nodeID;
        string m_typeName;
        bool m_isLocal;

        #endregion

        #region [ Constructor ]

        public HistoriansUserControl()
        {
            InitializeComponent();
            Initialize();
#if !SILVERLIGHT
            ButtonSave.Content = new BitmapImage(new Uri("images/Save.png", UriKind.Relative));
            ButtonClear.Content = new BitmapImage(new Uri("images/Cancel.png", UriKind.Relative));
            UpdateLayout();
#endif
            Loaded += new RoutedEventHandler(HistoriansUserControl_Loaded);
            ButtonInitialize.Visibility = System.Windows.Visibility.Collapsed;
            ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
            ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
            ListBoxHistorianList.SelectionChanged += new SelectionChangedEventHandler(ListBoxHistorianList_SelectionChanged);
        }

        #endregion

        #region [ Control Event Handlers ]

        void ListBoxHistorianList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxHistorianList.SelectedIndex >= 0)
            {
                Historian selectedHistorian = ListBoxHistorianList.SelectedItem as Historian;
                GridHistorianDetail.DataContext = selectedHistorian;
                ComboBoxNode.SelectedItem = new KeyValuePair<string, string>(selectedHistorian.NodeID, selectedHistorian.NodeName);
                CheckboxEnabled.IsChecked = selectedHistorian.Enabled;
                CheckboxIsLocal.IsChecked = selectedHistorian.IsLocal;
                m_inEditMode = true;
                m_historianID = selectedHistorian.ID;
                DisplayRuntimeID();
#if !SILVERLIGHT
                ButtonInitialize.Visibility = System.Windows.Visibility.Visible;
#endif
                ButtonSave.Tag = "Update";

                m_typeName = selectedHistorian.TypeName;
                m_isLocal = selectedHistorian.IsLocal;
            }
        }

        void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            System.Windows.Media.Animation.Storyboard sb = new Storyboard();
            sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            Storyboard.SetTarget(sb, ButtonSaveTransform);
            sb.Begin();
#endif
            if (IsValid())
            {
                Historian historian = new Historian();
                historian.NodeID = ((KeyValuePair<string, string>)ComboBoxNode.SelectedItem).Key;
                historian.Acronym = TextBoxAcronym.Text;
                historian.Name = TextBoxName.Text;
                historian.AssemblyName = TextBoxAssemblyName.Text;
                historian.TypeName = TextBoxTypeName.Text;
                historian.ConnectionString = TextBoxConnectionString.Text;
                historian.IsLocal = (bool)CheckboxIsLocal.IsChecked;
                historian.Description = TextBoxDescription.Text;
                historian.LoadOrder = TextBoxLoadOrder.Text.ToInteger();
                historian.MeasurementReportingInterval = TextBoxMeasurementReportingInterval.Text.ToInteger();
                historian.Enabled = (bool)CheckboxEnabled.IsChecked;

                if (m_inEditMode == true && m_historianID > 0)
                {
                    historian.ID = m_historianID;
                    SaveHistorian(historian, false);
                }
                else
                    SaveHistorian(historian, true);
            }
        }

        void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            System.Windows.Media.Animation.Storyboard sb = new Storyboard();
            sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            Storyboard.SetTarget(sb, ButtonClearTransform);
            sb.Begin();
#endif

            ClearForm();
        }

        void ButtonInitialize_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Do you want to send Initialize command?", SystemMessage = "Historian Acronym: " + ((Button)sender).Tag.ToString(), UserMessageType = MessageType.Confirmation }, ButtonType.YesNo);
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

        #endregion

        #region [ Page Event Handlers ]

        void HistoriansUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ClearForm();
            App app = (App)Application.Current;
            m_nodeID = app.NodeValue;
            GetNodes();
            GetHistorians();
        }

        #endregion

        #region [ Methods ]

        void ClearForm()
        {
            GridHistorianDetail.DataContext = new Historian() { IsLocal = true, MeasurementReportingInterval = 100000 };
            if (ComboBoxNode.Items.Count > 0)
                ComboBoxNode.SelectedIndex = 0;
            CheckboxEnabled.IsChecked = false;
            CheckboxIsLocal.IsChecked = false;
            m_inEditMode = false;
            m_historianID = 0;
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

            if (!TextBoxMeasurementReportingInterval.Text.IsInteger())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Measurement Reporting Interval", SystemMessage = "Please provide valid integer value for Measurement Reporting Interval.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxMeasurementReportingInterval.Text = "100000";
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

        #endregion

    }
}
