//*******************************************************************************************************
//  RequestPacket.cs
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
//  07/22/2009 - James R. Carroll
//       Generated original version of source code.
//
//*******************************************************************************************************

using System;
using TVA;

namespace NASPInet.Packets
{
    #region [ Enumerations ]

    /// <summary>
    /// NASPInet request enumeration.
    /// </summary>
    public enum Request : ushort
    {
        /// <summary>
        /// New crypto key assignment.
        /// </summary>
        AssignNewKey = 0xAA01,
        /// <summary>
        /// Cache new identity token.
        /// </summary>
        CacheIDToken = 0xAA02,
        /// <summary>
        /// Subscribe request.
        /// </summary>
        Subscribe = 0xAA03,
        /// <summary>
        /// Browse request.
        /// </summary>
        Browse = 0xAA04
    }

    #endregion

    /// <summary>
    /// Represents a NASPInet request packet.
    /// </summary>
    public class RequestPacket : CommandPacketBase
    {
        #region [ Properties ]

        /// <summary>
        /// Gets or sets <see cref="NASPInet.Packets.Request"/> value of this <see cref="RequestPacket"/>.
        /// </summary>
        public Request Request
        {
            get
            {
                return (Request)CommandID;
            }
            set
            {
                CommandID = (ushort)value;
            }
        }

        /// <summary>
        /// Gets <see cref="NASPInet.Packets.CommandPacketType"/> for a <see cref="RequestPacket"/>.
        /// </summary>
        public override CommandPacketType TypeID
        {
            get
            {
                return CommandPacketType.Request;
            }
        }

        #endregion

        #region [ Static ]

        // Static Methods

        /// <summary>
        /// Generates a binary payload for a <see cref="NASPInet.Packets.Request.AssignNewKey"/>.
        /// </summary>
        /// <param name="key">The secret key to use for the symmetric algorithm.</param>
        /// <param name="iv">The initialization vector to use for the symmetric algorithm.</param>
        /// <returns>Image of new key information.</returns>
        public static byte[] GenerateAssignNewKeyPayload(byte[] key, byte[] iv)
        {
            int index = 0, length = 8 + key.Length + iv.Length;
            byte[] image = new byte[length];

            // Add length of key buffer
            EndianOrder.BigEndian.CopyBytes(key.Length, image, index);
            index += 4;

            // Add key buffer
            Buffer.BlockCopy(key, 0, image, index, key.Length);
            index += key.Length;

            // Add length of IV buffer
            EndianOrder.BigEndian.CopyBytes(iv.Length, image, index);
            index += 4;

            // Add IV buffer
            Buffer.BlockCopy(iv, 0, image, index, iv.Length);

            return image;
        }

        /// <summary>
        /// Parses a binary payload for a <see cref="NASPInet.Packets.Request.AssignNewKey"/>.
        /// </summary>
        /// <param name="payload">Binary payload to parse.</param>
        /// <param name="key">The secret key to use for the symmetric algorithm.</param>
        /// <param name="iv">The initialization vector to use for the symmetric algorithm.</param>
        public static void ParseAssignNewKeyPayload(byte[] payload, out byte[] key, out byte[] iv)
        {
            int index = 0, length;

            // Parse length of key buffer
            length = EndianOrder.BigEndian.ToInt32(payload, index);
            index += 4;

            // Initialize and parse key buffer
            key = new byte[length];
            Buffer.BlockCopy(payload, index, key, 0, length);
            index += length;

            // Parse length of IV buffer
            length = EndianOrder.BigEndian.ToInt32(payload, index);
            index += 4;

            // Initialize and parse IV buffer
            iv = new byte[length];
            Buffer.BlockCopy(payload, index, iv, 0, length);
        }
        
        /// <summary>
        /// Generates a binary payload for a <see cref="NASPInet.Packets.Request.AssignNewKey"/> that includes key state.
        /// </summary>
        /// <param name="keyStateIsEven">Flag that determines if ket state is even.</param>
        /// <param name="key">The secret key to use for the symmetric algorithm.</param>
        /// <param name="iv">The initialization vector to use for the symmetric algorithm.</param>
        /// <returns>Image of new key information that includes key state.</returns>
        public static byte[] GenerateAssignNewKeyPayload(bool keyStateIsEven, byte[] key, byte[] iv)
        {
            int length = 9 + key.Length + iv.Length;
            byte[] image = new byte[length];            

            // Add key state flag
            image[0] = EndianOrder.BigEndian.GetBytes(keyStateIsEven)[0];

            // Add standard key payload to buffer
            Buffer.BlockCopy(GenerateAssignNewKeyPayload(key, iv), 0, image, 1, length - 1);

            return image;
        }

        /// <summary>
        /// Parses a binary payload for a <see cref="NASPInet.Packets.Request.AssignNewKey"/> that includes key state.
        /// </summary>
        /// <param name="payload">Binary payload to parse.</param>
        /// <param name="keyStateIsEven">Flag that determines if ket state is even.</param>
        /// <param name="key">The secret key to use for the symmetric algorithm.</param>
        /// <param name="iv">The initialization vector to use for the symmetric algorithm.</param>
        public static void ParseAssignNewKeyPayload(byte[] payload, out bool keyStateIsEven, out byte[] key, out byte[] iv)
        {
            // Parse key state flag
            keyStateIsEven = EndianOrder.BigEndian.ToBoolean(payload, 0);

            // Parse standard key payload from buffer
            ParseAssignNewKeyPayload(payload.BlockCopy(1, payload.Length - 1), out key, out iv);
        }

        #endregion
    }
}
