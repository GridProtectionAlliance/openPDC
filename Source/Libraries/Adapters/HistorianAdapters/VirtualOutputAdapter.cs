//*******************************************************************************************************
//  VirtualOutputAdapter.cs
//  Copyright © 2009 - TVA, all rights reserved - Gbtc
//
//  Build Environment: C#, Visual Studio 2008
//  Primary Developer: James R Carroll
//      Office: PSO TRAN & REL, CHATTANOOGA - MR BK-C
//       Phone: 423/751-4165
//       Email: jrcarrol@tva.gov
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  05/04/2009 - James R Carroll
//       Generated original version of source code.
//
//*******************************************************************************************************

using TVA;
using TVA.Measurements;
using TVA.Measurements.Routing;

namespace HistorianAdapters
{
    /// <summary>
    /// Represents a virtual historian ouput adapter used for testing purposes - no data gets archived.
    /// </summary>
    public class VirtualOutputAdapter : OutputAdapterBase
    {
        #region [ Properties ]

        /// <summary>
        /// Returns a flag that determines if measurements sent to this <see cref="VirtualOutputAdapter"/> are
        /// destined for archival.
        /// </summary>
        public override bool OutputIsForArchive
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets flag that determines if this <see cref="VirtualOutputAdapter"/> uses an asynchronous connection.
        /// </summary>
        protected override bool UseAsyncConnect
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Attempts to connect to this <see cref="VirtualOutputAdapter"/>.
        /// </summary>
        protected override void AttemptConnection()
        {
        }

        /// <summary>
        /// Attempts to disconnect from this <see cref="VirtualOutputAdapter"/>.
        /// </summary>
        protected override void AttemptDisconnection()
        {
        }

        /// <summary>
        /// Serializes measurements to data output stream.
        /// </summary>
        protected override void ProcessMeasurements(IMeasurement[] measurements)
        {
        }

        /// <summary>
        /// Gets a short one-line status of this <see cref="VirtualOutputAdapter"/>.
        /// </summary>
        public override string GetShortStatus(int maxLength)
        {
            return "Virtual historian sending data to null...".CenterText(maxLength);
        }

        #endregion
    }
}