//*******************************************************************************************************
//  PmuList.xaml.cs
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
    public partial class PmuList : Page
    {
        static string baseServiceUrl = Application.Current.Resources["BaseServiceUrl"].ToString();
        EndpointAddress address = new EndpointAddress(baseServiceUrl + "Service/PhasorDataService.svc");
		BasicHttpBinding binding = new BasicHttpBinding();
        PhasorDataServiceClient client;

        public PmuList()
        {
            InitializeComponent();
			binding.MaxReceivedMessageSize = 65536 * 3;
            client = new PhasorDataServiceClient(binding, address);
			//client.GetAllPmuListCompleted += new EventHandler<GetAllPmuListCompletedEventArgs>(client_GetAllPmuListCompleted);
			//client.GetAllPmuListAsync();            
        }
		//void client_GetAllPmuListCompleted(object sender, GetAllPmuListCompletedEventArgs e)
		//{
		//    if (e.Error == null)
		//        ItemsControlPmuList.ItemsSource = e.Result;
		//}
        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
