//*******************************************************************************************************
//  DuplexMessage.cs
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
    /// Base message class. Please add [KnownType] attributes as necessary for every 
    /// derived message type.
    /// </summary>
    [DataContract(Namespace = "http://samples.microsoft.com/silverlight2/duplex")]
    [KnownType(typeof(ConnectMessage))]
    [KnownType(typeof(DisconnectMessage))]
    [KnownType(typeof(LivePhasorDataMessage))]
    public class DuplexMessage { }
}
