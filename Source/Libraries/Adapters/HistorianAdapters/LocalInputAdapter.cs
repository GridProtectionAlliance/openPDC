//******************************************************************************************************
//  LocalInputAdapter.cs - Gbtc
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
//  11/09/2011 - Ritchie
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using TimeSeriesFramework;
using TimeSeriesFramework.Adapters;
using TVA;
using TVA.Historian;
using TVA.Historian.Files;
using TVA.IO;

namespace HistorianAdapters
{
    /// <summary>
    /// Represents an output adapter that publishes measurements to TVA Historian for archival.
    /// </summary>
    [Description("Local Historian: reads data from local openHistorian for replay.")]
    public class LocalInputAdapter : InputAdapterBase
    {
        #region [ Members ]

        // Fields
        private System.Timers.Timer m_readTimer;
        private string m_archiveLocation;
        private ArchiveFile m_archiveFile;
        private IEnumerator<IDataPoint> m_dataReader;
        private string m_instanceName;
        private bool m_disposed;

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets instance name defined for this <see cref="LocalOutputAdapter"/>.
        /// </summary>
        [ConnectionStringParameter,
        Description("Define the instance name the archive to read. Leave this value blank to default to the adapter name."),
        DefaultValue("")]
        public string InstanceName
        {
            get
            {
                if (string.IsNullOrEmpty(m_instanceName))
                    return Name.ToLower();

                return m_instanceName;
            }
            set
            {
                m_instanceName = value;
            }
        }

        /// <summary>
        /// Gets or sets archive path for this <see cref="LocalOutputAdapter"/>.
        /// </summary>
        [ConnectionStringParameter,
        Description("Define the archive location (i.e., the file system path) of the historical data.")]
        public string ArchiveLocation
        {
            get
            {
                return m_archiveLocation;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(m_archiveLocation))
                    throw new ArgumentNullException("archiveLocation", "The archiveLocation setting must be specified.");

                m_archiveLocation = FilePath.GetDirectoryName(m_archiveLocation);
            }
        }

