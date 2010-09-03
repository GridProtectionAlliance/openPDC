//******************************************************************************************************
//  InputWizardUserControl.xaml.cs - Gbtc
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
//  08/13/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
#if SILVERLIGHT
using openPDCManager.PhasorDataServiceProxy;

#else
using openPDCManager.Data.BusinessObjects;
using openPDCManager.Data;
using openPDCManager.Data.Entities;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
#endif

namespace openPDCManager.UserControls.CommonControls
{
    public partial class InputWizardUserControl : UserControl
    {
        #region [ Members ]
        
        Stream m_configFileData, m_connectionFileData, m_iniFileData;
        ConnectionSettings m_connectionSettings;
        ObservableCollection<WizardDeviceInfo> m_wizardDeviceInfoList;
        Dictionary<int, string> m_vendorDeviceList;
        Dictionary<string, string> m_phasorTypes;
        Dictionary<string, string> m_phaseTypes;
        ActivityWindow m_activityWindow;
        int? m_parentID = null;
        string m_iniFileName = string.Empty;
        string m_iniFilePath = string.Empty;
        bool nextButtonClicked = false;
        bool m_skipDisableRealTimeData = false;

        #endregion

        #region [ Constructor ]

        public InputWizardUserControl()
        {
            InitializeComponent();
            Initialize();
            //Controls Events
            Loaded += new RoutedEventHandler(InputWizard_Loaded);

#if !SILVERLIGHT
            ButtonBrowseConfigurationFile.Content = new BitmapImage(new Uri(@"images/Browse.png", UriKind.Relative));
            ButtonBrowseConnectionFile.Content = new BitmapImage(new Uri(@"images/Browse.png", UriKind.Relative));
            ButtonBrowseIniFile.Content = new BitmapImage(new Uri(@"images/Browse.png", UriKind.Relative));
            ButtonNext.Content = new BitmapImage(new Uri(@"images/Next.png", UriKind.Relative));
            ButtonPrevious.Content = new BitmapImage(new Uri(@"images/Previous.png", UriKind.Relative));
            ButtonRequestConfiguration.Content = new BitmapImage(new Uri(@"images/RequestData.png", UriKind.Relative));
            ButtonBuildConnectionString.Content = new BitmapImage(new Uri(@"images/Add.png", UriKind.Relative));
            ButtonBuildCommandChannel.Content = new BitmapImage(new Uri(@"images/Add.png", UriKind.Relative));            
#endif
            ButtonBrowseConfigurationFile.Click += new RoutedEventHandler(ButtonBrowseConfigurationFile_Click);
            ButtonBrowseConnectionFile.Click += new RoutedEventHandler(ButtonBrowseConnectionFile_Click);
            ButtonBrowseIniFile.Click += new RoutedEventHandler(ButtonBrowseIniFile_Click);
            ButtonNext.Click += new RoutedEventHandler(ButtonNext_Click);
            ButtonPrevious.Click += new RoutedEventHandler(ButtonPrevious_Click);
            ButtonRequestConfiguration.Click += new RoutedEventHandler(ButtonRequestConfiguration_Click);
            ButtonBuildConnectionString.Click += new RoutedEventHandler(ButtonBuildConnectionString_Click);
            ButtonBuildCommandChannel.Click += new RoutedEventHandler(ButtonBuildCommandChannel_Click);
            AccordianWizard.SelectionChanged += new SelectionChangedEventHandler(AccordianWizard_SelectionChanged);
            CheckboxConnectToPDC.Checked += new RoutedEventHandler(CheckboxConnectToPDC_Checked);
            CheckboxConnectToPDC.Unchecked += new RoutedEventHandler(CheckboxConnectToPDC_Unchecked);
            ComboboxProtocol.SelectionChanged += new SelectionChangedEventHandler(ComboboxProtocol_SelectionChanged);
        }

        #endregion

        #region [ Controls Event Handlers ]

        void ComboboxProtocol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //If BPA PDC Stream protocol is selected, then ask users to upload their INI file.
            if (((KeyValuePair<int, string>)ComboboxProtocol.SelectedItem).Value.ToUpper().Contains("BPA"))
                IniFileUploadVisualization(Visibility.Visible);
            else
                IniFileUploadVisualization(Visibility.Collapsed);
        }

        void CheckboxConnectToPDC_Unchecked(object sender, RoutedEventArgs e)
        {
            PdcInfoVisualization(Visibility.Collapsed);
        }

        void CheckboxConnectToPDC_Checked(object sender, RoutedEventArgs e)
        {
            PdcInfoVisualization(Visibility.Visible);
        }

