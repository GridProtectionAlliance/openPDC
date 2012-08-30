//*******************************************************************************************************
//  LocalHive.xaml.cs
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
    public partial class LocalHive : Page
    {
        static string baseServiceUrl = Application.Current.Resources["BaseServiceUrl"].ToString();
        EndpointAddress address = new EndpointAddress(baseServiceUrl + "Service/PhasorDataService.svc");
        PhasorDataServiceClient client;

        public LocalHive()
        {
            InitializeComponent();
            client = new PhasorDataServiceClient(new BasicHttpBinding(), address);
            client.GetHistorianListCompleted += new EventHandler<GetHistorianListCompletedEventArgs>(client_GetHistorianListCompleted);            
            Loaded += new RoutedEventHandler(LocalHive_Loaded);
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
        void client_GetHistorianListCompleted(object sender, GetHistorianListCompletedEventArgs e)
        {
            if (e.Error == null)
				ListBoxHistorianList.ItemsSource = e.Result;
        }
		private void ListBoxHistorianList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Historian selectedHistorian = ListBoxHistorianList.SelectedItem as Historian;
			GridHistorianDetail.DataContext = selectedHistorian;
		}
        void LocalHive_Loaded(object sender, RoutedEventArgs e)
        {
			//client.GetHistorianListAsync();
        }
		void ClearForm()
		{
			TextBoxAcronym.Text = string.Empty;
			TextBoxName.Text = string.Empty;
			TextBoxDescription.Text = string.Empty;
			TextBoxTypeName.Text = string.Empty;
			TextBoxAssemblyName.Text = string.Empty;
			TextBoxConnectionString.Text = string.Empty;
			CheckboxEnabled.IsChecked = false;
		}
        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

    }
}