        /// <summary>
        /// Gets the flag indicating if this adapter supports temporal processing.
        /// </summary>
        public override bool SupportsTemporalProcessing
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets flag that determines if this <see cref="LocalInputAdapter"/> uses an asynchronous connection.
        /// </summary>
        protected override bool UseAsyncConnect
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the detailed status of the data input source.
        /// </summary>
        public override string Status
        {
            get
            {
                StringBuilder status = new StringBuilder();
                status.Append(base.Status);

                if (m_archiveFile != null)
                    status.Append(m_archiveFile.Status);

                return status.ToString();
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="LocalInputAdapter"/> object and optionally releases the managed resources.
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
                        if (m_readTimer != null)
                        {
                            m_readTimer.Elapsed -= m_readTimer_Elapsed;
                            m_readTimer.Dispose();
                        }
                        m_readTimer = null;

                        if (m_archiveFile != null)
                        {
                            m_archiveFile.Close();
                            m_archiveFile.Dispose();
                        }
                        m_archiveFile = null;
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
        /// Initializes this <see cref="RemoteInputAdapter"/>.
        /// </summary>
        /// <exception cref="ArgumentException"><b>HistorianID</b>, <b>Server</b>, <b>Port</b>, <b>Protocol</b>, or <b>InitiateConnection</b> is missing from the <see cref="AdapterBase.Settings"/>.</exception>
        public override void Initialize()
        {
            base.Initialize();

            Dictionary<string, string> settings = Settings;
            string errorMessage = "{0} is missing from settings - Example: instanceName=PPA; archiveLocation=C:\\Program Files\\openPDC\\Archive\\";

            // Validate settings.
            if (!settings.TryGetValue("instanceName", out m_instanceName))
                throw new ArgumentException(string.Format(errorMessage, "instanceName"));

            if (!settings.TryGetValue("archiveLocation", out m_archiveLocation))
                throw new ArgumentException(string.Format(errorMessage, "archiveLocation"));

            // Define output measurements this input adapter can support based on the instance name
            OutputSourceIDs = new string[] { m_instanceName };

            // Validate path name by assignment
            ArchiveLocation = m_archiveLocation;
        }

        /// <summary>
        /// Gets a short one-line status of this <see cref="RemoteInputAdapter"/>.
        /// </summary>
        /// <param name="maxLength">Maximum length of the status message.</param>
        /// <returns>Text of the status message.</returns>
        public override string GetShortStatus(int maxLength)
        {
            return ""; // string.Format("Received {0} bytes in {1} packets.", m_historianDataListener.TotalBytesReceived, m_historianDataListener.TotalPacketsReceived).CenterText(maxLength);
        }

        /// <summary>
        /// Attempts to connect to this <see cref="LocalInputAdapter"/>.
        /// </summary>
        protected override void AttemptConnection()
        {
            // This adapter is only engaged for history, so we don't process any data unless a temporal constraint is definecd
            if (this.TemporalConstraintIsDefined())
            {
                // Setup a read timer
                if (m_readTimer == null)
                {
                    m_readTimer = new System.Timers.Timer();
                    m_readTimer.Elapsed += m_readTimer_Elapsed;
                }

                m_readTimer.Enabled = false;
                m_readTimer.Interval = ProcessingInterval;

                // Attempt to open historian files
                const string StateFileName = "{0}{1}_startup.dat";
                const string IntercomFileName = "{0}scratch.dat";
                const string MetadataFileName = "{0}{1}_dbase.dat";

                if (Directory.Exists(m_archiveLocation))
                {
                    // Specified directory is a valid one.
                    string[] matches = Directory.GetFiles(m_archiveLocation, "*_archive.d");

                    if (matches.Length > 0)
                    {
                        // Capture the instance name
                        string folder = FilePath.GetDirectoryName(matches[0]);
                        string instance = FilePath.GetFileName(matches[0]).Split('_')[0];

                        // Setup historian reader
                        m_archiveFile = new ArchiveFile();
                        m_archiveFile.StateFile = new StateFile();
                        m_archiveFile.StateFile.FileAccessMode = FileAccess.Read;
                        m_archiveFile.StateFile.FileName = string.Format(StateFileName, folder, instance);

                        m_archiveFile.IntercomFile = new IntercomFile();
                        m_archiveFile.IntercomFile.FileAccessMode = FileAccess.Read;
                        m_archiveFile.IntercomFile.FileName = string.Format(IntercomFileName, folder);

                        m_archiveFile.MetadataFile = new MetadataFile();
                        m_archiveFile.MetadataFile.FileAccessMode = FileAccess.Read;
                        m_archiveFile.MetadataFile.FileName = string.Format(MetadataFileName, folder, instance);

                        // Capture active archive
                        m_archiveFile.FileAccessMode = FileAccess.Read;
                        m_archiveFile.FileName = matches[0];

                        m_archiveFile.HistoricFileListBuildStart += m_archiveFile_HistoricFileListBuildStart;
                        m_archiveFile.HistoricFileListBuildComplete += m_archiveFile_HistoricFileListBuildComplete;
                        m_archiveFile.HistoricFileListBuildException += m_archiveFile_HistoricFileListBuildException;
                        m_archiveFile.DataReadException += m_archiveFile_DataReadException;

                        // Open the active archive
                        m_archiveFile.Open();
                    }
                }
                else
                {
                    OnProcessException(new InvalidOperationException("Cannot open historian files, directory does not exist: " + m_archiveLocation));
                }
            }
        }

        /// <summary>
        /// Attempts to disconnect from this <see cref="LocalInputAdapter"/>.
        /// </summary>
        protected override void AttemptDisconnection()
        {
            if (m_readTimer != null)
                m_readTimer.Enabled = false;

            if (m_archiveFile != null)
            {
                m_archiveFile.Close();
                m_archiveFile.Dispose();
            }
            m_archiveFile = null;

            m_dataReader = null;
        }

        // Kick start read process for historian
        private void StartDataReader()
        {
            MeasurementKey[] inputMeasurementKeys = InputMeasurementKeys;

            if (inputMeasurementKeys != null && inputMeasurementKeys.Length > 0)
            {
                OnStatusMessage("Starting historical data read...");
                IEnumerable<int> historianIDs = inputMeasurementKeys.Select(key => unchecked((int)key.ID));
                m_dataReader = m_archiveFile.ReadData(historianIDs, StartTimeConstraint, StopTimeConstraint).GetEnumerator();
                m_readTimer.Enabled = true;
            }
            else
            {
                OnStatusMessage("No measurement keys have been requested for reading, historian reader is idle.");
            }
        }

        // Process next data read
        private void m_readTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (m_dataReader != null && m_dataReader.MoveNext())
            {

            }
            else
            {
                m_readTimer.Enabled = false;
            }
        }

        private void m_archiveFile_DataReadException(object sender, EventArgs<Exception> e)
        {
            OnProcessException(e.Argument);
        }

        private void m_archiveFile_HistoricFileListBuildException(object sender, EventArgs<Exception> e)
        {
            OnProcessException(e.Argument);
        }

        private void m_archiveFile_HistoricFileListBuildStart(object sender, EventArgs e)
        {
            OnStatusMessage("Building list of historic archive files...");
        }

        private void m_archiveFile_HistoricFileListBuildComplete(object sender, EventArgs e)
        {
            OnStatusMessage("Completed building list of historic archive files, starting data reader...");

            if (!m_readTimer.Enabled)
                StartDataReader();
        }

        #endregion
    }
}
