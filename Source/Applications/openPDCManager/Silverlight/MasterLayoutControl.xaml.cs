//******************************************************************************************************
//  MasterLayoutControl.xaml.cs - Gbtc
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
//  09/28/2009 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using openPDCManager.PhasorDataServiceProxy;
//using openPDCManager.UserControls;
using openPDCManager.UserControls.CommonControls;
using openPDCManager.Utilities;

namespace openPDCManager
{
	public partial class MasterLayoutControl : UserControl
	{
		#region [ Members ]

		const double layoutRootHeight = 900;
		const double layoutRootWidth = 1200;

		#endregion

		#region [ Constructor ]

		public MasterLayoutControl()
		{
			InitializeComponent();			
			
			App.Current.Host.Content.Resized += new EventHandler(Content_Resized);
			
			Loaded += new RoutedEventHandler(MasterLayoutControl_Loaded);
			NetworkChange.NetworkAddressChanged += new NetworkAddressChangedEventHandler(NetworkChange_NetworkAddressChanged);
			ButtonChangeMode.Click += new RoutedEventHandler(ButtonChangeMode_Click);
			UserControlSelectNode.NodeCollectionChanged += new SelectNode.OnNodesChanged(UserControlSelectNode_NodeCollectionChanged);
			UserControlSelectNode.ComboboxNode.SelectionChanged += new SelectionChangedEventHandler(ComboboxNode_SelectionChanged);            
            ContentFrame.Navigating += new System.Windows.Navigation.NavigatingCancelEventHandler(ContentFrame_Navigating);
            //ContentFrame.Navigated += new System.Windows.Navigation.NavigatedEventHandler(ContentFrame_Navigated);
		}              

		#endregion

		#region [ Control Event Handlers ]

		void ComboboxNode_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (UserControlSelectNode.ComboboxNode.SelectedItem != null)
				TextBlockNode.Text = ((Node)UserControlSelectNode.ComboboxNode.SelectedItem).Name;
				
				//TextBlockNode.Text = ((KeyValuePair<string, string>)UserControlSelectNode.ComboboxNode.SelectedItem).Value;

			Uri homeUri = new Uri("/Pages/HomePage.xaml", UriKind.Relative);
			ContentFrame.Navigate(homeUri);			
		}

		void UserControlSelectNode_NodeCollectionChanged(object sender, RoutedEventArgs e)
		{
			(sender as SelectNode).RefreshNodeList();			
		}
				
		void ButtonChangeMode_Click(object sender, RoutedEventArgs e)
		{		
            if (!App.Current.IsRunningOutOfBrowser && App.Current.InstallState == InstallState.NotInstalled)
                App.Current.Install();
		}

		void XamWebMenuItem_Click(object sender, EventArgs e)
		{
			System.Windows.Browser.HtmlPage.Window.Navigate(new Uri("http://openpdc.codeplex.com/wikipage?title=Manager%20Configuration"), "_blank");
		}

        //void HyperlinkButtonMonitor_Click(object sender, RoutedEventArgs e)
        //{
        //    ContentFrame.Navigate(new Uri("/Pages/Monitor.xaml", UriKind.Relative));
        //}

		#endregion

		#region [ Page Event Handlers ]

		void MasterLayoutControl_Loaded(object sender, RoutedEventArgs e)
		{
			if (App.Current.IsRunningOutOfBrowser)
			{
				TextBlockExecutionMode.Text = "Out of Browser";
				//Application.Current.Resources["BaseServiceUrl"] = "http://localhost:1068/";
			}
			else
			{
				TextBlockExecutionMode.Text = "In Browser";
			}
			if (NetworkInterface.GetIsNetworkAvailable())
			{
				TextBlockConnectivity.Text = "Connected (online)";
				TextBlockConnectivity.Foreground = new SolidColorBrush(Colors.Cyan);
			}
			else
			{
				TextBlockConnectivity.Text = "Disconnected (offline)";
				TextBlockConnectivity.Foreground = new SolidColorBrush(Colors.Red);
			}			
		}
		
		void Content_Resized(object sender, EventArgs e)
		{	
			ScaleContent(Application.Current.Host.Content.ActualHeight, Application.Current.Host.Content.ActualWidth);
		}

