//******************************************************************************************************
//  SetupCompleteScreen.xaml.cs - Gbtc
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
//  09/10/2010 - Stephen C. Wills
//       Generated original version of source code.
//  09/19/2010 - J. Ritchie Carroll
//       Modified code to take into account that service will normally be stopped on this screen.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;
using GSF;
using GSF.Configuration;
using GSF.Data;
using GSF.IO;
using GSF.Security;

namespace ConfigurationSetupUtility.Screens
{
    /// <summary>
    /// Interaction logic for SetupCompleteScreen.xaml
    /// </summary>
    public partial class SetupCompleteScreen : UserControl, IScreen
    {
        #region [ Members ]

        // Fields

        private Dictionary<string, object> m_state;
        private ServiceController m_openPdcServiceController;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new instance of the <see cref="SetupCompleteScreen"/> class.
        /// </summary>
        public SetupCompleteScreen()
        {
            InitializeComponent();
            InitializeOpenPdcServiceController();
            InitializeServiceCheckboxState();
            InitializeManagerCheckboxState();
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets the screen to be displayed when the user clicks the "Next" button.
        /// </summary>
        public IScreen NextScreen
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets a boolean indicating whether the user can advance to
        /// the next screen from the current screen.
        /// </summary>
        public bool CanGoForward
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a boolean indicating whether the user can return to
        /// the previous screen from the current screen.
        /// </summary>
        public bool CanGoBack
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a boolean indicating whether the user can cancel the
        /// setup process from the current screen.
        /// </summary>
        public bool CanCancel
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a boolean indicating whether the user input is valid on the current page.
        /// </summary>
        public bool UserInputIsValid
        {
            get
            {
                // Very little input to validate on this page, but we take this opportunity to execute final shut-down operations
                if (m_state != null)
                {
                    try
                    {
                        bool existing = Convert.ToBoolean(m_state["existing"]);
                        bool migrate = existing && Convert.ToBoolean(m_state["updateConfiguration"]);

                        if (migrate)
                        {
                            const string SerializedSchemaPath = "SerializedSchema.bin";

                            string dataFolder = FilePath.GetApplicationDataFolder();
                            string dataMigrationUtilityUserSettingsFolder = dataFolder + "\\..\\DataMigrationUtility";
                            string userSettingsFile = dataMigrationUtilityUserSettingsFolder + "\\Settings.xml";

                            string newConnectionString = m_state["newConnectionString"].ToString();
                            string oldConnectionString = m_state.ContainsKey("oldConnectionString") ? m_state["oldConnectionString"].ToString() : string.Empty;
                            string newDataProviderString = m_state["newDataProviderString"].ToString();
                            string oldDataProviderString = m_state.ContainsKey("oldDataProviderString") ? m_state["oldDataProviderString"].ToString() : string.Empty;
                            string newDatabaseType = m_state["newDatabaseType"].ToString().Replace(" ", "");

                            if (!Directory.Exists(dataMigrationUtilityUserSettingsFolder))
                                Directory.CreateDirectory(dataMigrationUtilityUserSettingsFolder);

                            oldConnectionString += string.Format("; dataProviderString={{ {0} }}; serializedSchema={1}", oldDataProviderString, SerializedSchemaPath);
                            newConnectionString += string.Format("; dataProviderString={{ {0} }}; serializedSchema={1}", newDataProviderString, SerializedSchemaPath);

                            XDocument doc = new XDocument(
                                                new XElement("settings",
                                                    new XElement("applicationSettings",
                                                        new XElement("add", new XAttribute("name", "FromConnectionString"),
                                                                            new XAttribute("value", oldConnectionString)),
                                                        new XElement("add", new XAttribute("name", "ToConnectionString"),
                                                                            new XAttribute("value", newConnectionString)),
                                                        new XElement("add", new XAttribute("name", "ToDataType"),
                                                                            new XAttribute("value", newDatabaseType)),
                                                        new XElement("add", new XAttribute("name", "UseFromConnectionForRI"),
                                                                            new XAttribute("value", string.Empty)),
                                                        new XElement("add", new XAttribute("name", "FromDataType"),
                                                                            new XAttribute("value", m_state.ContainsKey("oldDatabaseType") ? m_state["oldDatabaseType"].ToString() : "Unspecified"))
                                                    )
                                                )
                                            );

                            doc.Save(userSettingsFile);

                            try
                            {
                                DependencyObject parent = VisualTreeHelper.GetParent(this);
                                Window mainWindow;

                                while (parent != null && !(parent is Window))
                                    parent = VisualTreeHelper.GetParent(parent);

                                mainWindow = parent as Window;

                                if (mainWindow != null)
                                    mainWindow.WindowState = WindowState.Minimized;
                            }
                            catch
                            {
                                // Nothing to do if we fail to minimize...
                            }

                            // Run the DataMigrationUtility.
                            using (Process migrationProcess = new Process())
                            {
                                migrationProcess.StartInfo.FileName = "DataMigrationUtility.exe";
                                migrationProcess.StartInfo.Arguments = "-install";
                                migrationProcess.Start();
                                migrationProcess.WaitForExit();
                            }
                        }

                        // Always make sure time series startup operations are defined in the database.
                        ValidateTimeSeriesStartupOperations();

                        // Always make sure the datapublisher record in the config file is changed to internaldatapublisher.
                        ValidateInternalDataPublisher();

                        if (migrate)
                        {
                            // Always make sure data operation assembly names
                            // and type names are correct after an upgrade.
                            ValidateGridSolutionsNamespaces();

                            // Always make sure skipOptimization is true after an upgrade
                            ValidatePhasorDataSourceValidation();
                        }

                        // Always make sure new configuration entity records are defined in the database.
                        ValidateConfigurationEntity();

                        // Always make sure that node settings defines security settings and the alarm service URL.
                        ValidateNodeSettings();

                        // Always make sure that all three needed roles are available for each defined node(s) in the database
                        ValidateSecurityRoles();

                        // Convert node table to new format (i.e., columns to connection settings string), if nedded
                        ConvertNodeTableFormat();

                        // Remove old configuration file settings
                        try
                        {
                            ConfigurationFile openPDCConfig = ConfigurationFile.Open("openPDC.exe.config");

                            // Some of the crypto settings elements were renamed for consistency, remove the old ones
                            CategorizedSettingsElementCollection cryptoSection = openPDCConfig.Settings["cryptographyServices"];
                            cryptoSection.Remove("RetryDelayInterval");
                            cryptoSection.Remove("MaximumRetryAttempts");

                            // Example connection settings are updated between builds - remove the section and openPDC will add back the latest
                            openPDCConfig.Settings.Remove("exampleConnectionSettings");

                            // Data publisher categories are now always lower case (such that code references are case insensitive)
                            openPDCConfig.Settings.Remove("dataPublisher");

                            openPDCConfig.Save(ConfigurationSaveMode.Full);
                        }
                        catch
                        {
                            // Just continue on errors with removal of old settings - this is not critical
                        }

                        // If the user requested it, start or restart the openPDC service
                        if (m_serviceStartCheckBox.IsChecked.Value)
                        {
                            try
                            {
#if DEBUG
                                Process.Start("openPDC.exe");
#else
                                m_openPdcServiceController.Start();
#endif
                            }
                            catch
                            {
                                MessageBox.Show("The configuration utility was unable to start openPDC service, you will need to manually start the service.", "Cannot Start Windows Service", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }

                        // If the user requested it, start the openPDC Manager.
                        if (m_managerStartCheckBox.IsChecked.Value)
                        {
                            Process.Start("openPDCManager.exe");
                        }
                    }
                    finally
                    {
                        if (m_openPdcServiceController != null)
                            m_openPdcServiceController.Close();
                    }
                }

                return true;
            }
        }

        /// <summary>
        /// Collection shared among screens that represents the state of the setup.
        /// </summary>
        public Dictionary<string, object> State
        {
            get
            {
                return m_state;
            }
            set
            {
                m_state = value;

                if (Convert.ToBoolean(m_state["restarting"]))
                    m_serviceStartCheckBox.Content = "Restart the openPDC";
            }
        }

        /// <summary>
        /// Allows the screen to update the navigation buttons after a change is made
        /// that would affect the user's ability to navigate to other screens.
        /// </summary>
        public Action UpdateNavigation
        {
            get;
            set;
        }

        #endregion

        #region [ Methods ]

        // Initializes the openPDC service controller.
        private void InitializeOpenPdcServiceController()
        {
            ServiceController[] services = ServiceController.GetServices();
            m_openPdcServiceController = services.SingleOrDefault(svc => string.Compare(svc.ServiceName, "openPDC", true) == 0);
        }

        // Initializes the state of the openPDC service checkbox.
        private void InitializeServiceCheckboxState()
        {
#if DEBUG
            bool serviceInstalled = File.Exists("openPDC.exe");
#else
            bool serviceInstalled = m_openPdcServiceController != null;
#endif
            m_serviceStartCheckBox.IsChecked = serviceInstalled;
            m_serviceStartCheckBox.IsEnabled = serviceInstalled;
        }

        // Initializes the state of the openPDC Manager checkbox.
        private void InitializeManagerCheckboxState()
        {
            bool managerInstalled = File.Exists("openPDCManager.exe");
            m_managerStartCheckBox.IsChecked = managerInstalled;
            m_managerStartCheckBox.IsEnabled = managerInstalled;
        }

        private void ValidateTimeSeriesStartupOperations()
        {
            const string countQuery = "SELECT COUNT(*) FROM DataOperation WHERE MethodName = 'PerformTimeSeriesStartupOperations'";
            const string insertQuery = "INSERT INTO DataOperation(Description, AssemblyName, TypeName, MethodName, Arguments, LoadOrder, Enabled) VALUES('Time Series Startup Operations', 'GSF.TimeSeries.dll', 'GSF.TimeSeries.TimeSeriesStartupOperations', 'PerformTimeSeriesStartupOperations', '', 0, 1)";

            IDbConnection connection = null;
            int timeSeriesStartupOperationsCount;

            try
            {
                connection = OpenNewConnection();
                timeSeriesStartupOperationsCount = Convert.ToInt32(connection.ExecuteScalar(countQuery));

                if (timeSeriesStartupOperationsCount == 0)
                    connection.ExecuteNonQuery(insertQuery);
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }
        }

        private void ValidateInternalDataPublisher()
        {
            string configFile = Directory.GetCurrentDirectory() + "\\openPDC.exe.config";
            string configText = File.ReadAllText(configFile);
            string replacedConfigText = configText.Replace("<datapublisher>", "<internaldatapublisher>").Replace("</datapublisher>", "</internaldatapublisher>");
            File.WriteAllText(configFile, replacedConfigText);
        }

        private void ValidateGridSolutionsNamespaces()
        {
            const string assemblyNameUpdateQuery = "UPDATE {0} SET AssemblyName = '{1}' WHERE AssemblyName = '{2}'";
            const string typeNameUpdateQuery = "UPDATE {0} SET TypeName = '{1}' WHERE TypeName = '{2}'";

            string[] tables = { "DataOperation", "Historian", "Protocol", "CustomInputAdapter", "CustomActionAdapter", "CustomOutputAdapter", "CalculatedMeasurement", "Statistic" };

            Tuple<string, string>[] assemblyNames = { Tuple.Create("GSF.TimeSeries.dll", "TimeSeriesFramework.dll"), Tuple.Create("PhasorProtocolAdapters.dll", "TVA.PhasorProtocols.dll") };

            Tuple<string, string>[] typeNames =
            {
                Tuple.Create("GSF.TimeSeries.TimeSeriesStartupOperations", "TimeSeriesFramework.TimeSeriesStartupOperations"),
                Tuple.Create("GSF.TimeSeries.Transport.DataSubscriber", "TimeSeriesFramework.Transport.DataSubscriber"),
                Tuple.Create("GSF.TimeSeries.Transport.DataPublisher", "TimeSeriesFramework.Transport.DataPublisher"),
                Tuple.Create("GSF.TimeSeries.Statistics.StatisticsEngine", "TimeSeriesFramework.Statistics.StatisticsEngine"),
                Tuple.Create("GSF.TimeSeries.Statistics.PerformanceStatistics", "TimeSeriesFramework.Statistics.PerformanceStatistics"),
                Tuple.Create("GSF.TimeSeries.Statistics.GatewayStatistics", "TimeSeriesFramework.Statistics.GatewayStatistics"),
                Tuple.Create("PhasorProtocolAdapters.CommonPhasorServices", "TVA.PhasorProtocols.CommonPhasorServices"),
                Tuple.Create("PhasorProtocolAdapters.PhasorMeasurementMapper", "TVA.PhasorProtocols.PhasorMeasurementMapper")
            };

            IDbConnection connection = null;

            try
            {
                connection = OpenNewConnection();

                foreach (string table in tables)
                {
                    foreach (Tuple<string, string> assemblyNamePair in assemblyNames)
                        connection.ExecuteNonQuery(string.Format(assemblyNameUpdateQuery, table, assemblyNamePair.Item1, assemblyNamePair.Item2));

                    foreach (Tuple<string, string> typeNamePair in typeNames)
                        connection.ExecuteNonQuery(string.Format(typeNameUpdateQuery, table, typeNamePair.Item1, typeNamePair.Item2));
                }
            }
            finally
            {
                if ((object)connection != null)
                    connection.Dispose();
            }
        }

        private void ValidatePhasorDataSourceValidation()
        {
            const string updateQuery = "UPDATE DataOperation SET Arguments = 'skipOptimization = True' WHERE AssemblyName = 'GSF.PhasorProtocols.dll' AND TypeName = 'GSF.PhasorProtocols.CommonPhasorServices' AND MethodName = 'PhasorDataSourceValidation'";
            IDbConnection connection = null;

            try
            {
                connection = OpenNewConnection();
                connection.ExecuteNonQuery(updateQuery);
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }
        }

        private void ValidateConfigurationEntity()
        {
            const string countQuery = "SELECT COUNT(*) FROM ConfigurationEntity WHERE RuntimeName = 'NodeInfo'";
            const string insertQuery = "INSERT INTO ConfigurationEntity(SourceName, RuntimeName, Description, LoadOrder, Enabled) VALUES('NodeInfo', 'NodeInfo', 'Defines information about the nodes in the database', 18, 1)";

            IDbConnection connection = null;
            int configurationEntityCount;

            try
            {
                connection = OpenNewConnection();
                configurationEntityCount = Convert.ToInt32(connection.ExecuteScalar(countQuery));

                if (configurationEntityCount == 0)
                    connection.ExecuteNonQuery(insertQuery);
            }
            finally
            {
                if ((object)connection != null)
                    connection.Dispose();
            }
        }

        private void ValidateNodeSettings()
        {
            const string settingsQuery = "SELECT Settings FROM Node WHERE ID = '{0}'";
            string updateQuery = "UPDATE Node SET Settings = @settings WHERE ID = '{0}'";

            object selectedNodeId;
            string nodeIDQueryString;

            IDbConnection connection = null;
            object nodeSettingsConnectionString;
            Dictionary<string, string> nodeSettings;

            Dictionary<string, string> remoteStatusServerSettings;
            string remoteStatusServerConnectionString;
            string alarmServiceUrl;

            try
            {
                // Ensure that there is a selected node ID
                if (m_state.TryGetValue("selectedNodeId", out selectedNodeId) && !string.IsNullOrWhiteSpace(selectedNodeId.ToNonNullString()))
                {
                    // Open new connection
                    nodeIDQueryString = selectedNodeId.ToString();
                    connection = OpenNewConnection();

                    // Get node settings from the database
                    nodeSettingsConnectionString = connection.ExecuteScalar(string.Format(settingsQuery, nodeIDQueryString));
                    nodeSettings = nodeSettingsConnectionString.ToNonNullString().ParseKeyValuePairs();

                    // Make sure security settings are enabled for the node
                    if (!nodeSettings.TryGetValue("RemoteStatusServerConnectionString", out remoteStatusServerConnectionString))
                    {
                        nodeSettings.Add("RemoteStatusServerConnectionString", "server=localhost:8500;integratedSecurity=true");
                    }
                    else
                    {
                        remoteStatusServerSettings = remoteStatusServerConnectionString.ParseKeyValuePairs();
                        remoteStatusServerSettings["integratedSecurity"] = "true";
                        nodeSettings["RemoteStatusServerConnectionString"] = remoteStatusServerSettings.JoinKeyValuePairs();
                    }

                    // If the AlarmServiceUrl does not exist in node settings, add it and then update the database record
                    if (!nodeSettings.TryGetValue("AlarmServiceUrl", out alarmServiceUrl))
                        nodeSettings.Add("AlarmServiceUrl", "http://localhost:5018/alarmservices");

                    // Execute query to update node settings
                    if (connection.GetType().Name == "OracleConnection")
                        updateQuery = updateQuery.Replace('@', ':');

                    connection.ExecuteNonQuery(string.Format(updateQuery, nodeIDQueryString), nodeSettings.JoinKeyValuePairs());
                }
            }
            finally
            {
                // Dispose of the connection if it was opened
                if ((object)connection != null)
                    connection.Dispose();
            }
        }

        private void ValidateSecurityRoles()
        {
            // For each Node in new database make sure all roles exist
            IDataReader nodeReader = null;
            IDbConnection connection = OpenNewConnection();

            if (connection != null)
            {
                try
                {
                    IDbCommand nodeCommand;
                    string databaseType = m_state["newDatabaseType"].ToString();

                    nodeCommand = connection.CreateCommand();
                    nodeCommand.CommandText = "SELECT ID FROM Node";

                    using (nodeReader = nodeCommand.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(nodeReader);

                        if (nodeReader != null)
                            nodeReader.Close();

                        foreach (DataRow row in dataTable.Rows)
                        {
                            string nodeID = string.Format("'{0}'", row["ID"].ToNonNullString());
                            IDbCommand command = connection.CreateCommand();

                            command.CommandText = string.Format("SELECT COUNT(*) FROM ApplicationRole WHERE NodeID = {0} AND Name = 'Administrator'", nodeID);
                            if (Convert.ToInt32(command.ExecuteScalar()) == 0)
                                AddRolesForNode(connection, nodeID, "Administrator");
                            else
                                VerifyAdminUser(connection, nodeID); // Verify an admin user exists for the node and attached to administrator role.

                            command.CommandText = string.Format("SELECT COUNT(*) FROM ApplicationRole WHERE NodeID = {0} AND Name = 'Editor'", nodeID);
                            if (Convert.ToInt32(command.ExecuteScalar()) == 0)
                                AddRolesForNode(connection, nodeID, "Editor");

                            command.CommandText = string.Format("SELECT COUNT(*) FROM ApplicationRole WHERE NodeID = {0} AND Name = 'Viewer'", nodeID);
                            if (Convert.ToInt32(command.ExecuteScalar()) == 0)
                                AddRolesForNode(connection, nodeID, "Viewer");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to validate application roles: " + ex.Message, "Configuration Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (connection != null)
                        connection.Dispose();
                }
            }
        }

        /// <summary>
        /// Adds role for newly added node (Administrator, Editor, Viewer).
        /// </summary>
        /// <param name="connection">IDbConnection to be used for database operations.</param>
        /// <param name="nodeID">Node ID to which three roles are being assigned</param>        
        private void AddRolesForNode(IDbConnection connection, string nodeID, string roleName)
        {
            IDbCommand adminCredentialCommand;
            adminCredentialCommand = connection.CreateCommand();

            if (roleName == "Administrator")
                adminCredentialCommand.CommandText = string.Format("INSERT INTO ApplicationRole(Name, Description, NodeID, UpdatedBy, CreatedBy) VALUES('Administrator', 'Administrator Role', {0}, '{1}', '{2}')", nodeID, Thread.CurrentPrincipal.Identity.Name, Thread.CurrentPrincipal.Identity.Name);
            else if (roleName == "Editor")
                adminCredentialCommand.CommandText = string.Format("INSERT INTO ApplicationRole(Name, Description, NodeID, UpdatedBy, CreatedBy) VALUES('Editor', 'Editor Role', {0}, '{1}', '{2}')", nodeID, Thread.CurrentPrincipal.Identity.Name, Thread.CurrentPrincipal.Identity.Name);
            else
                adminCredentialCommand.CommandText = string.Format("INSERT INTO ApplicationRole(Name, Description, NodeID, UpdatedBy, CreatedBy) VALUES('Viewer', 'Viewer Role', {0}, '{1}', '{2}')", nodeID, Thread.CurrentPrincipal.Identity.Name, Thread.CurrentPrincipal.Identity.Name);

            adminCredentialCommand.ExecuteNonQuery();

            if (roleName == "Administrator")    //verify admin user exists for the node and attached to administrator role.
                VerifyAdminUser(connection, nodeID);
        }

        private void VerifyAdminUser(IDbConnection connection, string nodeID)
        {
            // Lookup administrator role ID
            IDbCommand command = connection.CreateCommand();
            command.CommandText = string.Format("SELECT ID FROM ApplicationRole WHERE Name = 'Administrator' AND NodeID = {0}", nodeID);
            string adminRoleID = command.ExecuteScalar().ToNonNullString();
            string databaseType = m_state["newDatabaseType"].ToString();

            adminRoleID = adminRoleID.StartsWith("'") ? adminRoleID : "'" + adminRoleID + "'";

            // Check if there is any user associated with the administrator role ID in the ApplicationRoleUserAccount table.
            // if so that means there is atleast one user associated with that role. So we do not need to take any action.
            // if not that means, user provided on the screen must be attached to this role. Also check if that user exists in 
            // the UserAccount table. If so, then get the ID otherwise add user and retrieve ID.
            command.CommandText = string.Format("SELECT COUNT(*) FROM ApplicationRoleUserAccount WHERE ApplicationRoleID = {0}", adminRoleID);
            if (Convert.ToInt32(command.ExecuteScalar()) == 0)
            {
                if (m_state.ContainsKey("adminUserName"))   //i.e. if security setup screen was displayed during setup.
                {
                    command.CommandText = string.Format("Select ID FROM UserAccount WHERE Name = '{0}'", m_state["adminUserName"].ToString());
                    string adminUserID = command.ExecuteScalar().ToNonNullString();

                    if (!string.IsNullOrEmpty(adminUserID)) //if user exists then attach it to admin role and we'll be done with it.
                    {
                        adminUserID = adminUserID.StartsWith("'") ? adminUserID : "'" + adminUserID + "'";
                        command.CommandText = string.Format("INSERT INTO ApplicationRoleUserAccount(ApplicationRoleID, UserAccountID) VALUES({0}, {1})", adminRoleID, adminUserID);
                        command.ExecuteNonQuery();
                    }
                    else    //we need to add user to the UserAccount table and then attach it to admin role.
                    {
                        bool databaseIsOracle = (databaseType == "Oracle");
                        char paramChar = databaseIsOracle ? ':' : '@';

                        // Add Administrative User.                
                        IDbCommand adminCredentialCommand = connection.CreateCommand();
                        if (m_state["authenticationType"].ToString() == "windows")
                        {
                            IDbDataParameter nameParameter = adminCredentialCommand.CreateParameter();
                            IDbDataParameter createdByParameter = adminCredentialCommand.CreateParameter();
                            IDbDataParameter updatedByParameter = adminCredentialCommand.CreateParameter();

                            nameParameter.ParameterName = paramChar + "name";
                            createdByParameter.ParameterName = paramChar + "createdBy";
                            updatedByParameter.ParameterName = paramChar + "updatedBy";

                            nameParameter.Value = m_state["adminUserName"].ToString();
                            createdByParameter.Value = Thread.CurrentPrincipal.Identity.Name;
                            updatedByParameter.Value = Thread.CurrentPrincipal.Identity.Name;

                            adminCredentialCommand.Parameters.Add(nameParameter);
                            adminCredentialCommand.Parameters.Add(createdByParameter);
                            adminCredentialCommand.Parameters.Add(updatedByParameter);

                            if (databaseIsOracle)
                                adminCredentialCommand.CommandText = string.Format("INSERT INTO UserAccount(Name, DefaultNodeID, CreatedBy, UpdatedBy) VALUES(:name, {0}, :createdBy, :updatedBy)", nodeID);
                            else
                                adminCredentialCommand.CommandText = string.Format("INSERT INTO UserAccount(Name, DefaultNodeID, CreatedBy, UpdatedBy) VALUES(@name, {0}, @createdBy, @updatedBy)", nodeID);
                        }
                        else
                        {
                            IDbDataParameter nameParameter = adminCredentialCommand.CreateParameter();
                            IDbDataParameter passwordParameter = adminCredentialCommand.CreateParameter();
                            IDbDataParameter firstNameParameter = adminCredentialCommand.CreateParameter();
                            IDbDataParameter lastNameParameter = adminCredentialCommand.CreateParameter();
                            IDbDataParameter createdByParameter = adminCredentialCommand.CreateParameter();
                            IDbDataParameter updatedByParameter = adminCredentialCommand.CreateParameter();

                            nameParameter.ParameterName = paramChar + "name";
                            passwordParameter.ParameterName = paramChar + "password";
                            firstNameParameter.ParameterName = paramChar + "firstName";
                            lastNameParameter.ParameterName = paramChar + "lastName";
                            createdByParameter.ParameterName = paramChar + "createdBy";
                            updatedByParameter.ParameterName = paramChar + "updatedBy";

                            nameParameter.Value = m_state["adminUserName"].ToString();
                            passwordParameter.Value = SecurityProviderUtility.EncryptPassword(m_state["adminPassword"].ToString());
                            firstNameParameter.Value = m_state["adminUserFirstName"].ToString();
                            lastNameParameter.Value = m_state["adminUserLastName"].ToString();
                            createdByParameter.Value = Thread.CurrentPrincipal.Identity.Name;
                            updatedByParameter.Value = Thread.CurrentPrincipal.Identity.Name;

                            adminCredentialCommand.Parameters.Add(nameParameter);
                            adminCredentialCommand.Parameters.Add(passwordParameter);
                            adminCredentialCommand.Parameters.Add(firstNameParameter);
                            adminCredentialCommand.Parameters.Add(lastNameParameter);
                            adminCredentialCommand.Parameters.Add(createdByParameter);
                            adminCredentialCommand.Parameters.Add(updatedByParameter);

                            if (databaseIsOracle)
                                adminCredentialCommand.CommandText = string.Format("INSERT INTO UserAccount(Name, Password, FirstName, LastName, DefaultNodeID, UseADAuthentication, CreatedBy, UpdatedBy) VALUES" +
                                    "(:name, :password, :firstName, :lastName, {0}, 0, :createdBy, :updatedBy)", nodeID);
                            else
                                adminCredentialCommand.CommandText = string.Format("INSERT INTO UserAccount(Name, Password, FirstName, LastName, DefaultNodeID, UseADAuthentication, CreatedBy, UpdatedBy) VALUES" +
                                    "(@name, @password, @firstName, @lastName, {0}, 0, @createdBy, @updatedBy)", nodeID);
                        }

                        adminCredentialCommand.ExecuteNonQuery();

                        // Get the admin user ID from the database.
                        IDataReader userIdReader = null;
                        IDbDataParameter newNameParameter = adminCredentialCommand.CreateParameter();

                        newNameParameter.ParameterName = paramChar + "name";
                        newNameParameter.Value = m_state["adminUserName"].ToString();

                        adminCredentialCommand.CommandText = "SELECT ID FROM UserAccount WHERE Name = " + paramChar + "name";
                        adminCredentialCommand.Parameters.Clear();
                        adminCredentialCommand.Parameters.Add(newNameParameter);

                        using (userIdReader = adminCredentialCommand.ExecuteReader())
                        {
                            if (userIdReader.Read())
                                adminUserID = userIdReader["ID"].ToNonNullString();
                        }

                        // Assign Administrative User to Administrator Role.
                        if (!string.IsNullOrEmpty(adminRoleID) && !string.IsNullOrEmpty(adminUserID))
                        {
                            adminUserID = adminUserID.StartsWith("'") ? adminUserID : "'" + adminUserID + "'";
                            adminCredentialCommand.CommandText = string.Format("INSERT INTO ApplicationRoleUserAccount(ApplicationRoleID, UserAccountID) VALUES ({0}, {1})", adminRoleID, adminUserID);
                            adminCredentialCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void ConvertNodeTableFormat()
        {
            IDbConnection oldConnection = OpenOldConnection();

            if (oldConnection != null)
            {
                IDbCommand nodeCommand;

                //Dictionary<string, string> settings = m_state["oldConnectionString"].ToString().ParseKeyValuePairs();
                //string oldDatabaseType = "undetermined";

                //switch (oldConnection.GetType().Name)
                //{
                //    case "SqlConnection":
                //        oldDatabaseType = "SQLServer";
                //        break;
                //    case "MySqlConnection":
                //        oldDatabaseType = "MySQL";
                //        break;
                //    case "OracleConnection":
                //        oldDatabaseType = "Oracle";
                //        break;
                //    case "SQLiteConnection":
                //        oldDatabaseType = "SQLite";
                //        break;
                //    case "OleDbConnection":
                //        string connectionSetting;
                //        if (settings.TryGetValue("Provider", out connectionSetting) && connectionSetting.StartsWith("Microsoft.Jet.OLEDB", StringComparison.OrdinalIgnoreCase))
                //            oldDatabaseType = "access";
                //        break;
                //}

                nodeCommand = oldConnection.CreateCommand();
                nodeCommand.CommandText = "SELECT * FROM Node";
                using (IDataReader nodeReader = nodeCommand.ExecuteReader())
                {

                    DataTable dataTable = new DataTable();
                    dataTable.Load(nodeReader);

                    if (nodeReader != null)
                        nodeReader.Close();

                    // See if old database contains old column names
                    if (dataTable.Columns.Contains("TimeSeriesDataServiceUrl"))
                    {
                        IDbConnection newConnection = OpenNewConnection();

                        if (newConnection != null)
                        {
                            // Convert original columns into connection settings format
                            foreach (DataRow row in dataTable.Rows)
                            {
                                string nodeID = string.Format("'{0}'", row["ID"].ToNonNullString());
                                string remoteStatusServer = row["RemoteStatusServiceUrl"].ToNonNullString();
                                string realTimeStatisticServiceUrl = row["RealTimeStatisticServiceUrl"].ToNonNullString();

                                // Make sure remote status server contains a data publisher port
                                Dictionary<string, string> remoteStatusServerSettings = remoteStatusServer.ParseKeyValuePairs();

                                if (!remoteStatusServerSettings.ContainsKey("dataPublisherPort"))
                                {
                                    remoteStatusServerSettings["dataPublisherPort"] = "6165";
                                    remoteStatusServer = remoteStatusServerSettings.JoinKeyValuePairs();
                                }

                                string connectionSettings = string.Format("RemoteStatusServerConnectionString={{{0}}}; RealTimeStatisticServiceUrl={1}", remoteStatusServer, realTimeStatisticServiceUrl);

                                IDbCommand command = newConnection.CreateCommand();
                                command.CommandText = string.Format("UPDATE Node SET Settings = '{0}' WHERE ID = {1}", connectionSettings, nodeID);
                                command.ExecuteNonQuery();
                            }

                            newConnection.Dispose();
                        }
                    }
                }
                oldConnection.Dispose();
            }
        }

        private IDbConnection OpenOldConnection()
        {
            IDbConnection connection = null;

            try
            {
                string connectionString, dataProviderString;

                if (m_state.ContainsKey("oldConnectionString") && !string.IsNullOrWhiteSpace(m_state["oldConnectionString"].ToString()))
                    connectionString = m_state["oldConnectionString"].ToString();
                else
                    connectionString = null;

                if (m_state.ContainsKey("oldDataProviderString") && !string.IsNullOrWhiteSpace(m_state["oldDataProviderString"].ToString()))
                    dataProviderString = m_state["oldDataProviderString"].ToString();
                else
                    dataProviderString = null;

                if (connectionString != null && dataProviderString != null)
                {
                    Dictionary<string, string> dataProviderSettings = dataProviderString.ParseKeyValuePairs();
                    string assemblyName = dataProviderSettings["AssemblyName"];
                    string connectionTypeName = dataProviderSettings["ConnectionType"];

                    Assembly assembly = Assembly.Load(new AssemblyName(assemblyName));
                    Type connectionType = assembly.GetType(connectionTypeName);
                    connection = (IDbConnection)Activator.CreateInstance(connectionType);
                    connection.ConnectionString = connectionString;
                    connection.Open();
                }
            }
            catch
            {
                if (connection != null)
                    connection.Dispose();
                connection = null;
            }

            return connection;
        }

        private IDbConnection OpenNewConnection()
        {
            IDbConnection connection = null;

            try
            {
                string databaseType = m_state["newDatabaseType"].ToString();
                string connectionString = null;
                string dataProviderString = null;

                if (databaseType == "SQLServer")
                {
                    SqlServerSetup sqlServerSetup = m_state["sqlServerSetup"] as SqlServerSetup;
                    connectionString = sqlServerSetup.ConnectionString;
                    dataProviderString = sqlServerSetup.DataProviderString;

                    if (string.IsNullOrWhiteSpace(dataProviderString))
                        dataProviderString = "AssemblyName={System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089}; ConnectionType=System.Data.SqlClient.SqlConnection; AdapterType=System.Data.SqlClient.SqlDataAdapter";
                }
                else if (databaseType == "MySQL")
                {
                    MySqlSetup mySqlSetup = m_state["mySqlSetup"] as MySqlSetup;
                    connectionString = mySqlSetup.ConnectionString;
                    dataProviderString = mySqlSetup.DataProviderString;

                    if (string.IsNullOrWhiteSpace(dataProviderString))
                        dataProviderString = "AssemblyName={MySql.Data, Version=6.5.4.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d}; ConnectionType=MySql.Data.MySqlClient.MySqlConnection; AdapterType=MySql.Data.MySqlClient.MySqlDataAdapter";
                }
                else if (databaseType == "Oracle")
                {
                    OracleSetup oracleSetup = m_state["oracleSetup"] as OracleSetup;
                    connectionString = oracleSetup.ConnectionString;
                    dataProviderString = oracleSetup.DataProviderString;

                    if (string.IsNullOrWhiteSpace(dataProviderString))
                        dataProviderString = OracleSetup.DefaultDataProviderString;
                }
                else
                {
                    string destination = m_state["sqliteDatabaseFilePath"].ToString();
                    connectionString = "Data Source=" + destination + "; Version=3";
                    dataProviderString = "AssemblyName={System.Data.SQLite, Version=1.0.93.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139}; ConnectionType=System.Data.SQLite.SQLiteConnection; AdapterType=System.Data.SQLite.SQLiteDataAdapter";
                }

                if (!string.IsNullOrEmpty(connectionString) && !string.IsNullOrEmpty(dataProviderString))
                {
                    Dictionary<string, string> dataProviderSettings = dataProviderString.ParseKeyValuePairs();
                    string assemblyName = dataProviderSettings["AssemblyName"];
                    string connectionTypeName = dataProviderSettings["ConnectionType"];

                    Assembly assembly = Assembly.Load(new AssemblyName(assemblyName));
                    Type connectionType = assembly.GetType(connectionTypeName);
                    connection = (IDbConnection)Activator.CreateInstance(connectionType);
                    connection.ConnectionString = connectionString;
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open new database connection: " + ex.Message, "Configuration Error", MessageBoxButton.OK, MessageBoxImage.Error);

                if (connection != null)
                    connection.Dispose();

                connection = null;
            }

            return connection;
        }

        #endregion
    }
}
