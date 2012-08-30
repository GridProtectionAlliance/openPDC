//******************************************************************************************************
//  ActivityWindow.xaml.cs - Gbtc
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
//  07/12/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System.Windows;

namespace openPDCManager.ModalDialogs
{
    /// <summary>
    /// Interaction logic for ActivityWindow.xaml
    /// </summary>
    public partial class ActivityWindow : Window
    {
        #region [ Members ]

        string m_displayMessage;

        #endregion

        #region [ Constructor ]

        public ActivityWindow(string displayMessage)
        {
            InitializeComponent();
            m_displayMessage = displayMessage;
            Loaded += new RoutedEventHandler(ActivityWindow_Loaded);
            Closing += new System.ComponentModel.CancelEventHandler(ActivityWindow_Closing);
        }

        #endregion

        #region [ Windows Event Handlers ]

        void ActivityWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UserControlActivityWindow.TextBlockMessage.Text = string.Empty;
        }

        void ActivityWindow_Loaded(object sender, RoutedEventArgs e)
        {
            UserControlActivityWindow.TextBlockMessage.Text = m_displayMessage;
        }

        #endregion
    }
}
