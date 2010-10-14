//******************************************************************************************************
//  ConnectionStringBuilder.xaml.cs - Gbtc
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
//  04/21/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using openPDCManager.PhasorDataServiceProxy;
using openPDCManager.Utilities;

namespace openPDCManager.ModalDialogs
{
	public partial class ConnectionStringBuilder : ChildWindow
	{
        #region [ Members ]

        ConnectionType m_connectionType;
        string m_connectionString;
        PhasorDataServiceClient m_client;
        Dictionary<string, string> keyvaluepairs;

        public string ConnectionString
        {
            get { return m_connectionString; }
            set { m_connectionString = value; }
        }

        #endregion

        #region [ Enumerations ]

        enum TransportProtocol
        {
            tcp,
            udp,
            serial,
            file,
            udpserver
        }

        public enum ConnectionType
        {
            DeviceConnection,
            DataChannel,
            CommandChannel,
            AlternateCommandChannel
        }

        #endregion

        #region [ Constructor ]

        public ConnectionStringBuilder(ConnectionType connectionType)
        {
            InitializeComponent();
            m_connectionType = connectionType;
            m_client = ProxyClient.GetPhasorDataServiceProxyClient();
            //m_client.GetPortsCompleted += new System.EventHandler<GetPortsCompletedEventArgs>(m_client_GetPortsCompleted);
            m_client.GetStopBitsCompleted += new System.EventHandler<GetStopBitsCompletedEventArgs>(m_client_GetStopBitsCompleted);
            m_client.GetParitiesCompleted += new System.EventHandler<GetParitiesCompletedEventArgs>(m_client_GetParitiesCompleted);
            this.Loaded += new RoutedEventHandler(ConnectionStringBuilder_Loaded);
            ButtonSaveFile.Click += new RoutedEventHandler(ButtonSaveFile_Click);
            ButtonSaveTCP.Click += new RoutedEventHandler(ButtonSaveTCP_Click);
            ButtonSaveSerial.Click += new RoutedEventHandler(ButtonSaveSerial_Click);
            ButtonSaveUDP.Click += new RoutedEventHandler(ButtonSaveUDP_Click);
            ButtonBrowseFile.Click += new RoutedEventHandler(ButtonBrowseFile_Click);
            ButtonSaveUdpServer.Click += new RoutedEventHandler(ButtonSaveUdpServer_Click);
            TabControlOptions.SelectionChanged += new SelectionChangedEventHandler(TabControlOptions_SelectionChanged);
            CheckboxEnableMulticast.Checked += new RoutedEventHandler(CheckboxEnableMulticast_Checked);
            CheckboxEnableMulticast.Unchecked += new RoutedEventHandler(CheckboxEnableMulticast_Unchecked);
        }

        #endregion

        #region [ Service Event Handlers ]

        void m_client_GetParitiesCompleted(object sender, GetParitiesCompletedEventArgs e)
        {
            if (e.Error == null)
                ComboboxParity.ItemsSource = e.Result;
            if (ComboboxParity.Items.Count > 0)
                ComboboxParity.SelectedIndex = 0;
        }

        void m_client_GetStopBitsCompleted(object sender, GetStopBitsCompletedEventArgs e)
        {
            if (e.Error == null)
                ComboboxStopBits.ItemsSource = e.Result;
            if (ComboboxStopBits.Items.Count > 0)
                ComboboxStopBits.SelectedIndex = 0;
        }

        #endregion

        #region [ Controls Event Handlers ]

        void ButtonBrowseFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "PMU Capture File (*.PmuCapture)|*.PmuCapture|All Files (*.*)|*.*";
            bool? result = openFileDialog.ShowDialog();
            if (result != null && result == true)
                TextBoxFile.Text = openFileDialog.File.Name;
        }

