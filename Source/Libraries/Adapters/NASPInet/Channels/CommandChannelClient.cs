//*******************************************************************************************************
//  CommandChannelClient.cs
//  Copyright © 2009 - TVA, all rights reserved - Gbtc
//
//  Build Environment: C#, Visual Studio 2008
//  Primary Developer: James R. Carroll
//      Office: PSO PCS, CHATTANOOGA - MR BK-C
//       Phone: 423/751-4165
//       Email: jrcarrol@tva.gov
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  07/22/2009 - James R. Carroll
//       Generated original version of source code.
//
//*******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Text;
using NASPInet.Packets;
using TVA;
using TVA.Communication;

namespace NASPInet.Channels
{
    /// <summary>
    /// Represents a client connection to a server based command channel.
    /// </summary>
    public class CommandChannelClient : ISupportLifecycle, IProvideStatus
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
        /// <see cref="EventArgs{T}.Argument"/> is the <see cref="RequestPacket"/> that was received.
        /// </remarks>
        public event EventHandler<EventArgs<RequestPacket>> ReceivedRequestPacket;

        /// <summary>
        /// Event is raised when a new <see cref="ResponsePacket"/> is received.
        /// </summary>
        /// <remarks>
        /// <see cref="EventArgs{T}.Argument"/> is the <see cref="ResponsePacket"/> that was received.
        /// </remarks>
        public event EventHandler<EventArgs<ResponsePacket>> ReceivedResponsePacket;

        // Fields
        private TcpClient m_commandChannel;
        private CommandPacketParser m_commandParser;
        private System.Timers.Timer m_connectionTimer;
        private string m_name;
        private string m_connectionString;
        private byte[] m_identificationSequence;
        private CryptoProperties m_cryptoProperties;
        private bool m_enabled;
        private bool m_disposed;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new <see cref="CommandChannelClient"/>.
        /// </summary>
        public CommandChannelClient()
        {
            m_name = this.GetType().Name;
        }

        /// <summary>
        /// Releases the unmanaged resources before the <see cref="CommandChannelClient"/> object is reclaimed by <see cref="GC"/>.
        /// </summary>
        ~CommandChannelClient()
        {
            Dispose(false);
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets the name of this <see cref="CommandChannelClient"/>.
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
        /// Gets or sets connection string for this <see cref="CommandChannelClient"/>.
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
        /// Gets or sets identification sequence of this <see cref="CommandChannelClient"/>.
        /// </summary>
        /// <remarks>
        /// This might be the out-of-band assigned PG certificate used for a PG to verify its identity with the CA, or it may
        /// be a CA assigned identification token which a PG publisher would use to validate the identity of a PG subscriber.
        /// </remarks>
        public byte[] IdentificationSequence
        {
            get
            {
                return m_identificationSequence;
            }
            set
            {
                m_identificationSequence = value;
            }
        }

        /// <summary>
        /// Gets or sets enabled state of this <see cref="CommandChannelClient"/>.
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
        /// Gets a flag that determines if the command channel for this <see cref="CommandChannelClient"/> is connected.
        /// </summary>
        public bool IsConnected
        {
            get
            {
                if (m_commandChannel != null)
                    return (m_commandChannel.CurrentState == ClientState.Connected);

                return false;
            }
        }

        /// <summary>
        /// Gets or sets <see cref="CryptoProperties"/> used to encrypt or decrypt data for this <see cref="CommandChannelClient"/>.
        /// </summary>
        public CryptoProperties CryptoProperties
        {
            get
            {
                return m_cryptoProperties;
            }
            set
            {
                m_cryptoProperties = value;
            }
        }

        /// <summary>
        /// Gets the status of this <see cref="CommandChannelClient"/>.
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
        /// Releases all the resources used by the <see cref="CommandChannelClient"/> object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="CommandChannelClient"/> object and optionally releases the managed resources.
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
                            m_commandChannel.ConnectionTerminated -= m_commandChannel_ConnectionTerminated;
                            m_commandChannel.ConnectionException -= m_commandChannel_ConnectionException;
                            m_commandChannel.ReceiveDataException -= m_commandChannel_ReceiveDataException;
                            m_commandChannel.SendDataException -= m_commandChannel_SendDataException;
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
        /// Initialize this <see cref="CommandChannelClient"/>.
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
            m_commandChannel = new TcpClient(m_connectionString);
            m_commandChannel.ConnectionException += m_commandChannel_ConnectionException;
            m_commandChannel.ConnectionTerminated += m_commandChannel_ConnectionTerminated;
            m_commandChannel.ReceiveDataException += m_commandChannel_ReceiveDataException;
            m_commandChannel.SendDataException += m_commandChannel_SendDataException;

            // Send any data received from command channel to command parser
            m_commandChannel.ReceiveDataHandler = (buffer, offset, count) => m_commandParser.Parse(Guid.Empty, buffer, offset, count) ;

            // Initialize connection timer
            m_connectionTimer = new System.Timers.Timer();
            m_connectionTimer.Elapsed += m_connectionTimer_Elapsed;
            m_connectionTimer.AutoReset = false;
            m_connectionTimer.Interval = 2000;
            m_connectionTimer.Enabled = false;
        }

