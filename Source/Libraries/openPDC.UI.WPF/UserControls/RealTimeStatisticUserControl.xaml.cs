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

using System.Windows.Controls;
using openPDC.UI.ViewModels;

namespace openPDC.UI.UserControls
{
    /// <summary>
    /// Interaction logic for RealTimeStatisticUserControl.xaml
    /// </summary>
    public partial class RealTimeStatisticUserControl : UserControl
    {
        #region [ Members ]

        private int m_statisticDataRefreshInterval;
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
        }

        private void RealTimeStatisticUserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            int.TryParse(TimeSeriesFramework.UI.IsolatedStorageManager.ReadFromIsolatedStorage("StatisticsDataRefreshInterval").ToString(), out m_statisticDataRefreshInterval);
            TextBlockMeasurementRefreshInterval.Text = m_statisticDataRefreshInterval.ToString();
            m_dataContext = new RealTimeStatistics(1);
            this.DataContext = m_dataContext;
        }

        #endregion
    }
}
