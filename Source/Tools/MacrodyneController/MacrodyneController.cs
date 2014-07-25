//*******************************************************************************************************
//  MacrodyneController.cs - Gbtc
//
//  Grid Protection Alliance
//  Copyright © 2010, All Rights Reserved.
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  07/30/2010 - J. Ritchie Carroll
//       Generated original version of source code.
//
//*******************************************************************************************************

using System;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GSF;
using GSF.Communication;
using GSF.IO.Checksums;
using GSF.PhasorProtocols.Macrodyne;
using GSF.Reflection;
using GSF.Windows.Forms;

namespace MacrodyneController
{
    public partial class MacrodyneController : Form
    {
        private SerialClient m_serialClient;
        private MemoryStream m_bytesToSend;
        private MemoryStream m_bytesReceived;
        private ByteEncoding m_byteEncoding;

        public MacrodyneController()
        {
            InitializeComponent();

            m_bytesToSend = new MemoryStream();
            m_bytesReceived = new MemoryStream();
        }

        private void MacrodyneController_Load(object sender, EventArgs e)
        {
            // Update version label
            Version version = AssemblyInfo.EntryAssembly.Version;
            LabelVersion.Text = "Version " + version.Major + "." + version.Minor + "." + version.Build + "." + version.Revision;

            // Initialize serial port selection lists
            foreach (string port in SerialPort.GetPortNames())
            {
                ComboBoxSerialPorts.Items.Add(port);
            }

            foreach (string parity in Enum.GetNames(typeof(Parity)))
            {
                ComboBoxSerialParities.Items.Add(parity);
            }

            foreach (string stopbit in Enum.GetNames(typeof(StopBits)))
            {
                ComboBoxSerialStopBits.Items.Add(stopbit);
            }

            if (ComboBoxSerialPorts.Items.Count > 0)
                ComboBoxSerialPorts.SelectedIndex = 0;

            ComboBoxSerialBaudRates.SelectedIndex = 0;
            ComboBoxSerialParities.SelectedIndex = 0;
            ComboBoxSerialStopBits.SelectedIndex = 1;

            // Initialize command enumerations
            foreach (DeviceCommand command in Enum.GetValues(typeof(DeviceCommand)).Cast<DeviceCommand>())
            {
                if (command != DeviceCommand.Undefined)
                    ComboBoxCommands.Items.Add(new CommandItem(command));
            }

            ComboBoxCommands.SelectedIndex = 0;

            foreach (DataInputCommand command in Enum.GetValues(typeof(DataInputCommand)).Cast<DataInputCommand>())
            {
                if (command != DataInputCommand.SendReferencePhasor)
                    ComboBoxDataInputs.Items.Add(new DataInputItem(command));
            }

            ComboBoxDataInputs.SelectedIndex = 0;
            ComboBoxByteEncodingDisplayFormats.SelectedIndex = 0;

            this.RestoreLayout();
        }

        private void MacrodyneController_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
            this.SaveLayout();
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            if (m_serialClient == null)
            {
                Connect();
                ButtonConnect.Text = "Dis&connect";
            }
            else
            {
                Disconnect();
                ButtonConnect.Text = "&Connect";
            }
        }

        private void ButtonAddCommand_Click(object sender, EventArgs e)
        {
            // Add device command bytes to stream
            m_bytesToSend.Write(EndianOrder.BigEndian.GetBytes((ushort)(ComboBoxCommands.SelectedItem as CommandItem).Command), 0, 2);
            RefreshSendReceiveByteDisplays();
        }

