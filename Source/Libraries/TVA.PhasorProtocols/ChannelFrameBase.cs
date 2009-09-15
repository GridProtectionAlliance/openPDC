//*******************************************************************************************************
//  ChannelFrameBase.cs - Gbtc
//
//  Tennessee Valley Authority, 2009
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  This software is made freely available under the TVA Open Source Agreement (see below).
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  01/14/2005 - J. Ritchie Carroll
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
using System.Runtime.Serialization;
using System.Security.Permissions;
using TVA.Measurements;

namespace TVA.PhasorProtocols
{
    /// <summary>
    /// Represents the protocol independent common implementation of any frame of data that can be sent or received.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This phasor protocol implementation defines a "frame" as a collection of cells (logical units of data).
    /// For example, a <see cref="DataCellBase"/> could be defined as a PMU within a frame of data, a <see cref="DataFrameBase"/>
    /// (derived from <see cref="ChannelFrameBase{T}"/>), that contains multiple PMU's coming from a PDC.
    /// </para>
    /// <para>
    /// This class implements the <see cref="IFrame"/> interface so it can be cooperatively integrated into measurement concentration.
    /// For more information see the <see cref="ConcentratorBase"/> class.
    /// </para>
    /// </remarks>
    /// <typeparam name="T">Specific <see cref="IChannelCell"/> type that the <see cref="ChannelFrameBase{T}"/> contains.</typeparam>
    [Serializable()]
    public abstract class ChannelFrameBase<T> : ChannelBase, IChannelFrame<T> where T : IChannelCell
    {
        #region [ Members ]

        // Fields
        private ushort m_idCode;                                            // Numeric identifier of this frame of data (e.g., ID code of the PDC)
        private IChannelCellCollection<T> m_cells;                          // Collection of "cells" within this frame of data (e.g., PMU's in the PDC frame)
        private Ticks m_timestamp;                                          // Time, represented as 100-nanosecond ticks, of this frame of data
        private int m_parsedBinaryLength;                                   // Binary length of frame as provided from parsed header
        private bool m_published;                                           // Determines if this frame of data has been published (IFrame.Published)
        private int m_publishedMeasurements;                                // Total measurements published by this frame          (IFrame.PublishedMeasurements)
        private Dictionary<MeasurementKey, IMeasurement> m_measurements;    // Collection of measurements published by this frame  (IFrame.Measurements)
        private IMeasurement m_lastSortedMeasurement;                       // Last measurement sorted into this frame             (IFrame.LastSortedMeasurement)

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new <see cref="ChannelFrameBase{T}"/> from specified parameters.
        /// </summary>
        /// <param name="idCode">The ID code of this <see cref="ChannelFrameBase{T}"/>.</param>
        /// <param name="cells">The reference to the collection of cells for this <see cref="ChannelFrameBase{T}"/>.</param>
        /// <param name="timestamp">The exact timestamp, in <see cref="Ticks"/>, of the data represented by this <see cref="ChannelFrameBase{T}"/>.</param>
        protected ChannelFrameBase(ushort idCode, IChannelCellCollection<T> cells, Ticks timestamp)
        {
            m_idCode = idCode;
            m_cells = cells;
            m_timestamp = timestamp;
        }

