-- =============================================================================
-- openPDC Data Structures for MySQL 
--
-- Tennessee Valley Authority, 2009
-- No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
--
-- James Ritchie Carroll
-- 09/01/2009
-- =============================================================================

-- Execute the following from the command prompt to create database:
-- 	  mysql -uroot -p <"openPDC.sql"

CREATE DATABASE openPDC CHARACTER SET = latin1;
USE openPDC;

-- The following statements are used to create
-- a user with access to the database.
-- Be sure to change the username and password.
-- CREATE USER NewUser IDENTIFIED BY 'MyPassword';
-- GRANT SELECT, UPDATE, INSERT ON openPDC.* TO NewUser;

CREATE TABLE ErrorLog(
	ID INT AUTO_INCREMENT NOT NULL,
	Source NVARCHAR(256) NOT NULL,
	Message NVARCHAR(1024) NOT NULL,
	Detail LONGTEXT NULL,
	CreatedOn DATETIME NOT NULL DEFAULT 0,
	CONSTRAINT PK_ErrorLog PRIMARY KEY (ID ASC)
);

CREATE TRIGGER UpdateErrorLogDatetime BEFORE INSERT ON ErrorLog FOR EACH ROW
SET NEW.CreatedOn = NOW();

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
	URL LONGTEXT NULL,
	LoadOrder INT NOT NULL DEFAULT 0,
  CONSTRAINT PK_Company PRIMARY KEY (ID ASC)
);

CREATE TABLE ConfigurationEntity(
	SourceName NVARCHAR(100) NOT NULL,
	RuntimeName NVARCHAR(100) NOT NULL,
	Description LONGTEXT NULL,
	LoadOrder INT NOT NULL DEFAULT 0,
	Enabled TINYINT NOT NULL DEFAULT 0
);

CREATE TABLE Vendor(
	ID INT AUTO_INCREMENT NOT NULL,
	Acronym NVARCHAR(3) NULL,
	Name NVARCHAR(100) NOT NULL,
	PhoneNumber NVARCHAR(100) NULL,
	ContactEmail NVARCHAR(100) NULL,
	URL LONGTEXT NULL,
	CONSTRAINT PK_Vendor PRIMARY KEY (ID ASC)
);

CREATE TABLE Protocol(
	ID INT AUTO_INCREMENT NOT NULL,
	Acronym NVARCHAR(50) NOT NULL,
	Name NVARCHAR(100) NOT NULL,
	LoadOrder INT NOT NULL DEFAULT 0,
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
	Description LONGTEXT NULL,
	ImagePath LONGTEXT NULL,
	TimeSeriesDataServiceUrl LONGTEXT NULL,
	RemoteStatusServiceUrl LONGTEXT NULL,
	RealTimeStatisticServiceUrl LONGTEXT NULL,
	Master TINYINT NOT NULL DEFAULT 0,
	LoadOrder INT NOT NULL DEFAULT 0,
	Enabled TINYINT NOT NULL DEFAULT 0,
	CONSTRAINT PK_Node PRIMARY KEY (ID ASC)
);

CREATE TRIGGER UpdateNodeGuid BEFORE INSERT ON Node FOR EACH ROW
SET NEW.ID = UUID();

CREATE TABLE DataOperation(
	NodeID NCHAR(36) NULL,
	Description LONGTEXT NULL,
	AssemblyName TEXT NOT NULL,
	TypeName TEXT NOT NULL,
	MethodName NVARCHAR(255) NOT NULL,
	Arguments LONGTEXT NULL,
	LoadOrder INT NOT NULL DEFAULT 0,
	Enabled TINYINT NOT NULL DEFAULT 0
);

CREATE TABLE OtherDevice(
	ID INT AUTO_INCREMENT NOT NULL,
	Acronym NVARCHAR(16) NOT NULL,
	Name NVARCHAR(100) NULL,
	IsConcentrator TINYINT NOT NULL DEFAULT 0,
	CompanyID INT NULL,
	VendorDeviceID INT NULL,
	Longitude DECIMAL(9, 6) NULL,
	Latitude DECIMAL(9, 6) NULL,
	InterconnectionID INT NULL,
	Planned TINYINT NOT NULL DEFAULT 0,
	Desired TINYINT NOT NULL DEFAULT 0,
	InProgress TINYINT NOT NULL DEFAULT 0,
	CONSTRAINT PK_OtherDevice PRIMARY KEY (ID ASC)
);

CREATE TABLE Device(
	NodeID NCHAR(36) NOT NULL,
	ID INT AUTO_INCREMENT NOT NULL,
	ParentID INT NULL,
	Acronym NVARCHAR(16) NOT NULL,
	Name NVARCHAR(100) NULL,
	IsConcentrator TINYINT NOT NULL DEFAULT 0,
	CompanyID INT NULL,
	HistorianID INT NULL,
	AccessID INT NOT NULL DEFAULT 0,
	VendorDeviceID INT NULL,
	ProtocolID INT NULL,
	Longitude DECIMAL(9, 6) NULL,
	Latitude DECIMAL(9, 6) NULL,
	InterconnectionID INT NULL,
	ConnectionString LONGTEXT NULL,
	TimeZone NVARCHAR(128) NULL,
	FramesPerSecond INT NULL DEFAULT 30,
	TimeAdjustmentTicks BIGINT NOT NULL DEFAULT 0,
	DataLossInterval DOUBLE NOT NULL DEFAULT 5,
	AllowedParsingExceptions INT NOT NULL DEFAULT 10,
	ParsingExceptionWindow DOUBLE NOT NULL DEFAULT 5,
	DelayedConnectionInterval DOUBLE NOT NULL DEFAULT 5,
	AllowUseOfCachedConfiguration TINYINT NOT NULL DEFAULT 1,
	AutoStartDataParsingSequence TINYINT NOT NULL DEFAULT 1,
	SkipDisableRealTimeData TINYINT NOT NULL DEFAULT 0,
	MeasurementReportingInterval INT NOT NULL DEFAULT 100000,
	ContactList LONGTEXT NULL,
	MeasuredLines INT NULL,
	LoadOrder INT NOT NULL DEFAULT 0,
	Enabled TINYINT NOT NULL DEFAULT 0,
	CreatedOn DATETIME NOT NULL DEFAULT 0,
	CONSTRAINT PK_Device PRIMARY KEY (ID ASC),
	CONSTRAINT IX_Device_Acronym UNIQUE KEY (Acronym ASC)
);

CREATE TRIGGER UpdateDeviceDatetime BEFORE INSERT ON Device FOR EACH ROW
SET NEW.CreatedOn = NOW();

CREATE TABLE VendorDevice(
	ID INT AUTO_INCREMENT NOT NULL,
	VendorID INT NOT NULL DEFAULT 10,
	Name NVARCHAR(100) NOT NULL,
	Description LONGTEXT NULL,
	URL LONGTEXT NULL,
	CONSTRAINT PK_VendorDevice PRIMARY KEY (ID ASC)
);

CREATE TABLE OutputStreamDeviceDigital(
	NodeID NCHAR(36) NOT NULL,
	OutputStreamDeviceID INT NOT NULL,
	ID INT AUTO_INCREMENT NOT NULL,
	Label NVARCHAR(256) NOT NULL,
	MaskValue INT NOT NULL DEFAULT 0,
	LoadOrder INT NOT NULL DEFAULT 0,
	CONSTRAINT PK_OutputStreamDeviceDigital PRIMARY KEY (ID ASC)
);

CREATE TABLE OutputStreamDevicePhasor(
	NodeID NCHAR(36) NOT NULL,
	OutputStreamDeviceID INT NOT NULL,
	ID INT AUTO_INCREMENT NOT NULL,
	Label NVARCHAR(256) NOT NULL,
	Type NCHAR(1) NOT NULL DEFAULT 'V',
	Phase NCHAR(1) NOT NULL DEFAULT '+',
	ScalingValue INT NOT NULL DEFAULT 0,
	LoadOrder INT NOT NULL DEFAULT 0,
	CONSTRAINT PK_OutputStreamDevicePhasor PRIMARY KEY (ID ASC)
);

