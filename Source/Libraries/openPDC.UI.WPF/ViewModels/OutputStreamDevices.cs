//******************************************************************************************************
//  OutputStreamDevices.cs - Gbtc
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
//  08/03/2011 - Aniket Salver
//       Generated original version of source code.
//  08/26/2011 - Aniket Salver
//       Added few Properties which help in binding the objects
//  09/16/2011 - Mehulbhai P Thakkar
//       Modified Load() method to display binding properly.
//       Added commands to go to other screens.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using openPDC.UI.DataModels;
using openPDC.UI.UserControls;
using TimeSeriesFramework.UI;
using TimeSeriesFramework.UI.Commands;

namespace openPDC.UI.ViewModels
{
    /// <summary>
    /// Class to hold bindable <see cref="OutputStreamDevice"/> collection and selected OutputStreamDevice for UI.
    /// </summary>
    internal class OutputStreamDevices : PagedViewModelBase<OutputStreamDevice, int>
    {

        #region [ Members ]

        // Fields

        private int m_outputStreamID;
        private Dictionary<string, string> m_phasorDataformatLookupList;
        private Dictionary<string, string> m_frequencyDataformatLookupList;
        private Dictionary<string, string> m_analogDataformatLookupList;
        private Dictionary<string, string> m_coordinateDataformatLookupList;
        private RelayCommand m_phasorCommand;
        private RelayCommand m_analogCommand;
        private RelayCommand m_digitalCommand;

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets Output Stream ID.
        /// </summary>
        public int OutputStreamID
        {
            get
            {
                return m_outputStreamID;
            }
            set
            {
                m_outputStreamID = value;
                OnPropertyChanged("OutputStreamID");
            }
        }

        /// <summary>
        /// Gets <see cref="Dictionary{T1,T2}"/> PhasorDataformat collection of type defined in the database.
        /// </summary>
        public Dictionary<string, string> PhasorDataFormatLookupList
        {
            get
            {
                return m_phasorDataformatLookupList;
            }
        }

        /// <summary>
        /// Gets <see cref="Dictionary{T1,T2}"/> FrequencyDataformat collection of type defined in the database.
        /// </summary>
        public Dictionary<string, string> FrequencyDataFormatLookupList
        {
            get
            {
                return m_frequencyDataformatLookupList;
            }
        }

        /// <summary>
        /// Gets <see cref="Dictionary{T1,T2}"/> AnalogDataformat collection of type defined in the database.
        /// </summary>
        public Dictionary<string, string> AnalogDataFormatLookupList
        {
            get
            {
                return m_analogDataformatLookupList;
            }
        }

        /// <summary>
        /// Gets <see cref="Dictionary{T1,T2}"/> CoordinateDataformat collection of type defined in the database.
        /// </summary>
        public Dictionary<string, string> CoordinateFormatLookupList
        {
            get
            {
                return m_coordinateDataformatLookupList;
            }
        }

        ///// <summary>
        ///// Gets <see cref="ICommand"/> object to go to Phasors screen.
        ///// </summary>
        //public ICommand PhasorCommand
        //{

        //}

        ///// <summary>
        ///// Gets <see cref="ICommand"/> object to go to Analogs screen.
        ///// </summary>
        //public ICommand AnalogCommand
        //{

        //}

        ///// <summary>
        ///// Gets <see cref="ICommand"/> object to go to Digitals screen.
        ///// </summary>
        //public ICommand DigitalCommand
        //{

        //}

        /// <summary>
        /// Gets flag that determines if <see cref="PagedViewModelBase{T1, T2}.CurrentItem"/> is a new record.
        /// </summary>
        public override bool IsNewRecord
        {
            get
            {
                return CurrentItem.ID == 0;
            }
        }

        #endregion

        #region [ Constructor ]

