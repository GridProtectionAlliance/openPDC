//******************************************************************************************************
//  RealTimeStatistics.cs - Gbtc
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Threading;
using System.Xml.Linq;
using openPDC.UI.DataModels;
using TimeSeriesFramework.UI;
using TVA;
using TVA.Data;

namespace openPDC.UI.ViewModels
{
    internal class RealTimeStatistics : PagedViewModelBase<RealTimeStatistic, int>
    {
        #region [ Members ]

        private int m_statisticDataRefreshInterval = 10;
        private DispatcherTimer m_refreshTimer;
        private string m_lastRefresh;
        private string m_url;

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets flag that determines if <see cref="PagedViewModelBase{T1, T2}.CurrentItem"/> is a new record.
        /// </summary>
        public override bool IsNewRecord
        {
            get
            {
                return false;
            }
        }

        public string LastRefresh
        {
            get
            {
                return m_lastRefresh;
            }
            set
            {
                m_lastRefresh = value;
                OnPropertyChanged("LastRefresh");
            }
        }

        #endregion

        #region [ Constructors ]

        public RealTimeStatistics(int itemsPerPage, bool autoSave = false)
            : base(0, autoSave)
        {
            int.TryParse(TimeSeriesFramework.UI.IsolatedStorageManager.ReadFromIsolatedStorage("StatisticsDataRefreshInterval").ToString(), out m_statisticDataRefreshInterval);
            m_refreshTimer = new DispatcherTimer();
            m_refreshTimer.Interval = TimeSpan.FromSeconds(m_statisticDataRefreshInterval);
            m_refreshTimer.Tick += new EventHandler(m_refreshTimer_Tick);
            Load();
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Gets the primary key value of the <see cref="PagedViewModelBase{T1, T2}.CurrentItem"/>.
        /// </summary>
        /// <returns>The primary key value of the <see cref="PagedViewModelBase{T1, T2}.CurrentItem"/>.</returns>
        public override int GetCurrentItemKey()
        {
            return 0;
        }

        /// <summary>
        /// Gets the string based named identifier of the <see cref="PagedViewModelBase{T1, T2}.CurrentItem"/>.
        /// </summary>
        /// <returns>The string based named identifier of the <see cref="PagedViewModelBase{T1, T2}.CurrentItem"/>.</returns>
        public override string GetCurrentItemName()
        {
            return "";
        }

        public override void Load()
        {
            base.Load();

            using (AdoDataConnection database = new AdoDataConnection(CommonFunctions.DefaultSettingsCategory))
            {
                m_url = database.RealTimeStatisticServiceUrl();
                if (!m_url.EndsWith("/"))
                    m_url = m_url + "/";

                m_url = m_url + "timeseriesdata/read/current/" + RealTimeStatistic.MinPointID.ToString() + "-" + RealTimeStatistic.MaxPointID.ToString() + "/XML";
            }

            m_refreshTimer.Start();
        }

        private void m_refreshTimer_Tick(object sender, EventArgs e)
        {
            GetStatisticData();
            LastRefresh = "Last Refresh: " + DateTime.Now.ToString("HH:mm:ss.fff");
        }

        private void GetStatisticData()
        {
            try
            {
                Dictionary<int, StatisticMeasurement> statisticMeasurementData = new Dictionary<int, StatisticMeasurement>();
                HttpWebRequest request = WebRequest.Create(m_url) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        XElement timeSeriesDataPoints = XElement.Parse(reader.ReadToEnd());


                        foreach (XElement element in timeSeriesDataPoints.Element("TimeSeriesDataPoints").Elements("TimeSeriesDataPoint"))
                        {
                            StatisticMeasurement measurement;
                            if (RealTimeStatistic.StatisticMeasurements.TryGetValue(Convert.ToInt32(element.Element("HistorianID").Value), out measurement))
                            {
                                DateTime sourceDateTime;
                                string quality;
                                if (DateTime.TryParseExact(element.Element("Time").Value, "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out sourceDateTime) && DateTime.UtcNow.Subtract(sourceDateTime).TotalSeconds > 30)
                                    quality = "Unknown";
                                else
                                    quality = element.Element("Quality").Value;

                                measurement.Quality = quality;
                                measurement.Value = string.Format(measurement.DisplayFormat, ConvertValueToType(element.Element("Value").Value, measurement.DataType));
                                measurement.TimeTag = sourceDateTime.ToString("HH:mm:ss.fff");

                                StreamStatistic streamStatistic;
                                if (measurement.ConnectedState) //if measurement defines connection state.
                                {
                                    if ((measurement.Source == "InputStream" && RealTimeStatistic.InputStreamStatistics.TryGetValue(measurement.DeviceID, out streamStatistic)) ||
                                        (measurement.Source == "OutputStream" && RealTimeStatistic.OutputStreamStatistics.TryGetValue(measurement.DeviceID, out streamStatistic)))
                                    {
                                        if (DateTime.TryParseExact(element.Element("Time").Value, "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out sourceDateTime) && DateTime.UtcNow.Subtract(sourceDateTime).TotalSeconds > 30)
                                            streamStatistic.StatusColor = "Gray";
                                        else if (Convert.ToBoolean(measurement.Value))
                                            streamStatistic.StatusColor = "Green";
                                        else
                                            streamStatistic.StatusColor = "Red";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Popup("Failed to Retrieve Statistic Data: " + Environment.NewLine + ex.Message, "ERROR - Get Statistic Data", MessageBoxImage.Error);
            }
        }

        private object ConvertValueToType(string xmlValue, string xmlDataType)
        {
            Type dataType = Type.GetType(xmlDataType);
            float value;

            if (float.TryParse(xmlValue, out value))
            {
                switch (xmlDataType)
                {
                    case "System.DateTime":
                        return new DateTime((long)value);
                    default:
                        return Convert.ChangeType(value, dataType);
                }
            }

            return "".ConvertToType<object>(dataType);
        }

        public void Stop()
        {
            if (m_refreshTimer != null)
            {
                try
                {
                    m_refreshTimer.Stop();
                }
                finally
                {
                    m_refreshTimer = null;
                }
            }
        }

        #endregion
    }
}
