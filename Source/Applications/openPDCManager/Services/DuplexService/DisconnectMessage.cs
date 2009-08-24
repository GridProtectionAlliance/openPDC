//*******************************************************************************************************
//  DisconnectMessage.cs
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
    /// Standard "Disconnect" message - clients must use this message to disconnect
    /// </summary>
    [DataContract(Namespace = "http://samples.microsoft.com/silverlight2/duplex")]
    public class DisconnectMessage : DuplexMessage { }
}
