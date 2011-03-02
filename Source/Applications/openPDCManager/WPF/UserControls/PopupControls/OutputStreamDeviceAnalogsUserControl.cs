//******************************************************************************************************
//  OutputStreamDeviceAnalogsUserControl.cs - Gbtc
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
    public partial class OutputStreamDeviceAnalogsUserControl
    {
        #region [ Methods ]

        void Initialize()
        {
            if (((App)Application.Current).Principal.IsInRole("Administrator, Editor"))
                ButtonSave.IsEnabled = true;
            else
                ButtonSave.IsEnabled = false;
        }

        void GetOutputStreamDeviceAnalogList()
        {
            try
            {
                ListBoxOutputStreamDeviceAnalogList.ItemsSource = CommonFunctions.GetOutputStreamDeviceAnalogList(null, m_sourceOutputStreamDeviceID);
                if (ListBoxOutputStreamDeviceAnalogList.Items.Count > 0)
                    ListBoxOutputStreamDeviceAnalogList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetOutputStreamDeviceAnalogList", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Ouptu Stream Device Analog List", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        void SaveOutputStreamDeviceAnalog(OutputStreamDeviceAnalog outputStreamDeviceAnalog, bool isNew)
        {
            SystemMessages sm;
            try
            {
                string result = CommonFunctions.SaveOutputStreamDeviceAnalog(null, outputStreamDeviceAnalog, isNew);                
                sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);                
                GetOutputStreamDeviceAnalogList();
                //ClearForm();
                //make this newly added or updated item as default selected. So user can click initialize right away.
                ListBoxOutputStreamDeviceAnalogList.SelectedItem = ((List<OutputStreamDeviceAnalog>)ListBoxOutputStreamDeviceAnalogList.ItemsSource).Find(c => c.Label == outputStreamDeviceAnalog.Label);
                
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.SaveOutputStreamDeviceAnalog", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Output Stream Device Analog Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
            }
            sm.Owner = Window.GetWindow(this);
            sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            sm.ShowPopup();
        }

        void DeleteOutputStreamDeviceAnalog(int outputStreamDeviceAnalogID)
        {
            SystemMessages sm;
            try
            {
                string result = CommonFunctions.DeleteOutputStreamDeviceAnalog(null, outputStreamDeviceAnalogID);
                sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
                GetOutputStreamDeviceAnalogList();
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.DeleteOutputStreamDeviceAnalog", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Delete Output Stream Device Analog", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
            }
            sm.Owner = Window.GetWindow(this);
            sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            sm.ShowPopup();
        }

        #endregion
    }
}
