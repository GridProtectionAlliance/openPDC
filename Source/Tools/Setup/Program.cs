using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace Setup
{
    static class Program
    {
        public static bool MediaPlayerAvailable = false;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                using (AxWMPLib.AxWindowsMediaPlayer mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer())
                {
                    if (Registry.ClassesRoot.OpenSubKey("WMPlayer.OCX") != null)
                        MediaPlayerAvailable = File.Exists("Help\\InstallationVideo.wmv");
                }
            }
            catch
            {
                MediaPlayerAvailable = false;
            }

            Application.Run(new Main());
        }
    }
}
