//******************************************************************************************************
//  RealTimeMeasurementUserControl.xaml.cs - Gbtc
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
//  09/26/2011 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System.Windows;
using System.Windows.Controls;
using openPDC.UI.DataModels;
using openPDC.UI.ViewModels;
using TimeSeriesFramework.UI;

namespace openPDC.UI.UserControls
{
    /// <summary>
    /// Interaction logic for RealTimeMeasurementUserControl.xaml
    /// </summary>
    public partial class RealTimeMeasurementUserControl : UserControl
    {
        #region [ Members ]

        // Fields
        private int m_measurementsDataRefreshInterval = 10;
        private RealTimeStreams m_dataContext;

        #endregion

        #region [ Constructor ]

        /// <summary>
        /// Creates a new instance of <see cref="RealTimeMeasurementUserControl"/>.
        /// </summary>
        public RealTimeMeasurementUserControl()
        {
            InitializeComponent();
            this.Loaded += new System.Windows.RoutedEventHandler(RealTimeMeasurementUserControl_Loaded);
            this.Unloaded += new RoutedEventHandler(RealTimeMeasurementUserControl_Unloaded);
        }

        #endregion

        #region [ Methods ]

        private void RealTimeMeasurementUserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            m_dataContext.RestartConnectionCycle = false;
            m_dataContext.UnsubscribeUnsynchronizedData();
        }

        private void RealTimeMeasurementUserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            int.TryParse(TimeSeriesFramework.UI.IsolatedStorageManager.ReadFromIsolatedStorage("RealtimeMeasurementsDataRefreshInterval").ToString(), out m_measurementsDataRefreshInterval);
            TextBlockMeasurementRefreshInterval.Text = m_measurementsDataRefreshInterval.ToString();
            TextBoxRefreshInterval.Text = m_measurementsDataRefreshInterval.ToString();
            m_dataContext = new RealTimeStreams(1, m_measurementsDataRefreshInterval);
            this.DataContext = m_dataContext;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            Device device = Device.GetDevice(null, "WHERE Acronym = '" + ((Button)sender).Tag.ToString() + "'");
            DeviceUserControl deviceUserControl = new DeviceUserControl(device);
            CommonFunctions.LoadUserControl(deviceUserControl, "Manage Device Configuration");
        }

        #endregion

        private void ButtonDisplaySettings_Click(object sender, RoutedEventArgs e)
        {
            PopupSettings.IsOpen = true;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TextBoxRefreshInterval.Text, out m_measurementsDataRefreshInterval))
            {
                m_dataContext.RestartConnectionCycle = false;
                m_dataContext.UnsubscribeUnsynchronizedData();
                IsolatedStorageManager.WriteToIsolatedStorage("RealtimeMeasurementsDataRefreshInterval", m_measurementsDataRefreshInterval);
                int.TryParse(TimeSeriesFramework.UI.IsolatedStorageManager.ReadFromIsolatedStorage("RealtimeMeasurementsDataRefreshInterval").ToString(), out m_measurementsDataRefreshInterval);
                PopupSettings.IsOpen = false;
                CommonFunctions.LoadUserControl(new RealTimeMeasurementUserControl(), "Real-Time Device Measurements");
            }
            else
            {
                MessageBox.Show("Please provide integer value.", "ERROR: Invalid Value", MessageBoxButton.OK);
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            PopupSettings.IsOpen = false;
        }

        private void ButtonRestore_Click(object sender, RoutedEventArgs e)
        {
            m_dataContext.RestartConnectionCycle = false;
            m_dataContext.UnsubscribeUnsynchronizedData();
            IsolatedStorageManager.InitializeStorageForRealTimeMeasurements(true);
            int.TryParse(TimeSeriesFramework.UI.IsolatedStorageManager.ReadFromIsolatedStorage("RealtimeMeasurementsDataRefreshInterval").ToString(), out m_measurementsDataRefreshInterval);
            PopupSettings.IsOpen = false;
            CommonFunctions.LoadUserControl(new RealTimeMeasurementUserControl(), "Real-Time Device Measurements");
        }
    }
}
