//******************************************************************************************************
//  HomePageUserControl.xaml.cs - Gbtc
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
using openPDCManager.ModalDialogs;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
#if SILVERLIGHT
using openPDCManager.LivePhasorDataServiceProxy;
#else
using openPDCManager.Data;
using openPDCManager.Data.Entities;
using openPDCManager.Data.BusinessObjects;
using System.Windows.Media.Imaging;
using openPDCManager.Pages.Monitoring;
using openPDCManager.Pages.Adapters;
using openPDCManager.Pages.Devices;
using openPDCManager.UserControls.OutputStreamControls;
using System.Linq;
using System.Text;
using openPDCManager.Data.ServiceCommunication;
using openPDCManager.Utilities;
using System.Threading;
#endif


namespace openPDCManager.UserControls.CommonControls
{
    public partial class HomePageUserControl : UserControl
    {
        #region [ Members ]
                
        ActivityWindow m_activityWindow;
        //ObservableCollection<PmuDistribution> pmuDistributionList = new ObservableCollection<PmuDistribution>();        
        Dictionary<string, int> m_deviceDistributionList = new Dictionary<string, int>();        
        int m_framesPerSecond = 30;

        #endregion

        #region [ Constructor ]

        public HomePageUserControl()
        {
            InitializeComponent(); 
            Initialize();
            this.Loaded += new RoutedEventHandler(HomePage_Loaded);            
#if SILVERLIGHT
            (Application.Current.RootVisual as MasterLayoutControl).UserControlSelectNode.ComboboxNode.SelectionChanged += new SelectionChangedEventHandler(ComboboxNode_SelectionChanged);            
            ChartDeviceDistribution.Style = (Style)Application.Current.Resources["PieChartStyle"];
            ButtonInputStatus.Visibility = Visibility.Collapsed;
            ButtonRestartOpenPDC.Visibility = Visibility.Collapsed;
            ScrollViewerStatus.Height = 570;
#else            
            ScrollViewerStatus.Height = 497;
            ButtonGetData.Content = new BitmapImage(new Uri(@"images/RequestData.png", UriKind.Relative));
#endif
            ButtonGetData.Click += new RoutedEventHandler(ButtonGetData_Click);
            ComboBoxDevice.SelectionChanged += new SelectionChangedEventHandler(ComboBoxDevice_SelectionChanged);            
        }

        #endregion

        #region [ Control Event Handlers ]

        void ComboBoxDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxDevice.Items.Count > 0 && ComboBoxDevice.SelectedIndex != -1)
            {
                if (((KeyValuePair<int, string>)ComboBoxDevice.SelectedItem).Key == 0)
                    ComboBoxMeasurements.ItemsSource = new Dictionary<int, string>();
                else
                    GetFilteredMeasurementsByDevice();
            }
        }

        void ButtonGetData_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            Storyboard sb = new Storyboard();
            sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            Storyboard.SetTarget(sb, ButtonGetDataTransform);
            sb.Begin();
#endif
            ReconnectToService();
        }

        void ComboboxNode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ReconnectToService();
            GetDevices();
        }

        private void ButtonInputStatus_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            
#else
            //InputMonitoringUserControl inputMonitor = new InputMonitoringUserControl();
            InputStatusUserControl inputMonitor = new InputStatusUserControl();
            ((MasterLayoutWindow)Window.GetWindow(this)).ContentFrame.Navigate(inputMonitor);
#endif
        }

        private void ButtonRuntimeStatistics_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            this.ParentPage.NavigationService.Navigate(new Uri("/Pages/Adapters/RealTimeStatistics.xaml", UriKind.Relative));
#else
            RealTimeStatisticsUserControl realtimeStatistics = new RealTimeStatisticsUserControl();            
            ((MasterLayoutWindow)Window.GetWindow(this)).ContentFrame.Navigate(realtimeStatistics);
#endif
        }

        private void ButtonAddDevice_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            this.ParentPage.NavigationService.Navigate(new Uri("/Pages/Devices/InputWizard.xaml", UriKind.Relative));
#else
            InputWizardUserControl inputWizard = new InputWizardUserControl();
            ((MasterLayoutWindow)Window.GetWindow(this)).ContentFrame.Navigate(inputWizard);
#endif
        }

        private void ButtonDevices_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            this.ParentPage.NavigationService.Navigate(new Uri("/Pages/Devices/Browse.xaml", UriKind.Relative));
            //System.Windows.Browser.HtmlPage.Window.Navigate(new Uri("/Pages/Devices/Browse.xaml", UriKind.Relative));
