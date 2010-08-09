//*******************************************************************************************************
//  ConfigurationFrame.cs - Gbtc
//
//  Tennessee Valley Authority, 2009
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  This software is made freely available under the TVA Open Source Agreement (see below).
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  11/12/2004 - J. Ritchie Carroll
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
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using TVA.Interop;
using TVA.IO.Checksums;
using TVA.Parsing;
using TVA.Reflection;

namespace TVA.PhasorProtocols.BpaPdcStream
{
    /// <summary>
    /// Represents the BPA PDCstream implementation of a <see cref="IConfigurationFrame"/> that can be sent or received.
    /// </summary>
    [Serializable()]
    public class ConfigurationFrame : ConfigurationFrameBase, ISupportFrameImage<FrameType>
    {
        #region [ Members ]

        // Constants
        private const int FixedHeaderLength = CommonFrameHeader.FixedLength + 12;

        /// <summary>
        /// Default voltage phasor INI based configuration entry.
        /// </summary>
        public const string DefaultVoltagePhasorEntry = "V,4500.0,0.0060573,0,0,500,Default 500kV";

        /// <summary>
        /// Default current phasor INI based configuration entry.
        /// </summary>
        public const string DefaultCurrentPhasorEntry = "I,600.00,0.000040382,0,1,1,Default Current";

        /// <summary>
        /// Default frequency INI based configuration entry.
        /// </summary>
        public const string DefaultFrequencyEntry = "F,1000,60,1000,0,0,Frequency";

        // Events

        /// <summary>
        /// Occurs when the BPA PDCstream INI based configuration file has been reloaded.
        /// </summary>
        public event EventHandler ConfigurationFileReloaded;

        // Fields
        private CommonFrameHeader m_frameHeader;
        private IniFile m_iniFile;
        private ConfigurationCellCollection m_configurationFileCells;
        private PhasorDefinition m_defaultPhasorV;
        private PhasorDefinition m_defaultPhasorI;
        private FrequencyDefinition m_defaultFrequency;
        private ushort m_rowLength;
        private ushort m_packetsPerSample;
        private StreamType m_streamType;
        private RevisionNumber m_revisionNumber;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new <see cref="ConfigurationFrame"/>.
        /// </summary>
        /// <remarks>
        /// This constructor is used by <see cref="FrameImageParserBase{TTypeIdentifier,TOutputType}"/> to parse a BPA PDCstream configuration frame.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ConfigurationFrame()
            : base(0, new ConfigurationCellCollection(), 0, 0)
        {
            // We just assume current timestamp for configuration frames since they don't provide one
            Timestamp = DateTime.UtcNow.Ticks;
        }

        /// <summary>
        /// Creates a new <see cref="ConfigurationFrame"/> from specified parameters.
        /// </summary>
        /// <param name="timestamp">The exact timestamp, in <see cref="Ticks"/>, of the data represented by this <see cref="ConfigurationFrame"/>.</param>
        /// <param name="configurationFileName">The required external BPA PDCstream INI based configuration file.</param>
        /// <param name="revisionNumber">Defines the <see cref="RevisionNumber"/> for this BPA PDCstream configuration frame.</param>
        /// <param name="streamType">Defines the <see cref="StreamType"/> for this BPA PDCstream configuration frame.</param>
        /// <param name="packetsPerSample">Number of packets per sample.</param>
        /// <remarks>
        /// <para>
        /// This constructor is used by a consumer to generate a BPA PDCstream configuration frame.
        /// </para>
        /// <para>
        /// If you are going to create multiple data packets set <paramref name="packetsPerSample"/> to a number
        /// greater than one. This will only start becoming necessary if you start hitting data size limits imposed
        /// by the nature of the transport protocol.
        /// </para>
        /// </remarks>
        public ConfigurationFrame(Ticks timestamp, string configurationFileName, ushort packetsPerSample, RevisionNumber revisionNumber, StreamType streamType)
            : base(0, new ConfigurationCellCollection(), timestamp, 30)
        {
            m_iniFile = new IniFile(configurationFileName);
            m_packetsPerSample = packetsPerSample;
            m_revisionNumber = revisionNumber;
            m_streamType = streamType;
            Refresh(false);
        }

