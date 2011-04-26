//******************************************************************************************************
//  StringToBooleanConverter.cs - Gbtc
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
//  08/24/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Windows;
using System.Windows.Data;

namespace openPDCManager.Converters
{
    class StringToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                string temp = value.ToString().ToUpper();
                if (temp == "TRUE" || temp == "1" || temp == "IPHA" || temp == "IPHM" || temp == "VPHA" || temp == "VPHM" || temp == "FREQ")
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    class IntegerToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility visibility;
            if (value != null)
            {
                int temp;
                if (Int32.TryParse(value.ToString(), out temp))
                {
                    if (temp > 0)
                        visibility = Visibility.Visible;
                    else
                        visibility = Visibility.Collapsed;
                }
                else
                    visibility = Visibility.Collapsed;
            }
            else
                visibility = Visibility.Collapsed;

            //This was added for Browse->Devices screen where ParentID IS NULL then Update Configuration link is visible.
            //Just pass in bool parameter to invert boolean value.
            if (parameter is bool && (bool)parameter)
                return visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;

            return visibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
