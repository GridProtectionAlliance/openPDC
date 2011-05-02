//******************************************************************************************************
//  Measurements.xaml.cs - Gbtc
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
//  07/19/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using openPDCManager.Data;
using openPDCManager.Data.Entities;
using openPDCManager.Data.ServiceCommunication;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;

namespace openPDCManager.Pages.Manage
{
    /// <summary>
    /// Interaction logic for Measurements.xaml
    /// </summary>
    public partial class Measurements : UserControl
    {
        #region [ Members ]

        bool m_inEditMode = false;
        string m_signalID = string.Empty;
        int m_deviceID = 0;
        ActivityWindow m_activityWindow;
        List<Measurement> m_measurementList;

        #endregion

        #region [ Constructor ]

        public Measurements(int deviceID)
        {
            InitializeComponent();
            m_deviceID = deviceID;
            ButtonSearch.Content = new BitmapImage(new Uri(@"images/Search.png", UriKind.Relative));
            ButtonShowAll.Content = new BitmapImage(new Uri(@"images/CancelSearch.png", UriKind.Relative));
            ButtonSave.Content = new BitmapImage(new Uri(@"images/Save.png", UriKind.Relative));
            ButtonClear.Content = new BitmapImage(new Uri(@"images/Cancel.png", UriKind.Relative));
            Loaded += new RoutedEventHandler(Measurements_Loaded);
            ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
            ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
            ListBoxMeasurementList.SelectionChanged += new SelectionChangedEventHandler(ListBoxMeasurementList_SelectionChanged);
            ListBoxMeasurementList.SizeChanged += new SizeChangedEventHandler(ListBoxMeasurementList_SizeChanged);
            ComboBoxDevice.SelectionChanged += new SelectionChangedEventHandler(ComboBoxDevice_SelectionChanged);
            ButtonSearch.Click += new RoutedEventHandler(ButtonSearch_Click);
            ButtonShowAll.Click += new RoutedEventHandler(ButtonShowAll_Click);
        }

        void ListBoxMeasurementList_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (m_activityWindow != null)
                m_activityWindow.Close();
        }

        #endregion

        #region [ Control Event Handlers ]

