//******************************************************************************************************
//  IPhasorDataService.cs - Gbtc
//
//  Copyright © 2010, Grid Protection Alliance.  All Rights Reserved.
//
//  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
//  the NOTICE file distributed with this work for additional information regarding copyright ownership.
//  The GPA licenses this file to you under the Eclipse Public License -v 1.0 (the "License"); you may
//  not use this file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://www.opensource.org/licenses/eclipse-1.0.php
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  07/05/2009 - Mehulbhai Thakkar
//       Generated original version of source code.
//  09/15/2009 - Stephen C. Wills
//       Added new header and license agreement.
//
//******************************************************************************************************

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.ServiceModel;
using openPDCManager.Data.BusinessObjects;
using openPDCManager.Data.Entities;

namespace openPDCManager.Services.Service
{
	// NOTE: If you change the interface name "IPhasorDataService" here, you must also update the reference to "IPhasorDataService" in Web.config.
	/// <summary>
	/// Interface defines service and operation contract between WCF service and its consumers.
	/// </summary>
	[ServiceContract]
	public interface IPhasorDataService
	{

		#region " Manage Node Code"

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<Node> GetNodeList(bool enabledOnly);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		Dictionary<string, string> GetNodes(bool enabledOnly, bool isOptional);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		string SaveNode(Node node, bool isNew);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		Node GetNodeByID(string id);

		#endregion

		#region " Manage Company Code"

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<Company> GetCompanyList();

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		Dictionary<int, string> GetCompanies(bool isOptional);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		string SaveCompany(Company company, bool isNew);

		#endregion

		#region " Manage Historian Code"

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<Historian> GetHistorianList(string nodeID);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		string SaveHistorian(Historian historian, bool isNew);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		Dictionary<int, string> GetHistorians(bool enabledOnly, bool isOptional, bool includeSTAT);

		#endregion

		#region " Manage Vendor Code"

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<Vendor> GetVendorList();

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		Dictionary<int, string> GetVendors(bool isOptional);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		string SaveVendor(Vendor vendor, bool isNew);

		#endregion

		#region " Manage Vendor Device Code"

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<VendorDevice> GetVendorDeviceList();

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		string SaveVendorDevice(VendorDevice vendorDevice, bool isNew);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		Dictionary<int, string> GetVendorDevices(bool isOptional);

		#endregion

		#region " Manage Device Code"

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<Device> GetDeviceList(string nodeID);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<Device> GetDeviceListByParentID(int parentID);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		Dictionary<int, string> GetDevices(DeviceType deviceType, string nodeID, bool isOptional);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		string SaveDevice(Device device, bool isNew, int digitalCount, int analogCount);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		Device GetDeviceByDeviceID(int deviceID);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		Device GetDeviceByAcronym(string acronym);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		Dictionary<int, string> GetDevicesForOutputStream(int outputStreamID, string nodeID);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		Device GetConcentratorDevice(int deviceID);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		string DeleteDevice(int deviceID);

		#endregion

		#region " Manage Phasors Code"

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<Phasor> GetPhasorList(int deviceID);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		Dictionary<int, string> GetPhasors(int deviceID, bool isOptional);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		string SavePhasor(Phasor phasor, bool isNew);

		#endregion

		#region " Manage Measurements Code"

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<Measurement> GetMeasurementList(string nodeID);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<Measurement> GetFilteredMeasurementsByDevice(int deviceID);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		string SaveMeasurement(Measurement measurement, bool isNew);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<Measurement> GetMeasurementsByDevice(int deviceID);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<Measurement> GetMeasurementsForOutputStream(string nodeID, int outputStreamID);

		#endregion

		#region " Manage Other Device Code"

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<OtherDevice> GetOtherDeviceList();

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		string SaveOtherDevice(OtherDevice otherDevice, bool isNew);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		OtherDevice GetOtherDeviceByDeviceID(int deviceID);

		#endregion

		#region " Manage Interconnection Code"

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		Dictionary<int, string> GetInterconnections(bool isOptional);

		#endregion

		#region " Manage Protocols Code"

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		Dictionary<int, string> GetProtocols(bool isOptional);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		int GetProtocolIDByAcronym(string acronym);

		#endregion

		#region " Manage Signal Types Code"

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		Dictionary<int, string> GetSignalTypes(bool isOptional);

