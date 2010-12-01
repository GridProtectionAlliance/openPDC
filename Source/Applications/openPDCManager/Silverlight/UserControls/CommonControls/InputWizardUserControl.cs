//******************************************************************************************************
//  InputWizardUserControl.cs - Gbtc
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
//  08/16/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Windows;
using openPDCManager.ModalDialogs;
using openPDCManager.PhasorDataServiceProxy;
using openPDCManager.Utilities;

namespace openPDCManager.UserControls.CommonControls
{
    public partial class InputWizardUserControl
    {
        #region [ Members ]

        PhasorDataServiceClient m_client;

        #endregion

        #region [ Methods ]

        void Initialize()
        {
            //Services Events			
            m_client = ProxyClient.GetPhasorDataServiceProxyClient();
            m_client.GetProtocolsCompleted += new EventHandler<GetProtocolsCompletedEventArgs>(client_GetProtocolsCompleted);
            m_client.GetVendorDevicesCompleted += new EventHandler<GetVendorDevicesCompletedEventArgs>(client_GetVendorDevicesCompleted);
            m_client.GetCompaniesCompleted += new EventHandler<GetCompaniesCompletedEventArgs>(client_GetCompaniesCompleted);
            m_client.GetHistoriansCompleted += new EventHandler<GetHistoriansCompletedEventArgs>(client_GetHistoriansCompleted);
            m_client.GetInterconnectionsCompleted += new EventHandler<GetInterconnectionsCompletedEventArgs>(client_GetInterconnectionsCompleted);
            m_client.GetConnectionSettingsCompleted += new EventHandler<GetConnectionSettingsCompletedEventArgs>(client_GetConnectionSettingsCompleted);
            m_client.GetWizardConfigurationInfoCompleted += new EventHandler<GetWizardConfigurationInfoCompletedEventArgs>(client_GetWizardConfigurationInfoCompleted);
            m_client.SaveWizardConfigurationInfoCompleted += new EventHandler<SaveWizardConfigurationInfoCompletedEventArgs>(client_SaveWizardConfigurationInfoCompleted);
            m_client.GetDeviceByAcronymCompleted += new EventHandler<GetDeviceByAcronymCompletedEventArgs>(client_GetDeviceByAcronymCompleted);
            m_client.SaveDeviceCompleted += new EventHandler<SaveDeviceCompletedEventArgs>(client_SaveDeviceCompleted);
            m_client.GetExecutingAssemblyPathCompleted += new EventHandler<GetExecutingAssemblyPathCompletedEventArgs>(client_GetExecutingAssemblyPathCompleted);
            m_client.SaveIniFileCompleted += new EventHandler<SaveIniFileCompletedEventArgs>(client_SaveIniFileCompleted);
            m_client.GetProtocolIDByAcronymCompleted += new EventHandler<GetProtocolIDByAcronymCompletedEventArgs>(client_GetProtocolIDByAcronymCompleted);
            m_client.RetrieveConfigurationFrameCompleted += new EventHandler<RetrieveConfigurationFrameCompletedEventArgs>(client_RetrieveConfigurationFrameCompleted);
        }

        void RetrieveConfigurationFrame()
        {
            string connectionString = this.ConnectionString();
            if (!connectionString.EndsWith(";"))
                connectionString += ";";
            connectionString += "AccessID=" + TextBoxAccessID.Text;
            m_client.RetrieveConfigurationFrameAsync(((App)Application.Current).RemoteStatusServiceUrl, connectionString, ((KeyValuePair<int, string>)ComboboxProtocol.SelectedItem).Key);
        }

        void GetProtocolIDByAcronym()
        {
            m_client.GetProtocolIDByAcronymAsync(m_connectionSettings.PhasorProtocol.ToString());
        }

        void SaveIniFile()
        {
            m_client.SaveIniFileAsync(ReadFileBytes(m_iniFileData)); 
        }

        void GetExecutingAssemblyPath()
        {
            m_client.GetExecutingAssemblyPathAsync();
        }

