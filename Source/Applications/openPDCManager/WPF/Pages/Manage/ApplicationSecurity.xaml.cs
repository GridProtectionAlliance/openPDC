//******************************************************************************************************
//  ApplicationSecurity.xaml.cs - Gbtc
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
//  12/27/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using openPDCManager.Data.Entities;
using System.Collections.Generic;
using openPDCManager.Data;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
using System.Text;
using System.Web.Security;
using System.Threading;
using System.Windows.Threading;

namespace openPDCManager.Pages.Manage
{
    /// <summary>
    /// Interaction logic for ApplicationSecurity.xaml
    /// </summary>
    public partial class ApplicationSecurity : UserControl
    {
        #region " Members"
                
        User m_selectedUser;
        bool m_editUserMode;
        string m_strongPasswordRegex = "^.*(?=.{8,})(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).*$";
        StringBuilder m_invalidPasswordMessage;

        Group m_selectedGroup;
        bool m_editGroupMode;

        Role m_selectedRole;
        bool m_editRoleMode;

        DispatcherTimer m_groupUsersTimer, m_roleUsersTimer, m_roleGroupsTimer;

        #endregion

        #region " Constructor"

        public ApplicationSecurity()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(ApplicationSecurity_Loaded);
            ButtonAddNewUser.Content = new BitmapImage(new Uri(@"images/Add.png", UriKind.Relative));
            ButtonDeleteUser.Content = new BitmapImage(new Uri(@"images/Cancel.png", UriKind.Relative));
            ButtonSaveUser.Content = new BitmapImage(new Uri(@"images/Save.png", UriKind.Relative));
            ButtonClearUser.Content = new BitmapImage(new Uri(@"images/Cancel.png", UriKind.Relative));
            ButtonAddNewGroup.Content = new BitmapImage(new Uri(@"images/Add.png", UriKind.Relative));
            ButtonDeleteGroup.Content = new BitmapImage(new Uri(@"images/Cancel.png", UriKind.Relative));
            ButtonSaveGroup.Content = new BitmapImage(new Uri(@"images/Save.png", UriKind.Relative));
            ButtonClearGroup.Content = new BitmapImage(new Uri(@"images/Cancel.png", UriKind.Relative));
            ButtonDeleteGroupUsers.Content = new BitmapImage(new Uri(@"images/Next.png", UriKind.Relative));
            ButtonAddGroupUsers.Content = new BitmapImage(new Uri(@"images/Previous.png", UriKind.Relative));
            ButtonAddRoleGroups.Content = new BitmapImage(new Uri(@"images/Previous.png", UriKind.Relative));
            ButtonDeleteRoleGroups.Content = new BitmapImage(new Uri(@"images/Next.png", UriKind.Relative));
            ButtonAddRoleUsers.Content = new BitmapImage(new Uri(@"images/Previous.png", UriKind.Relative));
            ButtonDeleteRoleUsers.Content = new BitmapImage(new Uri(@"images/Next.png", UriKind.Relative));
            ButtonClearRole.Content = new BitmapImage(new Uri(@"images/Cancel.png", UriKind.Relative));
            
            //Attach event handlers to UI controls.            
            //User management control events.
            ListBoxUsers.SelectionChanged += new SelectionChangedEventHandler(ListBoxUsers_SelectionChanged);
            ButtonAddNewUser.Click += new RoutedEventHandler(ButtonAddNewUser_Click);
            ButtonDeleteUser.Click += new RoutedEventHandler(ButtonDeleteUser_Click);
            ComboBoxAuthentication.SelectionChanged += new SelectionChangedEventHandler(ComboBoxAuthentication_SelectionChanged);
            ButtonSaveUser.Click += new RoutedEventHandler(ButtonSaveUser_Click);
            ButtonClearUser.Click += new RoutedEventHandler(ButtonClearUser_Click);

            //Group management control events.
            GroupBoxGroupUsers.Visibility = Visibility.Collapsed;
            ListBoxGroups.SelectionChanged += new SelectionChangedEventHandler(ListBoxGroups_SelectionChanged);
            ButtonAddNewGroup.Click += new RoutedEventHandler(ButtonAddNewGroup_Click);
            ButtonDeleteGroup.Click += new RoutedEventHandler(ButtonDeleteGroup_Click);
            ButtonSaveGroup.Click += new RoutedEventHandler(ButtonSaveGroup_Click);
            ButtonClearGroup.Click += new RoutedEventHandler(ButtonClearGroup_Click);
            ButtonDeleteGroupUsers.Click += new RoutedEventHandler(ButtonDeleteGroupUsers_Click);
            ButtonAddGroupUsers.Click += new RoutedEventHandler(ButtonAddGroupUsers_Click);

