//*******************************************************************************************************
//  FrequencyMonitor.cs - Gbtc
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
using System.Text;
using TVA;
using TVA.Measurements;
using TVA.Measurements.Routing;

namespace EventDetection
{
    /// <summary>
    /// Represents an action adapter that monitors system frequency for events.
    /// </summary>
    public class FrequencyMonitor : ActionAdapterBase
    {
        protected override void PublishFrame(IFrame frame, int index)
        {
            throw new NotImplementedException();
        }
    }

    //public class EventDetection : CalculatedMeasurementAdapterBase
    //{
    //    #region "Private Member Declaraton"
    //    private ProcessQueue<IFrame> m_processQueue;
    //    private List<ChannelType> m_channelType;                                    //Channel type
    //    private string DefaultConfigSection = "EventDetection";
    //    private double m_estimateTriggerThreshold;                                  //Threshold for detecting abnormal excursion in frequency
    //    private int m_analysisWindowSize;                                           //Analysis Window Size
    //    private int m_analysisInterval;                                             //Analysis Interval
    //    private int m_consistantEstimate;                                           //Consistant estimation to determine if the alarm is true or false
    //    private double m_estiamteRatio;                                             //To calculate the total MW change from frequency 
    //    private string m_connString;                                                //Connection string for database connection
    //    private List<double> m_freqMeasurements;                                    //Measurements for frequency
    //    private List<DateTime> m_timeStamps;                                        //Timestamps
    //    private int m_alarmProhibitPeriod;                                          //Period to prevent duplicated alarms;
    //    private long m_count;                                                       //Frame count for debug purpose
    //    private int m_numDetectedExcursion;                                         //Number of detected excursions;
    //    private string m_configFileName;                                            //Configuration file
    //    private int m_totalChannelCount;
    //    private int m_minimumValidChannel;
    //    private int m_maximumPoints;

    //    #endregion

    //    #region "Constructor"
    //    public EventDetection()
    //    {
    //        m_processQueue = ProcessQueue<IFrame>.CreateRealTimeQueue(ProcessFrames);
    //        m_processQueue.Start();
    //    }
    //    #endregion

    //    #region "Public Methods"
    //    public override void Initialize(string calculationName, string configurationSection, IMeasurement[] outputMeasurements, MeasurementKey[] inputMeasurementKeys, int minimumMeasurementsToUse, int expectedFrameRate, double lagTime, double leadTime)
    //    {
    //        List<MeasurementKey> inputMeasurements = new List<MeasurementKey>();
    //        m_channelType = new List<ChannelType>();
    //        m_freqMeasurements = new List<double>();
    //        m_timeStamps = new List<DateTime>();

    //        string m_systemPath;
    //        base.Initialize(calculationName, configurationSection, outputMeasurements, inputMeasurementKeys, minimumMeasurementsToUse, expectedFrameRate, lagTime, leadTime);
    //        UpdateStatus("***EventDetection:Base initialization completed.");

    //        if (string.IsNullOrEmpty(configurationSection))
    //            configurationSection = DefaultConfigSection;
    //        CategorizedSettingsElementCollection settings = TVA.Configuration.Common.get_CategorizedSettings(ConfigurationSection);
    //        settings.Clear();
    //        //Initialize system path
    //        m_systemPath = TVA.IO.FilePath.GetApplicationPath();
    //        m_configFileName = m_systemPath + "EventDetection.xml";
    //        settings.Add("EventDetectionConfigFile", m_configFileName, "The configuration file for EventDetection Module");
    //        ParseConfigFile(m_configFileName, ref settings, ref inputMeasurements);
    //        UpdateStatus("***EventDetection:ParseConfigFile Finished.");
    //        TVA.Configuration.Common.SaveSettings();
    //        InputMeasurementKeys = inputMeasurements.ToArray();
    //        MinimumMeasurementsToUse = inputMeasurements.Count;
    //        m_totalChannelCount = InputMeasurementKeys.Length;

