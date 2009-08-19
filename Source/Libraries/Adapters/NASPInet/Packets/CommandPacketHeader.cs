//*******************************************************************************************************
//  CommandPacketHeader.cs
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
using TVA.Parsing;

namespace NASPInet.Packets
{
    /// <summary>
    /// Represents the header of <see cref="CommandPacketBase"/> objects.
    /// </summary>
    /// <remarks>
    /// This internal class is used to identify the type of a command packet (i.e., request or response).
    /// </remarks>
    internal class CommandPacketHeader : CommonHeaderBase<CommandPacketType>
    {
        #region [ Members ]

        // Constants

        /// <summary>
        /// Fixed length of <see cref="CommandPacketHeader"/>.
        /// </summary>
        public const int FixedLength = 4;

        // Fields

        /// <summary>
        /// Frame length of command packet.
        /// </summary>
        public ushort FrameLength;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new <see cref="CommandPacketHeader"/> packet.
        /// </summary>
        /// <param name="binaryImage">Binary image to be used for initialization.</param>
        /// <param name="startIndex">0-based starting index in the <paramref name="binaryImage"/> to be used for initialization.</param>
        /// <param name="length">Valid number of bytes within binary image.</param>
        public CommandPacketHeader(byte[] binaryImage, int startIndex, int length)
        {
            // Make sure there is enough data to parse common header
            if (length >= FixedLength)
            {
                // Parse command packet type from first byte in frame
                TypeID = (CommandPacketType)binaryImage[startIndex];

                // Parse frame length starting from third byte in frame
                FrameLength = EndianOrder.BigEndian.ToUInt16(binaryImage, startIndex + 2);
            }
            else
                throw new InvalidOperationException("Malformed image");
        }

        #endregion
    }
}
