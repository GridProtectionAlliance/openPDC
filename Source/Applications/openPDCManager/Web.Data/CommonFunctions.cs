//*******************************************************************************************************
//  CommonFunctions.cs - Gbtc
//
//  Tennessee Valley Authority, 2009
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  This software is made freely available under the TVA Open Source Agreement (see below).
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  07/05/2009 - Mehulbhai Thakkar
//       Generated original version of source code.
//  09/15/2009 - Stephen C. Wills
//       Added new header and license agreement.
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
using System.Data;
using System.Linq;
using openPDCManager.Web.Data.Entities;
using openPDCManager.Web.Data.BusinessObjects;
using TVA;

namespace openPDCManager.Web.Data
{
	/// <summary>
	/// Class that defines common operations on data (retrieval and update)
	/// </summary>
    public static class CommonFunctions
    {    
		#region " Old Code"
		//public static Dictionary<string, int> GetVendorDeviceDistribution()
		//{
		//    Dictionary<string, int> deviceDistribution = new Dictionary<string,int>();
		//    string queryString = "SELECT dbo.Vendor.Name AS VendorName, COUNT(*) AS PmuCount FROM dbo.Pmu " +
		//            "LEFT OUTER JOIN dbo.VendorDevice ON dbo.Pmu.VendorDeviceID = dbo.VendorDevice.ID " +
		//            "INNER JOIN dbo.Vendor ON dbo.VendorDevice.VendorID = dbo.Vendor.ID WHERE (dbo.Pmu.Validated = '1') " +
		//            "GROUP BY dbo.Vendor.Name Order By VendorName";
		//    SqlCommand command = new SqlCommand(queryString);
		//    DataAccess obj = new DataAccess();
		//    DataTable resultTable = new DataTable();
		//    resultTable = obj.GetDataTable(command, true);
		//    foreach (DataRow row in resultTable.Rows)
		//    {
		//        deviceDistribution.Add(row["VendorName"].ToString(), Convert.ToInt32(row["PmuCount"]));
		//    }
		//    return deviceDistribution;           
		//}
		//public static List<Pdc> GetPdcList()
		//{
		//    List<Pdc> pdcList = new List<Pdc>();

		//    SqlCommand command = new SqlCommand("Select * From PdcDetail");
		//    DataAccess obj = new DataAccess();
		//    DataTable resultTable = new DataTable();
		//    resultTable = obj.GetDataTable(command, true);

		//    pdcList = (from item in resultTable.AsEnumerable()
		//               orderby item.Field<string>("Acronym")
		//              select new Pdc() { 
		//                  ID = item.Field<int>("ID"),
		//                  Acronym = item.Field<string>("Acronym"),
		//                  Name = item.Field<string>("Name"),
		//                  CompanyID = item.Field<int>("CompanyID"),
		//                  CompanyAcronym = item.Field<string>("CompanyAcronym"),
		//                  CompanyName = item.Field<string>("CompanyName"),
		//                  AccessID = item.Field<int>("AccessID"),
		//                  VendorDeviceID = item.Field<int>("VendorDeviceID"),
		//                  VendorDeviceName = item.Field<string>("VendorDeviceName"),
		//                  VendorDeviceDescription = item.Field<string>("VendorDeviceDescription"),
		//                  ProtocolID = item.Field<int>("ProtocolID"),
		//                  ProtocolAcronym = item.Field<string>("ProtocolAcronym"),
		//                  ProtocolName = item.Field<string>("ProtocolName"),
		//                  Longitude = item.Field<decimal>("Longitude"),
		//                  Latitude = item.Field<decimal>("Latitude"),
		//                  ConnectionString = item.Field<string>("ConnectionString"),
		//                  AdditionalConnectionInfo = item.Field<string>("AdditionalConnectionInfo"),
		//                  TimeZone = item.Field<string>("TimeZone"),
		//                  TimeOffsetTicks = item.Field<string>("TimeOffsetTicks"),
		//                  FramesPerSecond = item.Field<int>("FramesPerSecond"),
		//                  EmailList = item.Field<string>("EmailList"),
		//                  Enabled = item.Field<bool>("Enabled")
		//              }).ToList();
		//    return pdcList;
		//}
		//public static List<BasicPmuInfo> GetValidatedPmuList()
		//{
		//    List<BasicPmuInfo> pmuList = new List<BasicPmuInfo>();
		//    SqlCommand command = new SqlCommand("Select ID, Acronym, Name, CompanyName, CompanyAcronym, Longitude, Latitude, VendorName, ProtocolName, Reporting, Active From MapDataActiveState Where Validated = '1'");
		//    DataAccess obj = new DataAccess();
		//    DataTable resultTable = new DataTable();
		//    resultTable = obj.GetDataTable(command, true);
		//    pmuList = (from item in resultTable.AsEnumerable()
		//               orderby item.Field<string>("Acronym")
		//               select new BasicPmuInfo()
		//               {
		//                  ID = item.Field<int>("ID"),
		//                  Acronym = item.Field<string>("Acronym"),
		//                  Name = item.Field<string>("Name"),
		//                  CompanyName = item.Field<string>("CompanyName"), 
		//                  CompanyAcronym = item.Field<string>("CompanyAcronym"),
		//                  Longitude = item.Field<decimal>("Longitude"),
		//                  Latitude = item.Field<decimal>("Latitude"),
		//                  DeviceName = item.Field<string>("VendorName"),
		//                  ProtocolName = item.Field<string>("ProtocolName"),
		//                  Reporting = item.Field<bool>("Reporting"),
		//                  Active = item.Field<bool>("Active")
		//              }).ToList();
		//    return pmuList;
		//}
		//public static List<BasicPmuInfo> GetAllPmuList()
		//{
		//    List<BasicPmuInfo> pmuList = new List<BasicPmuInfo>();
		//    SqlCommand command = new SqlCommand("Select ID, Acronym, Name, CompanyName, CompanyAcronym, Longitude, Latitude, VendorName, ProtocolName, Reporting, Active, Validated, InProgress From MapDataActiveState Where CompanyID = 29 AND BpaAcronym NOT IN ('BFNP','SQNP','MRFB','WRTC','ALCO')");
		//    DataAccess obj = new DataAccess();
		//    DataTable resultTable = new DataTable();
		//    resultTable = obj.GetDataTable(command, true);
		//    pmuList = (from item in resultTable.AsEnumerable()
		//               orderby item.Field<string>("Acronym")
		//               select new BasicPmuInfo()
		//               {
		//                  ID = item.Field<int>("ID"),
		//                  Acronym = item.Field<string>("Acronym"),
		//                  Name = item.Field<string>("Name"),
		//                  CompanyName = item.Field<string>("CompanyName"), 
		//                  CompanyAcronym = item.Field<string>("CompanyAcronym"),
		//                  Longitude = item.Field<decimal>("Longitude"),
		//                  Latitude = item.Field<decimal>("Latitude"),
		//                  DeviceName = item.Field<string>("VendorName"),
		//                  ProtocolName = item.Field<string>("ProtocolName"),
		//                  Reporting = item.Field<bool>("Reporting"),
		//                  Active = item.Field<bool>("Active"),
		//                  Validated = item.Field<bool>("Validated"),
		//                  InProgress = item.Field<bool>("InProgress")
		//              }).ToList();
		//    return pmuList;
		//}
		//public static List<InterconnectionStatus> GetInterconnectionStatus()
		//{
		//    List<InterconnectionStatus> interConnectionStatusList = new List<InterconnectionStatus>();

		//    SqlCommand command = new SqlCommand("CompanyStatus");
		//    DataAccess obj = new DataAccess();
		//    DataSet resultSet = new DataSet();
		//    resultSet.Tables.Add(obj.GetDataTable(command, false));
		//    resultSet.Tables[0].TableName = "CurrentStatus";

