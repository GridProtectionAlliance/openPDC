//******************************************************************************************************
//  FileExporter.cs - Gbtc
//
//  Copyright © 2012, Grid Protection Alliance.  All Rights Reserved.
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
//  05/03/2012 - J. Ritchie Carroll
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using TimeSeriesFramework;
using TimeSeriesFramework.Adapters;
using TVA;
using TVA.Collections;
using TVA.IO;
using TVA.PhasorProtocols;

namespace EpriExport
{
    /// <summary>
    /// Represents an action adapter that exports measurements on an interval to a file that can be picked up by EPRI applications.
    /// </summary>
    [Description("EPRI: exports measurements to a file that can be used by EPRI systems")]
    public class FileExporter : CalculatedMeasurementBase
    {
        #region [ Members ]


        // Constants
        private const double SqrtOf3 = 1.7320508075688772935274463415059D;

        // Fields
        private string m_fileExportPath;
        private string m_header;
        private MeasurementKey m_referenceAngleKey;
        private bool m_useReferenceAngle;
        private int m_exportInterval;
        private bool m_statusDisplayed;
        private long m_skippedExports;
        private StringBuilder m_fileData;
        private Ticks m_startTime;
        private long m_totalExports;

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets the file export path for the EPRI export.
        /// </summary>
        [ConnectionStringParameter,
        Description("Define the file export path for the EPRI export.")]
        public string FileExportPath
        {
            get
            {
                return m_fileExportPath;
            }
            set
            {
                m_fileExportPath = value;
            }
        }

        /// <summary>
        /// Gets or sets the interval, in seconds, at which data will be queued for concentration and then exported.
        /// </summary>
        [ConnectionStringParameter,
        Description("Define the interval, in seconds, at which data will be queued for concentration and then exported.")]
        public double ExportInterval
        {
            get
            {
                return m_exportInterval / 1000.0D;
            }
            set
            {
                m_exportInterval = (int)(value * 1000.0D);
            }
        }

        /// <summary>
        /// Gets or sets a value that determines whether a reference angle is used to adjust the value of phase angles.
        /// </summary>
        [ConnectionStringParameter,
        Description("Indicates whether a reference angle is used to adjust the value of phase angles. IMPORTANT: If this is true, ReferenceAngleMeasurement is a required parameter.")]
        public bool UseReferenceAngle
        {
            get
            {
                return m_useReferenceAngle;
            }
            set
            {
                m_useReferenceAngle = value;
            }
        }

        /// <summary>
        /// Gets or sets the key of the measurement used to adjust the value of phase angles.
        /// </summary>
        [ConnectionStringParameter,
        Description("Define the key of the measurement used to adjust the value of phase angles."),
        DefaultValue("")]
        public string ReferenceAngleMeasurement
        {
            get
            {
                return m_referenceAngleKey.ToString();
            }
            set
            {
                m_referenceAngleKey = MeasurementKey.Parse(value);
            }
        }

