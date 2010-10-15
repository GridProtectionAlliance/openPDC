//******************************************************************************************************
//  NodeSelectionScreen.xaml.cs - Gbtc
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
//  10/14/2010 - Stephen C. Wills
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Xml;
using TVA;

namespace ConfigurationSetupUtility.Screens
{
    /// <summary>
    /// Interaction logic for NodeSelectionScreen.xaml
    /// </summary>
    public partial class NodeSelectionScreen : UserControl, IScreen
    {

        #region [ Members ]

        // Nested Types

        private class NodeInfo
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Company { get; set; }
            public string Description { get; set; }
        }

        // Constants

        // Delegates

        // Events

        // Fields

        private ICollection<NodeInfo> m_nodes;
        private Dictionary<string, object> m_state;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new instance of the <see cref="NodeSelectionScreen"/> class.
        /// </summary>
        public NodeSelectionScreen()
        {
            InitializeComponent();
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets the screen to be displayed when the user clicks the "Next" button.
        /// </summary>
        public IScreen NextScreen { get; set; }

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
            IDbConnection connection = GetDatabaseConnection();
            IList<NodeInfo> nodes = GetNodes(connection);
            Guid nodeId = GetNodeIdFromConfigFile();
            NodeInfo defaultSelection = nodes.SingleOrDefault(info => info.Id == nodeId);
            int defaultIndex = (defaultSelection == null) ? 0 : nodes.IndexOf(defaultSelection);

            if (nodes.Count > 0)
                m_infoTextBlock.Text = "Please select the node you would like the openPDC to use.";
            else
            {
                // Inform the user that the node list could not be found.
                m_infoTextBlock.Text = "The Configuration Setup Utility encountered some difficulty"
                    + " retrieving the node list from your existing database."
                    + " This will not affect your ability to complete the setup.";
            }

            // If the configuration file node is not already in the list,
            // add it as a possible selection in case the user does not wish to change it.
            if (defaultSelection == null)
            {
                nodes.Add(new NodeInfo()
                {
                    Id = nodeId,
                    Name = "ConfigFile",
                    Description = "This node was found in the configuration file."
                });
            }

            m_dataGrid.ItemsSource = nodes;
            m_dataGrid.SelectedIndex = defaultIndex;
        }

        // Gets a database connection based on the selections the user made earlier in the setup.
        private IDbConnection GetDatabaseConnection()
        {
            if (Convert.ToBoolean(m_state["updateConfiguration"]))
                return GetConnectionFromConfigFile();
            else
            {
                string databaseType = m_state["databaseType"].ToString();

                if (databaseType == "access")
                    return GetAccessDatabaseConnection();
                else if (databaseType == "sql server")
                    return GetSqlServerConnection();
                else
                    return GetMySqlConnection();
            }
        }

        // Gets a database connection to the Access database configured earlier in the setup.
        private IDbConnection GetAccessDatabaseConnection()
        {
            string databaseFileName = m_state["accessDatabaseFilePath"].ToString();
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + databaseFileName;
            return new OleDbConnection(connectionString);
        }

        // Gets a database connection to the SQL Server database configured earlier in the setup.
        private IDbConnection GetSqlServerConnection()
        {
            SqlServerSetup sqlSetup = m_state["sqlServerSetup"] as SqlServerSetup;
            return (sqlSetup == null) ? null : new SqlConnection(sqlSetup.ConnectionString);
        }

        // Gets a database connection to the MySQL database configured earlier in the setup.
        private IDbConnection GetMySqlConnection()
        {
            MySqlSetup sqlSetup = m_state["mySqlSetup"] as MySqlSetup;
            string connectionString = (sqlSetup == null) ? null : sqlSetup.ConnectionString;
            string dataProviderString = m_state["mySqlDataProviderString"].ToString();
            return GetConnection(connectionString, dataProviderString);
        }