        void SaveDevice(Device device, bool isNew, int digitalCount, int analogCount)
        {
            m_client.SaveDeviceAsync(device, isNew, digitalCount, analogCount);
        }

        void GetDeviceByAcronym(string acronym)
        {
            m_client.GetDeviceByAcronymAsync(acronym);
        }

        void SaveWizardConfigurationInfo(string nodeID, ObservableCollection<WizardDeviceInfo> wizardDeviceInfoList, string connectionString,
                int? protocolID, int? companyID, int? historianID, int? interconnectionID, int? parentID, bool skipDisableRealTimeData)
        {
            m_client.SaveWizardConfigurationInfoAsync(nodeID, wizardDeviceInfoList, connectionString, protocolID, companyID, historianID, interconnectionID, parentID, skipDisableRealTimeData);
        }

        void GetWizardConfigurationInfo(byte[] data)
        {
            m_client.GetWizardConfigurationInfoAsync(data);
        }

        void GetConnectionSettings()
        {
            m_client.GetConnectionSettingsAsync(ReadFileBytes(m_connectionFileData));
        }

        void GetInterconnections()
        {
            m_client.GetInterconnectionsAsync(true);
        }

        void GetHistorians()
        {
            m_client.GetHistoriansAsync(true, true, false);
        }

        void GetCompanies()
        {
            m_client.GetCompaniesAsync(false);
        }

        void GetProtocols()
        {
            m_client.GetProtocolsAsync(false);
        }

        void GetVendorDevices()
        {
            m_client.GetVendorDevicesAsync(true);
        }
        
        #endregion

        #region [ Service Event Handlers ]

