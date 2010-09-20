//******************************************************************************************************
//  DatabaseSetupScreen.xaml.cs - Gbtc
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
//  09/07/2010 - Stephen C. Wills
//       Generated original version of source code.
//  09/19/2010 - J. Ritchie Carroll
//       Added code to hide Access database option for 64-bit installations
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ConfigurationSetupUtility
{
    /// <summary>
    /// Interaction logic for DatabaseSetupScreen.xaml
    /// </summary>
    public partial class DatabaseSetupScreen : UserControl, IScreen
    {

        #region [ Members ]

        // Fields

        private AccessDatabaseSetupScreen m_accessDatabaseSetupScreen;
        private SqlServerDatabaseSetupScreen m_sqlServerDatabaseSetupScreen;
        private MySqlDatabaseSetupScreen m_mySqlDatabaseSetupScreen;
        private Dictionary<string, object> m_state;
        private bool m_sampleScriptChanged;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new instance of the <see cref="DatabaseSetupScreen"/> class.
        /// </summary>
        public DatabaseSetupScreen()
        {
            InitializeComponent();
            InitializeNextScreens();
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
                string databaseType = m_state["databaseType"].ToString();

                if (databaseType == "access")
                    return m_accessDatabaseSetupScreen;
                else if (databaseType == "sql server")
                    return m_sqlServerDatabaseSetupScreen;
                else
                    return m_mySqlDatabaseSetupScreen;
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
                return true;
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
                return true;
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
                InitializeState();
            }
        }

        /// <summary>
        /// Allows the screen to update the navigation buttons after a change is made
        /// that would affect the user's ability to navigate to other screens.
        /// </summary>
        public Action UpdateNavigation { get; set; }

        #endregion

        #region [ Methods ]

        // Initializes the state keys to their default values.
        private void InitializeState()
        {
            if (m_state != null)
            {
                Visibility checkBoxVisibility = Convert.ToBoolean(m_state["existing"]) ? Visibility.Collapsed : Visibility.Visible;

                m_initialDataScriptCheckBox.Visibility = checkBoxVisibility;
                m_sampleDataScriptCheckBox.Visibility = checkBoxVisibility;

                // Access database will not work in 64-bit installations
                m_accessDatabaseRadioButton.Visibility = Convert.ToBoolean(m_state["64bit"]) ? Visibility.Collapsed : Visibility.Visible;

                if (!m_state.ContainsKey("databaseType"))
                    m_state.Add("databaseType", "sql server");

                if (!m_state.ContainsKey("initialDataScript"))
                    m_state.Add("initialDataScript", true);

                if (!m_state.ContainsKey("sampleDataScript"))
                    m_state.Add("sampleDataScript", false);
            }
        }

        // Initializes the screens that can be used as the next screen based on user input.
        private void InitializeNextScreens()
        {
            m_accessDatabaseSetupScreen = new AccessDatabaseSetupScreen();
            m_sqlServerDatabaseSetupScreen = new SqlServerDatabaseSetupScreen();
            m_mySqlDatabaseSetupScreen = new MySqlDatabaseSetupScreen();
        }

        // Occurs when the user chooses to set up an Access database.
        private void AccessDatabaseRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (m_state != null)
                m_state["databaseType"] = "access";

            if (!m_sampleScriptChanged && m_sampleDataScriptCheckBox != null)
                m_sampleDataScriptCheckBox.IsChecked = true;
        }

        // Occurs when the user chooses to set up a SQL Server database.
        private void SqlServerDatabaseRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (m_state != null)
                m_state["databaseType"] = "sql server";

            if (!m_sampleScriptChanged && m_sampleDataScriptCheckBox != null)
                m_sampleDataScriptCheckBox.IsChecked = false;
        }

        // Occurs when the user chooses to set up a MySQL database.
        private void MySqlRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (m_state != null)
                m_state["databaseType"] = "mysql";

            if (!m_sampleScriptChanged && m_sampleDataScriptCheckBox != null)
                m_sampleDataScriptCheckBox.IsChecked = false;
        }

        // Occurs when the user chooses to run the initial data script when setting up their database.
        private void InitialDataScriptCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (m_state != null)
                m_state["initialDataScript"] = true;
        }

        // Occurs when the user chooses to not run the initial data script when setting up their database.
        private void InitialDataScriptCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (m_state != null)
                m_state["initialDataScript"] = false;
        }

        // Occurs when the user explicitly changes the sample data script check box.
        private void SampleDataScriptCheckBox_Click(object sender, RoutedEventArgs e)
        {
            m_sampleScriptChanged = true;
        }

        // Occurs when the user chooses to run the sample data script when setting up their database.
        private void SampleDataScriptCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (m_state != null)
                m_state["sampleDataScript"] = true;
        }

        // Occurs when the user chooses to not run the sample data script when setting up their database.
        private void SampleDataScriptCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (m_state != null)
                m_state["sampleDataScript"] = false;
        }

        #endregion
    }
}
