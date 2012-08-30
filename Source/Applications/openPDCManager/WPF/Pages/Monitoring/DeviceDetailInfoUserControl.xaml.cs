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
//  08/06/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using openPDCManager.Data;
using openPDCManager.Data.BusinessObjects;
using openPDCManager.Data.Entities;
using TVA.Configuration;
using openPDCManager.Utilities;

namespace openPDCManager.Pages.Monitoring
{
    /// <summary>
    /// Interaction logic for DeviceDetailInfoUserControl.xaml
    /// </summary>
    public partial class DeviceDetailInfoUserControl : UserControl
    {
        ObservableCollection<DetailStatisticInfo> m_deviceStatisticInfoList;
        DispatcherTimer m_refreshTimer;
        int m_maxPointID = 0;
        int m_minPointID = 0;
        string m_url, m_nodeID;

        public DeviceDetailInfoUserControl()
        {
            InitializeComponent();            
        }

        public void Initialize(Device deviceInfo)
        {
            if (deviceInfo != null)
            { 
                try
                {
                    m_nodeID = ((App)Application.Current).NodeValue;
                    GridDeviceInfo.DataContext = deviceInfo;
                    m_deviceStatisticInfoList = CommonFunctions.GetDeviceStatisticMeasurements(null, deviceInfo.ID);
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
                catch (Exception ex)
                {
                    CommonFunctions.LogException(null, "WPF.Initialize", ex);
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
            m_url = ((App)Application.Current).RealTimeStatisticServiceUrl + "/timeseriesdata/read/current/" + m_minPointID + "-" + m_maxPointID + "/XML";
        }

        void m_refreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshData();
        }

        void RefreshData()
        {
            if (!string.IsNullOrEmpty(m_url))
            {
                Dictionary<int, TimeTaggedMeasurement> timeTaggedMeasurements = new Dictionary<int, TimeTaggedMeasurement>();
                timeTaggedMeasurements = CommonFunctions.GetStatisticMeasurements(m_url, m_nodeID);   //CommonFunctions.GetTimeTaggedMeasurements(m_url);
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
    }
}
