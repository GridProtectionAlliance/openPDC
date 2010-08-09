//*******************************************************************************************************
//  DataCell.cs - Gbtc
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
using System.Runtime.Serialization;
using System.Security.Permissions;
using TVA.Parsing;

namespace TVA.PhasorProtocols.BpaPdcStream
{
    /// <summary>
    /// Represents the BPA PDCstream implementation of a <see cref="IDataCell"/> that can be sent or received.
    /// </summary>
    [Serializable()]
    public class DataCell : DataCellBase
    {
        #region [ Members ]

        // Fields
        private ChannelFlags m_channelFlags;
        private ReservedFlags m_reservedFlags;
        private ushort m_sampleNumber;
        private byte m_dataRate;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new <see cref="DataCell"/>.
        /// </summary>
        /// <param name="parent">The reference to parent <see cref="IDataFrame"/> of this <see cref="DataCell"/>.</param>
        /// <param name="configurationCell">The <see cref="IConfigurationCell"/> associated with this <see cref="DataCell"/>.</param>
        public DataCell(IDataFrame parent, IConfigurationCell configurationCell)
            : base(parent, configurationCell, 0xFFFF, Common.MaximumPhasorValues, Common.MaximumAnalogValues, Common.MaximumDigitalValues)
        {
            // Define new parsing state which defines constructors for key data values
            State = new DataCellParsingState(
                configurationCell,
                BpaPdcStream.PhasorValue.CreateNewValue,
                BpaPdcStream.FrequencyValue.CreateNewValue,
                BpaPdcStream.AnalogValue.CreateNewValue,
                BpaPdcStream.DigitalValue.CreateNewValue);
        }

        /// <summary>
        /// Creates a new <see cref="DataCell"/> from specified parameters.
        /// </summary>
        /// <param name="parent">The reference to parent <see cref="DataFrame"/> of this <see cref="DataCell"/>.</param>
        /// <param name="configurationCell">The <see cref="ConfigurationCell"/> associated with this <see cref="DataCell"/>.</param>
        /// <param name="addEmptyValues">If <c>true</c>, adds empty values for each defined configuration cell definition.</param>
        public DataCell(DataFrame parent, ConfigurationCell configurationCell, bool addEmptyValues)
            : this(parent, configurationCell)
        {
            if (addEmptyValues)
            {
                int x;

                // Define needed phasor values
                for (x = 0; x < configurationCell.PhasorDefinitions.Count; x++)
                {
                    PhasorValues.Add(new PhasorValue(this, configurationCell.PhasorDefinitions[x]));
                }

                // Define a frequency and df/dt
                FrequencyValue = new FrequencyValue(this, configurationCell.FrequencyDefinition);

                // Define any analog values
                for (x = 0; x < configurationCell.AnalogDefinitions.Count; x++)
                {
                    AnalogValues.Add(new AnalogValue(this, configurationCell.AnalogDefinitions[x]));
                }

                // Define any digital values
                for (x = 0; x < configurationCell.DigitalDefinitions.Count; x++)
                {
                    DigitalValues.Add(new DigitalValue(this, configurationCell.DigitalDefinitions[x]));
                }
            }
        }

