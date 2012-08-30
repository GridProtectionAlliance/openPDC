//******************************************************************************************************
//  Subscribers.cs - Gbtc
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
//  05/20/2011 - Mehulbhai P Thakkar
//       Generated original version of source code.
//  05/20/2011 - Mehulbhai P Thakkar
//       Added commands and other logic to add or remove measurements and measurement groups.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using openPG.UI.DataModels;
using TimeSeriesFramework.UI;
using TimeSeriesFramework.UI.Commands;
using TimeSeriesFramework.UI.DataModels;

namespace openPG.UI.ViewModels
{
    /// <summary>
    /// Class to hold bindable <see cref="Subscriber"/> collection and current selection information for UI.
    /// </summary>
    internal class Subscribers : PagedViewModelBase<openPG.UI.DataModels.Subscriber, Guid>
    {
        #region [ Members ]

        // Fields
        private Dictionary<Guid, string> m_nodeLookupList;
        private RelayCommand m_addAllowedMeasurementCommand;
        private RelayCommand m_removeAllowedMeasurementCommand;
        private RelayCommand m_addDeniedMeasurementCommand;
        private RelayCommand m_removeDeniedMeasurementCommand;
        private RelayCommand m_addAllowedMeasurementGroupCommand;
        private RelayCommand m_removeAllowedMeasurementGroupCommand;
        private RelayCommand m_addDeniedMeasurementGroupCommand;
        private RelayCommand m_removeDeniedMeasurementGroupCommand;
        private DispatcherTimer m_refreshTimer;
        private SubscriberStatusQuery m_subscriberStatusQuery;
        private object m_subscriberStatusQueryLock;
        private List<Guid> m_subscriberIDs;

        // Delegates

        /// <summary>
        /// Method signature for a function which handles MeasurementsAdded event.
        /// </summary>
        /// <param name="sender">Source of an event.</param>
        /// <param name="e">Event arguments.</param>
        public delegate void OnMeasurementsAdded(object sender, RoutedEventArgs e);

        // Event

