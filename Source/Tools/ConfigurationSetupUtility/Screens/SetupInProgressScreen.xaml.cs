//******************************************************************************************************
//  SetupInProgressScreen.xaml.cs - Gbtc
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
//  09/09/2010 - Stephen C. Wills
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Xml;
using Microsoft.Win32;
using TVA.Security.Cryptography;

namespace DatabaseSetupUtility
{
    /// <summary>
    /// Interaction logic for SetupInProgressScreen.xaml
    /// </summary>
    public partial class SetupInProgressScreen : UserControl, IScreen
    {

        #region [ Members ]

        // Constants

        private const CipherStrength CryptoStrength = CipherStrength.Aes256;
        private const string DefaultCryptoKey = "0679d9ae-aca5-4702-a3f5-604415096987";

        // Fields

        private bool m_canGoForward;
        private bool m_canGoBack;
        private bool m_canCancel;
        private IScreen m_nextScreen;
        private Dictionary<string, object> m_state;
        private string m_oldConnectionString;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new instance of the <see cref="SetupInProgressScreen"/> class.
        /// </summary>
        public SetupInProgressScreen()
        {
            InitializeComponent();
            m_nextScreen = new SetupCompleteScreen();
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
                return m_nextScreen;
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
                return m_canGoForward;
            }
            private set
            {
                m_canGoForward = value;
                UpdateNavigation();
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
                return m_canGoBack;
            }
            private set
            {
                m_canGoBack = value;
                UpdateNavigation();
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
                return m_canCancel;
            }
            private set
            {
                m_canCancel = value;
                UpdateNavigation();
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
                m_canGoBack = false;
                m_canCancel = false;
                ThreadPool.QueueUserWorkItem(SetUpConfiguration);
            }
        }

        /// <summary>
        /// Allows the screen to update the navigation buttons after a change is made
        /// that would affect the user's ability to navigate to other screens.
        /// </summary>
        public Action UpdateNavigation { get; set; }

        #endregion

        #region [ Methods ]

        // Called when this screen is ready to set up the user's configuration.
        private void SetUpConfiguration(object state)
        {
            string configurationType = m_state["configurationType"].ToString();
            ClearStatusMessages();

            if (configurationType == "database")
                SetUpDatabase();
            else if (configurationType == "xml")
                SetUpXmlConfiguration();
            else
                SetUpWebServiceConfiguration();
        }

        // Called when the setup utility is about to set up the database
        private void SetUpDatabase()
        {
            string databaseType = m_state["databaseType"].ToString();

            if (databaseType == "access")
                SetUpAccessDatabase();
            else if (databaseType == "sql server")
                SetUpSqlServerDatabase();
            else
                SetUpMySqlDatabase();
        }

        // Called when the user has asked to set up an access database.
        private void SetUpAccessDatabase()
        {
            try
            {
                string filePath = null;
                string destination = m_state["accessDatabaseFilePath"].ToString();
                string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + destination;
                bool existing = Convert.ToBoolean(m_state["existing"]);
                bool migrate = existing && Convert.ToBoolean(m_state["updateConfiguration"]);

                if (!existing || migrate)
                {
                    bool initialDataScript = !migrate && Convert.ToBoolean(m_state["initialDataScript"]);
                    bool sampleDataScript = initialDataScript && Convert.ToBoolean(m_state["sampleDataScript"]);

                    if (!initialDataScript)
                        filePath = Directory.GetCurrentDirectory() + "\\Database scripts\\Access\\openPDC.mdb";
                    else if (!sampleDataScript)
                        filePath = Directory.GetCurrentDirectory() + "\\Database scripts\\Access\\openPDC-InitialDataSet.mdb";
                    else
                        filePath = Directory.GetCurrentDirectory() + "\\Database scripts\\Access\\openPDC-SampleDataSet.mdb";

                    UpdateProgressBar(2);
                    AppendStatusMessage(string.Format("Attempting to copy file {0} to {1}...", filePath, destination));

                    // Copy the file to the specified path.
                    File.Copy(filePath, destination);
                    UpdateProgressBar(95);
                    AppendStatusMessage("File copy successful.");
                    AppendStatusMessage(string.Empty);
                }

                // Modify the openPDC configuration file.
                AppendStatusMessage("Attempting to modify configuration files...");
                ModifyConfigFiles(connectionString, "AssemblyName={System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089}; ConnectionType=System.Data.OleDb.OleDbConnection; AdapterType=System.Data.OleDb.OleDbDataAdapter", false);
                m_state["oldOleDbConnectionString"] = m_oldConnectionString;
                m_state["newOleDbConnectionString"] = connectionString;
                AppendStatusMessage("Modification of configuration files was successful.");
                OnSetupSucceeded();
            }
            catch (Exception ex)
            {
                AppendStatusMessage(ex.Message);
                OnSetupFailed();
            }
        }