        /// <summary>
        /// Creates a new <see cref="DataCell"/> from serialization parameters.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> with populated with data.</param>
        /// <param name="context">The source <see cref="StreamingContext"/> for this deserialization.</param>
        protected DataCell(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Deserialize data cell
            m_channelFlags = (ChannelFlags)info.GetValue("channelFlags", typeof(ChannelFlags));
            m_reservedFlags = (ReservedFlags)info.GetValue("reservedFlags", typeof(ReservedFlags));
            m_sampleNumber = info.GetUInt16("sampleNumber");
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets the reference to parent <see cref="DataFrame"/> of this <see cref="DataCell"/>.
        /// </summary>
        public new DataFrame Parent
        {
            get
            {
                return base.Parent as DataFrame;
            }
            set
            {
                base.Parent = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="ConfigurationCell"/> associated with this <see cref="DataCell"/>.
        /// </summary>
        public new ConfigurationCell ConfigurationCell
        {
            get
            {
                return base.ConfigurationCell as ConfigurationCell;
            }
            set
            {
                base.ConfigurationCell = value;
            }
        }

        /// <summary>
        /// Gets or sets channel flags for this <see cref="DataCell"/>.
        /// </summary>
        /// <remarks>
        /// These are bit flags, use properties to change basic values.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public ChannelFlags ChannelFlags
        {
            get
            {
                return m_channelFlags;
            }
            set
            {
                m_channelFlags = value;
            }
        }

        /// <summary>
        /// Gets or sets reserved flags for this <see cref="DataCell"/>.
        /// </summary>
        /// <remarks>
        /// These are bit flags, use properties to change basic values.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public ReservedFlags ReservedFlags
        {
            get
            {
                return m_reservedFlags;
            }
            set
            {
                m_reservedFlags = value;
            }
        }

        /// <summary>
        /// Gets or sets data rate of this <see cref="DataCell"/>.
        /// </summary>
        public byte DataRate
        {
            get
            {
                if (Parent.ConfigurationFrame.RevisionNumber >= RevisionNumber.Revision2)
                    return (byte)Parent.ConfigurationFrame.FrameRate;
                else
                    return m_dataRate;
            }
            set
            {
                m_dataRate = value;
            }
        }

        /// <summary>
        /// Gets or sets <see cref="BpaPdcStream.FormatFlags"/> from <see cref="ConfigurationCell"/> associated with this <see cref="DataCell"/>.
        /// </summary>
        public FormatFlags FormatFlags
        {
            get
            {
                return ConfigurationCell.FormatFlags;
            }
            set
            {
                ConfigurationCell.FormatFlags = value;
            }
        }

        /// <summary>
        /// Gets or sets sample number associated with this <see cref="DataCell"/>.
        /// </summary>
        public ushort SampleNumber
        {
            get
            {
                return m_sampleNumber;
            }
            set
            {
                m_sampleNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if reserved flag zero is set.
        /// </summary>
        public bool ReservedFlag0IsSet
        {
            get
            {
                return ((m_reservedFlags & ReservedFlags.Reserved0) > 0);
            }
            set
            {
                if (value)
                    m_reservedFlags = m_reservedFlags | ReservedFlags.Reserved0;
                else
                    m_reservedFlags = m_reservedFlags & ~ReservedFlags.Reserved0;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if reserved flag one is set.
        /// </summary>
        public bool ReservedFlag1IsSet
        {
            get
            {
                return ((m_reservedFlags & ReservedFlags.Reserved1) > 0);
            }
            set
            {
                if (value)
                    m_reservedFlags = m_reservedFlags | ReservedFlags.Reserved1;
                else
                    m_reservedFlags = m_reservedFlags & ~ReservedFlags.Reserved1;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if data of this <see cref="DataCell"/> is valid.
        /// </summary>
        public override bool DataIsValid
        {
            get
            {
                return ((m_channelFlags & ChannelFlags.DataIsValid) == 0);
            }
            set
            {
                if (value)
                    m_channelFlags = m_channelFlags & ~ChannelFlags.DataIsValid;
                else
                    m_channelFlags = m_channelFlags | ChannelFlags.DataIsValid;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if timestamp of this <see cref="DataCell"/> is valid based on GPS lock.
        /// </summary>
        public override bool SynchronizationIsValid
        {
            get
            {
                return ((m_channelFlags & ChannelFlags.PmuSynchronized) == 0);
            }
            set
            {
                if (value)
                    m_channelFlags = m_channelFlags & ~ChannelFlags.PmuSynchronized;
                else
                    m_channelFlags = m_channelFlags | ChannelFlags.PmuSynchronized;
            }
        }

        /// <summary>
        /// Gets or sets <see cref="PhasorProtocols.DataSortingType"/> of this <see cref="DataCell"/>.
        /// </summary>
        public override DataSortingType DataSortingType
        {
            get
            {
                return (((m_channelFlags & ChannelFlags.DataSortedByArrival) > 0) ? PhasorProtocols.DataSortingType.ByArrival : PhasorProtocols.DataSortingType.ByTimestamp);
            }
            set
            {
                if (value == PhasorProtocols.DataSortingType.ByArrival)
                    m_channelFlags = m_channelFlags | ChannelFlags.DataSortedByArrival;
                else
                    m_channelFlags = m_channelFlags & ~ChannelFlags.DataSortedByArrival;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if source device of this <see cref="DataCell"/> is reporting an error.
        /// </summary>
        public override bool DeviceError
        {
            get
            {
                return ((m_channelFlags & ChannelFlags.TransmissionErrors) > 0);
            }
            set
            {
                if (value)
                    m_channelFlags = m_channelFlags | ChannelFlags.TransmissionErrors;
                else
                    m_channelFlags = m_channelFlags & ~ChannelFlags.TransmissionErrors;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if this <see cref="DataCell"/> is using the PDC exchange format.
        /// </summary>
        public bool UsingPdcExchangeFormat
        {
            get
            {
                return ((m_channelFlags & ChannelFlags.PdcExchangeFormat) > 0);
            }
            set
            {
                if (value)
                    m_channelFlags = m_channelFlags | ChannelFlags.PdcExchangeFormat;
                else
                    m_channelFlags = m_channelFlags & ~ChannelFlags.PdcExchangeFormat;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if this <see cref="DataCell"/> is using Macrodyne format.
        /// </summary>
        public bool UsingMacrodyneFormat
        {
            get
            {
                return ((m_channelFlags & ChannelFlags.MacrodyneFormat) > 0);
            }
            set
            {
                if (value)
                    m_channelFlags = m_channelFlags | ChannelFlags.MacrodyneFormat;
                else
                    m_channelFlags = m_channelFlags & ~ChannelFlags.MacrodyneFormat;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if this <see cref="DataCell"/> is using IEEE format.
        /// </summary>
        public bool UsingIeeeFormat
        {
            get
            {
                return ((m_channelFlags & ChannelFlags.MacrodyneFormat) == 0);
            }
            set
            {
                if (value)
                    m_channelFlags = m_channelFlags & ~ChannelFlags.MacrodyneFormat;
                else
                    m_channelFlags = m_channelFlags | ChannelFlags.MacrodyneFormat;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if this <see cref="DataCell"/> data is sorted by timestamp.
        /// </summary>
        [Obsolete("This bit definition is for obsolete uses that is no longer needed.", false)]
        public bool DataIsSortedByTimestamp
        {
            get
            {
                return ((m_channelFlags & ChannelFlags.DataSortedByTimestamp) == 0);
            }
            set
            {
                if (value)
                    m_channelFlags = m_channelFlags & ~ChannelFlags.DataSortedByTimestamp;
                else
                    m_channelFlags = m_channelFlags | ChannelFlags.DataSortedByTimestamp;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if timestamp is included with this <see cref="DataCell"/>.
        /// </summary>
        [Obsolete("This bit definition is for obsolete uses that is no longer needed.", false)]
        public bool TimestampIsIncluded
        {
            get
            {
                return ((m_channelFlags & ChannelFlags.TimestampIncluded) == 0);
            }
            set
            {
                if (value)
                    m_channelFlags = m_channelFlags & ~ChannelFlags.TimestampIncluded;
                else
                    m_channelFlags = m_channelFlags | ChannelFlags.TimestampIncluded;
            }
        }

        /// <summary>
        /// Gets the length of the <see cref="ISupportBinaryImage.BinaryImage"/>.
        /// </summary>
        /// <remarks>
        /// This property is overriden to extend length evenly at 4-byte intervals.
        /// </remarks>
        public override int BinaryLength
        {
            get
            {
                return base.BinaryLength.AlignDoubleWord();
            }
        }

        /// <summary>
        /// Gets the length of the <see cref="HeaderImage"/>.
        /// </summary>
        protected override int HeaderLength
        {
            get
            {
                return 6;
            }
        }

        /// <summary>
        /// Gets the binary header image of the <see cref="DataCell"/> object.
        /// </summary>
        /// <remarks>
        /// Although this BPA PDCstream implementation <see cref="DataCell"/> will correctly parse a PDCxchng style
        /// stream, one will not be produced. Only a fully formatted stream will ever be produced.
        /// </remarks>
        protected override byte[] HeaderImage
        {
            get
            {
                byte[] buffer = new byte[HeaderLength];

                // Add standard PDCstream specific image. There is no major benefit to justify development
                // that would to allow production of a PDCExchangeFormat stream.
                buffer[0] = (byte)(m_channelFlags & ~ChannelFlags.PdcExchangeFormat);

                if (Parent.ConfigurationFrame.RevisionNumber >= RevisionNumber.Revision2)
                {
                    buffer[1] = (byte)((AnalogValues.Count & (int)ReservedFlags.AnalogWordsMask) | (int)ReservedFlags);
                    buffer[2] = (byte)((DigitalValues.Count & (int)FormatFlags.DigitalWordsMask) | (int)FormatFlags);
                    buffer[3] = (byte)PhasorValues.Count;
                }
                else
                {
                    buffer[1] = m_dataRate;
                    buffer[2] = (byte)DigitalValues.Count;
                    buffer[3] = (byte)PhasorValues.Count;
                }

                EndianOrder.BigEndian.CopyBytes(m_sampleNumber, buffer, 4);

                return buffer;
            }
        }

        /// <summary>
        /// <see cref="Dictionary{TKey,TValue}"/> of string based property names and values for the <see cref="DataCell"/> object.
        /// </summary>
        public override Dictionary<string, string> Attributes
        {
            get
            {
                Dictionary<string, string> baseAttributes = base.Attributes;

                baseAttributes.Add("Channel Flags", (int)ChannelFlags + ": " + ChannelFlags);
                baseAttributes.Add("Reserved Flags", (int)ReservedFlags + ": " + ReservedFlags);
                baseAttributes.Add("Sample Number", SampleNumber.ToString());
                baseAttributes.Add("Using PDC Exchange Format", UsingPdcExchangeFormat.ToString());
                baseAttributes.Add("Using Macrodyne Format", UsingMacrodyneFormat.ToString());
                baseAttributes.Add("Using IEEE Format", UsingIeeeFormat.ToString());

                return baseAttributes;
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Parses the binary image.
        /// </summary>
        /// <param name="binaryImage">Binary image to parse.</param>
        /// <param name="startIndex">Start index into <paramref name="binaryImage"/> to begin parsing.</param>
        /// <param name="length">Length of valid data within <paramref name="binaryImage"/>.</param>
        /// <returns>The length of the data that was parsed.</returns>
        /// <remarks>
        /// This property is overriden to extend parsed length evenly at 4-byte intervals.
        /// </remarks>
        public override int Initialize(byte[] binaryImage, int startIndex, int length)
        {
            // We align data cells on 32-bit word boundaries (accounts for phantom digital)
            return base.Initialize(binaryImage, startIndex, length).AlignDoubleWord();
        }

        /// <summary>
        /// Parses the binary header image.
        /// </summary>
        /// <param name="binaryImage">Binary image to parse.</param>
        /// <param name="startIndex">Start index into <paramref name="binaryImage"/> to begin parsing.</param>
        /// <param name="length">Length of valid data within <paramref name="binaryImage"/>.</param>
        /// <returns>The length of the data that was parsed.</returns>
        protected override int ParseHeaderImage(byte[] binaryImage, int startIndex, int length)
        {
            DataFrame parentFrame = Parent;
            DataFrameParsingState frameState = parentFrame.State;
            IDataCellParsingState state = State;
            RevisionNumber revision = parentFrame.ConfigurationFrame.RevisionNumber;
            int x, index = startIndex;
            byte analogs = binaryImage[index + 1];
            byte digitals;
            byte phasors;

            // Get data cell flags
            m_channelFlags = (ChannelFlags)binaryImage[index];
            index += 2;

            // Parse PDCstream specific header image
            if (revision >= RevisionNumber.Revision2 && frameState.RemainingPdcBlockPmus == 0)
            {
                // Strip off reserved flags
                m_reservedFlags = (ReservedFlags)analogs & ~ReservedFlags.AnalogWordsMask;

                // Leave analog word count
                analogs &= (byte)ReservedFlags.AnalogWordsMask;
            }
            else
            {
                // Older revisions didn't allow analogs
                m_dataRate = analogs;
                analogs = 0;
            }

            if (frameState.RemainingPdcBlockPmus > 0)
            {
                // PDC Block PMU's contain exactly 2 phasors, 0 analogs and 1 digital
                phasors = 2;
                analogs = 0;
                digitals = 1;
                UsingPdcExchangeFormat = true;

                // Decrement remaining PDC block PMU's
                frameState.RemainingPdcBlockPmus--;
            }
            else
            {
                // Parse number of digitals and phasors for normal PMU cells
                digitals = binaryImage[index];
                phasors = binaryImage[index + 1];
                index += 2;

                if (revision >= RevisionNumber.Revision2)
                {
                    // Strip off IEEE flags
                    FormatFlags = (FormatFlags)digitals & ~FormatFlags.DigitalWordsMask;

                    // Leave digital word count
                    digitals &= (byte)FormatFlags.DigitalWordsMask;
                }

                // Check for PDC exchange format
                if (UsingPdcExchangeFormat)
                {
                    // In cases where we are using PDC exchange the phasor count is the number of PMU's in the PDC block
                    int pdcBlockPmus = phasors - 1; // <-- Current PMU counts as one
                    frameState.RemainingPdcBlockPmus = pdcBlockPmus;
                    frameState.CellCount += pdcBlockPmus;

                    // PDC Block PMU's contain exactly 2 phasors, 0 analogs and 1 digital
                    phasors = 2;
                    analogs = 0;
                    digitals = 1;
                    
                    // Get data cell flags for PDC block PMU
                    m_channelFlags = (ChannelFlags)binaryImage[index];
                    UsingPdcExchangeFormat = true;
                    index += 2;
                }
                else
                {
                    // Parse PMU's sample number
                    m_sampleNumber = EndianOrder.BigEndian.ToUInt16(binaryImage, index);
                    index += 2;
                }
            }

            // Algorithm Case: Determine best course of action when stream counts don't match counts defined in the
            // external INI based configuration file.  Think about what *will* happen when new data appears in the
            // stream that's not in the config file - you could raise an event notifying consumer about the mismatch
            // instead of raising an exception - could even make a boolean property that would allow either case.
            // The important thing to consider is that to parse the cell images you have to have a defined
            // definition (see base class method "DataCellBase.ParseBodyImage").  If you have more items defined
            // in the stream than you do in the config file then you won't get the new value, too few items and you
            // don't have enough definitions to correctly interpret the data (that would be bad) - either way the
            // definitions won't line up with the appropriate data value and you won't know which one is missing or
            // added.  I can't change the protocol so this is enough argument to just raise an error for config
            // file/stream mismatch.  So for now we'll just throw an exception and deal with consequences :)
            // Note that this only applies to BPA PDCstream protocol because of external configuration.

            // Addendum: After running this with several protocol implementations I noticed that if a device wasn't
            // reporting, the phasor count dropped to zero even if there were phasors defined in the configuration
            // file, so the only time an exception is thrown is if there are more phasors defined in the the stream
            // than there are defined in the INI file...

            // At least this number of phasors should be already defined in BPA PDCstream configuration file
            if (phasors > ConfigurationCell.PhasorDefinitions.Count)
                throw new InvalidOperationException(
                    "Stream/Config File Mismatch: Phasor value count in stream (" + phasors + 
                    ") does not match defined count in configuration file (" + ConfigurationCell.PhasorDefinitions.Count + 
                    ") for " + ConfigurationCell.IDLabel);

            // If analog values get a clear definition in INI file at some point, we can validate the number in the
            // stream to the number in the config file, in the mean time we dyanmically add analog definitions to
            // configuration cell as needed (they are only defined in data frame of BPA PDCstream)
            if (analogs > ConfigurationCell.AnalogDefinitions.Count)
            {
                for (x = ConfigurationCell.AnalogDefinitions.Count; x < analogs; x++)
                {
                    ConfigurationCell.AnalogDefinitions.Add(new AnalogDefinition(ConfigurationCell, "Analog " + (x + 1), 1, 0.0D, AnalogType.SinglePointOnWave));
                }
            }

            // If digital values get a clear definition in INI file at some point, we can validate the number in the
            // stream to the number in the config file, in the mean time we dyanmically add digital definitions to
            // configuration cell as needed (they are only defined in data frame of BPA PDCstream)
            if (digitals > ConfigurationCell.DigitalDefinitions.Count)
            {
                for (x = ConfigurationCell.DigitalDefinitions.Count; x < digitals; x++)
                {
                    ConfigurationCell.DigitalDefinitions.Add(new DigitalDefinition(ConfigurationCell, "Digital Word " + (x + 1)));
                }
            }

            // Unlike most all other protocols the counts defined for phasors, analogs and digitals in the data frame
            // may not exactly match what's defined in the configuration frame as these values are defined in an external
            // INI file for BPA PDCstream.  As a result, we manually assign the counts to the parsing state so that these
            // will be the counts used to parse values from data frame in the base class ParseBodyImage method
            state.PhasorCount = phasors;
            state.AnalogCount = analogs;
            state.DigitalCount = digitals;

            // Status flags and remaining data elements will parsed by base class in the ParseBodyImage method
            return (index - startIndex);
        }

        /// <summary>
        /// Populates a <see cref="SerializationInfo"/> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> to populate with data.</param>
        /// <param name="context">The destination <see cref="StreamingContext"/> for this serialization.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            // Serialize data cell
            info.AddValue("channelFlags", m_channelFlags, typeof(ChannelFlags));
            info.AddValue("reservedFlags", m_reservedFlags, typeof(ReservedFlags));
            info.AddValue("sampleNumber", m_sampleNumber);
        }

        #endregion

        #region [ Static ]

        // Static Methods

        // Delegate handler to create a new BPA PDCstream data cell
        internal static IDataCell CreateNewCell(IChannelFrame parent, IChannelFrameParsingState<IDataCell> state, int index, byte[] binaryImage, int startIndex, out int parsedLength)
        {
            DataCell dataCell = new DataCell(parent as IDataFrame, (state as IDataFrameParsingState).ConfigurationFrame.Cells[index]);

            parsedLength = dataCell.Initialize(binaryImage, startIndex, 0);

            return dataCell;
        }

        #endregion
    }
}