using System.Collections.Generic;
using System.Timers;
using TVA;
using TVA.Measurements;
using TVA.Measurements.Routing;
using System;

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
        private Ticks m_latestTimestamp;
        private Timer m_warningTimer;

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
            m_latestTimestamp = 0L;
            m_warningTimer = new Timer();
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
                if (!settings.TryGetValue("lowRange", out setting))
                    throw new ArgumentException(string.Format(errorMessage, "lowRange"));

                m_lowRange = double.Parse(setting);

                if (!settings.TryGetValue("highRange", out setting))
                    throw new ArgumentException(string.Format(errorMessage, "highRange"));

                m_highRange = double.Parse(setting);

                rangeSet = true;
            }

            if (settings.TryGetValue("timeToPurge", out setting))
                m_timeToPurge = Ticks.FromSeconds(double.Parse(setting));

            if (settings.TryGetValue("warnInterval", out setting))
                m_warnInterval = Ticks.FromSeconds(double.Parse(setting));

            m_warningTimer.Interval = m_warnInterval.ToMilliseconds();
            m_warningTimer.Elapsed += m_warningTimer_Elapsed;
        }

        /// <summary>
        /// Starts the <see cref="RangeTest"/>.
        /// </summary>
        public override void Start()
        {
            base.Start();

            m_warningTimer.Start();
        }

        /// <summary>
        /// Stops the <see cref="RangeTest"/>.
        /// </summary>
        public override void Stop()
        {
            base.Stop();

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
            m_latestTimestamp = frame.Timestamp;

            foreach (MeasurementKey key in frame.Measurements.Keys)
            {
                IMeasurement measurement = frame.Measurements[key];

                if (measurement.AdjustedValue <= m_lowRange || measurement.AdjustedValue >= m_highRange)
                {
                    AddOutOfRangeMeasurement(key, measurement);
                }
            }
        }

        private bool TrySetRange(string signalType)
        {
            switch (signalType)
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

        private void AddOutOfRangeMeasurement(MeasurementKey key, IMeasurement measurement)
        {
            LinkedList<IMeasurement> outOfRangeList;

            if (!m_outOfRangeMeasurements.TryGetValue(key, out outOfRangeList))
            {
                outOfRangeList = new LinkedList<IMeasurement>();
                m_outOfRangeMeasurements.Add(key, outOfRangeList);
            }

            outOfRangeList.AddLast(measurement);
        }

        private void m_warningTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (MeasurementKey key in m_outOfRangeMeasurements.Keys)
            {
                LinkedList<IMeasurement> measurements = m_outOfRangeMeasurements[key];
                bool donePurging = false;

                // Purge old measurements to prevent redundant warnings.
                while (measurements.Count > 0 && !donePurging)
                {
                    IMeasurement measurement = measurements.First.Value;
                    Ticks diff = m_latestTimestamp - measurement.Timestamp;

                    if (diff < m_timeToPurge)
                        donePurging = true;
                    else
                        measurements.RemoveFirst();
                }

                if (measurements.Count > 0)
                {
                    OnStatusMessage("Measurement {0} out-of-range {1} times within the last {2} seconds.", key, measurements.Count, ((int)m_timeToPurge.ToSeconds()));
                }
            }
        }

        #endregion
        
    }
}
