//******************************************************************************************************
//  PageControl.cs - Gbtc
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
//  07/01/2010 - Stephen C. Wills
//       Generated original version of source code.
//
//******************************************************************************************************

using System.Collections.Generic;

namespace DatabaseSetupUtility
{
    /// <summary>
    /// This class represents a list of pages that keeps track of the previous, current, and next pages to be displayed.
    /// </summary>
    public class PageControl : List<Page>
    {

        #region [ Members ]

        // Fields

        private int m_currentPage;

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets the index of the current page.
        /// </summary>
        public int CurrentPageIndex
        {
            get
            {
                return m_currentPage;
            }
        }

        /// <summary>
        /// Gets the page before the current page.
        /// </summary>
        public Page PreviousPage
        {
            get
            {
                if (m_currentPage > 0)
                    return this[m_currentPage - 1];
                else
                    return null;
            }
        }

        /// <summary>
        /// Gets the current page.
        /// </summary>
        public Page CurrentPage
        {
            get
            {
                return this[m_currentPage];
            }
        }

        /// <summary>
        /// Gets the page after the current page.
        /// </summary>
        public Page NextPage
        {
            get
            {
                if (m_currentPage + 1 < Count)
                    return this[m_currentPage + 1];
                else
                    return null;
            }
        }

        /// <summary>
        /// Determines whether the previous page is accessible.
        /// </summary>
        public bool PreviousPageAccessible
        {
            get
            {
                return (PreviousPage != null) && PreviousPage.Accessible && CurrentPage.CanGoBack;
            }
        }

        /// <summary>
        /// Determines whether the next page is accessible.
        /// </summary>
        public bool NextPageAccessible
        {
            get
            {
                return (NextPage == null) || (NextPage.Accessible && CurrentPage.CanGoForward);
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Moves to the next page.
        /// </summary>
        public void GoToNextPage()
        {
            if (NextPageAccessible && CurrentPage.UserInputIsValid())
            {
                this[m_currentPage].Visible = false;
                m_currentPage++;
                this[m_currentPage].Visible = true;
            }
        }

        /// <summary>
        /// Moves to the previous page.
        /// </summary>
        public void GoToPreviousPage()
        {
            if (PreviousPageAccessible)
            {
                this[m_currentPage].Visible = false;
                m_currentPage--;
                this[m_currentPage].Visible = true;
            }
        }

        #endregion
        
    }
}
