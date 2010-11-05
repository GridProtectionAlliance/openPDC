//******************************************************************************************************
//  DataPager.xaml.cs - Gbtc
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
//  10/08/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace openPDCManager.UserControls.CustomControls
{
    /// <summary>
    /// Interaction logic for DataPager.xaml
    /// </summary>
    public partial class DataPager : UserControl, INotifyPropertyChanged
    {
        #region [ Members ]

        private int m_pageCount;
        private int m_currentPageNumber;
        private ObservableCollection<ObservableCollection<Object>> m_pages;
        private ObservableCollection<Object> m_itemsSource;
        private ObservableCollection<Object> m_currentPage;

        #region [ INotifyPropertyChanged Members ]

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #endregion

        #region [ Properties ]

        public ObservableCollection<Object> CurrentPage
        {
            get { return m_currentPage; }
            set
            {
                m_currentPage = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentPage"));
            }
        }

        public ObservableCollection<object> ItemsSource
        {
            get { return m_itemsSource; }
            set
            {
                m_itemsSource = value;
                GeneratePages();
            }
        }

        public int CurrentPageNumber
        {
            get { return m_currentPageNumber; }
            set
            {
                m_currentPageNumber = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentPageNumber"));
            }
        }

        public int ItemsPerPage
        {
            get { return (int)GetValue(ItemsPerPageProperty); }
            set { SetValue(ItemsPerPageProperty, value); }
        }

        public static readonly DependencyProperty ItemsPerPageProperty = DependencyProperty.Register("ItemsPerPage", typeof(int), typeof(DataPager), new UIPropertyMetadata(10));

        #endregion
                
        #region [ Constructor ]

        public DataPager()
        {
            InitializeComponent();
        }

        #endregion

        #region [ Methods ]

        void GeneratePages()
        {
            if (ItemsSource != null)
            {
                m_pageCount = (int)Math.Ceiling(ItemsSource.Count / (double)ItemsPerPage);
                m_pages = new ObservableCollection<ObservableCollection<object>>();
                for (int i = 0; i < m_pageCount; i++)
                {
                    ObservableCollection<object> page = new ObservableCollection<object>();
                    for (int j = 0; j < ItemsPerPage; j++)
                    {
                        if (i * ItemsPerPage + j > ItemsSource.Count - 1) break;
                        page.Add(ItemsSource[i * ItemsPerPage + j]);
                    }
                    m_pages.Add(page);
                }
                CurrentPage = m_pages[0];
                CurrentPageNumber = 1;
                TextBlockTotalPages.Text = "of " + m_pageCount.ToString();
            }
            else
            {
                m_pageCount = 0;
                //m_pages = new ObservableCollection<ObservableCollection<object>>();
                CurrentPage = new ObservableCollection<object>();
                CurrentPageNumber = 0;
                TextBlockTotalPages.Text = "of " + m_pageCount.ToString();
            }
        }

        #endregion

        #region [ Controls Event Handlers ]

        private void ButtonFirstPage_Click(object sender, RoutedEventArgs e)
        {
            if (m_pages != null)
            {
                CurrentPage = m_pages[0];
                CurrentPageNumber = 1;
            }
        }

        private void ButtonPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (m_pages != null)
            {
                CurrentPageNumber = (CurrentPageNumber - 1) < 1 ? 1 : CurrentPageNumber - 1;
                CurrentPage = m_pages[CurrentPageNumber - 1];
            }
        }

        private void ButtonNextPage_Click(object sender, RoutedEventArgs e)
        {
            if (m_pages != null)
            {
                CurrentPageNumber = (CurrentPageNumber + 1) > m_pageCount ? m_pageCount : CurrentPageNumber + 1;
                CurrentPage = m_pages[CurrentPageNumber - 1];
            }
        }

        private void ButtonLastPage_Click(object sender, RoutedEventArgs e)
        {
            if (m_pages != null)
            {
                CurrentPage = m_pages[m_pageCount - 1];
                CurrentPageNumber = m_pageCount;
            }
        }

        private void ButtonGoPage_Click(object sender, RoutedEventArgs e)
        {
            if (m_pages != null)
            {
                CurrentPage = m_pages[CurrentPageNumber - 1];
            }
        }

        #endregion
    }
}
