//*******************************************************************************************************
//  Program.cs
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

namespace openPDC
{
    class Program
    {
        static ServiceClient m_serviceClient;

        static void Main(string[] args)
        {
            // Enable console events.
            TVA.Console.Events.ConsoleClosing += OnConsoleClosing;
            TVA.Console.Events.EnableRaisingEvents();

            // Start the client component.
            m_serviceClient = new ServiceClient();
            m_serviceClient.Start(args);
            m_serviceClient.Dispose();
        }

        static void OnConsoleClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Dispose the client component.
            m_serviceClient.Dispose();
        }
    }
}