CREATE TABLE OutputStreamDeviceAnalog(
	NodeID NCHAR(36) NOT NULL,
	OutputStreamDeviceID INT NOT NULL,
	ID INT AUTO_INCREMENT NOT NULL,
	Label NVARCHAR(16) NOT NULL,
	Type INT NOT NULL DEFAULT 0,
	ScalingValue INT NOT NULL DEFAULT 0,
	LoadOrder INT NOT NULL DEFAULT 0,
	CONSTRAINT PK_OutputStreamDeviceAnalog PRIMARY KEY (ID ASC)
);

CREATE TABLE Measurement(
	SignalID NCHAR(36) NULL,
	HistorianID INT NULL,
	PointID INT AUTO_INCREMENT NOT NULL,
	DeviceID INT NULL,
	PointTag NVARCHAR(50) NOT NULL,
	AlternateTag NVARCHAR(50) NULL,
	SignalTypeID INT NOT NULL,
	PhasorSourceIndex INT NULL,
	SignalReference NVARCHAR(24) NOT NULL,
	Adder DOUBLE NOT NULL DEFAULT 0.0,
	Multiplier DOUBLE NOT NULL DEFAULT 1.0,
	Description LONGTEXT NULL,
	Enabled TINYINT NOT NULL DEFAULT 0,
	CONSTRAINT PK_Measurement PRIMARY KEY (SignalID ASC),
	CONSTRAINT IX_Measurement UNIQUE KEY (PointID ASC),
	CONSTRAINT IX_Measurement_PointTag UNIQUE KEY (PointTag ASC),
	CONSTRAINT IX_Measurement_SignalReference UNIQUE KEY (SignalReference ASC)
);

CREATE TRIGGER UpdateMeasurementGuid BEFORE INSERT ON Measurement FOR EACH ROW
SET NEW.SignalID = UUID();

CREATE TABLE ImportedMeasurement(
	NodeID NCHAR(36) NULL,
	SourceNodeID NCHAR(36) NULL,
	SignalID NCHAR(36) NULL,
	Source NVARCHAR(50) NOT NULL,
	PointID INT NOT NULL,
	PointTag NVARCHAR(50) NOT NULL,
	AlternateTag NVARCHAR(50) NULL,
	SignalTypeAcronym NVARCHAR(4) NULL,
	SignalReference NVARCHAR(24) NOT NULL,
	FramesPerSecond INT NULL,
	ProtocolAcronym NVARCHAR(50) NULL,
	PhasorID INT NULL,
	PhasorType NCHAR(1) NULL,
	Phase NCHAR(1) NULL,
	Adder DOUBLE NOT NULL DEFAULT 0.0,
	Multiplier DOUBLE NOT NULL DEFAULT 1.0,
	CompanyAcronym NVARCHAR(50) NULL,
	Longitude DECIMAL(9, 6) NULL,
	Latitude DECIMAL(9, 6) NULL,
	Description LONGTEXT NULL,
	Enabled TINYINT NOT NULL DEFAULT 0
);

CREATE TABLE Statistic(
	ID INT AUTO_INCREMENT NOT NULL,
	Source NVARCHAR(20) NOT NULL,
	SignalIndex INT NOT NULL,
	Name NVARCHAR(100) NOT NULL,
	Description LONGTEXT NULL,
	AssemblyName TEXT NOT NULL,
	TypeName TEXT NOT NULL,
	MethodName NVARCHAR(255) NOT NULL,
	Arguments LONGTEXT NULL,
	Enabled TINYINT NOT NULL DEFAULT 0,
	DataType NVARCHAR(255) NULL,
	DisplayFormat LONGTEXT NULL,
	IsConnectedState TINYINT NOT NULL DEFAULT 0,
	LoadOrder INT NOT NULL DEFAULT 0,
	CONSTRAINT PK_Statistic PRIMARY KEY (ID ASC),
	CONSTRAINT IX_Statistic_Source_SignalIndex UNIQUE KEY (Source ASC, SignalIndex ASC)
);

CREATE TABLE OutputStreamMeasurement(
	NodeID NCHAR(36) NOT NULL,
	AdapterID INT NOT NULL,
	ID INT AUTO_INCREMENT NOT NULL,
	HistorianID INT NULL,
	PointID INT NOT NULL,
	SignalReference TEXT NOT NULL,
	CONSTRAINT PK_OutputStreamMeasurement PRIMARY KEY (ID ASC)
);

CREATE TABLE OutputStreamDevice(
	NodeID NCHAR(36) NOT NULL,
	AdapterID INT NOT NULL,
	ID INT AUTO_INCREMENT NOT NULL,
	Acronym NVARCHAR(16) NOT NULL,
	BpaAcronym NVARCHAR(4) NULL,
	Name NVARCHAR(100) NOT NULL,
	PhasorDataFormat NVARCHAR(15) NULL,
	FrequencyDataFormat NVARCHAR(15) NULL,
	AnalogDataFormat NVARCHAR(15) NULL,
	CoordinateFormat NVARCHAR(15) NULL,
	LoadOrder INT NOT NULL DEFAULT 0,
	Enabled TINYINT NOT NULL DEFAULT 0,
	CONSTRAINT PK_OutputStreamDevice PRIMARY KEY (ID ASC)
);

CREATE TABLE Phasor(
	ID INT AUTO_INCREMENT NOT NULL,
	DeviceID INT NOT NULL,
	Label NVARCHAR(256) NOT NULL,
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
	AssemblyName TEXT NOT NULL,
	TypeName TEXT NOT NULL,
	ConnectionString LONGTEXT NULL,
	ConfigSection NVARCHAR(100) NULL,
	InputMeasurements LONGTEXT NULL,
	OutputMeasurements LONGTEXT NULL,
	MinimumMeasurementsToUse INT NOT NULL DEFAULT -1,
	FramesPerSecond INT NOT NULL DEFAULT 30,
	LagTime DOUBLE NOT NULL DEFAULT 3.0,
	LeadTime DOUBLE NOT NULL DEFAULT 1.0,
	UseLocalClockAsRealTime TINYINT NOT NULL DEFAULT 0,
	AllowSortsByArrival TINYINT NOT NULL DEFAULT 1,
	IgnoreBadTimeStamps TINYINT NOT NULL DEFAULT 0,
	TimeResolution INT NOT NULL DEFAULT 10000,
	AllowPreemptivePublishing TINYINT NOT NULL DEFAULT 1,
	DownsamplingMethod NVARCHAR(15) NOT NULL DEFAULT N'LastReceived',
	LoadOrder INT NOT NULL DEFAULT 0,
	Enabled TINYINT NOT NULL DEFAULT 0,
	CONSTRAINT PK_CalculatedMeasurement PRIMARY KEY (ID ASC)
);

CREATE TABLE CustomActionAdapter(
	NodeID NCHAR(36) NOT NULL,
	ID INT AUTO_INCREMENT NOT NULL,
	AdapterName NVARCHAR(50) NOT NULL,
	AssemblyName TEXT NOT NULL,
	TypeName TEXT NOT NULL,
	ConnectionString LONGTEXT NULL,
	LoadOrder INT NOT NULL DEFAULT 0,
	Enabled TINYINT NOT NULL DEFAULT 0,
	CONSTRAINT PK_CustomActionAdapter PRIMARY KEY (ID ASC)
);

CREATE TABLE Historian(
	NodeID NCHAR(36) NOT NULL,
	ID INT AUTO_INCREMENT NOT NULL,
	Acronym NVARCHAR(50) NOT NULL,
	Name NVARCHAR(100) NULL,
	AssemblyName LONGTEXT NULL,
	TypeName LONGTEXT NULL,
	ConnectionString LONGTEXT NULL,
	IsLocal TINYINT NOT NULL DEFAULT 1,
	MeasurementReportingInterval INT NOT NULL DEFAULT 100000,
	Description LONGTEXT NULL,
	LoadOrder INT NOT NULL DEFAULT 0,
	Enabled TINYINT NOT NULL DEFAULT 0,
	CONSTRAINT PK_Historian PRIMARY KEY (ID ASC)
);

