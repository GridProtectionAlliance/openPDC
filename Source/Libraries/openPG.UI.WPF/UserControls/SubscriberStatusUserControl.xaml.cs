//******************************************************************************************************
//  SubscriberStatusUserControl.xaml.cs - Gbtc
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
//  03/21/2012 - Mehulbhai Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System.Windows.Controls;
using openPG.UI.ViewModels;

namespace openPG.UI.UserControls
{
    /// <summary>
    /// Interaction logic for SubscriberStatusUserControl.xaml
    /// </summary>
    public partial class SubscriberStatusUserControl : UserControl
    {
        #region [ Members ]

        private Subscribers m_dataContext;

        #endregion

        #region [ Constructor ]

        /// <summary>
        /// Creates an instance of <see cref="SubscriberStatusUserControl"/>.
        /// </summary>
        public SubscriberStatusUserControl()
        {
            InitializeComponent();
            this.Loaded += new System.Windows.RoutedEventHandler(SubscriberStatusUserControl_Loaded);
            this.Unloaded += new System.Windows.RoutedEventHandler(SubscriberStatusUserControl_Unloaded);
            m_dataContext = new Subscribers(20);
            this.DataContext = m_dataContext;
        }

        #endregion

        #region [ Methods ]

        private void SubscriberStatusUserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            m_dataContext.StopTimer();
        }

        private void SubscriberStatusUserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            m_dataContext.StartTimer();
        }

        #endregion
    }
}
