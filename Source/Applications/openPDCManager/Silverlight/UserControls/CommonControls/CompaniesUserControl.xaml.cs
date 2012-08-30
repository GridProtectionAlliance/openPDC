//******************************************************************************************************
//  CompaniesUserControl.xaml.cs - Gbtc
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
using System.Windows.Controls;
using openPDCManager.Utilities;
#if SILVERLIGHT
using openPDCManager.PhasorDataServiceProxy;
using openPDCManager.ModalDialogs;
using System.Windows.Media.Animation;
#else
using openPDCManager.Data.Entities;
using openPDCManager.ModalDialogs;
using System.Windows.Media.Imaging;
using System.Diagnostics;
#endif

namespace openPDCManager.UserControls.CommonControls
{
    public partial class CompaniesUserControl : UserControl
    {
        #region [ Members ]
        
        bool m_inEditMode = false;
        int m_companyID = 0;

        #endregion

        #region [ Constructor ]

        public CompaniesUserControl()
        {
            InitializeComponent();
            Initialize();
#if !SILVERLIGHT
            ButtonSave.Content = new BitmapImage(new Uri("images/Save.png", UriKind.Relative));
            ButtonClear.Content = new BitmapImage(new Uri("images/Cancel.png", UriKind.Relative));
            UpdateLayout();
#endif
            Loaded += new RoutedEventHandler(Companies_Loaded);
            ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
            ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
            ListBoxCompanyList.SelectionChanged += new SelectionChangedEventHandler(ListBoxCompanyList_SelectionChanged);
        }

        #endregion

        #region [ Methods ]

        void ClearForm()
        {
            GridCompanyDetail.DataContext = new Company();	//bind an empty object
            m_inEditMode = false;
            m_companyID = 0;
            ListBoxCompanyList.SelectedIndex = -1;
            ButtonSave.Tag = "Add";
        }

        bool IsValid()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(TextBoxAcronym.Text.CleanText()))
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Acronym", SystemMessage = "Please provide valid Acronym for a comapny.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxAcronym.Focus();
                });
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
#endif
                sm.ShowPopup();
                return isValid;
            }

            if (string.IsNullOrEmpty(TextBoxMapAcronym.Text.CleanText()))
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Map Acronym", SystemMessage = "Please provide valid Map Acronym for a company.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxMapAcronym.Focus();
                });
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
#endif
                sm.ShowPopup();
                return isValid;
            }

            if (string.IsNullOrEmpty(TextBoxName.Text.CleanText()))
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Name", SystemMessage = "Please provide valid Name for a company.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxName.Focus();
                });
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
#endif
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxLoadOrder.Text.IsInteger())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Load Order", SystemMessage = "Please provide valid integer value for Load Order.", UserMessageType = MessageType.Error },
                    ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxLoadOrder.Text = "0";
                    TextBoxLoadOrder.Focus();
                });
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
#endif
                sm.ShowPopup();
                return isValid;
            }

            return isValid;
        }

        #endregion

        #region [ Page Event Handlers ]

        void Companies_Loaded(object sender, RoutedEventArgs e)
        {            
            ClearForm();
            GetCompanies();
        }

        #endregion

        #region [ Control Event Handlers ]

        void ListBoxCompanyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxCompanyList.SelectedIndex >= 0)
            {
                Company selectedCompany = ListBoxCompanyList.SelectedItem as Company;
                GridCompanyDetail.DataContext = selectedCompany;
                m_inEditMode = true;
                m_companyID = selectedCompany.ID;
                ButtonSave.Tag = "Update";
            }
        }

        void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            Storyboard sb = new Storyboard();
            sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            Storyboard.SetTarget(sb, ButtonClearTransform);
            sb.Begin();
#endif
            ClearForm();
        }

        void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            Storyboard sb = new Storyboard();
            sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            Storyboard.SetTarget(sb, ButtonSaveTransform);
            sb.Begin();
#endif
            if (IsValid())
            {
                Company company = new Company();
                company.Acronym = TextBoxAcronym.Text.CleanText();
                company.MapAcronym = TextBoxMapAcronym.Text.CleanText();
                company.Name = TextBoxName.Text.CleanText();
                company.URL = TextBoxURL.Text.CleanText();
                company.LoadOrder = TextBoxLoadOrder.Text.ToInteger();

                if (m_inEditMode == true && m_companyID != 0)
                {
                    company.ID = m_companyID;
                    SaveCompany(company, false);
                }
                else
                    SaveCompany(company, true);
            }
        }

        void ButtonURL_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Content != null)
            {
#if SILVERLIGHT
                System.Windows.Browser.HtmlPage.Window.Navigate(new Uri(((Button)sender).Content.ToString()), "_blank");
#else
                Process.Start(((Button)sender).Content.ToString());
#endif
            }
        }

        #endregion

    }
}