CREATE TABLE CustomInputAdapter(
	NodeID NCHAR(36) NOT NULL,
	ID INT AUTO_INCREMENT NOT NULL,
	AdapterName NVARCHAR(50) NOT NULL,
	AssemblyName TEXT NOT NULL,
	TypeName TEXT NOT NULL,
	ConnectionString LONGTEXT NULL,
	LoadOrder INT NOT NULL DEFAULT 0,
	Enabled TINYINT NOT NULL DEFAULT 0,
	CONSTRAINT PK_CustomInputAdapter PRIMARY KEY (ID ASC)
);

CREATE TABLE OutputStream(
	NodeID NCHAR(36) NOT NULL,
	ID INT AUTO_INCREMENT NOT NULL,
	Acronym NVARCHAR(50) NOT NULL,
	Name NVARCHAR(100) NULL,
	Type INT NOT NULL DEFAULT 0,
	ConnectionString LONGTEXT NULL,
	DataChannel LONGTEXT NULL,
	CommandChannel LONGTEXT NULL,
	IDCode INT NOT NULL DEFAULT 0,
	AutoPublishConfigFrame TINYINT NOT NULL DEFAULT 0,
	AutoStartDataChannel TINYINT NOT NULL DEFAULT 1,
	NominalFrequency INT NOT NULL DEFAULT 60,
	FramesPerSecond INT NOT NULL DEFAULT 30,
	LagTime DOUBLE NOT NULL DEFAULT 3.0,
	LeadTime DOUBLE NOT NULL DEFAULT 1.0,
	UseLocalClockAsRealTime TINYINT NOT NULL DEFAULT 0,
	AllowSortsByArrival TINYINT NOT NULL DEFAULT 1,
	IgnoreBadTimeStamps TINYINT NOT NULL DEFAULT 0,
	TimeResolution INT NOT NULL DEFAULT 10000,
	AllowPreemptivePublishing TINYINT NOT NULL DEFAULT 1,
	DownsamplingMethod NVARCHAR(15) NOT NULL DEFAULT N'LastReceived',
	DataFormat NVARCHAR(15) NOT NULL DEFAULT N'FloatingPoint',
	CoordinateFormat NVARCHAR(15) NOT NULL DEFAULT N'Polar',
	CurrentScalingValue INT NOT NULL DEFAULT 2423,
	VoltageScalingValue INT NOT NULL DEFAULT 2725785,
	AnalogScalingValue INT NOT NULL DEFAULT 1373291,
	DigitalMaskValue INT NOT NULL DEFAULT -65536,
	LoadOrder INT NOT NULL DEFAULT 0,
	Enabled TINYINT NOT NULL DEFAULT 0,
	CONSTRAINT PK_OutputStream PRIMARY KEY (ID ASC)
);

CREATE TABLE CustomOutputAdapter(
	NodeID NCHAR(36) NOT NULL,
	ID INT AUTO_INCREMENT NOT NULL,
	AdapterName NVARCHAR(50) NOT NULL,
	AssemblyName TEXT NOT NULL,
	TypeName TEXT NOT NULL,
	ConnectionString LONGTEXT NULL,
	LoadOrder INT NOT NULL DEFAULT 0,
	Enabled TINYINT NOT NULL DEFAULT 0,
	CONSTRAINT PK_CustomOutputAdapter PRIMARY KEY (ID ASC)
);

ALTER TABLE Node ADD CONSTRAINT FK_Node_Company FOREIGN KEY(CompanyID) REFERENCES Company (ID);

ALTER TABLE DataOperation ADD CONSTRAINT FK_DataOperation_Node FOREIGN KEY(NodeID) REFERENCES Node (ID);

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

ALTER TABLE OutputStreamDeviceDigital ADD CONSTRAINT FK_OutputStreamDeviceDigital_OutputStreamDevice FOREIGN KEY(OutputStreamDeviceID) REFERENCES OutputStreamDevice (ID) ON DELETE CASCADE;

ALTER TABLE OutputStreamDevicePhasor ADD CONSTRAINT FK_OutputStreamDevicePhasor_Node FOREIGN KEY(NodeID) REFERENCES Node (ID);

ALTER TABLE OutputStreamDevicePhasor ADD CONSTRAINT FK_OutputStreamDevicePhasor_OutputStreamDevice FOREIGN KEY(OutputStreamDeviceID) REFERENCES OutputStreamDevice (ID) ON DELETE CASCADE;

ALTER TABLE OutputStreamDeviceAnalog ADD CONSTRAINT FK_OutputStreamDeviceAnalog_Node FOREIGN KEY(NodeID) REFERENCES Node (ID);

ALTER TABLE OutputStreamDeviceAnalog ADD CONSTRAINT FK_OutputStreamDeviceAnalog_OutputStreamDevice FOREIGN KEY(OutputStreamDeviceID) REFERENCES OutputStreamDevice (ID) ON DELETE CASCADE;

ALTER TABLE Measurement ADD CONSTRAINT FK_Measurement_Device FOREIGN KEY(DeviceID) REFERENCES Device (ID) ON DELETE CASCADE;

ALTER TABLE Measurement ADD CONSTRAINT FK_Measurement_Historian FOREIGN KEY(HistorianID) REFERENCES Historian (ID);

ALTER TABLE Measurement ADD CONSTRAINT FK_Measurement_SignalType FOREIGN KEY(SignalTypeID) REFERENCES SignalType (ID);

ALTER TABLE ImportedMeasurement ADD CONSTRAINT FK_ImportedMeasurement_Node FOREIGN KEY(NodeID) REFERENCES Node (ID);

ALTER TABLE OutputStreamMeasurement ADD CONSTRAINT FK_OutputStreamMeasurement_Historian FOREIGN KEY(HistorianID) REFERENCES Historian (ID);

ALTER TABLE OutputStreamMeasurement ADD CONSTRAINT FK_OutputStreamMeasurement_Measurement FOREIGN KEY(PointID) REFERENCES Measurement (PointID) ON DELETE CASCADE;

ALTER TABLE OutputStreamMeasurement ADD CONSTRAINT FK_OutputStreamMeasurement_Node FOREIGN KEY(NodeID) REFERENCES Node (ID);

ALTER TABLE OutputStreamMeasurement ADD CONSTRAINT FK_OutputStreamMeasurement_OutputStream FOREIGN KEY(AdapterID) REFERENCES OutputStream (ID);

ALTER TABLE OutputStreamDevice ADD CONSTRAINT FK_OutputStreamDevice_Node FOREIGN KEY(NodeID) REFERENCES Node (ID);

ALTER TABLE OutputStreamDevice ADD CONSTRAINT FK_OutputStreamDevice_OutputStream FOREIGN KEY(AdapterID) REFERENCES OutputStream (ID);

ALTER TABLE Phasor ADD CONSTRAINT FK_Phasor_Device FOREIGN KEY(DeviceID) REFERENCES Device (ID) ON DELETE CASCADE;

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
 Runtime ON OutputStreamMeasurement.AdapterID = Runtime.SourceID AND Runtime.SourceTable = N'OutputStream'
ORDER BY OutputStreamMeasurement.HistorianID, OutputStreamMeasurement.PointID;

CREATE VIEW RuntimeHistorian
AS
SELECT Historian.NodeID, Runtime.ID, Historian.Acronym AS AdapterName,
 COALESCE(NULLIF(TRIM(Historian.AssemblyName), ''), N'HistorianAdapters.dll') AS AssemblyName, 
 COALESCE(NULLIF(TRIM(Historian.TypeName), ''), IF(IsLocal = 1, N'HistorianAdapters.LocalOutputAdapter', N'HistorianAdapters.RemoteOutputAdapter')) AS TypeName, 
 CONCAT_WS(';', Historian.ConnectionString, CONCAT(N'instanceName=', Historian.Acronym), CONCAT(N'sourceids=', Historian.Acronym),
 CONCAT(N'measurementReportingInterval=', CAST(Historian.MeasurementReportingInterval AS CHAR))) AS ConnectionString
FROM Historian LEFT OUTER JOIN
 Runtime ON Historian.ID = Runtime.SourceID AND Runtime.SourceTable = N'Historian'
