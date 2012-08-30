//******************************************************************************************************
//  NodesUserControl.xaml.cs - Gbtc
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
//  07/12/2010 - Mehulbhai P Thakkar
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
using openPDCManager.Data;
using openPDCManager.Data.Entities;
using System.Windows.Media.Imaging;
#endif

namespace openPDCManager.UserControls.CommonControls
{
    public partial class NodesUserControl : UserControl
    {
        #region [ Members ]
        
        bool m_inEditMode = false;
        string m_nodeID = string.Empty;
        ActivityWindow m_activityWindow;

        #endregion

        #region [ Constructor ]

        public NodesUserControl()
        {
            InitializeComponent();
            Initialize();
#if !SILVERLIGHT
            ButtonSave.Content = new BitmapImage(new Uri("images/Save.png", UriKind.Relative));
            ButtonClear.Content = new BitmapImage(new Uri("images/Cancel.png", UriKind.Relative));
            UpdateLayout();
#endif
            Loaded += new RoutedEventHandler(Nodes_Loaded);
            ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
            ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
            ListBoxNodeList.SelectionChanged += new SelectionChangedEventHandler(ListBoxNodeList_SelectionChanged);
        }

        #endregion

        #region [ Control Event Handlers ]

        void ListBoxNodeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxNodeList.SelectedIndex >= 0)
            {
                Node selectedNode = ListBoxNodeList.SelectedItem as Node;
                GridNodeDetail.DataContext = selectedNode;
                if (selectedNode.CompanyID.HasValue)
                    ComboBoxCompany.SelectedItem = new KeyValuePair<int, string>((int)selectedNode.CompanyID, selectedNode.CompanyName);
                else
                    ComboBoxCompany.SelectedIndex = 0;
                m_inEditMode = true;
                m_nodeID = selectedNode.ID;

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
                Node node = new Node();
                node.Name = TextBoxName.Text.CleanText();
                node.CompanyID = ((KeyValuePair<int, string>)ComboBoxCompany.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboBoxCompany.SelectedItem).Key;
                node.Longitude = TextBoxLongitude.Text.ToNullableDecimal();
                node.Latitude = TextBoxLatitude.Text.ToNullableDecimal();
                node.Description = TextBoxDescription.Text.CleanText();
                node.Image = TextBoxImage.Text.CleanText();
                node.Master = (bool)CheckboxMaster.IsChecked;
                node.LoadOrder = TextBoxLoadOrder.Text.ToInteger();
                node.Enabled = (bool)CheckboxEnabled.IsChecked;
                node.TimeSeriesDataServiceUrl = TextBoxTimeSeriesDataServiceUrl.Text.CleanText();
                node.RemoteStatusServiceUrl = TextBoxRemoteStatusServiceUrl.Text.CleanText();
                node.RealTimeStatisticServiceUrl = TextBoxRealTimeStatisticServiceUrl.Text.CleanText();

                if (m_inEditMode == true && !string.IsNullOrEmpty(m_nodeID))
                {
                    node.ID = m_nodeID;
                    SaveNode(node, false);
                }
                else
                    SaveNode(node, true);
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

        #endregion

        #region [ Page Event Handlers ]

        void Nodes_Loaded(object sender, RoutedEventArgs e)
        {            
            GetCompanies();
            ClearForm();
            GetNodes();
        }               

        #endregion

        #region [ Methods ]

        void ClearForm()
        {
            GridNodeDetail.DataContext = new Node() { Longitude = -98.6m, Latitude = 37.5m };
            if (ComboBoxCompany.Items.Count > 0)
                ComboBoxCompany.SelectedIndex = 0;
            m_inEditMode = false;
            m_nodeID = string.Empty;
            ListBoxNodeList.SelectedIndex = -1;
            ButtonSave.Tag = "Add";
        }

        bool IsValid()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(TextBoxName.Text.CleanText()))
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Name", SystemMessage = "Please provide valid Name for a node.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxName.Focus();
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

            return isValid;
        }

        #endregion
    }
}
