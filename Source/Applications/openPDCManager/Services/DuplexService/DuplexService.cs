//*******************************************************************************************************
//  DuplexService.cs - Gbtc
//
//  Tennessee Valley Authority, 2009
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  This software is made freely available under the TVA Open Source Agreement (see below).
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  07/05/2009 - Mehulbhai Thakkar
//       Generated original version of source code.
//  09/15/2009 - Stephen C. Wills
//       Added new header and license agreement.
//  03/02/2010 - Pinal C. Patel
//       Implemented IDisposable interface and added code regions.
//
//*******************************************************************************************************

#region [ TVA Open Source Agreement ]
/*

 THIS OPEN SOURCE AGREEMENT ("AGREEMENT") DEFINES THE RIGHTS OF USE,REPRODUCTION, DISTRIBUTION,
 MODIFICATION AND REDISTRIBUTION OF CERTAIN COMPUTER SOFTWARE ORIGINALLY RELEASED BY THE
 TENNESSEE VALLEY AUTHORITY, A CORPORATE AGENCY AND INSTRUMENTALITY OF THE UNITED STATES GOVERNMENT
 ("GOVERNMENT AGENCY"). GOVERNMENT AGENCY IS AN INTENDED THIRD-PARTY BENEFICIARY OF ALL SUBSEQUENT
 DISTRIBUTIONS OR REDISTRIBUTIONS OF THE SUBJECT SOFTWARE. ANYONE WHO USES, REPRODUCES, DISTRIBUTES,
 MODIFIES OR REDISTRIBUTES THE SUBJECT SOFTWARE, AS DEFINED HEREIN, OR ANY PART THEREOF, IS, BY THAT
 ACTION, ACCEPTING IN FULL THE RESPONSIBILITIES AND OBLIGATIONS CONTAINED IN THIS AGREEMENT.

 Original Software Designation: openPDC
 Original Software Title: The TVA Open Source Phasor Data Concentrator
 User Registration Requested. Please Visit https://naspi.tva.com/Registration/
 Point of Contact for Original Software: J. Ritchie Carroll <mailto:jrcarrol@tva.gov>

 1. DEFINITIONS

 A. "Contributor" means Government Agency, as the developer of the Original Software, and any entity
 that makes a Modification.

 B. "Covered Patents" mean patent claims licensable by a Contributor that are necessarily infringed by
 the use or sale of its Modification alone or when combined with the Subject Software.

 C. "Display" means the showing of a copy of the Subject Software, either directly or by means of an
 image, or any other device.

 D. "Distribution" means conveyance or transfer of the Subject Software, regardless of means, to
 another.

 E. "Larger Work" means computer software that combines Subject Software, or portions thereof, with
 software separate from the Subject Software that is not governed by the terms of this Agreement.

 F. "Modification" means any alteration of, including addition to or deletion from, the substance or
 structure of either the Original Software or Subject Software, and includes derivative works, as that
 term is defined in the Copyright Statute, 17 USC § 101. However, the act of including Subject Software
 as part of a Larger Work does not in and of itself constitute a Modification.

 G. "Original Software" means the computer software first released under this Agreement by Government
 Agency entitled openPDC, including source code, object code and accompanying documentation, if any.

 H. "Recipient" means anyone who acquires the Subject Software under this Agreement, including all
 Contributors.

 I. "Redistribution" means Distribution of the Subject Software after a Modification has been made.

 J. "Reproduction" means the making of a counterpart, image or copy of the Subject Software.

 K. "Sale" means the exchange of the Subject Software for money or equivalent value.

 L. "Subject Software" means the Original Software, Modifications, or any respective parts thereof.

 M. "Use" means the application or employment of the Subject Software for any purpose.

 2. GRANT OF RIGHTS

 A. Under Non-Patent Rights: Subject to the terms and conditions of this Agreement, each Contributor,
 with respect to its own contribution to the Subject Software, hereby grants to each Recipient a
 non-exclusive, world-wide, royalty-free license to engage in the following activities pertaining to
 the Subject Software:

 1. Use

 2. Distribution

 3. Reproduction

 4. Modification

 5. Redistribution

 6. Display

 B. Under Patent Rights: Subject to the terms and conditions of this Agreement, each Contributor, with
 respect to its own contribution to the Subject Software, hereby grants to each Recipient under Covered
 Patents a non-exclusive, world-wide, royalty-free license to engage in the following activities
 pertaining to the Subject Software:

 1. Use

 2. Distribution

 3. Reproduction

 4. Sale

 5. Offer for Sale

 C. The rights granted under Paragraph B. also apply to the combination of a Contributor's Modification
 and the Subject Software if, at the time the Modification is added by the Contributor, the addition of
 such Modification causes the combination to be covered by the Covered Patents. It does not apply to
 any other combinations that include a Modification. 

 D. The rights granted in Paragraphs A. and B. allow the Recipient to sublicense those same rights.
 Such sublicense must be under the same terms and conditions of this Agreement.

 3. OBLIGATIONS OF RECIPIENT

 A. Distribution or Redistribution of the Subject Software must be made under this Agreement except for
 additions covered under paragraph 3H. 

 1. Whenever a Recipient distributes or redistributes the Subject Software, a copy of this Agreement
 must be included with each copy of the Subject Software; and

 2. If Recipient distributes or redistributes the Subject Software in any form other than source code,
 Recipient must also make the source code freely available, and must provide with each copy of the
 Subject Software information on how to obtain the source code in a reasonable manner on or through a
 medium customarily used for software exchange.

 B. Each Recipient must ensure that the following copyright notice appears prominently in the Subject
 Software:

          No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.

 C. Each Contributor must characterize its alteration of the Subject Software as a Modification and
 must identify itself as the originator of its Modification in a manner that reasonably allows
 subsequent Recipients to identify the originator of the Modification. In fulfillment of these
 requirements, Contributor must include a file (e.g., a change log file) that describes the alterations
 made and the date of the alterations, identifies Contributor as originator of the alterations, and
 consents to characterization of the alterations as a Modification, for example, by including a
 statement that the Modification is derived, directly or indirectly, from Original Software provided by
 Government Agency. Once consent is granted, it may not thereafter be revoked.

 D. A Contributor may add its own copyright notice to the Subject Software. Once a copyright notice has
 been added to the Subject Software, a Recipient may not remove it without the express permission of
 the Contributor who added the notice.

 E. A Recipient may not make any representation in the Subject Software or in any promotional,
 advertising or other material that may be construed as an endorsement by Government Agency or by any
 prior Recipient of any product or service provided by Recipient, or that may seek to obtain commercial
 advantage by the fact of Government Agency's or a prior Recipient's participation in this Agreement.

 F. In an effort to track usage and maintain accurate records of the Subject Software, each Recipient,
 upon receipt of the Subject Software, is requested to register with Government Agency by visiting the
 following website: https://naspi.tva.com/Registration/. Recipient's name and personal information
 shall be used for statistical purposes only. Once a Recipient makes a Modification available, it is
 requested that the Recipient inform Government Agency at the web site provided above how to access the
 Modification.

 G. Each Contributor represents that that its Modification does not violate any existing agreements,
 regulations, statutes or rules, and further that Contributor has sufficient rights to grant the rights
 conveyed by this Agreement.

 H. A Recipient may choose to offer, and to charge a fee for, warranty, support, indemnity and/or
 liability obligations to one or more other Recipients of the Subject Software. A Recipient may do so,
 however, only on its own behalf and not on behalf of Government Agency or any other Recipient. Such a
 Recipient must make it absolutely clear that any such warranty, support, indemnity and/or liability
 obligation is offered by that Recipient alone. Further, such Recipient agrees to indemnify Government
 Agency and every other Recipient for any liability incurred by them as a result of warranty, support,
 indemnity and/or liability offered by such Recipient.

 I. A Recipient may create a Larger Work by combining Subject Software with separate software not
 governed by the terms of this agreement and distribute the Larger Work as a single product. In such
 case, the Recipient must make sure Subject Software, or portions thereof, included in the Larger Work
 is subject to this Agreement.

 J. Notwithstanding any provisions contained herein, Recipient is hereby put on notice that export of
 any goods or technical data from the United States may require some form of export license from the
 U.S. Government. Failure to obtain necessary export licenses may result in criminal liability under
 U.S. laws. Government Agency neither represents that a license shall not be required nor that, if
 required, it shall be issued. Nothing granted herein provides any such export license.

 4. DISCLAIMER OF WARRANTIES AND LIABILITIES; WAIVER AND INDEMNIFICATION

 A. No Warranty: THE SUBJECT SOFTWARE IS PROVIDED "AS IS" WITHOUT ANY WARRANTY OF ANY KIND, EITHER
 EXPRESSED, IMPLIED, OR STATUTORY, INCLUDING, BUT NOT LIMITED TO, ANY WARRANTY THAT THE SUBJECT
 SOFTWARE WILL CONFORM TO SPECIFICATIONS, ANY IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
 PARTICULAR PURPOSE, OR FREEDOM FROM INFRINGEMENT, ANY WARRANTY THAT THE SUBJECT SOFTWARE WILL BE ERROR
 FREE, OR ANY WARRANTY THAT DOCUMENTATION, IF PROVIDED, WILL CONFORM TO THE SUBJECT SOFTWARE. THIS
 AGREEMENT DOES NOT, IN ANY MANNER, CONSTITUTE AN ENDORSEMENT BY GOVERNMENT AGENCY OR ANY PRIOR
 RECIPIENT OF ANY RESULTS, RESULTING DESIGNS, HARDWARE, SOFTWARE PRODUCTS OR ANY OTHER APPLICATIONS
 RESULTING FROM USE OF THE SUBJECT SOFTWARE. FURTHER, GOVERNMENT AGENCY DISCLAIMS ALL WARRANTIES AND
 LIABILITIES REGARDING THIRD-PARTY SOFTWARE, IF PRESENT IN THE ORIGINAL SOFTWARE, AND DISTRIBUTES IT
 "AS IS."

 B. Waiver and Indemnity: RECIPIENT AGREES TO WAIVE ANY AND ALL CLAIMS AGAINST GOVERNMENT AGENCY, ITS
 AGENTS, EMPLOYEES, CONTRACTORS AND SUBCONTRACTORS, AS WELL AS ANY PRIOR RECIPIENT. IF RECIPIENT'S USE
 OF THE SUBJECT SOFTWARE RESULTS IN ANY LIABILITIES, DEMANDS, DAMAGES, EXPENSES OR LOSSES ARISING FROM
 SUCH USE, INCLUDING ANY DAMAGES FROM PRODUCTS BASED ON, OR RESULTING FROM, RECIPIENT'S USE OF THE
 SUBJECT SOFTWARE, RECIPIENT SHALL INDEMNIFY AND HOLD HARMLESS  GOVERNMENT AGENCY, ITS AGENTS,
 EMPLOYEES, CONTRACTORS AND SUBCONTRACTORS, AS WELL AS ANY PRIOR RECIPIENT, TO THE EXTENT PERMITTED BY
 LAW.  THE FOREGOING RELEASE AND INDEMNIFICATION SHALL APPLY EVEN IF THE LIABILITIES, DEMANDS, DAMAGES,
 EXPENSES OR LOSSES ARE CAUSED, OCCASIONED, OR CONTRIBUTED TO BY THE NEGLIGENCE, SOLE OR CONCURRENT, OF
 GOVERNMENT AGENCY OR ANY PRIOR RECIPIENT.  RECIPIENT'S SOLE REMEDY FOR ANY SUCH MATTER SHALL BE THE
 IMMEDIATE, UNILATERAL TERMINATION OF THIS AGREEMENT.

 5. GENERAL TERMS

 A. Termination: This Agreement and the rights granted hereunder will terminate automatically if a
 Recipient fails to comply with these terms and conditions, and fails to cure such noncompliance within
 thirty (30) days of becoming aware of such noncompliance. Upon termination, a Recipient agrees to
 immediately cease use and distribution of the Subject Software. All sublicenses to the Subject
 Software properly granted by the breaching Recipient shall survive any such termination of this
 Agreement.

 B. Severability: If any provision of this Agreement is invalid or unenforceable under applicable law,
 it shall not affect the validity or enforceability of the remainder of the terms of this Agreement.

 C. Applicable Law: This Agreement shall be subject to United States federal law only for all purposes,
 including, but not limited to, determining the validity of this Agreement, the meaning of its
 provisions and the rights, obligations and remedies of the parties.

 D. Entire Understanding: This Agreement constitutes the entire understanding and agreement of the
 parties relating to release of the Subject Software and may not be superseded, modified or amended
 except by further written agreement duly executed by the parties.

 E. Binding Authority: By accepting and using the Subject Software under this Agreement, a Recipient
 affirms its authority to bind the Recipient to all terms and conditions of this Agreement and that
 Recipient hereby agrees to all terms and conditions herein.

 F. Point of Contact: Any Recipient contact with Government Agency is to be directed to the designated
 representative as follows: J. Ritchie Carroll <mailto:jrcarrol@tva.gov>.

*/
#endregion

