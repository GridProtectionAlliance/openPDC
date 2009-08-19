//*******************************************************************************************************
//  ResponsePacket.cs
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

namespace NASPInet.Packets
{
    #region [ Enumerations ]

    /// <summary>
    /// NASPInet response enumeration.
    /// </summary>
    public enum Response : ushort
    {
        /// <summary>
        /// Success response.
        /// </summary>
        Success = 0xBB01,
        /// <summary>
        /// Fail response.
        /// </summary>
        Fail = 0xBB02
    }

    #endregion

    /// <summary>
    /// Represents a NASPInet response packet.
    /// </summary>
    public class ResponsePacket : CommandPacketBase
    {
        #region [ Properties ]

        /// <summary>
        /// Gets or sets <see cref="NASPInet.Packets.Response"/> value of this <see cref="ResponsePacket"/>.
        /// </summary>
        public Response Response
        {
            get
            {
                return (Response)CommandID;
            }
            set
            {
                CommandID = (ushort)value;
            }
        }

        /// <summary>
        /// Gets <see cref="NASPInet.Packets.CommandPacketType"/> for a <see cref="ResponsePacket"/>.
        /// </summary>
        public override CommandPacketType TypeID
        {
            get
            {
                return CommandPacketType.Response;
            }
        }

        #endregion
    }
}