        void ButtonSaveUDP_Click(object sender, RoutedEventArgs e)
        {
            if (!keyvaluepairs.ContainsKey("localport"))
                keyvaluepairs.Add("localport", String.IsNullOrEmpty(TextBoxLocalPort.Text) ? "4712" : TextBoxLocalPort.Text);
            else
                keyvaluepairs["localport"] = String.IsNullOrEmpty(TextBoxLocalPort.Text) ? "4712" : TextBoxLocalPort.Text;

            if ((bool)CheckboxEnableMulticast.IsChecked)
            {
                if (!keyvaluepairs.ContainsKey("server"))
                    keyvaluepairs.Add("server", FormatIP(TextBoxHostIPUdp.Text));
                else
                    keyvaluepairs["server"] = FormatIP(TextBoxHostIPUdp.Text);

                if (!keyvaluepairs.ContainsKey("remoteport"))
                    keyvaluepairs.Add("remoteport", TextBoxRemotePort.Text);
                else
                    keyvaluepairs["remoteport"] = TextBoxRemotePort.Text;
            }
            else
            {
                if (keyvaluepairs.ContainsKey("server"))
                    keyvaluepairs.Remove("server");

                if (keyvaluepairs.ContainsKey("remoteport"))
                    keyvaluepairs.Remove("remoteport");
            }

            SetConnectionString(TransportProtocol.udp);
            this.DialogResult = true;
        }

        void ButtonSaveSerial_Click(object sender, RoutedEventArgs e)
        {
            if (!keyvaluepairs.ContainsKey("port"))
                keyvaluepairs.Add("port", ComboboxPort.SelectedItem.ToString());
            else
                keyvaluepairs["port"] = ComboboxPort.SelectedItem.ToString();

            if (!keyvaluepairs.ContainsKey("baudrate"))
                keyvaluepairs.Add("baudrate", ComboboxBaudRate.SelectedItem.ToString());
            else
                keyvaluepairs["baudrate"] = ComboboxBaudRate.SelectedItem.ToString();

            if (!keyvaluepairs.ContainsKey("parity"))
                keyvaluepairs.Add("parity", ComboboxParity.SelectedItem.ToString());
            else
                keyvaluepairs["parity"] = ComboboxParity.SelectedItem.ToString();

            if (!keyvaluepairs.ContainsKey("stopbits"))
                keyvaluepairs.Add("stopbits", ComboboxStopBits.SelectedItem.ToString());
            else
                keyvaluepairs["stopbits"] = ComboboxStopBits.SelectedItem.ToString();

            if (!keyvaluepairs.ContainsKey("databits"))
                keyvaluepairs.Add("databits", String.IsNullOrEmpty(TextBoxDataBits.Text) ? "8" : TextBoxDataBits.Text);
            else
                keyvaluepairs["databits"] = String.IsNullOrEmpty(TextBoxDataBits.Text) ? "8" : TextBoxDataBits.Text;

            if (!keyvaluepairs.ContainsKey("dtrenable"))
                keyvaluepairs.Add("dtrenable", CheckboxDTR.IsChecked.ToString().ToLower());
            else
                keyvaluepairs["dtrenable"] = CheckboxDTR.IsChecked.ToString().ToLower();

            if (!keyvaluepairs.ContainsKey("rtsenable"))
                keyvaluepairs.Add("rtsenable", CheckboxRTS.IsChecked.ToString().ToLower());
            else
                keyvaluepairs["rtsenable"] = CheckboxRTS.IsChecked.ToString().ToLower();

            SetConnectionString(TransportProtocol.serial);
            this.DialogResult = true;
        }

