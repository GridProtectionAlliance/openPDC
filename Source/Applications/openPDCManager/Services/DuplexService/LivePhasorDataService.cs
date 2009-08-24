//*******************************************************************************************************
//  LivePhasorDataService.cs
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

using System.Threading;
using openPDCManager.Web.Data;

namespace PCS.Services.DuplexService
{   
    /// <summary>
    /// This class actually does all the work for the duplex service. It is being referenced in the .svc file.
    /// </summary>
    public class LivePhasorDataService : DuplexService
    {
        // This timer will be used to retrieve fresh data from the database and then push to all clients.
        Timer liveDataTimer;
        public LivePhasorDataService()
        {
            liveDataTimer = new Timer(new TimerCallback(LivePhasorDataUpdate), null, 0, 10000);            
        }

        void LivePhasorDataUpdate(object obj)
        {
            LivePhasorDataMessage pList = new LivePhasorDataMessage()
            {
                PmuDistributionList = CommonFunctions.GetPmuDistribution(),
                DeviceDistributionList = CommonFunctions.GetVendorDeviceDistribution(),
                InterconnectionStatusList = CommonFunctions.GetInterconnectionStatus()
            };

            // push refreshed data to all the connected clients.
            PushToAllClients(pList);                      
        }
    }
}
