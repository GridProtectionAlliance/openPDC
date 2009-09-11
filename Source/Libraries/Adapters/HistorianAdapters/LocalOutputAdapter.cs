//*******************************************************************************************************
//  LocalOutputAdapter.cs
//  Copyright © 2009 - TVA, all rights reserved - Gbtc
//
//  Build Environment: C#, Visual Studio 2008
//  Primary Developer: Pinal C. Patel
//      Office: PSO TRAN & REL, CHATTANOOGA - MR BK-C
//       Phone: 423/751-3024
//       Email: pcpatel@tva.gov
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  09/10/2009 - Pinal C. Patel
//       Generated original version of source code.
//  09/11/2009 - Pinal C. Patel
//       Added support to refresh metadata from one or more external sources.
//
//*******************************************************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using TVA;
using TVA.Historian.Files;
using TVA.Historian.MetadataProviders;
using TVA.Historian.Services;
using TVA.Measurements;
using TVA.Measurements.Routing;

namespace HistorianAdapters
{
    /// <summary>
    /// Represents an output adapter that archives measurements to a local archive.
    /// </summary>
    public class LocalOutputAdapter : OutputAdapterBase
    {
        #region [ Members ]

        // Fields
        private ArchiveFile m_archive;
        private Services m_archiveServices;
        private MetadataProviders m_metadataProviders;
        private long m_measurementsArchived;
        private bool m_disposed;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalOutputAdapter"/> class.
        /// </summary>
        public LocalOutputAdapter()
            : base()
        {
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Returns a flag that determines if measurements sent to this <see cref="LocalOutputAdapter"/> are destined for archival.
        /// </summary>
        public override bool OutputIsForArchive
        {
            get 
            {
                return true;
            }
        }

        /// <summary>
        /// Gets flag that determines if this <see cref="LocalOutputAdapter"/> uses an asynchronous connection.
        /// </summary>
        protected override bool UseAsyncConnect
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Refreshes metadata using all available and enabled providers.
        /// </summary>
        [AdapterCommand("Refreshes metadata using all available and enabled providers.")]
        public void RefreshMetadata()
        {
            m_metadataProviders.RefreshAll();
        }

        /// <summary>
        /// Initializes this <see cref="LocalOutputAdapter"/>.
        /// </summary>
        /// <exception cref="ArgumentException"><b>ArchivePath</b> or <b>InstanceName</b> is missing from the <see cref="AdapterBase.Settings"/>.</exception>
        public override void Initialize()
        {
            string archivePath;
            string instanceName;
            Dictionary<string, string> settings = Settings;

            // Validate settings.
            if (!settings.TryGetValue("archivepath", out archivePath))
                throw new ArgumentException("ArchivePath is missing. Example: ArchivePath=c:\\;InstanceName=XX");

            if (!settings.TryGetValue("instancename", out instanceName))
                throw new ArgumentException("InstanceName is missing. Example: ArchivePath=c:\\;InstanceName=XX");

            // Initialize metadata file.
            MetadataFile metadataFile = new MetadataFile();          
            metadataFile.FileName = Path.Combine(archivePath, instanceName + "_dbase.dat");
            metadataFile.PersistSettings = true;
            metadataFile.Initialize();

            // Initialize state file.
            StateFile stateFile = new StateFile();
            stateFile.FileName = Path.Combine(archivePath, instanceName + "_startup.dat");
            stateFile.PersistSettings = true;
            stateFile.Initialize();

            // Initialize intercom file.
            IntercomFile intercomFile = new IntercomFile();
            intercomFile.FileName = Path.Combine(archivePath, "scratch.dat");
            intercomFile.PersistSettings = true;
            intercomFile.Initialize();

            // Initialize data archive file.
            m_archive = new ArchiveFile();
            m_archive.FileName = Path.Combine(archivePath, instanceName + "_archive.d");
            m_archive.PersistSettings = true;
            m_archive.MetadataFile = metadataFile;
            m_archive.StateFile = stateFile;
            m_archive.IntercomFile = intercomFile;
            m_archive.Initialize();

            // Provide web service support.
            m_archiveServices = new Services();
            m_archiveServices.AdapterLoaded += ArchiveServices_AdapterLoaded;
            m_archiveServices.AdapterUnloaded += ArchiveServices_AdapterUnloaded;
            m_archiveServices.Initialize();

            // Provide metadata sync support.
            m_metadataProviders = new MetadataProviders();
            m_metadataProviders.AdapterLoaded += MetadataProviders_AdapterLoaded;
            m_metadataProviders.AdapterUnloaded += MetadataProviders_AdapterUnloaded;
            m_metadataProviders.Initialize();
        }

        /// <summary>
        /// Gets a short one-line status of this <see cref="LocalOutputAdapter"/>.
        /// </summary>
        /// <param name="maxLength">Maximum length of the status message.</param>
        /// <returns>Text of the status message.</returns>
        public override string GetShortStatus(int maxLength)
        {
            return string.Format("Archived {0} measurements locally...", m_measurementsArchived).CenterText(maxLength);
        }

        /// <summary>
        /// Releases the unmanaged resources used by this <see cref="LocalOutputAdapter"/> and optionally releases the managed resources.
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
                        if (m_archiveServices != null)
                        {
                            m_archiveServices.Dispose();
                            m_archiveServices.AdapterLoaded -= ArchiveServices_AdapterLoaded;
                            m_archiveServices.AdapterUnloaded -= ArchiveServices_AdapterUnloaded;
                        }

                        if (m_metadataProviders != null)
                        {
                            m_metadataProviders.Dispose();
                            m_metadataProviders.AdapterLoaded -= MetadataProviders_AdapterLoaded;
                            m_metadataProviders.AdapterUnloaded -= MetadataProviders_AdapterUnloaded;
                        }

                        if (m_archive != null)
                        {
                            m_archive.MetadataFile = null;
                            m_archive.StateFile = null;
                            m_archive.IntercomFile = null;
                            m_archive.Dispose();

                            if (m_archive.MetadataFile != null)
                                m_archive.MetadataFile.Dispose();

                            if (m_archive.StateFile != null)
                                m_archive.StateFile.Dispose();

                            if (m_archive.IntercomFile != null)
                                m_archive.IntercomFile.Dispose();
                        }
                    }
                }
                finally
                {
                    base.Dispose(disposing);    // Call base class Dispose().
                    m_disposed = true;          // Prevent duplicate dispose.
                }
            }
        }

        /// <summary>
        /// Attempts to connect to this <see cref="LocalOutputAdapter"/>.
        /// </summary>
        protected override void AttemptConnection()
        {
            m_archive.MetadataFile.Open();
            m_archive.StateFile.Open();
            m_archive.IntercomFile.Open();
            m_archive.Open();
        }

        /// <summary>
        /// Attempts to disconnect from this <see cref="LocalOutputAdapter"/>.
        /// </summary>
        protected override void AttemptDisconnection()
        {
            m_archive.Save();
            m_archive.Close();
            m_archive.MetadataFile.Save();
            m_archive.MetadataFile.Close();
            m_archive.StateFile.Save();
            m_archive.StateFile.Close();
            m_archive.IntercomFile.Save();
            m_archive.IntercomFile.Close();
        }

        /// <summary>
        /// Archives <paramref name="measuremsnts"/> locally.
        /// </summary>
        /// <param name="measurements">Measurements to be archived.</param>
        /// <exception cref="InvalidOperationException">Local archive is closed.</exception>
        protected override void ProcessMeasurements(IMeasurement[] measurements)
        {
            if (!m_archive.IsOpen)
                throw new InvalidOperationException("Archive is closed.");

            foreach (IMeasurement measurement in measurements)
            {
                m_archive.WriteData(new ArchiveData(measurement));
            }
            m_measurementsArchived += measurements.Length;
        }

        private void ArchiveServices_AdapterLoaded(object sender, EventArgs<IService> e)
        {
            e.Argument.Archive = m_archive;
            e.Argument.ServiceProcessError += ArchiveServices_ServiceProcessError;
            OnStatusMessage("{0} has been loaded.", e.Argument.GetType().Name);
        }

        private void ArchiveServices_AdapterUnloaded(object sender, EventArgs<IService> e)
        {
            e.Argument.Archive = null;
            e.Argument.ServiceProcessError -= ArchiveServices_ServiceProcessError;
            OnStatusMessage("{0} has been unloaded.", e.Argument.GetType().Name);
        }

        private void ArchiveServices_ServiceProcessError(object sender, EventArgs<Exception> e)
        {
            OnProcessException(e.Argument);
        }

        private void MetadataProviders_AdapterLoaded(object sender, EventArgs<IMetadataProvider> e)
        {
            e.Argument.Metadata = m_archive.MetadataFile;
            e.Argument.MetadataRefreshStart += MetadataProviders_MetadataRefreshStart;
            e.Argument.MetadataRefreshComplete += MetadataProviders_MetadataRefreshComplete;
            e.Argument.MetadataRefreshTimeout += MetadataProviders_MetadataRefreshTimeout;
            e.Argument.MetadataRefreshException += MetadataProviders_MetadataRefreshException;
            OnStatusMessage("{0} has been loaded.", e.Argument.GetType().Name);
        }

        private void MetadataProviders_AdapterUnloaded(object sender, EventArgs<IMetadataProvider> e)
        {
            e.Argument.Metadata = null;
            e.Argument.MetadataRefreshStart -= MetadataProviders_MetadataRefreshStart;
            e.Argument.MetadataRefreshComplete -= MetadataProviders_MetadataRefreshComplete;
            e.Argument.MetadataRefreshTimeout -= MetadataProviders_MetadataRefreshTimeout;
            e.Argument.MetadataRefreshException -= MetadataProviders_MetadataRefreshException;
            OnStatusMessage("{0} has been unloaded.", e.Argument.GetType().Name);
        }

        private void MetadataProviders_MetadataRefreshStart(object sender, EventArgs e)
        {
            OnStatusMessage("{0} has started metadata refresh...", sender.GetType().Name);
        }

        private void MetadataProviders_MetadataRefreshComplete(object sender, EventArgs e)
        {
            OnStatusMessage("{0} has finished metadata refresh.", sender.GetType().Name);
        }

        private void MetadataProviders_MetadataRefreshTimeout(object sender, EventArgs e)
        {
            OnStatusMessage("{0} has timed-out on metadata refresh.", sender.GetType().Name);
        }

        private void MetadataProviders_MetadataRefreshException(object sender, EventArgs<Exception> e)
        {
            OnProcessException(e.Argument);
            OnStatusMessage("{0} has encountered an exception on metadata refresh.", sender.GetType().Name);
        }

        #endregion
    }
}
