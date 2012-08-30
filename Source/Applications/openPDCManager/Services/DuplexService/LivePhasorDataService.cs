//******************************************************************************************************
//  LivePhasorDataService.cs - Gbtc
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
//  03/02/2010 - Pinal C. Patel
//       Implemented IDisposable interface and added code regions.
//
//******************************************************************************************************

using System.Collections.Generic;
using System.Threading;
using openPDCManager.Data;
using openPDCManager.Data.Entities;
using openPDCManager.Data.ServiceCommunication;
using TVA;
using TVA.ServiceProcess;

namespace openPDCManager.Services.DuplexService
{   
    /// <summary>
    /// This class actually does all the work for the duplex service. It is being referenced in the .svc file.
    /// </summary>
    public class LivePhasorDataService : DuplexService
    {
        #region [ Members ]	
        // This timer will be used to retrieve fresh data from the database and then push to all clients.
        Timer livePhasorDataTimer;
        Timer timeSeriesDataTimer;
		Timer serviceClientListTimer;
		Timer timeTaggedMeasurementDataTimer;
        WindowsServiceClient serviceClient;
        bool m_disposed, m_retrievingData;		
		List<Node> nodeList;

        #endregion

        #region [ Constructors ]

        public LivePhasorDataService()
            : base()
        {
			serviceClientList = new Dictionary<string, WindowsServiceClient>();
			List<Node> nodeList = new List<Node>();
            livePhasorDataTimer = new Timer(LivePhasorDataUpdate, null, 0, 30000);
            timeSeriesDataTimer = new Timer(TimeSeriesDataUpdate, null, 0, 1000);			
			serviceClientListTimer = new Timer(RefreshServiceClientList, null, 0, 30000);
			timeTaggedMeasurementDataTimer = new Timer(TimeTaggedMeasurementDataUpdate, null, 0, 30000);
            nodeList = CommonFunctions.GetNodeList(null, true);
        }

        #endregion