        /// <summary>
        /// Event to notify subscribers that measurements have been added to the group.
        /// </summary>
        public event OnMeasurementsAdded MeasurementsAdded;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates an instance of <see cref="Subscribers"/> class.
        /// </summary>
        /// <param name="itemsPerPage">Integer value to determine number of items per page.</param>
        /// <param name="autoSave">Boolean value to determine is user changes should be saved automatically.</param>
        public Subscribers(int itemsPerPage, bool autoSave = true)
            : base(itemsPerPage, autoSave)
        {
            m_subscriberIDs = new List<Guid>();
            m_subscriberStatusQueryLock = new object();
            m_subscriberStatusQuery = new SubscriberStatusQuery();
            m_subscriberStatusQuery.SubscriberStatuses += new EventHandler<TVA.EventArgs<Dictionary<Guid, Tuple<bool, string>>>>(m_subscriberStatusQuery_SubscriberStatuses);
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets flag that determines if <see cref="PagedViewModelBase{T1, T2}.CurrentItem"/> is a new record.
        /// </summary>
        public override bool IsNewRecord
        {
            get
            {
                return CurrentItem.ID == Guid.Empty;
            }
        }

        /// <summary>
        /// Gets <see cref="Dictionary{T1,T2}"/> type collection of <see cref="Node"/> defined in the database.
        /// </summary>
        public Dictionary<Guid, string> NodeLookupList
        {
            get
            {
                return m_nodeLookupList;
            }
        }

        /// <summary>
        /// Gets <see cref="ICommand"/> to add allowed measurements.
        /// </summary>
        public ICommand AddAllowedMeasurementCommand
        {
            get
            {
                if (m_addAllowedMeasurementCommand == null)
                    m_addAllowedMeasurementCommand = new RelayCommand(AddAllowedMeasurement, (param) => CanSave);

                return m_addAllowedMeasurementCommand;
            }
        }

        /// <summary>
        /// Gets <see cref="ICommand"/> to remove allowed measurements.
        /// </summary>
        public ICommand RemoveAllowedMeasurementCommand
        {
            get
            {
                if (m_removeAllowedMeasurementCommand == null)
                    m_removeAllowedMeasurementCommand = new RelayCommand(RemoveAllowedMeasurement, (param) => CanSave);

                return m_removeAllowedMeasurementCommand;
            }
        }

        /// <summary>
        /// Gets <see cref="ICommand"/> to add denied measurements.
        /// </summary>
        public ICommand AddDeniedMeasurementCommand
        {
            get
            {
                if (m_addDeniedMeasurementCommand == null)
                    m_addDeniedMeasurementCommand = new RelayCommand(AddDeniedMeasurement, (param) => CanSave);

                return m_addDeniedMeasurementCommand;
            }
        }

        /// <summary>
        /// Gets <see cref="ICommand"/> to remove denied measurements.
        /// </summary>
        public ICommand RemoveDeniedMeasurementCommand
        {
            get
            {
                if (m_removeDeniedMeasurementCommand == null)
                    m_removeDeniedMeasurementCommand = new RelayCommand(RemoveDeniedMeasurement, (param) => CanSave);

                return m_removeDeniedMeasurementCommand;
            }
        }

        /// <summary>
        /// Gets <see cref="ICommand"/> to add allowed measurement groups.
        /// </summary>
        public ICommand AddAllowedMeasurementGroupCommand
        {
            get
            {
                if (m_addAllowedMeasurementGroupCommand == null)
                    m_addAllowedMeasurementGroupCommand = new RelayCommand(AddAllowedMeasurementGroup, (param) => CanSave);

                return m_addAllowedMeasurementGroupCommand;
            }
        }

        /// <summary>
        /// Gets <see cref="ICommand"/> to remove allowed measurement groups.
        /// </summary>
        public ICommand RemoveAllowedMeasurementGroupCommand
        {
            get
            {
                if (m_removeAllowedMeasurementGroupCommand == null)
                    m_removeAllowedMeasurementGroupCommand = new RelayCommand(RemoveAllowedMeasurementGroup, (param) => CanSave);

                return m_removeAllowedMeasurementGroupCommand;
            }
        }

        /// <summary>
        /// Gets <see cref="ICommand"/> to add denied measurement groups.
        /// </summary>
        public ICommand AddDeniedMeasurementGroupCommand
        {
            get
            {
                if (m_addDeniedMeasurementGroupCommand == null)
                    m_addDeniedMeasurementGroupCommand = new RelayCommand(AddDeniedMeasurementGroup, (param) => CanSave);

                return m_addDeniedMeasurementGroupCommand;
            }
        }

        /// <summary>
        /// Gets <see cref="ICommand"/> to remove denied measurement groups.
        /// </summary>
        public ICommand RemoveDeniedMeasurementGroupCommand
        {
            get
            {
                if (m_removeDeniedMeasurementGroupCommand == null)
                    m_removeDeniedMeasurementGroupCommand = new RelayCommand(RemoveDeniedMeasurementGroup, (param) => CanSave);

                return m_removeDeniedMeasurementGroupCommand;
            }
        }

        #endregion

        #region [ Methods ]

        private void m_subscriberStatusQuery_SubscriberStatuses(object sender, TVA.EventArgs<Dictionary<Guid, Tuple<bool, string>>> e)
        {
            Dictionary<Guid, Tuple<bool, string>> subscriberStatuses = e.Argument;

            lock (m_subscriberStatusQueryLock)
            {
                foreach (Subscriber subscriber in ItemsSource)
                {
                    Tuple<bool, string> status;
                    if (subscriberStatuses.TryGetValue(subscriber.ID, out status))
                    {
                        subscriber.StatusColor = status.Item1 ? "green" : "red";
                        subscriber.Version = status.Item2;
                    }
                }
            }

            //OnPropertyChanged("ItemsSource");
        }

        public void StartTimer()
        {
            try
            {
                if (m_refreshTimer == null)
                {
                    m_refreshTimer = new DispatcherTimer();
                    m_refreshTimer.Interval = TimeSpan.FromSeconds(10);
                    m_refreshTimer.Tick += new EventHandler(m_refreshTimer_Tick);
                }

                foreach (Subscriber subscriber in ItemsSource)
                    m_subscriberIDs.Add(subscriber.ID);

                m_subscriberStatusQuery.RequestSubsscriberStatus(m_subscriberIDs);
                m_refreshTimer.Start();
            }
            catch (Exception ex)
            {
                Popup("Failed to start data refresh timer. Please reload page." + Environment.NewLine + ex.Message, "Refresh Data", MessageBoxImage.Error);
            }
        }

        public void StopTimer()
        {
            try
            {
                if (m_refreshTimer != null)
                    m_refreshTimer.Stop();
            }
            finally
            {
                m_refreshTimer = null;
            }
        }

        private void m_refreshTimer_Tick(object sender, EventArgs e)
        {
            lock (m_subscriberStatusQueryLock)
            {
                m_subscriberStatusQuery.RequestSubsscriberStatus(m_subscriberIDs);
            }
        }

        /// <summary>
        /// Gets the primary key value of the <see cref="PagedViewModelBase{T1, T2}.CurrentItem"/>.
        /// </summary>
        /// <returns>The primary key value of the <see cref="PagedViewModelBase{T1, T2}.CurrentItem"/>.</returns>
        public override Guid GetCurrentItemKey()
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

        /// <summary>
        /// Creates a new instance of <see cref="Subscriber"/> and assigns it to CurrentItem.
        /// </summary>
        public override void Clear()
        {
            base.Clear();
            if (m_nodeLookupList.Count > 0)
                CurrentItem.NodeID = m_nodeLookupList.First().Key;
        }

        /// <summary>
        /// Initialization to be done before the initial call to <see cref="PagedViewModelBase{T1,T2}.Load"/>.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            m_nodeLookupList = Node.GetLookupList(null);
        }

