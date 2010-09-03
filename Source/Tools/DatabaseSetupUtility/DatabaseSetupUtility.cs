//******************************************************************************************************
//  DatabaseSetupUtility.cs - Gbtc
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
//  06/29/2010 - Stephen C. Wills
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;
using TVA.Security.Cryptography;

namespace DatabaseSetupUtility
{
    /// <summary>
    /// The main <see cref="Form"/> for the Database Setup Utility.
    /// </summary>
    public partial class DatabaseSetupUtility : Form
    {

        #region [ Members ]

        // Constants

        private const CipherStrength CryptoStrength = CipherStrength.Aes256;
        private const string DefaultCryptoKey = "0679d9ae-aca5-4702-a3f5-604415096987";

        // Delegates

        private delegate void AppendToSetupTextBoxDelegate(string line);
        private delegate void UpdateNavigationButtonsDelegate();
        private delegate void UpdateProgressBarDelegate(int value);

        // Fields

        private bool m_install;
        private PageControl m_pageControl;
        private Page m_accessDatabasePage;
        private Page m_mySqlDatabasePage;
        private Page m_sqlServerDatabasePage;
        private Page m_xmlConfigurationPage;
        private Page m_webServiceConfigurationPage;
        private MySqlSetup m_mySqlSetup;
        private SqlServerSetup m_sqlServerSetup;
        private AdvancedForm m_advancedForm;
        private AppendToSetupTextBoxDelegate m_appendToSetupTextBox;
        private UpdateNavigationButtonsDelegate m_updateNavigationButtons;
        private UpdateProgressBarDelegate m_updateProgressBar;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new instance of the <see cref="DatabaseSetupUtility"/>.
        /// </summary>
        /// <param name="scriptDirectory">The directory containing folders with the database scripts.</param>
        public DatabaseSetupUtility()
        {
            InitializeComponent();

            m_install = FindInstallArgument();
            m_pageControl = new PageControl();
            m_accessDatabasePage = new Page(accessDatabasePanel);
            m_mySqlDatabasePage = new Page(mySqlDatabasePanel);
            m_sqlServerDatabasePage = new Page(sqlServerDatabasePanel);
            m_xmlConfigurationPage = new Page(xmlConfigurationPanel);
            m_webServiceConfigurationPage = new Page(webServiceConfigurationPanel);

            Page installPage = new Page(installPanel);
            Page databaseTypePage = new Page(databaseTypePanel);
            Page prepareForSetupPage = new Page(prepareForSetupPanel);
            Page databaseSetupPage = new Page(databaseSetupPanel);
            Page setupFinishedPage = new Page(setupFinishedPanel);

            m_accessDatabasePage.UserInputValidationFunction = ValidateAccessDatabasePage;
            m_mySqlDatabasePage.UserInputValidationFunction = ValidateMySqlDatabasePage;
            m_sqlServerDatabasePage.UserInputValidationFunction = ValidateSqlServerDatabasePage;
            m_xmlConfigurationPage.UserInputValidationFunction = ValidateXmlConfigurationPage;
            m_webServiceConfigurationPage.UserInputValidationFunction = ValidateWebServiceConfigurationPage;
            databaseSetupPage.CanGoBack = false;
            databaseSetupPage.CanGoForward = false;
            databaseSetupPage.CanCancel = false;
            setupFinishedPage.CanGoBack = false;
            setupFinishedPage.CanCancel = false;

            if (m_install)
            {
                m_pageControl.Add(installPage);
                installPage.Visible = true;
                databaseTypePage.Visible = false;
                configFileCheckBox.Visible = false;

                xmlRadioButton.Text += " (does not migrate)";
                webServiceRadioButton.Text += " (does not migrate)";
            }

            m_pageControl.Add(databaseTypePage);
            m_pageControl.Add(m_accessDatabasePage);
            m_pageControl.Add(prepareForSetupPage);
            m_pageControl.Add(databaseSetupPage);
            m_pageControl.Add(setupFinishedPage);
            m_pageControl[0].Visible = true;

            m_appendToSetupTextBox = AppendToSetupTextBox;
            m_updateNavigationButtons = UpdateNavigationButtons;
            m_updateProgressBar = UpdateProgressBar;
        }

        #endregion

        #region [ Methods ]

