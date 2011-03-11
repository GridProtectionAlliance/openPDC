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
//  02/16/2011 - J. Ritchie Carroll
//       Updated key/value pair proxy functions.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Xml.Linq;
using openPDCManager.ModalDialogs;

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
        
		// These fuctions are copied from the code library solution as Silverlight doesn't support adding reference to that assembly.

        /// <summary>
        /// Parses key value pair parameters from a string. Parameter pairs are delimited by <paramref name="keyValueDelimeter"/>,
        /// and multiple pairs separated by <paramref name="parameterDelimeter"/>.
        /// </summary>
        /// <param name="value">Key pair string to parse.</param>
        /// <param name="parameterDelimeter">Character that delimits one key value pair from another (e.g., would be a ";" in a typical connection
        /// string).</param>
        /// <param name="keyValueDelimeter">Character that delimits key from value (e.g., would be an "=" in a typical connection string).</param>
        /// <param name="startValueDelimeter">Optional character that marks the start of a value such that value could contain other
        /// <paramref name="parameterDelimeter"/> or <paramref name="keyValueDelimeter"/> characters (e.g., "{").</param>
        /// <param name="endValueDelimeter">Optional character that marks the end of a value such that value could contain other
        /// <paramref name="parameterDelimeter"/> or <paramref name="keyValueDelimeter"/> characters (e.g., "}").</param>
        /// <returns>Dictionary of key/value pairs.</returns>
        /// <remarks>
        /// <para>
        /// Parses a key value string that contains one or many pairs. Note that "keys" are case-insensitive.
        /// </para>
        /// <para>
        /// If value includes <paramref name="startValueDelimeter"/>, it must include <paramref name="endValueDelimeter"/>
        /// otherwise results will be unexpected.
        /// Multiple levels of nesting is supported.
        /// </para>
        /// </remarks>
        /// <exception cref="ArgumentNullException">value is null.</exception>
        /// <exception cref="ArgumentException">All delimeters must be unique.</exception>
        /// <exception cref="FormatException">Total nested key value value pair expressions are mismatched -or-
        /// encountered <paramref name="endValueDelimeter"/> before <paramref name="startValueDelimeter"/>.</exception>
        public static Dictionary<string, string> ParseKeyValuePairs(this string value, char parameterDelimeter = ';', char keyValueDelimeter = '=', char startValueDelimeter = '{', char endValueDelimeter = '}')
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
            string escapedStartValueDelimeter = startValueDelimeter.RegexEncode();
            string escapedEndValueDelimeter = endValueDelimeter.RegexEncode();
            StringBuilder escapedValue = new StringBuilder();
            bool valueEscaped = false;
            int delimeterDepth = 0;
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
                        // Handle nested delimeters
                        delimeterDepth++;
                    }
                }

                if (character == endValueDelimeter)
                {
                    if (valueEscaped)
                    {
                        if (delimeterDepth > 0)
                        {
                            // Handle nested delimeters
                            delimeterDepth--;
                        }
                        else
                        {
                            valueEscaped = false;
                            continue;   // Don't add tag stop delimeter to final value
                        }
                    }
                    else
                    {
                        throw new FormatException(string.Format("Invalid delimeter mismatch: encountered end value delimeter \'{0}\' before start value delimeter \'{1}\' - could not parse key value pairs", endValueDelimeter, startValueDelimeter));
                    }
                }

                if (valueEscaped)
                {
                    // Escape any delimeter characters inside nested key/value pair
                    if (character == parameterDelimeter)
                        escapedValue.Append(escapedParameterDelimeter);
                    else if (character == keyValueDelimeter)
                        escapedValue.Append(escapedKeyValueDelimeter);
                    else if (character == startValueDelimeter)
                        escapedValue.Append(escapedStartValueDelimeter);
                    else if (character == endValueDelimeter)
                        escapedValue.Append(escapedEndValueDelimeter);
                    else
                        escapedValue.Append(character);
                }
                else
                {
                    escapedValue.Append(character);
                }
            }

            if (delimeterDepth != 0 || valueEscaped)
            {
                // If value is still escaped, tagged expression was not terminated
                if (valueEscaped)
                    delimeterDepth = 1;

                throw new FormatException(string.Format("Invalid delimeter mismatch: encountered more {0} than {1} - could not parse key value pairs.", delimeterDepth > 0 ? "start value delimeters \'" + startValueDelimeter + "\'" : "end value delimeters \'" + endValueDelimeter + "\'", delimeterDepth < 0 ? "start value delimeters \'" + startValueDelimeter + "\'" : "end value delimeters \'" + endValueDelimeter + "\'"));
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
                            Replace(escapedKeyValueDelimeter, keyValueDelimeter.ToString()).
                            Replace(escapedStartValueDelimeter, startValueDelimeter.ToString()).
                            Replace(escapedEndValueDelimeter, endValueDelimeter.ToString()));
                }
            }

            return keyValuePairs;
        }

        /// <summary>
        /// Combines a dictionary of key-value pairs in to a string.
        /// </summary>
        /// <param name="pairs">Dictionary of key-value pairs.</param>
        /// <param name="parameterDelimeter">Character that delimits one key-value pair from another (eg. ';').</param>
        /// <param name="keyValueDelimeter">Character that delimits a key from its value (eg. '=').</param>
        /// <param name="startValueDelimeter">Optional character that marks the start of a value such that value could contain other
        /// <paramref name="parameterDelimeter"/> or <paramref name="keyValueDelimeter"/> characters (e.g., "{").</param>
        /// <param name="endValueDelimeter">Optional character that marks the end of a value such that value could contain other
        /// <paramref name="parameterDelimeter"/> or <paramref name="keyValueDelimeter"/> characters (e.g., "}").</param>
        /// <returns>A string of key-value pairs.</returns>
        /// <remarks>
        /// Values will be escaped within <paramref name="startValueDelimeter"/> and <paramref name="endValueDelimeter"/>
        /// to contain nested key value pair expressions like the following: <c>normalKVP=-1; nestedKVP={p1=true; p2=0.001}</c>,
        /// when either the <paramref name="parameterDelimeter"/> or <paramref name="keyValueDelimeter"/> are detected in the
        /// value of the key/value pair.
        /// </remarks>
        public static string JoinKeyValuePairs(this Dictionary<string, string> pairs, char parameterDelimeter = ';', char keyValueDelimeter = '=', char startValueDelimeter = '{', char endValueDelimeter = '}')
        {
            // <pex>
            if (pairs == (Dictionary<string, string>)null)
                throw new ArgumentNullException("pairs");
            // </pex>
            char[] delimiters = { parameterDelimeter, keyValueDelimeter };
            StringBuilder result = new StringBuilder();
            string value;

            foreach (string key in pairs.Keys)
            {
                value = pairs[key];

                if (value.IndexOfAny(delimiters) >= 0)
                    value = startValueDelimeter + value + endValueDelimeter;

                result.AppendFormat("{0}{1}{2}{3}", key, keyValueDelimeter, value, parameterDelimeter);
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

        public static void GetChildren(UIElement parent, Type targetType, ref List<UIElement> children)
        {
            int count = VisualTreeHelper.GetChildrenCount(parent);
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    UIElement child = (UIElement)VisualTreeHelper.GetChild(parent, i);
                    if (child.GetType() == targetType)
                    {
                        children.Add(child);
                    }
                    GetChildren(child, targetType, ref children);
                }
            }
        }

        public static string GetDataPublisherServer()
        {
            string server = "localhost";
            string connectionString = ((App)Application.Current).RemoteStatusServiceUrl.ToLower();
            Dictionary<string, string> keyValues = connectionString.ParseKeyValuePairs();

            if (keyValues.ContainsKey("server"))
                server = keyValues["server"].Substring(0, keyValues["server"].LastIndexOf(":"));

            return server;
        }

        public static string GetDataPublisherPort()
        {
            string port = "6165";
            string connectionString = ((App)Application.Current).RemoteStatusServiceUrl.ToLower();
            Dictionary<string, string> keyValues = connectionString.ParseKeyValuePairs();

            if (keyValues.ContainsKey("datapublisherport"))
                port = keyValues["datapublisherport"];

            return port;
        }

        public static string GetDataPublisherPassword()
        {
            string password = "TSF-E1CCE965-39A6-4476-8C60-EF02D8212F16";
            string connectionString = ((App)Application.Current).RemoteStatusServiceUrl.ToLower();
            Dictionary<string, string> keyValues = connectionString.ParseKeyValuePairs();
            
            if (keyValues.ContainsKey("datapublisherpassword"))
                password = keyValues["datapublisherpassword"];

            return password;
        }

		#endregion

	}
}
