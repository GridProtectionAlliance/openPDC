//*******************************************************************************************************
//  DataPacketParser.cs
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
using TVA.Parsing;

namespace NASPInet.Packets
{
    /// <summary>
    /// Represents a frame parser for a stream of NASPInet <see cref="DataPacket"/> objects that returns parsed data via events.
    /// </summary>
    /// <remarks>
    /// Frame parser is implemented as a write-only stream - this way data can come from any source.
    /// </remarks>
    public class DataPacketParser : FrameImageParserBase<int, DataPacket>
    {        
        #region [ Members ]

        // Nested Types

        // NASPInet data packet is the only frame type for this streaming protocol...
        private class CommonHeader : CommonHeaderBase<int> {}

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets flag that determines if NASPInet <see cref="DataPacket"/> protocol parsing implementation uses synchronization bytes.
        /// </summary>
        public override bool ProtocolUsesSyncBytes
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Start the data packet parser.
        /// </summary>
        public override void Start()
        {
            // We narrow down parsing types to just those needed...
            base.Start(new Type[] { typeof(DataPacket) });
        }

        /// <summary>
        /// Parses a common header instance that implements <see cref="ICommonHeader{TTypeIdentifier}"/> for the output type represented
        /// in the binary image.
        /// </summary>
        /// <param name="buffer">Buffer containing data to parse.</param>
        /// <param name="offset">Offset index into buffer that represents where to start parsing.</param>
        /// <param name="length">Maximum length of valid data from offset.</param>
        /// <returns>The <see cref="ICommonHeader{TTypeIdentifier}"/> which includes a type ID for the <see cref="Type"/> to be parsed.</returns>
        protected override ICommonHeader<int> ParseCommonHeader(byte[] buffer, int offset, int length)
        {
            // Make sure there is at least one frame of data in the buffer
            if (length >= DataPacket.FixedLength)
                return new CommonHeader();

            return null;
        }

        #endregion
    }
}