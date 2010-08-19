using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Threading;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;

namespace openPDCManager.Pages.Monitoring
{
    /// <summary>
    /// Interaction logic for SystemMonitor.xaml
    /// </summary>
    public partial class SystemMonitor : UserControl
    {        
        DispatcherTimer m_refreshTimer;
        readonly double[] animatedX = new double[300];
        //readonly double[] animatedYFreq = new double[1000];
        EnumerableDataSource<double> sourceX;
        List<List<double>> listOfAnimatedY = new List<List<double>>();
        List<EnumerableDataSource<double>> listOfSourceY = new List<EnumerableDataSource<double>>();
        int chartCount = 0;

        public SystemMonitor()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(SystemMonitor_Loaded);
        }

        void SystemMonitor_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 300; i++)
            {
                animatedX[i] = i;
            }
            sourceX = new EnumerableDataSource<double>(animatedX);
            sourceX.SetXMapping(x => x);
        }

        private void AddFrequency_Click(object sender, RoutedEventArgs e)
        {
            chartCount++;
            List<double> animatedY = new List<double>();
            Random random = new Random(59);
            for (int i = 0; i < 300; i++)
            {
                animatedY.Add(random.NextDouble());
            }

            listOfAnimatedY.Add(animatedY);
            EnumerableDataSource<double> sourceY = new EnumerableDataSource<double>(listOfAnimatedY.Last());
            sourceY.SetYMapping(y => y);
            listOfSourceY.Add(sourceY);

            var line = plotter.AddLineGraph(new CompositeDataSource(sourceX, sourceY),"Frequency " + chartCount.ToString());           //, new Pen(Brushes.Red, 3), new PenDescription("Frequency"));

            if (m_refreshTimer == null)
            {
                m_refreshTimer = new DispatcherTimer();
                m_refreshTimer.Interval = TimeSpan.FromMilliseconds(500);
                m_refreshTimer.Tick += new EventHandler(m_refreshTimer_Tick);
                m_refreshTimer.Start();
            }   
        }

        void m_refreshTimer_Tick(object sender, EventArgs e)
        {
            Random random = new Random(59);
            for (int i = 0; i < listOfAnimatedY.Count; i++)
            {
                List<double> temp = listOfAnimatedY[i];
                temp.RemoveAt(0);
                temp.Insert(temp.Count - 1, random.NextDouble());
                listOfSourceY[i].RaiseDataChanged();
            }
        }

        private void AddPhaseAngle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveFrequency_Click(object sender, RoutedEventArgs e)
        {
            object itemToBeRemoved = null;
            //System.Diagnostics.Debug.WriteLine(plotter.Children.Count());
            foreach (object item in plotter.Children)
            {
                if (item is LineGraph)                    
                    itemToBeRemoved = item;
            }
            plotter.Children.Remove((IPlotterElement)itemToBeRemoved);
        }

        private void RemovePhaseAngle_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