        /// <summary>
        /// Creates a new <see cref="ChannelFrameBase{T}"/> from serialization parameters.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> with populated with data.</param>
        /// <param name="context">The source <see cref="StreamingContext"/> for this deserialization.</param>
        protected ChannelFrameBase(SerializationInfo info, StreamingContext context)
        {
            // Deserialize key frame elements...
            m_idCode = info.GetUInt16("idCode");
            m_cells = (IChannelCellCollection<T>)info.GetValue("cells", typeof(IChannelCellCollection<T>));
            m_timestamp = info.GetInt64("timestamp");
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets the <see cref="FundamentalFrameType"/> for this <see cref="ChannelFrameBase{T}"/>.
        /// </summary>
        public abstract FundamentalFrameType FrameType { get; }

        /// <summary>
        /// Gets the strongly-typed reference to the collection of cells for this <see cref="ChannelFrameBase{T}"/>.
        /// </summary>
        public virtual IChannelCellCollection<T> Cells
        {
            get
            {
                return m_cells;
            }
        }

        // Gets the simple object reference to the cell collection to satisfy IChannelFrame.Cells
        object IChannelFrame.Cells
        {
            get
            {
                return m_cells;
            }
        }

        /// <summary>
        /// Keyed measurements in this <see cref="ChannelFrameBase{T}"/>.
        /// </summary>
        /// <remarks>
        /// Represents a dictionary of measurements, keyed by <see cref="MeasurementKey"/>.
        /// </remarks>
        public virtual IDictionary<MeasurementKey, IMeasurement> Measurements
        {
            get
            {
                if (m_measurements == null)
                    m_measurements = new Dictionary<MeasurementKey, IMeasurement>();

                return m_measurements;
            }
        }

        /// <summary>
        /// Gets or sets the ID code of this <see cref="ChannelFrameBase{T}"/>.
        /// </summary>
        public virtual ushort IDCode
        {
            get
            {
                return m_idCode;
            }
            set
            {
                m_idCode = value;
            }
        }

        /// <summary>
        /// Gets or sets exact timestamp, in ticks, of the data represented by this <see cref="ChannelFrameBase{T}"/>.
        /// </summary>
        /// <remarks>
        /// The value of this property represents the number of 100-nanosecond intervals that have elapsed since 12:00:00 midnight, January 1, 0001.
        /// </remarks>
        public virtual Ticks Timestamp
        {
            get
            {
                return m_timestamp;
            }
            set
            {
                m_timestamp = value;
            }
        }

        /// <summary>
        /// Gets UNIX based time representation of the ticks of this <see cref="ChannelFrameBase{T}"/>.
        /// </summary>
        public virtual UnixTimeTag TimeTag
        {
            get
            {
                return new UnixTimeTag(Timestamp);
            }
        }

        /// <summary>
        /// Gets or sets the parsing state for the this <see cref="ChannelFrameBase{T}"/>.
        /// </summary>
        new public virtual IChannelFrameParsingState<T> State
        {
            get
            {
                return base.State as IChannelFrameParsingState<T>;
            }
            set
            {
                base.State = value;
            }
        }

        /// <summary>
        /// Gets ot sets reference to last <see cref="IMeasurement"/> that was sorted into this <see cref="ChannelFrameBase{T}"/>.
        /// </summary>
        /// <remarks>
        /// This value is used to help monitor slow moving measurements that are being sorted into the <see cref="ChannelFrameBase{T}"/>.
        /// </remarks>
        public virtual IMeasurement LastSortedMeasurement
        {
            get
            {
                return m_lastSortedMeasurement;
            }
            set
            {
                m_lastSortedMeasurement = value;
            }
        }

        /// <summary>
        /// Gets or sets published state of this <see cref="ChannelFrameBase{T}"/>.
        /// </summary>
        public virtual bool Published
        {
            get
            {
                return m_published;
            }
            set
            {
                m_published = value;
            }
        }

        /// <summary>
        /// Gets or sets total number of measurements that have been published for this <see cref="ChannelFrameBase{T}"/>.
        /// </summary>
        public virtual int PublishedMeasurements
        {
            get
            {
                return m_publishedMeasurements;
            }
            set
            {
                m_publishedMeasurements = value;
            }
        }

        /// <summary>
        /// Gets the length of the <see cref="BinaryImage"/>.
        /// </summary>
        /// <remarks>
        /// This property is overriden so the length can be extended to include a checksum.
        /// </remarks>
        public override int BinaryLength
        {
            get
            {
                // We override normal binary length so we can extend length to include checksum.
                // Also, if frame length was parsed from stream header - we use that length
                // instead of the calculated length...
                if (m_parsedBinaryLength > 0)
                    return m_parsedBinaryLength;
                else
                    return 2 + base.BinaryLength;
            }
        }

        /// <summary>
        /// Gets the binary image of this <see cref="ChannelFrameBase{T}"/>.
        /// </summary>
        /// <remarks>
        /// This property is overriden to include a checksum in the image.
        /// </remarks>
        public override byte[] BinaryImage
        {
            get
            {
                // We override normal binary image to include checksum
                byte[] buffer = new byte[BinaryLength];
                int index = 0;

                // Copy in base image
                base.BinaryImage.CopyImage(buffer, ref index, base.BinaryLength);

                // Add check sum
                AppendChecksum(buffer, index);

                return buffer;
            }
        }

        /// <summary>
        /// Gets the length of the <see cref="BodyImage"/>.
        /// </summary>
        /// <remarks>
        /// The length of the <see cref="ChannelFrameBase{T}"/> body image is the combined length of all the <see cref="Cells"/>.
        /// </remarks>
        protected override int BodyLength
        {
            get
            {
                return m_cells.BinaryLength;
            }
        }

        /// <summary>
        /// Gets the binary body image of this <see cref="ChannelFrameBase{T}"/>.
        /// </summary>
        /// <remarks>
        /// The body image of the <see cref="ChannelFrameBase{T}"/> is the combined images of all the <see cref="Cells"/>.
        /// </remarks>
        protected override byte[] BodyImage
        {
            get
            {
                return m_cells.BinaryImage;
            }
        }

        /// <summary>
        /// <see cref="Dictionary{TKey,TValue}"/> of string based property names and values for the <see cref="ChannelFrameBase{T}"/> object.
        /// </summary>
        public override Dictionary<string, string> Attributes
        {
            get
            {
                Dictionary<string, string> baseAttributes = base.Attributes;

                baseAttributes.Add("Total Cells", Cells.Count.ToString());
                baseAttributes.Add("Fundamental Frame Type", (int)FrameType + ": " + FrameType);
                baseAttributes.Add("ID Code", IDCode.ToString());
                baseAttributes.Add("Published", Published.ToString());
                baseAttributes.Add("Ticks", ((long)Timestamp).ToString());
                baseAttributes.Add("Timestamp", ((DateTime)Timestamp).ToString("yyyy-MM-dd HH:mm:ss.fff"));

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
        /// This method is overriden to validate the checksum in the <see cref="ChannelFrameBase{T}"/>.
        /// </remarks>
        /// <exception cref="InvalidOperationException">Invalid binary image detected - check sum did not match.</exception>
        public override int Initialize(byte[] binaryImage, int startIndex, int length)
        {
            // We use data length parsed from data stream if available - in many cases we'll have to as we won't enough
            // information about cell contents at this early parsing stage
            m_parsedBinaryLength = State.ParsedBinaryLength;
            
            // Normal binary image parsing is overriden for a frame so that checksum can be validated
            if (!ChecksumIsValid(binaryImage, startIndex))
                throw new InvalidOperationException("Invalid binary image detected - check sum of " + this.GetType().Name + " did not match");

            // Include 2 bytes for CRC in returned parsed length
            return base.Initialize(binaryImage, startIndex, length) + 2;
        }

        /// <summary>
        /// Parses the binary body image.
        /// </summary>
        /// <param name="binaryImage">Binary image to parse.</param>
        /// <param name="startIndex">Start index into <paramref name="binaryImage"/> to begin parsing.</param>
        /// <param name="length">Length of valid data within <paramref name="binaryImage"/>.</param>
        /// <returns>The length of the data that was parsed.</returns>
        /// <remarks>
        /// The body image of the <see cref="ChannelFrameBase{T}"/> is parsed to create a collection of <see cref="Cells"/>.
        /// </remarks>
        protected override int ParseBodyImage(byte[] binaryImage, int startIndex, int length)
        {
            IChannelFrameParsingState<T> state = State;
            T cell;
            int parsedLength, index = startIndex;

            // Parse all frame cells
            for (int x = 0; x < state.CellCount; x++)
            {
                cell = state.CreateNewCell(this, state, x, binaryImage, index, out parsedLength);
                m_cells.Add(cell);
                index += parsedLength;
            }

            return (index - startIndex);
        }

        /// <summary>
        /// Determines if checksum in the <paramref name="buffer"/> is valid.
        /// </summary>
        /// <param name="buffer">Buffer image to validate.</param>
        /// <param name="startIndex">Start index into <paramref name="buffer"/> to perform checksum.</param>
        /// <returns>Flag that determines if checksum over <paramref name="buffer"/> is valid.</returns>
        /// <remarks>
        /// Default implementation expects 2-byte big-endian ordered checksum. Override method if protocol checksum
        /// implementation is different.
        /// </remarks>
        protected virtual bool ChecksumIsValid(byte[] buffer, int startIndex)
        {
            int sumLength = BinaryLength - 2;
            return EndianOrder.BigEndian.ToUInt16(buffer, startIndex + sumLength) == CalculateChecksum(buffer, startIndex, sumLength);
        }

        /// <summary>
        /// Appends checksum onto <paramref name="buffer"/> starting at <paramref name="startIndex"/>.
        /// </summary>
        /// <param name="buffer">Buffer image on which to append checksum.</param>
        /// <param name="startIndex">Index into <paramref name="buffer"/> where checksum should be appended.</param>
        /// <remarks>
        /// Default implementation encodes checksum in big-endian order and expects buffer size large enough to accomodate
        /// 2-byte checksum representation. Override method if protocol expectations are different.
        /// </remarks>
        protected virtual void AppendChecksum(byte[] buffer, int startIndex)
        {
            EndianOrder.BigEndian.CopyBytes(CalculateChecksum(buffer, 0, startIndex), buffer, startIndex);
        }

        /// <summary>
        /// Calculates checksum of given <paramref name="buffer"/>.
        /// </summary>
        /// <param name="buffer">Buffer image over which to calculate checksum.</param>
        /// <param name="offset">Start index into <paramref name="buffer"/> to calculate checksum.</param>
        /// <param name="length">Length of data within <paramref name="buffer"/> to calculate checksum.</param>
        /// <returns>Checksum over specified portion of <paramref name="buffer"/>.</returns>
        /// <remarks>
        /// Override with needed checksum calculation for particular protocol.
        /// <example>
        /// This example provides a CRC-CCITT checksum:
        /// <code>
        /// using TVA.IO.Checksums;
        /// 
        /// protected override ushort CalculateChecksum(byte[] buffer, int offset, int length)
        /// {
        ///     // Return calculated CRC-CCITT over given buffer...
        ///     return buffer.CrcCCITTChecksum(offset, length);
        /// }
        /// </code>
        /// </example>
        /// </remarks>
        protected abstract ushort CalculateChecksum(byte[] buffer, int offset, int length);

        /// <summary>
        /// Compares the <see cref="ChannelFrameBase{T}"/> with an <see cref="IFrame"/>.
        /// </summary>
        /// <param name="other">The <see cref="IFrame"/> to compare with the current <see cref="ChannelFrameBase{T}"/>.</param>
        /// <returns>A 32-bit signed integer that indicates the relative order of the objects being compared.</returns>
        /// <remarks>This frame implementation compares itself by timestamp.</remarks>
        public virtual int CompareTo(IFrame other)
        {
            // We sort frames by timestamp
            return m_timestamp.CompareTo(other.Timestamp);
        }

        /// <summary>
        /// Compares the <see cref="ChannelFrameBase{T}"/> with the specified <see cref="Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to compare with the current <see cref="ChannelFrameBase{T}"/>.</param>
        /// <returns>A 32-bit signed integer that indicates the relative order of the objects being compared.</returns>
        /// <exception cref="ArgumentException"><see cref="Object"/> is not an <see cref="IFrame"/>.</exception>
        /// <remarks>This frame implementation compares itself by timestamp.</remarks>
        public virtual int CompareTo(object obj)
        {
            IFrame other = obj as IFrame;

            if (other != null)
                return CompareTo(other);

            throw new ArgumentException("Frame can only be compared with other IFrames...");
        }

        /// <summary>
        /// Determines whether the specified <see cref="IFrame"/> is equal to the current <see cref="ChannelFrameBase{T}"/>.
        /// </summary>
        /// <param name="other">The <see cref="IFrame"/> to compare with the current <see cref="ChannelFrameBase{T}"/>.</param>
        /// <returns>
        /// true if the specified <see cref="IFrame"/> is equal to the current <see cref="ChannelFrameBase{T}"/>;
        /// otherwise, false.
        /// </returns>
        /// <remarks>This frame implementation compares itself by timestamp.</remarks>
        public virtual bool Equals(IFrame other)
        {
            return (CompareTo(other) == 0);
        }

        /// <summary>
        /// Determines whether the specified <see cref="Object"/> is equal to the current <see cref="ChannelFrameBase{T}"/>.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to compare with the current <see cref="ChannelFrameBase{T}"/>.</param>
        /// <returns>
        /// true if the specified <see cref="Object"/> is equal to the current <see cref="ChannelFrameBase{T}"/>;
        /// otherwise, false.
        /// </returns>
        /// <exception cref="ArgumentException"><see cref="Object"/> is not an <see cref="IFrame"/>.</exception>
        public override bool Equals(object obj)
        {
            IFrame other = obj as IFrame;

            if (other != null)
                return Equals(other);

            return false;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return m_timestamp.GetHashCode();
        }

        /// <summary>
        /// Populates a <see cref="SerializationInfo"/> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> to populate with data.</param>
        /// <param name="context">The destination <see cref="StreamingContext"/> for this serialization.</param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Add key frame elements for serialization...
            info.AddValue("idCode", m_idCode);
            info.AddValue("cells", m_cells, typeof(IChannelCellCollection<T>));
            info.AddValue("timestamp", (long)m_timestamp);
        }

        #endregion
    }
}