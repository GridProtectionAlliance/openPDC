//*******************************************************************************************************
//  PowerStability.cs - Gbtc
//  
//  Calculate the Power Deviation from Cumberland. The VB.net version is developed by James. Ritchie Carroll
//  Tennessee Valley Authority, 2009
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  This software is made freely available under the TVA Open Source Agreement (see below).
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  11/08/2006 - J. Ritchie Carroll
//      Initial version of source generated
//  05/27/2008 - J. Ritchie Carroll
//       Added Montgomery line to power calculation
//  12/22/2009 - Jian R. Zuo
//       Conveted code to C#;
//  04/12/2010 - J. Ritchie Carroll
//       Performed full code review, optimization and further abstracted code for stability calculator.
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
using TVA;
using TVA.Collections;
using TimeSeriesFramework;
using TimeSeriesFramework.Adapters;
using TVA.NumericalAnalysis;
using TVA.PhasorProtocols;
using TVA.Units;

namespace PowerCalculations
{
    /// <summary>
    /// Represents an algorithm that calculates power and stability from a synchrophasor device.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This algorithm calculates power and its standard deviation in real-time that can be used to
    /// determine if there is an oscillatory signature in the power output.
    /// </para>
    /// <para>
    /// If multiple voltage phasors are provided as inputs to this algorithm, then they are assumed to be
    /// redundant values on the same bus, the first energized value will be the voltage phasor that is
    /// used in the calculation.<br/>
    /// If multiple current phasors are provided as inputs to this algorithm, then they are assumed to be
    /// cumulative inputs representing the desired power output summation of the generation source.
    /// </para>
    /// <para>
    /// Individual phase angle and magnitude phasor elements are expected to be defined consecutively.
    /// That is the definition order of angles and magnitudes must match so that the angle / magnitude
    /// pair can be matched up appropriately. For example: angle1;mag1;  angle2;mag2;  angle3;mag3.
    /// </para>
    /// </remarks>
    public class PowerStability : CalculatedMeasurementBase
    {
        #region [ Members ]

        // Fields
        private int m_minimumSamples;
        private double m_energizedThreshold;
        private List<double> m_powerDataSample;
        private double m_lastStdev;
        private MeasurementKey[] m_voltageAngles;
        private MeasurementKey[] m_voltageMagnitudes;
        private MeasurementKey[] m_currentAngles;
        private MeasurementKey[] m_currentMagnitudes;

