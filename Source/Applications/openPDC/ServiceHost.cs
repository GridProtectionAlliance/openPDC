//*******************************************************************************************************
//  ServiceHost.cs
//  Copyright © 2009 - TVA, all rights reserved - Gbtc
//
//  Build Environment: C#, Visual Studio 2008
//  Primary Developer: James R. Carroll
//      Office: PSO TRAN & REL, CHATTANOOGA - MR BK-C
//       Phone: 423/751-4165
//       Email: jrcarrol@tva.gov
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  05/04/2009 - James R. Carroll
//       Generated original version of source code.
//
//*******************************************************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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
        private DataSet m_configuration;
        private ConfigurationType m_configurationType;
        private string m_connectionString;
        private string m_cachedConfigurationFile;

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
            
            // Actual passphrase value is decrypted and updated at runtime so that value is obfuscated and not stored as a directly readable string in the executable or configuration file
            //m_remotingServer.SharedSecret = "O5ztzVTI5LojZEMONpq/8fscA0ClC79/OBbj8MwKZTaMmRjCBDUSjE5t3Npl1zBAQpo6qlUD6Jz4hpfywQBBIkqzy1DWvB9fPjgrb1sZkqUod9XsrCaMlM5osmdvprxOMCw7ZLd8pXbRuJ+RThcOgH7JXap9Xo2mt0zrmhOFhZT41GtlPVjlCGgKegSlaX9snnVMackXyW5I4Uaj+mI4YHaojZBdQco9glyQogdCywlTQSldCyos8Zl8pgVfT/jkqcixbML4NWvZVgZ6XIjAHcPp2yL95MA8M8KpjH1cZoc=".Decrypt("4PM3kCB137N62J31h057N8CwydTFLh58B218k0dr35n42qw3G2", CipherStrength.Level6);

            // System settings
            CategorizedSettingsElementCollection systemSettings = configFile.Settings["systemSettings"];
#if DEBUG
            systemSettings.Add("NodeID", "{60ACE9D2-3026-40A3-AD7E-1EB9DE6DCA34}", "Unique Node ID");
#else
            systemSettings.Add("NodeID", Guid.NewGuid().ToString(), "Unique Node ID");
#endif
            systemSettings.Add("ConfigurationType", "Database", "Specifies type of configuration: Database, WebService or XmlFile");
            systemSettings.Add("ConnectionString", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Databases\\PhasorMeasurementData.mdb", "Configuration database connection string");
            systemSettings.Add("CachedConfigurationFile", "CachedConfiguration.xml", "File name for last known good system configuration (only cached for a Database or WebService connection)");
            systemSettings.Add("Example.Database.SqlServer", "Provider=SQLOLEDB;Data Source=serverName;Initial Catalog=openPDC;User ID=userName;Password=password", "Example SQL Server database connection string");
            systemSettings.Add("Example.Database.MicrosoftAccess", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=openPDC.mdb", "Example Microsoft Access database connection string");
            systemSettings.Add("Example.Database.MySQL", "Provider=MySQLProv;Data Source=serverName;Initial Catalog=openPDC;User ID=userName;Password=password", "Example Microsoft Access database connection string");
            systemSettings.Add("Example.WebService", "https://naspi.tva.com/openPDC/LoadConfigurationData.aspx", "Example web service connection string");
            systemSettings.Add("Example.XmlFile", "SystemConfiguration.xml", "Example XML configuration file connection string");

            // Broadcast message settings
            CategorizedSettingsElementCollection broadcastMessageSettings = configFile.Settings["broadcastMessageSettings"];
            broadcastMessageSettings.Add("MessageDisplayTimespan", "2", "Timespan, in seconds, over which to monitor message volume");
            broadcastMessageSettings.Add("MaximumMessagesToDisplay", "100", "Maximum number of messages to be tolerated during MessageDisplayTimespan");

            // Threshold settings
            CategorizedSettingsElementCollection thresholdSettings = configFile.Settings["thresholdSettings"];
            thresholdSettings.Add("MeasurementWarningThreshold", "100000", "Number of unarchived measurements allowed in any output adapter queue before displaying a warning message");
            thresholdSettings.Add("MeasurementDumpingThreshold", "500000", "Number of unarchived measurements allowed in any output adapter queue before taking evasive action and dumping data");
            thresholdSettings.Add("DefaultSampleSizeWarningThreshold", "10", "Default number of unpublished samples (in seconds) allowed in any action adapter queue before displaying a warning message");

            // Initialize system settings
            m_nodeID = systemSettings["NodeID"].ValueAs<Guid>();
            m_configurationType = systemSettings["ConfigurationType"].ValueAs<ConfigurationType>();
            m_connectionString = systemSettings["ConnectionString"].Value;
            m_cachedConfigurationFile = FilePath.GetAbsolutePath(systemSettings["CachedConfigurationFile"].Value);

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
            m_healthExporter.Initialize(new ExportDestination[] { new ExportDestination("C:\\Health.txt", false, "", "", "") });
            m_healthExporter.StatusMessage += StatusMessageHandler;
            m_serviceHelper.ServiceComponents.Add(m_healthExporter);
            
            // Create status exporter
            m_statusExporter = new MultipleDestinationExporter("StatusExporter", Timeout.Infinite);
            m_statusExporter.Initialize(new ExportDestination[] { new ExportDestination("C:\\Status.txt", false, "", "", "") });
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
                    // Attempt to load configuration from database based connection
                    OleDbConnection connection = null;

                    try
                    {
                        connection = new OleDbConnection(m_connectionString);
                        connection.Open();

                        DisplayStatusMessage("Database configuration connection opened.");

                        configuration = new DataSet("Iaon");

                        // Load configuration entities defined in database
                        entities = connection.RetrieveData("SELECT * FROM ConfigurationEntity WHERE Enabled <> 0 ORDER BY LoadOrder");
                        entities.TableName = "ConfigurationEntity";
                        
                        // Add configuration entities table to system configuration for reference
                        configuration.Tables.Add(entities.Copy());

                        // Add each configuration entity to the system configuration
                        foreach (DataRow row in entities.Rows)
                        {
                            // Load configuration entity data filtered by node ID
                            entity = connection.RetrieveData(string.Format("SELECT * FROM {0} WHERE NodeID={{{1}}} AND Enabled <> 0 ORDER BY LoadOrder", row["SourceName"].ToString(), m_nodeID));
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

                        OleDbConnection.ReleaseObjectPool();
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
                    string backupConfigFile = FilePath.GetAbsolutePath(FilePath.GetFileNameWithoutExtension(m_cachedConfigurationFile) + ".backup");

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
                configuration.WriteXml(m_cachedConfigurationFile, XmlWriteMode.IgnoreSchema);
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
            ClientRequestHandler requestHandler = m_serviceHelper.GetClientRequestHandler(requestCommand);

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

                if (collection.TryGetAdapterByID(id, out adapter))
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