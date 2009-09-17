//<copyright>
//
//</copyright>

using System;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using openPDCManager.Silverlight.PhasorDataServiceProxy;

namespace openPDCManager.Silverlight.Pages.Manage
{
	public partial class Vendors : Page
	{
		static string baseServiceUrl = Application.Current.Resources["BaseServiceUrl"].ToString();
		EndpointAddress address = new EndpointAddress(baseServiceUrl + "Service/PhasorDataService.svc");
		PhasorDataServiceClient client;

		bool inEditMode = false;
		int vendorID = 0;

		public Vendors()
		{
			InitializeComponent();
			client = new PhasorDataServiceClient(new BasicHttpBinding(), address);
			client.GetVendorListCompleted += new EventHandler<GetVendorListCompletedEventArgs>(client_GetVendorListCompleted);
			client.SaveVendorCompleted += new EventHandler<SaveVendorCompletedEventArgs>(client_SaveVendorCompleted);
			Loaded += new RoutedEventHandler(Vendors_Loaded);
			ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
			ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
			ListBoxVendorList.SelectionChanged += new SelectionChangedEventHandler(ListBoxVendorList_SelectionChanged);
		}
		void client_SaveVendorCompleted(object sender, SaveVendorCompletedEventArgs e)
		{
			if (e.Error == null)
				MessageBox.Show(e.Result);
			client.GetVendorListAsync();	//Refresh data to reflect changes on the current screen.
		}
		void ListBoxVendorList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (ListBoxVendorList.SelectedIndex >= 0)
			{
				Vendor selectedVendor = ListBoxVendorList.SelectedItem as Vendor;
				GridVendorDetail.DataContext = selectedVendor;
				inEditMode = true;
				vendorID = selectedVendor.ID;
			}
		}
		void ButtonSave_Click(object sender, RoutedEventArgs e)
		{
			Vendor vendor = new Vendor();			
			vendor.Acronym = TextBoxAcronym.Text;
			vendor.Name = TextBoxName.Text;
			vendor.PhoneNumber = TextBoxPhoneNumber.Text;
			vendor.ContactEmail = TextBoxContactEmail.Text;
			vendor.URL = TextBoxUrl.Text;

			if (vendorID != 0 && inEditMode == true)		//i.e. It is an update to existing item.
			{
				vendor.ID = vendorID;
				client.SaveVendorAsync(vendor, false);
			}
			else	//i.e. It is a new item			
				client.SaveVendorAsync(vendor, true);			
		}
		void ButtonClear_Click(object sender, RoutedEventArgs e)
		{
			ClearForm();
		}
		void Vendors_Loaded(object sender, RoutedEventArgs e)
		{
			client.GetVendorListAsync();
		}
		void client_GetVendorListCompleted(object sender, GetVendorListCompletedEventArgs e)
		{
			if (e.Error == null)
				ListBoxVendorList.ItemsSource = e.Result;
		}
		void ClearForm()
		{
			GridVendorDetail.DataContext = new Vendor();		//this is done to clear all the textboxes and to retain binding information. Please do not set empty strings as textboxes' vaues.
			inEditMode = false;
			vendorID = 0;
			ListBoxVendorList.SelectedIndex = -1;
		}

		// Executes when the user navigates to this page.
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
		}

	}
}
