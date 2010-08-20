//******************************************************************************************************
//  ServiceClient.cs - Gbtc
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
//  08/20/2010 - J. Ritchie Carroll
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.ComponentModel;
using System.Text;
using TVA;
using TVA.Console;
using TVA.Reflection;
using TVA.Services;

namespace TimeSeriesFramework
{
    /// <summary>
    /// Represents a client that can remotely access the time-series framework service host.
    /// </summary>
    public partial class ServiceClient : Component
    {
        #region [ Members ]

        // Fields
        private bool m_telnetActive;
        private ConsoleColor m_originalBgColor;
        private ConsoleColor m_originalFgColor;

        #endregion

        #region [ Constructors ]

        public ServiceClient()
            : base()
        {
            InitializeComponent();

            // Save the color scheme.
            m_originalBgColor = Console.BackgroundColor;
            m_originalFgColor = Console.ForegroundColor;

            // Register event handlers.
            m_clientHelper.AuthenticationFailure += ClientHelper_AuthenticationFailure;
            m_clientHelper.ReceivedServiceUpdate += ClientHelper_ReceivedServiceUpdate;
            m_clientHelper.ReceivedServiceResponse += ClientHelper_ReceivedServiceResponse;
            m_clientHelper.TelnetSessionEstablished += ClientHelper_TelnetSessionEstablished;
            m_clientHelper.TelnetSessionTerminated += ClientHelper_TelnetSessionTerminated;
        }

        #endregion

        #region [ Methods ]

        public void Start(string[] args)
        {
            string userInput = null;
            Arguments arguments = new Arguments(string.Join(" ", args));

            if (arguments.Exists("server") || arguments.Exists("secret"))
            {
                // Override default settings with user provided input. 
                m_clientHelper.PersistSettings = false;
                m_remotingClient.PersistSettings = false;

                if (arguments.Exists("secret"))
                    m_remotingClient.SharedSecret = arguments["secret"];

                if (arguments.Exists("server"))
                    m_remotingClient.ConnectionString = string.Format("Server={0}", arguments["server"]);
            }

            // Connect to service and send commands. 
            m_clientHelper.Connect();
            while (m_clientHelper.Enabled && string.Compare(userInput, "Exit", true) != 0)
            {
                // Wait for a command from the user. 
                userInput = Console.ReadLine();
                // Write a blank line to the console.
                Console.WriteLine();

                if (!string.IsNullOrEmpty(userInput))
                {
                    // The user typed in a command and didn't just hit <ENTER>. 
                    switch (userInput.ToUpper())
                    {
                        case "CLS":
                            // User wants to clear the console window. 
                            Console.Clear();
                            break;
                        case "EXIT":
                            // User wants to exit the telnet session with the service. 
                            if (m_telnetActive)
                            {
                                userInput = string.Empty;
                                m_clientHelper.SendRequest("Telnet -disconnect");
                            }
                            break;
                        default:
                            // User wants to send a request to the service. 
                            m_clientHelper.SendRequest(userInput);
                            if (string.Compare(userInput, "Help", true) == 0)
                                DisplayHelp();

                            break;
                    }
                }
            }
        }

        private void DisplayHelp()
        {
            StringBuilder help = new StringBuilder();

            help.AppendFormat("Commands supported by {0}:", AssemblyInfo.EntryAssembly.Name);
            help.AppendLine();
            help.AppendLine();
            help.Append("Command".PadRight(20));
            help.Append(" ");
            help.Append("Description".PadRight(55));
            help.AppendLine();
            help.Append(new string('-', 20));
            help.Append(" ");
            help.Append(new string('-', 55));
            help.AppendLine();
            help.Append("Cls".PadRight(20));
            help.Append(" ");
            help.Append("Clears this console screen".PadRight(55));
            help.AppendLine();
            help.Append("Exit".PadRight(20));
            help.Append(" ");
            help.Append("Exits this console screen".PadRight(55));
            help.AppendLine();
            help.AppendLine();
            help.AppendLine();

            Console.Write(help.ToString());
        }

