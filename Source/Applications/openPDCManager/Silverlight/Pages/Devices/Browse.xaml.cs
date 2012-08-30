//******************************************************************************************************
//  Browse.xaml.cs - Gbtc
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
//  09/28/2009 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using openPDCManager.ModalDialogs;
using openPDCManager.PhasorDataServiceProxy;
using openPDCManager.Utilities;

namespace openPDCManager.Pages.Devices
{
	public partial class Browse : Page
	{
        #region [ Members ]

        PhasorDataServiceClient m_client;
        ObservableCollection<Device> m_deviceList = new ObservableCollection<Device>();
        PagedCollectionView m_pagedList;
        ActivityWindow m_activityWindow;

        #endregion

		#region [ Constructor ]

		public Browse()
		{
			InitializeComponent();
            m_client = ProxyClient.GetPhasorDataServiceProxyClient();
            m_client.GetDeviceListCompleted += new EventHandler<GetDeviceListCompletedEventArgs>(client_GetDeviceListCompleted);
            m_client.SaveDeviceCompleted += new EventHandler<SaveDeviceCompletedEventArgs>(m_client_SaveDeviceCompleted);
            m_client.DeleteDeviceCompleted += new EventHandler<DeleteDeviceCompletedEventArgs>(m_client_DeleteDeviceCompleted);
            Loaded += new RoutedEventHandler(Browse_Loaded);
            ButtonSearch.Click += new RoutedEventHandler(ButtonSearch_Click);
            ButtonShowAll.Click += new RoutedEventHandler(ButtonShowAll_Click);		
		}

		#endregion

        #region [ Control Event Handlers ]

        void ButtonShowAll_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sb = new Storyboard();
            sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            Storyboard.SetTarget(sb, ButtonShowAllTransform);
            sb.Begin();

            BindData(m_deviceList);
        }

        void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sb = new Storyboard();
            sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            Storyboard.SetTarget(sb, ButtonSearchTransform);
            sb.Begin();

