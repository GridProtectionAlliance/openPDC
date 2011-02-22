//******************************************************************************************************
//  MainWindow.xaml.cs - Gbtc
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
//  09/07/2010 - Stephen C. Wills
//       Generated original version of source code.
//  02/03/2011 - Mehul Thakkar
//       Set PrinicipalPolicy to WindowsPrincipal so that current windows user can be identified.
//
//******************************************************************************************************

using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using ConfigurationSetupUtility.Screens;
using TVA.Collections;
using TVA.ErrorManagement;
using TVA.Identity;
using TVA.IO;
using TVA.Reflection;

namespace ConfigurationSetupUtility
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region [ Members ]

        // Fields
        private ScreenManager m_screenManager;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            //LogFile logger = null;
            //bool restartingAsCurrentUser = false;

            //try
            //{
            //    logger = new LogFile();
            //    logger.FileName = FilePath.GetAbsolutePath("ErrorLog" + TVA.Security.Cryptography.Random.Byte +".txt");
            //    logger.Open();

            //    AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            //    logger.WriteTimestampedLine("Startup user: " + Thread.CurrentPrincipal.Identity.Name);
            //    logger.WriteTimestampedLine("User is elevated: " + UserAccountControl.IsCurrentProcessElevated);
            //    logger.WriteTimestampedLine("Current command line: " + Environment.CommandLine);

            //    // If an application is being launched from an installer it will have the NT Authority\System identity which
            //    // will not have available user information or desired rights - so we launch us current user instead
            //    if (string.Compare(Thread.CurrentPrincipal.Identity.Name, "NT AUTHORITY\\SYSTEM", true) == 0)
            //    {
            //        restartingAsCurrentUser = true;

            //        string fileName = AssemblyInfo.EntryAssembly.Location;
            //        string arguments = Environment.GetCommandLineArgs().ToDelimitedString(' ');

            //        if (UserAccountControl.IsCurrentProcessElevated)
            //        {
            //            logger.WriteTimestampedLine("Attempting to create process \"" + fileName + "\" as standard user: " + arguments);
            //            logger.Flush();

            //            using (Process process = UserAccountControl.CreateProcessAsStandardUser(fileName, arguments))
            //            {
            //                logger.WriteTimestampedLine("Create process as standard user succeeded with command line: " + Environment.CommandLine);
            //                process.WaitForExit();
            //            }
            //        }
            //        else
            //        {
            //            logger.WriteTimestampedLine("Attempting to create process \"" + fileName + "\" as admin user: " + arguments);
            //            logger.Flush();

            //            using (Process process = UserAccountControl.CreateProcessAsAdmin(fileName, arguments))
            //            {
            //                logger.WriteTimestampedLine("Create process as admin user succeeded with command line: " + Environment.CommandLine);
            //                process.WaitForExit();
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // At worst, we log the error and try continuing on as the current user...
            //    if (logger != null)
            //        logger.WriteTimestampedLine(ErrorLogger.GetExceptionInfo(ex, false));
            //}
            //finally
            //{
            //    if (logger != null)
            //        logger.Dispose();
            //}

            //if (restartingAsCurrentUser)
            //{
            //    // Close application
            //    this.Close();
            //}
            //else
            //{

            // Setup screen manager
            m_screenManager = new ScreenManager(this, new WelcomeScreen());

#if !DEBUG
            this.Topmost = true;
#endif
            //}
        }

        #endregion

        #region [ Methods ]

        // Occurs when the user clicks the "Next" button.
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (m_screenManager.CurrentScreen.NextScreen != null)
                m_screenManager.GoToNextScreen();
            else
                this.Close();
        }

        // Occurs when the user clicks the "Back" button.
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            m_screenManager.GoToPreviousScreen();
        }

        // Occurs when the user clicks the "Cancel" button.
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Occurs when an attempt is made to close the window.
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (m_screenManager.CurrentScreen.NextScreen != null)
            {
                if (!m_screenManager.CurrentScreen.CanCancel)
                    e.Cancel = true;
                else
                {
                    MessageBoxResult result = MessageBox.Show("The setup is not yet complete. Are you sure you want to exit?", this.Title, MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.No)
                        e.Cancel = true;
                }
            }
        }

        #endregion
    }
}
