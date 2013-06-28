//******************************************************************************************************
//  HistorianSetupScreen.xaml.cs - Gbtc
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
//  12/20/2010 - Stephen C. Wills
//       Generated original version of source code.
//  01/12/2011 - J. Ritchie Carroll
//       Modified adapter list to display descriptions instead of assemblies / types
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using GSF.TimeSeries.Adapters;
using GSF;
using GSF.ErrorManagement;
using GSF.IO;
using GSF.Reflection;

namespace ConfigurationSetupUtility.Screens
{
    /// <summary>
    /// Interaction logic for HistorianSetupScreen.xaml
    /// </summary>
    public partial class HistorianSetupScreen : UserControl, IScreen
    {
        #region [ Members ]

        // Nested Types
        private class HistorianAdapter
        {
            #region [ Members ]

            // Fields
            private Type m_type;
            private string m_description;

            #endregion

            #region [ Constructors ]

            /// <summary>
            /// Creates a new <see cref="HistorianAdapter"/>.
            /// </summary>
            /// <param name="type"><see cref="Type"/> of historian adapter.</param>
            public HistorianAdapter(Type type)
            {
                m_type = type;

                DescriptionAttribute descriptionAttribute;

                if (m_type.TryGetAttribute(out descriptionAttribute))
                    m_description = descriptionAttribute.Description;
                else
                    m_description = m_type.FullName;
            }

            #endregion

            #region [ Properties ]

            /// <summary>
            /// Gets type name of <see cref="HistorianAdapter"/>.
            /// </summary>
            public string TypeName
            {
                get
                {
                    return m_type.FullName;
                }
            }

            /// <summary>
            /// Gets assembly name of <see cref="HistorianAdapter"/>.
            /// </summary>
            public string AssemblyName
            {
                get
                {
                    return Path.GetFileName(m_type.Assembly.Location);
                }
            }

            #endregion

            #region [ Methods ]

            /// <summary>
            /// Provides the description of the <see cref="HistorianAdapter"/> as its string reprensentation.
            /// </summary>
            /// <returns>The description of the <see cref="HistorianAdapter"/>.</returns>
            public override string ToString()
            {
                return m_description;
            }

            #endregion
        }

        // Fields
        private HistorianConnectionStringScreen m_parametersScreen;
        private Dictionary<string, object> m_state;
        private List<HistorianAdapter> m_historianAdapters;
        private HistorianAdapter m_defaultAdapter;
        private string m_assemblyName;
        private string m_typeName;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new instance of the <see cref="HistorianSetupScreen"/>.
        /// </summary>
        public HistorianSetupScreen()
        {
            m_parametersScreen = new HistorianConnectionStringScreen();
            m_historianAdapters = new List<HistorianAdapter>();

            // This can fail if user is not running under proper credentials
            try
            {
                foreach (Type type in GetHistorianTypes())
                {
                    m_historianAdapters.Add(new HistorianAdapter(type));
                }
            }
            catch (Exception ex)
            {
                LogFile logger = new LogFile();
                logger.FileName = FilePath.GetAbsolutePath("ErrorLog.txt");
                logger.WriteTimestampedLine(ErrorLogger.GetExceptionInfo(ex, false));
                logger.Dispose();
            }

            if (m_historianAdapters.Count > 0)
            {
                m_defaultAdapter = m_historianAdapters.Find(adapter => adapter.TypeName == "HistorianAdapters.LocalOutputAdapter");

                if (m_defaultAdapter == null)
                    m_defaultAdapter = m_historianAdapters[0];

                m_assemblyName = m_defaultAdapter.AssemblyName;
                m_typeName = m_defaultAdapter.TypeName;
            }

            if (m_defaultAdapter == null)
            {
                m_assemblyName = FilePath.GetAbsolutePath("HistorianAdapters.dll");
                m_typeName = "HistorianAdapters.LocalOutputAdapter";
            }

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
                string assemblyName = m_state["historianAssemblyName"].ToString();
                string typeName = m_state["historianTypeName"].ToString();

                m_parametersScreen.RefreshConnectionStringParameters(assemblyName, typeName);

                // Skip the connection parameters screen when selecting virtual historian
                if (assemblyName != "TestingAdapters.dll" || typeName != "TestingAdapters.VirtualOutputAdapter")
                    return m_parametersScreen;

                // Otherwise, setup is ready
                return (IScreen)m_state["setupReadyScreen"];
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
                if (!string.IsNullOrWhiteSpace(AcronymTextBox.Text))
                    return true;
                else
                {
                    MessageBox.Show("You must specify an acronym for the historian.");
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

            if (!m_state.ContainsKey("historianConnectionString"))
                m_state["historianConnectionString"] = string.Empty;

            HistorianAdapterListBox.ItemsSource = m_historianAdapters;
            HistorianAdapterListBox.SelectedItem = m_defaultAdapter;
        }

        // Searches the assemblies in the current directory for historian implementations.
        // The historians are output adapters for which the initial value of
        // OutputIsForArchive is true.
        private List<Type> GetHistorianTypes()
        {
            return typeof(IOutputAdapter).LoadImplementations(true).Where(type =>
            {
                IOutputAdapter adapter = Activator.CreateInstance(type) as IOutputAdapter;
                return (adapter != null) && adapter.OutputIsForArchive;
            }).ToList();
        }

        // Occurs when the user changes the selection in the historian list box.
        // It saves the selection made by the user for future steps in the setup process.
        private void HistorianAdapterListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HistorianAdapter adapter = HistorianAdapterListBox.SelectedItem as HistorianAdapter;

            if (adapter != null)
            {
                m_assemblyName = adapter.AssemblyName;
                m_typeName = adapter.TypeName;

                m_state["historianTypeName"] = m_typeName;
                m_state["historianAssemblyName"] = m_assemblyName;

                AssemblyInfoTextBox.Content = m_typeName + " from " + m_assemblyName;
            }
        }

        // Occurs when the user changes the acronym of the historian.
        private void AcronymTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Validate format of acronym
            string currentValue = AcronymTextBox.Text;

            if (string.IsNullOrWhiteSpace(currentValue))
            {
                AcronymTextBox.Text = "PPA";
            }
            else
            {
                string newValue = currentValue.RemoveWhiteSpace().RemoveControlCharacters().ToUpper();

                if (string.Compare(currentValue, newValue) != 0)
                    AcronymTextBox.Text = newValue;

                if (m_state != null)
                    m_state["historianAcronym"] = AcronymTextBox.Text;
            }
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