    //        //Load parameters for algorithm from configuration file
    //        m_estimateTriggerThreshold = Convert.ToDouble(settings["EstimateTriggerThreshold"].Value);
    //        m_analysisWindowSize = Convert.ToInt32(settings["AnalysisWindowSize"].Value);
    //        m_analysisInterval = Convert.ToInt32(settings["AnalysisInterval"].Value);
    //        m_consistantEstimate = Convert.ToInt32(settings["ConsistantEstimate"].Value);
    //        m_minimumValidChannel = Convert.ToInt32(settings["MinimumValidChannel"].Value);
    //        m_maximumPoints = Convert.ToInt32(settings["MaximuPoints"].Value);
    //        m_estiamteRatio = Convert.ToDouble(settings["EstimateRatio"].Value);
    //        m_connString = Convert.ToString(settings["sqlConnectString"].Value);
    //        UpdateStatus("***EventDetection:Initialization Finished.");
    //    }


    //    private void ParseConfigFile(string fileName, ref CategorizedSettingsElementCollection settings, ref List<MeasurementKey> inputMeasurements)
    //    {
    //        ModuleConfig m_moduleConfig = null;
    //        try
    //        {
    //            XmlSerializer serializer = new XmlSerializer(typeof(ModuleConfig));
    //            StreamReader reader = new StreamReader(fileName);
    //            m_moduleConfig = (ModuleConfig)serializer.Deserialize(reader);
    //            reader.Close();
    //            for (int i = 0; i < m_moduleConfig.Parameters.Length; i++)
    //            {
    //                ParaConfig parameter = m_moduleConfig.Parameters[i];
    //                settings.Add(parameter.paraName, parameter.value, parameter.description);
    //            }
    //            for (int i = 0; i < m_moduleConfig.Unit.Length; i++)
    //            {
    //                UnitConfig unit = m_moduleConfig.Unit[i];
    //                inputMeasurements.Add(new MeasurementKey(unit.pointID, unit.servName));
    //                m_channelType.Add(unit.type);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            UpdateStatus(ex.ToString());
    //        }
    //    }

    //    override protected void PublishFrame(IFrame frame, int index)
    //    {
    //        m_processQueue.Add(frame);
    //        m_count++;
    //        if (m_count % 30 == 0)
    //        {
    //            UpdateStatus(frame.Timestamp.ToString());
    //            UpdateStatus(string.Format("*** Event Detection:{0} events handled...", m_count));
    //        }
    //        return;
    //    }

    //    protected void ProcessFrames(IFrame[] frames)
    //    {
    //        IMeasurement measurement;
    //        MeasurementKey measurementKey;
    //        MeasurementKey[] inputMeasurements = InputMeasurementKeys;
    //        IMeasurement[] measurements = TVA.Common.CreateArray<IMeasurement>(m_totalChannelCount);
    //        int i;
    //        int count;
    //        int validChannel;
    //        double freqMeasurement;
    //        ExcursionType typeofExcursion;
    //        double totalAmount;
    //        bool res;
    //        foreach (IFrame frame in frames)
    //        {
    //            //m_count++;
    //            try
    //            {
    //                //CategorizedSettingsElementCollection settings = TVA.Configuration.Common.get_CategorizedSettings(ConfigurationSection);
    //                if (m_alarmProhibitPeriod > 0)
    //                    m_alarmProhibitPeriod--;
    //                //if (m_count % 30 == 0)
    //                //{
    //                //    UpdateStatus(frame.Timestamp.ToString());
    //                //    UpdateStatus(string.Format("*** Event Detection:{0} events handled...", m_count));
    //                //}
    //                //Loop through all input measurements to see if they exist in this frame
    //                validChannel = 0;
    //                freqMeasurement = 0.0;
    //                for (i = 0; i < m_totalChannelCount; i++)
    //                {
    //                    measurementKey = inputMeasurements[i];
    //                    if (m_channelType[i] == ChannelType.F)
    //                        if (frame.Measurements.TryGetValue(measurementKey, out measurement))
    //                        {
    //                            freqMeasurement = freqMeasurement + measurement.AdjustedValue;
    //                            validChannel++;
    //                        }
    //                }

    //                if (validChannel > 0 && validChannel >= m_minimumValidChannel)
    //                    freqMeasurement = freqMeasurement / validChannel;
    //                else
    //                    freqMeasurement = Double.NaN;