		//    command = new SqlCommand("Select * From InterconnectionPmuSummary Order By PmuCount DESC, Interconnection");
		//    resultSet.Tables.Add(obj.GetDataTable(command, true));
		//    resultSet.Tables[1].TableName = "InterconnectionSummary";

		//    //resultSet.Relations.Add("InterconnectionSummary", resultSet.Tables["InterconnectionSummary"].Columns["Interconnection"],
		//    //                            resultSet.Tables["CurrentStatus"].Columns["Interconnection"]);

		//    interConnectionStatusList = (from item in resultSet.Tables["InterconnectionSummary"].AsEnumerable()
		//                                 select new InterconnectionStatus()
		//                                 {
		//                                     InterConnection = item.Field<string>("Interconnection"),
		//                                     TotalPmus = "Total " + item.Field<int>("PmuCount").ToString() + " PMUs",
		//                                     DisplayName = item.Field<string>("Description"),
		//                                     CompanyStatus = (from cs in resultSet.Tables["CurrentStatus"].AsEnumerable()
		//                                                      where cs.Field<string>("Interconnection") == item.Field<string>("Interconnection")
		//                                                      select new MemberStatus()
		//                                                      {
		//                                                          Name = cs.Field<string>("CompanyName"),
		//                                                          MeasuredLines = cs.Field<int>("MeasuredLines"),
		//                                                          TotalDevices = cs.Field<int>("PmuCount"),
		//                                                          ValidatedDevices = cs.Field<int>("ValidatedPmus"),
		//                                                          ReportingDevices = cs.Field<int>("ReportingPmus"),
		//                                                          Status = cs.Field<string>("Status")
		//                                                      }).ToList()
		//                                 }).ToList();

		//    return interConnectionStatusList;
		//}
		//public static List<PmuDistribution> GetPmuDistribution()
		//{
		//    List<PmuDistribution> pmuDistributionList = new List<PmuDistribution>();

		//    SqlCommand command = new SqlCommand("PmuStatistics");
		//    DataAccess obj = new DataAccess();
		//    DataTable resultTable = new DataTable();
		//    resultTable = obj.GetDataTable(command, false);

		//    pmuDistributionList = (from item in resultTable.AsEnumerable()
		//                           select new PmuDistribution()
		//                           {   Status = item.Field<string>("Status"),
		//                               EasternCount = item.Field<string>("Eastern"),
		//                               WesternCount = item.Field<string>("Western"),
		//                               TexasCount = item.Field<string>("Texas"),
		//                               QuebecCount = item.Field<string>("Quebec"),
		//                               AlaskanCount = item.Field<string>("Alaskan"),
		//                               HawaiiCount = item.Field<string>("Hawaii"),
		//                               Total = item.Field<int>("Total")
		//                           }).ToList();
		//    return pmuDistributionList;
		//}
		////public static List<Historian> GetHistorianList()
		////{
		////    List<Historian> historianList = new List<Historian>();
		////    SqlCommand command = new SqlCommand("Select *, Acronym + ': ' + Name As HistorianLongName From Historian Order By Name");
		////    DataAccess obj = new DataAccess();
		////    DataTable resultTable = new DataTable();
		////    resultTable = obj.GetDataTable(command, true);

		////    historianList = (from item in resultTable.AsEnumerable()
		////                     orderby item.Field<string>("Name")
		////                     select new Historian()
		////                     {
		////                         ID = item.Field<int>("ID"),
		////                         Acronym = item.Field<string>("Acronym"),
		////                         Name = item.Field<string>("Name"),
		////                         ConnectionString = item.Field<string>("ConnectionString"),
		////                         Description = item.Field<string>("Description"),
		////                         Enabled = item.Field<bool>("Enabled"),
		////                         TypeName = item.Field<string>("TypeName"),
		////                         AssemblyName = item.Field<string>("AssemblyName"),
		////                         HistorianLongName = item.Field<string>("HistorianLongName")
		////                     }).ToList();

		////    return historianList;
		////}
		//public static List<CalculatedMeasurement> GetCalculatedMeasurementList()
		//{
		//    List<CalculatedMeasurement> calculatedMeasurementList = new List<CalculatedMeasurement>();
		//    SqlCommand command = new SqlCommand("Select * From CalculatedMeasurement");
		//    DataAccess obj = new DataAccess();
		//    DataTable resultTable = new DataTable();
		//    resultTable = obj.GetDataTable(command, true);

		//    calculatedMeasurementList = (from item in resultTable.AsEnumerable()
		//                                 orderby item.Field<string>("Name")
		//                                 select new CalculatedMeasurement()
		//                                 {
		//                                     ID = item.Field<int>("ID"),
		//                                     Name = item.Field<string>("Name"),
		//                                     TypeName = item.Field<string>("TypeName"),
		//                                     AssemblyName = item.Field<string>("AssemblyName"),
		//                                     ConfigSection = item.Field<string>("ConfigSection"),
		//                                     OutputMeasurementsSql = item.Field<string>("OutputMeasurementsSql"),
		//                                     InputMeasurementsSql = item.Field<string>("InputMeasurementsSql"),
		//                                     MinimumInputMeasurements = item.Field<int>("MinimumInputMeasurements"),
		//                                     ExpectedFrameRate = item.Field<int>("ExpectedFrameRate"),
		//                                     //LagTime = item.Field<decimal>("LagTime"),
		//                                     //LeadTime = item.Field<decimal>("LeadTime"),
		//                                     Enabled = item.Field<bool>("Enabled")
		//                                 }).ToList();

		//    return calculatedMeasurementList;
		//}
		//public static List<OutputStream> GetOutputStreamList()
		//{
		//    List<OutputStream> outputStreamList = new List<OutputStream>();
		//    SqlCommand command = new SqlCommand("Select ID, Name, Type, ConnectionString, IsNull(PmuFilterSql, '') AS PmuFilterSql, IDCode, FrameRate, NominalFrequency, LagTime, LeadTime, Enabled From Concentrator");
		//    DataAccess obj = new DataAccess();
		//    DataTable resultTable = new DataTable();
		//    resultTable = obj.GetDataTable(command, true);

		//    outputStreamList = (from item in resultTable.AsEnumerable()
		//                        orderby item.Field<string>("Name")
		//                        select new OutputStream()
		//                        {
		//                            ID = item.Field<int>("ID"),
		//                            Name = item.Field<string>("Name"),
		//                            Type = item.Field<string>("Type"),
		//                            ConnectionString = item.Field<string>("ConnectionString"),
		//                            PmuFilterSql = item.Field<string>("PmuFilterSql"),
		//                            IDCode = item.Field<int>("IDCode"),
		//                            FrameRate = item.Field<int>("FrameRate"),
		//                            NominalFrequency = item.Field<int>("NominalFrequency"),
		//                            //LagTime = item.Field<decimal>("LagTime"),
		//                            //LeadTime = item.Field<decimal>("LeadTime"),
		//                            Enabled = item.Field<bool>("Enabled")
		//                        }).ToList();

