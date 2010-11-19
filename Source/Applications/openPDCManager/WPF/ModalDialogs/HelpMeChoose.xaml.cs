//******************************************************************************************************
//  HelpMeChoose.xaml.cs - Gbtc
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
//  11/19/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace openPDCManager.ModalDialogs
{
    /// <summary>
    /// Interaction logic for HelpMeChoose.xaml
    /// </summary>
    public partial class HelpMeChoose : Window
    {
        public HelpMeChoose(string imageName)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(imageName))
                ImageHelpMeChoose.Source = new BitmapImage(new Uri(@"/openPDCManager;component/Images/" + imageName, UriKind.Relative));
        }
    }
}
