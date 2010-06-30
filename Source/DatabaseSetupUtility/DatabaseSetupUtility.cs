//*******************************************************************************************************
//  DatabaseSetupUtility.cs - Gbtc
//
//  Tennessee Valley Authority, 2010
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  This software is made freely available under the TVA Open Source Agreement (see below).
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  06/29/2010 - Stephen C. Wills
//       Generated original version of source code.
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TVA;
using TVA.IO;
using System.Diagnostics;
using System.Xml;

namespace DatabaseSetupUtility
{
    /// <summary>
    /// The main <see cref="Form"/> for the Database Setup Utility.
    /// </summary>
    public partial class DatabaseSetupUtility : Form
    {

        #region [ Members ]

        // Fields

        private Page m_accessDatabasePage;
        private Page m_mySqlDatabasePage;
        private Page m_sqlServerDatabasePage;
        private List<Page> m_steps;
        private int m_currentStep;
        private MySqlSetup m_mySqlSetup;
        private SqlServerSetup m_sqlServerSetup;
        private AdvancedForm m_advancedForm;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new instance of the <see cref="DatabaseSetupUtility"/>.
        /// </summary>
        /// <param name="scriptDirectory">The directory containing folders with the database scripts.</param>
        public DatabaseSetupUtility()
        {
            InitializeComponent();

            m_accessDatabasePage = new Page(accessDatabasePanel);
            m_accessDatabasePage.UserInputValidationFunction = ValidateAccessDatabasePage;
            m_mySqlDatabasePage = new Page(mySqlDatabasePanel);
            m_mySqlDatabasePage.UserInputValidationFunction = ValidateMySqlDatabasePage;
            m_sqlServerDatabasePage = new Page(sqlServerDatabasePanel);
            m_sqlServerDatabasePage.UserInputValidationFunction = ValidateSqlServerDatabasePage;

            m_steps = new List<Page>();
            m_steps.Add(new Page(databaseTypePanel));
            m_steps.Add(m_accessDatabasePage);
            m_steps.Add(new Page(prepareForSetupPanel));
            m_steps.Add(new Page(databaseSetupPanel));
            m_steps.Add(new Page(setupFinishedPanel));
            m_currentStep = 1;
        }

        #endregion

        #region [ Methods ]

        // Called when the database setup utility form is closing.
        private void DatabaseSetupUtility_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_steps[m_currentStep - 1].PagePanel == databaseSetupPanel)
                e.Cancel = true;
            else if (m_currentStep != m_steps.Count)
            {
                DialogResult selection = MessageBox.Show(this, "The setup is not yet complete. Are you sure you want to exit?", this.Text, MessageBoxButtons.YesNo);

                if (selection == DialogResult.No)
                    e.Cancel = true;
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
            if (m_steps[m_currentStep - 1].UserInputIsValid())
            {
                if (m_currentStep == m_steps.Count)
                    this.Close();
                else
                {
                    backButton.Enabled = true;

                    m_steps[m_currentStep - 1].Visible = false;
                    m_currentStep++;
                    m_steps[m_currentStep - 1].Visible = true;

                    if (m_currentStep == m_steps.Count)
                        nextButton.Text = "Finish";
                }
            }
        }

        // Called when the "Back" button is clicked.
        private void backButton_Click(object sender, EventArgs e)
        {
            nextButton.Text = "Next >";

            m_steps[m_currentStep - 1].Visible = false;
            m_currentStep--;
            m_steps[m_currentStep - 1].Visible = true;

            if (m_currentStep == 1)
                backButton.Enabled = false;
        }