            //Role management control events.
            GroupBoxRoleUsers.Visibility = Visibility.Collapsed;
            GroupBoxRoleGroups.Visibility = Visibility.Collapsed;
            ListBoxRoles.SelectionChanged += new SelectionChangedEventHandler(ListBoxRoles_SelectionChanged);
            ButtonAddRoleUsers.Click += new RoutedEventHandler(ButtonAddRoleUsers_Click);
            ButtonDeleteRoleUsers.Click += new RoutedEventHandler(ButtonDeleteRoleUsers_Click);
            ButtonAddRoleGroups.Click += new RoutedEventHandler(ButtonAddRoleGroups_Click);
            ButtonDeleteRoleGroups.Click += new RoutedEventHandler(ButtonDeleteRoleGroups_Click);
            ButtonClearRole.Click += new RoutedEventHandler(ButtonClearRole_Click);
        }
        
        #endregion

        #region " Page Event Handlers"
        
        void ApplicationSecurity_Loaded(object sender, RoutedEventArgs e)
        {
            if (((App)Application.Current).Principal.IsInRole("Administrator"))
            {
                ButtonAddGroupUsers.IsEnabled = true;
                ButtonAddNewGroup.IsEnabled = true;
                ButtonAddNewUser.IsEnabled = true;
                ButtonAddRoleGroups.IsEnabled = true;
                ButtonAddRoleUsers.IsEnabled = true;
                ButtonClearGroup.IsEnabled = true;
                ButtonClearRole.IsEnabled = true;
                ButtonClearUser.IsEnabled = true;
                ButtonDeleteGroup.IsEnabled = true;
                ButtonDeleteGroupUsers.IsEnabled = true;
                ButtonDeleteRoleGroups.IsEnabled = true;
                ButtonDeleteRoleUsers.IsEnabled = true;
                ButtonDeleteUser.IsEnabled = true;
                ButtonSaveGroup.IsEnabled = true;
                ButtonSaveUser.IsEnabled = true;                
            }
            else
            {
                ButtonAddGroupUsers.IsEnabled = false;
                ButtonAddNewGroup.IsEnabled = false;
                ButtonAddNewUser.IsEnabled = false;
                ButtonAddRoleGroups.IsEnabled = false;
                ButtonAddRoleUsers.IsEnabled = false;
                ButtonClearGroup.IsEnabled = false;
                ButtonClearRole.IsEnabled = false;
                ButtonClearUser.IsEnabled = false;
                ButtonDeleteGroup.IsEnabled = false;
                ButtonDeleteGroupUsers.IsEnabled = false;
                ButtonDeleteRoleGroups.IsEnabled = false;
                ButtonDeleteRoleUsers.IsEnabled = false;
                ButtonDeleteUser.IsEnabled = false;
                ButtonSaveGroup.IsEnabled = false;
                ButtonSaveUser.IsEnabled = false;
            }

            ComboBoxAuthentication.Items.Add("Windows Authentication");
            ComboBoxAuthentication.Items.Add("Database Authentication");
            ComboBoxAuthentication.SelectedIndex = 0;            
            GetUsers();
            ClearUserInformation();
            GetGroups();
            ClearGroupInformation();
            GetRoles();
            ClearRoleInformation();
            TextBlockManageRoles.Text = "Manage Application Roles For Node: " + ((App)Application.Current).NodeName;
                        
            m_invalidPasswordMessage = new StringBuilder();
            m_invalidPasswordMessage.Append("Password does not meet the following criteria:");
            m_invalidPasswordMessage.AppendLine();
            m_invalidPasswordMessage.Append("- Password must be at least 8 characters");
            m_invalidPasswordMessage.AppendLine();
            m_invalidPasswordMessage.Append("- Password must contain at least 1 digit");
            m_invalidPasswordMessage.AppendLine();
            m_invalidPasswordMessage.Append("- Password must contain at least 1 upper case letter");
            m_invalidPasswordMessage.AppendLine();
            m_invalidPasswordMessage.Append("- Password must contain at least 1 lower case letter");

            m_groupUsersTimer = new DispatcherTimer();
            m_groupUsersTimer.Interval = TimeSpan.FromSeconds(5);
            m_groupUsersTimer.Tick += new EventHandler(m_groupUsersTimer_Tick);

            m_roleUsersTimer = new DispatcherTimer();
            m_roleUsersTimer.Interval = TimeSpan.FromSeconds(5);
            m_roleUsersTimer.Tick += new EventHandler(m_roleUsersTimer_Tick);

            m_roleGroupsTimer = new DispatcherTimer();
            m_roleGroupsTimer.Interval = TimeSpan.FromSeconds(5);
            m_roleGroupsTimer.Tick += new EventHandler(m_roleGroupsTimer_Tick);
        }

