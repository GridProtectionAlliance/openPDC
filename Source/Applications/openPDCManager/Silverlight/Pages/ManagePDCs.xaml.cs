//*******************************************************************************************************
//  ManagePDCs.xaml.cs
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
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using openPDCManager.Silverlight.PhasorDataServiceProxy;

namespace openPDCManager.Silverlight.Pages
{
    public partial class ManagePDCs : Page
    {
        static string baseServiceUrl = Application.Current.Resources["BaseServiceUrl"].ToString();
        EndpointAddress address = new EndpointAddress(baseServiceUrl + "Service/PhasorDataService.svc");        
        PhasorDataServiceClient client;		
                
        public ManagePDCs()
        {
            InitializeComponent();
			Loaded += new RoutedEventHandler(ManagePDCs_Loaded);
            client = new PhasorDataServiceClient(new BasicHttpBinding(), address);
			//client.GetPdcListCompleted += new EventHandler<GetPdcListCompletedEventArgs>(client_GetPdcListCompleted);
			//client.GetTransportProtocolListCompleted += new EventHandler<GetTransportProtocolListCompletedEventArgs>(client_GetTransportProtocolListCompleted);
			//client.GetCompanyListCompleted += new EventHandler<GetCompanyListCompletedEventArgs>(client_GetCompanyListCompleted);
			//client.GetVendorListCompleted += new EventHandler<GetVendorListCompletedEventArgs>(client_GetVendorListCompleted);
			//client.GetProtocolListCompleted += new EventHandler<GetProtocolListCompletedEventArgs>(client_GetProtocolListCompleted);
			//client.GetParityListCompleted += new EventHandler<GetParityListCompletedEventArgs>(client_GetParityListCompleted);
			//client.GetStopBitListCompleted += new EventHandler<GetStopBitListCompletedEventArgs>(client_GetStopBitListCompleted);
			//client.GetTimeZonesListCompleted += new EventHandler<GetTimeZonesListCompletedEventArgs>(client_GetTimeZonesListCompleted);
			ComboBoxTransportProtocol.SelectionChanged += new SelectionChangedEventHandler(ComboBoxTransportProtocol_SelectionChanged);
			ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
			ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
        }
		void ButtonSave_Click(object sender, RoutedEventArgs e)
		{
			
		}
		void ButtonClear_Click(object sender, RoutedEventArgs e)
		{
			ClearForm();
		}
		//void client_GetTimeZonesListCompleted(object sender, GetTimeZonesListCompletedEventArgs e)
		//{
		//    if (e.Error == null)
		//        ComboBoxTimeZone.ItemsSource = e.Result;
		//    if (ComboBoxTimeZone.Items.Count > 0)
		//        ComboBoxTimeZone.SelectedIndex = 0;
		//}
		//void client_GetStopBitListCompleted(object sender, GetStopBitListCompletedEventArgs e)
		//{
		//    if (e.Error == null)
		//        ComboBoxStopBits.ItemsSource = e.Result;
		//    if (ComboBoxStopBits.Items.Count > 0)
		//        ComboBoxStopBits.SelectedIndex = 0;
		//}
		//void client_GetParityListCompleted(object sender, GetParityListCompletedEventArgs e)
		//{
		//    if (e.Error == null)
		//        ComboBoxParity.ItemsSource = e.Result;
		//    if (ComboBoxParity.Items.Count > 0)
		//        ComboBoxParity.SelectedIndex = 0;
		//}
		void ComboBoxTransportProtocol_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			SetTransportProtocolFields();
		}
		//void client_GetProtocolListCompleted(object sender, GetProtocolListCompletedEventArgs e)
		//{
		//    if (e.Error == null)			
		//        ComboBoxProtocol.ItemsSource = e.Result;
		//    if (ComboBoxProtocol.Items.Count > 0)
		//        ComboBoxProtocol.SelectedIndex = 0;
		//}
		void client_GetVendorListCompleted(object sender, GetVendorListCompletedEventArgs e)
		{
			if (e.Error == null)
				ComboBoxVendor.ItemsSource = e.Result;
			if (ComboBoxVendor.Items.Count > 0)
				ComboBoxVendor.SelectedIndex = 0;
		}
		void client_GetCompanyListCompleted(object sender, GetCompanyListCompletedEventArgs e)
		{
			if (e.Error == null)
				ComboBoxCompany.ItemsSource = e.Result;
			if (ComboBoxCompany.Items.Count > 0)
				ComboBoxCompany.SelectedIndex = 0;
		}
		//void client_GetTransportProtocolListCompleted(object sender, GetTransportProtocolListCompletedEventArgs e)
		//{
		//    if (e.Error == null)
		//        ComboBoxTransportProtocol.ItemsSource = e.Result;
		//    if (ComboBoxTransportProtocol.Items.Count > 0)
		//        ComboBoxTransportProtocol.SelectedIndex = 0;			
		//}		
		//void client_GetPdcListCompleted(object sender, GetPdcListCompletedEventArgs e)
		//{
		//    if (e.Error == null)
		//        ListBoxPdcList.ItemsSource = e.Result;
		//}        
		void ListBoxPdcList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//Pdc selectedPdc = ListBoxPdcList.SelectedItem as Pdc;
			//GridPdcDetail.DataContext = selectedPdc;
			//ComboBoxCompany.SelectedItem = new KeyValuePair<int, string>(selectedPdc.CompanyID, selectedPdc.CompanyName);
			//ComboBoxProtocol.SelectedItem = new KeyValuePair<int, string>(selectedPdc.ProtocolID, selectedPdc.ProtocolName);
			//ComboBoxVendor.SelectedItem = new KeyValuePair<int, string>(selectedPdc.VendorDeviceID, selectedPdc.VendorDeviceDescription);
		}
		void ManagePDCs_Loaded(object sender, RoutedEventArgs e)
		{
			//client.GetPdcListAsync();
			//client.GetTransportProtocolListAsync();
			//client.GetCompanyListAsync();
			//client.GetVendorListAsync();
			//client.GetProtocolListAsync();
			//client.GetParityListAsync();
			//client.GetStopBitListAsync();
			//client.GetTimeZonesListAsync();

			// Load serial protocol fields.
			ComboBoxSerialPort.Items.Clear();
			for (int i = 1; i <= 20; i++)
			{
				ComboBoxSerialPort.Items.Add("COM" + i.ToString());
			}
			// Load Baud Rate dropdown.
			ComboBoxBaudRate.Items.Clear();
			ComboBoxBaudRate.Items.Add("115200");
            ComboBoxBaudRate.Items.Add("57600");
            ComboBoxBaudRate.Items.Add("38400");
            ComboBoxBaudRate.Items.Add("19200");
            ComboBoxBaudRate.Items.Add("9600");
            ComboBoxBaudRate.Items.Add("4800");
            ComboBoxBaudRate.Items.Add("2400");
			ComboBoxBaudRate.Items.Add("1200");				
		}
		void SetTransportProtocolFields()
		{
			if (ComboBoxTransportProtocol.SelectedItem.ToString().ToUpper() == "TCP")
			{
				BorderTcp.Visibility = Visibility.Visible;
				BorderUdp.Visibility = Visibility.Collapsed;
				BorderSerial.Visibility = Visibility.Collapsed;
			}
			else if (ComboBoxTransportProtocol.SelectedItem.ToString().ToUpper() == "UDP")
			{
				BorderTcp.Visibility = Visibility.Collapsed;
				BorderUdp.Visibility = Visibility.Visible;
				BorderSerial.Visibility = Visibility.Collapsed;
			}
			else
			{
				BorderTcp.Visibility = Visibility.Collapsed;
				BorderUdp.Visibility = Visibility.Collapsed;
				BorderSerial.Visibility = Visibility.Visible;
			}
		}
		void ClearForm()
		{
			TextBoxAcronym.Text = string.Empty;
			TextBoxName.Text = string.Empty;
			ComboBoxCompany.SelectedIndex = 0;
			TextBoxAccessID.Text = string.Empty;
			ComboBoxVendor.SelectedIndex = 0;
			ComboBoxProtocol.SelectedIndex = 0;
			TextBoxLongitude.Text = string.Empty;
			TextBoxLatitude.Text = string.Empty;
			ComboBoxTimeZone.SelectedIndex = 0;
			TextBoxOffsetTicks.Text = string.Empty;
			TextBoxConnectionString.Text = string.Empty;
			TextBoxAdditionalConnectionInfo.Text = string.Empty;
			ComboBoxTransportProtocol.SelectedIndex = 0;
			TextBoxFramesPerSecond.Text = string.Empty;
			TextBoxEmailList.Text = string.Empty;
			CheckBoxEnabled.IsChecked = false;

			// Clear TCP fields
			TextBoxIPAddress.Text = string.Empty;
			TextBoxTCPPort.Text = string.Empty;
			CheckBoxEstablishServer.IsChecked = false;

			// Clear UDP fields
			TextBoxLocalPort.Text = string.Empty;
			CheckBoxListenOnUdp.IsChecked = false;
			TextBoxUdpIpAddress.Text = string.Empty;
			TextBoxRemotePort.Text = string.Empty;

			// Clear Serial fields
			ComboBoxSerialPort.SelectedIndex = 0;
			ComboBoxBaudRate.SelectedIndex = 0;
			ComboBoxParity.SelectedIndex = 0;
			ComboBoxStopBits.SelectedIndex = 0;
			TextBoxDataBits.Text = string.Empty;
			CheckBoxDTR.IsChecked = false;
			CheckBoxRTS.IsChecked = false;
		}
		// Executes when the user navigates to this page.
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
		}
    }
}
