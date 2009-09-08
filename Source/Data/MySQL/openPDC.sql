-- =============================================
-- openPDC Data Structures for MySQL  
-- James Ritchie Carroll
-- 09/01/2009
-- =============================================

-- Execute the following from the command prompt to create database:
-- 	mysql -uroot -p <"openPDC.sql"

CREATE DATABASE openPDC;
USE openPDC;

CREATE TABLE Runtime(
	ID INT AUTO_INCREMENT NOT NULL,
	SourceID INT NOT NULL,
	SourceTable NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_Runtime PRIMARY KEY (SourceID ASC, SourceTable ASC),
	CONSTRAINT IX_Runtime UNIQUE KEY (ID)
);

CREATE TABLE Company(
	ID INT AUTO_INCREMENT NOT NULL,
	Acronym NVARCHAR(50) NOT NULL,
	MapAcronym NCHAR(3) NOT NULL,
	Name NVARCHAR(100) NOT NULL,
	URL TEXT UNICODE  NULL,
	LoadOrder INT NOT NULL DEFAULT 0,
    CONSTRAINT PK_Company PRIMARY KEY (ID ASC)
);

CREATE TABLE ConfigurationEntity(
	SourceName NVARCHAR(100) NOT NULL,
	RuntimeName NVARCHAR(100) NOT NULL,
	Description TEXT UNICODE NULL,
	LoadOrder INT NOT NULL DEFAULT 0,
	Enabled BIT NOT NULL DEFAULT 0
);

CREATE TABLE Vendor(
	ID INT AUTO_INCREMENT NOT NULL,
	Acronym NVARCHAR(3) NULL,
	Name NVARCHAR(100) NOT NULL,
	PhoneNumber NVARCHAR(100) NULL,
	ContactEmail NVARCHAR(100) NULL,
	URL TEXT UNICODE NULL,
	CONSTRAINT PK_Vendor PRIMARY KEY (ID ASC)
);

CREATE TABLE Protocol(
	ID INT AUTO_INCREMENT NOT NULL,
	Acronym NVARCHAR(50) NOT NULL,
	Name NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_Protocol PRIMARY KEY (ID ASC)
);

CREATE TABLE SignalType(
	ID INT AUTO_INCREMENT NOT NULL,
	Name NVARCHAR(100) NOT NULL,
	Acronym NVARCHAR(4) NOT NULL,
	Suffix NVARCHAR(2) NOT NULL,
	Abbreviation NVARCHAR(2) NOT NULL,
	Source NVARCHAR(10) NOT NULL,
	EngineeringUnits NVARCHAR(10) NULL,
	CONSTRAINT PK_SignalType PRIMARY KEY (ID ASC)
);

CREATE TABLE Interconnection(
	ID INT AUTO_INCREMENT NOT NULL,
	Acronym NVARCHAR(50) NOT NULL,
	Name NVARCHAR(100) NOT NULL,
	LoadOrder INT NULL DEFAULT 0,
	CONSTRAINT PK_Interconnection PRIMARY KEY (ID ASC)
);

CREATE TABLE Node(
	ID NCHAR(36) NULL,
	Name NVARCHAR(100) NOT NULL,
	CompanyID INT NULL,
	Longitude DECIMAL(9, 6) NULL,
	Latitude DECIMAL(9, 6) NULL,
	Description TEXT UNICODE NULL,
	Image TEXT UNICODE NULL,
	Master BIT NOT NULL DEFAULT 0,
	LoadOrder INT NOT NULL DEFAULT 0,
	Enabled BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_Node PRIMARY KEY (ID ASC)
);

CREATE TRIGGER UpdateNodeGuid BEFORE INSERT ON Node FOR EACH ROW
SET NEW.ID = UUID();

CREATE TABLE OtherDevice(
	ID INT AUTO_INCREMENT NOT NULL,
	Acronym NVARCHAR(16) NOT NULL,
	Name NVARCHAR(100) NULL,
	IsConcentrator BIT NOT NULL DEFAULT 0,
	CompanyID INT NULL,
	VendorDeviceID INT NULL,
	Longitude DECIMAL(9, 6) NULL,
	Latitude DECIMAL(9, 6) NULL,
	InterconnectionID INT NULL,
	Planned BIT NOT NULL DEFAULT 0,
	Desired BIT NOT NULL DEFAULT 0,
	InProgress BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_OtherDevice PRIMARY KEY (ID ASC)
);

CREATE TABLE Device(
	NodeID NCHAR(36) NOT NULL,
	ID INT AUTO_INCREMENT NOT NULL,
	ParentID INT NULL,
	Acronym NVARCHAR(16) NOT NULL,
	Name NVARCHAR(100) NULL,
	IsConcentrator BIT NOT NULL DEFAULT 0,
	CompanyID INT NULL,
	HistorianID INT NULL,
	AccessID INT NOT NULL DEFAULT 0,
	VendorDeviceID INT NULL,
	ProtocolID INT NULL,
	Longitude DECIMAL(9, 6) NULL,
	Latitude DECIMAL(9, 6) NULL,
	InterconnectionID INT NULL,
	ConnectionString TEXT UNICODE NULL,
	TimeZone NVARCHAR(128) NULL,
	TimeAdjustmentTicks BIGINT NOT NULL DEFAULT 0,
	DataLossInterval FLOAT NOT NULL DEFAULT 35,
	ContactList TEXT UNICODE NULL,
	MeasuredLines INT NULL,
	LoadOrder INT NOT NULL DEFAULT 0,
	Enabled BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_Device PRIMARY KEY (ID ASC)
);

CREATE TABLE VendorDevice(
	ID INT AUTO_INCREMENT NOT NULL,
	VendorID INT NOT NULL DEFAULT 10,
	Name NVARCHAR(100) NOT NULL,
	Description TEXT UNICODE NULL,
	URL TEXT UNICODE NULL,
	CONSTRAINT PK_VendorDevice PRIMARY KEY (ID ASC)
);

