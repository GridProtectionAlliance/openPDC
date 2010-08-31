//******************************************************************************************************
//  DeviceMeasurementsUserControl.xaml.cs - Gbtc
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
//  07/22/2010 - Mehulbhai P Thakkar
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
    /// Interaction logic for DeviceMeasurementsUserControl.xaml
    /// </summary>
    public partial class DeviceMeasurementsUserControl : UserControl
    {
        #region [ Members ]

        ActivityWindow m_activityWindow;
        ObservableCollection<DeviceMeasurementData> m_deviceMeasurementDataList;
        DeviceMeasurementDataForBinding m_dataForBinding;
        DispatcherTimer m_thirtySecondsTimer;
        KeyValuePair<int, int> m_minMaxPointIDs;
        string m_url;
        bool m_retrievingData;

        #endregion

        #region [ Constructor ]

        public DeviceMeasurementsUserControl()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(DeviceMeasurementsUserControl_Loaded);
            this.Unloaded += new RoutedEventHandler(DeviceMeasurementsUserControl_Unloaded);
            m_dataForBinding = new DeviceMeasurementDataForBinding();
            m_deviceMeasurementDataList = new ObservableCollection<DeviceMeasurementData>();
            m_minMaxPointIDs = new KeyValuePair<int, int>();                        
        }

        #endregion

        #region [ Page Event Handlers ]

        void thirtySecondsTimer_Tick(object sender, EventArgs e)
        {            
            GetTimeTaggesMeasurements(m_url);            
        }

        void DeviceMeasurementsUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            m_activityWindow = new ActivityWindow("Loading Data... Please Wait...");
            m_activityWindow.Owner = Window.GetWindow(this);
            m_activityWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            m_activityWindow.Show();
            GetDeviceMeasurementData();            
            GetMinMaxPointIDs();
            App app = (App)Application.Current;
            if (string.IsNullOrEmpty(app.TimeSeriesDataServiceUrl))
                m_url = string.Empty;
            else
                m_url = app.TimeSeriesDataServiceUrl + "/timeseriesdata/read/current/" + m_minMaxPointIDs.Key.ToString() + "-" + m_minMaxPointIDs.Value.ToString() + "/XML";
            GetTimeTaggesMeasurements(m_url);
        }

        void DeviceMeasurementsUserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (m_thirtySecondsTimer != null)
                    m_thirtySecondsTimer.Stop();
                m_thirtySecondsTimer = null;
            }
            catch { }            
        }

        #endregion

        #region [ Methods ]

        void GetMinMaxPointIDs()
        {
             m_minMaxPointIDs = CommonFunctions.GetMinMaxPointIDs(((App)Application.Current).NodeValue);
        }

        void GetTimeTaggesMeasurements(string url)
        {
            if (!string.IsNullOrEmpty(url) && !m_retrievingData)
            {
                try
                {
                    m_retrievingData = true;
                    Dictionary<int, TimeTaggedMeasurement> timeTaggedMeasurements = new Dictionary<int, TimeTaggedMeasurement>();
                    timeTaggedMeasurements = CommonFunctions.GetTimeTaggedMeasurements(url);
                    TextBlockLastRefresh.Text = "Last Refresh: " + DateTime.Now.ToString();
                    foreach (DeviceMeasurementData deviceMeasurement in m_deviceMeasurementDataList)
                    {
                        foreach (DeviceInfo device in deviceMeasurement.DeviceList)
                        {
                            foreach (MeasurementInfo measurement in device.MeasurementList)
                            {
                                TimeTaggedMeasurement timeTaggedMeasurement;
                                if (timeTaggedMeasurements.TryGetValue(measurement.PointID, out timeTaggedMeasurement))
                                {
                                    measurement.CurrentValue = timeTaggedMeasurement.CurrentValue;
                                    measurement.CurrentTimeTag = timeTaggedMeasurement.TimeTag;
                                    measurement.CurrentQuality = timeTaggedMeasurement.Quality;
                                }
                            }
                        }
                    }

                    TreeViewDeviceMeasurements.Items.Refresh();
                    m_dataForBinding.IsExpanded = true;
                    m_dataForBinding.DeviceMeasurementDataList = m_deviceMeasurementDataList;
                    TreeViewDeviceMeasurements.DataContext = m_dataForBinding;
                }
                catch (Exception ex)
                {
                    CommonFunctions.LogException("WPF.GetTimeTaggedMeasurements", ex);
                }
                finally
                {
                    m_retrievingData = false;
                }
            }
        }

        void GetDeviceMeasurementData()
        {
            try
            {
                m_deviceMeasurementDataList = CommonFunctions.GetDeviceMeasurementData(((App)Application.Current).NodeValue);
                m_dataForBinding.DeviceMeasurementDataList = m_deviceMeasurementDataList;
                m_dataForBinding.IsExpanded = false;
                TreeViewDeviceMeasurements.DataContext = m_dataForBinding;
                if (m_thirtySecondsTimer == null)
                    StartTimer();
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.GetDeviceMeasurementsData", ex);
                SystemMessages sm = new SystemMessages(new openPDCManager.Utilities.Message() { UserMessage = "Failed to Retrieve Current Device Measurements Tree Data", SystemMessage = ex.Message, UserMessageType = openPDCManager.Utilities.MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
            if (m_activityWindow != null)
                m_activityWindow.Close();
        }

        void StartTimer()
        {
            ConfigurationFile config = ConfigurationFile.Current;
            CategorizedSettingsElementCollection configSettings = config.Settings["systemSettings"];

            string timerInterval = configSettings["RealTimeMeasurementRefreshInterval"].Value;
            int interval = 10;

            if (!string.IsNullOrEmpty(timerInterval))
            {
                if (!int.TryParse(timerInterval, out interval))
                    interval = 10;
            }

            m_thirtySecondsTimer = new DispatcherTimer();
            m_thirtySecondsTimer.Interval = TimeSpan.FromSeconds(interval);
            TextBlockRefreshInterval.Text = "Refresh Interval: " + interval.ToString() + " sec";
            m_thirtySecondsTimer.Tick += new EventHandler(thirtySecondsTimer_Tick);
            m_thirtySecondsTimer.Start();
        }
        
        #endregion
           
    }
}
