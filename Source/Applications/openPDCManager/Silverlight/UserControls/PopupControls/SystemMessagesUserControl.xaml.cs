//******************************************************************************************************
//  SystemMessagesUserControl.xaml.cs - Gbtc
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

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using openPDCManager.Utilities;

namespace openPDCManager.UserControls.PopupControls
{
    public partial class SystemMessagesUserControl : UserControl
    {
        public Message message;
        public ButtonType buttonType;        

        public SystemMessagesUserControl()
        {
            InitializeComponent();
#if !SILVERLIGHT
            ButtonOk.Content = new BitmapImage(new Uri(@"images/Ok.png", UriKind.Relative));
            ButtonCancel.Content = new BitmapImage(new Uri(@"images/Cancel.png", UriKind.Relative));
            ButtonYes.Content = new BitmapImage(new Uri(@"images/Ok.png", UriKind.Relative));
            ButtonNo.Content = new BitmapImage(new Uri(@"images/Cancel.png", UriKind.Relative));
            UpdateLayout();
#endif
            Loaded += new RoutedEventHandler(SystemMessagesUserControl_Loaded);
        }

        void SystemMessagesUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            GridSystemMessageDetail.DataContext = message;
            if (message.UserMessageType == MessageType.Success)
            {
                TextBlockMessageType.Text = "SUCCESS";
#if SILVERLIGHT
                ImageMessageType.Source = new BitmapImage(new Uri(@"../../Images/Success.png", UriKind.Relative));
#else
                ImageMessageType.Source = new BitmapImage(new Uri(@"images/Success.png", UriKind.Relative));
#endif
                BorderMain.Background = Application.Current.Resources["GreenRadialGradientBrush"] as Brush;
            }
            else if (message.UserMessageType == MessageType.Warning)
            {
                TextBlockMessageType.Text = "WARNING";
#if SILVERLIGHT
                ImageMessageType.Source = new BitmapImage(new Uri(@"../../Images/Warning.png", UriKind.Relative));
#else
                ImageMessageType.Source = new BitmapImage(new Uri(@"images/Warning.png", UriKind.Relative));
#endif
                BorderMain.Background = Application.Current.Resources["YellowRadialGradientBrush"] as Brush;
            }
            else if (message.UserMessageType == MessageType.Error)
            {
                TextBlockMessageType.Text = "ERROR";
#if SILVERLIGHT
                ImageMessageType.Source = new BitmapImage(new Uri(@"../../Images/Error.png", UriKind.Relative));
#else
                ImageMessageType.Source = new BitmapImage(new Uri(@"images/Error.png", UriKind.Relative));
#endif
                BorderMain.Background = Application.Current.Resources["RedRadialGradientBrush"] as Brush;
            }
            else if (message.UserMessageType == MessageType.Confirmation)
            {
                TextBlockMessageType.Text = "CONFIRMATION";
#if SILVERLIGHT
                ImageMessageType.Source = new BitmapImage(new Uri(@"../../Images/Warning.png", UriKind.Relative));
#else
                ImageMessageType.Source = new BitmapImage(new Uri(@"images/Warning.png", UriKind.Relative));
#endif
                BorderMain.Background = Application.Current.Resources["YellowRadialGradientBrush"] as Brush;
            }
            else //treat as information.
            {
                TextBlockMessageType.Text = "INFORMATION";
#if SILVERLIGHT
                ImageMessageType.Source = new BitmapImage(new Uri(@"../../Images/Information.png", UriKind.Relative));
#else
                ImageMessageType.Source = new BitmapImage(new Uri(@"images/Information.png", UriKind.Relative));
#endif
                BorderMain.Background = Application.Current.Resources["BlueRadialGradientBrush"] as Brush;
            }

            if (buttonType == ButtonType.OkOnly)
            {
                ButtonOk.Visibility = Visibility.Visible;
                ButtonCancel.Visibility = Visibility.Collapsed;
                ButtonYes.Visibility = Visibility.Collapsed;
                ButtonNo.Visibility = Visibility.Collapsed;
            }
            else if (buttonType == ButtonType.OkCancel)
            {
                ButtonOk.Visibility = Visibility.Visible;
                ButtonCancel.Visibility = Visibility.Visible;
                ButtonYes.Visibility = Visibility.Collapsed;
                ButtonNo.Visibility = Visibility.Collapsed;
            }
            else if (buttonType == ButtonType.YesNo)
            {
                ButtonOk.Visibility = Visibility.Collapsed;
                ButtonCancel.Visibility = Visibility.Collapsed;
                ButtonYes.Visibility = Visibility.Visible;
                ButtonNo.Visibility = Visibility.Visible;
            }
            else if (buttonType == ButtonType.YesNoCancel)
            {
                ButtonOk.Visibility = Visibility.Collapsed;
                ButtonCancel.Visibility = Visibility.Visible;
                ButtonYes.Visibility = Visibility.Visible;
                ButtonNo.Visibility = Visibility.Visible;
            }
        }                
    }
}