CREATE TABLE OutputStreamDeviceDigital(
	NodeID NCHAR(36) NOT NULL,
	OutputStreamDeviceID INT NOT NULL,
	ID INT AUTO_INCREMENT NOT NULL,
	Label NVARCHAR(256) NOT NULL,
	LoadOrder INT NOT NULL DEFAULT 0,
	CONSTRAINT PK_OutputStreamDeviceDigital PRIMARY KEY (ID ASC)
);

CREATE TABLE OutputStreamDevicePhasor(
	NodeID NCHAR(36) NOT NULL,
	OutputStreamDeviceID INT NOT NULL,
	ID INT AUTO_INCREMENT NOT NULL,
	Label NVARCHAR(12) NOT NULL,
	Type NCHAR(1) NOT NULL DEFAULT 'V',
	Phase NCHAR(1) NOT NULL DEFAULT '+',
	LoadOrder INT NOT NULL DEFAULT 0,
	CONSTRAINT PK_OutputStreamDevicePhasor PRIMARY KEY (ID ASC)
);

CREATE TABLE OutputStreamDeviceAnalog(
	NodeID NCHAR(36) NOT NULL,
	OutputStreamDeviceID INT NOT NULL,
	ID INT AUTO_INCREMENT NOT NULL,
	Label NVARCHAR(16) NOT NULL,
	Type INT NOT NULL DEFAULT 0,
	LoadOrder INT NOT NULL DEFAULT 0,
	CONSTRAINT PK_OutputStreamDeviceAnalog PRIMARY KEY (ID ASC)
);

CREATE TABLE Measurement(
	SignalID NCHAR(36) NULL,
	HistorianID INT NULL,
	PointID INT AUTO_INCREMENT NOT NULL,
	DeviceID INT NOT NULL,
	PointTag NVARCHAR(50) NOT NULL,
	AlternateTag NVARCHAR(50) NULL,
	SignalTypeID INT NOT NULL,
	PhasorSourceIndex INT NULL,
	SignalReference TEXT UNICODE NOT NULL,
	Adder FLOAT NOT NULL DEFAULT 0.0,
	Multiplier FLOAT NOT NULL DEFAULT 1.0,
	Description TEXT UNICODE NULL,
	Enabled BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_Measurement PRIMARY KEY (SignalID ASC),
	CONSTRAINT IX_Measurement UNIQUE KEY (PointID ASC),
	CONSTRAINT IX_Measurement_PointTag UNIQUE KEY (PointTag ASC)
);

CREATE TRIGGER UpdateMeasurementGuid BEFORE INSERT ON Measurement FOR EACH ROW
SET NEW.SignalID = UUID();

CREATE TABLE OutputStreamMeasurement(
	NodeID NCHAR(36) NOT NULL,
	AdapterID INT NOT NULL,
	ID INT AUTO_INCREMENT NOT NULL,
	HistorianID INT NULL,
	PointID INT NOT NULL,
	SignalReference TEXT UNICODE NOT NULL,
	CONSTRAINT PK_OutputStreamMeasurement PRIMARY KEY (ID ASC)
);

CREATE TABLE OutputStreamDevice(
	NodeID NCHAR(36) NOT NULL,
	AdapterID INT NOT NULL,
	ID INT AUTO_INCREMENT NOT NULL,
	Acronym NVARCHAR(16) NOT NULL,
	BpaAcronym NVARCHAR(4) NULL,
	Name NVARCHAR(100) NOT NULL,
	LoadOrder INT NOT NULL DEFAULT 0,
	Enabled BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_OutputStreamDevice PRIMARY KEY (ID ASC)
);

CREATE TABLE Phasor(
	ID INT AUTO_INCREMENT NOT NULL,
	DeviceID INT NOT NULL,
	Label NVARCHAR(50) NOT NULL,
	Type NCHAR(1) NOT NULL DEFAULT 'V',
	Phase NCHAR(1) NOT NULL DEFAULT '+',
	DestinationPhasorID INT NULL,
	SourceIndex INT NOT NULL DEFAULT 0,
	CONSTRAINT PK_Phasor PRIMARY KEY (ID ASC)
);

CREATE TABLE CalculatedMeasurement(
	NodeID NCHAR(36) NOT NULL,
	ID INT AUTO_INCREMENT NOT NULL,
	Acronym NVARCHAR(50) NOT NULL,
	Name NVARCHAR(100) NULL,
	AssemblyName TEXT UNICODE NOT NULL,
	TypeName TEXT UNICODE NOT NULL,
	ConnectionString TEXT UNICODE NULL,
	ConfigSection NVARCHAR(100) NULL,
	InputMeasurements TEXT UNICODE NULL,
	OutputMeasurements TEXT UNICODE NULL,
	MinimumMeasurementsToUse INT NOT NULL DEFAULT -1,
	FramesPerSecond INT NOT NULL DEFAULT 30,
	LagTime FLOAT NOT NULL DEFAULT 3.0,
	LeadTime FLOAT NOT NULL DEFAULT 1.0,
	UseLocalClockAsRealTime BIT NOT NULL DEFAULT 0,
	AllowSortsByArrival BIT NOT NULL DEFAULT 0,
	LoadOrder INT NOT NULL DEFAULT 0,
	Enabled BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_CalculatedMeasurement PRIMARY KEY (ID ASC)
);

CREATE TABLE CustomActionAdapter(
	NodeID NCHAR(36) NOT NULL,
	ID INT AUTO_INCREMENT NOT NULL,
	AdapterName NVARCHAR(50) NOT NULL,
	AssemblyName TEXT UNICODE NOT NULL,
	TypeName TEXT UNICODE NOT NULL,
	ConnectionString TEXT UNICODE NULL,
	LoadOrder INT NOT NULL DEFAULT 0,
	Enabled BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_CustomActionAdapter PRIMARY KEY (ID ASC)
);

