//******************************************************************************************************
//  CompaniesUserControl.cs - Gbtc
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
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
using openPDCManager.Data;
using openPDCManager.Data.Entities;
using System.Collections.Generic;
using System.Threading;

namespace openPDCManager.UserControls.CommonControls
{
    public partial class CompaniesUserControl
    {
        #region [ Methods ]

        void Initialize()
        {
            if (((App)Application.Current).Principal.IsInRole("Administrator, Editor"))
                ButtonSave.IsEnabled = true;
            else
                ButtonSave.IsEnabled = false;
        }

        void GetCompanies()
        {
            try
            {
                ListBoxCompanyList.ItemsSource = CommonFunctions.GetCompanyList(null);
                if (ListBoxCompanyList.Items.Count > 0)
                    ListBoxCompanyList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetCompanyList", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Company List", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();

            }            
        }

        void SaveCompany(Company company, bool isNew)
        {
            SystemMessages sm;
            try
            {
                string result = CommonFunctions.SaveCompany(null, company, isNew);
                sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
                GetCompanies();
                //ClearForm();          

                //make this newly added or updated item as default selected. So user can click initialize right away.
                ListBoxCompanyList.SelectedItem = ((List<Company>)ListBoxCompanyList.ItemsSource).Find(c => c.Acronym == company.Acronym);                
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.SaveCompany", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Company Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }            
        }

        #endregion
    }
}
