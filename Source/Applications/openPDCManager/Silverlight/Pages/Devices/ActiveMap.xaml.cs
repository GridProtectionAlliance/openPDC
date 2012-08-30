//******************************************************************************************************
//  ActiveMap.xaml.cs - Gbtc
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
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Maps.MapControl;
using openPDCManager.ModalDialogs;
using openPDCManager.PhasorDataServiceProxy;
using openPDCManager.Utilities;

namespace openPDCManager.Pages.Devices
{
	public partial class ActiveMap : Page
	{
		#region [ Members ]

		PhasorDataServiceClient m_client;
		Button m_pushPinButton;		
		ToolTip m_toolTip;		
		ObservableCollection<MapData> m_mapDataList;

		#endregion

		#region [ Constructor ]

		public ActiveMap()
		{
			InitializeComponent();
			m_client = ProxyClient.GetPhasorDataServiceProxyClient();
			VirtualEarthActiveMap.CredentialsProvider = (Application.Current as App).Credentials;
			Loaded += new RoutedEventHandler(ActiveMap_Loaded);
			m_client.GetMapDataCompleted += new EventHandler<GetMapDataCompletedEventArgs>(client_GetMapDataCompleted);
		}

		#endregion

		#region [ Service Event Handlers ]

		void client_GetMapDataCompleted(object sender, GetMapDataCompletedEventArgs e)
		{
			if (e.Error == null)
			{
				m_mapDataList = new ObservableCollection<MapData>();
				m_mapDataList = e.Result;
				double avgLongitude = Convert.ToDouble(m_mapDataList.Average(m => m.Longitude));
				double avgLatitude = Convert.ToDouble(m_mapDataList.Average(m => m.Latitude));
				foreach (MapData mapData in m_mapDataList)
				{
					m_pushPinButton = new Button();
					m_toolTip = new ToolTip();
					m_toolTip.DataContext = mapData;
					m_toolTip.Template = Application.Current.Resources["MapToolTipTemplate"] as ControlTemplate;
					ToolTipService.SetToolTip(m_pushPinButton, m_toolTip);
					m_pushPinButton.Content = mapData.CompanyMapAcronym;
					if (mapData.Reporting)
						m_pushPinButton.Template = Application.Current.Resources["GreenPushPinButtonTemplate"] as ControlTemplate;
					else
						m_pushPinButton.Template = Application.Current.Resources["RedPushPinButtonTemplate"] as ControlTemplate;
					//pushPinButton.SetValue(MapLayer.MapPositionProperty, new Location(Convert.ToDouble(mapData.Latitude), Convert.ToDouble(mapData.Longitude)));
					//pushPinButton.SetValue(MapLayer.MapPositionMethodProperty, PositionMethod.Center);
					(VirtualEarthActiveMap.FindName("PushpinLayer") as MapLayer).AddChild(m_pushPinButton, new Location(Convert.ToDouble(mapData.Latitude), Convert.ToDouble(mapData.Longitude)));
				}
				VirtualEarthActiveMap.Center = new Location(avgLatitude, avgLongitude);
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
					sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Map Data", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
						ButtonType.OkOnly);

				sm.ShowPopup();
			}
		}

		#endregion

		#region [ Page Event Handlers ]

		void ActiveMap_Loaded(object sender, RoutedEventArgs e)
		{
			
		}
		
		// Executes when the user navigates to this page.
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			App app = (App)Application.Current;
			m_client.GetMapDataAsync(MapType.Active, app.NodeValue);
		}

		#endregion

	}
}