        /// <summary>
        /// Creates a new <see cref="ConfigurationFrame"/> from serialization parameters.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> with populated with data.</param>
        /// <param name="context">The source <see cref="StreamingContext"/> for this deserialization.</param>
        protected ConfigurationFrame(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Deserialize configuration frame
            m_frameHeader = (CommonFrameHeader)info.GetValue("frameHeader", typeof(CommonFrameHeader));
            m_packetsPerSample = info.GetUInt16("packetsPerSample");
            m_streamType = (StreamType)info.GetValue("streamType", typeof(StreamType));
            m_revisionNumber = (RevisionNumber)info.GetValue("revisionNumber", typeof(RevisionNumber));
            m_iniFile = new IniFile(info.GetString("configurationFileName"));
            Refresh(false);
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets reference to the <see cref="ConfigurationCellCollection"/> for this <see cref="ConfigurationFrame"/>.
        /// </summary>
        public new ConfigurationCellCollection Cells
        {
            get
            {
                return base.Cells as ConfigurationCellCollection;
            }
        }

        /// <summary>
        /// Gets reference to the <see cref="ConfigurationCellCollection"/> loaded from the configuration file of this <see cref="ConfigurationFrame"/>.
        /// </summary>
        public ConfigurationCellCollection ConfigurationFileCells
        {
            get
            {
                return m_configurationFileCells;
            }
        }

        /// <summary>
        /// Gets the <see cref="FrameType"/> of this <see cref="ConfigurationFrame"/>.
        /// </summary>
        public FrameType TypeID
        {
            get
            {
                return BpaPdcStream.FrameType.ConfigurationFrame;
            }
        }

        /// <summary>
        /// Gets or sets current <see cref="CommonFrameHeader"/>.
        /// </summary>
        public CommonFrameHeader CommonHeader
        {
            get
            {
                // Make sure frame header exists
                if (m_frameHeader == null)
                    m_frameHeader = new CommonFrameHeader(Common.DescriptorPacketFlag);

                return m_frameHeader;
            }
            set
            {
                m_frameHeader = value;

                if (m_frameHeader != null)
                {
                    ConfigurationFrameParsingState parsingState = m_frameHeader.State as ConfigurationFrameParsingState;

                    if (parsingState != null)
                    {
                        State = parsingState;
                        m_iniFile = new IniFile(parsingState.ConfigurationFileName);
                    }
                }
            }
        }

        // This interface implementation satisfies ISupportFrameImage<FrameType>.CommonHeader
        ICommonHeader<FrameType> ISupportFrameImage<FrameType>.CommonHeader
        {
            get
            {
                return CommonHeader;
            }
            set
            {
                CommonHeader = value as CommonFrameHeader;
            }
        }

        /// <summary>
        /// Gets or sets the BPA PDCstream protocol <see cref="BpaPdcStream.StreamType"/>, i.e., legacy or compact, of this <see cref="ConfigurationFrame"/>.
        /// </summary>
        public StreamType StreamType
        {
            get
            {
                return m_streamType;
            }
            set
            {
                m_streamType = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="BpaPdcStream.RevisionNumber"/> of this <see cref="ConfigurationFrame"/>.
        /// </summary>
        public RevisionNumber RevisionNumber
        {
            get
            {
                return m_revisionNumber;
            }
            set
            {
                m_revisionNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of packets per sample of this <see cref="ConfigurationFrame"/>.
        /// </summary>
        public ushort PacketsPerSample
        {
            get
            {
                return m_packetsPerSample;
            }
            set
            {
                m_packetsPerSample = value;
            }
        }

        /// <summary>
        /// Gets the INI based configuration file name of this <see cref="ConfigurationFrame"/>.
        /// </summary>
        public string ConfigurationFileName
        {
            get
            {
                return m_iniFile.FileName;
            }
        }

        /// <summary>
        /// Gets the default voltage phasor definition.
        /// </summary>
        public PhasorDefinition DefaultPhasorV
        {
            get
            {
                return m_defaultPhasorV;
            }
        }

        /// <summary>
        /// Gets the default current phasor definition.
        /// </summary>
        public PhasorDefinition DefaultPhasorI
        {
            get
            {
                return m_defaultPhasorI;
            }
        }

        /// <summary>
        /// Gets the default frequency definition.
        /// </summary>
        public FrequencyDefinition DefaultFrequency
        {
            get
            {
                return m_defaultFrequency;
            }
        }

        /// <summary>
        /// Gets the length of the <see cref="HeaderImage"/>.
        /// </summary>
        protected override int HeaderLength
        {
            get
            {
                return FixedHeaderLength;
            }
        }

        /// <summary>
        /// Gets the binary header image of the <see cref="ConfigurationFrame"/> object.
        /// </summary>
        protected override byte[] HeaderImage
        {
            get
            {
                // Make sure to provide proper frame length for use in the common header image
                unchecked
                {
                    CommonHeader.FrameLength = (ushort)BinaryLength;
                }

                byte[] buffer = new byte[FixedHeaderLength];
                int index = 0;

                CommonHeader.BinaryImage.CopyImage(buffer, ref index, CommonFrameHeader.FixedLength);
                buffer[4] = (byte)StreamType;
                buffer[5] = (byte)RevisionNumber;
                EndianOrder.BigEndian.CopyBytes(FrameRate, buffer, 6);
                EndianOrder.BigEndian.CopyBytes(RowLength(true), buffer, 8); // <-- Important: This step calculates all PMU row offsets!
                EndianOrder.BigEndian.CopyBytes(PacketsPerSample, buffer, 12);
                EndianOrder.BigEndian.CopyBytes((ushort)Cells.Count, buffer, 14);

                return buffer;
            }
        }

        /// <summary>
        /// <see cref="Dictionary{TKey,TValue}"/> of string based property names and values for the <see cref="ConfigurationFrame"/> object.
        /// </summary>
        public override Dictionary<string, string> Attributes
        {
            get
            {
                Dictionary<string, string> baseAttributes = base.Attributes;

                CommonHeader.AppendHeaderAttributes(baseAttributes);

                if (m_iniFile != null)
                    baseAttributes.Add("Configuration File Name", m_iniFile.FileName);

                baseAttributes.Add("Stream Type", (int)m_streamType + ": " + m_streamType);
                baseAttributes.Add("Revision Number", (int)m_revisionNumber + ": " + m_revisionNumber);
                baseAttributes.Add("Packets Per Sample", m_packetsPerSample.ToString());

                return baseAttributes;
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Parses the binary header image.
        /// </summary>
        /// <param name="binaryImage">Binary image to parse.</param>
        /// <param name="startIndex">Start index into <paramref name="binaryImage"/> to begin parsing.</param>
        /// <param name="length">Length of valid data within <paramref name="binaryImage"/>.</param>
        /// <returns>The length of the data that was parsed.</returns>
        protected override int ParseHeaderImage(byte[] binaryImage, int startIndex, int length)
        {
            // Skip past header that was already parsed...
            startIndex += CommonFrameHeader.FixedLength;

            // Only need to parse what wan't already parsed in common frame header
            m_streamType = (StreamType)binaryImage[startIndex];
            m_revisionNumber = (RevisionNumber)binaryImage[startIndex + 1];
            FrameRate = EndianOrder.BigEndian.ToUInt16(binaryImage, startIndex + 2);
            m_rowLength = (ushort)EndianOrder.BigEndian.ToUInt32(binaryImage, startIndex + 4);
            m_packetsPerSample = EndianOrder.BigEndian.ToUInt16(binaryImage, startIndex + 8);
            State.CellCount = EndianOrder.BigEndian.ToUInt16(binaryImage, startIndex + 10);

            // The data that's in the data stream will take precedence over what's in the
            // in the configuration file.  The configuration file may define more PMU's than
            // are in the stream - in my opinion that's OK - it's when you have PMU's in the
            // stream that aren't defined in the INI file that you'll have trouble...

            return FixedHeaderLength;
        }

        /// <summary>
        /// Parses the binary image.
        /// </summary>
        /// <param name="binaryImage">Binary image to parse.</param>
        /// <param name="startIndex">Start index into <paramref name="binaryImage"/> to begin parsing.</param>
        /// <param name="length">Length of valid data within <paramref name="binaryImage"/>.</param>
        /// <returns>The length of the data that was parsed.</returns>
        /// <remarks>
        /// This method is overriden so INI file can be loaded after binary image has been parsed.
        /// </remarks>
        public override int Initialize(byte[] binaryImage, int startIndex, int length)
        {
            int parsedLength = base.Initialize(binaryImage, startIndex, length);

            // Load INI file image and associate parsed cells to cells in configuration file...
            Refresh(true);

            return parsedLength;
        }

        /// <summary>
        /// Reload BPA PDcstream INI based configuration file.
        /// </summary>
        public void Refresh()
        {
            Refresh(false);
        }

        internal void Refresh(bool refreshCausedByFrameParse)
        {
            // The only time we need an access lock is when we reload the config file...
            lock (m_iniFile)
            {
                if (File.Exists(m_iniFile.FileName))
                {
                    ConfigurationCell pmuCell;
                    int x;
                    int phasorCount;

                    m_defaultPhasorV = new PhasorDefinition(null, 0, m_iniFile["DEFAULT", "PhasorV", DefaultVoltagePhasorEntry]);
                    m_defaultPhasorI = new PhasorDefinition(null, 0, m_iniFile["DEFAULT", "PhasorI", DefaultCurrentPhasorEntry]);
                    m_defaultFrequency = new FrequencyDefinition(null, m_iniFile["DEFAULT", "Frequency", DefaultFrequencyEntry]);
                    FrameRate = ushort.Parse(m_iniFile["CONFIG", "SampleRate", "30"]);

                    // We read all cells in the config file into their own configuration cell collection - cells parsed
                    // from the configuration frame will be mapped to their associated config file cell by ID label
                    // when the configuration cell is parsed from the configuration frame
                    if (m_configurationFileCells == null)
                        m_configurationFileCells = new ConfigurationCellCollection();

                    m_configurationFileCells.Clear();

                    // Load phasor data for each section in config file...
                    foreach (string section in m_iniFile.GetSectionNames())
                    {
                        if (section.Length > 0)
                        {
                            // Make sure this is not a special section
                            if (string.Compare(section, "DEFAULT", true) != 0 && string.Compare(section, "CONFIG", true) != 0)
                            {
                                // Create new PMU entry structure from config file settings...
                                phasorCount = int.Parse(m_iniFile[section, "NumberPhasors", "0"]);

                                pmuCell = new ConfigurationCell(this, 0, LineFrequency.Hz60);

                                pmuCell.SectionEntry = section; // This will automatically assign ID label as first 4 digits of section
                                pmuCell.StationName = m_iniFile[section, "Name", section];
                                pmuCell.IDCode = ushort.Parse(m_iniFile[section, "PMU", Cells.Count.ToString()]);

                                for (x = 0; x < phasorCount; x++)
                                {
                                    pmuCell.PhasorDefinitions.Add(new PhasorDefinition(pmuCell, x + 1, m_iniFile[section, "Phasor" + (x + 1), DefaultVoltagePhasorEntry]));
                                }

                                pmuCell.FrequencyDefinition = new FrequencyDefinition(pmuCell, m_iniFile[section, "Frequency", DefaultFrequencyEntry]);

                                m_configurationFileCells.Add(pmuCell);
                            }
                        }
                    }

                    // Associate parsed cells with cells defined in INI file
                    if (m_configurationFileCells.Count > 0 && (Cells != null))
                    {
                        ConfigurationCell configurationFileCell = null;
                        IConfigurationCell configurationCell = null;

                        if (refreshCausedByFrameParse)
                        {
                            // Create a new configuration cell collection that will account for PDC block cells
                            ConfigurationCellCollection cellCollection = new ConfigurationCellCollection();
                            ConfigurationCell cell;

                            // For freshly parsed configuration frames we'll have no PMU's in configuration
                            // frame for PDCxchng blocks - so we'll need to dynamically create them
                            for (x = 0; x < Cells.Count; x++)
                            {
                                // Get current configuration cell
                                cell = Cells[x];

                                // Lookup INI file configuration cell by ID label
                                m_configurationFileCells.TryGetByIDLabel(cell.IDLabel, out configurationCell);
                                configurationFileCell = (ConfigurationCell)configurationCell;

                                if (configurationFileCell == null)
                                {
                                    // Couldn't find associated INI file cell - just append the parsed cell to the collection
                                    cellCollection.Add(cell);
                                }
                                else
                                {
                                    if (configurationFileCell.IsPdcBlockSection)
                                    {
                                        // This looks like a PDC block section - so we'll keep adding cells for each defined PMU in the PDC block
                                        int index = 0;

                                        do
                                        {
                                            // Lookup PMU by section name
                                            m_configurationFileCells.TryGetBySectionEntry(cell.IDLabel + "pmu" + index, ref configurationFileCell);

                                            // Add PDC block PMU configuration cell to the collection
                                            if (configurationFileCell != null)
                                                cellCollection.Add(configurationFileCell);

                                            index++;
                                        }
                                        while (configurationFileCell != null);
                                    }
                                    else
                                    {
                                        // As far as we can tell from INI file, this is just a regular PMU
                                        cell.ConfigurationFileCell = configurationFileCell;
                                        cellCollection.Add(cell);
                                    }
                                }
                            }

                            // Assign "new" cell collection which will include PMU's from defined PDC blocks
                            Cells.Clear();
                            Cells.AddRange(cellCollection);
                        }
                        else
                        {
                            // For simple INI file updates, we just re-assign INI file cells associating by section entry
                            foreach (ConfigurationCell cell in Cells)
                            {
                                // Attempt to associate this configuration cell with information read from external INI based configuration file
                                m_configurationFileCells.TryGetBySectionEntry(cell.SectionEntry, ref configurationFileCell);
                                cell.ConfigurationFileCell = configurationFileCell;
                            }
                        }
                    }
                }
                else
                    throw new InvalidOperationException("PDC config file \"" + m_iniFile.FileName + "\" does not exist.");
            }

            // In case other classes want to know, we send out a notification that the config file has been reloaded (make sure
            // you do this after the write lock has been released to avoid possible dead-lock situations)
            if (ConfigurationFileReloaded != null)
                ConfigurationFileReloaded(this, EventArgs.Empty);

        }

        // RowLength property calculates cell offsets - so it must be called before
        // accessing cell offsets - this happens automatically since HeaderImage is
        // called before base class BodyImage which just gets Cells.BinaryImage
        internal uint RowLength(bool recalculate)
        {
            if (m_rowLength == 0 || recalculate)
            {
                m_rowLength = 0;

                for (int x = 0; x < Cells.Count; x++)
                {
                    ConfigurationCell cell = Cells[x];

                    cell.Offset = m_rowLength;

                    m_rowLength += (ushort)(8 + FrequencyValue.CalculateBinaryLength(cell.FrequencyDefinition));

                    for (int y = 0; y < cell.PhasorDefinitions.Count; y++)
                    {
                        m_rowLength += (ushort)PhasorValue.CalculateBinaryLength(cell.PhasorDefinitions[y]);
                    }
                }
            }

            return m_rowLength;
        }

        /// <summary>
        /// Calculates checksum of given <paramref name="buffer"/>.
        /// </summary>
        /// <param name="buffer">Buffer image over which to calculate checksum.</param>
        /// <param name="offset">Start index into <paramref name="buffer"/> to calculate checksum.</param>
        /// <param name="length">Length of data within <paramref name="buffer"/> to calculate checksum.</param>
        /// <returns>Checksum over specified portion of <paramref name="buffer"/>.</returns>
        protected override ushort CalculateChecksum(byte[] buffer, int offset, int length)
        {
            // PDCstream uses a 16-bit XOR based check sum
            return buffer.Xor16CheckSum(offset, length);
        }

        /// <summary>
        /// Appends checksum onto <paramref name="buffer"/> starting at <paramref name="startIndex"/>.
        /// </summary>
        /// <param name="buffer">Buffer image on which to append checksum.</param>
        /// <param name="startIndex">Index into <paramref name="buffer"/> where checksum should be appended.</param>
        /// <remarks>
        /// We override default implementation since BPA PDCstream implements check sum for frames in little-endian.
        /// </remarks>
        protected override void AppendChecksum(byte[] buffer, int startIndex)
        {
            // Oddly enough, check sum for frames in BPA PDC stream is little-endian
            EndianOrder.LittleEndian.CopyBytes(CalculateChecksum(buffer, 0, startIndex), buffer, startIndex);
        }

        /// <summary>
        /// Determines if checksum in the <paramref name="buffer"/> is valid.
        /// </summary>
        /// <param name="buffer">Buffer image to validate.</param>
        /// <param name="startIndex">Start index into <paramref name="buffer"/> to perform checksum.</param>
        /// <returns>Flag that determines if checksum over <paramref name="buffer"/> is valid.</returns>
        /// <remarks>
        /// We override default implementation since BPA PDCstream implements check sum for frames in little-endian.
        /// </remarks>
        protected override bool ChecksumIsValid(byte[] buffer, int startIndex)
        {
            int sumLength = BinaryLength - 2;
            return EndianOrder.LittleEndian.ToUInt16(buffer, startIndex + sumLength) == CalculateChecksum(buffer, startIndex, sumLength);
        }

        /// <summary>
        /// Populates a <see cref="SerializationInfo"/> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> to populate with data.</param>
        /// <param name="context">The destination <see cref="StreamingContext"/> for this serialization.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            // Serialize configuration frame
            info.AddValue("frameHeader", m_frameHeader, typeof(CommonFrameHeader));
            info.AddValue("packetsPerSample", m_packetsPerSample);
            info.AddValue("streamType", m_streamType, typeof(StreamType));
            info.AddValue("revisionNumber", m_revisionNumber, typeof(RevisionNumber));
            info.AddValue("configurationFileName", m_iniFile.FileName);
        }

        #endregion

        #region [ Static ]

        // Static Methods

        /// <summary>
        /// Gets a generated INI configuration file image.
        /// </summary>
        public static string GetIniFileImage(IConfigurationFrame configFrame)
        {
            StringBuilder fileImage = new StringBuilder();

            fileImage.AppendLine("; BPA PDCstream IniFile for Configuration " + configFrame.IDCode);
            fileImage.AppendLine("; Auto-generated on " + DateTime.Now);
            fileImage.AppendLine(";    Assembly: " + AssemblyInfo.ExecutingAssembly.Name);
            fileImage.AppendLine(";    Compiled: " + File.GetLastWriteTime(AssemblyInfo.ExecutingAssembly.Location));
            fileImage.AppendLine(";");
            fileImage.AppendLine(";");
            fileImage.AppendLine("; Format:");
            fileImage.AppendLine(";   Each Column in data file is given a bracketed identifier, numbered in the order it");
            fileImage.AppendLine(";   appears in the data file, and identified by data type ( PMU, PDC, or other)");
            fileImage.AppendLine(";     PMU designates column data format from a single PMU");
            fileImage.AppendLine(";     PDC designates column data format from another PDC which is somewhat different from a single PMU");
            fileImage.AppendLine(";   Default gives default values for a processing algorithm in case quantities are omitted");
            fileImage.AppendLine(";   Name= gives the overall station name for print labels");
            fileImage.AppendLine(";   NumberPhasors= :  for PMU data, gives the number of phasors contained in column");
            fileImage.AppendLine(";                     for PDC data, gives the number of PMUs data included in the column");
            fileImage.AppendLine(";                     Note - for PDC data, there will be 2 phasors & 1 freq per PMU");
            fileImage.AppendLine(";   Quantities within the column are listed by PhasorI=, Frequency=, etc");
            fileImage.AppendLine(";   Each quantity has 7 comma separated fields followed by an optional comment");
            fileImage.AppendLine(";");
            fileImage.AppendLine(";   Phasor entry format:  Type, Ratio, Cal Factor, Offset, Shunt, VoltageRef/Class, Label  ;Comments");
            fileImage.AppendLine(";    Type:       Type of measurement, V=voltage, I=current, N=don\'t care, single ASCII character");
            fileImage.AppendLine(";    Ratio:      PT/CT ratio N:1 where N is a floating point number");
            fileImage.AppendLine(";    Cal Factor: Conversion factor between integer in file and secondary volts, floating point");
            fileImage.AppendLine(";    Offset:     Phase Offset to correct for phase angle measurement errors or differences, floating point");
            fileImage.AppendLine(";    Shunt:      Current- shunt resistence in ohms, or the equivalent ratio for aux CTs, floating point");
            fileImage.AppendLine(";                Voltage- empty, not used");
            fileImage.AppendLine(";    VoltageRef: Current- phasor number (1-10) of voltage phasor to use for power calculation, integer");
            fileImage.AppendLine(";                Voltage- voltage class, standard l-l voltages, 500, 230, 115, etc, integer");
            fileImage.AppendLine(";    Label:      Phasor quantity label for print label, text");
            fileImage.AppendLine(";    Comments:   All text after the semicolon on a line are optional comments not for processing");
            fileImage.AppendLine(";");
            fileImage.AppendLine(";   Voltage Magnitude = MAG(Real,Imaginary) * CalFactor * PTR (line-neutral)");
            fileImage.AppendLine(";   Current Magnitude = MAG(Real,Imaginary) * CalFactor * CTR / Shunt (phase current)");
            fileImage.AppendLine(";   Phase Angle = ATAN(Imaginary/Real) + Phase Offset (usually degrees)");
            fileImage.AppendLine(";     Note: Usually phase Offset is 0, but is sometimes required for comparing measurements");
            fileImage.AppendLine(";           from different systems or through transformer banks");
            fileImage.AppendLine(";");
            fileImage.AppendLine(";   Frequency entry format:  scale, offset, dF/dt scale, dF/dt offset, dummy, label  ;Comments");
            fileImage.AppendLine(";   Frequency = Number / scale + offset");
            fileImage.AppendLine(";   dF/dt = Number / (dF/dt scale) + (dF/dt offset)");
            fileImage.AppendLine(";");
            fileImage.AppendLine(";");

            fileImage.AppendLine("[DEFAULT]");
            fileImage.AppendLine("PhasorV=" + DefaultVoltagePhasorEntry); //PhasorDefinition.ConfigFileFormat(DefaultPhasorV));
            fileImage.AppendLine("PhasorI=" + DefaultCurrentPhasorEntry); //PhasorDefinition.ConfigFileFormat(DefaultPhasorI));
            fileImage.AppendLine("Frequency=" + DefaultFrequencyEntry);   //FrequencyDefinition.ConfigFileFormat(DefaultFrequency));
            fileImage.AppendLine();

            fileImage.AppendLine("[CONFIG]");
            fileImage.AppendLine("SampleRate=" + configFrame.FrameRate);
            fileImage.AppendLine("NumberOfPMUs=" + configFrame.Cells.Count);
            fileImage.AppendLine();

            for (int x = 0; x < configFrame.Cells.Count; x++)
            {
                fileImage.AppendLine("[" + configFrame.Cells[x].IDLabel + "]");
                fileImage.AppendLine("Name=" + configFrame.Cells[x].StationName);
                fileImage.AppendLine("PMU=" + x);
                fileImage.AppendLine("NumberPhasors=" + configFrame.Cells[x].PhasorDefinitions.Count);
                for (int y = 0; y < configFrame.Cells[x].PhasorDefinitions.Count; y++)
                {
                    fileImage.AppendLine("Phasor" + (y + 1) + "=" + PhasorDefinition.ConfigFileFormat(configFrame.Cells[x].PhasorDefinitions[y]));
                }
                fileImage.AppendLine("Frequency=" + FrequencyDefinition.ConfigFileFormat(configFrame.Cells[x].FrequencyDefinition));
                fileImage.AppendLine();
            }

            return fileImage.ToString();
    }

        #endregion
        
    }
}