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
//  07/05/2009 - Mehulbhi Thakkar
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
using System.Data.SqlClient;
using System.IO.Ports;
using System.Linq;
using openPDCManager.Web.Data.BusinessObjects;
using openPDCManager.Web.Data.Entities;

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
		////    SqlCommand command = new SqlCommand("Select *, Acronym + ': ' + [Name] As HistorianLongName From Historian Order By [Name]");
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
        public static string NullableQuote(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "NULL";

            return string.Concat("'", value, "'");
        }

        /// <summary>
        /// Returns NULL for values that are null.
        /// </summary>
        /// <param name="value">Value to return or make NULL.</param>
        public static string NullableValue<T>(T? value) where T : struct
        {
            if (value.HasValue)
                return value.ToString();

            return "NULL";
        }

		#region " Manage Companies Code"

		public static List<Company> GetCompanyList()
		{
			List<Company> companyList = new List<Company>();
            DataConnection connection = new DataConnection();
            DataTable resultTable = connection.RetrieveData("SELECT ID, Acronym, MapAcronym, Name, URL, LoadOrder FROM Company ORDER BY LoadOrder");

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

		public static Dictionary<int, string> GetCompanies()
		{
			Dictionary<int, string> companyList = new Dictionary<int, string>();			
            DataConnection connection = new DataConnection();
            DataTable resultTable = connection.RetrieveData("SELECT ID, Name FROM Company ORDER BY Name");
            int id;

            companyList.Add(0, "Select Company");

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
            string query;

			if (isNew)
				query = string.Format("INSERT INTO Company (Acronym, MapAcronym, Name, URL, LoadOrder) VALUES ('{0}', '{1}', '{2}', {3}, {4})", company.Acronym, company.MapAcronym, company.Name, NullableQuote(company.URL), company.LoadOrder);
			else
				query = string.Format("UPDATE Company SET Acronym = '{0}', MapAcronym = '{1}', Name = '{2}', URL = {3}, LoadOrder = {4} WHERE ID = {5}", company.Acronym, company.MapAcronym, company.Name, NullableQuote(company.URL), company.LoadOrder, company.ID);

            DataConnection connection = new DataConnection();
            connection.ExecuteNonQuery(query);
            connection.Dispose();

            return "Done!";
		}

		#endregion

        #region " Manage Historians Code"
		public static List<Historian> GetHistorianList()
		{
			List<Historian> historianList = new List<Historian>();
			DataConnection connection = new DataConnection();
			DataTable resultTable = connection.RetrieveData("Select H.NodeID, H.ID, H.Acronym, ISNULL(H.Name, '') AS Name, ISNULL(H.AssemblyName, '') AS AssemblyName, " +
													"ISNULL(H.TypeName, '') AS TypeName, ISNULL(H.ConnectionString, '') AS ConnectionString, H.IsLocal, " +
													"ISNULL(H.Description, '') AS Description, H.LoadOrder, H.Enabled, N.Name AS NodeName From Historian H, Node N " +
													"Where H.NodeID = N.ID Order By H.LoadOrder");
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
		public static string SaveHistorian(Historian historian, bool isNew)
		{
			string query;
			if (isNew)
				query = string.Format("Insert Into Historian (NodeID, Acronym, Name, AssemblyName, TypeName, ConnectionString, IsLocal, Description, LoadOrder, Enabled) Values ('{0}', '{1}', {2}, {3}, {4}, {5}, '{6}', {7}, {8}, '{9}'",
					historian.NodeID, historian.Acronym, NullableQuote(historian.Name), NullableQuote(historian.AssemblyName), NullableQuote(historian.TypeName), NullableQuote(historian.ConnectionString), historian.IsLocal, 
					NullableQuote(historian.Description), historian.LoadOrder, historian.Enabled);
			else
				query = string.Format("Update Historian Set NodeID = '{0}', Acronym = '{1}', Name = {2}, AssemblyName = {3}, TypeName = {4}, ConnectionString = {5}, IsLocal = '{6}', Description = {7}, LoadOrder = {8}, Enabled = '{9}' Where ID = {10}",
					historian.NodeID, historian.Acronym, NullableQuote(historian.Name), NullableQuote(historian.AssemblyName), NullableQuote(historian.TypeName), NullableQuote(historian.ConnectionString), historian.IsLocal, 
					NullableQuote(historian.Description), historian.LoadOrder, historian.Enabled, historian.ID);
			DataConnection connection = new DataConnection();
			connection.ExecuteScalar(query);
			connection.Dispose();
			return "Done!";
		}
        #endregion

        #region " Manage Nodes Code"
		public static List<Node> GetNodeList()
		{
			List<Node> nodeList = new List<Node>();			
			DataConnection connection = new DataConnection();
			DataTable resultTable = connection.RetrieveData("Select N.ID, N.Name, N.CompanyID, N.Longitude, N.Latitude, ISNULL(N.Description, '') AS Description, " +
													"ISNULL(N.Image, '') AS Image, N.Master, N.LoadOrder, N.Enabled, ISNULL(C.Name, '') AS CompanyName " +
													"From Node N, Company C Where N.CompanyID = C.ID Order By N.LoadOrder");

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
		public static Dictionary<Guid, string> GetNodes(bool ActiveOnly)
		{
			Dictionary<Guid, string> nodeList = new Dictionary<Guid, string>();
			string query = "Select ID, Name From Node";
			if (ActiveOnly)
				query += " Where Enabled = '1'";
			query += " Order By LoadOrder";
						
			DataConnection connection = new DataConnection();
			DataTable resultTable = connection.RetrieveData(query);
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
			string query;
			if (isNew)
				query = string.Format("Insert Into Node (Name, CompanyID, Longitude, Latitude, Description, Image, Master, LoadOrder, Enabled) Values ('{0}', {1}, {2}, {3}, {4}, {5}, '{6}', {7}, '{8}')",
					node.Name, NullableValue(node.CompanyID), NullableValue(node.Longitude), NullableValue(node.Latitude), NullableQuote(node.Description), NullableQuote(node.Image), node.Master, node.LoadOrder, node.Enabled);
			else
				query = string.Format("Update Node Set Name = '{0}', CompanyID = {1}, Longitude = {2}, Latitude = {3}, Description = {4}, Image = {5}, Master = '{6}', LoadOrder = {7}, Enabled = '{8}' Where ID = '{9}'",
					node.Name, NullableValue(node.CompanyID), NullableValue(node.Longitude), NullableValue(node.Latitude), NullableQuote(node.Description), NullableQuote(node.Image), node.Master, node.LoadOrder, node.Enabled, node.ID);

			DataConnection connection = new DataConnection();
			connection.ExecuteScalar(query);
			connection.Dispose();
			return "Done!";
		}
        #endregion
		
        #region " Manage Vendors Code"
		public static List<Vendor> GetVendorList()
		{
			List<Vendor> vendorList = new List<Vendor>();			
			DataConnection connection = new DataConnection();
			DataTable resultTable = connection.RetrieveData("Select ID, ISNULL(Acronym, '') AS Acronym, Name, ISNULL(PhoneNumber, '') AS PhoneNumber, " +
												"ISNULL(ContactEmail, '') AS ContactEmail, ISNULL(URL, '') AS URL FROM Vendor Order By [Name]");

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
		public static Dictionary<int, string> GetVendors()
		{
			Dictionary<int, string> vendorList = new Dictionary<int, string>();
			DataConnection connection = new DataConnection();
			DataTable resultTable = connection.RetrieveData("Select ID, Name From Vendor Order By Name");

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
			string query;
			if (isNew)
				query = string.Format("Insert Into Vendor (Acronym, Name, PhoneNumber, ContactEmail, URL) Values ({0}, '{1}', {2}, {3}, {4})", NullableQuote(vendor.Acronym), vendor.Name, NullableQuote(vendor.PhoneNumber), NullableQuote(vendor.ContactEmail), NullableQuote(vendor.URL));
			else
				query = string.Format("Update Vendor Set Acronym = {0}, Name = '{1}', PhoneNumber = {2}, ContactEmail = {3}, URL = {4} Where ID = {5}", NullableQuote(vendor.Acronym), vendor.Name, NullableQuote(vendor.PhoneNumber), NullableQuote(vendor.ContactEmail), NullableQuote(vendor.URL), vendor.ID);
						
			DataConnection connection = new DataConnection();
			connection.ExecuteScalar(query);
			connection.Dispose();
			return "Done!";
		}
        #endregion

        #region " Manage Vendor Devices Code"
		public static List<VendorDevice> GetVendorDeviceList()
		{
			List<VendorDevice> vendorDeviceList = new List<VendorDevice>();			
			DataConnection connection = new DataConnection();
			DataTable resultTable = connection.RetrieveData("Select VD.ID, VD.VendorID, VD.Name, ISNULL(VD.Description, '') AS Description, ISNULL(VD.URL, '') AS URL, " +
													"V.Name AS VendorName FROM VendorDevice VD, Vendor V WHERE VD.VendorID = V.ID Order By VD.Name");

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
			string query;
			if (isNew)
				query = string.Format("Insert Into VendorDevice (VendorID, Name, Description, URL) Values ({0}, '{1}', {2}, {3})", vendorDevice.VendorID, vendorDevice.Name, NullableQuote(vendorDevice.Description), NullableQuote(vendorDevice.URL));
			else
				query = string.Format("Update VendorDevice Set VendorID = {0}, Name = '{1}', Description = {2}, URL = {3} Where ID = {4}", vendorDevice.VendorID, vendorDevice.Name, NullableQuote(vendorDevice.Description), NullableQuote(vendorDevice.URL), vendorDevice.ID);

			DataConnection connection = new DataConnection();
			connection.ExecuteScalar(query);
			connection.Dispose();
			return "Done!";
		}
        #endregion

	}
}
