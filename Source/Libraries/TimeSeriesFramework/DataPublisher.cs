//******************************************************************************************************
//  DataPublisher.cs - Gbtc
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
//  08/20/2010 - J. Ritchie Carroll
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVA;
using TVA.Collections;
using TVA.Communication;
using TVA.Measurements;
using TVA.Measurements.Routing;
using System.Data;
using System.IO;
using System.Threading;

namespace TimeSeriesFramework
{
    #region [ Enumerations ]

    /// <summary>
    /// <see cref="DataPublisher"/> server commands.
    /// </summary>
    public enum ServerCommand : byte
    {
        /// <summary>
        /// Subscribe command.
        /// </summary>
        Subscribe = 0xC0,
        /// <summary>
        /// Unsubscribe command.
        /// </summary>
        Unsubscribe = 0xC1,
        /// <summary>
        /// Query points command.
        /// </summary>
        QueryPoints = 0xC2
    }

    /// <summary>
    /// <see cref="DataPublisher"/> server responses.
    /// </summary>
    public enum ServerResponse : byte
    {
        /// <summary>
        /// Command succeeded response.
        /// </summary>
        Succeeded = 0xD0,
        /// <summary>
        /// Command failed response.
        /// </summary>
        Failed = 0xD1,
        /// <summary>
        /// Data packet response.
        /// </summary>
        DataPacket = 0xD2
    }

    [Flags()]
    public enum DataPacketFlags : byte
    {
        /// <summary>
        /// Determines if data packet is synchronized. Bit set = synchronized, bit clear = unsynchronized.
        /// </summary>
        Synchronized = (byte)Bits.Bit00,
        /// <summary>
        /// Determines if serialized measurement is compact. Bit set = compact, bit clear = full fidelity.
        /// </summary>
        Compact = (byte)Bits.Bit01,
        /// <summary>
        /// No flags set. This would represent unsynchronized, full fidelity measurement data packets.
        /// </summary>
        NoFlags = (Byte)Bits.Nil
    }

    #endregion

    /// <summary>
    /// Represents a data publishing server that allows multiple connections for data subscriptions.
    /// </summary>
    public class DataPublisher : ActionAdapterCollection
    {
        #region [ Members ]

        // Nested Types

        // Client subscription action adatper interface
        private interface IClientSubscription : IActionAdapter
        {
            /// <summary>
            /// Gets the <see cref="Guid"/> client identifier of this <see cref="IClientSubscription"/>.
            /// </summary>
            Guid ClientID { get; }

            /// <summary>
            /// Gets or sets flag that determines if full fidelity measurements should be used in data packets of this <see cref="IClientSubscription"/>.
            /// </summary>
            bool UseFullFidelityMeasurements { get; set; }
        }

        // Synchronized action adapter interface
        private class SynchronizedClientSubscription : ActionAdapterBase, IClientSubscription
        {
            #region [ Members ]

            // Fields
            private DataPublisher m_parent;
            private Guid m_clientID;
            private bool m_useFullFidelityMeasurements;
            private bool m_disposed;

            #endregion

            #region [ Constructors ]

            /// <summary>
            /// Creates a new <see cref="SynchronizedClientSubscription"/>.
            /// </summary>
            /// <param name="parent">Reference to parent.</param>
            /// <param name="clientID"></param>
            public SynchronizedClientSubscription(DataPublisher parent, Guid clientID)
            {
                // Pass parent reference into base class
                ((IAdapter)this).AssignParentCollection(parent);

                m_parent = parent;
                m_clientID = clientID;
            }

            #endregion

            #region [ Properties ]

            /// <summary>
            /// Gets the <see cref="Guid"/> client identifier of this <see cref="SynchronizedClientSubscription"/>.
            /// </summary>
            public Guid ClientID
            {
                get
                {
                    return m_clientID;
                }
            }

            /// <summary>
            /// Gets or sets flag that determines if full fidelity measurements should be used in data packets of this <see cref="SynchronizedClientSubscription"/>.
            /// </summary>
            public bool UseFullFidelityMeasurements
            {
                get
                {
                    return m_useFullFidelityMeasurements;
                }
                set
                {
                    m_useFullFidelityMeasurements = value;
                }
            }