        // Called when the user has asked to set up a MySQL database.
        private void SetUpMySqlDatabase()
        {
            MySqlSetup mySqlSetup = null;

            try
            {
                MySqlSetup oldConnectionStringSetup = new MySqlSetup();
                bool existing = Convert.ToBoolean(m_state["existing"]);
                bool migrate = existing && Convert.ToBoolean(m_state["updateConfiguration"]);
                string adminUserName, adminPassword;

                mySqlSetup = m_state["mySqlSetup"] as MySqlSetup;
                mySqlSetup.OutputDataReceived += MySqlSetup_OutputDataReceived;
                mySqlSetup.ErrorDataReceived += MySqlSetup_ErrorDataReceived;
                m_state["newOleDbConnectionString"] = mySqlSetup.ConnectionString;
                adminUserName = mySqlSetup.UserName;
                adminPassword = mySqlSetup.Password;

                if (!existing || migrate)
                {
                    List<string> scriptNames = new List<string>();
                    bool initialDataScript = !migrate && Convert.ToBoolean(m_state["initialDataScript"]);
                    bool sampleDataScript = initialDataScript && Convert.ToBoolean(m_state["sampleDataScript"]);
                    bool createNewUser = Convert.ToBoolean(m_state["createNewMySqlUser"]);

                    // Determine which scripts need to be run.
                    scriptNames.Add("openPDC.sql");
                    if (initialDataScript)
                    {
                        scriptNames.Add("InitialDataSet.sql");
                        if (sampleDataScript)
                            scriptNames.Add("SampleDataSet.sql");
                    }

                    foreach (string scriptName in scriptNames)
                    {
                        string scriptPath = Directory.GetCurrentDirectory() + "\\Database scripts\\MySQL\\" + scriptName;
                        int progress = 0;
                        AppendStatusMessage(string.Format("Attempting to run {0} script...", scriptName));

                        if (!mySqlSetup.ExecuteScript(scriptPath))
                        {
                            OnSetupFailed();
                            return;
                        }

                        progress += 90 / scriptNames.Count;
                        UpdateProgressBar(progress);
                        AppendStatusMessage(string.Format("{0} ran successfully.", scriptName));
                        AppendStatusMessage(string.Empty);
                    }

                    // Create new MySQL database user.
                    if (createNewUser)
                    {
                        string user = m_state["newMySqlUserName"].ToString();
                        string pass = m_state["newMySqlUserPassword"].ToString();
                        AppendStatusMessage(string.Format("Attempting to create new user {0}...", user));

                        if (!mySqlSetup.ExecuteStatement(string.Format("CREATE USER {0} IDENTIFIED BY '{1}'", user, pass)))
                        {
                            OnSetupFailed();
                            return;
                        }

                        if (!mySqlSetup.ExecuteStatement(string.Format("GRANT SELECT, UPDATE, INSERT ON {0}.* TO {1}", mySqlSetup.DatabaseName, user)))
                        {
                            OnSetupFailed();
                            return;
                        }

                        mySqlSetup.UserName = user;
                        mySqlSetup.Password = pass;

                        UpdateProgressBar(95);
                        AppendStatusMessage("New user created successfully.");
                        AppendStatusMessage(string.Empty);
                    }
                }

                // Modify the openPDC configuration file.
                AppendStatusMessage("Attempting to modify configuration files...");
                ModifyConfigFiles(mySqlSetup.ConnectionString, "AssemblyName={MySql.Data, Version=6.2.3.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d}; ConnectionType=MySql.Data.MySqlClient.MySqlConnection; AdapterType=MySql.Data.MySqlClient.MySqlDataAdapter", Convert.ToBoolean(m_state["encryptMySqlConnectionStrings"]));

                oldConnectionStringSetup.ConnectionString = m_oldConnectionString;
                oldConnectionStringSetup.UserName = adminUserName;
                oldConnectionStringSetup.Password = adminPassword;
                m_state["oldOleDbConnectionString"] = oldConnectionStringSetup.OleDbConnectionString;

                AppendStatusMessage("Modification of configuration files was successful.");
                OnSetupSucceeded();
            }
            catch (Exception ex)
            {
                AppendStatusMessage(ex.Message);
                OnSetupFailed();
            }
            finally
            {
                if (mySqlSetup != null)
                {
                    mySqlSetup.OutputDataReceived -= MySqlSetup_OutputDataReceived;
                    mySqlSetup.ErrorDataReceived -= MySqlSetup_ErrorDataReceived;
                }
            }
        }

