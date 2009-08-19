//*******************************************************************************************************
//  PublisherSignal.cs
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
//  07/21/2009 - James R. Carroll
//       Generated original version of source code.
//
//*******************************************************************************************************

using System;
using System.Security.Cryptography;

namespace NASPInet.Signals
{
    /// <summary>
    /// Represents a signal with needed information for a <see cref="NASPInet.PhasorGateway.Publisher"/>.
    /// </summary>
    public class PublisherSignal : SignalBase
    {
        #region [ Members ]

        // Fields

        /// <summary>
        /// Flag that determines if key state is currently even for this <see cref="PublisherSignal"/>.
        /// </summary>
        public bool KeyStateIsEven;

        /// <summary>
        /// Current key for encrypting data in this <see cref="PublisherSignal"/>.
        /// </summary>
        public byte[] Key;

        /// <summary>
        /// Current initialization vector for encrypting data in this <see cref="PublisherSignal"/>.
        /// </summary>
        public byte[] IV;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new <see cref="PublisherSignal"/>.
        /// </summary>
        /// <param name="signalID">Signal ID of this <see cref="PublisherSignal"/>.</param>
        /// <param name="algorithm">Symmetric algorithm to use for key generation.</param>
        public PublisherSignal(Guid signalID, SymmetricAlgorithm algorithm)
        {
            this.SignalID = signalID;

            // Generate initial encryption keys
            GenerateNewKeys(algorithm);
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Generates new encryption keys for this <see cref="PublisherSignal"/>.
        /// </summary>
        /// <param name="algorithm"></param>
        public void GenerateNewKeys(SymmetricAlgorithm algorithm)
        {
            // Define a new key state
            KeyStateIsEven = !KeyStateIsEven;

            // Generate new random keys
            algorithm.GenerateKey();
            algorithm.GenerateIV();

            // Save keys for this signal
            Key = algorithm.Key;
            IV = algorithm.IV;
        }

        #endregion
    }
}
