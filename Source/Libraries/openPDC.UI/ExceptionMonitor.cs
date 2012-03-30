//******************************************************************************************************
//  ExceptionMonitor.cs - Gbtc
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
//  3/26/2012 - prasanthgs
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using openPDC.UI.DataModels;
using TVA.Data;
using TimeSeriesFramework.UI;
using System.Data;
using System.Collections.ObjectModel;

namespace openPDC.UI
{
    /// <summary>
    /// Provides Exception Monitor that checks the ExceptionLog
    /// to keep the Exception Log list updated.
    /// </summary>
    /// <remarks>
    /// Typically class should be implemented as a singleton since one instance will create.
    /// </remarks>
    public class ExceptionMonitor : IDisposable
    {
        #region [ Members ]

        // Constants
        private const int DefaultRefreshInterval = 10;

        /// <summary>
        /// Event raised when ExceptionList updation required.
        /// </summary>
        public event EventHandler<EventArgs> UpdatedExceptions;

        // Fields
        private int m_refreshInterval;
        private object m_exLock;
        private List<ExceptionLog> m_ExceptionList;
        private System.Timers.Timer m_refreshTimer;
        private bool m_disposed;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new instance of the <see cref="ExceptionMonitor"/> class.
        /// </summary>
        /// <param name="singleton">Indicates whether this instance should 
        /// be singleton. Default value false</param>
        public ExceptionMonitor(bool singleton = false)
        {
            m_refreshInterval = DefaultRefreshInterval;

            m_exLock = new object();
            m_ExceptionList = new List<ExceptionLog>();
            m_refreshTimer = new System.Timers.Timer(m_refreshInterval * 1000);
            m_refreshTimer.Elapsed += m_refreshTimer_Elapsed;

            if (singleton)
                Default = this;
        }

        #endregion

        #region [ Properties ]
        /// <summary>
        /// Gets or sets the interval, in seconds,
        /// between refreshing the exception list.
        /// </summary>
        public int RefreshInterval
        {
            get
            {
                return m_refreshInterval;
            }
            set
            {
                m_refreshInterval = value;
                m_refreshTimer.Interval = m_refreshInterval * 1000;
            }
        }

        #endregion

        #region [ Methods ]

        private void m_refreshTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            RefreshExceptionsList();
        }

        /// <summary>
        /// Reset the refresh interval of Exception Monitor to 
        /// default value =  10 sec(s)
        /// </summary>
        public void ResetRefreshInterval()
        {
            RefreshInterval = DefaultRefreshInterval;
        }
        /// <summary>
        /// Starts the refresh timer that checks recent exceptions.
        /// </summary>
        public void Start()
        {
            if (m_disposed)
            {
                m_refreshTimer = new System.Timers.Timer(m_refreshInterval * 1000);
                m_refreshTimer.Elapsed += m_refreshTimer_Elapsed;
                m_disposed = false;
            }
            if (!m_refreshTimer.Enabled)
            {
                RefreshExceptionsList();
                m_refreshTimer.Start();
            }
        }

        /// <summary>
        /// Stops the refresh timer.
        /// </summary>
        public void Stop()
        {
            if (m_refreshTimer != null)
            {
                if (m_refreshTimer.Enabled)
                    m_refreshTimer.Stop();
            }
        }

        /// <summary>
        /// Gets current Exceptions.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<ExceptionLog> GetRecentExceptions()
        {
            lock (m_exLock)
            {
                return new ObservableCollection<ExceptionLog>(m_ExceptionList);
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or
        /// resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="ExceptionMonitor"/> 
        /// object and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources;
        /// false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                try
                {
                    if (disposing)
                    {
                        if ((object)m_refreshTimer != null)
                        {
                            m_refreshTimer.Dispose();
                            m_refreshTimer = null;
                        }
                    }
                }
                finally
                {
                    m_disposed = true;
                }
            }
        }

        /// <summary>
        /// Fetch recent exception details from ExceptionLog table.
        /// </summary>
        private void RefreshExceptionsList()
        {
            bool createdConnection = false;
            AdoDataConnection database = null;
            int idxNo = default(int);
            List<ExceptionLog> newTempList = null;

            try
            {

                createdConnection = DataModelBase.CreateConnection(ref database);

                DataTable ErrorLogTable = database.Connection.RetrieveData(database.AdapterType,
                    "SELECT Source, Type, Message, Detail, DateTime FROM ExceptionLog ORDER BY ID DESC");

                newTempList = new List<ExceptionLog>();

                foreach (DataRow row in ErrorLogTable.Rows)
                {
                    newTempList.Add(new ExceptionLog
                    {
                        DateandTime = row.Field<DateTime>("DateTime"),
                        ExceptionSource = row.Field<String>("Source"),
                        ExceptionType = row.Field<String>("Type"),
                        ExceptionMessage = row.Field<String>("Message"),
                        Index = ++idxNo,
                        Details = row.Field<String>("Detail")
                    });
                }

                // Update the exception list
                lock (m_exLock)
                {
                    m_ExceptionList = newTempList;
                }

                // Notify that the ExceptionList have been updated
                OnUpdatedExceptions();
            }
            catch (Exception)
            {  
                //Do nothing, if error raised while logging Exceptions
            }
            finally
            {
                if (createdConnection && database != null)
                    database.Dispose();
            }
        }

        // Triggers the updated ExceptionList event.
        private void OnUpdatedExceptions()
        {
            if (UpdatedExceptions != null)
                UpdatedExceptions(this, new EventArgs());
        }

        #endregion

        #region [ Static ]

        /// <summary>
        /// Gets ExceptionMonitor object.
        /// </summary>
        public static ExceptionMonitor Default { get; set; }

        #endregion
    }
}
