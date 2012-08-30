//******************************************************************************************************
//  SystemSettings.xaml.cs - Gbtc
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
//  04/09/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;

namespace openPDCManager.Pages.Manage
{
	public partial class SystemSettings : Page
	{
		#region [ Constructor ]

		public SystemSettings()
		{
			InitializeComponent();
			this.Loaded += new RoutedEventHandler(SystemSettings_Loaded);
			ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
			ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
		}

		#endregion

		#region [ Controls Event Handlers ]

		void ButtonClear_Click(object sender, RoutedEventArgs e)
		{
			Storyboard sb = new Storyboard();
			sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
			sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
			Storyboard.SetTarget(sb, ButtonClearTransform);
			sb.Begin();

			//Load Default Settings.
			ProxyClient.SetDefaultSystemSettings(true);
			LoadSettingsFromIsolatedStorage();

			SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Successfully Restored Default System Settings", SystemMessage = string.Empty, UserMessageType = MessageType.Success },
						ButtonType.OkOnly);			
			sm.ShowPopup();
		}

		void ButtonSave_Click(object sender, RoutedEventArgs e)
		{
			Storyboard sb = new Storyboard();
			sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
			sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
			Storyboard.SetTarget(sb, ButtonSaveTransform);
			sb.Begin();

			if (!string.IsNullOrEmpty(TextBoxDefaultWidth.Text))
				IsolatedStorageManager.SaveIntoIsolatedStorage("DefaultWidth", Convert.ToInt32(TextBoxDefaultWidth.Text));
			
			if (!string.IsNullOrEmpty(TextBoxDefaultHeight.Text))
				IsolatedStorageManager.SaveIntoIsolatedStorage("DefaultHeight", Convert.ToInt32(TextBoxDefaultHeight.Text));
			
			if (!string.IsNullOrEmpty(TextBoxMinimumWidth.Text))
				IsolatedStorageManager.SaveIntoIsolatedStorage("MinimumWidth", Convert.ToInt32(TextBoxMinimumWidth.Text));
			
			if (!string.IsNullOrEmpty(TextBoxMinimumHeight.Text))
				IsolatedStorageManager.SaveIntoIsolatedStorage("MinimumHeight", Convert.ToInt32(TextBoxMinimumHeight.Text));
			
			IsolatedStorageManager.SaveIntoIsolatedStorage("ResizeWithBrowser", CheckboxResizeWithBrowser.IsChecked);
			
			IsolatedStorageManager.SaveIntoIsolatedStorage("MaintainAspectRatio", CheckboxMaintainAspectRatio.IsChecked);

            IsolatedStorageManager.SaveIntoIsolatedStorage("ForceIPv4", CheckboxForceIPv4.IsChecked);

			if (!string.IsNullOrEmpty(TextBoxNumberOfMessagesOnMonitor.Text))
				IsolatedStorageManager.SaveIntoIsolatedStorage("NumberOfMessagesOnMonitor", Convert.ToInt32(TextBoxNumberOfMessagesOnMonitor.Text));

			LoadSettingsFromIsolatedStorage();

			SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Successfully Saved System Settings", SystemMessage = string.Empty, UserMessageType = MessageType.Success },
						ButtonType.OkOnly);
			sm.ShowPopup();
		}

		#endregion

		#region [ Page Event Handlers ]

		void SystemSettings_Loaded(object sender, RoutedEventArgs e)
		{
			LoadSettingsFromIsolatedStorage();
		}

		// Executes when the user navigates to this page.
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
		}

		#endregion

		#region [ Methods ]

		void LoadSettingsFromIsolatedStorage()
		{
			TextBoxDefaultWidth.Text = IsolatedStorageManager.LoadFromIsolatedStorage("DefaultWidth").ToString();
			TextBoxDefaultHeight.Text = IsolatedStorageManager.LoadFromIsolatedStorage("DefaultHeight").ToString();
			TextBoxMinimumWidth.Text = IsolatedStorageManager.LoadFromIsolatedStorage("MinimumWidth").ToString();
			TextBoxMinimumHeight.Text = IsolatedStorageManager.LoadFromIsolatedStorage("MinimumHeight").ToString();
			TextBoxNumberOfMessagesOnMonitor.Text = IsolatedStorageManager.LoadFromIsolatedStorage("NumberOfMessagesOnMonitor").ToString();
			CheckboxResizeWithBrowser.IsChecked = (bool)IsolatedStorageManager.LoadFromIsolatedStorage("ResizeWithBrowser");
			CheckboxMaintainAspectRatio.IsChecked = (bool)IsolatedStorageManager.LoadFromIsolatedStorage("MaintainAspectRatio");
            CheckboxForceIPv4.IsChecked = (bool)IsolatedStorageManager.LoadFromIsolatedStorage("ForceIPv4");
		}

		#endregion
	}
}