		//    return outputStreamList;
		//}
		////public static Dictionary<int, string> GetCompanyList()
		////{
		////    Dictionary<int, string> companyList = new Dictionary<int, string>();
		////    SqlCommand command = new SqlCommand("Select ID, Name From Company Order By Name");
		////    DataAccess obj = new DataAccess();
		////    DataTable resultTable = new DataTable();
		////    resultTable = obj.GetDataTable(command, true);
		////    foreach (DataRow row in resultTable.Rows)
		////    {
		////        companyList.Add(Convert.ToInt32(row["ID"]), row["Name"].ToString());
		////    }
		////    return companyList;
		////}
		//public static Dictionary<int, string> GetVendorList()
		//{
		//    Dictionary<int, string> vendorList = new Dictionary<int, string>();
		//    SqlCommand command = new SqlCommand("Select ID, Description From VendorDevice Order By Description");
		//    DataAccess obj = new DataAccess();
		//    DataTable resultTable = new DataTable();
		//    resultTable = obj.GetDataTable(command, true);
		//    foreach (DataRow row in resultTable.Rows)
		//    {
		//        vendorList.Add(Convert.ToInt32(row["ID"]), row["Description"].ToString());
		//    }
		//    return vendorList;
		//}
		//public static Dictionary<int, string> GetProtocolList()
		//{
		//    Dictionary<int, string> protocolList = new Dictionary<int, string>();
		//    SqlCommand command = new SqlCommand("Select ID, Name From Protocol Order By Name");
		//    DataAccess obj = new DataAccess();
		//    DataTable resultTable = new DataTable();
		//    resultTable = obj.GetDataTable(command, true);
		//    foreach (DataRow row in resultTable.Rows)
		//    {
		//        protocolList.Add(Convert.ToInt32(row["ID"]), row["Name"].ToString());
		//    }
		//    return protocolList;
		//}
		//public static List<string> GetTransportProtocolList()
		//{
		//    List<string> transportProtocolList = new List<string>();
		//    transportProtocolList.Add("TCP");
		//    transportProtocolList.Add("UDP");
		//    transportProtocolList.Add("Serial");
		//    return transportProtocolList;
		//}
		//public static List<string> GetParityList()
		//{
		//    List<string> parityList = new List<string>();
		//    foreach (string parity in Enum.GetNames(typeof(Parity)))
		//    {
		//        parityList.Add(parity);
		//    }
		//    return parityList;
		//}
		//public static List<string> GetStopBitList()
		//{
		//    List<string> stopBitList = new List<string>();
		//    foreach (string stopBit in Enum.GetNames(typeof(StopBits)))
		//    {
		//        stopBitList.Add(stopBit);
		//    }
		//    return stopBitList;
		//}
		//public static Dictionary<string, string> GetTimeZonesList()
		//{
		//    Dictionary<string, string> timeZoneList = new Dictionary<string, string>();

		//    List<TimeZoneInfo> timeZoneInfoList = System.TimeZoneInfo.GetSystemTimeZones().ToList<TimeZoneInfo>();
		//    foreach (TimeZoneInfo timeZoneInfo in timeZoneInfoList)
		//    {
		//        timeZoneList.Add(timeZoneInfo.DisplayName, timeZoneInfo.StandardName);
		//    }			
		//    return timeZoneList;
		//}
		//public static List<StatusReport> GetStatusReportList()
		//{
		//    List<StatusReport> statusReportList = new List<StatusReport>();

		//    SqlCommand command = new SqlCommand("NaspiReportData");
		//    DataAccess obj = new DataAccess();
		//    DataSet resultSet = new DataSet();
		//    obj.GetDataSet(command, ref resultSet, false);

		//    //resultSet.Tables[0].TableName = "CompanyStatus";
		//    //resultSet.Tables[0].TableName = "PmuStatus";

		//    statusReportList = (from item in resultSet.Tables[0].AsEnumerable()
		//                        select new StatusReport()
		//                        {
		//                            ID = item.Field<int>("ID"),
		//                            Acronym = item.Field<string>("Acronym"),
		//                            CompanyName = item.Field<string>("CompanyName"),
		//                            Status = item.Field<string>("Status"),
		//                            PmusStatus = (from ps in resultSet.Tables[1].AsEnumerable()
		//                                          where ps.Field<int>("CompanyID") == item.Field<int>("ID")
		//                                          select new PmuStatus()
		//                                          {
		//                                              Acronym = ps.Field<string>("Acronym"),
		//                                              Name = ps.Field<string>("Name"),
		//                                              DeviceDescription = ps.Field<string>("DeviceDescription"),
		//                                              ProtocolName = ps.Field<string>("ProtocolName"),
		//                                              StatusColor = (
		//                                                            ps.Field<bool>("Validated") == false ? "Gray" :
		//                                                            ps.Field<bool>("Reporting") == false ? "Red" : "Green"
		//                                                            )
		//                                          }).ToList()
		//                        }).ToList();

		//    return statusReportList;
		//}
		#endregion
			
		/// <summary>
        /// Adds quotes or returns NULL for strings for proper database insertion.
        /// </summary>
        /// <param name="value">Value to quote or make NULL.</param>
        /// <returns>Quoted string if string is not null or empty; otherwise NULL.</returns>
		//public static string NullableQuote(string value)
		//{
		//    if (string.IsNullOrEmpty(value))
		//        return "NULL";

		//    return string.Concat("'", value, "'");
		//}

        /// <summary>
        /// Returns NULL for values that are null.
        /// </summary>
        /// <param name="value">Value to return or make NULL.</param>
		//public static string NullableValue<T>(T? value) where T : struct
		//{
		//    if (value.HasValue)
		//        return value.ToString();

		//    return "NULL";
		//}

		//public static string FormatedNodeID(Guid nodeID)
		//{
		//    string nodeString = "'" + nodeID.ToString() + "'";
		//    DataConnection connection = new DataConnection();
		//    Dictionary<string, string> settings = connection.Connection.ConnectionString.ParseKeyValuePairs();
		//    string setting;
		//    if (settings.TryGetValue("Provider", out setting))
		//        if (setting.StartsWith("Microsoft.Jet.OLEDB", StringComparison.CurrentCultureIgnoreCase))
		//            nodeString = "{" + nodeID.ToString() + "}";

		//    return nodeString;
		//}

		public static bool MasterNode(Guid nodeID)
		{
			bool isMaster = false;

			return isMaster;
		}

		public static List<string> GetTimeZones(bool isOptional)
		{
			List<string> timeZonesList = new List<string>();
			if (isOptional)
				timeZonesList.Add("Select Timezone");

			foreach (TimeZoneInfo tzi in TimeZoneInfo.GetSystemTimeZones())
			{
				if (!timeZonesList.Contains(tzi.StandardName))
					timeZonesList.Add(tzi.StandardName);
			}
			return timeZonesList;
		}

		public static Dictionary<string, int> GetVendorDeviceDistribution()
		{
			Dictionary<string, int> deviceDistribution = new Dictionary<string, int>();			
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = "Select * From VendorDeviceDistribution Order By VendorName";
			
			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());

			foreach (DataRow row in resultTable.Rows)
			{
				deviceDistribution.Add(row["VendorName"].ToString(), Convert.ToInt32(row["DeviceCount"]));
			}
			return deviceDistribution;
		}

		public static List<InterconnectionStatus> GetInterconnectionStatus()
		{
		    List<InterconnectionStatus> interConnectionStatusList = new List<InterconnectionStatus>();
			
			DataConnection connection = new DataConnection();
			DataSet resultSet = new DataSet();
			resultSet.Tables.Add(new DataTable("InterconnectionSummary"));
			resultSet.Tables.Add(new DataTable("MemberSummary"));
			
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = "Select InterconnectionName, Count(*) AS DeviceCount From DeviceDetail Group By InterconnectionName";
			resultSet.Tables["InterconnectionSummary"].Load(command.ExecuteReader());

			command.CommandText = "Select CompanyAcronym, CompanyName, InterconnectionName, Count(*) AS DeviceCount, Count(MeasuredLines) AS MeasuredLines " +
									"From DeviceDetail Group By CompanyAcronym, CompanyName, InterconnectionName";
			resultSet.Tables["MemberSummary"].Load(command.ExecuteReader());		

			interConnectionStatusList = (from item in resultSet.Tables["InterconnectionSummary"].AsEnumerable()
										 select new InterconnectionStatus()
										 {
											 InterConnection = item.Field<string>("InterconnectionName"),
											 TotalDevices = "Total " + item.Field<int>("DeviceCount").ToString() + " Devices",
											 MemberStatusList = (from cs in resultSet.Tables["MemberSummary"].AsEnumerable()
															  where cs.Field<string>("InterconnectionName") == item.Field<string>("InterconnectionName")
															  select new MemberStatus()
															  {
																  CompanyAcronym = cs.Field<string>("CompanyAcronym"),
																  CompanyName = cs.Field<string>("CompanyName"),
																  MeasuredLines = cs.Field<int>("MeasuredLines"),
																  TotalDevices = cs.Field<int>("DeviceCount")																  
															  }).ToList()
										 }).ToList();

		    return interConnectionStatusList;
		}

