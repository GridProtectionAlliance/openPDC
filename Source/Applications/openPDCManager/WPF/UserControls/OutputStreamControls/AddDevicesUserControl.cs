//******************************************************************************************************
//  AddDevicesUserControl.cs - Gbtc
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
using System.Linq;
using System.Text;
using openPDCManager.Data;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
using System.Windows;
using System.Threading;

namespace openPDCManager.UserControls.OutputStreamControls
{
    public partial class AddDevicesUserControl
    {
        #region [ Methods ]

        void Initialize()
        {
            //this.KeyDown += new System.Windows.Input.KeyEventHandler(AddDevicesUserControl_KeyDown); 
            if (((App)Application.Current).Principal.IsInRole("Administrator, Editor"))
                ButtonAdd.IsEnabled = true;
            else
                ButtonAdd.IsEnabled = false;
        }
        
        void GetDevicesForOutputStream()
        {
            try
            {
                m_deviceList = CommonFunctions.GetDevicesForOutputStream(null, m_sourceOutputStreamID, m_nodeValue);
                ListBoxDeviceList.ItemsSource = m_deviceList;
                if (ListBoxDeviceList.Items.Count > 0)
                    ListBoxDeviceList.SelectedIndex = 0;
                else
                {
                    SystemMessages sm = new SystemMessages(new Message() { UserMessage = "There are no more devices to add to the Output Stream", SystemMessage = "Click OK to return back to Current Devices For Output Stream list.", UserMessageType = MessageType.Information },
                        ButtonType.OkOnly);
                    sm.Owner = Window.GetWindow(this);
                    sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    sm.ShowPopup();

                    (Window.GetWindow(this)).Close();
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetDevicesForOutputStream", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Device for Output Stream", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        void AddDevices()
        {
            SystemMessages sm;
            try
            {
                string result = CommonFunctions.AddDevices(null, m_sourceOutputStreamID, m_devicesToBeAdded, (bool)CheckAddDigitals.IsChecked, (bool)CheckAddAnalog.IsChecked);
                sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();

                GetDevicesForOutputStream();                
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.AddDevices", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Add Output Stream Device(s)", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                           ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
            
        }
                
        #endregion
    }
}
