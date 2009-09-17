using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Net.NetworkInformation;

namespace openPDCManager.Silverlight
{
	public partial class MasterLayoutControl : UserControl
	{
		const double layoutRootHeight = 768;
		const double layoutRootWidth = 1024;

		public MasterLayoutControl()
		{
			InitializeComponent();			
			
			App.Current.Host.Content.Resized += new EventHandler(Content_Resized);
			GridLayoutRoot.SizeChanged += new SizeChangedEventHandler(GridLayoutRoot_SizeChanged);

			Loaded += new RoutedEventHandler(MasterLayoutControl_Loaded);
			NetworkChange.NetworkAddressChanged += new NetworkAddressChangedEventHandler(NetworkChange_NetworkAddressChanged);
			ButtonChangeMode.Click += new RoutedEventHandler(ButtonChangeMode_Click);
		}

		void GridLayoutRoot_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			
		}
		void ButtonChangeMode_Click(object sender, RoutedEventArgs e)
		{		
            if (!App.Current.IsRunningOutOfBrowser && App.Current.InstallState == InstallState.NotInstalled)
                App.Current.Install();        
		}
		void MasterLayoutControl_Loaded(object sender, RoutedEventArgs e)
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
		void Content_Resized(object sender, EventArgs e)
		{			
			//ScaleContent(Application.Current.Host.Content.ActualHeight, Application.Current.Host.Content.ActualWidth);
		}
		void ScaleContent(double height, double width)
		{			
			if (height > 0 && width > 0)
			{
				//LayoutRootScale.ScaleX = width / layoutRootWidth;
				//LayoutRootScale.ScaleY = height / layoutRootHeight;
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
			System.Diagnostics.Debug.WriteLine("SL: " + GridLayoutRoot.Height.ToString() + " - " + GridLayoutRoot.Width.ToString());
			System.Diagnostics.Debug.WriteLine("Browser: " + height.ToString() + " - " + width.ToString());
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
	}
}
