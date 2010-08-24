//*******************************************************************************************************
//  InputMonitoringUserControl.xaml.cs - Gbtc
//
//  Tennessee Valley Authority, 2010
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  This software is made freely available under the TVA Open Source Agreement (see below).
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  08/06/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//*******************************************************************************************************

#region [ TVA Open Source Agreement ]
/*

 THIS OPEN SOURCE AGREEMENT ("AGREEMENT") DEFINES THE RIGHTS OF USE,REPRODUCTION, DISTRIBUTION,
 MODIFICATION AND REDISTRIBUTION OF CERTAIN COMPUTER SOFTWARE ORIGINALLY RELEASED BY THE
 TENNESSEE VALLEY AUTHORITY, A CORPORATE AGENCY AND INSTRUMENTALITY OF THE UNITED STATES GOVERNMENT
 ("GOVERNMENT AGENCY"). GOVERNMENT AGENCY IS AN INTENDED THIRD-PARTY BENEFICIARY OF ALL SUBSEQUENT
 DISTRIBUTIONS OR REDISTRIBUTIONS OF THE SUBJECT SOFTWARE. ANYONE WHO USES, REPRODUCES, DISTRIBUTES,
 MODIFIES OR REDISTRIBUTES THE SUBJECT SOFTWARE, AS DEFINED HEREIN, OR ANY PART THEREOF, IS, BY THAT
 ACTION, ACCEPTING IN FULL THE RESPONSIBILITIES AND OBLIGATIONS CONTAINED IN THIS AGREEMENT.

 Original Software Designation: openPDC
 Original Software Title: The TVA Open Source Phasor Data Concentrator
 User Registration Requested. Please Visit https://naspi.tva.com/Registration/
 Point of Contact for Original Software: J. Ritchie Carroll <mailto:jrcarrol@tva.gov>

 1. DEFINITIONS

 A. "Contributor" means Government Agency, as the developer of the Original Software, and any entity
 that makes a Modification.

 B. "Covered Patents" mean patent claims licensable by a Contributor that are necessarily infringed by
 the use or sale of its Modification alone or when combined with the Subject Software.

 C. "Display" means the showing of a copy of the Subject Software, either directly or by means of an
 image, or any other device.

 D. "Distribution" means conveyance or transfer of the Subject Software, regardless of means, to
 another.

 E. "Larger Work" means computer software that combines Subject Software, or portions thereof, with
 software separate from the Subject Software that is not governed by the terms of this Agreement.

 F. "Modification" means any alteration of, including addition to or deletion from, the substance or
 structure of either the Original Software or Subject Software, and includes derivative works, as that
 term is defined in the Copyright Statute, 17 USC § 101. However, the act of including Subject Software
 as part of a Larger Work does not in and of itself constitute a Modification.

 G. "Original Software" means the computer software first released under this Agreement by Government
 Agency entitled openPDC, including source code, object code and accompanying documentation, if any.

 H. "Recipient" means anyone who acquires the Subject Software under this Agreement, including all
 Contributors.

 I. "Redistribution" means Distribution of the Subject Software after a Modification has been made.

 J. "Reproduction" means the making of a counterpart, image or copy of the Subject Software.

 K. "Sale" means the exchange of the Subject Software for money or equivalent value.

 L. "Subject Software" means the Original Software, Modifications, or any respective parts thereof.

 M. "Use" means the application or employment of the Subject Software for any purpose.

 2. GRANT OF RIGHTS

 A. Under Non-Patent Rights: Subject to the terms and conditions of this Agreement, each Contributor,
 with respect to its own contribution to the Subject Software, hereby grants to each Recipient a
 non-exclusive, world-wide, royalty-free license to engage in the following activities pertaining to
 the Subject Software:

 1. Use

 2. Distribution

 3. Reproduction

 4. Modification

 5. Redistribution

 6. Display

 B. Under Patent Rights: Subject to the terms and conditions of this Agreement, each Contributor, with
 respect to its own contribution to the Subject Software, hereby grants to each Recipient under Covered
 Patents a non-exclusive, world-wide, royalty-free license to engage in the following activities
 pertaining to the Subject Software:

 1. Use

 2. Distribution

 3. Reproduction

 4. Sale

 5. Offer for Sale

 C. The rights granted under Paragraph B. also apply to the combination of a Contributor's Modification
 and the Subject Software if, at the time the Modification is added by the Contributor, the addition of
 such Modification causes the combination to be covered by the Covered Patents. It does not apply to
 any other combinations that include a Modification. 

 D. The rights granted in Paragraphs A. and B. allow the Recipient to sublicense those same rights.
 Such sublicense must be under the same terms and conditions of this Agreement.

 3. OBLIGATIONS OF RECIPIENT

 A. Distribution or Redistribution of the Subject Software must be made under this Agreement except for
 additions covered under paragraph 3H. 

 1. Whenever a Recipient distributes or redistributes the Subject Software, a copy of this Agreement
 must be included with each copy of the Subject Software; and

 2. If Recipient distributes or redistributes the Subject Software in any form other than source code,
 Recipient must also make the source code freely available, and must provide with each copy of the
 Subject Software information on how to obtain the source code in a reasonable manner on or through a
 medium customarily used for software exchange.

 B. Each Recipient must ensure that the following copyright notice appears prominently in the Subject
 Software:

          No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.

 C. Each Contributor must characterize its alteration of the Subject Software as a Modification and
 must identify itself as the originator of its Modification in a manner that reasonably allows
 subsequent Recipients to identify the originator of the Modification. In fulfillment of these
 requirements, Contributor must include a file (e.g., a change log file) that describes the alterations
 made and the date of the alterations, identifies Contributor as originator of the alterations, and
 consents to characterization of the alterations as a Modification, for example, by including a
 statement that the Modification is derived, directly or indirectly, from Original Software provided by
 Government Agency. Once consent is granted, it may not thereafter be revoked.

 D. A Contributor may add its own copyright notice to the Subject Software. Once a copyright notice has
 been added to the Subject Software, a Recipient may not remove it without the express permission of
 the Contributor who added the notice.

 E. A Recipient may not make any representation in the Subject Software or in any promotional,
 advertising or other material that may be construed as an endorsement by Government Agency or by any
 prior Recipient of any product or service provided by Recipient, or that may seek to obtain commercial
 advantage by the fact of Government Agency's or a prior Recipient's participation in this Agreement.

 F. In an effort to track usage and maintain accurate records of the Subject Software, each Recipient,
 upon receipt of the Subject Software, is requested to register with Government Agency by visiting the
 following website: https://naspi.tva.com/Registration/. Recipient's name and personal information
 shall be used for statistical purposes only. Once a Recipient makes a Modification available, it is
 requested that the Recipient inform Government Agency at the web site provided above how to access the
 Modification.

 G. Each Contributor represents that that its Modification does not violate any existing agreements,
 regulations, statutes or rules, and further that Contributor has sufficient rights to grant the rights
 conveyed by this Agreement.

 H. A Recipient may choose to offer, and to charge a fee for, warranty, support, indemnity and/or
 liability obligations to one or more other Recipients of the Subject Software. A Recipient may do so,
 however, only on its own behalf and not on behalf of Government Agency or any other Recipient. Such a
 Recipient must make it absolutely clear that any such warranty, support, indemnity and/or liability
 obligation is offered by that Recipient alone. Further, such Recipient agrees to indemnify Government
 Agency and every other Recipient for any liability incurred by them as a result of warranty, support,
 indemnity and/or liability offered by such Recipient.

 I. A Recipient may create a Larger Work by combining Subject Software with separate software not
 governed by the terms of this agreement and distribute the Larger Work as a single product. In such
 case, the Recipient must make sure Subject Software, or portions thereof, included in the Larger Work
 is subject to this Agreement.

 J. Notwithstanding any provisions contained herein, Recipient is hereby put on notice that export of
 any goods or technical data from the United States may require some form of export license from the
 U.S. Government. Failure to obtain necessary export licenses may result in criminal liability under
 U.S. laws. Government Agency neither represents that a license shall not be required nor that, if
 required, it shall be issued. Nothing granted herein provides any such export license.

 4. DISCLAIMER OF WARRANTIES AND LIABILITIES; WAIVER AND INDEMNIFICATION

 A. No Warranty: THE SUBJECT SOFTWARE IS PROVIDED "AS IS" WITHOUT ANY WARRANTY OF ANY KIND, EITHER
 EXPRESSED, IMPLIED, OR STATUTORY, INCLUDING, BUT NOT LIMITED TO, ANY WARRANTY THAT THE SUBJECT
 SOFTWARE WILL CONFORM TO SPECIFICATIONS, ANY IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
 PARTICULAR PURPOSE, OR FREEDOM FROM INFRINGEMENT, ANY WARRANTY THAT THE SUBJECT SOFTWARE WILL BE ERROR
 FREE, OR ANY WARRANTY THAT DOCUMENTATION, IF PROVIDED, WILL CONFORM TO THE SUBJECT SOFTWARE. THIS
 AGREEMENT DOES NOT, IN ANY MANNER, CONSTITUTE AN ENDORSEMENT BY GOVERNMENT AGENCY OR ANY PRIOR
 RECIPIENT OF ANY RESULTS, RESULTING DESIGNS, HARDWARE, SOFTWARE PRODUCTS OR ANY OTHER APPLICATIONS
 RESULTING FROM USE OF THE SUBJECT SOFTWARE. FURTHER, GOVERNMENT AGENCY DISCLAIMS ALL WARRANTIES AND
 LIABILITIES REGARDING THIRD-PARTY SOFTWARE, IF PRESENT IN THE ORIGINAL SOFTWARE, AND DISTRIBUTES IT
 "AS IS."

 B. Waiver and Indemnity: RECIPIENT AGREES TO WAIVE ANY AND ALL CLAIMS AGAINST GOVERNMENT AGENCY, ITS
 AGENTS, EMPLOYEES, CONTRACTORS AND SUBCONTRACTORS, AS WELL AS ANY PRIOR RECIPIENT. IF RECIPIENT'S USE
 OF THE SUBJECT SOFTWARE RESULTS IN ANY LIABILITIES, DEMANDS, DAMAGES, EXPENSES OR LOSSES ARISING FROM
 SUCH USE, INCLUDING ANY DAMAGES FROM PRODUCTS BASED ON, OR RESULTING FROM, RECIPIENT'S USE OF THE
 SUBJECT SOFTWARE, RECIPIENT SHALL INDEMNIFY AND HOLD HARMLESS  GOVERNMENT AGENCY, ITS AGENTS,
 EMPLOYEES, CONTRACTORS AND SUBCONTRACTORS, AS WELL AS ANY PRIOR RECIPIENT, TO THE EXTENT PERMITTED BY
 LAW.  THE FOREGOING RELEASE AND INDEMNIFICATION SHALL APPLY EVEN IF THE LIABILITIES, DEMANDS, DAMAGES,
 EXPENSES OR LOSSES ARE CAUSED, OCCASIONED, OR CONTRIBUTED TO BY THE NEGLIGENCE, SOLE OR CONCURRENT, OF
 GOVERNMENT AGENCY OR ANY PRIOR RECIPIENT.  RECIPIENT'S SOLE REMEDY FOR ANY SUCH MATTER SHALL BE THE
 IMMEDIATE, UNILATERAL TERMINATION OF THIS AGREEMENT.

 5. GENERAL TERMS

 A. Termination: This Agreement and the rights granted hereunder will terminate automatically if a
 Recipient fails to comply with these terms and conditions, and fails to cure such noncompliance within
 thirty (30) days of becoming aware of such noncompliance. Upon termination, a Recipient agrees to
 immediately cease use and distribution of the Subject Software. All sublicenses to the Subject
 Software properly granted by the breaching Recipient shall survive any such termination of this
 Agreement.

 B. Severability: If any provision of this Agreement is invalid or unenforceable under applicable law,
 it shall not affect the validity or enforceability of the remainder of the terms of this Agreement.

 C. Applicable Law: This Agreement shall be subject to United States federal law only for all purposes,
 including, but not limited to, determining the validity of this Agreement, the meaning of its
 provisions and the rights, obligations and remedies of the parties.

 D. Entire Understanding: This Agreement constitutes the entire understanding and agreement of the
 parties relating to release of the Subject Software and may not be superseded, modified or amended
 except by further written agreement duly executed by the parties.

 E. Binding Authority: By accepting and using the Subject Software under this Agreement, a Recipient
 affirms its authority to bind the Recipient to all terms and conditions of this Agreement and that
 Recipient hereby agrees to all terms and conditions herein.

 F. Point of Contact: Any Recipient contact with Government Agency is to be directed to the designated
 representative as follows: J. Ritchie Carroll <mailto:jrcarrol@tva.gov>.

*/
#endregion

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using openPDCManager.Data;
using openPDCManager.Data.BusinessObjects;
using openPDCManager.Data.Entities;
using openPDCManager.ModalDialogs;
using openPDCManager.Pages.Adapters;
using openPDCManager.Utilities;
using TVA.Configuration;

