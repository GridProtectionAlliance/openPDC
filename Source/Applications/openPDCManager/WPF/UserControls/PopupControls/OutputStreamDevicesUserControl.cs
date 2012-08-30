//******************************************************************************************************
//  OutputStreamDevicesUserControl.cs - Gbtc
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
//  07/30/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
using openPDCManager.Data;
using openPDCManager.Data.Entities;
using System.Threading;

namespace openPDCManager.UserControls.PopupControls
{
    public partial class OutputStreamDevicesUserControl
    {
        #region [ Methods ]

        void Initialize()
        {
            if (((App)Application.Current).Principal.IsInRole("Administrator, Editor"))
                ButtonSave.IsEnabled = true;
            else
                ButtonSave.IsEnabled = false;
        }

        void GetOutputStreamDeviceList()
        {
            try
            {
                ListBoxOutputStreamDeviceList.ItemsSource = CommonFunctions.GetOutputStreamDeviceList(null, m_sourceOutputStreamID, false);
                if (ListBoxOutputStreamDeviceList.Items.Count > 0)
                    ListBoxOutputStreamDeviceList.SelectedIndex = 0;
                else
                    ClearForm();
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

        void SaveOutputStreamDevice(OutputStreamDevice outputStreamDevice, bool isNew, string originalAcronym)
        {
            SystemMessages sm;
            try
            {
                string result = CommonFunctions.SaveOutputStreamDevice(null, outputStreamDevice, isNew, originalAcronym);
                sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
                GetOutputStreamDeviceList();
                //ClearForm();

                //make this newly added or updated item as default selected. So user can click initialize right away.
                ListBoxOutputStreamDeviceList.SelectedItem = ((List<OutputStreamDevice>)ListBoxOutputStreamDeviceList.ItemsSource).Find(c => c.Acronym == outputStreamDevice.Acronym);
                
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.SaveOutputStreamDevice", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Output Stream Device Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
            
        }

        void DeleteOutputStreamDevice(int outputStreamID, ObservableCollection<string> devicesToBeDeleted)
        {
            SystemMessages sm;
            try
            {
                string result = CommonFunctions.DeleteOutputStreamDevice(null, outputStreamID, new List<string>(devicesToBeDeleted));
                sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
                GetOutputStreamDeviceList();
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.DeleteOutputStreamDevice", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Delete Output Stream Device", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
            }
            sm.Owner = Window.GetWindow(this);
            sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            sm.ShowPopup();
        }

        #endregion
    }
}