    //                m_freqMeasurements.Add(freqMeasurement);
    //                m_timeStamps.Add(frame.Timestamp);
    //                count = m_freqMeasurements.Count;
    //                if (count > m_maximumPoints)
    //                {
    //                    m_freqMeasurements.RemoveAt(0);
    //                    m_timeStamps.RemoveAt(0);
    //                }

    //                if ((m_count % m_analysisInterval == 0) && (m_alarmProhibitPeriod == 0) && (m_freqMeasurements.Count > m_analysisWindowSize))
    //                {
    //                    double freq1 = m_freqMeasurements[0];
    //                    double freq2 = m_freqMeasurements[m_analysisWindowSize];
    //                    double freqDelta;
    //                    if (!Double.IsNaN(freq1) && !Double.IsNaN(freq2))
    //                    {
    //                        freqDelta = freq1 - freq2;
    //                        if (Math.Abs(freqDelta) > m_estimateTriggerThreshold)
    //                            m_numDetectedExcursion++;
    //                        if (m_numDetectedExcursion >= m_consistantEstimate)
    //                        {
    //                            typeofExcursion = (freq1 > freq2 ? ExcursionType.GenTrip : ExcursionType.LoadTrip);
    //                            totalAmount = Math.Abs(freqDelta) * m_estiamteRatio;
    //                            res = OutputResult(m_connString, m_timeStamps[0], freqDelta, typeofExcursion, totalAmount);
    //                            if (!res)
    //                                UpdateStatus("***EventDetection: ProcessFrames, fail to output result!***");
    //                            m_numDetectedExcursion = 0;
    //                            m_alarmProhibitPeriod = 600;
    //                        }
    //                    }
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                UpdateStatus(string.Format("***EventDetection:{0} ***", ex.ToString()));
    //            }

    //        }
    //    }

    //    private bool OutputResult(string connString, DateTime timestamp, double delta, ExcursionType typeofExcursion, double totalAmount)
    //    {
    //        //create the connection
    //        SqlConnection conn = new SqlConnection(connString);
    //        //create the command
    //        String sqlText = "INSERT INTO Event_Message (TimeStamp,Delta,EventType,TotalAmount) Values (@TimeStamp,@Delta,@EventType,@TotalAmount)";
    //        //create the transaction
    //        conn.Open();
    //        SqlTransaction tran = conn.BeginTransaction();
    //        try
    //        {
    //            //Create command in the transaction with parameters
    //            SqlCommand cmd = new SqlCommand(sqlText, conn, tran);
    //            cmd.Parameters.Add(new SqlParameter("@TimeStamp", SqlDbType.DateTime));
    //            cmd.Parameters.Add(new SqlParameter("@Delta", SqlDbType.Float));
    //            cmd.Parameters.Add(new SqlParameter("@EventType", SqlDbType.Int));
    //            cmd.Parameters.Add(new SqlParameter("@TotalAmount", SqlDbType.Float));
    //            cmd.Parameters["@TimeStamp"].Value = timestamp;
    //            cmd.Parameters["@Delta"].Value = (float)delta;
    //            cmd.Parameters["@EventType"].Value = (int)typeofExcursion;
    //            cmd.Parameters["@TotalAmount"].Value = (float)totalAmount;
    //            cmd.ExecuteNonQuery();
    //            tran.Commit();
    //        }
    //        catch (Exception ex)
    //        {
    //            //Exception occurred, Roll back the transaction
    //            tran.Rollback();
    //            UpdateStatus("***EventDetection:" + ex.ToString());
    //        }
    //        finally
    //        {
    //            conn.Close();
    //            UpdateStatus(string.Format("***EventDetection: OutputResult, time={0},delta={1},type of excursion={2},total amount={3}***", timestamp, delta, typeofExcursion, totalAmount));

    //        }
    //        return true;

    //    }

    //    #endregion
    //}
}


//namespace EventDetection
//{
//    class CommonModule
//    {
//    }

