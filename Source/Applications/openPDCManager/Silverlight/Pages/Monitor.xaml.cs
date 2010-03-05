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
using System.Windows.Navigation;
using openPDCManager.Silverlight.LivePhasorDataServiceProxy;
using openPDCManager.Silverlight.Utilities;
using openPDCManager.Silverlight.ModalDialogs;

namespace openPDCManager.Silverlight.Pages
{
	public partial class Monitor : Page
	{
		DuplexServiceClient m_duplexClient;
		bool m_connected = false;
		ActivityWindow m_activityWindow;

		public Monitor()
		{
			InitializeComponent();
			this.Loaded += new RoutedEventHandler(Monitor_Loaded);
			m_duplexClient = Common.GetDuplexServiceProxyClient();
			m_duplexClient.SendToServiceCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(m_duplexClient_SendToServiceCompleted);
			m_duplexClient.SendToClientReceived += new EventHandler<SendToClientReceivedEventArgs>(m_duplexClient_SendToClientReceived);
			ButtonSendServiceRequest.Click += new RoutedEventHandler(ButtonSendServiceRequest_Click);
		}

		void ButtonSendServiceRequest_Click(object sender, RoutedEventArgs e)
		{
			Storyboard sb = new Storyboard();
			sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
			sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
			Storyboard.SetTarget(sb, ButtonSendServiceRequestTransform);
			sb.Begin();

			if (!string.IsNullOrEmpty(TextBoxServiceRequest.Text))
			{
				ServiceRequestMessage message = new ServiceRequestMessage() { Request = TextBoxServiceRequest.Text };
				m_duplexClient.SendToServiceAsync(message);
			}
		}

		void m_duplexClient_SendToClientReceived(object sender, SendToClientReceivedEventArgs e)
		{
			if (e.msg is ServiceUpdateMessage)
			{
				//TextBoxServiceStatus.Text += ((ServiceUpdateMessage)e.msg).ServiceUpdate;

				if (((ServiceUpdateMessage)e.msg).ServiceUpdateType == UpdateType.Information)
				{
					//	TextBoxServiceStatus.Text += ((ServiceUpdateMessage)e.msg).ServiceUpdate;
					Run run = new Run();
					run.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
					run.Text = ((ServiceUpdateMessage)e.msg).ServiceUpdate;
					TextBoxServiceStatus.Inlines.Add(run);
				}
				else if (((ServiceUpdateMessage)e.msg).ServiceUpdateType == UpdateType.Warning)
				{
					Run run = new Run();
					run.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 0));
					run.Text = ((ServiceUpdateMessage)e.msg).ServiceUpdate;
					TextBoxServiceStatus.Inlines.Add(run);
				}
				else
				{
					Run run = new Run();
					run.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 10, 10));
					run.Text = ((ServiceUpdateMessage)e.msg).ServiceUpdate;
					TextBoxServiceStatus.Inlines.Add(run);
				}
			}

			ScrollViewerMonitor.ScrollToVerticalOffset(TextBoxServiceStatus.ActualHeight);

			if (TextBoxServiceStatus.Text.Length > 8000)
				TextBoxServiceStatus.Inlines.RemoveAt(0);

				//TextBoxServiceStatus.Text = TextBoxServiceStatus.Text.Substring(TextBoxServiceStatus.Text.Length - 5000);

			ScrollViewerMonitor.ScrollToVerticalOffset(TextBoxServiceStatus.ActualHeight);

			if (m_activityWindow != null)
				m_activityWindow.Close();
		}

		void m_duplexClient_SendToServiceCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
		{
			if (e.Error == null)
				m_connected = true;
		}

		void Monitor_Loaded(object sender, RoutedEventArgs e)
		{
			ReconnectToService();			
		}

		void ReconnectToService()
		{
			ConnectMessage msg = new ConnectMessage();
			msg.NodeID = ((App)Application.Current).NodeValue;
			msg.TimeSeriesDataRootUrl = ((App)Application.Current).TimeSeriesDataServiceUrl;	// "http://localhost:6152/historian/timeseriesdata/read/";			
			msg.CurrentDisplayType = DisplayType.ServiceClient;
			msg.DataPointID = 0;
			m_duplexClient.SendToServiceAsync(msg);
		}

		// Executes when the user navigates to this page.
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			m_activityWindow = new ActivityWindow("Connecting to Windows Service... Please Wait...");
			m_activityWindow.Show();
		}

		// Executes just before a page is no longer the active page in a frame.
		protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
		{
			if (m_connected)
				m_duplexClient.SendToServiceAsync(new DisconnectMessage());
			base.OnNavigatingFrom(e);
		}

	}
}
