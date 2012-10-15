//*******************************************************************************************************
//  HistorianMetadataService.svc.cs - Gbtc
//
//  Tennessee Valley Authority, 2009
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  11/25/2009 - Pinal C. Patel
//       Generated original version of source code.
//  12/04/2009 - Pinal C. Patel
//       Updated the SQL for retrieving metadata from database.
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
using System.Text;
using GSF.Configuration;
using GSF.Data;
using GSF.ServiceModel;

namespace openPDCServices
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class HistorianMetadataService : SelfHostingService, IHistorianMetadataService
    {
        #region [ Members ]

        // Fields
        private string m_connectionString;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Initializes a new instance of the <see cref="HistorianMetadataService"/> class.
        /// </summary>
        public HistorianMetadataService()
            : base()
        {
            PersistSettings = true;
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets the connection string to be used for connection the SQL Server database from where metadata is to be retrieved.
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
        /// Saves <see cref="HistorianMetadataService"/> settings to the config file if the <see cref="RestService.PersistSettings"/> property is set to true.
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
        /// Loads saved <see cref="HistorianMetadataService"/> settings from the config file if the <see cref="RestService.PersistSettings"/> property is set to true.
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
                settings.Add("ConnectionString", m_connectionString, "Connection string for connecting to the SQL Server database containing the metadata.", true);
                ConnectionString = settings["ConnectionString"].ValueAs(m_connectionString);
            }
        }

        public Stream GetMetadata(string historianInstance)
        {
            // Initialize service if uninitialized.
            Initialize();

            // Check for the required parameters.
            if (string.IsNullOrEmpty(historianInstance))
                throw new ArgumentNullException("historianInstance");

            if (string.IsNullOrEmpty(m_connectionString))
                throw new ArgumentNullException("ConnectionString");

            SqlConnection database = null;
            DataSet metadata  = null;
            MemoryStream output = null;
            byte[] envelopOpeningTag = Encoding.UTF8.GetBytes("<Metadata>\r\n");
            byte[] envelopClosingTag = Encoding.UTF8.GetBytes("\r\n</Metadata>");
            try
            {
                // Open connection to the database.
                database = new SqlConnection(m_connectionString);
                database.Open();

                // Retrive data from the database.
                metadata = database.RetrieveDataSet(string.Format("SELECT * FROM HistorianMetadata WHERE PlantCode = '{0}'", historianInstance));
                metadata.DataSetName = "MetadataRecords";
                metadata.Tables[0].TableName = "MetadataRecord";
                foreach (DataColumn column in metadata.Tables[0].Columns)
                {
                    column.ColumnMapping = MappingType.Attribute;
                }

                // Extract retrieved data in XML format.
                output = new MemoryStream();
                output.Write(envelopOpeningTag, 0, envelopOpeningTag.Length);
                metadata.WriteXml(output);
                output.Write(envelopClosingTag, 0, envelopClosingTag.Length);
                
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

                if (metadata != null)
                    metadata.Dispose();
            }
        }

        #endregion
    }
}
