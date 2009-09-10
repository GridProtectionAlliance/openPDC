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
//
//*******************************************************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using TVA;
using TVA.Historian.Files;
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

            // Create dependency files.
            MetadataFile metadataFile = new MetadataFile();
            metadataFile.FileName = Path.Combine(archivePath, instanceName + "_dbase.dat");
            StateFile stateFile = new StateFile();
            stateFile.FileName = Path.Combine(archivePath, instanceName + "_startup.dat");
            IntercomFile intercomFile = new IntercomFile();
            intercomFile.FileName = Path.Combine(archivePath, "scratch.dat");

            // Create data archive file.
            m_archive = new ArchiveFile();
            m_archive.FileName = Path.Combine(archivePath, instanceName + "_archive.d");
            m_archive.MetadataFile = metadataFile;
            m_archive.StateFile = stateFile;
            m_archive.IntercomFile = intercomFile;

            // Provide web service support.
            m_archiveServices = new Services();
            m_archiveServices.AdapterLoaded += ArchiveServices_AdapterLoaded;
            m_archiveServices.AdapterUnloaded += ArchiveServices_AdapterUnloaded;
            m_archiveServices.Initialize();
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
                    if (disposing)
                    {
                        // Stop web services.
                        m_archiveServices.AdapterLoaded -= ArchiveServices_AdapterLoaded;
                        m_archiveServices.AdapterUnloaded -= ArchiveServices_AdapterUnloaded;
                        m_archiveServices.Dispose();

                        // Close all the files.
                        m_archive.Dispose();
                        m_archive.MetadataFile.Dispose();
                        m_archive.StateFile.Dispose();
                        m_archive.IntercomFile.Dispose();
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
            m_archive.Close();
            m_archive.MetadataFile.Close();
            m_archive.StateFile.Close();
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
            OnStatusMessage("{0} web services has been loaded.", e.Argument.GetType().Name);
        }

        private void ArchiveServices_AdapterUnloaded(object sender, EventArgs<IService> e)
        {
            e.Argument.Archive = null;
            e.Argument.ServiceProcessError -= ArchiveServices_ServiceProcessError;
            OnStatusMessage("{0} web services has been unloaded.", e.Argument.GetType().Name);
        }

        private void ArchiveServices_ServiceProcessError(object sender, EventArgs<Exception> e)
        {
            // Notify of the exception encountered when processing a web service request.
            OnProcessException(e.Argument);
        }

        #endregion
    }
}
