//******************************************************************************************************
//  MasterLayoutWindow.xaml.cs - Gbtc
//
//  Copyright © 2010, Grid Protection Alliance.  All Rights Reserved.
//
//  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
//  the NOTICE file distributed with this work for additional information regarding copyright ownership.
//  The GPA licenses this file to you under the Eclipse Public License -v 1.0 (the "License"); you may
//  not use this file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://www.opensource.org/licenses/eclipse-1.0.php
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  08/31/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//  02/06/2011 - J. Ritchie Carroll
//       Updated "Help" action to launch local help if internet connectivity is not available.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using openPDCManager.Data;
using openPDCManager.Data.Entities;
using openPDCManager.Data.ServiceCommunication;
using openPDCManager.ModalDialogs;
using openPDCManager.Pages.Adapters;
using openPDCManager.Pages.Devices;
using openPDCManager.Pages.Manage;
using openPDCManager.Pages.Monitoring;
using openPDCManager.UserControls.CommonControls;
using openPDCManager.UserControls.OutputStreamControls;
using openPDCManager.Utilities;
using TVA.Reflection;
using TVA.Security;
using TVA.Windows;

namespace openPDCManager
{
    /// <summary>
    /// Interaction logic for MasterLayoutWindow.xaml
    /// </summary>
    public partial class MasterLayoutWindow : SecureWindow
    {
        #region [ Members ]

        // Constants
        private const double layoutRootHeight = 900;
        private const double layoutRootWidth = 1200;

        // Fields
        private WindowsServiceClient m_serviceClient;
        private bool m_applicationClosing = false;

        #endregion

        #region [ Constructors ]

        public MasterLayoutWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
            SizeChanged += MainWindow_SizeChanged;
            MouseDown += MainWindow_MouseDown;
            Closing += MainWindow_Closing;

            ButtonErrorLog.Content = new BitmapImage(new Uri(@"images/Log.png", UriKind.Relative));
            ButtonErrorLog.Click += ButtonErrorLog_Click;

            ButtonLogo.Content = new BitmapImage(new Uri(@"images/GPALock.png", UriKind.Relative));

            UserControlSelectNode.NodeCollectionChanged += new openPDCManager.UserControls.CommonControls.SelectNode.OnNodesChanged(UserControlSelectNode_NodeCollectionChanged);
            UserControlSelectNode.ComboboxNode.SelectionChanged += ComboboxNode_SelectionChanged;

            Version appVersion = AssemblyInfo.EntryAssembly.Version;
            Title = "openPDC Manager" + " v" + appVersion.Major + "." + appVersion.Minor + "." + appVersion.Build;
        }

        #endregion

        #region [ Methods ]