        // Checks to see if the -install command line option exists.
        private bool FindInstallArgument()
        {
            foreach (string arg in Environment.GetCommandLineArgs())
            {
                if (arg.ToLower() == "-install")
                    return true;
            }

            return false;
        }

        // Determines whether the next or previous pages can be reached.
        private void UpdateNavigationButtons()
        {
            cancelButton.Enabled = m_pageControl.CurrentPage.CanCancel;
            backButton.Enabled = m_pageControl.PreviousPageAccessible;
            nextButton.Enabled = m_pageControl.NextPageAccessible;
        }

        // Called when the database setup utility form is closing.
        private void DatabaseSetupUtility_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_pageControl.CurrentPage.PagePanel == databaseSetupPanel && !m_pageControl.CurrentPage.CanCancel)
                e.Cancel = true;
            else if (m_pageControl.NextPage != null)
            {
                DialogResult selection = MessageBox.Show(this, "The setup is not yet complete. Are you sure you want to exit?", this.Text, MessageBoxButtons.YesNo);

                if (selection == DialogResult.No)
                    e.Cancel = true;
            }
        }

        // Called when the database setup utility has been closed.
        private void DatabaseSetupUtility_FormClosed(object sender, FormClosedEventArgs e)
        {
            bool migrate =
                installOldRadioButton.Checked &&
                m_pageControl.NextPage == null &&
                xmlRadioButton.Checked == false &&
                webServiceRadioButton.Checked == false;

            if (migrate)
            {
                Process migrationProcess = null;

                try
                {
                    migrationProcess = new Process();
                    migrationProcess.StartInfo.FileName = "DataMigrationUtility.exe";
                    migrationProcess.StartInfo.UseShellExecute = false;
                    migrationProcess.StartInfo.CreateNoWindow = true;
                    migrationProcess.Start();
                }
                finally
                {
                    if (migrationProcess != null)
                        migrationProcess.Close();
                }
            }
        }

        // Called when the escape key is pressed while the form is in focus.
        private void DatabaseSetupUtility_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        // Called when the "Next" button is clicked.
        private void nextButton_Click(object sender, EventArgs e)
        {
            if (m_pageControl.NextPage == null)
                this.Close();
            else
            {
                m_pageControl.GoToNextPage();
                UpdateNavigationButtons();

                if (m_pageControl.NextPage == null)
                    nextButton.Text = "Finish";
            }
        }

        // Called when the "Back" button is clicked.
        private void backButton_Click(object sender, EventArgs e)
        {
            m_pageControl.GoToPreviousPage();
            UpdateNavigationButtons();

            if (m_pageControl.NextPage != null)
                nextButton.Text = "Next >";
        }

        // Called when the "Cancel" button is clicked.
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Called when the user chooses to install a brand new database.
        private void installNewRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (installNewRadioButton.Checked)
            {
                accessDatabaseFileLocationTextBox.Text = "openPDC.mdb";
                mySqlDatabaseNameTextBox.Text = "openPDC";
                sqlServerDatabaseNameTextBox.Text = "openPDC";
            }
        }

        private void installOldRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (installOldRadioButton.Checked)
            {
                accessDatabaseFileLocationTextBox.Text = "openPDCv2.mdb";
                mySqlDatabaseNameTextBox.Text = "openPDCv2";
                sqlServerDatabaseNameTextBox.Text = "openPDCv2";
            }
        }

        // Called when the "Access" radio button is checked or unchecked.
        private void accessRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (accessRadioButton.Checked)
                m_pageControl.Insert(m_pageControl.CurrentPageIndex + 1, m_accessDatabasePage);
            else
                m_pageControl.Remove(m_accessDatabasePage);

            UpdateNavigationButtons();
        }

        // Called when the "MySQL" radio button is checked or unchecked.
        private void mysqlRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (mySqlRadioButton.Checked)
                m_pageControl.Insert(m_pageControl.CurrentPageIndex + 1, m_mySqlDatabasePage);
            else
                m_pageControl.Remove(m_mySqlDatabasePage);

            UpdateNavigationButtons();
        }

        // Called when the "SQL Server" radio button is checked or unchecked.
        private void sqlServerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sqlServerRadioButton.Checked)
                m_pageControl.Insert(m_pageControl.CurrentPageIndex + 1, m_sqlServerDatabasePage);
            else
                m_pageControl.Remove(m_sqlServerDatabasePage);

            UpdateNavigationButtons();
        }

        // Called when the "XML" radio button is checked or unchecked.
        private void xmlRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (xmlRadioButton.Checked)
                m_pageControl.Insert(m_pageControl.CurrentPageIndex + 1, m_xmlConfigurationPage);
            else
                m_pageControl.Remove(m_xmlConfigurationPage);

            configFileCheckBox.Enabled = !xmlRadioButton.Checked;
            UpdateNavigationButtons();
        }

        // Called when the "Web service" radio button is checked or unchecked.
        private void webServiceRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (webServiceRadioButton.Checked)
                m_pageControl.Insert(m_pageControl.CurrentPageIndex + 1, m_webServiceConfigurationPage);
            else
                m_pageControl.Remove(m_webServiceConfigurationPage);

            configFileCheckBox.Enabled = !webServiceRadioButton.Checked;
            UpdateNavigationButtons();
        }

        // Called when the user chooses whether to create the database or not.
        private void configFileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            initialDataScriptCheckBox.Enabled = !configFileCheckBox.Checked;
            sampleDataScriptCheckBox.Enabled = initialDataScriptCheckBox.Enabled && initialDataScriptCheckBox.Checked;

            mySqlDatabaseCreateNewUserCheckBox.Visible = !configFileCheckBox.Checked;
            mySqlDatabaseNewUserNameLabel.Visible = !configFileCheckBox.Checked;
            mySqlDatabaseNewUserNameTextBox.Visible = !configFileCheckBox.Checked;
            mySqlDatabaseNewUserPasswordLabel.Visible = !configFileCheckBox.Checked;
            mySqlDatabaseNewUserPasswordTextBox.Visible = !configFileCheckBox.Checked;

            sqlServerDatabaseCreateNewUserCheckBox.Visible = !configFileCheckBox.Checked;
            sqlServerDatabaseNewUserNameLabel.Visible = !configFileCheckBox.Checked;
            sqlServerDatabaseNewUserNameTextBox.Visible = !configFileCheckBox.Checked;
            sqlServerDatabaseNewUserPasswordLabel.Visible = !configFileCheckBox.Checked;
            sqlServerDatabaseNewUserPasswordTextBox.Visible = !configFileCheckBox.Checked;

            if (configFileCheckBox.Checked)
            {
                mySqlDatabaseAdminUserNameLabel.Text = "User Name:";
                mySqlDatabaseAdminPasswordLabel.Text = "Password:";
                sqlServerDatabaseAdminUserNameLabel.Text = "User Name:";
                sqlServerDatabaseAdminPasswordLabel.Text = "Password:";
            }
            else
            {
                mySqlDatabaseAdminUserNameLabel.Text = "Admin User Name:";
                mySqlDatabaseAdminPasswordLabel.Text = "Admin Password:";
                sqlServerDatabaseAdminUserNameLabel.Text = "Admin User Name:";
                sqlServerDatabaseAdminPasswordLabel.Text = "Admin Password:";
            }
        }

        // Called when the "Run initial data script" checkbox is checked or unchecked.
        private void initialDataScriptCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            sampleDataScriptCheckBox.Enabled = initialDataScriptCheckBox.Checked;
        }

        // Called when the button is clicked to browse for a location for the Access database file.
        private void accessDatabaseBrowseButton_Click(object sender, EventArgs e)
        {
            DialogResult selection = accessDatabaseSaveFileDialog.ShowDialog(this);

            if (selection == DialogResult.OK)
                accessDatabaseFileLocationTextBox.Text = accessDatabaseSaveFileDialog.FileName;
        }

        // Called when the MySQL setup page is made visible or invisible.
        private void mySqlDatabasePanel_VisibleChanged(object sender, EventArgs e)
        {
            if (m_mySqlSetup == null)
            {
                m_mySqlSetup = new MySqlSetup();
                m_mySqlSetup.ErrorDataReceived += m_mySqlSetup_ErrorDataReceived;
                m_mySqlSetup.OutputDataReceived += m_mySqlSetup_OutputDataReceived;
            }

            advancedButton.Visible = mySqlDatabasePanel.Visible;
        }

        // Called when the SQL Server setup page is made visible or invisible.
        private void sqlServerDatabasePanel_VisibleChanged(object sender, EventArgs e)
        {
            if (m_sqlServerSetup == null)
            {
                m_sqlServerSetup = new SqlServerSetup();
                m_sqlServerSetup.ErrorDataReceived += m_sqlServerSetup_ErrorDataReceived;
                m_sqlServerSetup.OutputDataReceived += m_sqlServerSetup_OutputDataReceived;
            }

            advancedButton.Visible = sqlServerDatabasePanel.Visible;
        }

        // Called when the "Advanced" button is made visible or invisible.
        private void advancedButton_VisibleChanged(object sender, EventArgs e)
        {
            if (m_advancedForm == null)
                m_advancedForm = new AdvancedForm();
        }

        // Called when the MySQL create new user check box is checked or unchecked.
        private void mySqlDatabaseCreateNewUserCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mySqlDatabaseNewUserNameLabel.Enabled = mySqlDatabaseCreateNewUserCheckBox.Checked;
            mySqlDatabaseNewUserNameTextBox.Enabled = mySqlDatabaseCreateNewUserCheckBox.Checked;
            mySqlDatabaseNewUserPasswordLabel.Enabled = mySqlDatabaseCreateNewUserCheckBox.Checked;
            mySqlDatabaseNewUserPasswordTextBox.Enabled = mySqlDatabaseCreateNewUserCheckBox.Checked;
        }

        // Called when the SQL Server create new user check box is checked or unchecked.
        private void sqlServerDatabaseCreateNewUserCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            sqlServerDatabaseNewUserNameLabel.Enabled = sqlServerDatabaseCreateNewUserCheckBox.Checked;
            sqlServerDatabaseNewUserNameTextBox.Enabled = sqlServerDatabaseCreateNewUserCheckBox.Checked;
            sqlServerDatabaseNewUserPasswordLabel.Enabled = sqlServerDatabaseCreateNewUserCheckBox.Checked;
            sqlServerDatabaseNewUserPasswordTextBox.Enabled = sqlServerDatabaseCreateNewUserCheckBox.Checked;
        }

        // Called when the "Advanced" button is clicked.
        private void advancedButton_Click(object sender, EventArgs e)
        {
            if (mySqlRadioButton.Checked)
                MySqlAdvancedButtonClicked();
            else
                SqlServerAdvancedButtonClicked();
        }

        // Called when the "Advanced" button is clicked on the MySQL database page.
        private void MySqlAdvancedButtonClicked()
        {
            bool encrypted = m_advancedForm.Encrypted;
            m_mySqlSetup.HostName = mySqlDatabaseHostNameTextBox.Text;
            m_mySqlSetup.DatabaseName = mySqlDatabaseNameTextBox.Text;
            m_mySqlSetup.UserName = mySqlDatabaseAdminUserNameTextBox.Text;
            m_advancedForm.ConnectionString = m_mySqlSetup.ConnectionString;

            DialogResult result = m_advancedForm.ShowDialog(this);
            if (result == DialogResult.Cancel)
                m_advancedForm.Encrypted = encrypted;
            else
            {
                m_mySqlSetup.ConnectionString = m_advancedForm.ConnectionString;
                mySqlDatabaseHostNameTextBox.Text = m_mySqlSetup.HostName;
                mySqlDatabaseNameTextBox.Text = m_mySqlSetup.DatabaseName;
                mySqlDatabaseAdminUserNameTextBox.Text = m_mySqlSetup.UserName;

                if (!string.IsNullOrEmpty(m_mySqlSetup.Password))
                    mySqlDatabaseAdminPasswordTextBox.Text = m_mySqlSetup.Password;
            }
        }

        // Called when the "Advanced" button is clicked on the SQL Server database page.
        private void SqlServerAdvancedButtonClicked()
        {
            bool encrypted = m_advancedForm.Encrypted;
            m_sqlServerSetup.HostName = sqlServerDatabaseHostNameTextBox.Text;
            m_sqlServerSetup.DatabaseName = sqlServerDatabaseNameTextBox.Text;
            m_sqlServerSetup.UserName = sqlServerDatabaseAdminUserNameTextBox.Text;
            m_advancedForm.ConnectionString = m_sqlServerSetup.ConnectionString;

            DialogResult result = m_advancedForm.ShowDialog(this);
            if (result == DialogResult.Cancel)
                m_advancedForm.Encrypted = encrypted;
            else
            {
                m_sqlServerSetup.ConnectionString = m_advancedForm.ConnectionString;
                sqlServerDatabaseHostNameTextBox.Text = m_sqlServerSetup.HostName;
                sqlServerDatabaseNameTextBox.Text = m_sqlServerSetup.DatabaseName;
                sqlServerDatabaseAdminUserNameTextBox.Text = m_sqlServerSetup.UserName;

                if (!string.IsNullOrEmpty(m_sqlServerSetup.Password))
                    sqlServerDatabaseAdminPasswordTextBox.Text = m_sqlServerSetup.Password;
            }
        }

        // Called when the browse button for XML configurations is clicked.
        private void xmlConfigurationBrowseButton_Click(object sender, EventArgs e)
        {
            DialogResult result = xmlConfigurationOpenFileDialog.ShowDialog(this);

            if (result == DialogResult.OK)
                xmlConfigurationTextBox.Text = xmlConfigurationOpenFileDialog.FileName;
        }

        // Validates the user input on the Access database page.
        private bool ValidateAccessDatabasePage()
        {
            if (string.IsNullOrEmpty(accessDatabaseFileLocationTextBox.Text))
            {
                MessageBox.Show(this, "Please enter a file name for your Access database.");
                accessDatabaseFileLocationTextBox.Focus();
                return false;
            }

            if (accessDatabaseFileLocationTextBox.Text.EndsWith(".mdb") == false)
            {
                MessageBox.Show(this, "The file name for your Access database must end with the .mdb file extension.");
                accessDatabaseFileLocationTextBox.Focus();
                return false;
            }

            return true;
        }

        // Validates the user input on the MySQL database page.
        private bool ValidateMySqlDatabasePage()
        {
            if (string.IsNullOrEmpty(mySqlDatabaseHostNameTextBox.Text))
            {
                MessageBox.Show(this, "Please enter the host name for your MySQL database.");
                mySqlDatabaseHostNameTextBox.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(mySqlDatabaseNameTextBox.Text))
            {
                MessageBox.Show(this, "Please enter a name for your MySQL database.");
                mySqlDatabaseNameTextBox.Focus();
                return false;
            }

            return true;
        }

        // Validates the user input on the SQL Server database page.
        private bool ValidateSqlServerDatabasePage()
        {
            if (string.IsNullOrEmpty(sqlServerDatabaseHostNameTextBox.Text))
            {
                MessageBox.Show(this, "Please enter the host name for your SQL Server database.");
                sqlServerDatabaseHostNameTextBox.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(sqlServerDatabaseNameTextBox.Text))
            {
                MessageBox.Show(this, "Please enter a name for your SQL Server database.");
                sqlServerDatabaseNameTextBox.Focus();
                return false;
            }

            return true;
        }

        // Validates the user input on the XML configuration page.
        private bool ValidateXmlConfigurationPage()
        {
            if (string.IsNullOrEmpty(xmlConfigurationTextBox.Text))
            {
                MessageBox.Show(this, "Please enter the location of an XML configuration file.");
                xmlConfigurationTextBox.Focus();
                return false;
            }

            return true;
        }

        // Validates the user input on the web service configuration page.
        private bool ValidateWebServiceConfigurationPage()
        {
            if (string.IsNullOrEmpty(webServiceConfigurationTextBox.Text))
            {
                MessageBox.Show(this, "Please enter the URL for your web service configuration.");
                webServiceConfigurationTextBox.Focus();
                return false;
            }

            return true;
        }

        // Called when the user has indicated that they are ready to set up their database.
        private void databaseSetupPanel_VisibleChanged(object sender, EventArgs e)
        {
            if (databaseSetupPanel.Visible)
            {
                Thread databaseSetupThread = new Thread(SetUpDatabase);
                databaseSetupThread.Start();
            }
            else
            {
                m_pageControl.CurrentPage.CanGoBack = false;
                m_pageControl.CurrentPage.CanCancel = false;
                databaseSetupTextBox.Text = string.Empty;
            }
        }
        
        // Called when the setup utility is about to set up the database
        private void SetUpDatabase()
        {
            bool successful = false;

            if (accessRadioButton.Checked)
                successful = SetUpAccessDatabase();
            else if (mySqlRadioButton.Checked)
                successful = SetUpMySqlDatabase();
            else if (sqlServerRadioButton.Checked)
                successful = SetUpSqlServerDatabase();
            else if (xmlRadioButton.Checked)
                successful = SetUpXmlConfiguration();
            else
                successful = SetUpWebServiceConfiguration();

            if (successful)
            {
                m_pageControl.CurrentPage.Accessible = false;
                m_pageControl.CurrentPage.CanGoForward = true;
            }
            else
            {
                m_pageControl.CurrentPage.CanGoBack = true;
                m_pageControl.CurrentPage.CanCancel = true;
                Invoke(m_updateProgressBar, 0);
            }

            Invoke(m_updateNavigationButtons);
        }

        // Called when the user has asked to set up an access database.
        private bool SetUpAccessDatabase()
        {
            try
            {
                string filePath = null;
                string destination = accessDatabaseFileLocationTextBox.Text;

                if (configFileCheckBox.Checked == false)
                {
                    if (initialDataScriptCheckBox.Checked == false)
                        filePath = Directory.GetCurrentDirectory() + "\\Database scripts\\Access\\openPDC.mdb";
                    else if (sampleDataScriptCheckBox.Checked == false)
                        filePath = Directory.GetCurrentDirectory() + "\\Database scripts\\Access\\openPDC-InitialDataSet.mdb";
                    else
                        filePath = Directory.GetCurrentDirectory() + "\\Database scripts\\Access\\openPDC-SampleDataSet.mdb";

                    Invoke(m_updateProgressBar, 2);
                    Invoke(m_appendToSetupTextBox, string.Format("Attempting to copy file {0} to {1}...", filePath, destination));

                    // Copy the file to the specified path.
                    File.Copy(filePath, destination);
                    Invoke(m_updateProgressBar, 95);
                    Invoke(m_appendToSetupTextBox, "File copy successful.\r\n");
                }

                // Modify the openPDC configuration file.
                Invoke(m_appendToSetupTextBox, "Attempting to modify configuration files...");
                ModifyConfigFiles("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + destination, "AssemblyName={System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089}; ConnectionType=System.Data.OleDb.OleDbConnection; AdapterType=System.Data.OleDb.OleDbDataAdapter", false);
                Invoke(m_updateProgressBar, 100);
                Invoke(m_appendToSetupTextBox, "Modification of configuration files was successful.");

                return true;
            }
            catch (Exception ex)
            {
                Invoke(m_appendToSetupTextBox, ex.Message);
                return false;
            }
        }

        // Called when the user has asked to set up a MySQL database.
        private bool SetUpMySqlDatabase()
        {
            try
            {
                // Set up database connection string.
                m_mySqlSetup.HostName = mySqlDatabaseHostNameTextBox.Text;
                m_mySqlSetup.DatabaseName = mySqlDatabaseNameTextBox.Text;
                m_mySqlSetup.UserName = mySqlDatabaseAdminUserNameTextBox.Text;
                m_mySqlSetup.Password = mySqlDatabaseAdminPasswordTextBox.Text;

                if (configFileCheckBox.Checked == false)
                {
                    List<string> scriptNames = new List<string>();
                    int progress = 0;

                    // Determine which scripts need to be run.
                    scriptNames.Add("openPDC.sql");
                    if (initialDataScriptCheckBox.Checked)
                    {
                        scriptNames.Add("InitialDataSet.sql");
                        if (sampleDataScriptCheckBox.Checked)
                            scriptNames.Add("SampleDataSet.sql");
                    }

                    foreach (string scriptName in scriptNames)
                    {
                        string scriptPath = Directory.GetCurrentDirectory() + "\\Database scripts\\MySQL\\" + scriptName;
                        Invoke(m_appendToSetupTextBox, string.Format("Attempting to run {0} script...", scriptName));

                        if (!m_mySqlSetup.ExecuteScript(scriptPath))
                            return false;

                        progress += 90 / scriptNames.Count;
                        Invoke(m_updateProgressBar, progress);
                        Invoke(m_appendToSetupTextBox, string.Format("{0} ran successfully.\r\n", scriptName));
                    }

                    // Create new MySQL database user.
                    if (mySqlDatabaseCreateNewUserCheckBox.Checked)
                    {
                        string user = mySqlDatabaseNewUserNameTextBox.Text;
                        string pass = mySqlDatabaseNewUserPasswordTextBox.Text;

                        Invoke(m_appendToSetupTextBox, string.Format("Attempting to create new user {0}...", user));

                        if (!m_mySqlSetup.ExecuteStatement(string.Format("CREATE USER {0} IDENTIFIED BY '{1}'", user, pass)))
                            return false;

                        if (!m_mySqlSetup.ExecuteStatement(string.Format("GRANT SELECT, UPDATE, INSERT ON {0}.* TO {1}", m_mySqlSetup.DatabaseName, user)))
                            return false;

                        Invoke(m_updateProgressBar, 95);
                        Invoke(m_appendToSetupTextBox, "New user created successfully.");
                    }
                }

                // Modify the openPDC configuration file.
                Invoke(m_appendToSetupTextBox, "Attempting to modify configuration files...");

                if (mySqlDatabaseCreateNewUserCheckBox.Checked && !configFileCheckBox.Checked)
                {
                    m_mySqlSetup.UserName = mySqlDatabaseNewUserNameTextBox.Text;
                    m_mySqlSetup.Password = mySqlDatabaseNewUserPasswordTextBox.Text;
                }

                ModifyConfigFiles(m_mySqlSetup.ConnectionString, "AssemblyName={MySql.Data, Version=6.2.3.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d}; ConnectionType=MySql.Data.MySqlClient.MySqlConnection; AdapterType=MySql.Data.MySqlClient.MySqlDataAdapter", m_advancedForm.Encrypted);

                Invoke(m_updateProgressBar, 100);
                Invoke(m_appendToSetupTextBox, "Modification of configuration files was successful.");

                return true;
            }
            catch (Exception ex)
            {
                Invoke(m_appendToSetupTextBox, ex.Message);
                return false;
            }
        }

        // Called when the user has asked to set up a SQL Server database.
        private bool SetUpSqlServerDatabase()
        {
            try
            {
                // Set up database connection string.
                m_sqlServerSetup.HostName = sqlServerDatabaseHostNameTextBox.Text;
                m_sqlServerSetup.DatabaseName = sqlServerDatabaseNameTextBox.Text;
                m_sqlServerSetup.UserName = sqlServerDatabaseAdminUserNameTextBox.Text;
                m_sqlServerSetup.Password = sqlServerDatabaseAdminPasswordTextBox.Text;

                if (configFileCheckBox.Checked == false)
                {
                    List<string> scriptNames = new List<string>();
                    int progress = 0;

                    // Determine which scripts need to be run.
                    scriptNames.Add("openPDC.sql");
                    if (initialDataScriptCheckBox.Checked)
                    {
                        scriptNames.Add("InitialDataSet.sql");
                        if (sampleDataScriptCheckBox.Checked)
                            scriptNames.Add("SampleDataSet.sql");
                    }

                    foreach (string scriptName in scriptNames)
                    {
                        string scriptPath = Directory.GetCurrentDirectory() + "\\Database scripts\\SQL Server\\" + scriptName;
                        Invoke(m_appendToSetupTextBox, string.Format("Attempting to run {0} script...", scriptName));

                        if (!m_sqlServerSetup.ExecuteScript(scriptPath))
                            return false;

                        progress += 90 / scriptNames.Count;
                        Invoke(m_updateProgressBar, progress);
                        Invoke(m_appendToSetupTextBox, string.Format("{0} ran successfully.\r\n", scriptName));
                    }

                    // Create new SQL Server database user.
                    if (sqlServerDatabaseCreateNewUserCheckBox.Checked)
                    {
                        string user = sqlServerDatabaseNewUserNameTextBox.Text;
                        string pass = sqlServerDatabaseNewUserPasswordTextBox.Text;
                        string db = m_sqlServerSetup.DatabaseName;

                        Invoke(m_appendToSetupTextBox, string.Format("Attempting to create new user {0}...", user));

                        m_sqlServerSetup.DatabaseName = "master";
                        if (!m_sqlServerSetup.ExecuteStatement(string.Format("IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'{0}') CREATE LOGIN [{0}] WITH PASSWORD=N'{1}', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF", user, pass)))
                            return false;

                        m_sqlServerSetup.DatabaseName = db;
                        if (!m_sqlServerSetup.ExecuteStatement(string.Format("CREATE USER [{0}] FOR LOGIN [{0}]", user)))
                            return false;

                        if (!m_sqlServerSetup.ExecuteStatement(string.Format("EXEC sp_addrolemember N'openPDCManagerRole', N'{0}'", user)))
                            return false;

                        Invoke(m_updateProgressBar, 95);
                        Invoke(m_appendToSetupTextBox, "New user created successfully.");
                    }
                }

                // Modify the openPDC configuration file.
                Invoke(m_appendToSetupTextBox, "Attempting to modify configuration files...");

                if (sqlServerDatabaseCreateNewUserCheckBox.Checked && !configFileCheckBox.Checked)
                {
                    m_sqlServerSetup.UserName = sqlServerDatabaseNewUserNameTextBox.Text;
                    m_sqlServerSetup.Password = sqlServerDatabaseNewUserPasswordTextBox.Text;
                }

                ModifyConfigFiles(m_sqlServerSetup.ConnectionString, "AssemblyName={System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089}; ConnectionType=System.Data.SqlClient.SqlConnection; AdapterType=System.Data.SqlClient.SqlDataAdapter", m_advancedForm.Encrypted);

                Invoke(m_updateProgressBar, 100);
                Invoke(m_appendToSetupTextBox, "Modification of configuration files was successful.");

                return true;
            }
            catch (Exception ex)
            {
                Invoke(m_appendToSetupTextBox, ex.Message);
                return false;
            }
        }

        // Called when the user has asked to set up an XML configuration.
        private bool SetUpXmlConfiguration()
        {
            try
            {
                // Modify the openPDC configuration file.
                Invoke(m_appendToSetupTextBox, "Attempting to modify configuration files...");
                ModifyConfigFiles(xmlConfigurationTextBox.Text, string.Empty, false);
                Invoke(m_updateProgressBar, 100);
                Invoke(m_appendToSetupTextBox, "Modification of configuration files was successful.");

                return true;
            }
            catch (Exception ex)
            {
                Invoke(m_appendToSetupTextBox, ex.Message);
                return false;
            }
        }

        // Called when the user has asked to set up a web service configuration.
        private bool SetUpWebServiceConfiguration()
        {
            try
            {
                // Modify the openPDC configuration file.
                Invoke(m_appendToSetupTextBox, "Attempting to modify configuration files...");
                ModifyConfigFiles(webServiceConfigurationTextBox.Text, string.Empty, false);
                Invoke(m_updateProgressBar, 100);
                Invoke(m_appendToSetupTextBox, "Modification of configuration files was successful.");

                return true;
            }
            catch (Exception ex)
            {
                Invoke(m_appendToSetupTextBox, ex.Message);
                return false;
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
                if (child.Attributes["name"].Value == "DataProviderString")
                    child.Attributes["value"].Value = dataProviderString;
                else if (child.Attributes["name"].Value == "ConnectionString")
                {
                    child.Attributes["value"].Value = connectionString;
                    child.Attributes["encrypted"].Value = encrypted.ToString();
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

        // Called when error output is received from mysql.exe.
        private void m_mySqlSetup_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Invoke(m_appendToSetupTextBox, e.Data);
        }

        // Called when output is received from mysql.exe.
        private void m_mySqlSetup_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Invoke(m_appendToSetupTextBox, e.Data);
        }

        // Called when error output is received from sqlcmd.exe.
        private void m_sqlServerSetup_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Invoke(m_appendToSetupTextBox, e.Data);
        }

        // Called when output is received from sqlcmd.exe.
        private void m_sqlServerSetup_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Invoke(m_appendToSetupTextBox, e.Data);
        }

        // Appends a line of text to the databaseSetupTextBox.
        private void AppendToSetupTextBox(string line)
        {
            databaseSetupTextBox.AppendText(line + "\r\n");
        }

        // Updates the progress bar.
        private void UpdateProgressBar(int value)
        {
            databaseSetupProgressBar.Value = value;
        }

        #endregion

    }
}