CREATE TABLE Historian(
	NodeID NCHAR(36) NOT NULL,
	ID INT AUTO_INCREMENT NOT NULL,
	Acronym NVARCHAR(50) NOT NULL,
	Name NVARCHAR(100) NULL,
	AssemblyName TEXT UNICODE NULL,
	TypeName TEXT UNICODE NULL,
	ConnectionString TEXT UNICODE NULL,
	IsLocal BIT NOT NULL DEFAULT 0,
	Description TEXT UNICODE NULL,
	LoadOrder INT NOT NULL DEFAULT 0,
	Enabled BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_Historian PRIMARY KEY (ID ASC)
);

CREATE TABLE CustomInputAdapter(
	NodeID NCHAR(36) NOT NULL,
	ID INT AUTO_INCREMENT NOT NULL,
	AdapterName NVARCHAR(50) NOT NULL,
	AssemblyName TEXT UNICODE NOT NULL,
	TypeName TEXT UNICODE NOT NULL,
	ConnectionString TEXT UNICODE NULL,
	LoadOrder INT NOT NULL DEFAULT 0,
	Enabled BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_CustomInputAdapter PRIMARY KEY (ID ASC)
);

CREATE TABLE OutputStream(
	NodeID NCHAR(36) NOT NULL,
	ID INT AUTO_INCREMENT NOT NULL,
	Acronym NVARCHAR(50) NOT NULL,
	Name NVARCHAR(100) NULL,
	Type INT NOT NULL DEFAULT 0,
	ConnectionString TEXT UNICODE NULL,
	IDCode INT NOT NULL DEFAULT 0,
	CommandChannel TEXT UNICODE NULL,
	AutoPublishConfigFrame BIT NOT NULL DEFAULT 0,
	AutoStartDataChannel BIT NOT NULL DEFAULT 1,
	NominalFrequency INT NOT NULL DEFAULT 60,
	FramesPerSecond INT NOT NULL DEFAULT 30,
	LagTime FLOAT NOT NULL DEFAULT 3.0,
	LeadTime FLOAT NOT NULL DEFAULT 1.0,
	UseLocalClockAsRealTime BIT NOT NULL DEFAULT 0,
	AllowSortsByArrival BIT NOT NULL DEFAULT 0,
	LoadOrder INT NOT NULL DEFAULT 0,
	Enabled BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_OutputStream PRIMARY KEY (ID ASC)
);

CREATE TABLE CustomOutputAdapter(
	NodeID NCHAR(36) NOT NULL,
	ID INT AUTO_INCREMENT NOT NULL,
	AdapterName NVARCHAR(50) NOT NULL,
	AssemblyName TEXT UNICODE NOT NULL,
	TypeName TEXT UNICODE NOT NULL,
	ConnectionString TEXT UNICODE NULL,
	LoadOrder INT NOT NULL DEFAULT 0,
	Enabled BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_CustomOutputAdapter PRIMARY KEY (ID ASC)
);

ALTER TABLE Node ADD CONSTRAINT FK_Node_Company FOREIGN KEY(CompanyID) REFERENCES Company (ID);

ALTER TABLE OtherDevice ADD CONSTRAINT FK_OtherDevice_Company FOREIGN KEY(CompanyID) REFERENCES Company (ID);

ALTER TABLE OtherDevice ADD CONSTRAINT FK_OtherDevice_Interconnection FOREIGN KEY(InterconnectionID) REFERENCES Interconnection (ID);

ALTER TABLE OtherDevice ADD CONSTRAINT FK_OtherDevice_VendorDevice FOREIGN KEY(VendorDeviceID) REFERENCES VendorDevice (ID);

ALTER TABLE Device ADD CONSTRAINT FK_Device_Company FOREIGN KEY(CompanyID) REFERENCES Company (ID);

ALTER TABLE Device ADD CONSTRAINT FK_Device_Device FOREIGN KEY(ParentID) REFERENCES Device (ID);

ALTER TABLE Device ADD CONSTRAINT FK_Device_Historian FOREIGN KEY(HistorianID) REFERENCES Historian (ID);

ALTER TABLE Device ADD CONSTRAINT FK_Device_Interconnection FOREIGN KEY(InterconnectionID) REFERENCES Interconnection (ID);

ALTER TABLE Device ADD CONSTRAINT FK_Device_Node FOREIGN KEY(NodeID) REFERENCES Node (ID);

ALTER TABLE Device ADD CONSTRAINT FK_Device_Protocol FOREIGN KEY(ProtocolID) REFERENCES Protocol (ID);

ALTER TABLE Device ADD CONSTRAINT FK_Device_VendorDevice FOREIGN KEY(VendorDeviceID) REFERENCES VendorDevice (ID);

ALTER TABLE VendorDevice ADD CONSTRAINT FK_VendorDevice_Vendor FOREIGN KEY(VendorID) REFERENCES Vendor (ID);

ALTER TABLE OutputStreamDeviceDigital ADD CONSTRAINT FK_OutputStreamDeviceDigital_Node FOREIGN KEY(NodeID) REFERENCES Node (ID);

ALTER TABLE OutputStreamDeviceDigital ADD CONSTRAINT FK_OutputStreamDeviceDigital_OutputStreamDevice FOREIGN KEY(OutputStreamDeviceID) REFERENCES OutputStreamDevice (ID);

ALTER TABLE OutputStreamDevicePhasor ADD CONSTRAINT FK_OutputStreamDevicePhasor_Node FOREIGN KEY(NodeID) REFERENCES Node (ID);

ALTER TABLE OutputStreamDevicePhasor ADD CONSTRAINT FK_OutputStreamDevicePhasor_OutputStreamDevice FOREIGN KEY(OutputStreamDeviceID) REFERENCES OutputStreamDevice (ID);

ALTER TABLE OutputStreamDeviceAnalog ADD CONSTRAINT FK_OutputStreamDeviceAnalog_Node FOREIGN KEY(NodeID) REFERENCES Node (ID);

