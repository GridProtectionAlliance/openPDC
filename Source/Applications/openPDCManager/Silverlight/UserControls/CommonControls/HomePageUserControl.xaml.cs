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
using System.Collections.ObjectModel;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Media.Animation;
#if SILVERLIGHT
using System.Windows.Navigation;
using System.ServiceModel;
using openPDCManager.LivePhasorDataServiceProxy;
using openPDCManager.PhasorDataServiceProxy;
#else
using openPDCManager.Data;
using openPDCManager.Data.Entities;
using openPDCManager.Data.BusinessObjects;
using System.Windows.Media.Imaging;
#endif


namespace openPDCManager.UserControls.CommonControls
{
    public partial class HomePageUserControl : UserControl
    {
        #region [ Members ]
                
        ActivityWindow m_activityWindow;
        //ObservableCollection<PmuDistribution> pmuDistributionList = new ObservableCollection<PmuDistribution>();        
        Dictionary<string, int> deviceDistributionList = new Dictionary<string, int>();        
        int framesPerSecond = 30;

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
#else
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
            GetTimeSeriesData(((App)Application.Current).TimeSeriesDataServiceUrl + "/timeseriesdata/read/historic/" + ((Measurement)ComboBoxMeasurements.SelectedItem).PointID.ToString() + "/*-30S/*/XML");
            GetInterconnectionStatus();
            GetDeviceDistributionList();
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