            string searchText = TextBoxSearch.Text.ToUpper();
            List<Device> searchResult = new List<Device>();
            searchResult = (from item in m_deviceList
                            where item.Acronym.ToUpper().Contains(searchText) || item.Name.ToUpper().Contains(searchText) || item.ProtocolName.ToUpper().Contains(searchText)
                               || item.InterconnectionName.ToUpper().Contains(searchText) || item.CompanyName.ToUpper().Contains(searchText) || item.VendorDeviceName.ToUpper().Contains(searchText)
                            select item).ToList();
            BindData(searchResult);
        }

        void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            string deviceId = ((HyperlinkButton)sender).Tag.ToString();
            NavigationService.Navigate(new Uri("/Pages/Devices/AddNew.xaml?did=" + deviceId, UriKind.Relative));
        }

        void HyperlinkButtonPhasors_Click(object sender, RoutedEventArgs e)
        {
            int deviceId = Convert.ToInt32(((HyperlinkButton)sender).Tag.ToString());
            string acronym = ((HyperlinkButton)sender).Name;
            Phasors phasors = new Phasors(deviceId, acronym);
            phasors.Show();
        }

        void HyperlinkButtonMeasurements_Click(object sender, RoutedEventArgs e)
        {
            string deviceId = ((HyperlinkButton)sender).Tag.ToString();
            NavigationService.Navigate(new Uri("/Pages/Manage/Measurements.xaml?did=" + deviceId, UriKind.Relative));
        }

        void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            Device device = new Device();
            device = ((Button)sender).DataContext as Device;
            m_client.SaveDeviceAsync(device, false, 0, 0);
        }

        void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Device device = new Device();
            device = ((Button)sender).DataContext as Device;
            SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Do you want to delete device?", SystemMessage = "Device Acronym: " + device.Acronym, UserMessageType = MessageType.Confirmation }, ButtonType.YesNo);
            sm.Closed += new EventHandler(delegate(object popupWindow, EventArgs eargs)
            {
                if ((bool)sm.DialogResult)
                    m_client.DeleteDeviceAsync(device.ID);
            });
            sm.ShowPopup();
        }

        void ButtonCopy_Click(object sender, RoutedEventArgs e)
        {
            Device device = new Device();
            device = ((Button)sender).DataContext as Device;
            SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Do you want to make a copy of " + device.Acronym + " device?", SystemMessage = "This will copy device configuration and generate new measurements.", UserMessageType = MessageType.Confirmation }, ButtonType.YesNo);
            sm.Closed += new EventHandler(delegate(object popupWindow, EventArgs eargs)
            {
                if ((bool)sm.DialogResult)
                    NavigationService.Navigate(new Uri("/Pages/Devices/AddNew.xaml?copydid=" + device.ID, UriKind.Relative));
            });
            sm.ShowPopup();
        }

        void sm_Closed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region [ Page Event Handlers ]

        void Browse_Loaded(object sender, RoutedEventArgs e)
        {
            m_activityWindow = new ActivityWindow("Loading Data... Please Wait...");
            m_activityWindow.Show();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RefreshDeviceList();
        }

        #endregion

        #region [ Service Event Handlers ]

        void client_GetDeviceListCompleted(object sender, GetDeviceListCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                m_deviceList = e.Result;
                BindData(m_deviceList);
            }
            else
            {
                SystemMessages sm;
                if (e.Error is FaultException<CustomServiceFault>)
                {
                    FaultException<CustomServiceFault> fault = e.Error as FaultException<CustomServiceFault>;
                    sm = new SystemMessages(new Message() { UserMessage = fault.Detail.UserMessage, SystemMessage = fault.Detail.SystemMessage, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                }
                else
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Device List", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
            if (m_activityWindow != null)
                m_activityWindow.Close();
        }

        void m_client_SaveDeviceCompleted(object sender, SaveDeviceCompletedEventArgs e)
        {
            SystemMessages sm;
            if (e.Error == null)
                sm = new SystemMessages(new Message() { UserMessage = e.Result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
            else
            {
                if (e.Error is FaultException<CustomServiceFault>)
                {
                    FaultException<CustomServiceFault> fault = e.Error as FaultException<CustomServiceFault>;
                    sm = new SystemMessages(new Message() { UserMessage = fault.Detail.UserMessage, SystemMessage = fault.Detail.SystemMessage, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                }
                else
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Device Information", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
            }
            sm.ShowPopup();

            RefreshDeviceList();
        }

        void m_client_DeleteDeviceCompleted(object sender, DeleteDeviceCompletedEventArgs e)
        {
            SystemMessages sm;
            if (e.Error == null)
                sm = new SystemMessages(new Message() { UserMessage = e.Result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
            else
            {
                if (e.Error is FaultException<CustomServiceFault>)
                {
                    FaultException<CustomServiceFault> fault = e.Error as FaultException<CustomServiceFault>;
                    sm = new SystemMessages(new Message() { UserMessage = fault.Detail.UserMessage, SystemMessage = fault.Detail.SystemMessage, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                }
                else
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Delete Device", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
            }
            sm.ShowPopup();

            System.Diagnostics.Debug.WriteLine(sm.DialogResult);

            RefreshDeviceList();
        }

        #endregion

        #region [ Methods ]

        void RefreshDeviceList()
        {
            App app = (App)Application.Current;
            string nodeID = app.NodeValue;
            m_client.GetDeviceListAsync(nodeID);
        }

        void BindData(IEnumerable<Device> deviceList)
        {
            m_pagedList = new PagedCollectionView(deviceList);
            ListBoxDeviceList.ItemsSource = m_pagedList;
            DataPagerDevices.Source = m_pagedList;
            ListBoxDeviceList.SelectedIndex = -1;
        }

        #endregion

        private void HyperlinkButtonCreatedOn_Click(object sender, RoutedEventArgs e)
        {
            SortData("CreatedOn");
        }

        private void HyperlinkButtonAcronym_Click(object sender, RoutedEventArgs e)
        {
            SortData("Acronym");
        }

        void SortData(string sortFieldName)
        {
            if (m_pagedList.SortDescriptions.Contains(new SortDescription(sortFieldName, ListSortDirection.Ascending)))
            {
                //m_pagedList.SortDescriptions.Remove(new SortDescription(sortFieldName, ListSortDirection.Ascending));
                m_pagedList.SortDescriptions.Clear();
                m_pagedList.SortDescriptions.Add(new SortDescription(sortFieldName, ListSortDirection.Descending));
            }
            else if (m_pagedList.SortDescriptions.Contains(new SortDescription(sortFieldName, ListSortDirection.Descending)))
            {
                m_pagedList.SortDescriptions.Clear();
                m_pagedList.SortDescriptions.Add(new SortDescription(sortFieldName, ListSortDirection.Ascending));
            }
            else
                m_pagedList.SortDescriptions.Add(new SortDescription(sortFieldName, ListSortDirection.Ascending));

            ListBoxDeviceList.ItemsSource = m_pagedList;
            DataPagerDevices.Source = m_pagedList;
            ListBoxDeviceList.SelectedIndex = -1;
        }
		
	}
}