namespace openPDCManager.Pages.Monitoring
{
    /// <summary>
    /// Interaction logic for InputMonitoringUserControl.xaml
    /// </summary>
    public partial class InputMonitoringUserControl : UserControl
    {
        #region [ Members ]

        ActivityWindow m_activityWindow;
        ObservableCollection<DeviceMeasurementData> m_deviceMeasurementDataList;
        DeviceMeasurementDataForBinding m_dataForBinding;
        DispatcherTimer m_thirtySecondsTimer;
        KeyValuePair<int, int> m_minMaxPointIDs;
        Dictionary<int, int> m_deviceIDsWithStatusPointIDs;
        string m_urlForTree, m_timeSeriesDataServiceUrl, m_urlForStatistics, m_realTimeStatisticsServiceUrl;
        bool m_retrievingData;

        //Chart related fields        
        EnumerableDataSource<int> m_xAxisSource;
        DispatcherTimer m_chartRefreshTimer;
        Dictionary<int, EnumerableDataSource<Double>> m_yAxisSourceCollection; //this will contain PointID and corresponding data plotted on Y-axis
        Dictionary<int, List<double>> m_yAxisDataCollection;    //this will contain PointID and corresponding List<double> from the openPDC
        Dictionary<int, LineGraph> m_lineGraphCollection;                
        Dictionary<int, MeasurementInfo> m_pointsToPlot; //this will contain a list of PointIDs and MeasurementInfo
        Dictionary<int, InputMonitorData> m_currentValuesList; //this will contain PointIDs selected and corresponding current data.

