using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using openPDCManager.Silverlight.PhasorDataServiceProxy;

namespace openPDCManager.Silverlight.Pages.Manage
{
	public partial class VendorDevices : Page
	{
		static string baseServiceUrl = Application.Current.Resources["BaseServiceUrl"].ToString();
		EndpointAddress address = new EndpointAddress(baseServiceUrl + "Service/PhasorDataService.svc");
		PhasorDataServiceClient client;

		bool inEditMode = false;
		int vendorDeviceID = 0;

		public VendorDevices()
		{
			InitializeComponent();
			client = new PhasorDataServiceClient(new BasicHttpBinding(), address);
			client.GetVendorDeviceListCompleted += new EventHandler<GetVendorDeviceListCompletedEventArgs>(client_GetVendorDeviceListCompleted);
			client.GetVendorsCompleted += new EventHandler<GetVendorsCompletedEventArgs>(client_GetVendorsCompleted);
			client.SaveVendorDeviceCompleted += new EventHandler<SaveVendorDeviceCompletedEventArgs>(client_SaveVendorDeviceCompleted);
			Loaded += new RoutedEventHandler(VendorDevices_Loaded);
			ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
			ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
			ListBoxVendorDeviceList.SelectionChanged += new SelectionChangedEventHandler(ListBoxVendorDeviceList_SelectionChanged);
		}
		void client_SaveVendorDeviceCompleted(object sender, SaveVendorDeviceCompletedEventArgs e)
		{
			if (e.Error == null)
				MessageBox.Show(e.Result);
			client.GetVendorDeviceListAsync(); //Refresh data to reflect changes on the current screen.
		}
		void ListBoxVendorDeviceList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (ListBoxVendorDeviceList.SelectedIndex >= 0)
			{
				VendorDevice selectedVendorDevice = ListBoxVendorDeviceList.SelectedItem as VendorDevice;
				GridVendorDeviceDetail.DataContext = selectedVendorDevice;
				ComboBoxVendor.SelectedItem = new KeyValuePair<int, string>(selectedVendorDevice.VendorID, selectedVendorDevice.VendorName);
				vendorDeviceID = selectedVendorDevice.ID;
				inEditMode = true;
			}
		}
		void ButtonClear_Click(object sender, RoutedEventArgs e)
		{
			ClearForm();
		}
		void ButtonSave_Click(object sender, RoutedEventArgs e)
		{
			VendorDevice vendorDevice = new VendorDevice();
			KeyValuePair<int, string> selectedVendor = (KeyValuePair<int, string>)ComboBoxVendor.SelectedItem;
			vendorDevice.VendorID = selectedVendor.Key;
			vendorDevice.Name = TextBoxName.Text;
			vendorDevice.Description = TextBoxDescription.Text;
			vendorDevice.URL = TextBoxUrl.Text;

			if (vendorDeviceID != 0 && inEditMode == true)
			{
				vendorDevice.ID = vendorDeviceID;
				client.SaveVendorDeviceAsync(vendorDevice, false);
			}
			else
				client.SaveVendorDeviceAsync(vendorDevice, true);
		}
		void VendorDevices_Loaded(object sender, RoutedEventArgs e)
		{
			client.GetVendorsAsync();
			client.GetVendorDeviceListAsync();
		}
		void client_GetVendorsCompleted(object sender, GetVendorsCompletedEventArgs e)
		{
			if (e.Error == null)
				ComboBoxVendor.ItemsSource = e.Result;
			if (ComboBoxVendor.Items.Count > 0)
				ComboBoxVendor.SelectedIndex = 0;
		}
		void client_GetVendorDeviceListCompleted(object sender, GetVendorDeviceListCompletedEventArgs e)
		{
			if (e.Error == null)
				ListBoxVendorDeviceList.ItemsSource = e.Result;
		}
		void ClearForm()
		{
			if (ComboBoxVendor.Items.Count > 0)
				ComboBoxVendor.SelectedIndex = 0;
			GridVendorDeviceDetail.DataContext = new VendorDevice();	//Bind an empty element.	
			inEditMode = false;
			vendorDeviceID = 0;
			ListBoxVendorDeviceList.SelectedIndex = -1;
		}

		// Executes when the user navigates to this page.
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
		}

	}
}
