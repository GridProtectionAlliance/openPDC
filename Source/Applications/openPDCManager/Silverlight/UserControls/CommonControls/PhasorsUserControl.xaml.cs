//******************************************************************************************************
//  PhasorsUserControl.xaml.cs - Gbtc
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
//  07/16/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using openPDCManager.Utilities;
using openPDCManager.ModalDialogs;
#if SILVERLIGHT
using openPDCManager.PhasorDataServiceProxy;
#else
using openPDCManager.Data;
using openPDCManager.Data.Entities;
using System.Windows.Media.Imaging;
using System.Diagnostics;
#endif

namespace openPDCManager.UserControls.CommonControls
{
    public partial class PhasorsUserControl : UserControl
    {
        #region [ Members ]

        public int m_sourceDeviceID;
        public string m_sourceDeviceAcronym;
        bool m_inEditMode = false;
        int m_phasorID = 0;
        
        #endregion

        #region [ Constructor ]

        public PhasorsUserControl()
        {
            InitializeComponent();
            Initialize();
#if !SILVERLIGHT
            ButtonSave.Content = new BitmapImage(new Uri(@"images/Save.png", UriKind.Relative));
            ButtonClear.Content = new BitmapImage(new Uri(@"images/Cancel.png", UriKind.Relative));
            UpdateLayout();
#endif
            Loaded += new RoutedEventHandler(Phasors_Loaded);
            ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);
            ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);            
            ListBoxPhasorList.SelectionChanged += new SelectionChangedEventHandler(ListBoxPhasorList_SelectionChanged);
        }

        #endregion
               
        #region [ Controls Event Handlers ]

		void ListBoxPhasorList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (ListBoxPhasorList.SelectedIndex >= 0)
			{
				Phasor selectedPhasor = ListBoxPhasorList.SelectedItem as Phasor;
				GridPhasorDetail.DataContext = selectedPhasor;
				if (selectedPhasor.DestinationPhasorID.HasValue)
					ComboboxDestinationPhasor.SelectedItem = new KeyValuePair<int, string>((int)selectedPhasor.DestinationPhasorID, selectedPhasor.DestinationPhasorLabel);
				else if (ComboboxDestinationPhasor.Items.Count > 0)
					ComboboxDestinationPhasor.SelectedIndex = 0;
				ComboboxPhase.SelectedItem = new KeyValuePair<string, string>(selectedPhasor.Phase, selectedPhasor.PhaseType);
				ComboboxType.SelectedItem = new KeyValuePair<string, string>(selectedPhasor.Type, selectedPhasor.PhasorType);

				m_inEditMode = true;
				m_phasorID = selectedPhasor.ID;
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
            if (IsValid())
            {
                Phasor phasor = new Phasor();
                phasor.DeviceID = m_sourceDeviceID;
                phasor.Label = TextBoxLabel.Text.CleanText();
                phasor.Type = ((KeyValuePair<string, string>)ComboboxType.SelectedItem).Key;
                phasor.Phase = ((KeyValuePair<string, string>)ComboboxPhase.SelectedItem).Key;
                phasor.DestinationPhasorID = ((KeyValuePair<int, string>)ComboboxDestinationPhasor.SelectedItem).Key == 0 ? (int?)null : ((KeyValuePair<int, string>)ComboboxDestinationPhasor.SelectedItem).Key;
                phasor.SourceIndex = TextBoxSourceIndex.Text.ToInteger();

                if (m_inEditMode == true && m_phasorID > 0)
                {
                    phasor.ID = m_phasorID;
                    SavePhasor(phasor, false);
                }
                else
                    SavePhasor(phasor, true);
            }
        }
		
		#endregion

        #region [ Page Event Handlers ]

		void Phasors_Loaded(object sender, RoutedEventArgs e)
		{			
			GetPhasors();
			ComboboxPhase.Items.Add(new KeyValuePair<string, string>("+", "Positive Sequence"));
			ComboboxPhase.Items.Add(new KeyValuePair<string, string>("-", "Negative Sequence"));
            ComboboxPhase.Items.Add(new KeyValuePair<string, string>("0", "Zero Sequence"));
			ComboboxPhase.Items.Add(new KeyValuePair<string, string>("A", "Phase A"));
			ComboboxPhase.Items.Add(new KeyValuePair<string, string>("B", "Phase B"));
			ComboboxPhase.Items.Add(new KeyValuePair<string, string>("C", "Phase C"));
			ComboboxPhase.SelectedIndex = 0;

			ComboboxType.Items.Add(new KeyValuePair<string, string>("V", "Voltage"));
			ComboboxType.Items.Add(new KeyValuePair<string, string>("I", "Current"));
			ComboboxType.SelectedIndex = 0;

            ClearForm();
            GetPhasorList();
		}

		#endregion

		#region [ Methods ]

        bool IsValid()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(TextBoxLabel.Text.CleanText()))
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Phasor Label", SystemMessage = "Please provide valid phasor Label.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                                                {
                                                    TextBoxLabel.Focus();
                                                });
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);                
#endif
                sm.ShowPopup();
                return isValid;
            }

            if (!TextBoxSourceIndex.Text.IsInteger())
            {
                isValid = false;
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Invalid Phasor Source Index", SystemMessage = "Please provide valid integer value for Phasor Source Index.", UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Closed += new EventHandler(delegate(object sender, EventArgs e)
                                                {
                                                    TextBoxSourceIndex.Focus();
                                                });
#if !SILVERLIGHT
                sm.Owner = Window.GetWindow(this);                
#endif
                sm.ShowPopup();
                return isValid;
            }

            return isValid;
        }

		void ClearForm()
		{
			GridPhasorDetail.DataContext = new Phasor();
			if (ComboboxPhase.Items.Count > 0)
                ComboboxPhase.SelectedIndex = 0;
			if (ComboboxType.Items.Count > 0)
                ComboboxType.SelectedIndex = 0;
			if (ComboboxDestinationPhasor.Items.Count > 0)
                ComboboxDestinationPhasor.SelectedIndex = 0;
			ListBoxPhasorList.SelectedIndex = -1;
			m_inEditMode = false;
			m_phasorID = 0;
            ButtonSave.Tag = "Add";
		}

		#endregion

    }
}
