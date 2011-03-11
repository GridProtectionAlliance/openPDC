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
//  08/31/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//  09/19/2010 - J. Ritchie Carroll
//       Added unhandled exception logger with dialog for better end user problem diagnosis.
//  02/14/2011 - J. Ritchie Carroll
//       Set the startup principal policy to windows principal.
//
//******************************************************************************************************

using System;
using System.Windows;
using openPDCManager.Data.ServiceCommunication;
using TVA.ErrorManagement;
using System.Security.Principal;

namespace openPDCManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region [ Members ]

        private ErrorLogger m_errorLogger;
        private Func<string> m_defaultErrorText;

        #endregion

        #region [ Constructors ]

        public App()
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            m_errorLogger = new ErrorLogger();
            m_defaultErrorText = m_errorLogger.ErrorTextMethod;
            m_errorLogger.ErrorTextMethod = ErrorText;
            m_errorLogger.ExitOnUnhandledException = false;
            m_errorLogger.HandleUnhandledException = true;
            m_errorLogger.LogToEmail = false;
            m_errorLogger.LogToEventLog = true;
            m_errorLogger.LogToFile = true;
            m_errorLogger.LogToScreenshot = true;
            m_errorLogger.LogToUI = true;
            m_errorLogger.Initialize();            
        }

        #endregion

        #region [ Properties ]

        public string NodeValue { get; set; }
        public string NodeName { get; set; }
        public string TimeSeriesDataServiceUrl { get; set; }
        public string RemoteStatusServiceUrl { get; set; }
        public string RealTimeStatisticServiceUrl { get; set; }        
        //public ApplicationIdCredentialsProvider Credentials { get; set; }
        public WindowsServiceClient ServiceClient { get; set; }        
        public IPrincipal Principal { get; set; }
       
        #endregion

        #region [ Methods ]

        private string ErrorText()
        {
            string errorMessage = m_defaultErrorText();
            Exception ex = m_errorLogger.LastException;

            if (ex != null)
            {
                if (string.Compare(ex.Message, "UnhandledException", true) == 0 && ex.InnerException != null)
                    ex = ex.InnerException;

                errorMessage = string.Format("{0}\r\n\r\nError details: {1}", errorMessage, ex.Message);
            }

            return errorMessage;
        }

        #endregion
    }

}