        // Called when the user has asked to set up a SQL Server database.
        private void SetUpSqlServerDatabase()
        {
            SqlServerSetup sqlServerSetup = null;

            try
            {
                SqlServerSetup oldConnectionStringSetup = new SqlServerSetup();
                bool existing = Convert.ToBoolean(m_state["existing"]);
                bool migrate = existing && Convert.ToBoolean(m_state["updateConfiguration"]);
                string adminUserName, adminPassword;

                sqlServerSetup = m_state["sqlServerSetup"] as SqlServerSetup;
                sqlServerSetup.OutputDataReceived += SqlServerSetup_OutputDataReceived;
                sqlServerSetup.ErrorDataReceived += SqlServerSetup_ErrorDataReceived;
                m_state["newOleDbConnectionString"] = sqlServerSetup.OleDbConnectionString;
                adminUserName = sqlServerSetup.UserName;
                adminPassword = sqlServerSetup.Password;

                if (!existing || migrate)
                {
                    List<string> scriptNames = new List<string>();
                    bool initialDataScript = !migrate && Convert.ToBoolean(m_state["initialDataScript"]);
                    bool sampleDataScript = initialDataScript && Convert.ToBoolean(m_state["sampleDataScript"]);
                    bool createNewUser = Convert.ToBoolean(m_state["createNewSqlServerUser"]);

                    // Determine which scripts need to be run.
                    scriptNames.Add("openPDC.sql");
                    if (initialDataScript)
                    {
                        scriptNames.Add("InitialDataSet.sql");
                        if (sampleDataScript)
                            scriptNames.Add("SampleDataSet.sql");
                    }

                    foreach (string scriptName in scriptNames)
                    {
                        string scriptPath = Directory.GetCurrentDirectory() + "\\Database scripts\\SQL Server\\" + scriptName;
                        int progress = 0;
                        AppendStatusMessage(string.Format("Attempting to run {0} script...", scriptName));

                        if (!sqlServerSetup.ExecuteScript(scriptPath))
                        {
                            OnSetupFailed();
                            return;
                        }

                        progress += 90 / scriptNames.Count;
                        UpdateProgressBar(progress);
                        AppendStatusMessage(string.Format("{0} ran successfully.", scriptName));
                        AppendStatusMessage(string.Empty);
                    }

                    m_state["oleDbConnectionString"] = "Provider=SQLOLEDB; " + sqlServerSetup.ConnectionString;

                    // Create new SQL Server database user.
                    if (createNewUser)
                    {
                        string user = m_state["newSqlServerUserName"].ToString();
                        string pass = m_state["newSqlServerUserPassword"].ToString();
                        string db = sqlServerSetup.DatabaseName;

                        AppendStatusMessage(string.Format("Attempting to create new user {0}...", user));

                        sqlServerSetup.DatabaseName = "master";
                        if (!sqlServerSetup.ExecuteStatement(string.Format("IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'{0}') CREATE LOGIN [{0}] WITH PASSWORD=N'{1}', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF", user, pass)))
                        {
                            OnSetupFailed();
                            return;
                        }

                        sqlServerSetup.DatabaseName = db;
                        if (!sqlServerSetup.ExecuteStatement(string.Format("CREATE USER [{0}] FOR LOGIN [{0}]", user)))
                        {
                            OnSetupFailed();
                            return;
                        }

                        if (!sqlServerSetup.ExecuteStatement(string.Format("EXEC sp_addrolemember N'openPDCManagerRole', N'{0}'", user)))
                        {
                            OnSetupFailed();
                            return;
                        }

                        sqlServerSetup.UserName = user;
                        sqlServerSetup.Password = pass;

                        UpdateProgressBar(95);
                        AppendStatusMessage("New user created successfully.");
                        AppendStatusMessage(string.Empty);
                    }
                }

                // Modify the openPDC configuration file.
                AppendStatusMessage("Attempting to modify configuration files...");
                ModifyConfigFiles(sqlServerSetup.ConnectionString, "AssemblyName={System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089}; ConnectionType=System.Data.SqlClient.SqlConnection; AdapterType=System.Data.SqlClient.SqlDataAdapter", Convert.ToBoolean(m_state["encryptSqlServerConnectionStrings"]));

                oldConnectionStringSetup.ConnectionString = m_oldConnectionString;
                oldConnectionStringSetup.UserName = adminUserName;
                oldConnectionStringSetup.Password = adminPassword;
                m_state["oldOleDbConnectionString"] = oldConnectionStringSetup.OleDbConnectionString;

                AppendStatusMessage("Modification of configuration files was successful.");
                OnSetupSucceeded();
            }
            catch (Exception ex)
            {
                AppendStatusMessage(ex.Message);
                OnSetupFailed();
            }
            finally
            {
                if (sqlServerSetup != null)
                {
                    sqlServerSetup.OutputDataReceived -= SqlServerSetup_OutputDataReceived;
                    sqlServerSetup.ErrorDataReceived -= SqlServerSetup_ErrorDataReceived;
                }
            }
        }

