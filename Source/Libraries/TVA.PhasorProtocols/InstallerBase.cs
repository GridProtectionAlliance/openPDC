//******************************************************************************************************
//  InstallerBase.cs - Gbtc
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
//  09/22/2010 - J. Ritchie Carroll
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;
using TVA.IO;
using TVA.Reflection;
using System.Security.Permissions;
using System.Diagnostics.CodeAnalysis;
using System.Security;
using System.Security.Principal;

namespace TVA.PhasorProtocols
{
    /// <summary>
    /// Defines a common installer class for the openPDC.
    /// </summary>
    /// <remarks>
    /// Users may choose to only install openPDC or openPDC Manager, in either case common installation steps
    /// need to occur so these steps are managed in this one common base class.
    /// </remarks>
    [RunInstaller(true)]
    public abstract partial class InstallerBase : Installer
    {
        #region [ Properties ]

        /// <summary>
        /// Gets associated configuration name.
        /// </summary>
        protected abstract string ConfigurationName { get; }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Called when system settings are loaded.
        /// </summary>
        /// <param name="configurationFile">Open xml document containing configuration settings.</param>
        /// <param name="systemSettingsNode">Xml node containing system settings.</param>
        [SuppressMessage("Microsoft.Design", "CA1059")]
        protected virtual void OnSystemSettingsLoaded(XmlDocument configurationFile, XmlNode systemSettingsNode)
        {
        }

        /// <summary>
        /// Installs the class.
        /// </summary>
        /// <param name="stateSaver">Current state information.</param>
        [SuppressMessage("Microsoft.Security", "CA2122"), SuppressMessage("Microsoft.Globalization", "CA1300")]
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);

            try
            {
                // Open the configuration file as an XML document.
                string targetDir = FilePath.AddPathSuffix(Context.Parameters["DP_TargetDir"]).Replace("\\\\", "\\");
                string configFilePath = targetDir + ConfigurationName;
                string installedBitSize = "32bit";

                if (File.Exists(configFilePath))
                {
                    XmlDocument configurationFile = new XmlDocument();
                    configurationFile.Load(configFilePath);
                    XmlNode systemSettingsNode = configurationFile.SelectSingleNode("configuration/categorizedSettings/systemSettings");

                    if (systemSettingsNode != null)
                    {
                        // Allow user to add or update custom configuration settings if desired
                        OnSystemSettingsLoaded(configurationFile, systemSettingsNode);

                        // Lookup installed bit size in configuration file, if defined
                        XmlNode installedBitSizeNode = systemSettingsNode.SelectSingleNode("add[@name = 'InstalledBitSize']");

                        if (installedBitSizeNode != null)
                        {
                            installedBitSize = installedBitSizeNode.Attributes["value"].Value;

                            // Default to 32 if no target installation bit size was found
                            if (string.IsNullOrWhiteSpace(installedBitSize))
                                installedBitSize = "32";

                            installedBitSize += "bit";
                        }
                    }

                    // Save any updates to configuration file
                    configurationFile.Save(configFilePath);
                }

                // Run configuration setup utility
                Process configurationSetup = null;

                try
                {
                    configurationSetup = new Process();
                    configurationSetup.StartInfo.FileName = targetDir + "ConfigurationSetupUtility.exe";
                    configurationSetup.StartInfo.Arguments = "-install -" + installedBitSize;
                    configurationSetup.StartInfo.WorkingDirectory = targetDir;
                    configurationSetup.StartInfo.UseShellExecute = false;
                    configurationSetup.StartInfo.CreateNoWindow = true;
                    configurationSetup.Start();
                    configurationSetup.WaitForExit();
                }
                finally
                {
                    if (configurationSetup != null)
                        configurationSetup.Close();
                }

                // Make sure configuration editor, configuration setup utility and config crypter are all run in admin mode since they
                // modify files in programs folder
                string appCompatFlagsKey = "HKEY_CURRENT_USER\\Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers";
                
                Registry.SetValue(appCompatFlagsKey, targetDir + "ConfigurationSetupUtility.exe", "RUNASADMIN", RegistryValueKind.String);
                Registry.SetValue(appCompatFlagsKey, targetDir + "ConfigurationEditor.exe", "RUNASADMIN", RegistryValueKind.String);
                Registry.SetValue(appCompatFlagsKey, targetDir + "ConfigCrypter.exe", "RUNASADMIN", RegistryValueKind.String);
            }
            catch (Exception ex)
            {
                // Not failing install if we can't perform these steps...
                MessageBox.Show("There was an exception detected during the install process, this did not affect the install. The exception reported was: " + ex.Message);
            }
        }

        /// <summary>
        /// Called before uninstall of the class.
        /// </summary>
        /// <param name="savedState">Saved state information.</param>
        [SuppressMessage("Microsoft.Security", "CA2122"), SuppressMessage("Microsoft.Globalization", "CA1300")]
        protected override void OnBeforeUninstall(IDictionary savedState)
        {
            base.OnBeforeUninstall(savedState);

            try
            {
                string targetDir;

                // Get installation path as stored in the registry
                using (RegistryKey settings = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Grid Protection Alliance\\openPDC"))
                {
                    targetDir = FilePath.AddPathSuffix(settings.GetValue("InstallPath", Directory.GetCurrentDirectory()).ToString()).Replace("\\\\", "\\");
                }

                // Remove run as admin key values for configuration editor, configuration setup utility and config crypter
                using (RegistryKey settings = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers", true))
                {
                    settings.DeleteValue(targetDir + "ConfigurationSetupUtility.exe");
                    settings.DeleteValue(targetDir + "ConfigurationEditor.exe");
                    settings.DeleteValue(targetDir + "ConfigCrypter.exe");
                }
            }
            catch (Exception ex)
            {
                // Not failing uninstall if we can't perform these steps...
                MessageBox.Show("There was an exception detected during the uninstall process, this did not affect the uninstall. The exception reported was: " + ex.Message);
            }
        }

        #endregion
    }
}
