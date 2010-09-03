//******************************************************************************************************
//  ProxyClient.cs - Gbtc
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
//  07/08/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Windows;
using System.Windows.Browser;
using openPDCManager.LivePhasorDataServiceProxy;
using openPDCManager.PhasorDataServiceProxy;

namespace openPDCManager.Utilities
{
    public static class ProxyClient
    {
        #region [ Methods ]
        
        public static PhasorDataServiceClient GetPhasorDataServiceProxyClient()
        {
            string baseServiceUrl = Application.Current.Resources["BaseServiceUrl"].ToString();
            EndpointAddress address = new EndpointAddress(baseServiceUrl + "Service/PhasorDataService.svc");
            CustomBinding binding;

            if (HtmlPage.Document.DocumentUri.Scheme.ToLower().StartsWith("https"))
            {
                HttpsTransportBindingElement httpsTransportBindingElement = new HttpsTransportBindingElement();
                httpsTransportBindingElement.MaxReceivedMessageSize = int.MaxValue;		// 65536 * 50;
                binding = new CustomBinding(
                                    new BinaryMessageEncodingBindingElement(),
                                    httpsTransportBindingElement
                                    );
            }
            else
            {
                HttpTransportBindingElement httpTransportBindingElement = new HttpTransportBindingElement();
                httpTransportBindingElement.MaxReceivedMessageSize = int.MaxValue;	// 65536 * 50;
                binding = new CustomBinding(
                                    new BinaryMessageEncodingBindingElement(),
                                    httpTransportBindingElement
                                    );
            }

            binding.CloseTimeout = new TimeSpan(0, 20, 0);
            binding.OpenTimeout = new TimeSpan(0, 20, 0);
            binding.ReceiveTimeout = new TimeSpan(0, 20, 0);
            binding.SendTimeout = new TimeSpan(0, 20, 0);

            return new PhasorDataServiceClient(binding, address);
        }

        public static DuplexServiceClient GetDuplexServiceProxyClient()
        {
            string baseServiceUrl = Application.Current.Resources["BaseServiceUrl"].ToString();
            EndpointAddress address = new EndpointAddress(baseServiceUrl + "DuplexService/PhasorDataDuplexService.svc");
            CustomBinding binding;
            if (HtmlPage.Document.DocumentUri.Scheme.ToLower().StartsWith("https"))
            {
                HttpsTransportBindingElement httpsTransportBindingElement = new HttpsTransportBindingElement();
                httpsTransportBindingElement.MaxReceivedMessageSize = int.MaxValue;
                binding = new CustomBinding(
                                    new PollingDuplexBindingElement(),
                                    new BinaryMessageEncodingBindingElement(),
                                    httpsTransportBindingElement
                                    );
            }
            else
            {
                HttpTransportBindingElement httpTransportBindingElement = new HttpTransportBindingElement();
                httpTransportBindingElement.MaxReceivedMessageSize = int.MaxValue;	// 65536 * 50;
                binding = new CustomBinding(
                                    new PollingDuplexBindingElement(),
                                    new BinaryMessageEncodingBindingElement(),
                                    httpTransportBindingElement
                                    );
            }

            binding.CloseTimeout = new TimeSpan(0, 20, 0);
            binding.OpenTimeout = new TimeSpan(0, 20, 0);
            binding.ReceiveTimeout = new TimeSpan(0, 20, 0);
            binding.SendTimeout = new TimeSpan(0, 20, 0);

            return new DuplexServiceClient(binding, address);
        }

        public static void SetDefaultSystemSettings(bool overWrite)
        {
            //Check if system settings are available in the isolated storage. If not, then assign them default values.
            if (!IsolatedStorageManager.Contains("DefaultHeight") || overWrite)
                IsolatedStorageManager.SaveIntoIsolatedStorage("DefaultHeight", 900);

            if (!IsolatedStorageManager.Contains("DefaultWidth") || overWrite)
                IsolatedStorageManager.SaveIntoIsolatedStorage("DefaultWidth", 1200);

            if (!IsolatedStorageManager.Contains("MinimumHeight") || overWrite)
                IsolatedStorageManager.SaveIntoIsolatedStorage("MinimumHeight", 600);

            if (!IsolatedStorageManager.Contains("MinimumWidth") || overWrite)
                IsolatedStorageManager.SaveIntoIsolatedStorage("MinimumWidth", 800);

            if (!IsolatedStorageManager.Contains("ResizeWithBrowser") || overWrite)
                IsolatedStorageManager.SaveIntoIsolatedStorage("ResizeWithBrowser", true);

            if (!IsolatedStorageManager.Contains("MaintainAspectRatio") || overWrite)
                IsolatedStorageManager.SaveIntoIsolatedStorage("MaintainAspectRatio", true);

            if (!IsolatedStorageManager.Contains("NumberOfMessagesOnMonitor") || overWrite)
                IsolatedStorageManager.SaveIntoIsolatedStorage("NumberOfMessagesOnMonitor", 75);

            if (!IsolatedStorageManager.Contains("ForceIPv4") || overWrite)
                IsolatedStorageManager.SaveIntoIsolatedStorage("ForceIPv4", true);
        }

        #endregion
    }
}
