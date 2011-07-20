//******************************************************************************************************
//  DeviceDetailInfoUserControl.xaml.cs - Gbtc
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
//  07/15/2011 - Magdiel D. Lorenzo
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using openPDCManager.UI.DataModels;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using TVA.Data;
using TimeSeriesFramework.UI;

namespace openPDCManager.UI.UserControls
{
    /// <summary>
    /// Interaction logic for DeviceDetailInfoUserControl.xaml
    /// </summary>
    public partial class DeviceDetailInfoUserControl : UserControl
    {
        #region [ Members ]

        private ObservableCollection<DetailStatisticInfo> m_deviceStatisticInfoList;
        private DispatcherTimer m_refreshTimer;
        private int m_maxPointID = 0;
        private int m_minPointID = 0;
        private string m_url;
        private Guid m_nodeID;
        private AdoDataConnection database;

        #endregion

        #region [ Constructor ]

        public DeviceDetailInfoUserControl()
        {
            InitializeComponent();
            database = new AdoDataConnection(CommonFunctions.DefaultSettingsCategory);
        }
 
        #endregion

        #region [ Methods ]

        public void Initialize(Device deviceInfo)
        {
            if (deviceInfo != null)
            {
                try
                {
                    m_nodeID = (Guid)database.CurrentNodeID();
                    GridDeviceInfo.DataContext = deviceInfo;
                    m_deviceStatisticInfoList = new ObservableCollection<DetailStatisticInfo>(TimeTaggedMeasurement.GetStatisticInfoList(null, m_nodeID));
                    ListBoxStatisticsList.ItemsSource = m_deviceStatisticInfoList;
                    if (m_deviceStatisticInfoList.Count > 0)
                    {
                        GetMaxMinPointIDs();
                        RefreshData();
                    }

                    if (m_refreshTimer == null)
                    {
                        int interval = 10;
                        int.TryParse(IsolatedStorageManager.ReadFromIsolatedStorage("StatisticsDataRefreshInterval").ToString(), out interval);

                        m_refreshTimer = new DispatcherTimer();
                        m_refreshTimer.Interval = TimeSpan.FromSeconds(interval);
                        m_refreshTimer.Tick += new EventHandler(m_refreshTimer_Tick);
                        m_refreshTimer.Start();

                        TextBlockRefreshInterval.Text = " (Refresh Interval: " + interval.ToString() + " sec)";
                    }
                }
                catch (Exception e)
                {
                    CommonFunctions.LogException(null, "WPF.Initialize", e);
                }
            }
        }

        void GetMaxMinPointIDs()
        {
            m_maxPointID = int.MinValue;
            m_minPointID = int.MaxValue;
            foreach (DetailStatisticInfo statInfo in m_deviceStatisticInfoList)
            {
                if (statInfo.PointID > m_maxPointID)
                    m_maxPointID = statInfo.PointID;

                if (statInfo.PointID < m_minPointID)
                    m_minPointID = statInfo.PointID;
            }
            m_url = database.RealTimeStatisticServiceUrl() + "/timeseriesdata/read/current" + m_minPointID + "-" + m_maxPointID + "/XML";
        }

        void RefreshData()
        {
            if (!string.IsNullOrEmpty(m_url))
            {
                Dictionary<int, TimeTaggedMeasurement> timeTaggedMeasurements = new Dictionary<int, TimeTaggedMeasurement>();
                timeTaggedMeasurements = TimeTaggedMeasurement.GetStatisticMeasurements(m_url, m_nodeID.ToString());
                foreach (DetailStatisticInfo detailStatistic in m_deviceStatisticInfoList)
                {
                    TimeTaggedMeasurement timeTaggedMeasurement;
                    if (timeTaggedMeasurements.TryGetValue(detailStatistic.PointID, out timeTaggedMeasurement))
                    {
                        detailStatistic.Statistics.Value = timeTaggedMeasurement.CurrentValue;
                        detailStatistic.Statistics.TimeTag = timeTaggedMeasurement.TimeTag;
                        detailStatistic.Statistics.Quality = timeTaggedMeasurement.Quality;
                    }
                }
                ListBoxStatisticsList.Items.Refresh();
                ListBoxStatisticsList.ItemsSource = m_deviceStatisticInfoList;
            }
        }

        #region [ Timer Event Handlers ]

        void m_refreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshData();
        }
 
        #endregion

        #endregion
    }
}
