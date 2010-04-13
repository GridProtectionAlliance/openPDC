//*******************************************************************************************************
//  FrequencyExcursion.cs - Gbtc
//
//  Tennessee Valley Authority, 2009
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  This software is made freely available under the TVA Open Source Agreement (see below).
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  09/29/2009 - Jian (Ryan) Zuo
//       Generated original version of source code.
//  10/19/2009 - J. Ritchie Carroll
//       Migrated code to openPDC action adapter type.
//  04/12/2010 - J. Ritchie Carroll
//       Performed full code review, optimization and further abstracted code for excursion detection.
//
//*******************************************************************************************************

#region [ TVA Open Source Agreement ]
/*

 THIS OPEN SOURCE AGREEMENT ("AGREEMENT") DEFINES THE RIGHTS OF USE,REPRODUCTION, DISTRIBUTION,
 MODIFICATION AND REDISTRIBUTION OF CERTAIN COMPUTER SOFTWARE ORIGINALLY RELEASED BY THE
 TENNESSEE VALLEY AUTHORITY, A CORPORATE AGENCY AND INSTRUMENTALITY OF THE UNITED STATES GOVERNMENT
 ("GOVERNMENT AGENCY"). GOVERNMENT AGENCY IS AN INTENDED THIRD-PARTY BENEFICIARY OF ALL SUBSEQUENT
 DISTRIBUTIONS OR REDISTRIBUTIONS OF THE SUBJECT SOFTWARE. ANYONE WHO USES, REPRODUCES, DISTRIBUTES,
 MODIFIES OR REDISTRIBUTES THE SUBJECT SOFTWARE, AS DEFINED HEREIN, OR ANY PART THEREOF, IS, BY THAT
 ACTION, ACCEPTING IN FULL THE RESPONSIBILITIES AND OBLIGATIONS CONTAINED IN THIS AGREEMENT.

 Original Software Designation: openPDC
 Original Software Title: The TVA Open Source Phasor Data Concentrator
 User Registration Requested. Please Visit https://naspi.tva.com/Registration/
 Point of Contact for Original Software: J. Ritchie Carroll <mailto:jrcarrol@tva.gov>

 1. DEFINITIONS

 A. "Contributor" means Government Agency, as the developer of the Original Software, and any entity
 that makes a Modification.

 B. "Covered Patents" mean patent claims licensable by a Contributor that are necessarily infringed by
 the use or sale of its Modification alone or when combined with the Subject Software.

 C. "Display" means the showing of a copy of the Subject Software, either directly or by means of an
 image, or any other device.

 D. "Distribution" means conveyance or transfer of the Subject Software, regardless of means, to
 another.

 E. "Larger Work" means computer software that combines Subject Software, or portions thereof, with
 software separate from the Subject Software that is not governed by the terms of this Agreement.

 F. "Modification" means any alteration of, including addition to or deletion from, the substance or
 structure of either the Original Software or Subject Software, and includes derivative works, as that
 term is defined in the Copyright Statute, 17 USC § 101. However, the act of including Subject Software
 as part of a Larger Work does not in and of itself constitute a Modification.

 G. "Original Software" means the computer software first released under this Agreement by Government
 Agency entitled openPDC, including source code, object code and accompanying documentation, if any.

 H. "Recipient" means anyone who acquires the Subject Software under this Agreement, including all
 Contributors.

 I. "Redistribution" means Distribution of the Subject Software after a Modification has been made.

 J. "Reproduction" means the making of a counterpart, image or copy of the Subject Software.

 K. "Sale" means the exchange of the Subject Software for money or equivalent value.

 L. "Subject Software" means the Original Software, Modifications, or any respective parts thereof.

 M. "Use" means the application or employment of the Subject Software for any purpose.

 2. GRANT OF RIGHTS

 A. Under Non-Patent Rights: Subject to the terms and conditions of this Agreement, each Contributor,
 with respect to its own contribution to the Subject Software, hereby grants to each Recipient a
 non-exclusive, world-wide, royalty-free license to engage in the following activities pertaining to
 the Subject Software:

 1. Use

 2. Distribution

 3. Reproduction

 4. Modification

 5. Redistribution

 6. Display

 B. Under Patent Rights: Subject to the terms and conditions of this Agreement, each Contributor, with
 respect to its own contribution to the Subject Software, hereby grants to each Recipient under Covered
 Patents a non-exclusive, world-wide, royalty-free license to engage in the following activities
 pertaining to the Subject Software:

 1. Use

 2. Distribution

 3. Reproduction

 4. Sale

 5. Offer for Sale

 C. The rights granted under Paragraph B. also apply to the combination of a Contributor's Modification
 and the Subject Software if, at the time the Modification is added by the Contributor, the addition of
 such Modification causes the combination to be covered by the Covered Patents. It does not apply to
 any other combinations that include a Modification. 

 D. The rights granted in Paragraphs A. and B. allow the Recipient to sublicense those same rights.
 Such sublicense must be under the same terms and conditions of this Agreement.

 3. OBLIGATIONS OF RECIPIENT

 A. Distribution or Redistribution of the Subject Software must be made under this Agreement except for
 additions covered under paragraph 3H. 

 1. Whenever a Recipient distributes or redistributes the Subject Software, a copy of this Agreement
 must be included with each copy of the Subject Software; and

 2. If Recipient distributes or redistributes the Subject Software in any form other than source code,
 Recipient must also make the source code freely available, and must provide with each copy of the
 Subject Software information on how to obtain the source code in a reasonable manner on or through a
 medium customarily used for software exchange.

 B. Each Recipient must ensure that the following copyright notice appears prominently in the Subject
 Software:

          No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.

 C. Each Contributor must characterize its alteration of the Subject Software as a Modification and
 must identify itself as the originator of its Modification in a manner that reasonably allows
 subsequent Recipients to identify the originator of the Modification. In fulfillment of these
 requirements, Contributor must include a file (e.g., a change log file) that describes the alterations
 made and the date of the alterations, identifies Contributor as originator of the alterations, and
 consents to characterization of the alterations as a Modification, for example, by including a
 statement that the Modification is derived, directly or indirectly, from Original Software provided by
 Government Agency. Once consent is granted, it may not thereafter be revoked.

 D. A Contributor may add its own copyright notice to the Subject Software. Once a copyright notice has
 been added to the Subject Software, a Recipient may not remove it without the express permission of
 the Contributor who added the notice.

 E. A Recipient may not make any representation in the Subject Software or in any promotional,
 advertising or other material that may be construed as an endorsement by Government Agency or by any
 prior Recipient of any product or service provided by Recipient, or that may seek to obtain commercial
 advantage by the fact of Government Agency's or a prior Recipient's participation in this Agreement.

 F. In an effort to track usage and maintain accurate records of the Subject Software, each Recipient,
 upon receipt of the Subject Software, is requested to register with Government Agency by visiting the
 following website: https://naspi.tva.com/Registration/. Recipient's name and personal information
 shall be used for statistical purposes only. Once a Recipient makes a Modification available, it is
 requested that the Recipient inform Government Agency at the web site provided above how to access the
 Modification.

 G. Each Contributor represents that that its Modification does not violate any existing agreements,
 regulations, statutes or rules, and further that Contributor has sufficient rights to grant the rights
 conveyed by this Agreement.

 H. A Recipient may choose to offer, and to charge a fee for, warranty, support, indemnity and/or
 liability obligations to one or more other Recipients of the Subject Software. A Recipient may do so,
 however, only on its own behalf and not on behalf of Government Agency or any other Recipient. Such a
 Recipient must make it absolutely clear that any such warranty, support, indemnity and/or liability
 obligation is offered by that Recipient alone. Further, such Recipient agrees to indemnify Government
 Agency and every other Recipient for any liability incurred by them as a result of warranty, support,
 indemnity and/or liability offered by such Recipient.

 I. A Recipient may create a Larger Work by combining Subject Software with separate software not
 governed by the terms of this agreement and distribute the Larger Work as a single product. In such
 case, the Recipient must make sure Subject Software, or portions thereof, included in the Larger Work
 is subject to this Agreement.

 J. Notwithstanding any provisions contained herein, Recipient is hereby put on notice that export of
 any goods or technical data from the United States may require some form of export license from the
 U.S. Government. Failure to obtain necessary export licenses may result in criminal liability under
 U.S. laws. Government Agency neither represents that a license shall not be required nor that, if
 required, it shall be issued. Nothing granted herein provides any such export license.

 4. DISCLAIMER OF WARRANTIES AND LIABILITIES; WAIVER AND INDEMNIFICATION

 A. No Warranty: THE SUBJECT SOFTWARE IS PROVIDED "AS IS" WITHOUT ANY WARRANTY OF ANY KIND, EITHER
 EXPRESSED, IMPLIED, OR STATUTORY, INCLUDING, BUT NOT LIMITED TO, ANY WARRANTY THAT THE SUBJECT
 SOFTWARE WILL CONFORM TO SPECIFICATIONS, ANY IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
 PARTICULAR PURPOSE, OR FREEDOM FROM INFRINGEMENT, ANY WARRANTY THAT THE SUBJECT SOFTWARE WILL BE ERROR
 FREE, OR ANY WARRANTY THAT DOCUMENTATION, IF PROVIDED, WILL CONFORM TO THE SUBJECT SOFTWARE. THIS
 AGREEMENT DOES NOT, IN ANY MANNER, CONSTITUTE AN ENDORSEMENT BY GOVERNMENT AGENCY OR ANY PRIOR
 RECIPIENT OF ANY RESULTS, RESULTING DESIGNS, HARDWARE, SOFTWARE PRODUCTS OR ANY OTHER APPLICATIONS
 RESULTING FROM USE OF THE SUBJECT SOFTWARE. FURTHER, GOVERNMENT AGENCY DISCLAIMS ALL WARRANTIES AND
 LIABILITIES REGARDING THIRD-PARTY SOFTWARE, IF PRESENT IN THE ORIGINAL SOFTWARE, AND DISTRIBUTES IT
 "AS IS."

 B. Waiver and Indemnity: RECIPIENT AGREES TO WAIVE ANY AND ALL CLAIMS AGAINST GOVERNMENT AGENCY, ITS
 AGENTS, EMPLOYEES, CONTRACTORS AND SUBCONTRACTORS, AS WELL AS ANY PRIOR RECIPIENT. IF RECIPIENT'S USE
 OF THE SUBJECT SOFTWARE RESULTS IN ANY LIABILITIES, DEMANDS, DAMAGES, EXPENSES OR LOSSES ARISING FROM
 SUCH USE, INCLUDING ANY DAMAGES FROM PRODUCTS BASED ON, OR RESULTING FROM, RECIPIENT'S USE OF THE
 SUBJECT SOFTWARE, RECIPIENT SHALL INDEMNIFY AND HOLD HARMLESS  GOVERNMENT AGENCY, ITS AGENTS,
 EMPLOYEES, CONTRACTORS AND SUBCONTRACTORS, AS WELL AS ANY PRIOR RECIPIENT, TO THE EXTENT PERMITTED BY
 LAW.  THE FOREGOING RELEASE AND INDEMNIFICATION SHALL APPLY EVEN IF THE LIABILITIES, DEMANDS, DAMAGES,
 EXPENSES OR LOSSES ARE CAUSED, OCCASIONED, OR CONTRIBUTED TO BY THE NEGLIGENCE, SOLE OR CONCURRENT, OF
 GOVERNMENT AGENCY OR ANY PRIOR RECIPIENT.  RECIPIENT'S SOLE REMEDY FOR ANY SUCH MATTER SHALL BE THE
 IMMEDIATE, UNILATERAL TERMINATION OF THIS AGREEMENT.

 5. GENERAL TERMS

 A. Termination: This Agreement and the rights granted hereunder will terminate automatically if a
 Recipient fails to comply with these terms and conditions, and fails to cure such noncompliance within
 thirty (30) days of becoming aware of such noncompliance. Upon termination, a Recipient agrees to
 immediately cease use and distribution of the Subject Software. All sublicenses to the Subject
 Software properly granted by the breaching Recipient shall survive any such termination of this
 Agreement.

 B. Severability: If any provision of this Agreement is invalid or unenforceable under applicable law,
 it shall not affect the validity or enforceability of the remainder of the terms of this Agreement.

 C. Applicable Law: This Agreement shall be subject to United States federal law only for all purposes,
 including, but not limited to, determining the validity of this Agreement, the meaning of its
 provisions and the rights, obligations and remedies of the parties.

 D. Entire Understanding: This Agreement constitutes the entire understanding and agreement of the
 parties relating to release of the Subject Software and may not be superseded, modified or amended
 except by further written agreement duly executed by the parties.

 E. Binding Authority: By accepting and using the Subject Software under this Agreement, a Recipient
 affirms its authority to bind the Recipient to all terms and conditions of this Agreement and that
 Recipient hereby agrees to all terms and conditions herein.

 F. Point of Contact: Any Recipient contact with Government Agency is to be directed to the designated
 representative as follows: J. Ritchie Carroll <mailto:jrcarrol@tva.gov>.

*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVA.Measurements;
using TVA.PhasorProtocols;

namespace PowerCalculations.EventDetection
{
    /// <summary>
    /// Defines the type of frequency excursion detected.
    /// </summary>
    public enum ExcursionType
    {
        /// <summary>
        /// Generation based frequency excursion.
        /// </summary>
        GenerationTrip,
        /// <summary>
        /// Load based frequency excursion.
        /// </summary>
        LoadTrip
    }

    /// <summary>
    /// Represents an algorithm that detects frequency excursions.
    /// </summary>
    public class FrequencyExcursion : CalculatedMeasurementBase
    {
        #region [ Members ]

        // Fields
        private double m_estimateTriggerThreshold;  // Threshold for detecting abnormal excursion in frequency
        private int m_analysisWindowSize;           // Analysis Window Size
        private int m_analysisInterval;             // Analysis Interval
        private int m_consecutiveDetections;        // Consecutive detections used to determine if the alarm is true or false
        private double m_powerEstimateRatio;        // Ratio used to calculate the total estimated MW change from frequency 
        private int m_alarmProhibitCounter;         // Counter to prevent duplicated alarms
        private int m_alarmProhibitPeriod;          // Period to prevent duplicated alarms
        private List<double> m_frequencies;         // Frequency measurement values
        private List<DateTime> m_timeStamps;        // Timestamps of frequencies
        private int m_minimumValidChannels;         // Minimum frequency values needed to perform a valid calculation
        private int m_detectedExcursions;           // Number of detected excursions
        private long m_count;                       // Published frame count

        // Important: Make sure output definition defines points in the following order
        private enum Output { WarningSignal, FrequencyDelta, TypeOfExcursion, EstimatedSize }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Returns the detailed status of the <see cref="FrequencyExcursion"/> detector.
        /// </summary>
        public override string Status
        {
            get
            {
                StringBuilder status = new StringBuilder();

                status.AppendFormat("Estimate trigger threshold: {0}", m_estimateTriggerThreshold);
                status.AppendLine();
                status.AppendFormat("      Analysis window size: {0}", m_analysisWindowSize);
                status.AppendLine();
                status.AppendFormat("         Analysis interval: {0}", m_analysisInterval);
                status.AppendLine();
                status.AppendFormat("   Detections before alarm: {0}", m_consecutiveDetections);
                status.AppendLine();
                status.AppendFormat(" Minimum valid frequencies: {0}", m_minimumValidChannels);
                status.AppendLine();
                status.AppendFormat("      Power estimate ratio: {0}MW", m_powerEstimateRatio);
                status.AppendLine();
                status.AppendFormat("    Minimum alarm interval: {0} seconds", (int)(m_alarmProhibitPeriod / FramesPerSecond));
                status.AppendLine();

                status.Append(base.Status);

                return status.ToString();
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Initializes the <see cref="FrequencyExcursion"/> detector.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            Dictionary<string, string> settings = Settings;
            string setting;

            //  <Parameters paraName="EstimateTriggerThreshold" value="0.0256" description="The threshold of estimation trigger"></Parameters>
            //  <Parameters paraName="AnalysisWindowSize" value="120" description="The sample size of the analysis window"></Parameters>
            //  <Parameters paraName="AnalysisInterval" value="30" description="The frame interval between two adjacent frequency testing"></Parameters>
            //  <Parameters paraName="ConsecutiveDetections" value="2" description="Number of needed consecutive detections before positive alarm"></Parameters>
            //  <Parameters paraName="MinimumValidChannel" value="3" description="Minimum valid channel for conduction the frequency testing"></Parameters>
            //  <Parameters paraName="PowerEstimateRatio" value="19530.00" description="The ratio of total amount of generator (load) trip over the frequency excursion"></Parameters>
            //  <Parameters paraName="MinimumAlarmInterval" value="20" description="Minimum duration between alarms, in whole seconds"></Parameters>

            // Load required parameters
            if (settings.TryGetValue("estimateTriggerThreshold", out setting))
                m_estimateTriggerThreshold = double.Parse(setting);
            else
                m_estimateTriggerThreshold = 0.0256D;

            if (settings.TryGetValue("analysisWindowSize", out setting))
                m_analysisWindowSize = int.Parse(setting);
            else
                m_analysisWindowSize = 4 * FramesPerSecond;

            if (settings.TryGetValue("analysisInterval", out setting))
                m_analysisInterval = int.Parse(setting);
            else
                m_analysisInterval = FramesPerSecond;

            if (settings.TryGetValue("consecutiveDetections", out setting))
                m_consecutiveDetections = int.Parse(setting);
            else
                m_consecutiveDetections = 2;

            if (settings.TryGetValue("minimumValidChannels", out setting))
                m_minimumValidChannels = int.Parse(setting);
            else
                m_minimumValidChannels = 3;

            if (settings.TryGetValue("powerEstimateRatio", out setting))
                m_powerEstimateRatio = double.Parse(setting);
            else
                m_powerEstimateRatio = 19530.0D;

            if (settings.TryGetValue("minimumAlarmInterval", out setting))
                m_alarmProhibitPeriod = int.Parse(setting) * FramesPerSecond;
            else
                m_alarmProhibitPeriod = 20 * FramesPerSecond;

            m_frequencies = new List<double>();
            m_timeStamps = new List<DateTime>();

            // Validate input measurements
            List<MeasurementKey> validInputMeasurementKeys = new List<MeasurementKey>();

            for (int i = 0; i < InputMeasurementKeys.Length; i++)
            {
                if (InputMeasurementKeyTypes[i] == SignalType.FREQ)
                    validInputMeasurementKeys.Add(InputMeasurementKeys[i]);
            }

            if (validInputMeasurementKeys.Count == 0)
                throw new InvalidOperationException("No valid frequency measurements were specified as inputs to the frequency excursion detector.");

            if (validInputMeasurementKeys.Count < m_minimumValidChannels)
                throw new InvalidOperationException(string.Format("Minimum valid frequency measurements (i.e., \"minimumValidChannels\") for the frequency excursion detector is currently set to {0}, only {1} {2} defined.", m_minimumValidChannels, validInputMeasurementKeys.Count, (validInputMeasurementKeys.Count == 1 ? "was" : "were")));

            // Make sure only frequencies are used as input
            InputMeasurementKeys = validInputMeasurementKeys.ToArray();

            // Validate output measurements
            if (OutputMeasurements.Length < Enum.GetValues(typeof(Output)).Length)
                throw new InvalidOperationException("Not enough output measurements were specified for the frequency excursion detector, expecting measurements for \"Warning Signal Status (0 = Not Signaled, 1 = Signaled)\", \"Frequency Delta\", \"Type of Excursion (0 = Gen Trip, 1 = Load Trip)\" and \"Estimated Size (MW)\" - in this order.");
        }

        /// <summary>
        /// Publishes the <see cref="IFrame"/> of time-aligned collection of <see cref="IMeasurement"/> values that arrived within the
        /// adapter's defined <see cref="ConcentratorBase.LagTime"/>.
        /// </summary>
        /// <param name="frame"><see cref="IFrame"/> of measurements with the same timestamp that arrived within <see cref="ConcentratorBase.LagTime"/> that are ready for processing.</param>
        /// <param name="index">Index of <see cref="IFrame"/> within a second ranging from zero to <c><see cref="ConcentratorBase.FramesPerSecond"/> - 1</c>.</param>
        protected override void PublishFrame(IFrame frame, int index)
        {
            MeasurementKey[] inputMeasurements = InputMeasurementKeys;
            double averageFrequency = double.NaN;

            // Increment frame counter
            m_count++;

            if (m_alarmProhibitCounter > 0)
                m_alarmProhibitCounter--;

            // Calculate the average of all the frequencies that arrived in this frame
            if (frame.Measurements.Count > 0)
                averageFrequency = frame.Measurements.Select(m => m.Value.AdjustedValue).Average();

            // Track new frequency and its timestamp
            m_frequencies.Add(averageFrequency);
            m_timeStamps.Add(frame.Timestamp);

            // Maintain analysis window size
            while (m_frequencies.Count > m_analysisWindowSize)
            {
                m_frequencies.RemoveAt(0);
                m_timeStamps.RemoveAt(0);
            }

            if (m_count % m_analysisInterval == 0 && m_frequencies.Count == m_analysisWindowSize)
            {
                double frequency1 = m_frequencies[0];
                double frequency2 = m_frequencies[m_analysisWindowSize - 1];
                double frequencyDelta = 0.0D, estimatedSize = 0.0D;
                ExcursionType typeofExcursion = ExcursionType.GenerationTrip;
                bool warningSignaled = false;

                if (!double.IsNaN(frequency1) && !double.IsNaN(frequency2))
                {
                    frequencyDelta = frequency1 - frequency2;

                    if (Math.Abs(frequencyDelta) > m_estimateTriggerThreshold)
                        m_detectedExcursions++;
                    else
                        m_detectedExcursions = 0;

                    if (m_detectedExcursions >= m_consecutiveDetections)
                    {
                        typeofExcursion = (frequency1 > frequency2 ? ExcursionType.GenerationTrip : ExcursionType.LoadTrip);
                        estimatedSize = Math.Abs(frequencyDelta) * m_powerEstimateRatio;

                        // Display frequency excursion detection warning
                        if (m_alarmProhibitCounter == 0)
                        {
                            OutputFrequencyWarning(m_timeStamps[0], frequencyDelta, typeofExcursion, estimatedSize);
                            m_alarmProhibitCounter = m_alarmProhibitPeriod;
                        }

                        warningSignaled = true;
                    }
                }

                // Expose output measurement values
                IMeasurement[] outputMeasurements = OutputMeasurements;

                OnNewMeasurements(new IMeasurement[]
                { 
                    Measurement.Clone(outputMeasurements[(int)Output.WarningSignal], warningSignaled ? 1.0D : 0.0D, frame.Timestamp),
                    Measurement.Clone(outputMeasurements[(int)Output.FrequencyDelta], frequencyDelta, frame.Timestamp),
                    Measurement.Clone(outputMeasurements[(int)Output.TypeOfExcursion], (int)typeofExcursion, frame.Timestamp),
                    Measurement.Clone(outputMeasurements[(int)Output.EstimatedSize], estimatedSize, frame.Timestamp)
                });
            }
        }

        private void OutputFrequencyWarning(DateTime timestamp, double delta, ExcursionType typeOfExcursion, double totalAmount)
        {
            OnStatusMessage("WARNING: Frequency excursion detected!\r\n              Time = {0}\r\n             Delta = {1}\r\n              Type = {2}\r\n    Estimated Size = {3}MW\r\n", timestamp.ToString("dd-MMM-yyyy HH:mm:ss.fff"), delta, typeOfExcursion, totalAmount.ToString("0.00"));
        }

        #endregion
    }
}