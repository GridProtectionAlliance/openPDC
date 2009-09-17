//*******************************************************************************************************
//  LayoutContainer.xaml.cs
//  Copyright © 2009 - TVA, all rights reserved - Gbtc
//
//  Build Environment: C#, Visual Studio 2008
//  Primary Developer: Mehul P. Thakkar
//      Office: INFO SVCS APP DEV, CHATTANOOGA - MR BK-C
//       Phone: 423/751-7571
//       Email: mpthakka@tva.gov
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  07/05/2009 - Mehul P. Thakkar
//       Generated original version of source code.
//
//*******************************************************************************************************

using System;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace openPDCManager.Silverlight
{
    public partial class LayoutContainer : UserControl
    {
		const double layoutRootHeight = 875;
		const double layoutRootWidth = 1200;
        public LayoutContainer()
        {
            InitializeComponent();
			ScaleContent(Application.Current.Host.Content.ActualHeight, Application.Current.Host.Content.ActualWidth);
			Application.Current.Host.Content.Resized += new EventHandler(Content_Resized);
            Loaded += new RoutedEventHandler(LayoutContainer_Loaded);
            NetworkChange.NetworkAddressChanged += new NetworkAddressChangedEventHandler(NetworkChange_NetworkAddressChanged);
        }
		void Content_Resized(object sender, EventArgs e)
		{
			ScaleContent(Application.Current.Host.Content.ActualHeight, Application.Current.Host.Content.ActualWidth);
		}
		void ScaleContent(double height, double width)
		{			
			if (height > 0 && width > 0)
			{
				if (height / layoutRootHeight < width / layoutRootWidth)
				{
					LayoutRootScale.ScaleX = height / layoutRootHeight;
					LayoutRootScale.ScaleY = height / layoutRootHeight;
				}
				else
				{
					LayoutRootScale.ScaleX = width / layoutRootWidth;
					LayoutRootScale.ScaleY = width / layoutRootWidth;
				}
			}
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
        void LayoutContainer_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.Current.IsRunningOutOfBrowser)
            {
                TextBlockExecutionMode.Text = "Out of Browser";
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
        private void ButtonChangeMode_Click(object sender, RoutedEventArgs e)
        {
            if (!App.Current.IsRunningOutOfBrowser && App.Current.InstallState == InstallState.NotInstalled)
                App.Current.Install();
        }
    }
}
