//*******************************************************************************************************
//  PhasorDataConcentratorBase.cs - Gbtc
//
//  Tennessee Valley Authority, 2009
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  This software is made freely available under the TVA Open Source Agreement (see below).
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  05/26/2009 - J. Ritchie Carroll
//       Generated original version of source code.
//  09/15/2009 - Stephen C. Wills
//       Added new header and license agreement.
//  11/25/2009 - Pinal C. Patel
//       Modified Start() to wait for initialization to complete for thread synchronization.
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
using System.Linq;
using System.Text;
using System.Threading;
using TVA.Communication;
using TVA.Measurements;
using TVA.Measurements.Routing;
using TVA.PhasorProtocols.Anonymous;
using TVA.Units;

namespace TVA.PhasorProtocols
{
    /// <summary>
    /// Represents an <see cref="IActionAdapter"/> used to generate and transmit concentrated stream
    /// of phasor measurements in a specific phasor protocol.
    /// </summary>
    public abstract class PhasorDataConcentratorBase : ActionAdapterBase
    {
        #region [ Design Notes ]

        // These design notes were written prior to the development of this class so they may not completely
        // represent its final design; however, the comments should provide insight into to the reasoning
        // behind the implementation of this class so they are included here for reference purposes.

        // J. Ritchie Carroll

        // **************************************************************************************************

        // We can't assume what devices will appear in the stream - therefore a device list is needed.
        // In addition, a list of active measurements needs to be loaded - that is, the measurements that
        // will make up the data in the device list.  Idealistically one could map any given number of
        // measurements to a device allowing a completely virtually defined device.

        // In the existing system the need for virtual devices was minimal - there is only one virtual
        // device, the EIRA PMU, which defines the calculated interconnection reference angle - this includes
        // an average interconnection frequency - hence you have a virtual device consisting entirely of
        // of composed measurement points. Normally you just want to retransmit the received device data
        // which is forwared as a cell in the combined outgoing data stream - this typically excludes any
        // digital or analog values - but there may be cases where this data should be retransmitted as well.

        // It is fairly straight forward to reverse the process of mapping device signals to measurements
        // using the existing signal references - this requires the definition of input devices to match
        // the definition of output devices. For ultimate flexibility however, you would allow any given
        // measurement to be mapped to a device definition created entirely by hand.

        // To further explore this idea, a normal case would be including a device in the outgoing data
        // stream as it is currently defined in the system. This would mean simply creating a measurement
        // list for this device based on its defined signal references - or one would just load the
        // measurements (filtered by need - i.e., excluding digitals and analogs if needed) for the device
        // as its currently defined. This seems fairly trivial - a simple check box to include an existing
        // device as-is in the outgoing data stream definition.

        // The interesting part will be tweaking the outgoing device definition - for simple definitions
        // the existing signal reference for a measurement will define its purpose in an outgoing device
        // device definition, but for ultimate flexibility any existing measurement can be mapped to a
        // any field in the device definition - this means the measurement will need a signal reference
        // that is defined when the measurement is mapped to the field - a new signal reference that exists
        // solely for this outgoing stream definition.

        // In the end a set of tables needs to exist that defines the outgoing data streams, the devices
        // that will appear in these streams (technically these do not need to already exist) and the
        // points that make up the field defintitions in these devices along with their signal references
        // that designate their destination field location - this will not necessarily be the perordained 
        // signal reference that was used to orginally map this field to a measurement - but rather an
        // outgoing data stream specific signal reference that exists for this measurement mapped into
        // this device.

        // This brings up an interesting notion - measurements in the system will not necessarily have a
        // one-to-one ratio with the outgoing field devices.  What this means is that a single measurement
        // point could be mapped to multiple locations within the same or multiple devices in any
        // variety of outgoing data streams. From a technical perspective as it relates to the measurement
        // concentration engine, a point will still have a destination frame based on its timestamp, but
        // it may have application at various locations (i.e., cell based devices) within that frame.

        // As a result a measurement will need to identify multiple destinations, that is, it may need to
        // track multiple signal references so that the measurement can be applied to all destination
        // field locations during the AssignMeasurementToFrame procedure of the data frame creation stage.

        // As the measurement is assigned to its destination frame by the concentration engine, the method
        // will need to loop through each signal reference assigned to the measurement. The method will then
        // obtain a reference to the data cell by its cell index and assign the measurement to the field
        // location based on the signal type and optional field index (e.g., phasor 1, 2, 3, etc.). This
        // should complete the operation of creating a data frame based on incoming measurements and leave
        // the data frame ready to publish in the next 1/30 of a second.

        // Suggested table definitions for the phasor data concentrator base class:

        //    - OutputStreamDevice          Stream ID, Name, ID, Analog Count, Digital Count, etc.
        //    - OutputStreamPhasor          Device ID, Type (I or V), Name, Order, etc.
        //    - OutputStreamMeasurement     Device ID, MeasurementKey, Destination SignalReference

        // Proposed internal data structures used to collate information:

        // Protocol independent configuration frame that defines all output stream devices
        // Dictionary<MeasurementKey, SignalReference[]> <- multiple possible signal refs per measurement
        // SignalReference defines cell index of associated data cell and signal information

        #endregion

        #region [ Members ]