ALTER TABLE OutputStreamDeviceAnalog ADD CONSTRAINT FK_OutputStreamDeviceAnalog_OutputStreamDevice FOREIGN KEY(OutputStreamDeviceID) REFERENCES OutputStreamDevice (ID);

ALTER TABLE Measurement ADD CONSTRAINT FK_Measurement_Device FOREIGN KEY(DeviceID) REFERENCES Device (ID);

ALTER TABLE Measurement ADD CONSTRAINT FK_Measurement_Historian FOREIGN KEY(HistorianID) REFERENCES Historian (ID);

ALTER TABLE Measurement ADD CONSTRAINT FK_Measurement_SignalType FOREIGN KEY(SignalTypeID) REFERENCES SignalType (ID);

ALTER TABLE OutputStreamMeasurement ADD CONSTRAINT FK_OutputStreamMeasurement_Historian FOREIGN KEY(HistorianID) REFERENCES Historian (ID);

ALTER TABLE OutputStreamMeasurement ADD CONSTRAINT FK_OutputStreamMeasurement_Measurement FOREIGN KEY(PointID) REFERENCES Measurement (PointID);

ALTER TABLE OutputStreamMeasurement ADD CONSTRAINT FK_OutputStreamMeasurement_Node FOREIGN KEY(NodeID) REFERENCES Node (ID);

ALTER TABLE OutputStreamMeasurement ADD CONSTRAINT FK_OutputStreamMeasurement_OutputStream FOREIGN KEY(AdapterID) REFERENCES OutputStream (ID);

ALTER TABLE OutputStreamDevice ADD CONSTRAINT FK_OutputStreamDevice_Node FOREIGN KEY(NodeID) REFERENCES Node (ID);

ALTER TABLE OutputStreamDevice ADD CONSTRAINT FK_OutputStreamDevice_OutputStream FOREIGN KEY(AdapterID) REFERENCES OutputStream (ID);

ALTER TABLE Phasor ADD CONSTRAINT FK_Phasor_Device FOREIGN KEY(DeviceID) REFERENCES Device (ID);

ALTER TABLE Phasor ADD CONSTRAINT FK_Phasor_Phasor FOREIGN KEY(DestinationPhasorID) REFERENCES Phasor (ID);

ALTER TABLE CalculatedMeasurement ADD CONSTRAINT FK_CalculatedMeasurement_Node FOREIGN KEY(NodeID) REFERENCES Node (ID);

ALTER TABLE CustomActionAdapter ADD CONSTRAINT FK_CustomActionAdapter_Node FOREIGN KEY(NodeID) REFERENCES Node (ID);

ALTER TABLE Historian ADD CONSTRAINT FK_Historian_Node FOREIGN KEY(NodeID) REFERENCES Node (ID);

ALTER TABLE CustomInputAdapter ADD CONSTRAINT FK_CustomInputAdapter_Node FOREIGN KEY(NodeID) REFERENCES Node (ID);

ALTER TABLE OutputStream ADD CONSTRAINT FK_OutputStream_Node FOREIGN KEY(NodeID) REFERENCES Node (ID);

ALTER TABLE CustomOutputAdapter ADD CONSTRAINT FK_CustomOutputAdapter_Node FOREIGN KEY(NodeID) REFERENCES Node (ID);

CREATE VIEW RuntimeOutputStreamMeasurement
AS
SELECT OutputStreamMeasurement.NodeID, Runtime.ID AS AdapterID, Historian.Acronym AS Historian, 
  OutputStreamMeasurement.PointID, OutputStreamMeasurement.SignalReference
FROM OutputStreamMeasurement LEFT OUTER JOIN
  Historian ON OutputStreamMeasurement.HistorianID = Historian.ID LEFT OUTER JOIN
  Runtime ON OutputStreamMeasurement.AdapterID = Runtime.SourceID AND Runtime.SourceTable = 'OutputStream'
ORDER BY OutputStreamMeasurement.HistorianID, OutputStreamMeasurement.PointID;

CREATE VIEW RuntimeHistorian
AS
SELECT Historian.NodeID, Runtime.ID, Historian.Acronym AS AdapterName,
  COALESCE(Historian.AssemblyName, 'TVA.Historian.dll') AS AssemblyName, 
  COALESCE(Historian.TypeName, IF(IsLocal = 1, 'TVA.Historian.TimeSeriesData.LocalOutputAdapter', 'TVA.Historian.TimeSeriesData.RemoteOutputAdapter')) AS TypeName, 
  Historian.ConnectionString + '; sourceIDs=' + Historian.Acronym AS ConnectionString
FROM Historian LEFT OUTER JOIN
  Runtime ON Historian.ID = Runtime.SourceID AND Runtime.SourceTable = 'Historian'
WHERE (Historian.Enabled <> 0)
ORDER BY Historian.LoadOrder;

CREATE VIEW RuntimeDevice
AS
SELECT Device.NodeID, Runtime.ID, Device.Acronym AS AdapterName, 'TVA.PhasorProtocols.dll' AS AssemblyName, 
  'TVA.PhasorProtocols.PhasorMeasurementMapper' AS TypeName,
  Device.ConnectionString + '; isConcentrator=' + CONVERT(Device.IsConcentrator, CHAR(10))
  + '; accessID=' + CONVERT(Device.AccessID, CHAR(10))
  + IF(Device.TimeZone IS NULL,'', '; timeZone=' + Device.TimeZone)
  + '; timeAdjustmentTicks=' + CONVERT(Device.TimeAdjustmentTicks, CHAR(10))
  + IF(Protocol.Acronym IS NULL, '', '; phasorProtocol=' + Protocol.Acronym)
  + '; dataLossInterval=' + CONVERT(Device.DataLossInterval, CHAR(10)) AS ConnectionString
FROM Device LEFT OUTER JOIN
  Protocol ON Device.ProtocolID = Protocol.ID LEFT OUTER JOIN
  Runtime ON Device.ID = Runtime.SourceID AND Runtime.SourceTable = 'Device'