        /// <summary>
        /// Returns the detailed status of the <see cref="FileExporter"/>.
        /// </summary>
        public override string Status
        {
            get
            {
                StringBuilder status = new StringBuilder();

                status.AppendFormat("     Using reference angle: {0}", m_useReferenceAngle);
                status.AppendLine();
                status.AppendFormat("           Skipped exports: {0}", m_skippedExports);
                status.AppendLine();
                status.AppendFormat("          File export path: {0}", m_fileExportPath);
                status.AppendLine();

                if (m_useReferenceAngle)
                {
                    status.AppendFormat("     Reference angle point: {0}", m_referenceAngleKey.ToString());
                    status.AppendLine();
                }

                status.Append(base.Status);

                return status.ToString();
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Intializes <see cref="FileExporter"/>.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            Dictionary<string, string> settings = Settings;
            string errorMessage = "{0} is missing from Settings - Example: exportInterval=5; useReferenceAngle=True; referenceAngleMeasurement=DEVARCHIVE:6; companyTagPrefix=TVA; useNumericQuality=True; inputMeasurementKeys={{FILTER ActiveMeasurements WHERE Device='SHELBY' AND SignalType='FREQ'}}";
            string setting;
            double seconds;

            // Load required parameters
            if (!settings.TryGetValue("exportInterval", out setting) || !double.TryParse(setting, out seconds))
                throw new ArgumentException(string.Format(errorMessage, "exportInterval"));

            if (!settings.TryGetValue("fileExportPath", out m_fileExportPath))
                m_fileExportPath = FilePath.GetAbsolutePath("");

            m_exportInterval = (int)(seconds * 1000.0D);

            if (m_exportInterval <= 0)
                throw new ArgumentException("exportInterval should not be 0 - Example: exportInterval=5.5");

            if (InputMeasurementKeys == null || InputMeasurementKeys.Length == 0)
                throw new InvalidOperationException("There are no input measurements defined. You must define \"inputMeasurementKeys\" to define which measurements to export.");

            if (!settings.TryGetValue("useReferenceAngle", out setting))
                setting = "false";

            m_useReferenceAngle = setting.ParseBoolean();

            if (m_useReferenceAngle)
            {
                // Reference angle measurement has to be defined if using reference angle
                if (!settings.TryGetValue("referenceAngleMeasurement", out setting))
                    throw new ArgumentException(string.Format(errorMessage, "referenceAngleMeasurement"));

                m_referenceAngleKey = MeasurementKey.Parse(setting);

                // Make sure reference angle is part of input measurement keys collection
                if (!InputMeasurementKeys.Contains(m_referenceAngleKey))
                    InputMeasurementKeys = InputMeasurementKeys.Concat(new MeasurementKey[] { m_referenceAngleKey }).ToArray();

                // Make sure sure reference angle key is actually an angle measurement
                SignalType signalType = InputMeasurementKeyTypes[InputMeasurementKeys.IndexOf(key => key == m_referenceAngleKey)];

                if (signalType != SignalType.IPHA && signalType != SignalType.VPHA)
                    throw new InvalidOperationException(string.Format("Specified reference angle measurement key is a {0} signal, not a phase angle.", signalType.GetFormattedSignalTypeName()));
            }

            // We enable tracking of latest measurements so we can use these values if points are missing - since we are using
            // latest measurement tracking, we sort all incoming points even though most of them will be thrown out...
            TrackLatestMeasurements = true;

            StringBuilder header = new StringBuilder();

            header.Append("t");

            // Write header row
            int angleIndex = 1;
            int voltageIndex = 1;
            int pIndex = 1;
            int qIndex = 1;
            int count = 0;

            for (int i = 0; i < InputMeasurementKeys.Length; i++)
            {
                switch (InputMeasurementKeyTypes[i])
                {
                    case SignalType.VPHM:
                        header.AppendFormat(",V{0}", voltageIndex++);
                        count++;
                        break;
                    case SignalType.VPHA:
                        header.AppendFormat(",A{0}", angleIndex++);
                        count++;
                        break;
                    case SignalType.CALC:
                        // Lookup measurement key in active measurements table
                        DataRow row = DataSource.Tables["ActiveMeasurements"].Select(string.Format("ID='{0}'", InputMeasurementKeys[i].ToString()))[0];

                        // Remove invalid symbols that may be in tag name
                        string tagName = row["PointTag"].ToNonNullString("NA").ToUpper();

                        if (tagName.StartsWith("P"))
                            header.AppendFormat(",P{0}", pIndex++);
                        else if (tagName.StartsWith("Q"))
                            header.AppendFormat(",Q{0}", qIndex++);
                        count++;
                        break;
                }
            }

            string row3 = header.ToString();
            header = new StringBuilder();

            // Add row 1
            header.Append("Data Points,Tie lines,Time step");

            if (count - 4 > 0)
                header.Append(new string(',', count - 4));

            header.AppendLine();

            // Add row 2
            header.AppendFormat("{0},{1},{2}", m_exportInterval * 30, voltageIndex, 1 / 30.0D);
            header.AppendLine();

            // Add row 3
            header.AppendLine(row3);

            // Cache header for each file export
            m_header = header.ToString();
        }

        /// <summary>
        /// Process frame of time-aligned measurements that arrived within the defined lag time.
        /// </summary>
        /// <param name="frame"><see cref="IFrame"/> of measurements that arrived within lag time and are ready for processing.</param>
        /// <param name="index">Index of <see cref="IFrame"/> within one second of data ranging from zero to frames per second - 1.</param>
        protected override void PublishFrame(IFrame frame, int index)
        {
            Ticks timestamp = frame.Timestamp;
            IMeasurement measurement, referenceAngle;
            MeasurementKey inputMeasurementKey;
            SignalType signalType;
            double measurementValue, referenceAngleValue;
            bool displayedWarning = false;

            ConcurrentDictionary<MeasurementKey, IMeasurement> measurements = frame.Measurements;

            if (measurements.Count > 0)
            {
                if (m_fileData == null)
                {
                    m_startTime = frame.Timestamp;
                    m_fileData = new StringBuilder();
                }

                // We need to get calculated reference angle value in order to export relative phase angles
                // If the value is not here, we don't export
                referenceAngle = null;

                // Make sure reference made it in this frame...
                if (m_useReferenceAngle && !measurements.TryGetValue(m_referenceAngleKey, out referenceAngle))
                {
                    OnProcessException(new InvalidOperationException("Calculated reference angle was not found in this frame, possible reasons: system is initializing, receiving no data or lag time is too small. File creation was skipped."));
                }
                else
                {
                    m_fileData.AppendFormat("{0}", (timestamp - m_startTime).ToSeconds());

                    // Export all defined input measurements
                    for (int i = 0; i < InputMeasurementKeys.Length; i++)
                    {
                        m_fileData.Append(',');
                        inputMeasurementKey = InputMeasurementKeys[i];
                        signalType = InputMeasurementKeyTypes[i];

                        // See if measurement exists in this frame
                        if (measurements.TryGetValue(inputMeasurementKey, out measurement))
                        {
                            // Get measurement's adjusted value (takes into account any adder and or multipler)
                            measurementValue = measurement.AdjustedValue;
                        }
                        else
                        {
                            // Didn't find measurement in this frame, try using a recent value
                            measurementValue = LatestMeasurements[inputMeasurementKey.SignalID];
                        }

                        // Export measurement value making any needed adjustments based on signal type
                        if (signalType == SignalType.VPHA)
                        {
                            // This is a phase angle measurement, export the value relative to the reference angle (if available)
                            if (referenceAngle != null)
                            {
                                // Get reference angle's adjusted value (takes into account any adder and or multipler)
                                referenceAngleValue = referenceAngle.AdjustedValue;

                                // Handle relative angle wrapping
                                double dis0 = Math.Abs(measurementValue - referenceAngleValue);
                                double dis1 = Math.Abs(measurementValue - referenceAngleValue + 360);
                                double dis2 = Math.Abs(measurementValue - referenceAngleValue - 360);

                                if ((dis0 < dis1) && (dis0 < dis2))
                                    measurementValue = measurementValue - referenceAngleValue;
                                else if (dis1 < dis2)
                                    measurementValue = measurementValue - referenceAngleValue + 360;
                                else
                                    measurementValue = measurementValue - referenceAngleValue - 360;
                            }

                            // No reference angle defined, export raw angle
                            m_fileData.Append(measurementValue);
                        }
                        else if (signalType == SignalType.VPHM)
                        {
                            // Typical voltages from PMU's are line-to-neutral volts so we convert them to line-to-line kilovolts
                            m_fileData.Append(measurementValue * SqrtOf3 / 1000.0D);
                        }
                        else
                        {
                            // Export all other types of measurements as their raw value
                            m_fileData.Append(measurementValue / 100.0D);
                        }
                    }

                    // Terminate line
                    m_fileData.AppendLine();
                }

            }

            // Only publish when the export interval time has passed
            if ((timestamp - m_startTime).ToMilliseconds() > m_exportInterval)
            {
                // Queue up measurement export to data exporter - this will only allow one export at a time
                try
                {
                    string fileName = Path.Combine(FilePath.GetAbsolutePath(m_fileExportPath), "EPRI-VS-Input-" + m_startTime.ToString("yyyyMMddHHmmss") + ".csv");

                    using (StreamWriter writer = new StreamWriter(fileName))
                    {
                        writer.Write(m_header);
                        writer.Write(m_fileData.ToString());
                    }

                    m_totalExports++;
                }
                catch (ThreadAbortException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    m_skippedExports++;
                    OnStatusMessage("WARNING: Skipped export due to exception: " + ex.Message);
                    displayedWarning = true;
                }
                finally
                {
                    // Reset file data
                    m_fileData = null;
                }

                // We display export status every other minute
                if (new DateTime(timestamp).Minute % 2 == 0 && !displayedWarning)
                {
                    //Make sure message is only displayed once during the minute
                    if (!m_statusDisplayed)
                    {
                        OnStatusMessage("{0} successful file based measurement exports...", m_totalExports);
                        m_statusDisplayed = true;
                    }
                }
                else
                {
                    m_statusDisplayed = false;
                }
            }
        }

        #endregion
    }
}
