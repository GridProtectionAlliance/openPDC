//******************************************************************************************************
//  IsolatedStorageManager.cs - Gbtc
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
//  09/01/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using System;
using System.Text;
using System.Net;

namespace openPDCManager.Utilities
{
    public static class IsolatedStorageManager
    {
        static IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly();
        
        public static void SaveInputMonitoringPoints(List<string> pointList)
        {
            using (StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream("InputMonitoringPoints", FileMode.Create, storage)))
            {
                StringBuilder sb = new StringBuilder();                
                foreach (string value in pointList)
                    sb.Append(value + ";");

                writer.Write(sb.ToString());            
            }         
        }

        public static List<string> ReadInputMonitoringPoints()
        {
            List<string> pointList = new List<string>();
            using (StreamReader reader = new StreamReader(new IsolatedStorageFileStream("InputMonitoringPoints", FileMode.OpenOrCreate, storage)))
            {
                if (reader != null)
                {
                    string result = reader.ReadToEnd();
                    string[] points = result.Split(new char[] { ';' });
                    foreach (string value in points)
                    {
                        if (!string.IsNullOrEmpty(value))
                            pointList.Add(value);
                    }
                }
            }

            return pointList;
        }
                
        public static void SaveIntoIsolatedStorage(string storageName, object storageValue)
        {
            using (StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream(storageName, FileMode.Create, storage)))
                writer.Write(storageValue.ToString());
        }

        public static object ReadFromIsolatedStorage(string storageName)
        {
            using (StreamReader reader = new StreamReader(new IsolatedStorageFileStream(storageName, FileMode.OpenOrCreate, storage)))
            {
                if (reader != null)
                {
                    return reader.ReadToEnd();
                }
                else
                    return null;
            }
        }

        public static void SetDefaultStorage(bool overWrite)
        {
            if (!storage.FileExists("NumberOfMessages") || overWrite)
                SaveIntoIsolatedStorage("NumberOfMessages", "75");

            if (!storage.FileExists("ForceIPv4") || overWrite)
            {
                //if (Dns.GetHostEntry(IPAddress.Loopback).AddressList[0].AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                //    SaveIntoIsolatedStorage("ForceIPv4", "false");
                //else
                    SaveIntoIsolatedStorage("ForceIPv4", "true");
            }
            
            if (!storage.FileExists("InputMonitoringPoints") || overWrite)
                SaveIntoIsolatedStorage("InputMonitoringPoints", string.Empty);

            if (!storage.FileExists("NumberOfDataPointsToPlot") || overWrite)
                SaveIntoIsolatedStorage("NumberOfDataPointsToPlot", 150);

            if (!storage.FileExists("DataResolution") || overWrite)
                SaveIntoIsolatedStorage("DataResolution", 30);

            if (!storage.FileExists("LagTime") || overWrite)
                SaveIntoIsolatedStorage("LagTime", 3);

            if (!storage.FileExists("LeadTime") || overWrite)
                SaveIntoIsolatedStorage("LeadTime", 1);

            if (!storage.FileExists("UseLocalClockAsRealtime") || overWrite)
                SaveIntoIsolatedStorage("UseLocalClockAsRealtime", "false");

            if (!storage.FileExists("IgnoreBadTimestamps") || overWrite)
                SaveIntoIsolatedStorage("IgnoreBadTimestamps", "false");

            if (!storage.FileExists("ChartRefreshInterval") || overWrite)
                SaveIntoIsolatedStorage("ChartRefreshInterval", 250);

            if (!storage.FileExists("StatisticsDataRefreshInterval") || overWrite)
                SaveIntoIsolatedStorage("StatisticsDataRefreshInterval", 10);

            if (!storage.FileExists("MeasurementsDataRefreshInterval") || overWrite)
                SaveIntoIsolatedStorage("MeasurementsDataRefreshInterval", 10);

            if (!storage.FileExists("DisplayXAxis") || overWrite)
                SaveIntoIsolatedStorage("DisplayXAxis", "false");

            if (!storage.FileExists("DisplayFrequencyYAxis") || overWrite)
                SaveIntoIsolatedStorage("DisplayFrequencyYAxis", "true");

            if (!storage.FileExists("DisplayPhaseAngleYAxis") || overWrite)
                SaveIntoIsolatedStorage("DisplayPhaseAngleYAxis", "false");

            if (!storage.FileExists("DisplayVoltageYAxis") || overWrite)
                SaveIntoIsolatedStorage("DisplayVoltageYAxis", "false");

            if (!storage.FileExists("DisplayCurrentYAxis") || overWrite)
                SaveIntoIsolatedStorage("DisplayCurrentYAxis", "false");

            if (!storage.FileExists("FrequencyRangeMin") || overWrite)
                SaveIntoIsolatedStorage("FrequencyRangeMin", 59.95);

            if (!storage.FileExists("FrequencyRangeMax") || overWrite)
                SaveIntoIsolatedStorage("FrequencyRangeMax", 60.05);

            if (!storage.FileExists("DisplayLegend") || overWrite)
                SaveIntoIsolatedStorage("DisplayLegend", "true");
        }
    }
}
