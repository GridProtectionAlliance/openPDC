//*******************************************************************************************************
//  IUniversalDuplexCallbackContract.cs
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

using System;
using System.ServiceModel;

namespace PCS.Services.DuplexService
{
    /// <summary>
    /// "Callback" part of Duplex contract: From the Service to Silverlight
    /// </summary>
    [ServiceContract]
    public interface IUniversalDuplexCallbackContract
    {
        //[OperationContract(IsOneWay = true)]
        //void SendToClient(DuplexMessage msg);

        [OperationContract(IsOneWay = true, AsyncPattern = true)]
        IAsyncResult BeginSendToClient(DuplexMessage msg, AsyncCallback acb, object state);
        void EndSendToClient(IAsyncResult iar);
    }
}
