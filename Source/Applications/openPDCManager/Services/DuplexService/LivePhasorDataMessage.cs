//*******************************************************************************************************
//  LivePhasorDataMessage.cs
//  Copyright © 2009 - TVA, all rights reserved - Gbtc
//
//  Build Environment: C#, Visual Studio 2008
//  Primary Developer: Mehul P. Thakkar
//      Office: INFO SVCS APP DEV, CHATTANOOGA - MR BK-C
//       Phone: 423/751-7571
//       Email: mpthakka@tva.gov
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  07/05/2009 - Mehul P. Thakkar
//       Generated original version of source code.
//
//*******************************************************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;
using openPDCManager.Web.Data.BusinessObjects;

namespace PCS.Services.DuplexService
{
    /// <summary>
    /// This is the actual message containing live phasor data being sent to all clients connected.
    /// </summary>
    [DataContract]
    public class LivePhasorDataMessage : DuplexMessage
    {
        [DataMember]
        public List<PmuDistribution> PmuDistributionList { get; set; }

        [DataMember]
        public Dictionary<string, int> DeviceDistributionList { get; set; }

        [DataMember]
        public List<InterconnectionStatus> InterconnectionStatusList { get; set; }
    }
}