        // Important: Make sure output definition defines points in the following order
        private enum Output { Power, StDev }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Returns the detailed status of the <see cref="PowerStability"/> monitor.
        /// </summary>
        public override string Status
        {
            get
            {
                const int ValuesToShow = 3;
                
                StringBuilder status = new StringBuilder();

                status.AppendFormat("          Data sample size: {0} seconds", (int)(m_minimumSamples / FramesPerSecond));
                status.AppendLine();
                status.AppendFormat("   Energized bus threshold: {0} volts", m_energizedThreshold.ToString("0.00"));
                status.AppendLine();
                status.AppendFormat("     Total voltage phasors: {0}", m_voltageMagnitudes.Length);
                status.AppendLine();
                status.AppendFormat("     Total current phasors: {0}", m_currentMagnitudes.Length);
                status.AppendLine();
                status.Append("         Last power values: ");
                
                lock (m_powerDataSample)
                {
                    // Display last several values
                    if (m_powerDataSample.Count > ValuesToShow)
                        status.Append(m_powerDataSample.GetRange(m_powerDataSample.Count - ValuesToShow - 1, ValuesToShow).Select(v => v.ToString("0.00MW")).ToDelimitedString(", "));
                    else
                        status.Append("Not enough values calculated yet...");
                }

                status.AppendLine();
                status.AppendFormat("     Latest stdev of power: {0}", m_lastStdev);
                status.AppendLine();
                status.Append(base.Status);

                return status.ToString();
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Initializes the <see cref="PowerStability"/> monitor.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            Dictionary<string, string> settings = Settings;
            string setting;

            // Load parameters
            if (settings.TryGetValue("sampleSize", out setting))            // Data sample size to monitor, in seconds
                m_minimumSamples = int.Parse(setting) * FramesPerSecond;
            else
                m_minimumSamples = 15 * FramesPerSecond;

            if (settings.TryGetValue("energizedThreshold", out setting))    // Energized bus threshold, in volts, recommended value
                m_energizedThreshold = double.Parse(setting);               // is 20% of nominal line-to-neutral voltage
            else
                m_energizedThreshold = 58000.0D;

            // Load needed phase angle and magnitude measurement keys from defined InputMeasurementKeys
            m_voltageAngles = InputMeasurementKeys.Where((key, index) => InputMeasurementKeyTypes[index] == SignalType.VPHA).ToArray();
            m_voltageMagnitudes = InputMeasurementKeys.Where((key, index) => InputMeasurementKeyTypes[index] == SignalType.VPHM).ToArray();
            m_currentAngles = InputMeasurementKeys.Where((key, index) => InputMeasurementKeyTypes[index] == SignalType.IPHA).ToArray();
            m_currentMagnitudes = InputMeasurementKeys.Where((key, index) => InputMeasurementKeyTypes[index] == SignalType.IPHM).ToArray();

            if (m_voltageAngles.Length < 1)
                throw new InvalidOperationException("No voltage angle input measurement keys were not found - at least one voltage angle input measurement is required for the power stability monitor.");

            if (m_voltageMagnitudes.Length < 1)
                throw new InvalidOperationException("No voltage magnitude input measurement keys were not found - at least one voltage magnitude input measurement is required for the power stability monitor.");

            if (m_currentAngles.Length < 1)
                throw new InvalidOperationException("No current angle input measurement keys were not found - at least one current angle input measurement is required for the power stability monitor.");

            if (m_currentMagnitudes.Length < 1)
                throw new InvalidOperationException("No current magnitude input measurement keys were not found - at least one current magnitude input measurement is required for the power stability monitor.");

            if (m_voltageAngles.Length != m_voltageMagnitudes.Length)
                throw new InvalidOperationException("A different number of voltage magnitude and angle input measurement keys were supplied - the angles and magnitudes must be supplied in pairs, i.e., one voltage magnitude input measurement must be supplied for each voltage angle input measurement in a consecutive sequence (e.g., VA1;VM1;  VA2;VM2; ... VAn;VMn)");

            if (m_currentAngles.Length != m_currentMagnitudes.Length)
                throw new InvalidOperationException("A different number of current magnitude and angle input measurement keys were supplied - the angles and magnitudes must be supplied in pairs, i.e., one current magnitude input measurement must be supplied for each current angle input measurement in a consecutive sequence (e.g., IA1;IM1;  IA2;IM2; ... IAn;IMn)");

            // Make sure only these phasor measurements are used as input
            InputMeasurementKeys = m_voltageAngles.Concat(m_voltageMagnitudes).Concat(m_currentAngles).Concat(m_currentMagnitudes).ToArray();

            // Validate output measurements
            if (OutputMeasurements.Length < Enum.GetValues(typeof(Output)).Length)
                throw new InvalidOperationException("Not enough output measurements were specified for the power stability monitor, expecting measurements for the \"Calculated Power\", and the \"Standard Deviation of Power\" - in this order.");

            m_powerDataSample = new List<double>();            
        }

        /// <summary>
        /// Publishes the <see cref="IFrame"/> of time-aligned collection of <see cref="IMeasurement"/> values that arrived within the
        /// adapter's defined <see cref="ConcentratorBase.LagTime"/>.
        /// </summary>
        /// <param name="frame"><see cref="IFrame"/> of measurements with the same timestamp that arrived within <see cref="ConcentratorBase.LagTime"/> that are ready for processing.</param>
        /// <param name="index">Index of <see cref="IFrame"/> within a second ranging from zero to <c><see cref="ConcentratorBase.FramesPerSecond"/> - 1</c>.</param>
        protected override void PublishFrame(IFrame frame, int index)
        {
            IDictionary<MeasurementKey, IMeasurement> measurements = frame.Measurements;
            IMeasurement magnitude, angle;
            double voltageMagnitude = double.NaN, voltageAngle = double.NaN, power = 0.0D;
            int i;

            // Get first voltage magnitude and angle value pair that is above the energized threshold
            for (i = 0; i < m_voltageMagnitudes.Length; i++)
            {
                if (measurements.TryGetValue(m_voltageMagnitudes[i], out magnitude) && measurements.TryGetValue(m_voltageAngles[i], out angle))
                {
                    if (magnitude.AdjustedValue > m_energizedThreshold)
                    {
                        voltageMagnitude = magnitude.AdjustedValue;
                        voltageAngle = angle.AdjustedValue;
                        break;
                    }
                }
            }

            // Exit if bus voltage measurements were not available for calculation
            if (double.IsNaN(voltageMagnitude))
                return;
            
            // Calculate the sum of the current phasors
            for (i = 0; i < m_currentMagnitudes.Length; i++)
            {
                // Retrieve current magnitude and angle measurements as consecutive pairs
                if (measurements.TryGetValue(m_currentMagnitudes[i], out magnitude) && measurements.TryGetValue(m_currentAngles[i], out angle))
                    power += magnitude.AdjustedValue * Math.Cos(Angle.FromDegrees(angle.AdjustedValue - voltageAngle));
                else
                    return; // Exit if current measurements were not available for calculation
            }

            // Apply bus voltage and convert to 3-phase megawatts
            power = power * voltageMagnitude / (SI.Mega / 3.0D);
            
            // Add latest calculated power to data sample
            lock (m_powerDataSample)
            {
                m_powerDataSample.Add(power);
                
                // Maintain sample size
                while (m_powerDataSample.Count > m_minimumSamples)
                    m_powerDataSample.RemoveAt(0);
            }

            IMeasurement[] outputMeasurements = OutputMeasurements;
            Measurement powerMeasurement = Measurement.Clone(outputMeasurements[(int)Output.Power], power, frame.Timestamp);

            // Check to see if the needed number of samples are available to begin producing the standard deviation output measurement
            if (m_powerDataSample.Count >= m_minimumSamples)
            {
                Measurement stdevMeasurement = Measurement.Clone(outputMeasurements[(int)Output.StDev], frame.Timestamp);

                lock (m_powerDataSample)
                {
                    stdevMeasurement.Value = m_powerDataSample.StandardDeviation();
                }

                // Provide calculated measurements for external consumption
                OnNewMeasurements(new IMeasurement[] { powerMeasurement, stdevMeasurement });
                
                // Track last standard deviation...
                m_lastStdev = stdevMeasurement.AdjustedValue;
            }
            else if (power > 0.0D)
            {
                // If not, we can still start publishing power calculation as soon as we have one...
                OnNewMeasurements(new IMeasurement[] { powerMeasurement });
            }
        }

        #endregion
    }
}