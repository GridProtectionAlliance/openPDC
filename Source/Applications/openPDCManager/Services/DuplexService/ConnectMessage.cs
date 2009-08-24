//*******************************************************************************************************
//  ConnectMessage.cs
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

using System.Runtime.Serialization;

namespace PCS.Services.DuplexService
{
    /// <summary>
    /// Standard "Connect" message - clients may use this message to connect, when no other payload is required
    /// </summary>
    [DataContract(Namespace = "http://samples.microsoft.com/silverlight2/duplex")]
    public class ConnectMessage : DuplexMessage { }
}
