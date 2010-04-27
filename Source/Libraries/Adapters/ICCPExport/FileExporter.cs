//*******************************************************************************************************
//  FileExporter.cs - Gbtc
//
//  Tennessee Valley Authority, 2009
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  This software is made freely available under the TVA Open Source Agreement (see below).
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  01/10/2007 - J. Ritchie Carroll
//      Initial version of source generated.
//  12/29/2009 - Jian R. Zuo
//      Converted code to C# and corrected angle wrapping algorithm.
//  01/15/2010 - J. Ritchie Carroll
//      Abstracted code for general purpose use in the openPDC.
//  01/29/2010 - Jian R. Zuo
//      Add default value to m_exportInterval avoid "Attempted to divide by zero" exception
//  02/01/2010 - Jian R. Zuo
//      Change "return Status.ToString();" to "return status.ToString();"
//  04/27/2010 - J. Ritchie Carroll
//       Performed full code review, optimization and bug fixes for ICCP data export.
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
using System.Data;
using TVA;
using TVA.Collections;
using TVA.Measurements;
using TVA.Measurements.Routing;
using TVA.NumericalAnalysis;
using TVA.IO;
using TVA.PhasorProtocols;

namespace ICCPExport
{
    /// <summary>
    /// Represents an action adapter that exports measurements on an interval to a file that can be picked up by other systems such as ICCP.
    /// </summary>
    public class FileExporter : CalculatedMeasurementBase
    {        
        #region [ Members ]

        // Nested Types
        private enum DataQuality
        {
            Good = 0,
            Suspect = 20,
            Bad = 32
        };

        // Constants
        private const double SqrtOf3 = 1.7320508075688772935274463415059D;

