//*******************************************************************************************************
//  DataPacket.cs
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
