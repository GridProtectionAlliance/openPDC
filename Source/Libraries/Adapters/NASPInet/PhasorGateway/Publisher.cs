//*******************************************************************************************************
//  Publisher.cs
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
//  07/20/2009 - James R. Carroll
//       Generated original version of source code.
//
//*******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using NASPInet.Channels;
using NASPInet.Packets;
using NASPInet.Signals;
using TVA;
using TVA.Communication;
using TVA.Measurements;
using TVA.Measurements.Routing;

namespace NASPInet.PhasorGateway
{
    /// <summary>
    /// Represents the publisher component of a NASPInet phasor gateway.
    /// </summary>
    public class Publisher : OutputAdapterBase
    {
        #region [ Members ]

        // Nested Types

        /// <summary>
        /// Represents a <see cref="Subscriber"/> connection.
        /// </summary>
        private class SubscriberConnection : IDisposable
        {
            #region [ Members ]

            // Fields

            /// <summary>
            /// Connection ID of <see cref="Subscriber"/>.
            /// </summary>
            public Guid ConnectionID;

            /// <summary>
            /// Signals ID's defined for the <see cref="Subscriber"/>.
            /// </summary>
            /// <remarks>Users should keep list sorted to allow binary lookups.</remarks>
            public List<Guid> SignalIDs;

            /// <summary>
            /// Data channel used by <see cref="Subscriber"/>.
            /// </summary>
            public UdpClient DataChannel;

            /// <summary>
            /// Data transmission buffer for <see cref="Subscriber"/>.
            /// </summary>
            public MemoryStream Buffer;

            private bool m_disposed;

            #endregion

            #region [ Constructors ]

            /// <summary>
            /// Creates a new <see cref="SubscriberConnection"/>.
            /// </summary>
            /// <param name="connectionID">Communication ID of this <see cref="SubscriberConnection"/>.</param>
            public SubscriberConnection(Guid connectionID)
            {
                this.ConnectionID = connectionID;
                this.SignalIDs = new List<Guid>();
            }

            /// <summary>
            /// Releases the unmanaged resources before the <see cref="SubscriberConnection"/> object is reclaimed by <see cref="GC"/>.
            /// </summary>
            ~SubscriberConnection()
            {
                Dispose(false);
            }

            #endregion

            #region [ Methods ]