        /// <summary>
        /// Handles <see cref="AddAllowedMeasurementCommand"/>.
        /// </summary>
        /// <param name="parameter">Collection of measurements to be allowed.</param>
        private void AddAllowedMeasurement(object parameter)
        {
            ObservableCollection<Measurement> measurementsToBeAdded = (ObservableCollection<Measurement>)parameter;

            if (measurementsToBeAdded != null && measurementsToBeAdded.Count > 0)
            {
                List<Guid> measurementIDs = new List<Guid>();

                foreach (Measurement measurement in measurementsToBeAdded)
                {
                    if (!CurrentItem.AllowedMeasurements.ContainsKey(measurement.SignalID) &&
                        !CurrentItem.DeniedMeasurements.ContainsKey(measurement.SignalID) && measurement.Selected)
                        measurementIDs.Add(measurement.SignalID);
                }

                if (measurementIDs.Count > 0)
                {
                    string result = openPG.UI.DataModels.Subscriber.AddMeasurements(null, CurrentItem.ID, measurementIDs, true);
                    //Popup(result, "Allow Measurements", MessageBoxImage.Information);
                    DisplayStatusMessage(result);
                }
                else
                {
                    Popup("Selected measurements already exists or no measurements were selected.", "Allow Measurements", MessageBoxImage.Information);
                }

                if (MeasurementsAdded != null)
                    MeasurementsAdded(this, null);

                CurrentItem.AllowedMeasurements = openPG.UI.DataModels.Subscriber.GetAllowedMeasurements(null, CurrentItem.ID);
                CurrentItem.AvailableMeasurements = openPG.UI.DataModels.Subscriber.GetAvailableMeasurements(null, CurrentItem.ID);

                try
                {
                    CommonFunctions.SendCommandToService("Initialize /a EXTERNAL!DATAPUBLISHER");
                }
                catch (Exception ex)
                {
                    CommonFunctions.LogException(null, "", ex);
                }
            }
        }

        /// <summary>
        /// Handles <see cref="RemoveAllowedMeasurementCommand"/>.
        /// </summary>
        /// <param name="parameter">Collection of measurements to be disallowed.</param>
        private void RemoveAllowedMeasurement(object parameter)
        {
            ObservableCollection<object> items = (ObservableCollection<object>)parameter;

            if (items != null && items.Count > 0)
            {
                List<Guid> measurementIDs = new List<Guid>();

                foreach (object item in items)
                    measurementIDs.Add(((KeyValuePair<Guid, string>)item).Key);

                string result = openPG.UI.DataModels.Subscriber.RemoveMeasurements(null, CurrentItem.ID, measurementIDs);

                //Popup(result, "Remove Measurements", MessageBoxImage.Information);
                DisplayStatusMessage(result);

                CurrentItem.AllowedMeasurements = openPG.UI.DataModels.Subscriber.GetAllowedMeasurements(null, CurrentItem.ID);

                try
                {
                    CommonFunctions.SendCommandToService("Initialize /a EXTERNAL!DATAPUBLISHER");
                }
                catch (Exception ex)
                {
                    CommonFunctions.LogException(null, "", ex);
                }
            }
        }