        void AccordianWizard_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AccordianWizard.SelectedIndex == 1)
            {
            }

            if (AccordianWizard.SelectedIndex == 2)
            {
                if ((bool)CheckboxConnectToPDC.IsChecked)
                    GetDeviceByAcronym(TextBoxPDCAcronym.Text.Replace(" ", "").ToUpper());
            }

            if (AccordianWizard.SelectedIndex == 0)
            {
                ButtonPrevious.Visibility = Visibility.Collapsed;
                ButtonNext.Tag = "Next";
            }
            else if (AccordianWizard.SelectedIndex == AccordianWizard.Items.Count - 1)
            {
                ButtonPrevious.Visibility = Visibility.Visible;
                ButtonNext.Tag = "Finish";
            }
            else
            {
                ButtonNext.Tag = "Next";
                ButtonPrevious.Visibility = Visibility.Visible;
            }
        }

        void ButtonBrowseIniFile_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            Storyboard sb = new Storyboard();
            sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            Storyboard.SetTarget(sb, ButtonBrowseIniFileTransform);
            sb.Begin();
#endif
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "INI Files (*.ini)|*.ini|All Files (*.*)|*.*";
            bool? result = openFileDialog.ShowDialog();
            if (result != null && result == true)
            {
#if SILVERLIGHT
                TextBoxIniFile.Text = openFileDialog.File.Name;
                m_iniFileName = openFileDialog.File.Name;
                m_iniFileData = openFileDialog.File.OpenRead();
                SaveIniFile();            
#else
                TextBoxIniFile.Text = openFileDialog.FileName;
                m_iniFileName = openFileDialog.FileName;
                m_iniFileData = openFileDialog.OpenFile();
#endif                                    
            }
        }

        void ButtonBrowseConnectionFile_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            Storyboard sb = new Storyboard();
            sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            Storyboard.SetTarget(sb, ButtonBrowseConnectionFileTransform);
            sb.Begin();
#endif
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "PMU Connection Files (*.PmuConnection)|*.PmuConnection|All Files (*.*)|*.*";
            bool? result = openFileDialog.ShowDialog();
            if (result != null && result == true)
            {
#if SILVERLIGHT
                TextBoxConnectionFile.Text = openFileDialog.File.Name;
                m_connectionFileData = openFileDialog.File.OpenRead();
#else
                TextBoxConnectionFile.Text = openFileDialog.FileName;
                m_connectionFileData = openFileDialog.OpenFile();
#endif
                GetConnectionSettings();
            }
        }

        void ButtonBrowseConfigurationFile_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            Storyboard sb = new Storyboard();
            sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            Storyboard.SetTarget(sb, ButtonBrowseConfigurationFileTransform);
            sb.Begin();
#endif
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
            bool? result = openFileDialog.ShowDialog();
            if (result != null && result == true)
            {
                m_activityWindow = new ActivityWindow("Validating Configuration File... Please Wait...");
                
#if SILVERLIGHT
                m_activityWindow.Show();
                TextBoxConfigurationFile.Text = openFileDialog.File.Name;
                m_configFileData = openFileDialog.File.OpenRead();
#else
                m_activityWindow.Owner = Window.GetWindow(this);
                m_activityWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                m_activityWindow.Show();
                TextBoxConfigurationFile.Text = openFileDialog.FileName;
                m_configFileData = openFileDialog.OpenFile();
#endif

                if ((((KeyValuePair<int, string>)ComboboxProtocol.SelectedItem).Value.ToUpper().Contains("BPA")) && !string.IsNullOrEmpty(m_iniFileName))
                {
                    string configFileDataString = (new StreamReader(m_configFileData)).ReadToEnd();
                    string leftPart = configFileDataString.Substring(0, configFileDataString.IndexOf("</configurationFileName>"));
                    string rightPart = configFileDataString.Substring(configFileDataString.IndexOf("</configurationFileName>"));
                    leftPart = leftPart.Substring(0, leftPart.LastIndexOf(">") + 1);
#if SILVERLIGHT
                    configFileDataString = leftPart + m_iniFilePath + "\\" + m_iniFileName + rightPart;
#else
                    configFileDataString = leftPart + m_iniFileName + rightPart;
#endif
                    Byte[] fileData = Encoding.UTF8.GetBytes(configFileDataString);
                    MemoryStream ms = new MemoryStream();
                    ms.Write(fileData, 0, fileData.Length);
                    ms.Position = 0;
#if SILVERLIGHT
                    GetWizardConfigurationInfo(ReadFileBytes(ms));
#else
                    GetWizardConfigurationInfo(ms);
#endif

                }
                else
                {
#if SILVERLIGHT
                    GetWizardConfigurationInfo(ReadFileBytes(m_configFileData));
#else
                    GetWizardConfigurationInfo(m_configFileData);
#endif
                }
            }
        }

        void ButtonPrevious_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            Storyboard sb = new Storyboard();
            sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            Storyboard.SetTarget(sb, ButtonPreviousTransform);
            sb.Begin();
