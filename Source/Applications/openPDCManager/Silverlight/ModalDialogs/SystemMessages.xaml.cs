//******************************************************************************************************
//  SystemMessages.xaml.cs - Gbtc
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
//  11/27/2009 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System.Windows;
using System.Windows.Controls;
using openPDCManager.Utilities;

namespace openPDCManager.ModalDialogs
{
	public partial class SystemMessages : ChildWindow
	{		
		#region [ Constructor ]

		public SystemMessages(Message message, ButtonType buttonType)
		{
			InitializeComponent();            
            UserControlSystemMessages.ButtonOk.Click += new RoutedEventHandler(ButtonOk_Click);
            UserControlSystemMessages.ButtonCancel.Click += new RoutedEventHandler(ButtonCancel_Click);
            UserControlSystemMessages.ButtonYes.Click += new RoutedEventHandler(ButtonYes_Click);
            UserControlSystemMessages.ButtonNo.Click += new RoutedEventHandler(ButtonNo_Click);

            UserControlSystemMessages.message = message;
            UserControlSystemMessages.buttonType = buttonType;

            if (message.UserMessageType == MessageType.Success)
                this.Title = "openPDCManager: Operation Completed Successfully!";
            else if (message.UserMessageType == MessageType.Warning)
                this.Title = "openPDCManager: Warning!";
            else if (message.UserMessageType == MessageType.Error)
                this.Title = "openPDCManager: Error Occured!";
            else if (message.UserMessageType == MessageType.Confirmation)
                this.Title = "openPDCManager: Confirmation!";             
            else //treat as information.
                this.Title = "openPDCManager: Information Only!";
        }

        #endregion

        #region [ Control Event Handlers ]

        void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        #endregion
                
	}
}

