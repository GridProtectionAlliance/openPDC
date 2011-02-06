//******************************************************************************************************
//  SelectMeasurement.xaml.cs - Gbtc
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
//  10/07/2010 - Mehulbhai P Thakkar
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
using openPDCManager.Utilities;
using TVA.Windows;
using System.Threading;

namespace openPDCManager.ModalDialogs
{
    /// <summary>
    /// Interaction logic for SelectMeasurement.xaml
    /// </summary>
    public partial class SelectMeasurement : SecureWindow
    {
        #region [ Members ]

        int m_sourceOutputStreamID;
        string m_sourceOutputStreamAcronym;        
        ObservableCollection<Measurement> m_measurementList;        
        Dictionary<string, string[]> m_measurementsToBeAdded;
        ActivityWindow m_activityWindow;

        #endregion

        #region [ Constructor ]
        
        public SelectMeasurement(int outputStreamID, string outputStreamAcronym)
        {
            Thread.CurrentPrincipal = ((App)Application.Current).Principal;
            InitializeComponent();            
            ButtonAdd.Content = new BitmapImage(new Uri(@"Images/Add.png", UriKind.Relative));
            ButtonSearch.Content = new BitmapImage(new Uri(@"Images/Search.png", UriKind.Relative));
            ButtonShowAll.Content = new BitmapImage(new Uri(@"Images/CancelSearch.png", UriKind.Relative));
            m_sourceOutputStreamID = outputStreamID;
            m_sourceOutputStreamAcronym = outputStreamAcronym;
            this.Title = "Add Measurements For Output Stream: " + m_sourceOutputStreamAcronym;
            Loaded += new RoutedEventHandler(SelectMeasurement_Loaded);
            ButtonAdd.Click += new RoutedEventHandler(ButtonAdd_Click);
            ButtonSearch.Click += new RoutedEventHandler(ButtonSearch_Click);
            ButtonShowAll.Click += new RoutedEventHandler(ButtonShowAll_Click);
        }

        #endregion

        #region [ Page Event Handlers ]

        void SelectMeasurement_Loaded(object sender, RoutedEventArgs e)
        {
            m_activityWindow = new ActivityWindow("Loading Data... Please Wait...");
            m_activityWindow.Show();
            m_measurementList = new ObservableCollection<Measurement>();
            m_measurementsToBeAdded = new Dictionary<string, string[]>();
            App app = (App)Application.Current;
            GetMeasurementsForOutputStream(app.NodeValue, m_sourceOutputStreamID);
        }

        #endregion

        #region [ Controls Event Handlers ]

        void ButtonShowAll_Click(object sender, RoutedEventArgs e)
        {
            //ListBoxMeasurementList.ItemsSource = m_measurementList;
            DataPagerMeasurements.ItemsSource = new ObservableCollection<object>(m_measurementList);
        }

        void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchText = TextBoxSearch.Text.ToUpper();

            List<Measurement> searchResult = new List<Measurement>();
            searchResult = (from item in m_measurementList
                            where item.PointTag.ToUpper().Contains(searchText) || item.SignalReference.ToUpper().Contains(searchText)
                            select item).ToList();
            ListBoxMeasurementList.ItemsSource = DataPagerMeasurements.ItemsSource = new ObservableCollection<object>(searchResult);   // m_measurementList;
        }

        void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (m_measurementsToBeAdded.Count > 0)
                {
                    App app = (App)Application.Current;
                    //string[] format is {Name=PointID, Tooltip=SignalReference, Tag=HistorianID}
                    foreach (KeyValuePair<string, string[]> measurement in m_measurementsToBeAdded)
                    {
                        OutputStreamMeasurement outputStreamMeasurement = new OutputStreamMeasurement();
                        outputStreamMeasurement.NodeID = app.NodeValue;
                        outputStreamMeasurement.AdapterID = m_sourceOutputStreamID;
                        outputStreamMeasurement.HistorianID = string.IsNullOrEmpty(measurement.Value[2]) ? (int?)null : Convert.ToInt32(measurement.Value[2]);
                        outputStreamMeasurement.PointID = Convert.ToInt32(measurement.Value[0]);
                        outputStreamMeasurement.SignalReference = measurement.Value[1].Replace(measurement.Value[1].Substring(0, measurement.Value[1].LastIndexOf("-")), "<UNASSIGNED>");
                        CommonFunctions.SaveOutputStreamMeasurement(null, outputStreamMeasurement, true);
                    }
                    SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Output Stream Measurements Added Successfully", SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                             ButtonType.OkOnly);                    
                    sm.Owner = Window.GetWindow(this);
                    sm.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                    sm.ShowPopup();
                    GetMeasurementsForOutputStream(app.NodeValue, m_sourceOutputStreamID);
                }
                else
                {
                    SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Please Select Measurement(s) to Add", SystemMessage = string.Empty, UserMessageType = MessageType.Information },
                             ButtonType.OkOnly);
                    sm.Owner = Window.GetWindow(this);
                    sm.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                    sm.ShowPopup();
                }
            }
            catch (Exception ex)
            {
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Add Measurements to Output Stream", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Measurement measurement = ((CheckBox)sender).DataContext as Measurement;
            
            //string[] format is {Name=PointID, Tooltip=SignalReference, Tag=HistorianID}
            //m_measurementsToBeAdded.Add(new string[] { checkedBox.Name, ToolTipService.GetToolTip(checkedBox).ToString(), checkedBox.Tag == null ? string.Empty : checkedBox.Tag.ToString() });			
            if (!m_measurementsToBeAdded.ContainsKey(measurement.PointID.ToString()))
                m_measurementsToBeAdded.Add(measurement.PointID.ToString(), new string[] { measurement.PointID.ToString(), measurement.SignalReference, measurement.HistorianID == null ? string.Empty : measurement.HistorianID.ToString() });
        }

        void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Measurement measurement = ((CheckBox)sender).DataContext as Measurement;
            
            //string[] format is {Name=PointID, Tooltip=SignalReference, Tag=HistorianID}
            //m_measurementsToBeAdded.Remove(new string[] { checkedBox.Name, ToolTipService.GetToolTip(checkedBox).ToString(), checkedBox.Tag == null ? string.Empty : checkedBox.Tag.ToString() });
            if (m_measurementsToBeAdded.ContainsKey(measurement.PointID.ToString()))
                m_measurementsToBeAdded.Remove(measurement.PointID.ToString());
        }

        #endregion

        #region [ Methods ]

        void GetMeasurementsForOutputStream(string nodeID, int outputStreamID)
        {            
            try
            {
                m_measurementList = new ObservableCollection<Measurement>(CommonFunctions.GetMeasurementsForOutputStream(null, nodeID, outputStreamID));
                //ListBoxMeasurementList.ItemsSource = m_measurementList;
                if (m_measurementList.Count > 0)
                    DataPagerMeasurements.ItemsSource = new ObservableCollection<object>(m_measurementList);
                else
                {
                    DataPagerMeasurements.ItemsSource = null;                   
                    ListBoxMeasurementList.Items.Refresh();
                }
            }
            catch (Exception ex)
            {
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Measurements For Output Stream", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }

            if (m_activityWindow != null)
                m_activityWindow.Close();
        }

        #endregion
    }
}
