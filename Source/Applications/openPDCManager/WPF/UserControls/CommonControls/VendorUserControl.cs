//******************************************************************************************************
//  VendorUserControl.cs - Gbtc
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
//  07/13/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Windows;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
using openPDCManager.Data;
using openPDCManager.Data.Entities;

namespace openPDCManager.UserControls.CommonControls
{
    public partial class VendorUserControl
    {
        #region [ Methods ]

        void Initialize()
        {
        }

        void GetVendors()
        {
            try
            {
                ListBoxVendorList.ItemsSource = CommonFunctions.GetVendorList();        
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.GetVendors", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Vendor List", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }                        
        }

        void SaveVendor(Vendor vendor, bool isNew)
        {
            SystemMessages sm;
            try
            {
                string result = CommonFunctions.SaveVendor(vendor, isNew);
                GetVendors();
                ClearForm();
                sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.SaveVendor", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Vendor Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }
        }

        #endregion
    }
}