        void m_roleGroupsTimer_Tick(object sender, EventArgs e)
        {
            if (TextBlockRoleGroupsMessage.Visibility == Visibility.Collapsed)
                TextBlockRoleGroupsMessage.Visibility = Visibility.Visible;
            else
            {
                TextBlockRoleGroupsMessage.Visibility = Visibility.Collapsed;
                m_roleGroupsTimer.Stop();
            }
        }

        void m_roleUsersTimer_Tick(object sender, EventArgs e)
        {
            if (TextBlockRoleUsersMessage.Visibility == Visibility.Collapsed)
                TextBlockRoleUsersMessage.Visibility = Visibility.Visible;
            else
            {
                TextBlockRoleUsersMessage.Visibility = Visibility.Collapsed;
                m_roleUsersTimer.Stop();
            }
        }

        void m_groupUsersTimer_Tick(object sender, EventArgs e)
        {
            if (TextBlockGroupUsersMessage.Visibility == Visibility.Collapsed)
                TextBlockGroupUsersMessage.Visibility = Visibility.Visible;
            else
            {
                TextBlockGroupUsersMessage.Visibility = Visibility.Collapsed;
                m_groupUsersTimer.Stop();
            }
        }

        #endregion

        #region " Control Event Handlers"

        #region " User Management Control Event Handlers"
        
