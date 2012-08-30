//******************************************************************************************************
//  AdapterUserControl.xaml.cs - Gbtc
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
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using openPDCManager.ModalDialogs;
using openPDCManager.PhasorDataServiceProxy;
using openPDCManager.Utilities;

namespace openPDCManager.UserControls
{
	public partial class AdapterUserControl : UserControl
	{
		#region [ Members ]

		PhasorDataServiceClient m_client;
		bool m_inEditMode = false;
		int m_adapterID = 0;
		AdapterType m_adapterType;
		string m_nodeID;

		#endregion

		#region [ Constructor ]

		public AdapterUserControl()
		{
			InitializeComponent();
			m_client = ProxyClient.GetPhasorDataServiceProxyClient();
			m_client.GetAdapterListCompleted += new EventHandler<GetAdapterListCompletedEventArgs>(client_GetAdapterListCompleted);
			m_client.SaveAdapterCompleted += new EventHandler<SaveAdapterCompletedEventArgs>(client_SaveAdapterCompleted);
			m_client.GetNodesCompleted += new EventHandler<GetNodesCompletedEventArgs>(client_GetNodesCompleted);
			Loaded += new RoutedEventHandler(AdaptersUserControl_Loaded);
			ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
			ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
			ListBoxAdapterList.SelectionChanged += new SelectionChangedEventHandler(ListBoxAdapterList_SelectionChanged);
		}

		#endregion

		#region [ Service Event Handlers ]

		void client_GetNodesCompleted(object sender, GetNodesCompletedEventArgs e)
		{
			if (e.Error == null)
				ComboboxNode.ItemsSource = e.Result;
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
			if (ComboboxNode.Items.Count > 0)
				ComboboxNode.SelectedIndex = 0;
		}
		
		void client_SaveAdapterCompleted(object sender, SaveAdapterCompletedEventArgs e)
		{
			SystemMessages sm;
			if (e.Error == null)
			{
				ClearForm();
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
					sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Adapter Information", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
						ButtonType.OkOnly);
			}
			sm.ShowPopup();
			m_client.GetAdapterListAsync(false, m_adapterType, m_nodeID);
		}

		void client_GetAdapterListCompleted(object sender, GetAdapterListCompletedEventArgs e)
		{
			if (e.Error == null)
				ListBoxAdapterList.ItemsSource = e.Result;
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
					sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Adapter List", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
						ButtonType.OkOnly);

				sm.ShowPopup();
			}
		}

		#endregion

		#region [ Control Event Handlers ]

		void ListBoxAdapterList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (ListBoxAdapterList.SelectedIndex >= 0)
			{
				Adapter selectedAdapter = ListBoxAdapterList.SelectedItem as Adapter;
				GridAdapterDetail.DataContext = selectedAdapter;
				ComboboxNode.SelectedItem = new KeyValuePair<string, string>(selectedAdapter.NodeID, selectedAdapter.NodeName);
				m_inEditMode = true;
				m_adapterID = selectedAdapter.ID;
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

        void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sb = new Storyboard();
            sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            Storyboard.SetTarget(sb, ButtonSaveTransform);
            sb.Begin();

            if (IsValid())
            {
                Adapter adapter = new Adapter();
                adapter.adapterType = m_adapterType;
                adapter.NodeID = ((KeyValuePair<string, string>)ComboboxNode.SelectedItem).Key;
                adapter.AdapterName = TextBoxAdapterName.Text.CleanText();
                adapter.AssemblyName = TextBoxAssemblyName.Text.CleanText();
                adapter.TypeName = TextBoxTypeName.Text.CleanText();
                adapter.ConnectionString = TextBoxConnectionString.Text.CleanText();
                adapter.LoadOrder = TextBoxLoadOrder.Text.ToInteger();
                adapter.Enabled = (bool)CheckboxEnabled.IsChecked;

                if (m_inEditMode == true && m_adapterID > 0)
                {
                    adapter.ID = m_adapterID;
                    m_client.SaveAdapterAsync(adapter, false);
                }
                else
                    m_client.SaveAdapterAsync(adapter, true);
            }
        }

		#endregion

		#region [ Page Event Handlers ]

		void AdaptersUserControl_Loaded(object sender, RoutedEventArgs e)
		{
			App app = (App)Application.Current;
			m_nodeID = app.NodeValue;
			m_client.GetNodesAsync(true, false);
			m_client.GetAdapterListAsync(false, m_adapterType, m_nodeID);
            ClearForm();
		}

		#endregion

		#region [ Methods ]

        bool IsValid()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(TextBoxAdapterName.Text.CleanText()))
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Adapter Name", SystemMessage = "Please provide valid Adapter Name.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                                                {
                                                    TextBoxAdapterName.Focus();
                                                });
                sm.ShowPopup();
                return isValid;
            }

            if (string.IsNullOrEmpty(TextBoxAssemblyName.Text.CleanText()))
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Assembly Name", SystemMessage = "Please provide valid Assembly Name.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                                                {
                                                    TextBoxAssemblyName.Focus();
                                                });
                sm.ShowPopup();
                return isValid;
            }

            if (string.IsNullOrEmpty(TextBoxTypeName.Text.CleanText()))
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Type Name", SystemMessage = "Please provide valid Type Name.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                                                {
                                                    TextBoxTypeName.Focus();
                                                });
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxLoadOrder.Text.IsInteger())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Load Order", SystemMessage = "Please provide valid integer value for Load Order.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                                                {
                                                    TextBoxLoadOrder.Focus();
                                                });
                sm.ShowPopup();
                return isValid;
            }

            return isValid;
        }

		void ClearForm()
		{
			GridAdapterDetail.DataContext = new Adapter();
			if (ComboboxNode.Items.Count > 0)
				ComboboxNode.SelectedIndex = 0;
			m_inEditMode = false;
			m_adapterID = 0;
			ListBoxAdapterList.SelectedIndex = -1;
		}
		
		public void SetAdapterType(AdapterType adpType)
		{
			m_adapterType = adpType;
		}

		#endregion

	}
}
