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
	public partial class AddNew : Page
	{
		static string baseServiceUrl = Application.Current.Resources["BaseServiceUrl"].ToString();
		EndpointAddress address = new EndpointAddress(baseServiceUrl + "Service/PhasorDataService.svc");
		PhasorDataServiceClient client;

		public AddNew()
		{
			InitializeComponent();
			Loaded += new RoutedEventHandler(AddNew_Loaded);
			client = new PhasorDataServiceClient(new BasicHttpBinding(), address);
			client.GetDevicesCompleted += new EventHandler<GetDevicesCompletedEventArgs>(client_GetDevicesCompleted);
			client.GetCompaniesCompleted += new EventHandler<GetCompaniesCompletedEventArgs>(client_GetCompaniesCompleted);
			client.GetNodesCompleted += new EventHandler<GetNodesCompletedEventArgs>(client_GetNodesCompleted);
			client.GetHistoriansCompleted += new EventHandler<GetHistoriansCompletedEventArgs>(client_GetHistoriansCompleted);
			client.GetInterconnectionsCompleted += new EventHandler<GetInterconnectionsCompletedEventArgs>(client_GetInterconnectionsCompleted);
			client.GetVendorDevicesCompleted += new EventHandler<GetVendorDevicesCompletedEventArgs>(client_GetVendorDevicesCompleted);
			client.GetProtocolsCompleted += new EventHandler<GetProtocolsCompletedEventArgs>(client_GetProtocolsCompleted);
			client.GetTimeZonesCompleted += new EventHandler<GetTimeZonesCompletedEventArgs>(client_GetTimeZonesCompleted);
			client.SaveDeviceCompleted += new EventHandler<SaveDeviceCompletedEventArgs>(client_SaveDeviceCompleted);
			ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
			ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
		}

		void client_SaveDeviceCompleted(object sender, SaveDeviceCompletedEventArgs e)
		{
			if (e.Error == null)
				MessageBox.Show("Done!");
			else
				MessageBox.Show(e.Error.Message);
		}
		void ButtonClear_Click(object sender, RoutedEventArgs e)
		{
			ClearForm();
		}
		void ButtonSave_Click(object sender, RoutedEventArgs e)
		{
			Device device = new Device();
			device.NodeID = ((KeyValuePair<Guid, string>)ComboboxNode.SelectedItem).Key;
			device.ParentID = ((KeyValuePair<int, string>)ComboboxParent.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboboxParent.SelectedItem).Key;
			device.Acronym = TextBoxAcronym.Text;
			device.Name = TextBoxName.Text;
			device.IsConcentrator = (bool)CheckboxConcentrator.IsChecked;
			device.CompanyID = ((KeyValuePair<int, string>)ComboboxCompany.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboboxCompany.SelectedItem).Key;
			device.HistorianID = ((KeyValuePair<int, string>)ComboboxHistorian.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboboxHistorian.SelectedItem).Key;
			device.AccessID = Convert.ToInt32(TextBoxAccessID.Text);
			device.VendorDeviceID = ((KeyValuePair<int, string>)ComboboxVendorDevice.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboboxVendorDevice.SelectedItem).Key;
			device.ProtocolID = ((KeyValuePair<int, string>)ComboboxProtocol.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboboxProtocol.SelectedItem).Key;
			device.Longitude = string.IsNullOrEmpty(TextBoxLongitude.Text) ? (decimal?)null : Convert.ToDecimal(TextBoxLongitude.Text);
			device.Latitude = string.IsNullOrEmpty(TextBoxLatitude.Text) ? (decimal?)null : Convert.ToDecimal(TextBoxLatitude.Text);
			device.InterconnectionID = ((KeyValuePair<int, string>)ComboboxInterconnection.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboboxInterconnection.SelectedItem).Key;
			device.ConncetionString = TextBoxConnectionString.Text;
			device.TimeZone = ComboboxTimeZone.SelectedIndex == 0 ? string.Empty : ComboboxTimeZone.SelectedItem.ToString();
			device.TimeAdjustmentTicks = Convert.ToInt64(TextBoxTimeAdjustmentTicks.Text);
			device.DataLossInterval = Convert.ToDouble(TextBoxDataLossInterval.Text);
			device.ContactList = TextBoxContactList.Text;
			device.MeasuredLines = string.IsNullOrEmpty(TextBoxMeasuredLines.Text) ? (int?)null : Convert.ToInt32(TextBoxMeasuredLines.Text);
			device.LoadOrder = Convert.ToInt32(TextBoxLoadOrder.Text);
			device.Enabled = (bool)CheckboxEnabled.IsChecked;
			client.SaveDeviceAsync(device, true);
		}
		void client_GetTimeZonesCompleted(object sender, GetTimeZonesCompletedEventArgs e)
		{
			if (e.Error == null)
				ComboboxTimeZone.ItemsSource = e.Result;
			else
				MessageBox.Show(e.Error.Message);
			if (ComboboxTimeZone.Items.Count > 0)
				ComboboxTimeZone.SelectedIndex = 0;
		}
		void client_GetProtocolsCompleted(object sender, GetProtocolsCompletedEventArgs e)
		{
			if (e.Error == null)
				ComboboxProtocol.ItemsSource = e.Result;
			else
				MessageBox.Show(e.Error.Message);
			if (ComboboxProtocol.Items.Count > 0)
				ComboboxProtocol.SelectedIndex = 0;
		}
		void client_GetVendorDevicesCompleted(object sender, GetVendorDevicesCompletedEventArgs e)
		{
			if (e.Error == null)
				ComboboxVendorDevice.ItemsSource = e.Result;
			else
				MessageBox.Show(e.Error.Message);
			if (ComboboxVendorDevice.Items.Count > 0)
				ComboboxVendorDevice.SelectedIndex = 0;
		}
		void client_GetInterconnectionsCompleted(object sender, GetInterconnectionsCompletedEventArgs e)
		{
			if (e.Error == null)
				ComboboxInterconnection.ItemsSource = e.Result;
			else
				MessageBox.Show(e.Error.Message);
			if (ComboboxInterconnection.Items.Count > 0)
				ComboboxInterconnection.SelectedIndex = 0;
		}
		void client_GetHistoriansCompleted(object sender, GetHistoriansCompletedEventArgs e)
		{
			if (e.Error == null)
				ComboboxHistorian.ItemsSource = e.Result;
			else
				MessageBox.Show(e.Error.Message);
			if (ComboboxHistorian.Items.Count > 0)
				ComboboxHistorian.SelectedIndex = 0;
		}
		void client_GetNodesCompleted(object sender, GetNodesCompletedEventArgs e)
		{
			if (e.Error == null)
				ComboboxNode.ItemsSource = e.Result;
			else
				MessageBox.Show(e.Error.Message);
			if (ComboboxNode.Items.Count > 0)
				ComboboxNode.SelectedIndex = 0;
		}
		void client_GetCompaniesCompleted(object sender, GetCompaniesCompletedEventArgs e)
		{
			if (e.Error == null)
				ComboboxCompany.ItemsSource = e.Result;
			else
				MessageBox.Show(e.Error.Message);
			if (ComboboxCompany.Items.Count > 0)
				ComboboxCompany.SelectedIndex = 0;
		}
		void client_GetDevicesCompleted(object sender, GetDevicesCompletedEventArgs e)
		{
			if (e.Error == null)
				ComboboxParent.ItemsSource = e.Result;
			else
				MessageBox.Show(e.Error.Message);
			if (ComboboxParent.Items.Count > 0)
				ComboboxParent.SelectedIndex = 0;
		}
		void AddNew_Loaded(object sender, RoutedEventArgs e)
		{
			client.GetDevicesAsync(true, true);
			client.GetCompaniesAsync(true);
			client.GetNodesAsync(true, false);
			client.GetHistoriansAsync(true, true);
			client.GetInterconnectionsAsync(true);
			client.GetVendorDevicesAsync(true);
			client.GetProtocolsAsync(true);
			client.GetTimeZonesAsync(true);
		}
		void ClearForm()
		{
			GridDeviceDetail.DataContext = new Device();
			ComboboxCompany.SelectedIndex = 0;
			ComboboxHistorian.SelectedIndex = 0;
			ComboboxInterconnection.SelectedIndex = 0;
			ComboboxNode.SelectedIndex = 0;
			ComboboxParent.SelectedIndex = 0;
			ComboboxProtocol.SelectedIndex = 0;
			ComboboxTimeZone.SelectedIndex = 0;
			ComboboxVendorDevice.SelectedIndex = 0;
		}
		// Executes when the user navigates to this page.
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
		}

	}
}
