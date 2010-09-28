//******************************************************************************************************
//  AdapterUserControl.xaml.cs - Gbtc
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
//  07/08/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
#if SILVERLIGHT
using openPDCManager.PhasorDataServiceProxy;
#else
using openPDCManager.Data;
using openPDCManager.Data.Entities;
using System.Windows.Media.Imaging;
#endif
using openPDCManager.Utilities;
using openPDCManager.ModalDialogs;

namespace openPDCManager.UserControls.CommonControls
{
    public partial class AdapterUserControl : UserControl
    {
        #region [ Property ]

        public AdapterType TypeOfAdapter
        {
            get { return m_adapterType; }
            set 
            { 
                m_adapterType = value;
                if (m_adapterType == AdapterType.Action)
                    TextBlockTitle.Text = "Custom Action Adapter";
                else if (m_adapterType == AdapterType.Input)
                    TextBlockTitle.Text = "Custom Input Adapter";
                else if (m_adapterType == AdapterType.Output)
                    TextBlockTitle.Text = "Custom Output Adapter";
                else
                    TextBlockTitle.Text = "Custom Adapter";
            }
        }

        #endregion

        #region [ Members ]
                
        bool m_inEditMode = false;
        int m_adapterID = 0;
        AdapterType m_adapterType;
        string m_nodeID;

        #endregion

        #region [ Constructor ]

        public AdapterUserControl()
        {
            InitializeComponent();
            Initialize();
#if !SILVERLIGHT
            ButtonSave.Content = new BitmapImage(new Uri("images/Save.png", UriKind.Relative));
            ButtonClear.Content = new BitmapImage(new Uri("images/Cancel.png", UriKind.Relative));
            UpdateLayout();
#endif
            Loaded += new RoutedEventHandler(AdaptersUserControl_Loaded);
            ButtonInitialize.Visibility = System.Windows.Visibility.Collapsed;
            ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
            ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
            ListBoxAdapterList.SelectionChanged += new SelectionChangedEventHandler(ListBoxAdapterList_SelectionChanged);
        }

        #endregion
        
        #region [ Control Event Handlers ]

        void ListBoxAdapterList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxAdapterList.SelectedIndex >= 0)
            {
                Adapter selectedAdapter = ListBoxAdapterList.SelectedItem as Adapter;
                GridAdapterDetail.DataContext = selectedAdapter;
                ComboboxNode.SelectedItem = new KeyValuePair<string, string>(selectedAdapter.NodeID, selectedAdapter.NodeName);
                m_inEditMode = true;
                m_adapterID = selectedAdapter.ID;
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
                Adapter adapter = new Adapter();
                adapter.adapterType = m_adapterType;
                adapter.NodeID = ((KeyValuePair<string, string>)ComboboxNode.SelectedItem).Key;
                adapter.AdapterName = TextBoxAdapterName.Text.CleanText();
                adapter.AssemblyName = TextBoxAssemblyName.Text.CleanText();
                adapter.TypeName = TextBoxTypeName.Text.CleanText();
                adapter.ConnectionString = TextBoxConnectionString.Text.CleanText();
                adapter.LoadOrder = TextBoxLoadOrder.Text.ToInteger();
                adapter.Enabled = (bool)CheckboxEnabled.IsChecked;

                if (m_inEditMode == true && m_adapterID > 0)
                {
                    adapter.ID = m_adapterID;
                    SaveAdapter(adapter, false);
                }
                else
                {
                    SaveAdapter(adapter, true);
                }
            }
        }

        #endregion

        #region [ Page Event Handlers ]

        void AdaptersUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            App app = (App)Application.Current;
            m_nodeID = app.NodeValue;
            GetNodes();
            ClearForm();
            GetAdapterList();            
        }

        void ButtonInitialize_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Do you want to send Initialize command?", SystemMessage = "Adapter Acronym: " + ((Button)sender).Tag.ToString(), UserMessageType = MessageType.Confirmation }, ButtonType.YesNo);
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

        #region [ Methods ]

        void ClearForm()
        {
            GridAdapterDetail.DataContext = new Adapter();
            if (ComboboxNode.Items.Count > 0)
                ComboboxNode.SelectedIndex = 0;
            m_inEditMode = false;
            m_adapterID = 0;
            ListBoxAdapterList.SelectedIndex = -1;
            TextBlockRuntimeID.Text = string.Empty;
            ButtonInitialize.Visibility = System.Windows.Visibility.Collapsed;
            ButtonSave.Tag = "Add";
        }

        public void SetAdapterType(AdapterType adpType)
        {
            TypeOfAdapter = adpType;                        
        }

        bool IsValid()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(TextBoxAdapterName.Text.CleanText()))
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Adapter Name", SystemMessage = "Please provide valid Adapter Name.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxAdapterName.Focus();
                });
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
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
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
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

            return isValid;
        }

        #endregion
    }
}
