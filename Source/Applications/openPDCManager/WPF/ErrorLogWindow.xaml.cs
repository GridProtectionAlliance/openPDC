//******************************************************************************************************
//  ErrorLogWindow.xaml.cs - Gbtc
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
//  08/31/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Windows;
using System.Windows.Threading;
using openPDCManager.Data;

namespace openPDCManager
{
    /// <summary>
    /// Interaction logic for ErrorLogWindow.xaml
    /// </summary>
    public partial class ErrorLogWindow : Window
    {
        #region [ Members ]

        DispatcherTimer m_refreshTimer; 

        #endregion
        public ErrorLogWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(ErrorLogWindow_Loaded);
            this.Unloaded += new RoutedEventHandler(ErrorLogWindow_Unloaded);
        }

        void ErrorLogWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            if (m_refreshTimer != null)
            {
                m_refreshTimer.Stop();
                m_refreshTimer = null;
            }
        }

        void ErrorLogWindow_Loaded(object sender, RoutedEventArgs e)
        {
            GetErrorLog();
        }

        void GetErrorLog()
        {
            try
            {
                ListBoxErrorList.ItemsSource = CommonFunctions.ReadExceptionLog(10);
                if (m_refreshTimer == null)
                    StartTimer();
            }
            catch 
            {
                if (m_refreshTimer != null)
                {
                    m_refreshTimer.Stop();
                    m_refreshTimer = null;
                }
            }
        }

        void StartTimer()
        {
            m_refreshTimer = new DispatcherTimer();
            m_refreshTimer.Interval = TimeSpan.FromSeconds(15);
            m_refreshTimer.Tick += new EventHandler(m_refreshTimer_Tick);
            m_refreshTimer.Start();
        }

        void m_refreshTimer_Tick(object sender, EventArgs e)
        {
            GetErrorLog();
        }
    }
}
