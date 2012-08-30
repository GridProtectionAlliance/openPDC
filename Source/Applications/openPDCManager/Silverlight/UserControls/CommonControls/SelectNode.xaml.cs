//******************************************************************************************************
//  SelectNode.xaml.cs - Gbtc
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

using System.Windows;
using System.Windows.Controls;
#if SILVERLIGHT
using openPDCManager.PhasorDataServiceProxy;
#else
using openPDCManager.Data;
using openPDCManager.Data.Entities;
#endif

namespace openPDCManager.UserControls.CommonControls
{
    public partial class SelectNode : UserControl
    {
        #region [ Members ]

        public delegate void OnNodesChanged(object sender, RoutedEventArgs e);
        public event OnNodesChanged NodeCollectionChanged;
        bool m_raiseNodesCollectionChanged = false;

        #endregion

        #region [ Constructor ]

        public SelectNode()
        {
            InitializeComponent();
            ComboboxNode.SelectionChanged += new SelectionChangedEventHandler(ComboboxNode_SelectionChanged);
            Initialize();
        }

        #endregion

        #region [ Methods ]

        public void RaiseNotification()
        {
            m_raiseNodesCollectionChanged = true;
            if (NodeCollectionChanged != null && m_raiseNodesCollectionChanged)
                NodeCollectionChanged(this, null);
        }

        void SetGlobalVariables()
        {
            
            App app = (App)Application.Current;
            if (ComboboxNode.Items.Count > 0)
            {
                if (!string.IsNullOrEmpty(app.NodeValue))
                {
                    foreach (Node item in ComboboxNode.Items)
                    {
                        if (item.ID == app.NodeValue)
                        {
                            ComboboxNode.SelectedItem = item;
                            break;
                        }

                    }
                }
                else
                    ComboboxNode.SelectedIndex = 0;

                Node node = (Node)ComboboxNode.SelectedItem;
                app.NodeValue = node.ID;
                app.NodeName = node.Name;
                app.TimeSeriesDataServiceUrl = node.TimeSeriesDataServiceUrl;
                app.RemoteStatusServiceUrl = node.RemoteStatusServiceUrl;
                app.RealTimeStatisticServiceUrl = node.RealTimeStatisticServiceUrl;
            }
            else
                app.NodeValue = string.Empty;
        }

        #endregion

        #region [ Control Event Handlers ]

        void ComboboxNode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!m_raiseNodesCollectionChanged)
            {
                App app = (App)Application.Current;
                Node node = (Node)ComboboxNode.SelectedItem;
                app.NodeValue = node.ID;
                app.NodeName = node.Name;
                app.TimeSeriesDataServiceUrl = node.TimeSeriesDataServiceUrl;
                app.RemoteStatusServiceUrl = node.RemoteStatusServiceUrl;
                app.RealTimeStatisticServiceUrl = node.RealTimeStatisticServiceUrl;
                //app.NodeValue = ((KeyValuePair<string, string>)ComboboxNode.SelectedItem).Key;
                //app.NodeName = ((KeyValuePair<string, string>)(ComboboxNode.SelectedItem)).Value;
            }
        }

        #endregion

    }
}