        void ListBoxUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxUsers.SelectedIndex >= 0)
            {
                m_selectedUser = (User)ListBoxUsers.SelectedItem;
                GridManageUsers.DataContext = m_selectedUser;
                if (!m_selectedUser.UseADAuthentication)
                    DatePickerPasswordExpiry.SelectedDate = m_selectedUser.ChangePasswordOn;
                if (m_selectedUser.UseADAuthentication)
                    ComboBoxAuthentication.SelectedItem = "Windows Authentication";
                else
                    ComboBoxAuthentication.SelectedItem = "Database Authentication";
                ButtonSaveUser.Tag = "Update";
                m_editUserMode = true;
            }
            else
                ClearUserInformation();
        }

        void ComboBoxAuthentication_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeUserInfoVisualization();
        }

        void ButtonDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            SystemMessages sm;
            try
            {
                if (m_selectedUser == null)
                    throw new Exception("Please select User from the list to delete.");

                SystemMessages sm1 = new SystemMessages(new Message() { UserMessage = "Do you want to delete user?", SystemMessage = "Username: " + m_selectedUser.Name, UserMessageType = MessageType.Confirmation }, ButtonType.YesNo);

                sm1.Closed += new EventHandler(delegate(object popupWindow, EventArgs eargs)
                {
                    if ((bool)sm1.DialogResult)
                    {

                        string result = CommonFunctions.DeleteUser(null, m_selectedUser.ID);
                        sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                                ButtonType.OkOnly);
                        sm.Owner = Window.GetWindow(this);
                        sm.ShowPopup();
                        GetUsers();
                        ClearUserInformation();
                    }
                });

                sm1.Owner = Window.GetWindow(this);
                sm1.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm1.ShowPopup();
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.DeleteUser", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Delete User", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                       ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }
        }

        void ButtonAddNewUser_Click(object sender, RoutedEventArgs e)
        {
            ClearUserInformation();
            TextBoxUsername.Text = "User 1";
            TextBoxUsername.SelectAll();
            TextBoxUsername.Focus();
        }

        void ButtonClearUser_Click(object sender, RoutedEventArgs e)
        {
            ClearUserInformation();
        }

        void ButtonSaveUser_Click(object sender, RoutedEventArgs e)
        {   
            SystemMessages sm;
            try
            {
                if (ValidateUserInfo())
                {
                    string result;
                    User user = new User();
                    user.Name = TextBoxUsername.Text.CleanText();
                    user.DefaultNodeID = ((App)Application.Current).NodeValue;
                    user.LockedOut = (bool)CheckBoxLockedOut.IsChecked;
                    user.UseADAuthentication = true;
                    user.ChangePasswordOn = DateTime.MinValue;
                    user.UpdatedBy = ((App)Application.Current).Principal.Identity.Name;
                    user.UpdatedOn = DateTime.UtcNow;
                    if (ComboBoxAuthentication.SelectedValue.ToString() == "Database Authentication")
                    {

                        user.FirstName = TextBoxFirstName.Text.CleanText();
                        user.LastName = TextBoxLastName.Text.CleanText();
                        user.Phone = TextBoxPhone.Text.CleanText();
                        user.Email = TextBoxEmail.Text.CleanText();
                        user.UseADAuthentication = false;
                        user.ChangePasswordOn = DatePickerPasswordExpiry.SelectedDate ?? DateTime.MinValue;
                    }
                    else
                    {
                        user.FirstName = string.Empty;
                        user.LastName = string.Empty;
                        user.Phone = string.Empty;
                        user.Email = string.Empty;
                        user.UseADAuthentication = true;
                    }

                    if (m_editUserMode)
                    {
                        if (string.IsNullOrEmpty(TextBoxPassword.Password))
                            user.Password = m_selectedUser.Password;    //keep existing password.
                        else
                            user.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(@"O3990\P78f9E66b:a35_V©6M13©6~2&[" + TextBoxPassword.Password, "SHA1");
                        user.ID = m_selectedUser.ID;
                        user.CreatedBy = m_selectedUser.CreatedBy;
                        user.CreatedOn = m_selectedUser.CreatedOn;
                        result = CommonFunctions.SaveUser(null, user, false);
                    }
                    else
                    {
                        //don't need password for active directory users.
                        if (ComboBoxAuthentication.SelectedValue.ToString() == "Database Authentication")
                        {
                            if (string.IsNullOrEmpty(TextBoxPassword.Password))
                                throw new Exception(m_invalidPasswordMessage.ToString());
                            user.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(@"O3990\P78f9E66b:a35_V©6M13©6~2&[" + TextBoxPassword.Password, "SHA1");
                        }
                        else
                            user.Password = string.Empty;
                        user.CreatedBy = ((App)Application.Current).Principal.Identity.Name;
                        user.CreatedOn = DateTime.UtcNow;
                        result = CommonFunctions.SaveUser(null, user, true);                        
                    }

                    sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
                    sm.Owner = Window.GetWindow(this);
                    sm.ShowPopup();

                    GetUsers();
                    ClearUserInformation();

                    //If group is selected when a user was being added or updated, then refresh current users list and possible users  list.
                    if (m_selectedGroup != null && m_editGroupMode)
                    {
                        ListBoxCurrentGroupUsers.ItemsSource = m_selectedGroup.CurrentGroupUsers = CommonFunctions.GetCurrentGroupUsers(null, m_selectedGroup.ID);
                        ListBoxPossibleGroupUsers.ItemsSource = m_selectedGroup.PossibleGroupUsers = CommonFunctions.GetPossibleGroupUsers(null, m_selectedGroup.ID);
                    }

                    //If role is selected when a user was being added or updated then refresh current users, possible users list for role.
                    if (m_selectedRole != null && m_editRoleMode)
                    {
                        ListBoxCurrentRoleUsers.ItemsSource = m_selectedRole.CurrentRoleUsers = CommonFunctions.GetCurrentRoleUsers(null, m_selectedRole.ID);
                        ListBoxPossibleRoleUsers.ItemsSource = m_selectedRole.PossibleRoleUsers = CommonFunctions.GetPossibleRoleUsers(null, m_selectedRole.ID);
                    }
                }                
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.SaveUser", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Save User Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }            
        }

        #endregion

        #region " Group Management Control Event Handlers"

        void ListBoxGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxGroups.SelectedIndex >= 0)
            {
                m_selectedGroup = (Group)ListBoxGroups.SelectedItem;
                ListBoxCurrentGroupUsers.ItemsSource = m_selectedGroup.CurrentGroupUsers = CommonFunctions.GetCurrentGroupUsers(null, m_selectedGroup.ID);
                ListBoxPossibleGroupUsers.ItemsSource = m_selectedGroup.PossibleGroupUsers = CommonFunctions.GetPossibleGroupUsers(null, m_selectedGroup.ID);
                GridManageGroups.DataContext = m_selectedGroup;
                ButtonSaveGroup.Tag = "Update";
                m_editGroupMode = true;
                ChangeGroupsUsersVisualization();
            }
            else
                ClearGroupInformation();
        }

        void ButtonAddNewGroup_Click(object sender, RoutedEventArgs e)
        {
            ClearGroupInformation();
            TextBoxGroupName.Text = "Group 1";
            TextBoxGroupName.SelectAll();
            TextBoxGroupName.Focus();
        }

        void ButtonSaveGroup_Click(object sender, RoutedEventArgs e)
        {
            SystemMessages sm;
            try
            {
                if (ValidateGroupInfo())
                {
                    string result;
                    Group group = new Group();
                    group.Name = TextBoxGroupName.Text.CleanText();
                    group.Description = TextBoxGroupDescription.Text.CleanText();
                    group.UpdatedBy = ((App)Application.Current).Principal.Identity.Name;
                    if (m_editGroupMode)
                    {
                        group.ID = m_selectedGroup.ID;
                        group.UpdatedOn = DateTime.UtcNow;
                        group.CreatedBy = m_selectedGroup.CreatedBy;
                        group.CreatedOn = m_selectedGroup.CreatedOn;
                        result = CommonFunctions.SaveGroup(null, group, false);
                    }
                    else
                    {                        
                        group.CreatedBy = ((App)Application.Current).Principal.Identity.Name;                        
                        result = CommonFunctions.SaveGroup(null, group, true);
                    }

                    sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
                    sm.Owner = Window.GetWindow(this);
                    sm.ShowPopup();

                    GetGroups();
                    ClearGroupInformation();

                    //If role is selected when a group was being added or updated then refresh current users, possible users list for role.
                    if (m_selectedRole != null && m_editRoleMode)
                    {
                        ListBoxCurrentRoleGroups.ItemsSource = m_selectedRole.CurrentRoleGroups = CommonFunctions.GetCurrentRoleGroups(null, m_selectedRole.ID);
                        ListBoxPossibleRoleGroups.ItemsSource = m_selectedRole.PossibleRoleGroups = CommonFunctions.GetPossibleRoleGroups(null, m_selectedRole.ID);
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.SaveGroup", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Group Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }
        }

        void ButtonDeleteGroup_Click(object sender, RoutedEventArgs e)
        {
            SystemMessages sm;
            try
            {
                if (m_selectedGroup == null)
                    throw new Exception("Please select Group from the list to delete.");

                SystemMessages sm1 = new SystemMessages(new Message() { UserMessage = "Do you want to delete group?", SystemMessage = "Group Name: " + m_selectedGroup.Name, UserMessageType = MessageType.Confirmation }, ButtonType.YesNo);

                sm1.Closed += new EventHandler(delegate(object popupWindow, EventArgs eargs)
                {
                    if ((bool)sm1.DialogResult)
                    {
                        string result = CommonFunctions.DeleteGroup(null, m_selectedGroup.ID);
                        sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                                ButtonType.OkOnly);
                        sm.Owner = Window.GetWindow(this);
                        sm.ShowPopup();
                        GetGroups();
                        ClearGroupInformation();
                    }
                });

                sm1.Owner = Window.GetWindow(this);
                sm1.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm1.ShowPopup();
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.DeleteGroup", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Delete Group", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                       ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }
        }

        void ButtonClearGroup_Click(object sender, RoutedEventArgs e)
        {
            ClearGroupInformation();
        }

        void ButtonDeleteGroupUsers_Click(object sender, RoutedEventArgs e)
        {
            SystemMessages sm;
            try
            {
                List<string> usersToBeDeleted = new List<string>();
                foreach (object user in ListBoxCurrentGroupUsers.SelectedItems)
                    usersToBeDeleted.Add(((User)user).ID);

                if (usersToBeDeleted.Count > 0)
                    CommonFunctions.DeleteGroupUsers(null, m_selectedGroup.ID, usersToBeDeleted);

                ListBoxCurrentGroupUsers.ItemsSource = m_selectedGroup.CurrentGroupUsers = CommonFunctions.GetCurrentGroupUsers(null, m_selectedGroup.ID);
                ListBoxPossibleGroupUsers.ItemsSource = m_selectedGroup.PossibleGroupUsers = CommonFunctions.GetPossibleGroupUsers(null, m_selectedGroup.ID);

                TextBlockGroupUsersMessage.Visibility = Visibility.Visible;
                m_groupUsersTimer.Start();
            }
            catch (Exception ex)
            {
                TextBlockGroupUsersMessage.Visibility = Visibility.Collapsed;
                CommonFunctions.LogException(null, "WPF.DeleteGroupUsers", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Delete Group Users", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                       ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }
        }

        void ButtonAddGroupUsers_Click(object sender, RoutedEventArgs e)
        {
            SystemMessages sm;
            try
            {
                List<string> usersToBeAdded = new List<string>();
                foreach (object user in ListBoxPossibleGroupUsers.SelectedItems)
                    usersToBeAdded.Add(((User)user).ID);

                if (usersToBeAdded.Count > 0)
                    CommonFunctions.AddGroupUsers(null, m_selectedGroup.ID, usersToBeAdded);

                ListBoxCurrentGroupUsers.ItemsSource = m_selectedGroup.CurrentGroupUsers = CommonFunctions.GetCurrentGroupUsers(null, m_selectedGroup.ID);
                ListBoxPossibleGroupUsers.ItemsSource = m_selectedGroup.PossibleGroupUsers = CommonFunctions.GetPossibleGroupUsers(null, m_selectedGroup.ID);

                TextBlockGroupUsersMessage.Visibility = Visibility.Visible;
                m_groupUsersTimer.Start();
            }
            catch (Exception ex)
            {
                TextBlockGroupUsersMessage.Visibility = Visibility.Collapsed;   
                CommonFunctions.LogException(null, "WPF.AddGroupUsers", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Add Group Users", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                       ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }
        }

        #endregion

        #region " Role Management Control Event Handlers"

        void ButtonDeleteRoleGroups_Click(object sender, RoutedEventArgs e)
        {
            SystemMessages sm;
            try
            {
                List<string> groupsToBeDeleted = new List<string>();
                foreach (object group in ListBoxCurrentRoleGroups.SelectedItems)
                    groupsToBeDeleted.Add(((Group)group).ID);

                if (groupsToBeDeleted.Count > 0)
                    CommonFunctions.DeleteRoleGroups(null, m_selectedRole.ID, groupsToBeDeleted);

                ListBoxCurrentRoleGroups.ItemsSource = m_selectedRole.CurrentRoleGroups = CommonFunctions.GetCurrentRoleGroups(null, m_selectedRole.ID);
                ListBoxPossibleRoleGroups.ItemsSource = m_selectedRole.PossibleRoleGroups = CommonFunctions.GetPossibleRoleGroups(null, m_selectedRole.ID);

                TextBlockRoleGroupsMessage.Visibility = Visibility.Visible;
                m_roleGroupsTimer.Start();
            }
            catch (Exception ex)
            {
                TextBlockRoleGroupsMessage.Visibility = Visibility.Collapsed;
                CommonFunctions.LogException(null, "WPF.DeleteRoleGroups", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Delete Role Groups", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                       ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }
        }

        void ButtonAddRoleGroups_Click(object sender, RoutedEventArgs e)
        {
            SystemMessages sm;
            try
            {
                List<string> groupsToBeAdded = new List<string>();
                foreach (object group in ListBoxPossibleRoleGroups.SelectedItems)
                    groupsToBeAdded.Add(((Group)group).ID);

                if (groupsToBeAdded.Count > 0)
                    CommonFunctions.AddRoleGroups(null, m_selectedRole.ID, groupsToBeAdded);

                ListBoxCurrentRoleGroups.ItemsSource = m_selectedRole.CurrentRoleGroups = CommonFunctions.GetCurrentRoleGroups(null, m_selectedRole.ID);                
                ListBoxPossibleRoleGroups.ItemsSource = m_selectedRole.PossibleRoleGroups = CommonFunctions.GetPossibleRoleGroups(null, m_selectedRole.ID);
                
                TextBlockRoleGroupsMessage.Visibility = Visibility.Visible;
                m_roleGroupsTimer.Start();
            }
            catch (Exception ex)
            {
                TextBlockRoleGroupsMessage.Visibility = Visibility.Collapsed;
                CommonFunctions.LogException(null, "WPF.AddRoleGroups", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Add Role Groups", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                       ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }
        }

        void ButtonDeleteRoleUsers_Click(object sender, RoutedEventArgs e)
        {
            SystemMessages sm;
            try
            {
                List<string> usersToBeDeleted = new List<string>();
                foreach (object user in ListBoxCurrentRoleUsers.SelectedItems)
                    usersToBeDeleted.Add(((User)user).ID);

                if (usersToBeDeleted.Count > 0)
                    CommonFunctions.DeleteRoleUsers(null, m_selectedRole.ID, usersToBeDeleted);

                ListBoxCurrentRoleUsers.ItemsSource = m_selectedRole.CurrentRoleUsers = CommonFunctions.GetCurrentRoleUsers(null, m_selectedRole.ID);
                ListBoxPossibleRoleUsers.ItemsSource = m_selectedRole.PossibleRoleUsers = CommonFunctions.GetPossibleRoleUsers(null, m_selectedRole.ID);

                TextBlockRoleUsersMessage.Visibility = Visibility.Visible;
                m_roleUsersTimer.Start();
            }
            catch (Exception ex)
            {
                TextBlockRoleUsersMessage.Visibility = Visibility.Collapsed;
                CommonFunctions.LogException(null, "WPF.DeleteRoleUsers", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Delete Role Users", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                       ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }
        }

        void ButtonAddRoleUsers_Click(object sender, RoutedEventArgs e)
        {
            SystemMessages sm;
            try
            {
                List<string> usersToBeAdded = new List<string>();
                foreach (object user in ListBoxPossibleRoleUsers.SelectedItems)
                    usersToBeAdded.Add(((User)user).ID);

                if (usersToBeAdded.Count > 0)
                    CommonFunctions.AddRoleUsers(null, m_selectedRole.ID, usersToBeAdded);

                ListBoxCurrentRoleUsers.ItemsSource = m_selectedRole.CurrentRoleUsers = CommonFunctions.GetCurrentRoleUsers(null, m_selectedRole.ID);
                ListBoxPossibleRoleUsers.ItemsSource = m_selectedRole.PossibleRoleUsers = CommonFunctions.GetPossibleRoleUsers(null, m_selectedRole.ID);

                TextBlockRoleUsersMessage.Visibility = Visibility.Visible;
                m_roleUsersTimer.Start();
            }
            catch (Exception ex)
            {
                TextBlockRoleUsersMessage.Visibility = Visibility.Collapsed;
                CommonFunctions.LogException(null, "WPF.AddRoleUsers", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Add Role Users", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                       ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }
        }

        void ListBoxRoles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxRoles.SelectedIndex >= 0)
            {
                m_selectedRole = (Role)ListBoxRoles.SelectedItem;
                ListBoxCurrentRoleUsers.ItemsSource = m_selectedRole.CurrentRoleUsers = CommonFunctions.GetCurrentRoleUsers(null, m_selectedRole.ID);
                ListBoxCurrentRoleGroups.ItemsSource = m_selectedRole.CurrentRoleGroups = CommonFunctions.GetCurrentRoleGroups(null, m_selectedRole.ID);
                ListBoxPossibleRoleUsers.ItemsSource = m_selectedRole.PossibleRoleUsers = CommonFunctions.GetPossibleRoleUsers(null, m_selectedRole.ID);
                ListBoxPossibleRoleGroups.ItemsSource = m_selectedRole.PossibleRoleGroups = CommonFunctions.GetPossibleRoleGroups(null, m_selectedRole.ID);
                GridManageRoles.DataContext = m_selectedRole;
                m_editRoleMode = true;
                ChangeRoleUserAndGroupsVisualization();
            }
            else
                ClearRoleInformation();
        }

        void ButtonClearRole_Click(object sender, RoutedEventArgs e)
        {
            ClearRoleInformation();
        }

        #endregion

        #endregion

        #region " Methods"

        #region " User Information Methods"

        void GetUsers()
        {
            try
            {
                ListBoxUsers.ItemsSource = CommonFunctions.GetUsers(null);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetUsers", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Users", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }
        }

        void ChangeUserInfoVisualization()
        {
            if (ComboBoxAuthentication.SelectedValue.ToString() == "Windows Authentication")
            {
                TextBoxPassword.IsEnabled = false;
                TextBoxFirstName.IsEnabled = false;
                TextBoxLastName.IsEnabled = false;
                TextBoxPhone.IsEnabled = false;
                TextBoxEmail.IsEnabled = false;
                DatePickerPasswordExpiry.IsEnabled = false;
            }
            else
            {
                TextBoxPassword.IsEnabled = true;
                TextBoxFirstName.IsEnabled = true;
                TextBoxLastName.IsEnabled = true;
                TextBoxPhone.IsEnabled = true;
                TextBoxEmail.IsEnabled = true;
                DatePickerPasswordExpiry.IsEnabled = true;
            }
        }

        void ClearUserInformation()
        {
            m_selectedUser = null;
            GridManageUsers.DataContext = new User() { LockedOut = false };
            ComboBoxAuthentication.SelectedIndex = 0;
            TextBoxPassword.Password = string.Empty;
            DatePickerPasswordExpiry.SelectedDate = DateTime.Now.AddDays(90);
            ButtonSaveUser.Tag = "Add";
            m_editUserMode = false;
            ListBoxUsers.SelectedIndex = -1;
        }

        bool ValidateUserInfo()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(TextBoxUsername.Text.CleanText()))
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Username", SystemMessage = "Please provide valid username.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxUsername.Focus();
                });
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
                return isValid;
            }

            if (ComboBoxAuthentication.SelectedValue.ToString() == "Database Authentication")
            {
                //do not allow "\" in username when database authentication mode is selected as it may look like a domainname\username.
                if (TextBoxUsername.Text.Contains("\\"))
                {
                    isValid = false;
                    SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid character in Username", SystemMessage = "User name being used for database authentication appears to have a domain name prefix." + Environment.NewLine + "Avoid using \\ in the user name or switch to Windows authentication mode.", 
                        UserMessageType = MessageType.Error }, ButtonType.OkOnly);
                    sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                    {
                        TextBoxUsername.Focus();
                    });
                    sm.Owner = Window.GetWindow(this);
                    sm.ShowPopup();
                    return isValid;
                }

                //if it is a new user, then only password is required. Otherwise leave existing password as it is.
                if (!m_editUserMode && string.IsNullOrEmpty(TextBoxPassword.Password))
                {
                    isValid = false;
                    SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Password", SystemMessage = "Please provide valid Password.", UserMessageType = MessageType.Error },
                            ButtonType.OkOnly);
                    sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                    {
                        TextBoxPassword.Focus();
                    });
                    sm.Owner = Window.GetWindow(this);
                    sm.ShowPopup();
                    return isValid;
                }
                
                //Validate password only if it is provided. For user being edited, password is not always required. In edit mode password is required only if it is being changed.
                //For new user, password is always required.
                if (!string.IsNullOrEmpty(TextBoxPassword.Password) && !System.Text.RegularExpressions.Regex.IsMatch(TextBoxPassword.Password, m_strongPasswordRegex))
                {
                    isValid = false;
                    SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Password", SystemMessage = m_invalidPasswordMessage.ToString(), UserMessageType = MessageType.Error },
                            ButtonType.OkOnly);
                    sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                    {
                        TextBoxPassword.Focus();
                    });
                    sm.Owner = Window.GetWindow(this);
                    sm.ShowPopup();
                    return isValid;
                }

                if (string.IsNullOrEmpty(TextBoxFirstName.Text.CleanText()))
                {
                    isValid = false;
                    SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid First Name", SystemMessage = "Please provide valid First Name.", UserMessageType = MessageType.Error },
                            ButtonType.OkOnly);
                    sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                    {
                        TextBoxFirstName.Focus();
                    });
                    sm.Owner = Window.GetWindow(this);
                    sm.ShowPopup();
                    return isValid;
                }

                if (string.IsNullOrEmpty(TextBoxLastName.Text.CleanText()))
                {
                    isValid = false;
                    SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Last Name", SystemMessage = "Please provide valid Last Name.", UserMessageType = MessageType.Error },
                            ButtonType.OkOnly);
                    sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                    {
                        TextBoxLastName.Focus();
                    });
                    sm.Owner = Window.GetWindow(this);
                    sm.ShowPopup();
                    return isValid;
                }

                if (DatePickerPasswordExpiry.SelectedDate <= DateTime.Now)
                {
                    isValid = false;
                    SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Password Expiry Date", SystemMessage = "Please provide valid Password Expiry Date. Default is 90 days from now.", UserMessageType = MessageType.Error },
                            ButtonType.OkOnly);
                    sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                    {
                        DatePickerPasswordExpiry.SelectedDate = DateTime.Now.AddDays(90);
                    });
                    sm.Owner = Window.GetWindow(this);
                    sm.ShowPopup();
                    return isValid;
                }

            }

            return isValid;
        }

        #endregion

        #region " Group Information Methods"

        void GetGroups()
        {
            try
            {
                ListBoxGroups.ItemsSource = CommonFunctions.GetGroups(null);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetGroups", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Groups", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }
        }

        void ChangeGroupsUsersVisualization()
        {
            if (m_editGroupMode)
                GroupBoxGroupUsers.Visibility = Visibility.Visible;
            else
                GroupBoxGroupUsers.Visibility = Visibility.Collapsed;
        }

        void ClearGroupInformation()
        {
            m_selectedGroup = null;
            GridManageGroups.DataContext = new Group();
            ButtonSaveGroup.Tag = "Add";
            m_editGroupMode = false;
            ListBoxGroups.SelectedIndex = -1;
            TextBlockGroupUsersMessage.Visibility = Visibility.Collapsed;
            ChangeGroupsUsersVisualization();
        }

        bool ValidateGroupInfo()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(TextBoxGroupName.Text.CleanText()))
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Group Name", SystemMessage = "Please provide valid group name.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxGroupName.Focus();
                });
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
                return isValid;
            }

            return isValid;
        }

        #endregion

        #region " Role Information Methods"

        void GetRoles()
        {
            try
            {
                ListBoxRoles.ItemsSource = CommonFunctions.GetRoles(null, ((App)Application.Current).NodeValue);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetRoles", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Roles", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }
        }

        void ChangeRoleUserAndGroupsVisualization()
        {
            if (m_editRoleMode)
                GroupBoxRoleUsers.Visibility = GroupBoxRoleGroups.Visibility = Visibility.Visible;
            else
                GroupBoxRoleUsers.Visibility = GroupBoxRoleGroups.Visibility = Visibility.Collapsed;
        }

        void ClearRoleInformation()
        {
            m_selectedRole = null;
            GridManageRoles.DataContext = new Role();
            m_editRoleMode = false;
            ListBoxRoles.SelectedIndex = -1;
            TextBlockRoleUsersMessage.Visibility = Visibility.Collapsed;
            ChangeRoleUserAndGroupsVisualization();
        }

        #endregion

        #endregion

    }
}