        private void ClientHelper_AuthenticationFailure(object sender, CancelEventArgs e)
        {
            // Prompt for credentials.
            StringBuilder prompt = new StringBuilder();
            prompt.AppendLine();
            prompt.AppendLine();
            prompt.Append("Connection to the service was rejected due to authentication failure. \r\n");
            prompt.Append("Enter the credentials to be used for authentication with the service.");
            prompt.AppendLine();
            prompt.AppendLine();
            Console.Write(prompt.ToString());

            // Capture the username.
            Console.Write("Enter username: ");
            m_clientHelper.Username = Console.ReadLine();

            // Capture the password.
            ConsoleKeyInfo key;
            Console.Write("Enter password: ");
            while ((key = Console.ReadKey(true)).KeyChar != '\r')
            {
                m_clientHelper.Password += key.KeyChar;
            }

            // Re-attempt connection with new credentials.
            e.Cancel = false;
            Console.WriteLine();
            Console.WriteLine();
        }

        private void ClientHelper_ReceivedServiceUpdate(object sender, EventArgs<UpdateType, string> e)
        {
            // Output status updates from the service to the console window.
            switch (e.Argument1)
            {
                case UpdateType.Alarm:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case UpdateType.Information:
                    Console.ForegroundColor = m_originalFgColor;
                    break;
                case UpdateType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }

            Console.Write(e.Argument2);
            Console.ForegroundColor = m_originalFgColor;
        }

        private void ClientHelper_ReceivedServiceResponse(object sender, EventArgs<ServiceResponse> e)
        {
            string response = e.Argument.Type;
            string message = e.Argument.Message;
            
            // TODO: Move this code to openPDC specific implementation...
            ///List<object> attachments = e.Argument.Attachments;

            //// Handle any special attachments coming in from service
            //if (attachments != null)
            //{
            //    foreach (object attachment in attachments)
            //    {
            //        if (attachment is ConfigurationErrorFrame)
            //        {
            //            Console.WriteLine("Received configuration error frame, invocation request for device configuration has failed. See common phasor services response for reason.\r\n");
            //        }
            //        else if (attachment is IConfigurationFrame)
            //        {
            //            // Attachment is a configuration frame, serialize it to XML and open it in a browser
            //            IConfigurationFrame configurationFrame = attachment as IConfigurationFrame;
            //            string fileName = string.Format("{0}\\DownloadedConfiguration-ID[{1}].xml", FilePath.GetAbsolutePath(""), configurationFrame.IDCode);
            //            FileStream configFile = File.Create(fileName);
            //            SoapFormatter xmlSerializer = new SoapFormatter();

            //            xmlSerializer.AssemblyFormat = FormatterAssemblyStyle.Simple;
            //            xmlSerializer.TypeFormat = FormatterTypeStyle.TypesWhenNeeded;

            //            try 
            //            {
            //                // Attempt to serialize configuration frame as XML
            //                xmlSerializer.Serialize(configFile, configurationFrame);
            //            }
            //            catch (Exception ex)
            //            {                    		
            //                byte[] errorMessage = Encoding.UTF8.GetBytes(ex.Message);
            //                configFile.Write(errorMessage, 0, errorMessage.Length);
            //                Console.Write("Failed to serialize configuration frame: {0}", ex.Message);
            //            }

            //            configFile.Close();

            //            // Open captured XML sample file in explorer...
            //            Process.Start("explorer.exe", fileName);
            //        }
            //    }
            //}

            // Handle response message, if any
            if (!string.IsNullOrEmpty(response))
            {
                // Reponse types are formatted as "Command:Success" or "Command:Failure"
                string[] parts = response.Split(':');
                string action;
                bool success;

                if (parts.Length > 1)
                {
                    action = parts[0].Trim().ToTitleCase();
                    success = (string.Compare(parts[1].Trim(), "Success", true) == 0);
                }
                else
                {
                    action = response;
                    success = true;
                }

                if (success)
                {
                    if (string.IsNullOrEmpty(message))
                        Console.Write(string.Format("{0} command processed successfully.\r\n\r\n", action));
                    else
                        Console.Write(string.Format("{0}\r\n\r\n", message));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    if (string.IsNullOrEmpty(message))
                        Console.Write(string.Format("{0} failure.\r\n\r\n", action));
                    else
                        Console.Write(string.Format("{0} failure: {1}\r\n\r\n", action, message));

                    Console.ForegroundColor = m_originalFgColor;
                }
            }            
        }

        private void ClientHelper_TelnetSessionEstablished(object sender, EventArgs e)
        {
            // Change the console color scheme to indicate active telnet session.
            m_telnetActive = true;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
        }

        private void ClientHelper_TelnetSessionTerminated(object sender, EventArgs e)
        {
            // Revert to original color scheme to indicate end of telnet session.
            m_telnetActive = false;
            Console.BackgroundColor = m_originalBgColor;
            Console.ForegroundColor = m_originalFgColor;
            Console.Clear();
        }

        #endregion
    }
}