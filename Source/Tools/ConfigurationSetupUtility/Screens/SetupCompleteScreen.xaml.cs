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
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Controls;
using TVA.Configuration;
using TVA.IO;
using System.ServiceProcess;

namespace ConfigurationSetupUtility
{
    /// <summary>
    /// Interaction logic for SetupCompleteScreen.xaml
    /// </summary>
    public partial class SetupCompleteScreen : UserControl, IScreen
    {

        #region [ Constructors ]

        /// <summary>
        /// Creates a new instance of the <see cref="SetupCompleteScreen"/> class.
        /// </summary>
        public SetupCompleteScreen()
        {
            InitializeComponent();
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
        public Dictionary<string, object> State { get; set; }

        /// <summary>
        /// Allows the screen to update the navigation buttons after a change is made
        /// that would affect the user's ability to navigate to other screens.
        /// </summary>
        public Action UpdateNavigation { get; set; }

        #endregion

        #region [ Methods ]

        // Occurs just before the application shuts down.
        private void Current_Exit(object sender, System.Windows.ExitEventArgs e)
        {
            if (State != null)
            {
                ServiceController iaonHostController = null;
                Process managerProcess = null;
                bool existing = Convert.ToBoolean(State["existing"]);
                bool migrate = existing && Convert.ToBoolean(State["updateConfiguration"]);

                if (migrate)
                {
                    Process migrationProcess = null;

                    try
                    {
                        string dataFolder = FilePath.GetApplicationDataFolder();
                        string migrationDataFolder = dataFolder + "\\..\\DataMigrationUtility";
                        string oldOleDbConnectionString = State["oldOleDbConnectionString"].ToString();
                        string newOleDbConnectionString = State["newOleDbConnectionString"].ToString();
                        string databaseType = State["databaseType"].ToString().Replace(" ", "");
                        ConfigurationFile configFile = null;
                        CategorizedSettingsElementCollection applicationSettings = null;

                        // Copy user-level DataMigrationUtility config file to the DatabaseSetupUtility application folder.
                        if (File.Exists(migrationDataFolder + "\\Settings.xml"))
                        {
                            if (!Directory.Exists(dataFolder))
                                Directory.CreateDirectory(dataFolder);

                            File.Copy(migrationDataFolder + "\\Settings.xml", dataFolder + "\\Settings.xml", true);
                        }

                        // Modify OleDB configuration file settings for the DataMigrationUtility.
                        configFile = ConfigurationFile.Open("DataMigrationUtility.exe.config");
                        applicationSettings = configFile.Settings["applicationSettings"];
                        applicationSettings["FromConnectionString", true].Value = oldOleDbConnectionString;
                        applicationSettings["FromDataType", true].Value = databaseType;
                        applicationSettings["ToConnectionString", true].Value = newOleDbConnectionString;
                        applicationSettings["ToDataType", true].Value = databaseType;
                        configFile.Save();

                        // Copy user-level DatabaseSetupUtility config file to DataMigrationUtility application folder.
                        if (File.Exists(dataFolder + "\\Settings.xml"))
                        {
                            if (!Directory.Exists(migrationDataFolder))
                                Directory.CreateDirectory(migrationDataFolder);

                            File.Copy(dataFolder + "\\Settings.xml", migrationDataFolder + "\\Settings.xml", true);
                        }

                        // Run the DataMigrationUtility.
                        migrationProcess = new Process();
                        migrationProcess.StartInfo.FileName = "DataMigrationUtility.exe";
                        migrationProcess.StartInfo.UseShellExecute = false;
                        migrationProcess.StartInfo.CreateNoWindow = true;
                        migrationProcess.Start();
                        migrationProcess.WaitForExit();
                    }
                    finally
                    {
                        if (migrationProcess != null)
                            migrationProcess.Close();
                    }
                }

                try
                {
                    // If the user requested it, start the openPDC service.
                    if (m_serviceStartCheckBox.IsChecked.Value)
                    {
                        iaonHostController = new ServiceController("openPDC");

                        if (iaonHostController.Status == ServiceControllerStatus.Stopped)
                            iaonHostController.Start();
                    }

                    // If the user requested it, start the openPDC Manager.
                    if (m_managerStartCheckBox.IsChecked.Value)
                    {
                        managerProcess = new Process();
                        managerProcess.StartInfo.FileName = "openPDCManager.exe";
                        managerProcess.StartInfo.UseShellExecute = false;
                        managerProcess.StartInfo.CreateNoWindow = true;
                        managerProcess.Start();
                    }
                }
                finally
                {
                    if (managerProcess != null)
                        managerProcess.Close();

                    if (iaonHostController != null)
                        iaonHostController.Close();
                }
            }
        }

        #endregion
    }
}
