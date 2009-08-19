//*******************************************************************************************************
//  CommandChannelServer.cs
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
