//******************************************************************************************************
//  PhasorDataService.svc.cs - Gbtc
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
//  09/16/2009 - Mehulbhai Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.ServiceModel;
using openPDCManager.Data;
using openPDCManager.Data.BusinessObjects;
using openPDCManager.Data.Entities;

namespace openPDCManager.Services.Service
{
	// NOTE: If you change the class name "PhasorDataService" here, you must also update the reference to "PhasorDataService" in Web.config.	
	[ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
	public class PhasorDataService : IPhasorDataService
	{
		#region " Manage Company Code"				
		public List<Company> GetCompanyList()
		{
			try
			{
				return CommonFunctions.GetCompanyList(null);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetCompanyList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Company List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}			
		}
		public Dictionary<int, string> GetCompanies(bool isOptional)
		{
			try
			{
				return CommonFunctions.GetCompanies(null, isOptional);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetCompanyList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Companies", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public string SaveCompany(Company company, bool isNew)
		{
			try
			{
				return CommonFunctions.SaveCompany(null, company, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.SaveCompany", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Company Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
			
		}
		#endregion

		#region " Manage Historian Code"
		public List<Historian> GetHistorianList(string nodeID)
		{
			try
			{
				return CommonFunctions.GetHistorianList(null, nodeID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetHistorianList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Historian List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public string SaveHistorian(Historian historian, bool isNew)
		{
			try
			{
				return CommonFunctions.SaveHistorian(null, historian, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.SaveHistorian", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Historian Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public Dictionary<int, string> GetHistorians(bool enabledOnly, bool isOptional, bool includeSTAT)
		{
			try
			{
                return CommonFunctions.GetHistorians(null, enabledOnly, isOptional, includeSTAT);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetHistorians", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Historians", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		#endregion

		#region " Manage Vendor Code"
		public List<Vendor> GetVendorList()
		{
			try
			{
				return CommonFunctions.GetVendorList(null);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetVendorList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Vendor List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public Dictionary<int, string> GetVendors(bool isOptional)
		{
			try
			{
                return CommonFunctions.GetVendors(null, isOptional);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetVendors", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Vendors", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}			
		}
		public string SaveVendor(Vendor vendor, bool isNew)
		{
			try
			{
                return CommonFunctions.SaveVendor(null, vendor, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.SaveVendor", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Vendor Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}			
		}
		#endregion

		#region " Manage Vendor Device Code"
		public List<VendorDevice> GetVendorDeviceList()
		{
			try
			{
				return CommonFunctions.GetVendorDeviceList(null);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetVendorDeviceList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Vendor Device List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public string SaveVendorDevice(VendorDevice vendorDevice, bool isNew)
		{
			try
			{
                return CommonFunctions.SaveVendorDevice(null, vendorDevice, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.SaveVendorDevice", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Vendor Device Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public Dictionary<int, string> GetVendorDevices(bool isOptional)
		{
			try
			{
                return CommonFunctions.GetVendorDevices(null, isOptional);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetVendorDevices", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Vendor Devices", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		#endregion

		#region " Manage Node Code"
		public List<Node> GetNodeList(bool enabledOnly)
		{
			try
			{
                return CommonFunctions.GetNodeList(null, enabledOnly);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetNodeList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Node List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public Dictionary<string, string> GetNodes(bool enabledOnly, bool isOptional)
		{
			try
			{
                return CommonFunctions.GetNodes(null, enabledOnly, isOptional);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetNodes", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Nodes", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public string SaveNode(Node node, bool isNew)
		{
			try
			{
                return CommonFunctions.SaveNode(null, node, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.SaveNode", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Node Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public Node GetNodeByID(string id)
		{
            return CommonFunctions.GetNodeByID(null, id);
		}
		#endregion

		#region " Manage Device Code"
		public List<Device> GetDeviceList(string nodeID)
		{
			try
			{
                return CommonFunctions.GetDeviceList(null, nodeID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetDeviceList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Device List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public List<Device> GetDeviceListByParentID(int parentID)
		{
            return CommonFunctions.GetDeviceListByParentID(null, parentID);
		}
		public Dictionary<int, string> GetDevices(DeviceType deviceType, string nodeID, bool isOptional)
		{
			try
			{
                return CommonFunctions.GetDevices(null, deviceType, nodeID, isOptional);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetDevices", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Devices", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public string SaveDevice(Device device, bool isNew, int digitalCount, int analogCount)
		{
			try
			{
				return CommonFunctions.SaveDevice(null, device, isNew, digitalCount, analogCount);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.SaveDevice", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Device Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public Device GetDeviceByDeviceID(int deviceID)
		{
            return CommonFunctions.GetDeviceByDeviceID(null, deviceID);
		}
		public Device GetDeviceByAcronym(string acronym)
		{
            return CommonFunctions.GetDeviceByAcronym(null, acronym);
		}
		public Dictionary<int, string> GetDevicesForOutputStream(int outputStreamID, string nodeID)
		{
			try
			{
                return CommonFunctions.GetDevicesForOutputStream(null, outputStreamID, nodeID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetDevicesForOutputStream", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Devices For Output Stream", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public Device GetConcentratorDevice(int deviceID)
		{
            return CommonFunctions.GetConcentratorDevice(null, deviceID);
		}
		public string DeleteDevice(int deviceID)
		{
			try
			{
                return CommonFunctions.DeleteDevice(null, deviceID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.DeleteDevice", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Delete Device", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		#endregion

		#region " Manage Phasor Code"

		public List<Phasor> GetPhasorList(int deviceID)
		{
			try
			{
                return CommonFunctions.GetPhasorList(null, deviceID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetPhasorList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Phasor List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public Dictionary<int, string> GetPhasors(int deviceID, bool isOptional)
		{
			try
			{
                return CommonFunctions.GetPhasors(null, deviceID, isOptional);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.SavePhasor", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Phasors", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string SavePhasor(Phasor phasor, bool isNew)
		{
			try
			{
				return CommonFunctions.SavePhasor(null, phasor, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.SavePhasor", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Phasor Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		#endregion

		#region " Manage Measurement Code"

		public List<Measurement> GetMeasurementList(string nodeID)
		{
			try
			{
                return CommonFunctions.GetMeasurementList(null, nodeID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetMeasurementList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Measurement List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public List<Measurement> GetFilteredMeasurementsByDevice(int deviceID)
		{
			try
			{
                return CommonFunctions.GetFilteredMeasurementsByDevice(null, deviceID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetFilteredMeasurementsByDevice", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Filtered Measurements By Device", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string SaveMeasurement(Measurement measurement, bool isNew)
		{
			try
			{
				return CommonFunctions.SaveMeasurement(null, measurement, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.SaveMeasurement", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Measurement Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public List<Measurement> GetMeasurementsByDevice(int deviceID)
		{
			try
			{
                return CommonFunctions.GetMeasurementsByDevice(null, deviceID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetMeasurementsByDevice", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Measurements By Device", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public List<Measurement> GetMeasurementsForOutputStream(string nodeID, int outputStreamID)
		{
			try
			{
                return CommonFunctions.GetMeasurementsForOutputStream(null, nodeID, outputStreamID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetMeasurementsForOutputStream", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Measurements For Output Stream", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		#endregion

		#region " Manage Other Device Code"

		public List<OtherDevice> GetOtherDeviceList()
		{
			try
			{
				return CommonFunctions.GetOtherDeviceList(null);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetOtherDeviceList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Other Device List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string SaveOtherDevice(OtherDevice otherDevice, bool isNew)
		{
			try
			{
                return CommonFunctions.SaveOtherDevice(null, otherDevice, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.SaveOtherDevice", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Other Device Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public OtherDevice GetOtherDeviceByDeviceID(int deviceID)
		{
            return CommonFunctions.GetOtherDeviceByDeviceID(null, deviceID);
		}
		#endregion

		#region " Manage Interconnections Code"
		public Dictionary<int, string> GetInterconnections(bool isOptional)
		{
			try
			{
                return CommonFunctions.GetInterconnections(null, isOptional);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetInterconnections", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Interconnections", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		#endregion

		#region " Manage Protocols Code"

		public Dictionary<int, string> GetProtocols(bool isOptional)
		{
			try
			{
                return CommonFunctions.GetProtocols(null, isOptional);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetProtocols", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Protocols", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public int GetProtocolIDByAcronym(string acronym)
		{
            return CommonFunctions.GetProtocolIDByAcronym(null, acronym);
		}

		#endregion

		#region " Manage Signal Types Code"

		public Dictionary<int, string> GetSignalTypes(bool isOptional)
		{
			try
			{
                return CommonFunctions.GetSignalTypes(null, isOptional);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetSignalTypes", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Signal Types", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		#endregion

		#region " Manage Calculated Measurements Code"

		public List<CalculatedMeasurement> GetCalculatedMeasurementList(string nodeID)
		{
			try
			{
                return CommonFunctions.GetCalculatedMeasurementList(null, nodeID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetCalculatedMeasurementList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Calculated Measurement List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string SaveCalculatedMeasurement(CalculatedMeasurement calculatedMeasurement, bool isNew)
		{
			try
			{
                return CommonFunctions.SaveCalculatedMeasurement(null, calculatedMeasurement, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.SaveCalculatedMeasurement", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Calculated Measurement Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		#endregion

		#region " Manage Custom Adapters Code"

		public List<Adapter> GetAdapterList(bool enabledOnly, AdapterType adapterType, string nodeID)
		{
			try
			{
                return CommonFunctions.GetAdapterList(null, enabledOnly, adapterType, nodeID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetAdapterList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Adapter List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string SaveAdapter(Adapter adapter, bool isNew)
		{
			try
			{
                return CommonFunctions.SaveAdapter(null, adapter, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.SaveAdapter", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Adapter Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public List<IaonTree> GetIaonTreeData(string nodeID)
		{
			try
			{
				return CommonFunctions.GetIaonTreeData(null, nodeID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetIaonTreeData", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Iaon Tree Data", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		#endregion

		#region "Manage Output Stream Code"

		public List<OutputStream> GetOutputStreamList(bool enabledOnly, string nodeID)
		{
			try
			{
                return CommonFunctions.GetOutputStreamList(null, enabledOnly, nodeID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetOutputStreamList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Output Stream List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string SaveOutputStream(OutputStream outputStream, bool isNew)
		{
			try
			{
                return CommonFunctions.SaveOutputStream(null, outputStream, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.SaveOutputStream", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Output Stream Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

        public string DeleteOutputStream(int outputStreamID)
        {
            try
            {
                return CommonFunctions.DeleteOutputStream(null, outputStreamID);
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(null, "Service.DeleteOutputStream", ex);
                CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Delete Output Stream Information", SystemMessage = ex.Message };
                throw new FaultException<CustomServiceFault>(fault);
            }
        }

		#endregion
		
		#region " Manage Output Stream Device Code"

		public List<OutputStreamDevice> GetOutputStreamDeviceList(int outputStreamID, bool enabledOnly)
		{
			try
			{
                return CommonFunctions.GetOutputStreamDeviceList(null, outputStreamID, enabledOnly);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetOutputStreamDeviceList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Output Stream Device List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string SaveOutputStreamDevice(OutputStreamDevice outputStreamDevice, bool isNew, string originalAcronym)
		{
			try
			{
				return CommonFunctions.SaveOutputStreamDevice(null, outputStreamDevice, isNew, originalAcronym);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.SaveOutputStreamDevice", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Output Stream Device Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string DeleteOutputStreamDevice(int outputStreamID, List<string> devicesToBeDeleted)
		{
			try
			{
                return CommonFunctions.DeleteOutputStreamDevice(null, outputStreamID, devicesToBeDeleted);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.DeleteOutputStreamDevice", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Delete Output Stream Device", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string AddDevices(int outputStreamID, Dictionary<int, string> devicesToBeAdded, bool addDigitals, bool addAnalogs)
		{
			try
			{
                return CommonFunctions.AddDevices(null, outputStreamID, devicesToBeAdded, addDigitals, addAnalogs);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.AddDevices", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Output Stream Device(s)", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		#endregion

		#region " Manage Output Stream Measurements Code"

		public List<OutputStreamMeasurement> GetOutputStreamMeasurementList(int outputStreamID)
		{
			try
			{
                return CommonFunctions.GetOutputStreamMeasurementList(null, outputStreamID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetOutputStreamMeasurementList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Output Stream Measurement List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string SaveOutputStreamMeasurement(OutputStreamMeasurement outputStreamMeasurement, bool isNew)
		{
			try
			{
				return CommonFunctions.SaveOutputStreamMeasurement(null, outputStreamMeasurement, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.SaveOutputStreamMeasurement", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Output Stream Measurement Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string DeleteOutputStreamMeasurement(int outputStreamMeasurementID)
		{
			try
			{
                return CommonFunctions.DeleteOutputStreamMeasurement(null, outputStreamMeasurementID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.DeleteOutputStreamMeasurement", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Delete Output Stream Measurement", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		#endregion

		#region " Manage Output Stream Device Phasor Code"

		public List<OutputStreamDevicePhasor> GetOutputStreamDevicePhasorList(int outputStreamDeviceID)
		{
			try
			{
                return CommonFunctions.GetOutputStreamDevicePhasorList(null, outputStreamDeviceID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetOutputStreamDevicePhasorList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Output Stream Device Phasor List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string SaveOutputStreamDevicePhasor(OutputStreamDevicePhasor outputStreamDevicePhasor, bool isNew)
		{
			try
			{
				return CommonFunctions.SaveOutputStreamDevicePhasor(null, outputStreamDevicePhasor, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.SaveOutputStreamDevicePhasor", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Output Stream Device Phasor Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		#endregion

		#region " Manage Output Stream Device Analog Code"

		public List<OutputStreamDeviceAnalog> GetOutputStreamDeviceAnalogList(int outputStreamDeviceID)
		{
			try
			{
                return CommonFunctions.GetOutputStreamDeviceAnalogList(null, outputStreamDeviceID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetOutputStreamDeviceAnalogList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Output Stream Device Analog List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string SaveOutputStreamDeviceAnalog(OutputStreamDeviceAnalog outputStreamDeviceAnalog, bool isNew)
		{
			try
			{
				return CommonFunctions.SaveOutputStreamDeviceAnalog(null, outputStreamDeviceAnalog, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.SaveOutputStreamDeviceAnalog", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Output Stream Device Analog Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		#endregion

		#region " Manage Output Stream Device Digital Code"

		public List<OutputStreamDeviceDigital> GetOutputStreamDeviceDigitalList(int outputStreamDeviceID)
		{
			try
			{
                return CommonFunctions.GetOutputStreamDeviceDigitalList(null, outputStreamDeviceID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetOutputStreamDeviceDigitalList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Output Stream Device Digital List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string SaveOutputStreamDeviceDigital(OutputStreamDeviceDigital outputStreamDeviceDigital, bool isNew)
		{
			try
			{
				return CommonFunctions.SaveOutputStreamDeviceDigital(null, outputStreamDeviceDigital, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.SaveOutputStreamDeviceDigital", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Output Stream Device Digital Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		#endregion

		#region " Current Device Measurements Code"

		public ObservableCollection<DeviceMeasurementData> GetDeviceMeasurementData(string nodeID)
		{
			try
			{
                return CommonFunctions.GetDeviceMeasurementData(null, nodeID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetDeviceMeasurementsData", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Current Device Measurement Data", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		#endregion

		public Dictionary<string, string> GetTimeZones(bool isOptional)
		{
			try
			{
				return CommonFunctions.GetTimeZones(isOptional);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetTimeZones", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Get Timezones List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public List<MapData> GetMapData(MapType mapType, string nodeID)
		{
			try
			{
                return CommonFunctions.GetMapData(null, mapType, nodeID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetMapData", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Map Data", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public ConnectionSettings GetConnectionSettings(Stream inputStream)
		{
			try
			{
				return CommonFunctions.GetConnectionSettings(inputStream);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetConnectionSettings", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Parse Connection File", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		
		public List<WizardDeviceInfo> GetWizardConfigurationInfo(Stream inputStream)
		{
			try
			{
				return CommonFunctions.GetWizardConfigurationInfo(inputStream);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetWizardConfigurationInfo", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Parse Configuration File", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public List<WizardDeviceInfo> RetrieveConfigurationFrame(string nodeConnectionString, string deviceConnectionString, int protocolID)
		{
			try
			{ 
				return CommonFunctions.RetrieveConfigurationFrame(nodeConnectionString, deviceConnectionString, protocolID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.RetrieveConfigurationFrame", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Configuration", SystemMessage = ex.Message + " Error details: " + Environment.NewLine + CommonFunctions.s_responseMessage };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		
		public string SaveWizardConfigurationInfo(string nodeID, List<WizardDeviceInfo> wizardDeviceInfoList, string connectionString, int? protocolID, int? companyID, int? historianID, int? interconnectionID, int? parentID, bool skipDisableRealTimeData)
		{
			try
			{
                return CommonFunctions.SaveWizardConfigurationInfo(null, nodeID, wizardDeviceInfoList, connectionString, protocolID, companyID, historianID, interconnectionID, parentID, skipDisableRealTimeData);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.SaveWizardConfigurationInfo", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Configuration Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		
		public string GetExecutingAssemblyPath()
		{
			try
			{
				return CommonFunctions.GetExecutingAssemblyPath();
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetExecutingAssemblyPath", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Current Execution Path", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		
		public string SaveIniFile(Stream input)
		{
			try
			{
				return CommonFunctions.SaveIniFile(input);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.SaveIniFile", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Upload INI File", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		//public List<string> GetPorts()
		//{
		//    return CommonFunctions.GetPorts();
		//}

		public List<string> GetStopBits()
		{
			return CommonFunctions.GetStopBits();
		}

		public List<string> GetParities()
		{
			return CommonFunctions.GetParities();
		}

		public ObservableCollection<StatisticMeasurementData> GetStatisticMeasurementData(string nodeID)
		{
			try
			{
                return CommonFunctions.GetStatisticMeasurementData(null, nodeID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException(null, "Service.GetStatisticMeasurementData", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Statistic Measurements Data", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

        public string GetRuntimeID(string sourceTable, int sourceID)
        {
            return CommonFunctions.GetRuntimeID(null, sourceTable, sourceID);
        }   
	}
}
