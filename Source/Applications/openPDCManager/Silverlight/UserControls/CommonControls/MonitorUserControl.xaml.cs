//******************************************************************************************************
//  MonitorUserControl.xaml.cs - Gbtc
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
//  07/26/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

#if SILVERLIGHT

#endif
using openPDCManager.ModalDialogs;
using System.Windows.Media.Imaging;

namespace openPDCManager.UserControls.CommonControls
{
    public partial class MonitorUserControl : UserControl
    {
        #region [ Members ]
                
        ActivityWindow m_activityWindow;
        int m_numberOfMessagesOnMonitor;

        #endregion

        public MonitorUserControl()
        {
            InitializeComponent();
            Initialize();
            this.Loaded += new RoutedEventHandler(Monitor_Loaded);
            TextBoxServiceRequest.GotFocus += new RoutedEventHandler(TextBoxServiceRequest_GotFocus);            
            ButtonSendServiceRequest.Click += new RoutedEventHandler(ButtonSendServiceRequest_Click);    
#if !SILVERLIGHT
            ButtonSendServiceRequest.Content = new BitmapImage(new Uri(@"images/Input.png", UriKind.Relative));
#endif
        }

        #region [ Control Event Handlers ]

        void TextBoxServiceRequest_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxServiceRequest.SelectAll();
        }

        void ButtonSendServiceRequest_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            Storyboard sb = new Storyboard();
            sb = Application.Current.Resources["ButtonPressAnimation"] as Storyboard;
            sb.Completed += new EventHandler(delegate(object obj, EventArgs es) { sb.Stop(); });
            Storyboard.SetTarget(sb, ButtonSendServiceRequestTransform);
            sb.Begin();
#endif
            if (!string.IsNullOrEmpty(TextBoxServiceRequest.Text))
            {
                SendRequest();
                TextBoxServiceRequest.Focus();
                TextBoxServiceRequest.SelectAll();
            }
        }

        #endregion

        #region [ Page Event Handlers ]

        void Monitor_Loaded(object sender, RoutedEventArgs e)
        {
            m_activityWindow = new ActivityWindow("Connecting to Windows Service... Please Wait...");
#if !SILVERLIGHT
            m_activityWindow.Owner = Window.GetWindow(this);
            m_activityWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
#endif
            m_activityWindow.Show();            
            TextBoxServiceRequest.Focus();
            ReconnectToService();
        }

        #endregion

    }
}
