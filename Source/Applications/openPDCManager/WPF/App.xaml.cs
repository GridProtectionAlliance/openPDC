using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace openPDCManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region [ Properties ]

        public string NodeValue { get; set; }
        public string NodeName { get; set; }
        public string TimeSeriesDataServiceUrl { get; set; }
        public string RemoteStatusServiceUrl { get; set; }
        public string RealTimeStatisticServiceUrl { get; set; }
        //public ApplicationIdCredentialsProvider Credentials { get; set; }

        #endregion
    }
}