        #region [ Windows Event Handlers ]

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).Principal = Thread.CurrentPrincipal;

            if (((App)Application.Current).Principal.IsInRole("Administrator"))
                Nodes.Visibility = Security.Visibility = Visibility.Visible;
            else
                Nodes.Visibility = Security.Visibility = Visibility.Collapsed;

            if (((App)Application.Current).Principal.IsInRole("Administrator, Editor"))
            {
                ConfigurationWizard.Visibility = Visibility.Visible;
                AddNew.Visibility = Visibility.Visible;
                AddOtherDevice.Visibility = Visibility.Visible;
            }
            else
            {
                ConfigurationWizard.Visibility = Visibility.Collapsed;
                AddNew.Visibility = Visibility.Collapsed;
                AddOtherDevice.Visibility = Visibility.Collapsed;
            }

            IsolatedStorageManager.SetDefaultStorage(false);

            if (UserControlSelectNode.ComboboxNode.Items.Count > 0)
            {
                HomePageUserControl home = new HomePageUserControl();
                ContentFrame.Navigate(home);
            }
            else
            {
                NodesUserControl nodesUserControl = new NodesUserControl();
                ContentFrame.Navigate(nodesUserControl);
            }

            TextBlockCurrentUser.Text = "Current User: " + SecurityProviderCache.CurrentProvider.UserData.LoginID;
            CommonFunctions.s_currentUser = SecurityProviderCache.CurrentProvider.UserData.LoginID;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            m_applicationClosing = true;
            Properties.Settings.Default.Save();
            DisconnectFromService();
            Application.Current.Shutdown();
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            LayoutRootScale.ScaleX = (e.NewSize.Width - 15) / layoutRootWidth;
            LayoutRootScale.ScaleY = (e.NewSize.Height - 35) / layoutRootHeight;
        }

        private void MainWindow_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
                this.DragMove();
        }

        private void ConnectToService()
        {
            EllipseConnectionState.Fill = Application.Current.Resources["RedRadialGradientBrush"] as RadialGradientBrush;
            ToolTipService.SetToolTip(EllipseConnectionState, "Disconnected from openPDC Service");

            if (!string.IsNullOrEmpty(((App)Application.Current).RemoteStatusServiceUrl))
            {
                try
                {
                    // Disconnect from existsing connection if active
                    if (m_serviceClient != null)
                        DisconnectFromService();


                    Dictionary<string, string> settings = ((App)Application.Current).RemoteStatusServiceUrl.ToLower().ParseKeyValuePairs();

                    if (settings.ContainsKey("server"))
                    {
                        m_serviceClient = new WindowsServiceClient("server=" + settings["server"].Replace("{", "").Replace("}", ""));
                        m_serviceClient.Helper.RemotingClient.ConnectionEstablished += RemotingClient_ConnectionEstablished;
                        m_serviceClient.Helper.RemotingClient.ConnectionTerminated += RemotingClient_ConnectionTerminated;
                        m_serviceClient.Helper.RemotingClient.ConnectionAttempt += RemotingClient_ConnectionAttempt;

                        // Start connection cycle
                        System.Threading.ThreadPool.QueueUserWorkItem(ConnectAsync, null);

                        ((App)Application.Current).ServiceClient = m_serviceClient;
                    }
                    else
                    {
                        SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Please provide proper Remote Status Service Url value for node.", SystemMessage = "Remote Status Service Url value is not set properly for " + ((App)Application.Current).NodeName + " node." + Environment.NewLine + "Please go to Manage => Nodes screen to configure node settings." + Environment.NewLine + "For example: Server=localhost:8500", UserMessageType = MessageType.Error }, ButtonType.OkOnly);
                        sm.Owner = Window.GetWindow(this);
                        sm.ShowPopup();
                    }
                }
                catch (Exception ex)
                {
                    CommonFunctions.LogException(null, "MasterLayoutWindow_Loaded", new InvalidOperationException("Exception encountered while attempting to establish openPDC connection: " + ex.Message, ex));
                    ((App)Application.Current).ServiceClient = null;
                }
            }
            else
            {
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Please provide Remote Status Service Url value for node.", SystemMessage = "Remote Status Service Url value is not set for " + ((App)Application.Current).NodeName + " node." + Environment.NewLine + "Please go to Manage => Nodes screen to configure node settings." + Environment.NewLine + "For example: Server=localhost:8500", UserMessageType = MessageType.Error }, ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.ShowPopup();
            }
        }

        private void RemotingClient_ConnectionAttempt(object sender, EventArgs e)
        {
        }

        private void ConnectAsync(object state)
        {
            try
            {
                if (!m_applicationClosing && m_serviceClient != null)
                    m_serviceClient.Helper.Connect();
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.ConnectAsync", new InvalidOperationException("Connection to openPDC failed: " + ex.Message, ex));
            }
        }

        private void DisconnectFromService()
        {
            try
            {
                if (m_serviceClient != null)
                {
                    m_serviceClient.Helper.RemotingClient.ConnectionEstablished -= RemotingClient_ConnectionEstablished;
                    m_serviceClient.Helper.RemotingClient.ConnectionTerminated -= RemotingClient_ConnectionTerminated;
                    m_serviceClient.Helper.RemotingClient.ConnectionAttempt -= RemotingClient_ConnectionAttempt;
                    m_serviceClient.Dispose();
                }
                m_serviceClient = null;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.DisconnectFromService", new InvalidOperationException("Exception encountered while attempting to disconnect from openPDC: " + ex.Message, ex));
            }
        }

        private void RemotingClient_ConnectionTerminated(object sender, EventArgs e)
        {
            if (!m_applicationClosing)
            {
                EllipseConnectionState.Dispatcher.BeginInvoke((Action)delegate()
                {
                    EllipseConnectionState.Fill = Application.Current.Resources["RedRadialGradientBrush"] as RadialGradientBrush;
                    ToolTipService.SetToolTip(EllipseConnectionState, "Disconnected from openPDC Service");

                    if (ContentFrame.Content.GetType() == typeof(OutputStreamsUserControl))
                    {
                        OutputStreamsUserControl osuc = (OutputStreamsUserControl)ContentFrame.Content;
                        osuc.ButtonInitialize.IsEnabled = false;
                        osuc.ButtonInitialize.Foreground = new SolidColorBrush(Color.FromArgb(255, 100, 100, 100));
                    }
                    else if (ContentFrame.Content.GetType() == typeof(HistoriansUserControl))
                    {
                        HistoriansUserControl historianUserControl = (HistoriansUserControl)ContentFrame.Content;
                        historianUserControl.ButtonInitialize.IsEnabled = false;
                        historianUserControl.ButtonInitialize.Foreground = new SolidColorBrush(Color.FromArgb(255, 100, 100, 100));
                    }
                    else if (ContentFrame.Content.GetType() == typeof(CalculatedMeasurementsUserControl))
                    {
                        CalculatedMeasurementsUserControl calculatedMeasurementsUserControl = (CalculatedMeasurementsUserControl)ContentFrame.Content;
                        calculatedMeasurementsUserControl.ButtonInitialize.IsEnabled = false;
                        calculatedMeasurementsUserControl.ButtonInitialize.Foreground = new SolidColorBrush(Color.FromArgb(255, 100, 100, 100));
                    }
                    else if (ContentFrame.Content.GetType() == typeof(ManageDevicesUserControl))
                    {
                        ManageDevicesUserControl manageDevicesUserControl = (ManageDevicesUserControl)ContentFrame.Content;
                        manageDevicesUserControl.ButtonInitialize.IsEnabled = false;
                        manageDevicesUserControl.ButtonInitialize.Foreground = new SolidColorBrush(Color.FromArgb(255, 100, 100, 100));
                    }
                    else if (ContentFrame.Content.GetType() == typeof(AdapterUserControl))
                    {
                        AdapterUserControl adapterUserControl = (AdapterUserControl)ContentFrame.Content;
                        adapterUserControl.ButtonInitialize.IsEnabled = false;
                        adapterUserControl.ButtonInitialize.Foreground = new SolidColorBrush(Color.FromArgb(255, 100, 100, 100));
                    }
                    else if (ContentFrame.Content.GetType() == typeof(HomePageUserControl))
                    {
                        HomePageUserControl homePageUserControl = (HomePageUserControl)ContentFrame.Content;
                        homePageUserControl.ButtonRestartOpenPDC.IsEnabled = false;
                    }
                });
            }
        }

        private void RemotingClient_ConnectionEstablished(object sender, EventArgs e)
        {
            EllipseConnectionState.Dispatcher.BeginInvoke((Action)delegate()
            {
                EllipseConnectionState.Fill = Application.Current.Resources["GreenRadialGradientBrush"] as RadialGradientBrush;
                ToolTipService.SetToolTip(EllipseConnectionState, "Connected to openPDC Service");

                if (ContentFrame.Content.GetType() == typeof(OutputStreamsUserControl))
                {
                    OutputStreamsUserControl outputStreamUserControl = (OutputStreamsUserControl)ContentFrame.Content;
                    outputStreamUserControl.ButtonInitialize.IsEnabled = true;
                    outputStreamUserControl.ButtonInitialize.Foreground = new SolidColorBrush(Color.FromArgb(255, 9, 81, 136));
                }
                else if (ContentFrame.Content.GetType() == typeof(HistoriansUserControl))
                {
                    HistoriansUserControl historianUserControl = (HistoriansUserControl)ContentFrame.Content;
                    historianUserControl.ButtonInitialize.IsEnabled = true;
                    historianUserControl.ButtonInitialize.Foreground = new SolidColorBrush(Color.FromArgb(255, 9, 81, 136));
                }
                else if (ContentFrame.Content.GetType() == typeof(CalculatedMeasurementsUserControl))
                {
                    CalculatedMeasurementsUserControl calculatedMeasurementsUserControl = (CalculatedMeasurementsUserControl)ContentFrame.Content;
                    calculatedMeasurementsUserControl.ButtonInitialize.IsEnabled = true;
                    calculatedMeasurementsUserControl.ButtonInitialize.Foreground = new SolidColorBrush(Color.FromArgb(255, 9, 81, 136));
                }
                else if (ContentFrame.Content.GetType() == typeof(ManageDevicesUserControl))
                {
                    ManageDevicesUserControl manageDevicesUserControl = (ManageDevicesUserControl)ContentFrame.Content;
                    manageDevicesUserControl.ButtonInitialize.IsEnabled = true;
                    manageDevicesUserControl.ButtonInitialize.Foreground = new SolidColorBrush(Color.FromArgb(255, 9, 81, 136));
                }
                else if (ContentFrame.Content.GetType() == typeof(AdapterUserControl))
                {
                    AdapterUserControl adapterUserControl = (AdapterUserControl)ContentFrame.Content;
                    adapterUserControl.ButtonInitialize.IsEnabled = true;
                    adapterUserControl.ButtonInitialize.Foreground = new SolidColorBrush(Color.FromArgb(255, 9, 81, 136));
                }
                else if (ContentFrame.Content.GetType() == typeof(MonitorUserControl))
                {
                    MonitorUserControl monitorUserControl = (MonitorUserControl)ContentFrame.Content;
                    monitorUserControl.ReconnectToService();
                }
                else if (ContentFrame.Content.GetType() == typeof(HomePageUserControl))
                {
                    HomePageUserControl homePageUserControl = (HomePageUserControl)ContentFrame.Content;
                    //Eventhough connection has been established, check if user is administrator, then only enable it.
                    if (((App)Application.Current).Principal.IsInRole("Administrator"))
                        homePageUserControl.ButtonRestartOpenPDC.IsEnabled = true;
                }

            });
        }

        #endregion

        #region [ Controls Event Handlers ]

        private void ButtonErrorLog_Click(object sender, RoutedEventArgs e)
        {
            ErrorLogWindow errorLogWindow = new ErrorLogWindow();
            errorLogWindow.Owner = Window.GetWindow(this);
            errorLogWindow.WindowStartupLocation = WindowStartupLocation.Manual;

            if (MainWindow.WindowState == System.Windows.WindowState.Maximized)
            {
                errorLogWindow.Top = MainWindow.Top + MainWindow.Height - 150;
                errorLogWindow.Left = 0;
            }
            else
            {
                errorLogWindow.Top = MainWindow.Top + MainWindow.Height - 25;
                errorLogWindow.Left = MainWindow.Left;
            }
            errorLogWindow.Width = MainWindow.Width;
            errorLogWindow.Height = 150;
            errorLogWindow.Show();
        }

        private void ComboboxNode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserControlSelectNode.ComboboxNode.SelectedItem != null)
                TextBlockNode.Text = ((Node)UserControlSelectNode.ComboboxNode.SelectedItem).Name;

            HomePageUserControl home = new HomePageUserControl();
            ContentFrame.Navigate(home);

            if (m_serviceClient == null || m_serviceClient.Helper.RemotingClient.ConnectionString != ((App)Application.Current).RemoteStatusServiceUrl || m_serviceClient.Helper.RemotingClient.CurrentState == TVA.Communication.ClientState.Disconnected)
                ConnectToService();
        }

        private void UserControlSelectNode_NodeCollectionChanged(object sender, RoutedEventArgs e)
        {
            (sender as SelectNode).RefreshNodeList();
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ButtonMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonLogo_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("http://www.gridprotectionalliance.org/");
        }

        #endregion

        #region [ Menu Event Handlers ]

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = (MenuItem)e.OriginalSource;
            //if no node is defined then force user to add node.
            if (UserControlSelectNode.ComboboxNode.Items.Count == 0)
            {
                NodesUserControl nodesUserControl = new NodesUserControl();
                ContentFrame.Navigate(nodesUserControl);
            }
            else if (item.Name == "CustomInputs")
            {
                AdapterUserControl adapter = new AdapterUserControl();
                adapter.TypeOfAdapter = AdapterType.Input;
                ContentFrame.Navigate(adapter);
            }
            else if (item.Name == "CustomActions")
            {
                AdapterUserControl adapter = new AdapterUserControl();
                adapter.TypeOfAdapter = AdapterType.Action;
                ContentFrame.Navigate(adapter);
            }
            else if (item.Name == "CustomOutputs")
            {
                AdapterUserControl adapter = new AdapterUserControl();
                adapter.TypeOfAdapter = AdapterType.Output;
                ContentFrame.Navigate(adapter);
            }
            else if (item.Name == "CalculatedMeasurements")
            {
                CalculatedMeasurementsUserControl calculatedMeasurementsUserControl = new CalculatedMeasurementsUserControl();
                ContentFrame.Navigate(calculatedMeasurementsUserControl);
            }
            else if (item.Name == "Historians")
            {
                HistoriansUserControl historiansUserControl = new HistoriansUserControl();
                ContentFrame.Navigate(historiansUserControl);
            }
            else if (item.Name == "Nodes")
            {
                NodesUserControl nodesUserControl = new NodesUserControl();
                ContentFrame.Navigate(nodesUserControl);
            }
            else if (item.Name == "Companies")
            {
                CompaniesUserControl companiesUserControl = new CompaniesUserControl();
                ContentFrame.Navigate(companiesUserControl);
            }
            else if (item.Name == "Vendors")
            {
                VendorUserControl vendorUserControl = new VendorUserControl();
                ContentFrame.Navigate(vendorUserControl);
            }
            else if (item.Name == "VendorDevices")
            {
                VendorDevicesUserControl vendorDevicesUserControl = new VendorDevicesUserControl();
                ContentFrame.Navigate(vendorDevicesUserControl);
            }
            else if (item.Name == "AddOtherDevice")
            {
                ManageOtherDevicesUserControl manageOtherDeviceUserControl = new ManageOtherDevicesUserControl();
                ContentFrame.Navigate(manageOtherDeviceUserControl);
            }
            else if (item.Name == "OtherDevices")
            {
                OtherDevicesUserControl otherDevicesUserControl = new OtherDevicesUserControl();
                ContentFrame.Navigate(otherDevicesUserControl);
            }
            else if (item.Name == "AddNew")
            {
                ManageDevicesUserControl manageDevicesUserControl = new ManageDevicesUserControl();
                ContentFrame.Navigate(manageDevicesUserControl);
            }
            else if (item.Name == "BrowseDevices")
            {
                BrowseDevicesUserControl browse = new openPDCManager.Pages.Devices.BrowseDevicesUserControl();
                ContentFrame.Navigate(browse);
            }
            else if (item.Name == "Measurements")
            {
                Measurements measurements = new Measurements(0);
                ContentFrame.Navigate(measurements);
            }
            else if (item.Name == "Home")
            {
                HomePageUserControl home = new HomePageUserControl();
                ContentFrame.Navigate(home);
            }
            else if (item.Name == "IaonTree")
            {
                IaonTreeUserControl iaonTree = new IaonTreeUserControl();
                ContentFrame.Navigate(iaonTree);
            }
            else if (item.Name == "RealTimeMeasurements")
            {
                DeviceMeasurementsUserControl deviceMeasurements = new DeviceMeasurementsUserControl();
                ContentFrame.Navigate(deviceMeasurements);
            }
            else if (item.Name == "RealTimeStatistics")
            {
                RealTimeStatisticsUserControl realTimeStatistics = new RealTimeStatisticsUserControl();
                ContentFrame.Navigate(realTimeStatistics);
            }
            else if (item.Name == "RemoteConsole")
            {
                MonitorUserControl monitorControl = new MonitorUserControl();
                ContentFrame.Navigate(monitorControl);
            }
            else if (item.Name == "OutputStreams")
            {
                OutputStreamsUserControl outputStreams = new OutputStreamsUserControl();
                ContentFrame.Navigate(outputStreams);
            }
            else if (item.Name == "InputMonitor")
            {
                //SubscriptionTest inputMonitor = new SubscriptionTest();
                InputStatusUserControl inputMonitor = new InputStatusUserControl();

                //InputMonitoringUserControl inputMonitor = new InputMonitoringUserControl();
                ContentFrame.Navigate(inputMonitor);
            }
            else if (item.Name == "ConfigurationWizard")
            {
                InputWizardUserControl wizardControl = new InputWizardUserControl();
                ContentFrame.Navigate(wizardControl);
            }
            else if (item.Name == "Settings")
            {
                SystemSettings systemSettings = new SystemSettings();
                ContentFrame.Navigate(systemSettings);
            }
            else if (item.Name == "Security")
            {
                ApplicationSecurity security = new ApplicationSecurity();
                ContentFrame.Navigate(security);
            }
            else if (item.Name == "Help")
            {
                try
                {
                    // Check for internet connectivity.
                    Dns.GetHostEntry("openpdc.codeplex.com");

                    // Launch the help page available on web.
                    Process.Start("http://openpdc.codeplex.com/wikipage?title=Manager%20Configuration");
                }
                catch
                {
                    // Launch the offline copy of the help page.
                    Process.Start("openPDCManagerHelp.mht");
                }
            }
        }

        #endregion

        #endregion
    }
}
