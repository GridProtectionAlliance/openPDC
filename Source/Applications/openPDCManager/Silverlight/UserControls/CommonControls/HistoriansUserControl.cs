//******************************************************************************************************
//  HistoriansUserControl.cs - Gbtc
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
//  07/09/2010 - Mehulbhai P Thakkar
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
    public partial class HistoriansUserControl
    {
        #region [ Members ]

        PhasorDataServiceClient m_client;
        bool m_selectFirst = true;

        #endregion

        #region [ Methods ]

        void Initialize()
        {
            m_client = ProxyClient.GetPhasorDataServiceProxyClient();
            m_client.GetHistorianListCompleted += new EventHandler<GetHistorianListCompletedEventArgs>(client_GetHistorianListCompleted);
            m_client.GetNodesCompleted += new EventHandler<GetNodesCompletedEventArgs>(client_GetNodesCompleted);
            m_client.SaveHistorianCompleted += new EventHandler<SaveHistorianCompletedEventArgs>(client_SaveHistorianCompleted);
            m_client.GetRuntimeIDCompleted += new EventHandler<GetRuntimeIDCompletedEventArgs>(m_client_GetRuntimeIDCompleted);
        }       

        void SendInitialize()
        {

        }

        void GetHistorians()
        {
            m_client.GetHistorianListAsync(m_nodeID);
        }

        void GetNodes()
        {            
            m_client.GetNodesAsync(true, false);
        }

        void SaveHistorian(Historian historian, bool isNew)
        {
            bool continueSave = true;

            if (!isNew && (historian.TypeName != "HistorianAdapters.LocalOutputAdapter" || !historian.IsLocal))
            {
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "You are changing your historian type.", SystemMessage = "You are changing your historian type from an in-process local historian to another historian provider. Please note that once the changes are applied, any customizations you may have made to the in-process local historian in the openPDC configuration file will be lost." + Environment.NewLine + "Do you want to continue?", UserMessageType = MessageType.Confirmation }, ButtonType.YesNo);
                sm.Closed += new EventHandler(delegate(object popupWindow, EventArgs eargs)
                {
                    if ((bool)sm.DialogResult)
                        continueSave = true;
                    else
                        continueSave = false;
                });            
                sm.ShowPopup();
            }

            if (continueSave)
                m_client.SaveHistorianAsync(historian, isNew);
        }

        void DisplayRuntimeID()
        {
            m_client.GetRuntimeIDAsync("Historian", m_historianID);
        }

        #endregion

        #region [ Service Event Handlers ]

        void m_client_GetRuntimeIDCompleted(object sender, GetRuntimeIDCompletedEventArgs e)
        {
            if (e.Error == null)
                TextBlockRuntimeID.Text = e.Result;

        }

        void client_SaveHistorianCompleted(object sender, SaveHistorianCompletedEventArgs e)
        {
            SystemMessages sm;
            if (e.Error == null)
            {
                GetHistorians();
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Historian Information", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
            }
            sm.ShowPopup();
        }

        void client_GetNodesCompleted(object sender, GetNodesCompletedEventArgs e)
        {
            if (e.Error == null)
                ComboBoxNode.ItemsSource = e.Result;
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
            if (ComboBoxNode.Items.Count > 0)
                ComboBoxNode.SelectedIndex = 0;
        }

        void client_GetHistorianListCompleted(object sender, GetHistorianListCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                ListBoxHistorianList.ItemsSource = e.Result;
                if (ListBoxHistorianList.Items.Count > 0 && m_selectFirst)
                {
                    ListBoxHistorianList.SelectedIndex = 0;
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Historians", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
        }

        #endregion

    }
}
