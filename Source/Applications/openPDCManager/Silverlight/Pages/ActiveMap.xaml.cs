//*******************************************************************************************************
//  ActiveMap.xaml.cs
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
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.VirtualEarth.MapControl;
using openPDCManager.Silverlight.PhasorDataServiceProxy;

namespace openPDCManager.Silverlight.Pages
{
    public partial class ActiveMap : Page
    {
        static string baseServiceUrl = Application.Current.Resources["BaseServiceUrl"].ToString();
        EndpointAddress address = new EndpointAddress(baseServiceUrl + "Service/PhasorDataService.svc");
		BasicHttpBinding binding = new BasicHttpBinding();
		PhasorDataServiceClient client;
        Button pushPinButton;
		//ObservableCollection<BasicPmuInfo> pmuList;
        ToolTip toolTip;

        public ActiveMap()
        {
            InitializeComponent();
			//Loaded += new RoutedEventHandler(ActiveMap_Loaded);
			binding.MaxReceivedMessageSize = 65536 * 2;
            client = new PhasorDataServiceClient(binding, address);
			//client.GetValidatedPmuListCompleted +=new EventHandler<GetValidatedPmuListCompletedEventArgs>(client_GetValidatedPmuListCompleted);
        }
		//void client_GetValidatedPmuListCompleted(object sender, GetValidatedPmuListCompletedEventArgs e)
		//{
		//    if (e.Error == null)
		//    {
		//        pmuList = new ObservableCollection<BasicPmuInfo>();
		//        pmuList = e.Result;
		//        double longitude = Convert.ToDouble(pmuList.Average(pl => pl.Longitude));
		//        double latitude = Convert.ToDouble(pmuList.Average(pl => pl.Latitude));
				
		//        foreach (BasicPmuInfo pmu in pmuList)
		//        {
		//            pushPinButton = new Button();
		//            toolTip = new ToolTip();
		//            toolTip.DataContext = pmu;
		//            toolTip.Template = Application.Current.Resources["MapToolTipTemplate"] as ControlTemplate;
		//            ToolTipService.SetToolTip(pushPinButton, toolTip);
		//            pushPinButton.Content = pmu.CompanyAcronym;
		//            if (!pmu.Active)
		//                pushPinButton.Template = Application.Current.Resources["GrayPushPinButtonTemplate"] as ControlTemplate;
		//            else if (pmu.Reporting)
		//                pushPinButton.Template = Application.Current.Resources["GreenPushPinButtonTemplate"] as ControlTemplate;
		//            else
		//                pushPinButton.Template = Application.Current.Resources["RedPushPinButtonTemplate"] as ControlTemplate;
		//            pushPinButton.SetValue(MapLayer.MapPositionProperty, new Microsoft.VirtualEarth.MapControl.Location(Convert.ToDouble(pmu.Latitude), Convert.ToDouble(pmu.Longitude)));
		//            pushPinButton.SetValue(MapLayer.MapPositionMethodProperty, PositionMethod.Center);
		//            (VirtualEarthActiveMap.FindName("PushpinLayer") as MapLayer).AddChild(pushPinButton);					
		//        }
		//        VirtualEarthActiveMap.Center = new Location(latitude, longitude);
		//    }
		//}        
		//void ActiveMap_Loaded(object sender, RoutedEventArgs e)
		//{
		//    client.GetValidatedPmuListAsync();
		//}
        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        private void VirtualEarthActiveMap_MouseClick(object sender, Microsoft.VirtualEarth.MapControl.MapMouseEventArgs e)
        {
        }
    }
}
