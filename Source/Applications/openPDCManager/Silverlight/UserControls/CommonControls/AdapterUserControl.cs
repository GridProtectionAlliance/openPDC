//******************************************************************************************************
//  AdapterUserControl.cs - Gbtc
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
//  07/08/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.ServiceModel;
using openPDCManager.ModalDialogs;
using openPDCManager.PhasorDataServiceProxy;
using openPDCManager.Utilities;

namespace openPDCManager.UserControls.CommonControls
{
    public partial class AdapterUserControl
    {
        #region [ Members ]

        PhasorDataServiceClient m_client;
        bool m_selectFirst = true;

        #endregion

        #region [ Methods ]

        void Initialize()
        {
            m_client = ProxyClient.GetPhasorDataServiceProxyClient();
            m_client.GetAdapterListCompleted += new EventHandler<GetAdapterListCompletedEventArgs>(client_GetAdapterListCompleted);
            m_client.SaveAdapterCompleted += new EventHandler<SaveAdapterCompletedEventArgs>(client_SaveAdapterCompleted);
            m_client.GetNodesCompleted += new EventHandler<GetNodesCompletedEventArgs>(client_GetNodesCompleted);
            m_client.GetRuntimeIDCompleted += new EventHandler<GetRuntimeIDCompletedEventArgs>(m_client_GetRuntimeIDCompleted);
        }

        void SendInitialize()
        {

        }

        void DisplayRuntimeID()
        {
            if (m_adapterType == AdapterType.Action)
                m_client.GetRuntimeIDAsync("CustomActionAdapter", m_adapterID);
            else if (m_adapterType == AdapterType.Input)
                m_client.GetRuntimeIDAsync("CustomInputAdapter", m_adapterID);
            else if (m_adapterType == AdapterType.Output)
                m_client.GetRuntimeIDAsync("CustomOutputAdapter", m_adapterID);
        }

        void GetNodes()
        {
            m_client.GetNodesAsync(true, false);
        }

        void GetAdapterList()
        {
            m_client.GetAdapterListAsync(false, m_adapterType, m_nodeID);
        }

        void SaveAdapter(Adapter adapter, bool isNew)
        {
            m_client.SaveAdapterAsync(adapter, isNew);
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
                GetAdapterList();                
                sm = new SystemMessages(new Message() { UserMessage = e.Result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
                ClearForm();
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
        }

        void client_GetAdapterListCompleted(object sender, GetAdapterListCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                ListBoxAdapterList.ItemsSource = e.Result;
                if (ListBoxAdapterList.Items.Count > 0 && m_selectFirst)
                {
                    ListBoxAdapterList.SelectedIndex = 0;
                    m_selectFirst = false;
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Adapter List", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
        }

        void m_client_GetRuntimeIDCompleted(object sender, GetRuntimeIDCompletedEventArgs e)
        {
            if (e.Error == null)
                TextBlockRuntimeID.Text = e.Result;
        }

        #endregion
    }
}