        void ButtonSaveTCP_Click(object sender, RoutedEventArgs e)
        {
            if (m_connectionType != ConnectionType.CommandChannel)
            {
                string hostIP = String.IsNullOrEmpty(TextBoxHostIP.Text) ? "127.0.0.1" : TextBoxHostIP.Text;
                if (!keyvaluepairs.ContainsKey("server"))
                    keyvaluepairs.Add("server", FormatIP(hostIP));
                else
                    keyvaluepairs["server"] = FormatIP(hostIP);

                if (!keyvaluepairs.ContainsKey("islistener"))
                    keyvaluepairs.Add("islistener", CheckboxEstablishServer.IsChecked.ToString().ToLower());
                else
                    keyvaluepairs["islistener"] = CheckboxEstablishServer.IsChecked.ToString().ToLower();
            }

            if (!keyvaluepairs.ContainsKey("port"))
                keyvaluepairs.Add("port", String.IsNullOrEmpty(TextBoxPort.Text) ? "4712" : TextBoxPort.Text);
            else
                keyvaluepairs["port"] = String.IsNullOrEmpty(TextBoxPort.Text) ? "4712" : TextBoxPort.Text;

            SetConnectionString(TransportProtocol.tcp);
            this.DialogResult = true;
        }

        void ButtonSaveFile_Click(object sender, RoutedEventArgs e)
        {
            CheckboxForceIPv4.IsChecked = false;	//as IPv4 doesn't matter for file protocol
            if (!keyvaluepairs.ContainsKey("file"))
                keyvaluepairs.Add("file", TextBoxFile.Text);
            else
                keyvaluepairs["file"] = TextBoxFile.Text;

            if (!keyvaluepairs.ContainsKey("definedframerate"))
                keyvaluepairs.Add("definedframerate", String.IsNullOrEmpty(TextBoxFrameRate.Text) ? "30" : TextBoxFrameRate.Text);
            else
                keyvaluepairs["definedframerate"] = String.IsNullOrEmpty(TextBoxFrameRate.Text) ? "30" : TextBoxFrameRate.Text;

            if (!keyvaluepairs.ContainsKey("simulatetimestamp"))
                keyvaluepairs.Add("simulatetimestamp", CheckboxSimulateTimeStamp.IsChecked.ToString().ToLower());
            else
                keyvaluepairs["simulatetimestamp"] = CheckboxSimulateTimeStamp.IsChecked.ToString().ToLower();

            if (!keyvaluepairs.ContainsKey("autorepeatfile"))
                keyvaluepairs.Add("autorepeatfile", CheckboxAutoRepeat.IsChecked.ToString().ToLower());
            else
                keyvaluepairs["autorepeatfile"] = CheckboxAutoRepeat.IsChecked.ToString().ToLower();

            SetConnectionString(TransportProtocol.file);
            this.DialogResult = true;
        }

        void ButtonSaveUdpServer_Click(object sender, RoutedEventArgs e)
        {
            if (!keyvaluepairs.ContainsKey("port"))
                keyvaluepairs.Add("port", "-1");
            else
                keyvaluepairs["port"] = "-1";

            if (!keyvaluepairs.ContainsKey("clients"))
                keyvaluepairs.Add("clients", "");

            string clients = string.Empty;
            if (!string.IsNullOrEmpty(TextBoxHostIP1.Text))
                clients += FormatIP(TextBoxHostIP1.Text) + ":" + (string.IsNullOrEmpty(TextBoxHostPort1.Text) ? "4712" : TextBoxHostPort1.Text) + ",";

            if (!string.IsNullOrEmpty(TextBoxHostIP2.Text))
                clients += FormatIP(TextBoxHostIP2.Text) + ":" + (string.IsNullOrEmpty(TextBoxHostPort2.Text) ? "4712" : TextBoxHostPort2.Text) + ",";

            if (!string.IsNullOrEmpty(TextBoxHostIP3.Text))
                clients += FormatIP(TextBoxHostIP3.Text) + ":" + (string.IsNullOrEmpty(TextBoxHostPort3.Text) ? "4712" : TextBoxHostPort3.Text) + ",";

            while (clients.EndsWith(","))
                clients = clients.Substring(0, clients.LastIndexOf(','));

            keyvaluepairs["clients"] = clients;

            SetConnectionString(TransportProtocol.udpserver);
            this.DialogResult = true;
        }

        void TabControlOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        void CheckboxEnableMulticast_Unchecked(object sender, RoutedEventArgs e)
        {
            StackPanelMulticastOptions.Visibility = Visibility.Collapsed;
        }