WHERE (Historian.Enabled <> 0)
ORDER BY Historian.LoadOrder;

CREATE VIEW RuntimeDevice
AS
SELECT Device.NodeID, Runtime.ID, Device.Acronym AS AdapterName, N'TVA.PhasorProtocols.dll' AS AssemblyName, 
 N'TVA.PhasorProtocols.PhasorMeasurementMapper' AS TypeName,
 CONCAT_WS(';', Device.ConnectionString, CONCAT(N'isConcentrator=', CAST(Device.IsConcentrator AS CHAR)),
 CONCAT(N'accessID=', CAST(Device.AccessID AS CHAR)),
 IF(Device.TimeZone IS NULL, N'', CONCAT(N'timeZone=', Device.TimeZone)),
 CONCAT(N'timeAdjustmentTicks=', CAST(Device.TimeAdjustmentTicks AS CHAR)),
 IF(Protocol.Acronym IS NULL, N'', CONCAT(N'phasorProtocol=', Protocol.Acronym)),
 CONCAT(N'dataLossInterval=', CAST(Device.DataLossInterval AS CHAR)),
 CONCAT(N'allowedParsingExceptions=', CAST(Device.AllowedParsingExceptions AS CHAR)),
 CONCAT(N'parsingExceptionWindow=', CAST(Device.ParsingExceptionWindow AS CHAR)),
 CONCAT(N'delayedConnectionInterval=', CAST(Device.DelayedConnectionInterval AS CHAR)),
 CONCAT(N'allowUseOfCachedConfiguration=', CAST(Device.AllowUseOfCachedConfiguration AS CHAR)),
 CONCAT(N'autoStartDataParsingSequence=', CAST(Device.AutoStartDataParsingSequence AS CHAR)),
 CONCAT(N'skipDisableRealTimeData=', CAST(Device.SkipDisableRealTimeData AS CHAR)),
 CONCAT(N'measurementReportingInterval=', CAST(Device.MeasurementReportingInterval AS CHAR))) AS ConnectionString
FROM Device LEFT OUTER JOIN
 Protocol ON Device.ProtocolID = Protocol.ID LEFT OUTER JOIN
 Runtime ON Device.ID = Runtime.SourceID AND Runtime.SourceTable = N'Device'
WHERE (Device.Enabled <> 0 AND Device.ParentID IS NULL)
ORDER BY Device.LoadOrder;

CREATE VIEW RuntimeCustomOutputAdapter
AS
SELECT CustomOutputAdapter.NodeID, Runtime.ID, CustomOutputAdapter.AdapterName, 
 TRIM(CustomOutputAdapter.AssemblyName) AS AssemblyName, TRIM(CustomOutputAdapter.TypeName) AS TypeName, CustomOutputAdapter.ConnectionString
FROM CustomOutputAdapter LEFT OUTER JOIN
 Runtime ON CustomOutputAdapter.ID = Runtime.SourceID AND Runtime.SourceTable = N'CustomOutputAdapter'
WHERE (CustomOutputAdapter.Enabled <> 0)
ORDER BY CustomOutputAdapter.LoadOrder;

CREATE VIEW RuntimeInputStreamDevice
AS
SELECT Device.NodeID, Runtime_P.ID AS ParentID, Runtime.ID, Device.Acronym, Device.AccessID
FROM Device LEFT OUTER JOIN
 Runtime ON Device.ID = Runtime.SourceID AND Runtime.SourceTable = N'Device' LEFT OUTER JOIN
 Runtime AS Runtime_P ON Device.ParentID = Runtime_P.SourceID AND Runtime_P.SourceTable = N'Device'
WHERE (Device.IsConcentrator = 0) AND (Device.Enabled <> 0) AND (Device.ParentID IS NOT NULL)
ORDER BY Device.LoadOrder;

CREATE VIEW RuntimeCustomInputAdapter
AS
SELECT CustomInputAdapter.NodeID, Runtime.ID, CustomInputAdapter.AdapterName, 
 TRIM(CustomInputAdapter.AssemblyName) AS AssemblyName, TRIM(CustomInputAdapter.TypeName) AS TypeName, CustomInputAdapter.ConnectionString
FROM CustomInputAdapter LEFT OUTER JOIN
 Runtime ON CustomInputAdapter.ID = Runtime.SourceID AND Runtime.SourceTable = N'CustomInputAdapter'
WHERE (CustomInputAdapter.Enabled <> 0)
ORDER BY CustomInputAdapter.LoadOrder;

CREATE VIEW RuntimeOutputStreamDevice
AS
SELECT OutputStreamDevice.NodeID, Runtime.ID AS ParentID, OutputStreamDevice.ID, OutputStreamDevice.Acronym, 
 OutputStreamDevice.BpaAcronym, OutputStreamDevice.Name, NULLIF(OutputStreamDevice.PhasorDataFormat, '') AS PhasorDataFormat, NULLIF(OutputStreamDevice.FrequencyDataFormat, '') AS FrequencyDataFormat,
 NULLIF(OutputStreamDevice.AnalogDataFormat, '') AS AnalogDataFormat, NULLIF(OutputStreamDevice.CoordinateFormat, '') AS CoordinateFormat, OutputStreamDevice.LoadOrder
FROM OutputStreamDevice LEFT OUTER JOIN
 Runtime ON OutputStreamDevice.AdapterID = Runtime.SourceID AND Runtime.SourceTable = N'OutputStream'
WHERE (OutputStreamDevice.Enabled <> 0)
ORDER BY OutputStreamDevice.LoadOrder;

CREATE VIEW RuntimeOutputStream
AS
SELECT OutputStream.NodeID, Runtime.ID, OutputStream.Acronym AS AdapterName, 
 N'TVA.PhasorProtocols.dll' AS AssemblyName, 
 IF(Type = 1, N'TVA.PhasorProtocols.BpaPdcStream.Concentrator', N'TVA.PhasorProtocols.IeeeC37_118.Concentrator') AS TypeName,
 CONCAT_WS(';', OutputStream.ConnectionString,
 IF(OutputStream.DataChannel IS NULL, N'', CONCAT(N'dataChannel={', OutputStream.DataChannel, N'}')),
 IF(OutputStream.CommandChannel IS NULL, N'', CONCAT(N'commandChannel={', OutputStream.CommandChannel, N'}')),
 CONCAT(N'idCode=', CAST(OutputStream.IDCode AS CHAR)),
 CONCAT(N'autoPublishConfigFrame=', CAST(OutputStream.AutoPublishConfigFrame AS CHAR)),
 CONCAT(N'autoStartDataChannel=', CAST(OutputStream.AutoStartDataChannel AS CHAR)),
 CONCAT(N'nominalFrequency=', CAST(OutputStream.NominalFrequency AS CHAR)),
 CONCAT(N'lagTime=', CAST(OutputStream.LagTime AS CHAR)),
 CONCAT(N'leadTime=', CAST(OutputStream.LeadTime AS CHAR)),
 CONCAT(N'framesPerSecond=', CAST(OutputStream.FramesPerSecond AS CHAR)),
 CONCAT(N'useLocalClockAsRealTime=', CAST(OutputStream.UseLocalClockAsRealTime AS CHAR)),
 CONCAT(N'allowSortsByArrival=', CAST(OutputStream.AllowSortsByArrival AS CHAR)),
 CONCAT(N'ignoreBadTimestamps=', CAST(OutputStream.IgnoreBadTimeStamps AS CHAR)),
 CONCAT(N'timeResolution=', CAST(OutputStream.TimeResolution AS CHAR)),
 CONCAT(N'allowPreemptivePublishing=', CAST(OutputStream.AllowPreemptivePublishing AS CHAR)),
 CONCAT(N'downsamplingMethod=', OutputStream.DownsamplingMethod),
 CONCAT(N'dataFormat=', OutputStream.DataFormat),
 CONCAT(N'coordinateFormat=', OutputStream.CoordinateFormat),
 CONCAT(N'currentScalingValue=', CAST(OutputStream.CurrentScalingValue AS CHAR)),
 CONCAT(N'voltageScalingValue=', CAST(OutputStream.VoltageScalingValue AS CHAR)),
 CONCAT(N'analogScalingValue=', CAST(OutputStream.AnalogScalingValue AS CHAR)),
 CONCAT(N'digitalMaskValue=', CAST(OutputStream.DigitalMaskValue AS CHAR))) AS ConnectionString
