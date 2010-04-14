//*******************************************************************************************************
//  ReferenceAngle.cs - Gbtc
//
//  Tennessee Valley Authority, 2009
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  This software is made freely available under the TVA Open Source Agreement (see below).
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  05/19/2006 - J. Ritchie Carroll
//       Initial version of source generated.
//  01/16/2007 - Jian R. Zuo
//       Implement the unwrap offset of the angle.
//  01/17/2007 - J. Ritchie Carroll
//       Added code to detect data set changes (i.e., PMU's online/offline).
//  01/17/2007 - Jian R. Zuo
//       Added code to handle unwrap offset initialization and reset.
//  12/23/2009 - Jian R. Zuo
//       Converted code to C#.
//  12/28/2009 - Jian R. Zuo
//       Include System.Linq and use "Average" extension function.
//  04/12/2010 - J. Ritchie Carroll
//       Performed full code review, optimization and further abstracted code for average calculation.
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
using TVA.Collections;
using TVA.Measurements;
using TVA.PhasorProtocols;

namespace PowerCalculations
{
    /// <summary>
    /// Calculates a composed reference angle.
    /// </summary>
    public class ReferenceAngle : CalculatedMeasurementBase
    {
        #region [ Members ]

        // Constants
        private const int BackupQueueSize = 10;

        // Fields
        private double m_phaseResetAngle;
        private Dictionary<MeasurementKey, Double> m_lastAngles;
        private Dictionary<MeasurementKey, Double> m_unwrapOffsets;
        private List<Double> m_latestCalculatedAngles;
        private IMeasurement[] m_measurements;
        
        #endregion

        #region [ Properties ]

