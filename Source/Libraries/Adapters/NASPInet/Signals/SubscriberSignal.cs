//*******************************************************************************************************
//  SubscriberSignal.cs
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

namespace NASPInet.Signals
{
    /// <summary>
    /// Represents a <see cref="SignalBase"/> with needed information for a <see cref="NASPInet.PhasorGateway.Subscriber"/>.
    /// </summary>
    public class SubscriberSignal : SignalBase
    {
        /// <summary>
        /// Creates a new <see cref="SubscriberSignal"/>.
        /// </summary>
        /// <param name="signalID">Signal ID of this <see cref="SubscriberSignal"/>.</param>
        public SubscriberSignal(Guid signalID)
        {
            this.SignalID = signalID;
        }

        /// <summary>
        /// Current even key for decrypting data in this <see cref="SignalBase"/>.
        /// </summary>
        public byte[] EvenKey;

        /// <summary>
        /// Current even initialization vector for decrypting data in this <see cref="SignalBase"/>.
        /// </summary>
        public byte[] EvenIV;

        /// <summary>
        /// Current odd key for decrypting data in this <see cref="SignalBase"/>.
        /// </summary>
        public byte[] OddKey;

        /// <summary>
        /// Current odd initialization vector for decrypting data in this <see cref="SignalBase"/>.
        /// </summary>
        public byte[] OddIV;
    }
}
