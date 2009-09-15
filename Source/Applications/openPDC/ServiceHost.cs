//*******************************************************************************************************
//  ServiceHost.cs - Gbtc
//
//  Tennessee Valley Authority, 2009
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  This software is made freely available under the TVA Open Source Agreement (see below).
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  05/04/2009 - J. Ritchie Carroll
//       Generated original version of source code.
//  9/15/2009 - Stephen C. Wills
//       Added new header and license agreement.
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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using TVA;
using TVA.Collections;
using TVA.Configuration;
using TVA.Data;
using TVA.IO;
using TVA.Measurements;
using TVA.Measurements.Routing;
using TVA.Reflection;
using TVA.Security.Cryptography;
using TVA.Services;

namespace openPDC
{
    #region [ Enumerations ]

    /// <summary>
    /// Configuration data source type enumeration.
    /// </summary>
    public enum ConfigurationType
    {
        /// <summary>
        /// Configuration source is a database.
        /// </summary>
        Database,
        /// <summary>
        /// Configuration source is a webservice.
        /// </summary>
        WebService,
        /// <summary>
        /// Configuration source is a XML file.
        /// </summary>
        XmlFile
    }

    #endregion

    public partial class ServiceHost : ServiceBase
    {
        #region [ Members ]

        // Fields

        // Input, action and output adapters
        private AllAdaptersCollection m_allAdapters;
        private InputAdapterCollection m_inputAdapters;
        private ActionAdapterCollection m_actionAdapters;
        private OutputAdapterCollection m_outputAdapters;

        // System settings
        private Guid m_nodeID;
        private string m_nodeIDQueryString;
        private DataSet m_configuration;
        private ConfigurationType m_configurationType;
        private string m_connectionString;
        private string m_dataProvider;
        private string m_cachedConfigurationFile;
        private bool m_uniqueAdapterIDs;

        // Broadcast message settings
        private ProcessQueue<string> m_statusMessageQueue;
        private Ticks m_lastDisplayedMessageTime;
        private long m_displayedMessageCount;
        private int m_messageDisplayTimepan;
        private int m_maximumMessagesToDisplay;

        // Threshold settings
        private int m_measurementWarningThreshold;
        private int m_measurementDumpingThreshold;
        private int m_defaultSampleSizeWarningThreshold;

        // Health and status exporters
        private MultipleDestinationExporter m_healthExporter;
        private MultipleDestinationExporter m_statusExporter;

        #endregion
        
        #region [ Constructors ]

        /// <summary>
        /// Creates a new <see cref="ServiceHost"/>.
        /// </summary>
        public ServiceHost()
            : base()
        {
            InitializeComponent();

            // Register event handlers.
            m_serviceHelper.ServiceStarting += ServiceStartingHandler;
            m_serviceHelper.ServiceStarted += ServiceStartedHandler;
            m_serviceHelper.ServiceStopping += ServiceStoppingHandler;
            m_serviceHelper.StatusLog.LogException += ProcessExceptionHandler;
            m_serviceHelper.ErrorLogger.ErrorLog.LogException += ProcessExceptionHandler;
        }

        /// <summary>
        /// Creates a new <see cref="ServiceHost"/> from specified parameters.
        /// </summary>
        /// <param name="container">Service host <see cref="IContainer"/>.</param>
        public ServiceHost(IContainer container)
            : this()
        {
            if (container != null)
                container.Add(this);
        }

        #endregion

        #region [ Methods ]

        #region [ Service Event Handlers ]

