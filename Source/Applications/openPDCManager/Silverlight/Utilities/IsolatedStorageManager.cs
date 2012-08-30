//******************************************************************************************************
//  IsolatedStorageManager.cs - Gbtc
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
//  04/08/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System.IO.IsolatedStorage;

namespace openPDCManager.Utilities
{
	public static class IsolatedStorageManager
	{
		/// <summary>
		/// Save property and value into isolated storage
		/// </summary>
		/// <param name="value">value to store</param>
		/// <param name="name">name of property</param>
		public static void SaveIntoIsolatedStorage(string name, object value)
		{
			IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
			//If settings have never been saved, then we have to add appsetting first
			if (!appSettings.Contains(name))
				appSettings.Add(name, null);
						
			appSettings[name] = value;
			appSettings.Save();			
		}

		public static bool Contains(string name)
		{
			IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
			return appSettings.Contains(name);
		}

		/// <summary>
		/// Remove property value from isolated storage
		/// </summary>
		/// <param name="name">name of property</param>
		public static void Remove(string name)
		{
			IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;

			//If settings have been saved, then we remove 
			if (appSettings.Contains(name))
				appSettings.Remove(name);
		}

		/// <summary>
		/// Removes all properties stored in isolated storage
		/// </summary>
		public static void RemoveAll()
		{
			IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
			appSettings.Clear();
		}

		/// <summary>
		/// Retrieve setting that was stored in Isolated Storage
		/// </summary>
		/// <param name="name">name of the property to retrieve</param>
		/// <returns></returns>
		public static object LoadFromIsolatedStorage(string name)
		{
			IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
			if (appSettings.Contains(name))
			{
				return appSettings[name];
			}
			return null;
		}
	}
}
