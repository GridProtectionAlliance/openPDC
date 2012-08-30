//******************************************************************************************************
//  PhasorsUserControl.cs - Gbtc
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
//  07/16/2010 - Mehulbhai P Thakkar
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
    public partial class PhasorsUserControl
    {
        #region [ Members ]
        
        PhasorDataServiceClient m_client;
        bool m_selectFirst = true;

        #endregion

        #region [ Methods ]

        void Initialize()
        {
            m_client = ProxyClient.GetPhasorDataServiceProxyClient();
            m_client.GetPhasorListCompleted += new EventHandler<GetPhasorListCompletedEventArgs>(client_GetPhasorListCompleted);
            m_client.GetPhasorsCompleted += new EventHandler<GetPhasorsCompletedEventArgs>(client_GetPhasorsCompleted);
            m_client.SavePhasorCompleted += new EventHandler<SavePhasorCompletedEventArgs>(client_SavePhasorCompleted);
        }

        void SavePhasor(Phasor phasor, bool isNew)
        {
            m_client.SavePhasorAsync(phasor, isNew);
        }

        void GetPhasors()
        {            
            m_client.GetPhasorsAsync(m_sourceDeviceID, true);
        }

        void GetPhasorList()
        {
            m_client.GetPhasorListAsync(m_sourceDeviceID);
        }

        #endregion

        #region [ Service Event Handlers ]

        void client_SavePhasorCompleted(object sender, SavePhasorCompletedEventArgs e)
        {
            SystemMessages sm;
            if (e.Error == null)
            {
                GetPhasorList();
                GetPhasors();
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Phasor Information", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
            }
            sm.ShowPopup();
        }

        void client_GetPhasorsCompleted(object sender, GetPhasorsCompletedEventArgs e)
        {
            if (e.Error == null)
                ComboboxDestinationPhasor.ItemsSource = e.Result;
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
            if (ComboboxDestinationPhasor.Items.Count > 0)
                ComboboxDestinationPhasor.SelectedIndex = 0;
        }

        void client_GetPhasorListCompleted(object sender, GetPhasorListCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                ListBoxPhasorList.ItemsSource = e.Result;
                if (ListBoxPhasorList.Items.Count > 0 && m_selectFirst)
                {
                    ListBoxPhasorList.SelectedIndex = 0;
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Phasor List", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.ShowPopup();
            }
        }

        #endregion
    }
}