        /// <summary>
        /// Handles <see cref="AddDeniedMeasurementCommand"/>.
        /// </summary>
        /// <param name="parameter">Collection of measurements to be denied.</param>
        private void AddDeniedMeasurement(object parameter)
        {
            ObservableCollection<Measurement> measurementsToBeAdded = (ObservableCollection<Measurement>)parameter;

            if (measurementsToBeAdded != null && measurementsToBeAdded.Count > 0)
            {
                List<Guid> measurementIDs = new List<Guid>();

                foreach (Measurement measurement in measurementsToBeAdded)
                {
                    if (!CurrentItem.AllowedMeasurements.ContainsKey(measurement.SignalID) &&
                        !CurrentItem.DeniedMeasurements.ContainsKey(measurement.SignalID) && measurement.Selected)
                        measurementIDs.Add(measurement.SignalID);
                }

                if (measurementIDs.Count > 0)
                {
                    string result = openPG.UI.DataModels.Subscriber.AddMeasurements(null, CurrentItem.ID, measurementIDs, false);
                    //Popup(result, "Allow Measurements", MessageBoxImage.Information);
                    DisplayStatusMessage(result);
                }
                else
                {
                    Popup("Selected measurements already exists or no measurements were selected.", "Allow Measurements", MessageBoxImage.Information);
                }

                if (MeasurementsAdded != null)
                    MeasurementsAdded(this, null);

                CurrentItem.DeniedMeasurements = openPG.UI.DataModels.Subscriber.GetDeniedMeasurements(null, CurrentItem.ID);
                CurrentItem.AvailableMeasurements = openPG.UI.DataModels.Subscriber.GetAvailableMeasurements(null, CurrentItem.ID);

                try
                {
                    CommonFunctions.SendCommandToService("Initialize /a EXTERNAL!DATAPUBLISHER");
                }
                catch (Exception ex)
                {
                    CommonFunctions.LogException(null, "", ex);
                }
            }
        }

        /// <summary>
        /// Handles <see cref="RemoveDeniedMeasurementCommand"/>
        /// </summary>
        /// <param name="parameter">Collection of measurements to be removed.</param>
        private void RemoveDeniedMeasurement(object parameter)
        {
            ObservableCollection<object> items = (ObservableCollection<object>)parameter;

            if (items != null && items.Count > 0)
            {
                List<Guid> measurementIDs = new List<Guid>();

                foreach (object item in items)
                    measurementIDs.Add(((KeyValuePair<Guid, string>)item).Key);

                string result = openPG.UI.DataModels.Subscriber.RemoveMeasurements(null, CurrentItem.ID, measurementIDs);

                //Popup(result, "Remove Measurements", MessageBoxImage.Information);
                DisplayStatusMessage(result);

                CurrentItem.DeniedMeasurements = openPG.UI.DataModels.Subscriber.GetDeniedMeasurements(null, CurrentItem.ID);

                try
                {
                    CommonFunctions.SendCommandToService("Initialize /a EXTERNAL!DATAPUBLISHER");
                }
                catch (Exception ex)
                {
                    CommonFunctions.LogException(null, "", ex);
                }
            }
        }

        /// <summary>
        /// Handles <see cref="AddAllowedMeasurementGroupCommand"/>.
        /// </summary>
        /// <param name="parameter">Collection of measurement groups to be added.</param>
        private void AddAllowedMeasurementGroup(object parameter)
        {
            ObservableCollection<object> items = (ObservableCollection<object>)parameter;

            if (items != null && items.Count > 0)
            {
                List<int> measurementGroupIDs = new List<int>();

                foreach (object item in items)
                    measurementGroupIDs.Add(((KeyValuePair<int, string>)item).Key);

                string result = openPG.UI.DataModels.Subscriber.AddMeasurementGroups(null, CurrentItem.ID, measurementGroupIDs, true);

                //Popup(result, "Allow Measurement Groups", MessageBoxImage.Information);
                DisplayStatusMessage(result);

                CurrentItem.AllowedMeasurementGroups = openPG.UI.DataModels.Subscriber.GetAllowedMeasurementGroups(null, CurrentItem.ID);
                CurrentItem.AvailableMeasurementGroups = openPG.UI.DataModels.Subscriber.GetAvailableMeasurementGroups(null, CurrentItem.ID);

                try
                {
                    CommonFunctions.SendCommandToService("Initialize /a EXTERNAL!DATAPUBLISHER");
                }
                catch (Exception ex)
                {
                    CommonFunctions.LogException(null, "", ex);
                }
            }
        }

