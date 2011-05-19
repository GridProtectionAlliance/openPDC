//******************************************************************************************************
//  PhasorDataSchema.cs - Gbtc
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
//  05/18/2011 - J. Ritchie Carroll
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COMTRADE
{
    /// <summary>
    /// Represents the schema for phasor data using the COMTRADE file standard, IEEE Std C37.111-1999.
    /// </summary>
    public class PhasorDataSchema
    {
        #region [ Members ]

        // Nested Types

        // Constants

        // Delegates

        // Events

        // Fields
        private string m_stationName;
        private string m_deviceID;
        private int m_version;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new instance of the <see cref="PhasorDataSchema"/>.
        /// </summary>
        public PhasorDataSchema()
        {
            m_version = 1999;
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets free-form station name for this <see cref="PhasorDataSchema"/>.
        /// </summary>
        public string StationName
        {
            get
            {
                return m_stationName;
            }
            set
            {
                m_stationName = value;
            }
        }

        /// <summary>
        /// Gets or sets free-form device ID for this <see cref="PhasorDataSchema"/>.
        /// </summary>
        public string DeviceID
        {
            get
            {
                return m_deviceID;
            }
            set
            {
                m_deviceID = value;
            }
        }

        /// <summary>
        /// Gets or sets version number of the IEEE Std C37.111 used by this <see cref="PhasorDataSchema"/>.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Only IEEE Std C37.111 version 1999 is supported by this implementation of the phasor data schema.</exception>
        public int Version
        {
            get
            {
                return m_version;
            }
            set
            {
                if (value != 1999)
                    throw new ArgumentOutOfRangeException("value", value + " is an invalid version number. Only IEEE Std C37.111 version 1999 is supported by this implementation of the phasor data schema.");
                
                m_version = value;
            }
        }

        #endregion

        #region [ Methods ]

        #endregion

        #region [ Operators ]

        #endregion

        #region [ Static ]

        // Static Fields

        // Static Constructor

        // Static Properties

        // Static Methods

        #endregion

    }
}
