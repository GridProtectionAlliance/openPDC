//******************************************************************************************************
//  OutputStreamDevices.cs - Gbtc
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
//  08/03/2011 - Aniket Salver
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeSeriesFramework.UI.DataModels;
using TimeSeriesFramework.UI;
using openPDCManager.UI.DataModels;

namespace openPDCManager.UI.ViewModels
{
    /// <summary>
    /// Class to hold bindable <see cref="OutputStreamDevice"/> collection and selected OutputStreamDevice for UI.
    /// </summary>
    internal class OutputStreamDevices : PagedViewModelBase<OutputStreamDevice, int>
    {
     
        #region [ Members ]

        // Fields
        private int m_outputStreamID;

        #endregion

        #region [ Properties ]
        
        public int OutputStreamID
        {
            get
            {
                return m_outputStreamID;
            }
            set
            {
                m_outputStreamID = value;
                OnPropertyChanged("OutputStreamID");
            }
        }

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

        #endregion

        #region [ Constructor ]

        /// <summary>
        /// Creates an instance of <see cref="OutputStreamDevices"/> class.
        /// </summary>
        /// <param name="itemsPerPage">Integer value to determine number of items per page.</param>
        /// <param name="autoSave">Boolean value to determine is user changes should be saved automatically.</param>
        public OutputStreamDevices(int outputStreamID, int itemsPerPage, bool autoSave = true)
            : base(itemsPerPage, autoSave)
        {
            OutputStreamID = outputStreamID;
        }

        #endregion

        #region [ Methods ]

        public override void Load()
        {
            //base.Load();
            OutputStreamDevice.Load(OutputStreamID);
        }

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
            return CurrentItem.Name;
        }

        #endregion
    }
}
