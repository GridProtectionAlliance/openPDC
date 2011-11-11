//******************************************************************************************************
//  OutputStreamDeviceMeasurementUserControl.cs - Gbtc
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
//  09/14/2011 - Aniket Salver
//       Generated original version of source code.
//  09/16/2011 - Mehulbhai Thakkar
//       Added code to attach this user control to parent Output Stream.
//       Added delete key handling logic.
//
//******************************************************************************************************

using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using openPDC.UI.DataModels;
using openPDC.UI.ViewModels;
using TimeSeriesFramework.UI.DataModels;

namespace openPDC.UI.UserControls
{
    /// <summary>
    /// Interaction logic for OutputStreamMeasurementUserControl.xaml
    /// </summary>
    public partial class OutputStreamMeasurementUserControl : UserControl
    {
        #region [ Members ]

        private OutputStreamMeasurements m_dataContext;
        private int m_outputStreamID;
        private ObservableCollection<Measurement> m_newMeasurements;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates an instance of <see cref="OutputStreamMeasurementUserControl"/> class.
        /// </summary>
        public OutputStreamMeasurementUserControl(int outputStreamID)
        {
            InitializeComponent();
            m_outputStreamID = outputStreamID;
            m_dataContext = new OutputStreamMeasurements(outputStreamID, 24);
            this.DataContext = m_dataContext;
            m_newMeasurements = new ObservableCollection<Measurement>();
        }

        #endregion

        #region [ Methods ]

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

        #region [ Popup Code]

        private void LoadNewMeasurements(string filterText)
        {
            if (string.IsNullOrEmpty(filterText))
            {
                m_newMeasurements = Measurement.GetNewOutputStreamMeasurements(null, m_outputStreamID);
            }
            else
            {
                filterText = filterText.ToLower();
                m_newMeasurements = new ObservableCollection<Measurement>(
                        Measurement.GetNewOutputStreamMeasurements(null, m_outputStreamID).Where(m => m.Description.Contains(filterText) ||
                                                                                                    m.SignalAcronym.Contains(filterText) ||
                                                                                                    m.PointTag.Contains(filterText) ||
                                                                                                    m.SignalReference.Contains(filterText))
                    );
            }

            DataGridAddMeasurements.ItemsSource = m_newMeasurements;
        }

        private void CheckBoxAddMore_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            foreach (Measurement measurement in m_newMeasurements)
                measurement.Enabled = true;
        }

        private void CheckBoxAddMore_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            foreach (Measurement measurement in m_newMeasurements)
                measurement.Enabled = false;
        }

        private void ButtonAddMore_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //OutputStreamDevice.AddDevices(null, m_outputStreamID, new ObservableCollection<Device>(m_newDevices.Where(d => d.Enabled == true)),
            //    (bool)CheckBoxAddDigitals.IsChecked, (bool)CheckBoxAddAnalogs.IsChecked);

            OutputStreamMeasurement.AddMeasurements(null, m_outputStreamID, new ObservableCollection<Measurement>(m_newMeasurements.Where(m => m.Enabled == true)));
            m_dataContext = new OutputStreamMeasurements(m_outputStreamID, 24);
            this.DataContext = m_dataContext;
            PopupAddMore.IsOpen = false;
        }

        private void ButtonCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            m_dataContext = new OutputStreamMeasurements(m_outputStreamID, 24);
            this.DataContext = m_dataContext;
            PopupAddMore.IsOpen = false;
        }

        private void ButtonSearch_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            LoadNewMeasurements(TextBoxSearch.Text.Replace("'", "").Replace("%", ""));
        }

        private void ButtonShowAll_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            LoadNewMeasurements(string.Empty);
        }

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadNewMeasurements(string.Empty);
            PopupAddMore.IsOpen = true;
        }

        private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            m_dataContext.SortData(e.Column.SortMemberPath);
        }

        #endregion
    }
}
