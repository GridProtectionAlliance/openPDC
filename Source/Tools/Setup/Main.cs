using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;
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
                                // Attempt to launch .NET 4.0 installer... This requires elevated privledges, so this may fail
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
    }
}
