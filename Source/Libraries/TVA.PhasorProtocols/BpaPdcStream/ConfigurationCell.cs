//*******************************************************************************************************
//  ConfigurationCell.cs - Gbtc
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
//  9/15/2009 - Stephen C. Wills
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
using System.Text;

namespace TVA.PhasorProtocols.BpaPdcStream
{
    /// <summary>
    /// Represents the BPA PDCstream implementation of a <see cref="IConfigurationCell"/> that can be sent or received.
    /// </summary>
    [Serializable()]
    public class ConfigurationCell : ConfigurationCellBase
    {
        #region [ Members ]

        // Constants
        private const int FixedBodyLength = 8;

        // Fields
        private ConfigurationCell m_configurationFileCell;
        private string m_sectionEntry;
        private FormatFlags m_formatFlags;
        private ushort m_offset;
        private ushort m_reserved;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new <see cref="ConfigurationCell"/>.
        /// </summary>
        /// <param name="parent">The reference to parent <see cref="IConfigurationFrame"/> of this <see cref="ConfigurationCell"/>.</param>
        public ConfigurationCell(IConfigurationFrame parent)
            : base(parent, 0, Common.MaximumPhasorValues, Common.MaximumAnalogValues, Common.MaximumDigitalValues)
        {
            // Define new parsing state which defines constructors for key configuration values
            State = new ConfigurationCellParsingState(
                BpaPdcStream.PhasorDefinition.CreateNewDefinition,
                BpaPdcStream.FrequencyDefinition.CreateNewDefinition,
                BpaPdcStream.AnalogDefinition.CreateNewDefinition,
                BpaPdcStream.DigitalDefinition.CreateNewDefinition);
        }

        /// <summary>
        /// Creates a new <see cref="ConfigurationCell"/> from specified parameters.
        /// </summary>
        /// <param name="parent">The reference to parent <see cref="ConfigurationFrame"/> of this <see cref="ConfigurationCell"/>.</param>
        /// <param name="idCode">The numeric ID code for this <see cref="ConfigurationCell"/>.</param>
        /// <param name="nominalFrequency">The nominal <see cref="LineFrequency"/> of the <see cref="FrequencyDefinition"/> of this <see cref="ConfigurationCell"/>.</param>
        public ConfigurationCell(ConfigurationFrame parent, ushort idCode, LineFrequency nominalFrequency)
            : this(parent)
        {
            IDCode = idCode;
            NominalFrequency = nominalFrequency;
        }

