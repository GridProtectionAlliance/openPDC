//*******************************************************************************************************
//  PlanningMap.xaml.cs
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
	public partial class PlanningMap : Page
	{
		static string baseServiceUrl = Application.Current.Resources["BaseServiceUrl"].ToString();
		EndpointAddress address = new EndpointAddress(baseServiceUrl + "Service/PhasorDataService.svc");
		BasicHttpBinding binding = new BasicHttpBinding();
		PhasorDataServiceClient client;
		Button pushPinButton;
		//ObservableCollection<BasicPmuInfo> pmuList;
		ToolTip toolTip;

		public PlanningMap()
		{
			InitializeComponent();			
			binding.MaxReceivedMessageSize = 65536 * 3;
			client = new PhasorDataServiceClient(binding, address);
			//client.GetAllPmuListCompleted += new EventHandler<GetAllPmuListCompletedEventArgs>(client_GetAllPmuListCompleted);		
			Loaded += new RoutedEventHandler(PlanningMap_Loaded);
		}
		//void client_GetAllPmuListCompleted(object sender, GetAllPmuListCompletedEventArgs e)
		//{
		//    if (e.Error == null)
		//    {
		//        //pmuList = new ObservableCollection<BasicPmuInfo>();
		//        //pmuList = e.Result;
		//        //double longitude = Convert.ToDouble(pmuList.Average(pl => pl.Longitude));
		//        //double latitude = Convert.ToDouble(pmuList.Average(pl => pl.Latitude));
				
		//        //foreach (BasicPmuInfo pmu in pmuList)
		//        //{
		//        //    pushPinButton = new Button();
		//        //    toolTip = new ToolTip();
		//        //    toolTip.DataContext = pmu;
		//        //    toolTip.Template = Application.Current.Resources["MapToolTipTemplate"] as ControlTemplate;
		//        //    ToolTipService.SetToolTip(pushPinButton, toolTip);
		//        //    pushPinButton.Content = pmu.CompanyAcronym;
		//        //    if (pmu.Validated)
		//        //        pushPinButton.Template = Application.Current.Resources["BluePushPinButtonTemplate"] as ControlTemplate;
		//        //    else if (pmu.InProgress)
		//        //        pushPinButton.Template = Application.Current.Resources["WhitePushPinButtonTemplate"] as ControlTemplate;
		//        //    else
		//        //        pushPinButton.Template = Application.Current.Resources["YellowPushPinButtonTemplate"] as ControlTemplate;
		//        //    pushPinButton.SetValue(MapLayer.MapPositionProperty, new Microsoft.VirtualEarth.MapControl.Location(Convert.ToDouble(pmu.Latitude), Convert.ToDouble(pmu.Longitude)));
		//        //    pushPinButton.SetValue(MapLayer.MapPositionMethodProperty, PositionMethod.Center);
		//        //    (VirtualEarthPlanningMap.FindName("PushpinLayer") as MapLayer).AddChild(pushPinButton);
		//        //}
		//        //VirtualEarthPlanningMap.Center = new Location(latitude, longitude);				
		//    }
		//}
		void PlanningMap_Loaded(object sender, RoutedEventArgs e)
		{
			//client.GetAllPmuListAsync();
		}
		// Executes when the user navigates to this page.
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
		}
	}
}
