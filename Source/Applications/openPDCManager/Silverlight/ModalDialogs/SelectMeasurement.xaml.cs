//******************************************************************************************************
//  SelectMeasurement.xaml.cs - Gbtc
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
//  10/30/2009 - Mehulbhai P Thakkar
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
using openPDCManager.PhasorDataServiceProxy;
using openPDCManager.Utilities;

namespace openPDCManager.ModalDialogs
{
	public partial class SelectMeasurement : ChildWindow
	{
		#region [ Members ]

		int m_sourceOutputStreamID;
		string m_sourceOutputStreamAcronym;
		PhasorDataServiceClient m_client;
		ObservableCollection<Measurement> m_measurementList;		
		//List<string[]> m_measurementsToBeAdded;
		Dictionary<string, string[]> m_measurementsToBeAdded;
		ActivityWindow m_activityWindow;

		#endregion

		#region [ Constructor ]

		public SelectMeasurement(int outputStreamID, string outputStreamAcronym)
		{
			InitializeComponent();
			m_sourceOutputStreamID = outputStreamID;
			m_sourceOutputStreamAcronym = outputStreamAcronym;
			this.Title = "Add Measurements For Output Stream: " + m_sourceOutputStreamAcronym;
			Loaded += new RoutedEventHandler(SelectMeasurement_Loaded);
			ButtonAdd.Click += new RoutedEventHandler(ButtonAdd_Click);
			ButtonSearch.Click += new RoutedEventHandler(ButtonSearch_Click);
			ButtonShowAll.Click += new RoutedEventHandler(ButtonShowAll_Click);
			m_client = ProxyClient.GetPhasorDataServiceProxyClient();
			m_client.GetMeasurementsForOutputStreamCompleted += new EventHandler<GetMeasurementsForOutputStreamCompletedEventArgs>(client_GetMeasurementsForOutputStreamCompleted);
		}

		#endregion

		#region [ Service Event Handlers ]

		void client_GetMeasurementsForOutputStreamCompleted(object sender, GetMeasurementsForOutputStreamCompletedEventArgs e)
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
					sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Measurements For Output Stream", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
						ButtonType.OkOnly);
				sm.ShowPopup();
			}
			if (m_activityWindow != null)
				m_activityWindow.Close();
		}

		#endregion

		#region [ Controls Event Handlers ]

		void ButtonShowAll_Click(object sender, RoutedEventArgs e)
		{
			BindData(m_measurementList);
		}
		
		void ButtonSearch_Click(object sender, RoutedEventArgs e)
		{
			string searchText = TextBoxSearch.Text.ToUpper();

			List<Measurement> searchResult = new List<Measurement>();
			searchResult = (from item in m_measurementList
												  where item.PointTag.ToUpper().Contains(searchText) || item.SignalReference.ToUpper().Contains(searchText)
												  select item).ToList();
			BindData(searchResult);
		}
		
		void ButtonAdd_Click(object sender, RoutedEventArgs e)
		{
			if (m_measurementsToBeAdded.Count > 0)
			{
				App app = (App)Application.Current;
				//string[] format is {Name=PointID, Tooltip=SignalReference, Tag=HistorianID}
				foreach (KeyValuePair<string, string[]> measurement in m_measurementsToBeAdded)
				{
					OutputStreamMeasurement outputStreamMeasurement = new OutputStreamMeasurement();
					outputStreamMeasurement.NodeID = app.NodeValue;
					outputStreamMeasurement.AdapterID = m_sourceOutputStreamID;
					outputStreamMeasurement.HistorianID = string.IsNullOrEmpty(measurement.Value[2]) ? (int?)null : Convert.ToInt32(measurement.Value[2]);
					outputStreamMeasurement.PointID = Convert.ToInt32(measurement.Value[0]);
					outputStreamMeasurement.SignalReference = measurement.Value[1].Replace(measurement.Value[1].Substring(0, measurement.Value[1].LastIndexOf("-")), "<UNASSIGNED>");
					m_client.SaveOutputStreamMeasurementAsync(outputStreamMeasurement, true);
				}
				SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Output Stream Measurements Added Successfully", SystemMessage = string.Empty, UserMessageType = MessageType.Success },
						 ButtonType.OkOnly);
				sm.ShowPopup();
				m_client.GetMeasurementsForOutputStreamAsync(app.NodeValue, m_sourceOutputStreamID);
			}
			else
			{
				SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Please Select Measurement(s) to Add", SystemMessage = string.Empty, UserMessageType = MessageType.Information },
						 ButtonType.OkOnly);
				sm.ShowPopup();
			}				
		}
		
		void CheckBox_Checked(object sender, RoutedEventArgs e)
		{
			CheckBox checkedBox = (CheckBox)sender;
			ToolTip tooltip = new ToolTip();
			tooltip = ToolTipService.GetToolTip(checkedBox) as ToolTip;
			//string[] format is {Name=PointID, Tooltip=SignalReference, Tag=HistorianID}
			//m_measurementsToBeAdded.Add(new string[] { checkedBox.Name, ToolTipService.GetToolTip(checkedBox).ToString(), checkedBox.Tag == null ? string.Empty : checkedBox.Tag.ToString() });			
			if (!m_measurementsToBeAdded.ContainsKey(checkedBox.Name))
				m_measurementsToBeAdded.Add(checkedBox.Name, new string[] { checkedBox.Name, ToolTipService.GetToolTip(checkedBox).ToString(), checkedBox.Tag == null ? string.Empty : checkedBox.Tag.ToString() });
		}
		
		void CheckBox_Unchecked(object sender, RoutedEventArgs e)
		{
			CheckBox checkedBox = (CheckBox)sender;
			ToolTip tooltip = new ToolTip();
			tooltip = ToolTipService.GetToolTip(checkedBox) as ToolTip;
			//string[] format is {Name=PointID, Tooltip=SignalReference, Tag=HistorianID}
			//m_measurementsToBeAdded.Remove(new string[] { checkedBox.Name, ToolTipService.GetToolTip(checkedBox).ToString(), checkedBox.Tag == null ? string.Empty : checkedBox.Tag.ToString() });
			if (m_measurementsToBeAdded.ContainsKey(checkedBox.Name))
				m_measurementsToBeAdded.Remove(checkedBox.Name);
		}

		#endregion

		#region [ Page Event Handlers ]

		void SelectMeasurement_Loaded(object sender, RoutedEventArgs e)
		{
			m_activityWindow = new ActivityWindow("Loading Data... Please Wait...");
			m_activityWindow.Show();
			m_measurementList = new ObservableCollection<Measurement>();
			m_measurementsToBeAdded = new Dictionary<string, string[]>();
			App app = (App)Application.Current;
			m_client.GetMeasurementsForOutputStreamAsync(app.NodeValue, m_sourceOutputStreamID);
		}

		#endregion

		#region [ Methods ]

		void BindData(IEnumerable<Measurement> measurementList)
		{
			PagedCollectionView pagedList = new PagedCollectionView(measurementList);
			ListBoxMeasurementList.ItemsSource = pagedList;
			DataPagerMeasurements.Source = pagedList;
			ListBoxMeasurementList.SelectedIndex = -1;
		}

		#endregion
	}
}

