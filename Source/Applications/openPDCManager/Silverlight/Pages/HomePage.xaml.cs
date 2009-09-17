//*******************************************************************************************************
//  HomePage.xaml.cs
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
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using openPDCManager.Silverlight.LivePhasorDataServiceProxy;

namespace openPDCManager.Silverlight.Pages
{
    public partial class HomePage : Page
    {
        static string baseServiceUrl = Application.Current.Resources["BaseServiceUrl"].ToString();
        EndpointAddress address = new EndpointAddress(baseServiceUrl + "DuplexService/PhasorDataDuplexService.svc");
        CustomBinding binding = new CustomBinding(
                                    new PollingDuplexBindingElement(),
                                    new BinaryMessageEncodingBindingElement(),
                                    new HttpTransportBindingElement());
                
        DuplexServiceClient duplexClient;
        bool connected = false;

        ObservableCollection<PmuDistribution> pmuDistributionList = new ObservableCollection<PmuDistribution>();
        ObservableCollection<InterconnectionStatus> interconnectionStatusList = new ObservableCollection<InterconnectionStatus>();
        Dictionary<string, int> deviceDistributionList = new Dictionary<string, int>();

        public HomePage()
        {
            duplexClient = new DuplexServiceClient(binding, address);
            duplexClient.SendToServiceCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(duplexClient_SendToServiceCompleted);
            duplexClient.SendToClientReceived += new EventHandler<SendToClientReceivedEventArgs>(duplexClient_SendToClientReceived);
            duplexClient.SendToServiceAsync(new ConnectMessage());
            
            InitializeComponent();            
        }
        void duplexClient_SendToServiceCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {            
            if (e.Error == null)
                connected = true;
        }
        void duplexClient_SendToClientReceived(object sender, SendToClientReceivedEventArgs e)
        {
            if (e.msg is LivePhasorDataMessage)
            {
                LivePhasorDataMessage livePhasorData = (LivePhasorDataMessage)e.msg;
                pmuDistributionList = livePhasorData.PmuDistributionList;
                interconnectionStatusList = livePhasorData.InterconnectionStatusList;
                deviceDistributionList = livePhasorData.DeviceDistributionList;

				ItemsControlPmuDistribution.ItemsSource = pmuDistributionList;
				ChartDeviceDistribution.DataContext = deviceDistributionList;
				ItemControlInterconnectionStatus.ItemsSource = interconnectionStatusList;                
            }
        }
        // Executes just before a page is no longer the active page in a frame.
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            if (connected) 
                duplexClient.SendToServiceAsync(new DisconnectMessage());
            base.OnNavigatingFrom(e);
        }
        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

    }
}
