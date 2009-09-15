//*******************************************************************************************************
//  Publisher.cs - Gbtc
//
//  Tennessee Valley Authority, 2009
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  This software is made freely available under the TVA Open Source Agreement (see below).
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  07/20/2009 - J. Ritchie Carroll
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