        void CheckboxEnableMulticast_Checked(object sender, RoutedEventArgs e)
        {
            StackPanelMulticastOptions.Visibility = Visibility.Visible;
        }

        #endregion

        #region [ Page Event Handlers ]

        void ConnectionStringBuilder_Loaded(object sender, RoutedEventArgs e)
        {
            if (m_connectionType == ConnectionType.CommandChannel)
            {
                TabItemTCP.Visibility = Visibility.Visible;
                TabItemUDP.Visibility = Visibility.Collapsed;
                TabItemSerial.Visibility = Visibility.Collapsed;
                TabItemFile.Visibility = Visibility.Collapsed;
                TabItemUdpServer.Visibility = Visibility.Collapsed;
                TextBlockHostIP.Visibility = Visibility.Collapsed;
                TextBoxHostIP.Visibility = Visibility.Collapsed;
                CheckboxEstablishServer.Visibility = Visibility.Collapsed;
            }
            else if (m_connectionType == ConnectionType.AlternateCommandChannel)
            {
                TabItemTCP.Visibility = Visibility.Visible;
                TabItemUDP.Visibility = Visibility.Collapsed;
                TabItemSerial.Visibility = Visibility.Collapsed;
                TabItemFile.Visibility = Visibility.Collapsed;
                TabItemUdpServer.Visibility = Visibility.Collapsed;
            }
            else if (m_connectionType == ConnectionType.DataChannel)
            {
                TabControlOptions.SelectedIndex = 4;
                TabItemTCP.Visibility = Visibility.Collapsed;
                TabItemUDP.Visibility = Visibility.Collapsed;
                TabItemSerial.Visibility = Visibility.Collapsed;
                TabItemFile.Visibility = Visibility.Collapsed;
                TabItemUdpServer.Visibility = Visibility.Visible;
            }
            else
            {
                TabItemTCP.Visibility = Visibility.Visible;
                TabItemUDP.Visibility = Visibility.Visible;
                TabItemSerial.Visibility = Visibility.Visible;
                TabItemFile.Visibility = Visibility.Visible;
                TabItemUdpServer.Visibility = Visibility.Collapsed;
            }

            keyvaluepairs = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            m_client.GetParitiesAsync();
            m_client.GetStopBitsAsync();
            //m_client.GetPortsAsync();

            ComboboxPort.Items.Add("COM1");
            ComboboxPort.Items.Add("COM2");
            ComboboxPort.Items.Add("COM3");
            ComboboxPort.Items.Add("COM4");
            ComboboxPort.Items.Add("COM5");
            ComboboxPort.Items.Add("COM6");
            ComboboxPort.Items.Add("COM7");
            ComboboxPort.Items.Add("COM8");
            ComboboxPort.Items.Add("COM9");
            ComboboxPort.Items.Add("COM10");
            ComboboxPort.SelectedIndex = 0;

            // Populate Baud Rate Dropdown in Serial Tab
            ComboboxBaudRate.Items.Add(115200);
            ComboboxBaudRate.Items.Add(57600);
            ComboboxBaudRate.Items.Add(38400);
            ComboboxBaudRate.Items.Add(19200);
            ComboboxBaudRate.Items.Add(9600);
            ComboboxBaudRate.Items.Add(4800);
            ComboboxBaudRate.Items.Add(2400);
            ComboboxBaudRate.Items.Add(1200);
            ComboboxBaudRate.SelectedIndex = 0;

            if (IsolatedStorageManager.LoadFromIsolatedStorage("ForceIPv4") != null && (bool)IsolatedStorageManager.LoadFromIsolatedStorage("ForceIPv4"))
                CheckboxForceIPv4.IsChecked = true;
            else
                CheckboxForceIPv4.IsChecked = false;

            // populate connection info	if already provided from the parent window
            ParseConnectionString();
        }

        #endregion

        #region [ Methods ]

