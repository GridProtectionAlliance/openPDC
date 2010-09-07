//******************************************************************************************************
//  Common.cs - Gbtc
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
//  11/23/2009 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using openPDCManager.ModalDialogs;
using System.Windows;

namespace openPDCManager.Utilities
{
	public static class Common
	{
		#region [ Methods ]

		public static Message ParseStringToMessage(string messageXML)
		{	
			XDocument xdoc = XDocument.Parse(messageXML.Substring(1));
			var message = from element in xdoc.Descendants("Message")
						  select new Message()
						  {
							  UserMessageType = (MessageType)Enum.Parse(typeof(MessageType), element.Element("UserMessageType").Value, true),
							  UserMessage = element.Element("UserMessage").Value,
							  SystemMessage = element.Element("SystemMessage").Value
						  };
			return message.ToList()[0] as Message;
		}
        
		// This fuction is copied from Framework solution as Silverlight doesn't support adding reference to that assembly.
		public static Dictionary<string, string> ParseKeyValuePairs(this string value, char parameterDelimeter, char keyValueDelimeter, char startValueDelimeter, char endValueDelimeter)
		{
			if (value == (string)null)
				throw new ArgumentNullException("value");

			if (parameterDelimeter == keyValueDelimeter ||
				parameterDelimeter == startValueDelimeter ||
				parameterDelimeter == endValueDelimeter ||
				keyValueDelimeter == startValueDelimeter ||
				keyValueDelimeter == endValueDelimeter ||
				startValueDelimeter == endValueDelimeter)
				throw new ArgumentException("All delimeters must be unique");

			Dictionary<string, string> keyValuePairs = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
			string[] elements;
			string escapedParameterDelimeter = parameterDelimeter.RegexEncode();
			string escapedKeyValueDelimeter = keyValueDelimeter.RegexEncode();
			StringBuilder escapedValue = new StringBuilder();
			bool valueEscaped = false;
			char character;

			// Escape any parameter or key value delimeters within tagged value sequences
			//      For example, the following string:
			//          "normalKVP=-1; nestedKVP={p1=true; p2=false}")
			//      would be encoded as:
			//          "normalKVP=-1; nestedKVP=p1\\u003dtrue\\u003b p2\\u003dfalse")
			for (int x = 0; x < value.Length; x++)
			{
				character = value[x];

				if (character == startValueDelimeter)
				{
					if (!valueEscaped)
					{
						valueEscaped = true;
						continue;   // Don't add tag start delimeter to final value
					}
					else
					{
						throw new FormatException("Only one level of tagged value expressions are allowed");
					}
				}

				if (character == endValueDelimeter)
				{
					if (valueEscaped)
					{
						valueEscaped = false;
						continue;   // Don't add tag stop delimeter to final value
					}
					else
					{
						throw new FormatException(string.Format("Encountered end value delimeter \'{0}\' before start value delimeter \'{1}\'", endValueDelimeter, startValueDelimeter));
					}
				}

				if (valueEscaped)
				{
					// Escape any parameter or key value delimeters
					if (character == parameterDelimeter)
						escapedValue.Append(escapedParameterDelimeter);
					else if (character == keyValueDelimeter)
						escapedValue.Append(escapedKeyValueDelimeter);
					else
						escapedValue.Append(character);
				}
				else
				{
					escapedValue.Append(character);
				}
			}

			// Parse out key/value pairs
			foreach (string parameter in escapedValue.ToString().Split(parameterDelimeter))
			{
				// Parse out parameter's key/value elements
				elements = parameter.Split(keyValueDelimeter);
				if (elements.Length == 2)
				{
					// Add key/value pair, unescaping value expression as needed
					keyValuePairs.Add(
						elements[0].ToString().Trim(),
						elements[1].ToString().Trim().
							Replace(escapedParameterDelimeter, parameterDelimeter.ToString()).
							Replace(escapedKeyValueDelimeter, keyValueDelimeter.ToString()));
				}
			}

			return keyValuePairs;
		}

		// This fuction is copied from Framework solution as Silverlight doesn't support adding reference to that assembly.
		public static string JoinKeyValuePairs(this Dictionary<string, string> pairs, char parameterDelimeter, char keyValueDelimeter)
		{
			// <pex>
			if (pairs == (Dictionary<string, string>)null)
				throw new ArgumentNullException("pairs");
			// </pex>
			StringBuilder result = new StringBuilder();

			foreach (string key in pairs.Keys)
			{
				result.AppendFormat("{0}{1}{2}{3}", key, keyValueDelimeter, pairs[key], parameterDelimeter);
			}

			return result.ToString();
		}

		public static string RegexEncode(this char item)
		{
			return "\\u" + Convert.ToUInt16(item).ToString("x").PadLeft(4, '0');
		}

        public static string CleanText(this string value)
        {
            return value.Trim().Replace("%", "");   //.Replace("'", "");
        }

        public static bool IsInteger(this string value)
        {
            int temp;
            return int.TryParse(value.CleanText(), out temp);
        }

        public static bool IsLong(this string value)
        {
            long temp;
            return long.TryParse(value.CleanText(), out temp);
        }

        public static bool IsDecimal(this string value)
        {
            decimal temp;
            return decimal.TryParse(value.CleanText(), out temp);
        }

        public static bool IsDouble(this string value)
        {
            double temp;
            return double.TryParse(value.CleanText(), out temp);
        }

        public static int ToInteger(this string value)
        {
            int temp = 0;
            int.TryParse(value.CleanText(), out temp);
            return temp;
        }

        public static long ToLong(this string value)
        {
            long temp = 0;
            long.TryParse(value.CleanText(), out temp);
            return temp;
        }

        public static decimal ToDecimal(this string value)
        {
            decimal temp = 0;
            decimal.TryParse(value.CleanText(), out temp);
            return temp;
        }

        public static double ToDouble(this string value)
        {
            double temp = 0;
            double.TryParse(value.CleanText(), out temp);
            return temp;
        }

        public static int? ToNullableInteger(this string value)
        {
            int temp = 0;
            if (int.TryParse(value.CleanText(), out temp))
                return temp;
            else
                return (int?)null;
        }

        public static long? ToNullableLong(this string value)
        {
            long temp = 0;
            if (long.TryParse(value.CleanText(), out temp))
                return temp;
            else
                return (long?)null;
        }

        public static decimal? ToNullableDecimal(this string value)
        {
            decimal temp = 0;
            if (decimal.TryParse(value.CleanText(), out temp))
                return temp;
            else
                return (decimal?)null;
        }

        public static double? ToNullableDouble(this string value)
        {
            double temp = 0;
            if (double.TryParse(value.CleanText(), out temp))
                return temp;
            else
                return (double?)null;
        }

        public static object ConvertValueToType(object value, string dataType)
        {   
               switch (dataType)
                {
                    case "System.DateTime":
                        return new DateTime(Convert.ToInt64(value));
                    default:
                        return Convert.ChangeType(Convert.ToDouble(value), Type.GetType(dataType), null);
                }
        }

        public static void ShowPopup(this SystemMessages sm)
        {
#if SILVERLIGHT
            sm.Show();
#else            
            sm.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            sm.ShowDialog();            
#endif
        }
                
		#endregion

	}
}
