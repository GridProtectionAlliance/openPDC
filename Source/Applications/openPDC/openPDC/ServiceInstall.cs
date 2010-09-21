//******************************************************************************************************
//  ServiceInstall.cs - Gbtc
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
//  05/04/2009 - J. Ritchie Carroll
//       Generated original version of source code.
//
//******************************************************************************************************

using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.Xml;
using Microsoft.Win32;
using TVA.IO;
using System.IO;
using System.Windows.Forms;
using System;

namespace openPDC
{
    [RunInstaller(true)]
    public partial class ServiceInstall : Installer
    {
        public ServiceInstall()
        {
            InitializeComponent();
        }

        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);

            try
            {
                // Open the configuration file as an XML document.
                string targetDir = FilePath.AddPathSuffix(Context.Parameters["DP_TargetDir"]).Replace("\\\\", "\\");
                string configFilePath = targetDir + "openPDC.exe.Config";
                string installedBitSize = "32bit";

                if (File.Exists(configFilePath))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(configFilePath);
                    XmlNode node = xmlDoc.SelectSingleNode("configuration/categorizedSettings/systemSettings");
                    XmlNode companyName = null;
                    XmlNode companyAcronym = null;
                    string attributeValue;

                    // Find the needed installation parameters if they already exist.
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        attributeValue = child.Attributes["name"].Value;

                        if (attributeValue == "CompanyName")
                            companyName = child;
                        else if (attributeValue == "CompanyAcronym")
                            companyAcronym = child;
                        else if (attributeValue == "InstalledBitSize")
                        {
                            installedBitSize = child.Attributes["value"].Value;

                            // Default to 32 if no target installation bit size was found
                            if (string.IsNullOrWhiteSpace(installedBitSize))
                                installedBitSize = "32";

                            installedBitSize += "bit";
                        }
                    }

                    // Modify or add the CompanyName parameter.
                    if (companyName != null)
                        companyName.Attributes["value"].Value = Context.Parameters["DP_CompanyName"];
                    else
                    {
                        companyName = xmlDoc.CreateNode(XmlNodeType.Element, "add", string.Empty);
                        companyName.Attributes.Append(CreateAttribute(xmlDoc, "name", "CompanyName"));
                        companyName.Attributes.Append(CreateAttribute(xmlDoc, "value", Context.Parameters["DP_CompanyName"]));
                        companyName.Attributes.Append(CreateAttribute(xmlDoc, "description", "The name of the company who owns this instance of the openPDC."));
                        companyName.Attributes.Append(CreateAttribute(xmlDoc, "encrypted", "false"));
                        node.AppendChild(companyName);
                    }

                    // Modify or add the CompanyAcronym parameter.
                    if (companyAcronym != null)
                        companyAcronym.Attributes["value"].Value = Context.Parameters["DP_CompanyAcronym"];
                    else
                    {
                        companyAcronym = xmlDoc.CreateNode(XmlNodeType.Element, "add", string.Empty);
                        companyAcronym.Attributes.Append(CreateAttribute(xmlDoc, "name", "CompanyAcronym"));
                        companyAcronym.Attributes.Append(CreateAttribute(xmlDoc, "value", Context.Parameters["DP_CompanyAcronym"]));
                        companyAcronym.Attributes.Append(CreateAttribute(xmlDoc, "description", "The acronym representing the company who owns this instance of the openPDC."));
                        companyAcronym.Attributes.Append(CreateAttribute(xmlDoc, "encrypted", "false"));
                        node.AppendChild(companyAcronym);
                    }

                    xmlDoc.Save(configFilePath);
                }

                // Run database setup utility
                Process databaseSetup = null;
                try
                {
                    databaseSetup = new Process();
                    databaseSetup.StartInfo.FileName = targetDir + "ConfigurationSetupUtility.exe";
                    databaseSetup.StartInfo.Arguments = "-install -" + installedBitSize;
                    databaseSetup.StartInfo.WorkingDirectory = targetDir;
                    databaseSetup.StartInfo.UseShellExecute = false;
                    databaseSetup.StartInfo.CreateNoWindow = true;
                    databaseSetup.Start();
                    databaseSetup.WaitForExit();
                }
                finally
                {
                    if (databaseSetup != null)
                        databaseSetup.Close();
                }

                // Make sure configuration editor and database setup utility are run in admin mode since they
                // modify configuration file in programs folder
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers", targetDir + "ConfigurationSetupUtility.exe", "RUNASADMIN", RegistryValueKind.String);
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers", targetDir + "ConfigurationEditor.exe", "RUNASADMIN", RegistryValueKind.String);
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers", targetDir + "ConfigCrypter.exe", "RUNASADMIN", RegistryValueKind.String);
            }
            catch(Exception ex)
            {
                // Not failing install if we can't perform these steps...
                MessageBox.Show("There was an exception detected during the install process, this did not affect the install. The exception reported was: " + ex.Message);
            }
        }

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);

            try
            {
                string targetDir = FilePath.AddPathSuffix(Context.Parameters["DP_TargetDir"].ToString());

                // Make sure configuration editor and database setup utility are run in admin mode since they
                // modify configuration file in programs folder
                using (RegistryKey settings = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers", true))
                {
                    settings.DeleteValue(targetDir + "ConfigurationSetupUtility.exe");
                    settings.DeleteValue(targetDir + "ConfigurationEditor.exe");
                    settings.DeleteValue(targetDir + "ConfigCrypter.exe");
                }
            }
            catch 
            {
                //MessageBox.Show("There was an exception detected during the uninstall process, this did not affect the uninstall. The exception reported was: " + ex.Message);
            }
        }

        private XmlAttribute CreateAttribute(XmlDocument doc, string name, string value)
        {
            XmlAttribute attribute = doc.CreateAttribute(name);
            attribute.Value = value;
            return attribute;
        }
    }
}
