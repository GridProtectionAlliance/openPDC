//******************************************************************************************************
//  SequenceCalculator.cs - Gbtc
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
//  05/16/2012 - J. Ritchie Carroll
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TimeSeriesFramework;
using TimeSeriesFramework.Adapters;
using TVA;
using TVA.Collections;
using TVA.PhasorProtocols;

namespace PowerCalculations
{
    /// <summary>
    /// Calculates positive, negative and zero sequences using A, B and C phase voltage or current magnitude and angle signals input to the adapter.
    /// </summary>
    [Description("Sequence Calculator: positive, negative and zero sequences for synchrophasor measurements")]
    public class SequenceCalculator : CalculatedMeasurementBase
    {
        #region [ Members ]

        // Constants
        private const double SqrtOf3 = 1.7320508075688772935274463415059D;

        // Fields
        private MeasurementKey[] m_angles;
        private MeasurementKey[] m_magnitudes;
        private bool m_trackRecentValues;
        private int m_sampleSize;
        private string m_magnitudeUnits;
        private List<double> m_positiveSequenceSample;
        private List<double> m_negativeSequenceSample;
        private List<double> m_zeroSequenceSample;
        private List<double> m_sequenceMagnitudeSample;

        // Important: Make sure output definition defines points in the following order
        private enum Output
        {
            PositiveSequence,
            NegativeSequence,
            ZeroSequence,
            SequenceMagnitude
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets flag that determines if the last few values should be monitored.
        /// </summary>
        [ConnectionStringParameter,
        Description("Flag that determines if the last few values should be monitored."),
        DefaultValue(true)]
        public bool TrackRecentValues
        {
            get
            {
                return m_trackRecentValues;
            }
            set
            {
                m_trackRecentValues = value;
            }
        }

        /// <summary>
        /// Gets or sets the sample size of the data to be monitored.
        /// </summary>
        [ConnectionStringParameter,
        Description("Define the sample size of the data to be monitored."),
        DefaultValue(5)]
        public int SampleSize
        {
            get
            {
                return m_sampleSize;
            }
            set
            {
                m_sampleSize = value;
            }
        }

