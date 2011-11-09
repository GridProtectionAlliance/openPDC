//******************************************************************************************************
//  RealTimeStatisticUserControl.xaml.cs - Gbtc
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
//  09/29/2011 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using openPDC.UI.ViewModels;
using TimeSeriesFramework.UI;

namespace openPDC.UI.UserControls
{
    /// <summary>
    /// Interaction logic for RealTimeStatisticUserControl.xaml
    /// </summary>
    public partial class RealTimeStatisticUserControl : UserControl
    {
        #region [ Members ]

        // Fields
        private int m_statisticDataRefreshInterval = 10;
        private RealTimeStatistics m_dataContext;

        #endregion

        #region [ Constructor ]

        /// <summary>
        /// Creates a new instance of <see cref="RealTimeStatisticUserControl"/>.
        /// </summary>
        public RealTimeStatisticUserControl()
        {
            InitializeComponent();
            this.Loaded += new System.Windows.RoutedEventHandler(RealTimeStatisticUserControl_Loaded);
            this.Unloaded += new System.Windows.RoutedEventHandler(RealTimeStatisticUserControl_Unloaded);
        }

        #endregion

        #region [ Methods ]

        private void RealTimeStatisticUserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            m_dataContext.Stop();
        }

        private void RealTimeStatisticUserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            int.TryParse(TimeSeriesFramework.UI.IsolatedStorageManager.ReadFromIsolatedStorage("StreamStatisticsDataRefreshInterval").ToString(), out m_statisticDataRefreshInterval);

            if (m_statisticDataRefreshInterval == 0)
            {
                m_statisticDataRefreshInterval = 10;
                IsolatedStorageManager.InitializeStorageForStreamStatistics(true);
            }

            TextBlockMeasurementRefreshInterval.Text = m_statisticDataRefreshInterval.ToString() + " sec";
            TextBoxRefreshInterval.Text = m_statisticDataRefreshInterval.ToString();
            m_dataContext = new RealTimeStatistics(1, m_statisticDataRefreshInterval);
            this.DataContext = m_dataContext;
            this.KeyUp += new System.Windows.Input.KeyEventHandler(RealTimeStatisticUserControl_KeyUp);
        }

        #endregion

        private void RealTimeStatisticUserControl_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape && PopupSettings.IsOpen)
                PopupSettings.IsOpen = false;
        }

        private void ButtonDisplaySettings_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PopupSettings.IsOpen = true;
        }

        private void ButtonSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (int.TryParse(TextBoxRefreshInterval.Text, out m_statisticDataRefreshInterval))
            {
                m_dataContext.Stop();
                IsolatedStorageManager.WriteToIsolatedStorage("StreamStatisticsDataRefreshInterval", m_statisticDataRefreshInterval);
                int.TryParse(TimeSeriesFramework.UI.IsolatedStorageManager.ReadFromIsolatedStorage("StreamStatisticsDataRefreshInterval").ToString(), out m_statisticDataRefreshInterval);
                TextBlockMeasurementRefreshInterval.Text = m_statisticDataRefreshInterval.ToString();
                PopupSettings.IsOpen = false;
                CommonFunctions.LoadUserControl(new RealTimeStatisticUserControl(), "Real-Time Stream Statistics");
            }
            else
            {
                MessageBox.Show("Please provide integer value.", "ERROR: Invalid Value", MessageBoxButton.OK);
            }
        }

        private void ButtonRestore_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            m_dataContext.Stop();
            IsolatedStorageManager.InitializeStorageForStreamStatistics(true);
            int.TryParse(TimeSeriesFramework.UI.IsolatedStorageManager.ReadFromIsolatedStorage("StreamStatisticsDataRefreshInterval").ToString(), out m_statisticDataRefreshInterval);
            TextBlockMeasurementRefreshInterval.Text = m_statisticDataRefreshInterval.ToString();
            TextBoxRefreshInterval.Text = m_statisticDataRefreshInterval.ToString();
            PopupSettings.IsOpen = false;
            CommonFunctions.LoadUserControl(new RealTimeStatisticUserControl(), "Real-Time Stream Statistics");
        }

        private void ButtonCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PopupSettings.IsOpen = false;
        }
    }
}