        void ComboBoxDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            KeyValuePair<int, string> selectedDevice = (KeyValuePair<int, string>)ComboBoxDevice.SelectedItem;
            GetPhasors(selectedDevice.Key, true);
        }

        void ListBoxMeasurementList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxMeasurementList.SelectedIndex >= 0)
            {
                Measurement selectedMeasurement = ListBoxMeasurementList.SelectedItem as Measurement;
                GridMeasurementDetail.DataContext = selectedMeasurement;
                if (selectedMeasurement.HistorianID.HasValue)
                    ComboBoxHistorian.SelectedItem = new KeyValuePair<int, string>((int)selectedMeasurement.HistorianID, selectedMeasurement.HistorianAcronym);
                else
                    ComboBoxHistorian.SelectedIndex = 0;
                if (selectedMeasurement.DeviceID.HasValue)
                    ComboBoxDevice.SelectedItem = new KeyValuePair<int, string>((int)selectedMeasurement.DeviceID, selectedMeasurement.DeviceAcronym);
                else
                    ComboBoxDevice.SelectedIndex = 0;

                if (ComboBoxPhasorSource.Items.Count > 0)
                {
                    ComboBoxPhasorSource.SelectedIndex = 0;
                    if (selectedMeasurement.PhasorSourceIndex.HasValue)
                    {
                        foreach (KeyValuePair<int, string> item in ComboBoxPhasorSource.Items)
                        {
                            if (item.Value == selectedMeasurement.PhasorLabel)
                            {
                                ComboBoxPhasorSource.SelectedItem = item;
                                break;
                            }
                        }
                    }
                }

                ComboBoxSignalType.SelectedItem = new KeyValuePair<int, string>(selectedMeasurement.SignalTypeID, selectedMeasurement.SignalName);

                m_inEditMode = true;
                m_signalID = selectedMeasurement.SignalID;

                ButtonSave.Tag = "Update";
            }
        }

        void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            //Storyboard sb = new Storyboard();
            //sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            //sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            //Storyboard.SetTarget(sb, ButtonSaveTransform);
            //sb.Begin();

            if (IsValid())
            {
                Measurement measurement = new Measurement();
                measurement.HistorianID = ((KeyValuePair<int, string>)ComboBoxHistorian.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboBoxHistorian.SelectedItem).Key;
                measurement.DeviceID = ((KeyValuePair<int, string>)ComboBoxDevice.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboBoxDevice.SelectedItem).Key;
                measurement.PointTag = TextBoxPointTag.Text.CleanText();
                measurement.AlternateTag = TextBoxAlternateTag.Text.CleanText();
                measurement.SignalTypeID = ((KeyValuePair<int, string>)ComboBoxSignalType.SelectedItem).Key;
                measurement.PhasorSourceIndex = ((KeyValuePair<int, string>)ComboBoxPhasorSource.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboBoxPhasorSource.SelectedItem).Key;
                measurement.SignalReference = TextBoxSignalReference.Text.CleanText();
                measurement.Adder = TextBoxAdder.Text.ToDouble();
                measurement.Multiplier = TextBoxMultiplier.Text.ToDouble();
                measurement.Description = TextBoxDescription.Text.CleanText();
                measurement.Enabled = (bool)CheckboxEnabled.IsChecked;

                if (m_inEditMode == true && !string.IsNullOrEmpty(m_signalID))
                {
                    measurement.SignalID = m_signalID;
                    SaveMeasurement(measurement, false);
                }
                else
                    SaveMeasurement(measurement, true);
            }
        }

        void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            //Storyboard sb = new Storyboard();
            //sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            //sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            //Storyboard.SetTarget(sb, ButtonClearTransform);
            //sb.Begin();

            ClearForm();
        }

        void ButtonShowAll_Click(object sender, RoutedEventArgs e)
        {
            //Storyboard sb = new Storyboard();
            //sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            //sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            //Storyboard.SetTarget(sb, ButtonShowAllTransform);
            //sb.Begin();

            BindData(m_measurementList);
        }

        void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            //Storyboard sb = new Storyboard();
            //sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            //sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            //Storyboard.SetTarget(sb, ButtonSearchTransform);
            //sb.Begin();

            string searchText = TextBoxSearch.Text.ToUpper();
            //ListBoxMeasurementList.ItemsSource 
            List<Measurement> searchResult = new List<Measurement>();
            searchResult = (from item in m_measurementList
                            where item.PointTag.Contains(searchText) || item.SignalReference.Contains(searchText) || item.SignalSuffix.Contains(searchText) || item.Description.ToUpper().Contains(searchText)
                                  || item.DeviceAcronym.ToUpper().Contains(searchText) || item.SignalName.ToUpper().Contains(searchText) || item.SignalAcronym.Contains(searchText) || item.ID.Contains(searchText)
                            select item).ToList();
            BindData(searchResult);
        }

        #endregion

        #region [ Page Event Handlers ]

        void Measurements_Loaded(object sender, RoutedEventArgs e)
        {
            if (((App)Application.Current).Principal.IsInRole("Administrator, Editor"))
                ButtonSave.IsEnabled = true;
            else
                ButtonSave.IsEnabled = false;

            m_measurementList = new List<Measurement>();
            App app = (App)Application.Current;
            m_activityWindow = new ActivityWindow("Loading Data... Please Wait...");
            m_activityWindow.Owner = Window.GetWindow(this);
            m_activityWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            m_activityWindow.Show();
            GetSignalTypes();
            GetHistorians();
            GetDevices();
            ClearForm();
            if (m_deviceID > 0)
            {
                GetMeasurementsByDevice();
                GetDeviceByDeviceID();
            }
            else
            {
                GetMeasurementList();
            }
        }

        #endregion

        #region [ Methods ]

        void SaveMeasurement(Measurement measurement, bool isNew)
        {
            SystemMessages sm;
            try
            {
                string result = CommonFunctions.SaveMeasurement(null, measurement, isNew);
                sm = new SystemMessages(new Message()
                {
                    UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success
                },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();

                if (m_deviceID > 0)
                    GetMeasurementsByDevice();
                else
                    GetMeasurementList();

                //make this newly added or updated item as default selected. So user can click initialize right away.
                ListBoxMeasurementList.SelectedItem = (m_measurementList).Find(c => c.SignalReference == measurement.SignalReference);

                //Update Metadata in the openPDC Service.
                try
                {
                    if (measurement.HistorianID != null)
                    {
                        string runtimeID = CommonFunctions.GetRuntimeID(null, "Historian", (int)measurement.HistorianID);
                        WindowsServiceClient serviceClient = ((App)Application.Current).ServiceClient;
                        if (serviceClient.Helper.RemotingClient.CurrentState == TVA.Communication.ClientState.Connected)
                        {
                            CommonFunctions.SendCommandToWindowsService(serviceClient, "Invoke " + runtimeID + " RefreshMetadata");
                            CommonFunctions.SendCommandToWindowsService(serviceClient, "RefreshRoutes");
                        }
                    }
                }
                catch (Exception ex)
                {
                    CommonFunctions.LogException(null, "SaveMeasurement.RefreshMetadata", ex);
                }

                //ClearForm();
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.SaveMeasurement", ex);
                sm = new SystemMessages(new Message()
                {
                    UserMessage = "Failed to Save Measurement Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error
                },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }

        }

        void GetPhasors(int deviceID, bool isOptional)
        {
            try
            {
                ComboBoxPhasorSource.ItemsSource = CommonFunctions.GetPhasors(null, deviceID, isOptional);
                if (ComboBoxPhasorSource.Items.Count > 0)
                {
                    ComboBoxPhasorSource.SelectedIndex = 0;
                    if (ListBoxMeasurementList.SelectedIndex >= 0)
                    {
                        Measurement selectedMeasurement = ListBoxMeasurementList.SelectedItem as Measurement;
                        if (selectedMeasurement.PhasorSourceIndex.HasValue)
                        {
                            foreach (KeyValuePair<int, string> item in ComboBoxPhasorSource.Items)
                            {
                                if (item.Value == selectedMeasurement.PhasorLabel)
                                {
                                    ComboBoxPhasorSource.SelectedItem = item;
                                    break;
                                }
                            }
                        }
                        else
                            ComboBoxPhasorSource.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetPhasors", ex);
                SystemMessages sm = new SystemMessages(new Message()
                {
                    UserMessage = "Failed to Retrieve Phasors", SystemMessage = ex.Message, UserMessageType = MessageType.Error
                },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        void GetMeasurementsByDevice()
        {
            try
            {
                m_measurementList = CommonFunctions.GetMeasurementsByDevice(null, m_deviceID);

                BindData(m_measurementList);

                if (m_activityWindow != null)
                    m_activityWindow.Close();

            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetMeasurementsByDevice", ex);
                SystemMessages sm = new SystemMessages(new Message()
                {
                    UserMessage = "Failed to Retrieve Measurements for Device", SystemMessage = ex.Message, UserMessageType = MessageType.Error
                },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        void GetDeviceByDeviceID()
        {
            try
            {
                Device device = CommonFunctions.GetDeviceByDeviceID(null, m_deviceID);
                TextBlockHeading.Text = "Manage Measurements For Device: " + device.Acronym;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetDeviceByDeviceID", ex);
                SystemMessages sm = new SystemMessages(new Message()
                {
                    UserMessage = "Failed to Retrieve Device Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error
                },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        void GetMeasurementList()
        {
            try
            {
                m_measurementList = CommonFunctions.GetMeasurementList(null, ((App)Application.Current).NodeValue);

                BindData(m_measurementList);

                if (m_activityWindow != null)
                    m_activityWindow.Close();
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetMeasurementList", ex);
                SystemMessages sm = new SystemMessages(new Message()
                {
                    UserMessage = "Failed to Retrieve Measurement List", SystemMessage = ex.Message, UserMessageType = MessageType.Error
                },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        void GetSignalTypes()
        {
            try
            {
                ComboBoxSignalType.ItemsSource = CommonFunctions.GetSignalTypes(null, false);
                if (ComboBoxSignalType.Items.Count > 0)
                    ComboBoxSignalType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetSignalTypes", ex);
                SystemMessages sm = new SystemMessages(new Message()
                {
                    UserMessage = "Failed to Retrieve Signal Types", SystemMessage = ex.Message, UserMessageType = MessageType.Error
                },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        void GetHistorians()
        {
            try
            {
                ComboBoxHistorian.ItemsSource = CommonFunctions.GetHistorians(null, true, true, true);
                if (ComboBoxHistorian.Items.Count > 0)
                    ComboBoxHistorian.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetHistorians", ex);
                SystemMessages sm = new SystemMessages(new Message()
                {
                    UserMessage = "Failed to Retrieve Historians", SystemMessage = ex.Message, UserMessageType = MessageType.Error
                },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        void GetDevices()
        {
            try
            {
                ComboBoxDevice.ItemsSource = CommonFunctions.GetDevices(null, DeviceType.NonConcentrator, ((App)Application.Current).NodeValue, true);
                if (ComboBoxDevice.Items.Count > 0)
                    ComboBoxDevice.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetDevices", ex);
                SystemMessages sm = new SystemMessages(new Message()
                {
                    UserMessage = "Failed to Retrieve Devices", SystemMessage = ex.Message, UserMessageType = MessageType.Error
                },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        bool IsValid()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(TextBoxPointTag.Text.CleanText()))
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message()
                {
                    UserMessage = "Invalid Point Tag", SystemMessage = "Please provide valid Point Tag value.", UserMessageType = MessageType.Error
                },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxPointTag.Focus();
                });
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
                return isValid;
            }

            if (string.IsNullOrEmpty(TextBoxSignalReference.Text.CleanText()))
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message()
                {
                    UserMessage = "Invalid Signal Reference", SystemMessage = "Please provide valid Signal Reference value.", UserMessageType = MessageType.Error
                },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxSignalReference.Focus();
                });
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxAdder.Text.IsDouble())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message()
                {
                    UserMessage = "Invalid Adder", SystemMessage = "Please provide valid numeric value for Adder.", UserMessageType = MessageType.Error
                },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxAdder.Focus();
                });
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxMultiplier.Text.IsDouble())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message()
                {
                    UserMessage = "Invalid Multiplier", SystemMessage = "Please provide valid numeric value for Multiplier.", UserMessageType = MessageType.Error
                },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxMultiplier.Focus();
                });
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
                return isValid;
            }

            return isValid;
        }

        void ClearForm()
        {
            GridMeasurementDetail.DataContext = new Measurement()
            {
                Adder = 0, Multiplier = 1
            };
            if (ComboBoxDevice.Items.Count > 0)
                ComboBoxDevice.SelectedIndex = 0;
            if (ComboBoxHistorian.Items.Count > 0)
                ComboBoxHistorian.SelectedIndex = 0;
            if (ComboBoxPhasorSource.Items.Count > 0)
                ComboBoxPhasorSource.SelectedIndex = 0;
            if (ComboBoxSignalType.Items.Count > 0)
                ComboBoxSignalType.SelectedIndex = 0;
            m_inEditMode = false;
            m_signalID = string.Empty;
            ListBoxMeasurementList.SelectedIndex = -1;
            ButtonSave.Tag = "Add";
        }

        void BindData(List<Measurement> measurementList)
        {
            //ListBoxMeasurementList.ItemsSource = measurementList;
            if (measurementList.Count > 0)
                DataPagerMeasurements.ItemsSource = new ObservableCollection<Object>(measurementList);
            else
            {
                DataPagerMeasurements.ItemsSource = null;
                ListBoxMeasurementList.Items.Refresh();
            }

            if (ListBoxMeasurementList.Items.Count > 0)
                ListBoxMeasurementList.SelectedIndex = 0;
        }

        #endregion

    }
}
