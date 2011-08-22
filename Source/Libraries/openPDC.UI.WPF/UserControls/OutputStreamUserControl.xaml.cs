//******************************************************************************************************
//  OutputStreamUserControl.xaml.cs - Gbtc
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
//  08/16/2011 - Magdiel Lorenzo
//       Generated original version of source code.
//
//******************************************************************************************************

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
using openPDCManager.UI.DataModels;
using openPDCManager.UI.ViewModels;
using openPDC.UI.Modal;
using TimeSeriesFramework.UI;
using TVA.Data;

namespace openPDC.UI.UserControls
{
    /// <summary>
    /// Interaction logic for OutputStreamUserControl.xaml
    /// </summary>
    public partial class OutputStreamUserControl : UserControl
    {
        private int m_outputStreamID;
        private bool m_inEditMode;
        private Guid m_nodeValue;
        private AdoDataConnection database;

        public OutputStreamUserControl()
        {
            InitializeComponent();
            this.DataContext = new OutputStreams(10);
            database = new AdoDataConnection(TimeSeriesFramework.UI.CommonFunctions.DefaultSettingsCategory);
            ButtonInitialize.Visibility = System.Windows.Visibility.Collapsed;
            ButtonSave.Content = new BitmapImage(new Uri(@"images/Save.png", UriKind.Relative));
            ButtonClear.Content = new BitmapImage(new Uri(@"images/Cancel.png", UriKind.Relative));
            ButtonBuildCommandChannel.Content = new BitmapImage(new Uri(@"images/Add.png", UriKind.Relative));
            ButtonBuildDataChannel.Content = new BitmapImage(new Uri(@"images/Add.png", UriKind.Relative));
            UpdateLayout();
            ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
            ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
            Loaded += new RoutedEventHandler(OutputStreams_Loaded);
            ButtonBuildCommandChannel.Click += new RoutedEventHandler(ButtonBuildCommandChannel_Click);
            ButtonBuildDataChannel.Click += new RoutedEventHandler(ButtonBuildDataChannel_Click);

        }

        #region [ Page Event Handlers ]

        void OutputStreams_Loaded(object sender, RoutedEventArgs e)
        {
            m_nodeValue = (Guid)database.CurrentNodeID();
            ComboBoxType.Items.Add(new KeyValuePair<int, string>(0, "IEEE C37.118"));
            ComboBoxType.Items.Add(new KeyValuePair<int, string>(1, "BPA"));
            ComboBoxType.SelectedIndex = 0;
            ComboboxDownsamplingMethod.Items.Add("LastReceived");
            ComboboxDownsamplingMethod.Items.Add("Closest");
            ComboboxDownsamplingMethod.Items.Add("Filtered");
            ComboboxDownsamplingMethod.Items.Add("BestQuality");
            ComboboxDownsamplingMethod.SelectedIndex = 0;
            ComboboxDataFormat.Items.Add("FloatingPoint");
            ComboboxDataFormat.Items.Add("FixedInteger");
            ComboboxDataFormat.SelectedIndex = 0;
            ComboboxCoordinateFormat.Items.Add("Polar");
            ComboboxCoordinateFormat.Items.Add("Rectangular");
            ComboboxCoordinateFormat.SelectedIndex = 0;
            ClearForm();
            ChangeAdvancedOptionsVisibility(Visibility.Collapsed);

        }

        #endregion

        #region [ Control Event Handlers ]

