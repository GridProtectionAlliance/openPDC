//*******************************************************************************************************
//  ConnectionStringBuilder.xaml.cs - Gbtc
//
//  Tennessee Valley Authority, 2010
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  This software is made freely available under the TVA Open Source Agreement (see below).
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  04/21/2010 - Mehulbhai P. Thakkar
//       Generated original version of source code.
//
//*******************************************************************************************************

#region [ TVA Open Source Agreement ]
/*

 THIS OPEN SOURCE AGREEMENT ("AGREEMENT") DEFINES THE RIGHTS OF USE,REPRODUCTION, DISTRIBUTION,
 MODIFICATION AND REDISTRIBUTION OF CERTAIN COMPUTER SOFTWARE ORIGINALLY RELEASED BY THE
 TENNESSEE VALLEY AUTHORITY, A CORPORATE AGENCY AND INSTRUMENTALITY OF THE UNITED STATES GOVERNMENT
 ("GOVERNMENT AGENCY"). GOVERNMENT AGENCY IS AN INTENDED THIRD-PARTY BENEFICIARY OF ALL SUBSEQUENT
 DISTRIBUTIONS OR REDISTRIBUTIONS OF THE SUBJECT SOFTWARE. ANYONE WHO USES, REPRODUCES, DISTRIBUTES,
 MODIFIES OR REDISTRIBUTES THE SUBJECT SOFTWARE, AS DEFINED HEREIN, OR ANY PART THEREOF, IS, BY THAT
 ACTION, ACCEPTING IN FULL THE RESPONSIBILITIES AND OBLIGATIONS CONTAINED IN THIS AGREEMENT.

 Original Software Designation: openPDC
 Original Software Title: The TVA Open Source Phasor Data Concentrator
 User Registration Requested. Please Visit https://naspi.tva.com/Registration/
 Point of Contact for Original Software: J. Ritchie Carroll <mailto:jrcarrol@tva.gov>

 1. DEFINITIONS

 A. "Contributor" means Government Agency, as the developer of the Original Software, and any entity
 that makes a Modification.

 B. "Covered Patents" mean patent claims licensable by a Contributor that are necessarily infringed by
 the use or sale of its Modification alone or when combined with the Subject Software.

 C. "Display" means the showing of a copy of the Subject Software, either directly or by means of an
 image, or any other device.

 D. "Distribution" means conveyance or transfer of the Subject Software, regardless of means, to
 another.

 E. "Larger Work" means computer software that combines Subject Software, or portions thereof, with
 software separate from the Subject Software that is not governed by the terms of this Agreement.

 F. "Modification" means any alteration of, including addition to or deletion from, the substance or
 structure of either the Original Software or Subject Software, and includes derivative works, as that
 term is defined in the Copyright Statute, 17 USC § 101. However, the act of including Subject Software
 as part of a Larger Work does not in and of itself constitute a Modification.

 G. "Original Software" means the computer software first released under this Agreement by Government
 Agency entitled openPDC, including source code, object code and accompanying documentation, if any.

 H. "Recipient" means anyone who acquires the Subject Software under this Agreement, including all
 Contributors.

 I. "Redistribution" means Distribution of the Subject Software after a Modification has been made.

 J. "Reproduction" means the making of a counterpart, image or copy of the Subject Software.

 K. "Sale" means the exchange of the Subject Software for money or equivalent value.

 L. "Subject Software" means the Original Software, Modifications, or any respective parts thereof.

 M. "Use" means the application or employment of the Subject Software for any purpose.

 2. GRANT OF RIGHTS

 A. Under Non-Patent Rights: Subject to the terms and conditions of this Agreement, each Contributor,
 with respect to its own contribution to the Subject Software, hereby grants to each Recipient a
 non-exclusive, world-wide, royalty-free license to engage in the following activities pertaining to
 the Subject Software:

 1. Use

 2. Distribution

 3. Reproduction

 4. Modification

 5. Redistribution

 6. Display

 B. Under Patent Rights: Subject to the terms and conditions of this Agreement, each Contributor, with
 respect to its own contribution to the Subject Software, hereby grants to each Recipient under Covered
 Patents a non-exclusive, world-wide, royalty-free license to engage in the following activities
 pertaining to the Subject Software:

 1. Use

 2. Distribution

 3. Reproduction

 4. Sale

 5. Offer for Sale

 C. The rights granted under Paragraph B. also apply to the combination of a Contributor's Modification
 and the Subject Software if, at the time the Modification is added by the Contributor, the addition of
 such Modification causes the combination to be covered by the Covered Patents. It does not apply to
 any other combinations that include a Modification. 

 D. The rights granted in Paragraphs A. and B. allow the Recipient to sublicense those same rights.
 Such sublicense must be under the same terms and conditions of this Agreement.

 3. OBLIGATIONS OF RECIPIENT

 A. Distribution or Redistribution of the Subject Software must be made under this Agreement except for
 additions covered under paragraph 3H. 

 1. Whenever a Recipient distributes or redistributes the Subject Software, a copy of this Agreement
 must be included with each copy of the Subject Software; and

 2. If Recipient distributes or redistributes the Subject Software in any form other than source code,
 Recipient must also make the source code freely available, and must provide with each copy of the
 Subject Software information on how to obtain the source code in a reasonable manner on or through a
 medium customarily used for software exchange.

 B. Each Recipient must ensure that the following copyright notice appears prominently in the Subject
 Software:

          No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.

 C. Each Contributor must characterize its alteration of the Subject Software as a Modification and
 must identify itself as the originator of its Modification in a manner that reasonably allows
 subsequent Recipients to identify the originator of the Modification. In fulfillment of these
 requirements, Contributor must include a file (e.g., a change log file) that describes the alterations
 made and the date of the alterations, identifies Contributor as originator of the alterations, and
 consents to characterization of the alterations as a Modification, for example, by including a
 statement that the Modification is derived, directly or indirectly, from Original Software provided by
 Government Agency. Once consent is granted, it may not thereafter be revoked.

 D. A Contributor may add its own copyright notice to the Subject Software. Once a copyright notice has
 been added to the Subject Software, a Recipient may not remove it without the express permission of
 the Contributor who added the notice.

 E. A Recipient may not make any representation in the Subject Software or in any promotional,
 advertising or other material that may be construed as an endorsement by Government Agency or by any
 prior Recipient of any product or service provided by Recipient, or that may seek to obtain commercial
 advantage by the fact of Government Agency's or a prior Recipient's participation in this Agreement.

 F. In an effort to track usage and maintain accurate records of the Subject Software, each Recipient,
 upon receipt of the Subject Software, is requested to register with Government Agency by visiting the
 following website: https://naspi.tva.com/Registration/. Recipient's name and personal information
 shall be used for statistical purposes only. Once a Recipient makes a Modification available, it is
 requested that the Recipient inform Government Agency at the web site provided above how to access the
 Modification.

 G. Each Contributor represents that that its Modification does not violate any existing agreements,
 regulations, statutes or rules, and further that Contributor has sufficient rights to grant the rights
 conveyed by this Agreement.

 H. A Recipient may choose to offer, and to charge a fee for, warranty, support, indemnity and/or
 liability obligations to one or more other Recipients of the Subject Software. A Recipient may do so,
 however, only on its own behalf and not on behalf of Government Agency or any other Recipient. Such a
 Recipient must make it absolutely clear that any such warranty, support, indemnity and/or liability
 obligation is offered by that Recipient alone. Further, such Recipient agrees to indemnify Government
 Agency and every other Recipient for any liability incurred by them as a result of warranty, support,
 indemnity and/or liability offered by such Recipient.

 I. A Recipient may create a Larger Work by combining Subject Software with separate software not
 governed by the terms of this agreement and distribute the Larger Work as a single product. In such
 case, the Recipient must make sure Subject Software, or portions thereof, included in the Larger Work
 is subject to this Agreement.

 J. Notwithstanding any provisions contained herein, Recipient is hereby put on notice that export of
 any goods or technical data from the United States may require some form of export license from the
 U.S. Government. Failure to obtain necessary export licenses may result in criminal liability under
 U.S. laws. Government Agency neither represents that a license shall not be required nor that, if
 required, it shall be issued. Nothing granted herein provides any such export license.

 4. DISCLAIMER OF WARRANTIES AND LIABILITIES; WAIVER AND INDEMNIFICATION

 A. No Warranty: THE SUBJECT SOFTWARE IS PROVIDED "AS IS" WITHOUT ANY WARRANTY OF ANY KIND, EITHER
 EXPRESSED, IMPLIED, OR STATUTORY, INCLUDING, BUT NOT LIMITED TO, ANY WARRANTY THAT THE SUBJECT
 SOFTWARE WILL CONFORM TO SPECIFICATIONS, ANY IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
 PARTICULAR PURPOSE, OR FREEDOM FROM INFRINGEMENT, ANY WARRANTY THAT THE SUBJECT SOFTWARE WILL BE ERROR
 FREE, OR ANY WARRANTY THAT DOCUMENTATION, IF PROVIDED, WILL CONFORM TO THE SUBJECT SOFTWARE. THIS
 AGREEMENT DOES NOT, IN ANY MANNER, CONSTITUTE AN ENDORSEMENT BY GOVERNMENT AGENCY OR ANY PRIOR
 RECIPIENT OF ANY RESULTS, RESULTING DESIGNS, HARDWARE, SOFTWARE PRODUCTS OR ANY OTHER APPLICATIONS
 RESULTING FROM USE OF THE SUBJECT SOFTWARE. FURTHER, GOVERNMENT AGENCY DISCLAIMS ALL WARRANTIES AND
 LIABILITIES REGARDING THIRD-PARTY SOFTWARE, IF PRESENT IN THE ORIGINAL SOFTWARE, AND DISTRIBUTES IT
 "AS IS."

 B. Waiver and Indemnity: RECIPIENT AGREES TO WAIVE ANY AND ALL CLAIMS AGAINST GOVERNMENT AGENCY, ITS
 AGENTS, EMPLOYEES, CONTRACTORS AND SUBCONTRACTORS, AS WELL AS ANY PRIOR RECIPIENT. IF RECIPIENT'S USE
 OF THE SUBJECT SOFTWARE RESULTS IN ANY LIABILITIES, DEMANDS, DAMAGES, EXPENSES OR LOSSES ARISING FROM
 SUCH USE, INCLUDING ANY DAMAGES FROM PRODUCTS BASED ON, OR RESULTING FROM, RECIPIENT'S USE OF THE
 SUBJECT SOFTWARE, RECIPIENT SHALL INDEMNIFY AND HOLD HARMLESS  GOVERNMENT AGENCY, ITS AGENTS,
 EMPLOYEES, CONTRACTORS AND SUBCONTRACTORS, AS WELL AS ANY PRIOR RECIPIENT, TO THE EXTENT PERMITTED BY
 LAW.  THE FOREGOING RELEASE AND INDEMNIFICATION SHALL APPLY EVEN IF THE LIABILITIES, DEMANDS, DAMAGES,
 EXPENSES OR LOSSES ARE CAUSED, OCCASIONED, OR CONTRIBUTED TO BY THE NEGLIGENCE, SOLE OR CONCURRENT, OF
 GOVERNMENT AGENCY OR ANY PRIOR RECIPIENT.  RECIPIENT'S SOLE REMEDY FOR ANY SUCH MATTER SHALL BE THE
 IMMEDIATE, UNILATERAL TERMINATION OF THIS AGREEMENT.

 5. GENERAL TERMS

 A. Termination: This Agreement and the rights granted hereunder will terminate automatically if a
 Recipient fails to comply with these terms and conditions, and fails to cure such noncompliance within
 thirty (30) days of becoming aware of such noncompliance. Upon termination, a Recipient agrees to
 immediately cease use and distribution of the Subject Software. All sublicenses to the Subject
 Software properly granted by the breaching Recipient shall survive any such termination of this
 Agreement.

 B. Severability: If any provision of this Agreement is invalid or unenforceable under applicable law,
 it shall not affect the validity or enforceability of the remainder of the terms of this Agreement.

 C. Applicable Law: This Agreement shall be subject to United States federal law only for all purposes,
 including, but not limited to, determining the validity of this Agreement, the meaning of its
 provisions and the rights, obligations and remedies of the parties.

 D. Entire Understanding: This Agreement constitutes the entire understanding and agreement of the
 parties relating to release of the Subject Software and may not be superseded, modified or amended
 except by further written agreement duly executed by the parties.

 E. Binding Authority: By accepting and using the Subject Software under this Agreement, a Recipient
 affirms its authority to bind the Recipient to all terms and conditions of this Agreement and that
 Recipient hereby agrees to all terms and conditions herein.

 F. Point of Contact: Any Recipient contact with Government Agency is to be directed to the designated
 representative as follows: J. Ritchie Carroll <mailto:jrcarrol@tva.gov>.

*/
#endregion

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using openPDCManager.Silverlight.PhasorDataServiceProxy;
using openPDCManager.Silverlight.Utilities;

