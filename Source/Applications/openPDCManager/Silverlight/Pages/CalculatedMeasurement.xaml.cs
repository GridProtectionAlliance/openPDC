//*******************************************************************************************************
//  CalculatedMeasurement.xaml.cs
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
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using openPDCManager.Silverlight.PhasorDataServiceProxy;

namespace openPDCManager.Silverlight.Pages
{
    public partial class CalculatedMeasurement : Page
    {
        static string baseServiceUrl = Application.Current.Resources["BaseServiceUrl"].ToString();
        EndpointAddress address = new EndpointAddress(baseServiceUrl + "Service/PhasorDataService.svc");
        PhasorDataServiceClient client;

        public CalculatedMeasurement()
        {
            InitializeComponent();
            client = new PhasorDataServiceClient(new BasicHttpBinding(), address);
			//client.GetCalculatedMeasurementListCompleted += new EventHandler<GetCalculatedMeasurementListCompletedEventArgs>(client_GetCalculatedMeasurementListCompleted);
			//client.GetCalculatedMeasurementListAsync();
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
		//void client_GetCalculatedMeasurementListCompleted(object sender, GetCalculatedMeasurementListCompletedEventArgs e)
		//{
		//    if (e.Error == null)
		//        ListBoxCalculatedMeasurements.ItemsSource = e.Result;
		//}
        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
		private void ListBoxCalculatedMeasurements_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//openPDCManager.Silverlight.PhasorDataServiceProxy.CalculatedMeasurement selectedMeasurement = ListBoxCalculatedMeasurements.SelectedItem as openPDCManager.Silverlight.PhasorDataServiceProxy.CalculatedMeasurement;
			//GridCalculatedMeasurementsDetail.DataContext = selectedMeasurement;
		}
		void ClearForm()
		{
			TextBoxName.Text = string.Empty;
			TextBoxTypeName.Text = string.Empty;
			TextBoxAssemblyName.Text = string.Empty;
			TextBoxConfigSection.Text = string.Empty;
			TextBoxOutputMeasurementsSql.Text = string.Empty;
			TextBoxInputMeasurementsSql.Text = string.Empty;
			TextBoxMinimumInputMeasurements.Text = string.Empty;
			TextBoxExpectedFrameRate.Text = string.Empty;
			TextBoxLagTime.Text = string.Empty;
			TextBoxLeadTime.Text = string.Empty;
			CheckBoxEnabled.IsChecked = false;
		}

    }
}
