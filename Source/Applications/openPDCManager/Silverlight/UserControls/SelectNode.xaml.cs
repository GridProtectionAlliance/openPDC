//******************************************************************************************************
//  SelectNode.xaml.cs - Gbtc
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
//  12/09/2009 - Mehulbhi P. Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using openPDCManager.ModalDialogs;
using openPDCManager.PhasorDataServiceProxy;
using openPDCManager.Utilities;

namespace openPDCManager.UserControls
{
	public partial class SelectNode : UserControl
	{
		#region [ Members ]

		PhasorDataServiceClient m_client = new PhasorDataServiceClient();
		public delegate void OnNodesChanged(object sender, RoutedEventArgs e);
		public event OnNodesChanged NodeCollectionChanged;
		bool m_raiseNodesCollectionChanged = false;

		#endregion

		#region [ Constructor ]

		public SelectNode()
		{
			InitializeComponent();
			m_client = ProxyClient.GetPhasorDataServiceProxyClient();
			//m_client.GetNodesCompleted += new EventHandler<GetNodesCompletedEventArgs>(client_GetNodesCompleted);
			m_client.GetNodeListCompleted += new EventHandler<GetNodeListCompletedEventArgs>(m_client_GetNodeListCompleted);
			ComboboxNode.SelectionChanged += new SelectionChangedEventHandler(ComboboxNode_SelectionChanged);
			Loaded += new RoutedEventHandler(SelectNode_Loaded);
		}

		#endregion

		#region [ Service Event Handlers ]

		void m_client_GetNodeListCompleted(object sender, GetNodeListCompletedEventArgs e)
		{
			if (e.Error == null)
			{
				ComboboxNode.ItemsSource = e.Result;
				App app = (App)Application.Current;
				if (ComboboxNode.Items.Count > 0)
				{
					if (!string.IsNullOrEmpty(app.NodeValue))
					{
						foreach (Node item in ComboboxNode.Items)
						{
							if (item.ID == app.NodeValue)
							{
								ComboboxNode.SelectedItem = item;
								break;
							}

						}
					}
					else
						ComboboxNode.SelectedIndex = 0;

					Node node = (Node)ComboboxNode.SelectedItem;
					app.NodeValue = node.ID;
					app.NodeName = node.Name;
					app.TimeSeriesDataServiceUrl = node.TimeSeriesDataServiceUrl;
					app.RemoteStatusServiceUrl = node.RemoteStatusServiceUrl;
                    app.RealTimeStatisticServiceUrl = node.RealTimeStatisticServiceUrl;
				}
				else
					app.NodeValue = string.Empty;
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
					sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Nodes", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
						ButtonType.OkOnly);

				sm.ShowPopup();
			}
			m_raiseNodesCollectionChanged = false;
		}

		#endregion

		#region [ Page Event Handlers ]

		void SelectNode_Loaded(object sender, RoutedEventArgs e)
		{
			//m_client.GetNodesAsync(true, false);
			m_client.GetNodeListAsync(true);
		}

		#endregion

		#region [ Control Event Handlers ]

		void ComboboxNode_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (!m_raiseNodesCollectionChanged)
			{
				App app = (App)Application.Current;
				Node node = (Node)ComboboxNode.SelectedItem;
				app.NodeValue = node.ID;
				app.NodeName = node.Name;
				app.TimeSeriesDataServiceUrl = node.TimeSeriesDataServiceUrl;
				app.RemoteStatusServiceUrl = node.RemoteStatusServiceUrl;
                app.RealTimeStatisticServiceUrl = node.RealTimeStatisticServiceUrl;
				//app.NodeValue = ((KeyValuePair<string, string>)ComboboxNode.SelectedItem).Key;
				//app.NodeName = ((KeyValuePair<string, string>)(ComboboxNode.SelectedItem)).Value;
			}
		}

		#endregion

		#region [ Methods ]

		public void RefreshNodeList()
		{				
			//m_client.GetNodesAsync(true, false);	
			m_client.GetNodeListAsync(true);
		}

		public void RaiseNotification()
		{
			m_raiseNodesCollectionChanged = true;
			if (NodeCollectionChanged != null && m_raiseNodesCollectionChanged)
				NodeCollectionChanged(this, null);

		}

		#endregion

	}
}
