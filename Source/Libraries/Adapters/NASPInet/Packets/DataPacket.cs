//*******************************************************************************************************
//  DataPacket.cs - Gbtc
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
using TVA;
using TVA.IO.Checksums;
using TVA.Parsing;
using TVA.Security.Cryptography;

namespace NASPInet.Packets
{
    #region [ Enumerations ]
    
    /// <summary>
    /// NASPInet data packet status flags enumeration.
    /// </summary>
    [Flags()]
    public enum StatusFlags : ushort
    {
        /// <summary>
        /// Data packet timestamp and values are encrypted: 0 packet is not encrypted, 1 packet is encrypted.
        /// </summary>
        DataIsEncrypted = (ushort)Bits.Bit00,
        /// <summary>
        /// Cryptographic key state: 0 use even key, 1 use odd key.
        /// </summary>
        KeyState = (ushort)Bits.Bit01,
        /// <summary>
        /// Data is valid according to source device: 0 when device data is valid, 1 when invalid or device is in test mode.
        /// </summary>
        DataIsValid = (ushort)Bits.Bit02,
        /// <summary>
        /// Synchronization is valid according to source device: 0 when in device is in sync, 1 when it is not.
        /// </summary>
        SynchronizationIsValid = (ushort)Bits.Bit03,
        /// <summary>
        /// Reserved bits for future status flags, presently set to 0.
        /// </summary>
        ReservedFlags = (ushort)(Bits.Bit04 | Bits.Bit05 | Bits.Bit06 | Bits.Bit07 | Bits.Bit08 | Bits.Bit09 | Bits.Bit10 | Bits.Bit11 | Bits.Bit12 | Bits.Bit13 | Bits.Bit14 | Bits.Bit15),
        /// <summary>
        /// No flags set.
        /// </summary>
        NoFlags = (ushort)Bits.Nil
    }

    #endregion
    
    /// <summary>
    /// Represents a NASPInet data transmission packet.
    /// </summary>
    /// <remarks>
    /// Data Structure:
    /// <list type="table">
    ///     <listheader>
    ///         <term>Data Element Size</term>
    ///         <description>Data Element Description</description>
    ///     </listheader>
    ///     <item>
    ///         <term>16 bytes (128-bits)</term>
    ///         <description><see cref="Guid"/> based unique identifier.</description>
    ///     </item>
    ///     <item>
    ///         <term>8 bytes (64-bits)</term>
    ///         <description>Data timestamp (Int64 epoch based time from 01/01/0001 12:00:00 AM).</description>
    ///     </item>
    ///     <item>
    ///         <term>8 bytes (64-bits)</term>
    ///         <description>Data value (data type has variable interpretation).</description>
    ///     </item>
    ///     <item>
    ///         <term>2 bytes (16-bits)</term>
    ///         <description><see cref="StatusFlags"/>.</description>
    ///     </item>
    ///     <item>
    ///         <term>2 bytes (16-bits)</term>
    ///         <description>CRC-CCITT of entire packet post encryption.</description>
    ///     </item>
    /// </list>
    /// <br/>
    /// If encryption is enabled, only the data value is encrypted within the data packet, CRC of entire
    /// packet occurs after encryption. Bytes of all numeric values are encoded in big-endian order.
    /// </remarks>
    public class DataPacket : ISupportFrameImage<int>
    {
        #region [ Members ]

        // Constants

        /// <summary>
        /// Fixed length of <see cref="DataPacket"/>.
        /// </summary>
        public const int FixedLength = 36;

        // Fields
        private Guid m_signalID;
        private Ticks m_timestamp;
        private BigBinaryValue m_value;
        private StatusFlags m_statusFlags;
        private byte[] m_encryptedData;

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets <see cref="Guid"/> based signal ID for this <see cref="DataPacket"/>.
        /// </summary>
        public Guid SignalID
        {
            get
            {
                return m_signalID;
            }
            set
            {
                m_signalID = value;
            }
        }