        // Called when the "Cancel" button is clicked.
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Called when the "Access" radio button is checked or unchecked.
        private void accessRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (accessRadioButton.Checked)
                m_steps.Insert(m_currentStep, m_accessDatabasePage);
            else
                m_steps.Remove(m_accessDatabasePage);
        }

        // Called when the "MySQL" radio button is checked or unchecked.
        private void mysqlRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (mysqlRadioButton.Checked)
                m_steps.Insert(m_currentStep, m_mySqlDatabasePage);
            else
                m_steps.Remove(m_mySqlDatabasePage);
        }

        // Called when the "SQL Server" radio button is checked or unchecked.
        private void sqlServerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sqlServerRadioButton.Checked)
                m_steps.Insert(m_currentStep, m_sqlServerDatabasePage);
            else
                m_steps.Remove(m_sqlServerDatabasePage);
        }

        // Called when the "Run initial data script" checkbox is checked or unchecked.
        private void initialDataScriptCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            sampleDataScriptCheckBox.Enabled = !sampleDataScriptCheckBox.Enabled;
        }

        // Called when the button is clicked to browse for a location for the Access database file.
        private void accessDatabaseBrowseButton_Click(object sender, EventArgs e)
        {
            DialogResult selection = accessDatabaseSaveFileDialog.ShowDialog(this);

            if (selection == DialogResult.OK)
            {
                accessDatabaseFileLocationTextBox.Text = accessDatabaseSaveFileDialog.FileName;
            }
        }

        // Called when the MySQL setup page is made visible or invisible.
        private void mySqlDatabasePanel_VisibleChanged(object sender, EventArgs e)
        {
            if (m_mySqlSetup == null)
                m_mySqlSetup = new MySqlSetup();

            advancedButton.Visible = mySqlDatabasePanel.Visible;
        }

        // Called when the SQL Server setup page is made visible or invisible.
        private void sqlServerDatabasePanel_VisibleChanged(object sender, EventArgs e)
        {
            if (m_sqlServerSetup == null)
                m_sqlServerSetup = new SqlServerSetup();

            advancedButton.Visible = sqlServerDatabasePanel.Visible;
        }

        // Called when the "Advanced" button is made visible or invisible.
        private void advancedButton_VisibleChanged(object sender, EventArgs e)
        {
            m_advancedForm = new AdvancedForm();
        }

        // Called when the "Advanced" button is clicked.
        private void advancedButton_Click(object sender, EventArgs e)
        {
            if (mysqlRadioButton.Checked)
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
            m_mySqlSetup.UserName = mySqlDatabaseUserNameTextBox.Text;
            m_advancedForm.ConnectionString = m_mySqlSetup.ConnectionString;

            DialogResult result = m_advancedForm.ShowDialog(this);
            if (result == DialogResult.Cancel)
                m_advancedForm.Encrypted = encrypted;
            else
            {
                m_mySqlSetup.ConnectionString = m_advancedForm.ConnectionString;
                mySqlDatabaseHostNameTextBox.Text = m_mySqlSetup.HostName;
                mySqlDatabaseNameTextBox.Text = m_mySqlSetup.DatabaseName;
                mySqlDatabaseUserNameTextBox.Text = m_mySqlSetup.UserName;

                if (!string.IsNullOrEmpty(m_mySqlSetup.Password))
                    mySqlDatabasePasswordTextBox.Text = m_mySqlSetup.Password;
            }
        }

        // Called when the "Advanced" button is clicked on the SQL Server database page.
        private void SqlServerAdvancedButtonClicked()
        {
            bool encrypted = m_advancedForm.Encrypted;
            m_sqlServerSetup.HostName = sqlServerDatabaseHostNameTextBox.Text;
            m_sqlServerSetup.DatabaseName = sqlServerDatabaseNameTextBox.Text;
            m_sqlServerSetup.UserName = sqlServerDatabaseUserNameTextBox.Text;
            m_advancedForm.ConnectionString = m_sqlServerSetup.ConnectionString;

            DialogResult result = m_advancedForm.ShowDialog(this);
            if (result == DialogResult.Cancel)
                m_advancedForm.Encrypted = encrypted;
            else
            {
                m_sqlServerSetup.ConnectionString = m_advancedForm.ConnectionString;
                sqlServerDatabaseHostNameTextBox.Text = m_sqlServerSetup.HostName;
                sqlServerDatabaseNameTextBox.Text = m_sqlServerSetup.DatabaseName;
                sqlServerDatabaseUserNameTextBox.Text = m_sqlServerSetup.UserName;

                if (!string.IsNullOrEmpty(m_sqlServerSetup.Password))
                    sqlServerDatabasePasswordTextBox.Text = m_sqlServerSetup.Password;
            }
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

        // Called when the user has indicated that they are ready to set up their database.
        private void databaseSetupPanel_VisibleChanged(object sender, EventArgs e)
        {
            if (databaseSetupPanel.Visible)
            {
                cancelButton.Enabled = false;
                backButton.Enabled = false;
                nextButton.Enabled = false;

                if (accessRadioButton.Checked)
                    SetUpAccessDatabase();
                else if (mysqlRadioButton.Checked)
                    SetUpMySqlDatabase();
                else
                    SetUpSqlServerDatabase();

                nextButton.Enabled = true;
            }
        }

        // Called when the user has asked to set up an access database.
        private void SetUpAccessDatabase()
        {
            string filePath = null;

            if (initialDataScriptCheckBox.Checked == false)
                filePath = Directory.GetCurrentDirectory() + "\\Database scripts\\Access\\openPDC.mdb";
            else if (sampleDataScriptCheckBox.Checked == false)
                filePath = Directory.GetCurrentDirectory() + "\\Database scripts\\Access\\openPDC-InitialDataSet.mdb";
            else
                filePath = Directory.GetCurrentDirectory() + "\\Database scripts\\Access\\openPDC-SampleDataSet.mdb";

            // Update the progress bar to indicate we found the database file.
            databaseSetupProgressBar.Value = 2;

            // Copy the file to the specified path.
            File.Copy(filePath, accessDatabaseFileLocationTextBox.Text);
            databaseSetupProgressBar.Value = 95;

            // Modify the openPDC configuration file.
            string configFileName = Directory.GetCurrentDirectory() + "\\openPDC.exe.Config";
            XmlDocument configFile = new XmlDocument();
            configFile.Load(configFileName);
            XmlNode systemSettings = configFile.SelectSingleNode("configuration/categorizedSettings/systemSettings");

            foreach (XmlNode child in systemSettings.ChildNodes)
            {
                if (child.Attributes["name"].Value == "ConnectionString")
                    child.Attributes["value"].Value = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + accessDatabaseFileLocationTextBox.Text;
                else if (child.Attributes["name"].Value == "DataProviderString")
                    child.Attributes["value"].Value = "AssemblyName={System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089}; ConnectionType=System.Data.OleDb.OleDbConnection; AdapterType=System.Data.OleDb.OleDbDataAdapter";
            }

            configFile.Save(configFileName);

            databaseSetupProgressBar.Value = 100;
        }

        // Called when the user has asked to set up a MySQL database.
        private void SetUpMySqlDatabase()
        {
            List<string> scriptNames = new List<string>();
            StringBuilder args = new StringBuilder();

            // Determine which scripts need to be run.
            scriptNames.Add("openPDC.sql");
            if (initialDataScriptCheckBox.Checked)
            {
                scriptNames.Add("InitialDataSet.sql");
                if (sampleDataScriptCheckBox.Checked)
                    scriptNames.Add("SampleDataSet.sql");
            }

            // Set up database connection string.
            m_mySqlSetup.HostName = mySqlDatabaseHostNameTextBox.Text;
            m_mySqlSetup.DatabaseName = mySqlDatabaseNameTextBox.Text;
            m_mySqlSetup.UserName = mySqlDatabaseUserNameTextBox.Text;
            m_mySqlSetup.Password = mySqlDatabasePasswordTextBox.Text;

            // Set up command line arguments to mysql.exe.
            args.Append("-u");
            args.Append(m_mySqlSetup.UserName);
            args.Append(" -p");
            args.Append(m_mySqlSetup.Password);

            foreach (string scriptName in scriptNames)
            {
                Process mySqlProcess = null;
                StreamReader scriptStream = null;
                StreamWriter processInput = null;

                try
                {
                    string scriptPath = Directory.GetCurrentDirectory() + "\\Database scripts\\MySQL\\" + scriptName;
                    this.Update();

                    // Start mysql.exe.
                    mySqlProcess = new Process();
                    mySqlProcess.StartInfo.FileName = "mysql.exe";
                    mySqlProcess.StartInfo.Arguments = args.ToString();
                    mySqlProcess.StartInfo.UseShellExecute = false;
                    mySqlProcess.StartInfo.RedirectStandardInput = true;
                    mySqlProcess.StartInfo.CreateNoWindow = true;
                    mySqlProcess.Start();

                    // Send the script as standard input to mysql.exe.
                    scriptStream = new StreamReader(new FileStream(scriptPath, FileMode.Open, FileAccess.Read));
                    processInput = mySqlProcess.StandardInput;

                    while (!scriptStream.EndOfStream)
                    {
                        string line = scriptStream.ReadLine();

                        if (line.StartsWith("CREATE DATABASE") || line.StartsWith("USE"))
                            line = line.Replace("openPDC", m_mySqlSetup.DatabaseName);

                        processInput.WriteLine(line);
                    }

                    // Wait for mysql.exe to finish.
                    processInput.Close();
                    mySqlProcess.WaitForExit();

                    if (mySqlProcess.ExitCode != 0)
                        throw new Exception("Failed to create MySQL database.");

                    // Update the progress bar.
                    databaseSetupProgressBar.Value += 95 / scriptNames.Count;
                }
                finally
                {
                    // Close streams and processes.
                    if (scriptStream != null)
                        scriptStream.Close();

                    if (processInput != null)
                        processInput.Close();

                    if (mySqlProcess != null)
                        mySqlProcess.Close();
                }
            }

            // Modify the openPDC configuration file.
            string configFileName = Directory.GetCurrentDirectory() + "\\openPDC.exe.Config";
            XmlDocument configFile = new XmlDocument();
            configFile.Load(configFileName);
            XmlNode systemSettings = configFile.SelectSingleNode("configuration/categorizedSettings/systemSettings");

            foreach (XmlNode child in systemSettings.ChildNodes)
            {
                if (child.Attributes["name"].Value == "ConnectionString")
                    child.Attributes["value"].Value = m_mySqlSetup.ConnectionString;
                else if (child.Attributes["name"].Value == "DataProviderString")
                    child.Attributes["value"].Value = "AssemblyName={MySql.Data, Version=5.2.7.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d}; ConnectionType=MySql.Data.MySqlClient.MySqlConnection; AdapterType=MySql.Data.MySqlClient.MySqlDataAdapter";
            }

            configFile.Save(configFileName);
            
            databaseSetupProgressBar.Value = 100;
        }

        // Called when the user has asked to set up a SQL Server database.
        private void SetUpSqlServerDatabase()
        {
            List<string> scriptNames = new List<string>();
            StringBuilder args = new StringBuilder();

            // Determine which scripts need to be run.
            scriptNames.Add("openPDC.sql");
            if (initialDataScriptCheckBox.Checked)
            {
                scriptNames.Add("InitialDataSet.sql");
                if (sampleDataScriptCheckBox.Checked)
                    scriptNames.Add("SampleDataSet.sql");
            }

            // Set up database connection string.
            m_sqlServerSetup.HostName = sqlServerDatabaseHostNameTextBox.Text;
            m_sqlServerSetup.DatabaseName = sqlServerDatabaseNameTextBox.Text;
            m_sqlServerSetup.UserName = sqlServerDatabaseUserNameTextBox.Text;
            m_sqlServerSetup.Password = sqlServerDatabasePasswordTextBox.Text;

            // Command line argument for host name.
            args.Append("-S ");
            args.Append(m_sqlServerSetup.HostName);

            // Command line argument for user name.
            if (!string.IsNullOrEmpty(m_sqlServerSetup.UserName))
            {
                args.Append(" -U ");
                args.Append(m_sqlServerSetup.UserName);
            }

            // Command line argument for password.
            if (!string.IsNullOrEmpty(m_sqlServerSetup.Password))
            {
                args.Append(" -P ");
                args.Append(m_sqlServerSetup.Password);
            }

            // Command line argument for input file.
            args.Append(" -i ");

            foreach (string scriptName in scriptNames)
            {
                Process sqlCmdProcess = null;
                StreamReader scriptStream = null;
                StreamWriter copyStream = null;
                string scriptPath = Directory.GetCurrentDirectory() + "\\Database scripts\\SQL Server\\" + scriptName;
                string copyPath = Path.GetTempFileName();

                try
                {
                    // Copy the script to a temporary file with the proper database name.
                    scriptStream = new StreamReader(new FileStream(scriptPath, FileMode.Open, FileAccess.Read));
                    copyStream = new StreamWriter(new FileStream(copyPath, FileMode.Create, FileAccess.Write));

                    while (!scriptStream.EndOfStream)
                    {
                        string line = scriptStream.ReadLine();

                        if (line.StartsWith("CREATE DATABASE") || line.StartsWith("USE"))
                            line = line.Replace("openPDC", m_sqlServerSetup.DatabaseName);

                        copyStream.WriteLine(line);
                    }

                    copyStream.Close();

                    // Start sqlcmd.exe.
                    sqlCmdProcess = new Process();
                    sqlCmdProcess.StartInfo.FileName = "sqlcmd.exe";
                    sqlCmdProcess.StartInfo.Arguments = args.ToString() + '"' + copyPath + '"';
                    sqlCmdProcess.StartInfo.UseShellExecute = false;
                    sqlCmdProcess.StartInfo.CreateNoWindow = true;
                    sqlCmdProcess.Start();
                    sqlCmdProcess.WaitForExit();

                    if (sqlCmdProcess.ExitCode != 0)
                        throw new Exception("Failed to create SQL Server database.");

                    // Update the progress bar.
                    databaseSetupProgressBar.Value += 95 / scriptNames.Count;
                }
                finally
                {
                    // Close streams and processes.
                    if (scriptStream != null)
                        scriptStream.Close();

                    if (copyStream != null)
                        copyStream.Close();

                    if (sqlCmdProcess != null)
                        sqlCmdProcess.Close();

                    // Delete the temporary file.
                    if (File.Exists(copyPath))
                        File.Delete(copyPath);
                }
            }

            // Modify the openPDC configuration file.
            string configFileName = Directory.GetCurrentDirectory() + "\\openPDC.exe.Config";
            XmlDocument configFile = new XmlDocument();
            configFile.Load(configFileName);
            XmlNode systemSettings = configFile.SelectSingleNode("configuration/categorizedSettings/systemSettings");

            foreach (XmlNode child in systemSettings.ChildNodes)
            {
                if (child.Attributes["name"].Value == "ConnectionString")
                    child.Attributes["value"].Value = m_sqlServerSetup.ConnectionString;
                else if (child.Attributes["name"].Value == "DataProviderString")
                    child.Attributes["value"].Value = "AssemblyName={System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089}; ConnectionType=System.Data.SqlClient.SqlConnection; AdapterType=System.Data.SqlClient.SqlDataAdapter";
            }

            configFile.Save(configFileName);

            databaseSetupProgressBar.Value = 100;
        }

        // Called when the last page is made visible.
        private void setupFinishedPanel_VisibleChanged(object sender, EventArgs e)
        {
            backButton.Enabled = false;
        }

        #endregion
    }
}
