//******************************************************************************************************
//  CommonPhasorServices.cs - Gbtc
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
//  4/9/2010 - J. Ritchie Carroll
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using TVA.Configuration;
using TVA.Data;
using TVA.IO;
using TimeSeriesFramework;
using TimeSeriesFramework.Adapters;
using TVA.PhasorProtocols.Anonymous;
using TVA.Units;

namespace TVA.PhasorProtocols
{
    /// <summary>
    /// Method signature for function used to calculate a statistic for a given object.
    /// </summary>
    /// <param name="source">Source object.</param>
    /// <param name="arguments">Any needed arguments for statistic calculation.</param>
    /// <returns>Actual calculated statistic.</returns>
    public delegate double StatisticCalculationFunction(object source, string arguments);

    /// <summary>
    /// Provides common phasor services.
    /// </summary>
    /// <remarks>
    /// Typically class should be implemented as a singleton since one instance will suffice.
    /// </remarks>
    public class CommonPhasorServices : IActionAdapter
    {
        #region [ Members ]

        // Nested Types

        // Statistic calculation definition
        private class Statistic
        {
            public StatisticCalculationFunction Method;
            public string Source;
            public int Index;
            public string Arguments;
        }

        // Statistic value state
        private class StatisticValueState : ObjectState<double>
        {
            /// <summary>
            /// Creates a new <see cref="StatisticValueState"/>.
            /// </summary>
            /// <param name="name">Name of statistic.</param>
            public StatisticValueState(string name) : base(name) { }

            /// <summary>
            /// Gets the statistical difference between current and previous statistic value.
            /// </summary>
            /// <returns>Difference from last cached statistic value.</returns>
            public double GetDifference()
            {
                double value = CurrentState - PreviousState;

                // If value is negative, statistics may have been reset by user
                if (value < 0.0D)
                    value = CurrentState;

                // Track last value
                PreviousState = CurrentState;

                return value;
            }
        }

        // Statistical value state cache
        private class StatisticValueStateCache
        {
            #region [ Members ]

            // Fields
            private Dictionary<object, Dictionary<string, StatisticValueState>> m_statisticValueStates;

            #endregion

            #region [ Constructors ]

            /// <summary>
            /// Creates a new instance of the <see cref="StatisticValueStateCache"/>.
            /// </summary>
            public StatisticValueStateCache()
            {
                m_statisticValueStates = new Dictionary<object, Dictionary<string, StatisticValueState>>();
            }

            #endregion

            #region [ Methods ]

            /// <summary>
            /// Gets the statistical difference between current and previous statistic value.
            /// </summary>
            /// <param name="source">Source Device.</param>
            /// <param name="statistic">Current statistic value.</param>
            /// <param name="name">Name of statistic calculation.</param>
            /// <returns>Difference from last cached statistic value.</returns>
            public double GetDifference(object source, double statistic, string name)
            {
                Dictionary<string, StatisticValueState> valueStates;
                StatisticValueState valueState;

                lock (m_statisticValueStates)
                {
                    if (m_statisticValueStates.TryGetValue(source, out valueStates))
                    {
                        if (valueStates.TryGetValue(name, out valueState))
                        {
                            valueState.CurrentState = statistic;
                            statistic = valueState.GetDifference();
                        }
                        else
                        {
                            valueState = new StatisticValueState(name);
                            valueState.PreviousState = statistic;
                            valueStates.Add(name, valueState);
                        }
                    }
                    else
                    {
                        valueStates = new Dictionary<string, StatisticValueState>();

                        valueState = new StatisticValueState(name);
                        valueState.PreviousState = statistic;
                        valueStates.Add(name, valueState);

                        m_statisticValueStates.Add(source, valueStates);

                        // Attach to Disposed event of source, if defined
                        EventInfo disposedEvent = source.GetType().GetEvent("Disposed");

                        if (disposedEvent != null)
                            disposedEvent.GetAddMethod().Invoke(source, new object[] { new EventHandler(StatisticSourceDisposed) });
                    }
                }

                return statistic;
            }

            // Remove value states cache when statistic source is disposed
            private void StatisticSourceDisposed(object sender, EventArgs e)
            {
                lock (m_statisticValueStates)
                {
                    m_statisticValueStates.Remove(sender);
                }
            }

            #endregion
        }

        // Constants
        private const int DefaultMeasurementReportingInterval = 100000;
        private const int DefaultInitializationTimeout = 15000;

        // Events

        /// <summary>
        /// Provides status messages to consumer.
        /// </summary>
        /// <remarks>
        /// <see cref="EventArgs{T}.Argument"/> is new status message.
        /// </remarks>
        public event EventHandler<EventArgs<string>> StatusMessage;

        /// <summary>
        /// Event is raised when there is an exception encountered while processing.
        /// </summary>
        /// <remarks>
        /// <see cref="EventArgs{T}.Argument"/> is the exception that was thrown.
        /// </remarks>
        public event EventHandler<EventArgs<Exception>> ProcessException;

        /// <summary>
        /// Provides new measurements from action adapter.
        /// </summary>
        /// <remarks>
        /// <see cref="EventArgs{T}.Argument"/> is a collection of new measurements for host to process.
        /// </remarks>
        public event EventHandler<EventArgs<ICollection<IMeasurement>>> NewMeasurements;

        /// <summary>
        /// This event is raised, if needed, to track current number of unpublished seconds of data in the queue.
        /// </summary>
        /// <remarks>
        /// <see cref="EventArgs{T}.Argument"/> is the total number of unpublished seconds of data.
        /// </remarks>
        public event EventHandler<EventArgs<int>> UnpublishedSamples;

        /// <summary>
        /// This event is raised if there are any measurements being discarded during the sorting process.
        /// </summary>
        /// <remarks>
        /// <see cref="EventArgs{T}.Argument"/> is the enumeration of <see cref="IMeasurement"/> values that are being discarded during the sorting process.
        /// </remarks>
        public event EventHandler<EventArgs<IEnumerable<IMeasurement>>> DiscardingMeasurements;

        /// <summary>
        /// Event is raised when <see cref="CommonPhasorServices"/> is disposed.
        /// </summary>
        /// <remarks>
        /// If an adapter references another adapter by enumerating the <see cref="Parent"/> collection, this
        /// event should be monitored to release the reference.
        /// </remarks>
        public event EventHandler Disposed;

        // Fields
        private string m_name;
        private uint m_id;
        private string m_connectionString;
        private IAdapterCollection m_parent;
        private InputAdapterCollection m_inputAdapters;
        private ActionAdapterCollection m_actionAdapters;
        //private OutputAdapterCollection m_outputAdapters;
        private Dictionary<string, string> m_settings;
        private DataSet m_dataSource;
        private int m_initializationTimeout;
        private ManualResetEvent m_initializeWaitHandle;
        private long m_processedMeasurements;
        private int m_measurementReportingInterval;
        private int m_framesPerSecond;
        private ManualResetEvent m_configurationWaitHandle;
        private MultiProtocolFrameParser m_frameParser;
        private IConfigurationFrame m_configurationFrame;
        private Statistic[] m_deviceStatistics;
        private Statistic[] m_inputStreamStatistics;
        private Statistic[] m_outputStreamStatistics;
        private int m_deviceStatisticsMaxIndex;
        private int m_inputStreamStatisticsMaxIndex;
        private int m_outputStreamStatisticsMaxIndex;
        private Dictionary<string, IMeasurement> m_definedMeasurements;
        private System.Timers.Timer m_statisticCalculationTimer;
        private TimeSeriesFramework.DataPublisher m_dataPublisher;
        private bool m_enabled;
        private bool m_initialized;
        private bool m_disposed;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new <see cref="CommonPhasorServices"/>.
        /// </summary>
        public CommonPhasorServices()
        {
            // Initialize default adapter settings
            m_name = this.GetType().Name;
            m_initializeWaitHandle = new ManualResetEvent(false);
            m_settings = new Dictionary<string, string>();
            m_initializationTimeout = DefaultInitializationTimeout;

            // Create wait handle to use to wait for configuration frame
            m_configurationWaitHandle = new ManualResetEvent(false);

            // Create a new phasor protocol frame parser used to dynamically request device configuration frames
            // and return them to remote clients so that the frame can be used in system setup and configuration
            m_frameParser = new MultiProtocolFrameParser();

            // Attach to events on new frame parser reference
            m_frameParser.ConnectionAttempt += m_frameParser_ConnectionAttempt;
            m_frameParser.ConnectionEstablished += m_frameParser_ConnectionEstablished;
            m_frameParser.ConnectionException += m_frameParser_ConnectionException;
            m_frameParser.ConnectionTerminated += m_frameParser_ConnectionTerminated;
            m_frameParser.ExceededParsingExceptionThreshold += m_frameParser_ExceededParsingExceptionThreshold;
            m_frameParser.ParsingException += m_frameParser_ParsingException;
            m_frameParser.ReceivedConfigurationFrame += m_frameParser_ReceivedConfigurationFrame;

            // We only want to try to connect to device and retrieve configuration as quickly as possible
            m_frameParser.MaximumConnectionAttempts = 1;
            m_frameParser.SourceName = m_name;
            m_frameParser.AutoRepeatCapturedPlayback = false;
            m_frameParser.AutoStartDataParsingSequence = false;
            m_frameParser.SkipDisableRealTimeData = true;

            // Create a new data publishing server
            m_dataPublisher = new TimeSeriesFramework.DataPublisher();
        }

        /// <summary>
        /// Releases the unmanaged resources before the <see cref="CommonPhasorServices"/> object is reclaimed by <see cref="GC"/>.
        /// </summary>
        ~CommonPhasorServices()
        {
            Dispose(false);
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets the name of this <see cref="CommonPhasorServices"/> instance.
        /// </summary>
        /// <remarks>
        /// Derived classes should provide a name for the adapter.
        /// </remarks>
        public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
            }
        }

        /// <summary>
        /// Gets or sets numeric ID associated with this <see cref="CommonPhasorServices"/> instance.
        /// </summary>
        public uint ID
        {
            get
            {
                return m_id;
            }
            set
            {
                m_id = value;
            }
        }