FROM OutputStream LEFT OUTER JOIN
 Runtime ON OutputStream.ID = Runtime.SourceID AND Runtime.SourceTable = N'OutputStream'
WHERE (OutputStream.Enabled <> 0)
ORDER BY OutputStream.LoadOrder;

CREATE VIEW RuntimeCustomActionAdapter
AS
SELECT CustomActionAdapter.NodeID, Runtime.ID, CustomActionAdapter.AdapterName, 
 TRIM(CustomActionAdapter.AssemblyName) AS AssemblyName, TRIM(CustomActionAdapter.TypeName) AS TypeName, CustomActionAdapter.ConnectionString
FROM CustomActionAdapter LEFT OUTER JOIN
 Runtime ON CustomActionAdapter.ID = Runtime.SourceID AND Runtime.SourceTable = N'CustomActionAdapter'
WHERE (CustomActionAdapter.Enabled <> 0)
ORDER BY CustomActionAdapter.LoadOrder;

CREATE VIEW RuntimeCalculatedMeasurement
AS
SELECT CalculatedMeasurement.NodeID, Runtime.ID, CalculatedMeasurement.Acronym AS AdapterName, 
 TRIM(CalculatedMeasurement.AssemblyName) AS AssemblyName, TRIM(CalculatedMeasurement.TypeName) AS TypeName,
 CONCAT_WS(';', CalculatedMeasurement.ConnectionString, IF(ConfigSection IS NULL, N'', CONCAT(N'configurationSection=', ConfigSection)),
 CONCAT(N'minimumMeasurementsToUse=', CAST(CalculatedMeasurement.MinimumMeasurementsToUse AS CHAR)),
 CONCAT(N'framesPerSecond=', CAST(CalculatedMeasurement.FramesPerSecond AS CHAR)),
 CONCAT(N'lagTime=', CAST(CalculatedMeasurement.LagTime AS CHAR)),
 CONCAT(N'leadTime=', CAST(CalculatedMeasurement.LeadTime AS CHAR)),
 IF(InputMeasurements IS NULL, N'', CONCAT(N'inputMeasurementKeys={', InputMeasurements, N'}')),
 IF(OutputMeasurements IS NULL, N'', CONCAT(N'outputMeasurements={', OutputMeasurements, N'}')),
 CONCAT(N'ignoreBadTimestamps=', CAST(CalculatedMeasurement.IgnoreBadTimeStamps AS CHAR)),
 CONCAT(N'timeResolution=', CAST(CalculatedMeasurement.TimeResolution AS CHAR)),
 CONCAT(N'allowPreemptivePublishing=', CAST(CalculatedMeasurement.AllowPreemptivePublishing AS CHAR)),
 CONCAT(N'downsamplingMethod=', CalculatedMeasurement.DownsamplingMethod)) AS ConnectionString
FROM CalculatedMeasurement LEFT OUTER JOIN
 Runtime ON CalculatedMeasurement.ID = Runtime.SourceID AND Runtime.SourceTable = N'CalculatedMeasurement'
WHERE (CalculatedMeasurement.Enabled <> 0)
ORDER BY CalculatedMeasurement.LoadOrder;

CREATE VIEW ActiveMeasurement
AS
SELECT COALESCE(Historian.NodeID, Device.NodeID) AS NodeID, COALESCE(Historian.NodeID, Device.NodeID) AS SourceNodeID, CONCAT_WS(':', COALESCE(Historian.Acronym, Device.Acronym, '__'), CAST(Measurement.PointID AS CHAR)) AS ID, Measurement.SignalID, Measurement.PointTag, 
	Measurement.AlternateTag, Measurement.SignalReference, Device.Acronym AS Device, CASE WHEN Device.IsConcentrator = 0 AND Device.ParentID IS NOT NULL THEN RuntimeP.ID ELSE Runtime.ID END AS DeviceID,
	COALESCE(Device.FramesPerSecond, 30) AS FramesPerSecond, Protocol.Acronym AS Protocol, SignalType.Acronym AS SignalType, Phasor.ID AS PhasorID, Phasor.Type AS PhasorType, Phasor.Phase, Measurement.Adder, Measurement.Multiplier,
	Company.Acronym AS Company, Device.Longitude, Device.Latitude, Measurement.Description
FROM Company RIGHT OUTER JOIN
	Device ON Company.ID = Device.CompanyID RIGHT OUTER JOIN
	Measurement LEFT OUTER JOIN
	SignalType ON Measurement.SignalTypeID = SignalType.ID ON Device.ID = Measurement.DeviceID LEFT OUTER JOIN
	Phasor ON Measurement.DeviceID = Phasor.DeviceID AND 
	Measurement.PhasorSourceIndex = Phasor.SourceIndex LEFT OUTER JOIN
	Protocol ON Device.ProtocolID = Protocol.ID LEFT OUTER JOIN
	Historian ON Measurement.HistorianID = Historian.ID LEFT OUTER JOIN
	Runtime ON Device.ID = Runtime.SourceID AND Runtime.SourceTable = N'Device' LEFT OUTER JOIN
	Runtime AS RuntimeP ON RuntimeP.SourceID = Device.ParentID AND RuntimeP.SourceTable = N'Device'
WHERE (Device.Enabled <> 0 OR Device.Enabled IS NULL) AND (Measurement.Enabled <> 0)
UNION ALL
SELECT NodeID, SourceNodeID, CONCAT_WS(':', Source, CAST(PointID AS CHAR)) AS ID, SignalID, PointTag,
	AlternateTag, SignalReference, NULL AS Device, NULL AS DeviceID,
	FramesPerSecond, ProtocolAcronym AS Protocol, SignalTypeAcronym AS SignalType, PhasorID, PhasorType, Phase, Adder, Multiplier,
	CompanyAcronym AS Company, Longitude, Latitude, Description
FROM ImportedMeasurement
WHERE ImportedMeasurement.Enabled <> 0;

CREATE VIEW RuntimeStatistic
AS
SELECT Node.ID AS NodeID, Statistic.ID AS ID, Statistic.Source, Statistic.SignalIndex, Statistic.Name, Statistic.Description,
	Statistic.AssemblyName, Statistic.TypeName, Statistic.MethodName, Statistic.Arguments, Statistic.Enabled
FROM Statistic, Node;

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
SELECT Node.ID AS NodeID, 0 AS ID, N'PHASOR!SERVICES' AS AdapterName, N'TVA.PhasorProtocols.dll' AS AssemblyName, N'TVA.PhasorProtocols.CommonPhasorServices' AS TypeName, N'' AS ConnectionString
FROM Node
UNION
SELECT NodeID, ID, AdapterName, AssemblyName, TypeName, ConnectionString
FROM RuntimeOutputStream
UNION
SELECT NodeID, ID, AdapterName, AssemblyName, TypeName, ConnectionString
FROM RuntimeCalculatedMeasurement
UNION
SELECT NodeID, ID, AdapterName, AssemblyName, TypeName, ConnectionString
FROM RuntimeCustomActionAdapter;
      
