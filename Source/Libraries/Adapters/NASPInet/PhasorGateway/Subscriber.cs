//*******************************************************************************************************
//  Subscriber.cs
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
using TVA.Measurements.Routing;

namespace NASPInet.PhasorGateway
{
    /// <summary>
    /// Represents the subscriber component of a NASPInet phasor gateway.
    /// </summary>
    public class Subscriber : InputAdapterBase
    {
        #region [ Members ]

        // Nested Types

        // Constants

        // Delegates

        // Events

        // Fields

        #endregion

        #region [ Constructors ]

        #endregion

        #region [ Properties ]

        protected override bool UseAsyncConnect
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #region [ Methods ]

        protected override void AttemptConnection()
        {
            throw new NotImplementedException();
        }

        protected override void AttemptDisconnection()
        {
            throw new NotImplementedException();
        }

        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        public override string GetShortStatus(int maxLength)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region [ Operators ]

        #endregion

        #region [ Static ]

        // Static Fields

        // Static Constructor

        // Static Properties

        // Static Methods

        #endregion
    }
}
