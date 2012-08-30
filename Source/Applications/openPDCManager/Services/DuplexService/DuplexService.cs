//******************************************************************************************************
//  DuplexService.cs - Gbtc
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

using System;
using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;
using openPDCManager.Data;
using openPDCManager.Data.Entities;
using openPDCManager.Data.ServiceCommunication;
using TVA;

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
        DeviceMeasurements,
        RealTimeStatistics
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
        Dictionary<string, TimeTaggedDataMessage> realTimeStatisticsPerNode;        //stores current statistics data for all the input and output streams per node.
        Dictionary<string, KeyValuePair<int, int>> minMaxPointIDsPerNode;	//stores min and max values of point id in measurement table per node.
        private bool m_disposed;

        #endregion

        #region [ Constructors ]

        public DuplexService()
        {
            clients = new Dictionary<string, Client>();
            dataPerNode = new Dictionary<string, LivePhasorDataMessage>();
            timeTaggedMeasurementsPerNode = new Dictionary<string, TimeTaggedDataMessage>();
            realTimeStatisticsPerNode = new Dictionary<string, TimeTaggedDataMessage>();
            minMaxPointIDsPerNode = new Dictionary<string, KeyValuePair<int, int>>();

            List<Node> nodeList = new List<Node>();
            nodeList = CommonFunctions.GetNodeList(null, true);
            foreach (Node node in nodeList)
            {
                //lock (syncRoot)
                lock (minMaxPointIDsPerNode)
                {
                    if (minMaxPointIDsPerNode.ContainsKey(node.ID))
                        minMaxPointIDsPerNode[node.ID] = CommonFunctions.GetMinMaxPointIDs(null, node.ID);
                    else
                        minMaxPointIDsPerNode.Add(node.ID, CommonFunctions.GetMinMaxPointIDs(null, node.ID));
                }
            }

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
                        client.RealTimeStatisticRootUrl = (msg as ConnectMessage).RealTimeStatisticRootUrl;
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
                            RealTimeStatisticRootUrl = (msg as ConnectMessage).RealTimeStatisticRootUrl,
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
                                                DeviceDistributionList = CommonFunctions.GetVendorDeviceDistribution(null, currentClient.NodeID),
                                                InterconnectionStatusList = CommonFunctions.GetInterconnectionStatus(null, currentClient.NodeID)
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
                                                    ServiceUpdateType = UpdateType.Information,
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
                else if (currentClient.CurrentDisplayType == DisplayType.RealTimeStatistics)
                {
                    KeyValuePair<int, int> minMaxPointID = minMaxPointIDsPerNode[currentClient.NodeID];
                    if (!string.IsNullOrEmpty(currentClient.TimeSeriesDataRootUrl))	// if TimeSeriesDataRootUrl is defined for the node, then only try to send data to client upon connection.
                    {
                        System.Diagnostics.Debug.WriteLine("Sending Measurements to Client Connected on Device Measurements Page.");
                        PushMessageToClient(session, new TimeTaggedDataMessage()
                        {
                            TimeTaggedMeasurements = CommonFunctions.GetStatisticMeasurements(currentClient.RealTimeStatisticRootUrl + "/timeseriesdata/read/current/" + minMaxPointID.Key.ToString() + "-" + minMaxPointID.Value.ToString() + "/XML", currentClient.NodeID)
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
            nodeList = CommonFunctions.GetNodeList(null, true);
            foreach (Node node in nodeList)
            {
                LivePhasorDataMessage message = new LivePhasorDataMessage()
                {
                    //PmuDistributionList = CommonFunctions.GetPmuDistribution(),
                    DeviceDistributionList = CommonFunctions.GetVendorDeviceDistribution(null, node.ID),
                    InterconnectionStatusList = CommonFunctions.GetInterconnectionStatus(null, node.ID)
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
            nodeList = CommonFunctions.GetNodeList(null, true);
            foreach (Node node in nodeList)
            {
                //lock (syncRoot)
                lock (minMaxPointIDsPerNode)
                {
                    if (minMaxPointIDsPerNode.ContainsKey(node.ID))
                        minMaxPointIDsPerNode[node.ID] = CommonFunctions.GetMinMaxPointIDs(null, node.ID);
                    else
                        minMaxPointIDsPerNode.Add(node.ID, CommonFunctions.GetMinMaxPointIDs(null, node.ID));
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

        protected void RefreshRealTimeStatisticsPerNode()
        {
            List<Node> nodeList = new List<Node>();
            nodeList = CommonFunctions.GetNodeList(null, true);
            //foreach (Node node in nodeList)
            //{
            //    //lock (syncRoot)
            //    lock (minMaxPointIDsPerNode)
            //    {
            //        if (minMaxPointIDsPerNode.ContainsKey(node.ID))
            //            minMaxPointIDsPerNode[node.ID] = CommonFunctions.GetMinMaxPointIDs(node.ID);
            //        else
            //            minMaxPointIDsPerNode.Add(node.ID, CommonFunctions.GetMinMaxPointIDs(node.ID));
            //    }
            //}

            foreach (Node node in nodeList)
            {
                KeyValuePair<int, int> minMaxPointID = minMaxPointIDsPerNode[node.ID];
                TimeTaggedDataMessage message;
                if (!string.IsNullOrEmpty(node.RealTimeStatisticServiceUrl))
                    message = new TimeTaggedDataMessage()
                    {
                        TimeTaggedMeasurements = CommonFunctions.GetStatisticMeasurements(node.RealTimeStatisticServiceUrl + "/timeseriesdata/read/current/" + minMaxPointID.Key.ToString() + "-" + minMaxPointID.Value.ToString() + "/XML", node.ID)
                    };
                else
                    message = new TimeTaggedDataMessage();

                //lock (syncRoot)
                lock (realTimeStatisticsPerNode)
                {
                    if (realTimeStatisticsPerNode.ContainsKey(node.ID))
                        realTimeStatisticsPerNode[node.ID] = message;
                    else
                        realTimeStatisticsPerNode.Add(node.ID, message);
                }
            }
        }

        protected void PushServiceStatusToClients(string nodeID, DuplexMessage message)
        {
            Dictionary<string, Client> clientsList;
            lock (clients)
            {
                clientsList = new Dictionary<string, Client>(clients);	// we will take a copy of the global collection locally to avoid locking of the resource.
            }

            foreach (string session in clientsList.Keys)
            {
                if (clientsList[session].CurrentDisplayType == DisplayType.ServiceClient && clientsList[session].NodeID == nodeID)
                    PushMessageToClient(session, message);
            }
        }

        protected void PushToAllClients(MessageType messageType)
        {
            Dictionary<string, Client> clientsList;
            lock (clients)
            {
                clientsList = new Dictionary<string, Client>(clients);	// we will take a copy of the global collection locally to avoid locking of the resource.
            }

            //This is not the best way to check for measurementType and have individual local collection of clients and foreach loop but
            //since this method is being called by different threads and timers, I have implemented it this way. --Mehul Thakkar.
            if (messageType == MessageType.LivePhasorDataMessage)
            {
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
                        else if (clientsList[session].CurrentDisplayType == DisplayType.RealTimeStatistics)
                        {
                            if (realTimeStatisticsPerNode.ContainsKey(clientsList[session].NodeID))
                                PushMessageToClient(session, realTimeStatisticsPerNode[clientsList[session].NodeID]);
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
            catch
            {
            }
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
        protected virtual void OnConnected(string sessionId)
        {
        }

        /// <summary>
        /// This will be called when a client is disconnected
        /// </summary>
        /// <param name="sessionId">Session ID of the newly-disconnected client</param>
        protected virtual void OnDisconnected(string sessionId)
        {
        }

        /// <summary>
        /// This will be called when a message is received from a client
        /// </summary>
        /// <param name="sessionId">Session ID of the client sending the message</param>
        /// <param name="message">The message that was received</param>
        protected virtual void OnMessage(string sessionId, DuplexMessage message)
        {
        }

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