        // Gets a database connection object using the connection information that is stored in the configuration file.
        private IDbConnection GetConnectionFromConfigFile()
        {
            IDbConnection connection = null;
            string configFileName = Directory.GetCurrentDirectory() + "\\openPDC.exe.config";
            XmlDocument doc = new XmlDocument();
            IEnumerable<XmlNode> systemSettings;
            XmlNode connectionNode, dataProviderNode;

            try
            {
                doc.Load(configFileName);
                systemSettings = doc.SelectNodes("configuration/categorizedSettings/systemSettings/add").Cast<XmlNode>();
                connectionNode = systemSettings.SingleOrDefault(node => node.Attributes != null && node.Attributes["name"].Value == "ConnectionString");
                dataProviderNode = systemSettings.SingleOrDefault(node => node.Attributes != null && node.Attributes["name"].Value == "DataProviderString");

                if (connectionNode != null && dataProviderNode != null)
                {
                    string connectionString = connectionNode.Attributes["value"].Value;
                    string dataProviderString = dataProviderNode.Attributes["value"].Value;
                    connection = GetConnection(connectionString, dataProviderString);
                }
            }
            catch
            {
                // Ignore file not found and similar exceptions.
                // Failure to retrieve the node list should not
                // interrupt the setup.
            }

            return connection;
        }

        // Gets a database connection object using the given connection string and data provider string.
        private IDbConnection GetConnection(string connectionString, string dataProviderString)
        {
            Dictionary<string, string> settings = dataProviderString.ParseKeyValuePairs();
            string assemblyName = settings["AssemblyName"].ToNonNullString();
            string connectionTypeName = settings["ConnectionType"].ToNonNullString();
            string adapterTypeName = settings["AdapterType"].ToNonNullString();

            if (string.IsNullOrEmpty(connectionTypeName) || string.IsNullOrEmpty(adapterTypeName))
                return null;

            try
            {
                IDbConnection connection;
                Assembly assembly;
                Type connectionType, adapterType;

                assembly = Assembly.Load(new AssemblyName(assemblyName));
                connectionType = assembly.GetType(connectionTypeName);
                adapterType = assembly.GetType(adapterTypeName);
                connection = (IDbConnection)Activator.CreateInstance(connectionType);
                connection.ConnectionString = connectionString;

                return connection;
            }
            catch
            {
                // Ignore errors and return null.
                return null;
            }
        }

        // Gets the list of nodes that are stored in the existing database.
        private IList<NodeInfo> GetNodes(IDbConnection connection)
        {
            List<NodeInfo> nodes = new List<NodeInfo>();

            if (connection != null)
            {
                try
                {
                    IDbCommand command;
                    IDataReader reader;

                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "SELECT Node.ID AS ID, Node.Name AS Name, Company.Name AS Company, Description FROM Node LEFT OUTER JOIN Company ON Node.CompanyID = Company.ID";
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Guid nodeId;

                        if (Guid.TryParse(reader["ID"].ToNonNullString(), out nodeId))
                        {
                            nodes.Add(new NodeInfo()
                            {
                                Id = nodeId,
                                Name = reader["Name"].ToNonNullString(),
                                Company = reader["Company"].ToNonNullString(),
                                Description = reader["Description"].ToNonNullString()
                            });
                        }
                    }
                }
                catch
                {
                    // Ignore exceptions since failure to retrieve
                    // the node list should not interrupt the setup.
                }
                finally
                {
                    connection.Close();
                }
            }

            return nodes;
        }

        // Gets the node ID that is currently stored in the config file.
        private Guid GetNodeIdFromConfigFile()
        {
            Guid nodeId = Guid.NewGuid();
            string configFileName = Directory.GetCurrentDirectory() + "\\openPDC.exe.config";
            XmlDocument doc = new XmlDocument();
            IEnumerable<XmlNode> systemSettings;
            XmlNode idNode;

            try
            {
                doc.Load(configFileName);
                systemSettings = doc.SelectNodes("configuration/categorizedSettings/systemSettings/add").Cast<XmlNode>();
                idNode = systemSettings.SingleOrDefault(node => node.Attributes != null && node.Attributes["name"].Value == "NodeID");

                if (idNode != null)
                {
                    string nodeIdString = idNode.Attributes["value"].Value;
                    nodeId = Guid.Parse(nodeIdString);
                }
            }
            catch
            {
                // Ignore file not found and similar exceptions.
                // Failure to retrieve a node from the configuration
                // file will result in a newly generated GUID and
                // should not interrupt the setup.
            }

            return nodeId;
        }

        // Occurs when the user selects a different node to be used by the openPDC.
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NodeInfo info = m_dataGrid.SelectedItem as NodeInfo;

            if (m_state != null && info != null)
                m_state["selectedNodeId"] = info.Id;
        }

        #endregion
    }
}