        void client_GetProtocolIDByAcronymCompleted(object sender, GetProtocolIDByAcronymCompletedEventArgs e)
        {
            if (e.Error == null && e.Result > 0)
            {
                foreach (KeyValuePair<int, string> item in ComboboxProtocol.Items)
                {
                    if (item.Key == e.Result)
                    {
                        ComboboxProtocol.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        void client_SaveIniFileCompleted(object sender, SaveIniFileCompletedEventArgs e)
        {
            if (e.Error == null)
                m_iniFileName = e.Result;
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Upload INI File", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.ShowPopup();
            }
        }

        void client_GetExecutingAssemblyPathCompleted(object sender, GetExecutingAssemblyPathCompletedEventArgs e)
        {
            if (e.Error == null)
                m_iniFilePath = e.Result;
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Current Execution Path", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
        }

        void client_GetInterconnectionsCompleted(object sender, GetInterconnectionsCompletedEventArgs e)
        {
            if (e.Error == null)
                ComboboxInterconnection.ItemsSource = e.Result;
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Interconnections", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
            if (ComboboxInterconnection.Items.Count > 0)
                ComboboxInterconnection.SelectedIndex = 0;
        }

        void client_GetHistoriansCompleted(object sender, GetHistoriansCompletedEventArgs e)
        {
            if (e.Error == null)
                ComboboxHistorian.ItemsSource = e.Result;
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
            if (ComboboxHistorian.Items.Count > 1)
                ComboboxHistorian.SelectedIndex = 1;
            else if (ComboboxHistorian.Items.Count > 0)
                ComboboxHistorian.SelectedIndex = 0;
        }

        void client_GetCompaniesCompleted(object sender, GetCompaniesCompletedEventArgs e)
        {
            if (e.Error == null)
                ComboboxCompany.ItemsSource = e.Result;
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Companies", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
            if (ComboboxCompany.Items.Count > 0)
                ComboboxCompany.SelectedIndex = 0;
        }

        void client_GetVendorDevicesCompleted(object sender, GetVendorDevicesCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                m_vendorDeviceList = e.Result;
                ComboboxPDCVendor.ItemsSource = m_vendorDeviceList;
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Vendor Devices", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
            if (ComboboxPDCVendor.Items.Count > 0)
                ComboboxPDCVendor.SelectedIndex = 0;
        }

        void client_GetProtocolsCompleted(object sender, GetProtocolsCompletedEventArgs e)
        {
            if (e.Error == null)
                ComboboxProtocol.ItemsSource = e.Result;
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Protocols", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
            if (ComboboxProtocol.Items.Count > 0)
                ComboboxProtocol.SelectedIndex = 0;
        }

        void client_GetConnectionSettingsCompleted(object sender, GetConnectionSettingsCompletedEventArgs e)
        {
            if (e.Error == null)
            {                
                m_connectionSettings = e.Result;
                if (m_connectionSettings != null)
                {
                    string connectionString = m_connectionSettings.ConnectionString.ToLower();
                    Dictionary<string, string> connectionSettings = connectionString.ParseKeyValuePairs(';', '=', '{', '}');

                    if (connectionSettings.ContainsKey("commandchannel"))
                    {
                        TextBoxAlternateCommandChannel.Text = connectionSettings["commandchannel"];
                        connectionSettings.Remove("commandchannel");
                    }

                    if (connectionSettings.ContainsKey("skipdisablerealtimedata"))
                    {
                        m_skipDisableRealTimeData = Convert.ToBoolean(connectionSettings["skipdisablerealtimedata"]);
                        connectionSettings.Remove("skipdisablerealtimedata");
                    }

                    TextBoxConnectionString.Text = "TransportProtocol=" + m_connectionSettings.TransportProtocol.ToString() + ";" + connectionSettings.JoinKeyValuePairs(';', '=');

                    if (m_connectionSettings.ConnectionParameters != null)
                    {
                        TextBoxConnectionString.Text += ";iniFileName=" + m_connectionSettings.configurationFileName + ";refreshConfigFileOnChange=" + m_connectionSettings.refreshConfigurationFileOnChange.ToString() +
                                    ";parseWordCountFromByte=" + m_connectionSettings.parseWordCountFromByte;
                    }

                    //if (m_connectionSettings.PmuID != null)
                        TextBoxAccessID.Text = m_connectionSettings.PmuID.ToString();

                    //Select Phasor Protocol type in the combobox based on the protocol in the connection file.
                    GetProtocolIDByAcronym();
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Parse Connection File", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
        }

        void client_GetWizardConfigurationInfoCompleted(object sender, GetWizardConfigurationInfoCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                m_wizardDeviceInfoList = e.Result;
                ItemControlDeviceList.ItemsSource = m_wizardDeviceInfoList;
                if (m_wizardDeviceInfoList.Count > 1)
                {
                    CheckboxConnectToPDC.IsChecked = true;
                    SystemMessages sm = new SystemMessages(new openPDCManager.Utilities.Message() { UserMessage = "Please fill in required concentrator information.", SystemMessage = "The current configuration defines more than one device which means this connection is to a concentrated data stream. A unique concentrator acronym is required to identify the concentration device.", UserMessageType = openPDCManager.Utilities.MessageType.Information },
                                ButtonType.OkOnly);                   
                    sm.ShowPopup();
                    TextBoxPDCAcronym.Focus();                    
                }
                else
                    CheckboxConnectToPDC.IsChecked = false;                
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Parse Configuration File", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
            if (m_activityWindow != null)
                m_activityWindow.Close();
            m_configFileData.Close();
        }

        void client_SaveWizardConfigurationInfoCompleted(object sender, SaveWizardConfigurationInfoCompletedEventArgs e)
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Configuration Information", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
            }
            sm.ShowPopup();
            nextButtonClicked = false;
            if (m_activityWindow != null)
                m_activityWindow.Close();

            if (e.Error == null)
            {

            }
        }

        void client_GetDeviceByAcronymCompleted(object sender, GetDeviceByAcronymCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                Device device = new Device();
                device = e.Result;
                if (device != null)
                {
                    if (device.IsConcentrator)
                        m_parentID = device.ID;
                    else
                    {
                        SystemMessages sm = new SystemMessages(new openPDCManager.Utilities.Message() { UserMessage = "Invalid PDC Acronym", SystemMessage = "A non-PDC device with the same acronym already exists. Please change PDC acronym to continue.", UserMessageType = openPDCManager.Utilities.MessageType.Error },
                        ButtonType.OkOnly);                        
                        sm.ShowPopup();
                        TextBoxPDCAcronym.Focus();
                        m_goToPreviousAccordianItem = true;
                    }
                }
                else	// means PDC does not exist. if (parentID == null)
                {
                    App app = (App)Application.Current;
                    device = new Device();
                    device.Name = TextBoxPDCName.Text;
                    device.Acronym = TextBoxPDCAcronym.Text;
                    device.IsConcentrator = true;
                    device.VendorDeviceID = ((KeyValuePair<int, string>)ComboboxPDCVendor.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboboxPDCVendor.SelectedItem).Key;
                    int accessID;
                    device.AccessID = int.TryParse(TextBoxAccessID.Text, out accessID) ? accessID : m_wizardDeviceInfoList.Count > 0 ? m_wizardDeviceInfoList[0].ParentAccessID : 0;                    
                    device.NodeID = app.NodeValue;
                    device.ParentID = null;
                    device.Longitude = -98.6m;
                    device.Latitude = 37.5m;
                    device.CompanyID = ((KeyValuePair<int, string>)ComboboxCompany.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboboxCompany.SelectedItem).Key;
                    device.ProtocolID = ((KeyValuePair<int, string>)ComboboxProtocol.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboboxProtocol.SelectedItem).Key;
                    device.HistorianID = ((KeyValuePair<int, string>)ComboboxHistorian.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboboxHistorian.SelectedItem).Key;
                    device.InterconnectionID = ((KeyValuePair<int, string>)ComboboxInterconnection.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboboxInterconnection.SelectedItem).Key;
                    device.ConnectionString = this.ConnectionString();
                    device.TimeZone = string.Empty;
                    device.TimeAdjustmentTicks = 0;
                    device.MeasuredLines = 1;   //m_wizardDeviceInfoList.Count;
                    device.LoadOrder = 0;
                    device.ContactList = string.Empty;
                    device.Enabled = true;
                    device.FramesPerSecond = 30;
                    device.DataLossInterval = 5;
                    device.AllowedParsingExceptions = 10;
                    device.ParsingExceptionWindow = 5;
                    device.DelayedConnectionInterval = 5;
                    device.AllowUseOfCachedConfiguration = true;
                    device.AutoStartDataParsingSequence = true;
                    device.MeasurementReportingInterval = 100000;
                    SaveDevice(device, true, 0, 0);
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Device Information by Acronym", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
        }

        void client_SaveDeviceCompleted(object sender, SaveDeviceCompletedEventArgs e)
        {
            if (e.Error == null)
                m_client.GetDeviceByAcronymAsync(TextBoxPDCAcronym.Text.Replace(" ", "").ToUpper());	// calling this again would set parentID needed in the final step of the wizard.
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Device Information", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);

                sm.ShowPopup();
            }
        }

        void client_RetrieveConfigurationFrameCompleted(object sender, RetrieveConfigurationFrameCompletedEventArgs e)
        {
            SystemMessages sm;
            if (e.Error == null)
            {
                m_wizardDeviceInfoList = e.Result;
                ItemControlDeviceList.ItemsSource = m_wizardDeviceInfoList;
                if (m_wizardDeviceInfoList.Count > 1)
                {
                    CheckboxConnectToPDC.IsChecked = true;
                    SystemMessages sm1 = new SystemMessages(new openPDCManager.Utilities.Message() { UserMessage = "Please fill in required concentrator information.", SystemMessage = "The current configuration defines more than one device which means this connection is to a concentrated data stream. A unique concentrator acronym is required to identify the concentration device.", UserMessageType = openPDCManager.Utilities.MessageType.Information },
                                ButtonType.OkOnly);
                    sm1.ShowPopup();                    
                }
                else
                    CheckboxConnectToPDC.IsChecked = false;
                
                sm = new SystemMessages(new Message() { UserMessage = "Retrieved Configuration Successfully!", SystemMessage = "", UserMessageType = MessageType.Success }, ButtonType.OkOnly);
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
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Configuration", SystemMessage = e.Error.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
            }
            sm.ShowPopup();

            if (m_activityWindow != null)
                m_activityWindow.Close();
        }

        #endregion
    }
}
