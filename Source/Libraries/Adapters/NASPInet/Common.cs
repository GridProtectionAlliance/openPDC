//*******************************************************************************************************
//  Common.cs
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
//  07/24/2009 - James R. Carroll
//       Generated original version of source code.
//
//*******************************************************************************************************

using System.Security.Cryptography;

namespace NASPInet
{
    /// <summary>
    /// Defines common functions related to all of NASPInet.
    /// </summary>
    public static class Common
    {
        /// <summary>
        /// Returns the <see cref="System.Security.Cryptography.SymmetricAlgorithm"/> used by NASPInet.
        /// </summary>
        public static SymmetricAlgorithm SymmetricAlgorithm
        {
            get
            {
                // Using the Advanced Encryption Standard (AES) symmetric algorithm until specification states otherwise
                return new AesManaged();
            }
        }
    }
}
