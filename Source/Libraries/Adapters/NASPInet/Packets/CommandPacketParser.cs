//*******************************************************************************************************
//  CommandPacketParser.cs
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
using System.Collections.Generic;
using TVA.Parsing;

namespace NASPInet.Packets
{
    /// <summary>
    /// Represents a frame parser for a stream of NASPInet <see cref="CommandPacketBase"/> objects that returns parsed data via events.
    /// </summary>
    /// <remarks>
    /// Frame parser is implemented as a write-only stream - this way data can come from any source.
    /// </remarks>
    public class CommandPacketParser : MultiSourceFrameImageParserBase<Guid, CommandPacketType, CommandPacketBase>
    {
        #region [ Members ]

        // Fields
        private Dictionary<Guid, CryptoProperties> m_cryptoProperties;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new <see cref="CommandPacketParser"/>.
        /// </summary>
        public CommandPacketParser()
        {
            m_cryptoProperties = new Dictionary<Guid, CryptoProperties>();
        }

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

        public bool TryGetCryptoProperties(Guid sourceID, out CryptoProperties cryptoProperties)
        {
            lock (m_cryptoProperties)
            {
                return m_cryptoProperties.TryGetValue(sourceID, out cryptoProperties);
            }
        }

        /// <summary>
        /// Start the command packet parser.
        /// </summary>
        public override void Start()
        {
            // We narrow down parsing types to just those needed...
            base.Start(new Type[] { typeof(RequestPacket), typeof(ResponsePacket) });
        }

        /// <summary>
        /// Clears the internal buffer of unparsed data received from the specified <paramref name="source"/>.
        /// </summary>
        /// <param name="source">ID of the data source.</param>
        public override void PurgeBuffer(Guid source)
        {
            // Clear parsing buffer for this source, if any
            base.PurgeBuffer(source);

            // We also need to purge crypto properties we are tracking for this source
            m_cryptoProperties.Remove(source);
        }

        /// <summary>
        /// Parses a common header instance that implements <see cref="ICommonHeader{TTypeIdentifier}"/> for the output type represented
        /// in the binary image.
        /// </summary>
        /// <param name="buffer">Buffer containing data to parse.</param>
        /// <param name="offset">Offset index into buffer that represents where to start parsing.</param>
        /// <param name="length">Maximum length of valid data from offset.</param>
        /// <returns>The <see cref="ICommonHeader{TTypeIdentifier}"/> which includes a type ID for the <see cref="Type"/> to be parsed.</returns>
        protected override ICommonHeader<CommandPacketType> ParseCommonHeader(byte[] buffer, int offset, int length)
        {
            // Make sure there enough data to parse command header
            if (length >= CommandPacketHeader.FixedLength)
            {
                // Parse common header from data stream
                CommandPacketHeader parsedHeader = new CommandPacketHeader(buffer, offset, length);
                
                // Make sure there is enough data in the buffer to parse entire command packet
                if (length >= parsedHeader.FrameLength)
                    return parsedHeader;
            }

            return null;
        }

        /// <summary>
        /// Raises the <see cref="MultiSourceFrameImageParserBase{TSourceIdentifier, TTypeIdentifier, TOutputType}.DataParsed"/> event.
        /// </summary>
        /// <param name="sourceID">Data source ID.</param>
        /// <param name="parsedData">List of parsed events.</param>
        protected override void OnDataParsed(Guid sourceID, List<CommandPacketBase> parsedData)
        {
            CryptoProperties cryptoProperties;

            // Get current crypto properties for source
            if (!m_cryptoProperties.TryGetValue(sourceID, out cryptoProperties))
            {
                cryptoProperties = new CryptoProperties();
                m_cryptoProperties.Add(sourceID, cryptoProperties);
            }

            // Decrypt packet payloads
            if (cryptoProperties.AreDefined)
            {
                foreach (CommandPacketBase packet in parsedData)
                {
                    if (packet.Payload != null)
                        packet.DecryptPayload(cryptoProperties);
                }
            }

            base.OnDataParsed(sourceID, parsedData);
        }

        #endregion
    }
}