            /// <summary>
            /// Gets or sets primary keys of input measurements the <see cref="SynchronizedClientSubscription"/> expects, if any.
            /// </summary>
            /// <remarks>
            /// We override method so assignment can be synchronized such that dynamic updates won't interfere
            /// with filtering in <see cref="QueueMeasurementsForProcessing"/>.
            /// </remarks>
            public override MeasurementKey[] InputMeasurementKeys
            {
                get
                {
                    return base.InputMeasurementKeys;
                }
                set
                {
                    lock (this)
                    {
                        base.InputMeasurementKeys = value;
                    }
                }
            }

            #endregion

            #region [ Methods ]

            /// <summary>
            /// Releases the unmanaged resources used by the <see cref="SynchronizedClientSubscription"/> object and optionally releases the managed resources.
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
                            // Remove reference to parent
                            m_parent = null;
                        }
                    }
                    finally
                    {
                        m_disposed = true;          // Prevent duplicate dispose.
                        base.Dispose(disposing);    // Call base class Dispose().
                    }
                }
            }

            /// <summary>
            /// Publish <see cref="IFrame"/> of time-aligned collection of <see cref="IMeasurement"/> values that arrived within the
            /// concentrator's defined <see cref="ConcentratorBase.LagTime"/>.
            /// </summary>
            /// <param name="frame"><see cref="IFrame"/> of measurements with the same timestamp that arrived within <see cref="ConcentratorBase.LagTime"/> that are ready for processing.</param>
            /// <param name="index">Index of <see cref="IFrame"/> within a second ranging from zero to <c><see cref="ConcentratorBase.FramesPerSecond"/> - 1</c>.</param>
            protected override void PublishFrame(IFrame frame, int index)
            {
                MemoryStream data = new MemoryStream();
                bool useFullFidelityMeasurements = !m_useFullFidelityMeasurements;
                byte[] buffer;

                // Serialize data packet flags into response
                DataPacketFlags flags = DataPacketFlags.Synchronized;

                if (!useFullFidelityMeasurements)
                    flags |= DataPacketFlags.Compact;

                data.WriteByte((byte)flags);

                // Serialize frame timestamp into data packet
                data.Write(EndianOrder.BigEndian.GetBytes((long)frame.Timestamp), 0, 8);

                // Serialize measurements to data buffer
                foreach (IMeasurement measurement in frame.Measurements.Values)
                {
                    if (useFullFidelityMeasurements)
                        buffer = (new SerializableMeasurement(measurement)).BinaryImage;
                    else
                        buffer = (new SerializableMeasurementSlim(measurement, false)).BinaryImage;

                    data.Write(buffer, 0, buffer.Length);
                }

                // Pusblish data packet to client
                m_parent.SendClientResponse(m_clientID, ServerResponse.DataPacket, ServerCommand.Subscribe, data.ToArray());
            }

            /// <summary>
            /// Queues a single measurement for processing.
            /// </summary>
            /// <param name="measurement">Measurement to queue for processing.</param>
            /// <remarks>
            /// Measurement is filtered against the defined <see cref="InputMeasurementKeys"/> so we override method
            /// so that dyanmic updates to keys will be synchronized with filtering to prevent interference.
            /// </remarks>
            public override void QueueMeasurementForProcessing(IMeasurement measurement)
            {
                lock (this)
                {
                    base.QueueMeasurementForProcessing(measurement);
                }
            }

            /// <summary>
            /// Queues a collection of measurements for processing.
            /// </summary>
            /// <param name="measurements">Collection of measurements to queue for processing.</param>
            /// <remarks>
            /// Measurements are filtered against the defined <see cref="InputMeasurementKeys"/> so we override method
            /// so that dyanmic updates to keys will be synchronized with filtering to prevent interference.
            /// </remarks>
            public override void QueueMeasurementsForProcessing(IEnumerable<IMeasurement> measurements)
            {
                lock (this)
                {
                    base.QueueMeasurementsForProcessing(measurements);
                }
            }

            #endregion
        }

        // Unsynchronized action adapter interface
        private class UnsynchronizedClientSubscription : FacileActionAdapterBase, IClientSubscription
        {
            #region [ Members ]

            // Fields
            private DataPublisher m_parent;
            private Guid m_clientID;
            private bool m_useFullFidelityMeasurements;
            private bool m_disposed;

            #endregion

            #region [ Constructors ]

            /// <summary>
            /// Creates a new <see cref="UnsynchronizedClientSubscription"/>.
            /// </summary>
            /// <param name="parent">Reference to parent.</param>
            /// <param name="clientID"></param>
            public UnsynchronizedClientSubscription(DataPublisher parent, Guid clientID)
            {
                // Pass parent reference into base class
                ((IAdapter)this).AssignParentCollection(parent);

                m_parent = parent;
                m_clientID = clientID;
            }

            #endregion

            #region [ Properties ]

            /// <summary>
            /// Gets the <see cref="Guid"/> client identifier of this <see cref="UnsynchronizedClientSubscription"/>.
            /// </summary>
            public Guid ClientID
            {
                get
                {
                    return m_clientID;
                }
            }

            /// <summary>
            /// Gets or sets flag that determines if full fidelity measurements should be used in data packets of this <see cref="UnsynchronizedClientSubscription"/>.
            /// </summary>
            public bool UseFullFidelityMeasurements
            {
                get
                {
                    return m_useFullFidelityMeasurements;
                }
                set
                {
                    m_useFullFidelityMeasurements = value;
                }
            }

            /// <summary>
            /// Gets or sets primary keys of input measurements the <see cref="UnsynchronizedClientSubscription"/> expects, if any.
            /// </summary>
            /// <remarks>
            /// We override method so assignment can be synchronized such that dynamic updates won't interfere
            /// with filtering in <see cref="QueueMeasurementsForProcessing"/>.
            /// </remarks>
            public override MeasurementKey[] InputMeasurementKeys
            {
                get
                {
                    return base.InputMeasurementKeys;
                }
                set
                {
                    lock (this)
                    {
                        base.InputMeasurementKeys = value;
                    }
                }
            }

            #endregion

            #region [ Methods ]

            /// <summary>
            /// Releases the unmanaged resources used by the <see cref="UnsynchronizedClientSubscription"/> object and optionally releases the managed resources.
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
                            // Remove reference to parent
                            m_parent = null;
                        }
                    }
                    finally
                    {
                        m_disposed = true;          // Prevent duplicate dispose.
                        base.Dispose(disposing);    // Call base class Dispose().
                    }
                }
            }

            /// <summary>
            /// Gets a short one-line status of this <see cref="UnsynchronizedClientSubscription"/>.
            /// </summary>
            /// <param name="maxLength">Maximum number of available characters for display.</param>
            /// <returns>A short one-line summary of the current status of this <see cref="AdapterBase"/>.</returns>
            public override string GetShortStatus(int maxLength)
            {
                int inputCount = 0, outputCount = 0;

                if (InputMeasurementKeys != null)
                    inputCount = InputMeasurementKeys.Length;

                if (OutputMeasurements != null)
                    outputCount = OutputMeasurements.Length;

                return string.Format("Total input measurements: {0}, total output measurements: {1}", inputCount, outputCount).PadLeft(maxLength);
            }

            /// <summary>
            /// Queues a single measurement for processing.
            /// </summary>
            /// <param name="measurement">Measurement to queue for processing.</param>
            /// <remarks>
            /// Measurement is filtered against the defined <see cref="InputMeasurementKeys"/> so we override method
            /// so that dyanmic updates to keys will be synchronized with filtering to prevent interference.
            /// </remarks>
            public override void QueueMeasurementForProcessing(IMeasurement measurement)
            {
                QueueMeasurementsForProcessing(new IMeasurement[] { measurement });
            }

            /// <summary>
            /// Queues a collection of measurements for processing.
            /// </summary>
            /// <param name="measurements">Collection of measurements to queue for processing.</param>
            /// <remarks>
            /// Measurements are filtered against the defined <see cref="InputMeasurementKeys"/> so we override method
            /// so that dyanmic updates to keys will be synchronized with filtering to prevent interference.
            /// </remarks>
            public override void QueueMeasurementsForProcessing(IEnumerable<IMeasurement> measurements)
            {
                List<IMeasurement> filteredMeasurements = new List<IMeasurement>();

                lock (this)
                {
                    foreach (IMeasurement measurement in measurements)
                    {
                        if (IsInputMeasurement(measurement.Key))
                            filteredMeasurements.Add(measurement);
                    }
                }

                if (filteredMeasurements.Count > 0)
                    ThreadPool.QueueUserWorkItem(ProcessMeasurements, filteredMeasurements);
            }

            private void ProcessMeasurements(object state)
            {
                IEnumerable<IMeasurement> measurements = state as IEnumerable<IMeasurement>;

                if (state != null)
                {
                    MemoryStream data = new MemoryStream();
                    bool useFullFidelityMeasurements = !m_useFullFidelityMeasurements;
                    byte[] buffer;

                    // Serialize data packet flags into response
                    DataPacketFlags flags = DataPacketFlags.NoFlags;

                    if (!useFullFidelityMeasurements)
                        flags |= DataPacketFlags.Compact;

                    data.WriteByte((byte)flags);

                    // Serialize measurements to data buffer
                    foreach (IMeasurement measurement in measurements)
                    {
                        if (useFullFidelityMeasurements)
                            buffer = (new SerializableMeasurement(measurement)).BinaryImage;
                        else
                            buffer = (new SerializableMeasurementSlim(measurement, true)).BinaryImage;
                        
                        data.Write(buffer, 0, buffer.Length);
                    }

                    // Pusblish data packet to client
                    m_parent.SendClientResponse(m_clientID, ServerResponse.DataPacket, ServerCommand.Subscribe, data.ToArray());
                }
            }

            #endregion
        }

        // Fields
        private TcpServer m_dataServer;
        private bool m_disposed;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new <see cref="DataPublisher"/>.
        /// </summary>
        public DataPublisher()
        {
            base.Name = "Data Publisher Collection";
            base.DataMember = "[internal]";

            // Create a new TCP server
            m_dataServer = new TcpServer();

            // Initialize default settings
            m_dataServer.SettingsCategory = Name;
            m_dataServer.ConfigurationString = "port=6165";
            m_dataServer.PayloadAware = true;
            m_dataServer.PersistSettings = true;

            // Attach to desired events
            m_dataServer.ClientConnected += m_dataServer_ClientConnected;
            m_dataServer.ClientDisconnected += m_dataServer_ClientDisconnected;
            m_dataServer.HandshakeProcessTimeout += m_dataServer_HandshakeProcessTimeout;
            m_dataServer.HandshakeProcessUnsuccessful += m_dataServer_HandshakeProcessUnsuccessful;
            m_dataServer.ReceiveClientDataComplete += m_dataServer_ReceiveClientDataComplete;
            m_dataServer.ReceiveClientDataException += m_dataServer_ReceiveClientDataException;
            m_dataServer.ReceiveClientDataTimeout += m_dataServer_ReceiveClientDataTimeout;
            m_dataServer.SendClientDataException += m_dataServer_SendClientDataException;
            m_dataServer.ServerStarted += m_dataServer_ServerStarted;
            m_dataServer.ServerStopped += m_dataServer_ServerStopped;
        }

        /// <summary>
        /// Releases the unmanaged resources before the <see cref="DataPublisher"/> object is reclaimed by <see cref="GC"/>.
        /// </summary>
        ~DataPublisher()
        {
            Dispose(false);
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets the status of this <see cref="DataPublisher"/>.
        /// </summary>
        /// <remarks>
        /// Derived classes should provide current status information about the adapter for display purposes.
        /// </remarks>
        public override string Status
        {
            get
            {
                StringBuilder status = new StringBuilder();

                if (m_dataServer != null)
                    status.Append(m_dataServer.Status);

                status.Append(base.Status);

                return status.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the name of this <see cref="DataPublisher"/>.
        /// </summary>
        /// <remarks>
        /// The assigned name is used as the settings category when persisting the TCP server settings.
        /// </remarks>
        public override string Name
        {
            get
            {
                return base.Name;
            }
            set
            {
                base.Name = value.ToUpper();

                if (m_dataServer != null)
                    m_dataServer.SettingsCategory = value;
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="DataPublisher"/> object and optionally releases the managed resources.
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
                        if (m_dataServer != null)
                        {
                            m_dataServer.ClientConnected -= m_dataServer_ClientConnected;
                            m_dataServer.ClientDisconnected -= m_dataServer_ClientDisconnected;
                            m_dataServer.HandshakeProcessTimeout -= m_dataServer_HandshakeProcessTimeout;
                            m_dataServer.HandshakeProcessUnsuccessful -= m_dataServer_HandshakeProcessUnsuccessful;
                            m_dataServer.ReceiveClientDataComplete -= m_dataServer_ReceiveClientDataComplete;
                            m_dataServer.ReceiveClientDataException -= m_dataServer_ReceiveClientDataException;
                            m_dataServer.ReceiveClientDataTimeout -= m_dataServer_ReceiveClientDataTimeout;
                            m_dataServer.SendClientDataException -= m_dataServer_SendClientDataException;
                            m_dataServer.ServerStarted -= m_dataServer_ServerStarted;
                            m_dataServer.ServerStopped -= m_dataServer_ServerStopped;
                            m_dataServer.Dispose();
                        }
                        m_dataServer = null;
                    }
                }
                finally
                {
                    m_disposed = true;          // Prevent duplicate dispose.
                    base.Dispose(disposing);    // Call base class Dispose().
                }
            }
        }

        /// <summary>
        /// Intializes <see cref="DataPublisher"/>.
        /// </summary>
        public override void Initialize()
        {
            // We don't call base class initialize since it tries to auto-load adapters from the defined
            // data member - instead, the data publisher dyanmically creates adapters upon request
            Initialized = false;

            Clear();

            // Initialize TCP server (loads config file settings)
            if (m_dataServer != null)
                m_dataServer.Initialize();

            Initialized = true;
        }

        /// <summary>
        /// Establish <see cref="DataPublisher"/> and start listening for client connections.
        /// </summary>
        public override void Start()
        {
            if (!Enabled)
            {
                base.Start();

                if (m_dataServer != null)
                    m_dataServer.Start();
            }
        }

        /// <summary>
        /// Terminate <see cref="DataPublisher"/> and stop listening for client connections.
        /// </summary>
        public override void Stop()
        {
            base.Stop();

            if (m_dataServer != null)
                m_dataServer.Stop();
        }

        /// <summary>
        /// Gets a short one-line status of this <see cref="CommonPhasorServices"/>.
        /// </summary>
        /// <param name="maxLength">Maximum number of available characters for display.</param>
        /// <returns>A short one-line summary of the current status of the <see cref="CommonPhasorServices"/>.</returns>
        public override string GetShortStatus(int maxLength)
        {
            if (m_dataServer != null)
                return string.Format("Publishing data to {0} clients.", m_dataServer.ClientIDs.Length).CenterText(maxLength);

            return "Currently not connected".CenterText(maxLength);
        }

        /// <summary>
        /// Unwires events and disposes of <see cref="IActionAdapter"/> implementation.
        /// </summary>
        /// <param name="item"><see cref="IActionAdapter"/> to dispose.</param>
        protected override void DisposeItem(IActionAdapter item)
        {
            base.DisposeItem(item);

            try
            {
                if (m_dataServer != null)
                    m_dataServer.DisconnectOne(((IClientSubscription)item).ClientID);
            }
            catch (InvalidOperationException)
            {
                // This exception is thrown if client is no longer in the connection list - we can safely ignore this error
            }
        }

        /// <summary>
        /// Sends response back to specified client.
        /// </summary>
        /// <param name="clientID">ID of client to send response.</param>
        /// <param name="response">Server response.</param>
        /// <param name="command">In response to command.</param>
        protected virtual void SendClientResponse(Guid clientID, ServerResponse response, ServerCommand command)
        {
            SendClientResponse(clientID, response, command, (byte[])null);
        }

        /// <summary>
        /// Sends response back to specified client with a message.
        /// </summary>
        /// <param name="clientID">ID of client to send response.</param>
        /// <param name="response">Server response.</param>
        /// <param name="command">In response to command.</param>
        /// <param name="status">Status message to return.</param>
        protected virtual void SendClientResponse(Guid clientID, ServerResponse response, ServerCommand command, string status)
        {
            if (status != null)
                SendClientResponse(clientID, response, command, Encoding.Unicode.GetBytes(status));
            else
                SendClientResponse(clientID, response, command);
        }

        /// <summary>
        /// Sends response back to specified client with a formatted message.
        /// </summary>
        /// <param name="clientID">ID of client to send response.</param>
        /// <param name="response">Server response.</param>
        /// <param name="command">In response to command.</param>
        /// <param name="formattedStatus">Formatted status message to return.</param>
        /// <param name="args">Arguments for <paramref name="formattedStatus"/>.</param>
        protected virtual void SendClientResponse(Guid clientID, ServerResponse response, ServerCommand command, string formattedStatus, params object[] args)
        {
            if (formattedStatus != null)
                SendClientResponse(clientID, response, command, Encoding.Unicode.GetBytes(string.Format(formattedStatus, args)));
            else
                SendClientResponse(clientID, response, command);
        }

        /// <summary>
        /// Sends response back to specified client with attached data.
        /// </summary>
        /// <param name="clientID">ID of client to send response.</param>
        /// <param name="response">Server response.</param>
        /// <param name="command">In response to command.</param>
        /// <param name="data">Data to return to client; null if none.</param>
        protected virtual void SendClientResponse(Guid clientID, ServerResponse response, ServerCommand command, byte[] data)
        {
            SendClientResponse(clientID, (byte)response, (byte)command, data);
        }

        // Send binary response packet to client
        private void SendClientResponse(Guid clientID, byte responseCode, byte commandCode, byte[] data)
        {
            MemoryStream responsePacket = new MemoryStream();

            // Add response code
            responsePacket.WriteByte(responseCode);

            // Add original in response to command code
            responsePacket.WriteByte(commandCode);

            if (data == null || data.Length == 0)
            {
                // Add zero sized data buffer to response packet
                responsePacket.Write(EndianOrder.BigEndian.GetBytes(0), 0, 4);
            }
            else
            {
                // Add size of data buffer to response packet
                responsePacket.Write(EndianOrder.BigEndian.GetBytes(data.Length), 0, 4);

                // Add data buffer
                responsePacket.Write(data, 0, data.Length);
            }

            // Send response packet
            if (m_dataServer != null)
            {
                try
                {
                    m_dataServer.SendToAsync(clientID, responsePacket.ToArray());
                }
                catch (Exception ex)
                {
                    OnProcessException(new InvalidOperationException("Failed to send response packet to client due to exception: " + ex.Message, ex));
                }
            }
        }

        // Remove client subscription
        private void RemoveClientSubscription(Guid clientID)
        {
            lock (this)
            {
                IActionAdapter clientSubscription = this.First<IActionAdapter>(cs => ((IClientSubscription)cs).ClientID == clientID);

                if (clientSubscription != null)
                {
                    clientSubscription.Dispose();
                    Remove(clientSubscription);
                }
            }
        }

        private void m_dataServer_ClientConnected(object sender, EventArgs<Guid> e)
        {
            // Initialize a new subscription list for this client
            lock (this)
            {
                //Add();
            }
        }

        private void m_dataServer_ClientDisconnected(object sender, EventArgs<Guid> e)
        {
            RemoveClientSubscription(e.Argument);
        }

        private void m_dataServer_ReceiveClientDataComplete(object sender, EventArgs<Guid, byte[], int> e)
        {
            Guid clientID = e.Argument1;
            byte[] buffer = e.Argument2;
            int length = e.Argument3;
            string message;

            if (length > 0 && buffer != null)
            {
                // Query command byte
                switch ((ServerCommand)buffer[0])
                {
                    case ServerCommand.Subscribe:
                        // Handle subscribe
                        try
                        {
                            // Make sure there is enough buffer to for integer that defines signal ID count
                            if (length >= 5)
                            {
                                // Next 4 bytes are an integer representing the length of the connection string that follows
                                int byteLength = EndianOrder.BigEndian.ToInt32(buffer, 1);

                                if (byteLength > 0 && length >= 5 + byteLength)
                                {
                                    string connectionString = Encoding.Unicode.GetString(buffer, 5, byteLength);
                                    IClientSubscription subscription = null;

                                    // Lookup adapter by its client ID
                                    lock (this)
                                    {
                                        IActionAdapter adapter;

                                        if (this.TryGetAdapter<Guid>(clientID, (item, value) => ((IClientSubscription)item).ClientID == value, out adapter))
                                            subscription = (IClientSubscription)adapter;
                                    }

                                    if (subscription != null)
                                    {
                                        // Update connection string
                                        subscription.ConnectionString = connectionString;

                                        // Subscribed signals (i.e., input measurement keys) will be parsed from connection string during
                                        // initialization of adapter. This should also gracefully handle "resubscribing" since assignment
                                        // and  use of input measurment keys is synchronized within the client subscription class
                                        subscription.Initialize();

                                        // Make sure adapter is started
                                        subscription.Start();

                                        // Send success response
                                        if (subscription.InputMeasurementKeys != null)
                                            message = string.Format("Client subscribed with {0} signals.", subscription.InputMeasurementKeys.Length);
                                        else
                                            message = string.Format("Client subscribed, but no signals were specified. Make sure \"inputMeasurementKeys\" setting is properly defined.");

                                        SendClientResponse(clientID, ServerResponse.Succeeded, ServerCommand.Subscribe, message);
                                        OnStatusMessage(message);
                                    }
                                    else
                                    {
                                        // No need to send response to client, it is already disconnected...
                                        OnProcessException(new InvalidOperationException("Failed to find connection for client data subscription."));
                                    }
                                }
                                else
                                {
                                    if (byteLength > 0)
                                        message = "Not enough buffer was provided to parse client data subscription.";
                                    else
                                        message = "Cannot initialize client data subscription without a connection string.";

                                    SendClientResponse(clientID, ServerResponse.Failed, ServerCommand.Subscribe, message);
                                    OnProcessException(new InvalidOperationException(message));
                                }
                            }
                            else
                            {
                                message = "Not enough buffer was provided to parse client data subscription.";
                                SendClientResponse(clientID, ServerResponse.Failed, ServerCommand.Subscribe, message);
                                OnProcessException(new InvalidOperationException(message));
                            }
                        }
                        catch (Exception ex)
                        {
                            message = "Failed to process client data subscription due to exception: " + ex.Message;
                            SendClientResponse(clientID, ServerResponse.Failed, ServerCommand.Subscribe, message);
                            OnProcessException(new InvalidOperationException(message, ex));
                        }
                        break;
                    case ServerCommand.Unsubscribe:
                        // Handle unsubscribe
                        RemoveClientSubscription(clientID);
                        message = "Client unsubscribed.";
                        SendClientResponse(clientID, ServerResponse.Succeeded, ServerCommand.Unsubscribe, message);
                        OnStatusMessage(message);
                        break;
                    case ServerCommand.QueryPoints:
                        // Handle point query
                        message = "Client request for query points command is not implemented yet.";
                        SendClientResponse(clientID, ServerResponse.Failed, ServerCommand.QueryPoints, message);
                        OnProcessException(new NotImplementedException(message));
                        break;
                    default:
                        // Handle unrecognized commands
                        message = "Client sent an unrecognized server command: 0x" + buffer[0].ToString("X").PadLeft(2, '0');
                        SendClientResponse(clientID, (byte)ServerResponse.Failed, buffer[0], Encoding.Unicode.GetBytes(message));
                        OnProcessException(new InvalidOperationException(message));
                        break;
                }
            }
        }

        private void m_dataServer_ServerStarted(object sender, EventArgs e)
        {
            OnStatusMessage("Data publisher started.");
        }

        private void m_dataServer_ServerStopped(object sender, EventArgs e)
        {
            OnStatusMessage("Data publisher stopped.");
        }

        private void m_dataServer_SendClientDataException(object sender, EventArgs<Guid, Exception> e)
        {
            Exception ex = e.Argument2;
            OnProcessException(new InvalidOperationException("Data publisher encountered an exception while sending data to client connection: " + ex.Message, ex));
        }

        private void m_dataServer_ReceiveClientDataException(object sender, EventArgs<Guid, Exception> e)
        {
            Exception ex = e.Argument2;
            OnProcessException(new InvalidOperationException("Data publisher encountered an exception while receiving data from client connection: " + ex.Message, ex));
        }

        private void m_dataServer_ReceiveClientDataTimeout(object sender, EventArgs<Guid> e)
        {
            OnProcessException(new InvalidOperationException("Data publisher timed out while receiving data from client connection"));
        }

        private void m_dataServer_HandshakeProcessUnsuccessful(object sender, EventArgs e)
        {
            OnProcessException(new InvalidOperationException("Data publisher failed to authenticate client connection"));
        }

        private void m_dataServer_HandshakeProcessTimeout(object sender, EventArgs e)
        {
            OnProcessException(new InvalidOperationException("Data publisher timed out while trying authenticate client connection"));
        }

        #endregion
    }
}
