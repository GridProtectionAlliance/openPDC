//*******************************************************************************************************
//  CommandChannelServer.cs - Gbtc
//
//  Tennessee Valley Authority, 2009
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  This software is made freely available under the TVA Open Source Agreement (see below).
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  07/22/2009 - J. Ritchie Carroll
//       Generated original version of source code.
//  09/15/2009 - Stephen C. Wills
//       Added new header and license agreement.
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
using System.Text;
using NASPInet.Packets;
using TVA;
using TVA.Communication;

namespace NASPInet.Channels
{
    /// <summary>
    /// Represents a server based command channel.
    /// </summary>
    public class CommandChannelServer : ISupportLifecycle, IProvideStatus
    {
        #region [ Members ]

        // Events

        /// <summary>
        /// Provides status messages to consumer.
        /// </summary>
        /// <remarks>
        /// <see cref="EventArgs{T}.Argument"/> is new status message.
        /// </remarks>
        public event EventHandler<EventArgs<string>> StatusMessage;

        /// <summary>
        /// Occurs when a client connects to the server.
        /// </summary>
        /// <remarks>
        /// <see cref="EventArgs{T}.Argument"/> is the <see cref="Guid"/> connection ID of the client that connected to the server.
        /// </remarks>
        public event EventHandler<EventArgs<Guid>> ClientConnected;

        /// <summary>
        /// Occurs when a client disconnects from the server.
        /// </summary>
        /// <remarks>
        /// <see cref="EventArgs{T}.Argument"/> is the <see cref="Guid"/> connection ID of the client that disconnected from the server.
        /// </remarks>
        public event EventHandler<EventArgs<Guid>> ClientDisconnected;

        /// <summary>
        /// Event is raised when there is an exception encountered while processing.
        /// </summary>
        /// <remarks>
        /// <see cref="EventArgs{T}.Argument"/> is the exception that was thrown.
        /// </remarks>
        public event EventHandler<EventArgs<Exception>> ProcessException;

        /// <summary>
        /// Event is raised when a new <see cref="RequestPacket"/> is received.
        /// </summary>
        /// <remarks>
        /// <see cref="EventArgs{T1, T2}.Argument1"/> is the <see cref="Guid"/> connection ID of client that sent request.<br/>
        /// <see cref="EventArgs{T1, T2}.Argument2"/> is the <see cref="RequestPacket"/> that was received.
        /// </remarks>
        public event EventHandler<EventArgs<Guid, RequestPacket>> ReceivedRequestPacket;

        /// <summary>
        /// Event is raised when a new <see cref="ResponsePacket"/> is received.
        /// </summary>
        /// <remarks>
        /// <see cref="EventArgs{T1, T2}.Argument1"/> is the <see cref="Guid"/> connection ID of client that sent response.<br/>
        /// <see cref="EventArgs{T1, T2}.Argument2"/> is the <see cref="ResponsePacket"/> that was received.
        /// </remarks>
        public event EventHandler<EventArgs<Guid, ResponsePacket>> ReceivedResponsePacket;

        // Fields
        private TcpServer m_commandChannel;
        private CommandPacketParser m_commandParser;
        private System.Timers.Timer m_connectionTimer;
        private string m_name;
        private string m_connectionString;
        private bool m_enabled;
        private bool m_disposed;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new <see cref="CommandChannelServer"/>.
        /// </summary>
        public CommandChannelServer()
        {
            m_name = this.GetType().Name;
        }

        /// <summary>
        /// Releases the unmanaged resources before the <see cref="CommandChannelServer"/> object is reclaimed by <see cref="GC"/>.
        /// </summary>
        ~CommandChannelServer()
        {
            Dispose(false);
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets the name of this <see cref="CommandChannelServer"/>.
        /// </summary>
        public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
            }
        }

