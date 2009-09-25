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

namespace openPDCManager.Silverlight.Pages.Devices
{
	public partial class ManageOtherDevices : Page
	{
		static string baseServiceUrl = Application.Current.Resources["BaseServiceUrl"].ToString();
		EndpointAddress address = new EndpointAddress(baseServiceUrl + "Service/PhasorDataService.svc");
		PhasorDataServiceClient client;

		public ManageOtherDevices()
		{
			InitializeComponent();
			client = new PhasorDataServiceClient(new BasicHttpBinding(), address);
			Loaded += new RoutedEventHandler(ManageOtherDevices_Loaded);
			client.GetCompaniesCompleted += new EventHandler<GetCompaniesCompletedEventArgs>(client_GetCompaniesCompleted);
			client.GetVendorDevicesCompleted += new EventHandler<GetVendorDevicesCompletedEventArgs>(client_GetVendorDevicesCompleted);
			client.GetInterconnectionsCompleted += new EventHandler<GetInterconnectionsCompletedEventArgs>(client_GetInterconnectionsCompleted);
			ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
			ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
		}
		void ButtonClear_Click(object sender, RoutedEventArgs e)
		{
			
		}
		void ButtonSave_Click(object sender, RoutedEventArgs e)
		{
		
		}
		void client_GetInterconnectionsCompleted(object sender, GetInterconnectionsCompletedEventArgs e)
		{
			if (e.Error == null)
				ComboboxInterconnection.ItemsSource = e.Result;
			if (ComboboxInterconnection.Items.Count > 0)
				ComboboxInterconnection.SelectedIndex = 0;
		}
		void client_GetVendorDevicesCompleted(object sender, GetVendorDevicesCompletedEventArgs e)
		{
			if (e.Error == null)
				ComboboxVendorDevice.ItemsSource = e.Result;
			if (ComboboxVendorDevice.Items.Count > 0)
				ComboboxVendorDevice.SelectedIndex = 0;
		}
		void client_GetCompaniesCompleted(object sender, GetCompaniesCompletedEventArgs e)
		{
			if (e.Error == null)
				ComboboxCompany.ItemsSource = e.Result;
			if (ComboboxCompany.Items.Count > 0)
				ComboboxCompany.SelectedIndex = 0;
		}
		void ManageOtherDevices_Loaded(object sender, RoutedEventArgs e)
		{
			client.GetCompaniesAsync(true);
			client.GetVendorDevicesAsync(true);
			client.GetInterconnectionsAsync(true);
		}

		// Executes when the user navigates to this page.
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
		}

	}
}
