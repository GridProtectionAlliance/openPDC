//*******************************************************************************************************
//  LOFTrigger.cs - Gbtc
//
//  Tennessee Valley Authority, 2009
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  This software is made freely available under the TVA Open Source Agreement (see below).
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  11/16/2009 - Jian (Ryan) Zuo && Paul Trachian
//       Generated original version of C# source code.
//
//*******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVA;
using TVA.Measurements;
using TVA.PhasorProtocols;
using TVA.Collections;

namespace LOFTrigger
{
    /// <summary>
    /// Represents an action adapter that implement logic to detect Loss of Field based on Montgomery PMU.
    /// </summary>
    public class LOFTrigger : CalculatedMeasurementBase
    {
        #region [ Members ]

        // Fields
        private ProcessQueue<IFrame> m_processQueue;
        private double m_PSet;                                     //Threshold of Pset MW: default value -600 mW      
        private double m_QSet;                                     //Threshold of Qset MVar: default value 200 mVar
        private double m_QAreaSet;                                 //Threshold of Qarea MVar-sec: default value 500 mVar-sec
        private double m_VThreshold;                               //Threshold of Voltage: default value 0.95 p.u. or 475 kV
        private double m_QAreamVar;                                //Calculated Q area value                 
        private int m_interval;                                 //Interval between adjacent check
        private long m_count;                                    //Frame count for debug purpose
        private long m_count1;
        private long m_count2;
        private bool m_disposed;
        MeasurementKey m_MontVoltageMagnitude;
        MeasurementKey m_MontVoltageAngle;
        MeasurementKey m_MontCurrentMagnitude;
        MeasurementKey m_MontCurrentAngle;


        #endregion

        #region [ Constructors ]

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Returns the detailed status of the frequency monitor event detector.
        /// </summary>
        public override string Status
        {
            get
            {
                StringBuilder status = new StringBuilder();

                //status.AppendFormat("                Adpater ID: {0}", ID);
                //status.AppendLine();
                status.Append(base.Status);
                return status.ToString();
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="FrequencyMonitor"/> object and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                try
                {
                    if (disposing)
                    {
                        if (m_processQueue != null)
                            m_processQueue.Dispose();

                        m_processQueue = null;
                    }
                }
                finally
                {
                    base.Dispose(disposing);    // Call base class Dispose().
                    m_disposed = true;          // Prevent duplicate dispose.
                }
            }
        }

        /// <summary>
        /// Initializes <see cref="FrequencyMonitor"/>.
        /// </summary>

        public override void Initialize()
        {
            base.Initialize();

            Dictionary<string, string> settings = Settings;
            //string setting;

            // Load required parameters
            m_PSet = double.Parse(settings["PSet"]);
            m_QSet = double.Parse(settings["QSet"]);
            m_QAreaSet = double.Parse(settings["QAreaSet"]);
            m_VThreshold = double.Parse(settings["VoltageThreshold"]);
            m_interval = int.Parse(settings["CalculateInterval"]);
            m_count = 0;
            m_count1 = 0;
            m_count2 = 0;


            m_PSet = -600;
            m_QSet = 200;
            m_QAreaSet = 500;
            m_VThreshold = 475000;
            m_interval = 30;

            m_MontVoltageMagnitude = new MeasurementKey(3981, "P2");
            m_MontVoltageAngle = new MeasurementKey(3980, "P2");
            m_MontCurrentMagnitude = new MeasurementKey(3991, "P2");
            m_MontCurrentAngle = new MeasurementKey(3990, "P2");
            m_processQueue = ProcessQueue<IFrame>.CreateRealTimeQueue(ProcessFrames);
        }

        /// <summary>
        /// Starts the <see cref="FrequencyMonitor"/>, if it is not already running.
        /// </summary>
        public override void Start()
        {
            base.Start();
            m_processQueue.Start();
        }

        /// <summary>
        /// Stops the <see cref="FrequencyMonitor"/>.
        /// </summary>
        public override void Stop()
        {
            m_processQueue.Stop();
            base.Stop();
        }

