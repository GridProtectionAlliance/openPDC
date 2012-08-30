//******************************************************************************************************
//  RealTimeStatisticsUserControl.xaml.cs - Gbtc
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
//  07/23/2010 - Mehulbhai P Thakkar
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
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
using TVA.Configuration;

namespace openPDCManager.Pages.Adapters
{
    /// <summary>
    /// Interaction logic for RealTimeStatisticsUserControl.xaml
    /// </summary>
    public partial class RealTimeStatisticsUserControl : UserControl
    {
        #region [ Members ]

        ActivityWindow m_activityWindow;
        ObservableCollection<StatisticMeasurementData> m_statisticMeasurementDataList;
        StatisticMeasurementDataForBinding m_dataForBinding;
        DispatcherTimer m_thirtySecondsTimer;
        KeyValuePair<int, int> m_minMaxPointIDs;
        string m_url, m_nodeID;
        bool m_retrievingData;

        #endregion

        public RealTimeStatisticsUserControl()
        {
            InitializeComponent();            
            this.Loaded += new RoutedEventHandler(RealTimeStatistics_Loaded);
            this.Unloaded += new RoutedEventHandler(RealTimeStatisticsUserControl_Unloaded);
            m_dataForBinding = new StatisticMeasurementDataForBinding();
            m_statisticMeasurementDataList = new ObservableCollection<StatisticMeasurementData>();
            m_minMaxPointIDs = new KeyValuePair<int, int>();
            m_nodeID = ((App)Application.Current).NodeValue;

            int interval = 10;
            int.TryParse(IsolatedStorageManager.ReadFromIsolatedStorage("StatisticsDataRefreshInterval").ToString(), out interval);

            m_thirtySecondsTimer = new DispatcherTimer();
            m_thirtySecondsTimer.Interval = TimeSpan.FromSeconds(interval);
            TextBlockRefreshInterval.Text = "Refresh Interval: "  + interval.ToString() + " sec";           
            m_thirtySecondsTimer.Tick += new EventHandler(thirtySecondsTimer_Tick);
            m_thirtySecondsTimer.Start();
        }

        void RealTimeStatisticsUserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                m_thirtySecondsTimer.Stop();
                m_thirtySecondsTimer = null;
            }
            catch
            { }
        }

        #region [ Methods ]

        void GetMinMaxPointIDs()
        {
            m_minMaxPointIDs = CommonFunctions.GetMinMaxPointIDs(null, ((App)Application.Current).NodeValue);
        }

        void GetTimeTaggedMeasurements(string url)
        {
            if (!string.IsNullOrEmpty(url) && !m_retrievingData)
            {
                try
                {
                    m_retrievingData = true;
                    Dictionary<int, TimeTaggedMeasurement> timeTaggedMeasurements = new Dictionary<int, TimeTaggedMeasurement>();
                    timeTaggedMeasurements = CommonFunctions.GetStatisticMeasurements(url, m_nodeID);   //CommonFunctions.GetTimeTaggedMeasurements(url);

                    if (timeTaggedMeasurements != null)
                    {
                        TextBlockLastRefresh.Text = "Last Refresh: " + DateTime.Now.ToString();
                        foreach (StatisticMeasurementData statisticMeasurement in m_statisticMeasurementDataList)
                        {
                            foreach (StreamInfo streamInfo in statisticMeasurement.SourceStreamInfoList)
                            {
                                foreach (DeviceStatistic deviceStatistic in streamInfo.DeviceStatisticList)
                                {
                                    foreach (DetailStatisticInfo detailStatistic in deviceStatistic.StatisticList)
                                    {
                                        TimeTaggedMeasurement timeTaggedMeasurement;
                                        if (timeTaggedMeasurements.TryGetValue(detailStatistic.PointID, out timeTaggedMeasurement))
                                        {
                                            detailStatistic.Statistics.Value = timeTaggedMeasurement.CurrentValue;
                                            detailStatistic.Statistics.TimeTag = timeTaggedMeasurement.TimeTag;
                                            detailStatistic.Statistics.Quality = timeTaggedMeasurement.Quality;

                                            if (detailStatistic.Statistics.IsConnectedState == true)
                                            {
                                                DateTime sourceDateTime;
                                                if (DateTime.TryParseExact(timeTaggedMeasurement.TimeTag, "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out sourceDateTime) && DateTime.UtcNow.Subtract(sourceDateTime).TotalSeconds > 30)
                                                    streamInfo.StatusColor = "Gray";                                                                                                    
                                                else if (Convert.ToBoolean(timeTaggedMeasurement.CurrentValue))
                                                    streamInfo.StatusColor = "Green";
                                                else
                                                    streamInfo.StatusColor = "Red";
                                            }
                                            
                                        }
                                    }
                                }
                            }
                        }
                    }
                    
                    m_dataForBinding.IsExpanded = true;
                    m_dataForBinding.StatisticMeasurementDataList = m_statisticMeasurementDataList;
                    TreeViewRealTimeStatistics.DataContext = m_dataForBinding;TreeViewRealTimeStatistics.Items.Refresh();

                }
                catch (Exception ex)
                {
                    CommonFunctions.LogException(null, "WPF.TimeTaggedMeasurements", ex);
                }
                finally
                {
                    m_retrievingData = false;
                }
            }
        }

        void GetStatisticsMeasurementData()
        {
            try
            {
                m_statisticMeasurementDataList = CommonFunctions.GetStatisticMeasurementData(null, ((App)Application.Current).NodeValue);
                m_dataForBinding.StatisticMeasurementDataList = m_statisticMeasurementDataList;                
                m_dataForBinding.IsExpanded = false;
                TreeViewRealTimeStatistics.DataContext = m_dataForBinding;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetStatisticsMeasurementData", ex);
                SystemMessages sm = new SystemMessages(new openPDCManager.Utilities.Message() { UserMessage = "Failed to RetrieveStatistics Measurements Data", SystemMessage = ex.Message, UserMessageType = openPDCManager.Utilities.MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
            if (m_activityWindow != null)
                m_activityWindow.Close();
        }

        #endregion
               
        #region [ Page Event Handlers ]

        void thirtySecondsTimer_Tick(object sender, EventArgs e)
        {            
            GetTimeTaggedMeasurements(m_url);
        }

        void RealTimeStatistics_Loaded(object sender, RoutedEventArgs e)
        {
            m_activityWindow = new ActivityWindow("Loading Data... Please Wait...");
            m_activityWindow.Owner = Window.GetWindow(this);
            m_activityWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            m_activityWindow.Show();
            GetStatisticsMeasurementData();
            GetMinMaxPointIDs();
            App app = (App)Application.Current;
            if (string.IsNullOrEmpty(app.RealTimeStatisticServiceUrl))
                m_url = string.Empty;
            else
                m_url = app.RealTimeStatisticServiceUrl + "/timeseriesdata/read/current/" + m_minMaxPointIDs.Key.ToString() + "-" + m_minMaxPointIDs.Value.ToString() + "/XML";
            GetTimeTaggedMeasurements(m_url);
        }
                
        #endregion           

    }
}
