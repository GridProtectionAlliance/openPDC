//******************************************************************************************************
//  HomePageUserControl.cs - Gbtc
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
//  07/20/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Threading;
using openPDCManager.Data;
using openPDCManager.Data.BusinessObjects;
using openPDCManager.Data.Entities;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
using System.Threading;

namespace openPDCManager.UserControls.CommonControls
{
    public partial class HomePageUserControl
    {
        #region [ Members ]
                
        bool m_connected = false;
        DispatcherTimer m_secondsTimer, m_thirtySecondsTimer;
        List<InterconnectionStatus> interconnectionStatusList = new List<InterconnectionStatus>();
        ObservableCollection<TimeSeriesDataPoint> timeSeriesDataList = new ObservableCollection<TimeSeriesDataPoint>();
        string m_url;
        bool m_retrievingData;

        #endregion

        #region [ Methods ]

        void Initialize()
        {
            this.Unloaded += new RoutedEventHandler(HomePageUserControl_Unloaded);
            ComboBoxMeasurements.SelectionChanged += new SelectionChangedEventHandler(ComboBoxMeasurements_SelectionChanged);
            Setter setter = new Setter();
            setter.Property = PieDataPoint.TemplateProperty;
            setter.Value = Application.Current.Resources["PieDataPointTemplate"] as ControlTemplate;

            Style pieDataPointStyle = new Style(typeof(PieDataPoint));
            pieDataPointStyle.Setters.Add(setter);
            ((PieSeries)ChartDeviceDistribution.Series[0]).DataPointStyle = pieDataPointStyle;
        }

        void StartThirtySecondsTimer()
        {
            m_thirtySecondsTimer = new DispatcherTimer();
            m_thirtySecondsTimer.Interval = TimeSpan.FromSeconds(10);
            m_thirtySecondsTimer.Tick += new EventHandler(thirtySecondsTimer_Tick);
            m_thirtySecondsTimer.Start();
        }

        void StartSecondsTimer()
        {
            m_secondsTimer = new DispatcherTimer();
            m_secondsTimer.Interval = TimeSpan.FromMilliseconds(1000);
            m_secondsTimer.Tick += new EventHandler(secondsTimer_Tick);
            m_secondsTimer.Start();
        }

        void GetTimeSeriesData(object timeSeriesDataServiceUrl)
        {
            if (!m_retrievingData)
            {
                try
                {
                    m_retrievingData = true;
                    //App app = (App)Application.Current;
                    List<TimeSeriesDataPoint> temp = new List<TimeSeriesDataPoint>();
                    temp = CommonFunctions.GetTimeSeriesData(timeSeriesDataServiceUrl.ToString());

                    ChartRealTimeData.Dispatcher.BeginInvoke((Action)delegate()
                    {
                        if (temp.Count > framesPerSecond)
                        {
                            for (int i = 0; i < (int)(temp.Count / framesPerSecond); i++)
                            {
                                if (timeSeriesDataList.Count == 0)
                                    timeSeriesDataList.Add(new TimeSeriesDataPoint() { Index = 0, Value = temp[(i * framesPerSecond)].Value });
                                else
                                    timeSeriesDataList.Add(new TimeSeriesDataPoint() { Index = timeSeriesDataList[timeSeriesDataList.Count - 1].Index + 1, Value = temp[(i * framesPerSecond)].Value });
                            }
                        }
                        else if (temp.Count > 0)
                        {
                            if (timeSeriesDataList.Count == 0)
                                timeSeriesDataList.Add(new TimeSeriesDataPoint() { Index = 0, Value = temp[0].Value });
                            else
                                timeSeriesDataList.Add(new TimeSeriesDataPoint() { Index = timeSeriesDataList[timeSeriesDataList.Count - 1].Index + 1, Value = temp[0].Value });
                        }
                        if (timeSeriesDataList.Count > 30)
                            timeSeriesDataList.RemoveAt(0);
                                            
                        ChartRealTimeData.DataContext = timeSeriesDataList;
                    });                    

                    if (m_secondsTimer == null)
                        StartSecondsTimer();

                    m_retrievingData = false;
                }
                catch (Exception ex)
                {
                    CommonFunctions.LogException("WPF.GetTimeSeriesData", ex);
                    if (m_secondsTimer != null)
                    {
                        m_secondsTimer.Stop();
                        m_secondsTimer = null;
                    }                    
                }
                finally
                {
                    m_retrievingData = false;
                }
            }
        }