        /// <summary>
        /// Publishes the <see cref="IFrame"/> of time-aligned collection of <see cref="IMeasurement"/> values that arrived within the
        /// adapter's defined <see cref="ConcentratorBase.LagTime"/>.
        /// </summary>
        /// <param name="frame"><see cref="IFrame"/> of measurements with the same timestamp that arrived within <see cref="ConcentratorBase.LagTime"/> that are ready for processing.</param>
        /// <param name="index">Index of <see cref="IFrame"/> within a second ranging from zero to <c><see cref="ConcentratorBase.FramesPerSecond"/> - 1</c>.</param>
        /// <remarks>
        /// If user implemented publication function consistently exceeds available publishing time (i.e., <c>1 / <see cref="ConcentratorBase.FramesPerSecond"/></c> seconds),
        /// concentration will fall behind. A small amount of this time is required by the <see cref="ConcentratorBase"/> for processing overhead, so actual total time
        /// available for user function process will always be slightly less than <c>1 / <see cref="ConcentratorBase.FramesPerSecond"/></c> seconds.
        /// </remarks>
        protected override void PublishFrame(IFrame frame, int index)
        {
            m_processQueue.Add(frame);
        }


        /// <summary>
        /// Process queued frames
        /// </summary>
        /// <param name="frames"></param>
        protected void ProcessFrames(IFrame[] frames)
        {
            double voltageMagnitude;
            double voltageAngle;
            double currentMagnitude;
            double currentAngle;
            double realPower;
            double reactivePower;
            double deltaT;
            IMeasurement measurement;
            foreach (IFrame frame in frames)
            {
                m_count++;
#if DEBUG
                if (m_count % 60 == 0)
                    OnStatusMessage("{0} events handled...", m_count);
#endif
                if ((m_count % m_interval) == 0)
                {
                    m_count1 = m_count2;
                    m_count2 = m_count;
                    try
                    {
                        if (frame.Measurements.TryGetValue(m_MontVoltageMagnitude, out measurement))
                            voltageMagnitude = measurement.AdjustedValue;
                        else
                            continue;
                        if (frame.Measurements.TryGetValue(m_MontVoltageAngle, out measurement))
                            voltageAngle = measurement.AdjustedValue / 180.00 * Math.PI;
                        else
                            continue;
                        if (frame.Measurements.TryGetValue(m_MontCurrentMagnitude, out measurement))
                            currentMagnitude = measurement.AdjustedValue;
                        else
                            continue;
                        if (frame.Measurements.TryGetValue(m_MontVoltageAngle, out measurement))
                            currentAngle = measurement.AdjustedValue / 180.00 * Math.PI;
                        else
                            continue;

                        realPower = 3 * voltageMagnitude * currentMagnitude * Math.Cos(voltageAngle - currentAngle) / 1000000.00;
                        reactivePower = 3 * voltageMagnitude * currentMagnitude * Math.Sin(voltageAngle - currentAngle) / 1000000.00;
                        deltaT = (m_count2 - m_count1) / FramesPerSecond;
                        if ((realPower < m_PSet) && (reactivePower > m_QSet))
                        {
                            m_QAreamVar = m_QAreamVar + deltaT * (reactivePower - m_QSet);
                            if ((m_QAreamVar > m_QAreaSet) && (voltageMagnitude < (m_VThreshold / Math.Sqrt(3))))
                            {
                                OutputLOFWarning(realPower, reactivePower, m_QAreamVar);
                            }
                        }
                        else
                            m_QAreamVar = 0;
                    }
                    catch (Exception ex)
                    {
                        OnStatusMessage(string.Format("***LOFTrigger:{0} ***", ex.ToString()));
                    }
                }

            }
        }

        private void OutputLOFWarning (double realPower, double reactivePower, double QAreamVar)
        {
            OnStatusMessage("************** LOF Warning!!!!!*************");
            OnStatusMessage (string.Format ("The real power is {0}:",realPower ));
            OnStatusMessage (string.Format ("The reactive power is {0}:",reactivePower));
            OnStatusMessage(string.Format("The Q Area is {0}:", QAreamVar));
        }
        #endregion
    }
}