        /// <summary>
        /// Gets or sets key/value pair connection information specific to this <see cref="CommonPhasorServices"/> instance.
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return m_connectionString;
            }
            set
            {
                m_connectionString = value;

                // Preparse settings upon connection string assignment
                if (string.IsNullOrEmpty(m_connectionString))
                    m_settings = new Dictionary<string, string>();
                else
                    m_settings = m_connectionString.ParseKeyValuePairs();
            }
        }

        /// <summary>
        /// Gets a read-only reference to the collection that contains this <see cref="CommonPhasorServices"/> instance.
        /// </summary>
        public ReadOnlyCollection<IAdapter> Parent
        {
            get
            {
                return new ReadOnlyCollection<IAdapter>(m_parent);
            }
        }

        /// <summary>
        /// Gets or sets <see cref="DataSet"/> based data source available to this <see cref="CommonPhasorServices"/> instance.
        /// </summary>
        public DataSet DataSource
        {
            get
            {
                return m_dataSource;
            }
            set
            {
                m_dataSource = value;

                // Cascade to data publishing server
                if (m_dataPublisher != null)
                    m_dataPublisher.DataSource = value;
            }
        }

        /// <summary>
        /// Gets or sets maximum time system will wait during <see cref="Start"/> for initialization.
        /// </summary>
        /// <remarks>
        /// Set to <see cref="Timeout.Infinite"/> to wait indefinitely.
        /// </remarks>
        public int InitializationTimeout
        {
            get
            {
                return m_initializationTimeout;
            }
            set
            {
                m_initializationTimeout = value;

                // Cascade to data publishing server
                if (m_dataPublisher != null)
                    m_dataPublisher.InitializationTimeout = value;
            }
        }

        /// <summary>
        /// Gets or sets output measurements that the <see cref="CommonPhasorServices"/> will produce, if any.
        /// </summary>
        public IMeasurement[] OutputMeasurements
        {
            get
            {
                return null;
            }
            set
            {
                // Not used
            }
        }

        /// <summary>
        /// Gets or sets primary keys of input measurements the <see cref="CommonPhasorServices"/> expects, if any.
        /// </summary>
        public MeasurementKey[] InputMeasurementKeys
        {
            get
            {
                return null;
            }
            set
            {
                // Not used
            }
        }

        /// <summary>
        /// Gets the total number of measurements handled thus far by the <see cref="CommonPhasorServices"/>.
        /// </summary>
        public long ProcessedMeasurements
        {
            get
            {
                return m_processedMeasurements;
            }
        }

        /// <summary>
        /// Gets or sets the measurement reporting interval.
        /// </summary>
        /// <remarks>
        /// This is used to determined how many measurements should be processed before reporting status.
        /// </remarks>
        public int MeasurementReportingInterval
        {
            get
            {
                return m_measurementReportingInterval;
            }
            set
            {
                m_measurementReportingInterval = value;
            }
        }

        /// <summary>
        /// Gets or sets flag indicating if the adapter has been initialized successfully.
        /// </summary>
        public bool Initialized
        {
            get
            {
                return m_initialized;
            }
            set
            {
                m_initialized = value;

                // When initialization is complete we send notification
                if (m_initializeWaitHandle != null)
                {
                    if (value)
                        m_initializeWaitHandle.Set();
                    else
                        m_initializeWaitHandle.Reset();
                }
            }
        }

        /// <summary>
        /// Gets or sets enabled state of this <see cref="CommonPhasorServices"/> instance.
        /// </summary>
        /// <remarks>
        /// Base class simply starts or stops <see cref="CommonPhasorServices"/> based on flag value. Derived classes should
        /// extend this if needed to enable or disable operational state of the adapter based on flag value.
        /// </remarks>
        public bool Enabled
        {
            get
            {
                return m_enabled;
            }
            set
            {
                if (m_enabled && !value)
                    Stop();
                else if (!m_enabled && value)
                    Start();
            }
        }

        /// <summary>
        /// Gets settings <see cref="Dictionary{TKey,TValue}"/> parsed when <see cref="ConnectionString"/> was assigned.
        /// </summary>
        public Dictionary<string, string> Settings
        {
            get
            {
                return m_settings;
            }
        }

        /// <summary>
        /// Gets or sets the frames per second to be used by the <see cref="CommonPhasorServices"/>.
        /// </summary>
        /// <remarks>
        /// This value is only tracked in the <see cref="CommonPhasorServices"/>.
        /// </remarks>
        public int FramesPerSecond
        {
            get
            {
                return m_framesPerSecond;
            }
            set
            {
                m_framesPerSecond = value;
            }
        }

        /// <summary>
        /// Gets the status of this <see cref="CommonPhasorServices"/> instance.
        /// </summary>
        /// <remarks>
        /// Derived classes should provide current status information about the adapter for display purposes.
        /// </remarks>
        public string Status
        {
            get
            {
                const int MaxMeasurementsToShow = 10;

                StringBuilder status = new StringBuilder();
                DataSet dataSource = this.DataSource;

                status.AppendFormat("       Data source defined: {0}", (dataSource != null));
                status.AppendLine();
                if (dataSource != null)
                {
                    status.AppendFormat("    Referenced data source: {0}, {1} tables", dataSource.DataSetName, dataSource.Tables.Count);
                    status.AppendLine();
                }
                status.AppendFormat("    Initialization timeout: {0}", InitializationTimeout < 0 ? "Infinite" : InitializationTimeout.ToString() + " milliseconds");
                status.AppendLine();
                status.AppendFormat("       Adapter initialized: {0}", Initialized);
                status.AppendLine();
                status.AppendFormat("         Parent collection: {0}", m_parent == null ? "Undefined" : m_parent.Name);
                status.AppendLine();
                status.AppendFormat("         Operational state: {0}", Enabled ? "Running" : "Stopped");
                status.AppendLine();
                status.AppendFormat("    Processed measurements: {0}", ProcessedMeasurements);
                status.AppendLine();
                status.AppendFormat("   Item reporting interval: {0}", MeasurementReportingInterval);
                status.AppendLine();
                status.AppendFormat("                Adpater ID: {0}", ID);
                status.AppendLine();

                Dictionary<string, string> keyValuePairs = Settings;
                char[] keyChars;
                string value;

                status.AppendFormat("         Connection string: {0} key/value pairs", keyValuePairs.Count);
                //                            1         2         3         4         5         6         7
                //                   123456789012345678901234567890123456789012345678901234567890123456789012345678
                //                                         Key = Value
                //                                                        1         2         3         4         5
                //                                               12345678901234567890123456789012345678901234567890
                status.AppendLine();
                status.AppendLine();

                foreach (KeyValuePair<string, string> item in keyValuePairs)
                {
                    keyChars = item.Key.Trim().ToCharArray();
                    keyChars[0] = char.ToUpper(keyChars[0]);

                    value = item.Value.Trim();
                    if (value.Length > 50)
                        value = value.TruncateRight(47) + "...";

                    status.AppendFormat("{0} = {1}", (new string(keyChars)).TruncateRight(25).PadLeft(25), value.PadRight(50));
                    status.AppendLine();
                }

                status.AppendLine();

                if (OutputMeasurements != null)
                {
                    status.AppendFormat("       Output measurements: {0} defined measurements", OutputMeasurements.Length);
                    status.AppendLine();
                    status.AppendLine();

                    for (int i = 0; i < TVA.Common.Min(OutputMeasurements.Length, MaxMeasurementsToShow); i++)
                    {
                        status.Append(OutputMeasurements[i].ToString().TruncateRight(25).PadLeft(25));
                        status.Append(" ");
                        status.AppendLine(OutputMeasurements[i].SignalID.ToString());
                    }

                    if (OutputMeasurements.Length > MaxMeasurementsToShow)
                        status.AppendLine("...".PadLeft(26));

                    status.AppendLine();
                }

                if (InputMeasurementKeys != null)
                {
                    status.AppendFormat("        Input measurements: {0} defined measurements", InputMeasurementKeys.Length);
                    status.AppendLine();
                    status.AppendLine();

                    for (int i = 0; i < TVA.Common.Min(InputMeasurementKeys.Length, MaxMeasurementsToShow); i++)
                    {
                        status.AppendLine(InputMeasurementKeys[i].ToString().TruncateRight(25).CenterText(50));
                    }

                    if (InputMeasurementKeys.Length > MaxMeasurementsToShow)
                        status.AppendLine("...".CenterText(50));

                    status.AppendLine();
                }

                status.AppendFormat("        Defined frame rate: {0} frames/sec", FramesPerSecond);
                status.AppendLine();

                if (m_dataPublisher != null)
                {
                    status.AppendLine();
                    status.AppendLine("Data Publishing Server:");
                    status.AppendLine();
                    status.Append(m_dataPublisher.Status);
                }

                return status.ToString();
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Releases all the resources used by the <see cref="CommonPhasorServices"/> object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="CommonPhasorServices"/> object and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                try
                {
                    if (disposing)
                    {
                        // Dispose of initialization wait handle
                        if (m_initializeWaitHandle != null)
                            m_initializeWaitHandle.Close();

                        m_initializeWaitHandle = null;

                        // Detach from frame parser events and dispose
                        if (m_frameParser != null)
                        {
                            m_frameParser.ConnectionAttempt -= m_frameParser_ConnectionAttempt;
                            m_frameParser.ConnectionEstablished -= m_frameParser_ConnectionEstablished;
                            m_frameParser.ConnectionException -= m_frameParser_ConnectionException;
                            m_frameParser.ConnectionTerminated -= m_frameParser_ConnectionTerminated;
                            m_frameParser.ExceededParsingExceptionThreshold -= m_frameParser_ExceededParsingExceptionThreshold;
                            m_frameParser.ParsingException -= m_frameParser_ParsingException;
                            m_frameParser.ReceivedConfigurationFrame -= m_frameParser_ReceivedConfigurationFrame;
                            m_frameParser.Dispose();
                        }
                        m_frameParser = null;

                        // Dispose configuration of wait handle
                        if (m_configurationWaitHandle != null)
                            m_configurationWaitHandle.Close();

                        m_configurationWaitHandle = null;

                        m_configurationFrame = null;

                        // Dispose of statistic calculation timer
                        if (m_statisticCalculationTimer != null)
                        {
                            m_statisticCalculationTimer.Elapsed -= m_statisticCalculationTimer_Elapsed;
                            m_statisticCalculationTimer.Dispose();
                        }
                        m_statisticCalculationTimer = null;

                        // Dispose of data publishing server
                        if (m_dataPublisher != null)
                        {
                            m_dataPublisher.StatusMessage -= StatusMessage;
                            m_dataPublisher.ProcessException -= ProcessException;
                            //m_dataPublisher.NewMeasurements -= NewMeasurements;
                            m_dataPublisher.UnpublishedSamples -= UnpublishedSamples;
                            //m_dataPublisher.DiscardingMeasurements -= DiscardingMeasurements;
                            m_dataPublisher.Dispose();
                        }
                        m_dataPublisher = null;

                    }
                }
                finally
                {
                    m_disposed = true;  // Prevent duplicate dispose.

                    if (Disposed != null)
                        Disposed(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Intializes <see cref="CommonPhasorServices"/>.
        /// </summary>
        public void Initialize()
        {
            Initialized = false;

            Dictionary<string, string> settings = Settings;
            string setting;
            double reportingInterval;

            // Initialize standard adapter settings
            if (settings.TryGetValue("inputMeasurementKeys", out setting))
                InputMeasurementKeys = AdapterBase.ParseInputMeasurementKeys(DataSource, setting);

            if (settings.TryGetValue("outputMeasurements", out setting))
                OutputMeasurements = AdapterBase.ParseOutputMeasurements(DataSource, setting);

            if (settings.TryGetValue("measurementReportingInterval", out setting))
                MeasurementReportingInterval = int.Parse(setting);
            else
                MeasurementReportingInterval = DefaultMeasurementReportingInterval;

            if (settings.TryGetValue("framesPerSecond", out setting))
                m_framesPerSecond = int.Parse(setting);

            // Load the statistic reporting interval - note that the CommonPhasorServices instance
            // is usually loaded from the configuration data source so changes in this value should
            // be applied in the connection string from there, typically the IaonActionAdapter view.
            if (settings.TryGetValue("statisticReportingInverval", out setting))
                reportingInterval = double.Parse(setting) * 1000.0D;
            else
                reportingInterval = 10000.0D; // Default statistic reporting interval is 10 seconds

            // Setup the statistic calculation timer
            m_statisticCalculationTimer = new System.Timers.Timer();
            m_statisticCalculationTimer.Elapsed += m_statisticCalculationTimer_Elapsed;
            m_statisticCalculationTimer.Interval = reportingInterval;
            m_statisticCalculationTimer.AutoReset = true;
            m_statisticCalculationTimer.Enabled = false;

            ReloadStatistics();

            // Initialize the data publishing server (load settings from config file)
            if (m_dataPublisher != null)
            {
                m_dataPublisher.Name = "dataPublisher";
                m_dataPublisher.StatusMessage += StatusMessage;
                m_dataPublisher.ProcessException += ProcessException;
                //m_dataPublisher.NewMeasurements += NewMeasurements;
                m_dataPublisher.UnpublishedSamples += UnpublishedSamples;
                //m_dataPublisher.DiscardingMeasurements += DiscardingMeasurements;
                m_dataPublisher.Initialize();
            }
        }

        /// <summary>
        /// Starts the <see cref="CommonPhasorServices"/> or restarts it if it is already running.
        /// </summary>
        [AdapterCommand("Starts the common phasor services adapter or restarts it if it is already running.")]
        public void Start()
        {
            // Make sure we are stopped (e.g., disconnected) before attempting to start (e.g., connect)
            if (!m_enabled)
            {
                // Wait for adapter intialization to complete...
                m_enabled = WaitForInitialize(InitializationTimeout);

                if (m_dataPublisher != null)
                    m_dataPublisher.Start();

                if (!m_enabled)
                    OnProcessException(new TimeoutException("Failed to start adapter due to timeout waiting for initialization."));
            }
        }

        /// <summary>
        /// Stops the <see cref="CommonPhasorServices"/>.
        /// </summary>		
        [AdapterCommand("Stops the common phasor services adapter.")]
        public void Stop()
        {
            m_enabled = false;

            if (m_dataPublisher != null)
                m_dataPublisher.Stop();
        }

        // Assigns the reference to the parent adapter collection that will contain this adapter.
        void IAdapter.AssignParentCollection(IAdapterCollection parent)
        {
            // The common phasor services class does not inherit from the FacileActionAdapterBase (or ActionAdapterBase) since
            // it needs an internal reference to the IAdapter collections. With this internal reference all adapter collections
            // in the AllAdaptersCollection (the parent of the ActionAdapterCollection) can be referenced. This is needed so
            // that the common phasor services instance can cross reference the input adapter collection for monitoring devices
            // for statistic collection. As such this painfully requires full implementation of IAdapter and IActionAdapter, as
            // you see inside this class.
            m_parent = parent;

            if (parent != null)
            {
                // Dereference primary Iaon adapter collections
                m_inputAdapters = m_parent.Parent.Where(collection => collection is InputAdapterCollection).First() as InputAdapterCollection;
                m_actionAdapters = m_parent.Parent.Where(collection => collection is ActionAdapterCollection).First() as ActionAdapterCollection;
                //m_outputAdapters = m_parent.Parent.Where(collection => collection is OutputAdapterCollection).First() as OutputAdapterCollection;
            }
            else
            {
                m_inputAdapters = null;
                m_actionAdapters = null;
                //m_outputAdapters = null;
            }

            // Assign parent collection for data publishing server
            if (m_dataPublisher != null)
                ((IAdapter)m_dataPublisher).AssignParentCollection(parent);
        }

        /// <summary>
        /// Manually sets the intialized state of the <see cref="CommonPhasorServices"/>.
        /// </summary>
        /// <param name="initialized">Desired initialized state.</param>
        [AdapterCommand("Manually sets the intialized state of the adapter.")]
        public void SetInitializedState(bool initialized)
        {
            this.Initialized = initialized;
        }

        /// <summary>
        /// Gets a short one-line status of this <see cref="CommonPhasorServices"/>.
        /// </summary>
        /// <param name="maxLength">Maximum number of available characters for display.</param>
        /// <returns>A short one-line summary of the current status of the <see cref="CommonPhasorServices"/>.</returns>
        public string GetShortStatus(int maxLength)
        {
            return "Type \"LISTCOMMANDS 0\" to enumerate service commands.".CenterText(maxLength);
        }

        /// <summary>
        /// Blocks the <see cref="Thread.CurrentThread"/> until the adapter is <see cref="Initialized"/>.
        /// </summary>
        /// <param name="timeout">The number of milliseconds to wait.</param>
        /// <returns><c>true</c> if the initialization succeeds; otherwise, <c>false</c>.</returns>
        public bool WaitForInitialize(int timeout)
        {
            if (m_initializeWaitHandle != null)
                return m_initializeWaitHandle.WaitOne(timeout);

            return false;
        }

        /// <summary>
        /// Requests a configuration frame from a phasor device.
        /// </summary>
        /// <param name="connectionString">Connection string used to connect to phasor device.</param>
        /// <returns>A <see cref="IConfigurationFrame"/> if successful, -or- <c>null</c> if request failed.</returns>
        [AdapterCommand("Connects to a phasor device and requests its configuration frame.")]
        public IConfigurationFrame RequestDeviceConfiguration(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                OnStatusMessage("ERROR: No connection string was specified, request for configuration canceled.");
                return new ConfigurationErrorFrame();
            }

            // Define a line of asterisks for emphasis
            string stars = new string('*', 79);

            // Only allow configuration request if another request is not already pending...
            if (Monitor.TryEnter(m_frameParser))
            {
                try
                {
                    Dictionary<string, string> settings = connectionString.ParseKeyValuePairs();
                    string setting;
                    ushort accessID;

                    // Get accessID from connection string
                    if (settings.TryGetValue("accessID", out setting))
                        accessID = ushort.Parse(setting);
                    else
                        accessID = 1;

                    // Most of the parameters in the connection string will be for the data source in the frame parser
                    // so we provide all of them, other parameters will simply be ignored
                    m_frameParser.ConnectionString = connectionString;

                    // Provide access ID to frame parser as this may be necessary to make a phasor connection
                    m_frameParser.DeviceID = accessID;

                    // Clear any existing configuration frame
                    m_configurationFrame = null;

                    // Inform user of temporary loss of command access
                    OnStatusMessage("\r\n{0}\r\n\r\nAttempting to request remote device configuration.\r\n\r\nThis request could take up to sixty seconds to complete.\r\n\r\nNo other commands will be accepted until this request succeeds or fails.\r\n\r\n{0}", stars, stars);

                    // Make sure the wait handle is not set
                    m_configurationWaitHandle.Reset();

                    // Start the frame parser - this will attempt connection
                    m_frameParser.Start();

                    // We wait a maximum of 60 seconds to receive the configuration frame - this delay should be the maximum time ever needed
                    // to receive a configuration frame. If the device connection is Active or Hybrid then the configuration frame should be
                    // returned immediately - for purely Passive connections the configuration frame is delivered once per minute.
                    if (!m_configurationWaitHandle.WaitOne(60000))
                        OnStatusMessage("WARNING: Timed-out waiting to retrieve remote device configuration.");

                    // Terminate connection to device
                    m_frameParser.Stop();

                    if (m_configurationFrame == null)
                    {
                        m_configurationFrame = new ConfigurationErrorFrame();
                        OnStatusMessage("Failed to retrieve remote device configuration.");
                    }

                    return m_configurationFrame;
                }
                catch (Exception ex)
                {
                    OnStatusMessage("ERROR: Failed to request configuration due to exception: {0}", ex.Message);
                }
                finally
                {
                    // Release the lock
                    Monitor.Exit(m_frameParser);

                    // Inform user of restoration of command access
                    OnStatusMessage("\r\n{0}\r\n\r\nRemote device configuration request completed.\r\n\r\nCommand access has been restored.\r\n\r\n{0}", stars, stars);
                }
            }
            else
                OnStatusMessage("ERROR: Cannot process simultaneous requests for device configurations, please try again in a few seconds..");

            return new ConfigurationErrorFrame();
        }

        /// <summary>
        /// Sends the specified <see cref="DeviceCommand"/> to the current device connection.
        /// </summary>
        /// <param name="command"><see cref="DeviceCommand"/> to send to connected device.</param>
        public void SendCommand(DeviceCommand command)
        {
            if (m_frameParser != null)
            {
                m_frameParser.SendDeviceCommand(command);
                OnStatusMessage("Sent device command \"{0}\"...", command);
            }
            else
                OnStatusMessage("Failed to send device command \"{0}\", no frame parser is defined.", command);
        }

        /// <summary>
        /// Queues a single measurement for processing.
        /// </summary>
        /// <param name="measurement">Measurement to queue for processing.</param>
        public void QueueMeasurementForProcessing(IMeasurement measurement)
        {
            QueueMeasurementsForProcessing(new IMeasurement[] { measurement });
        }

        /// <summary>
        /// Queues a collection of measurements for processing.
        /// </summary>
        /// <param name="measurements">Collection of measurements to queue for processing.</param>
        public void QueueMeasurementsForProcessing(IEnumerable<IMeasurement> measurements)
        {
            //if (m_dataPublisher != null)
            //    m_dataPublisher.QueueMeasurementsForProcessing(measurements);
        }

        /// <summary>
        /// Raises the <see cref="StatusMessage"/> event.
        /// </summary>
        /// <param name="status">New status message.</param>
        protected virtual void OnStatusMessage(string status)
        {
            if (StatusMessage != null)
                StatusMessage(this, new EventArgs<string>(status));
        }

        /// <summary>
        /// Raises the <see cref="StatusMessage"/> event with a formatted status message.
        /// </summary>
        /// <param name="formattedStatus">Formatted status message.</param>
        /// <param name="args">Arguments for <paramref name="formattedStatus"/>.</param>
        /// <remarks>
        /// This overload combines string.Format and OnStatusMessage for convienence.
        /// </remarks>
        protected virtual void OnStatusMessage(string formattedStatus, params object[] args)
        {
            if (StatusMessage != null)
                StatusMessage(this, new EventArgs<string>(string.Format(formattedStatus, args)));
        }

        /// <summary>
        /// Raises <see cref="ProcessException"/> event.
        /// </summary>
        /// <param name="ex">Processing <see cref="Exception"/>.</param>
        protected virtual void OnProcessException(Exception ex)
        {
            if (ProcessException != null)
                ProcessException(this, new EventArgs<Exception>(ex));
        }

        /// <summary>
        /// Raises the <see cref="NewMeasurements"/> event.
        /// </summary>
        protected virtual void OnNewMeasurements(ICollection<IMeasurement> measurements)
        {
            if (NewMeasurements != null)
                NewMeasurements(this, new EventArgs<ICollection<IMeasurement>>(measurements));

            IncrementProcessedMeasurements(measurements.Count);
        }

        /// <summary>
        /// Raises the <see cref="UnpublishedSamples"/> event.
        /// </summary>
        /// <param name="seconds">Total number of unpublished seconds of data.</param>
        protected virtual void OnUnpublishedSamples(int seconds)
        {
            if (UnpublishedSamples != null)
                UnpublishedSamples(this, new EventArgs<int>(seconds));
        }

        /// <summary>
        /// Raises the <see cref="DiscardingMeasurements"/> event.
        /// </summary>
        /// <param name="measurements">Enumeration of <see cref="IMeasurement"/> values being discarded.</param>
        protected virtual void OnDiscardingMeasurements(IEnumerable<IMeasurement> measurements)
        {
            if (DiscardingMeasurements != null)
                DiscardingMeasurements(this, new EventArgs<IEnumerable<IMeasurement>>(measurements));
        }

        /// <summary>
        /// Safely increments the total processed measurements.
        /// </summary>
        /// <param name="totalAdded"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        protected virtual void IncrementProcessedMeasurements(long totalAdded)
        {
            // Check to see if total number of added points will exceed process interval used to show periodic
            // messages of how many points have been archived so far...
            int interval = MeasurementReportingInterval;

            if (interval > 0)
            {
                bool showMessage = m_processedMeasurements + totalAdded >= (m_processedMeasurements / interval + 1) * interval;

                m_processedMeasurements += totalAdded;

                if (showMessage)
                    OnStatusMessage("{0:N0} measurements have been processed so far...", m_processedMeasurements);
            }
        }

        /// <summary>
        /// Loads or reloads system statistics.
        /// </summary>
        [AdapterCommand("Reloads system statistics."), SuppressMessage("Microsoft.Reliability", "CA2001")]
        public void ReloadStatistics()
        {
            // Make sure setting exists to allow user to by-pass phasor data source validation at startup
            ConfigurationFile configFile = ConfigurationFile.Current;
            CategorizedSettingsElementCollection settings = configFile.Settings["systemSettings"];
            settings.Add("ProcessPhasorStatistics", true, "Determines if the phasor statistics should be processed during operation");

            // See if statistics should be processed
            if (settings["ProcessPhasorStatistics"].ValueAsBoolean())
            {
                List<Statistic> statistics = new List<Statistic>();
                Statistic statistic;
                Assembly assembly;
                Type type;
                MethodInfo method;
                Measurement definedMeasurement;
                MeasurementKey pointID;
                string assemblyName, typeName, methodName, signalReference;

                lock (m_parent)
                {
                    // Turn off statistic calculation timer while statistics are being reloaded
                    m_statisticCalculationTimer.Enabled = false;

                    // Load all defined statistics
                    foreach (DataRow row in DataSource.Tables["Statistics"].Select("Enabled <> 0", "Source, SignalIndex"))
                    {
                        // Create a new statistic
                        statistic = new Statistic();

                        // Load primary statistic parameters
                        statistic.Source = row["Source"].ToNonNullString();
                        statistic.Index = int.Parse(row["SignalIndex"].ToNonNullString("-1"));
                        statistic.Arguments = row["Arguments"].ToNonNullString();

                        // Load statistic's code location information
                        assemblyName = row["AssemblyName"].ToNonNullString();
                        typeName = row["TypeName"].ToNonNullString();
                        methodName = row["MethodName"].ToNonNullString();

                        if (string.IsNullOrEmpty(assemblyName))
                            throw new InvalidOperationException("Statistic assembly name was not defined.");

                        if (string.IsNullOrEmpty(typeName))
                            throw new InvalidOperationException("Statistic type name was not defined.");

                        if (string.IsNullOrEmpty(methodName))
                            throw new InvalidOperationException("Statistic method name was not defined.");

                        try
                        {
                            // See if statistic is defined in this assembly (no need to reload)
                            if (string.Compare(GetType().FullName, typeName, true) == 0)
                            {
                                // Assign statistic handler to local method (assumed to be private static)
                                statistic.Method = (StatisticCalculationFunction)Delegate.CreateDelegate(typeof(StatisticCalculationFunction), GetType().GetMethod(methodName, BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod));
                            }
                            else
                            {
                                // Load statistic method from containing assembly and type
                                assembly = Assembly.LoadFrom(FilePath.GetAbsolutePath(assemblyName));
                                type = assembly.GetType(typeName);
                                method = type.GetMethod(methodName, BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.InvokeMethod);

                                // Assign statistic handler to loaded assembly method
                                statistic.Method = (StatisticCalculationFunction)Delegate.CreateDelegate(typeof(StatisticCalculationFunction), method);
                            }
                        }
                        catch (Exception ex)
                        {
                            OnProcessException(new InvalidOperationException(string.Format("Failed to load statistic handler \"{0}\" from \"{1} [{2}::{3}()]\" due to exception: {4}", row["Name"].ToNonNullString("n/a"), assemblyName, typeName, methodName, ex.Message), ex));
                        }

                        // Add statistic to list
                        statistics.Add(statistic);
                    }

                    OnStatusMessage("Loaded {0} statistic calculation definitions...", statistics.Count);

                    // Filter statistics to device, input stream and output stream types
                    m_deviceStatistics = statistics.Where(stat => string.Compare(stat.Source, "Device", true) == 0).ToArray();
                    m_inputStreamStatistics = statistics.Where(stat => string.Compare(stat.Source, "InputStream", true) == 0).ToArray();
                    m_outputStreamStatistics = statistics.Where(stat => string.Compare(stat.Source, "OutputStream", true) == 0).ToArray();

                    // Calculate maximum signal indices
                    if (m_deviceStatistics.Length > 0)
                        m_deviceStatisticsMaxIndex = m_deviceStatistics.Max(stat => stat.Index);
                    else
                        m_deviceStatisticsMaxIndex = 0;

                    if (m_inputStreamStatistics.Length > 0)
                        m_inputStreamStatisticsMaxIndex = m_inputStreamStatistics.Max(stat => stat.Index);
                    else
                        m_inputStreamStatisticsMaxIndex = 0;

                    if (m_outputStreamStatistics.Length > 0)
                        m_outputStreamStatisticsMaxIndex = m_outputStreamStatistics.Max(stat => stat.Index);
                    else
                        m_outputStreamStatisticsMaxIndex = 0;

                    // Load statistical measurements
                    m_definedMeasurements = new Dictionary<string, IMeasurement>();

                    foreach (DataRow row in DataSource.Tables["ActiveMeasurements"].Select("SignalType='STAT'"))
                    {
                        signalReference = row["SignalReference"].ToString();

                        if (!string.IsNullOrEmpty(signalReference))
                        {
                            try
                            {
                                // Get measurement's point ID formatted as a measurement key
                                pointID = MeasurementKey.Parse(row["ID"].ToString());

                                // Create a measurement with a reference associated with this adapter
                                definedMeasurement = new Measurement(
                                    pointID.ID,
                                    pointID.Source,
                                    signalReference,
                                    double.Parse(row["Adder"].ToNonNullString("0.0")),
                                    double.Parse(row["Multiplier"].ToNonNullString("1.0")));

                                // Assign signal ID to defined measurement
                                definedMeasurement.SignalID = new Guid(row["SignalID"].ToNonNullString(Guid.NewGuid().ToString()));

                                // Add measurement to definition list keyed by signal reference
                                m_definedMeasurements.Add(signalReference, definedMeasurement);
                            }
                            catch (Exception ex)
                            {
                                OnProcessException(new InvalidOperationException(string.Format("Failed to load signal reference \"{0}\" due to exception: {1}", signalReference, ex.Message), ex));
                            }
                        }
                    }

                    OnStatusMessage("Loaded {0} statistic measurements...", m_definedMeasurements.Count);

                    // Turn on statistic calculation timer
                    m_statisticCalculationTimer.Enabled = true;
                }
            }
            else
            {
                lock (m_parent)
                {
                    // Make sure statistic calculation timer is off since statistics aren't being processed
                    m_statisticCalculationTimer.Enabled = false;
                }
            }
        }

        // Calculate statistics for each device and output stream
        private void m_statisticCalculationTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ICollection<IMeasurement> mappedMeasurements = new List<IMeasurement>();
            Measurement measurement;

            lock (m_parent)
            {
                DateTime serverTime = DateTime.UtcNow;

                try
                {
                    // Filter input adapter collection down to the phasor measurement mapper input streams
                    IEnumerable<PhasorMeasurementMapper> inputStreams = m_inputAdapters.Where<IInputAdapter>(adapter => adapter is PhasorMeasurementMapper).Cast<PhasorMeasurementMapper>();

                    // Calculate defined statistics for each input stream
                    foreach (PhasorMeasurementMapper inputStream in inputStreams)
                    {
                        foreach (Statistic statistic in m_inputStreamStatistics)
                        {
                            // Create a new measurement that will hold the calculated statistical value
                            measurement = new Measurement();
                            measurement.Timestamp = serverTime;

                            try
                            {
                                // Calculate statistic
                                measurement.Value = statistic.Method(inputStream, statistic.Arguments);

                                // Map attributes to new statistic measurement
                                MapMeasurementAttributes(mappedMeasurements, inputStream.GetSignalReference(FundamentalSignalType.Statistic, statistic.Index - 1, m_inputStreamStatisticsMaxIndex), measurement);
                            }
                            catch (Exception ex)
                            {
                                OnProcessException(new InvalidOperationException(string.Format("Exception encountered while calculating input stream statistic {0} for \"{1}\": {2}", statistic.Index, inputStream.Name, ex.Message), ex));
                            }
                        }
                    }

                    // Filter input adapter collection down to the configuration cells of each phasor measurement mapper
                    IEnumerable<ConfigurationCell> devices = inputStreams.SelectMany(mapper => mapper.DefinedDevices);

                    // Calculate defined statistics for each device
                    foreach (ConfigurationCell device in devices)
                    {
                        foreach (Statistic statistic in m_deviceStatistics)
                        {
                            // Create a new measurement that will hold the calculated statistical value
                            measurement = new Measurement();
                            measurement.Timestamp = serverTime;

                            try
                            {
                                // Calculate statistic
                                measurement.Value = statistic.Method(device, statistic.Arguments);

                                // Map attributes to new statistic measurement
                                MapMeasurementAttributes(mappedMeasurements, device.GetSignalReference(FundamentalSignalType.Statistic, statistic.Index - 1, m_deviceStatisticsMaxIndex), measurement);
                            }
                            catch (Exception ex)
                            {
                                OnProcessException(new InvalidOperationException(string.Format("Exception encountered while calculating device statistic {0} for \"{1}\": {2}", statistic.Index, device.IDLabel, ex.Message), ex));
                            }
                        }
                    }

                    // Filter action adapter collection down to the phasor data concentrator output streams
                    IEnumerable<PhasorDataConcentratorBase> outputStreams = m_actionAdapters.Where<IActionAdapter>(adapter => adapter is PhasorDataConcentratorBase).Cast<PhasorDataConcentratorBase>();

                    // Calculate defined statistics for each output stream
                    foreach (PhasorDataConcentratorBase outputStream in outputStreams)
                    {
                        foreach (Statistic statistic in m_outputStreamStatistics)
                        {
                            // Create a new measurement that will hold the calculated statistical value
                            measurement = new Measurement();
                            measurement.Timestamp = serverTime;

                            try
                            {
                                // Calculate statistic
                                measurement.Value = statistic.Method(outputStream, statistic.Arguments);

                                // Map attributes to new statistic measurement
                                MapMeasurementAttributes(mappedMeasurements, outputStream.GetSignalReference(FundamentalSignalType.Statistic, statistic.Index - 1, m_outputStreamStatisticsMaxIndex), measurement);
                            }
                            catch (Exception ex)
                            {
                                OnProcessException(new InvalidOperationException(string.Format("Exception encountered while calculating output stream statistic {0} for \"{1}\": {2}", statistic.Index, outputStream.Name, ex.Message), ex));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    OnProcessException(new InvalidOperationException(string.Format("Exception encountered while calculating statistics: {0}", ex.Message), ex));
                }
            }

            // Provide real-time measurements where needed
            OnNewMeasurements(mappedMeasurements);
        }

        /// <summary>
        /// Map parsed measurement value to defined measurement attributes (i.e., assign meta-data to parsed measured value).
        /// </summary>
        /// <param name="mappedMeasurements">Destination collection for the mapped measurement values.</param>
        /// <param name="signalReference">Derived <see cref="SignalReference"/> string for the parsed measurement value.</param>
        /// <param name="parsedMeasurement">The parsed <see cref="IMeasurement"/> value.</param>
        /// <remarks>
        /// This procedure is used to identify a parsed measurement value by its derived signal reference and apply the
        /// additional needed measurement meta-data attributes (i.e., ID, Source, Adder and Multiplier).
        /// </remarks>
        protected void MapMeasurementAttributes(ICollection<IMeasurement> mappedMeasurements, string signalReference, IMeasurement parsedMeasurement)
        {
            // Coming into this function the parsed measurement value will only have a "value" and a "timestamp"; the measurement
            // will not yet be associated with an actual historian measurement ID.  We take the generated signal reference and
            // use that to lookup the actual historian measurement ID, source, adder and multipler.
            IMeasurement definedMeasurement;

            // Lookup signal reference in defined measurement list
            if (m_definedMeasurements.TryGetValue(signalReference, out definedMeasurement))
            {
                // Assign ID and other relevant attributes to the parsed measurement value
                parsedMeasurement.ID = definedMeasurement.ID;
                parsedMeasurement.Source = definedMeasurement.Source;
                parsedMeasurement.SignalID = definedMeasurement.SignalID;
                parsedMeasurement.Adder = definedMeasurement.Adder;              // Allows for run-time additive measurement value adjustments
                parsedMeasurement.Multiplier = definedMeasurement.Multiplier;    // Allows for run-time mulplicative measurement value adjustments

                // Add the updated measurement value to the destination measurement collection
                mappedMeasurements.Add(parsedMeasurement);
            }
        }

        private void m_frameParser_ReceivedConfigurationFrame(object sender, EventArgs<IConfigurationFrame> e)
        {
            // Cache received configuration frame
            m_configurationFrame = e.Argument;

            OnStatusMessage("Successfully received configuration frame!");

            // Clear wait handle
            m_configurationWaitHandle.Set();
        }

        private void m_frameParser_ConnectionTerminated(object sender, EventArgs e)
        {
            // Communications layer closed connection (close not initiated by system) - so we cancel request..
            if (m_frameParser.Enabled)
                OnStatusMessage("ERROR: Connection closed by remote device, request for configuration canceled.");

            // Clear wait handle
            m_configurationWaitHandle.Set();
        }

        private void m_frameParser_ConnectionEstablished(object sender, EventArgs e)
        {
            OnStatusMessage("Connected to remote device, requesting configuration frame...");

            // Send manual request for configuration frame
            SendCommand(DeviceCommand.SendConfigurationFrame2);
        }

        private void m_frameParser_ConnectionException(object sender, EventArgs<Exception, int> e)
        {
            OnStatusMessage("ERROR: Connection attempt failed, request for configuration canceled: {0}", e.Argument1.Message);

            // Clear wait handle
            m_configurationWaitHandle.Set();
        }

        private void m_frameParser_ParsingException(object sender, EventArgs<Exception> e)
        {
            OnStatusMessage("ERROR: Parsing exception during request for configuration: {0}", e.Argument.Message);
        }

        private void m_frameParser_ExceededParsingExceptionThreshold(object sender, EventArgs e)
        {
            OnStatusMessage("\r\nRequest for configuration canceled due to an excessive number of exceptions...\r\n");

            // Clear wait handle
            m_configurationWaitHandle.Set();
        }

        private void m_frameParser_ConnectionAttempt(object sender, EventArgs e)
        {
            OnStatusMessage("Attempting {0} {1} based connection...", m_frameParser.PhasorProtocol.GetFormattedProtocolName(), m_frameParser.TransportProtocol.ToString().ToUpper());
        }

        #endregion

        #region [ Static ]

        // Static Fields
        private static StatisticValueStateCache s_statisticValueCache = new StatisticValueStateCache();
        private static long s_maximumLatency;   // Cached maximum latency
        private static long s_averageLatency;   // Cached average latency
        private static long s_configChanges;    // Cached configuration changes

        // Static Methods

        // Apply start-up phasor data source validations
        [SuppressMessage("Microsoft.Maintainability", "CA1502")]
        private static void PhasorDataSourceValidation(IDbConnection connection, Type adapterType, string nodeIDQueryString, Action<object, EventArgs<string>> statusMessage, Action<object, EventArgs<Exception>> processException)
        {
            // Make sure setting exists to allow user to by-pass phasor data source validation at startup
            ConfigurationFile configFile = ConfigurationFile.Current;
            CategorizedSettingsElementCollection settings = configFile.Settings["systemSettings"];
            settings.Add("ProcessPhasorDataSourceValidation", true, "Determines if the phasor data source validation should be processed at startup");

            // See if this node should process phasor source validation
            if (settings["ProcessPhasorDataSourceValidation"].ValueAsBoolean())
            {
                CreateDefaultNode(connection, nodeIDQueryString, statusMessage, processException);
                LoadDefaultConfigurationEntity(connection, statusMessage, processException);
                LoadDefaultInterconnection(connection, statusMessage, processException);
                LoadDefaultProtocol(connection, statusMessage, processException);
                LoadDefaultSignalType(connection, statusMessage, processException);
                LoadDefaultStatistic(connection, statusMessage, processException);

                statusMessage("CommonPhasorServices", new EventArgs<string>("Validating signal types..."));

                // Validate that the acronym for status flags is FLAG (it was STAT in prior versions)
                if (connection.ExecuteScalar("SELECT Acronym FROM SignalType WHERE Suffix='SF';").ToNonNullString().ToUpper() == "STAT")
                    connection.ExecuteNonQuery("UPDATE SignalType SET Acronym='FLAG' WHERE Suffix='SF';");

                // Validate that the calculation and statistic signal types are defined (they did not in initial release)
                if (Convert.ToInt32(connection.ExecuteScalar("SELECT COUNT(*) FROM SignalType WHERE Acronym='CALC';")) == 0)
                    connection.ExecuteNonQuery("INSERT INTO SignalType(Name, Acronym, Suffix, Abbreviation, Source, EngineeringUnits) VALUES('Calculated Value', 'CALC', 'CV', 'C', 'PMU', '');");

                if (Convert.ToInt32(connection.ExecuteScalar("SELECT COUNT(*) FROM SignalType WHERE Acronym='STAT';")) == 0)
                    connection.ExecuteNonQuery("INSERT INTO SignalType(Name, Acronym, Suffix, Abbreviation, Source, EngineeringUnits) VALUES('Statistic', 'STAT', 'ST', 'P', 'Any', '');");

                statusMessage("CommonPhasorServices", new EventArgs<string>("Verifying statistics archive exists..."));

                // Validate that the statistics historian exists
                if (Convert.ToInt32(connection.ExecuteScalar(string.Format("SELECT COUNT(*) FROM Historian WHERE Acronym='STAT' AND NodeID={0};", nodeIDQueryString))) == 0)
                    connection.ExecuteNonQuery(string.Format("INSERT INTO Historian(NodeID, Acronym, Name, AssemblyName, TypeName, ConnectionString, IsLocal, Description, LoadOrder, Enabled) VALUES({0}, 'STAT', 'Statistics Archive', 'HistorianAdapters.dll', 'HistorianAdapters.LocalOutputAdapter', '', 1, 'Local historian used to archive system statistics', 9999, 1);", nodeIDQueryString));

                // Make sure statistics path exists to hold historian files
                string statisticsPath = FilePath.GetAbsolutePath(FilePath.AddPathSuffix("Statistics"));

                if (!Directory.Exists(statisticsPath))
                    Directory.CreateDirectory(statisticsPath);

                // Make sure needed statistic historian configuration settings are properly defined
                settings = configFile.Settings["statMetadataFile"];                
                settings.Add("FileName", "Statistics\\stat_dbase.dat", "Name of the statistics meta-data file including its path.");
                settings.Add("LoadOnOpen", true, "True if file records are to be loaded in memory when opened; otherwise False - this defaults to True for the statistics meta-data file.");
                settings.Add("ReloadOnModify", true, "True if file records loaded in memory are to be re-loaded when file is modified on disk; otherwise False - this defaults to True for the statistics meta-data file.");

                settings = configFile.Settings["statStateFile"];                
                settings.Add("FileName", "Statistics\\stat_startup.dat", "Name of the statistics state file including its path.");
                settings.Add("AutoSaveInterval", 10000, "Interval in milliseconds at which the file records loaded in memory are to be saved automatically to disk. Use -1 to disable automatic saving - this defaults to 10,000 for the statistics state file.");
                settings.Add("LoadOnOpen", true, "True if file records are to be loaded in memory when opened; otherwise False - this defaults to True for the statistics state file.");
                settings.Add("SaveOnClose", true, "True if file records loaded in memory are to be saved to disk when file is closed; otherwise False - this defaults to True for the statistics state file.");

                settings = configFile.Settings["statIntercomFile"];                
                settings.Add("FileName", "Statistics\\scratch.dat", "Name of the statistics intercom file including its path.");
                settings.Add("AutoSaveInterval", 10000, "Interval in milliseconds at which the file records loaded in memory are to be saved automatically to disk. Use -1 to disable automatic saving - this defaults to 10,000 for the statistics intercom file.");
                settings.Add("LoadOnOpen", true, "True if file records are to be loaded in memory when opened; otherwise False - this defaults to True for the statistics intercom file.");
                settings.Add("SaveOnClose", true, "True if file records loaded in memory are to be saved to disk when file is closed; otherwise False - this defaults to True for the statistics intercom file.");

                settings = configFile.Settings["statArchiveFile"];
                settings.Add("FileName", "Statistics\\stat_archive.d", "Name of the statistics working archive file including its path.");
                settings.Add("CacheWrites", true, "True if writes are to be cached for performance; otherwise False - this defaults to True for the statistics working archive file.");
                settings.Add("ConserveMemory", false, "True if attempts are to be made to conserve memory; otherwise False - this defaults to False for the statistics working archive file.");

                settings = configFile.Settings["statMetadataService"];
                settings.Add("Enabled", true, "True if this web service is enabled; otherwise False - this defaults to True for the statistics meta-data service.");
                settings.Add("ServiceUri", "http://localhost:6051/historian", "URI where this web service is to be hosted - this defaults to http://localhost:6051/historian for the statistics meta-data service.");

                settings = configFile.Settings["statTimeSeriesDataService"];
                settings.Add("Enabled", true, "True if this web service is enabled; otherwise False - this defaults to True for the statistics time-series data service.");
                settings.Add("ServiceUri", "http://localhost:6052/historian", "URI where this web service is to be hosted - this defaults to http://localhost:6052/historian for the statistics time-series data service.");
                
                configFile.Save();

                // Get the needed statistic related IDs
                int statSignalTypeID = (int)connection.ExecuteScalar("SELECT ID FROM SignalType WHERE Acronym='STAT';");
                int statHistorianID = (int)connection.ExecuteScalar(string.Format("SELECT ID FROM Historian WHERE Acronym='STAT' AND NodeID={0};", nodeIDQueryString));
                object nodeCompanyID = connection.ExecuteScalar(string.Format("SELECT CompanyID FROM Node WHERE ID={0};", nodeIDQueryString));

                // Load the defined system statistics
                IEnumerable<DataRow> statistics = connection.RetrieveData(adapterType, "SELECT * FROM Statistic ORDER BY Source, SignalIndex;").AsEnumerable();

                // Filter statistics to device, input stream and output stream types            
                IEnumerable<DataRow> deviceStatistics = statistics.Where(row => string.Compare(row.Field<string>("Source"), "Device", true) == 0);
                IEnumerable<DataRow> inputStreamStatistics = statistics.Where(row => string.Compare(row.Field<string>("Source"), "InputStream", true) == 0);
                IEnumerable<DataRow> outputStreamStatistics = statistics.Where(row => string.Compare(row.Field<string>("Source"), "OutputStream", true) == 0);

                string acronym, signalReference, pointTag, company, vendorDevice, description;
                int signalIndex;

                statusMessage("CommonPhasorServices", new EventArgs<string>("Validating device statistic measurements..."));

                // Make sure needed device statistic measurements exist
                foreach (DataRow device in connection.RetrieveData(adapterType, string.Format("SELECT * FROM Device WHERE IsConcentrator = 0 AND NodeID = {0};", nodeIDQueryString)).Rows)
                {
                    foreach (DataRow statistic in deviceStatistics)
                    {
                        acronym = device.Field<string>("Acronym");
                        signalIndex = statistic.Field<int>("SignalIndex");
                        signalReference = SignalReference.ToString(acronym, FundamentalSignalType.Statistic, signalIndex);

                        if (Convert.ToInt32(connection.ExecuteScalar(string.Format("SELECT COUNT(*) FROM Measurement WHERE SignalReference='{0}' AND HistorianID={1};", signalReference, statHistorianID))) == 0)
                        {
                            company = (string)connection.ExecuteScalar(string.Format("SELECT MapAcronym FROM Company WHERE ID={0};", device.Field<int>("CompanyID")));
                            vendorDevice = (string)connection.ExecuteScalar(string.Format("SELECT Name FROM VendorDevice WHERE ID={0};", device.Field<int?>("VendorDeviceID") ?? 0));
                            pointTag = string.Format("{0}_{1}:ST{2}", company, acronym, signalIndex);
                            description = string.Format("{0} {1} Statistic for {2}", device.Field<string>("Name"), vendorDevice, statistic.Field<string>("Description"));

                            IDbCommand command = CreateParameterizedCommand(connection, "INSERT INTO Measurement(HistorianID, DeviceID, PointTag, SignalTypeID, PhasorSourceIndex, SignalReference, Description, Enabled) VALUES(@statHistorianID, @deviceID, @pointTag, @statSignalTypeID, NULL, @signalReference, @description, 1);", statHistorianID, device.Field<int>("ID"), pointTag, statSignalTypeID, signalReference, description);
                            command.ExecuteNonQuery();
                        }
                    }
                }

                statusMessage("CommonPhasorServices", new EventArgs<string>("Validating input stream statistic measurements..."));

                // Make sure needed input stream statistic measurements exist
                foreach (DataRow inputStream in connection.RetrieveData(adapterType, string.Format("SELECT * FROM Device WHERE ((IsConcentrator <> 0) OR (IsConcentrator = 0 AND ParentID IS NULL)) AND (NodeID = {0});", nodeIDQueryString)).Rows)
                {
                    foreach (DataRow statistic in inputStreamStatistics)
                    {
                        acronym = inputStream.Field<string>("Acronym") + "!IS";
                        signalIndex = statistic.Field<int>("SignalIndex");
                        signalReference = SignalReference.ToString(acronym, FundamentalSignalType.Statistic, signalIndex);

                        if (Convert.ToInt32(connection.ExecuteScalar(string.Format("SELECT COUNT(*) FROM Measurement WHERE SignalReference='{0}' AND HistorianID={1};", signalReference, statHistorianID))) == 0)
                        {
                            company = (string)connection.ExecuteScalar(string.Format("SELECT MapAcronym FROM Company WHERE ID={0};", inputStream.Field<int>("CompanyID")));
                            vendorDevice = (string)connection.ExecuteScalar(string.Format("SELECT Name FROM VendorDevice WHERE ID={0};", inputStream.Field<int?>("VendorDeviceID") ?? 0)); // Modified to retrieve VendorDeviceID into Nullable of Int as it is not a required field.
                            pointTag = string.Format("{0}_{1}:ST{2}", company, acronym, signalIndex);
                            description = string.Format("{0} {1} Statistic for {2}", inputStream.Field<string>("Name"), vendorDevice, statistic.Field<string>("Description"));

                            IDbCommand command = CreateParameterizedCommand(connection, "INSERT INTO Measurement(HistorianID, DeviceID, PointTag, SignalTypeID, PhasorSourceIndex, SignalReference, Description, Enabled) VALUES(@statHistorianID, @deviceID, @pointTag, @statSignalTypeID, NULL, @signalReference, @description, 1);", statHistorianID, inputStream.Field<int>("ID"), pointTag, statSignalTypeID, signalReference, description);
                            command.ExecuteNonQuery();
                        }
                    }
                }

                statusMessage("CommonPhasorServices", new EventArgs<string>("Validating output stream statistic measurements..."));

                // Make sure needed output stream statistic measurements exist
                foreach (DataRow outputStream in connection.RetrieveData(adapterType, string.Format("SELECT * FROM OutputStream WHERE NodeID = {0};", nodeIDQueryString)).Rows)
                {
                    foreach (DataRow statistic in outputStreamStatistics)
                    {
                        acronym = outputStream.Field<string>("Acronym") + "!OS";
                        signalIndex = statistic.Field<int>("SignalIndex");
                        signalReference = SignalReference.ToString(acronym, FundamentalSignalType.Statistic, signalIndex);

                        if (Convert.ToInt32(connection.ExecuteScalar(string.Format("SELECT COUNT(*) FROM Measurement WHERE SignalReference='{0}' AND HistorianID={1};", signalReference, statHistorianID))) == 0)
                        {
                            if (nodeCompanyID is DBNull)
                                company = configFile.Settings["systemSettings"]["CompanyAcronym"].Value.TruncateRight(3);
                            else
                                company = (string)connection.ExecuteScalar(string.Format("SELECT MapAcronym FROM Company WHERE ID={0};", nodeCompanyID));

                            pointTag = string.Format("{0}_{1}:ST{2}", company, acronym, signalIndex);
                            description = string.Format("{0} Statistic for {1}", outputStream.Field<string>("Name"), statistic.Field<string>("Description"));

                            IDbCommand command = CreateParameterizedCommand(connection, "INSERT INTO Measurement(HistorianID, DeviceID, PointTag, SignalTypeID, PhasorSourceIndex, SignalReference, Description, Enabled) VALUES(@statHistorianID, NULL, @pointTag, @statSignalTypeID, NULL, @signalReference, @description, 1);", statHistorianID, pointTag, statSignalTypeID, signalReference, description);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Creates and returns a parameterized SQL command. Parameter names are embedded in the SQL statement
        /// passed as a parameter to this method. This method does very rudimentary parsing of the SQL statement so parameter
        /// names should start with the '@' character and should be surrounded by either spaces, parentheses, or commas.
        /// </summary>
        /// <param name="connection">The database connection.</param>
        /// <param name="sql">The SQL statement.</param>
        /// <param name="args">The parameters for the command in the order that they appear in the SQL statement.</param>
        /// <returns>The parameterized command.</returns>
        private static IDbCommand CreateParameterizedCommand(IDbConnection connection, string sql, params object[] args)
        {
            // TODO: Move function to TVA.Data.DataExtensions as an extension...
            string[] tokens = sql.Split(' ', '(', ')', ',');
            IDbCommand command = connection.CreateCommand();
            int i = 0;

            foreach (string token in tokens)
            {
                if (token.StartsWith("@") && !command.Parameters.Contains(token))
                {
                    IDbDataParameter parameter = command.CreateParameter();

                    parameter.ParameterName = token;
                    parameter.Value = args[i++];
                    parameter.Direction = ParameterDirection.Input;

                    command.Parameters.Add(parameter);
                }
            }

            command.CommandText = sql;
            return command;
        }
        
        /// <summary>
        /// Creates the default node for the Node table.
        /// </summary>
        /// <param name="connection">The database connection.</param>
        /// <param name="nodeIDQueryString">The ID of the node in the proper database format.</param>
        /// <param name="statusMessage">The delegate which will display a status message to the user.</param>
        /// <param name="processException">The delegate which will handle exception logging.</param>
        private static void CreateDefaultNode(IDbConnection connection, string nodeIDQueryString, Action<object, EventArgs<string>> statusMessage, Action<object, EventArgs<Exception>> processException)
        {
            if (Convert.ToInt32(connection.ExecuteScalar("SELECT COUNT(*) FROM Node;")) == 0)
            {
                statusMessage("CommonPhasorServices", new EventArgs<string>("Creating default record for Node..."));
                connection.ExecuteNonQuery("INSERT INTO Node(Name, Description, TimeSeriesDataServiceUrl, RemoteStatusServiceUrl, RealTimeStatisticServiceUrl, Master, LoadOrder, Enabled) VALUES('Default', 'Default node', 'http://localhost:6152/historian', 'Server=localhost:8500', 'http://localhost:6052/historian', 1, 0, 1);");
                connection.ExecuteNonQuery("UPDATE Node SET ID=" + nodeIDQueryString + ";");
            }
        }

        /// <summary>
        /// Loads the default configuration for the ConfigurationEntity table.
        /// </summary>
        /// <param name="connection">The database connection.</param>
        /// <param name="statusMessage">The delegate which will display a status message to the user.</param>
        /// <param name="processException">The delegate which will handle exception logging.</param>
        private static void LoadDefaultConfigurationEntity(IDbConnection connection, Action<object, EventArgs<string>> statusMessage, Action<object, EventArgs<Exception>> processException)
        {
            if (Convert.ToInt32(connection.ExecuteScalar("SELECT COUNT(*) FROM ConfigurationEntity;")) == 0)
            {
                statusMessage("CommonPhasorServices", new EventArgs<string>("Loading default records for ConfigurationEntity..."));
                connection.ExecuteNonQuery("INSERT INTO ConfigurationEntity(SourceName, RuntimeName, Description, LoadOrder, Enabled) VALUES('IaonInputAdapter', 'InputAdapters', 'Defines IInputAdapter definitions for a PDC node', 1, 1);");
                connection.ExecuteNonQuery("INSERT INTO ConfigurationEntity(SourceName, RuntimeName, Description, LoadOrder, Enabled) VALUES('IaonActionAdapter', 'ActionAdapters', 'Defines IActionAdapter definitions for a PDC node', 2, 1);");
                connection.ExecuteNonQuery("INSERT INTO ConfigurationEntity(SourceName, RuntimeName, Description, LoadOrder, Enabled) VALUES('IaonOutputAdapter', 'OutputAdapters', 'Defines IOutputAdapter definitions for a PDC node', 3, 1);");
                connection.ExecuteNonQuery("INSERT INTO ConfigurationEntity(SourceName, RuntimeName, Description, LoadOrder, Enabled) VALUES('ActiveMeasurement', 'ActiveMeasurements', 'Defines active system measurements for a PDC node', 4, 1);");
                connection.ExecuteNonQuery("INSERT INTO ConfigurationEntity(SourceName, RuntimeName, Description, LoadOrder, Enabled) VALUES('RuntimeInputStreamDevice', 'InputStreamDevices', 'Defines input stream devices associated with a concentrator', 5, 1);");
                connection.ExecuteNonQuery("INSERT INTO ConfigurationEntity(SourceName, RuntimeName, Description, LoadOrder, Enabled) VALUES('RuntimeOutputStreamDevice', 'OutputStreamDevices', 'Defines output stream devices defined for a concentrator', 6, 1);");
                connection.ExecuteNonQuery("INSERT INTO ConfigurationEntity(SourceName, RuntimeName, Description, LoadOrder, Enabled) VALUES('RuntimeOutputStreamMeasurement', 'OutputStreamMeasurements', 'Defines output stream measurements for an output stream', 7, 1);");
                connection.ExecuteNonQuery("INSERT INTO ConfigurationEntity(SourceName, RuntimeName, Description, LoadOrder, Enabled) VALUES('OutputStreamDevicePhasor', 'OutputStreamDevicePhasors', 'Defines phasors for output stream devices', 8, 1);");
                connection.ExecuteNonQuery("INSERT INTO ConfigurationEntity(SourceName, RuntimeName, Description, LoadOrder, Enabled) VALUES('OutputStreamDeviceAnalog', 'OutputStreamDeviceAnalogs', 'Defines analog values for output stream devices', 9, 1);");
                connection.ExecuteNonQuery("INSERT INTO ConfigurationEntity(SourceName, RuntimeName, Description, LoadOrder, Enabled) VALUES('OutputStreamDeviceDigital', 'OutputStreamDeviceDigitals', 'Defines digital values for output stream devices', 10, 1);");
                connection.ExecuteNonQuery("INSERT INTO ConfigurationEntity(SourceName, RuntimeName, Description, LoadOrder, Enabled) VALUES('RuntimeStatistic', 'Statistics', 'Defines statistics that are monitored for devices and output streams', 11, 1);");
            }
        }

        /// <summary>
        /// Loads the default configuration for the Interconnection table.
        /// </summary>
        /// <param name="connection">The database connection.</param>
        /// <param name="statusMessage">The delegate which will display a status message to the user.</param>
        /// <param name="processException">The delegate which will handle exception logging.</param>
        private static void LoadDefaultInterconnection(IDbConnection connection, Action<object, EventArgs<string>> statusMessage, Action<object, EventArgs<Exception>> processException)
        {
            if (Convert.ToInt32(connection.ExecuteScalar("SELECT COUNT(*) FROM Interconnection;")) == 0)
            {
                statusMessage("CommonPhasorServices", new EventArgs<string>("Loading default records for Interconnection..."));
                connection.ExecuteNonQuery("INSERT INTO Interconnection(Acronym, Name, LoadOrder) VALUES('Eastern', 'Eastern Interconnection', 0);");
                connection.ExecuteNonQuery("INSERT INTO Interconnection(Acronym, Name, LoadOrder) VALUES('Western', 'Western Interconnection', 1);");
                connection.ExecuteNonQuery("INSERT INTO Interconnection(Acronym, Name, LoadOrder) VALUES('ERCOT', 'Texas Interconnection', 2);");
                connection.ExecuteNonQuery("INSERT INTO Interconnection(Acronym, Name, LoadOrder) VALUES('Quebec', 'Quebec Interconnection', 3);");
                connection.ExecuteNonQuery("INSERT INTO Interconnection(Acronym, Name, LoadOrder) VALUES('Alaskan', 'Alaskan Interconnection', 4);");
                connection.ExecuteNonQuery("INSERT INTO Interconnection(Acronym, Name, LoadOrder) VALUES('Hawaii', 'Islands of Hawaii', 5);");
            }
        }

        /// <summary>
        /// Loads the default configuration for the Protocol table.
        /// </summary>
        /// <param name="connection">The database connection.</param>
        /// <param name="statusMessage">The delegate which will display a status message to the user.</param>
        /// <param name="processException">The delegate which will handle exception logging.</param>
        private static void LoadDefaultProtocol(IDbConnection connection, Action<object, EventArgs<string>> statusMessage, Action<object, EventArgs<Exception>> processException)
        {
            if (Convert.ToInt32(connection.ExecuteScalar("SELECT COUNT(*) FROM Protocol;")) == 0)
            {
                statusMessage("CommonPhasorServices", new EventArgs<string>("Loading default records for Protocol..."));
                connection.ExecuteNonQuery("INSERT INTO Protocol(Acronym, Name) VALUES('BpaPdcStream', 'BPA PDCstream');");
                connection.ExecuteNonQuery("INSERT INTO Protocol(Acronym, Name) VALUES('OPC', 'OPC');");
                connection.ExecuteNonQuery("INSERT INTO Protocol(Acronym, Name) VALUES('Ieee1344', 'IEEE 1344-1995');");
                connection.ExecuteNonQuery("INSERT INTO Protocol(Acronym, Name) VALUES('IeeeC37_118D6', 'IEEE C37.118 Draft 6');");
                connection.ExecuteNonQuery("INSERT INTO Protocol(Acronym, Name) VALUES('IeeeC37_118V1', 'IEEE C37.118-2005');");
                connection.ExecuteNonQuery("INSERT INTO Protocol(Acronym, Name) VALUES('FNet', 'Virginia Tech FNET');");
                connection.ExecuteNonQuery("INSERT INTO Protocol(Acronym, Name) VALUES('SelFastMessage', 'SEL Fast Message');");
                connection.ExecuteNonQuery("INSERT INTO Protocol(Acronym, Name) VALUES('Macrodyne', 'Macrodyne');");
            }
        }

        /// <summary>
        /// Loads the default configuration for the SignalType table.
        /// </summary>
        /// <param name="connection">The database connection.</param>
        /// <param name="statusMessage">The delegate which will display a status message to the user.</param>
        /// <param name="processException">The delegate which will handle exception logging.</param>
        private static void LoadDefaultSignalType(IDbConnection connection, Action<object, EventArgs<string>> statusMessage, Action<object, EventArgs<Exception>> processException)
        {
            if (Convert.ToInt32(connection.ExecuteScalar("SELECT COUNT(*) FROM SignalType;")) == 0)
            {
                statusMessage("CommonPhasorServices", new EventArgs<string>("Loading default records for SignalType..."));
                connection.ExecuteNonQuery("INSERT INTO SignalType(Name, Acronym, Suffix, Abbreviation, Source, EngineeringUnits) VALUES('Current Magnitude', 'IPHM', 'PM', 'I', 'Phasor', 'Amps');");
                connection.ExecuteNonQuery("INSERT INTO SignalType(Name, Acronym, Suffix, Abbreviation, Source, EngineeringUnits) VALUES('Current Phase Angle', 'IPHA', 'PA', 'IH', 'Phasor', 'Degrees');");
                connection.ExecuteNonQuery("INSERT INTO SignalType(Name, Acronym, Suffix, Abbreviation, Source, EngineeringUnits) VALUES('Voltage Magnitude', 'VPHM', 'PM', 'V', 'Phasor', 'Volts');");
                connection.ExecuteNonQuery("INSERT INTO SignalType(Name, Acronym, Suffix, Abbreviation, Source, EngineeringUnits) VALUES('Voltage Phase Angle', 'VPHA', 'PA', 'VH', 'Phasor', 'Degrees');");
                connection.ExecuteNonQuery("INSERT INTO SignalType(Name, Acronym, Suffix, Abbreviation, Source, EngineeringUnits) VALUES('Frequency', 'FREQ', 'FQ', 'F', 'PMU', 'Hz');");
                connection.ExecuteNonQuery("INSERT INTO SignalType(Name, Acronym, Suffix, Abbreviation, Source, EngineeringUnits) VALUES('Frequency Delta (dF/dt)', 'DFDT', 'DF', 'DF', 'PMU', '');");
                connection.ExecuteNonQuery("INSERT INTO SignalType(Name, Acronym, Suffix, Abbreviation, Source, EngineeringUnits) VALUES('Analog Value', 'ALOG', 'AV', 'A', 'PMU', '');");
                connection.ExecuteNonQuery("INSERT INTO SignalType(Name, Acronym, Suffix, Abbreviation, Source, EngineeringUnits) VALUES('Status Flags', 'FLAG', 'SF', 'S', 'PMU', '');");
                connection.ExecuteNonQuery("INSERT INTO SignalType(Name, Acronym, Suffix, Abbreviation, Source, EngineeringUnits) VALUES('Digital Value', 'DIGI', 'DV', 'D', 'PMU', '');");
                connection.ExecuteNonQuery("INSERT INTO SignalType(Name, Acronym, Suffix, Abbreviation, Source, EngineeringUnits) VALUES('Calculated Value', 'CALC', 'CV', 'C', 'PMU', '');");
                connection.ExecuteNonQuery("INSERT INTO SignalType(Name, Acronym, Suffix, Abbreviation, Source, EngineeringUnits) VALUES('Statistic', 'STAT', 'ST', 'P', 'Any', '');");
            }
        }

        /// <summary>
        /// Loads the default configuration for the Statistic table.
        /// </summary>
        /// <param name="connection">The database connection.</param>
        /// <param name="statusMessage">The delegate which will display a status message to the user.</param>
        /// <param name="processException">The delegate which will handle exception logging.</param>
        private static void LoadDefaultStatistic(IDbConnection connection, Action<object, EventArgs<string>> statusMessage, Action<object, EventArgs<Exception>> processException)
        {
            if (Convert.ToInt32(connection.ExecuteScalar("SELECT COUNT(*) FROM Statistic;")) == 0)
            {
                statusMessage("CommonPhasorServices", new EventArgs<string>("Loading default records for Statistic..."));
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('Device', 1, 'Data Quality Errors', 'Number of data quaility errors reported by device during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetDeviceStatistic_DataQualityErrors', '', 1,  'System.Int32', @displayFormat, 0, 1);", "{0:N0}");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('Device', 2, 'Time Quality Errors', 'Number of time quality errors reported by device during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetDeviceStatistic_TimeQualityErrors', '', 1,  'System.Int32', @displayFormat, 0, 2);", "{0:N0}");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('Device', 3, 'Device Errors', 'Number of device errors reported by device during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetDeviceStatistic_DeviceErrors', '', 1,  'System.Int32', @displayFormat, 0, 3);", "{0:N0}");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('InputStream', 1, 'Total Frames', 'Total number of frames received from input stream during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetInputStreamStatistic_TotalFrames', '', 1,  'System.Int32', @displayFormat, 0, 2);", "{0:N0}");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('InputStream', 2, 'Last Report Time', 'Timestamp of last received data frame from input stream.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetInputStreamStatistic_LastReportTime', '', 1,  'System.DateTime', @displayFormat, 0, 1);", "{0:mm':'ss'.'fff}");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('InputStream', 3, 'Missing Frames', 'Number of frames that were not received from input stream during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetInputStreamStatistic_MissingFrames', '', 1,  'System.Int32', @displayFormat, 0, 3);", "{0:N0}");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('InputStream', 4, 'CRC Errors', 'Number of CRC errors reported from input stream during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetInputStreamStatistic_CRCErrors', '', 1,  'System.Int32', @displayFormat, 0, 15);", "{0:N0}");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('InputStream', 5, 'Out of Order Frames', 'Number of out-of-order frames received from input stream during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetInputStreamStatistic_OutOfOrderFrames', '', 1,  'System.Int32', @displayFormat, 0, 16);", "{0:N0}");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('InputStream', 6, 'Minimum Latency', 'Minimum latency from input stream, in milliseconds, during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetInputStreamStatistic_MinimumLatency', '', 1,  'System.Double', @displayFormat, 0, 9);", "{0:N3} ms");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('InputStream', 7, 'Maximum Latency', 'Maximum latency from input stream, in milliseconds, during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetInputStreamStatistic_MaximumLatency', '', 1,  'System.Double', @displayFormat, 0, 10);", "{0:N3} ms");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('InputStream', 8, 'Input Stream Connected', 'Boolean value representing if input stream was continually connected during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetInputStreamStatistic_Connected', '', 1,  'System.Boolean', @displayFormat, 1, 17);", "{0}");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('InputStream', 9, 'Received Configuration', 'Boolean value representing if input stream has received (or has cached) a configuration frame during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetInputStreamStatistic_ReceivedConfiguration', '', 1,  'System.Boolean', @displayFormat, 0, 7);", "{0}");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('InputStream', 10, 'Configuration Changes', 'Number of configuration changes reported by input stream during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetInputStreamStatistic_ConfigurationChanges', '', 1,  'System.Int32', @displayFormat, 0, 8);", "{0:N0}");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('InputStream', 11, 'Total Data Frames', 'Number of data frames received from input stream during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetInputStreamStatistic_TotalDataFrames', '', 1,  'System.Int32', @displayFormat, 0, 4);", "{0:N0}");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('InputStream', 12, 'Total Configuration Frames', 'Number of configuration frames received from input stream during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetInputStreamStatistic_TotalConfigurationFrames', '', 1,  'System.Int32', @displayFormat, 0, 5);", "{0:N0}");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('InputStream', 13, 'Total Header Frames', 'Number of header frames received from input stream during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetInputStreamStatistic_TotalHeaderFrames', '', 1,  'System.Int32', @displayFormat, 0, 6);", "{0:N0}");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('InputStream', 14, 'Average Latency', 'Average latency, in seconds, for data received from input stream during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetInputStreamStatistic_AverageLatency', '', 1,  'System.Double', @displayFormat, 0, 11);", "{0:N3} ms");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('InputStream', 15, 'Defined Frame Rate', 'Frame rate as defined by input stream during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetInputStreamStatistic_DefinedFrameRate', '', 1,  'System.Int32', @displayFormat, 0, 12);", "{0:N0} frames / second");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('InputStream', 16, 'Actual Frame Rate', 'Latest actual mean frame rate for data received from input stream during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetInputStreamStatistic_ActualFrameRate', '', 1,  'System.Double', @displayFormat, 0, 13);", "{0:N3} frames / second");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('InputStream', 17, 'Actual Data Rate', 'Latest actual mean Mbps data rate for data received from input stream during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetInputStreamStatistic_ActualDataRate', '', 1,  'System.Double', @displayFormat, 0, 14);", "{0:N3} Mbps");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('OutputStream', 1, 'Discarded Measurements', 'Number of discarded measurements reported by output stream during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetOutputStreamStatistic_DiscardedMeasurements', '', 1,  'System.Int32', @displayFormat, 0, 4);", "{0:N0}");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('OutputStream', 2, 'Received Measurements', 'Number of received measurements reported by the output strean during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetOutputStreamStatistic_ReceivedMeasurements', '', 1,  'System.Int32', @displayFormat, 0, 2);", "{0:N0}");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('OutputStream', 3, 'Expected Measurements', 'Number of expected measurements reported by the output stream during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetOutputStreamStatistic_ExpectedMeasurements', '', 1,  'System.Int32', @displayFormat, 0, 1);", "{0:N0}");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('OutputStream', 4, 'Processed Measurements', 'Number of processed measurements reported by the output stream during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetOutputStreamStatistic_ProcessedMeasurements', '', 1,  'System.Int32', @displayFormat, 0, 3);", "{0:N0}");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('OutputStream', 5, 'Measurements Sorted by Arrival', 'Number of measurments sorted by arrival reported by the output stream during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetOutputStreamStatistic_MeasurementsSortedByArrival', '', 1,  'System.Int32', @displayFormat, 0, 7);", "{0:N0}");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('OutputStream', 6, 'Published Measurements', 'Number of published measurements reported by output stream during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetOutputStreamStatistic_PublishedMeasurements', '', 1,  'System.Int32', @displayFormat, 0, 5);", "{0:N0}");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('OutputStream', 7, 'Downsampled Measurements', 'Number of downsampled measurements reported by the output stream during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetOutputStreamStatistic_DownsampledMeasurements', '', 1,  'System.Int32', @displayFormat, 0, 6);", "{0:N0}");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('OutputStream', 8, 'Missed Sorts by Timeout', 'Number of missed sorts by timeout reported by the output stream during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetOutputStreamStatistic_MissedSortsByTimeout', '', 1,  'System.Int32', @displayFormat, 0, 8);", "{0:N0}");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('OutputStream', 9, 'Frames Ahead of Schedule', 'Number of frames ahead of schedule reported by the output stream during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetOutputStreamStatistic_FramesAheadOfSchedule', '', 1,  'System.Int32', @displayFormat, 0, 9);", "{0:N0}");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('OutputStream', 10, 'Published Frames', 'Number of published frames reported by the output stream during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetOutputStreamStatistic_PublishedFrames', '', 1,  'System.Int32', @displayFormat, 0, 10);", "{0:N0}");
                LoadStatistic(connection, "INSERT INTO Statistic(Source, SignalIndex, Name, Description, AssemblyName, TypeName, MethodName, Arguments, Enabled, DataType, DisplayFormat, IsConnectedState, LoadOrder) VALUES('OutputStream', 11, 'Output Stream Connected', 'Boolean value representing if the output stream was continually connected during last reporting interval.', 'TVA.PhasorProtocols.dll', 'TVA.PhasorProtocols.CommonPhasorServices', 'GetOutputStreamStatistic_Connected', '', 1,  'System.Boolean', @displayFormat, 1, 11);", "{0}");
            }
        }

        private static void LoadStatistic(IDbConnection connection, string commandText, string displayFormat)
        {
            IDbCommand command = connection.CreateCommand();
            IDbDataParameter parameter = command.CreateParameter();

            parameter.ParameterName = "@displayFormat";
            parameter.Value = displayFormat;
            parameter.Direction = ParameterDirection.Input;

            command.Parameters.Add(parameter);
            command.CommandText = commandText;
            command.ExecuteNonQuery();
        }

        #region [ Device Statistic Calculators ]

        /// <summary>
        /// Calculates number of data quaility errors reported by device during last reporting interval.
        /// </summary>
        /// <param name="source">Source Device.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Data Quality Errors Statistic.</returns>
        private static double GetDeviceStatistic_DataQualityErrors(object source, string arguments)
        {
            double statistic = 0.0D;
            ConfigurationCell device = source as ConfigurationCell;

            if (device != null)
                statistic = s_statisticValueCache.GetDifference(device, device.DataQualityErrors, "DataQualityErrors");

            return statistic;
        }

        /// <summary>
        /// Calculates number of time quality errors reported by device during last reporting interval.
        /// </summary>
        /// <param name="source">Source Device.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Time Quality Errors Statistic.</returns>
        private static double GetDeviceStatistic_TimeQualityErrors(object source, string arguments)
        {
            double statistic = 0.0D;
            ConfigurationCell device = source as ConfigurationCell;

            if (device != null)
                statistic = s_statisticValueCache.GetDifference(device, device.TimeQualityErrors, "TimeQualityErrors");

            return statistic;
        }

        /// <summary>
        /// Calculates number of device errors reported by device during last reporting interval.
        /// </summary>
        /// <param name="source">Source Device.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Device Errros Statistic.</returns>
        private static double GetDeviceStatistic_DeviceErrors(object source, string arguments)
        {
            double statistic = 0.0D;
            ConfigurationCell device = source as ConfigurationCell;

            if (device != null)
                statistic = s_statisticValueCache.GetDifference(device, device.DeviceErrors, "DeviceErrors");

            return statistic;
        }

        #endregion

        #region [ InputStream Statistic Calculators ]

        /// <summary>
        /// Calculates total number of frames received from input stream during last reporting interval.
        /// </summary>
        /// <param name="source">Source InputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Total Frames Statistic.</returns>
        private static double GetInputStreamStatistic_TotalFrames(object source, string arguments)
        {
            double statistic = 0.0D;
            PhasorMeasurementMapper inputStream = source as PhasorMeasurementMapper;

            if (inputStream != null)
                statistic = s_statisticValueCache.GetDifference(inputStream, inputStream.TotalFrames, "TotalFrames");

            return statistic;
        }

        /// <summary>
        /// Calculates timestamp of last received data frame from input stream.
        /// </summary>
        /// <param name="source">Source InputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Last Report Time Statistic.</returns>
        private static double GetInputStreamStatistic_LastReportTime(object source, string arguments)
        {
            double statistic = 0.0D;
            PhasorMeasurementMapper inputStream = source as PhasorMeasurementMapper;

            // Local archival uses a 32-bit floating point number for statistical value storage so we
            // reduce the last reporting time resolution down to the hour to make sure the archived
            // timestamp is accurate at least to the milliseconds - remaining date/time high data bits
            // can be later deduced from the statistic's archival timestamp
            if (inputStream != null)
            {
                Ticks lastReportTime = inputStream.LastReportTime;
                statistic = lastReportTime - lastReportTime.BaselinedTimestamp(BaselineTimeInterval.Hour);
            }

            return statistic;
        }

        /// <summary>
        /// Calculates number of frames that were not received from input stream during last reporting interval.
        /// </summary>
        /// <param name="source">Source InputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Missing Frames Statistic.</returns>
        private static double GetInputStreamStatistic_MissingFrames(object source, string arguments)
        {
            double statistic = 0.0D;
            PhasorMeasurementMapper inputStream = source as PhasorMeasurementMapper;

            if (inputStream != null)
                statistic = s_statisticValueCache.GetDifference(inputStream, inputStream.MissingFrames, "MissingFrames");

            return statistic;
        }

        /// <summary>
        /// Calculates number of CRC errors reported from input stream during last reporting interval.
        /// </summary>
        /// <param name="source">Source InputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>CRC Errors Statistic.</returns>
        private static double GetInputStreamStatistic_CRCErrors(object source, string arguments)
        {
            double statistic = 0.0D;
            PhasorMeasurementMapper inputStream = source as PhasorMeasurementMapper;

            if (inputStream != null)
                statistic = s_statisticValueCache.GetDifference(inputStream, inputStream.CRCErrors, "CRCErrors");

            return statistic;
        }

        /// <summary>
        /// Calculates number of out-of-order frames received from input stream during last reporting interval.
        /// </summary>
        /// <param name="source">Source InputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Out of Order Frames Statistic.</returns>
        private static double GetInputStreamStatistic_OutOfOrderFrames(object source, string arguments)
        {
            double statistic = 0.0D;
            PhasorMeasurementMapper inputStream = source as PhasorMeasurementMapper;

            if (inputStream != null)
                statistic = s_statisticValueCache.GetDifference(inputStream, inputStream.OutOfOrderFrames, "OutOfOrderFrames");

            return statistic;
        }

        /// <summary>
        /// Calculates minimum latency from input stream, in milliseconds, during last reporting interval.
        /// </summary>
        /// <param name="source">Source InputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <remarks>
        /// This statistic also calculates the maximum and average latency statistics so its load order must occur first.
        /// </remarks>
        /// <returns>Minimum Latency Statistic.</returns>
        private static double GetInputStreamStatistic_MinimumLatency(object source, string arguments)
        {
            double statistic = 0.0D;
            PhasorMeasurementMapper inputStream = source as PhasorMeasurementMapper;

            if (inputStream != null)
            {
                // We get all latency statistics in close sequence for improved accuracy
                statistic = inputStream.MinimumLatency;
                s_maximumLatency = inputStream.MaximumLatency;
                s_averageLatency = inputStream.AverageLatency;
                inputStream.ResetLatencyCounters();
            }
            else
            {
                s_maximumLatency = 0;
                s_averageLatency = 0;
            }

            return statistic;
        }

        /// <summary>
        /// Calculates maximum latency from input stream, in milliseconds, during last reporting interval.
        /// </summary>
        /// <param name="source">Source InputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Maximum Latency Statistic.</returns>
        private static double GetInputStreamStatistic_MaximumLatency(object source, string arguments)
        {
            return s_maximumLatency;
        }

        /// <summary>
        /// Calculates average latency, in seconds, for data received from input stream during last reporting interval.
        /// </summary>
        /// <param name="source">Source InputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Average Latency Statistic.</returns>
        private static double GetInputStreamStatistic_AverageLatency(object source, string arguments)
        {
            return s_averageLatency;
        }

        /// <summary>
        /// Calculates boolean value representing if input stream was continually connected during last reporting interval.
        /// </summary>
        /// <param name="source">Source InputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Input Stream Connected Statistic.</returns>
        private static double GetInputStreamStatistic_Connected(object source, string arguments)
        {
            double statistic = 0.0D;
            PhasorMeasurementMapper inputStream = source as PhasorMeasurementMapper;

            if (inputStream != null)
                statistic = (s_statisticValueCache.GetDifference(inputStream, inputStream.ConnectionAttempts, "ConnectionAttempts") == 0.0D ? 1.0D : 0.0D);

            return statistic;
        }

        /// <summary>
        /// Calculates boolean value representing if input stream has received (or has cached) a configuration frame during last reporting interval.
        /// </summary>
        /// <param name="source">Source InputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <remarks>
        /// This statistic also calculates the total configuration changes so its load order must occur first.
        /// </remarks>
        /// <returns>Received Configuration Statistic.</returns>
        private static double GetInputStreamStatistic_ReceivedConfiguration(object source, string arguments)
        {
            double statistic = 0.0D;
            PhasorMeasurementMapper inputStream = source as PhasorMeasurementMapper;

            if (inputStream != null)
            {
                s_configChanges = (long)s_statisticValueCache.GetDifference(inputStream, inputStream.ConfigurationChanges, "ConfigurationChanges");
                statistic = (s_configChanges > 0 ? 1.0D : 0.0D);
            }
            else
                s_configChanges = 0;

            return statistic;
        }

        /// <summary>
        /// Calculates number of configuration changes reported by input stream during last reporting interval.
        /// </summary>
        /// <param name="source">Source InputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Configuration Changes Statistic.</returns>
        private static double GetInputStreamStatistic_ConfigurationChanges(object source, string arguments)
        {
            return s_configChanges;
        }

        /// <summary>
        /// Calculates number of data frames received from input stream during last reporting interval.
        /// </summary>
        /// <param name="source">Source InputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Total Data Frames Statistic.</returns>
        private static double GetInputStreamStatistic_TotalDataFrames(object source, string arguments)
        {
            double statistic = 0.0D;
            PhasorMeasurementMapper inputStream = source as PhasorMeasurementMapper;

            if (inputStream != null)
                statistic = s_statisticValueCache.GetDifference(inputStream, inputStream.TotalDataFrames, "TotalDataFrames");

            return statistic;
        }

        /// <summary>
        /// Calculates number of configuration frames received from input stream during last reporting interval.
        /// </summary>
        /// <param name="source">Source InputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Total Configuration Frames Statistic.</returns>
        private static double GetInputStreamStatistic_TotalConfigurationFrames(object source, string arguments)
        {
            double statistic = 0.0D;
            PhasorMeasurementMapper inputStream = source as PhasorMeasurementMapper;

            if (inputStream != null)
                statistic = s_statisticValueCache.GetDifference(inputStream, inputStream.TotalConfigurationFrames, "TotalConfigurationFrames");

            return statistic;
        }

        /// <summary>
        /// Calculates number of header frames received from input stream during last reporting interval.
        /// </summary>
        /// <param name="source">Source InputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Total Header Frames Statistic.</returns>
        private static double GetInputStreamStatistic_TotalHeaderFrames(object source, string arguments)
        {
            double statistic = 0.0D;
            PhasorMeasurementMapper inputStream = source as PhasorMeasurementMapper;

            if (inputStream != null)
                statistic = s_statisticValueCache.GetDifference(inputStream, inputStream.TotalHeaderFrames, "TotalHeaderFrames");

            return statistic;
        }

        /// <summary>
        /// Calculates frame rate as defined by input stream during last reporting interval.
        /// </summary>
        /// <param name="source">Source InputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Defined Frame Rate Statistic.</returns>
        private static double GetInputStreamStatistic_DefinedFrameRate(object source, string arguments)
        {
            double statistic = 0.0D;
            PhasorMeasurementMapper inputStream = source as PhasorMeasurementMapper;

            if (inputStream != null)
                statistic = inputStream.DefinedFrameRate;

            return statistic;
        }

        /// <summary>
        /// Calculates latest actual mean frame rate for data received from input stream during last reporting interval.
        /// </summary>
        /// <param name="source">Source InputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Actual Frame Rate Statistic.</returns>
        private static double GetInputStreamStatistic_ActualFrameRate(object source, string arguments)
        {
            double statistic = 0.0D;
            PhasorMeasurementMapper inputStream = source as PhasorMeasurementMapper;

            if (inputStream != null)
                statistic = inputStream.ActualFrameRate;

            return statistic;
        }

        /// <summary>
        /// Calculates latest actual mean Mbps data rate for data received from input stream during last reporting interval.
        /// </summary>
        /// <param name="source">Source InputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Actual Data Rate Statistic.</returns>
        private static double GetInputStreamStatistic_ActualDataRate(object source, string arguments)
        {
            double statistic = 0.0D;
            PhasorMeasurementMapper inputStream = source as PhasorMeasurementMapper;

            if (inputStream != null)
                statistic = inputStream.ActualDataRate * 8.0D / SI.Mega;

            return statistic;
        }

        #endregion

        #region [ OutputStream Statistic Calculators ]

        /// <summary>
        /// Calculates number of discarded measurements reported by output stream during last reporting interval.
        /// </summary>
        /// <param name="source">Source OutputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Discarded Measurements Statistic.</returns>
        private static double GetOutputStreamStatistic_DiscardedMeasurements(object source, string arguments)
        {
            double statistic = 0.0D;
            PhasorDataConcentratorBase outputStream = source as PhasorDataConcentratorBase;

            if (outputStream != null)
                statistic = s_statisticValueCache.GetDifference(outputStream, outputStream.DiscardedMeasurements, "DiscardedMeasurements");

            return statistic;
        }

        /// <summary>
        /// Calculates number of received measurements reported by the output strean during last reporting interval.
        /// </summary>
        /// <param name="source">Source OutputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Received Measurements Statistic.</returns>
        private static double GetOutputStreamStatistic_ReceivedMeasurements(object source, string arguments)
        {
            double statistic = 0.0D;
            PhasorDataConcentratorBase outputStream = source as PhasorDataConcentratorBase;

            if (outputStream != null)
                statistic = s_statisticValueCache.GetDifference(outputStream, outputStream.ReceivedMeasurements, "ReceivedMeasurements");

            return statistic;
        }

        /// <summary>
        /// Calculates number of expected measurements reported by the output stream during last reporting interval.
        /// </summary>
        /// <param name="source">Source OutputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Expected Measurements Statistic.</returns>
        private static double GetOutputStreamStatistic_ExpectedMeasurements(object source, string arguments)
        {
            double statistic = 0.0D;
            PhasorDataConcentratorBase outputStream = source as PhasorDataConcentratorBase;

            if (outputStream != null)
                statistic = s_statisticValueCache.GetDifference(outputStream, outputStream.ExpectedMeasurements, "ExpectedMeasurements");

            return statistic;
        }

        /// <summary>
        /// Calculates number of processed measurements reported by the output stream during last reporting interval.
        /// </summary>
        /// <param name="source">Source OutputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Processed Measurements Statistic.</returns>
        private static double GetOutputStreamStatistic_ProcessedMeasurements(object source, string arguments)
        {
            double statistic = 0.0D;
            PhasorDataConcentratorBase outputStream = source as PhasorDataConcentratorBase;

            if (outputStream != null)
                statistic = s_statisticValueCache.GetDifference(outputStream, outputStream.ProcessedMeasurements, "ProcessedMeasurements");

            return statistic;
        }

        /// <summary>
        /// Calculates number of measurments sorted by arrival reported by the output stream during last reporting interval.
        /// </summary>
        /// <param name="source">Source OutputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Measurements Sorted by Arrival Statistic.</returns>
        private static double GetOutputStreamStatistic_MeasurementsSortedByArrival(object source, string arguments)
        {
            double statistic = 0.0D;
            PhasorDataConcentratorBase outputStream = source as PhasorDataConcentratorBase;

            if (outputStream != null)
                statistic = s_statisticValueCache.GetDifference(outputStream, outputStream.MeasurementsSortedByArrival, "MeasurementsSortedByArrival");

            return statistic;
        }

        /// <summary>
        /// Calculates number of published measurements reported by output stream during last reporting interval.
        /// </summary>
        /// <param name="source">Source OutputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Published Measurements Statistic.</returns>
        private static double GetOutputStreamStatistic_PublishedMeasurements(object source, string arguments)
        {
            double statistic = 0.0D;
            PhasorDataConcentratorBase outputStream = source as PhasorDataConcentratorBase;

            if (outputStream != null)
                statistic = s_statisticValueCache.GetDifference(outputStream, outputStream.PublishedMeasurements, "PublishedMeasurements");

            return statistic;
        }

        /// <summary>
        /// Calculates number of downsampled measurements reported by the output stream during last reporting interval.
        /// </summary>
        /// <param name="source">Source OutputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Downsampled Measurements Statistic.</returns>
        private static double GetOutputStreamStatistic_DownsampledMeasurements(object source, string arguments)
        {
            double statistic = 0.0D;
            PhasorDataConcentratorBase outputStream = source as PhasorDataConcentratorBase;

            if (outputStream != null)
                statistic = s_statisticValueCache.GetDifference(outputStream, outputStream.DownsampledMeasurements, "DownsampledMeasurements");

            return statistic;
        }

        /// <summary>
        /// Calculates number of missed sorts by timeout reported by the output stream during last reporting interval.
        /// </summary>
        /// <param name="source">Source OutputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Missed Sorts by Timeout Statistic.</returns>
        private static double GetOutputStreamStatistic_MissedSortsByTimeout(object source, string arguments)
        {
            double statistic = 0.0D;
            PhasorDataConcentratorBase outputStream = source as PhasorDataConcentratorBase;

            if (outputStream != null)
                statistic = s_statisticValueCache.GetDifference(outputStream, outputStream.MissedSortsByTimeout, "MissedSortsByTimeout");

            return statistic;
        }

        /// <summary>
        /// Calculates number of frames ahead of schedule reported by the output stream during last reporting interval.
        /// </summary>
        /// <param name="source">Source OutputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Frames Ahead of Schedule Statistic.</returns>
        private static double GetOutputStreamStatistic_FramesAheadOfSchedule(object source, string arguments)
        {
            double statistic = 0.0D;
            PhasorDataConcentratorBase outputStream = source as PhasorDataConcentratorBase;

            if (outputStream != null)
                statistic = s_statisticValueCache.GetDifference(outputStream, outputStream.FramesAheadOfSchedule, "FramesAheadOfSchedule");

            return statistic;
        }

        /// <summary>
        /// Calculates number of published frames reported by the output stream during last reporting interval.
        /// </summary>
        /// <param name="source">Source OutputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Published Frames Statistic.</returns>
        private static double GetOutputStreamStatistic_PublishedFrames(object source, string arguments)
        {
            double statistic = 0.0D;
            PhasorDataConcentratorBase outputStream = source as PhasorDataConcentratorBase;

            if (outputStream != null)
                statistic = s_statisticValueCache.GetDifference(outputStream, outputStream.PublishedFrames, "PublishedFrames");

            return statistic;
        }

        /// <summary>
        /// Calculates boolean value representing if the output stream was continually connected during last reporting interval.
        /// </summary>
        /// <param name="source">Source OutputStream.</param>
        /// <param name="arguments">Any needed arguments for statistic calculation.</param>
        /// <returns>Output Stream Connected Statistic.</returns>
        private static double GetOutputStreamStatistic_Connected(object source, string arguments)
        {
            double statistic = 0.0D;
            PhasorDataConcentratorBase outputStream = source as PhasorDataConcentratorBase;

            if (outputStream != null)
                statistic = (s_statisticValueCache.GetDifference(outputStream, outputStream.ConnectionAttempts, "ConnectionAttempts") == 0.0D ? 1.0D : 0.0D);

            return statistic;
        }

        #endregion

        #endregion
    }
}