        /// <summary>
        /// Handles <see cref="RemoveAllowedMeasurementGroupCommand"/>.
        /// </summary>
        /// <param name="parameter">Collection of measurement groups to be removed.</param>
        private void RemoveAllowedMeasurementGroup(object parameter)
        {
            ObservableCollection<object> items = (ObservableCollection<object>)parameter;

            if (items != null && items.Count > 0)
            {
                List<int> measurementGroupIDs = new List<int>();

                foreach (object item in items)
                    measurementGroupIDs.Add(((KeyValuePair<int, string>)item).Key);

                string result = openPG.UI.DataModels.Subscriber.RemoveMeasurementGroups(null, CurrentItem.ID, measurementGroupIDs);

                //Popup(result, "Remove Measurement Groups", MessageBoxImage.Information);
                DisplayStatusMessage(result);

                CurrentItem.AllowedMeasurementGroups = openPG.UI.DataModels.Subscriber.GetAllowedMeasurementGroups(null, CurrentItem.ID);
                CurrentItem.AvailableMeasurementGroups = openPG.UI.DataModels.Subscriber.GetAvailableMeasurementGroups(null, CurrentItem.ID);

                try
                {
                    CommonFunctions.SendCommandToService("Initialize /a EXTERNAL!DATAPUBLISHER");
                }
                catch (Exception ex)
                {
                    CommonFunctions.LogException(null, "", ex);
                }
            }
        }

        /// <summary>
        /// Handles <see cref="AddDeniedMeasurementGroupCommand"/>.
        /// </summary>
        /// <param name="parameter">Collection of measurement groups to be added.</param>
        private void AddDeniedMeasurementGroup(object parameter)
        {
            ObservableCollection<object> items = (ObservableCollection<object>)parameter;

            if (items != null && items.Count > 0)
            {
                List<int> measurementGroupIDs = new List<int>();

                foreach (object item in items)
                    measurementGroupIDs.Add(((KeyValuePair<int, string>)item).Key);

                string result = openPG.UI.DataModels.Subscriber.AddMeasurementGroups(null, CurrentItem.ID, measurementGroupIDs, false);

                //Popup(result, "Deny Measurement Groups", MessageBoxImage.Information);
                DisplayStatusMessage(result);

                CurrentItem.AvailableMeasurementGroups = openPG.UI.DataModels.Subscriber.GetAvailableMeasurementGroups(null, CurrentItem.ID);
                CurrentItem.DeniedMeasurementGroups = openPG.UI.DataModels.Subscriber.GetDeniedMeasurementGroups(null, CurrentItem.ID);

                try
                {
                    CommonFunctions.SendCommandToService("Initialize /a EXTERNAL!DATAPUBLISHER");
                }
                catch (Exception ex)
                {
                    CommonFunctions.LogException(null, "", ex);
                }
            }
        }

        /// <summary>
        /// Hanldes <see cref="RemoveDeniedMeasurementGroupCommand"/>.
        /// </summary>
        /// <param name="parameter">Collection of measurement groups to be removed.</param>
        private void RemoveDeniedMeasurementGroup(object parameter)
        {
            ObservableCollection<object> items = (ObservableCollection<object>)parameter;

            if (items != null && items.Count > 0)
            {
                List<int> measurementGroupIDs = new List<int>();

                foreach (object item in items)
                    measurementGroupIDs.Add(((KeyValuePair<int, string>)item).Key);

                string result = openPG.UI.DataModels.Subscriber.RemoveMeasurementGroups(null, CurrentItem.ID, measurementGroupIDs);

                //Popup(result, "Remove Measurement Groups", MessageBoxImage.Information);
                DisplayStatusMessage(result);

                CurrentItem.AvailableMeasurementGroups = openPG.UI.DataModels.Subscriber.GetAvailableMeasurementGroups(null, CurrentItem.ID);
                CurrentItem.DeniedMeasurementGroups = openPG.UI.DataModels.Subscriber.GetDeniedMeasurementGroups(null, CurrentItem.ID);

                try
                {
                    CommonFunctions.SendCommandToService("Initialize /a EXTERNAL!DATAPUBLISHER");
                }
                catch (Exception ex)
                {
                    CommonFunctions.LogException(null, "", ex);
                }
            }
        }

        #endregion
    }
}