        /// <summary>
        /// Returns the detailed status of the <see cref="ReferenceAngle"/> calculator.
        /// </summary>
        public override string Status
        {
            get
            {
                const int ValuesToShow = 4;

                StringBuilder status = new StringBuilder ();

                status.AppendFormat("  Last " + ValuesToShow + " calculated angles:");

                lock (m_latestCalculatedAngles)
                {
                    if (m_latestCalculatedAngles.Count > ValuesToShow)
                        status.Append(m_latestCalculatedAngles.GetRange(m_latestCalculatedAngles.Count - ValuesToShow, ValuesToShow).Select(v => v.ToString("0.00°")).ToDelimitedString(", "));
                    else
                        status.Append("Not enough values calculated yet ...");
                }

                status.AppendLine();
                status.Append(base.Status);

                return status.ToString ();
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Initializes the <see cref="ReferenceAngle"/> calculator.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            // Validate input measurements
            List<MeasurementKey> validInputMeasurementKeys = new List<MeasurementKey>();
            SignalType keyType;

            for (int i = 0; i < InputMeasurementKeys.Length; i++)
            {
                keyType = InputMeasurementKeyTypes[i];

                // Make sure measurement key type is a phase angle
                if (keyType == SignalType.VPHA || keyType == SignalType.IPHA)
                    validInputMeasurementKeys.Add(InputMeasurementKeys[i]);
            }

            if (validInputMeasurementKeys.Count == 0)
                throw new InvalidOperationException("No valid phase angles were specified as inputs to the reference angle calculator.");

            if (InputMeasurementKeyTypes.Count(s => s == SignalType.VPHA) > 0 && InputMeasurementKeyTypes.Count(s => s == SignalType.IPHA) > 0)
                throw new InvalidOperationException("A mixture of voltage and current phase angles were specified as inputs to the reference angle calculator - you must specify one or the other: only voltage phase angles or only current phase angles.");

            // Make sure only phase angles are used as input
            InputMeasurementKeys = validInputMeasurementKeys.ToArray();

            // Validate output measurements
            if (OutputMeasurements.Length < 1)
                throw new InvalidOperationException("An output measurement was not specified for the reference angle calculator - one measurement is expected to represent the \"Calculated Reference Angle\" value.");

            // Initialize member fields
            m_lastAngles = new Dictionary<MeasurementKey, double>();
            m_unwrapOffsets = new Dictionary<MeasurementKey, double>();
            m_latestCalculatedAngles = new List<double>();
            m_phaseResetAngle = MinimumMeasurementsToUse * 360.0D;
        }

        /// <summary>
        /// Calculates a virtual reference angle.
        /// </summary>
        /// <param name="frame">Single frame of measurement data within one second samples</param>
        /// <param name="index">Index of frame within the one second samples</param>
        protected override void PublishFrame(IFrame frame, int index)
        {
            Measurement calculatedMeasurement = Measurement.Clone(OutputMeasurements[0], frame.Timestamp);
            double angle, deltaAngle, angleTotal, angleAverage, lastAngle, unwrapOffset;
            IMeasurement currentAngle;
            MeasurementKey key;
            bool dataSetChanged;
            int i;

            dataSetChanged = false;
            angleTotal = 0.0D;

            // Attempt to get minimum needed reporting set of composite angles used to calculate reference angle
            if (TryGetMinimumNeededMeasurements(frame, ref m_measurements))
            {
                // See if data set has changed since last run
                if (m_lastAngles.Count > 0 && m_lastAngles.Count == m_measurements.Length)
                {
                    for (i = 0; i < m_measurements.Length; i++)
                    {
                        if (!m_lastAngles.ContainsKey(m_measurements[i].Key))
                        {
                            dataSetChanged = true;
                            break;
                        }
                    }
                }
                else
                    dataSetChanged = true;

                // Reinitialize all angle calculation data if data set has changed
                if (dataSetChanged)
                {
                    double angleRef, angleDelta0, angleDelta1, angleDelta2;

                    // Clear last angles and unwrap offsets
                    m_lastAngles.Clear();
                    m_unwrapOffsets.Clear();

                    // Calculate new unwrap offsets
                    angleRef = m_measurements[0].AdjustedValue;

                    for (i = 0; i < m_measurements.Length; i++)
                    {
                        angleDelta0 = Math.Abs(m_measurements[i].AdjustedValue - angleRef);
                        angleDelta1 = Math.Abs(m_measurements[i].AdjustedValue + 360.0D - angleRef);
                        angleDelta2 = Math.Abs(m_measurements[i].AdjustedValue - 360.0D - angleRef);

                        if (angleDelta0 < angleDelta1 && angleDelta0 < angleDelta2)
                            unwrapOffset = 0.0D;
                        else if (angleDelta1 < angleDelta2)
                            unwrapOffset = 360.0D;
                        else
                            unwrapOffset = -360.0D;

                        m_unwrapOffsets[m_measurements[i].Key] = unwrapOffset;
                    }
                }

                // Add up all the phase angles, unwrapping angles if necessary
                for (i = 0; i < m_measurements.Length; i++)
                {
                    // Get current angle value and key
                    angle = m_measurements[i].AdjustedValue;
                    key = m_measurements[i].Key;

                    // Get the unwrap offset for this angle
                    unwrapOffset = m_unwrapOffsets[key];

                    // Get angle value from last run,if there was a last run
                    if (m_lastAngles.TryGetValue(key, out lastAngle))
                    {
                        // Calculate the angle difference from last run
                        deltaAngle = angle - lastAngle;

                        // Adjust angle unwrap offset if needed
                        if (deltaAngle > 300)
                            unwrapOffset -= 360;
                        else if (deltaAngle < -300)
                            unwrapOffset += 360;
                        
                        // Reset angle unwrap offset if needed
                        if (unwrapOffset > m_phaseResetAngle)
                            unwrapOffset -= m_phaseResetAngle;
                        else if (unwrapOffset < -m_phaseResetAngle)
                            unwrapOffset += m_phaseResetAngle;
                        
                        // Record last angle unwrap offset
                        m_unwrapOffsets[key] = unwrapOffset;
                    }

                    // Add up all the angles
                    angleTotal += (angle + unwrapOffset);
                }
                // We use modulus function to make sure angle is in range of 0 to 360
                angleAverage = (angleTotal / m_measurements.Length) % 360.0D;

                // Record last angles for next run
                m_lastAngles.Clear();

                for (i = 0; i < m_measurements.Length; i++)
                {
                    currentAngle = m_measurements[i];
                    m_lastAngles.Add(currentAngle.Key, currentAngle.AdjustedValue);
                }
            }
            else
            { 
                // Use stored average value when minimum set is not available
                angleAverage = m_latestCalculatedAngles.Average() % 360.0D;

                // Mark quality as "bad" when falling back to stored value
                calculatedMeasurement.ValueQualityIsGood = false;
            }
            
            // Convert angle value to the range of -180 to 180
            if (angleAverage > 180)
                angleAverage -= 360;

            if (angleAverage <= -180)
                angleAverage += 360;
            
            calculatedMeasurement.Value = angleAverage;

            // Expose calculated value
            OnNewMeasurements(new IMeasurement[] { calculatedMeasurement });

            // Add calculated reference angle to latest angle queue as backup in case needed
            // minimum number of angles are not available
            lock (m_latestCalculatedAngles)
            {
                m_latestCalculatedAngles.Add(angleAverage);

                while (m_latestCalculatedAngles.Count > BackupQueueSize)
                    m_latestCalculatedAngles.RemoveAt(0);
            }
        }

        #endregion
    }
}