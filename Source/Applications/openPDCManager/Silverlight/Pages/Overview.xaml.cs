//*******************************************************************************************************
//  Overview.xaml.cs
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
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace openPDCManager.Silverlight.Pages
{
    public partial class Overview : Page
    {
        public Overview()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Overview_Loaded);
        }

        void Overview_Loaded(object sender, RoutedEventArgs e)
        {
            string imageUrl = HtmlPage.Document.DocumentUri.AbsoluteUri;
            imageUrl = imageUrl.Substring(0, imageUrl.IndexOf("Default.aspx"));
            imageUrl = imageUrl + "Images/SMSConnectionPoint.png";
            ImageOverview.Source = new BitmapImage(new Uri(imageUrl, UriKind.Absolute));            
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

    }
}