WHERE (Device.Enabled <> 0)
ORDER BY Device.LoadOrder;

CREATE VIEW RuntimeCustomOutputAdapter
AS
SELECT CustomOutputAdapter.NodeID, Runtime.ID, CustomOutputAdapter.AdapterName, 
  CustomOutputAdapter.AssemblyName, CustomOutputAdapter.TypeName, CustomOutputAdapter.ConnectionString
FROM CustomOutputAdapter LEFT OUTER JOIN
  Runtime ON CustomOutputAdapter.ID = Runtime.SourceID AND Runtime.SourceTable = 'CustomOutputAdapter'
WHERE (CustomOutputAdapter.Enabled <> 0)
ORDER BY CustomOutputAdapter.LoadOrder;

CREATE VIEW RuntimeInputStreamDevice
AS
SELECT Device.NodeID, Runtime_P.ID AS ParentID, Runtime.ID, Device.Acronym, Device.AccessID
FROM Device LEFT OUTER JOIN
  Runtime ON Device.ID = Runtime.SourceID AND Runtime.SourceTable = 'Device' LEFT OUTER JOIN
  Runtime AS Runtime_P ON Device.ParentID = Runtime_P.SourceID AND Runtime_P.SourceTable = 'Device'
WHERE (Device.IsConcentrator = 0) AND (Device.Enabled <> 0) AND (Device.ParentID IS NOT NULL)
ORDER BY Device.LoadOrder;

CREATE VIEW RuntimeCustomInputAdapter
AS
SELECT CustomInputAdapter.NodeID, Runtime.ID, CustomInputAdapter.AdapterName, 
  CustomInputAdapter.AssemblyName, CustomInputAdapter.TypeName, CustomInputAdapter.ConnectionString
FROM CustomInputAdapter LEFT OUTER JOIN
  Runtime ON CustomInputAdapter.ID = Runtime.SourceID AND Runtime.SourceTable = 'CustomInputAdapter'
WHERE (CustomInputAdapter.Enabled <> 0)
ORDER BY CustomInputAdapter.LoadOrder;

CREATE VIEW RuntimeOutputStreamDevice
AS
SELECT OutputStreamDevice.NodeID, Runtime.ID AS ParentID, OutputStreamDevice.ID, OutputStreamDevice.Acronym, 
  OutputStreamDevice.BpaAcronym, OutputStreamDevice.Name, OutputStreamDevice.LoadOrder
FROM OutputStreamDevice LEFT OUTER JOIN
  Runtime ON OutputStreamDevice.AdapterID = Runtime.SourceID AND Runtime.SourceTable = 'OutputStream'
WHERE (OutputStreamDevice.Enabled <> 0)
ORDER BY OutputStreamDevice.LoadOrder;

CREATE VIEW RuntimeOutputStream
AS
SELECT OutputStream.NodeID, Runtime.ID, OutputStream.Acronym AS AdapterName, 
  'TVA.PhasorProtocols.dll' AS AssemblyName, 
  IF(Type = 1, 'TVA.PhasorProtocols.BpaPdcStream.Concentrator', 'TVA.PhasorProtocols.IeeeC37_118.Concentrator') AS TypeName,
  OutputStream.ConnectionString + '; framesPerSecond=' + CONVERT(OutputStream.FramesPerSecond, CHAR(10)) 
  + '; lagTime=' + CONVERT(OutputStream.LagTime, CHAR(10)) + '; leadTime=' + CONVERT(OutputStream.LeadTime, CHAR(10)) 
  + '; useLocalClockAsRealTime=' + CONVERT(OutputStream.UseLocalClockAsRealTime, CHAR(10)) 
  + '; allowSortsByArrival=' + CONVERT(OutputStream.AllowSortsByArrival, CHAR(10)) AS ConnectionString
FROM OutputStream LEFT OUTER JOIN
  Runtime ON OutputStream.ID = Runtime.SourceID AND Runtime.SourceTable = 'OutputStream'
WHERE (OutputStream.Enabled <> 0)
ORDER BY OutputStream.LoadOrder;

CREATE VIEW RuntimeCustomActionAdapter
AS
SELECT CustomActionAdapter.NodeID, Runtime.ID, CustomActionAdapter.AdapterName, 
  CustomActionAdapter.AssemblyName, CustomActionAdapter.TypeName, CustomActionAdapter.ConnectionString
FROM CustomActionAdapter LEFT OUTER JOIN
  Runtime ON CustomActionAdapter.ID = Runtime.SourceID AND Runtime.SourceTable = 'CustomActionAdapter'
WHERE (CustomActionAdapter.Enabled <> 0)
ORDER BY CustomActionAdapter.LoadOrder;

CREATE VIEW MeasurementDetail
AS
SELECT Device.CompanyID, Company.Acronym AS CompanyAcronym, Company.Name AS CompanyName, Measurement.HistorianID, 
  Historian.Acronym AS HistorianAcronym, Historian.ConnectionString AS HistorianConnectionString, Measurement.PointID, 
  Measurement.PointTag, Measurement.AlternateTag, Measurement.DeviceID, Device.Acronym AS DeviceAcronym, 
  Device.Name AS DeviceName, Device.Enabled AS DeviceEnabled, Device.ContactList, Device.VendorDeviceID, 
  VendorDevice.Name AS VendorDeviceName, VendorDevice.Description AS VendorDeviceDescription, Device.ProtocolID, 
  Protocol.Acronym AS ProtocolAcronym, Protocol.Name AS ProtocolName, Measurement.SignalTypeID, 
  Measurement.PhasorSourceIndex, Phasor.Label AS PhasorLabel, Phasor.Type AS PhasorType, Phasor.Phase, 
  Measurement.SignalReference, Measurement.Adder, Measurement.Multiplier, Measurement.Description, Measurement.Enabled, 
  COALESCE(SignalType.EngineeringUnits, '') AS EngineeringUnits, SignalType.Source, SignalType.Acronym AS SignalAcronym, 
  SignalType.Name AS SignalName, SignalType.Suffix AS SignalTypeSuffix, Device.Longitude, Device.Latitude