#endif            
            if (AccordianWizard.SelectedIndex > 0)
            {
                AccordionItem item = AccordianWizard.Items[AccordianWizard.SelectedIndex - 1] as AccordionItem;
                item.IsSelected = true;
            }
        }

        void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            ButtonNext.IsEnabled = false;
#if SILVERLIGHT
            Storyboard sb = new Storyboard();
            sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            Storyboard.SetTarget(sb, ButtonNextTransform);
            sb.Begin();
#endif
            //here we only handle finish button. Every other Next button click is handled in the Accordian selection changed event.
            if (AccordianWizard.SelectedIndex == AccordianWizard.Items.Count - 1)
            {
                if (!nextButtonClicked)
                {
                    nextButtonClicked = true;
                    m_activityWindow = new ActivityWindow("Processing Request... Please Wait...");
#if !SILVERLIGHT
                    m_activityWindow.Owner = Window.GetWindow(this);
                    m_activityWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
#endif
                    m_activityWindow.Show();

                    App app = (App)Application.Current;
                    int? protocolID = ((KeyValuePair<int, string>)ComboboxProtocol.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboboxProtocol.SelectedItem).Key;
                    int? companyID = ((KeyValuePair<int, string>)ComboboxCompany.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboboxCompany.SelectedItem).Key;
                    int? historianID = ((KeyValuePair<int, string>)ComboboxHistorian.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboboxHistorian.SelectedItem).Key;
                    int? interconnectionID = ((KeyValuePair<int, string>)ComboboxInterconnection.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboboxInterconnection.SelectedItem).Key;
                    SaveWizardConfigurationInfo(app.NodeValue, m_wizardDeviceInfoList, this.ConnectionString(), protocolID, companyID, historianID, interconnectionID, m_parentID, m_skipDisableRealTimeData);
                }
                else
                {
                    SystemMessages sm = new SystemMessages(new openPDCManager.Utilities.Message() { UserMessage = "Application is busy processing previous request. Please wait.", SystemMessage = "", UserMessageType = openPDCManager.Utilities.MessageType.Information }, ButtonType.OkOnly);
                    sm.ShowPopup();
                }
            }

            if (AccordianWizard.SelectedIndex < AccordianWizard.Items.Count - 1)
            {
                AccordionItem item = AccordianWizard.Items[AccordianWizard.SelectedIndex + 1] as AccordionItem;
                item.IsSelected = true;
            }

            ButtonNext.IsEnabled = true;
        }

        void ComboboxVendor_Loaded(object sender, RoutedEventArgs e)
        {
            if (m_vendorDeviceList.Count > 0)
            {
                ((ComboBox)sender).ItemsSource = m_vendorDeviceList;
                ((ComboBox)sender).SelectedIndex = 0;
            }
        }

        void ComboboxType_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox phasorTypes = (ComboBox)sender;
            phasorTypes.ItemsSource = m_phasorTypes;
            try
            {
                PhasorInfo dataContext = new PhasorInfo();
                dataContext = phasorTypes.DataContext as PhasorInfo;
                foreach (KeyValuePair<string, string> item in m_phasorTypes)
                {
                    if (item.Key == dataContext.Type)
                    {
                        phasorTypes.SelectedItem = item;
                        break;
                    }
                }
            }
            catch
            {
                //we don't care
            }

        }

        void ComboboxPhase_Loaded(object sender, RoutedEventArgs e)
        {           
            ComboBox phaseTypes = (ComboBox)sender;
            phaseTypes.ItemsSource = m_phaseTypes;
            try
            {
                PhasorInfo dataContext = new PhasorInfo();
                dataContext = phaseTypes.DataContext as PhasorInfo;
                foreach (KeyValuePair<string, string> item in m_phaseTypes)
                {
                    if (item.Key == dataContext.Phase)
                    {
                        phaseTypes.SelectedItem = item;
                        break;
                    }
                }
            }
            catch
            {
                //we don't care
            }
        }
        
        void CheckAllDevices_Checked(object sender, RoutedEventArgs e)
        {
            if (m_wizardDeviceInfoList != null)
            {
                foreach (WizardDeviceInfo deviceInfo in m_wizardDeviceInfoList)
                {
                    deviceInfo.Include = true;
#if !SILVERLIGHT
                    foreach (PhasorInfo phasorInfo in deviceInfo.PhasorList)
                    {
                        phasorInfo.Include = true;
                    }
#endif
                }
#if !SILVERLIGHT
                ItemControlDeviceList.Items.Refresh();
#endif
            }            
        }

        void CheckAllDevices_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (WizardDeviceInfo deviceInfo in m_wizardDeviceInfoList)
            {
                deviceInfo.Include = false;
#if !SILVERLIGHT
                foreach (PhasorInfo phasorInfo in deviceInfo.PhasorList)
                {
                    phasorInfo.Include = false;
                }
#endif
            }
