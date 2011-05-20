//******************************************************************************************************
//  ChannelBase.cs - Gbtc
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
//  3/7/2005 - J. Ritchie Carroll
//       Generated original version of source code.
//  09/15/2009 - Stephen C. Wills
//       Added new header and license agreement.
//
//******************************************************************************************************

using System.Collections.Generic;
using TVA.Parsing;

namespace TVA.PhasorProtocols
{
    /// <summary>
    /// Represents the common implementation of the protocol independent definition of any kind
    /// of data that can be parsed or generated.<br/>
    /// This is the base class of all parsing/generating classes in the phasor protocols library;
    /// it is the root of the parsing/generating class hierarchy.
    /// </summary>
    /// <remarks>
    /// This base class represents <see cref="IChannel"/> data images for parsing or generation in
    /// terms of a header, body and footer (see <see cref="BinaryImageBase"/> for details).
    /// </remarks>
    public abstract class ChannelBase : BinaryImageBase, IChannel
    {
        #region [ Members ]

        // Fields        
        private IChannelParsingState m_state;               // Current parsing state
        private Dictionary<string, string> m_attributes;    // Attributes dictionary
        private object m_tag;                               // User defined tag

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets the parsing state for this <see cref="ChannelBase"/> object.
        /// </summary>
        public virtual IChannelParsingState State
        {
            get
            {
                return m_state;
            }
            set
            {
                m_state = value;
            }
        }

        /// <summary>
        /// Gets a <see cref="Dictionary{TKey,TValue}"/> of string based property names and values for this <see cref="ChannelBase"/> object.
        /// </summary>
        /// <remarks>
        /// The attributes dictionary is relevant to all channel properties.  This dictionary will only be instantiated with a call to
        /// the <c>Attributes</c> property which will begin the enumeration of relevant system properties.  This is typically used for
        /// display purposes. For example, this information is displayed in a tree view on the the <b>PMU Connection Tester</b> to display
        /// attributes of data elements that may be protocol specific.
        /// </remarks>
        public virtual Dictionary<string, string> Attributes
        {
            get
            {
                // Create a new attributes dictionary or clear the contents of any existing one
                if (m_attributes == null)
                    m_attributes = new Dictionary<string, string>();
                else
                    m_attributes.Clear();

                m_attributes.Add("Derived Type", this.GetType().FullName);
                m_attributes.Add("Binary Length", BinaryLength.ToString());

                return m_attributes;
            }
        }

        /// <summary>
        /// Gets or sets a user definable reference to an object associated with this <see cref="ChannelBase"/> object.
        /// </summary>
        public virtual object Tag
        {
            get
            {
                return m_tag;
            }
            set
            {
                m_tag = value;
            }
        }

        #endregion
    }
}