        // Fields
        private MultipleDestinationExporter m_dataExporter;
        private Dictionary<MeasurementKey, string> m_measurementTags;
        private MeasurementKey m_referenceAngleKey;
        private bool m_useReferenceAngle;
        private bool m_useNumericQuality;
        private int m_exportInterval;
        private string m_companyTagPrefix;
        private bool m_statusDisplayed;

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Returns the detailed status of the <see cref="FileExporter"/>.
        /// </summary>
        public override string Status
        {
            get
            {
                StringBuilder status = new StringBuilder();
                
                status.AppendFormat("     Using numeric quality: {0}", m_useNumericQuality);
                status.AppendLine();
                status.AppendFormat("     Using reference angle: {0}", m_useReferenceAngle);
                status.AppendLine();

                if (m_useReferenceAngle)
                {
                    status.AppendFormat("     Reference angle point: {0}", m_referenceAngleKey.ToString());
                    status.AppendLine();
                }

                if (!string.IsNullOrEmpty(m_companyTagPrefix))
                {
                    status.AppendFormat("        Company tag prefix: {0}", m_companyTagPrefix);
                    status.AppendLine();
                }

                if (m_dataExporter != null)
                    status.Append(m_dataExporter.Status);

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

            // Load required parameters
            if (!settings.TryGetValue("exportInterval", out setting))
                throw new ArgumentException(string.Format(errorMessage, "exportInterval"));
            
            m_exportInterval = int.Parse(setting);

            if (m_exportInterval == 0)
                throw new ArgumentException("exportInterval should not be 0 - Example: exportInterval=5");

            if (InputMeasurementKeys == null || InputMeasurementKeys.Length == 0)
                throw new InvalidOperationException("There are no input measurements defined. You must define \"inputMeasurementKeys\" to define which measurements to export.");

            if (!settings.TryGetValue("useReferenceAngle", out setting))
                throw new ArgumentException(string.Format(errorMessage, "useReferenceAngle"));

            m_useReferenceAngle = setting.ParseBoolean();

            if (m_useReferenceAngle)
            {
                // Reference angle measurement has to be defined if using reference angle
                if (!settings.TryGetValue("referenceAngleMeasurement", out setting))
                    throw new ArgumentException(string.Format(errorMessage, "referenceAngleMeasurement"));

                m_referenceAngleKey = MeasurementKey.Parse(setting);
            }

            // Make sure reference angle is part of input measurement keys collection
            if (!InputMeasurementKeys.Contains(m_referenceAngleKey))
                InputMeasurementKeys = InputMeasurementKeys.Concat(new MeasurementKey[] { m_referenceAngleKey }).ToArray();

            // Make sure sure reference angle key is actually an angle measurement
            SignalType signalType = InputMeasurementKeyTypes[InputMeasurementKeys.IndexOf(key => key == m_referenceAngleKey)];

            if (signalType != SignalType.IPHA && signalType != SignalType.VPHA)
                throw new InvalidOperationException(string.Format("Specified reference angle measurement key is a {0} signal, not a phase angle.", signalType.GetFormattedSignalTypeName()));

            // Load optional parameters
            if (settings.TryGetValue("companyTagPrefix", out setting))
                m_companyTagPrefix = setting.ToUpper().Trim();
            else
                m_companyTagPrefix = null;

            if (settings.TryGetValue("useNumericQuality", out setting))
                m_useNumericQuality = setting.ParseBoolean();
            else
                m_useNumericQuality = false;

            // Suffix company tag prefix with an underscore if defined
            if (!string.IsNullOrEmpty(m_companyTagPrefix))
                m_companyTagPrefix = m_companyTagPrefix.EnsureEnd('_');

            // Define a default export location - user can override and add multiple locations in config later...
            ExportDestination[] defaultDestinations = new ExportDestination[] { new ExportDestination(FilePath.GetAbsolutePath("ICCPExport.txt"), false, "", "", "") };
            m_dataExporter = new MultipleDestinationExporter(ConfigurationSection, m_exportInterval * 1000);
            m_dataExporter.PersistSettings = true;
            m_dataExporter.Initialize(defaultDestinations);

            // Create new measurement tag name dictionary
            m_measurementTags = new Dictionary<MeasurementKey, string>();
            string pointID = "undefined";

            // Lookup point tag name for input measurement in the ActiveMeasurements table
            foreach (MeasurementKey key in InputMeasurementKeys)
            {
                try
                {
                    // Get measurement key as a string
                    pointID = key.ToString();

                    // Lookup measurement key in active measurements table
                    DataRow row = DataSource.Tables["ActiveMeasurements"].Select(string.Format("ID='{0}'", pointID))[0];

                    // Remove invalid symbols that may be in tag name
                    string pointTag = row["PointTag"].ToNonNullString(pointID).Replace('-', '_').Replace(':', '_').ToUpper();

                    // Prefix point tag with company prefix if defined
                    if (!string.IsNullOrEmpty(m_companyTagPrefix) && !pointTag.StartsWith(m_companyTagPrefix))
                        pointTag = m_companyTagPrefix + pointTag;

                    m_measurementTags.Add(key, pointTag);
                }
                catch (Exception ex)
                {
                    OnProcessException(new InvalidOperationException(string.Format("Failed to lookup point tag for measurement [{0}] due to exception: {1}", pointID, ex.Message)));
                }
            }

            // We enable tracking of latest measurements so we can use these values if points are missing
            TrackLatestMeasurements = true;
        }

        /// <summary>
        /// Queues a single measurement for processing.
        /// </summary>
        /// <param name="measurement">Measurement to queue for processing.</param>
        public override void QueueMeasurementForProcessing(IMeasurement measurement)
        {
            QueueMeasurementsForProcessing(new IMeasurement[] { measurement });
        }

        /// <summary>
        /// Queues a collection of measurements for processing.
        /// </summary>
        /// <param name="measurements">Collection of measurements to queue for processing.</param>
        /// <remarks>
        /// We override this method to only queue measurements at the desired export interval - no need
        /// do excess sorting work for measurements that will never be used :)
        /// </remarks>
        public override void QueueMeasurementsForProcessing(IEnumerable<IMeasurement> measurements)
        {
            List<IMeasurement> inputMeasurements = new List<IMeasurement>();
            Ticks timestamp;
            bool sortMeasurement;

            foreach (IMeasurement measurement in measurements)
            {
                timestamp = measurement.Timestamp;

                // Measurement will exported if the following criteria are true:
                //   A) Timestamp's seconds are an interval of the defined export interval
                //   B) Timestamp falls within first frame of data in the second
                //   C) This is a defined input measurement for this adapter
                sortMeasurement = 
                        ((DateTime)timestamp).Second % m_exportInterval == 0 && // <-- A
                        timestamp.DistanceBeyondSecond() < TicksPerFrame &&     // <-- B
                        IsInputMeasurement(measurement.Key);                    // <-- C

                if (sortMeasurement)
                    inputMeasurements.Add(measurement);
            }

            if (inputMeasurements.Count > 0)
                SortMeasurements(inputMeasurements);
        }

        /// <summary>
        /// Process frame of time-aligned measurements that arrived within the defined lag time.
        /// </summary>
        /// <param name="frame"><see cref="IFrame"/> of measurements that arrived within lag time and are ready for processing.</param>
        /// <param name="index">Index of <see cref="IFrame"/> within one second of data ranging from zero to frames per second - 1.</param>
        protected override void PublishFrame(IFrame frame, int index)
        {
            Ticks timestamp = frame.Timestamp;
            IDictionary<MeasurementKey, IMeasurement> measurements = frame.Measurements;

            if (measurements.Count > 0)
            {
                StringBuilder fileData = new StringBuilder();
                IMeasurement measurement, referenceAngle;
                MeasurementKey inputMeasurementKey;
                SignalType signalType;
                DataQuality measurementQuality;
                double measurementValue, referenceAngleValue;
                string measurementTag;

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
                    // Export all defined input measurements
                    for (int i = 0; i < InputMeasurementKeys.Length; i++)
			        {
        			    inputMeasurementKey = InputMeasurementKeys[i];
                        signalType = InputMeasurementKeyTypes[i];

                        // Look up measurement's tag name
                        if (m_measurementTags.TryGetValue(inputMeasurementKey, out measurementTag))
                        {
                            // See if measurement exists in this frame
                            if (measurements.TryGetValue(inputMeasurementKey, out measurement))
                            {
                                // Get measurement's adjusted value (takes into account any adder and or multipler)
                                measurementValue = measurement.AdjustedValue;

                                // Interpret data quality flags
                                measurementQuality = (measurement.ValueQualityIsGood ? (measurement.TimestampQualityIsGood ? DataQuality.Good : DataQuality.Suspect) : DataQuality.Bad);
                            }
                            else
                            {
                                // Didn't find measurement in this frame, try using most recent value
                                measurementValue = LatestMeasurements[inputMeasurementKey];

                                // Interpret data quality flags - since measurement was missing in this frame we mark it as
                                // suspect. Could have just missed the time window for sorting.
                                measurementQuality = (Double.IsNaN(measurementValue) ? DataQuality.Bad : DataQuality.Suspect);
                                
                                // We'll export zero instead of NaN for bad data
                                if (measurementQuality == DataQuality.Bad)
                                    measurementValue = 0.0D;
                            }

                            // Export tag name field
                            fileData.Append(measurementTag);
                            fileData.Append(",");

                            // Export measurement value making any needed adjustments based on signal type
                            if (signalType == SignalType.VPHA || signalType == SignalType.IPHA)
                            {
                                // This is a phase angle measurement, export the value relative to the reference angle (if available)
                                if (referenceAngle == null)
                                {
                                    // No reference angle defined, export raw angle
                                    fileData.Append(measurementValue);
                                }
                                else
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

                                    fileData.Append(measurementValue);
                                }
                            }
                            else if (signalType == SignalType.VPHM)
                            {
                                // Typical voltages from PMU's are line-to-neutral volts so we convert them to line-to-line kilovolts
                                fileData.Append(measurementValue * SqrtOf3 / 1000.0D);
                            }
                            else
                            {
                                // Export all other types of measurements as their raw value
                                fileData.Append(measurementValue);
                            }

                            // Export interpreted measurement quality
                            fileData.Append(",");

                            if (m_useNumericQuality)
                                fileData.Append((int)measurementQuality);
                            else
                                fileData.Append(measurementQuality);

                            // Terminate line (ICCP file link expects these two terminating commas, weird...)
                            fileData.AppendLine(",,");
                        }
                        else
                        {
                            // We were unable to find measurement tag for this key - this is unexpected
                            OnProcessException(new InvalidOperationException(string.Format("Failed to find measurement tag for measurement {0}", inputMeasurementKey)));
                        }
                    }
                }

                // Measurement export to a file may take more than available processing time - so we queue this work up ...
                m_dataExporter.ExportData(fileData.ToString());

                // We display export status every other minute
                if (new DateTime(frame.Timestamp).Minute % 2 == 0)
                {
                    //Make sure message is only displayed once during the minute
                    if (!m_statusDisplayed)
                    {
                        OnStatusMessage(string.Format("{0} successful file based measurement exports...", m_dataExporter.TotalExports));
                        m_statusDisplayed = true;
                    }
                }
                else
                    m_statusDisplayed = false;
            }
            else
            {
                // No data was available in the frame, lag time set too tight?
                OnProcessException(new InvalidOperationException("No measurements were available for file based data export, possible reasons: system is initializing , receiving no data or lag time is too small. File creation was skipped."));
            }
        }

        #endregion
    }
}