FROM Company RIGHT OUTER JOIN
  Device ON Company.ID = Device.CompanyID RIGHT OUTER JOIN
  Measurement LEFT OUTER JOIN
  SignalType ON Measurement.SignalTypeID = SignalType.ID ON Device.ID = Measurement.DeviceID LEFT OUTER JOIN
  Phasor ON Measurement.DeviceID = Phasor.DeviceID AND 
  Measurement.PhasorSourceIndex = Phasor.SourceIndex LEFT OUTER JOIN
  VendorDevice ON Device.VendorDeviceID = VendorDevice.ID LEFT OUTER JOIN
  Protocol ON Device.ProtocolID = Protocol.ID LEFT OUTER JOIN
  Historian ON Measurement.HistorianID = Historian.ID;

CREATE VIEW RuntimeCalculatedMeasurement
AS
SELECT CalculatedMeasurement.NodeID, Runtime.ID, CalculatedMeasurement.Acronym AS AdapterName, 
  CalculatedMeasurement.AssemblyName, CalculatedMeasurement.TypeName,
  IF(ConfigSection IS NULL, '', 'configurationSection=' + ConfigSection + '; ')
  + 'minimumMeasurementsToUse=' + CONVERT(CalculatedMeasurement.MinimumMeasurementsToUse, CHAR(10))
  + '; framesPerSecond=' + CONVERT(CalculatedMeasurement.FramesPerSecond, CHAR(10))
  + '; lagTime=' + CONVERT(CalculatedMeasurement.LagTime, CHAR(10)) 
  + '; leadTime=' + CONVERT(CalculatedMeasurement.LeadTime, CHAR(10))
  + IF(InputMeasurements IS NULL, '', '; inputMeasurementKeys={' + InputMeasurements + '}')
  + IF(OutputMeasurements IS NULL, '', '; outputMeasurements={' + OutputMeasurements + '}') AS ConnectionString
FROM CalculatedMeasurement LEFT OUTER JOIN
  Runtime ON CalculatedMeasurement.ID = Runtime.SourceID AND Runtime.SourceTable = 'CalculatedMeasurement'
WHERE (CalculatedMeasurement.Enabled <> 0)
ORDER BY CalculatedMeasurement.LoadOrder;

CREATE VIEW ActiveMeasurement
AS
SELECT Device.NodeID, Historian.Acronym + ':' + Measurement.PointID AS ID, Measurement.SignalID, Measurement.PointTag, 
	Measurement.AlternateTag, Measurement.SignalReference, Device.Acronym AS Device, Runtime.ID AS DeviceID, Protocol.Acronym AS Protocol,
	SignalType.Acronym AS SignalType, Phasor.Phase, Measurement.Adder, Measurement.Multiplier, Company.Acronym AS Company, 
	Device.Longitude, Device.Latitude, Measurement.Description
FROM Company RIGHT OUTER JOIN
	Device ON Company.ID = Device.CompanyID RIGHT OUTER JOIN
	Measurement LEFT OUTER JOIN
	SignalType ON Measurement.SignalTypeID = SignalType.ID ON Device.ID = Measurement.DeviceID LEFT OUTER JOIN
	Phasor ON Measurement.DeviceID = Phasor.DeviceID AND 
	Measurement.PhasorSourceIndex = Phasor.SourceIndex LEFT OUTER JOIN
	Protocol ON Device.ProtocolID = Protocol.ID LEFT OUTER JOIN
	Historian ON Measurement.HistorianID = Historian.ID LEFT OUTER JOIN
	Runtime ON Device.ID = Runtime.SourceID AND Runtime.SourceTable = 'Device'
WHERE (Device.Enabled <> 0);

CREATE VIEW IaonOutputAdapter
AS
SELECT NodeID, ID, AdapterName, AssemblyName, TypeName, ConnectionString
FROM RuntimeHistorian
UNION
SELECT NodeID, ID, AdapterName, AssemblyName, TypeName, ConnectionString
FROM RuntimeCustomOutputAdapter;

CREATE VIEW IaonInputAdapter
AS
SELECT NodeID, ID, AdapterName, AssemblyName, TypeName, ConnectionString
FROM RuntimeDevice
UNION
SELECT NodeID, ID, AdapterName, AssemblyName, TypeName, ConnectionString
FROM RuntimeCustomInputAdapter;

CREATE VIEW IaonActionAdapter
AS
SELECT NodeID, ID, AdapterName, AssemblyName, TypeName, ConnectionString
FROM RuntimeOutputStream
UNION
SELECT NodeID, ID, AdapterName, AssemblyName, TypeName, ConnectionString
FROM RuntimeCalculatedMeasurement
UNION
SELECT NodeID, ID, AdapterName, AssemblyName, TypeName, ConnectionString
FROM RuntimeCustomActionAdapter;

CREATE TRIGGER CustomActionAdapter_RuntimeSync_Insert AFTER INSERT ON CustomActionAdapter
FOR EACH ROW INSERT INTO Runtime (SourceID, SourceTable) VALUES(NEW.ID, 'CustomActionAdapter');

CREATE TRIGGER CustomActionAdapter_RuntimeSync_Delete BEFORE DELETE ON CustomActionAdapter
FOR EACH ROW DELETE FROM Runtime WHERE SourceID = OLD.ID AND SourceTable = 'CustomActionAdapter';

CREATE TRIGGER CustomInputAdapter_RuntimeSync_Insert AFTER INSERT ON CustomInputAdapter
FOR EACH ROW INSERT INTO Runtime (SourceID, SourceTable) VALUES(NEW.ID, 'CustomInputAdapter');

