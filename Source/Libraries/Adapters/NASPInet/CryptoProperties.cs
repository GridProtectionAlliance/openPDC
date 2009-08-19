//*******************************************************************************************************
//  CryptoProperties.cs
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
//  07/27/2009 - James R. Carroll
//       Generated original version of source code.
//
//*******************************************************************************************************

using System.Security.Cryptography;

namespace NASPInet
{
    /// <summary>
    /// Represents a set of cryptographic properties that can be used to encrypt or decrypt data.
    /// </summary>
    public struct CryptoProperties
    {
        /// <summary>
        /// <see cref="SymmetricAlgorithm"/> used to encrypt or decrypt data.
        /// </summary>
        public SymmetricAlgorithm Algorithm;

        /// <summary>
        /// The secret key to use for encrypting or decrypting data using the symmetric algorithm.
        /// </summary>
        public byte[] Key;
        
        /// <summary>
        /// The initialization vector to use for encrypting or decrypting data using the symmetric algorithm.
        /// </summary>
        public byte[] IV;

        /// <summary>
        /// Gets flag that determines if the crytographic properties are defined.
        /// </summary>
        public bool AreDefined
        {
            get
            {
                return (Algorithm != null && Key != null && IV != null);
            }
        }
    }
}
