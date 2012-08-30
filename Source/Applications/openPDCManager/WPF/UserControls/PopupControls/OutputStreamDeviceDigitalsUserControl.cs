//******************************************************************************************************
//  OutputStreamDeviceDigitalsUserControl.cs - Gbtc
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
//  08/23/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using openPDCManager.Data.Entities;
using openPDCManager.Data;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
using System.Windows;
using System.Threading;

namespace openPDCManager.UserControls.PopupControls
{
    public partial class OutputStreamDeviceDigitalsUserControl
    {
        #region [ Methods ]

        void Initialize()
        {
            if (((App)Application.Current).Principal.IsInRole("Administrator, Editor"))
                ButtonSave.IsEnabled = true;
            else
                ButtonSave.IsEnabled = false;
        }

        void GetOutputStreamDeviceDigitalList()
        {
            try
            {
                ListBoxOutputStreamDeviceDigitalList.ItemsSource = CommonFunctions.GetOutputStreamDeviceDigitalList(null, m_sourceOutputStreamDeviceID);
                if (ListBoxOutputStreamDeviceDigitalList.Items.Count > 0)
                    ListBoxOutputStreamDeviceDigitalList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetOutputStreamDeviceDigitalList", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Output Stream Device Digital List", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }            
        }

        void SaveOutputStreamDeviceDigital(OutputStreamDeviceDigital outputStreamDeviceDigital, bool isNew)
        {
            SystemMessages sm;
            try
            {
                string result = CommonFunctions.SaveOutputStreamDeviceDigital(null, outputStreamDeviceDigital, isNew);                
                sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);                
                GetOutputStreamDeviceDigitalList();
                //ClearForm();
                ListBoxOutputStreamDeviceDigitalList.SelectedItem = ((List<OutputStreamDeviceDigital>)ListBoxOutputStreamDeviceDigitalList.ItemsSource).Find(c => c.Label == outputStreamDeviceDigital.Label);
                
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.SaveOutputStreamDeviceDigital", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Output Stream Device Digital Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
            }
            sm.Owner = Window.GetWindow(this);
            sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            sm.ShowPopup();
        }

        void DeleteOutputStreamDeviceDigital(int outputStreamDeviceDigitalID)
        {
            SystemMessages sm;
            try
            {
                string result = CommonFunctions.DeleteOutputStreamDeviceDigital(null, outputStreamDeviceDigitalID);
                sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
                GetOutputStreamDeviceDigitalList();
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.DeleteOutputStreamDeviceDigital", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Delete Output Stream Device Digital", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
            }
            sm.Owner = Window.GetWindow(this);
            sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            sm.ShowPopup();
        }

        #endregion
    }
}
