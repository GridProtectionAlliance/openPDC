//*******************************************************************************************************
//  Measurements.xaml.cs - Gbtc
//
//  Tennessee Valley Authority, 2010
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  This software is made freely available under the TVA Open Source Agreement (see below).
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  07/19/2010 - Mehulbhai P Thakkar
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
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using openPDCManager.ModalDialogs;
using openPDCManager.Data.Entities;
using openPDCManager.Data;
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
        bool m_bindingData;

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

                if (ComboBoxPhasorSource.Items.Count > 0 && selectedMeasurement.PhasorSourceIndex.HasValue)
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

                ComboBoxSignalType.SelectedItem = new KeyValuePair<int, string>(selectedMeasurement.SignalTypeID, selectedMeasurement.SignalName);

                m_inEditMode = true;
                m_signalID = selectedMeasurement.SignalID;
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
                                  || item.DeviceAcronym.Contains(searchText) || item.SignalName.ToUpper().Contains(searchText) || item.SignalAcronym.Contains(searchText)
                            select item).ToList();
            BindData(searchResult);
        }

        #endregion

        #region [ Page Event Handlers ]

        void Measurements_Loaded(object sender, RoutedEventArgs e)
        {
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
                string result = CommonFunctions.SaveMeasurement(measurement, isNew);
                sm = new SystemMessages(new Message() { UserMessage = result, SystemMessage = string.Empty, UserMessageType = MessageType.Success },
                        ButtonType.OkOnly);
                if (m_deviceID > 0)
                    GetMeasurementsByDevice();
                else
                    GetMeasurementList();
                ClearForm();
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.SaveMeasurement", ex);
                sm = new SystemMessages(new Message() { UserMessage = "Failed to Save Measurement Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
            }
            sm.Owner = Window.GetWindow(this);
            sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            sm.ShowPopup();
        }

        void GetPhasors(int deviceID, bool isOptional)
        {
            try
            {
                ComboBoxPhasorSource.ItemsSource = CommonFunctions.GetPhasors(deviceID, isOptional);
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
                CommonFunctions.LogException("WPF.GetPhasors", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Phasors", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
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
                m_bindingData = false;
                m_measurementList = CommonFunctions.GetMeasurementsByDevice(m_deviceID);
                if (m_measurementList.Count > 30)
                    m_bindingData = true;

                BindData(m_measurementList);
                
                if (!m_bindingData && m_activityWindow != null)
                    m_activityWindow.Close();
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.GetMeasurementsByDevice", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Measurements for Device", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
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
                Device device = CommonFunctions.GetDeviceByDeviceID(m_deviceID);
                TextBlockHeading.Text = "Manage Measurements For Device: " + device.Acronym;                
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.GetDeviceByDeviceID", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Device Information", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
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
                m_bindingData = false;
                m_measurementList = CommonFunctions.GetMeasurementList(((App)Application.Current).NodeValue);

                if (m_measurementList.Count > 30)
                    m_bindingData = true;
             
                BindData(m_measurementList);

                if (!m_bindingData && m_activityWindow != null)
                    m_activityWindow.Close();
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.GetMeasurementList", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Measurement List", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
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
                ComboBoxSignalType.ItemsSource = CommonFunctions.GetSignalTypes(false); 
                if (ComboBoxSignalType.Items.Count > 0)
                    ComboBoxSignalType.SelectedIndex = 0;                
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.GetSignalTypes", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Signal Types", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
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
                ComboBoxHistorian.ItemsSource = CommonFunctions.GetHistorians(true, true);
                if (ComboBoxHistorian.Items.Count > 0)
                    ComboBoxHistorian.SelectedIndex = 0;                
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.GetHistorians", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Historians", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
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
                ComboBoxDevice.ItemsSource = CommonFunctions.GetDevices(DeviceType.NonConcentrator, ((App)Application.Current).NodeValue, true);
                if (ComboBoxDevice.Items.Count > 0)
                    ComboBoxDevice.SelectedIndex = 0;                
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException("WPF.GetDevices", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Devices", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
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
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Point Tag", SystemMessage = "Please provide valid Point Tag value.", UserMessageType = MessageType.Error },
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
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Signal Reference", SystemMessage = "Please provide valid Signal Reference value.", UserMessageType = MessageType.Error },
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
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Adder", SystemMessage = "Please provide valid numeric value for Adder.", UserMessageType = MessageType.Error },
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
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Multiplier", SystemMessage = "Please provide valid numeric value for Multiplier.", UserMessageType = MessageType.Error },
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
            GridMeasurementDetail.DataContext = new Measurement() { Adder = 0, Multiplier = 1 };
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
        }

        void BindData(List<Measurement> measurementList)
        {
            ListBoxMeasurementList.ItemsSource = measurementList;    
            ClearForm();
        }

        #endregion

    }
}