namespace openPDCManager.Silverlight.ModalDialogs
{
	public partial class ConnectionStringBuilder : ChildWindow
	{
		#region [ Members ]

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
			file
		}

		#endregion

		#region [ Constructor ]

		public ConnectionStringBuilder()
		{
			InitializeComponent();			
			m_client = Common.GetPhasorDataServiceProxyClient();
			//m_client.GetPortsCompleted += new System.EventHandler<GetPortsCompletedEventArgs>(m_client_GetPortsCompleted);
			m_client.GetStopBitsCompleted += new System.EventHandler<GetStopBitsCompletedEventArgs>(m_client_GetStopBitsCompleted);
			m_client.GetParitiesCompleted += new System.EventHandler<GetParitiesCompletedEventArgs>(m_client_GetParitiesCompleted);
			this.Loaded += new RoutedEventHandler(ConnectionStringBuilder_Loaded);
			ButtonSaveFile.Click += new RoutedEventHandler(ButtonSaveFile_Click);
			ButtonSaveTCP.Click += new RoutedEventHandler(ButtonSaveTCP_Click);
			ButtonSaveSerial.Click += new RoutedEventHandler(ButtonSaveSerial_Click);
			ButtonSaveUDP.Click += new RoutedEventHandler(ButtonSaveUDP_Click);
			ButtonBrowseFile.Click += new RoutedEventHandler(ButtonBrowseFile_Click);
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

		//void m_client_GetPortsCompleted(object sender, GetPortsCompletedEventArgs e)
		//{
		//    if (e.Error == null)
		//        ComboboxPort.ItemsSource = e.Result;
		//    if (ComboboxPort.Items.Count > 0)
		//        ComboboxPort.SelectedIndex = 0;
		//}

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
					keyvaluepairs.Add("server", TextBoxHostIPUdp.Text);
				else
					keyvaluepairs["server"] = TextBoxHostIPUdp.Text;

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
			if (!keyvaluepairs.ContainsKey("server"))
				keyvaluepairs.Add("server", String.IsNullOrEmpty(TextBoxHostIP.Text) ? "127.0.0.1" : TextBoxHostIP.Text);
			else
				keyvaluepairs["server"] = String.IsNullOrEmpty(TextBoxHostIP.Text) ? "127.0.0.1" : TextBoxHostIP.Text;

			if (!keyvaluepairs.ContainsKey("port"))
				keyvaluepairs.Add("port", String.IsNullOrEmpty(TextBoxPort.Text) ? "4712" : TextBoxPort.Text);
			else
				keyvaluepairs["port"] = String.IsNullOrEmpty(TextBoxPort.Text) ? "4712" : TextBoxPort.Text;

			if (!keyvaluepairs.ContainsKey("islistener"))
				keyvaluepairs.Add("islistener", CheckboxEstablishServer.IsChecked.ToString().ToLower());
			else
				keyvaluepairs["islistener"] = CheckboxEstablishServer.IsChecked.ToString().ToLower();

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

			// populate connection info	if already provided from the parent window
			ParseConnectionString();			
		}