        #region [ Methods ]
		
        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="LivePhasorDataService"/> object and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                try
                {
                    // This will be done regardless of whether the object is finalized or disposed.
                    if (disposing)
                    {
                        // This will be done only when the object is disposed by calling Dispose().
                        livePhasorDataTimer.Dispose();
                        timeSeriesDataTimer.Dispose();
                        serviceClientListTimer.Dispose();
                        timeTaggedMeasurementDataTimer.Dispose();
						lock (serviceClientList)
						{
							foreach (KeyValuePair<string, WindowsServiceClient> item in serviceClientList)
							{
								item.Value.Helper.ReceivedServiceUpdate -= ClientHelper_ReceivedServiceUpdate;
								item.Value.Helper.ReceivedServiceResponse -= ClientHelper_ReceivedServiceResponse;
								item.Value.Dispose();
							}
						}
						serviceClientList.Clear();
                    }
                }
                finally
                {
                    m_disposed = true;          // Prevent duplicate dispose.
                    base.Dispose(disposing);    // Call base class Dispose().
                }
            }
        }

        private void LivePhasorDataUpdate(object obj)
        {
            RefreshDataPerNode();
            PushToAllClients(MessageType.LivePhasorDataMessage);
        }

        private void TimeSeriesDataUpdate(object obj)
        {
            try
            {
                if (!m_retrievingData)
                {
                    m_retrievingData = true;
                    PushToAllClients(MessageType.TimeSeriesDataMessage);
                    m_retrievingData = false;
                }
            }
            catch 
            {
                m_retrievingData = false;
            }            
        }

		private void RefreshServiceClientList(object obj)
		{
			System.Diagnostics.Debug.WriteLine("Refreshing Service Clients List");
            nodeList = CommonFunctions.GetNodeList(null, true);
			
			//For each node defined in the database, we need to have a TCP client created to listen to the events.
			foreach (Node node in nodeList)
			{
				lock (serviceClientList)
				{
					if (serviceClientList.ContainsKey(node.ID))
					{
						if (node.RemoteStatusServiceUrl != serviceClientList[node.ID].Helper.RemotingClient.ConnectionString)
						{
							System.Diagnostics.Debug.WriteLine("Resetting Service Client for Node: " + node.ID);
							serviceClientList[node.ID].Helper.ReceivedServiceUpdate -= ClientHelper_ReceivedServiceUpdate;
							serviceClientList[node.ID].Helper.ReceivedServiceResponse -= ClientHelper_ReceivedServiceResponse;
							serviceClientList[node.ID].Dispose();
							if (!string.IsNullOrEmpty(node.RemoteStatusServiceUrl))
							{
								System.Diagnostics.Debug.WriteLine("Reconnecting Service Client for Node: " + node.ID);
								serviceClientList[node.ID] = null;
								serviceClient = new WindowsServiceClient(node.RemoteStatusServiceUrl);
								serviceClient.Helper.RemotingClient.MaxConnectionAttempts = 10;
								serviceClientList[node.ID] = serviceClient;
								serviceClient.Helper.ReceivedServiceUpdate += ClientHelper_ReceivedServiceUpdate;
								serviceClient.Helper.ReceivedServiceResponse += ClientHelper_ReceivedServiceResponse;
								ThreadPool.QueueUserWorkItem(ConnectWindowsServiceClient, serviceClient);
							}
							else
							{
								System.Diagnostics.Debug.WriteLine("Removing Service Client for Node: " + node.ID);
								serviceClientList.Remove(node.ID);
							}							
						}
						else if (!serviceClientList[node.ID].Helper.RemotingClient.Enabled)
						{
							ThreadPool.QueueUserWorkItem(ConnectWindowsServiceClient, serviceClientList[node.ID]);
						}
					}
					else
					{
						if (!string.IsNullOrEmpty(node.RemoteStatusServiceUrl))
						{
							System.Diagnostics.Debug.WriteLine("Adding New Service Client for Node: " + node.ID);
							serviceClient = new WindowsServiceClient(node.RemoteStatusServiceUrl);
							serviceClient.Helper.RemotingClient.MaxConnectionAttempts = 10;
							serviceClientList.Add(node.ID, serviceClient);
							serviceClient.Helper.ReceivedServiceUpdate += ClientHelper_ReceivedServiceUpdate;
							serviceClient.Helper.ReceivedServiceResponse += ClientHelper_ReceivedServiceResponse;		
							ThreadPool.QueueUserWorkItem(ConnectWindowsServiceClient, serviceClient);
						}
					}
				}
			}
		}
				
		private void ConnectWindowsServiceClient(object state)
		{
			try
			{
				((WindowsServiceClient)state).Helper.Connect();
			}
			catch 
			{ 
				
			}
		}

        private void ClientHelper_ReceivedServiceUpdate(object sender, EventArgs<UpdateType, string> e)
        {
			string connectionString = ((ClientHelper)sender).RemotingClient.ConnectionString;
			string nodeID = string.Empty;
			foreach (Node node in nodeList)
			{
				if (node.RemoteStatusServiceUrl == connectionString)
				{
					nodeID = node.ID;
					break;
				}
			}			
			ServiceUpdateMessage message = new ServiceUpdateMessage() 
												{ 
													ServiceUpdateType = e.Argument1, 
													ServiceUpdate = e.Argument2 
												};
			PushServiceStatusToClients(nodeID, message);            
        }

		private void ClientHelper_ReceivedServiceResponse(object sender, EventArgs<ServiceResponse> e)
		{
			string response = e.Argument.Type;
			string message = e.Argument.Message;
			string responseToClient = string.Empty;
			UpdateType responseType = UpdateType.Information;
			string connectionString = ((ClientHelper)sender).RemotingClient.ConnectionString;
			string nodeID = string.Empty;

			if (!string.IsNullOrEmpty(response))
			{
				// Reponse types are formatted as "Command:Success" or "Command:Failure"
				string[] parts = response.Split(':');
				string action;
				bool success;

				if (parts.Length > 1)
				{
					action = parts[0].Trim().ToTitleCase();
					success = (string.Compare(parts[1].Trim(), "Success", true) == 0);
				}
				else
				{
					action = response;
					success = true;
				}

				if (success)
				{
					if (string.IsNullOrEmpty(message))
						responseToClient = string.Format("{0} command processed successfully.\r\n\r\n", action);
					else
						responseToClient = string.Format("{0}\r\n\r\n", message);
				}
				else
				{
					responseType = UpdateType.Alarm;
					if (string.IsNullOrEmpty(message))
						responseToClient = string.Format("{0} failure.\r\n\r\n", action);
					else
						responseToClient = string.Format("{0} failure: {1}\r\n\r\n", action, message);
				}


				foreach (Node node in nodeList)
				{
					if (node.RemoteStatusServiceUrl == connectionString)
					{
						nodeID = node.ID;
						break;
					}
				}

				ServiceUpdateMessage msg = new ServiceUpdateMessage()
												{
													ServiceUpdateType = responseType,
													ServiceUpdate = responseToClient
												};
				PushServiceStatusToClients(nodeID, msg); 
			}

		}

		private void TimeTaggedMeasurementDataUpdate(object obj)
		{
			RefreshTimeTaggedMeasurementsPerNode();
            RefreshRealTimeStatisticsPerNode();
			PushToAllClients(MessageType.TimeTaggedDataMessage);
		}
                
        #endregion
    }
}
