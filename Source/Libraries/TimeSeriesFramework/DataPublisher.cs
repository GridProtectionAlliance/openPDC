//******************************************************************************************************
//  DataPublisher.cs - Gbtc
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
//  08/20/2010 - J. Ritchie Carroll
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVA;
using TVA.Communication;

namespace TimeSeriesFramework
{
    /// <summary>
    /// Represents a data publishing server that allows multiple connections for data subscriptions.
    /// </summary>
    public class DataPublisher : IDisposable
    {
        #region [ Members ]

        // Nested Types

        // Constants

        // Delegates

        // Events

        // Fields
        private TcpServer m_dataServer;
        private bool m_disposed;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new <see cref="DataPublisher"/>.
        /// </summary>
        public DataPublisher()
        {
            // Create a new TCP server
            m_dataServer = new TcpServer();
            m_dataServer.ClientConnected += m_dataServer_ClientConnected;
            m_dataServer.ClientDisconnected += m_dataServer_ClientDisconnected;
            m_dataServer.HandshakeProcessTimeout += m_dataServer_HandshakeProcessTimeout;
            m_dataServer.HandshakeProcessUnsuccessful += m_dataServer_HandshakeProcessUnsuccessful;
            m_dataServer.ReceiveClientDataComplete += m_dataServer_ReceiveClientDataComplete;
            m_dataServer.ReceiveClientDataException += m_dataServer_ReceiveClientDataException;
            m_dataServer.ReceiveClientDataTimeout += m_dataServer_ReceiveClientDataTimeout;
            m_dataServer.SendClientDataException += m_dataServer_SendClientDataException;
            m_dataServer.ServerStarted += m_dataServer_ServerStarted;
            m_dataServer.ServerStopped += m_dataServer_ServerStopped;
        }

        /// <summary>
        /// Releases the unmanaged resources before the <see cref="DataPublisher"/> object is reclaimed by <see cref="GC"/>.
        /// </summary>
        ~DataPublisher()
        {
            Dispose(false);
        }

        #endregion

        #region [ Properties ]

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Releases all the resources used by the <see cref="DataPublisher"/> object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="DataPublisher"/> object and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                try
                {
                    if (disposing)
                    {
                        if (m_dataServer != null)
                        {
                            m_dataServer.ClientConnected -= m_dataServer_ClientConnected;
                            m_dataServer.ClientDisconnected -= m_dataServer_ClientDisconnected;
                            m_dataServer.HandshakeProcessTimeout -= m_dataServer_HandshakeProcessTimeout;
                            m_dataServer.HandshakeProcessUnsuccessful -= m_dataServer_HandshakeProcessUnsuccessful;
                            m_dataServer.ReceiveClientDataComplete -= m_dataServer_ReceiveClientDataComplete;
                            m_dataServer.ReceiveClientDataException -= m_dataServer_ReceiveClientDataException;
                            m_dataServer.ReceiveClientDataTimeout -= m_dataServer_ReceiveClientDataTimeout;
                            m_dataServer.SendClientDataException -= m_dataServer_SendClientDataException;
                            m_dataServer.ServerStarted -= m_dataServer_ServerStarted;
                            m_dataServer.ServerStopped -= m_dataServer_ServerStopped;
                            m_dataServer.Dispose();
                        }
                        m_dataServer = null;
                    }
                }
                finally
                {
                    m_disposed = true;  // Prevent duplicate dispose.
                }
            }
        }

        private void m_dataServer_ServerStopped(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void m_dataServer_ServerStarted(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void m_dataServer_SendClientDataException(object sender, EventArgs<Guid, Exception> e)
        {
            throw new NotImplementedException();
        }

        private void m_dataServer_ReceiveClientDataTimeout(object sender, EventArgs<Guid> e)
        {
            throw new NotImplementedException();
        }

        private void m_dataServer_ReceiveClientDataException(object sender, EventArgs<Guid, Exception> e)
        {
            throw new NotImplementedException();
        }

        private void m_dataServer_ReceiveClientDataComplete(object sender, EventArgs<Guid, byte[], int> e)
        {
            throw new NotImplementedException();
        }

        private void m_dataServer_HandshakeProcessUnsuccessful(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void m_dataServer_HandshakeProcessTimeout(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void m_dataServer_ClientDisconnected(object sender, EventArgs<Guid> e)
        {
            throw new NotImplementedException();
        }

        private void m_dataServer_ClientConnected(object sender, EventArgs<Guid> e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region [ Operators ]

        #endregion

        #region [ Static ]

        // Static Fields

        // Static Constructor

        // Static Properties

        // Static Methods

        #endregion       
    }
}
