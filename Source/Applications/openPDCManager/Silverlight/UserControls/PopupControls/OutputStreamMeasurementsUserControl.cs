//******************************************************************************************************
//  OutputStreamMeasurementsUserControl.cs - Gbtc
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
//  07/30/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.ServiceModel;
using openPDCManager.ModalDialogs;
using openPDCManager.PhasorDataServiceProxy;
using openPDCManager.Utilities;

namespace openPDCManager.UserControls.PopupControls
{
    public partial class OutputStreamMeasurementsUserControl
    {
        #region [ Members ]

        PhasorDataServiceClient m_client;
        bool m_selectFirst = true;

        #endregion

        #region [ Methods ]

        void Initialize()
        {
            m_client = ProxyClient.GetPhasorDataServiceProxyClient();
            m_client.GetOutputStreamMeasurementListCompleted += new EventHandler<GetOutputStreamMeasurementListCompletedEventArgs>(client_GetOutputStreamMeasurementListCompleted);
            m_client.SaveOutputStreamMeasurementCompleted += new EventHandler<SaveOutputStreamMeasurementCompletedEventArgs>(client_SaveOutputStreamMeasurementCompleted);
            m_client.DeleteOutputStreamMeasurementCompleted += new EventHandler<DeleteOutputStreamMeasurementCompletedEventArgs>(client_DeleteOutputStreamMeasurementCompleted);
        }

        void GetOutputStreamMeasurementList()
        {
            m_client.GetOutputStreamMeasurementListAsync(m_sourceOutputStreamID);            
        }

        void SaveOutputStreamMeasurement()
        {
            m_client.SaveOutputStreamMeasurementAsync(m_selectedOutputStreamMeasurement, false);
        }

        void DeleteOutputStreamMeasurement(int outputStreamMeasurementId)
        {
            m_client.DeleteOutputStreamMeasurementAsync(outputStreamMeasurementId);
        }

        #endregion

        #region [ Service Event Handlers ]

        void client_DeleteOutputStreamMeasurementCompleted(object sender, DeleteOutputStreamMeasurementCompletedEventArgs e)
        {
            SystemMessages sm;
            if (e.Error == null)
            {
                m_client.GetOutputStreamMeasurementListAsync(m_sourceOutputStreamID);
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Delete Output Stream Measurement", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
            }
            sm.ShowPopup();            
        }

        void client_SaveOutputStreamMeasurementCompleted(object sender, SaveOutputStreamMeasurementCompletedEventArgs e)
        {
            SystemMessages sm;
            if (e.Error == null)
            {
                m_client.GetOutputStreamMeasurementListAsync(m_sourceOutputStreamID);
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Output Stream Measurement Information", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
            }
            sm.ShowPopup();            
        }

        void client_GetOutputStreamMeasurementListCompleted(object sender, GetOutputStreamMeasurementListCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                ListBoxOutputStreamMeasurementList.ItemsSource = e.Result;
                if (ListBoxOutputStreamMeasurementList.Items.Count > 0 && m_selectFirst)
                {
                    ListBoxOutputStreamMeasurementList.SelectedIndex = 0;
                    m_selectFirst = false;
                }

                if (ListBoxOutputStreamMeasurementList.Items.Count == 0)
                    ClearForm();
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Output Stream Measurement List", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
        }

        #endregion
    }
}