		#region " Manage Companies Code"

		public static List<Company> GetCompanyList()
		{
			List<Company> companyList = new List<Company>();
            DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = "SELECT ID, Acronym, MapAcronym, Name, URL, LoadOrder FROM Company ORDER BY LoadOrder";
			
			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());

			companyList = (from item in resultTable.AsEnumerable()
						   select new Company()
						   {
							   ID = item.Field<int>("ID"),
							   Acronym = item.Field<string>("Acronym"),
							   MapAcronym = item.Field<string>("MapAcronym"),
							   Name = item.Field<string>("Name"),
							   URL = item.Field<string>("URL"),
							   LoadOrder = item.Field<int>("LoadOrder")
						   }).ToList();

            connection.Dispose();

			return companyList;
		}

		public static Dictionary<int, string> GetCompanies(bool isOptional)
		{
			Dictionary<int, string> companyList = new Dictionary<int, string>();
			if (isOptional)
				companyList.Add(0, "Select Company");
            DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = "SELECT ID, Name FROM Company ORDER BY LoadOrder";

			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());

            int id;
            foreach (DataRow row in resultTable.Rows)
			{
                id = int.Parse(row["ID"].ToString());

                if (!companyList.ContainsKey(id))
                    companyList.Add(id, row["Name"].ToString());
			}

            connection.Dispose();
			return companyList;
		}

		public static string SaveCompany(Company company, bool isNew)
		{
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;

			if (isNew)
				command.CommandText = "INSERT INTO Company (Acronym, MapAcronym, Name, URL, LoadOrder) VALUES (@acronym, @mapAcronym, @name, @url, @loadOrder)";
			else
				command.CommandText = "UPDATE Company SET Acronym = @acronym, MapAcronym = @mapAcronym, Name = @name, URL = @url, LoadOrder = @loadOrder WHERE ID = @id";

			IDbDataParameter param = command.CreateParameter();
			param.ParameterName = "@acronym";
			param.Value = company.Acronym;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@mapAcronym";
			param.Value = company.MapAcronym;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@name";
			param.Value = company.Name;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@url";
			param.Value = company.URL;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@loadOrder";
			param.Value = company.LoadOrder;
			command.Parameters.Add(param);

			if (!isNew)
			{
				param = command.CreateParameter();
				param.ParameterName = "@id";
				param.Value = company.ID;
				command.Parameters.Add(param);
			}

			command.ExecuteNonQuery();
            connection.Dispose();
            return "Done!";
		}

		#endregion

        #region " Manage Historians Code"
		
		public static List<Historian> GetHistorianList(Guid nodeID)
		{
			List<Historian> historianList = new List<Historian>();
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			if (MasterNode(nodeID) || nodeID == Guid.Empty)			
				command.CommandText = "Select * From HistorianDetail Order By LoadOrder";			
			else
			{
				command.CommandText = "Select * From HistorianDetail Where NodeID = @nodeID Order By LoadOrder";
				IDbDataParameter param = command.CreateParameter();
				param.ParameterName = "@nodeID";
				param.Value = nodeID;
				command.Parameters.Add(param);
			}

			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());		
			historianList = (from item in resultTable.AsEnumerable()
							 select new Historian()
							 {
								 NodeID = item.Field<Guid>("NodeID"),
								 ID = item.Field<int>("ID"),
								 Acronym = item.Field<string>("Acronym"),
								 Name = item.Field<string>("Name"),
								 ConnectionString = item.Field<string>("ConnectionString"),
								 Description = item.Field<string>("Description"),
								 Enabled = item.Field<bool>("Enabled"),
								 TypeName = item.Field<string>("TypeName"),
								 AssemblyName = item.Field<string>("AssemblyName"),
								 NodeName = item.Field<string>("NodeName")
							 }).ToList();

			connection.Dispose();
			return historianList;
		}

		public static Dictionary<int, string> GetHistorians(bool enabledOnly, bool isOptional)
		{
			Dictionary<int, string> historianList = new Dictionary<int, string>();
			if (isOptional)
				historianList.Add(0, "Select Historian");
			string query = "Select ID, Acronym From Historian";
			if (enabledOnly)
				query += " Where Enabled = '1'";
			query += " Order By LoadOrder";

			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = query;
			
			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());
			foreach (DataRow row in resultTable.Rows)
			{
				if (!historianList.ContainsKey(Convert.ToInt32(row["ID"])))
					historianList.Add(Convert.ToInt32(row["ID"]), row["Acronym"].ToString());
			}
			connection.Dispose();
			return historianList;
		}

		public static string SaveHistorian(Historian historian, bool isNew)
		{
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			if (isNew)
				command.CommandText = "Insert Into Historian (NodeID, Acronym, Name, AssemblyName, TypeName, ConnectionString, IsLocal, Description, LoadOrder, Enabled) Values " +
					"(@nodeID, @acronym, @name, @assemblyName, @typeName, @connectionString, @isLocal, @description, @loadOrder, @enabled)";
			else
				command.CommandText = "Update Historian Set NodeID = @nodeID, Acronym = @acronym, Name = @name, AssemblyName = @assemblyName, TypeName = @typeName, " +
					"ConnectionString = @connectionString, IsLocal = @isLocal, Description = @description, LoadOrder = @loadOrder, Enabled = @enabled Where ID = @id";

			IDbDataParameter param = command.CreateParameter();
			param.ParameterName = "@nodeID";
			param.Value = historian.NodeID;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@acronym";
			param.Value = historian.Acronym;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@name";
			param.Value = historian.Name;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@assemblyName";
			param.Value = historian.AssemblyName;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@typeName";
			param.Value = historian.TypeName;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@connectionString";
			param.Value = historian.ConnectionString;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@isLocal";
			param.Value = historian.IsLocal;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@description";
			param.Value = historian.Description;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@loadOrder";
			param.Value = historian.LoadOrder;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@enabled";
			param.Value = historian.Enabled;
			command.Parameters.Add(param);

			if (!isNew)
			{
				param = command.CreateParameter();
				param.ParameterName = "@id";
				param.Value = historian.ID;
				command.Parameters.Add(param);
			}

			command.ExecuteNonQuery();
			connection.Dispose();
			return "Done!";
		}

        #endregion

        #region " Manage Nodes Code"
		
		public static List<Node> GetNodeList()
		{
			List<Node> nodeList = new List<Node>();			
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = "Select * From NodeDetail Order By LoadOrder";
			
			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());
			nodeList = (from item in resultTable.AsEnumerable()
						select new Node()
						{
							ID = item.Field<Guid>("ID"),
							Name = item.Field<string>("Name"),
							CompanyID = item.Field<int>("CompanyID"),
							Longitude = item.Field<decimal>("Longitude"),
							Latitude = item.Field<decimal>("Latitude"),
							Description = item.Field<string>("Description"),
							Image = item.Field<string>("Image"),
							Master = item.Field<bool>("Master"),
							LoadOrder = item.Field<int>("LoadOrder"),
							Enabled = item.Field<bool>("Enabled"),
							CompanyName = item.Field<string>("CompanyName")
						}).ToList();

			connection.Dispose();
			return nodeList;
		}
		
		public static Dictionary<Guid, string> GetNodes(bool enabledOnly, bool isOptional)
		{
			Dictionary<Guid, string> nodeList = new Dictionary<Guid, string>();
			if (isOptional)
				nodeList.Add(Guid.Empty, "Select Node");
			string query = "Select ID, Name From Node";
			if (enabledOnly)
				query += " Where Enabled = '1'";
			query += " Order By LoadOrder";
						
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = query;

			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());

			foreach (DataRow row in resultTable.Rows)
			{
				if (!nodeList.ContainsKey(new Guid(row["ID"].ToString())))
					nodeList.Add(new Guid(row["ID"].ToString()), row["Name"].ToString());
			}
			connection.Dispose();
			return nodeList;
		}
		
		public static string SaveNode(Node node, bool isNew)
		{
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;

			if (isNew)
				command.CommandText = "Insert Into Node (Name, CompanyID, Longitude, Latitude, Description, Image, Master, LoadOrder, Enabled) Values (@name, @companyID, @longitude, @latitude, @description, @image, @master, @loadOrder, @enabled)";
			else
				command.CommandText = "Update Node Set Name = @name, CompanyID = @companyID, Longitude = @longitude, Latitude = @latitude, Description = @description, Image = @image, Master = @master, LoadOrder = @loadOrder, Enabled = @enabled Where ID = @id";

			IDbDataParameter param = command.CreateParameter();
			param.ParameterName = "@name";
			param.Value = node.Name;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@companyID";
			param.Value = node.CompanyID ?? (object)DBNull.Value;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@longitude";
			param.Value = node.Longitude ?? (object)DBNull.Value;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@latitude";
			param.Value = node.Latitude ?? (object)DBNull.Value;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@description";
			param.Value = node.Description;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@image";
			param.Value = node.Image;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@master";
			param.Value = node.Master;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@loadOrder";
			param.Value = node.LoadOrder;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@enabled";
			param.Value = node.Enabled;
			command.Parameters.Add(param);

			if (!isNew)
			{
				param = command.CreateParameter();
				param.ParameterName = "@id";
				param.Value = node.ID;
				command.Parameters.Add(param);
			}

			command.ExecuteNonQuery();		
			connection.Dispose();
			return "Done!";
		}
        
		#endregion
		
        #region " Manage Vendors Code"
		
		public static List<Vendor> GetVendorList()
		{
			List<Vendor> vendorList = new List<Vendor>();			
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = "Select * FROM VendorDetail Order By Name";
			
			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());
			vendorList = (from item in resultTable.AsEnumerable()
						  select new Vendor()
						  {
							  ID = item.Field<int>("ID"),
							  Acronym = item.Field<string>("Acronym"),
							  Name = item.Field<string>("Name"),
							  PhoneNumber = item.Field<string>("PhoneNumber"),
							  ContactEmail = item.Field<string>("ContactEmail"),
							  URL = item.Field<string>("URL")
						  }).ToList();

			connection.Dispose();
			return vendorList;
		}
		
		public static Dictionary<int, string> GetVendors(bool isOptional)
		{
			Dictionary<int, string> vendorList = new Dictionary<int, string>();
			if (isOptional)
				vendorList.Add(0, "Select Vendor");
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = "Select ID, Name From Vendor Order By Name";

			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());

			foreach (DataRow row in resultTable.Rows)
			{
				if (!vendorList.ContainsKey(Convert.ToInt32(row["ID"])))
					vendorList.Add(Convert.ToInt32(row["ID"]), row["Name"].ToString());
			}
			connection.Dispose();
			return vendorList;
		}
		
		public static string SaveVendor(Vendor vendor, bool isNew)
		{
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			if (isNew)
				command.CommandText = "Insert Into Vendor (Acronym, Name, PhoneNumber, ContactEmail, URL) Values (@acronym, @name, @phoneNumber, @contactEmail, @url)";
			else
				command.CommandText = "Update Vendor Set Acronym = @acronym, Name = @name, PhoneNumber = @phoneNumber, ContactEmail = @contactEmail, URL = @url Where ID = @id";

			IDbDataParameter param = command.CreateParameter();
			param.ParameterName = "@acronym";
			param.Value = vendor.Acronym;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@name";
			param.Value = vendor.Name;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@phoneNumber";
			param.Value = vendor.PhoneNumber;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@contactEmail";
			param.Value = vendor.ContactEmail;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@url";
			param.Value = vendor.URL;
			command.Parameters.Add(param);

			command.ExecuteNonQuery();
			connection.Dispose();
			return "Done!";
		}
        
		#endregion

        #region " Manage Vendor Devices Code"
		
		public static List<VendorDevice> GetVendorDeviceList()
		{
			List<VendorDevice> vendorDeviceList = new List<VendorDevice>();			
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = "Select * From VendorDeviceDetail Order By Name";

			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());
			vendorDeviceList = (from item in resultTable.AsEnumerable()
								select new VendorDevice()
								{
									ID = item.Field<int>("ID"),
									VendorID = item.Field<int>("VendorID"),
									Name = item.Field<string>("Name"),
									Description = item.Field<string>("Description"),
									URL = item.Field<string>("URL"),
									VendorName = item.Field<string>("VendorName")
								}).ToList();
			connection.Dispose();
			return vendorDeviceList;
		}
		
		public static string SaveVendorDevice(VendorDevice vendorDevice, bool isNew)
		{
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			if (isNew)
				command.CommandText = "Insert Into VendorDevice (VendorID, Name, Description, URL) Values (@vendorID, @name, @description, @url)";
			else
				command.CommandText = "Update VendorDevice Set VendorID = @vendorID, Name = @name, Description = @description, URL = @url Where ID = @id";

			IDbDataParameter param = command.CreateParameter();
			param.ParameterName = "@vendorID";
			param.Value = vendorDevice.VendorID;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@name";
			param.Value = vendorDevice.Name;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@description";
			param.Value = vendorDevice.Description;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@url";
			param.Value = vendorDevice.URL;
			command.Parameters.Add(param);

			if (!isNew)
			{
				param = command.CreateParameter();
				param.ParameterName = "@id";
				param.Value = vendorDevice.ID;
				command.Parameters.Add(param);
			}

			command.ExecuteNonQuery();
			connection.Dispose();
			return "Done!";
		}

		public static Dictionary<int, string> GetVendorDevices(bool isOptional)
		{
			Dictionary<int, string> vendorDeviceList = new Dictionary<int, string>();
			if (isOptional)
				vendorDeviceList.Add(0, "Select Vendor Device");
			
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = "Select ID, Name From VendorDevice Order By Name";

			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());

			foreach (DataRow row in resultTable.Rows)
			{
				if (!vendorDeviceList.ContainsKey(Convert.ToInt32(row["ID"])))
					vendorDeviceList.Add(Convert.ToInt32(row["ID"]), row["Name"].ToString());
			}
			connection.Dispose();
			return vendorDeviceList;
		}

		#endregion

		#region " Manage Device Code"
				
		public static List<Device> GetDeviceList(Guid nodeID)
		{
			List<Device> deviceList = new List<Device>();
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;	
			if (MasterNode(nodeID) || nodeID == Guid.Empty)
				command.CommandText = "Select * From DeviceDetail Order By LoadOrder";										
			else
			{
				command.CommandText = "Select * From DeviceDetail Where NodeID = @nodeID Order By LoadOrder";				
				IDbDataParameter param = command.CreateParameter();
				param.ParameterName = "@nodeID";				
				param.Value = nodeID;
				command.Parameters.Add(param);
			}

			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());			
			deviceList = (from item in resultTable.AsEnumerable()
						  select new Device()
						  {
							  NodeID = item.Field<Guid>("NodeID"),
							  ID = item.Field<int>("ID"),
							  ParentID = item.Field<int?>("ParentID"),
							  Acronym = item.Field<string>("Acronym"),
							  Name = item.Field<string>("Name"),
							  IsConcentrator = item.Field<bool>("IsConcentrator"),
							  CompanyID = item.Field<int?>("CompanyID"),
							  HistorianID = item.Field<int?>("HistorianID"),
							  AccessID = item.Field<int>("AccessID"),
							  VendorDeviceID = item.Field<int?>("VendorDeviceID"),
							  ProtocolID = item.Field<int?>("ProtocolID"),
							  Longitude = item.Field<decimal?>("Longitude"),
							  Latitude = item.Field<decimal?>("Latitude"),
							  InterconnectionID = item.Field<int?>("InterconnectionID"),
							  ConnectionString = item.Field<string>("ConnectionString"),
							  TimeZone = item.Field<string>("TimeZone"),
							  TimeAdjustmentTicks = item.Field<long>("TimeAdjustmentTicks"),
							  DataLossInterval = item.Field<double>("DataLossInterval"),
							  ContactList = item.Field<string>("ContactList"),
							  MeasuredLines = item.Field<int?>("MeasuredLines"),
							  LoadOrder = item.Field<int>("LoadOrder"),
							  Enabled = item.Field<bool>("Enabled"),
							  CompanyName = item.Field<string>("CompanyName"),
							  HistorianAcronym = item.Field<string>("HistorianAcronym"),
							  VendorDeviceName = item.Field<string>("VendorDeviceName"),
							  ProtocolName = item.Field<string>("ProtocolName"),
							  InterconnectionName = item.Field<string>("InterconnectionName"),
							  NodeName = item.Field<string>("NodeName"),
							  ParentAcronym = item.Field<string>("ParentAcronym")
						  }).ToList();
			connection.Dispose();
			return deviceList;
		}

		public static string SaveDevice(Device device, bool isNew)
		{
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();

			if (isNew)
				command.CommandText = "Insert Into Device (NodeID, ParentID, Acronym, Name, IsConcentrator, CompanyID, HistorianID, AccessID, VendorDeviceID, ProtocolID, Longitude, Latitude, InterconnectionID, ConnectionString, TimeZone, TimeAdjustmentTicks, " +
					"DataLossInterval, ContactList, MeasuredLines, LoadOrder, Enabled) Values (@nodeID, @parentID, @acronym, @name, @isConcentrator, @companyID, @historianID, @accessID, @vendorDeviceID, @protocolID, @longitude, @latitude, @interconnectionID, " +
					"@connectionString, @timezone, @timeAdjustmentTicks, @dataLossInterval, @contactList, @measuredLines, @loadOrder, @enabled)";
			else
				command.CommandText = "Update Device Set NodeID = @nodeID, ParentID = @parentID, Acronym = @acronym, Name = @name, IsConcentrator = @isConcentrator, CompanyID = @companyID, HistorianID = @historianID, AccessID = @accessID, VendorDeviceID = @vendorDeviceID, " +
					"ProtocolID = @protocolID, Longitude = @longitude, Latitude = @latitude, InterconnectionID = @interconnectionID, ConnectionString = @connectionString, TimeZone = @timezone, TimeAdjustmentTicks = @timeAdjustmentTicks, DataLossInterval = @dataLossInterval, " +
					"ContactList = @contactList, MeasuredLines = @measuredLines, LoadOrder = @loadOrder, Enabled = @enabled WHERE ID = @id";

			command.CommandType = CommandType.Text;
			
			IDbDataParameter param = command.CreateParameter();
			param.ParameterName = "@nodeID";			
			param.Value = device.NodeID;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@parentID";			
			param.Value = device.ParentID ?? (object)DBNull.Value;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@acronym";
			param.Value = device.Acronym;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@name";
			param.Value = device.Name;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@isConcentrator";
			param.Value = device.IsConcentrator;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@companyID";
			param.Value = device.CompanyID;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@historianID";
			param.Value = device.HistorianID ?? (object)DBNull.Value;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@accessID";
			param.Value = device.AccessID;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@vendorDeviceID";
			param.Value = device.VendorDeviceID;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@protocolID";
			param.Value = device.ProtocolID;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@longitude";
			param.Value = device.Longitude ?? (object)DBNull.Value;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@latitude";
			param.Value = device.Latitude ?? (object)DBNull.Value;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@interconnectionID";
			param.Value = device.InterconnectionID ?? (object)DBNull.Value;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@connectionString";
			param.Value = device.ConnectionString;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@timezone";
			param.Value = device.TimeZone;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@timeAdjustmentTicks";
			param.Value = device.TimeAdjustmentTicks;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@dataLossInterval";
			param.Value = device.DataLossInterval;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@contactList";
			param.Value = device.ContactList;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@measuredLines";
			param.Value = device.MeasuredLines ?? (object)DBNull.Value;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@loadOrder";
			param.Value = device.LoadOrder;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@enabled";
			param.Value = device.Enabled;
			command.Parameters.Add(param);

			if (!isNew)
			{
				param = command.CreateParameter();
				param.ParameterName = "@id";
				param.Value = device.ID;
				command.Parameters.Add(param);
			}

			command.ExecuteNonQuery();			
			connection.Dispose();
			return "Done";			
		}

		public static Dictionary<int, string> GetDevices(bool concentratorOnly, bool isOptional)
		{
			Dictionary<int, string> deviceList = new Dictionary<int, string>();
			if (isOptional)
				deviceList.Add(0, "Select Concentrator");

			string query = "Select ID, Acronym From Device";
			if (concentratorOnly)
				query += " Where IsConcentrator = '1'";
			query += " Order By LoadOrder";

			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = query;
			
			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());

			foreach (DataRow row in resultTable.Rows)
			{
				if (!deviceList.ContainsKey(Convert.ToInt32(row["ID"])))
					deviceList.Add(Convert.ToInt32(row["ID"]), row["Acronym"].ToString());
			}
			connection.Dispose();
			return deviceList;
		}

		public static Device GetDeviceByDeviceID(int deviceID)
		{
			Device device = new Device();
			device = (from item in GetDeviceList(Guid.Empty)
					  where item.ID == deviceID
					  select item).ToList()[0];			
			return device;
		}

		#endregion

		#region " Manage Other Devices"

		public static List<OtherDevice> GetOtherDeviceList()
		{
			List<OtherDevice> otherDeviceList = new List<OtherDevice>();
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = "Select * From OtherDeviceDetail Order By Acronym, Name";

			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());
			otherDeviceList = (from item in resultTable.AsEnumerable()
							   select new OtherDevice()
							   {
									ID = item.Field<int>("ID"),
									Acronym = item.Field<string>("Acronym"),
									Name = item.Field<string>("Name"),
									IsConcentrator = item.Field<bool>("IsConcentrator"),
									CompanyID = item.Field<int?>("CompanyID"),
									VendorDeviceID = item.Field<int?>("VendorDeviceID"),
									Longitude = item.Field<decimal?>("Longitude"),
									Latitude = item.Field<decimal?>("Latitude"),
									InterconnectionID = item.Field<int?>("InterconnectionID"),
									Planned = item.Field<bool>("Planned"),
									Desired = item.Field<bool>("Desired"),
									InProgress = item.Field<bool>("InProgress"),
									CompanyName = item.Field<string>("CompanyName"),
									VendorDeviceName = item.Field<string>("VendorDeviceName"),
									InterconnectionName = item.Field<string>("InterconnectionName")
							   }).ToList();
			connection.Dispose();
			return otherDeviceList;
		}

		public static string SaveOtherDevice(OtherDevice otherDevice, bool isNew)
		{
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			if (isNew)
				command.CommandText = "Insert Into OtherDevice (Acronym, Name, IsConcentrator, CompanyID, VendorDeviceID, Longitude, Latitude, InterconnectionID, Planned, Desired, InProgress) Values " +
					"(@acronym, @name, @isConcentrator, @companyID, @vendorDeviceID, @longitude, @latitude, @interconnectionID, @planned, @desired, @inProgress)";
			else
				command.CommandText = "Update OtherDevice Set Acronym = @acronym, Name = @name, IsConcentrator = @isConcentrator, CompanyID = @companyID, VendorDeviceID = @vendorDeviceID, Longitude = @longitude, " +
					"Latitude = @latitude, InterconnectionID = @interconnectionID, Planned = @planned, Desired = @desired, InProgress = @inProgress Where ID = @id";

			IDbDataParameter param = command.CreateParameter();
			param.ParameterName = "@acronym";
			param.Value = otherDevice.Acronym;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@name";
			param.Value = otherDevice.Name;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@isConcentrator";
			param.Value = otherDevice.IsConcentrator;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@companyID";
			param.Value = otherDevice.CompanyID ?? (object)DBNull.Value;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@vendorDeviceID";
			param.Value = otherDevice.VendorDeviceID ?? (object)DBNull.Value;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@longitude";
			param.Value = otherDevice.Longitude ?? (object)DBNull.Value;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@latitude";
			param.Value = otherDevice.Latitude ?? (object)DBNull.Value;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@interconnectionID";
			param.Value = otherDevice.InterconnectionID ?? (object)DBNull.Value;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@planned";
			param.Value = otherDevice.Planned;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@desired";
			param.Value = otherDevice.Desired;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@inProgress";
			param.Value = otherDevice.InProgress;
			command.Parameters.Add(param);

			if (!isNew)
			{
				param = command.CreateParameter();
				param.ParameterName = "@id";
				param.Value = otherDevice.ID;
				command.Parameters.Add(param);
			}

			command.ExecuteScalar();
			connection.Dispose();
			return "Done!";
		}

		public static OtherDevice GetOtherDeviceByDeviceID(int deviceID)
		{
			OtherDevice otherDevice = new OtherDevice();
			otherDevice = (from item in GetOtherDeviceList()
						   where item.ID == deviceID
						   select item).ToList()[0];
			return otherDevice;
		}

		#endregion

		#region " Manage Interconnections Code"

		public static Dictionary<int, string> GetInterconnections(bool isOptional)
		{
			Dictionary<int, string> interconnectionList = new Dictionary<int, string>();
			if (isOptional)
				interconnectionList.Add(0, "Select Interconnection");
						
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = "Select ID, Name From Interconnection Order By LoadOrder";
			
			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());

			foreach (DataRow row in resultTable.Rows)
			{
				if (!interconnectionList.ContainsKey(Convert.ToInt32(row["ID"])))
					interconnectionList.Add(Convert.ToInt32(row["ID"]), row["Name"].ToString());
			}
			connection.Dispose();
			return interconnectionList;
		}

		#endregion

		#region " Manage Protocols Code"

		public static Dictionary<int, string> GetProtocols(bool isOptional)
		{
			Dictionary<int, string> protocolList = new Dictionary<int, string>();
			if (isOptional)
				protocolList.Add(0, "Select Protocol");
			
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = "Select ID, Name From Protocol Order By Name";
			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());

			foreach (DataRow row in resultTable.Rows)
			{
				if (!protocolList.ContainsKey(Convert.ToInt32(row["ID"])))
					protocolList.Add(Convert.ToInt32(row["ID"]), row["Name"].ToString());
			}

			connection.Dispose();
			return protocolList;
		}

		#endregion

		#region " Manage Calculated Measurements"

		public static List<CalculatedMeasurement> GetCalculatedMeasurementList(Guid nodeID)
		{
			List<CalculatedMeasurement> calculatedMeasurementList = new List<CalculatedMeasurement>();
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			if (MasterNode(nodeID) || nodeID == Guid.Empty)
				command.CommandText = "Select * From CalculatedMeasurementDetail Order By LoadOrder";
			else
			{
				command.CommandText = "Select * From CalculatedMeasurementDetail Where NodeID = @nodeID Order By LoadOrder";
				IDbDataParameter param = command.CreateParameter();
				param.ParameterName = "@nodeID";
				param.Value = nodeID;
				command.Parameters.Add(param);
			}

			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());
			calculatedMeasurementList = (from item in resultTable.AsEnumerable()
										 select new CalculatedMeasurement()
										 {
											 NodeId = item.Field<Guid>("NodeID"),
											 ID = item.Field<int>("ID"),
											 Acronym = item.Field<string>("Acronym"),
											 Name = item.Field<string>("Name"),
											 AssemblyName = item.Field<string>("AssemblyName"),
											 TypeName = item.Field<string>("TypeName"),
											 ConnectionString = item.Field<string>("ConnectionString"),
											 ConfigSection = item.Field<string>("ConfigSection"),
											 InputMeasurements = item.Field<string>("InputMeasurements"),
											 OutputMeasurements = item.Field<string>("OutputMeasurements"),
											 MinimumMeasurementsToUse = item.Field<int>("MinimumMeasurementsToUse"),
											 FramesPerSecond = item.Field<int>("FramesPerSecond"),
											 LagTime = item.Field<double>("LagTime"),
											 LeadTime = item.Field<double>("LeadTime"),
											 UseLocalClockAsRealTime = item.Field<bool>("UseLocalClockAsRealTime"),
											 AllowSortsByArrival = item.Field<bool>("AllowSortsByArrival"),
											 LoadOrder = item.Field<int>("LoadOrder"),
											 Enabled = item.Field<bool>("Enabled"),
											 NodeName = item.Field<string>("NodeName")
										 }).ToList();

			connection.Dispose();
			return calculatedMeasurementList;
		}

		public static string SaveCalculatedMeasurement(CalculatedMeasurement calculatedMeasurement, bool isNew)
		{
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;

			if (isNew)
				command.CommandText = "Insert Into CalculatedMeasurement (NodeID, Acronym, Name, AssemblyName, TypeName, ConnectionString, ConfigSection, InputMeasurements, OutputMeasurements, MinimumMeasurementsToUse, FramesPerSecond, LagTime, LeadTime, " +
					"UseLocalClockAsRealTime, AllowSortsByArrival, LoadOrder, Enabled) Values (@nodeID, @acronym, @name, @assemblyName, @typeName, @connectionString, @configSection, @inputMeasurements, @outputMeasurements, @minimumMeasurementsToUse, " +
					"@framesPerSecond, @lagTime, @leadTime, @useLocalClockAsRealTime, @allowSortsByArrival, @loadOrder, @enabled)";
			else
				command.CommandText = "Update CalculatedMeasurement Set NodeID = @nodeID, Acronym = @acronym, Name = @name, AssemblyName = @assemblyName, TypeName = @typeName, ConnectionString = @connectionString, ConfigSection = @configSection, " +
					"InputMeasurements = @inputMeasurements, OutputMeasurements = @outputMeasurements, MinimumMeasurementsToUse = @minimumMeasurementsToUse, FramesPerSecond = @framesPerSecond, LagTime = @lagTime, LeadTime = @leadTime, " +
					"UseLocalClockAsRealTime = @useLocalClockAsRealTime, AllowSortsByArrival = @allowSortsByArrival, LoadOrder = @loadOrder, Enabled = @enabled Where ID = @id";

			IDbDataParameter param = command.CreateParameter();
			param.ParameterName = "@nodeID";
			param.Value = calculatedMeasurement.NodeId;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@acronym";
			param.Value = calculatedMeasurement.Acronym;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@name";
			param.Value = calculatedMeasurement.Name;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@assemblyName";
			param.Value = calculatedMeasurement.AssemblyName;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@typeName";
			param.Value = calculatedMeasurement.TypeName;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@connectionString";
			param.Value = calculatedMeasurement.ConnectionString;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@configSection";
			param.Value = calculatedMeasurement.ConfigSection;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@inputMeasurements";
			param.Value = calculatedMeasurement.InputMeasurements;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@outputMeasurements";
			param.Value = calculatedMeasurement.OutputMeasurements;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@minimumMeasurementsToUse";
			param.Value = calculatedMeasurement.MinimumMeasurementsToUse;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@framesPerSecond";
			param.Value = calculatedMeasurement.FramesPerSecond;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@lagTime";
			param.Value = calculatedMeasurement.LagTime;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@leadTime";
			param.Value = calculatedMeasurement.LeadTime;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@useLocalClockAsRealTime";
			param.Value = calculatedMeasurement.UseLocalClockAsRealTime;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@allowSortsByArrival";
			param.Value = calculatedMeasurement.AllowSortsByArrival;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@loadOrder";
			param.Value = calculatedMeasurement.LoadOrder;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@enabled";
			param.Value = calculatedMeasurement.Enabled;
			command.Parameters.Add(param);

			if (!isNew)
			{
				param = command.CreateParameter();
				param.ParameterName = "@id";
				param.Value = calculatedMeasurement.ID;
				command.Parameters.Add(param);
			}
			command.ExecuteNonQuery();			
			connection.Dispose();
			return "Done!";
		}

		#endregion

		#region " Manage Custom Adapters Code"

		public static List<Adapter> GetAdapterList(bool enabledOnly, AdapterType adapterType, Guid nodeID)
		{
			List<Adapter> adapterList = new List<Adapter>();
			string viewName;
			if (adapterType == AdapterType.Action)
				viewName = "CustomActionAdapterDetail";
			else if (adapterType == AdapterType.Input)
				viewName = "CustomInputAdapterDetail";
			else
				viewName = "CustomOutputAdapterDetail";

			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			if (MasterNode(nodeID) || nodeID == Guid.Empty)
				command.CommandText = "Select * From " + viewName + " Order By LoadOrder";
			else
			{
				command.CommandText = "Select * From " + viewName + " Where NodeID = @nodeID Order By LoadOrder";
				IDbDataParameter param = command.CreateParameter();
				param.ParameterName = "@nodeID";
				param.Value = nodeID;
				command.Parameters.Add(param);
			}

			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());
			adapterList = (from item in resultTable.AsEnumerable()
						   select new Adapter()
						   {
							   NodeID = item.Field<Guid>("NodeID"),
							   ID = item.Field<int>("ID"),
							   AdapterName = item.Field<string>("AdapterName"),
							   AssemblyName = item.Field<string>("AssemblyName"),
							   TypeName = item.Field<string>("TypeName"),
							   ConnectionString = item.Field<string>("ConnectionString"),
							   LoadOrder = item.Field<int>("LoadOrder"),
							   Enabled = item.Field<bool>("Enabled"),
							   NodeName = item.Field<string>("NodeName"),
							   adapterType = adapterType
						   }).ToList();
			connection.Dispose();
			return adapterList;
		}

		public static string SaveAdapter(Adapter adapter, bool isNew)
		{
			string tableName;
			AdapterType adapterType = adapter.adapterType;

			if (adapterType == AdapterType.Input)
				tableName = "CustomInputAdapter";
			else if (adapterType == AdapterType.Action)
				tableName = "CustomActionAdapter";
			else
				tableName = "CustomOutputAdapter";

			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;

			if (isNew)
				command.CommandText = "Insert Into " + tableName + " (NodeID, AdapterName, AssemblyName, TypeName, ConnectionString, LoadOrder, Enabled) Values " +
					"(@nodeID, @adapterName, @assemblyName, @typeName, @connectionString, @loadOrder, @enabled)";
			else
				command.CommandText = "Update " + tableName + " Set NodeID = @nodeID, AdapterName = @adapterName, AssemblyName = @assemblyName, TypeName = @typeName, " +
					"ConnectionString = @connectionString, LoadOrder = @loadOrder, Enabled = @enabled Where ID = @id";

			IDbDataParameter param = command.CreateParameter();
			param.ParameterName = "@nodeID";
			param.Value = adapter.NodeID;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@adapterName";
			param.Value = adapter.AdapterName;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@assemblyName";
			param.Value = adapter.AssemblyName;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@typeName";
			param.Value = adapter.TypeName;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@connectionString";
			param.Value = adapter.ConnectionString;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@loadOrder";
			param.Value = adapter.LoadOrder;
			command.Parameters.Add(param);

			param = command.CreateParameter();
			param.ParameterName = "@enabled";
			param.Value = adapter.Enabled;
			command.Parameters.Add(param);

			if (!isNew)
			{
				param = command.CreateParameter();
				param.ParameterName = "@id";
				param.Value = adapter.ID;
				command.Parameters.Add(param);
			}

			command.ExecuteNonQuery();						
			connection.Dispose();
			return "Done!";
		}

		public static List<IaonTree> GetIaonTreeData()
		{
			List<IaonTree> iaonTreeList = new List<IaonTree>();
			DataTable rootNodesTable = new DataTable();			
			rootNodesTable.Columns.Add(new DataColumn("AdapterType", Type.GetType("System.String")));

			DataRow row;			
			row = rootNodesTable.NewRow();
			row["AdapterType"] = "Input Adapters";
			rootNodesTable.Rows.Add(row);

			row = rootNodesTable.NewRow();
			row["AdapterType"] = "Action Adapters";
			rootNodesTable.Rows.Add(row);

			row = rootNodesTable.NewRow();
			row["AdapterType"] = "Output Adapters";
			rootNodesTable.Rows.Add(row);

			DataSet resultSet = new DataSet();
			resultSet.Tables.Add(rootNodesTable);

			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = "Select * From IaonTreeView";
			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());
			resultSet.Tables.Add(resultTable.Copy());
			resultSet.Tables[0].TableName = "RootNodesTable";
			resultSet.Tables[1].TableName = "AdapterData";
					
			iaonTreeList = (from item in resultSet.Tables["RootNodesTable"].AsEnumerable()
							select new IaonTree()
							{
								AdapterType = item.Field<string>("AdapterType"),
								AdapterList = (from obj in resultSet.Tables["AdapterData"].AsEnumerable()
											   where obj.Field<string>("AdapterType") == item.Field<string>("AdapterType")
											   select new Adapter()
											   {
												   NodeID = obj.Field<Guid>("NodeID"),
												   ID = obj.Field<int>("ID"),
												   AdapterName = obj.Field<string>("AdapterName"),
												   AssemblyName = obj.Field<string>("AssemblyName"),
												   TypeName = obj.Field<string>("TypeName"),
												   ConnectionString = obj.Field<string>("ConnectionString")
											   }).ToList()
							}).ToList();
			
			connection.Dispose();
			return iaonTreeList;
		}

		#endregion

		#region " Manage Map Data"

		public static List<MapData> GetMapData(MapType mapType)
		{
			List<MapData> mapDataList = new List<MapData>();			
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = "Select * From MapData";

			if (mapType == MapType.Active)
				command.CommandText = "Select * From MapData Where DeviceType = 'Device'";
			
			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());

			if (mapType == MapType.Active)
				mapDataList = (from item in resultTable.AsEnumerable()
							   select new MapData()
							   {
								   NodeID = item.Field<Guid>("NodeID"),
								   ID = item.Field<int>("ID"),
								   Acronym = item.Field<string>("Acronym"),
								   Name = item.Field<string>("Name"),
								   CompanyMapAcronym = item.Field<string>("CompanyMapAcronym"),
								   CompanyName = item.Field<string>("CompanyName"),
								   VendorDeviceName = item.Field<string>("VendorDeviceName"),
								   Longitude = item.Field<decimal?>("Longitude"),
								   Latitude = item.Field<decimal?>("Latitude"),
								   Reporting = item.Field<bool>("Reporting")
							   }).ToList();
			else
				mapDataList = (from item in resultTable.AsEnumerable()
							   select new MapData()
							   {
								   ID = item.Field<int>("ID"),
								   Acronym = item.Field<string>("Acronym"),
								   Name = item.Field<string>("Name"),
								   CompanyMapAcronym = item.Field<string>("CompanyMapAcronym"),
								   CompanyName = item.Field<string>("CompanyName"),
								   VendorDeviceName = item.Field<string>("VendorDeviceName"),
								   Longitude = item.Field<decimal?>("Longitude"),
								   Latitude = item.Field<decimal?>("Latitude"),
								   Reporting = item.Field<bool>("Reporting"),
								   InProgress = item.Field<bool>("InProgress"),
								   Planned = item.Field<bool>("Planned"),
								   Desired = item.Field<bool>("Desired")								   
							   }).ToList();

			connection.Dispose();
			return mapDataList;
		}

		#endregion

		
	}
}
