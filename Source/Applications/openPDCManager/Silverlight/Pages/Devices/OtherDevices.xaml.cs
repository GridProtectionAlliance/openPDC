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
	public partial class OtherDevices : Page
	{
		static string baseServiceUrl = Application.Current.Resources["BaseServiceUrl"].ToString();
		EndpointAddress address = new EndpointAddress(baseServiceUrl + "Service/PhasorDataService.svc");
		PhasorDataServiceClient client;

		ObservableCollection<OtherDevice> otherDeviceList = new ObservableCollection<OtherDevice>();
		
		public OtherDevices()
		{
			InitializeComponent();
			client = new PhasorDataServiceClient(new BasicHttpBinding(), address);
			client.GetOtherDeviceListCompleted += new EventHandler<GetOtherDeviceListCompletedEventArgs>(client_GetOtherDeviceListCompleted);
			Loaded += new RoutedEventHandler(OtherDevices_Loaded);
			ButtonSearch.Click += new RoutedEventHandler(ButtonSearch_Click);
			ButtonShowAll.Click += new RoutedEventHandler(ButtonShowAll_Click);
		}
		void ButtonShowAll_Click(object sender, RoutedEventArgs e)
		{
			ListBoxOtherDeviceList.ItemsSource = otherDeviceList;
		}
		void ButtonSearch_Click(object sender, RoutedEventArgs e)
		{
			string searchText = TextBoxSearch.Text.ToUpper();
			ListBoxOtherDeviceList.ItemsSource = (from item in otherDeviceList
											 where item.Acronym.ToUpper().Contains(searchText) || item.Name.ToUpper().Contains(searchText) || item.InterconnectionName.ToUpper().Contains(searchText) 
													|| item.CompanyName.ToUpper().Contains(searchText) || item.VendorDeviceName.ToUpper().Contains(searchText)
											 select item).ToList();
		}
		void OtherDevices_Loaded(object sender, RoutedEventArgs e)
		{
			client.GetOtherDeviceListAsync();	
		}
		void client_GetOtherDeviceListCompleted(object sender, GetOtherDeviceListCompletedEventArgs e)
		{
			if (e.Error == null)
			{
				otherDeviceList = e.Result;
				ListBoxOtherDeviceList.ItemsSource = otherDeviceList;
			}
		}

		// Executes when the user navigates to this page.
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
		}

	}
}
