//******************************************************************************************************
//  StringToPhaseConverter.cs - Gbtc
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
//  11/09/2009 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Windows.Data;

namespace openPDCManager.Converters
{
	public class StringToPhaseConverter : IValueConverter
	{

		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
            //if (value.ToString() == "+")
            //    return new KeyValuePair<string, string>("+", "Positive");
            //else if (value.ToString() == "-")
            //    return new KeyValuePair<string, string>("-", "Negative");
            //else if (value.ToString() == "A")
            //    return new KeyValuePair<string, string>("A", "Phase A");
            //else if (value.ToString() == "B")
            //    return new KeyValuePair<string, string>("B", "Phase B");
            //else if (value.ToString() == "C")
            //    return new KeyValuePair<string, string>("C", "Phase C");
            //else
            //    return new KeyValuePair<string, string>("+", "Positive");
				//throw new ArgumentException("Value not supported as a Phase Type");

            if (value == null)
                return "";

            if (value.ToString() == "+")
                return "Positive Sequence";
            else if (value.ToString() == "-")
                return "Negative Sequence";
            else if (value.ToString() == "0")
                return "Zero Sequence";
            else if (value.ToString() == "A")
                return "Phase A";
            else if (value.ToString() == "B")
                return "Phase B";
            else if (value.ToString() == "C")
                return "Phase C";
            else
                return "";
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
            return null;
            //if (value is KeyValuePair<string, string>)
            //    return ((KeyValuePair<string, string>)value).Key;
            //else
            //    return "+";
				//throw new ArgumentException("Value not supported as a Phase Type");
		}

		#endregion
	}
}
