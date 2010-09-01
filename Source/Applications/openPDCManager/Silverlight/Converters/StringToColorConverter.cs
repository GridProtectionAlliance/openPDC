//******************************************************************************************************
//  StringToColorConverter.cs - Gbtc
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
//  03/16/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Windows.Data;
using System.Windows.Media;

namespace openPDCManager.Converters
{
	public class StringToColorConverter : IValueConverter
	{

		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			SolidColorBrush scBrush = new SolidColorBrush();
			if (value == null)
				value = "Unknown";

			if (value.ToString().ToUpper() == "GOOD")
				scBrush.Color = Color.FromArgb(255, 25, 150, 25);
			else if (value.ToString().ToUpper() == "BAD")
				scBrush.Color = Color.FromArgb(255, 200, 25, 25);								
			else	//any other quality tag
				scBrush.Color = Color.FromArgb(255, 180, 140, 10);
				
			return scBrush as Brush;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return null;
		}

		#endregion
	}
}