        // Fields
        private UdpServer m_dataChannel;
        private TcpServer m_commandChannel;
        private IServer m_publishChannel;
        private IConfigurationFrame m_configurationFrame;
        private ConfigurationFrame m_baseConfigurationFrame;
        private Dictionary<MeasurementKey, SignalReference[]> m_signalReferences;
        private LineFrequency m_nominalFrequency;
        private DataFormat m_dataFormat;
        private CoordinateFormat m_coordinateFormat;
        private uint m_currentScalingValue;
        private uint m_voltageScalingValue;
        private uint m_analogScalingValue;
        private uint m_digitalMaskValue;
        private bool m_autoPublishConfigurationFrame;
        private bool m_autoStartDataChannel;
        private bool m_processDataValidFlag;
        private ushort m_idCode;
        private bool m_disposed;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new <see cref="PhasorDataConcentratorBase"/>.
        /// </summary>
        protected PhasorDataConcentratorBase()
        {
            // Create a new signal reference dictionary indexed on measurement keys
            m_signalReferences = new Dictionary<MeasurementKey, SignalReference[]>();

            // Synchrophasor protocols should default to millisecond resolution
            base.TimeResolution = Ticks.PerMillisecond;
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets ID code defined for this <see cref="PhasorDataConcentratorBase"/> parsed from the <see cref="ActionAdapterBase.ConnectionString"/>.
        /// </summary>
        public ushort IDCode
        {
            get
            {
                return m_idCode;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if configuration frame should be automatically published at the top
        /// of each minute on the data channel.
        /// </summary>
        /// <remarks>
        /// By default if no command channel is defined, this flag will be <c>true</c>; otherwise if command channel
        /// is defined the flag will be <c>false</c>.
        /// </remarks>
        public bool AutoPublishConfigurationFrame
        {
            get
            {
                return m_autoPublishConfigurationFrame;
            }
            set
            {
                m_autoPublishConfigurationFrame = value;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if concentrator will automatically start data channel.
        /// </summary>
        /// <remarks>
        /// By default data channel will be started automatically, setting this flag to <c>false</c> will
        /// allow alternate methods of enabling and disabling the real-time data stream (e.g., this can
        /// be used to allow a remote to device to enable and disable data stream if the protocol supports
        /// such commands).
        /// </remarks>
        public bool AutoStartDataChannel
        {
            get
            {
                return m_autoStartDataChannel;
            }
            set
            {
                m_autoStartDataChannel = value;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if the data valid flag assignments should be processed during frame publication.
        /// </summary>
        /// <remarks>
        /// In cases where client applications ignore the data validity flag, setting this flag to <c>false</c> will
        /// provide a slight processing optimization, especially useful on very large data streams.
        /// </remarks>
        public bool ProcessDataValidFlag
        {
            get
            {
                return m_processDataValidFlag;
            }
            set
            {
                m_processDataValidFlag = value;
            }
        }

        /// <summary>
        /// Gets or sets the nominal <see cref="LineFrequency"/> defined for this <see cref="PhasorDataConcentratorBase"/>.
        /// </summary>
        public LineFrequency NominalFrequency
        {
            get
            {
                return m_nominalFrequency;
            }
            set
            {
                m_nominalFrequency = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="PhasorProtocols.DataFormat"/> defined for this <see cref="PhasorDataConcentratorBase"/>.
        /// </summary>
        /// <remarks>
        /// Note that this value represents the default format that will be used if user has not specified a data format for an individual device.
        /// </remarks>
        public DataFormat DataFormat
        {
            get
            {
                return m_dataFormat;
            }
            set
            {
                m_dataFormat = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="PhasorProtocols.CoordinateFormat"/> defined for this <see cref="PhasorDataConcentratorBase"/>.
        /// </summary>
        /// <remarks>
        /// Note that this value represents the default format that will be used if user has not specified a coordinate format for an individual device.
        /// </remarks>
        public CoordinateFormat CoordinateFormat
        {
            get
            {
                return m_coordinateFormat;
            }
            set
            {
                m_coordinateFormat = value;
            }
        }

        /// <summary>
        /// Gets or sets the integer scaling value to apply to current values published by this <see cref="PhasorDataConcentratorBase"/>.
        /// </summary>
        /// <remarks>
        /// Typically only the lower 24-bits will be used to scale current values in 10^–5 amperes per bit. Note that this value represents
        /// the default value that will be used if user has not specified a value for an individual device.
        /// </remarks>
        public uint CurrentScalingValue
        {
            get
            {
                return m_currentScalingValue;
            }
            set
            {
                m_currentScalingValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the integer scaling value to apply to voltage values published by this <see cref="PhasorDataConcentratorBase"/>.
        /// </summary>
        /// <remarks>
        /// Typically only the lower 24-bits will be used to scale voltage values in 10^–5 volts per bit. Note that this value represents
        /// the default value that will be used if user has not specified a value for an individual device.
        /// </remarks>
        public uint VoltageScalingValue
        {
            get
            {
                return m_voltageScalingValue;
            }
            set
            {
                m_voltageScalingValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the integer scaling value to apply to analog values published by this <see cref="PhasorDataConcentratorBase"/>.
        /// </summary>
        /// <remarks>
        /// Typically only the lower 24-bits will be used to scale analog values in 10^–5 units per bit. Note that this value represents
        /// the default value that will be used if user has not specified a value for an individual device.
        /// </remarks>
        public uint AnalogScalingValue
        {
            get
            {
                return m_analogScalingValue;
            }
            set
            {
                m_analogScalingValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the digital mask value made available in configuration frames for use with digital values published by this <see cref="PhasorDataConcentratorBase"/>.
        /// </summary>
        /// <remarks>
        /// This value represents two mask words for use with digital status values. In IEEE C37.118 configuration frames, the two 16-bit words that make up a digital mask
        /// value are provided for each defined digital word. Note that this value represents the default value that will be used if user has not specified a value for an
        /// individual device. The low word will be used to indicate the normal status of the digital inputs by returning a 0 when exclusive ORed (XOR) with the status word.
        /// The high word will indicate the current valid inputs to the PMU by having a bit set in the binary position corresponding to the digital input and all other bits
        /// set to 0. If digital status words are used for something other than boolean status indications, the use is left to the user.
        /// </remarks>
        public uint DigitalMaskValue
        {
            get
            {
                return m_digitalMaskValue;
            }
            set
            {
                m_digitalMaskValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the protocol specific <see cref="IConfigurationFrame"/> used to send to clients for protocol parsing.
        /// </summary>
        public virtual IConfigurationFrame ConfigurationFrame
        {
            get
            {
                return m_configurationFrame;
            }
            set
            {
                m_configurationFrame = value;
            }
        }

        /// <summary>
        /// Gets the protocol independent <see cref="Anonymous.ConfigurationFrame"/> defined for this <see cref="PhasorDataConcentratorBase"/>.
        /// </summary>
        public ConfigurationFrame BaseConfigurationFrame
        {
            get
            {
                return m_baseConfigurationFrame;
            }
        }

        /// <summary>
        /// Gets or sets reference to <see cref="UdpServer"/> data channel, attaching and/or detaching to events as needed.
        /// </summary>
        protected UdpServer DataChannel
        {
            get
            {
                return m_dataChannel;
            }
            set
            {
                if (m_dataChannel != null)
                {
                    // Detach from events on existing data channel reference
                    m_dataChannel.SendClientDataException -= m_dataChannel_SendClientDataException;
                    m_dataChannel.ServerStarted -= m_dataChannel_ServerStarted;
                    m_dataChannel.ServerStopped -= m_dataChannel_ServerStopped;

                    if (m_dataChannel != value)
                        m_dataChannel.Dispose();
                }

                // Assign new data channel reference
                m_dataChannel = value;

                if (m_dataChannel != null)
                {
                    // Attach to events on new data channel reference
                    m_dataChannel.SendClientDataException += m_dataChannel_SendClientDataException;
                    m_dataChannel.ServerStarted += m_dataChannel_ServerStarted;
                    m_dataChannel.ServerStopped += m_dataChannel_ServerStopped;
                }
            }
        }

        /// <summary>
        /// Gets or sets reference to <see cref="TcpServer"/> command channel, attaching and/or detaching to events as needed.
        /// </summary>
        protected TcpServer CommandChannel
        {
            get
            {
                return m_commandChannel;
            }
            set
            {
                if (m_commandChannel != null)
                {
                    // Detach from events on existing command channel reference
                    m_commandChannel.ClientConnected -= m_commandChannel_ClientConnected;
                    m_commandChannel.ClientDisconnected -= m_commandChannel_ClientDisconnected;
                    m_commandChannel.ReceiveClientDataComplete -= m_commandChannel_ReceiveClientDataComplete;
                    m_commandChannel.SendClientDataException -= m_commandChannel_SendClientDataException;
                    m_commandChannel.ServerStarted -= m_commandChannel_ServerStarted;
                    m_commandChannel.ServerStopped -= m_commandChannel_ServerStopped;

                    if (m_commandChannel != value)
                        m_commandChannel.Dispose();
                }

                // Assign new command channel reference
                m_commandChannel = value;

                if (m_commandChannel != null)
                {
                    // Attach to events on new command channel reference
                    m_commandChannel.ClientConnected += m_commandChannel_ClientConnected;
                    m_commandChannel.ClientDisconnected += m_commandChannel_ClientDisconnected;
                    m_commandChannel.ReceiveClientDataComplete += m_commandChannel_ReceiveClientDataComplete;
                    m_commandChannel.SendClientDataException += m_commandChannel_SendClientDataException;
                    m_commandChannel.ServerStarted += m_commandChannel_ServerStarted;
                    m_commandChannel.ServerStopped += m_commandChannel_ServerStopped;
                }
            }
        }

        /// <summary>
        /// Returns the detailed status of this <see cref="PhasorDataConcentratorBase"/>.
        /// </summary>
        public override string Status
        {
            get
            {
                StringBuilder status = new StringBuilder();

                if (m_baseConfigurationFrame != null && m_baseConfigurationFrame.Cells != null)
                {
                    status.AppendFormat("  Total configured devices: {0}", m_baseConfigurationFrame.Cells.Count);
                    status.AppendLine();
                }

                if (m_signalReferences != null)
                {
                    status.AppendFormat(" Total device measurements: {0}", m_signalReferences.Count);
                    status.AppendLine();
                }

                status.AppendFormat(" Auto-publish config frame: {0}", m_autoPublishConfigurationFrame);
                status.AppendLine();
                status.AppendFormat("   Auto-start data channel: {0}", m_autoStartDataChannel);
                status.AppendLine();
                status.AppendFormat("       Data stream ID code: {0}", m_idCode);
                status.AppendLine();
                status.AppendFormat("         Nomimal frequency: {0}Hz", (int)m_nominalFrequency);
                status.AppendLine();
                status.AppendFormat("               Data format: {0}", m_dataFormat);
                status.AppendLine();
                status.AppendFormat("         Coordinate format: {0}", m_coordinateFormat);
                status.AppendLine();

                if (m_dataFormat == DataFormat.FixedInteger)
                {
                    status.AppendFormat("     Current scaling value: {0:00000000} ({1})", m_currentScalingValue, (m_currentScalingValue * 0.00001D).ToString("0.00000"));
                    status.AppendLine();
                    status.AppendFormat("     Voltage scaling value: {0:00000000} ({1})", m_voltageScalingValue, (m_voltageScalingValue * 0.00001D).ToString("0.00000"));
                    status.AppendLine();
                    status.AppendFormat("      Analog scaling value: {0:00000000} ({1})", m_analogScalingValue, (m_analogScalingValue * 0.00001D).ToString("0.00000"));
                    status.AppendLine();
                }

                status.AppendFormat("       Digital normal mask: {0} (big endian)", ByteEncoding.BigEndianBinary.GetString(BitConverter.GetBytes(m_digitalMaskValue.LowWord())));
                status.AppendLine();
                status.AppendFormat(" Digital valid inputs mask: {0} (big endian)", ByteEncoding.BigEndianBinary.GetString(BitConverter.GetBytes(m_digitalMaskValue.HighWord())));
                status.AppendLine();

                if (m_dataChannel != null)
                {
                    status.AppendLine();
                    status.AppendLine("Data Channel Status".CenterText(50));
                    status.AppendLine("-------------------".CenterText(50));
                    status.Append(m_dataChannel.Status);
                }

                if (m_commandChannel != null)
                {
                    status.AppendLine();
                    status.AppendLine("Command Channel Status".CenterText(50));
                    status.AppendLine("----------------------".CenterText(50));
                    status.Append(m_commandChannel.Status);
                }

                status.AppendLine();
                status.Append(base.Status);

                return status.ToString();
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="PhasorDataConcentratorBase"/> object and optionally releases the managed resources.
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
                        // Dispose and detach from data and command channel events
                        this.DataChannel = null;
                        this.CommandChannel = null;
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
        /// Starts the <see cref="PhasorDataConcentratorBase"/>, if it is not already running.
        /// </summary>
        public override void Start()
        {
            // Make sure we are stopped before attempting to start
            if (Enabled)
                Stop();

            // Wait for initialization to complete
            if (WaitForInitialize(InitializationTimeout))
            {
                // Start communications servers
                if (m_autoStartDataChannel && m_dataChannel != null && m_dataChannel.CurrentState == ServerState.NotRunning)
                    m_dataChannel.Start();

                if (m_commandChannel != null && m_commandChannel.CurrentState == ServerState.NotRunning)
                    m_commandChannel.Start();

                // Base action adapter gets started once data channel has been started (see m_dataChannel_ServerStarted)
                // so that the system doesn't attempt to start frame publication without an operational output data channel
                // when m_autoStartDataChannel is set to false. Otherwise if data is being published on command channel,
                // we go ahead and start concentration engine...
                if (m_publishChannel == m_commandChannel)
                    base.Start();
            }
            else
                OnProcessException(new TimeoutException("Failed to start phasor data concentrator due to timeout waiting for initialization."));
        }

        /// <summary>
        /// Stops the <see cref="PhasorDataConcentratorBase"/>.
        /// </summary>
        public override void Stop()
        {
            // Stop concentration engine
            base.Stop();

            // Stop communications servers
            if (m_dataChannel != null)
                m_dataChannel.Stop();

            if (m_commandChannel != null)
                m_commandChannel.Stop();
        }

        /// <summary>
        /// Starts the <see cref="PhasorDataConcentratorBase"/> real-time data stream.
        /// </summary>
        /// <remarks>
        /// If <see cref="AutoStartDataChannel"/> is <c>false</c>, this method will allow host administrator
        /// to manually start the data channel, thus enabling the real-time data stream. If command channel
        /// is defined, it will be unaffected. 
        /// </remarks>
        [AdapterCommand("Manually starts the real-time data stream.")]
        public virtual void StartDataChannel()
        {
            // Start data channel
            if (m_dataChannel != null)
                m_dataChannel.Start();
        }

        /// <summary>
        /// Stops the <see cref="PhasorDataConcentratorBase"/> real-time data stream.
        /// </summary>
        /// <remarks>
        /// This method will allow host administrator to manually stop the data channel, thus disabling
        /// the real-time data stream. If command channel is defined, it will be unaffected.
        /// </remarks>
        [AdapterCommand("Manually stops the real-time data stream.")]
        public virtual void StopDataChannel()
        {
            // Stop concentration engine - this is done before stopping data channel since frames may still be
            // publishing while engine is stopping...
            base.Stop();

            // Stop data channel
            if (m_dataChannel != null)
                m_dataChannel.Stop();
        }

        /// <summary>
        /// Initializes <see cref="PhasorDataConcentratorBase"/>.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            string errorMessage = "{0} is missing from Settings - Example: IDCode=235; dataChannel={Port=0; Clients=localhost:8800}";

            Dictionary<string, string> settings = Settings;
            string setting, dataChannel, commandChannel;

            // Load required parameters
            if (!settings.TryGetValue("IDCode", out setting))
                throw new ArgumentException(string.Format(errorMessage, "IDCode"));

            m_idCode = ushort.Parse(setting);
            settings.TryGetValue("dataChannel", out dataChannel);
            settings.TryGetValue("commandChannel", out commandChannel);

            // Data channel and/or command channel must be defined
            if (string.IsNullOrEmpty(dataChannel) && string.IsNullOrEmpty(commandChannel))
                throw new InvalidOperationException("A data channel or command channel must be defined for a concentrator.");

            // Load optional parameters
            if (settings.TryGetValue("autoPublishConfigFrame", out setting))
                m_autoPublishConfigurationFrame = setting.ParseBoolean();
            else
                m_autoPublishConfigurationFrame = string.IsNullOrEmpty(commandChannel);

            if (settings.TryGetValue("autoStartDataChannel", out setting))
                m_autoStartDataChannel = setting.ParseBoolean();
            else
                m_autoStartDataChannel = true;

            if (settings.TryGetValue("nominalFrequency", out setting))
                m_nominalFrequency = (LineFrequency)int.Parse(setting);
            else
                m_nominalFrequency = LineFrequency.Hz60;

            if (settings.TryGetValue("dataFormat", out setting))
                m_dataFormat = (DataFormat)Enum.Parse(typeof(DataFormat), setting, true);
            else
                m_dataFormat = DataFormat.FloatingPoint;

            if (settings.TryGetValue("coordinateFormat", out setting))
                m_coordinateFormat = (CoordinateFormat)Enum.Parse(typeof(CoordinateFormat), setting, true);
            else
                m_coordinateFormat = CoordinateFormat.Polar;

            if (settings.TryGetValue("currentScalingValue", out setting))
            {
                if (!uint.TryParse(setting, out m_currentScalingValue))
                    m_currentScalingValue = unchecked((uint)int.Parse(setting));
            }
            else
                m_currentScalingValue = 2423U;

            if (settings.TryGetValue("voltageScalingValue", out setting))
            {
                if (!uint.TryParse(setting, out m_voltageScalingValue))
                    m_voltageScalingValue = unchecked((uint)int.Parse(setting));
            }
            else
                m_voltageScalingValue = 2725785U;

            if (settings.TryGetValue("analogScalingValue", out setting))
            {
                if (!uint.TryParse(setting, out m_analogScalingValue))
                    m_analogScalingValue = unchecked((uint)int.Parse(setting));
            }
            else
                m_analogScalingValue = 1373291U;

            if (settings.TryGetValue("digitalMaskValue", out setting))
            {
                if (!uint.TryParse(setting, out m_digitalMaskValue))
                    m_digitalMaskValue = unchecked((uint)int.Parse(setting));
            }
            else
                m_digitalMaskValue = Word.MakeDword(0xFFFF, 0x0000);

            if (settings.TryGetValue("processDataValidFlag", out setting))
                m_processDataValidFlag = setting.ParseBoolean();
            else
                m_processDataValidFlag = true;

            // Initialize data channel if defined
            if (!string.IsNullOrEmpty(dataChannel))
                this.DataChannel = new UdpServer(dataChannel);
            else
                this.DataChannel = null;

            // Initialize command channel if defined
            if (!string.IsNullOrEmpty(commandChannel))
                this.CommandChannel = new TcpServer(commandChannel);
            else
                this.CommandChannel = null;

            // If data channel is not defined and command channel is defined system assumes you
            // want to make data available over TCP connection
            if (m_dataChannel == null && m_commandChannel != null)
                m_publishChannel = m_commandChannel;
            else
                m_publishChannel = m_dataChannel;

            // Create the configuration frame
            UpdateConfiguration();
        }

        /// <summary>
        /// Reloads the configuration for this <see cref="PhasorDataConcentratorBase"/>.
        /// </summary>
        [AdapterCommand("Reloads the phasor data concentrator configuration.")]
        public void UpdateConfiguration()
        {
            const int labelLength = 16;
            Dictionary<string, int> signalCellIndexes = new Dictionary<string, int>();
            ConfigurationCell cell;
            SignalReference signal;
            SignalReference[] signals;
            MeasurementKey measurementKey;
            PhasorType type;
            AnalogType analogType;
            char phase;
            string label, scale;
            uint scalingValue;
            int order;

            // Define a protocol independent configuration frame
            m_baseConfigurationFrame = new ConfigurationFrame(m_idCode, DateTime.UtcNow.Ticks, (ushort)base.FramesPerSecond);

            // Define configuration cells (i.e., PMU's that will appear in outgoing data stream)
            foreach (DataRow deviceRow in DataSource.Tables["OutputStreamDevices"].Select(string.Format("ParentID={0}", ID), "LoadOrder"))
            {
                try
                {
                    // Create a new configuration cell
                    cell = new ConfigurationCell(m_baseConfigurationFrame, ushort.Parse(deviceRow["ID"].ToString()));

                    // Assign user selected data and coordinate formats, derived classes can change
                    cell.PhasorDataFormat = (DataFormat)Enum.Parse(typeof(DataFormat), deviceRow["PhasorDataFormat"].ToNonNullString(m_dataFormat.ToString()));
                    cell.FrequencyDataFormat = (DataFormat)Enum.Parse(typeof(DataFormat), deviceRow["FrequencyDataFormat"].ToNonNullString(m_dataFormat.ToString()));
                    cell.AnalogDataFormat = (DataFormat)Enum.Parse(typeof(DataFormat), deviceRow["AnalogDataFormat"].ToNonNullString(m_dataFormat.ToString()));
                    cell.PhasorCoordinateFormat = (CoordinateFormat)Enum.Parse(typeof(CoordinateFormat), deviceRow["CoordinateFormat"].ToNonNullString(m_coordinateFormat.ToString()));

                    // Assign device identification labels
                    cell.IDLabel = deviceRow["Name"].ToString().Trim();
                    cell.StationName = deviceRow["Acronym"].ToString().TruncateRight(cell.MaximumStationNameLength).Trim();

                    // Define all the phasors configured for this device
                    foreach (DataRow phasorRow in DataSource.Tables["OutputStreamDevicePhasors"].Select(string.Format("OutputStreamDeviceID={0}", cell.IDCode), "LoadOrder"))
                    {
                        order = int.Parse(phasorRow["LoadOrder"].ToNonNullString("0"));
                        label = phasorRow["Label"].ToNonNullString("Phasor " + order).Trim().RemoveDuplicateWhiteSpace().TruncateRight(labelLength - 4);
                        type = phasorRow["Type"].ToNonNullString("V").Trim().ToUpper().StartsWith("V") ? PhasorType.Voltage : PhasorType.Current;
                        phase = phasorRow["Phase"].ToNonNullString("+").Trim().ToUpper()[0];
                        scale = phasorRow["ScalingValue"].ToNonNullString("0");

                        // Scale can be defined as a negative value in database, so check both formatting styles
                        if (!uint.TryParse(scale, out scalingValue))
                            scalingValue = unchecked((uint)int.Parse(scale));

                        // Choose stream defined default value if no scaling value was defined
                        if (scalingValue == 0)
                            scalingValue = (type == PhasorType.Voltage ? m_voltageScalingValue : m_currentScalingValue);

                        cell.PhasorDefinitions.Add(
                            new PhasorDefinition(
                                cell,
                                GeneratePhasorLabel(label, phase, type),
                                scalingValue,
                                type,
                                null));
                    }

                    // Add frequency definition
                    label = string.Format("{0} Freq", cell.IDLabel.TruncateRight(labelLength - 5)).Trim();
                    cell.FrequencyDefinition = new FrequencyDefinition(cell, label);

                    // Optionally define all the analogs configured for this device
                    if (DataSource.Tables.Contains("OutputStreamDeviceAnalogs"))
                    {
                        foreach (DataRow analogRow in DataSource.Tables["OutputStreamDeviceAnalogs"].Select(string.Format("OutputStreamDeviceID={0}", cell.IDCode), "LoadOrder"))
                        {
                            order = int.Parse(analogRow["LoadOrder"].ToNonNullString("0"));
                            label = analogRow["Label"].ToNonNullString("Analog " + order).Trim().RemoveDuplicateWhiteSpace().TruncateRight(labelLength);
                            analogType = analogRow["AnalogType"].ToNonNullString("SinglePointOnWave").ConvertToType<AnalogType>();
                            scale = analogRow["ScalingValue"].ToNonNullString("0");

                            // Scale can be defined as a negative value in database, so check both formatting styles
                            if (!uint.TryParse(scale, out scalingValue))
                                scalingValue = unchecked((uint)int.Parse(scale));

                            cell.AnalogDefinitions.Add(
                                new AnalogDefinition(
                                    cell,
                                    label,
                                    scalingValue == 0 ? m_analogScalingValue : scalingValue,
                                    analogType));
                        }                            
                    }

                    // Optionally define all the digitals configured for this device
                    if (DataSource.Tables.Contains("OutputStreamDeviceDigitals"))
                    {
                        foreach (DataRow digitalRow in DataSource.Tables["OutputStreamDeviceDigitals"].Select(string.Format("OutputStreamDeviceID={0}", cell.IDCode), "LoadOrder"))
                        {
                            order = int.Parse(digitalRow["LoadOrder"].ToNonNullString("0"));
                            scale = digitalRow["MaskValue"].ToNonNullString("0");

                            // IEEE C37.118 digital labels are defined with all 16-labels (one for each bit) in one large formatted
                            // string - so we don't remove duplicate white space in this string
                            label = digitalRow["Label"].ToNonNullString("Digital " + order).Trim().TruncateRight(labelLength * 16);

                            // Mask can be defined as a negative value in database, so check both formatting styles
                            if (!uint.TryParse(scale, out scalingValue))
                                scalingValue = unchecked((uint)int.Parse(scale));

                            cell.DigitalDefinitions.Add(
                                new DigitalDefinition(
                                    cell,
                                    label,
                                    scalingValue == 0 ? m_digitalMaskValue : scalingValue));
                        }
                    }

                    m_baseConfigurationFrame.Cells.Add(cell);
                }
                catch (Exception ex)
                {
                    OnProcessException(new InvalidOperationException(string.Format("Failed to define output stream device \"{0}\" due to exception: {1}", deviceRow["Acronym"].ToString().Trim(), ex.Message), ex));
                }
            }

            OnStatusMessage("Defined {0} output stream devices...", m_baseConfigurationFrame.Cells.Count);

            // Clear any existing signal references
            m_signalReferences.Clear();

            // Define measurement to signals cross reference dictionary
            foreach (DataRow measurementRow in DataSource.Tables["OutputStreamMeasurements"].Select(string.Format("AdapterID={0}", ID)))
            {
                try
                {
                    // Create a new signal reference
                    signal = new SignalReference(measurementRow["SignalReference"].ToString());

                    // Lookup cell index by acronym - doing this work upfront will save a huge amount
                    // of work during primary measurement sorting
                    if (!signalCellIndexes.TryGetValue(signal.Acronym, out signal.CellIndex))
                    {
                        // We cache these indicies locally to speed up initialization as we'll be
                        // requesting them for the same devices over and over
                        signal.CellIndex = m_baseConfigurationFrame.Cells.IndexOfStationName(signal.Acronym);
                        signalCellIndexes.Add(signal.Acronym, signal.CellIndex);
                    }

                    // No need to define this measurement for sorting unless it has a destination in the outgoing frame
                    if (signal.CellIndex > -1)
                    {
                        // Define measurement key
                        measurementKey = new MeasurementKey(uint.Parse(measurementRow["PointID"].ToString()), measurementRow["Historian"].ToString());

                        // It is possible, but not as common, that a measurement will have multiple destinations
                        // within an outgoing data stream frame, hence the following
                        if (m_signalReferences.TryGetValue(measurementKey, out signals))
                        {
                            // Add a new signal to existing collection
                            List<SignalReference> signalList = new List<SignalReference>(signals);
                            signalList.Add(signal);
                            m_signalReferences[measurementKey] = signalList.ToArray();
                        }
                        else
                        {
                            // Add new signal to new collection
                            signals = new SignalReference[1];
                            signals[0] = signal;
                            m_signalReferences.Add(measurementKey, signals);
                        }
                    }
                }
                catch (Exception ex)
                {
                    OnProcessException(new InvalidOperationException(string.Format("Failed to associate measurement key to signal reference \"{0}\" due to exception: {1}", measurementRow["SignalReference"].ToString().Trim(), ex.Message), ex));
                }
            }

            // Assign action adapter input measurement keys - this assigns the expected measurements per frame needed
            // by the concentration engine for preemptive publication 
            InputMeasurementKeys = m_signalReferences.Keys.ToArray();

            // Create a new protocol specific configuration frame
            m_configurationFrame = CreateNewConfigurationFrame(m_baseConfigurationFrame);

            // Cache new protocol specific configuration frame
            CacheConfigurationFrame(m_configurationFrame, Name);
        }

        /// <summary>
        /// Queues a single measurement for processing.
        /// </summary>
        /// <param name="measurement">Measurement to queue for processing.</param>
        public override void QueueMeasurementForProcessing(IMeasurement measurement)
        {
            QueueMeasurementsForProcessing(new IMeasurement[] { measurement });
        }

        /// <summary>
        /// Queues a collection of measurements for processing.
        /// </summary>
        /// <param name="measurements">Collection of measurements to queue for processing.</param>
        public override void QueueMeasurementsForProcessing(IEnumerable<IMeasurement> measurements)
        {
            List<IMeasurement> inputMeasurements = new List<IMeasurement>();
            SignalReference[] signals;

            foreach (IMeasurement measurement in measurements)
            {
                // We assign signal reference to measurement in advance since we are using this as a filter
                // anyway, this will save a lookup later during measurement assignment to frame...
                if (m_signalReferences.TryGetValue(measurement.Key, out signals))
                {
                    // Loop through each signal reference defined for this measurement - this handles
                    // the case where there can be more than one destination for a measurement within
                    // an outgoing phasor data frame
                    foreach (SignalReference signal in signals)
                    {
                        inputMeasurements.Add(new SignalReferenceMeasurement(measurement, signal));
                    }
                }
            }

            if (inputMeasurements.Count > 0)
                SortMeasurements(inputMeasurements);
        }

        /// <summary>
        /// Assign <see cref="IMeasurement"/> to its <see cref="IFrame"/>.
        /// </summary>
        /// <param name="frame"><see cref="IFrame"/> to assign <paramref name="measurement"/> to.</param>
        /// <param name="measurement"><see cref="IMeasurement"/> to assign to <paramref name="frame"/>.</param>
        /// <returns><c>true</c> if <see cref="IMeasurement"/> was successfully assigned to its <see cref="IFrame"/>.</returns>
        /// <remarks>
        /// In simple concentration scenarios all you need to do is assign a measurement to its frame based on
        /// time. In the case of a phasor data concentrator you need to assign a measurement to its particular
        /// location in its <see cref="IDataFrame"/> - so this method overrides the default behavior in order
        /// to accomplish this task.
        /// </remarks>
        protected override bool AssignMeasurementToFrame(IFrame frame, IMeasurement measurement)
        {
            IDictionary<MeasurementKey, IMeasurement> measurements = frame.Measurements;

            lock (measurements)
            {
                if (!frame.Published)
                {
                    // Make sure the measurement is a "SignalReferenceMeasurement" (it should be)
                    SignalReferenceMeasurement signalMeasurement = measurement as SignalReferenceMeasurement;
                    IDataFrame dataFrame = frame as IDataFrame;

                    if ((object)signalMeasurement != null && dataFrame != null)
                    {
                        PhasorValueCollection phasorValues;
                        SignalReference signal = signalMeasurement.SignalReference;
                        IDataCell dataCell = dataFrame.Cells[signal.CellIndex];
                        int signalIndex = signal.Index;

                        // Assign measurement to its destination field in the data cell based on signal type
                        switch (signal.Type)
                        {
                            case FundamentalSignalType.Angle:
                                // Assign "phase angle" measurement to data cell
                                phasorValues = dataCell.PhasorValues;
                                if (phasorValues.Count >= signalIndex)
                                    phasorValues[signalIndex - 1].Angle = Angle.FromDegrees(signalMeasurement.AdjustedValue);
                                break;
                            case FundamentalSignalType.Magnitude:
                                // Assign "phase magnitude" measurement to data cell
                                phasorValues = dataCell.PhasorValues;
                                if (phasorValues.Count >= signalIndex)
                                    phasorValues[signalIndex - 1].Magnitude = signalMeasurement.AdjustedValue;
                                break;
                            case FundamentalSignalType.Frequency:
                                // Assign "frequency" measurement to data cell
                                dataCell.FrequencyValue.Frequency = signalMeasurement.AdjustedValue;
                                break;
                            case FundamentalSignalType.DfDt:
                                // Assign "dF/dt" measurement to data cell
                                dataCell.FrequencyValue.DfDt = signalMeasurement.AdjustedValue;
                                break;
                            case FundamentalSignalType.Status:
                                // Assign "common status flags" measurement to data cell
                                dataCell.CommonStatusFlags = unchecked((uint)signalMeasurement.AdjustedValue);

                                // Assign by arrival sorting flag for bad synchronization
                                if (!dataCell.SynchronizationIsValid && AllowSortsByArrival && !IgnoreBadTimestamps)
                                    dataCell.DataSortingType = DataSortingType.ByArrival;
                                break;
                            case FundamentalSignalType.Digital:
                                // Assign "digital" measurement to data cell
                                DigitalValueCollection digitalValues = dataCell.DigitalValues;
                                if (digitalValues.Count >= signalIndex)
                                    digitalValues[signalIndex - 1].Value = unchecked((ushort)signalMeasurement.AdjustedValue);
                                break;
                            case FundamentalSignalType.Analog:
                                // Assign "analog" measurement to data cell
                                AnalogValueCollection analogValues = dataCell.AnalogValues;
                                if (analogValues.Count >= signalIndex)
                                    analogValues[signalIndex - 1].Value = signalMeasurement.AdjustedValue;
                                break;
                        }

                        // So that we can accurately track the total measurements that were sorted into this frame,
                        // we also assign measurement to frame's measurement dictionary - this is important since
                        // in downsampling scenarios more than one of the same measurement can be sorted into a frame
                        // but this only needs to be counted as "one" sort so that when preemptive publishing is
                        // enabled you can compare expected measurements to sorted measurements...
                        measurements[measurement.Key] = measurement;

                        return true;
                    }

                    // This is not expected to occur - but just in case
                    if ((object)signalMeasurement == null && measurement != null)
                        OnProcessException(new InvalidCastException(string.Format("Attempt was made to assign an invalid measurement to phasor data concentration frame, expected a \"SignalReferenceMeasurement\" but received a \"{0}\"", measurement.GetType().Name)));

                    if (dataFrame == null && frame != null)
                        OnProcessException(new InvalidCastException(string.Format("During measurement assignment, incoming frame was not a phasor data concentration frame, expected a type derived from \"IDataFrame\" but received a \"{0}\"", frame.GetType().Name)));
                }
            }

            return false;
        }

        /// <summary>
        /// Publish <see cref="IFrame"/> of time-aligned collection of <see cref="IMeasurement"/> values that arrived within the
        /// concentrator's defined <see cref="ConcentratorBase.LagTime"/>.
        /// </summary>
        /// <param name="frame"><see cref="IFrame"/> of measurements with the same timestamp that arrived within <see cref="ConcentratorBase.LagTime"/> that are ready for processing.</param>
        /// <param name="index">Index of <see cref="IFrame"/> within a second ranging from zero to <c><see cref="ConcentratorBase.FramesPerSecond"/> - 1</c>.</param>
        protected override void PublishFrame(IFrame frame, int index)
        {
            IDataFrame dataFrame = frame as IDataFrame;

            if (dataFrame != null)
            {
                byte[] image;

                // Send the configuration frame at the top of each minute if the class has been configured
                // to automatically publish the configuration frame over the data channel
                if (m_autoPublishConfigurationFrame && index == 0 && ((DateTime)dataFrame.Timestamp).Second == 0)
                {
                    // Publish configuration frame binary image
                    m_configurationFrame.Timestamp = dataFrame.Timestamp;
                    image = m_configurationFrame.BinaryImage;
                    m_publishChannel.MulticastAsync(image, 0, image.Length);
                }

                // If the expected values did not arrive for a device, we mark the data as invalid
                if (m_processDataValidFlag)
                {
                    foreach (IDataCell cell in dataFrame.Cells)
                    {
                        if (!cell.AllValuesAssigned)
                            cell.DataIsValid = false;
                    }
                }

                // Publish data frame binary image
                image = dataFrame.BinaryImage;
                m_publishChannel.MulticastAsync(image, 0, image.Length);
            }
        }

        /// <summary>
        /// Handles incoming commands from devices connected over the command channel.
        /// </summary>
        /// <param name="clientID">Guid of client that sent the command.</param>
        /// <param name="commandBuffer">Data buffer received from connected client device.</param>
        /// <param name="length">Valid length of data within the buffer.</param>
        /// <remarks>
        /// This method should be overriden by derived classes in order to handle incoming commands,
        /// specifically handling requests for configuration frames.
        /// </remarks>
        protected virtual void DeviceCommandHandler(Guid clientID, byte[] commandBuffer, int length)
        {
            // This is optionally overridden to handle incoming data - such as IEEE commands
        }

        /// <summary>
        /// Creates a new protocol specific <see cref="IConfigurationFrame"/> based on provided protocol independent <paramref name="baseConfigurationFrame"/>.
        /// </summary>
        /// <param name="baseConfigurationFrame">Protocol independent <paramref name="IConfigurationFrame"/>.</param>
        /// <returns>A new protocol specific <see cref="IConfigurationFrame"/>.</returns>
        /// <remarks>
        /// Derived classes should notify consumers of change in configuration if system is active when
        /// new configuration frame is created if outgoing protocol allows such a notfication.
        /// </remarks>
        protected abstract IConfigurationFrame CreateNewConfigurationFrame(ConfigurationFrame baseConfigurationFrame);

        /// <summary>
        /// Serialize configuration frame to cache folder for later use (if needed).
        /// </summary>
        /// <param name="configurationFrame">New <see cref="IConfigurationFrame"/> to cache.</param>
        /// <param name="name">Name to use when caching the <paramref name="configurationFrame"/>.</param>
        /// <remarks>
        /// Derived concentrators can call this method to manually serialize their protocol specific
        /// configuration frames. Note that after initial call to <see cref="CreateNewConfigurationFrame"/>
        /// this method will be call automatically.
        /// </remarks>
        protected void CacheConfigurationFrame(IConfigurationFrame configurationFrame, string name)
        {
            // Cache configuration frame for reference
            OnStatusMessage("Caching configuration frame...");

            // Cache configuration on an independent thread in case this takes some time
            ThreadPool.QueueUserWorkItem(TVA.PhasorProtocols.Anonymous.ConfigurationFrame.Cache,
                new EventArgs<IConfigurationFrame, Action<Exception>, string>(configurationFrame, OnProcessException, name));
        }

        #region [ Data Channel Event Handlers ]

        private void m_dataChannel_SendClientDataException(object sender, EventArgs<Guid, Exception> e)
        {
            Exception ex = e.Argument2;
            OnProcessException(new InvalidOperationException(string.Format("Data channel exception occurred while sending client data: {0}", ex.Message), ex));
        }

        private void m_dataChannel_ServerStarted(object sender, EventArgs e)
        {
            // Start concentration engine
            base.Start();

            OnStatusMessage("Data channel started.");
        }

        private void m_dataChannel_ServerStopped(object sender, EventArgs e)
        {
            OnStatusMessage("Data channel stopped.");
        }

        #endregion

        #region [ Command Channel Event Handlers ]

        private void m_commandChannel_ClientConnected(object sender, EventArgs<Guid> e)
        {
            OnStatusMessage("Client connected to command channel.");
        }

        private void m_commandChannel_ClientDisconnected(object sender, EventArgs<Guid> e)
        {
            OnStatusMessage("Client disconnected from command channel.");
        }

        private void m_commandChannel_ReceiveClientDataComplete(object sender, EventArgs<Guid, byte[], int> e)
        {
            DeviceCommandHandler(e.Argument1, e.Argument2, e.Argument3);
        }

        private void m_commandChannel_SendClientDataException(object sender, EventArgs<Guid, Exception> e)
        {
            Exception ex = e.Argument2;
            OnProcessException(new InvalidOperationException(string.Format("Command channel exception occurred while sending client data: {0}", ex.Message), ex));
        }

        private void m_commandChannel_ServerStarted(object sender, EventArgs e)
        {
            OnStatusMessage("Command channel started.");
        }

        private void m_commandChannel_ServerStopped(object sender, EventArgs e)
        {
            OnStatusMessage("Command channel stopped.");
        }

        #endregion

        #endregion

        #region [ Static ]

        // Static Methods

        // Generate a descriptive phasor label
        private static string GeneratePhasorLabel(string phasorlabel, char phase, PhasorType type)
        {
            StringBuilder label = new StringBuilder();

            label.Append(phasorlabel);

            switch (phase)
            {
                case '+':   // Positive sequence
                    label.Append(" +S");
                    break;
                case '-':   // Negative sequence
                    label.Append(" -S");
                    break;
                case '0':   // Zero sequence
                    label.Append(" 0S");
                    break;
                case 'A':   // A-Phase
                    label.Append(" AP");
                    break;
                case 'B':   // B-Phase
                    label.Append(" BP");
                    break;
                case 'C':   // C-Phase
                    label.Append(" CP");
                    break;
                default:    // Undetermined
                    label.Append(" ??");
                    break;
            }

            label.Append(type == PhasorType.Voltage ? 'V' : 'I');

            return label.ToString();
        }

        #endregion
    }
}