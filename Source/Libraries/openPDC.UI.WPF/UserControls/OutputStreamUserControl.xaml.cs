//******************************************************************************************************
//  OutputStreamUserControl.xaml.cs - Gbtc
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
//  08/16/2011 - Magdiel Lorenzo
//       Generated original version of source code.
//  09/12/2011 - Mehulbhai Thakkar
//       Modified code to use MVVM pattern.
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using openPDCManager.UI.ViewModels;
using TimeSeriesFramework.UI.UserControls;

namespace openPDC.UI.UserControls
{
    /// <summary>
    /// Interaction logic for OutputStreamUserControl.xaml
    /// </summary>
    public partial class OutputStreamUserControl : UserControl
    {
        #region [ Members ]

        private OutputStreams m_dataContext;

        #endregion

        #region [ Constructor ]

        /// <summary>
        /// Creates an instance of <see cref="OutputStreamUserControl"/>.
        /// </summary>
        public OutputStreamUserControl()
        {
            InitializeComponent();
            m_dataContext = new OutputStreams(7, true);
            this.DataContext = m_dataContext;
        }

        #endregion

        #region [ Methods ]

        private void ButtonHelp_Click(object sender, RoutedEventArgs e)
        {
            PanAndZoomViewer viewer = new PanAndZoomViewer(new BitmapImage(new Uri(@"/openPDC.UI;component/Images/" + ((Button)sender).Tag.ToString(), UriKind.Relative)), "Help Me Choose");
            viewer.Owner = Window.GetWindow(this);
            viewer.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            viewer.ShowDialog();
        }

        private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                DataGrid dataGrid = sender as DataGrid;
                if (dataGrid.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show("Are you sure you want to delete " + dataGrid.SelectedItems.Count + " selected item(s)?", "Delete Selected Items", MessageBoxButton.YesNo) == MessageBoxResult.No)
                        e.Handled = true;
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxMirrorSource.SelectedItem = new KeyValuePair<string, string>(m_dataContext.CurrentItem.MirroringSourceDevice, m_dataContext.CurrentItem.MirroringSourceDevice);
        }

        private void OSGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            m_dataContext.SortData(e.Column.SortMemberPath);
        }

        private void GridDetailView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (m_dataContext.IsNewRecord)
                DataGridList.SelectedIndex = -1;
        }

        #endregion

    }
}
