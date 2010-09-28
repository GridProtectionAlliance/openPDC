//******************************************************************************************************
//  AddDevicesUserControl.cs - Gbtc
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
//  08/02/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.ServiceModel;
using openPDCManager.ModalDialogs;
using openPDCManager.PhasorDataServiceProxy;
using openPDCManager.Utilities;
using System.Windows.Controls;

namespace openPDCManager.UserControls.OutputStreamControls
{
    public partial class AddDevicesUserControl
    {
        #region [ Members ]

        PhasorDataServiceClient m_client;

        #endregion

        #region [ Methods ]

        void Initialize()
        {
            m_client = ProxyClient.GetPhasorDataServiceProxyClient();
            m_client.GetDevicesForOutputStreamCompleted += new EventHandler<GetDevicesForOutputStreamCompletedEventArgs>(client_GetDevicesForOutputStreamCompleted);
            m_client.AddDevicesCompleted += new EventHandler<AddDevicesCompletedEventArgs>(client_AddDevicesCompleted);            
        }

        void GetDevicesForOutputStream()
        {
            m_client.GetDevicesForOutputStreamAsync(m_sourceOutputStreamID, m_nodeValue);
        }

        void AddDevices()
        {
            m_client.AddDevicesAsync(m_sourceOutputStreamID, m_devicesToBeAdded, (bool)CheckAddDigitals.IsChecked, (bool)CheckAddAnalog.IsChecked);
        }

        #endregion

        #region [ Service Event Handlers ]

        void client_AddDevicesCompleted(object sender, AddDevicesCompletedEventArgs e)
        {
            SystemMessages sm;
            if (e.Error == null)
            {
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Add Output Stream Device(s)", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
            }
            sm.ShowPopup();
            m_client.GetDevicesForOutputStreamAsync(m_sourceOutputStreamID, m_nodeValue);            
        }

        void client_GetDevicesForOutputStreamCompleted(object sender, GetDevicesForOutputStreamCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                m_deviceList = e.Result;
                ListBoxDeviceList.ItemsSource = m_deviceList;
                if (ListBoxDeviceList.Items.Count > 0)
                    ListBoxDeviceList.SelectedIndex = 0;
                else
                {
                    SystemMessages sm = new SystemMessages(new Message() { UserMessage = "There are no more devices to add to the Output Stream", SystemMessage = "Click OK to return back to Current Devices For Output Stream list.", UserMessageType = MessageType.Information },
                        ButtonType.OkOnly);                    
                    sm.ShowPopup();
                    ((openPDCManager.ModalDialogs.OutputStreamWizard.AddDevices)((Grid)this.Parent).Parent).Close();
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Device for Output Stream", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
        }

        #endregion
    }
}