            /// <summary>
            /// Releases all the resources used by the <see cref="SubscriberConnection"/> object.
            /// </summary>
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            /// <summary>
            /// Releases the unmanaged resources used by the <see cref="SubscriberConnection"/> object and optionally releases the managed resources.
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
                            if (DataChannel != null)
                                DataChannel.Dispose();
                            DataChannel = null;
                        }
                    }
                    finally
                    {
                        m_disposed = true;  // Prevent duplicate dispose.
                    }
                }
            }

            #endregion
        }

        // Constants

        /// <summary>
        /// Default UDP buffer size for data transmission.
        /// </summary>
        /// <remarks>
        /// A buffer of 8192 will hold a maximum number 227 <see cref="DataPacket"/>s at 36 bytes each.
        /// </remarks>
        public const int UdpBufferSize = 8192;

        // Fields
        private Dictionary<Guid, PublisherSignal> m_registeredSignals;  // Defined publisher signals dictionary, keyed off signal ID
        private Dictionary<MeasurementKey, Guid> m_measurementSignals;  // Measurement to signal cross reference, keyed off measurement key
        private AuthoritativeClient m_centralAuthorityClient;           // Central authority client connection
        private CommandChannelServer m_commandChannel;                  // Publisher command channel
        private Dictionary<Guid, SubscriberConnection> m_subscribers;   // Subscriber connection dictionary, keyed off connection ID
        private List<SubscriberConnection> m_pendingSubscribers;        // Pending (un-validated) subscriber connection list
        private bool m_encryptSignals;                                  // Flag ther determines if signals are encrypted
        private SymmetricAlgorithm m_symmetricAlgorithm;                // Symmetric encryption algorithm
        private System.Timers.Timer m_keyExpirationTimer;               // Key expiration timer
        private bool m_disposed;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new publisher component of a NASPInet phasor gateway.
        /// </summary>
        public Publisher()
        {
            m_symmetricAlgorithm = Common.SymmetricAlgorithm;
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets flag that determines if signals published by this <see cref="Publisher"/> component are encrypted.
        /// </summary>
        public bool EncryptSignals
        {
            get
            {
                return m_encryptSignals;
            }
            set
            {
                m_encryptSignals = value;
            }
        }

        /// <summary>
        /// Returns <c>true</c>; phasor gateway publishing component command channel connection is started asynchronously.
        /// </summary>
        protected override bool UseAsyncConnect
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Returns <c>false</c>. Phasor gateways do not archive measurements directly; instead measurements
        /// are forwarded to historians for archival.
        /// </summary>
        public override bool OutputIsForArchive
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets or sets reference to command channel binding and unbinding events as necessary.
        /// </summary>
        internal CommandChannelServer CommandChannel
        {
            get
            {
                return m_commandChannel;
            }
            set
            {
                if (m_commandChannel != null)
                {
                    m_commandChannel.ClientConnected -= m_commandChannel_ClientConnected;
                    m_commandChannel.ClientDisconnected -= m_commandChannel_ClientDisconnected;
                    m_commandChannel.ReceivedRequestPacket -= m_commandChannel_ReceivedRequestPacket;
                    m_commandChannel.ReceivedResponsePacket -= m_commandChannel_ReceivedResponsePacket;
                    m_commandChannel.StatusMessage -= m_commandChannel_StatusMessage;
                    m_commandChannel.ProcessException -= m_commandChannel_ProcessException;

                    if (m_commandChannel != value)
                        m_commandChannel.Dispose();
                }

                m_commandChannel = value;

                if (m_commandChannel != null)
                {
                    m_commandChannel.ClientConnected += m_commandChannel_ClientConnected;
                    m_commandChannel.ClientDisconnected += m_commandChannel_ClientDisconnected;
                    m_commandChannel.ReceivedRequestPacket += m_commandChannel_ReceivedRequestPacket;
                    m_commandChannel.ReceivedResponsePacket += m_commandChannel_ReceivedResponsePacket;
                    m_commandChannel.StatusMessage += m_commandChannel_StatusMessage;
                    m_commandChannel.ProcessException += m_commandChannel_ProcessException;
                }
            }
        }

        /// <summary>
        /// Gets or sets reference to central authority client binding and unbinding events as necessary.
        /// </summary>
        internal AuthoritativeClient CentralAuthorityClient
        {
            get
            {
                return m_centralAuthorityClient;
            }
            set
            {
                if (m_centralAuthorityClient != null)
                {
                    // TODO: Unbind from events

                    if (m_centralAuthorityClient != value)
                        m_centralAuthorityClient.Dispose();
                }

                m_centralAuthorityClient = value;

                if (m_centralAuthorityClient != null)
                {
                    // TODO: Bind to needed events
                }
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="Publisher"/> object and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                try
                {
                    if (disposing)
                    {
                        CommandChannel = null;
                    }
                }
                finally
                {
                    base.Dispose(disposing);    // Call base class Dispose().
                    m_disposed = true;          // Prevent duplicate dispose.
                }
            }
        }

        /// <summary>
        /// Intializes the phasor gateway <see cref="Publisher"/> component.
        /// </summary>
        public override void Initialize()
        {
            Dictionary<string, string> settings = Settings;
            string setting;

            // Initialize command channel
            CommandChannel = new CommandChannelServer();                        
            m_commandChannel.ConnectionString = settings["commandChannel"].ToString();

            // Initialize central authority client
            CentralAuthorityClient = new AuthoritativeClient();
            m_centralAuthorityClient.ConnectionString = settings["centralAuthority"].ToString();

            // TODO: Assign PG certificate so that CA can validate PG's identity
            // Probably best to load this from a file...
            m_centralAuthorityClient.IdentificationSequence = null;

            // Load optional publisher connection parameters
            if (!settings.TryGetValue("keyExpirationTime", out setting))
                setting = "300000"; // Default to 5 minutes

            // Setup key expiration timer
            m_keyExpirationTimer = new System.Timers.Timer(double.Parse(setting));
            m_keyExpirationTimer.Elapsed += m_keyExpirationTimer_Elapsed;
            m_keyExpirationTimer.Start();

            // Define subscriber connection list
            m_subscribers = new Dictionary<Guid, SubscriberConnection>();

            // Load registered signals for this phasor gateway
            m_registeredSignals = new Dictionary<Guid, PublisherSignal>();
            m_measurementSignals = new Dictionary<MeasurementKey, Guid>();
            Guid signalID;

            foreach (DataRow row in DataSource.Tables["ActiveDeviceMeasurements"].Rows)
            {
                setting = row["SignalID"].ToString();

                // Active measurements that have a signal ID that has been registered with the central authority
                if (!string.IsNullOrEmpty(setting))
                {
                    try
                    {
                        // Create guid based signal ID
                        signalID = new Guid(setting);

                        // Add registered signal
                        m_registeredSignals.Add(signalID, new PublisherSignal(signalID, m_symmetricAlgorithm));

                        // Add signal to measurement cross reference dictionary
                        m_measurementSignals.Add(new MeasurementKey(
                            uint.Parse(row["PointID"].ToString()), row["Historian"].ToString()),
                            signalID);
                    }
                    catch (Exception ex)
                    {
                        OnProcessException(new InvalidOperationException(string.Format("Failed to load registered signal \"{0}\" due to exception: {1}", setting, ex.Message), ex));
                    }
                }
            }

            OnStatusMessage("Loaded {0} registered signals...", m_registeredSignals.Count);
        }

        /// <summary>
        /// Attempts to connect to central authority and establish a command channel.
        /// </summary>
        protected override void AttemptConnection()
        {
            m_commandChannel.Start();
            m_centralAuthorityClient.Start();
        }

        /// <summary>
        /// Attempts to disconnect to central authority and stop command channel.
        /// </summary>
        protected override void AttemptDisconnection()
        {
            m_commandChannel.Stop();
            m_centralAuthorityClient.Stop();
        }

        /// <summary>
        /// Gets short one-line status for this <see cref="Publisher"/>.
        /// </summary>
        /// <param name="maxLength">Maximyu length of status.</param>
        /// <returns>Short one-line status for this <see cref="Publisher"/>.</returns>
        public override string GetShortStatus(int maxLength)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serializes measurements into <see cref="DataPacket"/>'s for publication to <see cref="Subscriber"/>'s.
        /// </summary>
        protected override void ProcessMeasurements(IMeasurement[] measurements)
        {
            Guid signalID;
            PublisherSignal signal;
            DataPacket dataPacket;
            CryptoProperties cryptoProperties;
            byte[] packetImage;

            // Assign symmetric algorithm to use for signal encryption
            cryptoProperties.Algorithm = m_symmetricAlgorithm;

            // Process each received measurement
            foreach (IMeasurement measurement in measurements)
            {
                // Look up publisher signal via measurement key
                if (m_measurementSignals.TryGetValue(measurement.Key, out signalID) && 
                    m_registeredSignals.TryGetValue(signalID, out signal))
                {
                    // Create new data packet based on signal information
                    dataPacket = new DataPacket();
                    dataPacket.SignalID = signalID;
                    dataPacket.Timestamp = measurement.Timestamp;
                    dataPacket.Value = measurement.AdjustedValue;
                    dataPacket.DataIsValid = measurement.ValueQualityIsGood;
                    dataPacket.SynchronizationIsValid = measurement.TimestampQualityIsGood;
                    dataPacket.DataIsEncrypted = m_encryptSignals;

                    if (m_encryptSignals)
                    {
                        // Assign crypto key
                        cryptoProperties.Key = signal.Key;
                        cryptoProperties.IV = signal.IV;

                        // We synchronize encryption activity so that key change won't affect encryption of an individual signal
                        lock (m_symmetricAlgorithm)
                        {
                            dataPacket.KeyStateIsEven = signal.KeyStateIsEven;
                            dataPacket.EncryptValue(cryptoProperties);
                        }
                    }

                    // Generate data packet binary image
                    packetImage = dataPacket.BinaryImage;

                    // Assign this data packet to each subscriber with a subcription to this signal
                    lock (m_subscribers)
                    {
                        foreach (SubscriberConnection subscriber in m_subscribers.Values)
                        {
                            // Check if subscriber connection has subscribed to this signal
                            if (subscriber.SignalIDs.BinarySearch(signalID) > -1)
                            {
                                // Keep an eye on buffer size, if we are about to exceed our UDP buffer size
                                // then we need to go ahead and transmit cumulative packet
                                if (subscriber.Buffer.Length + DataPacket.FixedLength >= UdpBufferSize)
                                {
                                    subscriber.DataChannel.SendAsync(subscriber.Buffer.ToArray());
                                    subscriber.Buffer = null;
                                }

                                // Make sure transport buffer exists
                                if (subscriber.Buffer == null)
                                    subscriber.Buffer = new MemoryStream();

                                // Add data packet image to transport buffer
                                subscriber.Buffer.Write(packetImage, 0, packetImage.Length);
                            }
                        }
                    }
                }                
            }

            // Publish all cumulated data packets for each subscriber
            lock (m_subscribers)
            {
                foreach (SubscriberConnection subscriber in m_subscribers.Values)
                {
                    if (subscriber.Buffer != null)
                    {
                        subscriber.DataChannel.SendAsync(subscriber.Buffer.ToArray());
                        subscriber.Buffer = null;
                    }
                }
            }
        }

        // Key expiration timer elapsed event handler
        private void m_keyExpirationTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // We synchronize key generation locking off algorithm so that key generation and signal encryption
            // won't conflict across threaded data publication
            if (m_encryptSignals)
            {
                lock (m_symmetricAlgorithm)
                {
                    byte[] newKeyPayload;

                    // Update keys for all signals
                    foreach (PublisherSignal signal in m_registeredSignals.Values)
                    {
                        // Generate new keys for this signal
                        signal.GenerateNewKeys(m_symmetricAlgorithm);

                        // Generate payload for new keys command
                        newKeyPayload = RequestPacket.GenerateAssignNewKeyPayload(signal.KeyStateIsEven, signal.Key, signal.IV);

                        // Notify subscribers to this signal of the new key. Developers take note of nested lock, be careful
                        // that other locked enumerations over subscriber list are independent of encryption activities or you
                        // will have a deadlock to deal with.
                        lock (m_subscribers)
                        {
                            foreach (SubscriberConnection subscriber in m_subscribers.Values)
                            {
                                // Check if subscriber connection has subscribed to this signal
                                if (subscriber.SignalIDs.BinarySearch(signal.SignalID) > -1)
                                    // Send subscriber notification of new keys (this is an asynchronous send to reduce lock time)
                                    m_commandChannel.SendRequest(subscriber.ConnectionID, Request.AssignNewKey, newKeyPayload);
                            }
                        }
                    }
                }
            }
        }

        #region [ Command Channel Handlers ]

        private void m_commandChannel_ClientConnected(object sender, EventArgs<Guid> e)
        {
            if (m_pendingSubscribers == null)
                m_pendingSubscribers = new List<SubscriberConnection>();

            m_pendingSubscribers.Add(new SubscriberConnection(e.Argument));

            OnStatusMessage("Client attempting connection...");
        }

        private void m_commandChannel_ClientDisconnected(object sender, EventArgs<Guid> e)
        {
            Guid connectionID = e.Argument;
            SubscriberConnection connection;

            // Remove disconnected client
            lock (m_subscribers)
            {
                if (m_subscribers.TryGetValue(connectionID, out connection))
                {
                    connection.Dispose();
                    m_subscribers.Remove(connectionID);
                }
            }
        }

        private void m_commandChannel_ReceivedRequestPacket(object sender, EventArgs<Guid, RequestPacket> e)
        {
            throw new NotImplementedException();
        }

        private void m_commandChannel_ReceivedResponsePacket(object sender, EventArgs<Guid, ResponsePacket> e)
        {
            throw new NotImplementedException();
        }

        private void m_commandChannel_StatusMessage(object sender, EventArgs<string> e)
        {
            OnStatusMessage(e.Argument);
        }

        private void m_commandChannel_ProcessException(object sender, EventArgs<Exception> e)
        {
            OnProcessException(e.Argument);
        }

        #endregion

        #endregion
    }
}