        /// <summary>
        /// Gets or sets timestamp of this <see cref="DataPacket"/>.
        /// </summary>
        /// <remarks>
        /// <see cref="Ticks"/> is implicitly castable to <see cref="DateTime"/>.
        /// </remarks>
        public Ticks Timestamp
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
        /// Gets or sets data value of this <see cref="DataPacket"/>.
        /// </summary>
        /// <remarks>
        /// <see cref="BigBinaryValue"/> stores data values as bytes in big-endian order;
        /// the value is implicitly castable to most all common native data types. The
        /// NASPInet <see cref="DataPacket"/> will only transport values that are less
        /// than or equal to 8-bytes.
        /// </remarks>
        public BigBinaryValue Value
        {
            get
            {
                return m_value;
            }
            set
            {
                if (value.Buffer.Length > 8)
                    throw new InvalidOperationException("Value too large for NASPInet data packet; binary size of data must be less than or equal to 8-bytes");

                m_value = value;
            }
        }

        /// <summary>
        /// Gets ot sets <see cref="NASPInet.Packets.StatusFlags"/> for this <see cref="DataPacket"/>.
        /// </summary>
        /// <remarks>
        /// Common status flags can be set and retrieved from their associated <see cref="DataPacket"/> properties.
        /// </remarks>
        public StatusFlags StatusFlags
        {
            get
            {
                return m_statusFlags;
            }
            set
            {
                m_statusFlags = value;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if <see cref="DataPacket"/> is encrypted.
        /// </summary>
        public bool DataIsEncrypted
        {
            get
            {
                return (m_statusFlags & StatusFlags.DataIsEncrypted) > 0;
            }
            set
            {
                if (value)
                    m_statusFlags |= StatusFlags.DataIsEncrypted;
                else
                    m_statusFlags = m_statusFlags & ~StatusFlags.DataIsEncrypted;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if key state of <see cref="DataPacket"/> is even.
        /// </summary>
        public bool KeyStateIsEven
        {
            get
            {
                return (m_statusFlags & StatusFlags.KeyState) == 0;
            }
            set
            {
                if (value)
                    m_statusFlags = m_statusFlags & ~StatusFlags.KeyState;
                else
                    m_statusFlags |= StatusFlags.KeyState;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if data is valid (as reported by source device) for this <see cref="DataPacket"/>.
        /// </summary>
        public bool DataIsValid
        {
            get
            {
                return (m_statusFlags & StatusFlags.DataIsValid) == 0;
            }
            set
            {
                if (value)
                    m_statusFlags = m_statusFlags & ~StatusFlags.DataIsValid;
                else
                    m_statusFlags |= StatusFlags.DataIsValid;
            }
        }

        /// <summary>
        /// Gets or sets flag that determines if synchronization (i.e., timestamp) is valid (as reported by source device) for this <see cref="DataPacket"/>.
        /// </summary>
        public bool SynchronizationIsValid
        {
            get
            {
                return (m_statusFlags & StatusFlags.SynchronizationIsValid) == 0;
            }
            set
            {
                if (value)
                    m_statusFlags = m_statusFlags & ~StatusFlags.SynchronizationIsValid;
                else
                    m_statusFlags |= StatusFlags.SynchronizationIsValid;
            }
        }

        /// <summary>
        /// Gets binary image of this <see cref="DataPacket"/>.
        /// </summary>
        public byte[] BinaryImage
        {
            get
            {
                bool dataIsEncrypted = DataIsEncrypted;

                if (dataIsEncrypted && (m_encryptedData == null || m_encryptedData.Length != 8))
                    throw new InvalidOperationException("Data has not been encrypted or encrypted data is invalid, cannot generate binary image");

                if (m_value == null)
                    throw new NullReferenceException("No value has been assigned to data packet, cannot generate binary image");

                byte[] image = new byte[FixedLength];

                // Add signal ID to image
                EndianOrder.BigEndian.CopyBytes(m_signalID, image, 0);

                // Add timestamp to image
                EndianOrder.BigEndian.CopyBytes(m_timestamp, image, 16);

                // Add data value to image
                if (dataIsEncrypted)
                    Buffer.BlockCopy(m_encryptedData, 0, image, 24, 8);
                else
                    Buffer.BlockCopy(m_value.Buffer, 0, image, 24, 8);

                // Add status flags to image
                EndianOrder.BigEndian.CopyBytes((ushort)m_statusFlags, image, 32);

                // Calculate CRC and add to image
                EndianOrder.BigEndian.CopyBytes(image.CrcCCITTChecksum(0, 34), image, 34);

                return image;
            }
        }

        /// <summary>
        /// Gets length of <see cref="BinaryImage"/> of this <see cref="DataPacket"/>.
        /// </summary>
        public int BinaryLength
        {
            get
            {
                return FixedLength;
            }
        }

        // Required by ISupportFrameImage...
        int ISupportFrameImage<int>.TypeID
        {
            get
            {
                // There is only one frame type in NASPInet data channel transport protocol
                return 0;
            }
        }

        // Required by ISupportFrameImage...
        ICommonHeader<int> ISupportFrameImage<int>.CommonHeader { get; set; }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Initializes a new <see cref="DataPacket"/> from the <paramref name="binaryImage"/>.
        /// </summary>
        /// <param name="binaryImage">Binary image to be used for initialization.</param>
        /// <param name="startIndex">0-based starting index in the <paramref name="binaryImage"/> to be used for initialization.</param>
        /// <param name="length">Valid number of bytes within binary image.</param>
        /// <returns>The number of bytes used for initialization in the <paramref name="binaryImage"/> (i.e., the number of bytes parsed).</returns>
        public int Initialize(byte[] binaryImage, int startIndex, int length)
        {
            // Validate CRC in binary image
            if (binaryImage.CrcCCITTChecksum(startIndex, 34) != EndianOrder.BigEndian.ToUInt16(binaryImage, startIndex + 34))
                throw new InvalidOperationException("CRC check failed for NASPInet DataPacket");

            // Extract signal ID from image
            m_signalID = EndianOrder.BigEndian.ToGuid(binaryImage, startIndex);

            // Extract timestamp from image
            m_timestamp = EndianOrder.BigEndian.ToInt64(binaryImage, startIndex + 16);

            // Extract status flags from image (we do this before data so we can check flags)
            m_statusFlags = (StatusFlags)EndianOrder.BigEndian.ToUInt16(binaryImage, startIndex + 32);

            // Extract data image from image
            if (DataIsEncrypted)
                m_encryptedData = binaryImage.BlockCopy(startIndex + 24, 8);
            else
                m_value = new BigBinaryValue(binaryImage, startIndex + 24, 8);

            return FixedLength;
        }

        /// <summary>
        /// Decrypts the data value.
        /// </summary>
        /// <param name="cryptoProperties"><see cref="CryptoProperties"/> used to decrypt data.</param>
        public void DecryptValue(CryptoProperties cryptoProperties)
        {
            if (m_encryptedData == null)
                throw new NullReferenceException("No encrypted value has been parsed from binary image, cannot decrypt value");

            // Decrypt data value
            byte[] decryptedData = cryptoProperties.Algorithm.Decrypt(m_encryptedData, 0, m_encryptedData.Length, cryptoProperties.Key, cryptoProperties.IV);

            if (decryptedData.Length == 8)
                m_value = new BigBinaryValue(decryptedData, 0, 8);
            else
                throw new InvalidOperationException(string.Format("Decrypted {0} bytes from NASPInet data packet, expected 8", decryptedData.Length));
        }

        /// <summary>
        /// Encrypts the data value.
        /// </summary>
        /// <param name="cryptoProperties"><see cref="CryptoProperties"/> used to encrypt data.</param>
        public void EncryptValue(CryptoProperties cryptoProperties)
        {
            if (m_value == null)
                throw new NullReferenceException("No value has been assigned to data packet, cannot encrypt value");

            // Data value buffer may be smaller than 8-bytes, so we allocate a buffer of expected size
            byte[] decryptedData = new byte[8];

            // Copy relevant portion of data value into buffer in big-endian order
            Buffer.BlockCopy(m_value.Buffer, 0, decryptedData, 0, m_value.Buffer.Length);

            // Encrypt data value
            m_encryptedData = cryptoProperties.Algorithm.Encrypt(decryptedData, 0, 8, cryptoProperties.Key, cryptoProperties.IV);
        }

        #endregion
    }
}
