//******************************************************************************************************
//  SilverlightFaultBehavior.cs - Gbtc
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
//  12/18/2009 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace openPDCManager.Data
{
	public class SilverlightFaultBehavior : BehaviorExtensionElement, IEndpointBehavior
	{

		public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
		{
			SilverlightFaultMessageInspector inspector = new SilverlightFaultMessageInspector();
			endpointDispatcher.DispatchRuntime.MessageInspectors.Add(inspector);
		}

		public class SilverlightFaultMessageInspector : IDispatchMessageInspector
		{

			public void BeforeSendReply(ref Message reply, object correlationState)
			{
				if (reply.IsFault)
				{
					HttpResponseMessageProperty property = new HttpResponseMessageProperty();
					// Here the response code is changed to 200.
					property.StatusCode = System.Net.HttpStatusCode.OK;
					reply.Properties[HttpResponseMessageProperty.Name] = property;
				}
			}

			public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
			{
				// Do nothing to the incoming message.
				return null;
			}

		}

		// The following methods are stubs and not relevant. 
		public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
		{
		}

		public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
		{
		}

		public void Validate(ServiceEndpoint endpoint)
		{
		}

		public override System.Type BehaviorType
		{
			get { return typeof(SilverlightFaultBehavior); }
		}

		protected override object CreateBehavior()
		{
			return new SilverlightFaultBehavior();
		}

	}
}
