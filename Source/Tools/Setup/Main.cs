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
using System.ServiceProcess;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Setup
{
    public partial class Main : Form
    {
        // openPDC product code, as defined in the setup packages
        private const string ProductCode = "{493D6CED-50C6-4CF5-93A3-306C364F10A3}";

        private enum SetupType
        {
            Install,
            Uninstall
        }

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                Version version = Assembly.GetEntryAssembly().GetName().Version;
                labelVersion.Text = string.Format(labelVersion.Text, version.Major, version.Minor, version.Build);
            }
            catch
            {
                labelVersion.Visible = false;
            }
        }

        private void buttonInstall_Click(object sender, EventArgs e)
        {
            bool runSetup = false;

            // Verify that .NET 4.5 is installed
            try
            {
                RegistryKey net45 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\.NETFramework\\v4.0.30319\\SKUs\\.NETFramework,Version=v4.5");

                if (net45 == null)
                {
                    if (MessageBox.Show("Microsoft .NET 4.5 does not appear to be installed on this computer. The .NET 4.5 framework is required to be installed before you continue installation. Would you like to install it now?", ".NET 4.5 Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Process net45Install;
                        const string netInstallPath = "Installers\\dotnetfx45_full_x86_x64.exe";

                        if (File.Exists(netInstallPath))
                        {
                            try
                            {
                                // Attempt to launch .NET 4.5 installer...
                                net45Install = new Process();
                                net45Install.StartInfo.FileName = netInstallPath;
                                net45Install.StartInfo.UseShellExecute = false;
                                net45Install.Start();
                            }
                            catch
                            {
                                // At a minimum open folder containing .NET 4.5 installer since its available to run...
                                net45Install = new Process();
                                net45Install.StartInfo.FileName = Directory.GetCurrentDirectory() + "\\Installers\\";
                                net45Install.StartInfo.UseShellExecute = true;
                                net45Install.Start();
                            }
                        }
                        else
                        {
                            net45Install = new Process();
                            net45Install.StartInfo.FileName = "http://www.microsoft.com/en-us/download/details.aspx?id=30653";
                            net45Install.StartInfo.UseShellExecute = true;
                            net45Install.Start();
                        }
                    }
                    else
                        runSetup = (MessageBox.Show("Would you like to attempt installation anyway?", ".NET 4.5 Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
                }
                else
                    runSetup = true;
            }
            catch
            {
                runSetup = (MessageBox.Show("The setup program was not able to determine if Microsoft .NET 4.5 is installed on this computer. The .NET 4.5 framework is required to be installed before you continue installation. Would you like to attempt installation anyway?", ".NET 4.5 Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
            }

            // See if an existing version is currently installed
            RegistryKey openPDCInstallKey;

            openPDCInstallKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\" + ProductCode);

            // If key wasn't found, test for 32-bit virtualized location
            if (openPDCInstallKey == null)
                openPDCInstallKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\" + ProductCode);

            if (openPDCInstallKey != null)
            {
                if (MessageBox.Show("An existing version of the openPDC is installed on this computer. Would you like to remove the existing version?\r\n\r\nCurrent configuration will be preserved.", "Previous Version Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    runSetup = RunSetup(SetupType.Uninstall, false);
                else
                    runSetup = (MessageBox.Show("Would you like to attempt installation anyway?", "Previous Version Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);

                openPDCInstallKey.Close();
            }

            if (runSetup)
                RunSetup(SetupType.Install, true);
        }

        private void buttonUninstall_Click(object sender, EventArgs e)
        {
            RunSetup(SetupType.Uninstall, false);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool RunSetup(SetupType type, bool closeOnSuccess)
        {
            this.WindowState = FormWindowState.Minimized;

            // Install or uninstall openPDC
            Process openPDCInstall = new Process();

            openPDCInstall.StartInfo.FileName = "msiexec.exe";

            if (type == SetupType.Uninstall)
            {
                // Attempt to shutdown processes before uninstall
                AttemptToStopKeyProcesses();

                // Uninstall any version of the openPDC
                openPDCInstall.StartInfo.Arguments = "/x " + ProductCode + " /qr";
            }
            else
            {
                // Install current version of the openPDC
                openPDCInstall.StartInfo.Arguments = "/i Installers\\openPDCSetup.msi";
            }

            openPDCInstall.StartInfo.UseShellExecute = false;
            openPDCInstall.StartInfo.CreateNoWindow = true;
            openPDCInstall.Start();
            openPDCInstall.WaitForExit();

            if (openPDCInstall.ExitCode == 0)
            {
                // Run configuration setup utility post installation of openPDC, but not for uninstalls
                if (type == SetupType.Install)
                {
                    // Read registry installation parameters
                    string installPath, targetBitSize, configurationSetupUtility;

                    // Read values from primary registry location
                    installPath = AddPathSuffix(Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Grid Protection Alliance\openPDC", "InstallPath", "").ToString().Trim());
                    targetBitSize = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Grid Protection Alliance\openPDC", "TargetBitSize", "64bit").ToString().Trim();
                    configurationSetupUtility = installPath + "ConfigurationSetupUtility.exe";

                    // Note that if user only installs tools, i.e., skips openPDC and Manager, the CSU will not be installed
                    if (File.Exists(configurationSetupUtility))
                    {
                        try
                        {
                            // Run configuration setup utility
                            Process configSetupUtility = new Process();

                            configSetupUtility.StartInfo.FileName = configurationSetupUtility;
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
                }

                // Install or uninstall PMU Connection Tester
                if (checkBoxConnectionTester.Checked)
                {
                    Process connectionTesterInstall = new Process();

                    connectionTesterInstall.StartInfo.FileName = "msiexec.exe";

                    if (type == SetupType.Uninstall)
                    {
                        // Uninstall any version of the PMU Connection Tester
                        connectionTesterInstall.StartInfo.Arguments = "/x Installers\\PMUConnectionTesterSetup64.msi /passive";
                    }
                    else
                    {
                        // Install current version of the PMU Connection Tester
                        connectionTesterInstall.StartInfo.Arguments = "/i Installers\\PMUConnectionTesterSetup64.msi";
                    }

                    connectionTesterInstall.StartInfo.UseShellExecute = false;
                    connectionTesterInstall.StartInfo.CreateNoWindow = true;
                    connectionTesterInstall.Start();
                    connectionTesterInstall.WaitForExit();

                    if (closeOnSuccess)
                        this.Close();
                    else
                        this.WindowState = FormWindowState.Normal;

                    return true;
                }

                if (closeOnSuccess)
                    this.Close();
                else
                    this.WindowState = FormWindowState.Normal;

                return true;
            }

            this.WindowState = FormWindowState.Normal;
            return false;
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
        private string AddPathSuffix(string filePath)
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

        // Attempt to stop key processes/services before uninstall
        private void AttemptToStopKeyProcesses()
        {
            try
            {
                Process[] instances = Process.GetProcessesByName("openPDCManager");

                if (instances.Length > 0)
                {
                    // Terminate all instances of openPDC Manager running on the local computer
                    foreach (Process process in instances)
                    {
                        process.Kill();
                    }
                }
            }
            catch
            {
            }

            // Attempt to access service controller for the openPDC
            ServiceController openPdcServiceController = null;

            try
            {
                foreach (ServiceController service in ServiceController.GetServices())
                {
                    if (string.Compare(service.ServiceName, "openPDC", true) == 0)
                    {
                        openPdcServiceController = service;
                        break;
                    }
                }
            }
            catch
            {
            }

            if (openPdcServiceController != null)
            {
                try
                {
                    if (openPdcServiceController.Status == ServiceControllerStatus.Running)
                    {
                        openPdcServiceController.Stop();

                        // Can't wait forever for service to stop, so we time-out after 20 seconds
                        openPdcServiceController.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(20.0D));
                    }
                }
                catch
                {
                }
            }

            // If the openPDC service failed to stop or it is installed as stand-alone debug application, we try to stop any remaining running instances
            try
            {
                Process[] instances = Process.GetProcessesByName("openPDC");

                if (instances.Length > 0)
                {
                    // Terminate all instances of openPDC running on the local computer
                    foreach (Process process in instances)
                    {
                        process.Kill();
                    }
                }
            }
            catch
            {
            }

            // If uninstalling the PMU Connection Tester, we try to stop any running instances
            if (checkBoxConnectionTester.Checked)
            {
                try
                {
                    Process[] instances = Process.GetProcessesByName("PMUConnectionTester");

                    if (instances.Length > 0)
                    {
                        // Terminate all instances of PMU Connection Tester running on the local computer
                        foreach (Process process in instances)
                        {
                            process.Kill();
                        }
                    }
                }
                catch
                {
                }
            }
        }
    }
}