        void GetDeviceDistributionList()
        {
            try
            {
                ChartDeviceDistribution.DataContext = CommonFunctions.GetVendorDeviceDistribution(((App)Application.Current).NodeValue);
                if (m_thirtySecondsTimer == null)
                    StartThirtySecondsTimer();
            }
            catch
            {

            }
            if (m_activityWindow != null)
                m_activityWindow.Close();
        }

        void GetInterconnectionStatus()
        {
            try
            {
                ItemControlInterconnectionStatus.ItemsSource = CommonFunctions.GetInterconnectionStatus(((App)Application.Current).NodeValue);
                if (m_thirtySecondsTimer == null)
                    StartThirtySecondsTimer();
            }
            catch
            {

            }
            if (m_activityWindow != null)
                m_activityWindow.Close();
        }

        void GetFilteredMeasurementsByDevice()
        {
            try
            {
                ComboBoxMeasurements.ItemsSource = CommonFunctions.GetFilteredMeasurementsByDevice(((KeyValuePair<int, string>)ComboBoxDevice.SelectedItem).Key);
                if (ComboBoxMeasurements.Items.Count > 0)
                    ComboBoxMeasurements.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.GetFilteredMeasurementsByDevice", ex);
                SystemMessages sm = new SystemMessages(new openPDCManager.Utilities.Message() { UserMessage = "Failed to Retrieve Measurements for Device", SystemMessage = ex.Message, UserMessageType = openPDCManager.Utilities.MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        void GetDevices()
        {
            try
            {
                ComboBoxDevice.ItemsSource = CommonFunctions.GetDevices(DeviceType.NonConcentrator, ((App)Application.Current).NodeValue, false);
                if (ComboBoxDevice.Items.Count > 0)
                    ComboBoxDevice.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.GetDevices", ex);
                SystemMessages sm = new SystemMessages(new openPDCManager.Utilities.Message() { UserMessage = "Failed to Retrieve Devices", SystemMessage = ex.Message, UserMessageType = openPDCManager.Utilities.MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        void ReconnectToService()
        {
            //reset time series data list
            timeSeriesDataList = new ObservableCollection<TimeSeriesDataPoint>();
        }

        #endregion

        #region [ Control Event Handlers ]

        void ComboBoxMeasurements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxMeasurements.Items.Count > 0 && ComboBoxMeasurements.SelectedIndex >= 0)
            {
#if !SILVERLIGHT
                //This was done for WPF to make sure there are measurements available in the dropdown before calling time series data service. Otherwise ComboboxMeasurements.SelectedItem returned NULL.
                ReconnectToService();
                GetTimeSeriesData(((App)Application.Current).TimeSeriesDataServiceUrl + "/timeseriesdata/read/historic/" + ((Measurement)ComboBoxMeasurements.SelectedItem).PointID.ToString() + "/*-30S/*/XML");
#endif
                
                m_url = ((App)Application.Current).TimeSeriesDataServiceUrl + "/timeseriesdata/read/current/" + ((Measurement)ComboBoxMeasurements.SelectedItem).PointID.ToString() + "/XML";
                framesPerSecond = (int)((Measurement)ComboBoxMeasurements.SelectedItem).FramesPerSecond;
                LinearAxis yAxis = (LinearAxis)ChartRealTimeData.Axes[1];
                if (((Measurement)ComboBoxMeasurements.SelectedItem).SignalSuffix == "PA")
                {
                    yAxis.Minimum = -180;
                    yAxis.Maximum = 180;
                    yAxis.Interval = 60;
                }
                else
                {
                    yAxis.Minimum = 59.95;
                    yAxis.Maximum = 60.05;
                    yAxis.Interval = 0.02;
                }
            }
            else
                m_url = string.Empty;
        }

        void HomePageUserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                m_secondsTimer.Stop();               
                m_secondsTimer = null;                
            }
            catch { }

            try
            {
                m_thirtySecondsTimer.Stop();
                m_thirtySecondsTimer = null;
            }
            catch { }
        }

        void thirtySecondsTimer_Tick(object sender, EventArgs e)
        {
            GetInterconnectionStatus();            
            GetDeviceDistributionList();   
        }

        void secondsTimer_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(m_url))
                ThreadPool.QueueUserWorkItem(GetTimeSeriesData, m_url);
                //GetTimeSeriesData(m_url);
        }

        #endregion
    }
}