        /// <summary>
        /// Starts this <see cref="CommandChannelClient"/>.
        /// </summary>
        public void Start()
        {
            if (m_commandChannel == null || m_commandParser == null)
                throw new NullReferenceException("Command channel client has not been initialized.");

            Stop();

            m_enabled = true;

            // Start the connection cycle
            m_connectionTimer.Enabled = true;
        }

        /// <summary>
        /// Stops this <see cref="CommandChannelClient"/>.
        /// </summary>
        public void Stop()
        {
            if (m_commandChannel == null || m_commandParser == null)
                throw new NullReferenceException("Command channel client has not been initialized.");

            m_enabled = false;
            m_commandParser.Stop();
            m_commandChannel.Disconnect();
        }

        /// <summary>
        /// Sends request from this <see cref="CommandChannelClient"/>.
        /// </summary>
        /// <param name="request"><see cref="Request"/> to send.</param>
        /// <param name="payload">Payload to send, if any.</param>
        public void SendRequest(Request request, byte[] payload)
        {
            SendRequest(request, payload, m_cryptoProperties);
        }

        /// <summary>
        /// Sends request from this <see cref="CommandChannelClient"/>.
        /// </summary>
        /// <param name="request"><see cref="Request"/> to send.</param>
        /// <param name="payload">Payload to send, if any.</param>
        /// <param name="cryptoProperties"><see cref="CryptoProperties"/> used to encrypt data.</param>
        public void SendRequest(Request request, byte[] payload, CryptoProperties cryptoProperties)
        {
            if (m_commandChannel == null)
                throw new NullReferenceException("Command channel client has not been initialized.");

            RequestPacket packet = new RequestPacket()
            {
                Request = request,
                Payload = payload
            };

            if (payload != null)
                packet.EncryptPayload(cryptoProperties);

            m_commandChannel.SendAsync(packet.BinaryImage);
        }

        /// <summary>
        /// Sends response from this <see cref="CommandChannelClient"/>.
        /// </summary>
        /// <param name="requestID">Originating request ID for this response.</param>
        /// <param name="response"><see cref="Response"/> to send.</param>
        /// <param name="payload">Payload to send, if any.</param>
        public void SendResponse(Guid requestID, Response response, byte[] payload)
        {
            SendResponse(requestID, response, payload, m_cryptoProperties);
        }