        void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid())
            {
                OutputStream outputStream = new OutputStream();
                outputStream.NodeID = Guid.Parse(((KeyValuePair<string, string>)ComboBoxNode.SelectedItem).Key);
                outputStream.Acronym = TextBoxAcronym.Text.Trim().Replace("%", "");
                outputStream.Name = TextBoxName.Text.Trim().Replace("%", "");
                outputStream.Type = ((KeyValuePair<int, string>)ComboBoxType.SelectedItem).Key;
                outputStream.ConnectionString = TextBoxConnectionString.Text.Trim().Replace("%", "");
                outputStream.IDCode = int.Parse(TextBoxIDCode.Text);
                outputStream.CommandChannel = TextBoxCommandChannel.Text.Trim().Replace("%", "");
                outputStream.DataChannel = TextBoxDataChannel.Text.Trim().Replace("%", "");
                outputStream.AutoPublishConfigFrame = (bool)CheckBoxAutoPublishConfigFrame.IsChecked;
                outputStream.AutoStartDataChannel = (bool)CheckBoxAutoStartDataChannel.IsChecked;
                outputStream.NominalFrequency = int.Parse(TextBoxNominalFrequency.Text);
                outputStream.FramesPerSecond = int.Parse(TextBoxFramesPerSecond.Text);
                outputStream.LagTime = double.Parse(TextBoxLagTime.Text);
                outputStream.LeadTime = double.Parse(TextBoxLeadTime.Text);
                outputStream.UseLocalClockAsRealTime = (bool)CheckBoxUseLocalClockAsRealTime.IsChecked;
                outputStream.AllowSortsByArrival = (bool)CheckBoxAllowSortsByArrival.IsChecked;
                outputStream.LoadOrder = int.Parse(TextBoxLoadOrder.Text);
                outputStream.Enabled = (bool)CheckBoxEnabled.IsChecked;
                outputStream.IgnoreBadTimeStamps = (bool)CheckBoxIgnoreBadTimeStamps.IsChecked;
                outputStream.TimeResolution = int.Parse(TextBoxTimeResolution.Text);
                outputStream.AllowPreemptivePublishing = (bool)CheckBoxAllowPreemptivePublishing.IsChecked;
                outputStream.DownSamplingMethod = ComboboxDownsamplingMethod.SelectedItem.ToString();
                outputStream.DataFormat = ComboboxDataFormat.SelectedItem.ToString();
                outputStream.CoordinateFormat = ComboboxCoordinateFormat.SelectedItem.ToString();
                outputStream.CurrentScalingValue = int.Parse(TextBoxCurrentScalingValue.Text);
                outputStream.VoltageScalingValue = int.Parse(TextBoxVoltageScalingValue.Text);
                outputStream.AnalogScalingValue = int.Parse(TextBoxAnalogScalingValue.Text);
                outputStream.DigitalMaskValue = int.Parse(TextBoxDigitalMaskValue.Text);
                outputStream.PerformTimestampReasonabilityCheck = (bool)CheckBoxPerformTimestampCheck.IsChecked;

                if (m_inEditMode == true && m_outputStreamID > 0)
                {
                    outputStream.ID = m_outputStreamID;
                   // SaveOutputStream(outputStream, false);
                }
                //else
                    //SaveOutputStream(outputStream, true);
            }
        }

        void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        void ButtonBuildDataChannel_Click(object sender, RoutedEventArgs e)
        {
            ConnectionStringBuilder csb = new ConnectionStringBuilder(ConnectionStringBuilder.ConnectionType.DataChannel);
            if (!string.IsNullOrEmpty(TextBoxDataChannel.Text))
                csb.ConnectionString = TextBoxDataChannel.Text;
            csb.Closed += new EventHandler(delegate(object popupWindow, EventArgs eargs)
            {
                if ((bool)csb.DialogResult)
                    TextBoxDataChannel.Text = csb.ConnectionString;
            });
            csb.Owner = Window.GetWindow(this);
            csb.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            csb.ShowDialog();

        }

        void ButtonBuildCommandChannel_Click(object sender, RoutedEventArgs e)
        {
            ConnectionStringBuilder csb = new ConnectionStringBuilder(ConnectionStringBuilder.ConnectionType.CommandChannel);
            if (!string.IsNullOrEmpty(TextBoxCommandChannel.Text))
                csb.ConnectionString = TextBoxCommandChannel.Text;
            csb.Closed += new EventHandler(delegate(object popupWindow, EventArgs eargs)
            {
                if ((bool)csb.DialogResult)
                    TextBoxCommandChannel.Text = csb.ConnectionString;
            });
            csb.Owner = Window.GetWindow(this);
            csb.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            csb.ShowDialog();
        }

        void ButtonHelp_Click(object sender, RoutedEventArgs e)
        {
            //HelpMeChoose hmc = new HelpMeChoose(((Button)sender).Tag.ToString());
            //hmc.Owner = Window.GetWindow(this);
            //hmc.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            //hmc.ShowDialog();
        }

        private void ButtonAdvancedOptions_Click(object sender, RoutedEventArgs e)
        {
            if (StackPanelTimeResolution.Visibility == System.Windows.Visibility.Visible)
            {
                ChangeAdvancedOptionsVisibility(Visibility.Collapsed);
                OSGrid.Height = 450;
            }
            else
            {
                ChangeAdvancedOptionsVisibility(Visibility.Visible);
                OSGrid.Height = 265;
            }
        }

        #endregion

        #region [ Methods ]

        bool IsValid()
        {
            bool isValid = true;
            int result;
            double dbResult;

            if (string.IsNullOrEmpty(TextBoxAcronym.Text.Trim().Replace("%","")))
            {
                return isValid;
            }

            if (!int.TryParse(TextBoxIDCode.Text, out result) || Convert.ToInt32(TextBoxIDCode.Text) < 0)
            {
                isValid = false;
                return isValid;
            }

            if (!int.TryParse(TextBoxNominalFrequency.Text, out result))
            {
                isValid = false;
                return isValid;
            }

            if (!int.TryParse(TextBoxFramesPerSecond.Text, out result))
            {
                isValid = false;
                return isValid;
            }

            if (!double.TryParse(TextBoxLagTime.Text, out dbResult))
            {
                isValid = false;
                return isValid;
            }

            if (!double.TryParse(TextBoxLeadTime.Text, out dbResult))
            {
                isValid = false;
                return isValid;
            }

            if (!int.TryParse(TextBoxLoadOrder.Text, out result))
            {
                isValid = false;
                return isValid;
            }

            if (!int.TryParse(TextBoxTimeResolution.Text, out result))
            {
                isValid = false;
                return isValid;
            }

            if (!int.TryParse(TextBoxCurrentScalingValue.Text, out result))
            {
                isValid = false;
                return isValid;
            }

            if (!int.TryParse(TextBoxVoltageScalingValue.Text, out result))
            {
                isValid = false;
                return isValid;
            }

            if (!int.TryParse(TextBoxAnalogScalingValue.Text, out result))
            {
                isValid = false;
                return isValid;
            }

            if (!int.TryParse(TextBoxDigitalMaskValue.Text, out result))
            {
                isValid = false;
                return isValid;
            }

            return isValid;
        }

        void ClearForm()
        {
            GridOutputStreamDetail.DataContext = new OutputStream()
            {
                AutoStartDataChannel = true,
                NominalFrequency = 60,
                FramesPerSecond = 30,
                LagTime = 3,
                LeadTime = 1,
                AllowSortsByArrival = true,
                TimeResolution = 330000,
                AllowPreemptivePublishing = true,
                CurrentScalingValue = 2423,
                VoltageScalingValue = 2725785,
                AnalogScalingValue = 1373291,
                DigitalMaskValue = -65536
            };
            if (ComboBoxNode.Items.Count > 0)
                ComboBoxNode.SelectedIndex = 0;
            if (ComboBoxType.Items.Count > 0)
                ComboBoxType.SelectedIndex = 0;
            if (ComboboxDownsamplingMethod.Items.Count > 0)
                ComboboxDownsamplingMethod.SelectedIndex = 0;
            if (ComboboxCoordinateFormat.Items.Count > 0)
                ComboboxCoordinateFormat.SelectedIndex = 0;
            if (ComboboxDataFormat.Items.Count > 0)
                ComboboxDataFormat.SelectedIndex = 0;
            CheckBoxAllowSortsByArrival.IsChecked = false;
            CheckBoxAutoPublishConfigFrame.IsChecked = false;
            CheckBoxAutoStartDataChannel.IsChecked = false;
            CheckBoxEnabled.IsChecked = false;
            CheckBoxUseLocalClockAsRealTime.IsChecked = false;
            CheckBoxPerformTimestampCheck.IsChecked = false;
            m_inEditMode = false;
            m_outputStreamID = 0;
            TextBlockRuntimeID.Text = string.Empty;
            ButtonInitialize.Visibility = System.Windows.Visibility.Collapsed;
            ButtonSave.Tag = "Add";
        }

        void ChangeAdvancedOptionsVisibility(Visibility visibility)
        {
            StackPanelTimeResolution.Visibility = visibility;
            TextBoxTimeResolution.Visibility = visibility;
            StackPanelDownsamplingMethod.Visibility = visibility;
            ComboboxDownsamplingMethod.Visibility = visibility;
            StackPanelDataFormat.Visibility = visibility;
            ComboboxDataFormat.Visibility = visibility;
            StackPanelCoordinateFormat.Visibility = visibility;
            ComboboxCoordinateFormat.Visibility = visibility;
            StackPanelCurrentScalingValue.Visibility = visibility;
            TextBoxCurrentScalingValue.Visibility = visibility;
            StackPanelVoltageScalingValue.Visibility = visibility;
            TextBoxVoltageScalingValue.Visibility = visibility;
            StackPanelAnalogScalingValue.Visibility = visibility;
            TextBoxAnalogScalingValue.Visibility = visibility;
            StackPanelDigitalMaskValue.Visibility = visibility;
            TextBoxDigitalMaskValue.Visibility = visibility;
            CheckBoxAutoStartDataChannel.Visibility = visibility;
            CheckBoxAutoPublishConfigFrame.Visibility = visibility;
            CheckBoxAllowSortsByArrival.Visibility = visibility;
            CheckBoxUseLocalClockAsRealTime.Visibility = visibility;
            CheckBoxAllowPreemptivePublishing.Visibility = visibility;
            CheckBoxIgnoreBadTimeStamps.Visibility = visibility;
            CheckBoxPerformTimestampCheck.Visibility = visibility;
            ButtonAllowPreemptivePublishingHelp.Visibility = visibility;
            ButtonAllowSortsByArrivalHelp.Visibility = visibility;
            ButtonAutoPublishConfigFrameHelp.Visibility = visibility;
            ButtonDownsamplingMethodHelp.Visibility = visibility;
            ButtonIgnoreBadTimeStampsHelp.Visibility = visibility;
            ButtonStartDataChannelHelp.Visibility = visibility;
            ButtonTimeResolutionHelp.Visibility = visibility;
            ButtonUseLocalClockAsRealTimeHelp.Visibility = visibility;

        }

        #endregion

        private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                DataGrid dataGrid = sender as DataGrid;
                if (dataGrid.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show("Are you sure you want to delete " + dataGrid.SelectedItems.Count + " selected item(s)?", "Delete Selected Items", MessageBoxButton.YesNo) == MessageBoxResult.No)
                        e.Handled = true;
                }
            }
        }
    }
}