        // As service is starting we load settings from configuration file
        private void ServiceStartingHandler(object sender, EventArgs<string[]> e)
        {
            // Make sure default service settings exist
            ConfigurationFile configFile = ConfigurationFile.Current;

            // Remoting server settings
            CategorizedSettingsElementCollection remotingServerSettings = configFile.Settings[m_remotingServer.SettingsCategory];

            // System settings
            CategorizedSettingsElementCollection systemSettings = configFile.Settings["systemSettings"];
            systemSettings.Add("NodeID", Guid.NewGuid().ToString(), "Unique Node ID");
            systemSettings.Add("ConfigurationType", "Database", "Specifies type of configuration: Database, WebService or XmlFile");
            systemSettings.Add("ConnectionString", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=openPDC.mdb", "Configuration database connection string");
            systemSettings.Add("DataProvider", "AssemblyName={System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089};ConnectionType=System.Data.OleDb.OleDbConnection;AdapterType=System.Data.OleDb.OleDbDataAdapter", "Configuration database .NET provider string");
            systemSettings.Add("CachedConfigurationFile", "SystemConfiguration.xml", "File name for last known good system configuration (only cached for a Database or WebService connection)");
            systemSettings.Add("Example.SqlServer.ConnectionString", "Data Source=serverName;Initial Catalog=openPDC;User Id=userName;Password=password;AssemblyName=System.Data;ConnectionType=System.Data.SqlClient.SqlConnection;AdapterType=System.Data.SqlClient.SqlDataAdapter", "Example SQL Server database connection string");
            systemSettings.Add("Example.MicrosoftAccess.ConnectionString", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=openPDC.mdb;AssemblyName=System.Data;ConnectionType=System.Data.OleDb.OleDbConnection;AdapterType=System.Data.OleDb.OleDbDataAdapter", "Example Microsoft Access database connection string");
            systemSettings.Add("Example.MySQL.ConnectionString", "Server=serverName;Database=openPDC;Uid=root;Pwd=password;AssemblyName=MySql.Data;ConnectionType=MySql.Data.MySqlClient.MySqlConnection;AdapterType=MySql.Data.MySqlClient.MySqlDataAdapter", "Example MySQL database connection string");
            systemSettings.Add("Example.Oracle.ConnectionString", "Data Source=openPDC;User Id=username;Password=password;Integrated Security=no;AssemblyName=System.Data.OracleClient;ConnectionType=System.Data.OracleClient.OracleConnection;AdapterType=System.Data.OracleClient.OracleDataAdapter", "Example Oracle database connection string");
            systemSettings.Add("Example.WebService.ConnectionString", "https://naspi.tva.com/openPDC/LoadConfigurationData.aspx", "Example web service connection string");
            systemSettings.Add("Example.XmlFile.ConnectionString", "SystemConfiguration.xml", "Example XML configuration file connection string");
            systemSettings.Add("UniqueAdaptersIDs", "True", "Set to true if all runtime adapter ID's will be unique to allow for easier adapter specification");

            // Broadcast message settings
            CategorizedSettingsElementCollection broadcastMessageSettings = configFile.Settings["broadcastMessageSettings"];
            broadcastMessageSettings.Add("MessageDisplayTimespan", "2", "Timespan, in seconds, over which to monitor message volume");
            broadcastMessageSettings.Add("MaximumMessagesToDisplay", "100", "Maximum number of messages to be tolerated during MessageDisplayTimespan");

            // Threshold settings
            CategorizedSettingsElementCollection thresholdSettings = configFile.Settings["thresholdSettings"];
            thresholdSettings.Add("MeasurementWarningThreshold", "100000", "Number of unarchived measurements allowed in any output adapter queue before displaying a warning message");
            thresholdSettings.Add("MeasurementDumpingThreshold", "500000", "Number of unarchived measurements allowed in any output adapter queue before taking evasive action and dumping data");
            thresholdSettings.Add("DefaultSampleSizeWarningThreshold", "10", "Default number of unpublished samples (in seconds) allowed in any action adapter queue before displaying a warning message");
            
            // Define configuration cache sub-directory
            string cachePath = string.Format("{0}\\ConfigurationCache\\", FilePath.GetAbsolutePath(""));

            // Make sure configuration cache directory exists
            if (!Directory.Exists(cachePath))
                Directory.CreateDirectory(cachePath);

            // Initialize system settings
            m_nodeID = systemSettings["NodeID"].ValueAs<Guid>();
            m_configurationType = systemSettings["ConfigurationType"].ValueAs<ConfigurationType>();
            m_connectionString = systemSettings["ConnectionString"].Value;
            m_dataProvider = systemSettings["DataProvider"].Value;
            m_cachedConfigurationFile = cachePath + systemSettings["CachedConfigurationFile"].Value;
            m_uniqueAdapterIDs = systemSettings["UniqueAdaptersIDs"].ValueAsBoolean(true);

            // Define guid with query string delimeters according to database needs
            Dictionary<string, string> settings = m_connectionString.ParseKeyValuePairs();
            string setting;

            if (settings.TryGetValue("Provider", out setting))
                if (setting.StartsWith("Microsoft.Jet.OLEDB", StringComparison.CurrentCultureIgnoreCase))
                    m_nodeIDQueryString = "{" + m_nodeID + "}";

            if (string.IsNullOrEmpty(m_nodeIDQueryString))
                m_nodeIDQueryString = "'" + m_nodeID + "'";

            // Initialize broadcast message settings
            m_messageDisplayTimepan = broadcastMessageSettings["MessageDisplayTimespan"].ValueAsInt32();
            m_maximumMessagesToDisplay = broadcastMessageSettings["MaximumMessagesToDisplay"].ValueAsInt32();
            m_lastDisplayedMessageTime = DateTime.Now.Ticks;

            // Initialize threshold settings
            m_measurementWarningThreshold = thresholdSettings["MeasurementWarningThreshold"].ValueAsInt32();
            m_measurementDumpingThreshold = thresholdSettings["MeasurementDumpingThreshold"].ValueAsInt32();
            m_defaultSampleSizeWarningThreshold = thresholdSettings["DefaultSampleSizeWarningThreshold"].ValueAsInt32();

            // Create status message queue
            m_statusMessageQueue = ProcessQueue<string>.CreateSynchronousQueue(StatusMessageQueueHandler);
            m_statusMessageQueue.ProcessException += StatusMessageQueueExceptionHandler;
            m_statusMessageQueue.Start();
        }

        // Once service has successfully started we handle system initialization
        private void ServiceStartedHandler(object sender, EventArgs e)
        {
            // Log startup information
            m_serviceHelper.UpdateStatus(
                "\r\n\r\n{0}\r\n\r\nNode {{{1}}} Initializing\r\n\r\nUTC System Timestamp: {2}\r\n\r\nCurrent system file path:\r\n\r\n{3}\r\n\r\n{4}\r\n",
                new string('*', 80),
                m_nodeID,
                DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                FilePath.GetAbsolutePath(""),
                new string('*', 80));

            // Create health exporter
            m_healthExporter = new MultipleDestinationExporter("HealthExporter", Timeout.Infinite);
            m_healthExporter.Initialize(new ExportDestination[] { new ExportDestination(FilePath.GetAbsolutePath("Health.txt"), false, "", "", "") });
            m_healthExporter.StatusMessage += StatusMessageHandler;
            m_serviceHelper.ServiceComponents.Add(m_healthExporter);
            
            // Create status exporter
            m_statusExporter = new MultipleDestinationExporter("StatusExporter", Timeout.Infinite);
            m_statusExporter.Initialize(new ExportDestination[] { new ExportDestination(FilePath.GetAbsolutePath("Status.txt"), false, "", "", "") });
            m_statusExporter.StatusMessage += StatusMessageHandler;
            m_serviceHelper.ServiceComponents.Add(m_statusExporter);

            // Define scheduled service processes
            m_serviceHelper.AddScheduledProcess(HealthMonitorProcessHandler, "HealthMonitor", "* * * * *");    // Every minute
            m_serviceHelper.AddScheduledProcess(StatusExportProcessHandler, "StatusExport", "*/30 * * * *");   // Every 30 minutes

            // Create a collection to manage all input, action and output adapter collections as a unit
            m_allAdapters = new AllAdaptersCollection();
            m_allAdapters.StatusMessage += StatusMessageHandler;
            m_allAdapters.ProcessException += ProcessExceptionHandler;

            // Create input adapters collection
            m_inputAdapters = new InputAdapterCollection();
            m_inputAdapters.NewMeasurements += NewMeasurementsHandler;
            m_allAdapters.Add(m_inputAdapters);
            m_serviceHelper.ServiceComponents.Add(m_inputAdapters);

            // Create action adapters collection
            m_actionAdapters = new ActionAdapterCollection();
            m_actionAdapters.NewMeasurements += NewMeasurementsHandler;
            m_actionAdapters.UnpublishedSamples += UnpublishedSamplesHandler;
            m_allAdapters.Add(m_actionAdapters);
            m_serviceHelper.ServiceComponents.Add(m_actionAdapters);

            // Create output adapters collection
            m_outputAdapters = new OutputAdapterCollection();
            m_outputAdapters.UnprocessedMeasurements += UnprocessedMeasurementsHandler;
            m_allAdapters.Add(m_outputAdapters);
            m_serviceHelper.ServiceComponents.Add(m_outputAdapters);

            // Define remote client requests (i.e., console commands)
            m_serviceHelper.ClientRequestHandlers.Add(new ClientRequestHandler("List", "Displays status for specified adapter or collection", ListRequestHandler));
            m_serviceHelper.ClientRequestHandlers.Add(new ClientRequestHandler("Connect", "Connects (or starts) specified adapter", StartRequestHandler));
            m_serviceHelper.ClientRequestHandlers.Add(new ClientRequestHandler("Disconnect", "Disconnects (or stops) specified adapter", StopRequestHandler));
            m_serviceHelper.ClientRequestHandlers.Add(new ClientRequestHandler("Invoke", "Invokes a command for specified adapter", InvokeRequestHandler));
            m_serviceHelper.ClientRequestHandlers.Add(new ClientRequestHandler("ListCommands", "Displays possible commands for specified adapter", ListCommandsRequestHandler));
            m_serviceHelper.ClientRequestHandlers.Add(new ClientRequestHandler("Initialize", "Initializes specified adapter or collection", InitializeRequestHandler));
            m_serviceHelper.ClientRequestHandlers.Add(new ClientRequestHandler("ReloadConfig", "Manually reloads the system configuration", ReloadConfigRequstHandler));
            m_serviceHelper.ClientRequestHandlers.Add(new ClientRequestHandler("Authenticate", "Authenticates network shares for health and status exports", AuthenticateRequestHandler));

            // Start system initialization on an independent thread so that service responds in a timely fashion...
            ThreadPool.QueueUserWorkItem(InitializeSystem);

            // If any settings were added to configuration file, we go ahead and save them now
            m_serviceHelper.SaveSettings(true);
            ConfigurationFile.Current.Save();
        }

        // As service is stopping we un-wire events and dispose of key classes
        private void ServiceStoppingHandler(object sender, EventArgs e)
        {
            // Dispose system health exporter
            if (m_healthExporter != null)
            {
                m_healthExporter.Enabled = false;
                m_serviceHelper.ServiceComponents.Remove(m_healthExporter);
                m_healthExporter.StatusMessage -= StatusMessageHandler;
                m_healthExporter.Dispose();
            }
            m_healthExporter = null;

            // Dispose system status exporter
            if (m_statusExporter != null)
            {
                m_statusExporter.Enabled = false;
                m_serviceHelper.ServiceComponents.Remove(m_statusExporter);
                m_statusExporter.StatusMessage -= StatusMessageHandler;
                m_statusExporter.Dispose();
            }
            m_statusExporter = null;

            // Dispose input adapters collection
            if (m_inputAdapters != null)
            {
                m_inputAdapters.Stop();
                m_serviceHelper.ServiceComponents.Remove(m_inputAdapters);
                m_inputAdapters.NewMeasurements -= NewMeasurementsHandler;
                m_inputAdapters.Dispose();
            }
            m_inputAdapters = null;

            // Dispose action adapters collection
            if (m_actionAdapters != null)
            {
                m_actionAdapters.Stop();
                m_serviceHelper.ServiceComponents.Remove(m_actionAdapters);
                m_actionAdapters.NewMeasurements -= NewMeasurementsHandler;
                m_actionAdapters.UnpublishedSamples -= UnpublishedSamplesHandler;
                m_actionAdapters.Dispose();
            }
            m_actionAdapters = null;

            // Dispose output adapters collection
            if (m_outputAdapters != null)
            {
                m_outputAdapters.Stop();
                m_serviceHelper.ServiceComponents.Remove(m_outputAdapters);
                m_outputAdapters.UnprocessedMeasurements -= UnprocessedMeasurementsHandler;
                m_outputAdapters.Dispose();
            }
            m_outputAdapters = null;

            // Dispose all adapters collection
            if (m_allAdapters != null)
            {
                m_allAdapters.StatusMessage -= StatusMessageHandler;
                m_allAdapters.ProcessException -= ProcessExceptionHandler;
                m_allAdapters.Dispose();
            }
            m_allAdapters = null;

            // Dispose status message queue
            if (m_statusMessageQueue != null)
            {
                m_statusMessageQueue.Stop();
                m_statusMessageQueue.ProcessException -= StatusMessageQueueExceptionHandler;
                m_statusMessageQueue.Dispose();
            }
            m_statusMessageQueue = null;
        }

        #endregion

        #region [ System Initialization ]

        // Perform system initialization
        private void InitializeSystem(object state)
        {
            // Attempt to load system configuration
            if (LoadSystemConfiguration())
            {
                // Initialize all adapters
                m_allAdapters.Initialize();

                // Start all adapters
                m_allAdapters.Start();

                DisplayStatusMessage("System initialization complete.");
            }
            else
                DisplayStatusMessage("System initialization failed due to unavailable configuration.");
        }

        // Load the the system configuration data set
        private bool LoadSystemConfiguration()
        {
            DisplayStatusMessage("Loading system configuration...");

            // Attempt to load (or reload) system configuration
            m_configuration = GetConfigurationDataSet(m_configurationType, m_connectionString);

            if (m_configuration != null)
            {
                // Update data source on all adapters in all collections
                m_allAdapters.DataSource = m_configuration;
                return true;
            }

            return false;
        }

        // Load system configuration data set
        private DataSet GetConfigurationDataSet(ConfigurationType configType, string connectionString)
        {
            DataSet configuration = null;
            DataTable entities, entity;

            switch (configType)
            {
                case ConfigurationType.Database:
                    // Attempt to load configuration from a database connection
                    IDbConnection connection = null;
                    Dictionary<string, string> settings;
                    string assemblyName, connectionTypeName, adapterTypeName;
                    Assembly assembly;
                    Type connectionType, adapterType;

                    try
                    {
                        settings = m_dataProvider.ParseKeyValuePairs();
                        assemblyName = settings["AssemblyName"].ToNonNullString();
                        connectionTypeName = settings["ConnectionType"].ToNonNullString();
                        adapterTypeName = settings["AdapterType"].ToNonNullString();

                        if (string.IsNullOrEmpty(connectionTypeName))
                            throw new InvalidOperationException("Database connection type was not defined.");

                        if (string.IsNullOrEmpty(adapterTypeName))
                            throw new InvalidOperationException("Database adapter type was not defined.");

                        assembly = Assembly.Load(new AssemblyName(assemblyName));
                        connectionType = assembly.GetType(connectionTypeName);
                        adapterType = assembly.GetType(adapterTypeName);
                        
                        connection = (IDbConnection)Activator.CreateInstance(connectionType);
                        connection.ConnectionString = m_connectionString;
                        connection.Open();

                        DisplayStatusMessage("Database configuration connection opened.");

                        configuration = new DataSet("Iaon");

                        // Load configuration entities defined in database
                        entities = connection.RetrieveData(adapterType, "SELECT * FROM ConfigurationEntity WHERE Enabled <> 0 ORDER BY LoadOrder");
                        entities.TableName = "ConfigurationEntity";
                        
                        // Add configuration entities table to system configuration for reference
                        configuration.Tables.Add(entities.Copy());

                        // Add each configuration entity to the system configuration
                        foreach (DataRow row in entities.Rows)
                        {
                            // Load configuration entity data filtered by node ID
                            entity = connection.RetrieveData(adapterType, string.Format("SELECT * FROM {0} WHERE NodeID={1}", row["SourceName"].ToString(), m_nodeIDQueryString));
                            entity.TableName = row["RuntimeName"].ToString();

                            DisplayStatusMessage("Loaded configuration entity {0} with {1} rows of data...", entity.TableName, entity.Rows.Count);

                            // Remove redundant node ID column
                            entity.Columns.Remove("NodeID");
                            
                            // Add entity configuration data to system configuration
                            configuration.Tables.Add(entity.Copy());
                        }

                        DisplayStatusMessage("Database configuration successfully loaded.");

                        CacheCurrentConfiguration(configuration);
                    }
                    catch (Exception ex)
                    {
                        DisplayStatusMessage("WARNING: Failed to load database configuration due to exception: {0} Attempting to use last known good configuration.", ex.Message);
                        m_serviceHelper.ErrorLogger.Log(ex);
                        configuration = GetConfigurationDataSet(ConfigurationType.XmlFile, m_cachedConfigurationFile);
                    }
                    finally
                    {
                        if (connection != null && connection.State == ConnectionState.Open)
                            connection.Close();

                        DisplayStatusMessage("Database configuration connection closed.");
                    }

                    break;
                case ConfigurationType.WebService:
                    // Attempt to load configuration from webservice based connection
                    try
                    {
                        // TODO: Define methods to download dataset from common web service...
                        //DisplayStatusMessage("Webservice configuration connection opened.");

                        //configuration = new DataSet("Iaon");

                        //DisplayStatusMessage("Webservice configuration successfully loaded.");

                        //CacheCurrentConfiguration(configuration);
                    }
                    catch (Exception ex)
                    {
                        DisplayStatusMessage("WARNING: Failed to load webservice configuration due to exception: {0} Attempting to use last known good configuration.", ex.Message);
                        m_serviceHelper.ErrorLogger.Log(ex);
                        configuration = GetConfigurationDataSet(ConfigurationType.XmlFile, m_cachedConfigurationFile);
                    }

                    break;
                case ConfigurationType.XmlFile:
                    // Attempt to load cached configuration file
                    try
                    {
                        DisplayStatusMessage("Loading XML based configuration from \"{0}\".", connectionString);
                        
                        configuration = new DataSet();
                        configuration.ReadXml(connectionString);
                        
                        DisplayStatusMessage("XML based configuration successfully loaded.");
                    }
                    catch (Exception ex)
                    {
                        DisplayStatusMessage("ERROR: Failed to load XML based configuration due to exception: {0}.", ex.Message);
                        m_serviceHelper.ErrorLogger.Log(ex);
                        configuration = null;
                    }

                    break;
            }

            return configuration;
        }

        // Cache the current system configuration so it can be used if primary configuration source is unavailable
        private void CacheCurrentConfiguration(DataSet configuration)
        {
            try
            {
                // Back up existing configuration file, if any
                if (File.Exists(m_cachedConfigurationFile))
                {
                    string backupConfigFile = m_cachedConfigurationFile + ".backup";

                    if (File.Exists(backupConfigFile))
                        File.Delete(backupConfigFile);

                    File.Move(m_cachedConfigurationFile, backupConfigFile);
                }
            }
            catch (Exception ex)
            {
                DisplayStatusMessage("WARNING: Failed to backup last known cached configuration due to exception: {0}", ex.Message);
                m_serviceHelper.ErrorLogger.Log(ex);
            }

            try
            {
                // Write current data set to a file
                configuration.WriteXml(m_cachedConfigurationFile, XmlWriteMode.WriteSchema);
                DisplayStatusMessage("Successfully cached current configuration.");
            }
            catch (Exception ex)
            {
                DisplayStatusMessage("ERROR: Failed to cache last known configuration due to exception: {0}", ex.Message);
                m_serviceHelper.ErrorLogger.Log(ex);
            }
        }

        #endregion

        #region [ Primary Adapter Event Handlers ]

        // Handle new measurements from input adapters and action adapters
        private void NewMeasurementsHandler(object sender, EventArgs<ICollection<IMeasurement>> e)
        {
            ICollection<IMeasurement> measurements = e.Argument;

            // All new measurements get passed to action and output adapters for processing
            m_actionAdapters.QueueMeasurementsForProcessing(measurements);
            m_outputAdapters.QueueMeasurementsForProcessing(measurements);
        }

        // Monitor number of unpublished samples (in seconds of data) in action adapters - this typically occurs once per second
        private void UnpublishedSamplesHandler(object sender, EventArgs<int> e)
        {
            int secondsOfData = e.Argument;
            int threshold = m_defaultSampleSizeWarningThreshold;
            ConcentratorBase concentrator = sender as ConcentratorBase;

            // Most action adapters will be based on a concentrator, if so we monitor the unpublished sample queue size compared to the defined
            // lag time - if the queue size is over twice the lag size, the action adapter could be falling behind
            if (concentrator != null)
                threshold = (int)(2 * Math.Ceiling(concentrator.LagTime));

            if (secondsOfData > threshold)
                DisplayStatusMessage("[{0}] WARNING: There are {1} seconds of unpublished data in the action adapter concentration queue.", GetDerivedName(sender), secondsOfData);
        }

        // Monitor number of unprocesses measurements in output adapters - this typically occurs once per second
        private void UnprocessedMeasurementsHandler(object sender, EventArgs<int> e)
        {
            int unprocessedMeasurements = e.Argument;

            if (unprocessedMeasurements > m_measurementDumpingThreshold)
            {
                IOutputAdapter outputAdpater = sender as IOutputAdapter;

                if (outputAdpater != null)
                {
                    // If an output adapter queue size exceeds the defined measurement dumping threshold,
                    // then the queue will be truncated before system runs out of memory
                    outputAdpater.RemoveMeasurements(m_measurementDumpingThreshold);
                    DisplayStatusMessage("[{0}] ERROR: System exercised evasive action to convserve memory and dumped {1} unprocessed measurements from the output queue :(", outputAdpater.Name, m_measurementDumpingThreshold);
                    DisplayStatusMessage("[{0}] NOTICE: Please adjust measurement threshold settings and/or increase amount of available system memory.", outputAdpater.Name);
                }
                else
                    // It is only expected that output adapters will be mapped to this handler, but in case
                    // another adapter type uses this handler we will still display a message
                    DisplayStatusMessage("[{0}] CRITICAL: There are {1} unprocessed measurements in the adapter queue - but sender \"{2}\" is not an IOutputAdapter, so no evasive action can be exercised.", GetDerivedName(sender), unprocessedMeasurements, sender.GetType().Name);
            }
            else if (unprocessedMeasurements > m_measurementWarningThreshold)
            {
                if (unprocessedMeasurements >= m_measurementDumpingThreshold - m_measurementWarningThreshold)
                    DisplayStatusMessage("[{0}] CRITICAL: There are {1} unprocessed measurements in the output queue.", GetDerivedName(sender), unprocessedMeasurements);
                else
                    DisplayStatusMessage("[{0}] WARNING: There are {1} unprocessed measurements in the output queue.", GetDerivedName(sender), unprocessedMeasurements);
            }
        }

        // Handle status message events
        private void StatusMessageHandler(object sender, EventArgs<string> e)
        {
            DisplayStatusMessage("[{0}] {1}", GetDerivedName(sender), e.Argument);
        }

        // Handle process exceptions from all adapters
        private void ProcessExceptionHandler(object sender, EventArgs<Exception> e)
        {
            Exception ex = e.Argument;

            DisplayStatusMessage("[{0}] ERROR: {1}", GetDerivedName(sender), ex.Message);
            m_serviceHelper.ErrorLogger.Log(ex, false);
        }

        // Handle health monitoring processing
        private void HealthMonitorProcessHandler(string name, object[] parameters)
        {
            string requestCommand = "Health";
            ClientRequestHandler requestHandler = m_serviceHelper.FindClientRequestHandler(requestCommand);

            if (requestHandler != null)
            {
                // We pretend to be a client and send a "Health" command to ourselves...
                requestHandler.HandlerMethod(ClientHelper.PretendRequest(requestCommand));

                // We also export human readable health information to a text file for external display
                m_healthExporter.ExportData(m_serviceHelper.PerformanceMonitor.Status);
            }
        }

        // Handle status export processing
        private void StatusExportProcessHandler(string name, object[] parameters)
        {
            // Every thirty minutes we export a human readable service status to a text file for external display
            m_statusExporter.ExportData(m_serviceHelper.Status);
        }

        // Attempt to get name of component raising an event
        private string GetDerivedName(object sender)
        {
            IProvideStatus statusProvider = sender as IProvideStatus;

            if (statusProvider != null)
                return statusProvider.Name.NotEmpty(sender.GetType().Name);

            return sender.GetType().Name;
        }

        #endregion

        #region [ Remote Client Request Handlers ]

        // Get requested adapters collection
        private IAdapterCollection GetRequestedCollection(ClientRequestInfo requestInfo)
        {
            if (requestInfo.Request.Arguments.Exists("A"))
                return m_actionAdapters;
            else if (requestInfo.Request.Arguments.Exists("O"))
                return m_outputAdapters;
            else
                return m_inputAdapters;
        }

        // Get requested adapter
        private IAdapter GetRequestedAdapter(ClientRequestInfo requestInfo)
        {
            IAdapterCollection collection;
            return GetRequestedAdapter(requestInfo, out collection);
        }
        
        // Get requested adapter and its parent collection
        private IAdapter GetRequestedAdapter(ClientRequestInfo requestInfo, out IAdapterCollection collection)
        {
            IAdapter adapter;
            string adapterID = requestInfo.Request.Arguments["OrderedArg1"];
            collection = GetRequestedCollection(requestInfo);

            if (adapterID.IsAllNumbers())
            {
                // Adapter ID is numeric, lookup by adapter ID
                uint id = uint.Parse(adapterID);

                // Try requested collection
                if (collection.TryGetAdapterByID(id, out adapter))
                    return adapter;
                // Try looking for ID in any collection if all runtime ID's are unique
                else if (m_uniqueAdapterIDs && m_allAdapters.TryGetAnyAdapterByID(id, out adapter, out collection))
                    return adapter;
                else
                    SendResponse(requestInfo, false, "Failed to find adapter with ID \"{0}\" in {1}.", id, collection.Name);
            }
            else
            {
                // Adapter ID is alpha-numeric, lookup by adapter name
                if (collection.TryGetAdapterByName(adapterID, out adapter))
                    return adapter;
                else
                    SendResponse(requestInfo, false, "Failed to find adapter \"{0}\" in {1}.", adapterID, collection.Name);
            }

            return null;
        }

        // List specified adapters
        private void ListRequestHandler(ClientRequestInfo requestInfo)
        {			
            if (requestInfo.Request.Arguments.ContainsHelpRequest)
            {
                StringBuilder helpMessage = new StringBuilder();

                helpMessage.Append("Displays status of specified adapter or collection.");
                helpMessage.AppendLine();
                helpMessage.AppendLine();
                helpMessage.Append("   Usage:");
                helpMessage.AppendLine();
                helpMessage.Append("       List [ID] [Options]");
                helpMessage.AppendLine();
                helpMessage.AppendLine();
                helpMessage.Append("   ID:".PadRight(20));
                helpMessage.Append("ID of the adapter to display, or all adapters if not specified");
                helpMessage.AppendLine();
                helpMessage.Append("   Options:");
                helpMessage.AppendLine();
                helpMessage.Append("       -?".PadRight(20));
                helpMessage.Append("Displays this help message");
                helpMessage.AppendLine();
                helpMessage.Append("       -I".PadRight(20));
                helpMessage.Append("Enumerate input adapters (default)");
                helpMessage.AppendLine();
                helpMessage.Append("       -A".PadRight(20));
                helpMessage.Append("Enumerate action adapters");
                helpMessage.AppendLine();
                helpMessage.Append("       -O".PadRight(20));
                helpMessage.Append("Enumerate output adapters");
                helpMessage.AppendLine();

                DisplayResponseMessage(requestInfo, helpMessage.ToString());
            }
            else
            {
                StringBuilder adapterList = new StringBuilder();
                IAdapterCollection collection = GetRequestedCollection(requestInfo);
                IEnumerable<IAdapter> listItems = collection;
                bool idArgExists = requestInfo.Request.Arguments.Exists("OrderedArg1");
                int enumeratedItems = 0;

                adapterList.AppendFormat("System Uptime: {0}", m_serviceHelper.RemotingServer.RunTime.ToString());
                adapterList.AppendLine();
                adapterList.AppendLine();

                if (idArgExists)
                    adapterList.AppendFormat(">> Selected adapter from {0}", collection.Name);
                else
                    adapterList.AppendFormat(">> All defined adapters in {0} ({1} total)", collection.Name, collection.Count);

                // Make a collection of one item for individual adapters
                if (idArgExists)
                {
                    IAdapter adapter = GetRequestedAdapter(requestInfo);
                    List<IAdapter> singleItemList = new List<IAdapter>();

                    if (adapter != null)
                        singleItemList.Add(adapter);

                    listItems = singleItemList;
                }

                adapterList.AppendLine();
                adapterList.AppendLine();
                adapterList.Append("    ID     Name");
                adapterList.AppendLine();
                //                  12345678901234567890123456789012345678901234567890123456789012345678901234567890
                //                           1         2         3         4         5         6         7         8
                adapterList.Append("---------- --------------------------------------------------------------------");
                //                             123456789012345678901234567890123456789012345678901234567890123456789
                //                                      1         2         3         4         5         6
                adapterList.AppendLine();

                foreach (IAdapter adapter in listItems)
                {
                    adapterList.AppendFormat("{0} {1}", adapter.ID.ToString().CenterText(10), adapter.Name.TruncateRight(66));
                    adapterList.AppendLine();
                    adapterList.Append("           ");
                    adapterList.Append(adapter.GetShortStatus(68).TruncateRight(68));

                    // If a request was made to list a specific item, we request full status
                    if (idArgExists)
                    {
                        adapterList.AppendLine();
                        adapterList.AppendLine();
                        adapterList.Append(adapter.Status);
                    }
                    adapterList.AppendLine();

                    enumeratedItems++;
                }

                if (enumeratedItems > 0)
                    SendResponse(requestInfo, true, adapterList.ToString());
                else
                    SendResponse(requestInfo, false, "No items were available enumerate.");
            }			
        }

        // Start specified adapter
        private void StartRequestHandler(ClientRequestInfo requestInfo)
        {
            ActionRequestHandler(requestInfo, adapter => adapter.Start());
        }

        // Stop specified adapter
        private void StopRequestHandler(ClientRequestInfo requestInfo)
        {
            ActionRequestHandler(requestInfo, adapter => adapter.Stop());
        }

        // Abstract handler for adapter actions
        private void ActionRequestHandler(ClientRequestInfo requestInfo, Action<IAdapter> adapterAction)
        {
            string actionName = requestInfo.Request.Command.ToTitleCase();

            if (requestInfo.Request.Arguments.ContainsHelpRequest)
            {
                StringBuilder helpMessage = new StringBuilder();

                helpMessage.AppendFormat("Handles {0} command for specified adapter.", actionName);
                helpMessage.AppendLine();
                helpMessage.AppendLine();
                helpMessage.Append("   Usage:");
                helpMessage.AppendLine();
                helpMessage.AppendFormat("       {0} ID [Options]", actionName);
                helpMessage.AppendLine();
                helpMessage.AppendLine();
                helpMessage.Append("   ID:".PadRight(20));
                helpMessage.Append("ID of the adapter to execute action on");
                helpMessage.AppendLine();
                helpMessage.Append("   Options:");
                helpMessage.AppendLine();
                helpMessage.Append("       -?".PadRight(20));
                helpMessage.Append("Displays this help message");
                helpMessage.AppendLine();
                helpMessage.Append("       -I".PadRight(20));
                helpMessage.AppendFormat("Perform {0} command on input adapters (default)", actionName);
                helpMessage.AppendLine();
                helpMessage.Append("       -A".PadRight(20));
                helpMessage.AppendFormat("Perform {0} command on action adapters", actionName);
                helpMessage.AppendLine();
                helpMessage.Append("       -O".PadRight(20));
                helpMessage.AppendFormat("Perform {0} command on output adapters", actionName);
                helpMessage.AppendLine();

                DisplayResponseMessage(requestInfo, helpMessage.ToString());
            }
            else
            {
                if (requestInfo.Request.Arguments.Exists("OrderedArg1"))
                {
                    IAdapter adapter = GetRequestedAdapter(requestInfo);

                    if (adapter != null)
                    {
                        adapterAction(adapter);
                        SendResponse(requestInfo, true);
                    }
                }
                else
                    SendResponse(requestInfo, false, "No ID was specified for \"{0}\" command.", actionName);
            }
        }

        // Reflected invoke command request handler
        private void InvokeRequestHandler(ClientRequestInfo requestInfo)
        {
            if (requestInfo.Request.Arguments.ContainsHelpRequest)
            {
                StringBuilder helpMessage = new StringBuilder();

                helpMessage.Append("Invokes specified adapter command.");
                helpMessage.AppendLine();
                helpMessage.AppendLine();
                helpMessage.Append("   Usage:");
                helpMessage.AppendLine();
                helpMessage.Append("       Invoke ID Command [Params] [Options]");
                helpMessage.AppendLine();
                helpMessage.AppendLine();
                helpMessage.Append("   ID:".PadRight(20));
                helpMessage.Append("ID of the adapter to execute command on");
                helpMessage.AppendLine();
                helpMessage.Append("   Command:".PadRight(20));
                helpMessage.Append("Name of the adapter command (i.e., method) to invoke");
                helpMessage.AppendLine();
                helpMessage.Append("   Params:".PadRight(20));
                helpMessage.Append("Command parameters, if any, separated by spaces");
                helpMessage.AppendLine();
                helpMessage.Append("   Options:");
                helpMessage.AppendLine();
                helpMessage.Append("       -?".PadRight(20));
                helpMessage.Append("Displays this help message");
                helpMessage.AppendLine();
                helpMessage.Append("       -I".PadRight(20));
                helpMessage.Append("Invoke specified command on input adapter (default)");
                helpMessage.AppendLine();
                helpMessage.Append("       -A".PadRight(20));
                helpMessage.Append("Invoke specified command on action adapter");
                helpMessage.AppendLine();
                helpMessage.Append("       -O".PadRight(20));
                helpMessage.Append("Invoke specified command on output adapter");
                helpMessage.AppendLine();

                DisplayResponseMessage(requestInfo, helpMessage.ToString());
            }
            else
            {
                if (requestInfo.Request.Arguments.Exists("OrderedArg2"))
                {
                    IAdapter adapter = GetRequestedAdapter(requestInfo);
                    string command = requestInfo.Request.Arguments["OrderedArg2"];

                    if (adapter != null)
                    {
                        try
                        {
                            // See if method exists with specified name using reflection
                            MethodInfo method = adapter.GetType().GetMethod(command, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase);

                            // Invoke method
                            if (method != null)
                            {
                                AdapterCommandAttribute commandAttribute;

                                // Make sure method is marked as invokable (i.e., AdapterCommandAttribute exists on method)
                                if (method.TryGetAttribute(out commandAttribute))
                                {
                                    ParameterInfo[] parameterInfo = method.GetParameters();

                                    if (parameterInfo == null || (parameterInfo != null && parameterInfo.Length == 0))
                                    {
                                        // Invoke parameterless method
                                        method.Invoke(adapter, null);
                                    }
                                    else
                                    {
                                        // Create typed parameters for method and invoke
                                        if (requestInfo.Request.Arguments.OrderedArgCount - 2 >= parameterInfo.Length)
                                        {
                                            // Attempt to convert command parameters to the method parameter types
                                            object[] parameters = new object[parameterInfo.Length];
                                            string parameterValue;

                                            for (int i = 0; i < parameterInfo.Length; i++)
                                            {
                                                parameterValue = requestInfo.Request.Arguments["OrderedArg" + (3 + i)];
                                                parameters[i] = parameterValue.ConvertToType(parameterInfo[i].ParameterType);
                                            }

                                            method.Invoke(adapter, parameters);
                                            SendResponse(requestInfo, true);
                                        }
                                        else
                                            SendResponse(requestInfo, false, "Parameter count mismatch, \"{0}\" command expects {1} parameters.", command, parameterInfo.Length);
                                    }
                                }
                                else
                                    SendResponse(requestInfo, false, "Specified command \"{0}\" is not marked as invokable for adapter \"{1}\" [Type = {2}].", command, adapter.Name, adapter.GetType().Name);
                            }
                            else
                                SendResponse(requestInfo, false, "Specified command \"{0}\" does not exist for adapter \"{1}\" [Type = {2}].", command, adapter.Name, adapter.GetType().Name);
                        }
                        catch (Exception ex)
                        {
                            SendResponse(requestInfo, false, ex.Message);
                            m_serviceHelper.ErrorLogger.Log(ex);
                        }
                    }
                }
                else
                    SendResponse(requestInfo, false, "No command was specified.");
            }
        }

        // Reflected list commands request handler
        private void ListCommandsRequestHandler(ClientRequestInfo requestInfo)
        {
            if (requestInfo.Request.Arguments.ContainsHelpRequest)
            {
                StringBuilder helpMessage = new StringBuilder();

                helpMessage.Append("Lists possible commands of specified adapter.");
                helpMessage.AppendLine();
                helpMessage.AppendLine();
                helpMessage.Append("   Usage:");
                helpMessage.AppendLine();
                helpMessage.Append("       ListCommands ID [Options]");
                helpMessage.AppendLine();
                helpMessage.AppendLine();
                helpMessage.Append("   ID:".PadRight(20));
                helpMessage.Append("ID of the adapter to execute command on");
                helpMessage.AppendLine();
                helpMessage.Append("   Options:");
                helpMessage.AppendLine();
                helpMessage.Append("       -?".PadRight(20));
                helpMessage.Append("Displays this help message");
                helpMessage.AppendLine();
                helpMessage.Append("       -I".PadRight(20));
                helpMessage.Append("Lists commands on input adapter (default)");
                helpMessage.AppendLine();
                helpMessage.Append("       -A".PadRight(20));
                helpMessage.Append("Lists commands on action adapter");
                helpMessage.AppendLine();
                helpMessage.Append("       -O".PadRight(20));
                helpMessage.Append("Lists commands on output adapter");
                helpMessage.AppendLine();

                DisplayResponseMessage(requestInfo, helpMessage.ToString());
            }
            else
            {
                IAdapter adapter = GetRequestedAdapter(requestInfo);

                if (adapter != null)
                {
                    try
                    {
                        // Get public command methods of specified adpater using reflection
                        MethodInfo[] methods = adapter.GetType().GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase);

                        // Invoke method
                        if (methods != null)
                        {
                            StringBuilder methodList = new StringBuilder();
                            AdapterCommandAttribute commandAttribute;
                            bool firstParameter;
                            string typeName;

                            methodList.AppendFormat("Adapter \"{0}\" [Type = {1}] Command List:", adapter.Name, adapter.GetType().Name);
                            methodList.AppendLine();
                            methodList.AppendLine();

                            // Enumerate each public method
                            foreach (MethodInfo method in methods)
                            {
                                // Only display methods marked as invokable (i.e., AdapterCommandAttribute exists on method)
                                if (method.TryGetAttribute(out commandAttribute))
                                {
                                    firstParameter = true;

                                    methodList.Append("    ");
                                    methodList.Append(method.Name);
                                    methodList.Append('(');

                                    // Enumerate each method parameter
                                    foreach (ParameterInfo parameter in method.GetParameters())
                                    {
                                        if (!firstParameter)
                                            methodList.Append(", ");

                                        typeName = parameter.ParameterType.ToString();

                                        // Assume namespace for basic System types...
                                        if (typeName.StartsWith("System.", StringComparison.InvariantCultureIgnoreCase) && typeName.CharCount('.') == 1)
                                            typeName = typeName.Substring(7);

                                        methodList.Append(typeName);
                                        methodList.Append(' ');
                                        methodList.Append(parameter.Name);

                                        firstParameter = false;
                                    }

                                    methodList.Append(')');
                                    methodList.AppendLine();

                                    if (!string.IsNullOrEmpty(commandAttribute.Description))
                                    {
                                        methodList.Append("        ");
                                        methodList.Append(commandAttribute.Description);
                                    }
                                    
                                    methodList.AppendLine();
                                }
                            }

                            methodList.AppendLine();

                            SendResponse(requestInfo, true, methodList.ToString());
                        }
                        else
                            SendResponse(requestInfo, false, "Specified adapter \"{0}\" [Type = {1}] has no commands.", adapter.Name, adapter.GetType().Name);
                    }
                    catch (Exception ex)
                    {
                        SendResponse(requestInfo, false, ex.Message);
                        m_serviceHelper.ErrorLogger.Log(ex);
                    }
                }
            }
        }

        // Initialize specified adapter or collection of adapters
        private void InitializeRequestHandler(ClientRequestInfo requestInfo)
        {
            if (requestInfo.Request.Arguments.ContainsHelpRequest)
            {
                StringBuilder helpMessage = new StringBuilder();

                helpMessage.Append("Performs (re)initialization of specified adapter or collection.");
                helpMessage.AppendLine();
                helpMessage.AppendLine();
                helpMessage.Append("   Usage:");
                helpMessage.AppendLine();
                helpMessage.Append("       Initialize [ID] [Options]");
                helpMessage.AppendLine();
                helpMessage.AppendLine();
                helpMessage.Append("   ID:".PadRight(20));
                helpMessage.Append("ID of the adapter to initialize, or all adapters if not specified");
                helpMessage.AppendLine();
                helpMessage.Append("   Options:");
                helpMessage.AppendLine();
                helpMessage.Append("       -?".PadRight(20));
                helpMessage.Append("Displays this help message");
                helpMessage.AppendLine();
                helpMessage.Append("       -I".PadRight(20));
                helpMessage.Append("Initialize input adapters (default)");
                helpMessage.AppendLine();
                helpMessage.Append("       -A".PadRight(20));
                helpMessage.Append("Initialize action adapters");
                helpMessage.AppendLine();
                helpMessage.Append("       -O".PadRight(20));
                helpMessage.Append("Initialize output adapters");
                helpMessage.AppendLine();
                helpMessage.Append("       -System".PadRight(20));
                helpMessage.Append("Performs full system initialization");
                helpMessage.AppendLine();

                DisplayResponseMessage(requestInfo, helpMessage.ToString());
            }
            else
            {
                if (requestInfo.Request.Arguments.Exists("System"))
                {
                    DisplayStatusMessage("Starting manual full system initialization...");
                    InitializeSystem(null);
                    SendResponse(requestInfo, true);
                }
                else
                {
                    IAdapterCollection collection;

                    // Reload system configuration
                    if (LoadSystemConfiguration())
                    {
                        // See if specific ID for an adapter was requested
                        if (requestInfo.Request.Arguments.Exists("OrderedArg1"))
                        {
                            IAdapter adapter = GetRequestedAdapter(requestInfo, out collection);

                            // Initialize specified adapter
                            if (adapter != null && collection != null)
                            {
                                if (collection.TryInitializeAdapterByID(adapter.ID))
                                    SendResponse(requestInfo, true, "Adapter \"{0}\" ({1}) was successfully initialized...", adapter.Name, adapter.ID);
                                else
                                    SendResponse(requestInfo, false, "Adapter \"{0}\" ({1}) failed to initialize.", adapter.Name, adapter.ID);
                            }
                            else
                                SendResponse(requestInfo, false, "Requested adapter was not found.");

                        }
                        else
                        {
                            // Get specified adapter collection
                            collection = GetRequestedCollection(requestInfo);

                            if (collection != null)
                            {
                                DisplayStatusMessage("Initializing all adapters in {0}...", collection.Name);
                                collection.Initialize();
                                DisplayStatusMessage("{0} initialization complete.", collection.Name);
                                SendResponse(requestInfo, true);
                            }
                            else
                                SendResponse(requestInfo, false, "Requested collection was unavailable.");
                        }
                    }
                    else
                        SendResponse(requestInfo, false, "Failed to load system configuration.");
                }
            }
        }

        // Reload system configuration 
        private void ReloadConfigRequstHandler(ClientRequestInfo requestInfo)
        {
            if (requestInfo.Request.Arguments.ContainsHelpRequest)
            {
                StringBuilder helpMessage = new StringBuilder();

                helpMessage.Append("Manually reloads system configuration.");
                helpMessage.AppendLine();
                helpMessage.AppendLine();
                helpMessage.Append("   Usage:");
                helpMessage.AppendLine();
                helpMessage.Append("       ReloadConfig [Options]");
                helpMessage.AppendLine();
                helpMessage.AppendLine();
                helpMessage.Append("   Options:");
                helpMessage.AppendLine();
                helpMessage.Append("       -?".PadRight(20));
                helpMessage.Append("Displays this help message");

                DisplayResponseMessage(requestInfo, helpMessage.ToString());
            }
            else
            {
                if (LoadSystemConfiguration())
                    SendResponse(requestInfo, true, "System configuration was successfully reloaded.");
                else
                    SendResponse(requestInfo, false, "System configuration failed to reload.");
            }
        }

        // Attempts to authenticate (or reauthenticate) to network shares
        private void AuthenticateRequestHandler(ClientRequestInfo requestInfo)
        {
            if (requestInfo.Request.Arguments.ContainsHelpRequest)
            {
                StringBuilder helpMessage = new StringBuilder();

                helpMessage.Append("Attempts to (re)authenticate to network shares.");
                helpMessage.AppendLine();
                helpMessage.AppendLine();
                helpMessage.Append("   Usage:");
                helpMessage.AppendLine();
                helpMessage.Append("       Authenticate [Options]");
                helpMessage.AppendLine();
                helpMessage.AppendLine();
                helpMessage.Append("   Options:");
                helpMessage.AppendLine();
                helpMessage.Append("       -?".PadRight(20));
                helpMessage.Append("Displays this help message");

                DisplayResponseMessage(requestInfo, helpMessage.ToString());
            }
            else
            {
                DisplayStatusMessage("Attempting to reauthenticate network shares for health and status exports...");

                try
                {
                    m_healthExporter.Initialize();
                    m_statusExporter.Initialize();
                    SendResponse(requestInfo, true);
                }
                catch
                {
                    SendResponse(requestInfo, false);
                    throw;
                }
            }
        }

        #endregion

        #region [ Broadcast Message Handling ]

        // Send actionable response to client
        private void SendResponse(ClientRequestInfo requestInfo, bool success)
        {
            string response = requestInfo.Request.Command + (success ? ":Success" : ":Failure");

            m_serviceHelper.SendResponse(requestInfo.Sender.ClientID, new ServiceResponse(response));

            if (m_serviceHelper.LogStatusUpdates && m_serviceHelper.StatusLog.IsOpen)
                m_serviceHelper.StatusLog.WriteTimestampedLine(response);
        }

        // Send actionable response to client with message
        private void SendResponse(ClientRequestInfo requestInfo, bool success, string status, params object[] args)
        {
            string response = requestInfo.Request.Command + (success ? ":Success" : ":Failure");
            string message = string.Format(status, args) + "\r\n\r\n";

            m_serviceHelper.SendResponse(requestInfo.Sender.ClientID, new ServiceResponse(response, message));

            if (m_serviceHelper.LogStatusUpdates && m_serviceHelper.StatusLog.IsOpen)
                m_serviceHelper.StatusLog.WriteTimestampedLine(response + " - " + message);
        }

        // Display response message (send to request sender)
        private void DisplayResponseMessage(ClientRequestInfo requestInfo, string status, params object[] args)
        {
            m_serviceHelper.UpdateStatus(requestInfo.Sender.ClientID, string.Format("{0}\r\n\r\n", status), args);
        }

        // Display status messages (broadcast to all clients)
        private void DisplayStatusMessage(string status)
        {
            // We queue up status messages for display on a separate thread so we don't slow any important activity
            m_statusMessageQueue.Add(string.Format("{0}\r\n\r\n", status));
        }

        // Display formatted status messages (broadcast to all clients)
        private void DisplayStatusMessage(string status, params object[] args)
        {
            DisplayStatusMessage(string.Format(status, args));
        }

        // Handles processing of queued status messages
        private void StatusMessageQueueHandler(string[] messages)
        {
            bool displayMessage;

            for (int x = 0; x < messages.Length; x++)
            {
                // When errors happen with data being processed at 30 samples per second you can get a hefty
                // volume of messages very quickly, so to keep from flooding the message queue we'll only
                // send a finite number of messages every few seconds
                if ((DateTime.Now.Ticks - m_lastDisplayedMessageTime).ToSeconds() < m_messageDisplayTimepan)
                {
                    displayMessage = m_displayedMessageCount < m_maximumMessagesToDisplay;
                    m_displayedMessageCount++;
                }
                else
                {
                    if (m_displayedMessageCount > m_maximumMessagesToDisplay)
                        m_serviceHelper.UpdateStatus("WARNING: {0:N0} status messages discarded to avoid flooding message queue, check log for full detail.", m_displayedMessageCount - m_maximumMessagesToDisplay);

                    displayMessage = true;
                    m_displayedMessageCount = 0;
                    m_lastDisplayedMessageTime = DateTime.Now.Ticks;
                }

                if (displayMessage)
                {
                    m_serviceHelper.UpdateStatus(messages[x]);
                }
                else if (m_serviceHelper.LogStatusUpdates && m_serviceHelper.StatusLog.IsOpen)
                {
                    // We always at least log messages
                    m_serviceHelper.StatusLog.WriteTimestampedLine(messages[x]);
                }
            }
        }

        // Handles any exceptions encountered in the statsu message queue
        private void StatusMessageQueueExceptionHandler(object sender, EventArgs<Exception> e)
        {
            // We still try to log message to error log file even if it couldn't be displayed...
            m_serviceHelper.ErrorLogger.Log(e.Argument, false);
        }

        #endregion

        #endregion
    }
}