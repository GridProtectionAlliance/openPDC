//******************************************************************************************************
//  ManualConfigurator.xaml.cs - Gbtc
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
//  09/30/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Windows;
using System.Windows.Media.Imaging;
using TVA.PhasorProtocols;
using TVA.Windows;
using System.Threading;

namespace openPDCManager.ModalDialogs
{
    /// <summary>
    /// Interaction logic for ManualConfigurator.xaml
    /// </summary>
    public partial class ManualConfigurator : SecureWindow
    {
        public ManualConfigurator(IConfigurationFrame configurationFrame)
        {
            Thread.CurrentPrincipal = ((App)Application.Current).Principal;
            InitializeComponent();
            ButtonSave.Content = new BitmapImage(new Uri(@"images/Save.png", UriKind.Relative));
            ButtonClear.Content = new BitmapImage(new Uri(@"images/Cancel.png", UriKind.Relative));

            ButtonClear.Click += new RoutedEventHandler(ButtonClear_Click);
            ButtonSave.Click += new RoutedEventHandler(ButtonSave_Click);

            if (configurationFrame != null)
                UserControlConfiguratorCreator.ConfigurationFrame = configurationFrame;
        }

        void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }                
    }
}