CREATE VIEW MeasurementDetail
AS
SELECT     Device.CompanyID, Company.Acronym AS CompanyAcronym, Company.Name AS CompanyName, Measurement.SignalID, 
                      Measurement.HistorianID, Historian.Acronym AS HistorianAcronym, Historian.ConnectionString AS HistorianConnectionString, 
                      Measurement.PointID, Measurement.PointTag, Measurement.AlternateTag, Measurement.DeviceID, Historian.NodeID, 
                      Device.Acronym AS DeviceAcronym, Device.Name AS DeviceName, COALESCE(Device.FramesPerSecond, 30) AS FramesPerSecond, Device.Enabled AS DeviceEnabled, Device.ContactList, 
                      Device.VendorDeviceID, VendorDevice.Name AS VendorDeviceName, VendorDevice.Description AS VendorDeviceDescription, 
                      Device.ProtocolID, Protocol.Acronym AS ProtocolAcronym, Protocol.Name AS ProtocolName, Measurement.SignalTypeID, 
                      Measurement.PhasorSourceIndex, Phasor.Label AS PhasorLabel, Phasor.Type AS PhasorType, Phasor.Phase, 
                      Measurement.SignalReference, Measurement.Adder, Measurement.Multiplier, Measurement.Description, Measurement.Enabled, 
                      COALESCE (SignalType.EngineeringUnits, N'') AS EngineeringUnits, SignalType.Source, SignalType.Acronym AS SignalAcronym, 
                      SignalType.Name AS SignalName, SignalType.Suffix AS SignalTypeSuffix, Device.Longitude, Device.Latitude
FROM         Company RIGHT OUTER JOIN
                      Device ON Company.ID = Device.CompanyID RIGHT OUTER JOIN
                      Measurement LEFT OUTER JOIN
                      SignalType ON Measurement.SignalTypeID = SignalType.ID ON Device.ID = Measurement.DeviceID LEFT OUTER JOIN
                      Phasor ON Measurement.DeviceID = Phasor.DeviceID AND 
                      Measurement.PhasorSourceIndex = Phasor.SourceIndex LEFT OUTER JOIN
                      VendorDevice ON Device.VendorDeviceID = VendorDevice.ID LEFT OUTER JOIN
                      Protocol ON Device.ProtocolID = Protocol.ID LEFT OUTER JOIN
                      Historian ON Measurement.HistorianID = Historian.ID;

CREATE VIEW HistorianMetadata
AS
SELECT PointID AS HistorianID, IF(SignalAcronym = N'DIGI', 1, 0) AS DataType, PointTag AS Name, SignalReference AS Synonym1, 
SignalAcronym AS Synonym2, AlternateTag AS Synonym3, Description, VendorDeviceDescription AS HardwareInfo, N'' AS Remarks, 
HistorianAcronym AS PlantCode, 1 AS UnitNumber, DeviceAcronym AS SystemName, ProtocolID AS SourceID, Enabled, 1 / FramesPerSecond AS ScanRate, 
0 AS CompressionMinTime, 0 AS CompressionMaxTime, EngineeringUnits,
CASE SignalAcronym WHEN N'FREQ' THEN 59.95 WHEN N'VPHM' THEN 475000 WHEN N'IPHM' THEN 0 WHEN N'VPHA' THEN -181 WHEN N'IPHA' THEN -181 ELSE 0 END AS LowWarning,
CASE SignalAcronym WHEN N'FREQ' THEN 60.05 WHEN N'VPHM' THEN 525000 WHEN N'IPHM' THEN 3150 WHEN N'VPHA' THEN 181 WHEN N'IPHA' THEN 181 ELSE 0 END AS HighWarning,
CASE SignalAcronym WHEN N'FREQ' THEN 59.90 WHEN N'VPHM' THEN 450000 WHEN N'IPHM' THEN 0 WHEN N'VPHA' THEN -181 WHEN N'IPHA' THEN -181 ELSE 0 END AS LowAlarm,
CASE SignalAcronym WHEN N'FREQ' THEN 60.10 WHEN N'VPHM' THEN 550000 WHEN N'IPHM' THEN 3300 WHEN N'VPHA' THEN 181 WHEN N'IPHA' THEN 181 ELSE 0 END AS HighAlarm,
CASE SignalAcronym WHEN N'FREQ' THEN 59.95 WHEN N'VPHM' THEN 475000 WHEN N'IPHM' THEN 0 WHEN N'VPHA' THEN -180 WHEN N'IPHA' THEN -180 ELSE 0 END AS LowRange,
CASE SignalAcronym WHEN N'FREQ' THEN 60.05 WHEN N'VPHM' THEN 525000 WHEN N'IPHM' THEN 3000 WHEN N'VPHA' THEN 180 WHEN N'IPHA' THEN 180 ELSE 0 END AS HighRange,
0.0 AS CompressionLimit, 0.0 AS ExceptionLimit, CASE SignalAcronym WHEN N'DIGI' THEN 0 ELSE 7 END AS DisplayDigits, N'' AS SetDescription,
'' AS ClearDescription, 0 AS AlarmState, 5 AS ChangeSecurity, 0 AS AccessSecurity, 0 AS StepCheck, 0 AS AlarmEnabled, 0 AS AlarmFlags, 0 AS AlarmDelay,
0 AS AlarmToFile, 0 AS AlarmByEmail, 0 AS AlarmByPager, 0 AS AlarmByPhone, ContactList AS AlarmEmails, N'' AS AlarmPagers, N'' AS AlarmPhones
FROM MeasurementDetail;

CREATE VIEW CalculatedMeasurementDetail
AS
SELECT CM.NodeID, CM.ID, CM.Acronym, COALESCE(CM.Name, '') AS Name, CM.AssemblyName, CM.TypeName, COALESCE(CM.ConnectionString, '') AS ConnectionString,
		COALESCE(CM.ConfigSection, '') AS ConfigSection, COALESCE(CM.InputMeasurements, '') AS InputMeasurements, COALESCE(CM.OutputMeasurements, '') AS OutputMeasurements,
		CM.MinimumMeasurementsToUse, CM.FramesPerSecond, CM.LagTime, CM.LeadTime, CM.UseLocalClockAsRealTime, CM.AllowSortsByArrival, CM.LoadOrder, CM.Enabled,
		N.Name AS NodeName, CM.IgnoreBadTimeStamps, CM.TimeResolution, CM.AllowPreemptivePublishing, COALESCE(CM.DownsamplingMethod, '') AS DownsamplingMethod
FROM CalculatedMeasurement CM, Node N
WHERE CM.NodeID = N.ID;

CREATE VIEW HistorianDetail
AS
SELECT H.NodeID, H.ID, H.Acronym, COALESCE(H.Name, '') AS Name, COALESCE(H.AssemblyName, '') AS AssemblyName, COALESCE(H.TypeName, '') AS TypeName, 
	COALESCE(H.ConnectionString, '') AS ConnectionString, H.IsLocal, COALESCE(H.Description, '') AS Description, H.LoadOrder, H.Enabled, N.Name AS NodeName, H.MeasurementReportingInterval 
FROM Historian AS H INNER JOIN
	 Node AS N ON H.NodeID = N.ID;

CREATE VIEW NodeDetail
AS
SELECT N.ID, N.Name, N.CompanyID AS CompanyID, COALESCE(N.Longitude, 0) AS Longitude, COALESCE(N.Latitude, 0) AS Latitude, 
		COALESCE(N.Description, '') AS Description, COALESCE(N.ImagePath, '') AS ImagePath, N.Master, N.LoadOrder, N.Enabled, 
		COALESCE(N.TimeSeriesDataServiceUrl, '') AS TimeSeriesDataServiceUrl, COALESCE(N.RemoteStatusServiceUrl, '') AS RemoteStatusServiceUrl,	
		COALESCE(N.RealTimeStatisticServiceUrl, '') AS RealTimeStatisticServiceUrl, COALESCE(C.Name, '') AS CompanyName
FROM Node N LEFT JOIN Company C 
ON N.CompanyID = C.ID;

CREATE VIEW VendorDetail
AS
Select ID, COALESCE(Acronym, '') AS Acronym, Name, COALESCE(PhoneNumber, '') AS PhoneNumber, COALESCE(ContactEmail, '') AS ContactEmail, COALESCE(URL, '') AS URL 
FROM Vendor;

CREATE VIEW CustomActionAdapterDetail AS
SELECT     CA.NodeID, CA.ID, CA.AdapterName, CA.AssemblyName, CA.TypeName, COALESCE(CA.ConnectionString, '') AS ConnectionString, CA.LoadOrder, 
                      CA.Enabled, N.Name AS NodeName
FROM         CustomActionAdapter AS CA INNER JOIN
                      Node AS N ON CA.NodeID = N.ID;
 
