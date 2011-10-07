//******************************************************************************************************
//  PhasorMeasurementUserControl.xaml.cs - Gbtc
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
//  05/12/2011 - Magdiel D. Lorenzo
//       Generated original version of source code.
//  05/13/2011 - Mehulbhai P Thakkar
//       Added constructor overload to handle device specific data.
//  07/12/2011 - Stephen C. Wills
//       Migrated phasor-specific code from MeasurementUserControl to here.
//
//******************************************************************************************************

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using openPDC.UI.ViewModels;

namespace openPDC.UI.UserControls
{
    /// <summary>
    /// Interaction logic for PhasorMeasurementUserControl.xaml
    /// </summary>
    public partial class PhasorMeasurementUserControl : UserControl
    {
        #region [ Constructor ]

        /// <summary>
        /// Creates an instance of <see cref="PhasorMeasurementUserControl"/> class.
        /// </summary>
        public PhasorMeasurementUserControl()
            : this(0)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="PhasorMeasurementUserControl"/> class.
        /// </summary>
        /// <param name="deviceID">ID of the device to filter measurements.</param>
        public PhasorMeasurementUserControl(int deviceID)
        {
            InitializeComponent();
            this.Unloaded += new RoutedEventHandler(PhasorMeasurementUserControl_Unloaded);
            this.DataContext = new PhasorMeasurements(deviceID, 17);
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Handles unloaded event.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Arguments of the event.</param>
        void PhasorMeasurementUserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            (this.DataContext as PhasorMeasurements).ProcessPropertyChange();
        }

        /// <summary>
        /// Handles key down event on the datagrid object.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Arguments of the event.</param>
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

        #endregion
    }
}
