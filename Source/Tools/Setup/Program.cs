using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace Setup
{
    static class Program
    {
        public static bool MediaPlayerAvailable;

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
