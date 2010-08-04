using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using openPDCManager.Data;

namespace openPDCManager
{
    /// <summary>
    /// Interaction logic for ErrorLogWindow.xaml
    /// </summary>
    public partial class ErrorLogWindow : Window
    {
        #region [ Members ]

        DispatcherTimer m_refreshTimer; 

        #endregion
        public ErrorLogWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(ErrorLogWindow_Loaded);
            this.Unloaded += new RoutedEventHandler(ErrorLogWindow_Unloaded);
        }

        void ErrorLogWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            if (m_refreshTimer != null)
            {
                m_refreshTimer.Stop();
                m_refreshTimer = null;
            }
        }

        void ErrorLogWindow_Loaded(object sender, RoutedEventArgs e)
        {
            GetErrorLog();
        }

        void GetErrorLog()
        {
            try
            {
                ListBoxErrorList.ItemsSource = CommonFunctions.ReadExceptionLog(10);
                if (m_refreshTimer == null)
                    StartTimer();
            }
            catch (Exception ex)
            {
                if (m_refreshTimer != null)
                {
                    m_refreshTimer.Stop();
                    m_refreshTimer = null;
                }
            }
        }

        void StartTimer()
        {
            m_refreshTimer = new DispatcherTimer();
            m_refreshTimer.Interval = TimeSpan.FromSeconds(60);
            m_refreshTimer.Tick += new EventHandler(m_refreshTimer_Tick);
            m_refreshTimer.Start();
        }

        void m_refreshTimer_Tick(object sender, EventArgs e)
        {
            GetErrorLog();
        }
    }
}