using System;
using System.Collections.Generic;
using System.ServiceModel;
using openPDCManager.Web.Data;
using openPDCManager.Web.Data.Entities;
using System.Collections;
using openPDCManager.Web.Data.ServiceCommunication;

namespace openPDCManager.Services.DuplexService
{
    #region [ Enumerations ]

    public enum MessageType
    {
        LivePhasorDataMessage,
        TimeSeriesDataMessage,
        ServiceStatusMessage,
		TimeTaggedDataMessage
    }

    public enum DisplayType
    {
        Home,
        ServiceClient,
		DeviceMeasurements
    }

    #endregion

    /// <summary>
    /// Derive your own Duplex service from this class
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, AddressFilterMode = AddressFilterMode.Any)]
    public abstract class DuplexService : IUniversalDuplexContract
    {
        #region [ Members ]

        // Nested Types

        /// <summary>
        /// Helper class for tracking both a channel and its session ID together
        /// </summary>
        private class PushMessageState
        {
            public IUniversalDuplexCallbackContract Channel;
            public string SessionId;
            public PushMessageState(IUniversalDuplexCallbackContract channel, string session)
            {
                Channel = channel;
                SessionId = session;
            }
        }

        // Fields
        object syncRoot = new object();
        Dictionary<string, Client> clients;        
		protected Dictionary<string, WindowsServiceClient> serviceClientList;
        //Will maintain data for each node in a dictionary to serve to any number of clients. This would eliminate database hit for each client.
        Dictionary<string, LivePhasorDataMessage> dataPerNode;	//stores vendor device distribution and interconnectionstatus per node.
		Dictionary<string, TimeTaggedDataMessage> timeTaggedMeasurementsPerNode;	//stores current time series data for all the measurements per node.
		Dictionary<string, KeyValuePair<int, int>> minMaxPointIDsPerNode;	//stores min and max values of point id in measurement table per node.
        private bool m_disposed;

        #endregion

        #region [ Constructors ]

        public DuplexService()
        {
            clients = new Dictionary<string, Client>();            
            dataPerNode = new Dictionary<string, LivePhasorDataMessage>();
			timeTaggedMeasurementsPerNode = new Dictionary<string, TimeTaggedDataMessage>();
			minMaxPointIDsPerNode = new Dictionary<string, KeyValuePair<int, int>>();
        }

        /// <summary>
        /// Releases the unmanaged resources before the <see cref="DuplexService"/> object is reclaimed by <see cref="GC"/>.
        /// </summary>
        ~DuplexService()
        {
            Dispose(false);
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Releases all the resources used by the <see cref="DuplexService"/> object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SendToService(DuplexMessage msg)
        {
            //We get here when we receive a message from a client
            IUniversalDuplexCallbackContract ch = OperationContext.Current.GetCallbackChannel<IUniversalDuplexCallbackContract>();
            string session = OperationContext.Current.Channel.SessionId;

            if (msg is ConnectMessage)
            {
                //lock (syncRoot)
				lock (clients)
                {
                    if (!clients.ContainsKey(session))	// new client
                    {
						System.Diagnostics.Debug.WriteLine("New client connected: ");
						System.Diagnostics.Debug.WriteLine("          " + (msg as ConnectMessage).NodeID);
						System.Diagnostics.Debug.WriteLine("          " + (msg as ConnectMessage).TimeSeriesDataRootUrl);
						System.Diagnostics.Debug.WriteLine("          " + (msg as ConnectMessage).CurrentDisplayType.ToString());
                        Client client = new Client();
                        client.Channel = ch;
                        client.NodeID = (msg as ConnectMessage).NodeID;
                        client.TimeSeriesDataRootUrl = (msg as ConnectMessage).TimeSeriesDataRootUrl;
                        client.DataPointID = (msg as ConnectMessage).DataPointID;
						client.CurrentDisplayType = (msg as ConnectMessage).CurrentDisplayType;
                        clients.Add(session, client);
                        OperationContext.Current.Channel.Closing += Channel_Closing;
                        OperationContext.Current.Channel.Faulted += Channel_Faulted;
                        OnConnected(session);
                    }
                    else	//existing connected client. Just trying to update its settings.
                    {
                        clients[session] = new Client()
                        {
                            Channel = ch,
                            NodeID = (msg as ConnectMessage).NodeID,
                            DataPointID = (msg as ConnectMessage).DataPointID,
                            TimeSeriesDataRootUrl = (msg as ConnectMessage).TimeSeriesDataRootUrl,
							CurrentDisplayType = (msg as ConnectMessage).CurrentDisplayType
                        };
                    }
                }

                Client currentClient = clients[session];
				// Initially when client is connected, we will send them data only if client is connected from home page of the openPDCManager.
				if (currentClient.CurrentDisplayType == DisplayType.Home)
				{
					PushMessageToClient(session, new LivePhasorDataMessage()
											{
												//PmuDistributionList = CommonFunctions.GetPmuDistribution(),
												DeviceDistributionList = CommonFunctions.GetVendorDeviceDistribution(currentClient.NodeID),
												InterconnectionStatusList = CommonFunctions.GetInterconnectionStatus(currentClient.NodeID)
											}
										);

					PushMessageToClient(session, new TimeSeriesDataMessage()
												{
													TimeSeriesData = CommonFunctions.GetTimeSeriesData(currentClient.TimeSeriesDataRootUrl + "/timeseriesdata/read/historic/" + currentClient.DataPointID.ToString() + "/*-30S/*/XML")
													//TimeSeriesData = CommonFunctions.GetTimeSeriesData(currentClient.TimeSeriesDataRootUrl + "current/" + currentClient.DataPointID.ToString() + "/XML")
												}
											);
				}
				else if (currentClient.CurrentDisplayType == DisplayType.ServiceClient)
				{
					if (serviceClientList.ContainsKey(currentClient.NodeID))
					{
						System.Diagnostics.Debug.WriteLine("Sending Cached Status to Client Connected on System Monitor Page.");
						PushMessageToClient(session, new ServiceUpdateMessage()
												{
													ServiceUpdateType = TVA.Services.UpdateType.Information,
													ServiceUpdate = serviceClientList[currentClient.NodeID].CachedStatus
												});
					}					
					else
					{
						System.Diagnostics.Debug.WriteLine("Sending Empty Message to Client Connected on System Monitor Page.");
						PushMessageToClient(session, new ServiceUpdateMessage());
					}
				}
				else if (currentClient.CurrentDisplayType == DisplayType.DeviceMeasurements)
				{
					KeyValuePair<int, int> minMaxPointID = minMaxPointIDsPerNode[currentClient.NodeID];
					if (!string.IsNullOrEmpty(currentClient.TimeSeriesDataRootUrl))	// if TimeSeriesDataRootUrl is defined for the node, then only try to send data to client upon connection.
					{
						System.Diagnostics.Debug.WriteLine("Sending Measurements to Client Connected on Device Measurements Page.");
						PushMessageToClient(session, new TimeTaggedDataMessage()
												{
													TimeTaggedMeasurements = CommonFunctions.GetTimeTaggedMeasurements(currentClient.TimeSeriesDataRootUrl + "/timeseriesdata/read/current/" + minMaxPointID.Key.ToString() + "-" + minMaxPointID.Value.ToString() + "/XML")
												});
					}
					else
					{
						System.Diagnostics.Debug.WriteLine("Sending Empty Message to Client Connected on Device Measurements Page.");
						PushMessageToClient(session, new TimeTaggedDataMessage());
					}
				}
            }
			else if (msg is ServiceRequestMessage)
			{
				SendServiceRequest(clients[session].NodeID, (msg as ServiceRequestMessage).Request);
			}
			else if (msg is DisconnectMessage) //If it's a Disconnect message, treat as disconnection
			{
				ClientDisconnected(session);

			}
			else		//if (!(msg is ConnectMessage)) //Otherwise, if it's a payload-carrying message (and not just a simple "Connect"), process it
			{
				OnMessage(session, msg);
			}
        }

		private void SendServiceRequest(string nodeID, string request)
		{
			serviceClientList[nodeID].Helper.SendRequest(request);
		}

        protected void RefreshDataPerNode()
        {   			
			//nodesInDatabase = CommonFunctions.GetNodeList(true);
			List<Node> nodeList = new List<Node>();
			nodeList = CommonFunctions.GetNodeList(true);
			foreach (Node node in nodeList)
            {
				LivePhasorDataMessage message = new LivePhasorDataMessage()
                {
					//PmuDistributionList = CommonFunctions.GetPmuDistribution(),
                    DeviceDistributionList = CommonFunctions.GetVendorDeviceDistribution(node.ID),
                    InterconnectionStatusList = CommonFunctions.GetInterconnectionStatus(node.ID)
                };
			
				//lock (syncRoot)
				lock (dataPerNode)
				{
					if (dataPerNode.ContainsKey(node.ID))
						dataPerNode[node.ID] = message;
					else
						dataPerNode.Add(node.ID, message);
				}
            }
        }

		protected void RefreshTimeTaggedMeasurementsPerNode()
		{
			List<Node> nodeList = new List<Node>();
			nodeList = CommonFunctions.GetNodeList(true);
			foreach (Node node in nodeList)
			{
				//lock (syncRoot)
				lock (minMaxPointIDsPerNode)
				{
					if (minMaxPointIDsPerNode.ContainsKey(node.ID))
						minMaxPointIDsPerNode[node.ID] = CommonFunctions.GetMinMaxPointIDs(node.ID);
					else
						minMaxPointIDsPerNode.Add(node.ID, CommonFunctions.GetMinMaxPointIDs(node.ID));
				}
			}
					
			foreach (Node node in nodeList)
			{
				KeyValuePair<int, int> minMaxPointID = minMaxPointIDsPerNode[node.ID];				
				TimeTaggedDataMessage message;
				if (!string.IsNullOrEmpty(node.TimeSeriesDataServiceUrl))
					message = new TimeTaggedDataMessage()
								{
										TimeTaggedMeasurements = CommonFunctions.GetTimeTaggedMeasurements(node.TimeSeriesDataServiceUrl + "/timeseriesdata/read/current/" + minMaxPointID.Key.ToString() + "-" + minMaxPointID.Value.ToString() + "/XML")
								};
				else
					message = new TimeTaggedDataMessage();

				//lock (syncRoot)
				lock (timeTaggedMeasurementsPerNode)
				{
					if (timeTaggedMeasurementsPerNode.ContainsKey(node.ID))
						timeTaggedMeasurementsPerNode[node.ID] = message;
					else
						timeTaggedMeasurementsPerNode.Add(node.ID, message);
				}
			}
		}

		protected void PushServiceStatusToClients(string nodeID, DuplexMessage message)
		{			
			Dictionary<string, Client> clientsList = new Dictionary<string, Client>();
			lock (clients)
			{
				clientsList = clients;	// we will take a copy of the global collection locally to avoid locking of the resource.
			}
			
			foreach (string session in clientsList.Keys)
			{
				if (clientsList[session].CurrentDisplayType == DisplayType.ServiceClient && clientsList[session].NodeID == nodeID)
					PushMessageToClient(session, message);
			}			
		}

        protected void PushToAllClients(MessageType messageType)
        {
			//This is not the best way to check for measurementType and have individual local collection of clients and foreach loop but
			//since this method is being called by different threads and timers, I have implemented it this way. --Mehul Thakkar.
			if (messageType == MessageType.LivePhasorDataMessage)
			{
				Dictionary<string, Client> clientsList = new Dictionary<string, Client>();
				lock (clients)
				{
					clientsList = clients;	// we will take a copy of the global collection locally to avoid locking of the resource.
				}

				lock (clientsList)
				{
					foreach (string session in clientsList.Keys)
					{
						if (clientsList[session].CurrentDisplayType == DisplayType.Home)
						{
							if (dataPerNode.ContainsKey(clientsList[session].NodeID))
								PushMessageToClient(session, dataPerNode[clientsList[session].NodeID]);
							else
								PushMessageToClient(session, new LivePhasorDataMessage());
						}
					}
				}
			}
			else if (messageType == MessageType.TimeSeriesDataMessage)
			{
				Dictionary<string, Client> clientsList = new Dictionary<string, Client>();
				lock (clients)
				{
					clientsList = clients;	// we will take a copy of the global collection locally to avoid locking of the resource.
				}

				lock (clientsList)
				{
					foreach (string session in clientsList.Keys)
					{
						if (clientsList[session].CurrentDisplayType == DisplayType.Home && !string.IsNullOrEmpty(clientsList[session].TimeSeriesDataRootUrl))
						{
							TimeSeriesDataMessage message = new TimeSeriesDataMessage()
							{
								TimeSeriesData = CommonFunctions.GetTimeSeriesData(clientsList[session].TimeSeriesDataRootUrl + "/timeseriesdata/read/current/" + clientsList[session].DataPointID.ToString() + "/XML")
							};
							PushMessageToClient(session, message);
						}
					}
				}
			}
			else if (messageType == MessageType.TimeTaggedDataMessage)
			{
				Dictionary<string, Client> clientsList = new Dictionary<string, Client>();
				lock (clients)
				{
					clientsList = clients;	// we will take a copy of the global collection locally to avoid locking of the resource.
				}
				
				lock (clientsList)
				{
					foreach (string session in clientsList.Keys)
					{
						if (clientsList[session].CurrentDisplayType == DisplayType.DeviceMeasurements)
						{
							if (timeTaggedMeasurementsPerNode.ContainsKey(clientsList[session].NodeID))
								PushMessageToClient(session, timeTaggedMeasurementsPerNode[clientsList[session].NodeID]);
							else
								PushMessageToClient(session, new TimeTaggedDataMessage());
						}
					}
				}
			}
            
        }

        /// <summary>
        /// Pushes a message to one specific client
        /// </summary>
        /// <param name="clientSessionId">Session ID of the client that should receive the message</param>
        /// <param name="message">The message to push</param>
        protected void PushMessageToClient(string clientSessionId, DuplexMessage message)
        {
			try		//try to send message to client if it is still connected. Otherwise dont worry about it.
			{
				IUniversalDuplexCallbackContract ch = (clients[clientSessionId]).Channel;

				IAsyncResult iar = ch.BeginSendToClient(message, new AsyncCallback(OnPushMessageComplete), new PushMessageState(ch, clientSessionId));
				if (iar.CompletedSynchronously)
				{
					CompletePushMessage(iar);
				}
			}
			catch { }
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="DuplexService"/> object and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                try
                {
                    // This will be done regardless of whether the object is finalized or disposed.
                    if (disposing)
                    {
                        // This will be done only when the object is disposed by calling Dispose().
                        ICollection<string> sessionIds = clients.Keys;
                        foreach (string sessionId in sessionIds)
                        {
                            ClientDisconnected(sessionId);
                        }
                    }
                }
                finally
                {
                    m_disposed = true;  // Prevent duplicate dispose.
                }
            }
        }

        /// <summary>
        /// This will be called when a new client is connected
        /// </summary>
        /// <param name="sessionId">Session ID of the newly-connected client</param>
        protected virtual void OnConnected(string sessionId) { }

        /// <summary>
        /// This will be called when a client is disconnected
        /// </summary>
        /// <param name="sessionId">Session ID of the newly-disconnected client</param>
        protected virtual void OnDisconnected(string sessionId) { }

        /// <summary>
        /// This will be called when a message is received from a client
        /// </summary>
        /// <param name="sessionId">Session ID of the client sending the message</param>
        /// <param name="message">The message that was received</param>
        protected virtual void OnMessage(string sessionId, DuplexMessage message) { }

        private void OnPushMessageComplete(IAsyncResult iar)
        {
            if (iar.CompletedSynchronously)
            {
                return;
            }
            else
            {
                CompletePushMessage(iar);
            }
        }

        private void CompletePushMessage(IAsyncResult iar)
        {
            IUniversalDuplexCallbackContract ch = ((PushMessageState)(iar.AsyncState)).Channel;
            try
            {
                ch.EndSendToClient(iar);
            }
            catch (Exception ex)
            {
                //Any error while pushing out a message to a client
                //will be treated as if that client has disconnected
                System.Diagnostics.Debug.WriteLine(ex);
                ClientDisconnected(((PushMessageState)(iar.AsyncState)).SessionId);
            }
        }

        private void Channel_Closing(object sender, EventArgs e)
        {
            IContextChannel channel = (IContextChannel)sender;
            ClientDisconnected(channel.SessionId);
        }

        private void Channel_Faulted(object sender, EventArgs e)
        {
            IContextChannel channel = (IContextChannel)sender;
            ClientDisconnected(channel.SessionId);
        }

        private void ClientDisconnected(string sessionId)
        {
            //lock (syncRoot)
			lock (clients)
            {
                if (clients.ContainsKey(sessionId))
                    clients.Remove(sessionId);
            }
            try
            {
                OnDisconnected(sessionId);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        #endregion
    }
}