#if !SILVERLIGHT
            ItemControlDeviceList.Items.Refresh();
#endif
        }

        void CheckBox_Checked(object sender, RoutedEventArgs e)
        {   
            WizardDeviceInfo deviceInfo = (WizardDeviceInfo)((CheckBox)sender).DataContext;
            foreach (PhasorInfo phasorInfo in deviceInfo.PhasorList)
            {
                phasorInfo.Include = true;
            }
#if !SILVERLIGHT
            ItemsControl phasorItems = (((((CheckBox)sender).Parent as Border).Parent as StackPanel).Parent as StackPanel).FindName("ItemControlPhasorList") as ItemsControl;
            //var container = ItemControlDeviceList.ItemContainerGenerator.ContainerFromItem(ItemControlDeviceList.Items.CurrentItem) as FrameworkElement;
            //ItemsControl phasorItems = ItemControlDeviceList.ItemTemplate.FindName("ItemControlPhasorList", container) as ItemsControl;
            phasorItems.Items.Refresh();
#endif            
        }

        void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            WizardDeviceInfo deviceInfo = (WizardDeviceInfo)((CheckBox)sender).DataContext;
            foreach (PhasorInfo phasorInfo in deviceInfo.PhasorList)
            {
                phasorInfo.Include = false;
            }
#if !SILVERLIGHT
            ItemsControl phasorItems = (((((CheckBox)sender).Parent as Border).Parent as StackPanel).Parent as StackPanel).FindName("ItemControlPhasorList") as ItemsControl;
            //var container = ItemControlDeviceList.ItemContainerGenerator.ContainerFromItem(ItemControlDeviceList.Items.CurrentItem) as FrameworkElement;
            //ItemsControl phasorItems = ItemControlDeviceList.ItemTemplate.FindName("ItemControlPhasorList", container) as ItemsControl;
            phasorItems.Items.Refresh();