        void ParseConnectionString()
        {
            if (!string.IsNullOrEmpty(this.ConnectionString))
            {
                string[] keyvalues = this.ConnectionString.ToLower().Replace("[", "").Replace("]", "").Split(new char[] { ';' }, System.StringSplitOptions.RemoveEmptyEntries);
                foreach (string keyvalue in keyvalues)
                {
                    string[] keyvaluepair = keyvalue.Split('=');
                    if (keyvaluepair.GetLength(0) == 2)
                    {
                        keyvaluepairs.Add(keyvaluepair[0].Trim(), keyvaluepair[1].Trim());
                    }
                }

                if (m_connectionType == ConnectionType.DataChannel) //then it is UDP server.
                {
                    TabControlOptions.SelectedIndex = 4;
                    if (keyvaluepairs.ContainsKey("clients"))
                    {
                        string[] clients = keyvaluepairs["clients"].Split(',');
                        int count = 0;
                        foreach (string client in clients)
                        {
                            string port = "4712";
                            string hostIp = string.Empty;
                            if (client.Contains(":"))
                            {
                                hostIp = client.Substring(0, client.LastIndexOf(':'));
                                port = client.Substring(client.LastIndexOf(':') + 1);
                            }
                            else
                                hostIp = client;

                            if (count == 0)
                            {
                                TextBoxHostIP1.Text = hostIp;
                                TextBoxHostPort1.Text = port;
                            }
                            else if (count == 1)
                            {
                                TextBoxHostIP2.Text = hostIp;
                                TextBoxHostPort2.Text = port;
                            }
                            else if (count == 2)
                            {
                                TextBoxHostIP3.Text = hostIp;
                                TextBoxHostPort3.Text = port;
                            }
                            count += 1;
                        }
                    }
                }
                else if ((keyvaluepairs.ContainsKey("transportprotocol") && keyvaluepairs["transportprotocol"].ToLower() == "tcp") || (keyvaluepairs.ContainsKey("protocol") && keyvaluepairs["protocol"].ToLower() == "tcp"))
                {
                    TabControlOptions.SelectedIndex = 0;
                    if (keyvaluepairs.ContainsKey("server"))
                        TextBoxHostIP.Text = keyvaluepairs["server"];
                    if (keyvaluepairs.ContainsKey("port"))
                        TextBoxPort.Text = keyvaluepairs["port"];
                    if (keyvaluepairs.ContainsKey("islistener") && keyvaluepairs["islistener"].ToLower() == "true")
                        CheckboxEstablishServer.IsChecked = true;
                    else
                        CheckboxEstablishServer.IsChecked = false;
                }
                else if ((keyvaluepairs.ContainsKey("transportprotocol") && keyvaluepairs["transportprotocol"].ToLower() == "udp") ||
                            (keyvaluepairs.ContainsKey("protocol") && keyvaluepairs["protocol"].ToLower() == "udp"))
                {
                    TabControlOptions.SelectedIndex = 1;
                    if (keyvaluepairs.ContainsKey("localport"))
                        TextBoxLocalPort.Text = keyvaluepairs["localport"];
                    if (keyvaluepairs.ContainsKey("server"))
                    {
                        CheckboxEnableMulticast.IsChecked = true;
                        TextBoxHostIPUdp.Text = keyvaluepairs["server"];
                        if (keyvaluepairs.ContainsKey("remoteport"))
                            TextBoxRemotePort.Text = keyvaluepairs["remoteport"];
                    }
                    else
                    {
                        CheckboxEnableMulticast.IsChecked = false;
                        TextBoxHostIPUdp.Text = string.Empty;
                        TextBoxRemotePort.Text = string.Empty;
                    }
                }
                else if ((keyvaluepairs.ContainsKey("transportprotocol") && keyvaluepairs["transportprotocol"].ToLower() == "serial") || (keyvaluepairs.ContainsKey("protocol") && keyvaluepairs["protocol"].ToLower() == "serial"))
                {
                    TabControlOptions.SelectedIndex = 2;
                    if (keyvaluepairs.ContainsKey("port"))
                        ComboboxPort.SelectedItem = keyvaluepairs["port"];
                    if (keyvaluepairs.ContainsKey("baudrate"))
                        ComboboxBaudRate.SelectedItem = keyvaluepairs["baudrate"];
                    if (keyvaluepairs.ContainsKey("parity"))
                        ComboboxParity.SelectedItem = keyvaluepairs["parity"];
                    if (keyvaluepairs.ContainsKey("stopbits"))
                        ComboboxStopBits.SelectedItem = keyvaluepairs["stopbits"];
                    if (keyvaluepairs.ContainsKey("databits"))
                        TextBoxDataBits.Text = keyvaluepairs["databits"];
                    if (keyvaluepairs.ContainsKey("dtrenable") && keyvaluepairs["dtrenable"].ToLower() == "true")
                        CheckboxDTR.IsChecked = true;
                    else
                        CheckboxDTR.IsChecked = false;
                    if (keyvaluepairs.ContainsKey("rtsenable") && keyvaluepairs["rtsenable"].ToLower() == "true")
                        CheckboxRTS.IsChecked = true;
                    else
                        CheckboxRTS.IsChecked = false;
                }
                else if ((keyvaluepairs.ContainsKey("transportprotocol") && keyvaluepairs["transportprotocol"].ToLower() == "file") || (keyvaluepairs.ContainsKey("protocol") && keyvaluepairs["protocol"].ToLower() == "file"))
                {
                    TabControlOptions.SelectedIndex = 3;
                    if (keyvaluepairs.ContainsKey("file"))
                        TextBoxFile.Text = keyvaluepairs["file"];

                    if (keyvaluepairs.ContainsKey("definedframerate"))
                        TextBoxFrameRate.Text = keyvaluepairs["definedframerate"];

                    if (keyvaluepairs.ContainsKey("simulatetimestamp") && keyvaluepairs["simulatetimestamp"].ToLower() == "false")
                        CheckboxSimulateTimeStamp.IsChecked = false;	//by default it is true

                    if (keyvaluepairs.ContainsKey("autorepeatfile") && keyvaluepairs["autorepeatfile"].ToLower() == "false")
                        CheckboxAutoRepeat.IsChecked = false;
                }
                else
                    TabControlOptions.SelectedIndex = 0;


                if (keyvaluepairs.ContainsKey("interface"))
                    CheckboxForceIPv4.IsChecked = true;
                else
                    CheckboxForceIPv4.IsChecked = false;
            }
        }