        // Called when the user has asked to set up an XML configuration.
        private void SetUpXmlConfiguration()
        {
            try
            {
                // Modify the openPDC configuration file.
                AppendStatusMessage("Attempting to modify configuration files...");
                ModifyConfigFiles(m_state["xmlFilePath"].ToString(), string.Empty, false);
                AppendStatusMessage("Modification of configuration files was successful.");
                OnSetupSucceeded();
            }
            catch (Exception ex)
            {
                AppendStatusMessage(ex.Message);
                OnSetupFailed();
            }
        }

        // Called when the user has asked to set up a web service configuration.
        private void SetUpWebServiceConfiguration()
        {
            try
            {
                // Modify the openPDC configuration file.
                AppendStatusMessage("Attempting to modify configuration files...");
                ModifyConfigFiles(m_state["webServiceUrl"].ToString(), string.Empty, false);
                AppendStatusMessage("Modification of configuration files was successful.");
                OnSetupSucceeded();
            }
            catch (Exception ex)
            {
                AppendStatusMessage(ex.Message);
                OnSetupFailed();
            }
        }

        // Modifies the configuration files to contain the given connection string and data provider string.
        private void ModifyConfigFiles(string connectionString, string dataProviderString, bool encrypted)
        {
            object webManagerDir = Registry.GetValue("HKEY_LOCAL_MACHINE\\Software\\openPDCManagerServices", "Installation Path", null) ?? Registry.GetValue("HKEY_LOCAL_MACHINE\\Software\\Wow6432Node\\openPDCManagerServices", "Installation Path", null);

            ModifyConfigFile(Directory.GetCurrentDirectory() + "\\openPDC.exe.config", connectionString, dataProviderString, encrypted);
            ModifyConfigFile(Directory.GetCurrentDirectory() + "\\openPDCManager.exe.config", connectionString, dataProviderString, encrypted);

            if (webManagerDir != null)
                ModifyConfigFile(webManagerDir.ToString() + "\\Web.config", connectionString, dataProviderString, encrypted);
        }

