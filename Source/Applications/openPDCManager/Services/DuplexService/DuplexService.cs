//*******************************************************************************************************
//  DuplexService.cs
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
using System.Collections.Generic;
using System.ServiceModel;
using openPDCManager.Web.Data;

namespace PCS.Services.DuplexService
{    
    /// <summary>
    /// Derive your own Duplex service from this class
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public abstract class DuplexService : IUniversalDuplexContract
    {    
        object syncRoot = new object();
        Dictionary<string, IUniversalDuplexCallbackContract> clients = new Dictionary<string, IUniversalDuplexCallbackContract>();
        
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

        /// <summary>
        /// Pushes a message to all connected clients
        /// </summary>
        /// <param name="message">The message to push</param>
        protected void PushToAllClients(DuplexMessage message)
        {
            lock (syncRoot)
            {
                foreach (string session in clients.Keys)
                {
                    PushMessageToClient(session, message);
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
            IUniversalDuplexCallbackContract ch = clients[clientSessionId];

            IAsyncResult iar = ch.BeginSendToClient(message, new AsyncCallback(OnPushMessageComplete), new PushMessageState(ch, clientSessionId));
            if (iar.CompletedSynchronously)
            {
                CompletePushMessage(iar);
            }    
        }

        void OnPushMessageComplete(IAsyncResult iar)
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

        void CompletePushMessage(IAsyncResult iar)
        {
            IUniversalDuplexCallbackContract ch = ((PushMessageState)(iar.AsyncState)).ch;
            try
            {
                ch.EndSendToClient(iar);
            }
            catch (Exception ex)
            {
                //Any error while pushing out a message to a client
                //will be treated as if that client has disconnected
                System.Diagnostics.Debug.WriteLine(ex);
                ClientDisconnected(((PushMessageState)(iar.AsyncState)).sessionId);
            }
        }


        void IUniversalDuplexContract.SendToService(DuplexMessage msg)
        {
            //We get here when we receive a message from a client

            IUniversalDuplexCallbackContract ch = OperationContext.Current.GetCallbackChannel<IUniversalDuplexCallbackContract>();
            string session = OperationContext.Current.Channel.SessionId;

            //Any message from a client we haven't seen before causes the new client to be added to our list
            //(Basically, treated as a "Connect" message)
            lock (syncRoot)
            {
                if (!clients.ContainsKey(session))
                {
                    clients.Add(session, ch);
                    OperationContext.Current.Channel.Closing += new EventHandler(Channel_Closing);
                    OperationContext.Current.Channel.Faulted += new EventHandler(Channel_Faulted);
                    OnConnected(session);

                    PushMessageToClient(session, new LivePhasorDataMessage(){
                                                    PmuDistributionList = CommonFunctions.GetPmuDistribution(),
                                                    DeviceDistributionList = CommonFunctions.GetVendorDeviceDistribution(),
                                                    InterconnectionStatusList = CommonFunctions.GetInterconnectionStatus()
                                                    }
                    );

                }
            }

            //If it's a Disconnect message, treat as disconnection
            if (msg is DisconnectMessage)
            {
                ClientDisconnected(session);
            }
            //Otherwise, if it's a payload-carrying message (and not just a simple "Connect"), process it
            else if (!(msg is ConnectMessage))
            {
                OnMessage(session, msg);
            }
        }

        void Channel_Closing(object sender, EventArgs e)
        {
            IContextChannel channel = (IContextChannel)sender;
            ClientDisconnected(channel.SessionId);
        }
        void Channel_Faulted(object sender, EventArgs e)
        {
            IContextChannel channel = (IContextChannel)sender;
            ClientDisconnected(channel.SessionId);
        }
        void ClientDisconnected(string sessionId)
        {
            lock (syncRoot)
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

        //Helper class for tracking both a channel and its session ID together
        class PushMessageState
        {
            internal IUniversalDuplexCallbackContract ch;
            internal string sessionId;
            internal PushMessageState(IUniversalDuplexCallbackContract channel, string session)
            {
                ch = channel;
                sessionId = session;
            }
        }
    }
}