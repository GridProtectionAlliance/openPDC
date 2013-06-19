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
//  02/28/2011 - Mehulbhai P Thakkar
//       Added a checkbox to allow pass-through authentication.
//       Added SetFocus() method to set intial focus for better user experience.
//       Added TextBox_GotFocus() event for all textboxes to highlight current value in the textbox.
//  03/02/2011 - J. Ritchie Carroll
//       Improved text box focusing after message box display.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using GSF.Identity;

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
                if (!CheckUserAuthentication())
                {
                    if ((bool)RadioButtonWindowsAuthentication.IsChecked)
                    {
                        string errorMessage = string.Empty;

                        try
                        {
                            string[] userData = m_userNameTextBox.Text.Split(new char[] { '\\' });

                            if (userData.Length == 2)
                            {
                                if (UserInfo.AuthenticateUser(userData[0].Trim(), userData[1].Trim(), m_userPasswordTextBox.Password.Trim(), out errorMessage) == null)
                                {
                                    MessageBox.Show("Authentication failed. Please verify your username and password.\r\n\r\n" + errorMessage, "Windows Authentication User Setup Error");
                                    m_userPasswordTextBox.Focus();
                                    return false;
                                }

                                // We only store user account name in the database in Windows authentication mode - so we make sure it is well formatted
                                m_userNameTextBox.Text = userData[0].Trim() + "\\" + userData[1].Trim();
                            }
                            else
                            {
                                MessageBox.Show("Username format is invalid: for Windows authentication please provide a username formatted like \"domain\\username\".\r\nUse the machine name \"" + Environment.MachineName + "\" as the domain name if the system is not on a domain or you want to use a local account.", "Windows Authentication User Setup Error");
                                m_userNameTextBox.Focus();
                                return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + Environment.NewLine + errorMessage, "Windows Authentication User Setup Error");
                            m_userPasswordTextBox.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        string passwordRequirementRegex = "^.*(?=.{8,})(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).*$";
                        string passwordRequirementError = "Invalid Password: Password must be at least 8 characters and must contain at least 1 number, 1 upper case letter and 1 lower case letter";

                        string userName = m_userNameTextBox.Text.Trim();
                        string password = m_userPasswordTextBox.Password.Trim();
                        string confirmPassword = m_userConfirmPasswordTextBox.Password.Trim();
                        string firstName = m_userFirstNameTextBox.Text.Trim();
                        string lastName = m_userLastNameTextBox.Text.Trim();

                        if (string.IsNullOrEmpty(userName))
                        {
                            MessageBox.Show("Please provide administrative user account name.", "Database Authentication User Setup Error");
                            m_userNameTextBox.Focus();
                            return false;
                        }
                        else if (userName.Contains("\\"))
                        {
                            MessageBox.Show("User name being used for database authentication appears to have a domain name prefix.\r\n\r\nAvoid using a \"\\\" in the user name or switch to Windows authentication mode.", "Database Authentication User Setup Error");
                            m_userNameTextBox.Focus();
                            return false;
                        }
                        else if (string.IsNullOrEmpty(password) || !Regex.IsMatch(password, passwordRequirementRegex))
                        {
                            MessageBox.Show("Please provide valid password for administrative user." + Environment.NewLine + passwordRequirementError, "Database Authentication User Setup Error");
                            m_userPasswordTextBox.Focus();
                            return false;
                        }
                        else if (password != confirmPassword)
                        {
                            MessageBox.Show("Password does not match the cofirm password", "Database Authentication User Setup Error");
                            m_userConfirmPasswordTextBox.Focus();
                            return false;
                        }
                        else if (string.IsNullOrEmpty(m_userFirstNameTextBox.Text.Trim()))
                        {
                            MessageBox.Show("Please provide first name for administrative user", "Database Authentication User Setup Error");
                            m_userFirstNameTextBox.Focus();
                            return false;
                        }
                        else if (string.IsNullOrEmpty(m_userLastNameTextBox.Text.Trim()))
                        {
                            MessageBox.Show("Please provide last name for administrative user", "Database Authentication User Setup Error");
                            m_userLastNameTextBox.Focus();
                            return false;
                        }
                    }
                }

                // Update state values to the latest entered on the form.
                InitializeState();
                return true;
            }
        }

        private SecureString ConvertToSecureString(string value)
        {
            SecureString ret = new SecureString();

            foreach (char c in value)
            {
                ret.AppendChar(c);
            }

            ret.MakeReadOnly();

            return ret;
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
        public Action UpdateNavigation
        {
            get;
            set;
        }

        #endregion

        #region [ Methods ]

        // Initializes the state keys to their default values.
        private void InitializeState()
        {
            if (m_state != null)
            {
                m_state["authenticationType"] = (bool)RadioButtonWindowsAuthentication.IsChecked ? "windows" : "database";
                m_state["adminUserName"] = m_userNameTextBox.Text.Trim();
                m_state["adminPassword"] = m_userPasswordTextBox.Password.Trim();
                m_state["adminUserFirstName"] = m_userFirstNameTextBox.Text.Trim();
                m_state["adminUserLastName"] = m_userLastNameTextBox.Text.Trim();
                m_state["allowPassThroughAuthentication"] = (bool)m_checkBoxPassThroughAuthentication.IsChecked ? "True" : "False";
            }
        }

        private void RadioButtonWindowsAuthentication_Checked(object sender, RoutedEventArgs e)
        {
            // Windows Authentication Selected.            
            m_messageTextBlock.Text = "Please enter current credentials for the Windows authenticated user setup to be the administrator for openPDC. Credentials validated by operating system.";
            m_userAccountHeaderTextBlock.Text = "Windows Authentication";
            m_userNameTextBox.Text = Thread.CurrentPrincipal.Identity.Name;
            m_userPasswordTextBox.IsEnabled = !CheckUserAuthentication();
            m_dbInfoGrid.Visibility = Visibility.Collapsed;
            m_checkBoxPassThroughAuthentication.Visibility = Visibility.Visible;
            m_textBlockPassThroughMessage.Visibility = Visibility.Visible;
            SetFocus();

        }

        private void RadioButtonWindowsAuthentication_Unchecked(object sender, RoutedEventArgs e)
        {
            // Database Authentication Selected.
            m_messageTextBlock.Text = "Please provide the desired credentials for database user setup to be the administrator for openPDC. Password complexity rules apply.";
            m_userAccountHeaderTextBlock.Text = "Database Authentication";
            m_userNameTextBox.Text = string.Empty;
            m_userPasswordTextBox.IsEnabled = true;
            m_dbInfoGrid.Visibility = Visibility.Visible;
            m_checkBoxPassThroughAuthentication.Visibility = Visibility.Collapsed;
            m_textBlockPassThroughMessage.Visibility = Visibility.Collapsed;
            SetFocus();
        }

        private void UserAccountCredentialsSetupScreen_Loaded(object sender, RoutedEventArgs e)
        {            
            RadioButtonWindowsAuthentication.IsChecked = true;
            m_userNameTextBox.Text = Thread.CurrentPrincipal.Identity.Name;
            SetFocus();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            m_userPasswordTextBox.IsEnabled = !CheckUserAuthentication();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox)
                ((TextBox)sender).SelectAll();
            else if (sender is PasswordBox)
                ((PasswordBox)sender).SelectAll();
        }

        private bool CheckUserAuthentication()
        {
            string userName;
            UserInfo userInfo;
            WindowsPrincipal currentPrincipal;

            userName = m_userNameTextBox.Text;

            if (RadioButtonWindowsAuthentication.IsChecked == true && !string.IsNullOrEmpty(userName))
            {
                currentPrincipal = Thread.CurrentPrincipal as WindowsPrincipal;

                if ((object)currentPrincipal != null)
                {
                    userInfo = new UserInfo(m_userNameTextBox.Text);
                    userInfo.Initialize();

                    if (string.Compare(currentPrincipal.Identity.Name, userInfo.LoginID, true) == 0 && currentPrincipal.Identity.IsAuthenticated)
                        return true;
                }
            }

            return false;
        }

        private void SetFocus()
        {
            if (!string.IsNullOrEmpty(m_userNameTextBox.Text))
                m_userPasswordTextBox.Focus();
            else
                m_userNameTextBox.Focus();
        }

        #endregion
    }
}