		#endregion

		#region [ Methods ]

		void ParseConnectionString()
		{
			if (!string.IsNullOrEmpty(this.ConnectionString))
			{
				string[] keyvalues = this.ConnectionString.ToLower().Split(new char[] { ';' }, System.StringSplitOptions.RemoveEmptyEntries);				
				foreach (string keyvalue in keyvalues)
				{
					string[] keyvaluepair = keyvalue.Split(new char[] { '=' });
					if (keyvaluepair.GetLength(0) == 2)
					{
						keyvaluepairs.Add(keyvaluepair[0].Trim(), keyvaluepair[1].Trim());
					}
				}
				
				if ((keyvaluepairs.ContainsKey("transportprotocol") && keyvaluepairs["transportprotocol"].ToLower() == "tcp") || (keyvaluepairs.ContainsKey("protocol") && keyvaluepairs["protocol"].ToLower() == "tcp"))
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
				else if ((keyvaluepairs.ContainsKey("transportprotocol") && keyvaluepairs["transportprotocol"].ToLower() == "udp") || (keyvaluepairs.ContainsKey("protocol") && keyvaluepairs["protocol"].ToLower() == "udp"))
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
			if (!keyvaluepairs.ContainsKey("transportprotocol") && !keyvaluepairs.ContainsKey("protocol"))
				keyvaluepairs.Add("transportprotocol", transportProtocol.ToString());
			else if (keyvaluepairs.ContainsKey("transportprotocol"))
				keyvaluepairs["transportprotocol"] = transportProtocol.ToString();
			else if (keyvaluepairs.ContainsKey("protocol"))
				keyvaluepairs["protocol"] = transportProtocol.ToString();

			if ((bool)CheckboxForceIPv4.IsChecked)
			{
				if (!keyvaluepairs.ContainsKey("interface"))
					keyvaluepairs.Add("interface", "0.0.0.0");
				else
					keyvaluepairs["interface"] = "0.0.0.0";
			}

			m_connectionString = string.Empty;
			foreach (KeyValuePair<string, string> keyvalue in keyvaluepairs)
			{
				m_connectionString += keyvalue.Key + "=" + keyvalue.Value + "; ";
			}
		}

		#endregion

	}
}

