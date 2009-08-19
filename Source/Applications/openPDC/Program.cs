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
//  05/14/2009 - James R. Carroll
//       Generated original version of source code.
//
//*******************************************************************************************************

//#define RunAsService

#if RunAsService
    using System.ServiceProcess;
#else
    using System.Windows.Forms;
#endif

namespace openPDC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
#if RunAsService
            // Run as Windows Service.
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new ServiceHost() 
            };
            ServiceBase.Run(ServicesToRun);
#else
            // Run as Windows Application.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DebugHost());
#endif
        }
    }
}
