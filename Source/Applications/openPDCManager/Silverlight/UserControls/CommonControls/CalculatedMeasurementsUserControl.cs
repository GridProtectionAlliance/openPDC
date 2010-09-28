//******************************************************************************************************
//  CalculatedMeasurementsUserControl.cs - Gbtc
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
    public partial class CalculatedMeasurementsUserControl
    {
        #region [ Members ]

        PhasorDataServiceClient m_client;
        bool m_selectFirst = true;

        #endregion

        #region [ Methods ]

        void Initialize()
        {
            m_client = ProxyClient.GetPhasorDataServiceProxyClient();
            m_client.GetCalculatedMeasurementListCompleted += new EventHandler<GetCalculatedMeasurementListCompletedEventArgs>(client_GetCalculatedMeasurementListCompleted);
            m_client.GetNodesCompleted += new EventHandler<GetNodesCompletedEventArgs>(client_GetNodesCompleted);
            m_client.SaveCalculatedMeasurementCompleted += new EventHandler<SaveCalculatedMeasurementCompletedEventArgs>(client_SaveCalculatedMeasurementCompleted);
            m_client.GetRuntimeIDCompleted += new EventHandler<GetRuntimeIDCompletedEventArgs>(m_client_GetRuntimeIDCompleted);
        }

        void SendInitialize()
        {

        }

        void GetCalculatedMeasurements()
        {
            m_client.GetCalculatedMeasurementListAsync(m_nodeID);            
        }

        void GetNodes()
        {
            m_client.GetNodesAsync(true, false);
        }

        void SaveCalculatedMeasurement(CalculatedMeasurement calculatedMeasurement, bool isNew)
        {
            m_client.SaveCalculatedMeasurementAsync(calculatedMeasurement, isNew);
        }

        void DisplayRuntimeID()
        {
            m_client.GetRuntimeIDAsync("CalculatedMeasurement", m_calculatedMeasurementID);
        }

        #endregion

        #region [ Service Event Handlers ]

        void client_SaveCalculatedMeasurementCompleted(object sender, SaveCalculatedMeasurementCompletedEventArgs e)
        {
            SystemMessages sm;
            if (e.Error == null)
            {
                ClearForm();
                GetCalculatedMeasurements();
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Calculated Measurement Information", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
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

        void client_GetCalculatedMeasurementListCompleted(object sender, GetCalculatedMeasurementListCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                ListBoxCalculatedMeasurementList.ItemsSource = e.Result;
                if (ListBoxCalculatedMeasurementList.Items.Count > 0 && m_selectFirst)
                {
                    ListBoxCalculatedMeasurementList.SelectedIndex = 0;
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Calculated Measurement List", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
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
