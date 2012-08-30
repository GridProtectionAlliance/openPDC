//******************************************************************************************************
//  CurrentDevicesUserControl.cs - Gbtc
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
//  08/02/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Windows;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
using openPDCManager.Data;
using System.Threading;

namespace openPDCManager.UserControls.OutputStreamControls
{
    public partial class CurrentDevicesUserControl
    {
        #region [ Methods ]

        void Initialize()
        {
            if (((App)Application.Current).Principal.IsInRole("Administrator, Editor"))
                ButtonAdd.IsEnabled = true;
            else
                ButtonAdd.IsEnabled = false;
        }

        void GetOutputStreamDeviceList()
        {
            try
            {
                ListBoxOutputStreamDeviceList.ItemsSource = CommonFunctions.GetOutputStreamDeviceList(null, m_sourceOutputStreamID, true);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetOutputStreamDeviceList", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Output Stream Device List", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        void DeleteOutputStreamDevice()
        {
            SystemMessages sm;
            try
            {
                string result = CommonFunctions.DeleteOutputStreamDevice(null, m_sourceOutputStreamID, new List<string>(m_devicesToBeDeleted));
                GetOutputStreamDeviceList();
                sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.DeleteOutputStreamDevice", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Delete Output Stream Device(s)", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
            }
            sm.Owner = Window.GetWindow(this);
            sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            sm.ShowPopup();
        }

        #endregion
    }
}