CREATE TRIGGER CustomInputAdapter_RuntimeSync_Delete BEFORE DELETE ON CustomInputAdapter
FOR EACH ROW DELETE FROM Runtime WHERE SourceID = OLD.ID AND SourceTable = 'CustomInputAdapter';

CREATE TRIGGER CustomOutputAdapter_RuntimeSync_Insert AFTER INSERT ON CustomOutputAdapter
FOR EACH ROW INSERT INTO Runtime (SourceID, SourceTable) VALUES(NEW.ID, 'CustomOutputAdapter');

CREATE TRIGGER CustomOutputAdapter_RuntimeSync_Delete BEFORE DELETE ON CustomOutputAdapter
FOR EACH ROW DELETE FROM Runtime WHERE SourceID = OLD.ID AND SourceTable = 'CustomOutputAdapter';

CREATE TRIGGER Device_RuntimeSync_Insert AFTER INSERT ON Device
FOR EACH ROW INSERT INTO Runtime (SourceID, SourceTable) VALUES(NEW.ID, 'Device');

CREATE TRIGGER Device_RuntimeSync_Delete BEFORE DELETE ON Device
FOR EACH ROW DELETE FROM Runtime WHERE SourceID = OLD.ID AND SourceTable = 'Device';

CREATE TRIGGER CalculatedMeasurement_RuntimeSync_Insert AFTER INSERT ON CalculatedMeasurement
FOR EACH ROW INSERT INTO Runtime (SourceID, SourceTable) VALUES(NEW.ID, 'CalculatedMeasurement');

CREATE TRIGGER CalculatedMeasurement_RuntimeSync_Delete BEFORE DELETE ON CalculatedMeasurement
FOR EACH ROW DELETE FROM Runtime WHERE SourceID = OLD.ID AND SourceTable = 'CalculatedMeasurement';

CREATE TRIGGER OutputStream_RuntimeSync_Insert AFTER INSERT ON OutputStream
FOR EACH ROW INSERT INTO Runtime (SourceID, SourceTable) VALUES(NEW.ID, 'OutputStream');

CREATE TRIGGER OutputStream_RuntimeSync_Delete BEFORE DELETE ON OutputStream
FOR EACH ROW DELETE FROM Runtime WHERE SourceID = OLD.ID AND SourceTable = 'OutputStream';

CREATE TRIGGER Historian_RuntimeSync_Insert AFTER INSERT ON Historian
FOR EACH ROW INSERT INTO Runtime (SourceID, SourceTable) VALUES(NEW.ID, 'Historian');

CREATE TRIGGER Historian_RuntimeSync_Delete BEFORE DELETE ON Historian
FOR EACH ROW DELETE FROM Runtime WHERE SourceID = OLD.ID AND SourceTable = 'Historian';

-- =============================================
-- Author:        Pinal C. Patel
-- Create date: 07/23/09
-- Description:   
-- =============================================
DELIMITER $$
CREATE PROCEDURE GetHistorianMetadata(plantCode VARCHAR(24))
BEGIN
	-- Fill the table variable with the rows for your result set
	DECLARE warningThreshold FLOAT;
	DECLARE alarmThreshold FLOAT;
	DECLARE voltage FLOAT;
	DECLARE amps FLOAT;

	CREATE TEMPORARY TABLE historianMetadata
	(
		HistorianID INT, 
		DataType INT,
		Name VARCHAR(40),
		Synonym1 VARCHAR(40),
		Synonym2 VARCHAR(40),
		Synonym3 VARCHAR(40),
		Description VARCHAR(80),
		HardwareInfo VARCHAR(512),
		Remarks VARCHAR(512),
		PlantCode VARCHAR(24),
		UnitNumber INT,
		SystemName VARCHAR(24),
		SourceID INT,
		Enabled INT,
		ScanRate FLOAT,
		CompressionMinTime INT,
		CompressionMaxTime INT,
		EngineeringUnits VARCHAR(24),
		LowWarning FLOAT,
		HighWarning FLOAT,
		LowAlarm FLOAT,
		HighAlarm FLOAT,
		LowRange FLOAT,
		HighRange FLOAT,
		CompressionLimit FLOAT,
		ExceptionLimit FLOAT,
		DisplayDigits INT,
		SetDescription VARCHAR(24),
		ClearDescription VARCHAR(24),
		AlarmState INT,
		ChangeSecurity INT,
		AccessSecurity INT,
		StepCheck INT,
		AlarmEnabled INT,
		AlarmFlags INT,
		AlarmDelay FLOAT,
		AlarmToFile INT,
		AlarmByEmail INT,
		AlarmByPager INT,
		AlarmByPhone INT,
		AlarmEmails VARCHAR(512),
		AlarmPagers VARCHAR(40),
		AlarmPhones VARCHAR(40)
	)
	TABLESPACE MEMORY;
	
	SET warningThreshold = 5.0 / 100.0;
	SET alarmThreshold = 10.0 / 100.0;
	SET voltage = 500000;
	SET amps = 3000;

	INSERT INTO historianMetadata
	SELECT 
		HistorianID             = PointID,
		DataType                = IF(SignalAcronym = 'DIGI', 1, 0),
		Name                    = PointTag,
		Synonym1                = SignalReference,
		Synonym2                = SignalAcronym,
		Synonym3                = AlternateTag,
		Description             = Description,
		HardwareInfo            = VendorDeviceDescription,
		Remarks                 = '',
		PlantCode               = HistorianAcronym,
		UnitNumber              = 1,
		SystemName              = DeviceAcronym,
		SourceID                = ProtocolID,
		Enabled                 = Enabled,
		ScanRate                = 1.0 / 30.0,
		CompressionMinTime      = 0,
		CompressionMaxTime      = 0,
		EngineeringUnits        = EngineeringUnits,
		LowWarning              = CASE SignalAcronym WHEN 'FREQ' THEN 59.95 WHEN 'VPHM' THEN voltage - voltage * warningThreshold WHEN 'IPHM' THEN 0 WHEN 'VPHA' THEN -181 WHEN 'IPHA' THEN -181 ELSE 0 END,
		HighWarning             = CASE SignalAcronym WHEN 'FREQ' THEN 60.05 WHEN 'VPHM' THEN voltage + voltage * warningThreshold WHEN 'IPHM' THEN amps + amps * warningThreshold WHEN 'VPHA' THEN 181 WHEN 'IPHA' THEN 181 ELSE 0 END,
		LowAlarm                = CASE SignalAcronym WHEN 'FREQ' THEN 59.90 WHEN 'VPHM' THEN voltage - voltage * alarmThreshold WHEN 'IPHM' THEN 0 WHEN 'VPHA' THEN -181 WHEN 'IPHA' THEN -181 ELSE 0 END,
		HighAlarm               = CASE SignalAcronym WHEN 'FREQ' THEN 60.10 WHEN 'VPHM' THEN voltage + voltage * alarmThreshold WHEN 'IPHM' THEN amps + amps * alarmThreshold WHEN 'VPHA' THEN 181 WHEN 'IPHA' THEN 181 ELSE 0 END,
		LowRange                = CASE SignalAcronym WHEN 'FREQ' THEN 59.95 WHEN 'VPHM' THEN voltage - voltage * warningThreshold WHEN 'IPHM' THEN 0 WHEN 'VPHA' THEN -180 WHEN 'IPHA' THEN -180 ELSE 0 END,
		HighRange               = CASE SignalAcronym WHEN 'FREQ' THEN 60.05 WHEN 'VPHM' THEN voltage + voltage * warningThreshold WHEN 'IPHM' THEN amps WHEN 'VPHA' THEN 180 WHEN 'IPHA' THEN 180 ELSE 0 END,
		CompressionLimit        = 0.0,
		ExceptionLimit          = 0.0,
		DisplayDigits           = CASE SignalAcronym WHEN 'DIGI' THEN 0 ELSE 7 END,
		SetDescription          = '',
		ClearDescription        = '',
		AlarmState              = 0,
		ChangeSecurity          = 5,
		AccessSecurity          = 0,
		StepCheck               = 0,
		AlarmEnabled            = 0,
		AlarmFlags              = 0,
		AlarmDelay              = 0,
		AlarmToFile             = 0,
		AlarmByEmail            = 0,
		AlarmByPager            = 0,
		AlarmByPhone            = 0,
		AlarmEmails             = ContactList,
		AlarmPagers             = '',
		AlarmPhones             = ''
	FROM MeasurementDetail
	WHERE HistorianAcronym LIKE plantCode
	ORDER BY HistorianID;

	SELECT * FROM historianMetadata;
	DROP TABLE historianMetadata;