        /// <summary>
        /// Creates an instance of <see cref="OutputStreamDevices"/> class.
        /// </summary>
        /// <param name="outputStreamID">ID of the output stream to filter data.</param>
        /// <param name="itemsPerPage">Integer value to determine number of items per page.</param>
        /// <param name="autoSave">Boolean value to determine is user changes should be saved automatically.</param>
        public OutputStreamDevices(int outputStreamID, int itemsPerPage, bool autoSave = true)
            : base(itemsPerPage, autoSave)
        {
            OutputStreamID = outputStreamID;

            m_phasorDataformatLookupList = new Dictionary<string, string>();
            m_phasorDataformatLookupList.Add("", "Select Phasor Data Format");
            m_phasorDataformatLookupList.Add("FloatingPoint", "FloatingPoint");
            m_phasorDataformatLookupList.Add("FixedInteger", "FixedInteger");

            m_frequencyDataformatLookupList = new Dictionary<string, string>();
            m_frequencyDataformatLookupList.Add("", "Select Frequency Data Format");
            m_frequencyDataformatLookupList.Add("FloatingPoint", "FloatingPoint");
            m_frequencyDataformatLookupList.Add("FixedInteger", "FixedInteger");

            m_analogDataformatLookupList = new Dictionary<string, string>();
            m_analogDataformatLookupList.Add("", "Select Frequency Data Format");
            m_analogDataformatLookupList.Add("FloatingPoint", "FloatingPoint");
            m_analogDataformatLookupList.Add("FixedInteger", "FixedInteger");

            m_coordinateDataformatLookupList = new Dictionary<string, string>();
            m_coordinateDataformatLookupList.Add("", "Select Coordinate Format");
            m_coordinateDataformatLookupList.Add("Polar", "Polar");
            m_coordinateDataformatLookupList.Add("Rectangular", "Rectangular");
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Loads output stream devices.
        /// </summary>
        public override void Load()
        {
            try
            {
                ItemsSource = OutputStreamDevice.Load(null, OutputStreamID);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    Popup(ex.Message + Environment.NewLine + "Inner Exception: " + ex.InnerException.Message, "Load " + DataModelName + " Exception:", MessageBoxImage.Error);
                else
                    Popup(ex.Message, "Load " + DataModelName + " Exception:", MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Gets the primary key value of the <see cref="PagedViewModelBase{T1, T2}.CurrentItem"/>.
        /// </summary>
        /// <returns>The primary key value of the <see cref="PagedViewModelBase{T1, T2}.CurrentItem"/>.</returns>
        public override int GetCurrentItemKey()
        {
            return CurrentItem.ID;
        }

        /// <summary>
        /// Gets the string based named identifier of the <see cref="PagedViewModelBase{T1, T2}.CurrentItem"/>.
        /// </summary>
        /// <returns>The string based named identifier of the <see cref="PagedViewModelBase{T1, T2}.CurrentItem"/>.</returns>
        public override string GetCurrentItemName()
        {
            return CurrentItem.Name;
        }

        private void GoToPhasors()
        {
            UIElement frame = null;
            UIElement groupBox = null;
            TimeSeriesFramework.UI.CommonFunctions.GetFirstChild(Application.Current.MainWindow, typeof(System.Windows.Controls.Frame), ref frame);
            TimeSeriesFramework.UI.CommonFunctions.GetFirstChild(Application.Current.MainWindow, typeof(GroupBox), ref groupBox);

            if (frame != null)
            {
                OutputStreamDevicePhasorUserControl outputStreamDevicePhasorUserControl = new OutputStreamDevicePhasorUserControl(CurrentItem.ID);
                ((System.Windows.Controls.Frame)frame).Navigate(outputStreamDevicePhasorUserControl);

                if (groupBox != null)
                {
                    Run run = new Run();
                    run.FontWeight = FontWeights.Bold;
                    run.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    run.Text = "Manage Phasors for " + CurrentItem.Acronym;

                    TextBlock txt = new TextBlock();
                    txt.Padding = new Thickness(5.0);
                    txt.Inlines.Add(run);

                    ((GroupBox)groupBox).Header = txt;
                }
            }
        }

        private void GoToAnalogs()
        {
            UIElement frame = null;
            UIElement groupBox = null;
            TimeSeriesFramework.UI.CommonFunctions.GetFirstChild(Application.Current.MainWindow, typeof(System.Windows.Controls.Frame), ref frame);
            TimeSeriesFramework.UI.CommonFunctions.GetFirstChild(Application.Current.MainWindow, typeof(GroupBox), ref groupBox);

            if (frame != null)
            {
                OutputStreamDeviceAnalogUserControl outputStreamDeviceAnalogUserControl = new OutputStreamDeviceAnalogUserControl(CurrentItem.ID);
                ((System.Windows.Controls.Frame)frame).Navigate(outputStreamDeviceAnalogUserControl);

                if (groupBox != null)
                {
                    Run run = new Run();
                    run.FontWeight = FontWeights.Bold;
                    run.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    run.Text = "Manage Analogs for " + CurrentItem.Acronym;

                    TextBlock txt = new TextBlock();
                    txt.Padding = new Thickness(5.0);
                    txt.Inlines.Add(run);

                    ((GroupBox)groupBox).Header = txt;
                }
            }
        }

        private void GoToDigitals()
        {
            UIElement frame = null;
            UIElement groupBox = null;
            TimeSeriesFramework.UI.CommonFunctions.GetFirstChild(Application.Current.MainWindow, typeof(System.Windows.Controls.Frame), ref frame);
            TimeSeriesFramework.UI.CommonFunctions.GetFirstChild(Application.Current.MainWindow, typeof(GroupBox), ref groupBox);

            if (frame != null)
            {
                OutputStreamDeviceDigitalUserControl outputStreamDeviceDigitalUserControl = new OutputStreamDeviceDigitalUserControl(CurrentItem.ID);
                ((System.Windows.Controls.Frame)frame).Navigate(outputStreamDeviceDigitalUserControl);

                if (groupBox != null)
                {
                    Run run = new Run();
                    run.FontWeight = FontWeights.Bold;
                    run.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    run.Text = "Manage Digitals for " + CurrentItem.Acronym;

                    TextBlock txt = new TextBlock();
                    txt.Padding = new Thickness(5.0);
                    txt.Inlines.Add(run);

                    ((GroupBox)groupBox).Header = txt;
                }
            }
        }

        #endregion
    }
}
