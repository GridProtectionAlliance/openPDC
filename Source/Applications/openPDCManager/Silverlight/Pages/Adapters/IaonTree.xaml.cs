//******************************************************************************************************
//  IaonTree.xaml.cs - Gbtc
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
//  09/29/2009 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using openPDCManager.ModalDialogs;
using openPDCManager.PhasorDataServiceProxy;
using openPDCManager.Utilities;

namespace openPDCManager.Pages.Adapters
{
	public partial class IaonTree : Page
	{
        #region [ Members ]

        PhasorDataServiceClient m_client;

        #endregion

		#region [ Constructor ]

		public IaonTree()
		{
			InitializeComponent();
            m_client = ProxyClient.GetPhasorDataServiceProxyClient();
            m_client.GetIaonTreeDataCompleted += new EventHandler<GetIaonTreeDataCompletedEventArgs>(client_GetIaonTreeDataCompleted);
            Loaded += new RoutedEventHandler(IaonTree_Loaded);
		}

		#endregion

        #region [ Page Event Handlers ]

        void IaonTree_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        protected override void  OnNavigatedTo(NavigationEventArgs e)
        {
            m_client.GetIaonTreeDataAsync(((App)Application.Current).NodeValue);
 	        base.OnNavigatedTo(e);
        }

        #endregion

        #region [ Service Event Handlers ]

        void client_GetIaonTreeDataCompleted(object sender, GetIaonTreeDataCompletedEventArgs e)
        {
            if (e.Error == null)
                TreeViewIaon.ItemsSource = e.Result;
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Iaon Tree Data", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.ShowPopup();
            }
        }

        #endregion
		
	}
}
