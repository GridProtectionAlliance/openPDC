//******************************************************************************************************
//  OutputStreamMeasurementsUserControl.xaml.cs - Gbtc
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
//  07/30/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;
#if SILVERLIGHT
using openPDCManager.PhasorDataServiceProxy;

#else
using openPDCManager.Data.Entities;
using System.Windows.Media.Imaging;
#endif

namespace openPDCManager.UserControls.PopupControls
{
    public partial class OutputStreamMeasurementsUserControl : UserControl
    {
        #region [ Members ]

        public int m_sourceOutputStreamID;
        public string m_sourceOutputStreamAcronym;
        bool m_inEditMode = false;
        int m_outputStreamMeasurementID = 0;
        OutputStreamMeasurement m_selectedOutputStreamMeasurement;
        ActivityWindow m_activityWindow;

        #endregion

        #region [ Constructor ]

        public OutputStreamMeasurementsUserControl()
        {
            InitializeComponent();
            Initialize();
#if !SILVERLIGHT
            ButtonSave.Content = new BitmapImage(new Uri(@"images/Save.png", UriKind.Relative));
            ButtonClear.Content = new BitmapImage(new Uri(@"images/Cancel.png", UriKind.Relative));            
#endif
            m_selectedOutputStreamMeasurement = new OutputStreamMeasurement();     
            Loaded += new RoutedEventHandler(OutputStreamMeasurements_Loaded);
            ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
            ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
            ButtonSourceMeasurement.Click += new RoutedEventHandler(ButtonSourceMeasurement_Click);
            ListBoxOutputStreamMeasurementList.SelectionChanged += new SelectionChangedEventHandler(ListBoxOutputStreamMeasurementList_SelectionChanged);            
        }

        #endregion

        #region [ Controls Event Handlers ]

        void ButtonSourceMeasurement_Click(object sender, RoutedEventArgs e)
        {
            SelectMeasurement selectMeasurement = new SelectMeasurement(m_sourceOutputStreamID, m_sourceOutputStreamAcronym);
            selectMeasurement.Closed += new EventHandler(selectMeasurement_Closed);
            #if SILVERLIGHT            
            selectMeasurement.Show();
#else
            selectMeasurement.Owner = Window.GetWindow(this);
            selectMeasurement.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            selectMeasurement.ShowDialog();
#endif
        }

        void selectMeasurement_Closed(object sender, EventArgs e)
        {
            GetOutputStreamMeasurementList();            
        }

        void ListBoxOutputStreamMeasurementList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxOutputStreamMeasurementList.SelectedIndex >= 0)
            {
                m_selectedOutputStreamMeasurement = ListBoxOutputStreamMeasurementList.SelectedItem as OutputStreamMeasurement;
                GridOutputStreamMeasurementDetail.DataContext = m_selectedOutputStreamMeasurement;
                m_inEditMode = true;
                m_outputStreamMeasurementID = m_selectedOutputStreamMeasurement.ID;
                ButtonSave.Tag = "Update";
            }
        }

        void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            Storyboard sb = new Storyboard();
            sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            Storyboard.SetTarget(sb, ButtonClearTransform);
            sb.Begin();
#endif
            ClearForm();
        }

        void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            Storyboard sb = new Storyboard();
            sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            Storyboard.SetTarget(sb, ButtonSaveTransform);
            sb.Begin();
#endif
            //since this screen only allows editing of the existing measurement from the list box, following lines were commented and new lines were added below it.

            //OutputStreamMeasurement outputStreamMeasurement = new OutputStreamMeasurement();
            //App app = (App)Application.Current;
            //outputStreamMeasurement.NodeID = app.NodeValue;
            //outputStreamMeasurement.AdapterID = m_sourceOutputStreamID;
            //outputStreamMeasurement.HistorianID = string.IsNullOrEmpty(TextBlockHistorian.Text) ? (int?)null : Convert.ToInt32(TextBlockHistorian.Text);
            //outputStreamMeasurement.PointID = Convert.ToInt32(TextBlockPointID.Text);
            //outputStreamMeasurement.SignalReference = TextBoxSignalReference.Text;

            //if (m_inEditMode == true && m_outputStreamMeasurementID > 0)
            //{
            //    outputStreamMeasurement.ID = m_outputStreamMeasurementID;
            //    m_client.SaveOutputStreamMeasurementAsync(outputStreamMeasurement, false);
            //}
            //else
            //    m_client.SaveOutputStreamMeasurementAsync(outputStreamMeasurement, true);

            if (m_inEditMode)
            {
                m_selectedOutputStreamMeasurement.SignalReference = TextBoxSignalReference.Text.CleanText();
                SaveOutputStreamMeasurement();                
            }
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            int outputStreamMeasurementId = Convert.ToInt32(((Button)sender).Tag.ToString());
            DeleteOutputStreamMeasurement(outputStreamMeasurementId);            
        }

        #endregion

        #region [ Page Event Handlers ]

        void OutputStreamMeasurements_Loaded(object sender, RoutedEventArgs e)
        {
            m_activityWindow = new ActivityWindow("Loading Data... Please Wait...");
#if !SILVERLIGHT
            m_activityWindow.Owner = Window.GetWindow(this);
            m_activityWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
#endif
            m_activityWindow.Show();
            GetOutputStreamMeasurementList();            
        }

        #endregion

        #region [ Methods ]

        bool IsValid()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(TextBoxSignalReference.Text.CleanText()))
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Signal Reference", SystemMessage = "Please provide valid Signal Reference.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    TextBoxSignalReference.Focus();
                });                
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
#endif
                sm.ShowPopup();
                return isValid;
            }

            return isValid;
        }

        void ClearForm()
        {
            GridOutputStreamMeasurementDetail.DataContext = new OutputStreamMeasurement();
            m_inEditMode = false;
            m_outputStreamMeasurementID = 0;
            ListBoxOutputStreamMeasurementList.SelectedIndex = -1;
            ButtonSave.Tag = "Add";
        }

        #endregion
    }
}
