//******************************************************************************************************
//  StringToDictionaryConverter.cs - Gbtc
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
//  04/26/2011 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Windows.Data;
using openPDCManager.Data;

namespace openPDCManager.Converters
{
    public class StringToDictionaryConverter : IValueConverter
    {
        Dictionary<int, string> vendorDevices;

        public StringToDictionaryConverter()
        {
            vendorDevices = CommonFunctions.GetVendorDevices(null, true);
        }

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter != null && parameter.ToString() == "VendorDevice")
            {
                int vendorDeviceID;
                if (value is int)
                {
                    vendorDeviceID = (int)value;
                    foreach (KeyValuePair<int, string> item in vendorDevices)
                        if (item.Key == vendorDeviceID)
                            return item;
                }
                else
                    return new KeyValuePair<int, string>(0, "Select Vendor Device");
            }

            return new KeyValuePair<int, string>(0, "Select Vendor Device");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
                return ((KeyValuePair<int, string>)value).Key;
            else
                return 0;
        }

        #endregion
    }
}