END$$
DELIMITER ;

/*
CREATE FUNCTION StringToGuid(str CHAR(36)) RETURNS BINARY(16)
RETURN CONCAT(UNHEX(LEFT(str, 8)), UNHEX(MID(str, 10, 4)), UNHEX(MID(str, 15, 4)), UNHEX(MID(str, 20, 4)), UNHEX(RIGHT(str, 12)));

CREATE FUNCTION GuidToString(guid BINARY(16)) RETURNS CHAR(36) 
RETURN CONCAT(HEX(LEFT(guid, 4)), '-', HEX(MID(guid, 5, 2)), '-', HEX(MID(guid, 7, 2)), '-', HEX(MID(guid, 9, 2)), '-', HEX(RIGHT(guid, 6)));

CREATE FUNCTION NewGuid() RETURNS BINARY(16) 
RETURN StringToGuid(UUID());

DELIMITER $$
CREATE PROCEDURE GetFormattedMeasurements(measurementSql TEXT, includeAdjustments BIT, OUT measurements TEXT)
BEGIN
	DECLARE done INT DEFAULT 0;
	DECLARE measurementID INT;
	DECLARE archiveSource NVARCHAR(50);
	DECLARE adder FLOAT DEFAULT 0.0;
	DECLARE multiplier FLOAT DEFAULT 1.1;	
	DECLARE selectedMeasurements CURSOR FOR SELECT * FROM temp;
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;

	CREATE TEMPORARY TABLE temp
	(
		MeasurementID INT,
		ArchiveSource NVARCHAR(50),
		Adder FLOAT,
		Multiplier FLOAT
	)
	TABLESPACE MEMORY;
	
	SET @insertSQL = CONCAT('INSERT INTO temp ', measurementSql);
	PREPARE stmt FROM @insertSQL;
	EXECUTE stmt;
	DEALLOCATE PREPARE stmt;

	OPEN selectedMeasurements;	
	SET measurements = '';
	
	-- Step through selected measurements
	REPEAT
		-- Get next row from measurements SQL
		FETCH selectedMeasurements INTO measurementID, archiveSource, adder, multiplier;

		IF NOT done THEN
			IF LENGTH(measurements) > 0 THEN
				SET measurements = CONCAT(measurements, ';');
			END IF;
			
			IF includeAdjustments <> 0 AND (adder <> 0.0 OR multiplier <> 1.0) THEN
				SET measurements = CONCAT(measurements, archiveSource, ':', measurementID, ',', adder, ',', multiplier);
			ELSE
				SET measurements = CONCAT(measurements, archiveSource, ':', measurementID);
			END IF;

		END IF;
	UNTIL done END REPEAT;

	CLOSE selectedMeasurements;
	DROP TABLE temp;
END$$
DELIMITER ;

DELIMITER $$
CREATE FUNCTION FormatMeasurements(measurementSql TEXT, includeAdjustments BIT)
RETURNS TEXT 
BEGIN
    DECLARE measurements TEXT; 

	CALL GetFormattedMeasurements(measurementSql, includeAdjustments, measurements);

	IF LENGTH(measurements) > 0 THEN
		SET measurements = CONCAT('{', measurements, '}');
	ELSE
		SET measurements = NULL;
	END IF;
		
	RETURN measurements;
END$$
DELIMITER ;
*/
