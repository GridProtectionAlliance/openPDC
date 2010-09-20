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
