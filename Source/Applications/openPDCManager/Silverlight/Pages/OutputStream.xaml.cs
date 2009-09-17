//*******************************************************************************************************
//  OutputStream.xaml.cs
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
    public partial class OutputStream : Page
    {
        static string baseServiceUrl = Application.Current.Resources["BaseServiceUrl"].ToString();
        EndpointAddress address = new EndpointAddress(baseServiceUrl + "Service/PhasorDataService.svc");
        PhasorDataServiceClient client;

        public OutputStream()
        {
            InitializeComponent();
            client = new PhasorDataServiceClient(new BasicHttpBinding(), address);
			//client.GetOutputStreamListCompleted += new EventHandler<GetOutputStreamListCompletedEventArgs>(client_GetOutputStreamListCompleted);
			Loaded += new RoutedEventHandler(OutputStream_Loaded);
			ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
			ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
        }
		void ButtonSave_Click(object sender, RoutedEventArgs e)
		{
			
		}
		void ButtonClear_Click(object sender, RoutedEventArgs e)
		{
			
		}
		void OutputStream_Loaded(object sender, RoutedEventArgs e)
		{
			//client.GetOutputStreamListAsync();
		}
		//void client_GetOutputStreamListCompleted(object sender, GetOutputStreamListCompletedEventArgs e)
		//{
		//    if (e.Error == null)
		//        ListBoxOutputStream.ItemsSource = e.Result;                
		//}
        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
		private void ListBoxOutputStream_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//openPDCManager.Silverlight.PhasorDataServiceProxy.OutputStream selectedStream = ListBoxOutputStream.SelectedItem as openPDCManager.Silverlight.PhasorDataServiceProxy.OutputStream;
			//GridOutputStreamDetail.DataContext = selectedStream;
		}
		void ClearForm()
		{

		}

    }
}
