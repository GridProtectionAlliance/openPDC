//*******************************************************************************************************
//  CommandPacketBase.cs
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
    /// Command packet type enumeration.
    /// </summary>
    public enum CommandPacketType : byte
    {
        /// <summary>
        /// Request command packet.
        /// </summary>
        Request = 0xAA,
        /// <summary>
        /// Response command packet.
        /// </summary>
        Response = 0xBB
    }

    #endregion

    /// <summary>
    /// Represents the base class for NASPInet command packets.
    /// </summary>
    /// <remarks>
    /// This is the base class for the <see cref="RequestPacket"/> and the <see cref="ResponsePacket"/> classes.
    /// <br/><br/>
    /// Data Structure:
    /// <list type="table">
    ///     <listheader>
    ///         <term>Data Element Size</term>
    ///         <description>Data Element Description</description>
    ///     </listheader>
    ///     <item>
    ///         <term>2 bytes (16-bits)</term>
    ///         <description>Command ID. First byte represents type: Request = 0xAA, Response = 0xBB.</description>
    ///     </item>
    ///     <item>
    ///         <term>2 bytes (16-bits)</term>
    ///         <description>Number of bytes in the command packet.</description>
    ///     </item>
    ///     <item>
    ///         <term>16 bytes (128-bits)</term>
    ///         <description><see cref="Guid"/> based unique identifier of original request.</description>
    ///     </item>
    ///     <item>
    ///         <term>Variable</term>
    ///         <description>Command packet payload (if any).</description>
    ///     </item>
    ///     <item>
    ///         <term>2 bytes (16-bits)</term>
    ///         <description>CRC-CCITT of entire packet.</description>
    ///     </item>
    /// </list>
    /// <br/>
    /// If the crypto properties are defined, only the payload will be encrypted within the data packet; CRC
    /// of entire packet occurs after encryption. Bytes of all numeric values are encoded in big-endian order.
    /// </remarks>
    public abstract class CommandPacketBase : ISupportFrameImage<CommandPacketType>
    {
        #region [ Members ]

        // Constants

        /// <summary>
        /// Fixed length of <see cref="CommandPacketBase"/> including CRC.
        /// </summary>
        public const int FixedLength = 22;

        // Fields
        private ushort m_commandID;
        private Guid m_requestID;
        private ushort m_frameLength;
        private CommandPacketHeader m_commonHeader;
        private byte[] m_payload;
        private byte[] m_encryptedData;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new <see cref="CommandPacketBase"/>.
        /// </summary>
        protected CommandPacketBase()
	    {
            m_requestID = Guid.Empty;
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets unique request ID of this <see cref="CommandPacketBase"/>.
        /// </summary>
        /// <remarks>
        /// If no <see cref="Guid"/> has been assigned when <see cref="BinaryImage"/> is called, one will be created.
        /// </remarks>
        public Guid RequestID
        {
            get
            {
                return m_requestID;
            }
            set
            {
                m_requestID = value;
            }
        }

        /// <summary>
        /// Gets or sets payload of this <see cref="CommandPacketBase"/>.
        /// </summary>
        public byte[] Payload
        {
            get
            {
                return m_payload;
            }
            set
            {
                m_payload = value;

                // Changes to payload invalidate any parsed framelength...
                m_frameLength = 0;
            }
        }

        /// <summary>
        /// Gets the binary image of the <see cref="CommandPacketBase"/>.
        /// </summary>
        public byte[] BinaryImage
        {
            get
            {
                if (m_payload != null && m_encryptedData == null)
                    throw new InvalidOperationException("Payload has not been encrypted, cannot generate binary image");

                ushort length = (ushort)BinaryLength;
                byte[] image = new byte[length];

                // Generate a new unique ID for command packet if one hasn't been defined
                if (m_requestID == Guid.Empty)
                    m_requestID = Guid.NewGuid();

                // Add command ID to image
                EndianOrder.BigEndian.CopyBytes(m_commandID, image, 0);

                // Add frame length to image
                EndianOrder.BigEndian.CopyBytes(length, image, 2);

                // Add request ID to image
                EndianOrder.BigEndian.CopyBytes(m_requestID, image, 4);

                // Add encrypted payload to image, if any
                if (m_encryptedData != null)
                    Buffer.BlockCopy(m_encryptedData, 0, image, 20, m_encryptedData.Length);

                // Calculate CRC and add to image
                EndianOrder.BigEndian.CopyBytes(image.CrcCCITTChecksum(0, length - 2), image, length - 2);

                return image;
            }
        }

        /// <summary>
        /// Gets the length of the binary image.
        /// </summary>
        public int BinaryLength
        {
            get
            {
                // If frame length was parsed from stream, use this length
                if (m_frameLength > 0)
                    return m_frameLength;

                // Else calculate frame length
                if (m_payload != null)
                    return FixedLength + m_payload.Length;

                return FixedLength;
            }
        }

        /// <summary>
        /// Gets the <see cref="NASPInet.Packets.CommandPacketType"/> for the <see cref="CommandPacketBase"/>.
        /// </summary>
        public abstract CommandPacketType TypeID { get; }

        /// <summary>
        /// Gets or sets numeric command ID for this <see cref="CommandPacketBase"/>.
        /// </summary>
        /// <remarks>
        /// Derived classes should expose a public enumeration based property representing the same value.
        /// </remarks>
        protected ushort CommandID
        {
            get
            {
                return m_commandID;
            }
            set
            {
                m_commandID = value;
            }
        }

        /// <summary>
        /// Gets or sets current <see cref="CommandPacketHeader"/> associated with this <see cref="CommandPacketBase"/>.
        /// </summary>
        ICommonHeader<CommandPacketType> ISupportFrameImage<CommandPacketType>.CommonHeader
        {
            get
            {
                return m_commonHeader;
            }
            set
            {
                m_commonHeader = value as CommandPacketHeader;

                // Frame length is parsed from command packet header
                if (m_commonHeader != null)
                    m_frameLength = m_commonHeader.FrameLength;
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Initializes the <see cref="CommandPacketBase"/> from the specified <paramref name="binaryImage"/>.
        /// </summary>
        /// <param name="binaryImage">Binary image to be used for initialization.</param>
        /// <param name="startIndex">0-based starting index in the <paramref name="binaryImage"/> to be used for initialization.</param>
        /// <param name="length">Valid number of bytes within binary image.</param>
        /// <returns>The number of bytes used for initialization in the <paramref name="binaryImage"/> (i.e., the number of bytes parsed).</returns>
        public int Initialize(byte[] binaryImage, int startIndex, int length)
        {
            // Validate CRC in binary image
            if (binaryImage.CrcCCITTChecksum(startIndex, m_frameLength - 2) != EndianOrder.BigEndian.ToUInt16(binaryImage, startIndex + m_frameLength - 2))
                throw new InvalidOperationException("CRC check failed for NASPInet " + this.GetType().Name);

            // Extract command ID from image
            m_commandID = EndianOrder.BigEndian.ToUInt16(binaryImage, startIndex);

            // Extract request ID from image (note that frame length was pre-parsed from header)
            m_requestID = EndianOrder.BigEndian.ToGuid(binaryImage, startIndex + 4);

            // Extract encrypted payload from image, if any
            if (m_frameLength > FixedLength)
            {
                int payloadLength = m_frameLength - FixedLength;
                m_encryptedData = binaryImage.BlockCopy(startIndex + 20, payloadLength);
                m_payload = null;
            }

            return m_frameLength;
        }

        /// <summary>
        /// Decrypts the command packet payload.
        /// </summary>
        /// <param name="cryptoProperties"><see cref="CryptoProperties"/> used to decrypt data.</param>
        public void DecryptPayload(CryptoProperties cryptoProperties)
        {
            if (m_encryptedData == null)
                throw new NullReferenceException("No encrypted payload has been parsed from binary image, cannot decrypt data");

            // Decrypt payload
            m_payload = cryptoProperties.Algorithm.Decrypt(m_encryptedData, 0, m_encryptedData.Length, cryptoProperties.Key, cryptoProperties.IV);
        }

        /// <summary>
        /// Encrypts the command packet payload.
        /// </summary>
        /// <param name="cryptoProperties"><see cref="CryptoProperties"/> used to encrypt data.</param>
        public void EncryptPayload(CryptoProperties cryptoProperties)
        {
            if (m_payload == null)
                throw new NullReferenceException("No payload has been assigned to command packet, cannot encrypt data");

            // Encrypt payload
            m_encryptedData = cryptoProperties.Algorithm.Encrypt(m_payload, 0, m_payload.Length, cryptoProperties.Key, cryptoProperties.IV);

            if (m_payload.Length != m_encryptedData.Length)
                throw new InvalidOperationException(string.Format("Encrypted {0} bytes for NASPInet command packet, expected {1}", m_encryptedData.Length, m_payload.Length));
        }

        #endregion
    }
}