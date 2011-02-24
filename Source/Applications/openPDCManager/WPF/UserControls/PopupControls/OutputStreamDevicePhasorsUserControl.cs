//******************************************************************************************************
//  OutputStreamDevicePhasorsUserControl.cs - Gbtc
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
using System.Windows;
using openPDCManager.Data;
using openPDCManager.Data.Entities;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
using System.Collections.Generic;
using System.Threading;

namespace openPDCManager.UserControls.PopupControls
{
    public partial class OutputStreamDevicePhasorsUserControl
    {
        #region [ Methods ]

        void Initialize()
        {
            if (((App)Application.Current).Principal.IsInRole("Administrator, Editor"))
                ButtonSave.IsEnabled = true;
            else
                ButtonSave.IsEnabled = false;
        }

        void GetOutputStreamDevicePhasorList()
        {
            try
            {
                ListBoxOutputStreamDevicePhasorList.ItemsSource = CommonFunctions.GetOutputStreamDevicePhasorList(null, m_sourceOutputStreamDeviceID);
                if (ListBoxOutputStreamDevicePhasorList.Items.Count > 0)
                    ListBoxOutputStreamDevicePhasorList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetOutputStreamDevicePhasorList", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Output Stream Device Phasor List", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }            
        }

        void SaveOutputStreamDevicePhasor(OutputStreamDevicePhasor outputStreamDevicePhasor, bool isNew)
        {
            SystemMessages sm;
            try
            {
                string result = CommonFunctions.SaveOutputStreamDevicePhasor(null, outputStreamDevicePhasor, isNew);                
                sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
                GetOutputStreamDevicePhasorList();
                //ClearForm();

                //make this newly added or updated item as default selected. So user can click initialize right away.
                ListBoxOutputStreamDevicePhasorList.SelectedItem = ((List<OutputStreamDevicePhasor>)ListBoxOutputStreamDevicePhasorList.ItemsSource).Find(c => c.Label == outputStreamDevicePhasor.Label);
                
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.SaveOutputStreamDevicePhasor", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Output Stream Device Phasor Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
            }
            sm.Owner = Window.GetWindow(this);
            sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            sm.ShowPopup();
        }

        void DeleteOutputStreamDevicePhasor(int outputStreamDevicePhasorID)
        {
            SystemMessages sm;
            try
            {
                string result = CommonFunctions.DeleteOutputStreamDevicePhasor(null, outputStreamDevicePhasorID);
                sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
                GetOutputStreamDevicePhasorList();
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.DeleteOutputStreamDevicePhasor", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Delete Output Stream Device Phasor", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
            }
            sm.Owner = Window.GetWindow(this);
            sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            sm.ShowPopup();
        }

        #endregion
    }
}
