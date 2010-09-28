//******************************************************************************************************
//  Measurements.xaml.cs - Gbtc
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
//  10/23/2009 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace openPDCManager.Pages.Manage
{
	public partial class Measurements : Page
	{
		#region [ Members ]

		PhasorDataServiceClient m_client;
		bool m_inEditMode = false;
		string m_signalID = string.Empty;
		int m_deviceID = 0;
		ActivityWindow m_activityWindow;
		ObservableCollection<Measurement> m_measurementList;
        bool m_selectFirst = true;

		#endregion

		#region [ Constructor ]

		public Measurements()
		{
			InitializeComponent();
			Loaded += new RoutedEventHandler(Measurements_Loaded);
			m_client = ProxyClient.GetPhasorDataServiceProxyClient();
			m_client.GetHistoriansCompleted += new EventHandler<GetHistoriansCompletedEventArgs>(client_GetHistoriansCompleted);
			m_client.GetDevicesCompleted += new EventHandler<GetDevicesCompletedEventArgs>(client_GetDevicesCompleted);
			m_client.GetSignalTypesCompleted += new EventHandler<GetSignalTypesCompletedEventArgs>(client_GetSignalTypesCompleted);
			m_client.GetPhasorsCompleted += new EventHandler<GetPhasorsCompletedEventArgs>(client_GetPhasorsCompleted);
			m_client.GetMeasurementListCompleted += new EventHandler<GetMeasurementListCompletedEventArgs>(client_GetMeasurementListCompleted);
			m_client.SaveMeasurementCompleted += new EventHandler<SaveMeasurementCompletedEventArgs>(client_SaveMeasurementCompleted);
			m_client.GetMeasurementsByDeviceCompleted += new EventHandler<GetMeasurementsByDeviceCompletedEventArgs>(client_GetMeasurementsByDeviceCompleted);
			m_client.GetDeviceByDeviceIDCompleted += new EventHandler<GetDeviceByDeviceIDCompletedEventArgs>(client_GetDeviceByDeviceIDCompleted);
			ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
			ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
			ListBoxMeasurementList.SelectionChanged += new SelectionChangedEventHandler(ListBoxMeasurementList_SelectionChanged);
			ComboBoxDevice.SelectionChanged += new SelectionChangedEventHandler(ComboBoxDevice_SelectionChanged);
			ButtonSearch.Click += new RoutedEventHandler(ButtonSearch_Click);
			ButtonShowAll.Click += new RoutedEventHandler(ButtonShowAll_Click);
		}

		#endregion

		#region [ Service Event Handlers ]

		void client_GetDeviceByDeviceIDCompleted(object sender, GetDeviceByDeviceIDCompletedEventArgs e)
		{
			if (e.Error == null)
			{
				Device device = e.Result;
				TextBlockHeading.Text = "Manage Measurements For Device: " + device.Acronym;
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
					sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Device Information", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
						ButtonType.OkOnly);

				sm.ShowPopup();
			}
		}

		void client_GetMeasurementsByDeviceCompleted(object sender, GetMeasurementsByDeviceCompletedEventArgs e)
		{
			if (e.Error == null)
			{
				m_measurementList = e.Result;
				BindData(m_measurementList);
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
					sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Measurements for Device", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
						ButtonType.OkOnly);

				sm.ShowPopup();
			}
			if (m_activityWindow != null)
				m_activityWindow.Close();	
		}
		
		void client_GetMeasurementListCompleted(object sender, GetMeasurementListCompletedEventArgs e)
		{
			if (e.Error == null)
			{
				m_measurementList = e.Result;
				BindData(m_measurementList);
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
					sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Measurement List", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
						ButtonType.OkOnly);

				sm.ShowPopup();
			}
			if (m_activityWindow != null)
				m_activityWindow.Close();			
		}
		
		void client_SaveMeasurementCompleted(object sender, SaveMeasurementCompletedEventArgs e)
		{
			SystemMessages sm;
			if (e.Error == null)
			{
				ClearForm();
				//(Application.Current.RootVisual as MasterLayoutControl).UserControlSelectNode.RaiseNotification();
				sm = new SystemMessages(new Message() { UserMessage = e.Result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
						ButtonType.OkOnly);
			}
			else
			{
				if (e.Error is FaultException<CustomServiceFault>)
				{
					FaultException<CustomServiceFault> fault = e.Error as FaultException<CustomServiceFault>;
					sm = new SystemMessages(new Message() { UserMessage = fault.Detail.UserMessage, SystemMessage = fault.Detail.SystemMessage, UserMessageType = MessageType.Error },
						ButtonType.OkOnly);
				}
				else
					sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Measurement Information", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
						ButtonType.OkOnly);
			}
			sm.ShowPopup();

			App app = (App)Application.Current;
			if (m_deviceID > 0)
				m_client.GetMeasurementsByDeviceAsync(m_deviceID);
			else
				m_client.GetMeasurementListAsync(app.NodeValue);
		}

		void client_GetPhasorsCompleted(object sender, GetPhasorsCompletedEventArgs e)
		{
			//ComboBoxPhasorSource.Items.Clear();
			if (e.Error == null)
			{
				ComboBoxPhasorSource.ItemsSource = e.Result;
				if (ComboBoxPhasorSource.Items.Count > 0)
				{
					ComboBoxPhasorSource.SelectedIndex = 0;
					if (ListBoxMeasurementList.SelectedIndex >= 0)
					{
						Measurement selectedMeasurement = ListBoxMeasurementList.SelectedItem as Measurement;
						if (selectedMeasurement.PhasorSourceIndex.HasValue)
						{
							foreach (KeyValuePair<int, string> item in ComboBoxPhasorSource.Items)
							{
								if (item.Value == selectedMeasurement.PhasorLabel)
								{
									ComboBoxPhasorSource.SelectedItem = item;
									break;
								}
							}
						}
						else
							ComboBoxPhasorSource.SelectedIndex = 0;
					}
				}
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
					sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Phasors", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
						ButtonType.OkOnly);

				sm.ShowPopup();
			}
		}

		void client_GetSignalTypesCompleted(object sender, GetSignalTypesCompletedEventArgs e)
		{
			if (e.Error == null)
			{
				ComboBoxSignalType.ItemsSource = e.Result;
				if (ComboBoxSignalType.Items.Count > 0)
					ComboBoxSignalType.SelectedIndex = 0;
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
					sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Signal Types", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
						ButtonType.OkOnly);

				sm.ShowPopup();
			}
		}

		void client_GetDevicesCompleted(object sender, GetDevicesCompletedEventArgs e)
		{
			if (e.Error == null)
			{
				ComboBoxDevice.ItemsSource = e.Result;
				if (ComboBoxDevice.Items.Count > 0)
					ComboBoxDevice.SelectedIndex = 0;
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
					sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Devices", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
						ButtonType.OkOnly);

				sm.ShowPopup();
			}
		}

		void client_GetHistoriansCompleted(object sender, GetHistoriansCompletedEventArgs e)
		{
			if (e.Error == null)
			{
				ComboBoxHistorian.ItemsSource = e.Result;
				if (ComboBoxHistorian.Items.Count > 0)
					ComboBoxHistorian.SelectedIndex = 0;
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
					sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Historians", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
						ButtonType.OkOnly);

				sm.ShowPopup();
			}
		}
		
		#endregion

		#region [ Control Event Handlers ]

		void ComboBoxDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			KeyValuePair<int, string> selectedDevice = (KeyValuePair<int, string>)ComboBoxDevice.SelectedItem;
			m_client.GetPhasorsAsync(selectedDevice.Key, true);
		}
		
		void ListBoxMeasurementList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (ListBoxMeasurementList.SelectedIndex >= 0)
			{
				Measurement selectedMeasurement = ListBoxMeasurementList.SelectedItem as Measurement;
				GridMeasurementDetail.DataContext = selectedMeasurement;
				if (selectedMeasurement.HistorianID.HasValue)
					ComboBoxHistorian.SelectedItem = new KeyValuePair<int, string>((int)selectedMeasurement.HistorianID, selectedMeasurement.HistorianAcronym);
				else
					ComboBoxHistorian.SelectedIndex = 0;
				if (selectedMeasurement.DeviceID.HasValue)
					ComboBoxDevice.SelectedItem = new KeyValuePair<int, string>((int)selectedMeasurement.DeviceID, selectedMeasurement.DeviceAcronym);
				else
					ComboBoxDevice.SelectedIndex = 0;

				if (ComboBoxPhasorSource.Items.Count > 0 && selectedMeasurement.PhasorSourceIndex.HasValue)
				{
					foreach (KeyValuePair<int, string> item in ComboBoxPhasorSource.Items)
					{
						if (item.Value == selectedMeasurement.PhasorLabel)
						{
							ComboBoxPhasorSource.SelectedItem = item;
							break;
						}
					}
				}

				ComboBoxSignalType.SelectedItem = new KeyValuePair<int, string>(selectedMeasurement.SignalTypeID, selectedMeasurement.SignalName);

				m_inEditMode = true;
				m_signalID = selectedMeasurement.SignalID;

                ButtonSave.Tag = "Update";
			}
		}
		
		void ButtonSave_Click(object sender, RoutedEventArgs e)
		{
			Storyboard sb = new Storyboard();
			sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
			sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
			Storyboard.SetTarget(sb, ButtonSaveTransform);
			sb.Begin();

            if (IsValid())
            {
                Measurement measurement = new Measurement();
                measurement.HistorianID = ((KeyValuePair<int, string>)ComboBoxHistorian.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboBoxHistorian.SelectedItem).Key;
                measurement.DeviceID = ((KeyValuePair<int, string>)ComboBoxDevice.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboBoxDevice.SelectedItem).Key;
                measurement.PointTag = TextBoxPointTag.Text.CleanText();
                measurement.AlternateTag = TextBoxAlternateTag.Text.CleanText();
                measurement.SignalTypeID = ((KeyValuePair<int, string>)ComboBoxSignalType.SelectedItem).Key;
                measurement.PhasorSourceIndex = ((KeyValuePair<int, string>)ComboBoxPhasorSource.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboBoxPhasorSource.SelectedItem).Key;
                measurement.SignalReference = TextBoxSignalReference.Text.CleanText();
                measurement.Adder = TextBoxAdder.Text.ToDouble();
                measurement.Multiplier = TextBoxMultiplier.Text.ToDouble();
                measurement.Description = TextBoxDescription.Text.CleanText();
                measurement.Enabled = (bool)CheckboxEnabled.IsChecked;

                if (m_inEditMode == true && !string.IsNullOrEmpty(m_signalID))
                {
                    measurement.SignalID = m_signalID;
                    m_client.SaveMeasurementAsync(measurement, false);
                }
                else
                    m_client.SaveMeasurementAsync(measurement, true);
            }
		}
		
		void ButtonClear_Click(object sender, RoutedEventArgs e)
		{
			Storyboard sb = new Storyboard();
			sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
			sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
			Storyboard.SetTarget(sb, ButtonClearTransform);
			sb.Begin();

			ClearForm();
		}

		void ButtonShowAll_Click(object sender, RoutedEventArgs e)
		{
			Storyboard sb = new Storyboard();
			sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
			sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
			Storyboard.SetTarget(sb, ButtonShowAllTransform);
			sb.Begin();

			BindData(m_measurementList);
		}

		void ButtonSearch_Click(object sender, RoutedEventArgs e)
		{
			Storyboard sb = new Storyboard();
			sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
			sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
			Storyboard.SetTarget(sb, ButtonSearchTransform);
			sb.Begin();

			string searchText = TextBoxSearch.Text.ToUpper();
			//ListBoxMeasurementList.ItemsSource 
			List<Measurement> searchResult = new List<Measurement>();
			searchResult = (from item in m_measurementList
												  where item.PointTag.Contains(searchText) || item.SignalReference.Contains(searchText) || item.SignalSuffix.Contains(searchText) || item.Description.ToUpper().Contains(searchText)
														|| item.DeviceAcronym.Contains(searchText) || item.SignalName.ToUpper().Contains(searchText) || item.SignalAcronym.Contains(searchText)
												  select item).ToList();
			BindData(searchResult);
		}

		#endregion

		#region [ Page Event Handlers ]

		void Measurements_Loaded(object sender, RoutedEventArgs e)
		{
            
		}
						
		// Executes when the user navigates to this page.
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			m_measurementList = new ObservableCollection<Measurement>();
			App app = (App)Application.Current;
			m_activityWindow = new ActivityWindow("Loading Data... Please Wait...");
			m_activityWindow.Show();
			m_client.GetHistoriansAsync(true, true, true);
			m_client.GetDevicesAsync(DeviceType.NonConcentrator, app.NodeValue, true);
			m_client.GetSignalTypesAsync(false);

            ClearForm();
			if (this.NavigationContext.QueryString.ContainsKey("did"))
			{
				m_deviceID = Convert.ToInt32(this.NavigationContext.QueryString["did"]);
				m_client.GetMeasurementsByDeviceAsync(m_deviceID);
				m_client.GetDeviceByDeviceIDAsync(m_deviceID);
			}
			else
			{
				m_client.GetMeasurementListAsync(app.NodeValue);
			}
		}

		#endregion

		#region [ Methods ]

        bool IsValid()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(TextBoxPointTag.Text.CleanText()))
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Point Tag", SystemMessage = "Please provide valid Point Tag value.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                                                {
                                                    TextBoxPointTag.Focus();
                                                });
                sm.ShowPopup();
                return isValid;
            }

            if (string.IsNullOrEmpty(TextBoxSignalReference.Text.CleanText()))
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Signal Reference", SystemMessage = "Please provide valid Signal Reference value.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                                                {
                                                    TextBoxSignalReference.Focus();
                                                });
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxAdder.Text.IsDouble())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Adder", SystemMessage = "Please provide valid numeric value for Adder.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                                                {
                                                    TextBoxAdder.Focus();
                                                });
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxMultiplier.Text.IsDouble())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Multiplier", SystemMessage = "Please provide valid numeric value for Multiplier.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                                                {
                                                    TextBoxMultiplier.Focus();
                                                });
                sm.ShowPopup();
                return isValid;
            }

            return isValid;
        }

		void ClearForm()
		{
            GridMeasurementDetail.DataContext = new Measurement() { Adder = 0, Multiplier = 1 };
			if (ComboBoxDevice.Items.Count > 0)
				ComboBoxDevice.SelectedIndex = 0;
			if (ComboBoxHistorian.Items.Count > 0)
				ComboBoxHistorian.SelectedIndex = 0;
			if (ComboBoxPhasorSource.Items.Count > 0)
				ComboBoxPhasorSource.SelectedIndex = 0;
			if (ComboBoxSignalType.Items.Count > 0)
				ComboBoxSignalType.SelectedIndex = 0;
			m_inEditMode = false;
			m_signalID = string.Empty;
			ListBoxMeasurementList.SelectedIndex = -1;
            ButtonSave.Tag = "Add";
		}

		void BindData(IEnumerable<Measurement> measurementList)
		{
			PagedCollectionView pagedList = new PagedCollectionView(measurementList);
			ListBoxMeasurementList.ItemsSource = pagedList;
			DataPagerMeasurements.Source = pagedList;
			ListBoxMeasurementList.SelectedIndex = -1;
            if (ListBoxMeasurementList.Items.Count > 0 && m_selectFirst)
            {
                ListBoxMeasurementList.SelectedIndex = 0;
                m_selectFirst = false;
            }
			//ClearForm();
		}

		#endregion

	}
}