        // Modifies the configuration file with the given file name to contain the given connection string and data provider string.
        private void ModifyConfigFile(string configFileName, string connectionString, string dataProviderString, bool encrypted)
        {
            // Modify system settings.
            XmlDocument configFile = new XmlDocument();
            configFile.Load(configFileName);
            XmlNode categorizedSettings = configFile.SelectSingleNode("configuration/categorizedSettings");
            XmlNode systemSettings = configFile.SelectSingleNode("configuration/categorizedSettings/systemSettings");

            if (encrypted)
                connectionString = Cipher.Encrypt(connectionString, DefaultCryptoKey, CryptoStrength);

            foreach (XmlNode child in systemSettings.ChildNodes)
            {
                if (child.Attributes != null)
                {
                    if (child.Attributes["name"].Value == "DataProviderString")
                        child.Attributes["value"].Value = dataProviderString;
                    else if (child.Attributes["name"].Value == "ConnectionString")
                    {
                        if (m_oldConnectionString == null)
                        {
                            // Retrieve the old connection string from the config file.
                            m_oldConnectionString = child.Attributes["value"].Value;

                            if (Convert.ToBoolean(child.Attributes["encrypted"].Value))
                                m_oldConnectionString = Cipher.Decrypt(m_oldConnectionString, DefaultCryptoKey, CryptoStrength);
                        }

                        // Modify the config file settings to the new values.
                        child.Attributes["value"].Value = connectionString;
                        child.Attributes["encrypted"].Value = encrypted.ToString();
                    }
                }
            }

            // Modify ADO metadata provider sections.
            IEnumerable<XmlNode> adoProviderSections = categorizedSettings.ChildNodes
                .Cast<XmlNode>().Where(node => node.Name.EndsWith("AdoMetadataProvider"));

            foreach (XmlNode section in adoProviderSections)
            {
                XmlAttribute connectionAttribute = section.Attributes.Cast<XmlAttribute>().SingleOrDefault(attribute => attribute["name"].Value == "ConnectionString");
                XmlAttribute dataProviderAttribute = section.Attributes.Cast<XmlAttribute>().SingleOrDefault(attribute => attribute["value"].Value == "DataProviderString");

                if (connectionAttribute != null && dataProviderAttribute != null)
                {
                    connectionAttribute["value"].Value = connectionString;
                    connectionAttribute["encrypted"].Value = encrypted.ToString();
                    dataProviderAttribute["value"].Value = dataProviderString;
                }
            }

            configFile.Save(configFileName);
        }

        // Called when mysql.exe receives data on its standard output stream.
        private void MySqlSetup_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            AppendStatusMessage(e.Data);
        }

        // Called when mysql.exe receives data on its standard error stream.
        private void MySqlSetup_ErrorDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            AppendStatusMessage(e.Data);
        }

        // Called when sqlcmd.exe receives data on its standard output stream.
        private void SqlServerSetup_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            AppendStatusMessage(e.Data);
        }

        // Called when sqlcmd.exe receives data on its standard error stream.
        private void SqlServerSetup_ErrorDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            AppendStatusMessage(e.Data);
        }

        // Updates the progress bar to have the specified value.
        private void UpdateProgressBar(int value)
        {
            if (Dispatcher.CheckAccess())
                m_progressBar.Value = value;
            else
                Dispatcher.Invoke(new Action<int>(UpdateProgressBar), value);
        }

        // Clears the status messages on the setup status text box.
        private void ClearStatusMessages()
        {
            if (Dispatcher.CheckAccess())
                m_setupStatusTextBox.Text = string.Empty;
            else
                Dispatcher.Invoke(new Action(ClearStatusMessages), null);
        }

        // Updates the setup status text box to include the specified message.
        private void AppendStatusMessage(string message)
        {
            if (!Dispatcher.CheckAccess())
                Dispatcher.Invoke(new Action<string>(AppendStatusMessage), message);
            else
            {
                m_setupStatusTextBox.AppendText(message + Environment.NewLine);
                m_setupStatusTextBox.ScrollToEnd();
            }
        }

        // Allows the user to proceed to the next screen if the setup succeeded.
        private void OnSetupSucceeded()
        {
            UpdateProgressBar(100);
            CanGoForward = true;
        }

        // Allows the user to go back to previous screens or cancel the setup if it failed.
        private void OnSetupFailed()
        {
            UpdateProgressBar(0);
            m_canGoBack = true;
            CanCancel = true;
        }

        #endregion
    }
}
