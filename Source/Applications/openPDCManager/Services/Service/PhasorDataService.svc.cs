//*******************************************************************************************************
//  PhasorDataService.svc.cs - Gbtc
//
//  Tennessee Valley Authority, 2009
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  This software is made freely available under the TVA Open Source Agreement (see below).
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  09/16/2009 - Mehulbhai Thakkar
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
using openPDCManager.Data;
using openPDCManager.Data.Entities;
using openPDCManager.Data.BusinessObjects;
using System.IO;
using System.ServiceModel;
using System.Collections.ObjectModel;

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
				return CommonFunctions.GetCompanyList();
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetCompanyList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Company List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}			
		}
		public Dictionary<int, string> GetCompanies(bool isOptional)
		{
			try
			{
				return CommonFunctions.GetCompanies(isOptional);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetCompanies", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Companies", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public string SaveCompany(Company company, bool isNew)
		{
			try
			{
				return CommonFunctions.SaveCompany(company, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.SaveCompany", ex);
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
				return CommonFunctions.GetHistorianList(nodeID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetHistorianList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Historian List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public string SaveHistorian(Historian historian, bool isNew)
		{
			try
			{
				return CommonFunctions.SaveHistorian(historian, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.SaveHistorian", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Historian Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public Dictionary<int, string> GetHistorians(bool enabledOnly, bool isOptional)
		{
			try
			{
				return CommonFunctions.GetHistorians(enabledOnly, isOptional);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetHistorians", ex);
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
				return CommonFunctions.GetVendorList();
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetVendorList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Vendor List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public Dictionary<int, string> GetVendors(bool isOptional)
		{
			try
			{
				return CommonFunctions.GetVendors(isOptional);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetVendors", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Vendors", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}			
		}
		public string SaveVendor(Vendor vendor, bool isNew)
		{
			try
			{
				return CommonFunctions.SaveVendor(vendor, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.SaveVendor", ex);
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
				return CommonFunctions.GetVendorDeviceList();
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetVendorDeviceList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Vendor Device List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public string SaveVendorDevice(VendorDevice vendorDevice, bool isNew)
		{
			try
			{
				return CommonFunctions.SaveVendorDevice(vendorDevice, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.SaveVendorDevice", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Vendor Device Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public Dictionary<int, string> GetVendorDevices(bool isOptional)
		{
			try
			{
				return CommonFunctions.GetVendorDevices(isOptional);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetVendorDevices", ex);
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
				return CommonFunctions.GetNodeList(enabledOnly);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetNodeList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Node List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public Dictionary<string, string> GetNodes(bool enabledOnly, bool isOptional)
		{
			try
			{
				return CommonFunctions.GetNodes(enabledOnly, isOptional);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetNodes", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Nodes", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public string SaveNode(Node node, bool isNew)
		{
			try
			{
				return CommonFunctions.SaveNode(node, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.SaveNode", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Node Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public Node GetNodeByID(string id)
		{
			return CommonFunctions.GetNodeByID(id);
		}
		#endregion

		#region " Manage Device Code"
		public List<Device> GetDeviceList(string nodeID)
		{
			try
			{
				return CommonFunctions.GetDeviceList(nodeID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetDeviceList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Device List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public List<Device> GetDeviceListByParentID(int parentID)
		{
			return CommonFunctions.GetDeviceListByParentID(parentID);
		}
		public Dictionary<int, string> GetDevices(DeviceType deviceType, string nodeID, bool isOptional)
		{
			try
			{
				return CommonFunctions.GetDevices(deviceType, nodeID, isOptional);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetDevices", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Devices", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public string SaveDevice(Device device, bool isNew, int digitalCount, int analogCount)
		{
			try
			{
				return CommonFunctions.SaveDevice(device, isNew, digitalCount, analogCount);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.SaveDevice", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Device Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public Device GetDeviceByDeviceID(int deviceID)
		{
			return CommonFunctions.GetDeviceByDeviceID(deviceID);
		}
		public Device GetDeviceByAcronym(string acronym)
		{
			return CommonFunctions.GetDeviceByAcronym(acronym);
		}
		public Dictionary<int, string> GetDevicesForOutputStream(int outputStreamID, string nodeID)
		{
			try
			{
				return CommonFunctions.GetDevicesForOutputStream(outputStreamID, nodeID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetDevicesForOutputStream", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Devices For Output Stream", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public Device GetConcentratorDevice(int deviceID)
		{
			return CommonFunctions.GetConcentratorDevice(deviceID);
		}
		public string DeleteDevice(int deviceID)
		{
			try
			{
				return CommonFunctions.DeleteDevice(deviceID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.DeleteDevice", ex);
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
				return CommonFunctions.GetPhasorList(deviceID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetPhasorList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Phasor List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public Dictionary<int, string> GetPhasors(int deviceID, bool isOptional)
		{
			try
			{
				return CommonFunctions.GetPhasors(deviceID, isOptional);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.SavePhasor", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Phasors", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string SavePhasor(Phasor phasor, bool isNew)
		{
			try
			{
				return CommonFunctions.SavePhasor(phasor, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.SavePhasor", ex);
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
				return CommonFunctions.GetMeasurementList(nodeID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetMeasurementList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Measurement List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public List<Measurement> GetFilteredMeasurementsByDevice(int deviceID)
		{
			try
			{
				return CommonFunctions.GetFilteredMeasurementsByDevice(deviceID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetFilteredMeasurementsByDevice", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Filtered Measurements By Device", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string SaveMeasurement(Measurement measurement, bool isNew)
		{
			try
			{
				return CommonFunctions.SaveMeasurement(measurement, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.SaveMeasurement", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Measurement Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public List<Measurement> GetMeasurementsByDevice(int deviceID)
		{
			try
			{
				return CommonFunctions.GetMeasurementsByDevice(deviceID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetMeasurementsByDevice", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Measurements By Device", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		public List<Measurement> GetMeasurementsForOutputStream(string nodeID, int outputStreamID)
		{
			try
			{
				return CommonFunctions.GetMeasurementsForOutputStream(nodeID, outputStreamID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetMeasurementsForOutputStream", ex);
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
				return CommonFunctions.GetOtherDeviceList();
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetOtherDeviceList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Other Device List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string SaveOtherDevice(OtherDevice otherDevice, bool isNew)
		{
			try
			{
				return CommonFunctions.SaveOtherDevice(otherDevice, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.SaveOtherDevice", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Other Device Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public OtherDevice GetOtherDeviceByDeviceID(int deviceID)
		{
			return CommonFunctions.GetOtherDeviceByDeviceID(deviceID);
		}
		#endregion

		#region " Manage Interconnections Code"
		public Dictionary<int, string> GetInterconnections(bool isOptional)
		{
			try
			{
				return CommonFunctions.GetInterconnections(isOptional);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetInterconnections", ex);
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
				return CommonFunctions.GetProtocols(isOptional);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetProtocols", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Protocols", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public int GetProtocolIDByAcronym(string acronym)
		{
			return CommonFunctions.GetProtocolIDByAcronym(acronym);
		}

		#endregion

		#region " Manage Signal Types Code"

		public Dictionary<int, string> GetSignalTypes(bool isOptional)
		{
			try
			{
				return CommonFunctions.GetSignalTypes(isOptional);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetSignalTypes", ex);
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
				return CommonFunctions.GetCalculatedMeasurementList(nodeID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetCalculatedMeasurementList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Calculated Measurement List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string SaveCalculatedMeasurement(CalculatedMeasurement calculatedMeasurement, bool isNew)
		{
			try
			{
				return CommonFunctions.SaveCalculatedMeasurement(calculatedMeasurement, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.SaveCalculatedMeasurement", ex);
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
			return CommonFunctions.GetAdapterList(enabledOnly, adapterType, nodeID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetAdapterList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Adapter List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string SaveAdapter(Adapter adapter, bool isNew)
		{
			try
			{
				return CommonFunctions.SaveAdapter(adapter, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.SaveAdapter", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Adapter Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public List<IaonTree> GetIaonTreeData(string nodeID)
		{
			try
			{
				return CommonFunctions.GetIaonTreeData(nodeID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetIaonTreeData", ex);
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
				return CommonFunctions.GetOutputStreamList(enabledOnly, nodeID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetOutputStreamList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Output Stream List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string SaveOutputStream(OutputStream outputStream, bool isNew)
		{
			try
			{
				return CommonFunctions.SaveOutputStream(outputStream, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.SaveOutputStream", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Output Stream Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		#endregion
		
		#region " Manage Output Stream Device Code"

		public List<OutputStreamDevice> GetOutputStreamDeviceList(int outputStreamID, bool enabledOnly)
		{
			try
			{
				return CommonFunctions.GetOutputStreamDeviceList(outputStreamID, enabledOnly);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetOutputStreamDeviceList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Output Stream Device List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string SaveOutputStreamDevice(OutputStreamDevice outputStreamDevice, bool isNew, string originalAcronym)
		{
			try
			{
				return CommonFunctions.SaveOutputStreamDevice(outputStreamDevice, isNew, originalAcronym);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.SaveOutputStreamDevice", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Output Stream Device Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string DeleteOutputStreamDevice(int outputStreamID, List<string> devicesToBeDeleted)
		{
			try
			{
				return CommonFunctions.DeleteOutputStreamDevice(outputStreamID, devicesToBeDeleted);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.DeleteOutputStreamDevice", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Delete Output Stream Device", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string AddDevices(int outputStreamID, Dictionary<int, string> devicesToBeAdded, bool addDigitals, bool addAnalogs)
		{
			try
			{
				return CommonFunctions.AddDevices(outputStreamID, devicesToBeAdded, addDigitals, addAnalogs);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.AddDevices", ex);
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
				return CommonFunctions.GetOutputStreamMeasurementList(outputStreamID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetOutputStreamMeasurementList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Output Stream Measurement List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string SaveOutputStreamMeasurement(OutputStreamMeasurement outputStreamMeasurement, bool isNew)
		{
			try
			{
				return CommonFunctions.SaveOutputStreamMeasurement(outputStreamMeasurement, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.SaveOutputStreamMeasurement", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Save Output Stream Measurement Information", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string DeleteOutputStreamMeasurement(int outputStreamMeasurementID)
		{
			try
			{
				return CommonFunctions.DeleteOutputStreamMeasurement(outputStreamMeasurementID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.DeleteOutputStreamMeasurement", ex);
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
				return CommonFunctions.GetOutputStreamDevicePhasorList(outputStreamDeviceID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetOutputStreamDevicePhasorList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Output Stream Device Phasor List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string SaveOutputStreamDevicePhasor(OutputStreamDevicePhasor outputStreamDevicePhasor, bool isNew)
		{
			try
			{
				return CommonFunctions.SaveOutputStreamDevicePhasor(outputStreamDevicePhasor, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.SaveOutputStreamDevicePhasor", ex);
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
				return CommonFunctions.GetOutputStreamDeviceAnalogList(outputStreamDeviceID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetOutputStreamDeviceAnalogList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Output Stream Device Analog List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string SaveOutputStreamDeviceAnalog(OutputStreamDeviceAnalog outputStreamDeviceAnalog, bool isNew)
		{
			try
			{
				return CommonFunctions.SaveOutputStreamDeviceAnalog(outputStreamDeviceAnalog, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.SaveOutputStreamDeviceAnalog", ex);
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
				return CommonFunctions.GetOutputStreamDeviceDigitalList(outputStreamDeviceID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetOutputStreamDeviceDigitalList", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Output Stream Device Digital List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public string SaveOutputStreamDeviceDigital(OutputStreamDeviceDigital outputStreamDeviceDigital, bool isNew)
		{
			try
			{
				return CommonFunctions.SaveOutputStreamDeviceDigital(outputStreamDeviceDigital, isNew);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.SaveOutputStreamDeviceDigital", ex);
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
				return CommonFunctions.GetDeviceMeasurementData(nodeID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetDeviceMeasurementsData", ex);
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
				CommonFunctions.LogException("Service.GetTimeZones", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Get Timezones List", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}

		public List<MapData> GetMapData(MapType mapType, string nodeID)
		{
			try
			{
				return CommonFunctions.GetMapData(mapType, nodeID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetMapData", ex);
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
				CommonFunctions.LogException("Service.GetConnectionSettings", ex);
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
				CommonFunctions.LogException("Service.GetWizardConfigurationInfo", ex);
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
				CommonFunctions.LogException("Service.RetrieveConfigurationFrame", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Configuration", SystemMessage = ex.Message + " Error details: " + Environment.NewLine + CommonFunctions.s_responseMessage };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
		
		public string SaveWizardConfigurationInfo(string nodeID, List<WizardDeviceInfo> wizardDeviceInfoList, string connectionString, int? protocolID, int? companyID, int? historianID, int? interconnectionID, int? parentID, bool skipDisableRealTimeData)
		{
			try
			{
				return CommonFunctions.SaveWizardConfigurationInfo(nodeID, wizardDeviceInfoList, connectionString, protocolID, companyID, historianID, interconnectionID, parentID, skipDisableRealTimeData);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.SaveWizardConfigurationInfo", ex);
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
				CommonFunctions.LogException("Service.GetExecutingAssemblyPath", ex);
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
				CommonFunctions.LogException("Service.SaveIniFile", ex);
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
				return CommonFunctions.GetStatisticMeasurementData(nodeID);
			}
			catch (Exception ex)
			{
				CommonFunctions.LogException("Service.GetStatisticMeasurementData", ex);
				CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Retrieve Statistic Measurements Data", SystemMessage = ex.Message };
				throw new FaultException<CustomServiceFault>(fault);
			}
		}
	}
}
