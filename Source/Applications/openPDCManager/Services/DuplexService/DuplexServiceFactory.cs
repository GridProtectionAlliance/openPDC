//*******************************************************************************************************
//  DuplexServiceFactory.cs
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
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace PCS.Services.DuplexService
{
    /// <summary>
    /// Derive from this class to create a duplex Service Factory to use in an .svc file
    /// </summary>
    /// <typeparam name="T">The Duplex Service type (typically derived from DuplexService)</typeparam>
    public abstract class DuplexServiceFactory<T> : ServiceHostFactoryBase
         where T : IUniversalDuplexContract, new()
    {
        T serviceInstance = new T();

        /// <summary>
        /// This method is called by WCF when it needs to construct the service.
        /// Typically this should not be overridden further.
        /// </summary>
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            ServiceHost service = new ServiceHost(serviceInstance, baseAddresses);
            CustomBinding binding = new CustomBinding(
                new PollingDuplexBindingElement(),
                new BinaryMessageEncodingBindingElement(),
                new HttpTransportBindingElement());

            service.Description.Behaviors.Add(new ServiceMetadataBehavior());
            service.AddServiceEndpoint(typeof(IUniversalDuplexContract), binding, "");
            service.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
            return service;
        }
    }
}