        /// <summary>
        /// Creates a new <see cref="ConfigurationCell"/> from serialization parameters.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> with populated with data.</param>
        /// <param name="context">The source <see cref="StreamingContext"/> for this deserialization.</param>
        protected ConfigurationCell(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Deserialize configuration cell
            m_sectionEntry = info.GetString("sectionEntry");
            m_formatFlags = (FormatFlags)info.GetValue("formatFlags", typeof(FormatFlags));
            m_offset = info.GetUInt16("offset");
            m_reserved = info.GetUInt16("reserved");
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets a reference to the parent <see cref="ConfigurationFrame"/> for this <see cref="ConfigurationCell"/>.
        /// </summary>
        public new ConfigurationFrame Parent
        {
            get
            {
                return base.Parent as ConfigurationFrame;
            }
            set
            {
                base.Parent = value;
            }
        }

        /// <summary>
        /// Gets or sets reference to the <see cref="ConfigurationCell"/> loaded from the configuration file associated this <see cref="ConfigurationCell"/>.
        /// </summary>
        public ConfigurationCell ConfigurationFileCell
        {
            get
            {
                return m_configurationFileCell;
            }
            set
            {
                m_configurationFileCell = value;
            }
        }

        /// <summary>
        /// Gets a reference to the <see cref="PhasorDefinitionCollection"/> of this <see cref="ConfigurationCell"/>.
        /// </summary>
        public override PhasorDefinitionCollection PhasorDefinitions
        {
            get
            {
                if (m_configurationFileCell == null)
                    return base.PhasorDefinitions;
                
                return m_configurationFileCell.PhasorDefinitions;
            }
        }

        /// <summary>
        /// Gets or sets the station name of this <see cref="ConfigurationCell"/>.
        /// </summary>
        public override string StationName
        {
            get
            {
                if (m_configurationFileCell == null)
                    return base.StationName;
                
                return m_configurationFileCell.StationName;
            }
            set
            {
                if (m_configurationFileCell == null)
                    base.StationName = value;
                else
                    m_configurationFileCell.StationName = value;
            }
        }

        /// <summary>
        /// Gets the length of the <see cref="ConfigurationCellBase.IDLabel"/> of this <see cref="ConfigurationCell"/>.
        /// </summary>
        public override int IDLabelLength
        {
            get
            {
                // BPA PDCstream ID label length is 4 characters - max!
                return 4;
            }
        }

        /// <summary>
        /// Gets or sets section entry in INI based configuration file for this <see cref="ConfigurationCell"/>.
        /// </summary>
        public string SectionEntry
        {
            get
            {
                if (m_configurationFileCell == null)
                    return m_sectionEntry;
                
                return m_configurationFileCell.SectionEntry;
            }
            set
            {
                m_sectionEntry = value.Trim();

                // Get ID label as substring of section entry
                if (!string.IsNullOrEmpty(m_sectionEntry))
                {
                    if (m_sectionEntry.Length > IDLabelLength)
                        IDLabel = m_sectionEntry.Substring(0, IDLabelLength);
                    else
                        IDLabel = m_sectionEntry;
                }
            }
        }

        /// <summary>
        /// Gets flag that determines if current <see cref="SectionEntry"/> defines a PDC block section.
        /// </summary>
        public bool IsPdcBlockSection
        {
            get
            {
                if (m_configurationFileCell == null)
                {
                    if (string.IsNullOrEmpty(m_sectionEntry))
                        return false;
                    
                    return (m_sectionEntry.Length > IDLabelLength);
                }

                return m_configurationFileCell.IsPdcBlockSection;
            }
        }

        /// <summary>
        /// Gets or sets the numeric ID code for this <see cref="ConfigurationCell"/>.
        /// </summary>
        public override ushort IDCode
        {
            get
            {
                if (m_configurationFileCell == null)
                    return base.IDCode;
                
                return m_configurationFileCell.IDCode;
            }
            set
            {
                if (m_configurationFileCell == null)
                    base.IDCode = value;
                else
                    m_configurationFileCell.IDCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IFrequencyDefinition"/> of this <see cref="ConfigurationCell"/>.
        /// </summary>
        public override IFrequencyDefinition FrequencyDefinition
        {
            get
            {
                if (m_configurationFileCell == null)
                    return base.FrequencyDefinition;
                
                return m_configurationFileCell.FrequencyDefinition;
            }
            set
            {
                if (m_configurationFileCell == null)
                    base.FrequencyDefinition = value;
                else
                    m_configurationFileCell.FrequencyDefinition = value;
            }
        }

        /// <summary>
        /// Gets or sets the nominal <see cref="LineFrequency"/> of the <see cref="FrequencyDefinition"/> of this <see cref="ConfigurationCell"/>.
        /// </summary>
        public override LineFrequency NominalFrequency
        {
            get
            {
                if (m_configurationFileCell == null)
                    return base.NominalFrequency;

                return m_configurationFileCell.NominalFrequency;
            }
            set
            {
                if (m_configurationFileCell == null)
                {
                    base.NominalFrequency = value;
                }
                else
                {
                    m_configurationFileCell.NominalFrequency = value;
                }
            }
        }

        /// <summary>
        /// Gets the maximum length of the <see cref="StationName"/> of this <see cref="ConfigurationCell"/>.
        /// </summary>
        public override int MaximumStationNameLength
        {
            get
            {
                // The station name in the PDCstream is read from an INI file, so there is no set limit
                return int.MaxValue;
            }
        }

        /// <summary>
        /// Gets or sets BPA PDCstream descriptor offset of this <see cref="ConfigurationCell"/> in its data packet.
        /// </summary>
        public ushort Offset
        {
            get
            {
                return m_offset;
            }
            set
            {
                m_offset = value;
            }
        }

        /// <summary>
        /// Gets or sets reserved word of this <see cref="ConfigurationCell"/>.
        /// </summary>
        public ushort Reserved
        {
            get
            {
                return m_reserved;
            }
            set
            {
                m_reserved = value;
            }
        }

        /// <summary>
        /// Gets or sets format flags of this <see cref="ConfigurationCell"/>.
        /// </summary>
        /// <remarks>
        /// These are bit flags, use properties to change basic values.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public FormatFlags FormatFlags
        {
            get
            {
                return m_formatFlags;
            }
            set
            {
                m_formatFlags = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="DataFormat"/> for the <see cref="IPhasorDefinition"/> objects in the <see cref="ConfigurationCellBase.PhasorDefinitions"/> of this <see cref="ConfigurationCell"/>.
        /// </summary>
        public override DataFormat PhasorDataFormat
        {
            get
            {
                return (((m_formatFlags & FormatFlags.Phasors) > 0) ? DataFormat.FloatingPoint : DataFormat.FixedInteger);
            }
            set
            {
                if (value == DataFormat.FloatingPoint)
                    m_formatFlags = m_formatFlags | FormatFlags.Phasors;
                else
                    m_formatFlags = m_formatFlags & ~FormatFlags.Phasors;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="CoordinateFormat"/> for the <see cref="IPhasorDefinition"/> objects in the <see cref="ConfigurationCellBase.PhasorDefinitions"/> of this <see cref="ConfigurationCell"/>.
        /// </summary>
        public override CoordinateFormat PhasorCoordinateFormat
        {
            get
            {
                return (((m_formatFlags & FormatFlags.Coordinates) > 0) ? CoordinateFormat.Polar : CoordinateFormat.Rectangular);
            }
            set
            {
                if (value == CoordinateFormat.Polar)
                    m_formatFlags = m_formatFlags | FormatFlags.Coordinates;
                else
                    m_formatFlags = m_formatFlags & ~FormatFlags.Coordinates;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="DataFormat"/> of the <see cref="FrequencyDefinition"/> of this <see cref="ConfigurationCell"/>.
        /// </summary>
        public override DataFormat FrequencyDataFormat
        {
            get
            {
                return (((m_formatFlags & FormatFlags.Frequency) > 0) ? DataFormat.FloatingPoint : DataFormat.FixedInteger);
            }
            set
            {
                if (value == DataFormat.FloatingPoint)
                    m_formatFlags = m_formatFlags | FormatFlags.Frequency;
                else
                    m_formatFlags = m_formatFlags & ~FormatFlags.Frequency;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="DataFormat"/> for the <see cref="IAnalogDefinition"/> objects in the <see cref="ConfigurationCellBase.AnalogDefinitions"/> of this <see cref="ConfigurationCell"/>.
        /// </summary>
        public override DataFormat AnalogDataFormat
        {
            get
            {
                return (((m_formatFlags & FormatFlags.Analog) > 0) ? DataFormat.FloatingPoint : DataFormat.FixedInteger);
            }
            set
            {
                if (value == DataFormat.FloatingPoint)
                    m_formatFlags = m_formatFlags | FormatFlags.Analog;
                else
                    m_formatFlags = m_formatFlags & ~FormatFlags.Analog;
            }
        }

        // The descriptor cell broadcasted by PDCstream only includes PMUID and offset, all
        // other metadata is defined in an external INI based configuration file - so we
        // override the base class image implementations which attempt to generate and
        // parse data based on a common nature of IEEE configuration frames

        /// <summary>
        /// Gets the length of the <see cref="HeaderImage"/>.
        /// </summary>
        protected override int HeaderLength
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the binary header image of the <see cref="ConfigurationCell"/> object.
        /// </summary>
        protected override byte[] HeaderImage
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the length of the <see cref="BodyImage"/>.
        /// </summary>
        protected override int BodyLength
        {
            get
            {
                return FixedBodyLength;
            }
        }

        /// <summary>
        /// Gets the binary body image of the <see cref="ConfigurationCell"/> object.
        /// </summary>
        protected override byte[] BodyImage
        {
            get
            {
                byte[] buffer = new byte[FixedBodyLength];
                int index = 0;

                IDLabelImage.CopyImage(buffer, ref index, IDLabelLength);   // PMUID
                EndianOrder.BigEndian.CopyBytes(Reserved, buffer, index);   // Reserved
                EndianOrder.BigEndian.CopyBytes(Offset, buffer, index + 2); // Offset

                return buffer;
            }
        }

        /// <summary>
        /// Gets the length of the <see cref="FooterImage"/>.
        /// </summary>
        protected override int FooterLength
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the binary footer image of the <see cref="ConfigurationCell"/> object.
        /// </summary>
        protected override byte[] FooterImage
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// <see cref="Dictionary{TKey,TValue}"/> of string based property names and values for the <see cref="ConfigurationCell"/> object.
        /// </summary>
        public override Dictionary<string, string> Attributes
        {
            get
            {
                Dictionary<string, string> baseAttributes = base.Attributes;

                baseAttributes.Add("INI File Section Entry", SectionEntry);
                baseAttributes.Add("Offset", Offset.ToString());
                baseAttributes.Add("Reserved", Reserved.ToString());

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
            // BPA PDC stream doesn't use standard configuration cell header like IEEE protocols do - so we override this function to do nothing
            return 0;
        }

        /// <summary>
        /// Parses the binary body image.
        /// </summary>
        /// <param name="binaryImage">Binary image to parse.</param>
        /// <param name="startIndex">Start index into <paramref name="binaryImage"/> to begin parsing.</param>
        /// <param name="length">Length of valid data within <paramref name="binaryImage"/>.</param>
        /// <returns>The length of the data that was parsed.</returns>
        protected override int ParseBodyImage(byte[] binaryImage, int startIndex, int length)
        {
            IDLabel = Encoding.ASCII.GetString(binaryImage, startIndex, 4);
            Reserved = EndianOrder.BigEndian.ToUInt16(binaryImage, startIndex + 4);
            Offset = EndianOrder.BigEndian.ToUInt16(binaryImage, startIndex + 6);

            return FixedBodyLength;
        }

        /// <summary>
        /// Parses the binary footer image.
        /// </summary>
        /// <param name="binaryImage">Binary image to parse.</param>
        /// <param name="startIndex">Start index into <paramref name="binaryImage"/> to begin parsing.</param>
        /// <param name="length">Length of valid data within <paramref name="binaryImage"/>.</param>
        /// <returns>The length of the data that was parsed.</returns>
        protected override int ParseFooterImage(byte[] binaryImage, int startIndex, int length)
        {
            // BPA PDC stream doesn't use standard configuration cell footer like IEEE protocols do - so we override this function to do nothing
            return 0;
        }

        /// <summary>
        /// Populates a <see cref="SerializationInfo"/> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> to populate with data.</param>
        /// <param name="context">The destination <see cref="StreamingContext"/> for this serialization.</param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            // Serialize configuration cell
            info.AddValue("sectionEntry", SectionEntry);
            info.AddValue("formatFlags", m_formatFlags, typeof(FormatFlags));
            info.AddValue("offset", m_offset);
            info.AddValue("reserved", m_reserved);
        }

        #endregion

        #region [ Static ]

        // Static Methods

        // Delegate handler to create a new BPA PDCstream configuration cell
        internal static IConfigurationCell CreateNewCell(IChannelFrame parent, IChannelFrameParsingState<IConfigurationCell> state, int index, byte[] binaryImage, int startIndex, out int parsedLength)
        {
            ConfigurationCell configCell = new ConfigurationCell(parent as IConfigurationFrame);

            parsedLength = configCell.Initialize(binaryImage, startIndex, 0);

            return configCell;
        }

        #endregion        
    }
}