        /// <summary>
        /// Sends response from this <see cref="CommandChannelClient"/>.
        /// </summary>
        /// <param name="requestID">Originating request ID for this response.</param>
        /// <param name="response"><see cref="Response"/> to send.</param>
        /// <param name="payload">Payload to send, if any.</param>
        /// <param name="cryptoProperties"><see cref="CryptoProperties"/> used to encrypt data.</param>
        public void SendResponse(Guid requestID, Response response, byte[] payload, CryptoProperties cryptoProperties)
        {
            if (m_commandChannel == null)
                throw new NullReferenceException("Command channel client has not been initialized.");

            ResponsePacket packet = new ResponsePacket()
            {
                RequestID = requestID,
                Response = response,
                Payload = payload
            };

            if (payload != null)
                packet.EncryptPayload(cryptoProperties);

            m_commandChannel.SendAsync(packet.BinaryImage);
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
        /// Raises the <see cref="ReceivedRequestPacket"/> event.
        /// </summary>
        /// <param name="packet"><see cref="RequestPacket"/> received.</param>
        protected virtual void OnReceivedRequestPacket(RequestPacket packet)
        {
            if (ReceivedRequestPacket != null)
                ReceivedRequestPacket(this, new EventArgs<RequestPacket>(packet));
        }

        /// <summary>
        /// Raises the <see cref="ReceivedResponsePacket"/> event.
        /// </summary>
        /// <param name="packet"><see cref="ResponsePacket"/> received.</param>
        protected virtual void OnReceivedResponsePacket(ResponsePacket packet)
        {
            if (ReceivedResponsePacket != null)
                ReceivedResponsePacket(this, new EventArgs<ResponsePacket>(packet));
        }

        #region [ Connection Timer Event Hander ]

        private void m_connectionTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                OnStatusMessage("Attempting connection...");

                // Attempt connection to data source
                m_commandChannel.Connect();
                m_commandParser.Start();

                OnStatusMessage("Connection established.");
            }
            catch (Exception ex)
            {
                OnProcessException(new InvalidOperationException(string.Format("Connection attempt failed: {0}", ex.Message), ex));

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
            // If there were multiple commands in the stream (likely not common), we raise an event for each
            foreach (CommandPacketBase commandPacket in e.Argument2)
            {
                switch (commandPacket.TypeID)
                {
                    case CommandPacketType.Request:
                        // Make sure command packet is a request
                        RequestPacket requestPacket = commandPacket as RequestPacket;

                        if (requestPacket != null)
                        {
                            // Check for assignment of new crypto key - we handle this for the consumer to simplify usage
                            switch (requestPacket.Request)
                            {
                                case Request.AssignNewKey:
                                    // Key assignments for the command channel are handled internally on behalf of the consumer
                                    bool initialAssignment = (m_cryptoProperties.Key == null);
                                    byte[] key, iv;

                                    // Parse new crypto key
                                    RequestPacket.ParseAssignNewKeyPayload(requestPacket.Payload, out key, out iv);

                                    // Assign new crypto key
                                    m_cryptoProperties.Key = key;
                                    m_cryptoProperties.IV = iv;

                                    // If server provided an initial crypto key, we must respond with our identification
                                    // sequence such that server can verify our identity
                                    if (initialAssignment)
                                        SendResponse(requestPacket.RequestID, Response.Success, m_identificationSequence);
                                    break;
                                default:
                                    // Pass all other notifications on to consumer
                                    OnReceivedRequestPacket(requestPacket);
                                    break;
                            }

                        }
                        break;
                    case CommandPacketType.Response:
                        // Make sure command packet is a response
                        ResponsePacket responsePacket = commandPacket as ResponsePacket;

                        if (responsePacket != null)
                            OnReceivedResponsePacket(responsePacket);
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

        private void m_commandChannel_ConnectionTerminated(object sender, EventArgs e)
        {
            // Purge any left over parsing buffer on disconnect
            m_commandParser.PurgeBuffer(Guid.Empty);

            if (m_commandParser.Enabled)
            {
                // Communications layer closed connection (close not initiated by system) - so we restart connection cycle...
                OnStatusMessage("WARNING: Connection closed by remote device, attempting reconnection...");
                Start();
            }
        }

        private void m_commandChannel_ReceiveDataException(object sender, EventArgs<Exception> e)
        {
            OnProcessException(e.Argument);
        }

        private void m_commandChannel_ConnectionException(object sender, EventArgs<Exception> e)
        {
            OnProcessException(e.Argument);
        }

        private void m_commandChannel_SendDataException(object sender, EventArgs<Exception> e)
        {
            OnProcessException(e.Argument);
        }

        #endregion

        #endregion
    }
}