#endif            
        }

        void ButtonRequestConfiguration_Click(object sender, RoutedEventArgs e)
        {
            m_activityWindow = new ActivityWindow("Retrieving Configuration Frame... Please Wait...");
            
#if !SILVERLIGHT
            m_activityWindow.Owner = Window.GetWindow(this);
            m_activityWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
#endif
            m_activityWindow.Show();

#if SILVERLIGHT
            Storyboard sb = new Storyboard();
            sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            Storyboard.SetTarget(sb, ButtonRequestConfigurationTransform);
            sb.Begin();
#endif           
            if (!string.IsNullOrEmpty(((App)Application.Current).RemoteStatusServiceUrl))
                RetrieveConfigurationFrame();
            else
            {
            }
        }

        void ButtonBuildConnectionString_Click(object sender, RoutedEventArgs e)
        {
            ConnectionStringBuilder csb = new ConnectionStringBuilder(ConnectionStringBuilder.ConnectionType.DeviceConnection);
            if (!string.IsNullOrEmpty(TextBoxConnectionString.Text))
                csb.ConnectionString = TextBoxConnectionString.Text;
            csb.Closed += new EventHandler(delegate(object popupWindow, EventArgs eargs)
            {
                if ((bool)csb.DialogResult)
                    TextBoxConnectionString.Text = csb.ConnectionString;
            });
#if SILVERLIGHT
            csb.Show();
#else
            csb.Owner = Window.GetWindow(this);
            csb.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            csb.ShowDialog();
#endif

        }

        void ButtonBuildCommandChannel_Click(object sender, RoutedEventArgs e)
        {
            ConnectionStringBuilder csb = new ConnectionStringBuilder(ConnectionStringBuilder.ConnectionType.CommandChannel);
            if (!string.IsNullOrEmpty(TextBoxAlternateCommandChannel.Text))
                csb.ConnectionString = TextBoxAlternateCommandChannel.Text;
            csb.Closed += new EventHandler(delegate(object popupWindow, EventArgs eargs)
            {
                if (csb.DialogResult != null && (bool)csb.DialogResult)
                    TextBoxAlternateCommandChannel.Text = csb.ConnectionString;
            });
#if SILVERLIGHT
            csb.Show();
#else
            csb.Owner = Window.GetWindow(this);
            csb.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            csb.ShowDialog();
#endif
        }

        #endregion

        #region [ Methods ]

        //void UploadIniFile(string fileName, Stream fileData)
        //{
        //    string hostUrl = HtmlPage.Document.DocumentUri.AbsoluteUri;
        //    hostUrl = hostUrl.Substring(0, hostUrl.IndexOf("#"));
        //    hostUrl = hostUrl.Substring(0, hostUrl.LastIndexOf("/"));

        //    string handlerUrl = hostUrl + "/HttpHandlers/IniFileUploader.ashx";

        //    UriBuilder uriBuilder = new UriBuilder(handlerUrl);
        //    uriBuilder.Query = string.Format("fileName={0}", iniFileName);

        //    WebClient webClient = new WebClient();
        //    webClient.OpenWriteCompleted += (sender, e) =>
        //        {
        //            PushFileData(fileData, e.Result);
        //            e.Result.Close();
        //            fileData.Close();
        //        };
        //    webClient.OpenWriteAsync(uriBuilder.Uri);						
        //}
        //void PushFileData(Stream input, Stream output)
        //{
        //    byte[] buffer = new byte[4096];
        //    int bytesRead;
        //    while ((bytesRead = input.Read(buffer, 0, buffer.Length)) != 0)
        //    {
        //        output.Write(buffer, 0, bytesRead);
        //    }
        //}

        void InputWizard_Loaded(object sender, RoutedEventArgs e)
        {
            m_wizardDeviceInfoList = new ObservableCollection<WizardDeviceInfo>();
            m_vendorDeviceList = new Dictionary<int, string>();
            GetProtocols();
            GetVendorDevices();
            PdcInfoVisualization(Visibility.Collapsed);
            if (AccordianWizard.SelectedIndex == 0)
                ButtonPrevious.Visibility = Visibility.Collapsed;
            GetCompanies();
            GetHistorians();
            GetInterconnections();
            GetExecutingAssemblyPath();

            m_phaseTypes = new Dictionary<string, string>();
            m_phaseTypes.Add("+", "Positive");
            m_phaseTypes.Add("-", "Negative");
            m_phaseTypes.Add("A", "Phase A");
            m_phaseTypes.Add("B", "Phase B");
            m_phaseTypes.Add("C", "Phase C");
            
            m_phasorTypes = new Dictionary<string, string>();
            m_phasorTypes.Add("V", "Voltage");
            m_phasorTypes.Add("I", "Current");
        }

        void PdcInfoVisualization(Visibility visibility)
        {
            TextBlockPDCName.Visibility = visibility;
            TextBoxPDCName.Visibility = visibility;
            TextBlockAcronym.Visibility = visibility;
            TextBoxPDCAcronym.Visibility = visibility;
            TextBlockPDCDeviceVendor.Visibility = visibility;
            ComboboxPDCVendor.Visibility = visibility;
        }

        void IniFileUploadVisualization(Visibility visibility)
        {
            TextBlockIniFile.Visibility = visibility;
            StackPanelIniFile.Visibility = visibility;
        }

        byte[] ReadFileBytes(Stream inputStream)
        {
            byte[] bytes;
            bytes = new byte[inputStream.Length];
            try
            {
                int numBytesToRead = (int)inputStream.Length;
                int numBytesRead = 0;
                while (numBytesToRead > 0)
                {
                    // Read may return anything from 0 to numBytesToRead.
                    int n = inputStream.Read(bytes, numBytesRead, numBytesToRead);

                    // Break when the end of the file is reached.
                    if (n == 0)
                        break;

                    numBytesRead += n;
                    numBytesToRead -= n;
                }
                numBytesToRead = bytes.Length;
            }
            catch
            {
                if (m_activityWindow != null)
                    m_activityWindow.Close();
            }
            return bytes;
        }

        //T Deserialize<T>(Stream inputStream)
        //{
        //    var serializer = new DataContractSerializer(typeof(T));
        //    T deserializedObject = (T)serializer.ReadObject(inputStream);
        //    return deserializedObject;
        //}

        string ConnectionString()
        {
            string connectionString = TextBoxConnectionString.Text;
            if (!string.IsNullOrEmpty(TextBoxAlternateCommandChannel.Text))
            {
                if (!connectionString.EndsWith(";"))
                    connectionString += ";";

                connectionString += "commandchannel={" + TextBoxAlternateCommandChannel.Text + "}";
            }
            return connectionString;
        }
        
        #endregion
              
    
    }
}