        /// <summary>
        /// Gets or sets connection string for this <see cref="CommandChannelServer"/>.
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return m_connectionString;
            }
            set
            {
                m_connectionString = value;
            }
        }

        /// <summary>
        /// Gets or sets enabled state of this <see cref="CommandChannelServer"/>.
        /// </summary>
        public bool Enabled
        {
            get
            {
                return m_enabled;
            }
            set
            {
                if (m_enabled && !value)
                    Stop();
                else if (!m_enabled && value)
                    Start();
            }
        }

        /// <summary>
        /// Gets a flag that determines if the command channel for this <see cref="CommandChannelServer"/> is running.
        /// </summary>
        public bool IsRunning
        {
            get
            {
                if (m_commandChannel != null)
                    return (m_commandChannel.CurrentState == ServerState.Running);

                return false;
            }
        }

        /// <summary>
        /// Gets the <see cref="Guid"/> connection ID's of the clients connected to this <see cref="CommandChannelServer"/>.
        /// </summary>
        public Guid[] ClientIDs
        {
            get
            {
                if (m_commandChannel == null)
                    return null;

                return m_commandChannel.ClientIDs;
            }
        }

        /// <summary>
        /// Gets the status of this <see cref="CommandChannelServer"/>.
        /// </summary>
        /// <remarks>
        /// Derived classes should provide current status information about the adapter for display purposes.
        /// </remarks>
        public string Status
        {
            get
            {
                StringBuilder status = new StringBuilder();

                status.AppendFormat("      Command channel name: {0}", Name);
                status.AppendLine();
                status.AppendFormat("         Operational state: {0}", Enabled ? "Running" : "Stopped");
                status.AppendLine();

                if (m_commandChannel != null)
                    status.Append(m_commandChannel.Status);

                if (m_commandParser != null)
                    status.Append(m_commandParser.Status);

                return status.ToString();
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Releases all the resources used by the <see cref="CommandChannelServer"/> object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="CommandChannelServer"/> object and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                try
                {
                    if (disposing)
                    {
                        if (m_connectionTimer != null)
                        {
                            m_connectionTimer.Elapsed -= m_connectionTimer_Elapsed;
                            m_connectionTimer.Dispose();
                        }
                        m_connectionTimer = null;

                        if (m_commandChannel != null)
                        {
                            m_commandChannel.ClientConnected -= m_commandChannel_ClientConnected;
                            m_commandChannel.ClientDisconnected -= m_commandChannel_ClientDisconnected;
                            m_commandChannel.ServerStarted -= m_commandChannel_ServerStarted;
                            m_commandChannel.ServerStopped -= m_commandChannel_ServerStopped;
                            m_commandChannel.SendClientDataException -= m_commandChannel_SendClientDataException;
                            m_commandChannel.ReceiveClientDataException -= m_commandChannel_ReceiveClientDataException;
                            m_commandChannel.Dispose();
                        }
                        m_commandChannel = null;

                        if (m_commandParser != null)
                        {
                            m_commandParser.DataParsed -= m_commandParser_DataParsed;
                            m_commandParser.DataDiscarded -= m_commandParser_DataDiscarded;
                            m_commandParser.ParsingException -= m_commandParser_ParsingException;
                            m_commandParser.Dispose();
                        }
                        m_commandParser = null;
                    }
                }
                finally
                {
                    m_disposed = true;  // Prevent duplicate dispose.
                }
            }
        }

        /// <summary>
        /// Initialize this <see cref="CommandChannelServer"/>.
        /// </summary>
        public void Initialize()
        {
            if (m_connectionString == null)
                throw new NullReferenceException("Connection string has not been defined.");

            // Initialize command parser
            m_commandParser = new CommandPacketParser();
            m_commandParser.DataParsed += m_commandParser_DataParsed;
            m_commandParser.DataDiscarded += m_commandParser_DataDiscarded;
            m_commandParser.ParsingException += m_commandParser_ParsingException;

            // Initialize command channel
            m_commandChannel = new TcpServer(m_connectionString);
            m_commandChannel.ClientConnected += m_commandChannel_ClientConnected;
            m_commandChannel.ClientDisconnected += m_commandChannel_ClientDisconnected;
            m_commandChannel.ServerStarted += m_commandChannel_ServerStarted;
            m_commandChannel.ServerStopped += m_commandChannel_ServerStopped;
            m_commandChannel.SendClientDataException += m_commandChannel_SendClientDataException;
            m_commandChannel.ReceiveClientDataException += m_commandChannel_ReceiveClientDataException;

            // Send any data received from command channel to command parser
            m_commandChannel.ReceiveClientDataHandler = m_commandParser.Parse;

            // Initialize connection timer
            m_connectionTimer = new System.Timers.Timer();
            m_connectionTimer.Elapsed += m_connectionTimer_Elapsed;
            m_connectionTimer.AutoReset = false;
            m_connectionTimer.Interval = 2000;
            m_connectionTimer.Enabled = false;
        }

        /// <summary>
        /// Starts this <see cref="CommandChannelServer"/>.
        /// </summary>
        public void Start()
        {
            if (m_commandChannel == null || m_commandParser == null)
                throw new NullReferenceException("Command channel server has not been initialized.");

            Stop();

            m_enabled = true;

            // Start the connection cycle
            m_connectionTimer.Enabled = true;
        }

        /// <summary>
        /// Stops this <see cref="CommandChannelServer"/>.
        /// </summary>
        public void Stop()
        {
            if (m_commandChannel == null || m_commandParser == null)
                throw new NullReferenceException("Command channel server has not been initialized.");

            m_enabled = false;
            m_commandParser.Stop();
            m_commandChannel.Stop();
        }

        /// <summary>
        /// Sends request from this <see cref="CommandChannelServer"/>.
        /// </summary>
        /// <param name="connectionID">Client connection ID.</param>
        /// <param name="request"><see cref="Request"/> to send.</param>
        /// <param name="payload">Payload to send, if any.</param>
        public void SendRequest(Guid connectionID, Request request, byte[] payload)
        {
            // TODO: Lookup crypto properties for connection
            //SendRequest(connectionID, request, payload, m_symmetricAlgorithm, m_key, m_iv);
        }

        /// <summary>
        /// Sends request from this <see cref="CommandChannelServer"/>.
        /// </summary>
        /// <param name="connectionID">Client connection ID.</param>
        /// <param name="request"><see cref="Request"/> to send.</param>
        /// <param name="payload">Payload to send, if any.</param>
        /// <param name="cryptoProperties"><see cref="CryptoProperties"/> used to encrypt data.</param>
        public void SendRequest(Guid connectionID, Request request, byte[] payload, CryptoProperties cryptoProperties)
        {
            if (m_commandChannel == null)
                throw new NullReferenceException("Command channel server has not been initialized.");

            RequestPacket packet = new RequestPacket()
            {
                Request = request,
                Payload = payload
            };

            if (payload != null)
                packet.EncryptPayload(cryptoProperties);

            m_commandChannel.SendToAsync(connectionID, packet.BinaryImage);
        }

        /// <summary>
        /// Sends response from this <see cref="CommandChannelServer"/>.
        /// </summary>
        /// <param name="connectionID">Client connection ID.</param>
        /// <param name="requestID">Originating request ID for this response.</param>
        /// <param name="response"><see cref="Response"/> to send.</param>
        /// <param name="payload">Payload to send, if any.</param>
        public void SendResponse(Guid connectionID, Guid requestID, Response response, byte[] payload)
        {
            // TODO: Lookup crypto properties for connection
            //SendResponse(connectionID, requestID, response, payload, m_symmetricAlgorithm, m_key, m_iv);
        }

        /// <summary>
        /// Sends response from this <see cref="CommandChannelServer"/>.
        /// </summary>
        /// <param name="connectionID">Client connection ID.</param>
        /// <param name="requestID">Originating request ID for this response.</param>
        /// <param name="response"><see cref="Response"/> to send.</param>
        /// <param name="payload">Payload to send, if any.</param>
        /// <param name="cryptoProperties"><see cref="CryptoProperties"/> used to encrypt data.</param>
        public void SendResponse(Guid connectionID, Guid requestID, Response response, byte[] payload, CryptoProperties cryptoProperties)
        {
            if (m_commandChannel == null)
                throw new NullReferenceException("Command channel server has not been initialized.");

            ResponsePacket packet = new ResponsePacket()
            {
                RequestID = requestID,
                Response = response,
                Payload = payload
            };

            if (payload != null)
                packet.EncryptPayload(cryptoProperties);

            m_commandChannel.SendToAsync(connectionID, packet.BinaryImage);
        }

        /// <summary>
        /// Raises the <see cref="StatusMessage"/> event.
        /// </summary>
        /// <param name="status">New status message.</param>
        protected virtual void OnStatusMessage(string status)
        {
            if (StatusMessage != null)
                StatusMessage(this, new EventArgs<string>(string.Format("[{0}] {1}", Name, status)));
        }

        /// <summary>
        /// Raises the <see cref="StatusMessage"/> event with a formatted status message.
        /// </summary>
        /// <param name="formattedStatus">Formatted status message.</param>
        /// <param name="args">Arguments for <paramref name="formattedStatus"/>.</param>
        /// <remarks>
        /// This overload combines string.Format and SendStatusMessage for convienence.
        /// </remarks>
        protected virtual void OnStatusMessage(string formattedStatus, params object[] args)
        {
            OnStatusMessage(string.Format(formattedStatus, args));
        }

        /// <summary>
        /// Raises <see cref="ProcessException"/> event.
        /// </summary>
        /// <param name="ex">Processing <see cref="Exception"/>.</param>
        protected virtual void OnProcessException(Exception ex)
        {
            if (ProcessException != null)
                ProcessException(this, new EventArgs<Exception>(ex));
        }

        /// <summary>
        /// Raises the <see cref="ClientConnected"/> event.
        /// </summary>
        /// <param name="connectionID">Connection ID of client to send to <see cref="ClientConnected"/> event.</param>
        protected virtual void OnClientConnected(Guid connectionID)
        {
            if (ClientConnected != null)
                ClientConnected(this, new EventArgs<Guid>(connectionID));
        }

        /// <summary>
        /// Raises the <see cref="ClientDisconnected"/> event.
        /// </summary>
        /// <param name="connectionID">Connection ID of client to send to <see cref="ClientDisconnected"/> event.</param>
        protected virtual void OnClientDisconnected(Guid connectionID)
        {
            if (ClientDisconnected != null)
                ClientDisconnected(this, new EventArgs<Guid>(connectionID));
        }

        /// <summary>
        /// Raises the <see cref="ReceivedRequestPacket"/> event.
        /// </summary>
        /// <param name="connectionID">Client connection ID.</param>
        /// <param name="packet"><see cref="RequestPacket"/> received.</param>
        protected virtual void OnReceivedRequestPacket(Guid connectionID, RequestPacket packet)
        {
            if (ReceivedRequestPacket != null)
                ReceivedRequestPacket(this, new EventArgs<Guid, RequestPacket>(connectionID, packet));
        }

        /// <summary>
        /// Raises the <see cref="ReceivedResponsePacket"/> event.
        /// </summary>
        /// <param name="connectionID">Client connection ID.</param>
        /// <param name="packet"><see cref="ResponsePacket"/> received.</param>
        protected virtual void OnReceivedResponsePacket(Guid connectionID, ResponsePacket packet)
        {
            if (ReceivedResponsePacket != null)
                ReceivedResponsePacket(this, new EventArgs<Guid, ResponsePacket>(connectionID, packet));
        }

        #region [ Connection Timer Event Hander ]

        private void m_connectionTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                OnStatusMessage("Attempting to establish server...");

                // Attempt connection to data source
                m_commandChannel.Start();
                m_commandParser.Start();

                OnStatusMessage("Server established.");
            }
            catch (Exception ex)
            {
                OnProcessException(new InvalidOperationException(string.Format("Server setup attempt failed: {0}", ex.Message), ex));

                // So long as user hasn't requested to stop, keep trying connection
                if (Enabled)
                    Start();
            }
        }

        #endregion

        #region [ Command Parser Event Handlers ]

        // Expose command packets as their native types (i.e., request and response packets)
        private void m_commandParser_DataParsed(object sender, EventArgs<Guid, IList<CommandPacketBase>> e)
        {
            // If there were multiple commands in the stream, we raise an event for each
            foreach (CommandPacketBase packet in e.Argument2)
            {
                switch (packet.TypeID)
                {
                    case CommandPacketType.Request:
                        OnReceivedRequestPacket(e.Argument1, packet as RequestPacket);
                        break;
                    case CommandPacketType.Response:
                        OnReceivedResponsePacket(e.Argument1, packet as ResponsePacket);
                        break;
                }
            }
        }

        private void m_commandParser_DataDiscarded(object sender, EventArgs<byte[]> e)
        {
            OnStatusMessage("WARNING: {0} bytes of unrecognized command data were discarded.", e.Argument.Length);
        }

        private void m_commandParser_ParsingException(object sender, EventArgs<Exception> e)
        {
            OnProcessException(e.Argument);
        }

        #endregion

        #region [ Command Channel Event Handlers ]

        private void m_commandChannel_ClientConnected(object sender, EventArgs<Guid> e)
        {
            OnClientConnected(e.Argument);
        }

        private void m_commandChannel_ClientDisconnected(object sender, EventArgs<Guid> e)
        {
            Guid connectionID = e.Argument;

            // Purge any left over parsing buffer on disconnect
            m_commandParser.PurgeBuffer(connectionID);

            OnClientDisconnected(connectionID);
        }

        private void m_commandChannel_ServerStarted(object sender, EventArgs e)
        {
            OnStatusMessage("Server started and listening for connections...");
        }

        private void m_commandChannel_ServerStopped(object sender, EventArgs e)
        {
            OnStatusMessage("Server stopped.");
        }

        private void m_commandChannel_SendClientDataException(object sender, EventArgs<Guid, Exception> e)
        {
            Exception ex = e.Argument2;
            OnProcessException(new Exception(string.Format("Send data exception from client {{{0}}}: {1}", e.Argument1, ex.Message), ex));
        }

        private void m_commandChannel_ReceiveClientDataException(object sender, EventArgs<Guid, Exception> e)
        {
            Exception ex = e.Argument2;
            OnProcessException(new Exception(string.Format("Receive data exception from client {{{0}}}: {1}", e.Argument1, ex.Message), ex));
        }

        #endregion

        #endregion
    }
}
