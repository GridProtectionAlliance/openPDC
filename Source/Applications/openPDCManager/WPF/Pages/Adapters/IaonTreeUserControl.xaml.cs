//******************************************************************************************************
//  IaonTreeUserControl.xaml.cs - Gbtc
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
//  07/22/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Windows;
using System.Windows.Controls;
using openPDCManager.Data;
using openPDCManager.ModalDialogs;
using openPDCManager.Utilities;

namespace openPDCManager.Pages.Adapters
{
    /// <summary>
    /// Interaction logic for IaonTreeUserControl.xaml
    /// </summary>
    public partial class IaonTreeUserControl : UserControl
    {
        #region [ Constructor ]

        public IaonTreeUserControl()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(IaonTreeUserControl_Loaded);
        }

        #endregion

        #region [ Page Event Handlers ]

        void IaonTreeUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            GetIaonTreeData();
        }

        #endregion

        #region [ Methods ]

        void GetIaonTreeData()
        {
            try
            {
                TreeViewIaon.ItemsSource = CommonFunctions.GetIaonTreeData(null, ((App)Application.Current).NodeValue);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "WPF.GetIaonTreeData", ex);
                SystemMessages sm = new SystemMessages(new Message() { UserMessage = "Failed to Retrieve Iaon Tree Data", SystemMessage = ex.Message, UserMessageType = MessageType.Error },
                        ButtonType.OkOnly);
                sm.Owner = Window.GetWindow(this);
                sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                sm.ShowPopup();
            }
        }

        #endregion
    }
}
