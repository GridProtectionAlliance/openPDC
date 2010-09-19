//******************************************************************************************************
//  AccessDatabaseSetupScreen.xaml.cs - Gbtc
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
//      Generated original version of source code.
//  09/19/2010 - J. Ritchie Carroll
//      Made default path for Access database point to a non-restrictive location.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.IO;

namespace ConfigurationSetupUtility
{
    /// <summary>
    /// Interaction logic for AccessDatabaseSetupScreen.xaml
    /// </summary>
    public partial class AccessDatabaseSetupScreen : UserControl, IScreen
    {

        #region [ Members ]

        // Fields

        private Dictionary<string, object> m_state;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new instance of the <see cref="AccessDatabaseSetupScreen"/> class.
        /// </summary>
        public AccessDatabaseSetupScreen()
        {
            InitializeComponent();

            try
            {
                // Set a default path for Access database that will allow non-restrictive read/write access
                string accessDatabaseFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "openPDC\\");

                // Make sure path exists
                if (!Directory.Exists(accessDatabaseFilePath))
                    Directory.CreateDirectory(accessDatabaseFilePath);

                m_accessDatabaseFilePathTextBox.Text = Path.Combine(accessDatabaseFilePath, "openPDC.mdb");
            }
            catch
            {
                m_accessDatabaseFilePathTextBox.Text = "openPDC.mdb";
            }
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
                if (!string.IsNullOrEmpty(m_accessDatabaseFilePathTextBox.Text))
                    return true;
                else
                {
                    MessageBox.Show("Please enter a location for the Access database file.");
                    m_accessDatabaseFilePathTextBox.Focus();
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

                if (!m_state.ContainsKey("accessDatabaseFilePath"))
                    m_state.Add("accessDatabaseFilePath", m_accessDatabaseFilePathTextBox.Text);
            }
        }

        /// <summary>
        /// Allows the screen to update the navigation buttons after a change is made
        /// that would affect the user's ability to navigate to other screens.
        /// </summary>
        public Action UpdateNavigation { get; set; }

        #endregion

        #region [ Methods ]

        // Occurs when the user changes the path name of the Access database file.
        private void AccessDatabaseFilePathTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (m_state != null)
                m_state["accessDatabaseFilePath"] = m_accessDatabaseFilePathTextBox.Text;
        }

        // Occurs when the user clicks the "Browse..." button.
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            FileDialog browseDialog;
            bool existing = Convert.ToBoolean(m_state["existing"]);
            bool migrate = existing && Convert.ToBoolean(m_state["updateConfiguration"]);

            if (existing && !migrate)
            {
                browseDialog = new OpenFileDialog();
                browseDialog.CheckFileExists = true;
            }
            else
            {
                browseDialog = new SaveFileDialog();
                browseDialog.AddExtension = true;
                browseDialog.CheckPathExists = true;
                browseDialog.DefaultExt = "mdb";
            }

            browseDialog.Filter = "MDB files (*.mdb)|*.mdb|All Files|*.*";

            if (browseDialog.ShowDialog() == true)
                m_accessDatabaseFilePathTextBox.Text = browseDialog.FileName;
        }

        #endregion
    }
}
