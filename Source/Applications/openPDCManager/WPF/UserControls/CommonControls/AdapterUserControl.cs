//******************************************************************************************************
//  AdapterUserControl.cs - Gbtc
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
using System.Windows;
using openPDCManager.Data;
using openPDCManager.Data.Entities;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;

namespace openPDCManager.UserControls.CommonControls
{
    public partial class AdapterUserControl
    {
        #region [ Methods ]

        void Initialize()
        {
           
        }
               
        void GetNodes()
        {
            try
            {
              ComboboxNode.ItemsSource = CommonFunctions.GetNodes(true, false);
              if (ComboboxNode.Items.Count > 0)
                  ComboboxNode.SelectedIndex = 0;
            }            
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.GetNodes", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Nodes", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                       ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }            
        }

        void GetAdapterList()
        {
            try
            {
                ListBoxAdapterList.ItemsSource = CommonFunctions.GetAdapterList(false, m_adapterType, m_nodeID);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.GetAdapterList", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Adapter List", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                         ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }
        }

        void SaveAdapter(Adapter adapter, bool isNew)
        {
            SystemMessages sm;
            try
            {
                string result = CommonFunctions.SaveAdapter(adapter, isNew);
                GetAdapterList();
                ClearForm();
                sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                       ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.SaveAdapter", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Adapter Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }                        
        }

        #endregion
    }
}
