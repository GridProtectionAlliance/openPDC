//*******************************************************************************************************
//  LocalOutputAdapter.cs - Gbtc
//
//  Tennessee Valley Authority, 2009
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  This software is made freely available under the TVA Open Source Agreement (see below).
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  09/10/2009 - Pinal C. Patel
//       Generated original version of source code.
//  09/11/2009 - Pinal C. Patel
//       Added support to refresh metadata from one or more external sources.
//  09/15/2009 - Stephen C. Wills
//       Added new header and license agreement.
//  09/17/2009 - Pinal C. Patel
//       Added option to refresh metadata during connection.
//       Modified RefreshMetadata() to perform synchronous refresh.
//       Corrected the implementation of Dispose().
//  09/18/2009 - Pinal C. Patel
//       Added override to Status property and added event handler to archive rollver notification.
//  10/28/2009 - Pinal C. Patel
//       Modified to allow for multiple instances of the adapter to be loaded and configured with 
//       different settings by persisting the settings in the config file under unique categories.
//  11/18/2009 - Pinal C. Patel
//       Added support for the replication of local historian archive.
//  12/01/2009 - Pinal C. Patel
//       Modified Initialize() to load all available metadata providers.
//  12/03/2009 - Pinal C. Patel
//       Modified to use seperate ArchiveFile component for reading data to improve efficiency.
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
using System.IO;
using System.Text;
using System.Threading;
using TVA;
using TVA.Historian.DataServices;
using TVA.Historian.Files;
using TVA.Historian.MetadataProviders;
using TVA.Historian.Replication;
using TVA.IO;
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
        private ArchiveFile m_readArchive;
        private ArchiveFile m_writeArchive;
        private DataServices m_dataServices;
        private MetadataProviders m_metadataProviders;
        private ReplicationProviders m_replicationProviders;
        private bool m_refreshMetadata;
        private long m_archivedMeasurements;
        private bool m_disposed;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalOutputAdapter"/> class.
        /// </summary>
        public LocalOutputAdapter()
            : base()
        {
            m_refreshMetadata = true;
            // Instantiate archive file for writing data.
            m_writeArchive = new ArchiveFile();
            m_writeArchive.MetadataFile = new MetadataFile();
            m_writeArchive.StateFile = new StateFile();
            m_writeArchive.IntercomFile = new IntercomFile();
            // Instantiate archive file for reading data.
            m_readArchive = new ArchiveFile();
            m_readArchive.MetadataFile = m_writeArchive.MetadataFile;
            m_readArchive.StateFile = m_writeArchive.StateFile;
            m_readArchive.IntercomFile = m_writeArchive.IntercomFile;
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Returns the detailed status of the data output source.
        /// </summary>
        public override string Status
        {
            get
            {
                StringBuilder status = new StringBuilder();
                status.Append(base.Status);
                status.AppendLine();
                status.Append(m_writeArchive.Status);
                status.AppendLine();
                status.Append(m_writeArchive.MetadataFile.Status);
                status.AppendLine();
                status.Append(m_writeArchive.StateFile.Status);
                status.AppendLine();
                status.Append(m_writeArchive.IntercomFile.Status);

                return status.ToString();
            }
        }

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
                return true;
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
            bool queueEnabled = InternalProcessQueue.Enabled;
            try
            {
                InternalProcessQueue.Stop();
                // Synchronously refresh the metabase.
                lock (m_metadataProviders.Adapters)
                {
                    foreach (IMetadataProvider provider in m_metadataProviders.Adapters)
                    {
                        provider.Refresh();
                    }
                }

                // Wait for the metabase to synchronize.
                while (m_writeArchive.StateFile.RecordsOnDisk != m_writeArchive.MetadataFile.RecordsOnDisk)
                {
                    Thread.Sleep(100);
                }
            }
            finally
            {
                if (queueEnabled)
                    InternalProcessQueue.Start();
            }
        }

        /// <summary>
        /// Initializes this <see cref="LocalOutputAdapter"/>.
        /// </summary>
        /// <exception cref="ArgumentException"><b>InstanceName</b> is missing from the <see cref="AdapterBase.Settings"/>.</exception>
        public override void Initialize()
        {
            base.Initialize();

            string instanceName;
            string archivePath;
            string refreshMetadata;
            string errorMessage = "{0} is missing from Settings - Example: instanceName=XX;archivePath=c:\\;refreshMetadata=True";
            Dictionary<string, string> settings = Settings;

            // Validate settings.
            if (!settings.TryGetValue("instancename", out instanceName))
                throw new ArgumentException(string.Format(errorMessage, "instanceName"));
            
            if (!settings.TryGetValue("archivepath", out archivePath))
                archivePath = FilePath.GetAbsolutePath("");

            if (settings.TryGetValue("refreshmetadata", out refreshMetadata))
                m_refreshMetadata = refreshMetadata.ParseBoolean();

            // Initialize metadata file.           
            m_writeArchive.MetadataFile.FileName = Path.Combine(archivePath, instanceName + "_dbase.dat");
            m_writeArchive.MetadataFile.PersistSettings = true;
            m_writeArchive.MetadataFile.SettingsCategory = Name + m_writeArchive.MetadataFile.SettingsCategory;
            m_writeArchive.MetadataFile.Initialize();

            // Initialize state file.
            m_writeArchive.StateFile.FileName = Path.Combine(archivePath, instanceName + "_startup.dat");
            m_writeArchive.StateFile.PersistSettings = true;
            m_writeArchive.StateFile.SettingsCategory = Name + m_writeArchive.StateFile.SettingsCategory;
            m_writeArchive.StateFile.Initialize();

            // Initialize intercom file.
            m_writeArchive.IntercomFile.FileName = Path.Combine(archivePath, "scratch.dat");
            m_writeArchive.IntercomFile.PersistSettings = true;
            m_writeArchive.IntercomFile.SettingsCategory = Name + m_writeArchive.IntercomFile.SettingsCategory;
            m_writeArchive.IntercomFile.Initialize();

            // Initialize archive file for writing data.
            m_writeArchive.FileName = Path.Combine(archivePath, instanceName + "_archive.d");
            m_writeArchive.FileSize = 100;
            m_writeArchive.CompressData = false;
            m_writeArchive.PersistSettings = true;
            m_writeArchive.SettingsCategory = Name + m_writeArchive.SettingsCategory;
            m_writeArchive.RolloverStart += Archive_RolloverStart;
            m_writeArchive.RolloverComplete += Archive_RolloverComplete;
            m_writeArchive.RolloverException += Archive_RolloverException;
            m_writeArchive.Initialize();

            // Initialize archive file for reading data.
            m_readArchive.FileName = m_writeArchive.FileName;
            m_readArchive.FileAccessMode = FileAccess.Read;
            m_readArchive.Initialize();

            // Provide web service support.
            m_dataServices = new DataServices();
            m_dataServices.AdapterLoaded += DataServices_AdapterLoaded;
            m_dataServices.AdapterUnloaded += DataServices_AdapterUnloaded;
            m_dataServices.AdapterLoadException += AdapterLoader_AdapterLoadException;
            m_dataServices.Initialize();

            // Provide metadata sync support.
            m_metadataProviders = new MetadataProviders();
            m_metadataProviders.AdapterLoaded += MetadataProviders_AdapterLoaded;
            m_metadataProviders.AdapterUnloaded += MetadataProviders_AdapterUnloaded;
            m_metadataProviders.AdapterLoadException += AdapterLoader_AdapterLoadException;
            m_metadataProviders.Initialize();

            // Provide archive replication support.
            m_replicationProviders = new ReplicationProviders();
            m_replicationProviders.AdapterLoaded += ReplicationProviders_AdapterLoaded;
            m_replicationProviders.AdapterUnloaded += ReplicationProviders_AdapterUnloaded;
            m_replicationProviders.AdapterLoadException += AdapterLoader_AdapterLoadException;
            m_replicationProviders.Initialize();
        }

        /// <summary>
        /// Gets a short one-line status of this <see cref="LocalOutputAdapter"/>.
        /// </summary>
        /// <param name="maxLength">Maximum length of the status message.</param>
        /// <returns>Text of the status message.</returns>
        public override string GetShortStatus(int maxLength)
        {
            return string.Format("Archived {0} measurements locally.", m_archivedMeasurements).TruncateRight(maxLength);
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
                        if (m_dataServices != null)
                        {
                            m_dataServices.AdapterLoaded -= DataServices_AdapterLoaded;
                            m_dataServices.AdapterUnloaded -= DataServices_AdapterUnloaded;
                            m_dataServices.AdapterLoadException -= AdapterLoader_AdapterLoadException;
                            m_dataServices.Dispose();
                        }

                        if (m_metadataProviders != null)
                        {
                            m_metadataProviders.AdapterLoaded -= MetadataProviders_AdapterLoaded;
                            m_metadataProviders.AdapterUnloaded -= MetadataProviders_AdapterUnloaded;
                            m_metadataProviders.AdapterLoadException -= AdapterLoader_AdapterLoadException;
                            m_metadataProviders.Dispose();
                        }

                        if (m_replicationProviders != null)
                        {
                            m_replicationProviders.AdapterLoaded -= ReplicationProviders_AdapterLoaded;
                            m_replicationProviders.AdapterUnloaded -= ReplicationProviders_AdapterUnloaded;
                            m_replicationProviders.AdapterLoadException -= AdapterLoader_AdapterLoadException;
                            m_replicationProviders.Dispose();
                        }

                        if (m_writeArchive != null)
                        {
                            m_writeArchive.RolloverStart -= Archive_RolloverStart;
                            m_writeArchive.RolloverComplete -= Archive_RolloverComplete;
                            m_writeArchive.RolloverException -= Archive_RolloverException;
                            m_writeArchive.Dispose();

                            if (m_writeArchive.MetadataFile != null)
                            {
                                m_writeArchive.MetadataFile.Dispose();
                                m_writeArchive.MetadataFile = null;
                            }

                            if (m_writeArchive.StateFile != null)
                            {
                                m_writeArchive.StateFile.Dispose();
                                m_writeArchive.StateFile = null;
                            }

                            if (m_writeArchive.IntercomFile != null)
                            {
                                m_writeArchive.IntercomFile.Dispose();
                                m_writeArchive.IntercomFile = null;
                            }
                        }

                        if (m_readArchive != null)
                        {
                            m_readArchive.Dispose();
                            m_readArchive.MetadataFile = null;
                            m_readArchive.StateFile = null;
                            m_readArchive.IntercomFile = null;
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
            m_writeArchive.MetadataFile.Open();
            m_writeArchive.StateFile.Open();
            m_writeArchive.IntercomFile.Open();
            m_writeArchive.Open();
            m_readArchive.Open();

            if (m_refreshMetadata)
            {
                RefreshMetadata();
                m_refreshMetadata = false;
            }

            OnConnected();
        }

        /// <summary>
        /// Attempts to disconnect from this <see cref="LocalOutputAdapter"/>.
        /// </summary>
        protected override void AttemptDisconnection()
        {
            if (m_readArchive != null && m_readArchive.IsOpen)
                m_readArchive.Close();

            if (m_writeArchive != null)
            {
                if (m_writeArchive.IsOpen)
                {
                    m_writeArchive.Save();
                    m_writeArchive.Close();
                }

                if (m_writeArchive.MetadataFile != null && m_writeArchive.MetadataFile.IsOpen)
                {
                    m_writeArchive.MetadataFile.Save();
                    m_writeArchive.MetadataFile.Close();
                }

                if (m_writeArchive.StateFile != null && m_writeArchive.StateFile.IsOpen)
                {
                    m_writeArchive.StateFile.Save();
                    m_writeArchive.StateFile.Close();
                }

                if (m_writeArchive.IntercomFile != null && m_writeArchive.IntercomFile.IsOpen)
                {
                    m_writeArchive.IntercomFile.Save();
                    m_writeArchive.IntercomFile.Close();
                }

                OnDisconnected();
                m_archivedMeasurements = 0;
            }
        }

        /// <summary>
        /// Archives <paramref name="measurements"/> locally.
        /// </summary>
        /// <param name="measurements">Measurements to be archived.</param>
        /// <exception cref="InvalidOperationException">Local archive is closed.</exception>
        protected override void ProcessMeasurements(IMeasurement[] measurements)
        {
            if (!m_writeArchive.IsOpen)
                throw new InvalidOperationException("Archive is closed.");

            foreach (IMeasurement measurement in measurements)
            {
                m_writeArchive.WriteData(new ArchiveDataPoint(measurement));
            }
            m_archivedMeasurements += measurements.Length;
        }

        private void Archive_RolloverStart(object sender, EventArgs e)
        {
            // Close the archive file used for reading data.
            if (m_readArchive != null && m_readArchive.IsOpen)
                m_readArchive.Close();

            OnStatusMessage("Archive is being rolled over...");
        }

        private void Archive_RolloverComplete(object sender, EventArgs e)
        {
            // Re-open the archive file used for reading data.
            if (m_readArchive != null && !m_readArchive.IsOpen)
                m_readArchive.Open();

            OnStatusMessage("Archive rollover is complete.");
        }

        private void Archive_RolloverException(object sender, EventArgs<Exception> e)
        {
            OnProcessException(e.Argument);
            OnStatusMessage("Archive rollover failed - {0}", e.Argument.Message);
        }

        private void DataServices_AdapterLoaded(object sender, EventArgs<IDataService> e)
        {
            e.Argument.Archive = m_readArchive;
            e.Argument.ServiceProcessException += DataServices_ServiceProcessException;
            OnStatusMessage("{0} has been loaded.", e.Argument.GetType().Name);
        }

        private void DataServices_AdapterUnloaded(object sender, EventArgs<IDataService> e)
        {
            e.Argument.Archive = null;
            e.Argument.ServiceProcessException -= DataServices_ServiceProcessException;
            OnStatusMessage("{0} has been unloaded.", e.Argument.GetType().Name);
        }

        private void MetadataProviders_AdapterLoaded(object sender, EventArgs<IMetadataProvider> e)
        {
            e.Argument.Metadata = m_writeArchive.MetadataFile;
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

        private void ReplicationProviders_AdapterLoaded(object sender, EventArgs<IReplicationProvider> e)
        {
            e.Argument.ReplicationStart += ReplicationProvider_ReplicationStart;
            e.Argument.ReplicationComplete += ReplicationProvider_ReplicationComplete;
            e.Argument.ReplicationProgress += ReplicationProvider_ReplicationProgress;
            e.Argument.ReplicationException += ReplicationProvider_ReplicationException;
            OnStatusMessage("{0} has been loaded.", e.Argument.GetType().Name);
        }

        private void ReplicationProviders_AdapterUnloaded(object sender, EventArgs<IReplicationProvider> e)
        {
            e.Argument.ReplicationStart -= ReplicationProvider_ReplicationStart;
            e.Argument.ReplicationComplete -= ReplicationProvider_ReplicationComplete;
            e.Argument.ReplicationProgress -= ReplicationProvider_ReplicationProgress;
            e.Argument.ReplicationException -= ReplicationProvider_ReplicationException;
            OnStatusMessage("{0} has been unloaded.", e.Argument.GetType().Name);
        }

        private void AdapterLoader_AdapterLoadException(object sender, EventArgs<Type, Exception> e)
        {
            OnStatusMessage("{0} could not be loaded - {1}", e.Argument1.Name, e.Argument2.Message);
        }

        private void DataServices_ServiceProcessException(object sender, EventArgs<Exception> e)
        {
            OnProcessException(e.Argument);
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
        }

        private void ReplicationProvider_ReplicationStart(object sender, EventArgs e)
        {
            OnStatusMessage("{0} has started archive replication...", sender.GetType().Name);
        }

        private void ReplicationProvider_ReplicationComplete(object sender, EventArgs e)
        {
            OnStatusMessage("{0} has finished archive replication.", sender.GetType().Name);
        }

        private void ReplicationProvider_ReplicationProgress(object sender, EventArgs<ProcessProgress<int>> e)
        {
            OnStatusMessage("{0} has replicated archive file {1}.", sender.GetType().Name, e.Argument.ProgressMessage);
        }

        private void ReplicationProvider_ReplicationException(object sender, EventArgs<Exception> e)
        {
            OnProcessException(e.Argument);
        }

        #endregion
    }
}
