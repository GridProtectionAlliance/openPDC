//******************************************************************************************************
//  LogDisplay.xaml.cs - Gbtc
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
//  03/09/2012 - prasanthgs
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

namespace openPDC.UI.Modal
{
    /// <summary>
    /// Interaction logic for LogDisplay.xaml
    /// </summary>
    public partial class LogDisplay : Window
    {
        #region [Constructor]
        /// <summary>
        /// Creates a new instance of <see cref="ConnectionStringBuilder"/> class.
        /// </summary>
        public LogDisplay(string _message)
        {
            InitializeComponent();
            this.DataContext = this;
            Message = _message;
        }
        #endregion

        #region [ Members ]
        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(LogDisplay), new UIPropertyMetadata(string.Empty));
        #endregion

        #region [Properties]
        /// <summary>
        /// Gets and Sets <see cref="ICommand"/> for exception message details.
        /// </summary>
        /// 
        public string Message
        {
            get
            {
                return (string)GetValue(MessageProperty);
            }
            set
            {
                SetValue(MessageProperty, value);
            }
        }
        #endregion
    }
}