CREATE VIEW CustomInputAdapterDetail AS
SELECT     CA.NodeID, CA.ID, CA.AdapterName, CA.AssemblyName, CA.TypeName, COALESCE(CA.ConnectionString, '') AS ConnectionString, CA.LoadOrder, 
                      CA.Enabled, N.Name AS NodeName
FROM         CustomInputAdapter AS CA INNER JOIN
                      Node AS N ON CA.NodeID = N.ID;
 
CREATE VIEW CustomOutputAdapterDetail AS
SELECT     CA.NodeID, CA.ID, CA.AdapterName, CA.AssemblyName, CA.TypeName, COALESCE(CA.ConnectionString, '') AS ConnectionString, CA.LoadOrder, 
                      CA.Enabled, N.Name AS NodeName
FROM         CustomOutputAdapter AS CA INNER JOIN
                      Node AS N ON CA.NodeID = N.ID;
 
CREATE VIEW IaonTreeView AS
SELECT     'Action Adapters' AS AdapterType, NodeID, ID, AdapterName, AssemblyName, TypeName, COALESCE(ConnectionString, '') AS ConnectionString
FROM         IaonActionAdapter
UNION ALL
SELECT     'Input Adapters' AS AdapterType, NodeID, ID, AdapterName, AssemblyName, TypeName, COALESCE(ConnectionString, '') AS ConnectionString
FROM         IaonInputAdapter
UNION ALL
SELECT     'Output Adapters' AS AdapterType, NodeID, ID, AdapterName, AssemblyName, TypeName, COALESCE(ConnectionString, '') AS ConnectionString
FROM         IaonOutputAdapter;
 
CREATE VIEW OtherDeviceDetail AS
SELECT     OD.ID, OD.Acronym, COALESCE(OD.Name, '') AS Name, OD.IsConcentrator, OD.CompanyID, OD.VendorDeviceID, OD.Longitude, OD.Latitude, 
                      OD.InterconnectionID, OD.Planned, OD.Desired, OD.InProgress, COALESCE(C.Name, '') AS CompanyName, COALESCE(C.Acronym, '') AS CompanyAcronym, 
                      COALESCE(C.MapAcronym, '') AS CompanyMapAcronym, COALESCE(VD.Name, '') AS VendorDeviceName, COALESCE(I.Name, '') AS InterconnectionName
FROM         OtherDevice AS OD LEFT OUTER JOIN
                      Company AS C ON OD.CompanyID = C.ID LEFT OUTER JOIN
                      VendorDevice AS VD ON OD.VendorDeviceID = VD.ID LEFT OUTER JOIN
                      Interconnection AS I ON OD.InterconnectionID = I.ID;
 
CREATE VIEW VendorDeviceDistribution AS
SELECT Device.NodeID, Vendor.Name AS VendorName, COUNT(*) AS DeviceCount 
FROM Device 
      LEFT OUTER JOIN VendorDevice ON Device.VendorDeviceID = VendorDevice.ID
      INNER JOIN Vendor ON VendorDevice.VendorID = Vendor.ID
      GROUP BY Device.NodeID, Vendor.Name;

CREATE VIEW VendorDeviceDetail
AS
SELECT     VD.ID, VD.VendorID, VD.Name, COALESCE(VD.Description, '') AS Description, COALESCE(VD.URL, '') AS URL, V.Name AS VendorName, 
                      V.Acronym AS VendorAcronym
FROM         VendorDevice AS VD INNER JOIN
                      Vendor AS V ON VD.VendorID = V.ID;
                      
CREATE VIEW DeviceDetail
AS
SELECT     D.NodeID, D.ID, D.ParentID, D.Acronym, COALESCE(D.Name, '') AS Name, D.IsConcentrator, D.CompanyID, D.HistorianID, D.AccessID, D.VendorDeviceID, 
                      D.ProtocolID, D.Longitude, D.Latitude, D.InterconnectionID, COALESCE(D.ConnectionString, '') AS ConnectionString, COALESCE(D.TimeZone, '') AS TimeZone, 
                      COALESCE(D.FramesPerSecond, 30) AS FramesPerSecond, D.TimeAdjustmentTicks, D.DataLossInterval, COALESCE(D.ContactList, '') AS ContactList, D.MeasuredLines, D.LoadOrder, D.Enabled, COALESCE(C.Name, '') 
                      AS CompanyName, COALESCE(C.Acronym, '') AS CompanyAcronym, COALESCE(C.MapAcronym, '') AS CompanyMapAcronym, COALESCE(H.Acronym, '') 
                      AS HistorianAcronym, COALESCE(VD.VendorAcronym, '') AS VendorAcronym, COALESCE(VD.Name, '') AS VendorDeviceName, COALESCE(P.Name, '') 
                      AS ProtocolName, COALESCE(I.Name, '') AS InterconnectionName, N.Name AS NodeName, COALESCE(PD.Acronym, '') AS ParentAcronym, D.CreatedOn, D.AllowedParsingExceptions, 
                      D.ParsingExceptionWindow, D.DelayedConnectionInterval, D.AllowUseOfCachedConfiguration, D.AutoStartDataParsingSequence, D.SkipDisableRealTimeData, 
                      D.MeasurementReportingInterval
FROM         Device AS D LEFT OUTER JOIN
                      Company AS C ON C.ID = D.CompanyID LEFT OUTER JOIN
                      Historian AS H ON H.ID = D.HistorianID LEFT OUTER JOIN
                      VendorDeviceDetail AS VD ON VD.ID = D.VendorDeviceID LEFT OUTER JOIN
                      Protocol AS P ON P.ID = D.ProtocolID LEFT OUTER JOIN
                      Interconnection AS I ON I.ID = D.InterconnectionID LEFT OUTER JOIN
                      Node AS N ON N.ID = D.NodeID LEFT OUTER JOIN
                      Device AS PD ON PD.ID = D.ParentID;
 
CREATE VIEW MapData AS
SELECT     'Device' AS DeviceType, NodeID, ID, Acronym, COALESCE(Name, '') AS Name, CompanyMapAcronym, CompanyName, VendorDeviceName, Longitude, 
                      Latitude, true AS Reporting, false AS Inprogress, false AS Planned, false AS Desired
FROM         DeviceDetail AS D
UNION ALL
SELECT     'OtherDevice' AS DeviceType, NULL AS NodeID, ID, Acronym, COALESCE(Name, '') AS Name, CompanyMapAcronym, CompanyName, VendorDeviceName, 
                      Longitude, Latitude, false AS Reporting, true AS Inprogress, true AS Planned, true 
                      AS Desired
FROM         OtherDeviceDetail AS OD;

CREATE VIEW OutputStreamDetail AS
SELECT     OS.NodeID, OS.ID, OS.Acronym, COALESCE(OS.Name, '') AS Name, OS.Type, COALESCE(OS.ConnectionString, '') AS ConnectionString, OS.IDCode, 
                      COALESCE(OS.CommandChannel, '') AS CommandChannel, COALESCE(OS.DataChannel, '') AS DataChannel, OS.AutoPublishConfigFrame, 
                      OS.AutoStartDataChannel, OS.NominalFrequency, OS.FramesPerSecond, OS.LagTime, OS.LeadTime, OS.UseLocalClockAsRealTime, 
                      OS.AllowSortsByArrival, OS.LoadOrder, OS.Enabled, N.Name AS NodeName, OS.DigitalMaskValue, OS.AnalogScalingValue, 
                      OS.VoltageScalingValue, OS.CurrentScalingValue, OS.CoordinateFormat, OS.DataFormat, OS.DownsamplingMethod, 
                      OS.AllowPreemptivePublishing, OS.TimeResolution, OS.IgnoreBadTimeStamps
FROM         OutputStream AS OS INNER JOIN
                      Node AS N ON OS.NodeID = N.ID;
                      
CREATE VIEW OutputStreamMeasurementDetail AS
SELECT     OSM.NodeID, OSM.AdapterID, OSM.ID, OSM.HistorianID, OSM.PointID, OSM.SignalReference, M.PointTag AS SourcePointTag, COALESCE(H.Acronym, '') 
                      AS HistorianAcronym
