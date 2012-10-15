//*******************************************************************************************************
//  RuntimeConfigurationService.svc.cs - Gbtc
//
//  Tennessee Valley Authority, 2009
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  11/25/2009 - Pinal C. Patel
//       Generated original version of source code.
//  11/07/2010 - Pinal C. Patel
//       Modified to fix breaking changes made to SelfHostingService.
//
//*******************************************************************************************************

using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using GSF.Configuration;
using GSF.Data;
using GSF.ServiceModel;

namespace openPDCServices
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class RuntimeConfigurationService : SelfHostingService, IRuntimeConfigurationService
    {
        #region [ Members ]

        // Fields
        private string m_connectionString;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Initializes a new instance of the <see cref="RuntimeConfigurationService"/> class.
        /// </summary>
        public RuntimeConfigurationService()
            : base()
        {
            PersistSettings = true;
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets the connection string to be used for connection the SQL Server database from where configuration is to be retrieved.
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return m_connectionString;
            }
            set
            {
                m_connectionString = value;
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Saves <see cref="RuntimeConfigurationService"/> settings to the config file if the <see cref="RestService.PersistSettings"/> property is set to true.
        /// </summary>
        public override void SaveSettings()
        {
            base.SaveSettings();
            if (PersistSettings)
            {
                // Ensure that settings category is specified.
                if (string.IsNullOrEmpty(SettingsCategory))
                    throw new InvalidOperationException("SettingsCategory property has not been set");

                // Save settings under the specified category.
                ConfigurationFile config = ConfigurationFile.Current;
                CategorizedSettingsElement element = null;
                CategorizedSettingsElementCollection settings = config.Settings[SettingsCategory];
                element = settings["ConnectionString", true];
                element.Update(m_connectionString, element.Description, element.Encrypted);
                config.Save();
            }
        }

        /// <summary>
        /// Loads saved <see cref="RuntimeConfigurationService"/> settings from the config file if the <see cref="RestService.PersistSettings"/> property is set to true.
        /// </summary>
        public override void LoadSettings()
        {
            base.LoadSettings();
            if (PersistSettings)
            {
                // Ensure that settings category is specified.
                if (string.IsNullOrEmpty(SettingsCategory))
                    throw new InvalidOperationException("SettingsCategory property has not been set");

                // Load settings from the specified category.
                ConfigurationFile config = ConfigurationFile.Current;
                CategorizedSettingsElementCollection settings = config.Settings[SettingsCategory];
                settings.Add("ConnectionString", m_connectionString, "Connection string for connecting to the SQL Server database containing the configuration.", true);
                ConnectionString = settings["ConnectionString"].ValueAs(m_connectionString);
            }
        }

        public Stream GetConfiguration(string nodeName)
        {
            // Initialize service if uninitialized.
            Initialize();

            // Check for the required parameters.
            if (string.IsNullOrEmpty(nodeName))
                throw new ArgumentNullException("nodeName");

            if (string.IsNullOrEmpty(m_connectionString))
                throw new ArgumentNullException("ConnectionString");

            SqlConnection database = null;
            DataSet configuration = new DataSet("Iaon"); ;
            MemoryStream output = new MemoryStream();
            try
            {
                // Open connection to the database.
                database = new SqlConnection(m_connectionString);
                database.Open();

                // Lookup ID of the specified node.
                object nodeID = database.ExecuteScalar(string.Format("SELECT ID FROM Node WHERE [Name] = '{0}'", nodeName));
                if (nodeID == null)
                    throw new ArgumentException("nodeName is not valid.");

                // Add configuration entities table to the output.
                DataTable entities, entity;
                entities = database.RetrieveData("SELECT * FROM ConfigurationEntity WHERE Enabled <> 0 ORDER BY LoadOrder");
                entities.TableName = "ConfigurationEntity";
                configuration.Tables.Add(entities.Copy());

                // Add each configuration entity to the output.
                foreach (DataRow row in entities.Rows)
                {
                    // Load configuration entity data filtered by node ID.
                    entity = database.RetrieveData(string.Format("SELECT * FROM {0} WHERE NodeID = '{1}'", row["SourceName"].ToString(), nodeID.ToString()));
                    entity.TableName = row["RuntimeName"].ToString();

                    // Remove redundant node ID column from the data.
                    entity.Columns.Remove("NodeID");

                    // Add entity configuration data to the output.
                    configuration.Tables.Add(entity.Copy());
                }

                // Extract prepared data in XML format.
                configuration.WriteXml(output);

                // Return formatted output to requestor.
                output.Position = 0;
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/xml";
                WebOperationContext.Current.OutgoingResponse.ContentLength = output.Length;
                return output;
            }
            finally
            {
                // Release used memory.
                if (database != null)
                    database.Dispose();

                if (configuration != null)
                    configuration.Dispose();
            }
        }

        #endregion
    }
}