//    public class ModuleConfig
//    {
//        [XmlElement("Parameters")]
//        public ParaConfig[] Parameters;
//        [XmlElement("Unit")]
//        public UnitConfig[] Unit;
//    }
//    public class ParaConfig
//    {
//        [XmlAttribute]
//        public string paraName;
//        [XmlAttribute]
//        public string value;
//        [XmlAttribute]
//        public string description;
//    }
//    public class UnitConfig
//    {
//        [XmlAttribute]
//        public int unitID;
//        [XmlAttribute]
//        public int pointID;
//        [XmlAttribute]
//        public string servName;
//        [XmlAttribute]
//        public ChannelType type;
//        [XmlAttribute]
//        public string description;
//    }
//    public enum ChannelType
//    {
//        F = 5,  //Frequency
//        IA = 4, //Current Angle
//        IM = 3, //Current Magnitude
//        VA = 2, //Voltage Angle
//        VM = 1  //Voltage Magnitude
//    }
//    public enum ExcursionType
//    {
//        GenTrip = 1,      //Generator Trip
//        LoadTrip = 2      //Load Trip
//    }

//}
//<?xml version="1.0" encoding="utf-8"?>
//<ModuleConfig xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
//  <Parameters paraName="EstimateTriggerThreshold" value="0.0256" description="The threshold of estimation trigger"></Parameters>
//  <Parameters paraName="AnalysisWindowSize" value="120" description="The size of analysis window"></Parameters>
//  <Parameters paraName="AnalysisInterval" value="30" description="The interval between two adjacent frequency testing"></Parameters>
//  <Parameters paraName="ConsistantEstimate" value="2" description="Consistent estimation of frequency excursion"></Parameters>
//  <Parameters paraName="MinimumValidChannel" value="3" description="Minimum valid channel for conduction the frequency testing"></Parameters>
//  <Parameters paraName="MaximuPoints" value="600" description="Maximum points in the queue"></Parameters>
//  <Parameters paraName="EstimateRatio" value="19530.00" description="The ratio of total amount of generator (load) trip over the frequency excursion"></Parameters>
//  <Parameters paraName="sqlConnectString" value="Data Source=localhost\SQLExpress;Initial Catalog=EventDetection;User ID=db_test;password=welcome" description="Connection string"></Parameters>
  

//  <Unit unitID ="0" pointID ="37" servName ="P1" type="F" description="TVA_SHEL:ABBF"></Unit>
//  <Unit unitID ="1" pointID ="55" servName ="P1" type="F" description="TVA_FREE:ABBF"></Unit>
//  <Unit unitID ="2" pointID ="75" servName ="P1" type="F" description="TVA_VOLU:ABBF"></Unit>
//  <Unit unitID ="3" pointID ="2171" servName ="P1" type="F" description="TVA_CONC:ABBF"></Unit>
//  <Unit unitID ="4" pointID ="2191" servName ="P1" type="F" description="TVA_ORNL:ABBF"></Unit>
//  <Unit unitID ="5" pointID ="2431" servName ="P1" type="F"  description="TVA_BULL:ABBF"></Unit>
//  <Unit unitID ="6" pointID ="2431" servName ="P1" type="F"  description="TVA_BULL:ABBF"></Unit>
//  <Unit unitID ="7" pointID ="4016" servName ="P1" type="F"  description="TVA_SEBA:ABBF"></Unit>
//  <Unit unitID ="8" pointID ="1586" servName ="P2" type="F"  description="TVA_RIDG:ABBF"></Unit>
//  <Unit unitID ="9" pointID ="1603" servName ="P2" type="F"  description="TVA_CUMB:ABBF"></Unit>
//  <Unit unitID ="10" pointID ="1624" servName ="P2" type="F"  description="TVA_LOWN:ABBF"></Unit>
//  <Unit unitID ="11" pointID ="1649" servName ="P2" type="F"  description="TVA_COLN:ABBF"></Unit>
//  <Unit unitID ="12" pointID ="1668" servName ="P2" type="F"  description="TVA_HEND:ABBF"></Unit>
//  <Unit unitID ="13" pointID ="2136" servName ="P2" type="F"  description="TVA_MARS:ABBF"></Unit>
//  <Unit unitID ="14" pointID ="3892" servName ="P2" type="F"  description="TVA_BRAD:ABBF"></Unit>
//  <Unit unitID ="15" pointID ="3925" servName ="P2" type="F"  description="TVA_SLVN:ABBF"></Unit>
//</ModuleConfig>