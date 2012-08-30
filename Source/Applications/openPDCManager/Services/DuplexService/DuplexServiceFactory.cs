//******************************************************************************************************
//  DuplexServiceFactory.cs - Gbtc
//
//  Copyright © 2010, Grid Protection Alliance.  All Rights Reserved.
//
//  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
//  the NOTICE file distributed with this work for additional information regarding copyright ownership.
//  The GPA licenses this file to you under the Eclipse Public License -v 1.0 (the "License"); you may
//  not use this file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://www.opensource.org/licenses/eclipse-1.0.php
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  07/05/2009 - Mehulbhai Thakkar
//       Generated original version of source code.
//  09/15/2009 - Stephen C. Wills
//       Added new header and license agreement.
//
//******************************************************************************************************

using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace openPDCManager.Services.DuplexService
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
