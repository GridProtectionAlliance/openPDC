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
using System.Collections.Concurrent;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Shapes;
using System.Windows.Data;

namespace openPDCManager.Pages.Monitoring
{
    /// <summary>
    /// Interaction logic for SubscriptionTest.xaml
    /// </summary>
    public partial class SubscriptionTest : UserControl
    {
        #region [ Members ]

        DispatcherTimer m_chartRefreshTimer;
        //ConcurrentDictionary<string, ObservableCollection<TimeSeriesDataPoint>> m_subscriptionDataList;
        ConcurrentDictionary<string, List<TimeSeriesDataPoint>> m_subscriptionDataList;
        Dictionary<string, LineSeries> m_dataSeriesList;
        List<Color> m_lineColors;
        
        DataSubscriber m_subscriber = new DataSubscriber();        
        
        #endregion

        #region [ Constructor ]
        
        public SubscriptionTest()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(SubscriptionTest_Loaded);
            this.Unloaded += new RoutedEventHandler(SubscriptionTest_Unloaded);
            m_subscriptionDataList = new ConcurrentDictionary<string, List<TimeSeriesDataPoint>>();
            m_dataSeriesList = new Dictionary<string, LineSeries>();
            InitializeLineColors();
        }

        #endregion

        #region [ Page Event Handlers ]
        
        void SubscriptionTest_Unloaded(object sender, RoutedEventArgs e)
        {
            m_subscriber.Unsubscribe();
            m_subscriber.StatusMessage -= subscriber_StatusMessage;
            m_subscriber.ProcessException -= subscriber_ProcessException;
            m_subscriber.ConnectionEstablished -= subscriber_ConnectionEstablished;
            m_subscriber.NewMeasurements -= subscriber_NewMeasurements;
        }

        void SubscriptionTest_Loaded(object sender, RoutedEventArgs e)
        {
            m_subscriber.StatusMessage += subscriber_StatusMessage;
            m_subscriber.ProcessException += subscriber_ProcessException;
            m_subscriber.ConnectionEstablished += subscriber_ConnectionEstablished;
            m_subscriber.NewMeasurements += subscriber_NewMeasurements;            
            m_subscriber.ConnectionString = "server=localhost:6165";
            m_subscriber.Initialize();            
            m_subscriber.Start();

            StartChartRefreshTimer();
        }

        #endregion

        #region [ Subscription API Code ]

        void subscriber_NewMeasurements(object sender, EventArgs<ICollection<IMeasurement>> e)
        {
            foreach (IMeasurement measurement in e.Argument)
            {
                double tempValue = measurement.Value;
                string tempSignalID = measurement.SignalID.ToString();
                

                lock (m_subscriptionDataList)
                {
                    //if (m_subscriptionDataList.TryGetValue(tempSignalID, out tempCollection))
                    if (m_subscriptionDataList.ContainsKey(tempSignalID))
                    {
                        //lock (tempCollection)
                        //{
                            ChartRealTimeData.Dispatcher.BeginInvoke((Action)delegate()
                            {
                                List<TimeSeriesDataPoint> tempCollection = m_subscriptionDataList[tempSignalID];                                
                                tempCollection.RemoveAt(0);
                                tempCollection.Add(new TimeSeriesDataPoint() { Index = tempCollection.Last().Index + 1, Value = tempValue });
                            });
                        //}
                    }
                    else
                    {
                        //ChartRealTimeData.Dispatcher.BeginInvoke((Action)delegate()
                        //    {
                        List<TimeSeriesDataPoint> tempCollection = new List<TimeSeriesDataPoint>();
                                for (int i = 0; i < 300; i++)
                                    tempCollection.Add(new TimeSeriesDataPoint() { Index = i, Value = tempValue });
                                m_subscriptionDataList.TryAdd(tempSignalID, tempCollection);
                           // });
                                //ThreadPool.QueueUserWorkItem(AddNewLineSeries, tempSignalID);
                        AddNewLineSeries(tempSignalID);                        
                    }
                }
            }
        }

