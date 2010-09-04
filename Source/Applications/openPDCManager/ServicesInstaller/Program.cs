//******************************************************************************************************
//  Program.cs - Gbtc
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
//  09/03/2010 - Stephen C. Wills
//       Generated original version of source code.
//
//******************************************************************************************************

using System.Diagnostics;
using System.IO;
using ServicesInstaller.Properties;

namespace ServicesInstaller
{
    public class Program
    {
        public static void Main()
        {
            string tempPath = Path.GetTempPath();
            string exeFilePath = tempPath + "setup.exe";
            string msiFilePath = tempPath + "openPDCManagerServicesSetup.msi";
            BinaryWriter exeWriter = null;
            BinaryWriter msiWriter = null;
            Process setupProcess = null;

            try
            {
                exeWriter = new BinaryWriter(new FileStream(exeFilePath, FileMode.Create, FileAccess.Write));
                exeWriter.Write(Resources.setup);
                exeWriter.Close();

                msiWriter = new BinaryWriter(new FileStream(msiFilePath, FileMode.Create, FileAccess.Write));
                msiWriter.Write(Resources.openPDCManagerServicesSetup);
                msiWriter.Close();

                setupProcess = new Process();
                setupProcess.StartInfo.FileName = exeFilePath;
                setupProcess.StartInfo.UseShellExecute = false;
                setupProcess.StartInfo.CreateNoWindow = true;
                setupProcess.Start();
            }
            finally
            {
                if (exeWriter != null)
                    exeWriter.Close();

                if (msiWriter != null)
                    msiWriter.Close();

                if (setupProcess != null)
                    setupProcess.Close();
            }
        }
    }
}