        private void ComboBoxDataInputs_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((ComboBoxDataInputs.SelectedItem as DataInputItem).Command)
            {
                case DataInputCommand.SendWordData:
                    TextBoxData.Text = "0";
                    TextBoxData.Mask = "99999";
                    TextBoxData.ValidatingType = typeof(ushort);
                    LabelInDecimal.Visible = true;
                    break;
                case DataInputCommand.SendUnitIDData:
                    TextBoxData.Text = "";
                    TextBoxData.Mask = "CCCCCCCC";
                    TextBoxData.ValidatingType = typeof(string);
                    LabelInDecimal.Visible = false;
                    break;
                case DataInputCommand.SendByteData:
                    TextBoxData.Text = "0";
                    TextBoxData.Mask = "999";
                    TextBoxData.ValidatingType = typeof(byte);
                    LabelInDecimal.Visible = true;
                    break;
            }
        }

        private void TextBoxData_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                TextBoxData.Text = "";
                e.Cancel = true;
            }
        }

        private void TextBoxData_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = ButtonAddInput;
        }

        private void TextBoxData_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = ButtonConnect;
        }

        private void ButtonAddInput_Click(object sender, EventArgs e)
        {
            string data = TextBoxData.Text.Trim();

            if (data.Length > 0)
            {
                MemoryStream inputData = new MemoryStream();

                // Add data input command bytes to stream
                inputData.WriteByte((byte)(ComboBoxDataInputs.SelectedItem as DataInputItem).Command);

                // Add user data to stream
                switch ((ComboBoxDataInputs.SelectedItem as DataInputItem).Command)
                {
                    case DataInputCommand.SendWordData:
                        inputData.Write(EndianOrder.BigEndian.GetBytes(ushort.Parse(data)), 0, 2);
                        break;
                    case DataInputCommand.SendUnitIDData:
                        inputData.Write(Encoding.ASCII.GetBytes(data.PadRight(8)), 0, 8);
                        break;
                    case DataInputCommand.SendByteData:
                        inputData.WriteByte(byte.Parse(data));
                        break;
                }

                inputData.WriteByte(inputData.ToArray().Xor8Checksum(1, (int)inputData.Length - 1));
                inputData.WriteTo(m_bytesToSend);

                RefreshSendReceiveByteDisplays();
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            m_bytesToSend = new MemoryStream();
            RefreshSendReceiveByteDisplays();
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            if (m_serialClient != null & m_bytesToSend.Length > 0)
            {
                m_serialClient.SendAsync(m_bytesToSend.ToArray());
                UpdateStatus(m_bytesToSend.Length + " bytes sent.");
            }

            m_bytesToSend = new MemoryStream();
            RefreshSendReceiveByteDisplays();
        }

        private void ComboBoxByteEncodingDisplayFormats_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ComboBoxByteEncodingDisplayFormats.SelectedIndex)
            {
                case 0:
                    m_byteEncoding = ByteEncoding.Hexadecimal;
                    break;
                case 1:
                    m_byteEncoding = ByteEncoding.Decimal;
                    break;
                case 2:
                    m_byteEncoding = ByteEncoding.BigEndianBinary;
                    break;
                case 3:
                    m_byteEncoding = ByteEncoding.LittleEndianBinary;
                    break;
                case 4:
                    m_byteEncoding = ByteEncoding.Base64;
                    break;
                case 5:
                    m_byteEncoding = ByteEncoding.ASCII;
                    break;
                default:
                    m_byteEncoding = ByteEncoding.Hexadecimal;
                    break;
            }

            RefreshSendReceiveByteDisplays();
        }

        private void RefreshSendReceiveByteDisplays()
        {
            // Cross thread delegate invocation
            Invoke(new EventHandler(RefreshSendReceiveByteDisplays), this, EventArgs.Empty);
        }

        private void RefreshSendReceiveByteDisplays(object sender, EventArgs e)
        {
            if (m_byteEncoding == ByteEncoding.ASCII)
            {
                TextBoxBytesToSend.Text = m_byteEncoding.GetString(m_bytesToSend.ToArray()).RemoveControlCharacters();
                TextBoxBytesReceived.Text = m_byteEncoding.GetString(m_bytesReceived.ToArray()).RemoveControlCharacters();
            }
            else
            {
                TextBoxBytesToSend.Text = m_byteEncoding.GetString(m_bytesToSend.ToArray(), ' ');
                TextBoxBytesReceived.Text = m_byteEncoding.GetString(m_bytesReceived.ToArray(), ' ');
            }
        }

        private void UpdateStatus(string message)
        {
            // Cross thread delegate invocation
            Invoke(new EventHandler<EventArgs<string>>(UpdateStatus), this, new EventArgs<string>(message));
        }

        private void UpdateStatus(object sender, EventArgs<string> e)
        {
            StringBuilder statusText = new StringBuilder();

            statusText.Append(TextBoxStatus.Text);
            statusText.Append(e.Argument);
            statusText.Append(Environment.NewLine);

            TextBoxStatus.Text = statusText.ToString().TruncateLeft(TextBoxStatus.MaxLength);
            TextBoxStatus.SelectionStart = TextBoxStatus.Text.Length;
            TextBoxStatus.ScrollToCaret();
        }

        private void Connect()
        {
            if (m_serialClient != null)
                Disconnect();

            string connectionString =
                            "port=" + ComboBoxSerialPorts.Text +
                            "; baudrate=" + ComboBoxSerialBaudRates.Text +
                            "; parity=" + ComboBoxSerialParities.Text +
                            "; stopbits=" + ComboBoxSerialStopBits.Text +
                            "; databits=" + TextBoxSerialDataBits.Text +
                            "; dtrenable=" + CheckBoxSerialDTR.Checked.ToString() +
                            "; rtsenable=" + CheckBoxSerialRTS.Checked.ToString();

            // Wire up serial client events
            m_serialClient = new SerialClient();
            m_serialClient.SettingsCategory = ComboBoxSerialPorts.Text;
            m_serialClient.ConnectionAttempt += m_serialClient_ConnectionAttempt;
            m_serialClient.ConnectionEstablished += m_serialClient_ConnectionEstablished;
            m_serialClient.ConnectionException += m_serialClient_ConnectionException;
            m_serialClient.ConnectionTerminated += m_serialClient_ConnectionTerminated;
            m_serialClient.ReceiveDataComplete += m_serialClient_ReceiveDataComplete;
            m_serialClient.ReceiveDataException += m_serialClient_ReceiveDataException;
            m_serialClient.SendDataComplete += m_serialClient_SendDataComplete;
            m_serialClient.SendDataException += m_serialClient_SendDataException;
            m_serialClient.ConnectionString = connectionString;
            m_serialClient.ConnectAsync();
        }

        private void Disconnect()
        {
            if (m_serialClient != null)
            {
                // Unwire serial client events
                m_serialClient.Disconnect();
                m_serialClient.ConnectionAttempt -= m_serialClient_ConnectionAttempt;
                m_serialClient.ConnectionEstablished -= m_serialClient_ConnectionEstablished;
                m_serialClient.ConnectionException -= m_serialClient_ConnectionException;
                m_serialClient.ConnectionTerminated -= m_serialClient_ConnectionTerminated;
                m_serialClient.ReceiveDataComplete -= m_serialClient_ReceiveDataComplete;
                m_serialClient.ReceiveDataException -= m_serialClient_ReceiveDataException;
                m_serialClient.SendDataComplete -= m_serialClient_SendDataComplete;
                m_serialClient.SendDataException -= m_serialClient_SendDataException;
                m_serialClient.Dispose();
                m_serialClient = null;
            }
        }

        private void LinkLabelMacrodyne_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.macrodyneusa.com/model_1690.htm");
        }

        private void PictureBoxLogo_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.gridprotectionalliance.org/");
        }

        // The serial client event handler are invoked from another thread, be sure any calls back to main
        // form are invoked as needed...

        void m_serialClient_SendDataException(object sender, EventArgs<Exception> e)
        {
            UpdateStatus("Exception encountered while sending data to connection on " + m_serialClient.Name + ": " + e.Argument.Message);
        }

        void m_serialClient_SendDataComplete(object sender, EventArgs e)
        {
            UpdateStatus("Data send successful.");
        }

        void m_serialClient_ConnectionTerminated(object sender, EventArgs e)
        {
            UpdateStatus("Connection to " + m_serialClient.Name + " terminated.");
        }

        void m_serialClient_ReceiveDataException(object sender, EventArgs<Exception> e)
        {
            UpdateStatus("Exception encountered while receiving data from connection on " + m_serialClient.Name + ": " + e.Argument.Message);
        }

        void m_serialClient_ReceiveDataComplete(object sender, EventArgs<byte[], int> e)
        {
            m_bytesReceived = new MemoryStream(e.Argument1, 0, e.Argument2);
            RefreshSendReceiveByteDisplays();
            UpdateStatus(e.Argument2 + " bytes received.");
        }

        void m_serialClient_ConnectionException(object sender, EventArgs<Exception> e)
        {
            UpdateStatus("Exception encountered while attempting connection to " + m_serialClient.Name + ": " + e.Argument.Message);
        }

        void m_serialClient_ConnectionEstablished(object sender, EventArgs e)
        {
            UpdateStatus("Connection to " + m_serialClient.Name + " established.");
        }

        void m_serialClient_ConnectionAttempt(object sender, EventArgs e)
        {
            UpdateStatus("Attempting connection to " + m_serialClient.Name + "...");
        }
    }
}
