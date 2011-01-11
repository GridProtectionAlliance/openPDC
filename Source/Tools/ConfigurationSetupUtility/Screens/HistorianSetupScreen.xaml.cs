//******************************************************************************************************
//  HistorianSetupScreen.xaml.cs - Gbtc
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
//  12/20/2010 - Stephen C. Wills
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using TimeSeriesFramework.Adapters;
using TVA;
using System.Windows;
using System.Reflection;

namespace ConfigurationSetupUtility.Screens
{
    /// <summary>
    /// Interaction logic for HistorianSetupScreen.xaml
    /// </summary>
    public partial class HistorianSetupScreen : UserControl, IScreen
    {

        #region [ Members ]

        // Fields

        private IScreen m_nextScreen;
        private Dictionary<string, object> m_state;
        private string m_assemblyName;
        private string m_typeName;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new instance of the <see cref="HistorianSetupScreen"/>.
        /// </summary>
        public HistorianSetupScreen()
        {
            m_nextScreen = new HistorianConnectionStringScreen();
            m_assemblyName = "HistorianAdapters.dll";
            m_typeName = "HistorianAdapters.LocalOutputAdapter";
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
                return m_nextScreen;
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
                if (!string.IsNullOrEmpty(m_assemblyName) && !string.IsNullOrEmpty(m_typeName))
                    return true;
                else
                {
                    MessageBox.Show("Please select an assembly name and a type name.");
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
            List<string> assemblies = GetHistorianTypes()
                .Select(type => Path.GetFileName(type.Assembly.Location))
                .Distinct().ToList();

            if (!m_state.ContainsKey("historianAssemblyName"))
                m_state["historianAssemblyName"] = m_assemblyName;

            if (!m_state.ContainsKey("historianTypeName"))
                m_state["historianTypeName"] = m_typeName;

            if (!m_state.ContainsKey("historianAcronym"))
                m_state["historianAcronym"] = AcronymTextBox.Text;

            if (!m_state.ContainsKey("historianName"))
                m_state["historianName"] = NameTextBox.Text;

            if (!m_state.ContainsKey("historianDescription"))
                m_state["historianDescription"] = DescriptionTextBox.Text;

            AssemblyNameListBox.ItemsSource = assemblies;
            AssemblyNameListBox.SelectedIndex = assemblies.IndexOf(m_assemblyName);
        }

        // Searches the assemblies in the current directory for historian implementations.
        // The historians are output adapters for which the initial value of
        // OutputIsForArchive is true.
        private List<Type> GetHistorianTypes()
        {
            Func<Type, bool> whereFunction = type =>
            {
                IOutputAdapter adapter = Activator.CreateInstance(type) as IOutputAdapter;
                return (adapter != null) && adapter.OutputIsForArchive;
            };

            return typeof(IOutputAdapter).LoadImplementations(true).Where(whereFunction).ToList();
        }

        // Occurs when the user changes the selected assembly in the assembly list box.
        // This updates the historian list box to contain the historians that are found
        // in the selected assembly.
        private void AssemblyNameListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> historianTypes;

            Func<Type, bool> whereFunction = type =>
            {
                string typeAssemblyName = Path.GetFileName(type.Assembly.Location);
                return typeAssemblyName.Equals(m_assemblyName, StringComparison.CurrentCultureIgnoreCase);
            };

            m_assemblyName = AssemblyNameListBox.SelectedItem.ToNonNullString();
            m_state["historianAssemblyName"] = m_assemblyName;

            historianTypes = GetHistorianTypes().Where(whereFunction).Select(type => type.FullName).ToList();
            TypeNameListBox.ItemsSource = historianTypes;
            TypeNameListBox.SelectedIndex = historianTypes.IndexOf(m_typeName);
        }

        // Occurs when the user changes the selection in the historian list box.
        // It saves the selection made by the user for future steps in the setup process.
        private void TypeNameListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m_typeName = TypeNameListBox.SelectedItem.ToNonNullString();
            m_state["historianTypeName"] = m_typeName;
        }

        // Occurs when the user changes the acronym of the historian.
        private void AcronymTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (m_state != null)
                m_state["historianAcronym"] = AcronymTextBox.Text;
        }

        // Occurs when the user changes the name of the historian.
        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (m_state != null)
                m_state["historianName"] = NameTextBox.Text;
        }

        // Occurs when the user changes the description associated with the historian.
        private void DescriptionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (m_state != null)
                m_state["historianDescription"] = DescriptionTextBox.Text;
        }

        #endregion
    }
}
