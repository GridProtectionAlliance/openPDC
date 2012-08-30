//******************************************************************************************************
//  NodesUserControl.cs - Gbtc
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
//  07/12/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Windows;
using openPDCManager.Utilities;
using openPDCManager.Data;
using openPDCManager.Data.Entities;
using openPDCManager.ModalDialogs;
using System.Threading;

namespace openPDCManager.UserControls.CommonControls
{
    public partial class NodesUserControl
    {
        #region [ Methods ]

        void Initialize()
        {
            if (((App)Application.Current).Principal.IsInRole("Administrator"))
                ButtonSave.IsEnabled = true;
            else
                ButtonSave.IsEnabled = false;
        }

        void GetNodes()
        {            
            try
            {
                m_activityWindow = new ActivityWindow("Loading Data... Please Wait...");
                m_activityWindow.Owner = Window.GetWindow(this);
                m_activityWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                m_activityWindow.Show();
                ListBoxNodeList.ItemsSource = CommonFunctions.GetNodeList(null, false);
                if (ListBoxNodeList.Items.Count > 0)
                    ListBoxNodeList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetNodeList", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Node Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }
            finally
            {                
                m_activityWindow.Close();
            }
        }

        void GetCompanies()
        {
            try
            {
                ComboBoxCompany.ItemsSource = CommonFunctions.GetCompanies(null, true);
                if (ComboBoxCompany.Items.Count > 0)
                    ComboBoxCompany.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetCompanies", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Companies", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                         ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }            
        }

        void SaveNode(Node node, bool isNew)
        {
            SystemMessages sm;
            try
            {
                string result = CommonFunctions.SaveNode(null, node, isNew);
                try
                {
                    string nodeID = CommonFunctions.GetNodeByName(null, node.Name).ID;
                    if (isNew)
                        CreateRoles(nodeID);
                }
                catch (Exception ex1)
                {
                    CommonFunctions.LogException(null, "WPF.CreateRoles", ex1);
                    sm = new SystemMessages(new Message() { UserMessage = "Failed to Create Application Roles for Node", SystemMessage = ex1.Message, UserMessageType = MessageType.Error },
                           ButtonType.OkOnly);
                    sm.Owner = Window.GetWindow(this);
                    sm.ShowPopup();
                }
                sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
                GetNodes();
                //ClearForm();
                ((MasterLayoutWindow)Window.GetWindow(this)).UserControlSelectNode.RaiseNotification();
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.SaveNode", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Node Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                       ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }
        }

        void CreateRoles(string nodeID)
        {
            Role role;

            //Create Administrator role
            role = new Role() { Name = "Administrator", Description = "Administrator Role", NodeID = nodeID, CreatedBy = ((App)Application.Current).Principal.Identity.Name, UpdatedBy = ((App)Application.Current).Principal.Identity.Name };
            CommonFunctions.SaveRole(null, role, true);

            //Create Editor role
            role = new Role() { Name = "Editor", Description = "Editor Role", NodeID = nodeID, CreatedBy = ((App)Application.Current).Principal.Identity.Name, UpdatedBy = ((App)Application.Current).Principal.Identity.Name };
            CommonFunctions.SaveRole(null, role, true);

            //Create Viewer role
            role = new Role() { Name = "Viewer", Description = "Viewer Role", NodeID = nodeID, CreatedBy = ((App)Application.Current).Principal.Identity.Name, UpdatedBy = ((App)Application.Current).Principal.Identity.Name };
            CommonFunctions.SaveRole(null, role, true);
        }

        #endregion
    }
}
