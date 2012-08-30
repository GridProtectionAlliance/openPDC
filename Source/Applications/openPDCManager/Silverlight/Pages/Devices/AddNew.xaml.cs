//******************************************************************************************************
//  AddNew.xaml.cs - Gbtc
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using openPDCManager.PhasorDataServiceProxy;

namespace openPDCManager.Pages.Devices
{
	public partial class AddNew : Page
	{
		#region [ Constructor ]

		public AddNew()
		{
			InitializeComponent();            
		}

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (this.NavigationContext.QueryString.ContainsKey("did"))
            {
                UserControlManageDevices.hasQueryString = true;
                UserControlManageDevices.m_deviceID = Convert.ToInt32(this.NavigationContext.QueryString["did"]);
                UserControlManageDevices.m_copyDevice = false;
            }
            else if (this.NavigationContext.QueryString.ContainsKey("copydid"))
            {
                UserControlManageDevices.hasQueryString = true;
                UserControlManageDevices.m_deviceID = Convert.ToInt32(this.NavigationContext.QueryString["copydid"]);
                UserControlManageDevices.m_copyDevice = true;
            }
            UserControlManageDevices.GetDevices(DeviceType.Concentrator, ((App)Application.Current).NodeValue, true);
            UserControlManageDevices.GetCompanies();
            UserControlManageDevices.GetNodes();
            UserControlManageDevices.GetHistorians();
            UserControlManageDevices.GetInterconnections();
            UserControlManageDevices.GetVendorDevices();
            UserControlManageDevices.GetProtocols();
            UserControlManageDevices.GetTimeZones();           
        }

		#endregion		
	}
}
