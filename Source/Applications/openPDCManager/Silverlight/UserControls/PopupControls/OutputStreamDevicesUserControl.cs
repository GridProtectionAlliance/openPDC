//******************************************************************************************************
//  OutputStreamDevicesUserControl.cs - Gbtc
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
//  07/29/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using openPDCManager.ModalDialogs;
using openPDCManager.PhasorDataServiceProxy;
using openPDCManager.Utilities;

namespace openPDCManager.UserControls.PopupControls
{
    public partial class OutputStreamDevicesUserControl
    {
        #region [ Members ]

        PhasorDataServiceClient m_client;
        bool m_selectFirst = true;

        #endregion

        #region [ Methods ]

        void Initialize()
        {
            m_client = ProxyClient.GetPhasorDataServiceProxyClient();
            m_client.GetOutputStreamDeviceListCompleted += new EventHandler<GetOutputStreamDeviceListCompletedEventArgs>(client_GetOutputStreamDeviceListCompleted);
            m_client.SaveOutputStreamDeviceCompleted += new EventHandler<SaveOutputStreamDeviceCompletedEventArgs>(client_SaveOutputStreamDeviceCompleted);
            m_client.DeleteOutputStreamDeviceCompleted += new EventHandler<DeleteOutputStreamDeviceCompletedEventArgs>(client_DeleteOutputStreamDeviceCompleted);
        }

        void GetOutputStreamDeviceList()
        {
            m_client.GetOutputStreamDeviceListAsync(m_sourceOutputStreamID, false);
        }

        void SaveOutputStreamDevice(OutputStreamDevice outputStreamDevice, bool isNew, string originalAcronym)
        {
            m_client.SaveOutputStreamDeviceAsync(outputStreamDevice, isNew, originalAcronym);
        }

        void DeleteOutputStreamDevice(int outputStreamID, ObservableCollection<string> devicesToBeDeleted)
        {
            m_client.DeleteOutputStreamDeviceAsync(outputStreamID, devicesToBeDeleted);
        }

        #endregion

        #region [ Service Event Handlers ]

        void client_DeleteOutputStreamDeviceCompleted(object sender, DeleteOutputStreamDeviceCompletedEventArgs e)
        {
            SystemMessages sm;
            if (e.Error == null)
            {
                GetOutputStreamDeviceList();
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Delete Output Stream Device", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
            }
            sm.ShowPopup();            
        }

        void client_SaveOutputStreamDeviceCompleted(object sender, SaveOutputStreamDeviceCompletedEventArgs e)
        {
            SystemMessages sm;
            if (e.Error == null)
            {
                GetOutputStreamDeviceList();
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Output Stream Device Information", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
            }
            sm.ShowPopup();            
        }

        void client_GetOutputStreamDeviceListCompleted(object sender, GetOutputStreamDeviceListCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                ListBoxOutputStreamDeviceList.ItemsSource = e.Result;
                if (ListBoxOutputStreamDeviceList.Items.Count > 0 && m_selectFirst)
                {
                    ListBoxOutputStreamDeviceList.SelectedIndex = 0;
                    m_selectFirst = false;
                }

                if (ListBoxOutputStreamDeviceList.Items.Count == 0)
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Output Stream Device List", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
        }

        #endregion
    }
}
