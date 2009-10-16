//*******************************************************************************************************
//  PhasorMeasurementMapper.cs - Gbtc
//
//  Tennessee Valley Authority, 2009
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  This software is made freely available under the TVA Open Source Agreement (see below).
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  05/18/2009 - J. Ritchie Carroll
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
using System.Data;
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
    /// Represents an <see cref="IInputAdapter"/> used to map measured values from a connection
    /// to a phasor measurement device to new <see cref="IMeasurement"/> values.
    /// </summary>
    public class PhasorMeasurementMapper : InputAdapterBase
    {
        #region [ Members ]

        // Fields
        private MultiProtocolFrameParser m_frameParser;
        private Dictionary<string, IMeasurement> m_definedMeasurements;
        private Dictionary<ushort, ConfigurationCell> m_definedDevices;
        private Dictionary<string, long> m_undefinedDevices;
        private System.Timers.Timer m_dataStreamMonitor;
        private TimeZoneInfo m_timezone;
        private Ticks m_timeAdjustmentTicks;
        private Ticks m_lastReportTime;
        private ushort m_accessID;
        private bool m_isConcentrator;
        private bool m_receivedConfigFrame;
        private long m_bytesReceived;
        private bool m_disposed;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new <see cref="PhasorMeasurementMapper"/>.
        /// </summary>
        public PhasorMeasurementMapper()
        {
            m_dataStreamMonitor = new System.Timers.Timer();
            m_dataStreamMonitor.Elapsed += m_dataStreamMonitor_Elapsed;
            m_dataStreamMonitor.AutoReset = true;
            m_dataStreamMonitor.Enabled = false;

            m_undefinedDevices = new Dictionary<string, long>();
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets flag that determines if device being mapped is a concentrator (i.e., data from multiple
        /// devices combined together from the connected device).
        /// </summary>
        public bool IsConcentrator
        {
            get
            {
                return m_isConcentrator;
            }
        }

        /// <summary>
        /// Gets or sets access ID (or ID code) for this device connection which is often necessary in order to make a connection to some phasor protocols.
        /// </summary>
        public ushort AccessID
        {
            get
            {
                return m_accessID;
            }
            set
            {
                m_accessID = value;
            }
        }
        
        /// <summary>
        /// Gets or sets time zone of this <see cref="PhasorMeasurementMapper"/>.
        /// </summary>
        /// <remarks>
        /// If time zone of clock of connected device is not set to UTC, assigning this property
        /// with proper time zone will allow proper adjustment.
        /// </remarks>
        public TimeZoneInfo TimeZone
        {
            get
            {
                return m_timezone;
            }
            set
            {
                m_timezone = value;
            }
        }

        /// <summary>
        /// Gets or sets ticks used to manually adjust time of this <see cref="PhasorMeasurementMapper"/>.
        /// </summary>
        /// <remarks>
        /// This property will allow for precise time adjustments of connected devices should
        /// this be needed.
        /// </remarks>
        public Ticks TimeAdjustmentTicks
        {
            get
            {
                return m_timeAdjustmentTicks;
            }
            set
            {
                m_timeAdjustmentTicks = value;
            }
        }

        /// <summary>
        /// Gets or set last report time for current mapper connection.
        /// </summary>
        public Ticks LastReportTime
        {
            get
            {
                return m_lastReportTime;
            }
            set
            {
                m_lastReportTime = value;
            }
        }

        /// <summary>
        /// Gets flag that determines if the data input connects asynchronously.
        /// </summary>
        protected override bool UseAsyncConnect
        {
            get
            {
                // We use asynchronous connection on devices
                return true;
            }
        }

        /// <summary>
        /// Returns the detailed status of the data input source.
        /// </summary>
        public override string Status
        {
            get
            {
				StringBuilder status = new StringBuilder();

                status.Append(base.Status);
                status.AppendFormat("    Source is concentrator: {0}", m_isConcentrator);
                status.AppendLine();
                status.AppendFormat("   Source device time zone: {0}", m_timezone.Id);
                status.AppendLine();
                status.AppendFormat("    Manual time adjustment: {0} seconds", m_timeAdjustmentTicks.ToSeconds().ToString("0.000"));
                status.AppendLine();
                
                if (m_frameParser != null)
                    status.Append(m_frameParser.Status);

                status.AppendLine();
                status.Append("Parsed Frame Quality Statistics".CenterText(78));
                status.AppendLine();
                status.AppendLine();
                //                      1         2         3         4         5         6         7
                //             123456789012345678901234567890123456789012345678901234567890123456789012345678
                status.Append("Device                  Bad Data   Bad Time    Frame      Total    Last Report");
                status.AppendLine();
                status.Append(" Name                    Frames     Frames     Errors     Frames      Time");
                status.AppendLine();
                //                      1         2            1          1          1          1          1
                //             1234567890123456789012 1234567890 1234567890 1234567890 1234567890 123456789012
                status.Append("---------------------- ---------- ---------- ---------- ---------- ------------");
                status.AppendLine();

                IConfigurationCell parsedDevice;
                string stationName;

                foreach (ConfigurationCell definedDevice in m_definedDevices.Values)
                {
                    stationName = null;

                    // Attempt to lookup station name in configuration frame of connected device
                    if (m_frameParser != null && m_frameParser.ConfigurationFrame != null && m_frameParser.ConfigurationFrame.Cells.TryGetByIDCode(definedDevice.IDCode, out parsedDevice))
                        stationName = parsedDevice.StationName;

                    // We will default to defined name if parsed name is unavailable
                    if (string.IsNullOrEmpty(stationName))
                        stationName = "[" + definedDevice.IDLabel + "]";

                    status.Append(stationName.TruncateRight(22).PadRight(22));
                    status.Append(' ');
                    status.Append(definedDevice.TotalDataQualityErrors.ToString().CenterText(10));
                    status.Append(' ');
                    status.Append(definedDevice.TotalTimeQualityErrors.ToString().CenterText(10));
                    status.Append(' ');
                    status.Append(definedDevice.TotalDeviceErrors.ToString().CenterText(10));
                    status.Append(' ');
                    status.Append(definedDevice.TotalFrames.ToString().CenterText(10));
                    status.Append(' ');
                    status.Append(((DateTime)definedDevice.LastReportTime).ToString("HH:mm:ss.fff"));
                    status.AppendLine();
                }
				
				status.AppendLine();
                status.AppendFormat("Undefined devices encountered: {0}", m_undefinedDevices.Count);
                status.AppendLine();

                lock (m_undefinedDevices)
                {
                    foreach (KeyValuePair<string, long> item in m_undefinedDevices)
                    {
                        status.Append("    Device \"");
                        status.Append(item.Key);
                        status.Append("\" encountered ");
                        status.Append(item.Value);
                        status.Append(" times");
                        status.AppendLine();
                    }
                }
				
				return status.ToString();
            }
        }

        /// <summary>
        /// Gets or sets reference to <see cref="MultiProtocolFrameParser"/>, attaching and/or detaching to events as needed.
        /// </summary>
        protected MultiProtocolFrameParser FrameParser
        {
            get
            {
                return m_frameParser;
            }
            set
            {
                if (m_frameParser != null)
                {
                    // Detach from events on existing frame parser reference
                    m_frameParser.ConfigurationChanged -= m_frameParser_ConfigurationChanged;
                    m_frameParser.ConnectionAttempt -= m_frameParser_ConnectionAttempt;
                    m_frameParser.ConnectionEstablished -= m_frameParser_ConnectionEstablished;
                    m_frameParser.ConnectionException -= m_frameParser_ConnectionException;
                    m_frameParser.ConnectionTerminated -= m_frameParser_ConnectionTerminated;
                    m_frameParser.ParsingException -= m_frameParser_ParsingException;
                    m_frameParser.ReceivedConfigurationFrame -= m_frameParser_ReceivedConfigurationFrame;
                    m_frameParser.ReceivedDataFrame -= m_frameParser_ReceivedDataFrame;
                    m_frameParser.ReceivedFrameBufferImage -= m_frameParser_ReceivedFrameBufferImage;
                    m_frameParser.Dispose();
                }

                // Assign new frame parser reference
                m_frameParser = value;

                if (m_frameParser != null)
                {
                    // Attach to events on new frame parser reference
                    m_frameParser.ConfigurationChanged += m_frameParser_ConfigurationChanged;
                    m_frameParser.ConnectionAttempt += m_frameParser_ConnectionAttempt;
                    m_frameParser.ConnectionEstablished += m_frameParser_ConnectionEstablished;
                    m_frameParser.ConnectionException += m_frameParser_ConnectionException;
                    m_frameParser.ConnectionTerminated += m_frameParser_ConnectionTerminated;
                    m_frameParser.ParsingException += m_frameParser_ParsingException;
                    m_frameParser.ReceivedConfigurationFrame += m_frameParser_ReceivedConfigurationFrame;
                    m_frameParser.ReceivedDataFrame += m_frameParser_ReceivedDataFrame;
                    m_frameParser.ReceivedFrameBufferImage += m_frameParser_ReceivedFrameBufferImage;
                }
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="PhasorMeasurementMapper"/> object and optionally releases the managed resources.
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
                        // Detach from frame parser events and set reference to null
                        this.FrameParser = null;

                        if (m_dataStreamMonitor != null)
                        {
                            m_dataStreamMonitor.Elapsed -= m_dataStreamMonitor_Elapsed;
                            m_dataStreamMonitor.Dispose();
                        }
                        m_dataStreamMonitor = null;
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
        /// Intializes <see cref="PhasorMeasurementMapper"/>.
        /// </summary>
        public override void Initialize()
        {
            Dictionary<string, string> settings = Settings;
            ConfigurationCell definedDevice;
            MeasurementKey pointID;
            string setting, signalReference;

            // Load optional mapper specific connection parameters
            if (settings.TryGetValue("isConcentrator", out setting))
                m_isConcentrator = setting.ParseBoolean();
            else
                m_isConcentrator = false;

            if (settings.TryGetValue("accessID", out setting))
                m_accessID = ushort.Parse(setting);
            else
                m_accessID = 1;

            if (settings.TryGetValue("timeZone", out setting))
                m_timezone = TimeZoneInfo.FindSystemTimeZoneById(setting);
            else
                m_timezone = TimeZoneInfo.Utc;

            if (settings.TryGetValue("timeAdjustmentTicks", out setting))
                m_timeAdjustmentTicks = long.Parse(setting);
            else
                m_timeAdjustmentTicks = 0;

            if (settings.TryGetValue("dataLossInterval", out setting))
                m_dataStreamMonitor.Interval = double.Parse(setting) * 1000.0D;
            else
                m_dataStreamMonitor.Interval = 35000.0D;

            // Create a new phasor protocol frame parser for non-virtual connections
            MultiProtocolFrameParser frameParser = new MultiProtocolFrameParser();

            // Most of the parameters in the connection string will be for the frame parser so we provide all of them,
            // other parameters will simply be ignored
            frameParser.ConnectionString = ConnectionString;

            // For captured data simulations we will inject a simulated timestamp and auto-repeat file stream...
            if (frameParser.TransportProtocol == TransportProtocol.File)
            {
                if (settings.TryGetValue("definedFrameRate", out setting))
                    frameParser.DefinedFrameRate = 1.0D / double.Parse(setting);
                else
                    frameParser.DefinedFrameRate = 1.0D / 30.0D;

                if (settings.TryGetValue("simulateTimestamp", out setting))
                    frameParser.InjectSimulatedTimestamp = setting.ParseBoolean();
                else
                    frameParser.InjectSimulatedTimestamp = true;

                if (settings.TryGetValue("autoRepeatFile", out setting))
                    frameParser.AutoRepeatCapturedPlayback = setting.ParseBoolean();
                else
                    frameParser.AutoRepeatCapturedPlayback = true;
            }

            // Provide access ID to frame parser as this may be necessary to make a phasor connection
            frameParser.DeviceID = m_accessID;
            frameParser.SourceName = Name;

            // Assign reference to frame parser and attach to needed events
            this.FrameParser = frameParser;

            // Load device list for this mapper connection
            m_definedDevices = new Dictionary<ushort, ConfigurationCell>();

            if (m_isConcentrator)
            {
                StringBuilder deviceStatus = new StringBuilder();
                int index = 0;

                deviceStatus.AppendLine();
                deviceStatus.AppendLine();
                deviceStatus.Append("Loading expected concentrator device list...");
                deviceStatus.AppendLine();
                deviceStatus.AppendLine();

                // Making a connection to a concentrator that can support multiple devices
                foreach (DataRow row in DataSource.Tables["InputStreamDevices"].Select(string.Format("ParentID={0}", ID)))
                {
                    definedDevice = new ConfigurationCell(ushort.Parse(row["AccessID"].ToString()));
                    definedDevice.IDLabel = row["Acronym"].ToString();
                    definedDevice.Tag = uint.Parse(row["ID"].ToString());
                    m_definedDevices.Add(definedDevice.IDCode, definedDevice);

                    // Create status display string for expected device
                    deviceStatus.Append("   Device ");
                    deviceStatus.Append((index++).ToString("00"));
                    deviceStatus.Append(": ");
                    deviceStatus.Append(definedDevice.IDLabel);
                    deviceStatus.Append(" (");
                    deviceStatus.Append(definedDevice.IDCode);
                    deviceStatus.Append(')');
                    deviceStatus.AppendLine();
                }

                OnStatusMessage(deviceStatus.ToString());
            }
            else
            {
                // Making a connection to a single device
                definedDevice = new ConfigurationCell(m_accessID);
                definedDevice.IDLabel = Name;
                definedDevice.Tag = ID;
                m_definedDevices.Add(definedDevice.IDCode, definedDevice);
            }

            // Load active device measurements for this mapper connection
            m_definedMeasurements = new Dictionary<string, IMeasurement>();

            foreach (DataRow row in DataSource.Tables["ActiveMeasurements"].Select(string.Format("DeviceID={0}", ID)))
            {
                signalReference = row["SignalReference"].ToString();

                if (!string.IsNullOrEmpty(signalReference))
                {
                    try
                    {
                        // Get measurement's point ID formatted as a measurement key
                        pointID = MeasurementKey.Parse(row["ID"].ToString());

                        // Create a reference to this measurement associated with this adapter
                        m_definedMeasurements.Add(signalReference, new Measurement(
                            pointID.ID,
                            pointID.Source,
                            signalReference,
                            double.Parse(row["Adder"].ToNonNullString("0.0")),
                            double.Parse(row["Multiplier"].ToNonNullString("1.0"))));
                    }
                    catch (Exception ex)
                    {
                        OnProcessException(new InvalidOperationException(string.Format("Failed to load signal reference \"{0}\" due to exception: {1}", signalReference, ex.Message), ex));
                    }
                }
            }

            OnStatusMessage("Loaded {0} active device measurements...", m_definedMeasurements.Count);
        }

        /// <summary>
        /// Send the specified <see cref="DeviceCommand"/> to the current device connection.
        /// </summary>
        /// <param name="command"><see cref="DeviceCommand"/> to send to connected device.</param>
        [AdapterCommand("Sends the specified command to connected phasor device.")]
        public void SendCommand(DeviceCommand command)
        {
            if (m_frameParser != null)
            {
                m_frameParser.SendDeviceCommand(command);
                OnStatusMessage("Sent device command \"{0}\"...", command);
            }
            else
                OnStatusMessage("Failed to send device command \"{0}\", no frame parser is defined.");
        }

        /// <summary>
        /// Gets a short one-line status of this <see cref="PhasorMeasurementMapper"/>.
        /// </summary>
        /// <param name="maxLength">Maximum number of available characters for display.</param>
        /// <returns>A short one-line summary of the current status of this <see cref="PhasorMeasurementMapper"/>.</returns>
        public override string GetShortStatus(int maxLength)
        {
            StringBuilder status = new StringBuilder();

            if (m_frameParser != null && m_frameParser.IsConnected)
            {
                if (m_lastReportTime > 0)
                {
                    // Calculate total bad frames
                    long totalDataErrors = 0;

                    foreach (ConfigurationCell definedDevice in m_definedDevices.Values)
                    {
                        totalDataErrors += definedDevice.TotalDataQualityErrors;
                    }

                    // Generate a short connect time
                    Time connectionTime = m_frameParser.ConnectionTime;
                    string uptime;

                    if (connectionTime.ToDays() < 1.0D)
                    {
                        if (connectionTime.ToHours() < 1.0D)
                        {
                            if (connectionTime.ToMinutes() < 1.0D)
                                uptime = (int)connectionTime + " seconds";
                            else
                                uptime = connectionTime.ToMinutes().ToString("0.0") + " minutes";
                        }
                        else
                            uptime = connectionTime.ToHours().ToString("0.00") + " hours";
                    }
                    else
                        uptime = connectionTime.ToDays().ToString("0.00") + " days";

                    string uptimeStats = string.Format("Up for {0}, {1} errors",
                        uptime, totalDataErrors);

                    string runtimeStats = string.Format(" {0} {1} fps",
                        ((DateTime)m_lastReportTime).ToString("MM/dd/yyyy HH:mm:ss.fff"),
                        m_frameParser.FrameRate.ToString("0.00"));

                    uptimeStats = uptimeStats.TruncateRight(maxLength - runtimeStats.Length).PadLeft(maxLength - runtimeStats.Length, '\xA0');

                    status.Append(uptimeStats);
                    status.Append(runtimeStats);
                }
                else if (m_frameParser.ConfigurationFrame == null)
                {
                    status.Append(">> Awaiting configuration frame - ");
                    status.Append(m_frameParser.TotalBytesReceived);
                    status.Append(" bytes received");
                }
                else
                {
                    status.Append("** No data mapped, check configuration - ");
                    status.Append(m_frameParser.TotalBytesReceived);
                    status.Append(" bytes received");
                }
            }
            else
                status.Append("** Not connected");

            return status.ToString();
        }

        /// <summary>
        /// Attempts to connect to data input source.
        /// </summary>
        protected override void AttemptConnection()
        {
            m_lastReportTime = 0;
            m_bytesReceived = 0;
         
            // Start frame parser
            if (m_frameParser != null)
                m_frameParser.Start();
        }

        /// <summary>
        /// Attempts to disconnect from data input source.
        /// </summary>
        protected override void AttemptDisconnection()
        {
            // Stop data stream monitor
            m_dataStreamMonitor.Enabled = false;

            // Stop frame parser
            if (m_frameParser != null)
                m_frameParser.Stop();

            m_receivedConfigFrame = false;
        }

        /// <summary>
        /// Map parsed measurement value to defined measurement attributes (i.e., assign meta-data to parsed measured value).
        /// </summary>
        /// <param name="mappedMeasurements">Destination collection for the mapped measurement values.</param>
        /// <param name="signalReference">Derived <see cref="SignalReference"/> string for the parsed measurement value.</param>
        /// <param name="parsedMeasurement">The parsed <see cref="IMeasurement"/> value.</param>
        /// <remarks>
        /// This procedure is used to identify a parsed measurement value by its derived signal reference and apply the
        /// additional needed measurement meta-data attributes (i.e., ID, Source, Adder and Multiplier).
        /// </remarks>
        protected void MapMeasurementAttributes(ICollection<IMeasurement> mappedMeasurements, string signalReference, IMeasurement parsedMeasurement)
        {
            // Coming into this function the parsed measurement value will only have a "value" and a "timestamp";
            // the measurement will not yet be associated with an actual historian measurement ID as the measurement
            // will have come directly out of the parsed phasor protocol data frame.  We take the generated signal
            // reference and use that to lookup the actual historian measurement ID, source, adder and multipler.
            IMeasurement definedMeasurement;

            // Lookup signal reference in defined measurement list
            if (m_definedMeasurements.TryGetValue(signalReference, out definedMeasurement))
            {
                // Assign ID and other relevant attributes to the parsed measurement value
                parsedMeasurement.ID = definedMeasurement.ID;
                parsedMeasurement.Source = definedMeasurement.Source;
                parsedMeasurement.Adder = definedMeasurement.Adder;              // Allows for run-time additive measurement value adjustments
                parsedMeasurement.Multiplier = definedMeasurement.Multiplier;    // Allows for run-time mulplicative measurement value adjustments

                // Add the updated measurement value to the destination measurement collection
                mappedMeasurements.Add(parsedMeasurement);
            }
        }

        /// <summary>
        /// Extract frame measurements and add expose them via the <see cref="IInputAdapter.NewMeasurements"/> event.
        /// </summary>
        /// <param name="frame">Phasor data frame to extract measurements from.</param>
        protected void ExtractFrameMeasurements(IDataFrame frame)
        {
            const int AngleIndex = (int)CompositePhasorValue.Angle;
            const int MagnitudeIndex = (int)CompositePhasorValue.Magnitude;
            const int FrequencyIndex = (int)CompositeFrequencyValue.Frequency;
            const int DfDtIndex = (int)CompositeFrequencyValue.DfDt;

            ICollection<IMeasurement> mappedMeasurements = new List<IMeasurement>();
            ConfigurationCell definedDevice;
            PhasorValueCollection phasors;
            AnalogValueCollection analogs;
            DigitalValueCollection digitals;
            IMeasurement[] measurements;
            Ticks timestamp;
            int x, count;

            // Adjust time to UTC based on source time zone
            if (m_timezone != TimeZoneInfo.Utc)
                frame.Timestamp = TimeZoneInfo.ConvertTimeToUtc(frame.Timestamp, m_timezone);

            // We also allow "fine tuning" of time for fickle GPS clocks...
            if (m_timeAdjustmentTicks != 0)
                frame.Timestamp += m_timeAdjustmentTicks;

            // Get adjusted timestamp of this frame
            timestamp = frame.Timestamp;

            // Track latest reporting time for mapper
            if (timestamp > m_lastReportTime)
                m_lastReportTime = timestamp;

            // Loop through each parsed device in the data frame
            foreach (IDataCell parsedDevice in frame.Cells)
            {
                try
                {
                    // Lookup device information by its ID code
                    if (m_definedDevices.TryGetValue(parsedDevice.IDCode, out definedDevice))
                    {
                        // Track latest reporting time for this device
                        if (timestamp > definedDevice.LastReportTime)
                            definedDevice.LastReportTime = timestamp;

                        // Track quality statistics for this device
                        definedDevice.TotalFrames++;

                        if (!parsedDevice.DataIsValid)
                            definedDevice.TotalDataQualityErrors++;

                        if (!parsedDevice.SynchronizationIsValid)
                            definedDevice.TotalTimeQualityErrors++;

                        if (parsedDevice.DeviceError)
                            definedDevice.TotalDeviceErrors++;

                        // Map status flags (SF) from device data cell itself (IDataCell implements IMeasurement
                        // and exposes the status flags as its value)
                        MapMeasurementAttributes(mappedMeasurements, definedDevice.GetSignalReference(SignalType.Status), parsedDevice);

                        // Map phase angles (PAn) and magnitudes (PMn)
                        phasors = parsedDevice.PhasorValues;
                        count = phasors.Count;

                        for (x = 0; x < count; x++)
                        {
                            // Get composite phasor measurements
                            measurements = phasors[x].Measurements;

                            // Map angle
                            MapMeasurementAttributes(mappedMeasurements, definedDevice.GetSignalReference(SignalType.Angle, x, count), measurements[AngleIndex]);

                            // Map magnitude
                            MapMeasurementAttributes(mappedMeasurements, definedDevice.GetSignalReference(SignalType.Magnitude, x, count), measurements[MagnitudeIndex]);
                        }

                        // Map frequency (FQ) and dF/dt (DF)
                        measurements = parsedDevice.FrequencyValue.Measurements;

                        // Map frequency
                        MapMeasurementAttributes(mappedMeasurements, definedDevice.GetSignalReference(SignalType.Frequency), measurements[FrequencyIndex]);

                        // Map dF/dt
                        MapMeasurementAttributes(mappedMeasurements, definedDevice.GetSignalReference(SignalType.DfDt), measurements[DfDtIndex]);

                        // Map analog values (AVn)
                        analogs = parsedDevice.AnalogValues;
                        count = analogs.Count;

                        for (x = 0; x < count; x++)
                        {
                            // Map analog value
                            MapMeasurementAttributes(mappedMeasurements, definedDevice.GetSignalReference(SignalType.Analog, x, count), analogs[x].Measurements[0]);
                        }

                        // Map digital values (DVn)
                        digitals = parsedDevice.DigitalValues;
                        count = digitals.Count;

                        for (x = 0; x < count; x++)
                        {
                            // Map digital value
                            MapMeasurementAttributes(mappedMeasurements, definedDevice.GetSignalReference(SignalType.Digital, x, count), digitals[x].Measurements[0]);
                        }
                    }
                    else
                    {
                        // Encountered an undefined device, track frame counts
                        lock (m_undefinedDevices)
                        {
                            long frameCount;

                            if (m_undefinedDevices.TryGetValue(parsedDevice.StationName, out frameCount))
                            {
                                frameCount++;
                                m_undefinedDevices[parsedDevice.StationName] = frameCount;
                            }
                            else
                            {
                                m_undefinedDevices.Add(parsedDevice.StationName, 1);
                                OnStatusMessage("WARNING: Encountered an undefined device \"{0}\"...", parsedDevice.StationName);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    OnProcessException(new InvalidOperationException(string.Format("Exception encountered while mapping \"{0}\" data frame cell \"{1}\" elements to measurements: {2}", Name, parsedDevice.StationName.ToNonNullString("[undefined]"), ex.Message), ex));
                }
            }

            // Provide real-time measurements where needed
            OnNewMeasurements(mappedMeasurements);
        }

        private void m_frameParser_ReceivedDataFrame(object sender, EventArgs<IDataFrame> e)
        {
            ExtractFrameMeasurements(e.Argument);
        }

        private void m_frameParser_ReceivedConfigurationFrame(object sender, EventArgs<IConfigurationFrame> e)
        {
            if (!m_receivedConfigFrame)
            {
                OnStatusMessage("Received configuration frame at {0}", DateTime.UtcNow);

                // Cache configuration on an independent thread in case this takes some time
                ThreadPool.QueueUserWorkItem(ConfigurationFrame.Cache,
                    new EventArgs<IConfigurationFrame, Action<Exception>, string>(e.Argument, OnProcessException, Name));

                m_receivedConfigFrame = true;
            }
        }

        private void m_frameParser_ReceivedFrameBufferImage(object sender, EventArgs<FundamentalFrameType, byte[], int, int> e)
        {
            // We track bytes received so that connection can be restarted if data is not flowing
            m_bytesReceived += e.Argument4;
        }

        private void m_frameParser_ConnectionTerminated(object sender, EventArgs e)
        {
            OnDisconnected();

            if (m_frameParser.Enabled)
            {
                // Communications layer closed connection (close not initiated by system) - so we restart connection cycle...
                OnStatusMessage("WARNING: Connection closed by remote device, attempting reconnection...");
                Start();
            }
        }

        private void m_frameParser_ConnectionEstablished(object sender, EventArgs e)
        {
            OnConnected();

            // Enable data stream monitor for connections that support commands
            m_dataStreamMonitor.Enabled = m_frameParser.DeviceSupportsCommands;
        }

        private void m_frameParser_ConnectionException(object sender, EventArgs<Exception, int> e)
        {
            Exception ex = e.Argument1;
            OnProcessException(new InvalidOperationException(string.Format("Connection attempt failed: {0}", ex.Message), ex));
        }

        private void m_frameParser_ParsingException(object sender, EventArgs<Exception> e)
        {
            OnProcessException(e.Argument);
        }

        private void m_frameParser_ConnectionAttempt(object sender, EventArgs e)
        {
            OnStatusMessage("Initiating {0} {1} based connection...", m_frameParser.PhasorProtocol.GetFormattedProtocolName(), m_frameParser.TransportProtocol.ToString().ToUpper());
        }

        private void m_frameParser_ConfigurationChanged(object sender, EventArgs e)
        {
            m_receivedConfigFrame = false;
            OnStatusMessage("NOTICE: Configuration has changed, requesting new configuration frame...");
            SendCommand(DeviceCommand.SendConfigurationFrame2);
        }

        private void m_dataStreamMonitor_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // If we've received no data in the last timespan, we restart connect cycle...
            if (m_bytesReceived == 0)
            {
                m_dataStreamMonitor.Enabled = false;
                OnStatusMessage("\r\nNo data received in {0} seconds, restarting connect cycle...\r\n", (int)m_dataStreamMonitor.Interval / 1000.0D);
                Start();
            }

            m_bytesReceived = 0;
        }

        #endregion
    }
}
