//******************************************************************************************************
//  UserAccountCredentialsSetupScreen.xaml.cs - Gbtc
//
//  Copyright © 2011, Grid Protection Alliance.  All Rights Reserved.
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
//  01/23/2011 - J. Ritchie Carroll
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TVA;

namespace ConfigurationSetupUtility.Screens
{
    /// <summary>
    /// Interaction logic for UserAccountCredentialsSetupScreen.xaml
    /// </summary>
    public partial class UserAccountCredentialsSetupScreen : UserControl, IScreen
    {
        #region [ Members ]

        // Fields
        private Dictionary<string, object> m_state;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new instance of the <see cref="UserAccountCredentialsSetupScreen"/> class.
        /// </summary>
        public UserAccountCredentialsSetupScreen()
        {
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
                IScreen applyChangesScreen;

                if (!State.ContainsKey("applyChangesScreen"))
                    State.Add("applyChangesScreen", new ApplyConfigurationChangesScreen());

                applyChangesScreen = State["applyChangesScreen"] as IScreen;

                return applyChangesScreen;
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
                string adminUserName = null, adminPassword = null;

                // Assign or re-assign state values, change events won't fire if user left default values
                m_state["adminUserName"] = m_userNameTextBox.Text.Trim();
                m_state["adminPassword"] = m_userPasswordTextBox.Password.Trim();

                adminUserName = m_state["adminUserName"] as string;
                adminPassword = m_state["adminPassword"] as string;

                if (!string.IsNullOrWhiteSpace(adminUserName))
                {
                    if (!string.IsNullOrWhiteSpace(adminPassword))
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Please enter a password for the administrative user.");
                        m_userPasswordTextBox.Focus();
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a user name for the administrative user.");
                    m_userNameTextBox.Focus();
                    return false;
                }
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
            m_userPasswordTextBox.Focus();
        }

        private void UserNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (m_state != null)
                m_state["adminUserName"] = m_userNameTextBox.Text.Trim();
        }

        private void UserPasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (m_state != null)
                m_state["adminPassword"] = m_userPasswordTextBox.Password.Trim();
        }

        #endregion
    }
}
