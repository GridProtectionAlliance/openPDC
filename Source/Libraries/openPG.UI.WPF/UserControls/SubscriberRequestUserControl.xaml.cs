//******************************************************************************************************
//  SubscriberRequestUserControl.xaml.cs - Gbtc
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
//  05/18/2011 - Magdiel Lorenzo
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using openPDC.UI.DataModels;
using TimeSeriesFramework.UI;
using TVA;
using TVA.Collections;
using TVA.Data;
using TVA.IO;
using TVA.Security.Cryptography;

namespace openPG.UI.UserControls
{
    /// <summary>
    /// Interaction logic for SubscriberRequestUserControl.xaml
    /// </summary>
    public partial class SubscriberRequestUserControl : UserControl
    {
        #region [ Constructor ]

        /// <summary>
        /// Creates an instance of <see cref="SubscriberRequestUserControl"/> class.
        /// </summary>     
        public SubscriberRequestUserControl()
        {
            InitializeComponent();
            this.Loaded += SubscriberRequestUserControl_Loaded;
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Populates screen fields on load.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Arguments of the event.</param>
        void SubscriberRequestUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Connect to database to retrieve company information for current node
            AdoDataConnection database = new AdoDataConnection(CommonFunctions.DefaultSettingsCategory);
            try
            {
                string query = database.ParameterizedQueryString("SELECT Company.Acronym, Company.Name FROM Company, Node WHERE Company.ID = Node.CompanyID AND Node.ID = {0}", "id");
                DataRow row = database.Connection.RetrieveRow(database.AdapterType, query, database.CurrentNodeID());

                m_acronymField.Text = row.Field<string>("Acronym");
                m_nameField.Text = row.Field<string>("Name");

                // Generate a default shared secret password for subscriber key and initialization vector
                byte[] buffer = new byte[4];
                TVA.Security.Cryptography.Random.GetBytes(buffer);

                string generatedSecret = Convert.ToBase64String(buffer).RemoveCrLfs();

                if (generatedSecret.Contains("="))
                    generatedSecret = generatedSecret.Split('=')[0];

                m_sharedSecretField.Text = generatedSecret;

                // Generate an identity for this subscriber
                AesManaged sa = new AesManaged();
                sa.GenerateKey();
                m_authenticationIDField.Text = Convert.ToBase64String(sa.Key);

                // Generate valid local IP addresses for this connection
                IEnumerable<IPAddress> addresses = Dns.GetHostAddresses(Dns.GetHostName()).OrderBy(key => key.AddressFamily);
                m_validIpAddressesField.Text = addresses.ToDelimitedString("; ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Subscriber Request", MessageBoxButton.OK);
            }
            finally
            {
                if (database != null)
                    database.Dispose();
            }

            try
            {
                Dictionary<string, string> settings = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
                settings = database.ServiceConnectionString().ParseKeyValuePairs();
                IPAddress[] hostIPs = null;
                if (settings.ContainsKey("server"))
                    hostIPs = Dns.GetHostAddresses(settings["server"].Split(':')[0]);

                IEnumerable<IPAddress> localIPs = Dns.GetHostAddresses("localhost").Concat(Dns.GetHostAddresses(Dns.GetHostName()));

                // Check to see if entered host name corresponds to a local IP address
                if (hostIPs == null)
                    MessageBox.Show("Failed to find service host address. Secure key exchange may not succeed." + Environment.NewLine + "Please make sure to run manager application with administrative privileges on the server where service is hosted.", "Subscription Request", MessageBoxButton.OK, MessageBoxImage.Warning);
                else if (!hostIPs.Any(ip => localIPs.Contains(ip)))
                    MessageBox.Show("Secure key exchange may not succeed." + Environment.NewLine + "Please make sure to run manager application with administrative privileges on the server where service is hosted.", "Subscription Request", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch
            {
                MessageBox.Show("Please make sure to run manager application with administrative privileges on the server where service is hosted.", "Subscription Request", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Click Event for Export button.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Arguments of the event</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ExportAuthorizationRequest(sender, e);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Popup(ex.Message + Environment.NewLine + "Inner Exception: " + ex.InnerException.Message, "Subscription Request Exception:", MessageBoxImage.Error);
                    CommonFunctions.LogException(null, "Subscription Request", ex.InnerException);
                }
                else
                {
                    Popup(ex.Message, "Subscription Request Exception:", MessageBoxImage.Error);
                    CommonFunctions.LogException(null, "Subscription Request", ex);
                }
            }
        }

        // Export the authorization request.
        private void ExportAuthorizationRequest(object sender, RoutedEventArgs e)
        {
            const string messageFormat = "Data subscription adapter \"{0}\" already exists. Unable to create subscription request.";

            Device device = null;
            bool saveDevice;

            System.Windows.Forms.SaveFileDialog saveFileDialog;
            System.Windows.Forms.DialogResult dialogResult;

            string requestAcronym;
            string requestName;
            string[] keyIV;

            if (!string.IsNullOrEmpty(m_acronymField.Text.Replace(" ", "")))
            {
                // Determine if the user wants to save the associated device
                saveDevice = m_createAdapter.IsChecked.HasValue && m_createAdapter.IsChecked.Value;

                if (saveDevice)
                {
                    // Check if the device already exists
                    device = GetDeviceByAcronym(m_acronymField.Text.Replace(" ", ""));

                    if (device != null)
                    {
                        m_acronymField.Focus();
                        m_acronymField.SelectAll();
                        throw new Exception(string.Format(messageFormat, device.Acronym));
                    }
                }

                saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                saveFileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
                saveFileDialog.DefaultExt = ".xml";
                dialogResult = saveFileDialog.ShowDialog();

                if (dialogResult != System.Windows.Forms.DialogResult.Cancel)
                {
                    AuthenticationRequest request = new AuthenticationRequest();

                    // Get the name and acronym that go into the authentication request
                    if (TryGetCompanyAcronym(out requestAcronym))
                    {
                        requestName = string.Format("{0} subscription authorization", requestAcronym);
                    }
                    else
                    {
                        requestAcronym = m_acronymField.Text;
                        requestName = "Subscription authorization";
                    }

                    // Export cipher key to common crypto cache
                    if (!ExportCipherKey(m_sharedSecretField.Text, 256))
                        throw new Exception("Failed to export cipher keys from common key cache.");
                    
                    // Reload local crypto cache and get key and IV
                    // that go into the authentication request
                    Cipher.ReloadCache();
                    keyIV = Cipher.ExportKeyIV(m_sharedSecretField.Text, 256).Split('|');

                    // Set up the request
                    request.Acronym = requestAcronym;
                    request.Name = requestName;
                    request.SharedSecret = m_sharedSecretField.Text;
                    request.AuthenticationID = m_authenticationIDField.Text;
                    request.Key = keyIV[0];
                    request.IV = keyIV[1];
                    request.ValidIPAddresses = m_validIpAddressesField.Text;

                    // Create the request
                    File.WriteAllBytes(saveFileDialog.FileName, Serialization.Serialize(request, TVA.SerializationFormat.Xml));

                    // Send ReloadCryptoCache to service
                    ReloadServiceCryptoCache();

                    // Save the associated device
                    if (saveDevice)
                        SaveDevice(device);
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                MessageBox.Show("Acronym is a required field. Please provide value.");
                m_acronymField.Focus();
            }
        }

        // Gets the device from the database with the given acronym for the currently selected node.
        private Device GetDeviceByAcronym(string acronym)
        {
            AdoDataConnection database = null;
            string nodeID;

            try
            {
                database = new AdoDataConnection(CommonFunctions.DefaultSettingsCategory);
                nodeID = CommonFunctions.CurrentNodeID(database).ToString();
                return Device.GetDevice(database, string.Format(" WHERE NodeID = '{0}' AND Acronym = '{1}'", nodeID, acronym));
            }
            finally
            {
                if ((object)database != null)
                    database.Dispose();
            }
        }

        // Attempt to get the company acronym stored in the openPG configuration file.
        private bool TryGetCompanyAcronym(out string acronym)
        {
            string configFileName;
            FileStream configStream = null;
            StreamReader configStreamReader = null;
            XElement configRoot;
            XElement systemSettings;

            try
            {
                // Set up XML searching
                configFileName = FilePath.GetAbsolutePath("openPG.exe.config");
                configStream = File.Open(configFileName, FileMode.Open, FileAccess.Read);
                configStreamReader = new StreamReader(configStream);
                configRoot = XElement.Parse(configStreamReader.ReadToEnd());

                // Find company name and company acronym
                systemSettings = configRoot.Element("categorizedSettings").Element("systemSettings");
                acronym = systemSettings.Elements().Single(e => e.Attribute("name").Value == "CompanyAcronym").Attribute("value").Value;

                // Indicate success
                return true;
            }
            catch
            {
                // Company info retrieval failed
                acronym = null;
                return false;
            }
            finally
            {
                if (configStreamReader != null)
                    configStreamReader.Dispose();

                if (configStream != null)
                    configStream.Dispose();
            }
        }

        // Exports the given cipher key from the common key cache.
        private bool ExportCipherKey(string password, int keySize)
        {
            ProcessStartInfo configCrypterInfo = new ProcessStartInfo();
            Process configCrypter;

            configCrypterInfo.FileName = FilePath.GetAbsolutePath("ConfigCrypter.exe");
            configCrypterInfo.Arguments = string.Format("-password {0} -keySize {1}", password, keySize);
            configCrypterInfo.CreateNoWindow = true;

            configCrypter = Process.Start(configCrypterInfo);
            configCrypter.WaitForExit();

            return configCrypter.ExitCode == 0;
        }

        // Send service command to reload crypto cache.
        private void ReloadServiceCryptoCache()
        {
            try
            {
                CommonFunctions.SendCommandToService("ReloadCryptoCache");
            }
            catch (Exception ex)
            {
                string message = "Unable to notify service about updated crypto cache:" + Environment.NewLine;

                if (ex.InnerException != null)
                {
                    message += ex.Message + Environment.NewLine;
                    message += "Inner Exception: " + ex.InnerException.Message;
                    Popup(message, "Subscription Request Exception:", MessageBoxImage.Information);
                    CommonFunctions.LogException(null, "Subscription Request", ex.InnerException);
                }
                else
                {
                    message += ex.Message;
                    Popup(message, "Subscription Request Exception:", MessageBoxImage.Information);
                    CommonFunctions.LogException(null, "Subscription Request", ex);
                }
            }
        }

        // Associate the given device with the
        // authorization request and save it.
        private void SaveDevice(Device device)
        {
            if (device == null)
            {
                device = new Device();
                device.Enabled = false;
                device.IsConcentrator = true;
                device.ProtocolID = GetGatewayProtocolID();
                device.ConnectionString = "interface=0.0.0.0; compression=false; autoConnect=true; requireAuthentication=true; sharedSecret=" + m_sharedSecretField.Text +
                    "; localport=6175; transportprotocol=udp; authenticationID={" + m_authenticationIDField.Text + "}; commandChannel={server=127.0.0.1:6171; interface=0.0.0.0}";
            }

            device.Acronym = m_acronymField.Text.Replace(" ", "");
            device.Name = m_nameField.Text;
            Device.Save(null, device);
        }

        // Get the Gateway Transport protocol ID by querying the database.
        private int? GetGatewayProtocolID()
        {
            const string query = "SELECT ID FROM Protocol WHERE Acronym = 'GatewayTransport'";
            AdoDataConnection database = null;
            object queryResult;

            try
            {
                database = new AdoDataConnection(CommonFunctions.DefaultSettingsCategory);
                queryResult = database.Connection.ExecuteScalar(query);
                return (queryResult != null) ? Convert.ToInt32(queryResult) : 8;
            }
            finally
            {
                if ((object)database != null)
                    database.Dispose();
            }
        }

        // Display popup message for the user
        private void Popup(string message, string caption, MessageBoxImage image)
        {
            MessageBox.Show(Application.Current.MainWindow, message, caption, MessageBoxButton.OK, image);
        }

        #endregion
    }
}
