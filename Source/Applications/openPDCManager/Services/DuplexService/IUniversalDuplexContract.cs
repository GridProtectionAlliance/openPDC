//*******************************************************************************************************
//  IUniversalDuplexContract.cs
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

using System.ServiceModel;

namespace PCS.Services.DuplexService
{
    /// <summary>
    /// "Regular" part of Duplex contract:  From Silverlight to the Service
    /// </summary>
    [ServiceContract(Name = "DuplexService", CallbackContract = typeof(IUniversalDuplexCallbackContract))]
    public interface IUniversalDuplexContract
    {
        [OperationContract(IsOneWay = true)]
        void SendToService(DuplexMessage msg);

    }
}