#else
            BrowseDevicesUserControl browseDevices = new BrowseDevicesUserControl();
            ((MasterLayoutWindow)Window.GetWindow(this)).ContentFrame.Navigate(browseDevices);
#endif
        }

        private void ButtonOutputStreams_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            this.ParentPage.NavigationService.Navigate(new Uri("/Pages/Adapters/OutputStreams.xaml", UriKind.Relative));
#else
            OutputStreamsUserControl outputStreams = new OutputStreamsUserControl();
            ((MasterLayoutWindow)Window.GetWindow(this)).ContentFrame.Navigate(outputStreams);
#endif
        }

        private void ButtonSystemConsole_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            this.ParentPage.NavigationService.Navigate(new Uri("/Pages/Monitor.xaml", UriKind.Relative));
#else
            MonitorUserControl monitor = new MonitorUserControl();
            ((MasterLayoutWindow)Window.GetWindow(this)).ContentFrame.Navigate(monitor);
#endif
        }

        private void ButtonRestartOpenPDC_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT

#else
            SystemMessages sm1 = new SystemMessages(new openPDCManager.Utilities.Message() { UserMessage = "Do you want to restart openPDC service?", SystemMessage = "", UserMessageType = openPDCManager.Utilities.MessageType.Confirmation }, ButtonType.YesNo);
            sm1.Closed += new EventHandler(delegate(object popupWindow, EventArgs eargs)
            {
                if ((bool)sm1.DialogResult)
                {
                    WindowsServiceClient serviceClient = ((App)Application.Current).ServiceClient;
                    if (serviceClient != null && serviceClient.Helper.RemotingClient.CurrentState == TVA.Communication.ClientState.Connected)
                    {
                        CommonFunctions.SendCommandToWindowsService(serviceClient, "Restart");
                        SystemMessages sm = new SystemMessages(new openPDCManager.Utilities.Message() { UserMessage = "Successfully sent RESTART command to openPDC", SystemMessage = "", UserMessageType = openPDCManager.Utilities.MessageType.Success }, ButtonType.OkOnly);
                        sm.Owner = Window.GetWindow(this);
                        sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        sm.ShowPopup();
                    }
                    else
                    {
                        SystemMessages sm = new SystemMessages(new openPDCManager.Utilities.Message() { UserMessage = "Failed to send RESTART command to openPDC", SystemMessage = "Application is disconnected from the openPDC Service.", UserMessageType = openPDCManager.Utilities.MessageType.Error }, ButtonType.OkOnly);
                        sm.Owner = Window.GetWindow(this);
                        sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        sm.ShowPopup();
                    }
                }
            });
            sm1.Owner = Window.GetWindow(this);
            sm1.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            sm1.ShowPopup();
#endif
        }

        #endregion

        #region [ Methods ]
                
        public void DisconnectFromService()
        {
            if (m_connected)
            {
#if SILVERLIGHT
                SendToService(new DisconnectMessage());
#endif
            }
        }

        #endregion

        #region [ Page Event Handlers ]

        void HomePage_Loaded(object sender, RoutedEventArgs e)
        {   
            m_activityWindow = new ActivityWindow("Loading Data... Please Wait...");
#if !SILVERLIGHT
            ((MasterLayoutWindow)Window.GetWindow(this)).UserControlSelectNode.ComboboxNode.SelectionChanged += new SelectionChangedEventHandler(ComboboxNode_SelectionChanged);
            m_activityWindow.Owner = Window.GetWindow(this);
            m_activityWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
#endif
            m_activityWindow.Show();
            GetDevices();
#if !SILVERLIGHT
            GetInterconnectionStatus();
            GetDeviceDistributionList();
            //GetTimeSeriesData(((App)Application.Current).TimeSeriesDataServiceUrl + "/timeseriesdata/read/historic/" + ((Measurement)ComboBoxMeasurements.SelectedItem).PointID.ToString() + "/*-30S/*/XML");            
            WindowsServiceClient serviceClient = ((App)Application.Current).ServiceClient;
            if (serviceClient == null || serviceClient.Helper.RemotingClient.CurrentState != TVA.Communication.ClientState.Connected || !((App)Application.Current).Principal.IsInRole("Administrator"))
                ButtonRestartOpenPDC.IsEnabled = false;
#endif
            //if (!string.IsNullOrEmpty(((App)Application.Current).NodeValue))
            //m_client.GetDevicesAsync(DeviceType.NonConcentrator, ((App)Application.Current).NodeValue, false);
            //else
            //{
            //    ReconnectToService();
            //    if (m_activityWindow != null)
            //        m_activityWindow.Close();
            //}
        }               

        #endregion

    }
}
