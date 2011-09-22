//******************************************************************************************************
//  OutputStreamDeviceDigitals.cs - Gbtc
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
//  08/011/2011 - Aniket Salver
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Windows;
using openPDC.UI.DataModels;
using TimeSeriesFramework.UI;

namespace openPDC.UI.ViewModels
{
    // <summary>
    /// Class to hold bindable <see cref="OutputStreamDeviceDigital"/> collection and selected OutputStreamDeviceDigital for UI.
    /// </summary>
    internal class OutputStreamDeviceDigitals : PagedViewModelBase<OutputStreamDeviceDigital, int>
    {
        #region [ Members ]

        private int m_outputStreamDeviceID;

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets flag that determines if <see cref="PagedViewModelBase{T1, T2}.CurrentItem"/> is a new record.
        /// </summary>
        public override bool IsNewRecord
        {
            get
            {
                return CurrentItem.ID == 0;
            }
        }

        public int OutputStreamDeviceID
        {
            get
            {
                return m_outputStreamDeviceID;
            }
             set
            {
                m_outputStreamDeviceID = value;
            }
        }

        #endregion

        #region [ Constructor ]

        /// <summary>
        /// Creates an instance of <see cref="OutputStreamDeviceDigitals "/> class.
        /// </summary>
        /// <param name="itemsPerPage">Integer value to determine number of items per page.</param>
        /// <param name="autoSave">Boolean value to determine is user changes should be saved automatically.</param>
        public OutputStreamDeviceDigitals(int outputStreamDeviceID, int itemsPerPage, bool autoSave = true)
            : base(0, autoSave)
        {
            m_outputStreamDeviceID = outputStreamDeviceID;
            ItemsPerPage = itemsPerPage;
            Load();
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Gets the primary key value of the <see cref="PagedViewModelBase{T1, T2}.CurrentItem"/>.
        /// </summary>
        /// <returns>The primary key value of the <see cref="PagedViewModelBase{T1, T2}.CurrentItem"/>.</returns>
        public override int GetCurrentItemKey()
        {
            return CurrentItem.ID;
        }

        /// <summary>
        /// Gets the string based named identifier of the <see cref="PagedViewModelBase{T1, T2}.CurrentItem"/>.
        /// </summary>
        /// <returns>The string based named identifier of the <see cref="PagedViewModelBase{T1, T2}.CurrentItem"/>.</returns>
        public override string GetCurrentItemName()
        {
            return CurrentItem.Label;
        }

        /// <summary>
        /// Load output stream device phasors.
        /// </summary>
        public override void Load()
        {
            try
            {
                ItemsSource = OutputStreamDeviceDigital.Load(null, m_outputStreamDeviceID);
                CurrentItem.OutputStreamDeviceID = m_outputStreamDeviceID;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    Popup(ex.Message + Environment.NewLine + "Inner Exception: " + ex.InnerException.Message, "Load " + DataModelName + " Exception:", MessageBoxImage.Error);
                else
                    Popup(ex.Message, "Load " + DataModelName + " Exception:", MessageBoxImage.Error);
            }
        }

        public override void Clear()
        {
            base.Clear();
            CurrentItem.OutputStreamDeviceID = m_outputStreamDeviceID;
        }

        #endregion
    }
}