        void subscriber_ConnectionEstablished(object sender, EventArgs e)
        {
            m_subscriber.SynchronizedSubscribe(true, 30, 0.5D, 1.0D, "DEVARCHIVE:2;DEVARCHIVE:6");
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

        void AddNewLineSeries(object state)
        {
            //LineSeriesFrequency.ItemsSource = m_subscriptionDataList[state.ToString()];            

            string tempSignalID = state.ToString();
            //ObservableCollection<TimeSeriesDataPoint> tempCollection;
            //lock (m_subscriptionDataList)
            //    tempCollection = m_subscriptionDataList[tempSignalID];

            lock (m_dataSeriesList)
            {
                if (!m_dataSeriesList.ContainsKey(tempSignalID))
                {
                    ChartRealTimeData.Dispatcher.BeginInvoke((Action)delegate()
                    {
                        LineSeries series = new LineSeries();
                        try
                        {
                            series.IndependentValuePath = "Index";
                            series.DependentValuePath = "Value";
                            series.IsSelectionEnabled = false;
                            //series.AnimationSequence = AnimationSequence.FirstToLast;
                            series.DataPointStyle = new Style(typeof(LineDataPoint));
                            series.DataPointStyle.Setters.Add(new Setter(LineDataPoint.VisibilityProperty, Visibility.Collapsed));
                            series.DataPointStyle.Setters.Add(new Setter(LineDataPoint.BackgroundProperty, new SolidColorBrush(m_lineColors[m_dataSeriesList.Count()])));
                            series.DataPointStyle.Setters.Add(new Setter(LineDataPoint.TemplateProperty, new ControlTemplate()));
                            series.PolylineStyle = new Style(typeof(Polyline));
                            series.PolylineStyle.Setters.Add(new Setter(Polyline.StrokeThicknessProperty, 1.0));
                            Binding binding = new Binding();
                            binding.Mode = BindingMode.OneTime;
                            binding.Source = m_subscriptionDataList[tempSignalID];

                            if (tempSignalID.ToUpper() == "93673C68-D59D-4926-B7E9-E7678F9F66B4")
                                series.DependentRangeAxis = LinearAxisFrequency;
                            else
                                series.DependentRangeAxis = LinearAxisPhaseAngle;
                            m_dataSeriesList.Add(tempSignalID, series);
                            //series.ItemsSource = tempCollection;
                            series.SetBinding(LineSeries.ItemsSourceProperty, binding);
                            ChartRealTimeData.Series.Add(series);
                        }
                        finally
                        {
                            series = null;
                        }
                    });
                }
            }

            //((LineSeries)chart1.Series[1]).DependentRangeAxis = new LinearAxis
            //{
            //    Name = list[1],
            //    Maximum = 200,
            //    Minimum = 0,
            //    Interval = 10,
            //    Orientation = AxisOrientation.Y,
            //    Location = AxisLocation.Right,
            //    Title = "This is Serie1's Y axis"
            //};

            
        }

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
            lock (m_dataSeriesList)
            {
                foreach (KeyValuePair<string, LineSeries> pair in m_dataSeriesList)
                    
                    pair.Value.ItemsSource = new List<TimeSeriesDataPoint>(m_subscriptionDataList[pair.Key]);
            }            
        }
                
        void InitializeLineColors()
        {
            m_lineColors = new List<Color>();
            m_lineColors.Add(Colors.Blue);
            m_lineColors.Add(Colors.Red);
            m_lineColors.Add(Colors.Yellow);
            m_lineColors.Add(Colors.Green);
            m_lineColors.Add(Colors.Orange);
            m_lineColors.Add(Colors.Purple);
            m_lineColors.Add(Colors.Black);
            m_lineColors.Add(Colors.White);
            m_lineColors.Add(Colors.Brown);
            m_lineColors.Add(Colors.Cyan);
            m_lineColors.Add(Colors.Lime);
            m_lineColors.Add(Colors.Salmon);
        }

        #endregion
    }
}
