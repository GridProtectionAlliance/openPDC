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
        
        EnumerableDataSource<int> m_xAxisBindingCollection;                     //this will contain DateTime values plotted on X-Axis
        List<int> m_xAxisDataCollection;                                        //this will contain DateTime values from the subscription API
        Dictionary<string, List<double>> m_yAxisDataCollection;                      //this will contain SignalID and corresponding List<double> from the subsription API
        Dictionary<string, EnumerableDataSource<Double>> m_yAxisBindingCollection;   //this will contain SignalID and corresponding data plotted on Y-axis        
        DispatcherTimer m_chartRefreshTimer;

        #endregion

        #region [ Static Members ]

        DataSubscriber s_subscriber = new DataSubscriber();
        //long s_dataCount = 0;

        #endregion

        #endregion

        #region [ Constructor ]

        public InputStatusUserControl()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(InputStatusUserControl_Loaded);
            this.Unloaded += new RoutedEventHandler(InputStatusUserControl_Unloaded);

            m_xAxisDataCollection = new List<int>();
            m_yAxisDataCollection = new Dictionary<string, List<double>>();
            m_yAxisBindingCollection = new Dictionary<string, EnumerableDataSource<double>>();                      
        }        

        #endregion

        #region [ Page Event Handlers ]

        void InputStatusUserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            s_subscriber.Unsubscribe();
            s_subscriber.StatusMessage -= subscriber_StatusMessage;
            s_subscriber.ProcessException -= subscriber_ProcessException;
            s_subscriber.ConnectionEstablished -= subscriber_ConnectionEstablished;
            s_subscriber.NewMeasurements -= subscriber_NewMeasurements;
        }

        void InputStatusUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Remove legend on the right.
            Panel legendParent = (Panel)ChartPlotterDynamic.Legend.ContentGrid.Parent;
            legendParent.Children.Remove(ChartPlotterDynamic.Legend.ContentGrid);

            //Assign x-axis binding collection to x-axis.
            for (int i = 0; i < 150; i++)
                m_xAxisDataCollection.Add(i);
            m_xAxisBindingCollection = new EnumerableDataSource<int>(m_xAxisDataCollection);
            m_xAxisBindingCollection.SetXMapping(x => x);
            
            List<double> temp = new List<double>();            
            for (int i = 0; i < 150; i++)
                temp.Add(60.0);

            m_yAxisDataCollection.Add("Test", temp);
            m_yAxisBindingCollection.Add("Test", new EnumerableDataSource<double>(m_yAxisDataCollection["Test"]));
            m_yAxisBindingCollection["Test"].SetYMapping(y => y);

            ChartPlotterDynamic.AddLineGraph(new CompositeDataSource(m_xAxisBindingCollection, m_yAxisBindingCollection["Test"]));

            s_subscriber.StatusMessage += subscriber_StatusMessage;
            s_subscriber.ProcessException += subscriber_ProcessException;
            s_subscriber.ConnectionEstablished += subscriber_ConnectionEstablished;
            s_subscriber.NewMeasurements += subscriber_NewMeasurements;

            // Initialize subscriber
            s_subscriber.ConnectionString = "server=localhost:6165";
            s_subscriber.Initialize();

            // Start subscriber connection cycle
            s_subscriber.Start();

            StartChartRefreshTimer();
        }

        #endregion

        #region [ Subscription API Code ]

        void subscriber_NewMeasurements(object sender, EventArgs<ICollection<IMeasurement>> e)
        {
            double temp = e.Argument.First().Value;
            lock (m_yAxisDataCollection)
            {
                lock (m_yAxisDataCollection["Test"])
                {
                    List<double> tempCollection = m_yAxisDataCollection["Test"];
                    tempCollection.RemoveAt(0);
                    tempCollection.Add(temp);

                    //ChartPlotterDynamic.Dispatcher.BeginInvoke((Action)delegate()
                    //    {
                    //        lock (m_yAxisBindingCollection)
                    //        {
                    //            lock (m_yAxisBindingCollection["Test"])
                    //                m_yAxisBindingCollection["Test"].RaiseDataChanged();                                                                
                    //        }
                    //    });
                }
            }
            //foreach (IMeasurement measurement in e.Argument)
            //{
            //    //DateTime measurementDateTime = new DateTime(measurement.Timestamp);
            //    string measurementSignalID = measurement.SignalID.ToString();
            //    double measurementValue = measurement.Value;

            //    //lock (m_xAxisDataCollection)
            //    //{                    
            //    //    if (!m_xAxisDataCollection.Contains(measurementDateTime))
            //    //    {
            //    //        if (m_xAxisDataCollection.Count > 300)
            //    //            m_xAxisDataCollection.RemoveAt(0);

            //    //        m_xAxisDataCollection.Add(measurementDateTime);
            //    //        //m_xAxisBindingCollection.SetXMapping(x => XAxisDateTime.ConvertToDouble(x.Date));
            //    //    }
            //    //    //m_xAxisBindingCollection.RaiseDataChanged();
            //    //}

            //    lock (m_yAxisDataCollection)
            //    {
            //        if (!m_yAxisDataCollection.ContainsKey(measurementSignalID))
            //        {
            //            m_yAxisDataCollection.Add(measurementSignalID, new List<double>());
            //            lock (m_yAxisBindingCollection)
            //            {
            //                m_yAxisBindingCollection.Add(measurementSignalID, new EnumerableDataSource<double>(m_yAxisDataCollection[measurementSignalID]));
            //                m_yAxisBindingCollection[measurementSignalID].SetYMapping(y => y);
                            
            //                ChartPlotterDynamic.Dispatcher.BeginInvoke((Action)delegate()
            //                {
            //                    ChartPlotterDynamic.AddLineGraph(new CompositeDataSource(m_xAxisBindingCollection, m_yAxisBindingCollection[measurementSignalID]));
            //                });
            //            }
            //        }

            //        List<double> tempCollection = m_yAxisDataCollection[measurementSignalID];
            //        if (tempCollection.Count > 300)
            //            tempCollection.RemoveAt(0);

            //        tempCollection.Add(measurementValue);
            //        m_yAxisDataCollection[measurementSignalID] = tempCollection;

            //        ChartPlotterDynamic.Dispatcher.BeginInvoke((Action)delegate()
            //        {
            //            lock(m_yAxisBindingCollection)
            //                m_yAxisBindingCollection[measurementSignalID].RaiseDataChanged();
            //        });
            //    }
            //}            
        }

        void subscriber_ConnectionEstablished(object sender, EventArgs e)
        {
            s_subscriber.SynchronizedSubscribe(true, 30, 0.5D, 1.0D, "DEVARCHIVE:2");
        }

        void subscriber_ProcessException(object sender, TVA.EventArgs<Exception> e)
        {
            System.Diagnostics.Debug.WriteLine("EXCEPTION: " + e.Argument.Message);            
        }

        void subscriber_StatusMessage(object sender, TVA.EventArgs<string> e)
        {
            System.Diagnostics.Debug.WriteLine(e.Argument);
        }

        #endregion                
    
        #region [ Methods ]

        void StartChartRefreshTimer()
        {
            if (m_chartRefreshTimer == null)
            {
                m_chartRefreshTimer = new DispatcherTimer();
                m_chartRefreshTimer.Interval = TimeSpan.FromMilliseconds(1000);
                m_chartRefreshTimer.Tick += new EventHandler(m_chartRefreshTimer_Tick);
                m_chartRefreshTimer.Start();
            }
        }

        void m_chartRefreshTimer_Tick(object sender, EventArgs e)
        {         
            //RefreshChart(null);
            ChartPlotterDynamic.Dispatcher.BeginInvoke((Action)delegate()
                {
                    lock (m_yAxisBindingCollection)
                    {
                        lock (m_yAxisBindingCollection["Test"])
                            m_yAxisBindingCollection["Test"].RaiseDataChanged();
                    }
                });
        }

        #endregion
    }
}
