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
using System.Windows.Controls;
using TVA.Configuration;
using TVA.IO;
using System.Windows;

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
        public Action UpdateNavigation { get; set; }

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
                            migrationProcess.Start();
                            migrationProcess.WaitForExit();
                        }
                    }

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
                        Process.Start("openPDCManager.exe");
                }
                finally
                {
                    if (m_openPdcServiceController != null)
                        m_openPdcServiceController.Close();
                }
            }
        }

        #endregion
    }
}