		#endregion

		#region " Manage Calculated Measurements Code"

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<CalculatedMeasurement> GetCalculatedMeasurementList(string nodeID);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		string SaveCalculatedMeasurement(CalculatedMeasurement calculatedMeasurement, bool isNew);

		#endregion

		#region " Manage Custom Adapters Code"

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<Adapter> GetAdapterList(bool enabledOnly, AdapterType adapterType, string nodeID);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		string SaveAdapter(Adapter adapter, bool isNew);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<IaonTree> GetIaonTreeData(string nodeID);

		#endregion

		#region " Manage Output Stream Code"

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<OutputStream> GetOutputStreamList(bool enabledOnly, string nodeID);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		string SaveOutputStream(OutputStream outputStream, bool isNew);

        [OperationContract]
        [FaultContract(typeof(CustomServiceFault))]
        string DeleteOutputStream(int outputStreamID);

		#endregion

		#region " Manage Output Stream Device Code"

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<OutputStreamDevice> GetOutputStreamDeviceList(int outputStreamID, bool enabledOnly);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		string SaveOutputStreamDevice(OutputStreamDevice outputStreamDevice, bool isNew, string originalAcronym);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		string DeleteOutputStreamDevice(int outputStreamID, List<string> devicesToBeDeleted);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		string AddDevices(int outputStreamID, Dictionary<int, string> devicesToBeAdded, bool addDigitals, bool addAnalogs);

		#endregion

		#region " Manage Output Stream Measurements Code"

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<OutputStreamMeasurement> GetOutputStreamMeasurementList(int outputStreamID);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		string SaveOutputStreamMeasurement(OutputStreamMeasurement outputStreamMeasurement, bool isNew);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		string DeleteOutputStreamMeasurement(int outputStreamMeasurementID);

		#endregion

		#region " Manage Output Stream Device Phasor Code"

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<OutputStreamDevicePhasor> GetOutputStreamDevicePhasorList(int outputStreamDeviceID);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		string SaveOutputStreamDevicePhasor(OutputStreamDevicePhasor outputStreamDevicePhasor, bool isNew);

		#endregion

		#region " Manage Output Stream Device Analog Code"

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<OutputStreamDeviceAnalog> GetOutputStreamDeviceAnalogList(int outputStreamDeviceID);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		string SaveOutputStreamDeviceAnalog(OutputStreamDeviceAnalog outputStreamDeviceAnalog, bool isNew);

		#endregion

		#region " Manage Output Stream Device Digital Code"

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<OutputStreamDeviceDigital> GetOutputStreamDeviceDigitalList(int outputStreamDeviceID);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		string SaveOutputStreamDeviceDigital(OutputStreamDeviceDigital outputStreamDeviceDigital, bool isNew);

		#endregion

		#region " Current Device Measurements Code"

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		ObservableCollection<DeviceMeasurementData> GetDeviceMeasurementData(string nodeID);

		#endregion

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		Dictionary<string, string> GetTimeZones(bool isOptional);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<MapData> GetMapData(MapType mapType, string nodeID);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		ConnectionSettings GetConnectionSettings(Stream inputStream);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<WizardDeviceInfo> GetWizardConfigurationInfo(Stream inputStream);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<WizardDeviceInfo> RetrieveConfigurationFrame(string nodeConnectionString, string deviceConnectionString, int protocolID);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		string SaveWizardConfigurationInfo(string nodeID, List<WizardDeviceInfo> wizardDeviceInfoList, string connectionString, int? protocolID, int? companyID, int? historianID, int? interconnectionID, int? parentID, bool skipDisableRealTimeData);

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		string GetExecutingAssemblyPath();

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		string SaveIniFile(Stream input);

		//[OperationContract]
		//[FaultContract(typeof(CustomServiceFault))]
		//List<string> GetPorts();

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<string> GetStopBits();

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		List<string> GetParities();

		[OperationContract]
		[FaultContract(typeof(CustomServiceFault))]
		ObservableCollection<StatisticMeasurementData> GetStatisticMeasurementData(string nodeID);

        [OperationContract]
        [FaultContract(typeof(CustomServiceFault))]
        string GetRuntimeID(string sourceTable, int sourceID);        
	}
}
