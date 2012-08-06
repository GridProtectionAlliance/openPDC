//******************************************************************************************************
//  PhasorMeasurements.cs - Gbtc
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
//  05/13/2011 - Magdiel D. Lorenzo
//       Generated original version of source code.
//  05/13/2011 - Mehulbhai P Thakkar
//       Added constructor overload and other changes to handle device specific data.
//  07/12/2011 - Stephen C. Wills
//       Moved phasor-specific code from Measurements in TimeSeriesFramework.UI.WPF to here.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using openPDC.UI.DataModels;
using TimeSeriesFramework.UI;
using TimeSeriesFramework.UI.ViewModels;

namespace openPDC.UI.ViewModels
{
    /// <summary>
    /// Class to hold bindable <see cref="TimeSeriesFramework.UI.DataModels.Measurement"/> collection.
    /// </summary>
    internal class PhasorMeasurements : Measurements
    {
        #region [ Members ]

        private bool m_canLoad;
        private Dictionary<int, string> m_deviceLookupList;
        private int m_deviceID;

        #endregion

        #region [ Constructors ]

        public PhasorMeasurements(int deviceID, int itemsPerPage, bool autosave = true)
            : base(deviceID, itemsPerPage, autosave)     // Set ItemsPerPage to zero to avoid load() in the base class.
        {
            m_canLoad = true;
            m_deviceID = deviceID;
            m_deviceLookupList = Device.GetLookupList(null, DeviceType.All, true, true);
            Load();
        }



        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets <see cref="Dictionary{T1,T2}"/> type collection of devices defined in the database.
        /// </summary>
        public Dictionary<int, string> DeviceLookupList
        {
            get
            {
                return m_deviceLookupList;
            }
            set
            {
                m_deviceLookupList = value;
                OnPropertyChanged("DeviceLookupList");
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Creates a new instance of <see cref="TimeSeriesFramework.UI.DataModels.Measurement"/> and assigns it to CurrentItem.
        /// </summary>
        public override void Clear()
        {
            base.Clear();

            if (m_deviceLookupList.Count > 0)
                CurrentItem.DeviceID = m_deviceLookupList.First().Key;
        }

        public override void Save()
        {
            try
            {
                if (CurrentItem.HistorianID != null && (int)CurrentItem.HistorianID > 0)
                {
                    CommonFunctions.SendCommandToService("Invoke " + TimeSeriesFramework.UI.CommonFunctions.GetRuntimeID("Historian", (int)CurrentItem.HistorianID) + " RefreshMetadata");
                    base.Save();
                }
                else
                {
                    base.Save();
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Popup(ex.Message + Environment.NewLine + "Inner Exception: " + ex.InnerException.Message, "Save " + DataModelName + ", Refresh Metadata Exception:", MessageBoxImage.Error);
                    CommonFunctions.LogException(null, "Save " + DataModelName, ex.InnerException);
                }
                else
                {
                    Popup(ex.Message, "Save " + DataModelName + ", Refresh Metadata Exception:", MessageBoxImage.Error);
                    CommonFunctions.LogException(null, "Save " + DataModelName, ex);
                }
            }
        }

        /// <summary>
        /// Loads collection of <see cref="TimeSeriesFramework.UI.DataModels.Measurement"/> defined in the database.
        /// </summary>
        public override void Load()
        {
            if (m_canLoad)
            {
                Mouse.OverrideCursor = Cursors.Wait;

                try
                {
                    base.Load();
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        Popup(ex.Message + Environment.NewLine + "Inner Exception: " + ex.InnerException.Message, "Load " + DataModelName + " Exception:", MessageBoxImage.Error);
                        CommonFunctions.LogException(null, "Load " + DataModelName, ex.InnerException);
                    }
                    else
                    {
                        Popup(ex.Message, "Load " + DataModelName + " Exception:", MessageBoxImage.Error);
                        CommonFunctions.LogException(null, "Load " + DataModelName, ex);
                    }
                }
                finally
                {
                    Mouse.OverrideCursor = null;
                }
            }
        }

        #endregion

    }
}
