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
using System.ServiceModel;
using openPDCManager.Silverlight.PhasorDataServiceProxy;

namespace openPDCManager.Silverlight.Pages
{
	public partial class StatusReport : Page
	{
		static string baseServiceUrl = Application.Current.Resources["BaseServiceUrl"].ToString();
		EndpointAddress address = new EndpointAddress(baseServiceUrl + "Service/PhasorDataService.svc");
		BasicHttpBinding binding = new BasicHttpBinding();
		PhasorDataServiceClient client;

		public StatusReport()
		{
			InitializeComponent();
			binding.MaxReceivedMessageSize = 65536 * 3;
			client = new PhasorDataServiceClient(binding, address);
			//client.GetStatusReportListCompleted += new EventHandler<GetStatusReportListCompletedEventArgs>(client_GetStatusReportListCompleted);
			//client.GetStatusReportListAsync();
		}
		//void client_GetStatusReportListCompleted(object sender, GetStatusReportListCompletedEventArgs e)
		//{
		//    if (e.Error == null)
		//        ItemControlCompanyStatus.ItemsSource = e.Result;
		//}
		// Executes when the user navigates to this page.
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
		}
	}
}
