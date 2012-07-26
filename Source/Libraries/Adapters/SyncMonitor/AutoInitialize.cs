//******************************************************************************************************
//  AutoInitialize.cs - Gbtc
//
//  Copyright © 2012, Grid Protection Alliance.  All Rights Reserved.
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
//  07/26/2012 - J. Ritchie Carroll
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using TimeSeriesFramework.Adapters;
using TimeSeriesFramework.UI;
using TVA;
using TVA.Collections;
using TVA.Communication;
using TVA.Data;

namespace SyncMonitor
{
    /// <summary>
    /// Represents an adapter that can be loaded to monitor for database changes and auto-initialze an adapter.
    /// </summary>
    [Description("AutoInitialize: monitors database and auto-initializes adapters with configurations changes.")]
    public class AutoInitialize : FacileActionAdapterBase
    {
        #region [ Members ]

        // Constants

        /// <summary>
        /// Defines the default <see cref="MonitoringInterval"/>.
        /// </summary>
        private const int DefaultMonitoringInterval = 30000;

        // Fields
        private System.Timers.Timer m_monitor;
        private long m_databaseQueries;
        private DateTime m_lastInitialization;
        private Guid m_nodeID;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new instance of the <see cref="AutoInitialize"/> class.
        /// </summary>
        public AutoInitialize()
        {
            m_monitor = new System.Timers.Timer
            {
                AutoReset = true,
                Interval = DefaultMonitoringInterval,
                Enabled = false
            };

            m_monitor.Elapsed += m_monitor_Elapsed;
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets the interval overwhich the <see cref="AutoInitialize"/> instance will monitor the database for updates.
        /// </summary>
        [ConnectionStringParameter,
        Description("Define the interval, in milliseconds, overwhich the database will be monitored for updates."),
        DefaultValue(DefaultMonitoringInterval)]
        public int MonitoringInterval
        {
            get
            {
                if ((object)m_monitor != null)
                    return (int)m_monitor.Interval;

                return 0;
            }
            set
            {
                if (value < 1)
                    value = DefaultMonitoringInterval;

                if ((object)m_monitor != null)
                    m_monitor.Interval = value;
            }
        }

        /// <summary>
        /// Gets the flag indicating if this adapter supports temporal processing.
        /// </summary>
        /// <remarks>
        /// For the <see cref="AutoInitialize"/> adapter this always returns false.
        /// </remarks>
        public override bool SupportsTemporalProcessing
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the detailed status of the <see cref="AutoInitialize"/> instance.
        /// </summary>
        public override string Status
        {
            get
            {
                StringBuilder status = new StringBuilder();

                status.AppendFormat("       Monitoring interval: {0}ms", MonitoringInterval);
                status.AppendLine();
                status.AppendFormat("    Total database queries: {0}", m_databaseQueries);
                status.AppendLine();

                status.Append(base.Status);

                return status.ToString();
            }
        }

        #endregion

        #region [ Methods ]

        private bool m_disposed;

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="AutoInitialize"/> object and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                try
                {
                    if (disposing)
                    {
                        if ((object)m_monitor != null)
                        {
                            m_monitor.Stop();
                            m_monitor.Dispose();
                        }
                        m_monitor = null;
                    }
                }
                finally
                {
                    m_disposed = true;          // Prevent duplicate dispose.
                    base.Dispose(disposing);    // Call base class Dispose().
                }
            }
        }
        /// <summary>
        /// Initializes the <see cref="AutoInitialize"/> calculator.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            Dictionary<string, string> settings = Settings;
            string setting;
            int interval;

            // Load required parameters
            if (!settings.TryGetValue("monitoringInterval", out setting) || !int.TryParse(setting, out interval))
                interval = DefaultMonitoringInterval;

