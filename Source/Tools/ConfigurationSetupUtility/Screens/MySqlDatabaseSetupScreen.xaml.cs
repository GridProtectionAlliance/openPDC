//******************************************************************************************************
//  MySqlDatabaseSetupScreen.xaml.cs - Gbtc
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ConfigurationSetupUtility
{
    /// <summary>
    /// Interaction logic for MySqlDatabaseSetupScreen.xaml
    /// </summary>
    public partial class MySqlDatabaseSetupScreen : UserControl, IScreen
    {

        #region [ Members ]

        // Fields

        private MySqlSetup m_mySqlSetup;
        private Dictionary<string, object> m_state;
        private Button m_advancedButton;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new instance of the <see cref="MySqlDatabaseSetupScreen"/> class.
        /// </summary>
        public MySqlDatabaseSetupScreen()
        {
            m_mySqlSetup = new MySqlSetup();
            InitializeComponent();
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
                IScreen readyScreen;

                if (!State.ContainsKey("readyScreen"))
                    State.Add("readyScreen", new SetupReadyScreen());

                readyScreen = State["readyScreen"] as IScreen;

                return readyScreen;
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
                if (string.IsNullOrEmpty(m_hostNameTextBox.Text))
                {
                    MessageBox.Show("Please enter a valid host name for the MySQL instance.");
                    m_hostNameTextBox.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(m_databaseNameTextBox.Text))
                {
                    MessageBox.Show("Please enter a valid database name.");
                    m_databaseNameTextBox.Focus();
                    return false;
                }

                if (m_createNewUserCheckBox.IsChecked.Value && string.IsNullOrEmpty(m_newUserNameTextBox.Text))
                {
                    MessageBox.Show("Please enter a valid user name for the new user.");
                    m_newUserNameTextBox.Focus();
                    return false;
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
                bool existing = Convert.ToBoolean(m_state["existing"]);
                bool migrate = existing && Convert.ToBoolean(m_state["updateConfiguration"]);
                Visibility newUserVisibility = (existing && !migrate) ? Visibility.Collapsed : Visibility.Visible;

                m_state["mySqlSetup"] = m_mySqlSetup;
                m_mySqlSetup.HostName = m_hostNameTextBox.Text;
                m_mySqlSetup.DatabaseName = m_databaseNameTextBox.Text;
                m_createNewUserCheckBox.Visibility = newUserVisibility;
                m_newUserNameLabel.Visibility = newUserVisibility;
                m_newUserPasswordLabel.Visibility = newUserVisibility;
                m_newUserNameTextBox.Visibility = newUserVisibility;
                m_newUserPasswordTextBox.Visibility = newUserVisibility;

                if (!m_state.ContainsKey("createNewMySqlUser"))
                    m_state.Add("createNewMySqlUser", m_createNewUserCheckBox.IsChecked.Value);

                if (!m_state.ContainsKey("newMySqlUserName"))
                    m_state.Add("newMySqlUserName", m_newUserNameTextBox.Text);

                if (!m_state.ContainsKey("newMySqlUserPassword"))
                    m_state.Add("newMySqlUserPassword", m_newUserPasswordTextBox.Password);

                if (!m_state.ContainsKey("encryptMySqlConnectionStrings"))
                    m_state.Add("encryptMySqlConnectionStrings", false);

                m_databaseNameTextBox.Text = migrate ? "openPDCv2" : "openPDC";
            }
        }

        // Occurs when the screen is made visible or invisible.
        private void MySqlDatabaseSetupScreen_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (m_advancedButton == null)
            {
                DependencyObject parent = VisualTreeHelper.GetParent(this);
                Window mainWindow;

                while (parent != null && !(parent is Window))
                    parent = VisualTreeHelper.GetParent(parent);

                mainWindow = parent as Window;
                m_advancedButton = (mainWindow == null) ? null : mainWindow.FindName("m_advancedButton") as Button;
            }

            if (m_advancedButton != null)
            {
                if (IsVisible)
                {
                    m_advancedButton.Visibility = Visibility.Visible;
                    m_advancedButton.Click += AdvancedButton_Click;
                }
                else
                {
                    m_advancedButton.Visibility = Visibility.Collapsed;
                    m_advancedButton.Click -= AdvancedButton_Click;
                }
            }
        }

        // Occurs when the user changes the host name of the MySQL instance.
        private void HostNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            m_mySqlSetup.HostName = m_hostNameTextBox.Text;
        }

        // Occurs when the user changes the database name.
        private void DatabaseNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            m_mySqlSetup.DatabaseName = m_databaseNameTextBox.Text;
        }

        // Occurs when the user changes the administrator user name.
        private void AdminUserNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string adminUserName = m_adminUserNameTextBox.Text;
            m_mySqlSetup.UserName = adminUserName;
        }

        // Occurs when the user changes the administrator password.
        private void AdminPasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string adminPassword = m_adminPasswordTextBox.Password;
            m_mySqlSetup.Password = adminPassword;
        }

        // Occurs when the user chooses to create a new database user.
        private void CreateNewUserCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (m_state != null)
                m_state["createNewMySqlUser"] = true;
        }

        // Occurs when the user chooses not to create a new database user.
        private void CreateNewUserCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (m_state != null)
                m_state["createNewMySqlUser"] = false;
        }

        // Occurs when the user changes the user name of the new MySQL database user.
        private void NewUserNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (m_state != null)
                m_state["newMySqlUserName"] = m_newUserNameTextBox.Text;
        }

        // Occurs when the user changes the password of the new MySQL database user.
        private void NewUserPasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (m_state != null)
                m_state["newMySqlUserPassword"] = m_newUserPasswordTextBox.Password;
        }

        // Occurs when the user clicks the "Advanced..." button.
        private void AdvancedButton_Click(object sender, RoutedEventArgs e)
        {
            if (m_state != null)
            {
                string password = m_mySqlSetup.Password;
                bool encrypt = Convert.ToBoolean(m_state["encryptMySqlConnectionStrings"]);
                string connectionString;
                AdvancedSettingsWindow advancedWindow;

                m_mySqlSetup.Password = null;
                connectionString = m_mySqlSetup.ConnectionString;
                advancedWindow = new AdvancedSettingsWindow(connectionString, encrypt);

                if (advancedWindow.ShowDialog() == true)
                {
                    m_mySqlSetup.ConnectionString = advancedWindow.ConnectionString;
                    m_state["encryptMySqlConnectionStrings"] = advancedWindow.Encrypt;
                }

                if (string.IsNullOrEmpty(m_mySqlSetup.Password))
                    m_mySqlSetup.Password = password;

                m_hostNameTextBox.Text = m_mySqlSetup.HostName;
                m_databaseNameTextBox.Text = m_mySqlSetup.DatabaseName;
                m_adminUserNameTextBox.Text = m_mySqlSetup.UserName;
                m_adminPasswordTextBox.Password = m_mySqlSetup.Password;
            }
        }

        #endregion
    }
}
