//*******************************************************************************************************
//  IRuntimeConfigurationService.cs - Gbtc
//
//  Tennessee Valley Authority, 2009
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  11/25/2009 - Pinal C. Patel
//       Generated original version of source code.
//
//*******************************************************************************************************

using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace openPDCServices
{
    [ServiceContract()]
    public interface IRuntimeConfigurationService
    {
        [OperationContract(),
        WebGet(ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/runtimeconfiguration/{nodeName}")]
        Stream GetConfiguration(string nodeName);
    }
}
