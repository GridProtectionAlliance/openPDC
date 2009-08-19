//*******************************************************************************************************
//  SignalBase.cs
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
using TVA.Measurements;

namespace NASPInet.Signals
{
    /// <summary>
    /// Represents a signal base class with common information used by all signal classes.
    /// </summary>
    public abstract class SignalBase
    {
        #region [ Members ]

        // Fields

        /// <summary>
        /// Registered public signal ID for this <see cref="SignalBase"/>.
        /// </summary>
        public Guid SignalID;

        /// <summary>
        /// Internal use key of measurement associated with this <see cref="SignalBase"/>.
        /// </summary>
        public MeasurementKey MeasurementKey;

        #endregion
    }
}