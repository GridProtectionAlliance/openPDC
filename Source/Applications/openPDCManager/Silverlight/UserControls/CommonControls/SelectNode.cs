//******************************************************************************************************
//  SelectNode.cs - Gbtc
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
using System.Windows;
using openPDCManager.ModalDialogs;
using openPDCManager.PhasorDataServiceProxy;
using openPDCManager.Utilities;

namespace openPDCManager.UserControls.CommonControls
{
    public partial class SelectNode
    {
        #region [ Members ]

        PhasorDataServiceClient m_client = new PhasorDataServiceClient();
        
        #endregion

        #region [ Service Event Handlers ]

        void m_client_GetNodeListCompleted(object sender, GetNodeListCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                ComboboxNode.ItemsSource = e.Result;
                SetGlobalVariables();
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
            m_client.GetNodeListAsync(true);
        }

        #endregion

        #region [ Methods ]

        public void Initialize()
        {
            m_client = ProxyClient.GetPhasorDataServiceProxyClient();
            m_client.GetNodeListCompleted += new EventHandler<GetNodeListCompletedEventArgs>(m_client_GetNodeListCompleted);            
            Loaded += new RoutedEventHandler(SelectNode_Loaded);
        }

        public void RefreshNodeList()
        {
            //m_client.GetNodesAsync(true, false);	
            m_client.GetNodeListAsync(true);
        }

        #endregion

    }
}
