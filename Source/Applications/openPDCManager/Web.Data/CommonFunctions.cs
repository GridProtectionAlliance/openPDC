//*******************************************************************************************************
//  CommonFunctions.cs
//  Copyright © 2009 - TVA, all rights reserved - Gbtc
//
//  Build Environment: C#, Visual Studio 2008
//  Primary Developer: Mehul P. Thakkar
//      Office: INFO SVCS APP DEV, CHATTANOOGA - MR BK-C
//       Phone: 423/751-7571
//       Email: mpthakka@tva.gov
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  07/05/2009 - Mehul P. Thakkar
//       Generated original version of source code.
//
//*******************************************************************************************************

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
    public class CommonFunctions
    {    
		public static Dictionary<string, int> GetVendorDeviceDistribution()
        {
            Dictionary<string, int> deviceDistribution = new Dictionary<string,int>();
            string queryString = "SELECT dbo.Vendor.Name AS VendorName, COUNT(*) AS PmuCount FROM dbo.Pmu " +
                    "LEFT OUTER JOIN dbo.VendorDevice ON dbo.Pmu.VendorDeviceID = dbo.VendorDevice.ID " +
                    "INNER JOIN dbo.Vendor ON dbo.VendorDevice.VendorID = dbo.Vendor.ID WHERE (dbo.Pmu.Validated = '1') " +
                    "GROUP BY dbo.Vendor.Name Order By VendorName";
            SqlCommand command = new SqlCommand(queryString);
            DataAccess obj = new DataAccess();
            DataTable resultTable = new DataTable();
            resultTable = obj.GetDataTable(command, true);
            foreach (DataRow row in resultTable.Rows)
            {
                deviceDistribution.Add(row["VendorName"].ToString(), Convert.ToInt32(row["PmuCount"]));
            }
            return deviceDistribution;           
        }
        public static List<Pdc> GetPdcList()
        {
            List<Pdc> pdcList = new List<Pdc>();

            SqlCommand command = new SqlCommand("Select * From PdcDetail");
            DataAccess obj = new DataAccess();
            DataTable resultTable = new DataTable();
            resultTable = obj.GetDataTable(command, true);

            pdcList = (from item in resultTable.AsEnumerable()
                       orderby item.Field<string>("Acronym")
                      select new Pdc() { 
                          ID = item.Field<int>("ID"),
                          Acronym = item.Field<string>("Acronym"),
                          Name = item.Field<string>("Name"),
                          CompanyID = item.Field<int>("CompanyID"),
                          CompanyAcronym = item.Field<string>("CompanyAcronym"),
                          CompanyName = item.Field<string>("CompanyName"),
                          AccessID = item.Field<int>("AccessID"),
                          VendorDeviceID = item.Field<int>("VendorDeviceID"),
                          VendorDeviceName = item.Field<string>("VendorDeviceName"),
                          VendorDeviceDescription = item.Field<string>("VendorDeviceDescription"),
                          ProtocolID = item.Field<int>("ProtocolID"),
                          ProtocolAcronym = item.Field<string>("ProtocolAcronym"),
                          ProtocolName = item.Field<string>("ProtocolName"),
                          Longitude = item.Field<decimal>("Longitude"),
                          Latitude = item.Field<decimal>("Latitude"),
                          ConnectionString = item.Field<string>("ConnectionString"),
                          AdditionalConnectionInfo = item.Field<string>("AdditionalConnectionInfo"),
                          TimeZone = item.Field<string>("TimeZone"),
                          TimeOffsetTicks = item.Field<string>("TimeOffsetTicks"),
                          FramesPerSecond = item.Field<int>("FramesPerSecond"),
                          EmailList = item.Field<string>("EmailList"),
                          Enabled = item.Field<bool>("Enabled")
                      }).ToList();
            return pdcList;
        }
        public static List<BasicPmuInfo> GetValidatedPmuList()
        {
            List<BasicPmuInfo> pmuList = new List<BasicPmuInfo>();
            SqlCommand command = new SqlCommand("Select ID, Acronym, Name, CompanyName, CompanyAcronym, Longitude, Latitude, VendorName, ProtocolName, Reporting, Active From MapDataActiveState Where Validated = '1'");
            DataAccess obj = new DataAccess();
            DataTable resultTable = new DataTable();
            resultTable = obj.GetDataTable(command, true);
            pmuList = (from item in resultTable.AsEnumerable()
                       orderby item.Field<string>("Acronym")
                       select new BasicPmuInfo()
                       {
                          ID = item.Field<int>("ID"),
                          Acronym = item.Field<string>("Acronym"),
                          Name = item.Field<string>("Name"),
                          CompanyName = item.Field<string>("CompanyName"), 
                          CompanyAcronym = item.Field<string>("CompanyAcronym"),
                          Longitude = item.Field<decimal>("Longitude"),
                          Latitude = item.Field<decimal>("Latitude"),
                          DeviceName = item.Field<string>("VendorName"),
                          ProtocolName = item.Field<string>("ProtocolName"),
                          Reporting = item.Field<bool>("Reporting"),
                          Active = item.Field<bool>("Active")
                      }).ToList();
            return pmuList;
        }
		public static List<BasicPmuInfo> GetAllPmuList()
		{
			List<BasicPmuInfo> pmuList = new List<BasicPmuInfo>();
            SqlCommand command = new SqlCommand("Select ID, Acronym, Name, CompanyName, CompanyAcronym, Longitude, Latitude, VendorName, ProtocolName, Reporting, Active, Validated, InProgress From MapDataActiveState Where CompanyID = 29 AND BpaAcronym NOT IN ('BFNP','SQNP','MRFB','WRTC','ALCO')");
            DataAccess obj = new DataAccess();
            DataTable resultTable = new DataTable();
            resultTable = obj.GetDataTable(command, true);
            pmuList = (from item in resultTable.AsEnumerable()
                       orderby item.Field<string>("Acronym")
                       select new BasicPmuInfo()
                       {
                          ID = item.Field<int>("ID"),
                          Acronym = item.Field<string>("Acronym"),
                          Name = item.Field<string>("Name"),
                          CompanyName = item.Field<string>("CompanyName"), 
                          CompanyAcronym = item.Field<string>("CompanyAcronym"),
                          Longitude = item.Field<decimal>("Longitude"),
                          Latitude = item.Field<decimal>("Latitude"),
                          DeviceName = item.Field<string>("VendorName"),
                          ProtocolName = item.Field<string>("ProtocolName"),
                          Reporting = item.Field<bool>("Reporting"),
                          Active = item.Field<bool>("Active"),
						  Validated = item.Field<bool>("Validated"),
						  InProgress = item.Field<bool>("InProgress")
                      }).ToList();
            return pmuList;
		}
        public static List<InterconnectionStatus> GetInterconnectionStatus()
        {
            List<InterconnectionStatus> interConnectionStatusList = new List<InterconnectionStatus>();

            SqlCommand command = new SqlCommand("CompanyStatus");
            DataAccess obj = new DataAccess();
            DataSet resultSet = new DataSet();
            resultSet.Tables.Add(obj.GetDataTable(command, false));
            resultSet.Tables[0].TableName = "CurrentStatus";

            command = new SqlCommand("Select * From InterconnectionPmuSummary Order By PmuCount DESC, Interconnection");
            resultSet.Tables.Add(obj.GetDataTable(command, true));
            resultSet.Tables[1].TableName = "InterconnectionSummary";

            //resultSet.Relations.Add("InterconnectionSummary", resultSet.Tables["InterconnectionSummary"].Columns["Interconnection"],
            //                            resultSet.Tables["CurrentStatus"].Columns["Interconnection"]);

            interConnectionStatusList = (from item in resultSet.Tables["InterconnectionSummary"].AsEnumerable()
                                         select new InterconnectionStatus()
                                         {
                                             InterConnection = item.Field<string>("Interconnection"),
                                             TotalPmus = "Total " + item.Field<int>("PmuCount").ToString() + " PMUs",
                                             DisplayName = item.Field<string>("Description"),
                                             CompanyStatus = (from cs in resultSet.Tables["CurrentStatus"].AsEnumerable()
                                                              where cs.Field<string>("Interconnection") == item.Field<string>("Interconnection")
                                                              select new MemberStatus()
                                                              {
                                                                  Name = cs.Field<string>("CompanyName"),
                                                                  MeasuredLines = cs.Field<int>("MeasuredLines"),
                                                                  TotalDevices = cs.Field<int>("PmuCount"),
                                                                  ValidatedDevices = cs.Field<int>("ValidatedPmus"),
                                                                  ReportingDevices = cs.Field<int>("ReportingPmus"),
                                                                  Status = cs.Field<string>("Status")
                                                              }).ToList()
                                         }).ToList();

            return interConnectionStatusList;
        }
        public static List<PmuDistribution> GetPmuDistribution()
        {
            List<PmuDistribution> pmuDistributionList = new List<PmuDistribution>();

            SqlCommand command = new SqlCommand("PmuStatistics");
            DataAccess obj = new DataAccess();
            DataTable resultTable = new DataTable();
            resultTable = obj.GetDataTable(command, false);

            pmuDistributionList = (from item in resultTable.AsEnumerable()
                                   select new PmuDistribution()
                                   {   Status = item.Field<string>("Status"),
                                       EasternCount = item.Field<string>("Eastern"),
                                       WesternCount = item.Field<string>("Western"),
                                       TexasCount = item.Field<string>("Texas"),
                                       QuebecCount = item.Field<string>("Quebec"),
                                       AlaskanCount = item.Field<string>("Alaskan"),
                                       HawaiiCount = item.Field<string>("Hawaii"),
                                       Total = item.Field<int>("Total")
                                   }).ToList();
            return pmuDistributionList;
        }
        public static List<Historian> GetHistorianList()
        {
            List<Historian> historianList = new List<Historian>();
            SqlCommand command = new SqlCommand("Select *, Acronym + ': ' + [Name] As HistorianLongName From Historian Order By [Name]");
            DataAccess obj = new DataAccess();
            DataTable resultTable = new DataTable();
            resultTable = obj.GetDataTable(command, true);

            historianList = (from item in resultTable.AsEnumerable()
                             orderby item.Field<string>("Name")
                             select new Historian()
                             {
                                 ID = item.Field<int>("ID"),
                                 Acronym = item.Field<string>("Acronym"),
                                 Name = item.Field<string>("Name"),
                                 ConnectionString = item.Field<string>("ConnectionString"),
                                 Description = item.Field<string>("Description"),
                                 Enabled = item.Field<bool>("Enabled"),
                                 TypeName = item.Field<string>("TypeName"),
                                 AssemblyName = item.Field<string>("AssemblyName"),
                                 HistorianLongName = item.Field<string>("HistorianLongName")
                             }).ToList();

            return historianList;
        }
        public static List<CalculatedMeasurement> GetCalculatedMeasurementList()
        {
            List<CalculatedMeasurement> calculatedMeasurementList = new List<CalculatedMeasurement>();
            SqlCommand command = new SqlCommand("Select * From CalculatedMeasurement");
            DataAccess obj = new DataAccess();
            DataTable resultTable = new DataTable();
            resultTable = obj.GetDataTable(command, true);

            calculatedMeasurementList = (from item in resultTable.AsEnumerable()
                                         orderby item.Field<string>("Name")
                                         select new CalculatedMeasurement()
                                         {
                                             ID = item.Field<int>("ID"),
                                             Name = item.Field<string>("Name"),
                                             TypeName = item.Field<string>("TypeName"),
                                             AssemblyName = item.Field<string>("AssemblyName"),
                                             ConfigSection = item.Field<string>("ConfigSection"),
                                             OutputMeasurementsSql = item.Field<string>("OutputMeasurementsSql"),
                                             InputMeasurementsSql = item.Field<string>("InputMeasurementsSql"),
                                             MinimumInputMeasurements = item.Field<int>("MinimumInputMeasurements"),
                                             ExpectedFrameRate = item.Field<int>("ExpectedFrameRate"),
                                             //LagTime = item.Field<decimal>("LagTime"),
                                             //LeadTime = item.Field<decimal>("LeadTime"),
                                             Enabled = item.Field<bool>("Enabled")
                                         }).ToList();

            return calculatedMeasurementList;
        }
        public static List<OutputStream> GetOutputStreamList()
        {
            List<OutputStream> outputStreamList = new List<OutputStream>();
            SqlCommand command = new SqlCommand("Select ID, Name, Type, ConnectionString, IsNull(PmuFilterSql, '') AS PmuFilterSql, IDCode, FrameRate, NominalFrequency, LagTime, LeadTime, Enabled From Concentrator");
            DataAccess obj = new DataAccess();
            DataTable resultTable = new DataTable();
            resultTable = obj.GetDataTable(command, true);

            outputStreamList = (from item in resultTable.AsEnumerable()
                                orderby item.Field<string>("Name")
                                select new OutputStream()
                                {
                                    ID = item.Field<int>("ID"),
                                    Name = item.Field<string>("Name"),
                                    Type = item.Field<string>("Type"),
                                    ConnectionString = item.Field<string>("ConnectionString"),
                                    PmuFilterSql = item.Field<string>("PmuFilterSql"),
                                    IDCode = item.Field<int>("IDCode"),
                                    FrameRate = item.Field<int>("FrameRate"),
                                    NominalFrequency = item.Field<int>("NominalFrequency"),
									//LagTime = item.Field<decimal>("LagTime"),
									//LeadTime = item.Field<decimal>("LeadTime"),
                                    Enabled = item.Field<bool>("Enabled")
                                }).ToList();

            return outputStreamList;
        }
		public static Dictionary<int, string> GetCompanyList()
		{
			Dictionary<int, string> companyList = new Dictionary<int, string>();
			SqlCommand command = new SqlCommand("Select ID, Name From Company Order By Name");
			DataAccess obj = new DataAccess();
			DataTable resultTable = new DataTable();
			resultTable = obj.GetDataTable(command, true);
			foreach (DataRow row in resultTable.Rows)
			{
				companyList.Add(Convert.ToInt32(row["ID"]), row["Name"].ToString());
			}
			return companyList;
		}
		public static Dictionary<int, string> GetVendorList()
		{
			Dictionary<int, string> vendorList = new Dictionary<int, string>();
			SqlCommand command = new SqlCommand("Select ID, Description From VendorDevice Order By Description");
			DataAccess obj = new DataAccess();
			DataTable resultTable = new DataTable();
			resultTable = obj.GetDataTable(command, true);
			foreach (DataRow row in resultTable.Rows)
			{
				vendorList.Add(Convert.ToInt32(row["ID"]), row["Description"].ToString());
			}
			return vendorList;
		}
		public static Dictionary<int, string> GetProtocolList()
		{
			Dictionary<int, string> protocolList = new Dictionary<int, string>();
			SqlCommand command = new SqlCommand("Select ID, Name From Protocol Order By Name");
			DataAccess obj = new DataAccess();
			DataTable resultTable = new DataTable();
			resultTable = obj.GetDataTable(command, true);
			foreach (DataRow row in resultTable.Rows)
			{
				protocolList.Add(Convert.ToInt32(row["ID"]), row["Name"].ToString());
			}
			return protocolList;
		}
		public static List<string> GetTransportProtocolList()
		{
			List<string> transportProtocolList = new List<string>();
			transportProtocolList.Add("TCP");
			transportProtocolList.Add("UDP");
			transportProtocolList.Add("Serial");
			return transportProtocolList;
		}
		public static List<string> GetParityList()
		{
			List<string> parityList = new List<string>();
			foreach (string parity in Enum.GetNames(typeof(Parity)))
			{
				parityList.Add(parity);
			}
			return parityList;
		}
		public static List<string> GetStopBitList()
		{
			List<string> stopBitList = new List<string>();
			foreach (string stopBit in Enum.GetNames(typeof(StopBits)))
			{
				stopBitList.Add(stopBit);
			}
			return stopBitList;
		}
		public static Dictionary<string, string> GetTimeZonesList()
		{
			Dictionary<string, string> timeZoneList = new Dictionary<string, string>();

			List<TimeZoneInfo> timeZoneInfoList = System.TimeZoneInfo.GetSystemTimeZones().ToList<TimeZoneInfo>();
			foreach (TimeZoneInfo timeZoneInfo in timeZoneInfoList)
			{
				timeZoneList.Add(timeZoneInfo.DisplayName, timeZoneInfo.StandardName);
			}			
			return timeZoneList;
		}
		public static List<StatusReport> GetStatusReportList()
		{
			List<StatusReport> statusReportList = new List<StatusReport>();

			SqlCommand command = new SqlCommand("NaspiReportData");
			DataAccess obj = new DataAccess();
			DataSet resultSet = new DataSet();
			obj.GetDataSet(command, ref resultSet, false);

			//resultSet.Tables[0].TableName = "CompanyStatus";
			//resultSet.Tables[0].TableName = "PmuStatus";

			statusReportList = (from item in resultSet.Tables[0].AsEnumerable()
								select new StatusReport()
								{
									ID = item.Field<int>("ID"),
									Acronym = item.Field<string>("Acronym"),
									CompanyName = item.Field<string>("CompanyName"),
									Status = item.Field<string>("Status"),
									PmusStatus = (from ps in resultSet.Tables[1].AsEnumerable()
									              where ps.Field<int>("CompanyID") == item.Field<int>("ID")
									              select new PmuStatus()
									              {
									                  Acronym = ps.Field<string>("Acronym"),
									                  Name = ps.Field<string>("Name"),
									                  DeviceDescription = ps.Field<string>("DeviceDescription"),
									                  ProtocolName = ps.Field<string>("ProtocolName"),
													  StatusColor = (
																	ps.Field<bool>("Validated") == false ? "Gray" :
																	ps.Field<bool>("Reporting") == false ? "Red" : "Green"
																	)
									              }).ToList()
								}).ToList();

			return statusReportList;
		}
	}
}
