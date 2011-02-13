//******************************************************************************************************
//  OutputStreamMeasurementsUserControl.cs - Gbtc
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
using System.Linq;
using System.Text;
using openPDCManager.Data;
using openPDCManager.Utilities;
using openPDCManager.ModalDialogs;
using System.Windows;
using System.Threading;

namespace openPDCManager.UserControls.PopupControls
{
    public partial class OutputStreamMeasurementsUserControl
    {
        #region [ Methods ]

        void Initialize()
        {
            ListBoxOutputStreamMeasurementList.LayoutUpdated += new EventHandler(ListBoxOutputStreamMeasurementList_LayoutUpdated);
            if (((App)Application.Current).Principal.IsInRole("Administrator, Editor"))
                ButtonSave.IsEnabled = true;
            else
                ButtonSave.IsEnabled = false;
        }

        void ListBoxOutputStreamMeasurementList_LayoutUpdated(object sender, EventArgs e)
        {
            
        }

        void GetOutputStreamMeasurementList()
        {
            try
            {
                ListBoxOutputStreamMeasurementList.ItemsSource = CommonFunctions.GetOutputStreamMeasurementList(null, m_sourceOutputStreamID);
                if (ListBoxOutputStreamMeasurementList.Items.Count > 0)
                    ListBoxOutputStreamMeasurementList.SelectedIndex = 0;
                else
                    ClearForm();
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetOutputStreamMeasurementList", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Output Stream Measurement List", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
            if (m_activityWindow != null)
                m_activityWindow.Close();                
        }

        void SaveOutputStreamMeasurement()
        {
            SystemMessages sm;
            try
            {
                string result = CommonFunctions.SaveOutputStreamMeasurement(null, m_selectedOutputStreamMeasurement, false);                
                sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();            

                GetOutputStreamMeasurementList();
                //ClearForm();

                ListBoxOutputStreamMeasurementList.SelectedItem = m_selectedOutputStreamMeasurement;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.SaveOutputStreamMeasurement", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Output Stream Measurement Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();            
            }            
        }

        void DeleteOutputStreamMeasurement(int outputStreamMeasurementId)
        {
            SystemMessages sm;
            try
            {
                string result = CommonFunctions.DeleteOutputStreamMeasurement(null, outputStreamMeasurementId);
                GetOutputStreamMeasurementList();
                ClearForm();
                sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.DeleteOutputStreamMeasurement", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Delete Output Stream Measurement", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
            }
            sm.Owner = Window.GetWindow(this);
            sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            sm.ShowPopup();            
        }

        #endregion
    }
}
