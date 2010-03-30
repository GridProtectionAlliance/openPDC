//*******************************************************************************************************
//  RangeTest.cs - Gbtc
//
//  Tennessee Valley Authority, 2009
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  This software is made freely available under the TVA Open Source Agreement (see below).
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  11/25/2009 - Stephen C. Wills
//       Generated original version of source code.
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
using System.Timers;
using DataQualityMonitoring.Services;
using TVA;
using TVA.Measurements;
using TVA.Measurements.Routing;

namespace DataQualityMonitoring
{
    /// <summary>
    /// Tests measurements to determine whether their values satisfy a range condition.
    /// </summary>
    public class RangeTest : ActionAdapterBase
    {

        #region [ Members ]

        // Constants

        /// <summary>
        /// Default low range for frequency measurements.
        /// </summary>
        public const double DEFAULT_FREQ_LOW_RANGE = 59.95;

        /// <summary>
        /// Default high range for frequency measurements.
        /// </summary>
        public const double DEFAULT_FREQ_HIGH_RANGE = 60.05;

        /// <summary>
        /// Default low range for voltage phasor magnitudes.
        /// </summary>
        public const double DEFAULT_VPHM_LOW_RANGE = 475000.0;

        /// <summary>
        /// Default high range for voltage phasor magnitudes.
        /// </summary>
        public const double DEFAULT_VPHM_HIGH_RANGE = 525000.0;

        /// <summary>
        /// Default low range for current phasor magnitudes.
        /// </summary>
        public const double DEFAULT_IPHM_LOW_RANGE = 0.0;

        /// <summary>
        /// Default high range for current phasor magnitudes.
        /// </summary>
        public const double DEFAULT_IPHM_HIGH_RANGE = 3000.0;

        /// <summary>
        /// Default low range for voltage phasor angles.
        /// </summary>
        public const double DEFAULT_VPHA_LOW_RANGE = -180.0;

        /// <summary>
        /// Default high range for voltage phasor angles.
        /// </summary>
        public const double DEFAULT_VPHA_HIGH_RANGE = 180.0;

        /// <summary>
        /// Default low range for current phasor angles.
        /// </summary>
        public const double DEFAULT_IPHA_LOW_RANGE = -180.0;

        /// <summary>
        /// Default high range for current phasor angles.
        /// </summary>
        public const double DEFAULT_IPHA_HIGH_RANGE = 180.0;

