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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Soap;
using openPDCManager.Web.Data.BusinessObjects;
using openPDCManager.Web.Data.Entities;
using TVA.PhasorProtocols;

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
		
		public static string GetExecutingAssemblyPath()
		{
			return TVA.IO.FilePath.GetAbsolutePath("Temp");
		}

		public static string SaveIniFile(Stream input)
		{
			try
			{
				string fileName = Guid.NewGuid().ToString() + ".ini";
				using (FileStream fs = File.Create(GetExecutingAssemblyPath() + "\\" + fileName))
				{
					byte[] buffer = new byte[4096];
					int bytesRead;
					while ((bytesRead = input.Read(buffer, 0, buffer.Length)) != 0)
					{
						fs.Write(buffer, 0, bytesRead);
					}
				}
				return fileName;
			}
			catch
			{
				return string.Empty;
			}
		}

		public static ConnectionSettings GetConnectionSettings(Stream inputStream)
		{
			ConnectionSettings connectionSettings = new ConnectionSettings();
			try
			{
				SoapFormatter sf = new SoapFormatter();
				sf.AssemblyFormat = FormatterAssemblyStyle.Simple;
				sf.TypeFormat = FormatterTypeStyle.TypesWhenNeeded;
				sf.Binder = new VersionConfigToNamespaceAssemblyObjectBinder();
				connectionSettings = sf.Deserialize(inputStream) as ConnectionSettings;
			}
			catch
			{
				throw;				
			}

			return connectionSettings;
		}

		public static List<WizardDeviceInfo> GetWizardConfigurationInfo(Stream inputStream)
		{
			List<WizardDeviceInfo> wizardDeviceInfoList = new List<WizardDeviceInfo>();
			try
			{
				SoapFormatter sf = new SoapFormatter();
				sf.AssemblyFormat = FormatterAssemblyStyle.Simple;
				sf.TypeFormat = FormatterTypeStyle.TypesWhenNeeded;
				IConfigurationFrame configurationFrame = sf.Deserialize(inputStream) as IConfigurationFrame;
				if (configurationFrame != null)
				{
					int parentAccessID = configurationFrame.IDCode;
					wizardDeviceInfoList = (from cell in configurationFrame.Cells
											select new WizardDeviceInfo()
											{												
												Acronym = cell.StationName.Replace(" ", "").ToUpper(),
												Name = CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(cell.StationName.ToLower()),
												Longitude = 0,
												Latitude = 0,
												VendorDeviceID = (int?)null,
												AccessID = cell.IDCode,
												ParentAccessID = parentAccessID,
												Include = true,
												PhasorList = (from phasor in cell.PhasorDefinitions
															  select new PhasorInfo()
															  {
																  Label = CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(phasor.Label.Replace("?", " ").Trim().ToLower()),
																  Type = phasor.PhasorType == PhasorType.Current ? "I" : "V",
																  Phase = "+",
																  DestinationLabel = "",
																  Include = true
															  }).ToList()
											}).ToList();
												
				}
			}
			catch
			{
				throw;
			}

			return wizardDeviceInfoList;
		}

		public static string SaveWizardConfigurationInfo(string nodeID, List<WizardDeviceInfo> wizardDeviceInfoList, string connectionString, 
				int? protocolID, int? companyID, int? historianID, int? interconnectionID, int? parentID)
		{
			//Before we start saving information into database make sure all the device acronyms are unique in the collection.
			List<string> acronymList = new List<string>();
			acronymList = (from item in wizardDeviceInfoList
						   select item.Acronym).Distinct().ToList();

			if (acronymList.Count != wizardDeviceInfoList.Count)	//i.e. there are duplicate acronyms.
				throw new ArgumentException("Duplicate Acronyms Exists!");

			int loadOrder = 1;
			foreach (WizardDeviceInfo info in wizardDeviceInfoList)
			{
				if (info.Include)
				{
					Device device = new Device();
					device.NodeID = nodeID;
					device.Acronym = info.Acronym;
					device.Name = info.Name;
					device.IsConcentrator = false;
					device.Longitude = info.Longitude;
					device.Latitude = info.Latitude;
					device.ConnectionString = parentID == null ? connectionString : string.Empty;
					device.ProtocolID = protocolID;
					device.CompanyID = companyID;
					device.HistorianID = historianID;
					device.InterconnectionID = interconnectionID;
					device.Enabled = true;
					device.VendorDeviceID = info.VendorDeviceID == null ? (int?)null : info.VendorDeviceID == 0 ? (int?)null : info.VendorDeviceID;
					device.ParentID = parentID;
					device.TimeZone = string.Empty;
					device.AccessID = info.AccessID;
					//Please review from here.										
					device.TimeAdjustmentTicks = 0;
					device.DataLossInterval = 35;
					device.MeasuredLines = 1;
					device.LoadOrder = loadOrder;
					device.ContactList = string.Empty;

					Device existingDevice = GetDeviceByAcronym(info.Acronym);
					if (existingDevice != null)
					{
						device.ID = existingDevice.ID;
						SaveDevice(device, false);
					}
					else
						SaveDevice(device, true);

					Device addedDevice = GetDeviceByAcronym(info.Acronym);
					int count = 1;
					foreach (PhasorInfo phasorInfo in info.PhasorList)
					{
						if (phasorInfo.Label.ToLower() != "unused")
						{
							Phasor phasor = new Phasor();
							phasor.DeviceID = addedDevice.ID;
							phasor.Label = phasorInfo.Label;
							phasor.Type = phasorInfo.Type;
							phasor.Phase = phasorInfo.Phase;
							phasor.DestinationPhasorID = null;
							phasor.SourceIndex = count;

							Phasor existingPhasor = GetPhasorBySourceIndex(addedDevice.ID, phasor.SourceIndex);
							if (existingPhasor != null)
							{
								phasor.ID = existingPhasor.ID;
								SavePhasor(phasor, false);
							}
							else
								SavePhasor(phasor, true);
						}
						count++;
					}
				}
				loadOrder++;
			}

			return "Done!";
		}

		public static IDbDataParameter AddWithValue(IDbCommand command, string name, object value)
		{
			return AddWithValue(command, name, value, ParameterDirection.Input);
		}
		
		public static IDbDataParameter AddWithValue(IDbCommand command, string name, object value, ParameterDirection direction)
		{
			IDbDataParameter param = command.CreateParameter();
			param.ParameterName = name;
			param.Value = value;
			param.Direction = direction;			
			return param;
		}

		public static bool MasterNode(string nodeID)
		{
			bool isMaster = false;

			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = "Select Master From Node Where ID = @id";
			command.Parameters.Add(AddWithValue(command, "@id", nodeID));
			isMaster = (bool)command.ExecuteScalar();
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
											 TotalDevices = "Total " + item.Field<object>("DeviceCount").ToString() + " Devices",
											 MemberStatusList = (from cs in resultSet.Tables["MemberSummary"].AsEnumerable()
															  where cs.Field<string>("InterconnectionName") == item.Field<string>("InterconnectionName")
															  select new MemberStatus()
															  {
																  CompanyAcronym = cs.Field<string>("CompanyAcronym"),
																  CompanyName = cs.Field<string>("CompanyName"),
																  MeasuredLines = Convert.ToInt32(cs.Field<object>("MeasuredLines")),
																  TotalDevices = Convert.ToInt32(cs.Field<object>("DeviceCount"))
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
			
			command.Parameters.Add(AddWithValue(command, "@acronym", company.Acronym));
			command.Parameters.Add(AddWithValue(command, "@mapAcronym", company.MapAcronym));
			command.Parameters.Add(AddWithValue(command, "@name", company.Name));
			command.Parameters.Add(AddWithValue(command, "@url", company.URL));
			command.Parameters.Add(AddWithValue(command, "@loadOrder", company.LoadOrder));

			if (!isNew)
			{
				command.Parameters.Add(AddWithValue(command, "@id", company.ID));
			}

			command.ExecuteNonQuery();
            connection.Dispose();
            return "Done!";
		}

		#endregion

		#region " Manage Output Streams Code"

		public static List<OutputStream> GetOutputStreamList(bool enabledOnly)
		{
			List<OutputStream> outputStreamList = new List<OutputStream>();
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			if (enabledOnly)
			{
				command.CommandText = "SELECT * FROM OutputStreamDetail Where Enabled = @enabled ORDER BY LoadOrder";				
				command.Parameters.Add(AddWithValue(command, "@enabled", true));
			}
			else
				command.CommandText = "SELECT * FROM OutputStreamDetail ORDER BY LoadOrder";

			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());

			outputStreamList = (from item in resultTable.AsEnumerable()
								select new OutputStream()
								{
									NodeID = item.Field<Guid>("NodeID").ToString(),
									ID = item.Field<int>("ID"),
									Acronym = item.Field<string>("Acronym"),
									Name = item.Field<string>("Name"),
									Type = item.Field<int>("Type"),
									ConnectionString = item.Field<string>("ConnectionString"),
									IDCode = item.Field<int>("IDCode"),
									CommandChannel = item.Field<string>("CommandChannel"),
									DataChannel = item.Field<string>("DataChannel"),
									AutoPublishConfigFrame = item.Field<bool>("AutoPublishConfigFrame"),
									AutoStartDataChannel = item.Field<bool>("AutoStartDataChannel"),
									NominalFrequency = item.Field<int>("NominalFrequency"),
									FramesPerSecond = item.Field<int>("FramesPerSecond"),
									LagTime = item.Field<double>("LagTime"),
									LeadTime = item.Field<double>("LeadTime"),
									UseLocalClockAsRealTime = item.Field<bool>("UseLocalClockAsRealTime"),
									AllowSortsByArrival = item.Field<bool>("AllowSortsByArrival"),
									LoadOrder = item.Field<int>("LoadOrder"),
									Enabled = item.Field<bool>("Enabled"),
									NodeName = item.Field<string>("NodeName"),
									TypeName = item.Field<int>("Type") == 0 ? "IEEE C37.118" : "BPA"
								}).ToList();
			connection.Dispose();
			return outputStreamList;
		}

		public static string SaveOutputStream(OutputStream outputStream, bool isNew)
		{
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;

			if (isNew)
				command.CommandText = "INSERT INTO OutputStream (NodeID, Acronym, Name, Type, ConnectionString, IDCode, CommandChannel, DataChannel, AutoPublishConfigFrame, AutoStartDataChannel, NominalFrequency, FramesPerSecond, LagTime, LeadTime, " +
									"UseLocalClockAsRealTime, AllowSortsByArrival, LoadOrder, Enabled) VALUES (@nodeID, @acronym, @name, @type, @connectionString, @idCode, @commandChannel, @dataChannel, @autoPublishConfigFrame, @autoStartDataChannel, " +
									"@nominalFrequency, @framesPerSecond, @lagTime, @leadTime, @useLocalClockAsRealTime, @allowSortsByArrival, @loadOrder, @enabled)";
			else
				command.CommandText = "UPDATE OutputStream SET NodeID = @nodeID, Acronym = @acronym, Name = @name, Type = @type, ConnectionString = @connectionString, IDCode = @idCode, CommandChannel = @commandChannel, DataChannel = @dataChannel, AutoPublishConfigFrame = @autoPublishConfigFrame, " +
									"AutoStartDataChannel = @autoStartDataChannel, NominalFrequency = @nominalFrequency, FramesPerSecond = @framesPerSecond, LagTime = @lagTime, LeadTime = @leadTime, UseLocalClockAsRealTime = @useLocalClockAsRealTime, " +
									"AllowSortsByArrival = @allowSortsByArrival, LoadOrder = @loadOrder, Enabled = @enabled WHERE ID = @id";
						
			command.Parameters.Add(AddWithValue(command, "@nodeID", outputStream.NodeID));
			command.Parameters.Add(AddWithValue(command, "@acronym", outputStream.Acronym));
			command.Parameters.Add(AddWithValue(command, "@name", outputStream.Name));
			command.Parameters.Add(AddWithValue(command, "@type", outputStream.Type));
			command.Parameters.Add(AddWithValue(command, "@connectionString", outputStream.ConnectionString));
			command.Parameters.Add(AddWithValue(command, "@idCode", outputStream.IDCode));
			command.Parameters.Add(AddWithValue(command, "@commandChannel", outputStream.CommandChannel));
			command.Parameters.Add(AddWithValue(command, "@dataChannel", outputStream.DataChannel));
			command.Parameters.Add(AddWithValue(command, "@autoPublishConfigFrame", outputStream.AutoPublishConfigFrame));
			command.Parameters.Add(AddWithValue(command, "@autoStartDataChannel", outputStream.AutoStartDataChannel));
			command.Parameters.Add(AddWithValue(command, "@nominalFrequency", outputStream.NominalFrequency));
			command.Parameters.Add(AddWithValue(command, "@framesPerSecond", outputStream.FramesPerSecond));
			command.Parameters.Add(AddWithValue(command, "@lagTime", outputStream.LagTime));
			command.Parameters.Add(AddWithValue(command, "@leadTime", outputStream.LeadTime));
			command.Parameters.Add(AddWithValue(command, "@useLocalClockAsRealTime", outputStream.UseLocalClockAsRealTime));
			command.Parameters.Add(AddWithValue(command, "@allowSortsByArrival", outputStream.AllowSortsByArrival));
			command.Parameters.Add(AddWithValue(command, "@loadOrder", outputStream.LoadOrder));
			command.Parameters.Add(AddWithValue(command, "@enabled", outputStream.Enabled));

			if (!isNew)
			{
				command.Parameters.Add(AddWithValue(command, "@id", outputStream.ID));
			}

			command.ExecuteNonQuery();
			connection.Dispose();			
			return "Done!";
		}

		#endregion

		#region " Manage Output Stream Measurements Code"

		public static List<OutputStreamMeasurement> GetOutputStreamMeasurementList(int outputStreamID)
		{
			List<OutputStreamMeasurement> outputStreamMeasurementList = new List<OutputStreamMeasurement>();
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = "Select * From OutputStreamMeasurementDetail Where AdapterID = @adapterID";
			//IDbDataParameter param = command.CreateParameter();
			//param.ParameterName = "@adapterID";
			//param.Value = outputStreamID;
			//command.Parameters.Add(param);
			command.Parameters.Add(AddWithValue(command, "@adapterID", outputStreamID));

			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());

			outputStreamMeasurementList = (from item in resultTable.AsEnumerable()
										   select new OutputStreamMeasurement()
										   {
											   NodeID = item.Field<Guid>("NodeID").ToString(),
											   AdapterID = item.Field<int>("AdapterID"),
											   ID = item.Field<int>("ID"),
											   PointID = item.Field<int>("PointID"),
											   HistorianID = item.Field<int?>("HistorianID"),
											   SignalReference = item.Field<string>("SignalReference"),
											   HistorianAcronym = item.Field<string>("HistorianAcronym")
										   }).ToList();
			connection.Dispose();
			return outputStreamMeasurementList;
		}

		public static string SaveOutputStreamMeasurement(OutputStreamMeasurement outputStreamMeasurement, bool isNew)
		{
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;

			if (isNew)
				command.CommandText = "Insert Into OutputStreamMeasurement (NodeID, AdapterID, HistorianID, PointID, SignalReference) " +
					"Values (@nodeID, @adapterID, @historianID, @pointID, @signalReference)";
			else
				command.CommandText = "Update OutputStreamMeasurement Set NodeID = @nodeID, AdapterID = @adapterID, HistorianID = @historianID, " +
					"PointID = @pointID, SignalReference = @signalReference WHERE ID = @id";

			command.Parameters.Add(AddWithValue(command, "@nodeID", outputStreamMeasurement.NodeID));
			command.Parameters.Add(AddWithValue(command, "@adapterID", outputStreamMeasurement.AdapterID));
			command.Parameters.Add(AddWithValue(command, "@historianID", outputStreamMeasurement.HistorianID ?? (object)DBNull.Value));
			command.Parameters.Add(AddWithValue(command, "@pointID", outputStreamMeasurement.PointID));
			command.Parameters.Add(AddWithValue(command, "@signalReference", outputStreamMeasurement.SignalReference));

			if (!isNew)
				command.Parameters.Add(AddWithValue(command, "@id", outputStreamMeasurement.ID));

			command.ExecuteNonQuery();
			connection.Dispose();
			return "Done!";
		}

		#endregion

		#region " Manage Output Stream Devices Code"

		public static List<OutputStreamDevice> GetOutputStreamDeviceList(int outputStreamID, bool enabledOnly)
		{
			List<OutputStreamDevice> outputStreamDeviceList = new List<OutputStreamDevice>();
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			if (!enabledOnly)
				command.CommandText = "Select * From OutputStreamDeviceDetail Where AdapterID = @adapterID";
			else
				command.CommandText = "Select * From OutputStreamDeviceDetail Where AdapterID = @adapterID AND Enabled = @enabled";
	
			command.Parameters.Add(AddWithValue(command, "@adapterID", outputStreamID));
			if (enabledOnly)			
				command.Parameters.Add(AddWithValue(command, "@enabled", true));

			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());

			outputStreamDeviceList = (from item in resultTable.AsEnumerable()
									  select new OutputStreamDevice()
									  {
										  NodeID = item.Field<Guid>("NodeID").ToString(),
										  AdapterID = item.Field<int>("AdapterID"),
										  ID = item.Field<int>("ID"),
										  Acronym = item.Field<string>("Acronym"),
										  Name = item.Field<string>("Name"),
										  BpaAcronym = item.Field<string>("BpaAcronym"),
										  LoadOrder = item.Field<int>("LoadOrder"),
										  Enabled = item.Field<bool>("Enabled"),
										  Virtual = Convert.ToBoolean(item.Field<object>("Virtual"))
									  }).ToList();
			connection.Dispose();
			return outputStreamDeviceList;
		}

		public static OutputStreamDevice GetOutputStreamDevice(int outputStreamID, string acronym)
		{
			List<OutputStreamDevice> ouputStreamDeviceList = new List<OutputStreamDevice>();
			ouputStreamDeviceList = (from item in GetOutputStreamDeviceList(outputStreamID, false)
								  where item.Acronym == acronym
								  select item).ToList();
			if (ouputStreamDeviceList.Count > 0)
				return ouputStreamDeviceList[0];
			else
				return null;
		}

		public static string SaveOutputStreamDevice(OutputStreamDevice outputStreamDevice, bool isNew)
		{
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;

			if (isNew)
				command.CommandText = "Insert Into OutputStreamDevice (NodeID, AdapterID, Acronym, BpaAcronym, Name, LoadOrder, Enabled) " +
					"Values (@nodeID, @adapterID, @acronym, @bpaAcronym, @name, @loadOrder, @enabled)";
			else
				command.CommandText = "Update OutputStreamDevice Set NodeID = @nodeID, AdapterID = @adapterID, Acronym = @acronym, " +
					"BpaAcronym = @bpaAcronym, Name = @name, LoadOrder = @loadOrder, Enabled = @enabled Where ID = @id";

			command.Parameters.Add(AddWithValue(command, "@nodeID", outputStreamDevice.NodeID));
			command.Parameters.Add(AddWithValue(command, "@adapterID", outputStreamDevice.AdapterID));
			command.Parameters.Add(AddWithValue(command, "@acronym", outputStreamDevice.Acronym));
			command.Parameters.Add(AddWithValue(command, "@bpaAcronym", outputStreamDevice.BpaAcronym));
			command.Parameters.Add(AddWithValue(command, "@name", outputStreamDevice.Name));
			command.Parameters.Add(AddWithValue(command, "@loadOrder", outputStreamDevice.LoadOrder));
			command.Parameters.Add(AddWithValue(command, "@enabled", outputStreamDevice.Enabled));
			if (!isNew)
				command.Parameters.Add(AddWithValue(command, "@id", outputStreamDevice.ID));

			command.ExecuteNonQuery();
			connection.Dispose();

			return "Done!";
		}

		public static string DeleteOutputStreamDevice(int outputStreamID, List<string> devicesToBeDeleted)
		{
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;

			foreach (string acronym in devicesToBeDeleted)
			{
				command.CommandText = "Delete From OutputStreamDevice Where Acronym = @acronym And AdapterID = @adapterID";
				command.Parameters.Add(AddWithValue(command, "@acronym", acronym));
				command.Parameters.Add(AddWithValue(command, "@adapterID", outputStreamID));
				command.ExecuteNonQuery();

				command.CommandText = "Delete From OutputStreamMeasurement Where AdapterID = @outputStreamID And SignalReference LIKE @signalReference";
				command.Parameters.Add(AddWithValue(command, "@outputStreamID", outputStreamID));
				command.Parameters.Add(AddWithValue(command, "@signalReference", acronym + "%"));
				command.ExecuteNonQuery();
			}

			connection.Dispose();
			return "Done!";
		}

		public static string AddDevices(int outputStreamID, Dictionary<int, string> devicesToBeAdded, bool addDigitals, bool addAnalogs)
		{
			foreach (KeyValuePair<int, string> deviceInfo in devicesToBeAdded)	//loop through all the devices that needs to be added.
			{
				Device device = new Device();
				device = GetDeviceByDeviceID(deviceInfo.Key);	//Get alll the information about the device to be added.
				OutputStreamDevice outputStreamDevice = new OutputStreamDevice();
				outputStreamDevice.NodeID = device.NodeID;
				outputStreamDevice.AdapterID = outputStreamID;
				outputStreamDevice.Acronym = device.Acronym;
				outputStreamDevice.BpaAcronym = string.Empty;
				outputStreamDevice.Name = device.Name;
				outputStreamDevice.LoadOrder = device.LoadOrder;
				outputStreamDevice.Enabled = true;
				SaveOutputStreamDevice(outputStreamDevice, true);	//save in to OutputStreamDevice Table.

				int savedOutputStreamDeviceID = GetOutputStreamDevice(outputStreamID, device.Acronym).ID;


				//********************************************
				List<Phasor> phasorList = new List<Phasor>();
				phasorList = GetPhasorList(deviceInfo.Key);			//Get all the phasor information for the device to be added.

				foreach (Phasor phasor in phasorList)
				{
					OutputStreamDevicePhasor outputStreamDevicePhasor = new OutputStreamDevicePhasor(); //Add all phasors one by one into OutputStreamDevicePhasor table.
					outputStreamDevicePhasor.NodeID = device.NodeID;
					outputStreamDevicePhasor.OutputStreamDeviceID = savedOutputStreamDeviceID;
					outputStreamDevicePhasor.Label = phasor.Label;
					outputStreamDevicePhasor.Type = phasor.Type;
					outputStreamDevicePhasor.Phase = phasor.Phase;
					outputStreamDevicePhasor.LoadOrder = phasor.SourceIndex;
					SaveOutputStreamDevicePhasor(outputStreamDevicePhasor, true);
				}
				//********************************************

				//********************************************
				List<Measurement> measurementList = new List<Measurement>();
				measurementList = GetMeasurementsByDevice(deviceInfo.Key);

				foreach (Measurement measurement in measurementList)
				{
					OutputStreamMeasurement outputStreamMeasurement = new OutputStreamMeasurement();
					outputStreamMeasurement.NodeID = device.NodeID;
					outputStreamMeasurement.AdapterID = outputStreamID;
					outputStreamMeasurement.HistorianID = measurement.HistorianID;
					outputStreamMeasurement.PointID = measurement.PointID;
					outputStreamMeasurement.SignalReference = measurement.SignalReference;
					SaveOutputStreamMeasurement(outputStreamMeasurement, true);

					if (addAnalogs && measurement.SignalSuffix == "AV") //if add analogs checked and measurement is analog value then add it to OutputStreamDeviceAnalog Table.
					{
						OutputStreamDeviceAnalog outputStreamDeviceAnalog = new OutputStreamDeviceAnalog();
						outputStreamDeviceAnalog.NodeID = device.NodeID;
						outputStreamDeviceAnalog.OutputStreamDeviceID = savedOutputStreamDeviceID;
						outputStreamDeviceAnalog.Label = measurement.PointTag;
						outputStreamDeviceAnalog.Type = 0;	//default
						outputStreamDeviceAnalog.LoadOrder = Convert.ToInt32(measurement.SignalReference.Substring((measurement.SignalReference.LastIndexOf("-") + 3)));
						SaveOutputStreamDeviceAnalog(outputStreamDeviceAnalog, true);
					}

					if (addDigitals && measurement.SignalSuffix == "DV") //if add digitals checked and measurement is digital value then add it to OutputStreamDeviceDigital Table.
					{
						OutputStreamDeviceDigital outputStreamDeviceDigital = new OutputStreamDeviceDigital();
						outputStreamDeviceDigital.NodeID = device.NodeID;
						outputStreamDeviceDigital.OutputStreamDeviceID = savedOutputStreamDeviceID;
						outputStreamDeviceDigital.Label = measurement.PointTag;
						outputStreamDeviceDigital.LoadOrder = Convert.ToInt32(measurement.SignalReference.Substring((measurement.SignalReference.LastIndexOf("-") + 3)));
						SaveOutputStreamDeviceDigital(outputStreamDeviceDigital, true);
					}
				}
				//********************************************

			}

			return "Done!";
		}

		#endregion

		#region " Manage Output Stream Device Phasor Code"

		public static List<OutputStreamDevicePhasor> GetOutputStreamDevicePhasorList(int outputStreamDeviceID)
		{
			List<OutputStreamDevicePhasor> outputStreamDevicePhasorList = new List<OutputStreamDevicePhasor>();
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = "Select * From OutputStreamDevicePhasor Where OutputStreamDeviceID = @outputStreamDeviceID Order By LoadOrder";
			command.Parameters.Add(AddWithValue(command, "@outputStreamDeviceID", outputStreamDeviceID));
			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());

			outputStreamDevicePhasorList = (from item in resultTable.AsEnumerable()
											select new OutputStreamDevicePhasor()
											{
												NodeID = item.Field<Guid>("NodeID").ToString(),
												OutputStreamDeviceID = item.Field<int>("OutputStreamDeviceID"),
												ID = item.Field<int>("ID"),
												Label = item.Field<string>("Label"),
												Type = item.Field<string>("Type"),
												Phase = item.Field<string>("Phase"),
												LoadOrder = item.Field<int>("LoadOrder"),
												PhasorType = item.Field<string>("Type") == "V" ? "Voltage" : "Current",
												PhaseType = item.Field<string>("Phase") == "+" ? "Positive" : item.Field<string>("Phase") == "-" ? "Negative" :
															item.Field<string>("Phase") == "A" ? "Phase A" : item.Field<string>("Phase") == "B" ? "Phase B" : "Phase C"
											}).ToList();
			connection.Dispose();
			return outputStreamDevicePhasorList;
		}

		public static string SaveOutputStreamDevicePhasor(OutputStreamDevicePhasor outputStreamDevicePhasor, bool isNew)
		{
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;

			if (isNew)
				command.CommandText = "Insert Into OutputStreamDevicePhasor (NodeID, OutputStreamDeviceID, Label, Type, Phase, LoadOrder) " +
					"Values (@nodeID, @outputStreamDeviceID, @label, @type, @phase, @loadOrder)";
			else
				command.CommandText = "Update OutputStreamDevicePhasor Set NodeID = @nodeID, OutputStreamDeviceID = @outputStreamDeviceID, Label = @label, " +
					"Type = @type, Phase = @phase, LoadOrder = @loadOrder Where ID = @id";

			command.Parameters.Add(AddWithValue(command, "@nodeID", outputStreamDevicePhasor.NodeID));
			command.Parameters.Add(AddWithValue(command, "@outputStreamDeviceID", outputStreamDevicePhasor.OutputStreamDeviceID));
			command.Parameters.Add(AddWithValue(command, "@label", outputStreamDevicePhasor.Label));
			command.Parameters.Add(AddWithValue(command, "@type", outputStreamDevicePhasor.Type));
			command.Parameters.Add(AddWithValue(command, "@phase", outputStreamDevicePhasor.Phase));
			command.Parameters.Add(AddWithValue(command, "@loadOrder", outputStreamDevicePhasor.LoadOrder));
			if (!isNew)
				command.Parameters.Add(AddWithValue(command, "@id", outputStreamDevicePhasor.ID));

			command.ExecuteNonQuery();
			connection.Dispose();
			return "Done!";
		}

		#endregion

		#region " Manage Output Stream Device Analogs Code"

		public static List<OutputStreamDeviceAnalog> GetOutputStreamDeviceAnalogList(int outputStreamDeviceID)
		{
			List<OutputStreamDeviceAnalog> outputStreamDeviceAnalogList = new List<OutputStreamDeviceAnalog>();
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = "Select * From OutputStreamDeviceAnalog Where OutputStreamDeviceID = @outputStreamDeviceID Order By LoadOrder";
			command.Parameters.Add(AddWithValue(command, "@outputStreamDeviceID", outputStreamDeviceID));

			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());

			outputStreamDeviceAnalogList = (from item in resultTable.AsEnumerable()
											select new OutputStreamDeviceAnalog()
											{
												NodeID = item.Field<Guid>("NodeID").ToString(),
												OutputStreamDeviceID = item.Field<int>("OutputStreamDeviceID"),
												ID = item.Field<int>("ID"),
												Label = item.Field<string>("Label"),
												Type = item.Field<int>("Type"),
												LoadOrder = item.Field<int>("LoadOrder"),
												TypeName = item.Field<int>("Type") == 0 ? "Single point-on-wave" : item.Field<int>("Type") == 1 ? "RMS of analog input" : "Peak of analog input"
											}).ToList();
			connection.Dispose();
			return outputStreamDeviceAnalogList;
		}

		public static string SaveOutputStreamDeviceAnalog(OutputStreamDeviceAnalog outputStreamDeviceAnalog, bool isNew)
		{
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;

			if (isNew)
				command.CommandText = "Insert Into OutputStreamDeviceAnalog (NodeID, OutputStreamDeviceID, Label, Type, LoadOrder) " +
					"Values (@nodeID, @outputStreamDeviceID, @label, @type, @loadOrder)";
			else
				command.CommandText = "Update OutputStreamDeviceAnalog Set NodeID = @nodeID, OutputStreamDeviceID = @outputStreamDeviceID, Label = @label, " +
					"Type = @type, LoadOrder = @loadOrder Where ID = @id";

			command.Parameters.Add(AddWithValue(command, "@nodeID", outputStreamDeviceAnalog.NodeID));
			command.Parameters.Add(AddWithValue(command, "@outputStreamDeviceID", outputStreamDeviceAnalog.OutputStreamDeviceID));
			command.Parameters.Add(AddWithValue(command, "@label", outputStreamDeviceAnalog.Label));
			command.Parameters.Add(AddWithValue(command, "@type", outputStreamDeviceAnalog.Type));
			command.Parameters.Add(AddWithValue(command, "@loadOrder", outputStreamDeviceAnalog.LoadOrder));
			if (!isNew)
				command.Parameters.Add(AddWithValue(command, "@id", outputStreamDeviceAnalog.ID));

			command.ExecuteNonQuery();
			connection.Dispose();

			return "Done!";
		}

		#endregion

		#region " Manage Output Stream Device Digitals Code"

		public static List<OutputStreamDeviceDigital> GetOutputStreamDeviceDigitalList(int outputStreamDeviceID)
		{
			List<OutputStreamDeviceDigital> outputStreamDeviceDigitalList = new List<OutputStreamDeviceDigital>();
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = "Select * From OutputStreamDeviceDigital Where OutputStreamDeviceID = @outputStreamDeviceID Order By LoadOrder";
			command.Parameters.Add(AddWithValue(command, "@outputStreamDeviceID", outputStreamDeviceID));

			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());

			outputStreamDeviceDigitalList = (from item in resultTable.AsEnumerable()
											select new OutputStreamDeviceDigital()
											{
												NodeID = item.Field<Guid>("NodeID").ToString(),
												OutputStreamDeviceID = item.Field<int>("OutputStreamDeviceID"),
												ID = item.Field<int>("ID"),
												Label = item.Field<string>("Label"),												
												LoadOrder = item.Field<int>("LoadOrder")
											}).ToList();
			connection.Dispose();

			return outputStreamDeviceDigitalList;
		}

		public static string SaveOutputStreamDeviceDigital(OutputStreamDeviceDigital outputStreamDeviceDigital, bool isNew)
		{
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;

			if (isNew)
				command.CommandText = "Insert Into OutputStreamDeviceDigital (NodeID, OutputStreamDeviceID, Label, LoadOrder) " +
					"Values (@nodeID, @outputStreamDeviceID, @label, @loadOrder)";
			else
				command.CommandText = "Update OutputStreamDeviceDigital Set NodeID = @nodeID, OutputStreamDeviceID = @outputStreamDeviceID, Label = @label, " +
					"LoadOrder = @loadOrder Where ID = @id";

			command.Parameters.Add(AddWithValue(command, "@nodeID", outputStreamDeviceDigital.NodeID));
			command.Parameters.Add(AddWithValue(command, "@outputStreamDeviceID", outputStreamDeviceDigital.OutputStreamDeviceID));
			command.Parameters.Add(AddWithValue(command, "@label", outputStreamDeviceDigital.Label));			
			command.Parameters.Add(AddWithValue(command, "@loadOrder", outputStreamDeviceDigital.LoadOrder));
			if (!isNew)
				command.Parameters.Add(AddWithValue(command, "@id", outputStreamDeviceDigital.ID));

			command.ExecuteNonQuery();
			connection.Dispose();

			return "Done!";
		}

		#endregion

		#region " Manage Historians Code"

		public static List<Historian> GetHistorianList(string nodeID)
		{
			List<Historian> historianList = new List<Historian>();
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			if (string.IsNullOrEmpty(nodeID) || MasterNode(nodeID))			
				command.CommandText = "Select * From HistorianDetail Order By LoadOrder";			
			else
			{
				command.CommandText = "Select * From HistorianDetail Where NodeID = @nodeID Order By LoadOrder";				
				command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));
			}

			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());		
			historianList = (from item in resultTable.AsEnumerable()
							 select new Historian()
							 {
								 NodeID = item.Field<Guid>("NodeID").ToString(),
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
			
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			if (enabledOnly)
			{
				command.CommandText = "Select ID, Acronym From Historian Where Enabled = @enabled Order By LoadOrder";
				command.Parameters.Add(AddWithValue(command, "@enabled", true));
			}
			else
				command.CommandText = "Select ID, Acronym From Historian Order By LoadOrder";
			
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

			command.Parameters.Add(AddWithValue(command, "@nodeID", historian.NodeID));
			command.Parameters.Add(AddWithValue(command, "@acronym", historian.Acronym));
			command.Parameters.Add(AddWithValue(command, "@name", historian.Name));
			command.Parameters.Add(AddWithValue(command, "@assemblyName", historian.AssemblyName));
			command.Parameters.Add(AddWithValue(command, "@typeName", historian.TypeName));
			command.Parameters.Add(AddWithValue(command, "@connectionString", historian.ConnectionString));
			command.Parameters.Add(AddWithValue(command, "@isLocal", historian.IsLocal));
			command.Parameters.Add(AddWithValue(command, "@description", historian.Description));
			command.Parameters.Add(AddWithValue(command, "@loadOrder", historian.LoadOrder));
			command.Parameters.Add(AddWithValue(command, "@enabled", historian.Enabled));

			if (!isNew)
				command.Parameters.Add(AddWithValue(command, "@id", historian.ID));

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
							ID = item.Field<Guid>("ID").ToString(),
							Name = item.Field<string>("Name"),
							CompanyID = item.Field<int?>("CompanyID"),
							Longitude = item.Field<decimal?>("Longitude"),
							Latitude = item.Field<decimal?>("Latitude"),
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
		
		public static Dictionary<string, string> GetNodes(bool enabledOnly, bool isOptional)
		{
			Dictionary<string, string> nodeList = new Dictionary<string, string>();
			if (isOptional)
				nodeList.Add(string.Empty, "Select Node");
								
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			if (enabledOnly)
			{
				command.CommandText = "Select ID, Name From Node Where Enabled = @enabled Order By LoadOrder";
				command.Parameters.Add(AddWithValue(command, "@enabled", true));
			}
			else
				command.CommandText = "Select ID, Name From Node Order By LoadOrder";
			
			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());

			foreach (DataRow row in resultTable.Rows)
			{
				if (!nodeList.ContainsKey(row["ID"].ToString()))
					nodeList.Add(row["ID"].ToString(), row["Name"].ToString());
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
				command.CommandText = "Insert Into Node (Name, CompanyID, Longitude, Latitude, Description, [Image], Master, LoadOrder, Enabled) Values (@name, @companyID, @longitude, @latitude, @description, @image, @master, @loadOrder, @enabled)";
			else
				command.CommandText = "Update Node Set Name = @name, CompanyID = @companyID, Longitude = @longitude, Latitude = @latitude, Description = @description, [Image] = @image, Master = @master, LoadOrder = @loadOrder, Enabled = @enabled Where ID = @id";

			command.Parameters.Add(AddWithValue(command, "@name", node.Name));
			command.Parameters.Add(AddWithValue(command, "@companyID", node.CompanyID ?? (object)DBNull.Value));
			command.Parameters.Add(AddWithValue(command, "@longitude", node.Longitude ?? (object)DBNull.Value));
			command.Parameters.Add(AddWithValue(command, "@latitude", node.Latitude ?? (object)DBNull.Value));
			command.Parameters.Add(AddWithValue(command, "@description", node.Description));
			command.Parameters.Add(AddWithValue(command, "@image", node.Image));
			command.Parameters.Add(AddWithValue(command, "@master", node.Master));
			command.Parameters.Add(AddWithValue(command, "@loadOrder", node.LoadOrder));
			command.Parameters.Add(AddWithValue(command, "@enabled", node.Enabled));

			if (!isNew)
				command.Parameters.Add(AddWithValue(command, "@id", node.ID));

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

			command.Parameters.Add(AddWithValue(command, "@acronym", vendor.Acronym));
			command.Parameters.Add(AddWithValue(command, "@name", vendor.Name));
			command.Parameters.Add(AddWithValue(command, "@phoneNumber", vendor.PhoneNumber));
			command.Parameters.Add(AddWithValue(command, "@contactEmail", vendor.ContactEmail));
			command.Parameters.Add(AddWithValue(command, "@url", vendor.URL));

			if (!isNew)
				command.Parameters.Add(AddWithValue(command, "@id", vendor.ID));

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

			command.Parameters.Add(AddWithValue(command, "@vendorID", vendorDevice.VendorID));
			command.Parameters.Add(AddWithValue(command, "@name", vendorDevice.Name));
			command.Parameters.Add(AddWithValue(command, "@description", vendorDevice.Description));
			command.Parameters.Add(AddWithValue(command, "@url", vendorDevice.URL));

			if (!isNew)
				command.Parameters.Add(AddWithValue(command, "@id", vendorDevice.ID));
			
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

		public static List<Device> GetDeviceList(string nodeID)
		{
			List<Device> deviceList = new List<Device>();
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;	
			if (string.IsNullOrEmpty(nodeID) || MasterNode(nodeID))
				command.CommandText = "Select * From DeviceDetail Order By LoadOrder";										
			else
			{
				command.CommandText = "Select * From DeviceDetail Where NodeID = @nodeID Order By LoadOrder";				
				command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));
			}
			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());			
			deviceList = (from item in resultTable.AsEnumerable()
						  select new Device()
						  {
							  NodeID =	item.Field<Guid>("NodeID").ToString(),
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
							  TimeAdjustmentTicks = Convert.ToInt64(item.Field<object>("TimeAdjustmentTicks")),	
							  DataLossInterval = item.Field<double>("DataLossInterval"),
							  ContactList = item.Field<string>("ContactList"),
							  MeasuredLines = item.Field<int?>("MeasuredLines"),
							  LoadOrder = item.Field<int>("LoadOrder"),
							  Enabled = item.Field<bool>("Enabled"),
							  CompanyName = item.Field<string>("CompanyName"),
							  CompanyAcronym = item.Field<string>("CompanyAcronym"),
							  HistorianAcronym = item.Field<string>("HistorianAcronym"),
							  VendorDeviceName = item.Field<string>("VendorDeviceName"),
							  VendorAcronym = item.Field<string>("VendorAcronym"),
							  ProtocolName = item.Field<string>("ProtocolName"),
							  InterconnectionName = item.Field<string>("InterconnectionName"),
							  NodeName = item.Field<string>("NodeName"),
							  ParentAcronym = item.Field<string>("ParentAcronym")
						  }).ToList();
			connection.Dispose();
			return deviceList;
		}

		public static List<Device> GetDeviceListByParentID(int parentID)
		{
			List<Device> deviceList = new List<Device>();
			deviceList = (from item in GetDeviceList(string.Empty)
						  where item.ParentID == parentID
						  select item).ToList();
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
			command.Parameters.Add(AddWithValue(command, "@nodeID", device.NodeID));
			command.Parameters.Add(AddWithValue(command, "@parentID", device.ParentID ?? (object)DBNull.Value));
			command.Parameters.Add(AddWithValue(command, "@acronym", device.Acronym));
			command.Parameters.Add(AddWithValue(command, "@name", device.Name));
			command.Parameters.Add(AddWithValue(command, "@isConcentrator", device.IsConcentrator));
			command.Parameters.Add(AddWithValue(command, "@companyID", device.CompanyID));
			command.Parameters.Add(AddWithValue(command, "@historianID", device.HistorianID ?? (object)DBNull.Value));
			command.Parameters.Add(AddWithValue(command, "@accessID", device.AccessID));
			command.Parameters.Add(AddWithValue(command, "@vendorDeviceID", device.VendorDeviceID == null ? (object)DBNull.Value : device.VendorDeviceID == 0 ? (object)DBNull.Value : device.VendorDeviceID));
			command.Parameters.Add(AddWithValue(command, "@protocolID", device.ProtocolID));
			command.Parameters.Add(AddWithValue(command, "@longitude", device.Longitude ?? (object)DBNull.Value));
			command.Parameters.Add(AddWithValue(command, "@latitude", device.Latitude ?? (object)DBNull.Value));
			command.Parameters.Add(AddWithValue(command, "@interconnectionID", device.InterconnectionID ?? (object)DBNull.Value));
			command.Parameters.Add(AddWithValue(command, "@connectionString", device.ConnectionString));
			command.Parameters.Add(AddWithValue(command, "@timezone", device.TimeZone));
			command.Parameters.Add(AddWithValue(command, "@timeAdjustmentTicks", device.TimeAdjustmentTicks));
			command.Parameters.Add(AddWithValue(command, "@dataLossInterval", device.DataLossInterval));
			command.Parameters.Add(AddWithValue(command, "@contactList", device.ContactList));
			command.Parameters.Add(AddWithValue(command, "@measuredLines", device.MeasuredLines ?? (object)DBNull.Value));
			command.Parameters.Add(AddWithValue(command, "@loadOrder", device.LoadOrder));
			command.Parameters.Add(AddWithValue(command, "@enabled", device.Enabled));

			if (!isNew)
				command.Parameters.Add(AddWithValue(command, "@id", device.ID));

			command.ExecuteNonQuery();
			connection.Dispose();

			if (device.IsConcentrator)
				return "Done!";		//As we do not add measurements for PDC device or device which is concentrator.

			Device addedDevice = new Device();
			addedDevice = GetDeviceByAcronym(device.Acronym);
			
			DataTable pmuSignalTypes = new DataTable();
		    pmuSignalTypes = GetPmuSignalTypes();

			Measurement measurement;

			foreach (DataRow row in pmuSignalTypes.Rows)
			{
				measurement = new Measurement();
				measurement.HistorianID = addedDevice.HistorianID;
				measurement.DeviceID = addedDevice.ID;
				measurement.PointTag = addedDevice.CompanyAcronym + "_" + addedDevice.Acronym + ":" + addedDevice.VendorAcronym + row["Abbreviation"].ToString();
				measurement.AlternateTag = string.Empty;
				measurement.SignalTypeID = Convert.ToInt32(row["ID"]);
				measurement.PhasorSourceIndex = (int?)null;
				measurement.SignalReference = addedDevice.Acronym + "-" + row["Suffix"].ToString();
				measurement.Adder = 0.0d;
				measurement.Multiplier = 1.0d;
				measurement.Description = addedDevice.Name + " " + addedDevice.VendorDeviceName + " " + row["Name"].ToString();
				measurement.Enabled = true;
				if (isNew)	//if it is a new device then measurements are new too. So don't worry about updating them.
					SaveMeasurement(measurement, true);
				else	//if device is existing one, then check and see if its measusremnts exist, if so then update measurements.
				{
					Measurement existingMeasurement = new Measurement();
					existingMeasurement = GetMeasurementInfo(measurement.DeviceID, row["Suffix"].ToString(), measurement.PhasorSourceIndex);

					if (existingMeasurement == null)	//measurement does not exist for this device and signal type then add as a new measurement otherwise update.
						SaveMeasurement(measurement, true);
					else
					{
						measurement.SignalID = existingMeasurement.SignalID;
						SaveMeasurement(measurement, false);
					}
				}
			}
						
			return "Done";			
		}

		public static Dictionary<int, string> GetDevices(DeviceType deviceType, bool isOptional)
		{
			Dictionary<int, string> deviceList = new Dictionary<int, string>();
			if (isOptional)
				deviceList.Add(0, "Select Device");

			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			if (deviceType == DeviceType.Concentrator)
			{
				command.CommandText = "Select ID, Acronym From Device Where IsConcentrator = @isConcentrator Order By LoadOrder";
				command.Parameters.Add(AddWithValue(command, "@isConcentrator", true));
			}
			else if (deviceType == DeviceType.NonConcentrator)
			{
				command.CommandText = "Select ID, Acronym From Device Where IsConcentrator = @isConcentrator Order By LoadOrder";
				command.Parameters.Add(AddWithValue(command, "@isConcentrator", false));
			}
			else
				command.CommandText = "Select ID, Acronym From Device Order By LoadOrder";

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
			List<Device> deviceList = new List<Device>();
			deviceList = (from item in GetDeviceList(string.Empty)
					  where item.ID == deviceID
					  select item).ToList();
			if (deviceList.Count > 0)
				return deviceList[0];
			else
				return null;
		}

		public static Device GetDeviceByAcronym(string acronym)
		{
			List<Device> deviceList = new List<Device>();
			deviceList = (from item in GetDeviceList(string.Empty)
					  where item.Acronym == acronym
					  select item).ToList();
			if (deviceList.Count > 0)
				return deviceList[0];
			else
				return null;
		}

		public static Dictionary<int, string> GetDevicesForOutputStream(int outputStreamID)
		{
			Dictionary<int, string> deviceList = new Dictionary<int, string>();
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = "Select ID, Acronym From Device Where IsConcentrator = @isConcentrator AND Acronym NOT IN (Select Acronym From OutputStreamDevice Where AdapterID = @adapterID)";
			command.Parameters.Add(AddWithValue(command, "@isConcentrator", false));
			command.Parameters.Add(AddWithValue(command, "@adapterID", outputStreamID));
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

		public static Device GetConcentratorDevice(int deviceID)
		{
			Device device = new Device();
			device = GetDeviceByDeviceID(deviceID);
			if (device.IsConcentrator)
				return device;
			else
				return null;
		}

		#endregion

		#region " Manage Phasor Code"

		public static List<Phasor> GetPhasorList(int deviceID)
		{
			List<Phasor> phasorList = new List<Phasor>();
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = "Select * From PhasorDetail Where DeviceID = @deviceID Order By SourceIndex";
			command.Parameters.Add(AddWithValue(command, "@deviceID", deviceID));

			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());

			phasorList = (from item in resultTable.AsEnumerable()
						  select new Phasor()
						  {
							  ID = item.Field<int>("ID"),
							  DeviceID = item.Field<int>("DeviceID"),
							  Label = item.Field<string>("Label"),
							  Type = item.Field<string>("Type"),
							  Phase = item.Field<string>("Phase"),
							  DestinationPhasorID = item.Field<int?>("DestinationPhasorID"),
							  SourceIndex = item.Field<int>("SourceIndex"),
							  DestinationPhasorLabel = item.Field<string>("DestinationPhasorLabel"),
							  DeviceAcronym = item.Field<string>("DeviceAcronym"),
							  PhasorType = item.Field<string>("Type") == "V" ? "Voltage" : "Current",
							  PhaseType = item.Field<string>("Phase") == "+" ? "Positive" : item.Field<string>("Phase") == "-" ? "Negative" :
										  item.Field<string>("Phase") == "A" ? "Phase A" : item.Field<string>("Phase") == "B" ? "Phase B" : "Phase C"
						  }).ToList();

			connection.Dispose();
			return phasorList;
		}

		public static Dictionary<int, string> GetPhasors(int deviceID, bool isOptional)
		{
			Dictionary<int, string> phasorList = new Dictionary<int, string>();
			if (isOptional)
				phasorList.Add(0, "Select Phasor");

			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = "Select ID, Label From Phasor Where DeviceID = @deviceID Order By SourceIndex";
			command.Parameters.Add(AddWithValue(command, "@deviceID", deviceID));

			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());

			foreach (DataRow row in resultTable.Rows)
			{
				if (!phasorList.ContainsKey(Convert.ToInt32(row["ID"])))
					phasorList.Add(Convert.ToInt32(row["ID"]), row["Label"].ToString());
			}

			connection.Dispose();
			return phasorList;
		}

		public static string SavePhasor(Phasor phasor, bool isNew)
		{
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();

			if (isNew)
				command.CommandText = "Insert Into Phasor (DeviceID, Label, Type, Phase, DestinationPhasorID, SourceIndex) Values (@deviceID, @label, @type, @phase, " +
					"@destinationPhasorID, @sourceIndex)";
			else
				command.CommandText = "Update Phasor Set DeviceID =@deviceID, Label = @label, Type = @type, Phase = @phase, DestinationPhasorID = @destinationPhasorID, " +
					"SourceIndex = @sourceIndex Where ID = @id";

			command.Parameters.Add(AddWithValue(command, "@deviceID", phasor.DeviceID));
			command.Parameters.Add(AddWithValue(command, "@label", phasor.Label));
			command.Parameters.Add(AddWithValue(command, "@type", phasor.Type));
			command.Parameters.Add(AddWithValue(command, "@phase", phasor.Phase));
			command.Parameters.Add(AddWithValue(command, "@destinationPhasorID", phasor.DestinationPhasorID ?? (object)DBNull.Value));
			command.Parameters.Add(AddWithValue(command, "@sourceIndex", phasor.SourceIndex));

			if (!isNew)
				command.Parameters.Add(AddWithValue(command, "@id", phasor.ID));

			command.ExecuteNonQuery();
			connection.Dispose();

			Phasor addedPhasor = new Phasor();
			addedPhasor = GetPhasorByLabel(phasor.DeviceID, phasor.Label);

			Device device = new Device();
			device = GetDeviceByDeviceID(phasor.DeviceID);
			
			Measurement measurement;

			DataTable phasorSignalTypes = new DataTable();
			phasorSignalTypes = GetPhasorSignalTypes(phasor.Type);

			foreach (DataRow row in phasorSignalTypes.Rows)
			{
				measurement = new Measurement();
				measurement.HistorianID = device.HistorianID;
				measurement.DeviceID = device.ID;
				if (addedPhasor.DestinationPhasorID.HasValue)
					measurement.PointTag = device.CompanyAcronym + "_" + device.Acronym + "-" + GetPhasorByID(addedPhasor.DeviceID, (int)addedPhasor.DestinationPhasorID).Label + ":" + device.VendorAcronym + row["Abbreviation"].ToString();
				else
					measurement.PointTag = device.CompanyAcronym + "_" + device.Acronym + "-" + row["Suffix"].ToString() + addedPhasor.SourceIndex.ToString() + ":" + device.VendorAcronym + row["Abbreviation"].ToString();
				measurement.AlternateTag = string.Empty;
				measurement.SignalTypeID = Convert.ToInt32(row["ID"]);
				measurement.PhasorSourceIndex = addedPhasor.SourceIndex;
				measurement.SignalReference = device.Acronym + "-" + row["Suffix"].ToString() + addedPhasor.SourceIndex.ToString();
				measurement.Adder = 0.0d;
				measurement.Multiplier = 1.0d;
				measurement.Description = device.Name + " " + addedPhasor.Label + " " + device.VendorDeviceName + " " + addedPhasor.PhaseType + " " + row["Name"].ToString();
				measurement.Enabled = true;
				if (isNew)	//if it is a new phasor then add measurements as new.
					SaveMeasurement(measurement, true);
				else //Check if measurement exists, if so then update them otherwise add new.
				{
					Measurement existingMeasurement = new Measurement();
					existingMeasurement = GetMeasurementInfo(measurement.DeviceID, row["Suffix"].ToString(), measurement.PhasorSourceIndex);
					if (existingMeasurement == null)
						SaveMeasurement(measurement, true);
					else
					{
						measurement.SignalID = existingMeasurement.SignalID;
						SaveMeasurement(measurement, false);
					}
				}
			}

			return "Done!";
		}

		static Phasor GetPhasorByLabel(int deviceID, string label)
		{			
			List<Phasor> phasorList = new List<Phasor>();
			phasorList = (from item in GetPhasorList(deviceID)
					  where item.Label == label
					  select item).ToList();
			if (phasorList.Count > 0)
				return phasorList[0];
			else
				return null;
		}

		static Phasor GetPhasorByID(int deviceID, int phasorID)
		{
			List<Phasor> phasorList = new List<Phasor>();
			phasorList = (from item in GetPhasorList(deviceID)
					  where item.ID == phasorID
					  select item).ToList();
			if (phasorList.Count > 0)
				return phasorList[0];
			else
				return null;
		}

		static Phasor GetPhasorBySourceIndex(int deviceID, int sourceIndex)
		{
			List<Phasor> phasorList = new List<Phasor>();
			phasorList = (from item in GetPhasorList(deviceID)
						  where item.SourceIndex == sourceIndex
						  select item).ToList();
			if (phasorList.Count > 0)
				return phasorList[0];
			else
				return null;
		}

		#endregion

		#region " Manage Measurements Code"

		public static List<Measurement> GetMeasurementList(string nodeID)
		{
			List<Measurement> measurementList = new List<Measurement>();
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			if (string.IsNullOrEmpty(nodeID) || MasterNode(nodeID))
				command.CommandText = "Select * From MeasurementDetail Order By PointTag";
			else
			{
				command.CommandText = "Select * From MeasurementDetail Where NodeID = @nodeID Order By PointTag";
				command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));
			}
			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());

			measurementList = (from item in resultTable.AsEnumerable()
							   select new Measurement()
							   {
								   SignalID = item.Field<Guid>("SignalID").ToString(),
								   HistorianID = item.Field<int?>("HistorianID"),
								   PointID = item.Field<int>("PointID"),
								   DeviceID = item.Field<int>("DeviceID"),
								   PointTag = item.Field<string>("PointTag"),
								   AlternateTag = item.Field<string>("AlternateTag"),
								   SignalTypeID = item.Field<int>("SignalTypeID"),
								   PhasorSourceIndex = item.Field<int?>("PhasorSourceIndex"),
								   SignalReference = item.Field<string>("SignalReference"),
								   Adder = item.Field<double>("Adder"),
								   Multiplier = item.Field<double>("Multiplier"),
								   Description = item.Field<string>("Description"),
								   Enabled = item.Field<bool>("Enabled"),
								   HistorianAcronym = item.Field<string>("HistorianAcronym"),
								   DeviceAcronym = item.Field<string>("DeviceAcronym"),
								   SignalName = item.Field<string>("SignalName"),
								   SignalAcronym = item.Field<string>("SignalAcronym"),
								   SignalSuffix = item.Field<string>("SignalTypeSuffix"),
								   PhasorLabel = item.Field<string>("PhasorLabel")
							   }).ToList();

			connection.Dispose();
			return measurementList;
		}

		public static List<Measurement> GetMeasurementsByDevice(int deviceID)
		{
			List<Measurement> measurementList = new List<Measurement>();
			DataConnection connection = new DataConnection();
			IDbCommand commnad = connection.Connection.CreateCommand();
			commnad.CommandType = CommandType.Text;
			commnad.CommandText = "Select * From MeasurementDetail Where DeviceID = @deviceID Order By PointTag";
			commnad.Parameters.Add(AddWithValue(commnad, "@deviceID", deviceID));
			DataTable resultTable = new DataTable();
			resultTable.Load(commnad.ExecuteReader());

			measurementList = (from item in resultTable.AsEnumerable()
							   select new Measurement()
							   {
								   SignalID = item.Field<Guid>("SignalID").ToString(),
								   HistorianID = item.Field<int?>("HistorianID"),
								   PointID = item.Field<int>("PointID"),
								   DeviceID = item.Field<int>("DeviceID"),
								   PointTag = item.Field<string>("PointTag"),
								   AlternateTag = item.Field<string>("AlternateTag"),
								   SignalTypeID = item.Field<int>("SignalTypeID"),
								   PhasorSourceIndex = item.Field<int?>("PhasorSourceIndex"),
								   SignalReference = item.Field<string>("SignalReference"),
								   Adder = item.Field<double>("Adder"),
								   Multiplier = item.Field<double>("Multiplier"),
								   Description = item.Field<string>("Description"),
								   Enabled = item.Field<bool>("Enabled"),
								   HistorianAcronym = item.Field<string>("HistorianAcronym"),
								   DeviceAcronym = item.Field<string>("DeviceAcronym"),
								   SignalName = item.Field<string>("SignalName"),
								   SignalAcronym = item.Field<string>("SignalAcronym"),
								   SignalSuffix = item.Field<string>("SignalTypeSuffix"),
								   PhasorLabel = item.Field<string>("PhasorLabel")
							   }).ToList();

			connection.Dispose();
			return measurementList;
		}

		public static string SaveMeasurement(Measurement measurement, bool isNew)
		{
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();

			if (isNew)
				command.CommandText = "Insert Into Measurement (HistorianID, DeviceID, PointTag, AlternateTag, SignalTypeID, PhasorSourceIndex, SignalReference, Adder, Multiplier, Description, Enabled) " +
					"Values (@historianID, @deviceID, @pointTag, @alternateTag, @signalTypeID, @phasorSourceIndex, @signalReference, @adder, @multiplier, @description, @enabled)";
			else
				command.CommandText = "Update Measurement Set HistorianID = @historianID, DeviceID = @deviceID, PointTag = @pointTag, AlternateTag = @alternateTag, SignalTypeID = @signalTypeID, " +
					"PhasorSourceIndex = @phasorSourceIndex, SignalReference = @signalReference, Adder = @adder, Multiplier = @multiplier, Description = @description, Enabled = @enabled Where SignalID = @signalID";

			command.Parameters.Add(AddWithValue(command, "@historianID", measurement.HistorianID ?? (object)DBNull.Value));
			//command.Parameters.Add(AddWithValue(command, "@pointID", measurement.PointID));
			command.Parameters.Add(AddWithValue(command, "@deviceID", measurement.DeviceID ?? (object)DBNull.Value));
			command.Parameters.Add(AddWithValue(command, "@pointTag", measurement.PointTag));
			command.Parameters.Add(AddWithValue(command, "@alternateTag", measurement.AlternateTag));
			command.Parameters.Add(AddWithValue(command, "@signalTypeID", measurement.SignalTypeID));
			command.Parameters.Add(AddWithValue(command, "@phasorSourceIndex", measurement.PhasorSourceIndex ?? (object)DBNull.Value));
			command.Parameters.Add(AddWithValue(command, "@signalReference", measurement.SignalReference));
			command.Parameters.Add(AddWithValue(command, "@adder", measurement.Adder));
			command.Parameters.Add(AddWithValue(command, "@multiplier", measurement.Multiplier));
			command.Parameters.Add(AddWithValue(command, "@description", measurement.Description));
			command.Parameters.Add(AddWithValue(command, "@enabled", measurement.Enabled));

			if (!isNew)
				command.Parameters.Add(AddWithValue(command, "@signalID", measurement.SignalID));

			command.ExecuteNonQuery();
			connection.Dispose();
			return "Done!";
		}

		public static List<Measurement> GetMeasurementsForOutputStream(string nodeID, int outputStreamID)
		{
			List<Measurement> measurementList = new List<Measurement>();
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			if (string.IsNullOrEmpty(nodeID) || MasterNode(nodeID))
				command.CommandText = "Select * From MeasurementDetail Where PointID Not In (Select PointID From OutputStreamMeasurement Where AdapterID = @outputStreamID)";
			else
			{
				command.CommandText = "Select * From MeasurementDetail Where NodeID = @nodeID AND PointID Not In (Select PointID From OutputStreamMeasurement Where AdapterID = @outputStreamID)";
				command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));
			}
			command.Parameters.Add(AddWithValue(command, "@outputStreamID", outputStreamID));

			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());
			measurementList = (from item in resultTable.AsEnumerable()
							   select new Measurement()
							   {
								   SignalID = item.Field<Guid>("SignalID").ToString(),
								   HistorianID = item.Field<int?>("HistorianID"),
								   PointID = item.Field<int>("PointID"),
								   DeviceID = item.Field<int>("DeviceID"),
								   PointTag = item.Field<string>("PointTag"),
								   AlternateTag = item.Field<string>("AlternateTag"),
								   SignalTypeID = item.Field<int>("SignalTypeID"),
								   PhasorSourceIndex = item.Field<int?>("PhasorSourceIndex"),
								   SignalReference = item.Field<string>("SignalReference"),
								   Adder = item.Field<double>("Adder"),
								   Multiplier = item.Field<double>("Multiplier"),
								   Description = item.Field<string>("Description"),
								   Enabled = item.Field<bool>("Enabled"),
								   HistorianAcronym = item.Field<string>("HistorianAcronym"),
								   DeviceAcronym = item.Field<string>("DeviceAcronym"),
								   SignalName = item.Field<string>("SignalName"),
								   SignalAcronym = item.Field<string>("SignalAcronym"),
								   SignalSuffix = item.Field<string>("SignalTypeSuffix"),
								   PhasorLabel = item.Field<string>("PhasorLabel")
							   }).ToList();
			connection.Dispose();
			return measurementList;
		}

		public static Measurement GetMeasurementInfo(int? deviceID, string signalSuffix, int? phasorSourceIndex)	//we are using signal suffix because it remains same if phasor is current or voltage which helps in modifying existing measurement if phasor changes from voltage to current.
		{
			List<Measurement> measurementList = new List<Measurement>();
			measurementList = (from item in GetMeasurementsByDevice((int)deviceID)
							   where item.SignalSuffix == signalSuffix && item.PhasorSourceIndex == phasorSourceIndex 
							   select item).ToList();
			if (measurementList.Count > 0)
				return measurementList[0];
			else
				return null;
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

			command.Parameters.Add(AddWithValue(command, "@acronym", otherDevice.Acronym));
			command.Parameters.Add(AddWithValue(command, "@name", otherDevice.Name));
			command.Parameters.Add(AddWithValue(command, "@isConcentrator", otherDevice.IsConcentrator));
			command.Parameters.Add(AddWithValue(command, "@companyID", otherDevice.CompanyID ?? (object)DBNull.Value));
			command.Parameters.Add(AddWithValue(command, "@vendorDeviceID", otherDevice.VendorDeviceID ?? (object)DBNull.Value));
			command.Parameters.Add(AddWithValue(command, "@longitude", otherDevice.Longitude ?? (object)DBNull.Value));
			command.Parameters.Add(AddWithValue(command, "@latitude", otherDevice.Latitude ?? (object)DBNull.Value));
			command.Parameters.Add(AddWithValue(command, "@interconnectionID", otherDevice.InterconnectionID ?? (object)DBNull.Value));
			command.Parameters.Add(AddWithValue(command, "@planned", otherDevice.Planned));
			command.Parameters.Add(AddWithValue(command, "@desired", otherDevice.Desired));
			command.Parameters.Add(AddWithValue(command, "@inProgress", otherDevice.InProgress));

			if (!isNew)			
				command.Parameters.Add(AddWithValue(command, "@id", otherDevice.ID));
		
			command.ExecuteScalar();
			connection.Dispose();
			return "Done!";
		}

		public static OtherDevice GetOtherDeviceByDeviceID(int deviceID)
		{
			List<OtherDevice> otherDeviceList = new List<OtherDevice>();
			otherDeviceList = (from item in GetOtherDeviceList()
						   where item.ID == deviceID
						   select item).ToList();
			if (otherDeviceList.Count > 0)
				return otherDeviceList[0];
			else
				return null;
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
			command.CommandText = "Select ID, Name From Protocol Order By LoadOrder";
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

		#region " Manage Signal Types Code"

		public static Dictionary<int, string> GetSignalTypes(bool isOptional)
		{
			Dictionary<int, string> signalTypeList = new Dictionary<int, string>();
			if (isOptional)
				signalTypeList.Add(0, "Select Signal Type");

			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = "Select ID, Name From SignalType Order By Name";
			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());

			foreach (DataRow row in resultTable.Rows)
			{
				if (!signalTypeList.ContainsKey(Convert.ToInt32(row["ID"])))
					signalTypeList.Add(Convert.ToInt32(row["ID"]), row["Name"].ToString());
			}

			connection.Dispose();
			return signalTypeList;
		}

		static DataTable GetPmuSignalTypes()	//Do not use this method in WCF call or silverlight. It is for internal use only.
		{
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			command.CommandText = "Select * From SignalType Where Source = 'PMU' AND Suffix IN ('FQ', 'DF', 'SF')";
			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());
			return resultTable;
		}

		static DataTable GetPhasorSignalTypes(string phasorType)
		{
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			if (phasorType == "V")
				command.CommandText = "Select * From SignalType Where Source = 'Phasor' AND Acronym LIKE 'V%'";
			else
				command.CommandText = "Select * From SignalType Where Source = 'Phasor' AND Acronym LIKE 'I%'";
			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());
			return resultTable;
		}

		#endregion

		#region " Manage Calculated Measurements"

		public static List<CalculatedMeasurement> GetCalculatedMeasurementList(string nodeID)
		{
			List<CalculatedMeasurement> calculatedMeasurementList = new List<CalculatedMeasurement>();
			DataConnection connection = new DataConnection();
			IDbCommand command = connection.Connection.CreateCommand();
			command.CommandType = CommandType.Text;
			if (string.IsNullOrEmpty(nodeID) || MasterNode(nodeID))
				command.CommandText = "Select * From CalculatedMeasurementDetail Order By LoadOrder";
			else
			{
				command.CommandText = "Select * From CalculatedMeasurementDetail Where NodeID = @nodeID Order By LoadOrder";				
				command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));
			}

			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());
			calculatedMeasurementList = (from item in resultTable.AsEnumerable()
										 select new CalculatedMeasurement()
										 {
											 NodeId = item.Field<Guid>("NodeID").ToString(),
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

			command.Parameters.Add(AddWithValue(command, "@nodeID", calculatedMeasurement.NodeId));
			command.Parameters.Add(AddWithValue(command, "@acronym", calculatedMeasurement.Acronym));
			command.Parameters.Add(AddWithValue(command, "@name", calculatedMeasurement.Name));
			command.Parameters.Add(AddWithValue(command, "@assemblyName", calculatedMeasurement.AssemblyName));
			command.Parameters.Add(AddWithValue(command, "@typeName", calculatedMeasurement.TypeName));
			command.Parameters.Add(AddWithValue(command, "@connectionString", calculatedMeasurement.ConnectionString));
			command.Parameters.Add(AddWithValue(command, "@configSection", calculatedMeasurement.ConfigSection));
			command.Parameters.Add(AddWithValue(command, "@inputMeasurements", calculatedMeasurement.InputMeasurements));
			command.Parameters.Add(AddWithValue(command, "@outputMeasurements", calculatedMeasurement.OutputMeasurements));
			command.Parameters.Add(AddWithValue(command, "@minimumMeasurementsToUse", calculatedMeasurement.MinimumMeasurementsToUse));
			command.Parameters.Add(AddWithValue(command, "@framesPerSecond", calculatedMeasurement.FramesPerSecond));
			command.Parameters.Add(AddWithValue(command, "@lagTime", calculatedMeasurement.LagTime));
			command.Parameters.Add(AddWithValue(command, "@leadTime", calculatedMeasurement.LeadTime));
			command.Parameters.Add(AddWithValue(command, "@useLocalClockAsRealTime", calculatedMeasurement.UseLocalClockAsRealTime));
			command.Parameters.Add(AddWithValue(command, "@allowSortsByArrival", calculatedMeasurement.AllowSortsByArrival));
			command.Parameters.Add(AddWithValue(command, "@loadOrder", calculatedMeasurement.LoadOrder));
			command.Parameters.Add(AddWithValue(command, "@enabled", calculatedMeasurement.Enabled));

			if (!isNew)
				command.Parameters.Add(AddWithValue(command, "@id", calculatedMeasurement.ID));
			
			command.ExecuteNonQuery();			
			connection.Dispose();
			return "Done!";
		}

		#endregion

		#region " Manage Custom Adapters Code"

		public static List<Adapter> GetAdapterList(bool enabledOnly, AdapterType adapterType, string nodeID)
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
			if (string.IsNullOrEmpty(nodeID) || MasterNode(nodeID))
				command.CommandText = "Select * From " + viewName + " Order By LoadOrder";
			else
			{
				command.CommandText = "Select * From " + viewName + " Where NodeID = @nodeID Order By LoadOrder";				
				command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));
			}

			DataTable resultTable = new DataTable();
			resultTable.Load(command.ExecuteReader());
			adapterList = (from item in resultTable.AsEnumerable()
						   select new Adapter()
						   {
							   NodeID = item.Field<Guid>("NodeID").ToString(),
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

			command.Parameters.Add(AddWithValue(command, "@nodeID", adapter.NodeID));
			command.Parameters.Add(AddWithValue(command, "@adapterName", adapter.AdapterName));
			command.Parameters.Add(AddWithValue(command, "@assemblyName", adapter.AssemblyName));
			command.Parameters.Add(AddWithValue(command, "@typeName", adapter.TypeName));
			command.Parameters.Add(AddWithValue(command, "@connectionString", adapter.ConnectionString));
			command.Parameters.Add(AddWithValue(command, "@loadOrder", adapter.LoadOrder));
			command.Parameters.Add(AddWithValue(command, "@enabled", adapter.Enabled));

			if (!isNew)			
				command.Parameters.Add(AddWithValue(command, "@id", adapter.ID));

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
												   NodeID = obj.Field<Guid>("NodeID").ToString(),
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
								   NodeID = item.Field<Guid>("NodeID").ToString(),
								   ID = item.Field<int>("ID"),
								   Acronym = item.Field<string>("Acronym"),
								   Name = item.Field<string>("Name"),
								   CompanyMapAcronym = item.Field<string>("CompanyMapAcronym"),
								   CompanyName = item.Field<string>("CompanyName"),
								   VendorDeviceName = item.Field<string>("VendorDeviceName"),
								   Longitude = item.Field<decimal?>("Longitude"),
								   Latitude = item.Field<decimal?>("Latitude"),
								   Reporting = Convert.ToBoolean(item.Field<object>("Reporting"))
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
								   Reporting = Convert.ToBoolean(item.Field<object>("Reporting")),
								   InProgress = Convert.ToBoolean(item.Field<object>("InProgress")),
								   Planned = Convert.ToBoolean(item.Field<object>("Planned")),
								   Desired = Convert.ToBoolean(item.Field<object>("Desired"))
							   }).ToList();

			connection.Dispose();
			return mapDataList;
		}

		#endregion			
	}
}