		void NetworkChange_NetworkAddressChanged(object sender, EventArgs e)
		{
			if (NetworkInterface.GetIsNetworkAvailable())
			{
				TextBlockConnectivity.Text = "Connected (online)";
				TextBlockConnectivity.Foreground = new SolidColorBrush(Colors.Green);
			}
			else
			{
				TextBlockConnectivity.Text = "Disconnected (offline)";
				TextBlockConnectivity.Foreground = new SolidColorBrush(Colors.Red);
			}
		}

        void ContentFrame_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            App app = Application.Current as App;
            if (string.IsNullOrEmpty(app.NodeValue))
            {
                Uri nodeUri = new Uri("/Pages/Manage/Nodes.xaml", UriKind.Relative);
                if (e.Uri != nodeUri)
                {
                    e.Cancel = true;
                    ContentFrame.Navigate(nodeUri);
                }
            }
        }
        

		#endregion

		#region [ Methods ]

		void ScaleContent(double height, double width)
		{
            if ((bool)IsolatedStorageManager.LoadFromIsolatedStorage("MaintainAspectRatio"))
                StackPanelRoot.HorizontalAlignment = HorizontalAlignment.Center;
            else
                StackPanelRoot.HorizontalAlignment = HorizontalAlignment.Left;

			double defaultHeight = IsolatedStorageManager.LoadFromIsolatedStorage("DefaultHeight") == null ? layoutRootHeight : Convert.ToDouble(IsolatedStorageManager.LoadFromIsolatedStorage("DefaultHeight"));
			double defaultWidth = IsolatedStorageManager.LoadFromIsolatedStorage("DefaultWidth") == null ? layoutRootWidth : Convert.ToDouble(IsolatedStorageManager.LoadFromIsolatedStorage("DefaultWidth"));
			double minimumHeight = IsolatedStorageManager.LoadFromIsolatedStorage("MinimumHeight") == null ? 600 : Convert.ToDouble(IsolatedStorageManager.LoadFromIsolatedStorage("MinimumHeight"));
			double minimumWidth = IsolatedStorageManager.LoadFromIsolatedStorage("MinimumWidth") == null ? 800 : Convert.ToDouble(IsolatedStorageManager.LoadFromIsolatedStorage("MinimumWidth"));
			
			if (height == 0) height = defaultHeight; //If for some reason, we dont get actual height and width then use default values.
			if (width == 0) width = defaultWidth;

			//if set to resize with browser then use actual height and width of the browser passed in the method parameters.
			if (IsolatedStorageManager.LoadFromIsolatedStorage("ResizeWithBrowser") != null && (bool)IsolatedStorageManager.LoadFromIsolatedStorage("ResizeWithBrowser"))
			{				
				if (IsolatedStorageManager.LoadFromIsolatedStorage("MaintainAspectRatio") != null && (bool)IsolatedStorageManager.LoadFromIsolatedStorage("MaintainAspectRatio"))
				{
					if (height / layoutRootHeight <= width / layoutRootWidth)
					{
						if (height < minimumHeight) height = minimumHeight;
						LayoutRootScale.ScaleX = 0.98 * (height / layoutRootHeight);
						LayoutRootScale.ScaleY = 0.98 * (height / layoutRootHeight);
					}
					else
					{
						if (width < minimumWidth) width = minimumWidth;
						LayoutRootScale.ScaleX = 0.98 * (width / layoutRootWidth);
						LayoutRootScale.ScaleY = 0.98 * (width / layoutRootWidth);
					}
				}
				else
				{
					if (height < minimumHeight) height = minimumHeight;
					if (width < minimumWidth) width = minimumWidth;
					LayoutRootScale.ScaleX = 0.98 * (width / layoutRootWidth);
					LayoutRootScale.ScaleY = 0.98 * (height / layoutRootHeight);
				}
			}
			else	// if set not to resize with browser then, use default height and width to scale
			{
				if (defaultWidth < minimumWidth) defaultWidth = minimumWidth;
				if (defaultHeight < minimumHeight) defaultHeight = minimumHeight;
			
				LayoutRootScale.ScaleX = 0.98 * (defaultWidth / layoutRootWidth);
				LayoutRootScale.ScaleY = 0.98 * (defaultHeight / layoutRootHeight);				
			}
		}

		#endregion
		
	}
}
