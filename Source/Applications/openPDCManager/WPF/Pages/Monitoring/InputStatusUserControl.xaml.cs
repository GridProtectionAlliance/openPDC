using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using Microsoft.Win32;
using openPDCManager.Data;
using openPDCManager.Data.BusinessObjects;
using openPDCManager.Data.Entities;
using openPDCManager.ModalDialogs;
using openPDCManager.Pages.Adapters;
using openPDCManager.UserControls.CommonControls;
using openPDCManager.Utilities;
using TVA.Configuration;
using TimeSeriesFramework.Transport;
using TVA;
using TimeSeriesFramework;
using TVA.Collections;

namespace openPDCManager.Pages.Monitoring
{
    /// <summary>
    /// Interaction logic for InputStatusUserControl.xaml
    /// </summary>
    public partial class InputStatusUserControl : UserControl
    {
        #region [ Members ]
                

        #region [ Members for Dynamic Data Display ]
        
        EnumerableDataSource<int> m_xAxisSource;
        Dictionary<string, EnumerableDataSource<Double>> m_yAxisSourceCollection; //this will contain PointID and corresponding data plotted on Y-axis
        Dictionary<string, List<double>> m_yAxisDataCollection;    //this will contain PointID and corresponding List<double> from the openPDC
        
        #endregion

        #region [ Static Members ]

        static DataSubscriber subscriber = new DataSubscriber();
        static long dataCount = 0;

        #endregion

        #endregion

        #region [ Constructor ]

        public InputStatusUserControl()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(InputStatusUserControl_Loaded);
            this.Unloaded += new RoutedEventHandler(InputStatusUserControl_Unloaded);

            m_yAxisDataCollection = new Dictionary<string, List<double>>();
            m_yAxisSourceCollection = new Dictionary<string, EnumerableDataSource<double>>();            
        }

        #endregion

        #region [ Page Event Handlers ]

        void InputStatusUserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            subscriber.Unsubscribe();

            subscriber.StatusMessage -= subscriber_StatusMessage;
            subscriber.ProcessException -= subscriber_ProcessException;
            subscriber.ConnectionEstablished -= subscriber_ConnectionEstablished;
            subscriber.NewMeasurements -= subscriber_NewMeasurements;
        }

        void InputStatusUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Remove legend on the right.
            Panel legendParent = (Panel)ChartPlotterDynamic.Legend.ContentGrid.Parent;
            legendParent.Children.Remove(ChartPlotterDynamic.Legend.ContentGrid);

            List<int> tempXValues = new List<int>();
            for (int i = 0; i < 300; i++)
                tempXValues.Add(i);

            m_xAxisSource = new EnumerableDataSource<int>(tempXValues);
            m_xAxisSource.SetXMapping(x => x);

            subscriber.StatusMessage += subscriber_StatusMessage;
            subscriber.ProcessException += subscriber_ProcessException;
            subscriber.ConnectionEstablished += subscriber_ConnectionEstablished;
            subscriber.NewMeasurements += subscriber_NewMeasurements;

            // Initialize subscriber
            subscriber.ConnectionString = "server=localhost:6165";
            subscriber.Initialize();

            // Start subscriber connection cycle
            subscriber.Start();
        }

        #endregion

        #region [ Subscription API Code ]

        static void subscriber_NewMeasurements(object sender, EventArgs<ICollection<IMeasurement>> e)
        {
            foreach (IMeasurement measurement in e.Argument)
            {
                System.Diagnostics.Debug.WriteLine(measurement.SignalID.ToString() + " | " + measurement.Value);
            }
        }

        static void subscriber_ConnectionEstablished(object sender, EventArgs e)
        {
            subscriber.SynchronizedSubscribe(true, 1, 0.5D, 1.0D, "DEVARCHIVE:2");
        }

        static void subscriber_ProcessException(object sender, TVA.EventArgs<Exception> e)
        {
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine("EXCEPTION: " + e.Argument.Message);
            //Console.ResetColor();
        }

        static void subscriber_StatusMessage(object sender, TVA.EventArgs<string> e)
        {
            //Console.WriteLine(e.Argument);
        }

        #endregion
                
    }
}