        void SetConnectionString(TransportProtocol transportProtocol)
        {
            if (m_connectionType != ConnectionType.DataChannel)	// don't need transport protocol if it is a data channel. By default it is UDP.
            {
                if (!keyvaluepairs.ContainsKey("transportprotocol") && !keyvaluepairs.ContainsKey("protocol"))
                    keyvaluepairs.Add("transportprotocol", transportProtocol.ToString());
                else if (keyvaluepairs.ContainsKey("transportprotocol"))
                    keyvaluepairs["transportprotocol"] = transportProtocol.ToString();
                else if (keyvaluepairs.ContainsKey("protocol"))
                    keyvaluepairs["protocol"] = transportProtocol.ToString();
            }

            if ((bool)CheckboxForceIPv4.IsChecked)
            {
                if (!keyvaluepairs.ContainsKey("interface"))
                    keyvaluepairs.Add("interface", "0.0.0.0");
                else
                    keyvaluepairs["interface"] = "0.0.0.0";
            }
            else
            {
                keyvaluepairs.Remove("interface");
            }

            m_connectionString = string.Empty;
            foreach (KeyValuePair<string, string> keyvalue in keyvaluepairs)
            {
                m_connectionString += keyvalue.Key + "=" + keyvalue.Value + "; ";
            }
        }

        string FormatIP(string ipAddress)
        {
            if (ipAddress.Contains(":"))
                ipAddress = "[" + ipAddress + "]";

            return ipAddress;
        }

        #endregion

	}
}

