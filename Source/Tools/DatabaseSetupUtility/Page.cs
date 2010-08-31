//******************************************************************************************************
//  Page.cs - Gbtc
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
//  06/29/2010 - Stephen C. Wills
//       Generated original version of source code.
//
//******************************************************************************************************

using System.Windows.Forms;

namespace DatabaseSetupUtility
{
    /// <summary>
    /// Represents a setup page for the <see cref="DatabaseSetupUtility"/> form.
    /// </summary>
    public class Page
    {

        #region [ Members ]

        // Delegates

        /// <summary>
        /// This defines the signature of methods that can be used for user input validation.
        /// </summary>
        /// <returns>True if the user input is valid. False otherwise.</returns>
        public delegate bool UserInputValidationFunctionSignature();

        // Fields

        private Panel m_pagePanel;
        private bool m_canGoBack;
        private bool m_canGoForward;
        private bool m_accessible;
        private bool m_canCancel;
        private UserInputValidationFunctionSignature m_userInputValidationFunction;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new instance of the <see cref="Page"/> class.
        /// </summary>
        /// <param name="pagePanel">The panel that is displayed when this page is visible.</param>
        public Page(Panel pagePanel)
        {
            m_pagePanel = pagePanel;
            m_canGoBack = true;
            m_canGoForward = true;
            m_accessible = true;
            m_canCancel = true;
            pagePanel.Visible = false;
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Sets the user input validation function.
        /// </summary>
        public UserInputValidationFunctionSignature UserInputValidationFunction
        {
            set
            {
                m_userInputValidationFunction = value;
            }
        }

        /// <summary>
        /// Gets or sets whether this page is visible.
        /// </summary>
        public bool Visible
        {
            get
            {
                return m_pagePanel.Visible;
            }
            set
            {
                m_pagePanel.Visible = value;
            }
        }

        /// <summary>
        /// Gets the panel that is displayed when this page is visible.
        /// </summary>
        public Panel PagePanel
        {
            get
            {
                return m_pagePanel;
            }
        }

        /// <summary>
        /// Determines whether the user can move back to the previous page from this page.
        /// </summary>
        public bool CanGoBack
        {
            get
            {
                return m_canGoBack;
            }
            set
            {
                m_canGoBack = value;
            }
        }

        /// <summary>
        /// Determines whether the user can move forward to the next page from this page.
        /// </summary>
        public bool CanGoForward
        {
            get
            {
                return m_canGoForward;
            }
            set
            {
                m_canGoForward = value;
            }
        }

        /// <summary>
        /// Determines whether the user can reach this page from another page.
        /// </summary>
        public bool Accessible
        {
            get
            {
                return m_accessible;
            }
            set
            {
                m_accessible = value;
            }
        }

        /// <summary>
        /// Determines whether the user can cancel the setup from this page.
        /// </summary>
        public bool CanCancel
        {
            get
            {
                return m_canCancel;
            }
            set
            {
                m_canCancel = value;
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Validates the user input on the page before proceeding to the next page.
        /// </summary>
        /// <returns>True if the user inputs are valid on this page, false otherwise.</returns>
        public bool UserInputIsValid()
        {
            if (m_userInputValidationFunction != null)
                return m_userInputValidationFunction();
            else
                return true;
        }

        #endregion
        
    }
}
