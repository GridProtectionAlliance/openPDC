//******************************************************************************************************
//  App.xaml.cs - Gbtc
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
//  09/28/2009 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Text;
using System.Windows;
using Microsoft.Maps.MapControl;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;

namespace openPDCManager
{
    public partial class App : Application
	{
		#region [ Properties ]

		public string NodeValue { get; set; }
		public string NodeName { get; set; }
		public string TimeSeriesDataServiceUrl { get; set; }
		public string RemoteStatusServiceUrl { get; set; }
        public string RealTimeStatisticServiceUrl { get; set; }
		public ApplicationIdCredentialsProvider Credentials { get; set; }

		#endregion

		#region [ Constructor ]

		public App()
        {
            this.Startup += this.Application_Startup;
            this.Exit += this.Application_Exit;
            this.UnhandledException += this.Application_UnhandledException;
            
            InitializeComponent();
		}

		#endregion

		#region [ Application Event Handlers ]

		private void Application_Startup(object sender, StartupEventArgs e)
        {
            if ((e.InitParams != null) && (e.InitParams.ContainsKey("BaseServiceUrl")))
                Resources.Add("BaseServiceUrl", e.InitParams["BaseServiceUrl"]);

			ApplicationIdCredentialsProvider credentialsProvider = new ApplicationIdCredentialsProvider();
			if ((e.InitParams != null) && (e.InitParams.ContainsKey("BingMapsKey")))
				credentialsProvider.ApplicationId = e.InitParams["BingMapsKey"];

			this.Credentials = credentialsProvider;
			this.RootVisual = new MasterLayoutControl();

			//Set default system settings if no settings exist.
			ProxyClient.SetDefaultSystemSettings(false);
        }
        
		private void Application_Exit(object sender, EventArgs e)
        {

        }
        
		private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
			//// If the app is running outside of the debugger then report the exception using
			//// the browser's exception mechanism. On IE this will display it a yellow alert 
			//// icon in the status bar and Firefox will display a script error.
			//if (!System.Diagnostics.Debugger.IsAttached)
			//{

			//    // NOTE: This will allow the application to continue running after an exception has been thrown
			//    // but not handled. 
			//    // For production applications this error handling should be replaced with something that will 
			//    // report the error to the website and stop the application.
			//    e.Handled = true;
			//    Deployment.Current.Dispatcher.BeginInvoke(delegate { ReportErrorToDOM(e); });
			//}

			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Exception Type: " + e.GetType().ToString());
			sb.AppendLine("Error Message: " + e.ExceptionObject.Message);
			sb.AppendLine("Stack Trace: " + e.ExceptionObject.StackTrace);

			SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Application Error Occured", SystemMessage = sb.ToString(), UserMessageType = MessageType.Error },
						ButtonType.OkOnly);
			sm.ShowPopup();
		}

		#endregion

		#region [ Methods ]

		private void ReportErrorToDOM(ApplicationUnhandledExceptionEventArgs e)
        {
            try
            {
                string errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
                errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

                System.Windows.Browser.HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight Application " + errorMsg + "\");");
            }
            catch (Exception)
            {
            }
		}

		#endregion
	}
}