        /// <summary>
        /// Gets the flag indicating if this adapter supports temporal processing.
        /// </summary>
        public override bool SupportsTemporalProcessing
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Returns the detailed status of the <see cref="PowerCalculator"/>.
        /// </summary>
        public override string Status
        {
            get
            {
                const int ValuesToShow = 3;

                StringBuilder status = new StringBuilder();

                if (m_trackRecentValues)
                {
                    status.Append("   Last positive sequences: ");

                    lock (m_positiveSequenceSample)
                    {
                        // Display last several values
                        if (m_positiveSequenceSample.Count > ValuesToShow)
                            status.Append(m_positiveSequenceSample.GetRange(m_positiveSequenceSample.Count - ValuesToShow - 1, ValuesToShow).Select(v => v.ToString("0.00°")).ToDelimitedString(", "));
                        else
                            status.Append("Not enough values calculated yet...");
                    }
                    status.AppendLine();

                    status.Append("   Last negative sequences: ");

                    lock (m_negativeSequenceSample)
                    {
                        // Display last several values
                        if (m_negativeSequenceSample.Count > ValuesToShow)
                            status.Append(m_negativeSequenceSample.GetRange(m_negativeSequenceSample.Count - ValuesToShow - 1, ValuesToShow).Select(v => v.ToString("0.00°")).ToDelimitedString(", "));
                        else
                            status.Append("Not enough values calculated yet...");
                    }
                    status.AppendLine();

                    status.Append("       Last zero sequences: ");

                    lock (m_zeroSequenceSample)
                    {
                        // Display last several values
                        if (m_zeroSequenceSample.Count > ValuesToShow)
                            status.Append(m_zeroSequenceSample.GetRange(m_zeroSequenceSample.Count - ValuesToShow - 1, ValuesToShow).Select(v => v.ToString("0.00°")).ToDelimitedString(", "));
                        else
                            status.Append("Not enough values calculated yet...");
                    }
                    status.AppendLine();

                    status.Append("  Last sequence magnitudes: ");

                    lock (m_sequenceMagnitudeSample)
                    {
                        // Display last several values
                        if (m_sequenceMagnitudeSample.Count > ValuesToShow)
                            status.Append(m_sequenceMagnitudeSample.GetRange(m_sequenceMagnitudeSample.Count - ValuesToShow - 1, ValuesToShow).Select(v => v.ToString("0.00 ") + m_magnitudeUnits).ToDelimitedString(", "));
                        else
                            status.Append("Not enough values calculated yet...");
                    }
                    status.AppendLine();
                }

                status.Append(base.Status);

                return status.ToString();
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Initializes the <see cref="PowerCalculator"/>.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            Dictionary<string, string> settings = Settings;
            string setting;

            // Load parameters
            if (settings.TryGetValue("trackRecentValues", out setting))
                m_trackRecentValues = setting.ParseBoolean();
            else
                m_trackRecentValues = true;

            if (settings.TryGetValue("sampleSize", out setting))            // Data sample size to monitor, in seconds
                m_sampleSize = int.Parse(setting);
            else
                m_sampleSize = 5;

            // Load needed phase angle measurement keys from defined InputMeasurementKeys
            m_angles = InputMeasurementKeys.Where((key, index) => InputMeasurementKeyTypes[index] == SignalType.VPHA).ToArray();

            if (m_angles.Length == 0)
            {
                // No voltage angles existed, check for current angles
                m_angles = InputMeasurementKeys.Where((key, index) => InputMeasurementKeyTypes[index] == SignalType.IPHA).ToArray();
            }
            else
            {
                // Make only only one kind of angles are defined - not a mixture of voltage and currents
                if (InputMeasurementKeys.Where((key, index) => InputMeasurementKeyTypes[index] == SignalType.IPHA).Any())
                    throw new InvalidOperationException("Angle input measurements for a single sequence calculator instance should only be for voltages or currents - not both.");
            }

            // Load needed phase magnitude measurement keys from defined InputMeasurementKeys
            m_magnitudes = InputMeasurementKeys.Where((key, index) => InputMeasurementKeyTypes[index] == SignalType.VPHM).ToArray();

            if (m_magnitudes.Length == 0)
            {
                // No voltage magnitudes existed, check for current magnitudes
                m_magnitudes = InputMeasurementKeys.Where((key, index) => InputMeasurementKeyTypes[index] == SignalType.IPHM).ToArray();
                m_magnitudeUnits = "amps";
            }
            else
            {
                // Make only only one kind of magnitudes are defined - not a mixture of voltage and currents
                if (InputMeasurementKeys.Where((key, index) => InputMeasurementKeyTypes[index] == SignalType.IPHM).Any())
                    throw new InvalidOperationException("Magnitude input measurements for a single sequence calculator instance should only be for voltages or currents - not both.");

                m_magnitudeUnits = "volts";
            }

            if (m_angles.Length < 3)
                throw new InvalidOperationException("Three angle input measurements, i.e., A, B and C - in that order, are required for the sequence calculator.");

            if (m_magnitudes.Length < 3)
                throw new InvalidOperationException("Three magnitude input measurements, i.e., A, B and C - in that order, are required for the sequence calculator.");

            if (m_angles.Length != m_magnitudes.Length)
                throw new InvalidOperationException("A different number of magnitude and angle input measurement keys were supplied - the angles and magnitudes must be supplied in pairs in A, B, C sequence, i.e., one magnitude input measurement must be supplied for each angle input measurement in a consecutive sequence (e.g., A1;M1;  A2;M2; ... An;Mn)");

            // Make sure only these phasor measurements are used as input
            InputMeasurementKeys = m_angles.Concat(m_magnitudes).ToArray();

            // Validate output measurements
            if (OutputMeasurements.Length < Enum.GetValues(typeof(Output)).Length)
                throw new InvalidOperationException("Not enough output measurements were specified for the sequence calculator, expecting measurements for the \"Positive Sequence\", \"Negative Sequence\", \"Zero Sequence\" and the \"Common Sequence Magnitude\" - in this order.");

            if (m_trackRecentValues)
            {
                m_positiveSequenceSample = new List<double>();
                m_negativeSequenceSample = new List<double>();
                m_zeroSequenceSample = new List<double>();
                m_sequenceMagnitudeSample = new List<double>();
            }

            // Assign a default adapter name to be used if sequence calculator is loaded as part of automated collection
            Name = string.Format("SC!{0}", OutputMeasurements[(int)Output.PositiveSequence].Key);
        }

        /// <summary>
        /// Publish frame of time-aligned collection of measurement values that arrived within the defined lag time.
        /// </summary>
        /// <param name="frame">Frame of measurements with the same timestamp that arrived within lag time that are ready for processing.</param>
        /// <param name="index">Index of frame within a second ranging from zero to frames per second - 1.</param>
        protected override void PublishFrame(IFrame frame, int index)
        {
            double positiveSequence = double.NaN, negativeSequence = double.NaN, zeroSequence = double.NaN, sequenceMagnitude = double.NaN;

            try
            {
                ConcurrentDictionary<MeasurementKey, IMeasurement> measurements = frame.Measurements;
                double mA = 0.0D, aA = 0.0D, mB = 0.0D, aB = 0.0D, mC = 0.0D, aC = 0.0D;
                IMeasurement measurement;
                bool allValuesReceived = false;

                // Get all needed measurement value from this frame
                if (measurements.TryGetValue(m_magnitudes[0], out measurement) && measurement.ValueQualityIsGood())
                {
                    // Get A-phase magnitude value
                    mA = measurement.AdjustedValue;

                    if (measurements.TryGetValue(m_angles[0], out measurement) && measurement.ValueQualityIsGood())
                    {
                        // Get A-phase angle value
                        aA = measurement.AdjustedValue;

                        if (measurements.TryGetValue(m_magnitudes[1], out measurement) && measurement.ValueQualityIsGood())
                        {
                            // Get B-phase magnitude value
                            mB = measurement.AdjustedValue;

                            if (measurements.TryGetValue(m_angles[1], out measurement) && measurement.ValueQualityIsGood())
                            {
                                // Get B-phase angle value
                                aB = measurement.AdjustedValue;

                                if (measurements.TryGetValue(m_magnitudes[2], out measurement) && measurement.ValueQualityIsGood())
                                {
                                    // Get C-phase magnitude value
                                    mC = measurement.AdjustedValue;

                                    if (measurements.TryGetValue(m_angles[2], out measurement) && measurement.ValueQualityIsGood())
                                    {
                                        // Get C-phase angle value
                                        aC = measurement.AdjustedValue;

                                        allValuesReceived = true;
                                    }
                                }
                            }
                        }
                    }
                }


                if (allValuesReceived)
                {
                    const double a = 120.0D;
                    const double a2 = 240.0D;

                    // Calculate the sequence magnitude (this will be same for all sequences)
                    sequenceMagnitude = (mA + mB + mC) / 3.0D;

                    // Calculate zero sequence value (basically an average)
                    zeroSequence = (aA + aB + aC) / 3.0D;

                    if (zeroSequence > 180)
                        zeroSequence = 360 - zeroSequence;

                    // Calculate positive sequence value
                    positiveSequence = (aA + (a + aB) + (a2 + aC)) / 3.0D;

                    if (positiveSequence > 180)
                        positiveSequence = 360 - positiveSequence;

                    // Calculate negative sequence value
                    negativeSequence = (aA + (a2 + aB) + (a + aC)) / 3.0D;

                    if (negativeSequence > 180)
                        negativeSequence = 360 - negativeSequence;

                    if (m_trackRecentValues)
                    {
                        // Add latest positive sequence to data sample
                        lock (m_positiveSequenceSample)
                        {
                            m_positiveSequenceSample.Add(positiveSequence);

                            // Maintain sample size
                            while (m_positiveSequenceSample.Count > m_sampleSize)
                                m_positiveSequenceSample.RemoveAt(0);
                        }

                        // Add latest negative sequence to data sample
                        lock (m_negativeSequenceSample)
                        {
                            m_negativeSequenceSample.Add(negativeSequence);

                            // Maintain sample size
                            while (m_negativeSequenceSample.Count > m_sampleSize)
                                m_negativeSequenceSample.RemoveAt(0);
                        }

                        // Add latest zero sequence to data sample
                        lock (m_zeroSequenceSample)
                        {
                            m_zeroSequenceSample.Add(zeroSequence);

                            // Maintain sample size
                            while (m_zeroSequenceSample.Count > m_sampleSize)
                                m_zeroSequenceSample.RemoveAt(0);
                        }

                        // Add latest sequence magnitude to data sample
                        lock (m_sequenceMagnitudeSample)
                        {
                            m_sequenceMagnitudeSample.Add(sequenceMagnitude);

                            // Maintain sample size
                            while (m_sequenceMagnitudeSample.Count > m_sampleSize)
                                m_sequenceMagnitudeSample.RemoveAt(0);
                        }
                    }
                }
            }
            finally
            {
                IMeasurement[] outputMeasurements = OutputMeasurements;

                Measurement positiveSequenceMeasurement = Measurement.Clone(outputMeasurements[(int)Output.PositiveSequence], positiveSequence, frame.Timestamp);
                Measurement negativeSequenceMeasurement = Measurement.Clone(outputMeasurements[(int)Output.NegativeSequence], negativeSequence, frame.Timestamp);
                Measurement zeroSequenceMeasurement = Measurement.Clone(outputMeasurements[(int)Output.ZeroSequence], zeroSequence, frame.Timestamp);
                Measurement sequenceMagnitudeMeasurement = Measurement.Clone(outputMeasurements[(int)Output.SequenceMagnitude], sequenceMagnitude, frame.Timestamp);

                // Provide calculated measurements for external consumption
                OnNewMeasurements(new IMeasurement[] { positiveSequenceMeasurement, negativeSequenceMeasurement, zeroSequenceMeasurement, sequenceMagnitudeMeasurement });
            }
        }

        #endregion
    }
}