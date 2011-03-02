//******************************************************************************************************
//  Main.cs - Gbtc
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
//  09/24/2010 - J. Ritchie Carroll
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Setup
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            radioButton64bit.Enabled = (IntPtr.Size > 4);

            try
            {
                Version version = Assembly.GetEntryAssembly().GetName().Version;
                labelVersion.Text = string.Format(labelVersion.Text, version.Major, version.Minor, version.Build, version.Revision);
            }
            catch
            {
                labelVersion.Visible = false;
            }
        }

        private void buttonInstall_Click(object sender, EventArgs e)
        {
            bool runSetup = false;

            // Verify that .NET 4.0 is installed
            try
            {
                RegistryKey net40 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\.NETFramework\\v4.0.30319");

                if (net40 == null)
                {
                    if (MessageBox.Show("Microsoft .NET 4.0 does not appear to be installed on this computer. The .NET 4.0 framework is required to be installed before you continue installation. Would you like to install it now?", ".NET 4.0 Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Process net40Install;
                        string netInstallPath = "Installers\\dotNetFx40_Full_x86_x64.exe";
                        
                        if (File.Exists(netInstallPath))
                        {
                            try
                            {
                                // Attempt to launch .NET 4.0 installer...
                                net40Install = new Process();
                                net40Install.StartInfo.FileName = netInstallPath;
                                net40Install.StartInfo.UseShellExecute = false;
                                net40Install.Start();
                            }
                            catch
                            {
                                // At a minimum open folder containing .NET 4.0 installer since its available to run...
                                net40Install = new Process();
                                net40Install.StartInfo.FileName = Directory.GetCurrentDirectory() + "\\Installers\\";
                                net40Install.StartInfo.UseShellExecute = true;
                                net40Install.Start();
                            }
                        }
                        else
                        {
                            net40Install = new Process();
                            net40Install.StartInfo.FileName = "http://www.microsoft.com/downloads/en/details.aspx?FamilyID=9cfb2d51-5ff4-4491-b0e5-b386f32c0992&displaylang=en";
                            net40Install.StartInfo.UseShellExecute = true;
                            net40Install.Start();
                        }
                    }
                    else
                        runSetup = (MessageBox.Show("Would you like to attempt installation anyway?", ".NET 4.0 Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
                }
                else
                    runSetup = true;
            }
            catch
            {
                runSetup = (MessageBox.Show("The setup program was not able to determine if Microsoft .NET 4.0 is installed on this computer. The .NET 4.0 framework is required to be installed before you continue installation. Would you like to attempt installation anyway?", ".NET 4.0 Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
            }

            if (runSetup)
                RunSetup("/i");
        }

        private void buttonUninstall_Click(object sender, EventArgs e)
        {
            RunSetup("/x");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RunSetup(string parameters)
        {
            this.WindowState = FormWindowState.Minimized;

            // Install or uninstall openPDC
            Process openPDCInstall = new Process();

            openPDCInstall.StartInfo.FileName = "msiexec.exe";

            if (radioButton64bit.Checked)
                openPDCInstall.StartInfo.Arguments = parameters + " Installers\\openPDCSetup64.msi";
            else
                openPDCInstall.StartInfo.Arguments = parameters + " Installers\\openPDCSetup.msi";

            openPDCInstall.StartInfo.UseShellExecute = false;
            openPDCInstall.StartInfo.CreateNoWindow = true;
            openPDCInstall.Start();
            openPDCInstall.WaitForExit();

            if (openPDCInstall.ExitCode == 0)
            {
                // Run configuration setup utility post installation of openPDC, but not for uninstalls
                if (string.Compare(parameters, "/x", true) != 0)
                {
                    // Read registry installation parameters
                    string installPath, targetBitSize;

                    if (IntPtr.Size == 4 || radioButton64bit.Checked)
                    {
                        // Read values from primary registry location
                        installPath = AddPathSuffix(Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Grid Protection Alliance\openPDC", "InstallPath", "").ToString().Trim());
                        targetBitSize = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Grid Protection Alliance\openPDC", "TargetBitSize", "32bit").ToString().Trim();
                    }
                    else
                    {
                        // Read values from 32-bit virtualized registry location
                        installPath = AddPathSuffix(Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Grid Protection Alliance\openPDC", "InstallPath", "").ToString().Trim());
                        targetBitSize = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Grid Protection Alliance\openPDC", "TargetBitSize", "32bit").ToString().Trim();
                    }

                    try
                    {
                        // Run configuration setup utility
                        Process configSetupUtility = new Process();

                        configSetupUtility.StartInfo.FileName = installPath + "ConfigurationSetupUtility.exe";
                        configSetupUtility.StartInfo.Arguments = "-install -" + targetBitSize;
                        configSetupUtility.StartInfo.UseShellExecute = false;
                        configSetupUtility.Start();
                        configSetupUtility.WaitForExit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Setup program was not able to launch the openPDC Configuration Setup Utility due to an exception. You will need to run this program manually before starting the openPDC.\r\n\r\nError: " + ex.Message, "Configuration Setup Utility Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Install or uninstall PMU Connection Tester
                if (checkBoxConnectionTester.Checked)
                {
                    Process connectionTesterInstall = new Process();

                    connectionTesterInstall.StartInfo.FileName = "msiexec.exe";

                    if (radioButton64bit.Checked)
                        connectionTesterInstall.StartInfo.Arguments = parameters + " Installers\\PMUConnectionTesterSetup64.msi";
                    else
                        connectionTesterInstall.StartInfo.Arguments = parameters + " Installers\\PMUConnectionTesterSetup.msi";

                    connectionTesterInstall.StartInfo.UseShellExecute = false;
                    connectionTesterInstall.StartInfo.CreateNoWindow = true;
                    connectionTesterInstall.Start();
                    connectionTesterInstall.WaitForExit();

                    if (connectionTesterInstall.ExitCode == 0)
                        this.Close();
                    else
                        this.WindowState = FormWindowState.Normal;
                }
                else
                    this.Close();
            }
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Load release notes
            if (tabControlMain.SelectedTab == tabPageReleaseNotes && richTextBoxReleaseNotes.TextLength == 0)
            {
                if (File.Exists("Help\\ReleaseNotes.rtf"))
                    richTextBoxReleaseNotes.LoadFile("Help\\ReleaseNotes.rtf");
                else
                    richTextBoxReleaseNotes.Text = "ERROR: Release notes file not found.";
            }
        }

        private void richTextBoxReleaseNotes_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start("Explorer.exe", e.LinkText);
        }

        /// <summary>
        /// Makes sure path is suffixed with standard <see cref="Path.DirectorySeparatorChar"/>.
        /// </summary>
        /// <param name="filePath">The file path to be suffixed.</param>
        /// <returns>Suffixed path.</returns>
        public static string AddPathSuffix(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                filePath = Path.DirectorySeparatorChar.ToString();
            }
            else
            {
                char suffixChar = filePath[filePath.Length - 1];

                if (suffixChar != Path.DirectorySeparatorChar && suffixChar != Path.AltDirectorySeparatorChar)
                    filePath += Path.DirectorySeparatorChar;
            }

            return filePath;
        }
    }
}
