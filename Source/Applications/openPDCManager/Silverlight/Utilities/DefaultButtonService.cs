//******************************************************************************************************
//  DefaultButtonService.cs - Gbtc
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
//  02/24/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Input;

namespace openPDCManager.Utilities
{
	public static class DefaultButtonService
	{
		#region [ Members ]

		public static DependencyProperty DefaultButtonProperty = DependencyProperty.RegisterAttached("DefaultButton", typeof(Button), typeof(DefaultButtonService),
																	new PropertyMetadata(null, DefaultButtonChanged));
		
		#endregion

		#region [ Methods ]

		private static void DefaultButtonChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var uiElement = d as UIElement;
			var button = e.NewValue as Button;
			if (uiElement != null && button != null)
			{
				uiElement.KeyUp += (sender, arg) =>
				{
					if (arg.Key == Key.Enter)
					{
						var peer = new ButtonAutomationPeer(button);
						var invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
						if (invokeProv != null)
							invokeProv.Invoke();
					}
				};
			}
		}

		public static void SetDefaultButton(UIElement obj, Button button)
		{
			obj.SetValue(DefaultButtonProperty, button);
		}

		public static void GetDefaultButton(UIElement obj)
		{
			obj.GetValue(DefaultButtonProperty);
		}

		#endregion

	}
}
