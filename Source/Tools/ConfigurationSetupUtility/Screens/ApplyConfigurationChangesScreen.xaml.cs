//******************************************************************************************************
//  ApplyConfigurationChangesScreen.xaml.cs - Gbtc
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
//  10/12/2010 - Stephen C. Wills
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace ConfigurationSetupUtility.Screens
{
    /// <summary>
    /// Interaction logic for ApplyConfigurationChangesScreen.xaml
    /// </summary>
    public partial class ApplyConfigurationChangesScreen : UserControl, IScreen
    {

        #region [ Members ]

        // Fields

        private NodeSelectionScreen m_nodeSelectionScreen;
        private SetupReadyScreen m_setupReadyScreen;
        private Dictionary<string, object> m_state;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new instance of the <see cref="ApplyConfigurationChangesScreen"/> class.
        /// </summary>
        public ApplyConfigurationChangesScreen()
        {
            InitializeComponent();
            m_nodeSelectionScreen = new NodeSelectionScreen();
            m_setupReadyScreen = new SetupReadyScreen();
            m_nodeSelectionScreen.NextScreen = m_setupReadyScreen;
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
                bool applyChangesToService = Convert.ToBoolean(m_state["applyChangesToService"]);
                bool existing = Convert.ToBoolean(m_state["existing"]);

                if (applyChangesToService && existing)
                    return m_nodeSelectionScreen;
                else
                    return m_setupReadyScreen;
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
            object webManagerDir = Registry.GetValue("HKEY_LOCAL_MACHINE\\Software\\openPDCManagerServices", "Installation Path", null) ?? Registry.GetValue("HKEY_LOCAL_MACHINE\\Software\\Wow6432Node\\openPDCManagerServices", "Installation Path", null);
            bool managerOptionsEnabled = m_state["configurationType"].ToString() == "database";
            bool webManagerOptionEnabled = managerOptionsEnabled && (webManagerDir != null);

            // Enable or disable the options based on whether those options are available for the current configuration.
            m_openPdcManagerLocalCheckBox.IsEnabled = managerOptionsEnabled;
            m_openPdcManagerWebCheckBox.IsEnabled = webManagerOptionEnabled;

            // If the options are disabled, they must also be unchecked.
            if (!managerOptionsEnabled)
                m_openPdcManagerLocalCheckBox.IsChecked = false;

            if (!webManagerOptionEnabled)
                m_openPdcManagerWebCheckBox.IsChecked = false;

            // Set up the state object with the proper initial values.
            m_state["applyChangesToService"] = m_openPdcServiceCheckBox.IsChecked.Value;
            m_state["applyChangesToLocalManager"] = m_openPdcManagerLocalCheckBox.IsChecked.Value;
            m_state["applyChangesToWebManager"] = m_openPdcManagerWebCheckBox.IsChecked.Value;
        }

        // Occurs when the user chooses to apply changes to the openPDC service.
        private void OpenPdcServiceCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (m_state != null)
                m_state["applyChangesToService"] = true;
        }

        // Occurs when the user chooses to not apply changes to the openPDC service.
        private void OpenPdcServiceCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (m_state != null)
                m_state["applyChangesToService"] = false;
        }

        // Occurs when the user chooses to changes to the local openPDC Manager application.
        private void OpenPdcManagerLocalCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (m_state != null)
                m_state["applyChangesToLocalManager"] = true;
        }

        // Occurs when the user chooses to not apply changes to the local openPDC Manager application.
        private void OpenPdcManagerLocalCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (m_state != null)
                m_state["applyChangesToLocalManager"] = false;
        }

        // Occurs when the user chooses to apply changes to the openPDC Manager web application.
        private void OpenPdcManagerWebCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (m_state != null)
                m_state["applyChangesToWebManager"] = true;
        }

        // Occurs when the user chooses to not apply changes to the openPDC Manager web application.
        private void OpenPdcManagerWebCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (m_state != null)
                m_state["applyChangesToWebManager"] = false;
        }

        #endregion
    }
}
