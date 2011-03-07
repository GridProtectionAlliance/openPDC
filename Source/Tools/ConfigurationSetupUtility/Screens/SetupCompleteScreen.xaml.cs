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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Windows;
using System.Windows.Controls;
using TVA.Configuration;
using TVA.Identity;
using TVA.IO;
using TVA;
using System.Reflection;
using System.Data;
using System.Threading;
using System.Web.Security;

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
            App.Current.Exit += Current_Exit;
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
            bool serviceInstalled = m_openPdcServiceController != null;
            m_serviceStartCheckBox.IsChecked = serviceInstalled;
            m_serviceStartCheckBox.IsEnabled = serviceInstalled;
        }

        // Initializes the state of the openPDC Manager checkbox.
        private void InitializeManagerCheckboxState()
        {
            bool managerInstalled = File.Exists("openPDCManager.exe");
            string[] args = Environment.GetCommandLineArgs();
            bool installFlag = args.Contains("-install", StringComparer.CurrentCultureIgnoreCase);

            m_managerStartCheckBox.IsChecked = managerInstalled;
            m_managerStartCheckBox.IsEnabled = managerInstalled;
        }

        // Occurs just before the application shuts down.
        private void Current_Exit(object sender, System.Windows.ExitEventArgs e)
        {
            if (m_state != null)
            {
                try
                {
                    bool existing = Convert.ToBoolean(m_state["existing"]);
                    bool migrate = existing && Convert.ToBoolean(m_state["updateConfiguration"]);

                    if (migrate)
                    {
                        string dataFolder = FilePath.GetApplicationDataFolder();
                        string migrationDataFolder = dataFolder + "\\..\\DataMigrationUtility";
                        string newOleDbConnectionString = m_state["newOleDbConnectionString"].ToString();
                        string databaseType = m_state["databaseType"].ToString().Replace(" ", "");
                        ConfigurationFile configFile = null;
                        CategorizedSettingsElementCollection applicationSettings = null;

                        // Copy user-level DataMigrationUtility config file to the ConfigurationSetupUtility application folder.
                        if (File.Exists(migrationDataFolder + "\\Settings.xml"))
                        {
                            if (!Directory.Exists(dataFolder))
                                Directory.CreateDirectory(dataFolder);

                            File.Copy(migrationDataFolder + "\\Settings.xml", dataFolder + "\\Settings.xml", true);
                        }

                        // Modify OleDB configuration file settings for the DataMigrationUtility.
                        configFile = ConfigurationFile.Open("DataMigrationUtility.exe.config");
                        applicationSettings = configFile.Settings["applicationSettings"];
                        applicationSettings["FromDataType", true].Value = "Unspecified";
                        applicationSettings["ToConnectionString", true].Value = newOleDbConnectionString;
                        applicationSettings["ToDataType", true].Value = databaseType;

                        if (m_state.ContainsKey("oldOleDbConnectionString"))
                        {
                            string oldOleDbConnectionString = m_state["oldOleDbConnectionString"].ToString();
                            applicationSettings["FromConnectionString", true].Value = oldOleDbConnectionString;

                            if (m_state.ContainsKey("oldOleDbDataType"))
                                applicationSettings["FromDataType", true].Value = m_state["oldOleDbDataType"].ToString();
                        }

                        configFile.Save();

                        // Copy user-level ConfigurationSetupUtility config file to DataMigrationUtility application folder.
                        if (File.Exists(dataFolder + "\\Settings.xml"))
                        {
                            if (!Directory.Exists(migrationDataFolder))
                                Directory.CreateDirectory(migrationDataFolder);

                            File.Copy(dataFolder + "\\Settings.xml", migrationDataFolder + "\\Settings.xml", true);
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

                    // Always make sure that all three needed roles are available for each defined node(s) in the database.
                    ValidateSecurityRoles();
                    
                    // If the user requested it, start or restart the openPDC service.
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
                        if (UserAccountControl.IsUacEnabled && UserAccountControl.IsCurrentProcessElevated)
                        {
                            try
                            {
                                UserAccountControl.CreateProcessAsStandardUser("openPDCManager.exe");
                            }
                            catch
                            {
                                Process.Start("openPDCManager.exe");
                            }
                        }
                        else
                            Process.Start("openPDCManager.exe");
                    }
                }
                finally
                {
                    if (m_openPdcServiceController != null)
                        m_openPdcServiceController.Close();
                }
            }
        }

        private void ValidateSecurityRoles()
        {
            //For each Node in new database make sure all roles exist
            IDataReader nodeReader = null;
            IDbConnection connection = null;
            try
            {
                string databaseType = m_state["databaseType"].ToString();
                string connectionString = string.Empty;
                string dataProviderString = string.Empty;

                if (databaseType == "access")
                {
                    string destination = m_state["accessDatabaseFilePath"].ToString();
                    connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + destination;
                    dataProviderString = "AssemblyName={System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089}; ConnectionType=System.Data.OleDb.OleDbConnection; AdapterType=System.Data.OleDb.OleDbDataAdapter";
                }
                else if (databaseType == "sql server")
                {
                    SqlServerSetup sqlServerSetup = m_state["sqlServerSetup"] as SqlServerSetup;
                    connectionString = sqlServerSetup.ConnectionString;

                    object dataProviderStringValue;
                    if (m_state.TryGetValue("sqlServerDataProviderString", out dataProviderStringValue))
                        dataProviderString = dataProviderStringValue.ToString();

                    if (string.IsNullOrWhiteSpace(dataProviderString))
                        dataProviderString = "AssemblyName={System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089}; ConnectionType=System.Data.SqlClient.SqlConnection; AdapterType=System.Data.SqlClient.SqlDataAdapter";
                }
                else
                {
                    MySqlSetup mySqlSetup = m_state["mySqlSetup"] as MySqlSetup;
                    connectionString = mySqlSetup.ConnectionString;

                    object dataProviderStringValue;
                    // Get user customized data provider string
                    if (m_state.TryGetValue("mySqlDataProviderString", out dataProviderStringValue))
                        dataProviderString = dataProviderStringValue.ToString();

                    if (string.IsNullOrWhiteSpace(dataProviderString))
                        dataProviderString = "AssemblyName={MySql.Data, Version=6.3.4.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d}; ConnectionType=MySql.Data.MySqlClient.MySqlConnection; AdapterType=MySql.Data.MySqlClient.MySqlDataAdapter";
                }

                if (!string.IsNullOrEmpty(connectionString) && !string.IsNullOrEmpty(dataProviderString))
                {
                    Dictionary<string, string> settings = connectionString.ParseKeyValuePairs();
                    Dictionary<string, string> dataProviderSettings = dataProviderString.ParseKeyValuePairs();
                    string assemblyName = dataProviderSettings["AssemblyName"];
                    string connectionTypeName = dataProviderSettings["ConnectionType"];
                    string connectionSetting;

                    Assembly assembly = Assembly.Load(new AssemblyName(assemblyName));
                    Type connectionType = assembly.GetType(connectionTypeName);
                    
                    if (settings.TryGetValue("Provider", out connectionSetting))
                    {
                        // Check if provider is for Access to make sure the path is fully qualified.
                        if (connectionSetting.StartsWith("Microsoft.Jet.OLEDB", StringComparison.OrdinalIgnoreCase))
                        {
                            if (settings.TryGetValue("Data Source", out connectionSetting))
                            {
                                settings["Data Source"] = FilePath.GetAbsolutePath(connectionSetting);
                                connectionString = settings.JoinKeyValuePairs();
                            }
                        }
                    }

                    connection = (IDbConnection)Activator.CreateInstance(connectionType);
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    IDbCommand nodeCommand;
                    
                    nodeCommand = connection.CreateCommand();
                    nodeCommand.CommandText = "SELECT ID FROM Node";
                    nodeReader = nodeCommand.ExecuteReader();

                    DataTable dataTable = new DataTable();
                    dataTable.Load(nodeReader);

                    if (nodeReader != null) nodeReader.Close();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        string nodeID = row["ID"].ToNonNullString();

                        if (settings.TryGetValue("Provider", out connectionSetting))
                        {
                            // Check if provider is for Access since it uses braces as Guid delimeters
                            if (connectionSetting.StartsWith("Microsoft.Jet.OLEDB", StringComparison.OrdinalIgnoreCase))
                                nodeID = "{" + nodeID + "}";
                        }
                        else
                            nodeID = "'" + nodeID + "'";

                        IDbCommand command = connection.CreateCommand();

                        command.CommandText = string.Format("Select Count(*) From ApplicationRole Where NodeID = {0} AND Name = 'Administrator'", nodeID);
                        if (Convert.ToInt32(command.ExecuteScalar()) == 0)
                            AddRolesForNode(connection, nodeID, "Administrator");
                        else    //verify admin user exists for the node and attached to administrator role.
                            VerifyAdminUser(connection, nodeID);

                        command.CommandText = string.Format("Select Count(*) From ApplicationRole Where NodeID = {0} AND Name = 'Editor'", nodeID);
                        if (Convert.ToInt32(command.ExecuteScalar()) == 0)
                            AddRolesForNode(connection, nodeID, "Editor");

                        command.CommandText = string.Format("Select Count(*) From ApplicationRole Where NodeID = {0} AND Name = 'Viewer'", nodeID);
                        if (Convert.ToInt32(command.ExecuteScalar()) == 0)
                            AddRolesForNode(connection, nodeID, "Viewer");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Validate Application Roles for Node(s)" + Environment.NewLine + ex.Message);
            }
            finally
            {
                if (nodeReader != null)
                    nodeReader.Close();

                if (connection != null)
                    connection.Dispose();
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
                adminCredentialCommand.CommandText = string.Format("Insert Into ApplicationRole (Name, Description, NodeID, UpdatedBy, CreatedBy) Values ('Administrator', 'Administrator Role', {0}, '{1}', '{2}')", nodeID, Thread.CurrentPrincipal.Identity.Name, Thread.CurrentPrincipal.Identity.Name);
            else if (roleName == "Editor")
                adminCredentialCommand.CommandText = string.Format("Insert Into ApplicationRole (Name, Description, NodeID, UpdatedBy, CreatedBy) Values ('Editor', 'Editor Role', {0}, '{1}', '{2}')", nodeID, Thread.CurrentPrincipal.Identity.Name, Thread.CurrentPrincipal.Identity.Name);
            else
                adminCredentialCommand.CommandText = string.Format("Insert Into ApplicationRole (Name, Description, NodeID, UpdatedBy, CreatedBy) Values ('Viewer', 'Viewer Role', {0}, '{1}', '{2}')", nodeID, Thread.CurrentPrincipal.Identity.Name, Thread.CurrentPrincipal.Identity.Name);
            
            adminCredentialCommand.ExecuteNonQuery();

            if (roleName == "Administrator")    //verify admin user exists for the node and attached to administrator role.
                VerifyAdminUser(connection, nodeID);
        }

        private void VerifyAdminUser(IDbConnection connection, string nodeID)
        {
            //find out administrator role ID.
            IDbCommand command = connection.CreateCommand();
            command.CommandText = string.Format("SELECT ID FROM ApplicationRole WHERE Name = 'Administrator' AND NodeID = {0}", nodeID);
            string adminRoleID = command.ExecuteScalar().ToNonNullString();

            bool databaseIsAccess = false;
            Dictionary<string, string> settings = connection.ConnectionString.ParseKeyValuePairs();
            string connectionSetting;
            if (settings.TryGetValue("Provider", out connectionSetting))
            {            
                if (connectionSetting.StartsWith("Microsoft.Jet.OLEDB", StringComparison.OrdinalIgnoreCase))
                    databaseIsAccess = true;                    
            }   

            if (databaseIsAccess)
                adminRoleID = adminRoleID.StartsWith("{") ? adminRoleID : "{" + adminRoleID + "}";
            else
                adminRoleID = "'" + adminRoleID + "'";

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
                        if (databaseIsAccess)
                            adminUserID = adminUserID.StartsWith("{") ? adminUserID : "{" + adminUserID + "}";
                        else
                            adminUserID = "'" + adminUserID + "'";

                        command.CommandText = string.Format("INSERT INTO ApplicationRoleUserAccount(ApplicationRoleID, UserAccountID) VALUES ({0}, {1})", adminRoleID, adminUserID);
                        command.ExecuteNonQuery();
                    }
                    else    //we need to add user to the UserAccount table and then attach it to admin role.
                    {
                        // Add Administrative User.                
                        IDbCommand adminCredentialCommand = connection.CreateCommand();
                        if (m_state["authenticationType"].ToString() == "windows")
                        {
                            IDbDataParameter nameParameter = adminCredentialCommand.CreateParameter();
                            IDbDataParameter createdByParameter = adminCredentialCommand.CreateParameter();
                            IDbDataParameter updatedByParameter = adminCredentialCommand.CreateParameter();

                            nameParameter.ParameterName = "@name";
                            createdByParameter.ParameterName = "@createdBy";
                            updatedByParameter.ParameterName = "@updatedBy";

                            nameParameter.Value = m_state["adminUserName"].ToString();
                            createdByParameter.Value = Thread.CurrentPrincipal.Identity.Name;
                            updatedByParameter.Value = Thread.CurrentPrincipal.Identity.Name;

                            adminCredentialCommand.Parameters.Add(nameParameter);
                            adminCredentialCommand.Parameters.Add(createdByParameter);
                            adminCredentialCommand.Parameters.Add(updatedByParameter);

                            adminCredentialCommand.CommandText = string.Format("INSERT INTO UserAccount(Name, DefaultNodeID, CreatedBy, UpdatedBy) Values (@name, {0}, @createdBy, @updatedBy)", nodeID);
                        }
                        else
                        {
                            IDbDataParameter nameParameter = adminCredentialCommand.CreateParameter();
                            IDbDataParameter passwordParameter = adminCredentialCommand.CreateParameter();
                            IDbDataParameter firstNameParameter = adminCredentialCommand.CreateParameter();
                            IDbDataParameter lastNameParameter = adminCredentialCommand.CreateParameter();
                            IDbDataParameter createdByParameter = adminCredentialCommand.CreateParameter();
                            IDbDataParameter updatedByParameter = adminCredentialCommand.CreateParameter();

                            nameParameter.ParameterName = "@name";
                            passwordParameter.ParameterName = "@password";
                            firstNameParameter.ParameterName = "@firstName";
                            lastNameParameter.ParameterName = "@lastName";
                            createdByParameter.ParameterName = "@createdBy";
                            updatedByParameter.ParameterName = "@updatedBy";

                            nameParameter.Value = m_state["adminUserName"].ToString();
                            passwordParameter.Value = FormsAuthentication.HashPasswordForStoringInConfigFile(@"O3990\P78f9E66b:a35_V©6M13©6~2&[" + m_state["adminPassword"].ToString(), "SHA1");
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

                            if (connectionSetting.StartsWith("Microsoft.Jet.OLEDB", StringComparison.OrdinalIgnoreCase))
                                adminCredentialCommand.CommandText = string.Format("INSERT INTO UserAccount(Name, [Password], FirstName, LastName, DefaultNodeID, UseADAuthentication, CreatedBy, UpdatedBy) Values " +
                                    "(@name, @password, @firstName, @lastName, {0}, 0, @createdBy, @updatedBy)", nodeID);
                            else
                                adminCredentialCommand.CommandText = string.Format("INSERT INTO UserAccount(Name, Password, FirstName, LastName, DefaultNodeID, UseADAuthentication, CreatedBy, UpdatedBy) Values " +
                                    "(@name, @password, @firstName, @lastName, {0}, 0, @createdBy, @updatedBy)", nodeID);
                        }

                        adminCredentialCommand.ExecuteNonQuery();

                        // Get the admin user ID from the database.
                        IDataReader userIdReader = null;
                        try
                        {
                            IDbDataParameter nameParameter = adminCredentialCommand.CreateParameter();

                            nameParameter.ParameterName = "@name";
                            nameParameter.Value = m_state["adminUserName"].ToString();

                            adminCredentialCommand.CommandText = "SELECT ID FROM UserAccount WHERE Name = @name";
                            adminCredentialCommand.Parameters.Clear();
                            adminCredentialCommand.Parameters.Add(nameParameter);
                            userIdReader = adminCredentialCommand.ExecuteReader();

                            if (userIdReader.Read())
                                adminUserID = userIdReader["ID"].ToNonNullString();
                        }
                        finally
                        {
                            if (userIdReader != null)
                                userIdReader.Close();
                        }

                        // Assign Administrative User to Administrator Role.
                        if (!string.IsNullOrEmpty(adminRoleID) && !string.IsNullOrEmpty(adminUserID))
                        {
                            if (databaseIsAccess)
                            {
                                adminUserID = adminUserID.StartsWith("{") ? adminUserID : "{" + adminUserID + "}";
                                adminRoleID = adminRoleID.StartsWith("{") ? adminRoleID : "{" + adminRoleID + "}";                             
                            }
                            else
                            {
                                adminUserID = "'" + adminUserID + "'";
                                adminRoleID = "'" + adminRoleID + "'";
                            }

                            adminCredentialCommand.CommandText = string.Format("INSERT INTO ApplicationRoleUserAccount(ApplicationRoleID, UserAccountID) VALUES ({0}, {1})", adminRoleID, adminUserID);
                            adminCredentialCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        #endregion
    }
}
