//*******************************************************************************************************
//  ServiceClient.cs
//  Copyright © 2009 - TVA, all rights reserved - Gbtc
//
//  Build Environment: C#, Visual Studio 2008
//  Primary Developer: James R. Carroll
//      Office: PSO TRAN & REL, CHATTANOOGA - MR BK-C
//       Phone: 423/751-4165
//       Email: jrcarrol@tva.gov
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  05/04/2009 - James R. Carroll
//       Generated original version of source code.
//
//*******************************************************************************************************

using System;
using System.ComponentModel;
using System.Text;
using TVA;
using TVA.Console;
using TVA.Reflection;
using TVA.Security.Cryptography;
using TVA.Services;

namespace openPDC
{
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
            else
            {
                // Actual passphrase value is decrypted and updated at runtime so that value is obfuscated and not stored as a directly readable string in the executable or configuration file
                m_remotingClient.SharedSecret = "O5ztzVTI5LojZEMONpq/8fscA0ClC79/OBbj8MwKZTaMmRjCBDUSjE5t3Npl1zBAQpo6qlUD6Jz4hpfywQBBIkqzy1DWvB9fPjgrb1sZkqUod9XsrCaMlM5osmdvprxOMCw7ZLd8pXbRuJ+RThcOgH7JXap9Xo2mt0zrmhOFhZT41GtlPVjlCGgKegSlaX9snnVMackXyW5I4Uaj+mI4YHaojZBdQco9glyQogdCywlTQSldCyos8Zl8pgVfT/jkqcixbML4NWvZVgZ6XIjAHcPp2yL95MA8M8KpjH1cZoc=".Decrypt("4PM3kCB137N62J31h057N8CwydTFLh58B218k0dr35n42qw3G2", CipherStrength.Level6);
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
            // Prompt for authentication method.
            StringBuilder prompt = new StringBuilder();
            prompt.Append("Remote connection was has rejected due to authentication failure. Please ");
            prompt.Append("select from one of the options below to re-authenticate the remote connection:");
            prompt.AppendLine();
            prompt.AppendLine();
            prompt.Append("[0] Abort (no retry)");
            prompt.AppendLine();
            prompt.Append("[1] NTLM Authentication");
            prompt.AppendLine();
            prompt.Append("[2] Kerberos Authentication");
            prompt.AppendLine();
            prompt.AppendLine();
            prompt.Append("Selection: ");
            Console.Write(prompt.ToString());

            // Capture authentication method selection.
            int selection;
            int.TryParse(Console.ReadLine(), out selection);

            Console.WriteLine();
            if (selection == 1)         // NTLM Authentication
            {
                // Capture the username.
                string username = "";
                Console.Write("Enter username: ");
                username = Console.ReadLine();

                // Capture the password.
                string password = "";
                ConsoleKeyInfo key;
                Console.Write("Enter password: ");
                while ((key = Console.ReadKey(true)).KeyChar != '\r')
                {
                    password += key.KeyChar;
                }

                // Update authentication parameters.
                e.Cancel = false;
                m_clientHelper.AuthenticationMethod = IdentityToken.Ntlm;
                m_clientHelper.AuthenticationInput = username + ":" + password;
            }
            else if (selection == 2)    // Kerberos Authentication
            {
                // Update authentication parameters.
                e.Cancel = false;
                Console.Write("Enter target principal: ");
                m_clientHelper.AuthenticationMethod = IdentityToken.Kerberos;
                m_clientHelper.AuthenticationInput = Console.ReadLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private void ClientHelper_ReceivedServiceUpdate(object sender, EventArgs<string> e)
        {
            // Output status updates from the service to the console window.
            Console.Write(e.Argument);
        }

        private void ClientHelper_ReceivedServiceResponse(object sender, EventArgs<ServiceResponse> e)
        {
            string response = e.Argument.Type;
            string message = e.Argument.Message;

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
                    if (string.IsNullOrEmpty(message))
                        Console.Write(string.Format("{0} failure.\r\n\r\n", action));
                    else
                        Console.Write(string.Format("{0} failure: {1}\r\n\r\n", action, message));
                }
            }            
        }

        private void ClientHelper_TelnetSessionEstablished(object sender, EventArgs e)
        {
            // Save the current state.
            m_telnetActive = true;
            m_originalBgColor = Console.BackgroundColor;
            m_originalFgColor = Console.ForegroundColor;

            // Change the console color scheme to indicate active telnet session.
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
        }

        private void ClientHelper_TelnetSessionTerminated(object sender, EventArgs e)
        {
            // Revert to saved state.
            m_telnetActive = false;
            Console.BackgroundColor = m_originalBgColor;
            Console.ForegroundColor = m_originalFgColor;
            Console.Clear();
        }

        #endregion
    }
}