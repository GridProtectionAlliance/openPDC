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
using System.Collections.ObjectModel;

namespace openPDCManager.Silverlight.Pages.Devices
{
	public partial class Browse : Page
	{
		static string baseServiceUrl = Application.Current.Resources["BaseServiceUrl"].ToString();
		EndpointAddress address = new EndpointAddress(baseServiceUrl + "Service/PhasorDataService.svc");
		PhasorDataServiceClient client;

		ObservableCollection<Device> deviceList = new ObservableCollection<Device>();

		public Browse()
		{
			InitializeComponent();
			client = new PhasorDataServiceClient(new BasicHttpBinding(), address);
			client.GetDeviceListCompleted += new EventHandler<GetDeviceListCompletedEventArgs>(client_GetDeviceListCompleted);
			Loaded += new RoutedEventHandler(Browse_Loaded);
			ButtonSearch.Click += new RoutedEventHandler(ButtonSearch_Click);
			ButtonShowAll.Click += new RoutedEventHandler(ButtonShowAll_Click);
		}
		void ButtonShowAll_Click(object sender, RoutedEventArgs e)
		{
			ListBoxDeviceList.ItemsSource = deviceList;
		}
		void ButtonSearch_Click(object sender, RoutedEventArgs e)
		{
			string searchText = TextBoxSearch.Text.ToUpper();			
			ListBoxDeviceList.ItemsSource = (from item in deviceList
											 where item.Acronym.ToUpper().Contains(searchText) || item.Name.ToUpper().Contains(searchText) || item.ProtocolName.ToUpper().Contains(searchText)
												|| item.InterconnectionName.ToUpper().Contains(searchText) || item.CompanyName.ToUpper().Contains(searchText) || item.VendorDeviceName.ToUpper().Contains(searchText)
											 select item).ToList();
		}
		void Browse_Loaded(object sender, RoutedEventArgs e)
		{
			client.GetDeviceListAsync();	
		}
		void client_GetDeviceListCompleted(object sender, GetDeviceListCompletedEventArgs e)
		{
			if (e.Error == null)
			{
				deviceList = e.Result;
				ListBoxDeviceList.ItemsSource = deviceList;
			}
		}

		// Executes when the user navigates to this page.
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
		}

	}
}