        // Fields
        private Dictionary<MeasurementKey, LinkedList<IMeasurement>> m_outOfRangeMeasurements;
        private double m_lowRange;
        private double m_highRange;
        private Ticks m_timeToPurge;
        private Ticks m_warnInterval;
        private System.Timers.Timer m_warningTimer;
        private System.Timers.Timer m_purgeTimer;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new instance of the <see cref="RangeTest"/> class.
        /// </summary>
        public RangeTest()
        {
            m_outOfRangeMeasurements = new Dictionary<MeasurementKey, LinkedList<IMeasurement>>();
            m_timeToPurge = Ticks.FromSeconds(1.0);
            m_warnInterval = Ticks.FromSeconds(4.0);
            m_warningTimer = new System.Timers.Timer();
            m_purgeTimer = new System.Timers.Timer();
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets the low range of the measurements sent to this range test.
        /// </summary>
        public double LowRange
        {
            get
            {
                return m_lowRange;
            }
            set
            {
                m_lowRange = value;
            }
        }

        /// <summary>
        /// Gets or sets the high range of the measurements sent to this range test.
        /// </summary>
        public double HighRange
        {
            get
            {
                return m_highRange;
            }
            set
            {
                m_highRange = value;
            }
        }

        /// <summary>
        /// Gets or sets the value that determines when to purge old measurements.
        /// </summary>
        public double TimeToPurge
        {
            get
            {
                return m_timeToPurge.ToSeconds();
            }
            set
            {
                m_timeToPurge = Ticks.FromSeconds(value);
            }
        }

        /// <summary>
        /// Gets or sets how often the <see cref="RangeTest"/> sends out-of-range notifications to the console.
        /// </summary>
        public double WarnInterval
        {
            get
            {
                return m_warnInterval.ToSeconds();
            }
            set
            {
                m_warnInterval = Ticks.FromSeconds(value);
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Initializes this <see cref="RangeTest"/>.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            string errorMessage = "{0} is missing from Settings - Example: lowRange=59.95; highRange=60.05";
            bool rangeSet = false;

            Dictionary<string, string> settings = Settings;
            string setting;

            if (settings.TryGetValue("signalType", out setting))
                rangeSet = TrySetRange(setting);

            if(!rangeSet)
            {
                // Load required parameters
                if (!settings.TryGetValue("lowRange", out setting))
                    throw new ArgumentException(string.Format(errorMessage, "lowRange"));

                m_lowRange = double.Parse(setting);

                if (!settings.TryGetValue("highRange", out setting))
                    throw new ArgumentException(string.Format(errorMessage, "highRange"));

                m_highRange = double.Parse(setting);

                rangeSet = true;
            }

            // Load optional parameters
            if (settings.TryGetValue("timeToPurge", out setting))
                m_timeToPurge = Ticks.FromSeconds(double.Parse(setting));

            if (settings.TryGetValue("warnInterval", out setting))
                m_warnInterval = Ticks.FromSeconds(double.Parse(setting));

            m_warningTimer.Interval = m_warnInterval.ToMilliseconds();
            m_warningTimer.Elapsed += m_warningTimer_Elapsed;

            m_purgeTimer.Interval = m_timeToPurge.ToMilliseconds();
            m_purgeTimer.Elapsed += m_purgeTimer_Elapsed;
        }

        /// <summary>
        /// Starts the <see cref="RangeTest"/>.
        /// </summary>
        public override void Start()
        {
            base.Start();

            AttachToService();
            m_warningTimer.Start();
        }

        /// <summary>
        /// Stops the <see cref="RangeTest"/>.
        /// </summary>
        public override void Stop()
        {
            base.Stop();

            DetachFromService();
            m_warningTimer.Stop();
        }

        /// <summary>
        /// Publish <see cref="IFrame"/> of time-aligned collection of <see cref="IMeasurement"/> values that arrived within the
        /// concentrator's defined <see cref="ConcentratorBase.LagTime"/>.
        /// </summary>
        /// <param name="frame"><see cref="IFrame"/> of measurements with the same timestamp that arrived within <see cref="ConcentratorBase.LagTime"/> that are ready for processing.</param>
        /// <param name="index">Index of <see cref="IFrame"/> within a second ranging from zero to <c><see cref="ConcentratorBase.FramesPerSecond"/> - 1</c>.</param>
        /// <remarks>
        /// If user implemented publication function consistently exceeds available publishing time (i.e., <c>1 / <see cref="ConcentratorBase.FramesPerSecond"/></c> seconds),
        /// concentration will fall behind. A small amount of this time is required by the <see cref="ConcentratorBase"/> for processing overhead, so actual total time
        /// available for user function process will always be slightly less than <c>1 / <see cref="ConcentratorBase.FramesPerSecond"/></c> seconds.
        /// </remarks>
        protected override void PublishFrame(TVA.Measurements.IFrame frame, int index)
        {
            IMeasurement measurement = null;

            foreach (MeasurementKey key in frame.Measurements.Keys)
            {
                measurement = frame.Measurements[key];

                if (measurement.AdjustedValue < m_lowRange || measurement.AdjustedValue > m_highRange)
                {
                    AddOutOfRangeMeasurement(key, measurement);
                }
            }
        }

        /// <summary>
        /// Get a dictionary of <see cref="MeasurementKey"/>,<see cref="System.Int32"/> pairs representing
        /// the number of times each key received has been out-of-range within the last <see cref="TimeToPurge"/> seconds.
        /// </summary>
        /// <returns>A dictionary of count values for each out-of-range measurement.</returns>
        public Dictionary<MeasurementKey, int> GetOutOfRangeCounts()
        {
            Dictionary<MeasurementKey, int> outOfRangeCounts = new Dictionary<MeasurementKey, int>();

            lock (m_outOfRangeMeasurements)
            {
                PurgeOldMeasurements();

                int count = 0;
                foreach (MeasurementKey key in m_outOfRangeMeasurements.Keys)
                {
                    count = m_outOfRangeMeasurements[key].Count;

                    if (count > 0)
                        outOfRangeCounts.Add(key, count);
                }
            }

            return outOfRangeCounts;
        }

        /// <summary>
        /// Get the full collection of out-of-range <see cref="IMeasurement"/>s.
        /// </summary>
        /// <returns>The full collection of out-of-range <see cref="IMeasurement"/>s.</returns>
        public ICollection<IMeasurement> GetOutOfRangeMeasurements()
        {
            ICollection<IMeasurement> allOutOfRangeMeasurements = new LinkedList<IMeasurement>();

            lock (m_outOfRangeMeasurements)
            {
                PurgeOldMeasurements();

                foreach (LinkedList<IMeasurement> measurementList in m_outOfRangeMeasurements.Values)
                {
                    foreach (IMeasurement measurement in measurementList)
                    {
                        allOutOfRangeMeasurements.Add(measurement);
                    }
                }
            }

            return allOutOfRangeMeasurements;
        }

        /// <summary>
        /// Get a collection of out-of-range <see cref="IMeasurement"/>s with the given key.
        /// </summary>
        /// <param name="key">The <see cref="MeasurementKey"/> corresponding to the desired measurements.</param>
        /// <returns>A collection of out-of-range <see cref="IMeasurement"/>s.</returns>
        public ICollection<IMeasurement> GetOutOfRangeMeasurements(MeasurementKey key)
        {
            lock (m_outOfRangeMeasurements)
            {
                PurgeOldMeasurements(key);
                return new LinkedList<IMeasurement>(m_outOfRangeMeasurements[key]);
            }
        }

        // Purge all old out-of-range measurements.
        private void PurgeOldMeasurements()
        {
            lock (m_outOfRangeMeasurements)
            {
                foreach (MeasurementKey key in m_outOfRangeMeasurements.Keys)
                {
                    PurgeOldMeasurements(key);
                }
            }
        }

        // Purge old, out-of-range measurements with the given key.
        private void PurgeOldMeasurements(MeasurementKey key)
        {
            lock (m_outOfRangeMeasurements)
            {
                LinkedList<IMeasurement> measurements = m_outOfRangeMeasurements[key];
                bool donePurging = false;

                // Purge old measurements to prevent redundant warnings.
                while (measurements.Count > 0 && !donePurging)
                {
                    IMeasurement measurement = measurements.First.Value;
                    Ticks diff = base.RealTime - measurement.Timestamp;

                    if (diff >= base.LagTicks + m_timeToPurge)
                        measurements.RemoveFirst();
                    else
                        donePurging = true;
                }
            }
        }

        // Try to set the testing range based on the given signal type.
        private bool TrySetRange(string signalType)
        {
            switch (signalType.ToUpper())
            {
                case "FREQ":
                    m_lowRange = DEFAULT_FREQ_LOW_RANGE;
                    m_highRange = DEFAULT_FREQ_HIGH_RANGE;
                    break;

                case "VPHM":
                    m_lowRange = DEFAULT_VPHM_LOW_RANGE;
                    m_highRange = DEFAULT_VPHM_HIGH_RANGE;
                    break;

                case "IPHM":
                    m_lowRange = DEFAULT_IPHM_LOW_RANGE;
                    m_highRange = DEFAULT_IPHM_HIGH_RANGE;
                    break;

                case "VPHA":
                    m_lowRange = DEFAULT_VPHA_LOW_RANGE;
                    m_highRange = DEFAULT_VPHA_HIGH_RANGE;
                    break;

                case "IPHA":
                    m_lowRange = DEFAULT_IPHA_LOW_RANGE;
                    m_highRange = DEFAULT_IPHA_HIGH_RANGE;
                    break;

                default:
                    return false;
            }

            return true;
        }

        // Add a measurement to the list of out of range measurements corresponding to the given key.
        private void AddOutOfRangeMeasurement(MeasurementKey key, IMeasurement measurement)
        {
            lock (m_outOfRangeMeasurements)
            {
                LinkedList<IMeasurement> outOfRangeList;

                if (!m_outOfRangeMeasurements.TryGetValue(key, out outOfRangeList))
                {
                    outOfRangeList = new LinkedList<IMeasurement>();
                    m_outOfRangeMeasurements.Add(key, outOfRangeList);
                }

                outOfRangeList.AddLast(measurement);
            }
        }

        private void AttachToService()
        {
            lock (s_service)
            {
                s_service.AttachRangeTest(this);

                if (s_exceptionProcessor == null)
                    s_exceptionProcessor = this;
            }
        }

        private void DetachFromService()
        {
            lock (s_service)
            {
                s_service.DetachRangeTest(this);

                if (this == s_exceptionProcessor)
                {
                    ICollection<RangeTest> tests = s_service.Tests;

                    if (tests.Count > 0)
                        s_exceptionProcessor = tests.GetEnumerator().Current;
                    else
                        s_exceptionProcessor = null;
                }
            }
        }

        // Periodically send warnings to the console about out-of-range measurements.
        private void m_warningTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dictionary<MeasurementKey, int> measurementCounts = GetOutOfRangeCounts();

            foreach (MeasurementKey key in measurementCounts.Keys)
            {
                int count = measurementCounts[key];
                OnStatusMessage("Measurement {0} arrived out-of-range {1} times within the last {2} seconds.", key, count, (int)m_timeToPurge.ToSeconds());
            }
        }

        // Periodically purge old measurements to lighten system load and speed up out-of-range measurement retrieval.
        private void m_purgeTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            PurgeOldMeasurements();
        }

        #endregion

        #region [ Static ]

        // Static Fields
        private static OutOfRangeService s_service;
        private static RangeTest s_exceptionProcessor;

        // Static Constructor
        static RangeTest()
        {
            s_service = new OutOfRangeService();
            s_service.ServiceProcessException += s_service_ServiceProcessException;
            s_service.Initialize();
        }

        // Static Methods
        private static void s_service_ServiceProcessException(object sender, EventArgs<Exception> e)
        {
            if (s_exceptionProcessor != null)
                s_exceptionProcessor.OnProcessException(e.Argument);
        }

        #endregion
        
    }
}