        #endregion

        #region [ Constructor ]
                
        public InputMonitoringUserControl()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(InputMonitoringUserControl_Loaded);
            this.Unloaded += new RoutedEventHandler(InputMonitoringUserControl_Unloaded);
            m_dataForBinding = new DeviceMeasurementDataForBinding();
            m_deviceMeasurementDataList = new ObservableCollection<DeviceMeasurementData>();
            m_minMaxPointIDs = new KeyValuePair<int, int>();
            m_deviceIDsWithStatusPointIDs = new Dictionary<int, int>();
            UserControlDeviceDetailInfo.Visibility = Visibility.Hidden;
            //Chart related fields initializer.
            m_yAxisSourceCollection = new Dictionary<int, EnumerableDataSource<double>>();
            m_yAxisDataCollection = new Dictionary<int, List<double>>();
            m_lineGraphCollection = new Dictionary<int, LineGraph>();
            m_pointsToPlot = new Dictionary<int, MeasurementInfo>();
            m_currentValuesList = new Dictionary<int, InputMonitorData>();
        }

        #endregion

        #region [ Page Events Handlers ]

        void InputMonitoringUserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (m_thirtySecondsTimer != null)
                    m_thirtySecondsTimer.Stop();
                m_thirtySecondsTimer = null;
            }
            catch { }

            try
            {
                if (m_chartRefreshTimer != null)
                    m_chartRefreshTimer.Stop();
                m_chartRefreshTimer = null;
            }
            catch { }
        }

        void InputMonitoringUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            m_activityWindow = new ActivityWindow("Loading Data... Please Wait...");
            m_activityWindow.Owner = Window.GetWindow(this);
            m_activityWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            m_activityWindow.Show();
            GetDeviceMeasurementData();
            GetMinMaxPointIDs();            
            App app = (App)Application.Current;
            m_deviceIDsWithStatusPointIDs = CommonFunctions.GetDeviceIDsWithStatusPointIDs(app.NodeValue);

            m_realTimeStatisticsServiceUrl = app.RealTimeStatisticServiceUrl;
            if (string.IsNullOrEmpty(m_realTimeStatisticsServiceUrl))
                m_urlForStatistics = string.Empty;
            else
                m_urlForStatistics = m_realTimeStatisticsServiceUrl + "/timeseriesdata/read/current/" + m_minMaxPointIDs.Key.ToString() + "-" + m_minMaxPointIDs.Value.ToString() + "/XML";
            GetTimeTaggedMeasurementsForStatus(m_urlForStatistics);

            m_timeSeriesDataServiceUrl = app.TimeSeriesDataServiceUrl;
            if (string.IsNullOrEmpty(m_timeSeriesDataServiceUrl))
                m_urlForTree = string.Empty;
            else
                m_urlForTree = m_timeSeriesDataServiceUrl + "/timeseriesdata/read/current/" + m_minMaxPointIDs.Key.ToString() + "-" + m_minMaxPointIDs.Value.ToString() + "/XML";
            GetTimeTaggedMeasurements(m_urlForTree);

            //Chart related settings.
            //Remove legend on the right.
            Panel legendParent = (Panel)ChartPlotterDynamic.Legend.ContentGrid.Parent;
            legendParent.Children.Remove(ChartPlotterDynamic.Legend.ContentGrid);
            List<int> m_xAxisValuesList = new List<int>();            

            //Create 300 values array for x-axis.
            for (int i = 0; i < 300; i++)
            {
                m_xAxisValuesList.Add(i);
            }
            m_xAxisSource = new EnumerableDataSource<int>(m_xAxisValuesList);
            m_xAxisSource.SetXMapping(x => x);
        }

        #endregion

        #region [ Controls Event Handlers ]

        void thirtySecondsTimer_Tick(object sender, EventArgs e)
        {
            GetTimeTaggedMeasurementsForStatus(m_urlForStatistics);
            GetTimeTaggedMeasurements(m_urlForTree);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = ((CheckBox)sender);
            string signalReference = checkBox.Content.ToString();
            int pointID;
            
            if (int.TryParse(checkBox.Tag.ToString(), out pointID))
            {
                RemoveLineGraph(checkBox.DataContext);
            }         
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = ((CheckBox)sender);
            MeasurementInfo measurementInfo = (MeasurementInfo)checkBox.DataContext;
            string signalReference = checkBox.Content.ToString();
            int pointID;

            if (int.TryParse(checkBox.Tag.ToString(), out pointID))
            {
                if (!m_pointsToPlot.ContainsKey(pointID))
                {
                    lock (m_pointsToPlot)
                        m_pointsToPlot.Add(pointID, measurementInfo);
                }                    

                ThreadPool.QueueUserWorkItem(GetChartData, measurementInfo);
            }

            if (m_pointsToPlot.Count > 0 && m_chartRefreshTimer == null)
            {
                m_chartRefreshTimer = new DispatcherTimer();
                m_chartRefreshTimer.Interval = TimeSpan.FromMilliseconds(1000);
                m_chartRefreshTimer.Tick += new EventHandler(m_chartRefreshTimer_Tick);
                m_chartRefreshTimer.Start();                
            }
        }

        void m_chartRefreshTimer_Tick(object sender, EventArgs e)
        {
            Dictionary<int, MeasurementInfo> temp;
            lock (m_pointsToPlot)
            {
                temp = new Dictionary<int, MeasurementInfo>(m_pointsToPlot);
            }
            foreach (KeyValuePair<int, MeasurementInfo> item in temp)
            {
                GetChartData(item.Value);
                //ThreadPool.QueueUserWorkItem(GetChartData, item.Value);
            }
        }

        private void ButtonGetStatistics_Click(object sender, RoutedEventArgs e)
        {
            string deviceAcronym = ((Button)sender).Content.ToString();
            Device deviceInfo = CommonFunctions.GetDeviceByAcronym(deviceAcronym);
            UserControlDeviceDetailInfo.Initialize(deviceInfo);
            UserControlDeviceDetailInfo.Visibility = Visibility.Visible;
        }

        #endregion

        #region [ Methods ]

        void GetMinMaxPointIDs()
        {
            m_minMaxPointIDs = CommonFunctions.GetMinMaxPointIDs(((App)Application.Current).NodeValue);
        }

        void GetTimeTaggedMeasurementsForStatus(string url)
        {
            if (!string.IsNullOrEmpty(url) && !m_retrievingData)
            {
                try
                {
                    m_retrievingData = true;
                    Dictionary<int, TimeTaggedMeasurement> timeTaggedMeasurements = new Dictionary<int, TimeTaggedMeasurement>();
                    timeTaggedMeasurements = CommonFunctions.GetTimeTaggedMeasurements(url);
                    foreach (DeviceMeasurementData deviceMeasurement in m_deviceMeasurementDataList)
                    {
                        int statusPointID;
                        if (m_deviceIDsWithStatusPointIDs.TryGetValue(deviceMeasurement.ID, out statusPointID))
                        {
                            if (timeTaggedMeasurements.ContainsKey(statusPointID))
                            {
                                if (Convert.ToBoolean(Convert.ToInt32(timeTaggedMeasurements[statusPointID].CurrentValue)))
                                    deviceMeasurement.StatusColor = "Green";
                                else
                                    deviceMeasurement.StatusColor = "Red";
                            }
                        }

                        foreach (DeviceInfo device in deviceMeasurement.DeviceList)
                        {
                            if (device.ID != null)
                            {
                                if (m_deviceIDsWithStatusPointIDs.TryGetValue((int)device.ID, out statusPointID))
                                {
                                    if (timeTaggedMeasurements.ContainsKey(statusPointID))
                                    {
                                        if (Convert.ToBoolean(Convert.ToInt32(timeTaggedMeasurements[statusPointID].CurrentValue)))
                                            device.StatusColor = "Green";
                                        else
                                            device.StatusColor = "Red";
                                    }
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    CommonFunctions.LogException("WPF.GetTimeTaggedMeasurements", ex);
                }
                finally
                {
                    m_retrievingData = false;
                }
            }
        }

        void GetTimeTaggedMeasurements(string url)
        {
            if (!string.IsNullOrEmpty(url) && !m_retrievingData)
            {
                try
                {
                    m_retrievingData = true;
                    Dictionary<int, TimeTaggedMeasurement> timeTaggedMeasurements = new Dictionary<int, TimeTaggedMeasurement>();
                    timeTaggedMeasurements = CommonFunctions.GetTimeTaggedMeasurements(url);
                    TextBlockLastRefresh.Text = "Last Refresh: " + DateTime.Now.ToString();
                    foreach (DeviceMeasurementData deviceMeasurement in m_deviceMeasurementDataList)
                    {
                        foreach (DeviceInfo device in deviceMeasurement.DeviceList)
                        {
                            foreach (MeasurementInfo measurement in device.MeasurementList)
                            {                                
                                TimeTaggedMeasurement timeTaggedMeasurement;
                                if (timeTaggedMeasurements.TryGetValue(measurement.PointID, out timeTaggedMeasurement))
                                {
                                    measurement.CurrentValue = timeTaggedMeasurement.CurrentValue;
                                    measurement.CurrentTimeTag = timeTaggedMeasurement.TimeTag;
                                    measurement.CurrentQuality = timeTaggedMeasurement.Quality;
                                    if (measurement.SignalAcronym == "FLAG")
                                    {
                                        if (deviceMeasurement.StatusColor == "Red")
                                            device.StatusColor = "Red";
                                        else if (timeTaggedMeasurement.Quality.ToUpper() == "GOOD")
                                            device.StatusColor = "Green";
                                        else
                                            device.StatusColor = "Yellow";
                                    }
                                }
                            }
                        }
                    }

                    TreeViewDeviceMeasurements.Items.Refresh();
                    m_dataForBinding.IsExpanded = true;
                    m_dataForBinding.DeviceMeasurementDataList = m_deviceMeasurementDataList;
                    TreeViewDeviceMeasurements.DataContext = m_dataForBinding;
                }
                catch (Exception ex)
                {
                    CommonFunctions.LogException("WPF.GetTimeTaggedMeasurements", ex);
                }
                finally
                {
                    m_retrievingData = false;
                }
            }
        }

        void GetDeviceMeasurementData()
        {
            try
            {
                m_deviceMeasurementDataList = CommonFunctions.GetDeviceMeasurementData(((App)Application.Current).NodeValue);
                m_dataForBinding.DeviceMeasurementDataList = m_deviceMeasurementDataList;
                m_dataForBinding.IsExpanded = false;
                TreeViewDeviceMeasurements.DataContext = m_dataForBinding;
                if (m_thirtySecondsTimer == null)
                    StartTimer();
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.GetDeviceMeasurementsData", ex);
                SystemMessages sm = new SystemMessages(new openPDCManager.Utilities.Message() { UserMessage = "Failed to Retrieve Current Device Measurements Tree Data", SystemMessage = ex.Message, UserMessageType = openPDCManager.Utilities.MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
            if (m_activityWindow != null)
                m_activityWindow.Close();
        }

        void StartTimer()
        {
            ConfigurationFile config = ConfigurationFile.Current;
            CategorizedSettingsElementCollection configSettings = config.Settings["systemSettings"];

            string timerInterval = configSettings["RealTimeMeasurementRefreshInterval"].Value;
            int interval = 10;

            if (!string.IsNullOrEmpty(timerInterval))
            {
                if (!int.TryParse(timerInterval, out interval))
                    interval = 10;
            }

            m_thirtySecondsTimer = new DispatcherTimer();
            m_thirtySecondsTimer.Interval = TimeSpan.FromSeconds(interval);
            TextBlockRefreshInterval.Text = "Refresh Interval: " + interval.ToString() + " sec";
            m_thirtySecondsTimer.Tick += new EventHandler(thirtySecondsTimer_Tick);
            m_thirtySecondsTimer.Start();
        }

        void GetChartData(object state)
        {
            MeasurementInfo measurementInfo = (MeasurementInfo)state;

            int pointID = measurementInfo.PointID;
            string signalReference = measurementInfo.SignalReference;
                        
            List<TimeSeriesDataPointDetail> measurements;
            EnumerableDataSource<double> yDataSource;
            if (!m_yAxisSourceCollection.TryGetValue(pointID, out yDataSource))
            {
                measurements = CommonFunctions.GetTimeSeriesDataDetail(m_timeSeriesDataServiceUrl + "/timeseriesdata/read/historic/" + pointID.ToString() + "/*-10S/*/XML");                        
                List<double> values = new List<double>();
                InputMonitorData inputMonitorData = new InputMonitorData();
                foreach (TimeSeriesDataPointDetail point in measurements)
                {
                    values.Add(point.Value);
                    if (values.Count == 300)
                    {
                        inputMonitorData.PointID = pointID;
                        inputMonitorData.SignalReference = signalReference;
                        inputMonitorData.EngineeringUnit = measurementInfo.EngineeringUnits;
                        inputMonitorData.Description = measurementInfo.Description;
                        inputMonitorData.TimeStamp = point.TimeStamp;
                        inputMonitorData.Value = point.Value;
                        inputMonitorData.Quality = point.Quality;
                        break;
                    }                        
                }
                if (values.Count > 0)
                {
                    m_yAxisDataCollection.Add(pointID, values);
                    m_yAxisSourceCollection.Add(pointID, new EnumerableDataSource<double>(m_yAxisDataCollection.Last().Value));
                    m_yAxisSourceCollection[pointID].SetYMapping(y => y);
                    

                    ChartPlotterDynamic.Dispatcher.BeginInvoke((Action)delegate()
                    {                        
                        LineGraph line = null;
                        if (measurementInfo.SignalAcronym == "FREQ")
                            line = FrequencyPlotter.AddLineGraph(new CompositeDataSource(m_xAxisSource, m_yAxisSourceCollection[pointID]), 2, signalReference);
                        else if (measurementInfo.SignalAcronym == "IPHA" || measurementInfo.SignalAcronym == "VPHA")
                            line = PhaseAnglePlotter.AddLineGraph(new CompositeDataSource(m_xAxisSource, m_yAxisSourceCollection[pointID]), 2, signalReference);
                        else if (measurementInfo.SignalAcronym == "VPHM")
                            line = VoltageMagnitudePlotter.AddLineGraph(new CompositeDataSource(m_xAxisSource, m_yAxisSourceCollection[pointID]), 2, signalReference);
                        else if (measurementInfo.SignalAcronym == "IPHM")
                            line = CurrentMagnitudePlotter.AddLineGraph(new CompositeDataSource(m_xAxisSource, m_yAxisSourceCollection[pointID]), 2, signalReference);

                        if (line != null)
                        {
                            m_lineGraphCollection.Add(pointID, line);
                            inputMonitorData.Background = (SolidColorBrush)line.LinePen.Brush;
                        }
                    });

                    m_currentValuesList.Add(pointID, inputMonitorData);
                    ListBoxCurrentValues.Dispatcher.BeginInvoke((Action)delegate()
                    {
                        ListBoxCurrentValues.ItemsSource = m_currentValuesList;
                    });
                }
            }
            else
            {
                measurements = CommonFunctions.GetTimeSeriesDataDetail(m_timeSeriesDataServiceUrl + "/timeseriesdata/read/historic/" + pointID.ToString() + "/*-1S/*/XML");
                List<double> yData = m_yAxisDataCollection[pointID];
                InputMonitorData inputMonitorData = m_currentValuesList[pointID];
                foreach (TimeSeriesDataPointDetail point in measurements)
                {
                    yData.RemoveAt(0);
                    yData.Insert(yData.Count - 1, point.Value);
                    inputMonitorData.Value = point.Value;
                    inputMonitorData.TimeStamp = point.TimeStamp;
                    inputMonitorData.Quality = point.Quality;

                }

                ChartPlotterDynamic.Dispatcher.BeginInvoke((Action)delegate()
                {
                    lock (m_yAxisSourceCollection)
                        m_yAxisSourceCollection[pointID].RaiseDataChanged();
                });

                ListBoxCurrentValues.Dispatcher.BeginInvoke((Action)delegate()
                {
                    ListBoxCurrentValues.Items.Refresh();
                    ListBoxCurrentValues.ItemsSource = m_currentValuesList;
                });
            }
        }

        void RemoveLineGraph(object state)
        {
            MeasurementInfo measurementInfo = (MeasurementInfo)state;
            int pointID = measurementInfo.PointID;

            if (m_pointsToPlot.ContainsKey(pointID))
            {
                lock(m_pointsToPlot)
                    m_pointsToPlot.Remove(pointID);
            }

            if (m_yAxisSourceCollection.ContainsKey(pointID))
            {
                lock(m_yAxisSourceCollection)
                    m_yAxisSourceCollection.Remove(pointID);
            }

            if (m_yAxisDataCollection.ContainsKey(pointID))
            {
                lock (m_yAxisDataCollection)
                    m_yAxisDataCollection.Remove(pointID);
            }

            if (m_currentValuesList.ContainsKey(pointID))
            {
                lock (m_currentValuesList)
                    m_currentValuesList.Remove(pointID);

                ListBoxCurrentValues.Items.Refresh();
                ListBoxCurrentValues.ItemsSource = m_currentValuesList;
            }

            if (m_lineGraphCollection.ContainsKey(pointID))
            {
                LineGraph lineGraphToBeRemoved = m_lineGraphCollection[pointID];
                try
                {
                    if (measurementInfo.SignalAcronym == "FREQ")
                        FrequencyPlotter.Children.Remove((IPlotterElement)lineGraphToBeRemoved);
                    else if (measurementInfo.SignalAcronym == "IPHA" || measurementInfo.SignalAcronym == "VPHA")
                        PhaseAnglePlotter.Children.Remove((IPlotterElement)lineGraphToBeRemoved);
                    else if (measurementInfo.SignalAcronym == "VPHM")
                        VoltageMagnitudePlotter.Children.Remove((IPlotterElement)lineGraphToBeRemoved);
                    else if (measurementInfo.SignalAcronym == "IPHM")
                        CurrentMagnitudePlotter.Children.Remove((IPlotterElement)lineGraphToBeRemoved);                    
                }
                catch 
                { 
                
                }

                lock(m_lineGraphCollection)
                    m_lineGraphCollection.Remove(pointID);
            }

            if (m_pointsToPlot.Count == 0 && m_chartRefreshTimer != null)
            {
                m_chartRefreshTimer.Stop();
                m_chartRefreshTimer.Tick -= new EventHandler(m_chartRefreshTimer_Tick);
                m_chartRefreshTimer = null;
            }  
        }

        #endregion
        
    }
}