            MonitoringInterval = interval;
            m_lastInitialization = DateTime.UtcNow;
        }

        /// <summary>
        /// Starts this <see cref="AutoInitialize"/> instance.
        /// </summary>
        public override void Start()
        {
            base.Start();

            // When this instance is started we start the monitoring timer
            if ((object)m_monitor != null)
                m_monitor.Start();
        }

        /// <summary>
        /// Stops this <see cref="AutoInitialize"/> instance.
        /// </summary>
        public override void Stop()
        {
            base.Stop();

            // When this instance is stopped we stop the monitoring timer
            if ((object)m_monitor != null)
                m_monitor.Stop();
        }

        /// <summary>
        /// Gets a short one-line status of this <see cref="AutoInitialize"/> adapter.
        /// </summary>
        /// <param name="maxLength">Maximum number of available characters for display.</param>
        /// <returns>A short one-line summary of the current status of this <see cref="AdapterBase"/>.</returns>
        public override string GetShortStatus(int maxLength)
        {
            if ((object)m_monitor != null && m_monitor.Enabled)
                return string.Format("Actively monitoring configuration - {0} checks so far...", m_databaseQueries).PadLeft(maxLength);

            return "Configuration monitoring is not active".PadLeft(maxLength);
        }

        // Queries database for any changes and initializes and adapters that have new configurations
        private void m_monitor_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                List<int> runtimeIDs = new List<int>();

                using (AdoDataConnection database = new AdoDataConnection("systemSettings"))
                {
                    IDbConnection connection = database.Connection;

                    // Get base tables that contain adapters
                    string[] sourceTables = connection.RetrieveData(database.AdapterType, "SELECT DISTINCT SourceTable FROM Runtime").AsEnumerable().Select(row => row[0].ToString()).ToArray();

                    // Get runtime ID's for all adapters that have changes
                    foreach (string sourceTable in sourceTables)
                    {
                        string query = database.ParameterizedQueryString(string.Format("SELECT ID FROM {0} WHERE UpdatedOn >= {{0}}", sourceTable), "currentTime");
                        int runtimeID;

                        foreach (int sourceID in connection.RetrieveData(database.AdapterType, query, database.IsJetEngine ? (object)m_lastInitialization.ToOADate() : (object)m_lastInitialization).AsEnumerable().Select(row => int.Parse(row[0].ToString())))
                        {
                            if (int.TryParse(connection.ExecuteScalar(string.Format("SELECT ID FROM Runtime WHERE SourceID={0} AND SourceTable='{1}'", sourceID, sourceTable)).ToNonNullString("0"), out runtimeID) && runtimeID > 0)
                                runtimeIDs.Add(runtimeID);
                        }
                    }

                    if (runtimeIDs.Count > 0)
                    {
                        // Determine the active node ID - we cache this since this value won't change for the lifetime of this class
                        if (m_nodeID == Guid.Empty)
                        {
                            m_nodeID = Guid.Parse(connection.ExecuteScalar(string.Format("SELECT NodeID FROM IaonActionAdapter WHERE ID = {0}", ID)).ToString());

                            // Make sure common functions know which is the active node - this will start the connect sequence
                            m_nodeID.SetAsCurrentNodeID();
                        }

                        // Make sure a connection to service exists
                        WindowsServiceClient client = CommonFunctions.GetWindowsServiceClient();
                        int waitCount = 0;

                        // Wait up to two seconds for service client to connect to host
                        while (client.Helper.RemotingClient.CurrentState != ClientState.Connected && waitCount < 10)
                        {
                            Thread.Sleep(200);
                            waitCount++;
                        }

                        if (waitCount >= 10)
                        {
                            OnStatusMessage("WARNING: Could not connect to service to send initialization commands after waiting for two seconds to connect. Restarting service connection sequence...");

                            // Restart the service connect sequence
                            m_nodeID.SetAsCurrentNodeID();
                        }
                        else
                        {
                            // Send a single configuration reload command
                            CommonFunctions.SendCommandToService("ReloadConfig");

                            // Send an initialize command for each updated adapter
                            foreach (int runtimeID in runtimeIDs)
                            {
                                CommonFunctions.SendCommandToService(string.Format("Initialize {0} -SkipReloadConfig", runtimeID));
                            }

                            OnStatusMessage("Applied configuration updates for adapters: " + runtimeIDs.ToDelimitedString(", "));

                            // After we have updated any adapters, we update last initialization time
                            m_lastInitialization = DateTime.UtcNow;
                        }
                    }
                }

                m_databaseQueries++;
            }
            catch (ThreadAbortException)
            {
                throw;
            }
            catch (Exception ex)
            {
                OnProcessException(new InvalidOperationException("Failed while checking database to monitor for adapter changes: " + ex.Message, ex));
            }
        }

        #endregion
    }
}