FROM         OutputStreamMeasurement AS OSM INNER JOIN
                      Measurement AS M ON M.PointID = OSM.PointID LEFT OUTER JOIN
                      Historian AS H ON H.ID = OSM.HistorianID;
      
CREATE VIEW OutputStreamDeviceDetail AS
SELECT OSD.NodeID, OSD.AdapterID, OSD.ID, OSD.Acronym, COALESCE(OSD.BpaAcronym, '') AS BpaAcronym, OSD.Name, OSD.LoadOrder, OSD.Enabled, 
			COALESCE(PhasorDataFormat, '') AS PhasorDataFormat, COALESCE(FrequencyDataFormat, '') AS FrequencyDataFormat, 
			COALESCE(AnalogDataFormat, '') AS AnalogDataFormat, COALESCE(CoordinateFormat, '') AS CoordinateFormat,
                    CASE 
                        WHEN EXISTS (Select Acronym From Device Where Acronym = OSD.Acronym) THEN FALSE 
                        ELSE TRUE 
                    END AS Virtual
FROM OutputStreamDevice OSD;
                      
CREATE VIEW PhasorDetail AS
SELECT P.*, COALESCE(DP.Label, '') AS DestinationPhasorLabel, D.Acronym AS DeviceAcronym
FROM Phasor P LEFT OUTER JOIN Phasor DP ON P.DestinationPhasorID = DP.ID
      LEFT OUTER JOIN Device D ON P.DeviceID = D.ID;

CREATE VIEW StatisticMeasurement AS
SELECT     MeasurementDetail.CompanyID, MeasurementDetail.CompanyAcronym, MeasurementDetail.CompanyName, MeasurementDetail.SignalID, MeasurementDetail.HistorianID, MeasurementDetail.HistorianAcronym, MeasurementDetail.HistorianConnectionString, MeasurementDetail.PointID, MeasurementDetail.PointTag, MeasurementDetail.AlternateTag, MeasurementDetail.DeviceID, 
                      MeasurementDetail.NodeID, MeasurementDetail.DeviceAcronym, MeasurementDetail.DeviceName, MeasurementDetail.FramesPerSecond, MeasurementDetail.DeviceEnabled, MeasurementDetail.ContactList, MeasurementDetail.VendorDeviceID, MeasurementDetail.VendorDeviceName, MeasurementDetail.VendorDeviceDescription, MeasurementDetail.ProtocolID, 
                      MeasurementDetail.ProtocolAcronym, MeasurementDetail.ProtocolName, MeasurementDetail.SignalTypeID, MeasurementDetail.PhasorSourceIndex, MeasurementDetail.PhasorLabel, MeasurementDetail.PhasorType, MeasurementDetail.Phase, MeasurementDetail.SignalReference, MeasurementDetail.Adder, MeasurementDetail.Multiplier, MeasurementDetail.Description, MeasurementDetail.Enabled, 
                      MeasurementDetail.EngineeringUnits, MeasurementDetail.Source, MeasurementDetail.SignalAcronym, MeasurementDetail.SignalName, MeasurementDetail.SignalTypeSuffix, MeasurementDetail.Longitude, MeasurementDetail.Latitude, CASE WHEN LOCATE('!IS', MeasurementDetail.SignalReference) > 0 THEN 'InputStream' WHEN LOCATE('!OS', MeasurementDetail.SignalReference) > 0 THEN 'OutputStream' ELSE 'Device' END AS MeasurementSource
FROM MeasurementDetail 
WHERE MeasurementDetail.SignalAcronym = 'STAT';

CREATE TRIGGER CustomActionAdapter_RuntimeSync_Insert AFTER INSERT ON CustomActionAdapter
FOR EACH ROW INSERT INTO Runtime (SourceID, SourceTable) VALUES(NEW.ID, N'CustomActionAdapter');

CREATE TRIGGER CustomActionAdapter_RuntimeSync_Delete BEFORE DELETE ON CustomActionAdapter
FOR EACH ROW DELETE FROM Runtime WHERE SourceID = OLD.ID AND SourceTable = N'CustomActionAdapter';

CREATE TRIGGER CustomInputAdapter_RuntimeSync_Insert AFTER INSERT ON CustomInputAdapter
FOR EACH ROW INSERT INTO Runtime (SourceID, SourceTable) VALUES(NEW.ID, N'CustomInputAdapter');

CREATE TRIGGER CustomInputAdapter_RuntimeSync_Delete BEFORE DELETE ON CustomInputAdapter
FOR EACH ROW DELETE FROM Runtime WHERE SourceID = OLD.ID AND SourceTable = N'CustomInputAdapter';

CREATE TRIGGER CustomOutputAdapter_RuntimeSync_Insert AFTER INSERT ON CustomOutputAdapter
FOR EACH ROW INSERT INTO Runtime (SourceID, SourceTable) VALUES(NEW.ID, N'CustomOutputAdapter');

CREATE TRIGGER CustomOutputAdapter_RuntimeSync_Delete BEFORE DELETE ON CustomOutputAdapter
FOR EACH ROW DELETE FROM Runtime WHERE SourceID = OLD.ID AND SourceTable = N'CustomOutputAdapter';

CREATE TRIGGER Device_RuntimeSync_Insert AFTER INSERT ON Device
FOR EACH ROW INSERT INTO Runtime (SourceID, SourceTable) VALUES(NEW.ID, N'Device');

CREATE TRIGGER Device_RuntimeSync_Delete BEFORE DELETE ON Device
FOR EACH ROW DELETE FROM Runtime WHERE SourceID = OLD.ID AND SourceTable = N'Device';

CREATE TRIGGER CalculatedMeasurement_RuntimeSync_Insert AFTER INSERT ON CalculatedMeasurement
FOR EACH ROW INSERT INTO Runtime (SourceID, SourceTable) VALUES(NEW.ID, N'CalculatedMeasurement');

CREATE TRIGGER CalculatedMeasurement_RuntimeSync_Delete BEFORE DELETE ON CalculatedMeasurement
FOR EACH ROW DELETE FROM Runtime WHERE SourceID = OLD.ID AND SourceTable = N'CalculatedMeasurement';

CREATE TRIGGER OutputStream_RuntimeSync_Insert AFTER INSERT ON OutputStream
FOR EACH ROW INSERT INTO Runtime (SourceID, SourceTable) VALUES(NEW.ID, N'OutputStream');

CREATE TRIGGER OutputStream_RuntimeSync_Delete BEFORE DELETE ON OutputStream
FOR EACH ROW DELETE FROM Runtime WHERE SourceID = OLD.ID AND SourceTable = N'OutputStream';

CREATE TRIGGER Historian_RuntimeSync_Insert AFTER INSERT ON Historian
FOR EACH ROW INSERT INTO Runtime (SourceID, SourceTable) VALUES(NEW.ID, N'Historian');

CREATE TRIGGER Historian_RuntimeSync_Delete BEFORE DELETE ON Historian
FOR EACH ROW DELETE FROM Runtime WHERE SourceID = OLD.ID AND SourceTable = N'Historian';

/*
CREATE FUNCTION StringToGuid(str CHAR(36)) RETURNS BINARY(16)
RETURN CONCAT(UNHEX(LEFT(str, 8)), UNHEX(MID(str, 10, 4)), UNHEX(MID(str, 15, 4)), UNHEX(MID(str, 20, 4)), UNHEX(RIGHT(str, 12)));

CREATE FUNCTION GuidToString(guid BINARY(16)) RETURNS CHAR(36) 
RETURN CONCAT(HEX(LEFT(guid, 4)), '-', HEX(MID(guid, 5, 2)), '-', HEX(MID(guid, 7, 2)), '-', HEX(MID(guid, 9, 2)), '-', HEX(RIGHT(guid, 6)));

CREATE FUNCTION NewGuid() RETURNS BINARY(16) 
RETURN StringToGuid(UUID());

DELIMITER $$
CREATE PROCEDURE GetFormattedMeasurements(measurementSql TEXT, includeAdjustments TINYINT, OUT measurements TEXT)
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
CREATE FUNCTION FormatMeasurements(measurementSql TEXT, includeAdjustments TINYINT)
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
