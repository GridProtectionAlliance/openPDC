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
-- GRANT SELECT, UPDATE, INSERT, DELETE ON openPDC.* TO NewUser;

CREATE TABLE ErrorLog(
	ID INT AUTO_INCREMENT NOT NULL,
	Source NVARCHAR(256) NOT NULL,
	Message NVARCHAR(1024) NOT NULL,
	Detail LONGTEXT NULL,
	CreatedOn DATETIME NOT NULL DEFAULT 0,
	CONSTRAINT PK_ErrorLog PRIMARY KEY (ID ASC)
);

CREATE TABLE Runtime(
	ID INT AUTO_INCREMENT NOT NULL,
	SourceID INT NOT NULL,
	SourceTable NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_Runtime PRIMARY KEY (SourceID ASC, SourceTable ASC),
	CONSTRAINT IX_Runtime UNIQUE KEY (ID)
);

CREATE TABLE AuditLog(
  ID INT NOT NULL AUTO_INCREMENT,
  TableName VARCHAR(128) NOT NULL,
  PrimaryKeyColumn VARCHAR(128) NOT NULL,
  PrimaryKeyValue LONGTEXT NOT NULL,
  ColumnName VARCHAR(128) NOT NULL,
  OriginalValue LONGTEXT,
  NewValue LONGTEXT,
  Deleted TINYINT(4) NOT NULL DEFAULT '0',
  UpdatedBy VARCHAR(128) NOT NULL DEFAULT '',
  UpdatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (ID)
);

CREATE TABLE Company(
	ID INT AUTO_INCREMENT NOT NULL,
	Acronym NVARCHAR(50) NOT NULL,
	MapAcronym NCHAR(3) NOT NULL,
	Name NVARCHAR(100) NOT NULL,
	URL LONGTEXT NULL,
	LoadOrder INT NOT NULL DEFAULT 0,
	CreatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	CreatedBy VARCHAR(50) NOT NULL DEFAULT '',
  	UpdatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	UpdatedBy VARCHAR(50) NOT NULL DEFAULT '',
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
	CreatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	CreatedBy VARCHAR(50) NOT NULL DEFAULT '',
  	UpdatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	UpdatedBy VARCHAR(50) NOT NULL DEFAULT '',
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
	CreatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	CreatedBy VARCHAR(50) NOT NULL DEFAULT '',
  	UpdatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	UpdatedBy VARCHAR(50) NOT NULL DEFAULT '',
	CONSTRAINT PK_Node PRIMARY KEY (ID ASC)
);

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
	CreatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	CreatedBy VARCHAR(50) NOT NULL DEFAULT '',
  	UpdatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	UpdatedBy VARCHAR(50) NOT NULL DEFAULT '',
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
	CreatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	CreatedBy VARCHAR(50) NOT NULL DEFAULT '',
  	UpdatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	UpdatedBy VARCHAR(50) NOT NULL DEFAULT '',
	CONSTRAINT PK_Device PRIMARY KEY (ID ASC),
	CONSTRAINT IX_Device_Acronym UNIQUE KEY (Acronym ASC)
);

CREATE TABLE VendorDevice(
	ID INT AUTO_INCREMENT NOT NULL,
	VendorID INT NOT NULL DEFAULT 10,
	Name NVARCHAR(100) NOT NULL,
	Description LONGTEXT NULL,
	URL LONGTEXT NULL,
	CreatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	CreatedBy VARCHAR(50) NOT NULL DEFAULT '',
  	UpdatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	UpdatedBy VARCHAR(50) NOT NULL DEFAULT '',
	CONSTRAINT PK_VendorDevice PRIMARY KEY (ID ASC)
);

CREATE TABLE OutputStreamDeviceDigital(
	NodeID NCHAR(36) NOT NULL,
	OutputStreamDeviceID INT NOT NULL,
	ID INT AUTO_INCREMENT NOT NULL,
	Label NVARCHAR(256) NOT NULL,
	MaskValue INT NOT NULL DEFAULT 0,
	LoadOrder INT NOT NULL DEFAULT 0,
	CreatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	CreatedBy VARCHAR(50) NOT NULL DEFAULT '',
  	UpdatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	UpdatedBy VARCHAR(50) NOT NULL DEFAULT '',
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
	CreatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	CreatedBy VARCHAR(50) NOT NULL DEFAULT '',
  	UpdatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	UpdatedBy VARCHAR(50) NOT NULL DEFAULT '',
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
	CreatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	CreatedBy VARCHAR(50) NOT NULL DEFAULT '',
  	UpdatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	UpdatedBy VARCHAR(50) NOT NULL DEFAULT '',
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
	CreatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	CreatedBy VARCHAR(50) NOT NULL DEFAULT '',
  	UpdatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	UpdatedBy VARCHAR(50) NOT NULL DEFAULT '',
	CONSTRAINT PK_Measurement PRIMARY KEY (SignalID ASC),
	CONSTRAINT IX_Measurement UNIQUE KEY (PointID ASC),
	CONSTRAINT IX_Measurement_PointTag UNIQUE KEY (PointTag ASC),
	CONSTRAINT IX_Measurement_SignalReference UNIQUE KEY (SignalReference ASC)
);

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
	CreatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	CreatedBy VARCHAR(50) NOT NULL DEFAULT '',
  	UpdatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	UpdatedBy VARCHAR(50) NOT NULL DEFAULT '',
	CONSTRAINT PK_OutputStreamMeasurement PRIMARY KEY (ID ASC)
);

CREATE TABLE OutputStreamDevice(
	NodeID NCHAR(36) NOT NULL,
	AdapterID INT NOT NULL,
	ID INT AUTO_INCREMENT NOT NULL,
	IDCode INT NOT NULL DEFAULT 0,
	Acronym NVARCHAR(16) NOT NULL,
	BpaAcronym NVARCHAR(4) NULL,
	Name NVARCHAR(100) NOT NULL,
	PhasorDataFormat NVARCHAR(15) NULL,
	FrequencyDataFormat NVARCHAR(15) NULL,
	AnalogDataFormat NVARCHAR(15) NULL,
	CoordinateFormat NVARCHAR(15) NULL,
	LoadOrder INT NOT NULL DEFAULT 0,
	Enabled TINYINT NOT NULL DEFAULT 0,
	CreatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	CreatedBy VARCHAR(50) NOT NULL DEFAULT '',
  	UpdatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	UpdatedBy VARCHAR(50) NOT NULL DEFAULT '',
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
	CreatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	CreatedBy VARCHAR(50) NOT NULL DEFAULT '',
  	UpdatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	UpdatedBy VARCHAR(50) NOT NULL DEFAULT '',
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
	PerformTimestampReasonabilityCheck TINYINT NOT NULL DEFAULT 1,
	DownsamplingMethod NVARCHAR(15) NOT NULL DEFAULT N'LastReceived',
	LoadOrder INT NOT NULL DEFAULT 0,
	Enabled TINYINT NOT NULL DEFAULT 0,
	CreatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	CreatedBy VARCHAR(50) NOT NULL DEFAULT '',
  	UpdatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	UpdatedBy VARCHAR(50) NOT NULL DEFAULT '',
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
	CreatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	CreatedBy VARCHAR(50) NOT NULL DEFAULT '',
  	UpdatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	UpdatedBy VARCHAR(50) NOT NULL DEFAULT '',
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
	CreatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	CreatedBy VARCHAR(50) NOT NULL DEFAULT '',
  	UpdatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	UpdatedBy VARCHAR(50) NOT NULL DEFAULT '',
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
	CreatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	CreatedBy VARCHAR(50) NOT NULL DEFAULT '',
  	UpdatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	UpdatedBy VARCHAR(50) NOT NULL DEFAULT '',
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
	TimeResolution INT NOT NULL DEFAULT 330000,
	AllowPreemptivePublishing TINYINT NOT NULL DEFAULT 1,
	PerformTimestampReasonabilityCheck TINYINT NOT NULL DEFAULT 1,
	DownsamplingMethod NVARCHAR(15) NOT NULL DEFAULT N'LastReceived',
	DataFormat NVARCHAR(15) NOT NULL DEFAULT N'FloatingPoint',
	CoordinateFormat NVARCHAR(15) NOT NULL DEFAULT N'Polar',
	CurrentScalingValue INT NOT NULL DEFAULT 2423,
	VoltageScalingValue INT NOT NULL DEFAULT 2725785,
	AnalogScalingValue INT NOT NULL DEFAULT 1373291,
	DigitalMaskValue INT NOT NULL DEFAULT -65536,
	LoadOrder INT NOT NULL DEFAULT 0,
	Enabled TINYINT NOT NULL DEFAULT 0,
	CreatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	CreatedBy VARCHAR(50) NOT NULL DEFAULT '',
  	UpdatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	UpdatedBy VARCHAR(50) NOT NULL DEFAULT '',
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
	CreatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	CreatedBy VARCHAR(50) NOT NULL DEFAULT '',
  	UpdatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
	UpdatedBy VARCHAR(50) NOT NULL DEFAULT '',
	CONSTRAINT PK_CustomOutputAdapter PRIMARY KEY (ID ASC)
);

CREATE TABLE AccessLog (
  ID INT(11) NOT NULL AUTO_INCREMENT,
  UserName VARCHAR(50) NOT NULL,
  AccessGranted TINYINT(3) UNSIGNED NOT NULL,
  COMMENT LONGTEXT,
  CreatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  CONSTRAINT PK_AccessLog PRIMARY KEY (ID ASC)
);

CREATE TABLE UserAccount (
  ID NCHAR(36) NOT NULL DEFAULT '',
  NAME VARCHAR(50) NOT NULL,
  PASSWORD VARCHAR(256) DEFAULT NULL,
  FirstName VARCHAR(50) DEFAULT NULL,
  LastName VARCHAR(50) DEFAULT NULL,
  DefaultNodeID NCHAR(36) NOT NULL,
  Phone VARCHAR(50) DEFAULT NULL,
  Email VARCHAR(256) DEFAULT NULL,
  LockedOut TINYINT(3) UNSIGNED NOT NULL DEFAULT '0',
  UseADAuthentication TINYINT(3) UNSIGNED NOT NULL DEFAULT '1',
  ChangePasswordOn DATETIME DEFAULT NULL,
  CreatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  CreatedBy VARCHAR(50) NOT NULL DEFAULT '',
  UpdatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  UpdatedBy VARCHAR(50) NOT NULL DEFAULT '',
  CONSTRAINT PK_UserAccount PRIMARY KEY (ID ASC)  
);

CREATE TABLE SecurityGroup (
  ID NCHAR(36) NOT NULL DEFAULT '',
  NAME VARCHAR(50) NOT NULL,
  Description LONGTEXT,
  CreatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  CreatedBy VARCHAR(50) NOT NULL DEFAULT '',
  UpdatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  UpdatedBy VARCHAR(50) NOT NULL DEFAULT '',
  CONSTRAINT PK_SecurityGorup PRIMARY KEY (ID ASC)
);

CREATE TABLE ApplicationRole (
  ID NCHAR(36) NOT NULL DEFAULT '',
  NAME VARCHAR(50) NOT NULL,
  Description LONGTEXT,
  NodeID NCHAR(36) NOT NULL,
  CreatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  CreatedBy VARCHAR(50) NOT NULL DEFAULT '',
  UpdatedOn DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  UpdatedBy VARCHAR(50) NOT NULL DEFAULT '',
  CONSTRAINT PK_ApplicationRole PRIMARY KEY (ID ASC)  
);

CREATE TABLE ApplicationRoleSecurityGroup (
  ApplicationRoleID NCHAR(36) NOT NULL,
  SecurityGroupID NCHAR(36) NOT NULL  
);

CREATE TABLE ApplicationRoleUserAccount (
  ApplicationRoleID NCHAR(36) NOT NULL,
  UserAccountID NCHAR(36) NOT NULL  
);

CREATE TABLE SecurityGroupUserAccount (
  SecurityGroupID NCHAR(36) NOT NULL,
  UserAccountID NCHAR(36) NOT NULL  
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

ALTER TABLE OutputStreamMeasurement ADD CONSTRAINT FK_OutputStreamMeasurement_OutputStream FOREIGN KEY(AdapterID) REFERENCES OutputStream (ID) ON DELETE CASCADE;

ALTER TABLE OutputStreamDevice ADD CONSTRAINT FK_OutputStreamDevice_Node FOREIGN KEY(NodeID) REFERENCES Node (ID);

ALTER TABLE OutputStreamDevice ADD CONSTRAINT FK_OutputStreamDevice_OutputStream FOREIGN KEY(AdapterID) REFERENCES OutputStream (ID) ON DELETE CASCADE;

ALTER TABLE Phasor ADD CONSTRAINT FK_Phasor_Device FOREIGN KEY(DeviceID) REFERENCES Device (ID) ON DELETE CASCADE;

ALTER TABLE Phasor ADD CONSTRAINT FK_Phasor_Phasor FOREIGN KEY(DestinationPhasorID) REFERENCES Phasor (ID);

ALTER TABLE CalculatedMeasurement ADD CONSTRAINT FK_CalculatedMeasurement_Node FOREIGN KEY(NodeID) REFERENCES Node (ID);

ALTER TABLE CustomActionAdapter ADD CONSTRAINT FK_CustomActionAdapter_Node FOREIGN KEY(NodeID) REFERENCES Node (ID);

ALTER TABLE Historian ADD CONSTRAINT FK_Historian_Node FOREIGN KEY(NodeID) REFERENCES Node (ID);

ALTER TABLE CustomInputAdapter ADD CONSTRAINT FK_CustomInputAdapter_Node FOREIGN KEY(NodeID) REFERENCES Node (ID);

ALTER TABLE OutputStream ADD CONSTRAINT FK_OutputStream_Node FOREIGN KEY(NodeID) REFERENCES Node (ID);

ALTER TABLE CustomOutputAdapter ADD CONSTRAINT FK_CustomOutputAdapter_Node FOREIGN KEY(NodeID) REFERENCES Node (ID);

ALTER TABLE ApplicationRoleSecurityGroup ADD CONSTRAINT FK_applicationrolesecuritygroup_applicationrole FOREIGN KEY (ApplicationRoleID) REFERENCES applicationrole (ID) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE ApplicationRoleSecurityGroup ADD CONSTRAINT FK_applicationrolesecuritygroup_securitygroup FOREIGN KEY (SecurityGroupID) REFERENCES securitygroup (ID) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE UserAccount ADD CONSTRAINT FK_useraccount FOREIGN KEY (DefaultNodeID) REFERENCES node (ID) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE ApplicationRole ADD CONSTRAINT FK_applicationrole FOREIGN KEY (NodeID) REFERENCES node (ID) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE ApplicationRoleUserAccount ADD CONSTRAINT FK_applicationroleuseraccount_useraccount FOREIGN KEY (UserAccountID) REFERENCES useraccount (ID) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE ApplicationRoleUserAccount ADD CONSTRAINT FK_applicationroleuseraccount_applicationrole FOREIGN KEY (ApplicationRoleID) REFERENCES applicationrole (ID) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE SecurityGroupUserAccount ADD CONSTRAINT FK_securitygroupuseraccount_useraccount FOREIGN KEY (UserAccountID) REFERENCES useraccount (ID) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE SecurityGroupUserAccount ADD CONSTRAINT FK_securitygroupuseraccount_securitygroup FOREIGN KEY (SecurityGroupID) REFERENCES securitygroup (ID) ON DELETE CASCADE ON UPDATE CASCADE;

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
SELECT Device.NodeID, Runtime_P.ID AS ParentID, Runtime.ID, Device.Acronym, Device.Name, Device.AccessID
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
SELECT OutputStreamDevice.NodeID, Runtime.ID AS ParentID, OutputStreamDevice.ID, OutputStreamDevice.IDCode, OutputStreamDevice.Acronym, 
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
 CONCAT(N'performTimestampReasonabilityCheck=', CAST(OutputStream.PerformTimestampReasonabilityCheck AS CHAR)),
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
 CONCAT(N'performTimestampReasonabilityCheck=', CAST(CalculatedMeasurement.PerformTimestampReasonabilityCheck AS CHAR)),
 CONCAT(N'downsamplingMethod=', CalculatedMeasurement.DownsamplingMethod)),
 CONCAT(N'useLocalClockAsRealTime=', CAST(CalculatedMeasurement.UseLocalClockAsRealTime AS CHAR)) AS ConnectionString
FROM CalculatedMeasurement LEFT OUTER JOIN
 Runtime ON CalculatedMeasurement.ID = Runtime.SourceID AND Runtime.SourceTable = N'CalculatedMeasurement'
WHERE (CalculatedMeasurement.Enabled <> 0)
ORDER BY CalculatedMeasurement.LoadOrder;

CREATE VIEW ActiveMeasurement
AS
SELECT COALESCE(Historian.NodeID, Device.NodeID) AS NodeID, COALESCE(Device.NodeID, Historian.NodeID) AS SourceNodeID, CONCAT_WS(':', COALESCE(Historian.Acronym, Device.Acronym, '__'), CAST(Measurement.PointID AS CHAR)) AS ID, Measurement.SignalID, Measurement.PointTag, 
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
                      Measurement.PointID, Measurement.PointTag, Measurement.AlternateTag, Measurement.DeviceID,  COALESCE (Device.NodeID, Historian.NodeID) AS NodeID, 
                      Device.Acronym AS DeviceAcronym, Device.Name AS DeviceName, COALESCE(Device.FramesPerSecond, 30) AS FramesPerSecond, Device.Enabled AS DeviceEnabled, Device.ContactList, 
                      Device.VendorDeviceID, VendorDevice.Name AS VendorDeviceName, VendorDevice.Description AS VendorDeviceDescription, 
                      Device.ProtocolID, Protocol.Acronym AS ProtocolAcronym, Protocol.Name AS ProtocolName, Measurement.SignalTypeID, 
                      Measurement.PhasorSourceIndex, Phasor.Label AS PhasorLabel, Phasor.Type AS PhasorType, Phasor.Phase, 
                      Measurement.SignalReference, Measurement.Adder, Measurement.Multiplier, Measurement.Description, Measurement.Enabled, 
                      COALESCE (SignalType.EngineeringUnits, N'') AS EngineeringUnits, SignalType.Source, SignalType.Acronym AS SignalAcronym, 
                      SignalType.Name AS SignalName, SignalType.Suffix AS SignalTypeSuffix, Device.Longitude, Device.Latitude,
					  CONCAT_WS(':', COALESCE(Historian.Acronym, Device.Acronym, '__'), CAST(Measurement.PointID AS CHAR)) AS ID
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
		N.Name AS NodeName, CM.IgnoreBadTimeStamps, CM.TimeResolution, CM.AllowPreemptivePublishing, COALESCE(CM.DownsamplingMethod, '') AS DownsamplingMethod, CM.PerformTimestampReasonabilityCheck
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
                      OS.AllowPreemptivePublishing, OS.TimeResolution, OS.IgnoreBadTimeStamps, OS.PerformTimestampReasonabilityCheck
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
			COALESCE(AnalogDataFormat, '') AS AnalogDataFormat, COALESCE(CoordinateFormat, '') AS CoordinateFormat, IDCode,
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

CREATE VIEW ApplicationRoleSecurityGroupDetail AS 
SELECT ApplicationRoleSecurityGroup.ApplicationRoleID AS ApplicationRoleID,ApplicationRoleSecurityGroup.SecurityGroupID AS SecurityGroupID,ApplicationRole.Name AS ApplicationRoleName,ApplicationRole.Description AS ApplicationRoleDescription,SecurityGroup.Name AS SecurityGroupName,SecurityGroup.Description AS SecurityGroupDescription 
FROM ((ApplicationRoleSecurityGroup JOIN ApplicationRole ON((ApplicationRoleSecurityGroup.ApplicationRoleID = ApplicationRole.ID))) 
	JOIN SecurityGroup ON((ApplicationRoleSecurityGroup.SecurityGroupID = SecurityGroup.ID)));

CREATE VIEW ApplicationRoleUserAccountDetail AS 
SELECT ApplicationRoleUserAccount.ApplicationRoleID AS ApplicationRoleID,ApplicationRoleUserAccount.UserAccountID AS UserAccountID,UserAccount.Name AS UserName,UserAccount.FirstName AS FirstName,UserAccount.LastName AS LastName,UserAccount.Email AS Email,ApplicationRole.Name AS ApplicationRoleName,ApplicationRole.Description AS ApplicationRoleDescription 
FROM ((ApplicationRoleUserAccount JOIN ApplicationRole ON((ApplicationRoleUserAccount.ApplicationRoleID = ApplicationRole.ID))) JOIN UserAccount ON((ApplicationRoleUserAccount.UserAccountID = UserAccount.ID)));

CREATE VIEW SecurityGroupUserAccountDetail AS 
SELECT SecurityGroupUserAccount.SecurityGroupID AS SecurityGroupID,SecurityGroupUserAccount.UserAccountID AS UserAccountID,UserAccount.Name AS UserName,UserAccount.FirstName AS FirstName,UserAccount.LastName AS LastName,UserAccount.Email AS Email,SecurityGroup.Name AS SecurityGroupName,SecurityGroup.Description AS SecurityGroupDescription 
FROM ((SecurityGroupUserAccount JOIN SecurityGroup ON((SecurityGroupUserAccount.SecurityGroupID = SecurityGroup.ID))) JOIN UserAccount ON((SecurityGroupUserAccount.UserAccountID = UserAccount.ID)));

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

CREATE  TRIGGER AccessLog_InsertDefault BEFORE INSERT ON AccessLog 
FOR EACH ROW SET NEW.CreatedOn = UTC_TIMESTAMP();

CREATE  TRIGGER ApplicationRole_InsertDefault BEFORE INSERT ON ApplicationRole 
FOR EACH ROW SET NEW.ID = UUID(), NEW.CreatedBy = USER(), NEW.CreatedOn = UTC_TIMESTAMP(), NEW.UpdatedBy = USER(), NEW.UpdatedOn = UTC_TIMESTAMP();

CREATE  TRIGGER SecurityGroup_InsertDefault BEFORE INSERT ON SecurityGroup 
FOR EACH ROW SET NEW.ID = UUID(), NEW.CreatedBy = USER(), NEW.CreatedOn = UTC_TIMESTAMP(), NEW.UpdatedBy = USER(), NEW.UpdatedOn = UTC_TIMESTAMP();

CREATE  TRIGGER UserAccount_InsertDefault BEFORE INSERT ON UserAccount 
FOR EACH ROW SET NEW.ID = UUID(), NEW.ChangePasswordOn = ADDDATE(UTC_TIMESTAMP(), 90), NEW.CreatedBy = USER(), NEW.CreatedOn = UTC_TIMESTAMP(), NEW.UpdatedBy = USER(), NEW.UpdatedOn = UTC_TIMESTAMP();

CREATE  TRIGGER CalculatedMeasurement_InsertDefault BEFORE INSERT ON CalculatedMeasurement
FOR EACH ROW SET NEW.CreatedBy = USER(), NEW.CreatedOn = UTC_TIMESTAMP(), NEW.UpdatedBy = USER(), NEW.UpdatedOn = UTC_TIMESTAMP();

CREATE  TRIGGER Company_InsertDefault BEFORE INSERT ON Company
FOR EACH ROW SET NEW.CreatedBy = USER(), NEW.CreatedOn = UTC_TIMESTAMP(), NEW.UpdatedBy = USER(), NEW.UpdatedOn = UTC_TIMESTAMP();

CREATE  TRIGGER CustomActionAdapter_InsertDefault BEFORE INSERT ON CustomActionAdapter
FOR EACH ROW SET NEW.CreatedBy = USER(), NEW.CreatedOn = UTC_TIMESTAMP(), NEW.UpdatedBy = USER(), NEW.UpdatedOn = UTC_TIMESTAMP();

CREATE  TRIGGER CustomInputAdapter_InsertDefault BEFORE INSERT ON CustomInputAdapter
FOR EACH ROW SET NEW.CreatedBy = USER(), NEW.CreatedOn = UTC_TIMESTAMP(), NEW.UpdatedBy = USER(), NEW.UpdatedOn = UTC_TIMESTAMP();

CREATE  TRIGGER CustomOutputAdapter_InsertDefault BEFORE INSERT ON CustomOutputAdapter
FOR EACH ROW SET NEW.CreatedBy = USER(), NEW.CreatedOn = UTC_TIMESTAMP(), NEW.UpdatedBy = USER(), NEW.UpdatedOn = UTC_TIMESTAMP();

CREATE  TRIGGER Device_InsertDefault BEFORE INSERT ON Device
FOR EACH ROW SET NEW.CreatedBy = USER(), NEW.CreatedOn = UTC_TIMESTAMP(), NEW.UpdatedBy = USER(), NEW.UpdatedOn = UTC_TIMESTAMP();

CREATE  TRIGGER Historian_InsertDefault BEFORE INSERT ON Historian
FOR EACH ROW SET NEW.CreatedBy = USER(), NEW.CreatedOn = UTC_TIMESTAMP(), NEW.UpdatedBy = USER(), NEW.UpdatedOn = UTC_TIMESTAMP();

CREATE  TRIGGER Measurement_InsertDefault BEFORE INSERT ON Measurement
FOR EACH ROW SET NEW.SignalID = UUID(), NEW.CreatedBy = USER(), NEW.CreatedOn = UTC_TIMESTAMP(), NEW.UpdatedBy = USER(), NEW.UpdatedOn = UTC_TIMESTAMP();

CREATE  TRIGGER Node_InsertDefault BEFORE INSERT ON Node
FOR EACH ROW SET NEW.ID = UUID(), NEW.CreatedBy = USER(), NEW.CreatedOn = UTC_TIMESTAMP(), NEW.UpdatedBy = USER(), NEW.UpdatedOn = UTC_TIMESTAMP();

CREATE  TRIGGER OtherDevice_InsertDefault BEFORE INSERT ON OtherDevice
FOR EACH ROW SET NEW.CreatedBy = USER(), NEW.CreatedOn = UTC_TIMESTAMP(), NEW.UpdatedBy = USER(), NEW.UpdatedOn = UTC_TIMESTAMP();

CREATE  TRIGGER OutputStream_InsertDefault BEFORE INSERT ON OutputStream
FOR EACH ROW SET NEW.CreatedBy = USER(), NEW.CreatedOn = UTC_TIMESTAMP(), NEW.UpdatedBy = USER(), NEW.UpdatedOn = UTC_TIMESTAMP();

CREATE  TRIGGER OutputStreamDevice_InsertDefault BEFORE INSERT ON OutputStreamDevice
FOR EACH ROW SET NEW.CreatedBy = USER(), NEW.CreatedOn = UTC_TIMESTAMP(), NEW.UpdatedBy = USER(), NEW.UpdatedOn = UTC_TIMESTAMP();

CREATE  TRIGGER OutputStreamDeviceAnalog_InsertDefault BEFORE INSERT ON OutputStreamDeviceAnalog
FOR EACH ROW SET NEW.CreatedBy = USER(), NEW.CreatedOn = UTC_TIMESTAMP(), NEW.UpdatedBy = USER(), NEW.UpdatedOn = UTC_TIMESTAMP();

CREATE  TRIGGER OutputStreamDeviceDigital_InsertDefault BEFORE INSERT ON OutputStreamDeviceDigital
FOR EACH ROW SET NEW.CreatedBy = USER(), NEW.CreatedOn = UTC_TIMESTAMP(), NEW.UpdatedBy = USER(), NEW.UpdatedOn = UTC_TIMESTAMP();

CREATE  TRIGGER OutputStreamDevicePhasor_InsertDefault BEFORE INSERT ON OutputStreamDevicePhasor
FOR EACH ROW SET NEW.CreatedBy = USER(), NEW.CreatedOn = UTC_TIMESTAMP(), NEW.UpdatedBy = USER(), NEW.UpdatedOn = UTC_TIMESTAMP();

CREATE  TRIGGER OutputStreamMeasurement_InsertDefault BEFORE INSERT ON OutputStreamMeasurement
FOR EACH ROW SET NEW.CreatedBy = USER(), NEW.CreatedOn = UTC_TIMESTAMP(), NEW.UpdatedBy = USER(), NEW.UpdatedOn = UTC_TIMESTAMP();

CREATE  TRIGGER Phasor_InsertDefault BEFORE INSERT ON Phasor
FOR EACH ROW SET NEW.CreatedBy = USER(), NEW.CreatedOn = UTC_TIMESTAMP(), NEW.UpdatedBy = USER(), NEW.UpdatedOn = UTC_TIMESTAMP();

CREATE  TRIGGER Vendor_InsertDefault BEFORE INSERT ON Vendor
FOR EACH ROW SET NEW.CreatedBy = USER(), NEW.CreatedOn = UTC_TIMESTAMP(), NEW.UpdatedBy = USER(), NEW.UpdatedOn = UTC_TIMESTAMP();

CREATE  TRIGGER VendorDevice_InsertDefault BEFORE INSERT ON VendorDevice
FOR EACH ROW SET NEW.CreatedBy = USER(), NEW.CreatedOn = UTC_TIMESTAMP(), NEW.UpdatedBy = USER(), NEW.UpdatedOn = UTC_TIMESTAMP();

CREATE TRIGGER ErrorLog_InsertDefault BEFORE INSERT ON ErrorLog FOR EACH ROW
SET NEW.CreatedOn = UTC_TIMESTAMP();

CREATE TRIGGER AuditLog_InsertDefault BEFORE INSERT ON AuditLog FOR EACH ROW
SET NEW.UpdatedOn = UTC_TIMESTAMP();	

DELIMITER $$

CREATE TRIGGER UserAccount_AuditUpdate AFTER UPDATE ON UserAccount FOR EACH ROW 
	BEGIN
    	
		IF OLD.Name != NEW.Name THEN 
			INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Name', OriginalValue = OLD.Name, NewValue = NEW.Name, UpdatedBy = NEW.UpdatedBy;
		END IF;

		IF OLD.Password != NEW.Password THEN
			INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Password', OriginalValue = OLD.Password, NewValue = NEW.Password, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.FirstName != NEW.FirstName THEN
			INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'FirstName', OriginalValue = OLD.FirstName, NewValue = NEW.FirstName, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.LastName != NEW.LastName THEN
			INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LastName', OriginalValue = OLD.LastName, NewValue = NEW.LastName, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.DefaultNodeID != NEW.DefaultNodeID THEN
			INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'DefaultNodeID', OriginalValue = OLD.DefaultNodeID, NewValue = NEW.DefaultNodeID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Phone != NEW.Phone THEN
			INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Phone', OriginalValue = OLD.Phone, NewValue = NEW.Phone, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Email != NEW.Email THEN
			INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Email', OriginalValue = OLD.Email, NewValue = NEW.Email, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.LockedOut != NEW.LockedOut THEN
			INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LockedOut', OriginalValue = OLD.LockedOut, NewValue = NEW.LockedOut, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UseADAuthentication != NEW.UseADAuthentication THEN
			INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UseADAuthentication', OriginalValue = OLD.UseADAuthentication, NewValue = NEW.UseADAuthentication, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.ChangePasswordOn != NEW.ChangePasswordOn THEN
			INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ChangePasswordOn', OriginalValue = OLD.ChangePasswordOn, NewValue = NEW.ChangePasswordOn, UpdatedBy = NEW.UpdatedBy;
		END IF;

		IF OLD.UpdatedOn != NEW.UpdatedOn THEN
			INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NEW.UpdatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedBy != NEW.UpdatedBy THEN
			INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NEW.UpdatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;			
	
		IF OLD.CreatedBy != NEW.CreatedBy THEN
			INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NEW.CreatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedOn != NEW.CreatedOn THEN
			INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NEW.CreatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
    END$$

CREATE TRIGGER UserAccount_AuditDelete AFTER DELETE ON UserAccount
    FOR EACH ROW BEGIN
		INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Name', OriginalValue = OLD.Name, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Password', OriginalValue = OLD.Password, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'FirstName', OriginalValue = OLD.FirstName, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LastName', OriginalValue = OLD.LastName, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'DefaultNodeID', OriginalValue = OLD.DefaultNodeID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Phone', OriginalValue = OLD.Phone, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Email', OriginalValue = OLD.Email, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LockedOut', OriginalValue = OLD.LockedOut, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UseADAuthentication', OriginalValue = OLD.UseADAuthentication, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ChangePasswordOn', OriginalValue = OLD.ChangePasswordOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'UserAccount', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
	
	END$$

CREATE TRIGGER SecurityGroup_AuditUpdate AFTER UPDATE ON SecurityGroup
    FOR EACH ROW BEGIN
	
		IF OLD.Name != NEW.Name THEN
			INSERT INTO AuditLog SET TableName = 'SecurityGroup', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Name', OriginalValue = OLD.Name, NewValue = NEW.Name, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Description != NEW.Description THEN
			INSERT INTO AuditLog SET TableName = 'SecurityGroup', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Description', OriginalValue = OLD.Description, NewValue = NEW.Description, UpdatedBy = NEW.UpdatedBy;
		END IF;

		IF OLD.UpdatedOn != NEW.UpdatedOn THEN
			INSERT INTO AuditLog SET TableName = 'SecurityGroup', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NEW.UpdatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedBy != NEW.UpdatedBy THEN
			INSERT INTO AuditLog SET TableName = 'SecurityGroup', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NEW.UpdatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;

		IF OLD.CreatedBy != NEW.CreatedBy THEN
			INSERT INTO AuditLog SET TableName = 'SecurityGroup', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NEW.CreatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedOn != NEW.CreatedOn THEN
			INSERT INTO AuditLog SET TableName = 'SecurityGroup', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NEW.CreatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
    END$$

CREATE TRIGGER SecurityGroup_AuditDelete AFTER DELETE ON SecurityGroup
    FOR EACH ROW BEGIN		
		INSERT INTO AuditLog SET TableName = 'SecurityGroup', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Name', OriginalValue = OLD.Name, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'SecurityGroup', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Description', OriginalValue = OLD.Description, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'SecurityGroup', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'SecurityGroup', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'SecurityGroup', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'SecurityGroup', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
	END$$

CREATE TRIGGER ApplicationRole_AuditUpdate AFTER UPDATE ON ApplicationRole
    FOR EACH ROW BEGIN

		IF OLD.Name != NEW.Name THEN
			INSERT INTO AuditLog SET TableName = 'ApplicationRole', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Name', OriginalValue = OLD.Name, NewValue = NEW.Name, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Description != NEW.Description THEN
			INSERT INTO AuditLog SET TableName = 'ApplicationRole', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Description', OriginalValue = OLD.Description, NewValue = NEW.Description, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.NodeID != NEW.NodeID THEN
			INSERT INTO AuditLog SET TableName = 'ApplicationRole', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NodeID', OriginalValue = OLD.NodeID, NewValue = NEW.NodeID, UpdatedBy = NEW.UpdatedBy;
		END IF;

		IF OLD.UpdatedOn != NEW.UpdatedOn THEN
			INSERT INTO AuditLog SET TableName = 'ApplicationRole', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NEW.UpdatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedBy != NEW.UpdatedBy THEN
			INSERT INTO AuditLog SET TableName = 'ApplicationRole', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NEW.UpdatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;

		IF OLD.CreatedBy != NEW.CreatedBy THEN
			INSERT INTO AuditLog SET TableName = 'ApplicationRole', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NEW.CreatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedOn != NEW.CreatedOn THEN
			INSERT INTO AuditLog SET TableName = 'ApplicationRole', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NEW.CreatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;

    END$$

CREATE TRIGGER ApplicationRole_AuditDelete AFTER DELETE ON ApplicationRole
    FOR EACH ROW BEGIN	
		INSERT INTO AuditLog SET TableName = 'ApplicationRole', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Name', OriginalValue = OLD.Name, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'ApplicationRole', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Description', OriginalValue = OLD.Description, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'ApplicationRole', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NodeID', OriginalValue = OLD.NodeID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'ApplicationRole', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'ApplicationRole', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'ApplicationRole', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'ApplicationRole', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
	
	END$$

CREATE TRIGGER CalculatedMeasurement_AuditUpdate AFTER UPDATE ON CalculatedMeasurement
    FOR EACH ROW BEGIN
    
		IF OLD.NodeID != NEW.NodeID THEN
			INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NodeID', OriginalValue = OLD.NodeID, NewValue = NEW.NodeID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Acronym != NEW.Acronym THEN
			INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Acronym', OriginalValue = OLD.Acronym, NewValue = NEW.Acronym, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Name != NEW.Name THEN
			INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Name', OriginalValue = OLD.Name, NewValue = NEW.Name, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.AssemblyName != NEW.AssemblyName THEN
			INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AssemblyName', OriginalValue = OLD.AssemblyName, NewValue = NEW.AssemblyName, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.TypeName != NEW.TypeName THEN
			INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'TypeName', OriginalValue = OLD.TypeName, NewValue = NEW.TypeName, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.ConnectionString != NEW.ConnectionString THEN
			INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ConnectionString', OriginalValue = OLD.ConnectionString, NewValue = NEW.ConnectionString, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.ConfigSection != NEW.ConfigSection THEN
			INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ConfigSection', OriginalValue = OLD.ConfigSection, NewValue = NEW.ConfigSection, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.InputMeasurements != NEW.InputMeasurements THEN
			INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'InputMeasurements', OriginalValue = OLD.InputMeasurements, NewValue = NEW.InputMeasurements, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.OutputMeasurements != NEW.OutputMeasurements THEN
			INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'OutputMeasurements', OriginalValue = OLD.OutputMeasurements, NewValue = NEW.OutputMeasurements, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.MinimumMeasurementsToUse != NEW.MinimumMeasurementsToUse THEN
			INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'MinimumMeasurementsToUse', OriginalValue = OLD.MinimumMeasurementsToUse, NewValue = NEW.MinimumMeasurementsToUse, UpdatedBy = NEW.UpdatedBy;
		END IF;
		
		IF OLD.FramesPerSecond != NEW.FramesPerSecond THEN
			INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'FramesPerSecond', OriginalValue = OLD.FramesPerSecond, NewValue = NEW.FramesPerSecond, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.LagTime != NEW.LagTime THEN	
			INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LagTime', OriginalValue = OLD.LagTime, NewValue = NEW.LagTime, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.LeadTime != NEW.LeadTime THEN
			INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LeadTime', OriginalValue = OLD.LeadTime, NewValue = NEW.LeadTime, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UseLocalClockAsRealTime != NEW.UseLocalClockAsRealTime THEN
			INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UseLocalClockAsRealTime', OriginalValue = OLD.UseLocalClockAsRealTime, NewValue = NEW.UseLocalClockAsRealTime, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.AllowSortsByArrival != NEW.AllowSortsByArrival THEN
			INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AllowSortsByArrival', OriginalValue = OLD.AllowSortsByArrival, NewValue = NEW.AllowSortsByArrival, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.IgnoreBadTimestamps != NEW.IgnoreBadTimestamps THEN
			INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'IgnoreBadTimestamps', OriginalValue = OLD.IgnoreBadTimestamps, NewValue = NEW.IgnoreBadTimestamps, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.TimeResolution != NEW.TimeResolution THEN
			INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'TimeResolution', OriginalValue = OLD.TimeResolution, NewValue = NEW.TimeResolution, UpdatedBy = NEW.UpdatedBy;
		END IF;

		IF OLD.AllowPreemptivePublishing != NEW.AllowPreemptivePublishing THEN
			INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AllowPreemptivePublishing', OriginalValue = OLD.AllowPreemptivePublishing, NewValue = NEW.AllowPreemptivePublishing, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.PerformTimestampReasonabilityCheck != NEW.PerformTimestampReasonabilityCheck THEN
			INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'PerformTimestampReasonabilityCheck', OriginalValue = OLD.PerformTimestampReasonabilityCheck, NewValue = NEW.PerformTimestampReasonabilityCheck, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.DownsamplingMethod != NEW.DownsamplingMethod THEN
			INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'DownsamplingMethod', OriginalValue = OLD.DownsamplingMethod, NewValue = NEW.DownsamplingMethod, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.LoadOrder != NEW.LoadOrder THEN
			INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LoadOrder', OriginalValue = OLD.LoadOrder, NewValue = NEW.LoadOrder, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Enabled != NEW.Enabled THEN
			INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Enabled', OriginalValue = OLD.Enabled, NewValue = NEW.Enabled, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedOn != NEW.UpdatedOn THEN
			INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NEW.UpdatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedBy != NEW.UpdatedBy THEN
			INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NEW.UpdatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;

		IF OLD.CreatedBy != NEW.CreatedBy THEN
			INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NEW.CreatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedOn != NEW.CreatedOn THEN
			INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NEW.CreatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;

    END$$

CREATE TRIGGER CalculatedMeasurement_AuditDelete AFTER DELETE ON CalculatedMeasurement
    FOR EACH ROW BEGIN
    
		INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NodeID', OriginalValue = OLD.NodeID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Acronym', OriginalValue = OLD.Acronym, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Name', OriginalValue = OLD.Name, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AssemblyName', OriginalValue = OLD.AssemblyName, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'TypeName', OriginalValue = OLD.TypeName, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ConnectionString', OriginalValue = OLD.ConnectionString, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ConfigSection', OriginalValue = OLD.ConfigSection, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'InputMeasurements', OriginalValue = OLD.InputMeasurements, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'OutputMeasurements', OriginalValue = OLD.OutputMeasurements, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'MinimumMeasurementsToUse', OriginalValue = OLD.MinimumMeasurementsToUse, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'FramesPerSecond', OriginalValue = OLD.FramesPerSecond, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LagTime', OriginalValue = OLD.LagTime, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LeadTime', OriginalValue = OLD.LeadTime, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UseLocalClockAsRealTime', OriginalValue = OLD.UseLocalClockAsRealTime, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AllowSortsByArrival', OriginalValue = OLD.AllowSortsByArrival, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'IgnoreBadTimestamps', OriginalValue = OLD.IgnoreBadTimestamps, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'TimeResolution', OriginalValue = OLD.TimeResolution, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AllowPreemptivePublishing', OriginalValue = OLD.AllowPreemptivePublishing, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'PerformTimestampReasonabilityCheck', OriginalValue = OLD.PerformTimestampReasonabilityCheck, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'DownsamplingMethod', OriginalValue = OLD.DownsamplingMethod, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LoadOrder', OriginalValue = OLD.LoadOrder, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Enabled', OriginalValue = OLD.Enabled, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CalculatedMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;

    END$$

CREATE TRIGGER Company_AuditUpdate AFTER UPDATE ON Company
    FOR EACH ROW BEGIN

		IF OLD.Acronym != NEW.Acronym THEN
			INSERT INTO AuditLog SET TableName = 'Company', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Acronym', OriginalValue = OLD.Acronym, NewValue = NEW.Acronym, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.MapAcronym != NEW.MapAcronym THEN
			INSERT INTO AuditLog SET TableName = 'Company', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'MapAcronym', OriginalValue = OLD.MapAcronym, NewValue = NEW.MapAcronym, UpdatedBy = NEW.UpdatedBy;
		END IF;

		IF OLD.Name != NEW.Name THEN
			INSERT INTO AuditLog SET TableName = 'Company', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Name', OriginalValue = OLD.Name, NewValue = NEW.Name, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Url != NEW.Url THEN
			INSERT INTO AuditLog SET TableName = 'Company', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Url', OriginalValue = OLD.Url, NewValue = NEW.Url, UpdatedBy = NEW.UpdatedBy;
		END IF;

		IF OLD.LoadOrder != NEW.LoadOrder THEN
			INSERT INTO AuditLog SET TableName = 'Company', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LoadOrder', OriginalValue = OLD.LoadOrder, NewValue = NEW.LoadOrder, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedBy != NEW.UpdatedBy THEN
			INSERT INTO AuditLog SET TableName = 'Company', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NEW.UpdatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedOn != NEW.UpdatedOn THEN
			INSERT INTO AuditLog SET TableName = 'Company', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NEW.UpdatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedBy != NEW.CreatedBy THEN
			INSERT INTO AuditLog SET TableName = 'Company', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NEW.CreatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedOn != NEW.CreatedOn THEN
			INSERT INTO AuditLog SET TableName = 'Company', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NEW.CreatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
    END$$

CREATE TRIGGER Company_AuditDelete AFTER DELETE ON Company
    FOR EACH ROW BEGIN
    
		INSERT INTO AuditLog SET TableName = 'Company', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Acronym', OriginalValue = OLD.Acronym, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Company', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'MapAcronym', OriginalValue = OLD.MapAcronym, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Company', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Name', OriginalValue = OLD.Name, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Company', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Url', OriginalValue = OLD.Url, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Company', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LoadOrder', OriginalValue = OLD.LoadOrder, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Company', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Company', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Company', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Company', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
	
    END$$

CREATE TRIGGER CustomActionAdapter_AuditUpdate AFTER UPDATE ON CustomActionAdapter
    FOR EACH ROW BEGIN

		IF OLD.NodeID != NEW.NodeID THEN
			INSERT INTO AuditLog SET TableName = 'CustomActionAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NodeID', OriginalValue = OLD.NodeID, NewValue = NEW.NodeID, UpdatedBy = NEW.UpdatedBy;
		END IF;

		IF OLD.AdapterName != NEW.AdapterName THEN
			INSERT INTO AuditLog SET TableName = 'CustomActionAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AdapterName', OriginalValue = OLD.AdapterName, NewValue = NEW.AdapterName, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.AssemblyName != NEW.AssemblyName THEN
			INSERT INTO AuditLog SET TableName = 'CustomActionAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AssemblyName', OriginalValue = OLD.AssemblyName, NewValue = NEW.AssemblyName, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.TypeName != NEW.TypeName THEN
			INSERT INTO AuditLog SET TableName = 'CustomActionAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'TypeName', OriginalValue = OLD.TypeName, NewValue = NEW.TypeName, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.ConnectionString != NEW.ConnectionString THEN
			INSERT INTO AuditLog SET TableName = 'CustomActionAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ConnectionString', OriginalValue = OLD.ConnectionString, NewValue = NEW.ConnectionString, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.LoadOrder != NEW.LoadOrder THEN
			INSERT INTO AuditLog SET TableName = 'CustomActionAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LoadOrder', OriginalValue = OLD.LoadOrder, NewValue = NEW.LoadOrder, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Enabled != NEW.Enabled THEN
			INSERT INTO AuditLog SET TableName = 'CustomActionAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Enabled', OriginalValue = OLD.Enabled, NewValue = NEW.Enabled, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedBy != NEW.UpdatedBy THEN
			INSERT INTO AuditLog SET TableName = 'CustomActionAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NEW.UpdatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedOn != NEW.UpdatedOn THEN
			INSERT INTO AuditLog SET TableName = 'CustomActionAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NEW.UpdatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedBy != NEW.CreatedBy THEN
			INSERT INTO AuditLog SET TableName = 'CustomActionAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NEW.CreatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedOn != NEW.CreatedOn THEN
			INSERT INTO AuditLog SET TableName = 'CustomActionAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NEW.CreatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;

    END$$

CREATE TRIGGER CustomActionAdapter_AuditDelete AFTER DELETE ON CustomActionAdapter
    FOR EACH ROW BEGIN

		INSERT INTO AuditLog SET TableName = 'CustomActionAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NodeID', OriginalValue = OLD.NodeID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomActionAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AdapterName', OriginalValue = OLD.AdapterName, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomActionAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AssemblyName', OriginalValue = OLD.AssemblyName, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomActionAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'TypeName', OriginalValue = OLD.TypeName, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomActionAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ConnectionString', OriginalValue = OLD.ConnectionString, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomActionAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LoadOrder', OriginalValue = OLD.LoadOrder, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomActionAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Enabled', OriginalValue = OLD.Enabled, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomActionAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomActionAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomActionAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomActionAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
	
    END$$

CREATE TRIGGER CustomInputAdapter_AuditUpdate AFTER UPDATE ON CustomInputAdapter
    FOR EACH ROW BEGIN

		IF OLD.NodeID != NEW.NodeID THEN
			INSERT INTO AuditLog SET TableName = 'CustomInputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NodeID', OriginalValue = OLD.NodeID, NewValue = NEW.NodeID, UpdatedBy = NEW.UpdatedBy;
		END IF;

		IF OLD.AdapterName != NEW.AdapterName THEN
			INSERT INTO AuditLog SET TableName = 'CustomInputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AdapterName', OriginalValue = OLD.AdapterName, NewValue = NEW.AdapterName, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.AssemblyName != NEW.AssemblyName THEN
			INSERT INTO AuditLog SET TableName = 'CustomInputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AssemblyName', OriginalValue = OLD.AssemblyName, NewValue = NEW.AssemblyName, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.TypeName != NEW.TypeName THEN
			INSERT INTO AuditLog SET TableName = 'CustomInputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'TypeName', OriginalValue = OLD.TypeName, NewValue = NEW.TypeName, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.ConnectionString != NEW.ConnectionString THEN
			INSERT INTO AuditLog SET TableName = 'CustomInputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ConnectionString', OriginalValue = OLD.ConnectionString, NewValue = NEW.ConnectionString, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.LoadOrder != NEW.LoadOrder THEN
			INSERT INTO AuditLog SET TableName = 'CustomInputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LoadOrder', OriginalValue = OLD.LoadOrder, NewValue = NEW.LoadOrder, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Enabled != NEW.Enabled THEN
			INSERT INTO AuditLog SET TableName = 'CustomInputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Enabled', OriginalValue = OLD.Enabled, NewValue = NEW.Enabled, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedBy != NEW.UpdatedBy THEN
			INSERT INTO AuditLog SET TableName = 'CustomInputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NEW.UpdatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedOn != NEW.UpdatedOn THEN
			INSERT INTO AuditLog SET TableName = 'CustomInputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NEW.UpdatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedBy != NEW.CreatedBy THEN
			INSERT INTO AuditLog SET TableName = 'CustomInputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NEW.CreatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedOn != NEW.CreatedOn THEN
			INSERT INTO AuditLog SET TableName = 'CustomInputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NEW.CreatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;

    END$$

CREATE TRIGGER CustomInputAdapter_AuditDelete AFTER DELETE ON CustomInputAdapter
    FOR EACH ROW BEGIN

		INSERT INTO AuditLog SET TableName = 'CustomInputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NodeID', OriginalValue = OLD.NodeID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomInputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AdapterName', OriginalValue = OLD.AdapterName, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomInputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AssemblyName', OriginalValue = OLD.AssemblyName, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomInputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'TypeName', OriginalValue = OLD.TypeName, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomInputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ConnectionString', OriginalValue = OLD.ConnectionString, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomInputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LoadOrder', OriginalValue = OLD.LoadOrder, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomInputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Enabled', OriginalValue = OLD.Enabled, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomInputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomInputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomInputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomInputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
	
    END$$

CREATE TRIGGER CustomOutputAdapter_AuditUpdate AFTER UPDATE ON CustomOutputAdapter
    FOR EACH ROW BEGIN

		IF OLD.NodeID != NEW.NodeID THEN
			INSERT INTO AuditLog SET TableName = 'CustomOutputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NodeID', OriginalValue = OLD.NodeID, NewValue = NEW.NodeID, UpdatedBy = NEW.UpdatedBy;
		END IF;

		IF OLD.AdapterName != NEW.AdapterName THEN
			INSERT INTO AuditLog SET TableName = 'CustomOutputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AdapterName', OriginalValue = OLD.AdapterName, NewValue = NEW.AdapterName, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.AssemblyName != NEW.AssemblyName THEN
			INSERT INTO AuditLog SET TableName = 'CustomOutputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AssemblyName', OriginalValue = OLD.AssemblyName, NewValue = NEW.AssemblyName, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.TypeName != NEW.TypeName THEN
			INSERT INTO AuditLog SET TableName = 'CustomOutputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'TypeName', OriginalValue = OLD.TypeName, NewValue = NEW.TypeName, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.ConnectionString != NEW.ConnectionString THEN
			INSERT INTO AuditLog SET TableName = 'CustomOutputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ConnectionString', OriginalValue = OLD.ConnectionString, NewValue = NEW.ConnectionString, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.LoadOrder != NEW.LoadOrder THEN
			INSERT INTO AuditLog SET TableName = 'CustomOutputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LoadOrder', OriginalValue = OLD.LoadOrder, NewValue = NEW.LoadOrder, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Enabled != NEW.Enabled THEN
			INSERT INTO AuditLog SET TableName = 'CustomOutputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Enabled', OriginalValue = OLD.Enabled, NewValue = NEW.Enabled, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedBy != NEW.UpdatedBy THEN
			INSERT INTO AuditLog SET TableName = 'CustomOutputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NEW.UpdatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedOn != NEW.UpdatedOn THEN
			INSERT INTO AuditLog SET TableName = 'CustomOutputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NEW.UpdatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedBy != NEW.CreatedBy THEN
			INSERT INTO AuditLog SET TableName = 'CustomOutputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NEW.CreatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedOn != NEW.CreatedOn THEN
			INSERT INTO AuditLog SET TableName = 'CustomOutputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NEW.CreatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;

    END$$

CREATE TRIGGER CustomOutputAdapter_AuditDelete AFTER DELETE ON CustomOutputAdapter
    FOR EACH ROW BEGIN

		INSERT INTO AuditLog SET TableName = 'CustomOutputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NodeID', OriginalValue = OLD.NodeID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomOutputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AdapterName', OriginalValue = OLD.AdapterName, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomOutputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AssemblyName', OriginalValue = OLD.AssemblyName, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomOutputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'TypeName', OriginalValue = OLD.TypeName, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomOutputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ConnectionString', OriginalValue = OLD.ConnectionString, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomOutputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LoadOrder', OriginalValue = OLD.LoadOrder, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomOutputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Enabled', OriginalValue = OLD.Enabled, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomOutputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomOutputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomOutputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'CustomOutputAdapter', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
	
    END$$

CREATE TRIGGER Device_AuditUpdate AFTER UPDATE ON Device
    FOR EACH ROW BEGIN

		IF OLD.NodeID != NEW.NodeID THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NodeID', OriginalValue = OLD.NodeID, NewValue = NEW.NodeID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.ParentID != NEW.ParentID THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ParentID', OriginalValue = OLD.ParentID, NewValue = NEW.ParentID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Acronym != NEW.Acronym THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Acronym', OriginalValue = OLD.Acronym, NewValue = NEW.Acronym, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Name != NEW.Name THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Name', OriginalValue = OLD.Name, NewValue = NEW.Name, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.IsConcentrator != NEW.IsConcentrator THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'IsConcentrator', OriginalValue = OLD.IsConcentrator, NewValue = NEW.IsConcentrator, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CompanyID != NEW.CompanyID THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CompanyID', OriginalValue = OLD.CompanyID, NewValue = NEW.CompanyID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.HistorianID != NEW.HistorianID THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'HistorianID', OriginalValue = OLD.HistorianID, NewValue = NEW.HistorianID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.AccessID != NEW.AccessID THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AccessID', OriginalValue = OLD.AccessID, NewValue = NEW.AccessID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.VendorDeviceID != NEW.VendorDeviceID THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'VendorDeviceID', OriginalValue = OLD.VendorDeviceID, NewValue = NEW.VendorDeviceID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.ProtocolID != NEW.ProtocolID THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ProtocolID', OriginalValue = OLD.ProtocolID, NewValue = NEW.ProtocolID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Longitude != NEW.Longitude THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Longitude', OriginalValue = OLD.Longitude, NewValue = NEW.Longitude, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Latitude != NEW.Latitude THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Latitude', OriginalValue = OLD.Latitude, NewValue = NEW.Latitude, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.InterconnectionID != NEW.InterconnectionID THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'InterconnectionID', OriginalValue = OLD.InterconnectionID, NewValue = NEW.InterconnectionID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.ConnectionString != NEW.ConnectionString THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ConnectionString', OriginalValue = OLD.ConnectionString, NewValue = NEW.ConnectionString, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.TimeZone != NEW.TimeZone THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'TimeZone', OriginalValue = OLD.TimeZone, NewValue = NEW.TimeZone, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.FramesPerSecond != NEW.FramesPerSecond THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'FramesPerSecond', OriginalValue = OLD.FramesPerSecond, NewValue = NEW.FramesPerSecond, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.TimeAdjustmentTicks != NEW.TimeAdjustmentTicks THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'TimeAdjustmentTicks', OriginalValue = OLD.TimeAdjustmentTicks, NewValue = NEW.TimeAdjustmentTicks, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.DataLossInterval != NEW.DataLossInterval THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'DataLossInterval', OriginalValue = OLD.DataLossInterval, NewValue = NEW.DataLossInterval, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.AllowedParsingExceptions != NEW.AllowedParsingExceptions THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AllowedParsingExceptions', OriginalValue = OLD.AllowedParsingExceptions, NewValue = NEW.AllowedParsingExceptions, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.ParsingExceptionWindow != NEW.ParsingExceptionWindow THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ParsingExceptionWindow', OriginalValue = OLD.ParsingExceptionWindow, NewValue = NEW.ParsingExceptionWindow, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.DelayedConnectionInterval != NEW.DelayedConnectionInterval THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'DelayedConnectionInterval', OriginalValue = OLD.DelayedConnectionInterval, NewValue = NEW.DelayedConnectionInterval, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.AllowUseOfCachedConfiguration != NEW.AllowUseOfCachedConfiguration THEN	
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AllowUseOfCachedConfiguration', OriginalValue = OLD.AllowUseOfCachedConfiguration, NewValue = NEW.AllowUseOfCachedConfiguration, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.AutoStartDataParsingSequence != NEW.AutoStartDataParsingSequence THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AutoStartDataParsingSequence', OriginalValue = OLD.AutoStartDataParsingSequence, NewValue = NEW.AutoStartDataParsingSequence, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.SkipDisableRealTimeData != NEW.SkipDisableRealTimeData THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'SkipDisableRealTimeData', OriginalValue = OLD.SkipDisableRealTimeData, NewValue = NEW.SkipDisableRealTimeData, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.MeasurementReportingInterval != NEW.MeasurementReportingInterval THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'MeasurementReportingInterval', OriginalValue = OLD.MeasurementReportingInterval, NewValue = NEW.MeasurementReportingInterval, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.ContactList != NEW.ContactList THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ContactList', OriginalValue = OLD.ContactList, NewValue = NEW.ContactList, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.MeasuredLines != NEW.MeasuredLines THEN	
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'MeasuredLines', OriginalValue = OLD.MeasuredLines, NewValue = NEW.MeasuredLines, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.LoadOrder != NEW.LoadOrder THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LoadOrder', OriginalValue = OLD.LoadOrder, NewValue = NEW.LoadOrder, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Enabled != NEW.Enabled THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Enabled', OriginalValue = OLD.Enabled, NewValue = NEW.Enabled, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedOn != NEW.CreatedOn THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NEW.CreatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedBy != NEW.CreatedBy THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NEW.CreatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedOn != NEW.UpdatedOn THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NEW.UpdatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedBy != NEW.UpdatedBy THEN
			INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NEW.UpdatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
    END$$

CREATE TRIGGER Device_AuditDelete AFTER DELETE ON Device
    FOR EACH ROW BEGIN

		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NodeID', OriginalValue = OLD.NodeID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ParentID', OriginalValue = OLD.ParentID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Acronym', OriginalValue = OLD.Acronym, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Name', OriginalValue = OLD.Name, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'IsConcentrator', OriginalValue = OLD.IsConcentrator, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CompanyID', OriginalValue = OLD.CompanyID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'HistorianID', OriginalValue = OLD.HistorianID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AccessID', OriginalValue = OLD.AccessID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'VendorDeviceID', OriginalValue = OLD.VendorDeviceID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ProtocolID', OriginalValue = OLD.ProtocolID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Longitude', OriginalValue = OLD.Longitude, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Latitude', OriginalValue = OLD.Latitude, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'InterconnectionID', OriginalValue = OLD.InterconnectionID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ConnectionString', OriginalValue = OLD.ConnectionString, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'TimeZone', OriginalValue = OLD.TimeZone, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'FramesPerSecond', OriginalValue = OLD.FramesPerSecond, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'TimeAdjustmentTicks', OriginalValue = OLD.TimeAdjustmentTicks, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'DataLossInterval', OriginalValue = OLD.DataLossInterval, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AllowedParsingExceptions', OriginalValue = OLD.AllowedParsingExceptions, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ParsingExceptionWindow', OriginalValue = OLD.ParsingExceptionWindow, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'DelayedConnectionInterval', OriginalValue = OLD.DelayedConnectionInterval, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AllowUseOfCachedConfiguration', OriginalValue = OLD.AllowUseOfCachedConfiguration, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AutoStartDataParsingSequence', OriginalValue = OLD.AutoStartDataParsingSequence, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'SkipDisableRealTimeData', OriginalValue = OLD.SkipDisableRealTimeData, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'MeasurementReportingInterval', OriginalValue = OLD.MeasurementReportingInterval, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ContactList', OriginalValue = OLD.ContactList, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'MeasuredLines', OriginalValue = OLD.MeasuredLines, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LoadOrder', OriginalValue = OLD.LoadOrder, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Enabled', OriginalValue = OLD.Enabled, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Device', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
	
    END$$

CREATE TRIGGER Historian_AuditUpdate AFTER UPDATE ON Historian
    FOR EACH ROW BEGIN

		IF OLD.NodeID != NEW.NodeID THEN	
			INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NodeID', OriginalValue = OLD.NodeID, NewValue = NEW.NodeID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Acronym != NEW.Acronym THEN
			INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Acronym', OriginalValue = OLD.Acronym, NewValue = NEW.Acronym, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Name != NEW.Name THEN
			INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Name', OriginalValue = OLD.Name, NewValue = NEW.Name, UpdatedBy = NEW.UpdatedBy;
		END IF;

		IF OLD.AssemblyName != NEW.AssemblyName THEN	
			INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AssemblyName', OriginalValue = OLD.AssemblyName, NewValue = NEW.AssemblyName, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.TypeName != NEW.TypeName THEN
			INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'TypeName', OriginalValue = OLD.TypeName, NewValue = NEW.TypeName, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.ConnectionString != NEW.ConnectionString THEN
			INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ConnectionString', OriginalValue = OLD.ConnectionString, NewValue = NEW.ConnectionString, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.IsLocal != NEW.IsLocal THEN	
			INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'IsLocal', OriginalValue = OLD.IsLocal, NewValue = NEW.IsLocal, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.MeasurementReportingInterval != NEW.MeasurementReportingInterval THEN
			INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'MeasurementReportingInterval', OriginalValue = OLD.MeasurementReportingInterval, NewValue = NEW.MeasurementReportingInterval, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Description != NEW.Description THEN
			INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Description', OriginalValue = OLD.Description, NewValue = NEW.Description, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.LoadOrder != NEW.LoadOrder THEN	
			INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LoadOrder', OriginalValue = OLD.LoadOrder, NewValue = NEW.LoadOrder, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Enabled != NEW.Enabled THEN
			INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Enabled', OriginalValue = OLD.Enabled, NewValue = NEW.Enabled, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedOn != NEW.CreatedOn THEN
			INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NEW.CreatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedBy != NEW.CreatedBy THEN
			INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NEW.CreatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedOn != NEW.UpdatedOn THEN
			INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NEW.UpdatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedBy != NEW.UpdatedBy THEN
			INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NEW.UpdatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;

    END$$

CREATE TRIGGER Historian_AuditDelete AFTER DELETE ON Historian
    FOR EACH ROW BEGIN

		INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NodeID', OriginalValue = OLD.NodeID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Acronym', OriginalValue = OLD.Acronym, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Name', OriginalValue = OLD.Name, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AssemblyName', OriginalValue = OLD.AssemblyName, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'TypeName', OriginalValue = OLD.TypeName, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ConnectionString', OriginalValue = OLD.ConnectionString, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'IsLocal', OriginalValue = OLD.IsLocal, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'MeasurementReportingInterval', OriginalValue = OLD.MeasurementReportingInterval, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Description', OriginalValue = OLD.Description, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LoadOrder', OriginalValue = OLD.LoadOrder, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Enabled', OriginalValue = OLD.Enabled, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Historian', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
	
    END$$

CREATE TRIGGER Measurement_AuditUpdate AFTER UPDATE ON Measurement
    FOR EACH ROW BEGIN

		IF OLD.HistorianID != NEW.HistorianID THEN
			INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'HistorianID', OriginalValue = OLD.HistorianID, NewValue = NEW.HistorianID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.PointID != NEW.PointID THEN
			INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'PointID', OriginalValue = OLD.PointID, NewValue = NEW.PointID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.DeviceID != NEW.DeviceID THEN
			INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'DeviceID', OriginalValue = OLD.DeviceID, NewValue = NEW.DeviceID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.PointTag != NEW.PointTag THEN
			INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'PointTag', OriginalValue = OLD.PointTag, NewValue = NEW.PointTag, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.AlternateTag != NEW.AlternateTag THEN
			INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'AlternateTag', OriginalValue = OLD.AlternateTag, NewValue = NEW.AlternateTag, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.SignalTypeID != NEW.SignalTypeID THEN
			INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'SignalTypeID', OriginalValue = OLD.SignalTypeID, NewValue = NEW.SignalTypeID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.PhasorSourceIndex != NEW.PhasorSourceIndex THEN
			INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'PhasorSourceIndex', OriginalValue = OLD.PhasorSourceIndex, NewValue = NEW.PhasorSourceIndex, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.SignalReference != NEW.SignalReference THEN
			INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'SignalReference', OriginalValue = OLD.SignalReference, NewValue = NEW.SignalReference, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Adder != NEW.Adder THEN
			INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'Adder', OriginalValue = OLD.Adder, NewValue = NEW.Adder, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Multiplier != NEW.Multiplier THEN
			INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'Multiplier', OriginalValue = OLD.Multiplier, NewValue = NEW.Multiplier, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Description != NEW.Description THEN
			INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'Description', OriginalValue = OLD.Description, NewValue = NEW.Description, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Enabled != NEW.Enabled THEN
			INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'Enabled', OriginalValue = OLD.Enabled, NewValue = NEW.Enabled, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedOn != NEW.CreatedOn THEN
			INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NEW.CreatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedBy != NEW.CreatedBy THEN
			INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NEW.CreatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedOn != NEW.UpdatedOn THEN
			INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NEW.UpdatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedBy != NEW.UpdatedBy THEN
			INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NEW.UpdatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;

    END$$

CREATE TRIGGER Measurement_AuditDelete AFTER DELETE ON Measurement
    FOR EACH ROW BEGIN

		INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'HistorianID', OriginalValue = OLD.HistorianID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'PointID', OriginalValue = OLD.PointID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'DeviceID', OriginalValue = OLD.DeviceID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'PointTag', OriginalValue = OLD.PointTag, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'AlternateTag', OriginalValue = OLD.AlternateTag, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'SignalTypeID', OriginalValue = OLD.SignalTypeID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'PhasorSourceIndex', OriginalValue = OLD.PhasorSourceIndex, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'SignalReference', OriginalValue = OLD.SignalReference, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'Adder', OriginalValue = OLD.Adder, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'Multiplier', OriginalValue = OLD.Multiplier, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'Description', OriginalValue = OLD.Description, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'Enabled', OriginalValue = OLD.Enabled, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Measurement', PrimaryKeyColumn = 'SignalID', PrimaryKeyValue = OLD.SignalID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
	
    END$$

CREATE TRIGGER Node_AuditUpdate AFTER UPDATE ON Node
    FOR EACH ROW BEGIN

		IF OLD.Name != NEW.Name THEN
			INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Name', OriginalValue = OLD.Name, NewValue = NEW.Name, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CompanyID != NEW.CompanyID THEN
			INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CompanyID', OriginalValue = OLD.CompanyID, NewValue = NEW.CompanyID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Longitude != NEW.Longitude THEN
			INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Longitude', OriginalValue = OLD.Longitude, NewValue = NEW.Longitude, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Latitude != NEW.Latitude THEN
			INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Latitude', OriginalValue = OLD.Latitude, NewValue = NEW.Latitude, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Description != NEW.Description THEN
			INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Description', OriginalValue = OLD.Description, NewValue = NEW.Description, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.ImagePath != NEW.ImagePath THEN
			INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ImagePath', OriginalValue = OLD.ImagePath, NewValue = NEW.ImagePath, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.TimeSeriesDataServiceUrl != NEW.TimeSeriesDataServiceUrl THEN
			INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'TimeSeriesDataServiceUrl', OriginalValue = OLD.TimeSeriesDataServiceUrl, NewValue = NEW.TimeSeriesDataServiceUrl, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.RemoteStatusServiceUrl != NEW.RemoteStatusServiceUrl THEN
			INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'RemoteStatusServiceUrl', OriginalValue = OLD.RemoteStatusServiceUrl, NewValue = NEW.RemoteStatusServiceUrl, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.RealTimeStatisticServiceUrl != NEW.RealTimeStatisticServiceUrl THEN
			INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'RealTimeStatisticServiceUrl', OriginalValue = OLD.RealTimeStatisticServiceUrl, NewValue = NEW.RealTimeStatisticServiceUrl, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Master != NEW.Master THEN
			INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Master', OriginalValue = OLD.Master, NewValue = NEW.Master, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.LoadOrder != NEW.LoadOrder THEN
			INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LoadOrder', OriginalValue = OLD.LoadOrder, NewValue = NEW.LoadOrder, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Enabled != NEW.Enabled THEN
			INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Enabled', OriginalValue = OLD.Enabled, NewValue = NEW.Enabled, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedOn != NEW.CreatedOn THEN
			INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NEW.CreatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedBy != NEW.CreatedBy THEN
			INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NEW.CreatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedOn != NEW.UpdatedOn THEN
			INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NEW.UpdatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedBy != NEW.UpdatedBy THEN
			INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NEW.UpdatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;

    END$$

CREATE TRIGGER Node_AuditDelete AFTER DELETE ON Node
    FOR EACH ROW BEGIN

		INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Name', OriginalValue = OLD.Name, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CompanyID', OriginalValue = OLD.CompanyID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Longitude', OriginalValue = OLD.Longitude, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Latitude', OriginalValue = OLD.Latitude, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Description', OriginalValue = OLD.Description, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ImagePath', OriginalValue = OLD.ImagePath, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'TimeSeriesDataServiceUrl', OriginalValue = OLD.TimeSeriesDataServiceUrl, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'RemoteStatusServiceUrl', OriginalValue = OLD.RemoteStatusServiceUrl, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'RealTimeStatisticServiceUrl', OriginalValue = OLD.RealTimeStatisticServiceUrl, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Master', OriginalValue = OLD.Master, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LoadOrder', OriginalValue = OLD.LoadOrder, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Enabled', OriginalValue = OLD.Enabled, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Node', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
	
    END$$

CREATE TRIGGER OtherDevice_AuditUpdate AFTER UPDATE ON OtherDevice
    FOR EACH ROW BEGIN

		IF OLD.Acronym != NEW.Acronym THEN
			INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Acronym', OriginalValue = OLD.Acronym, NewValue = NEW.Acronym, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Name != NEW.Name THEN
			INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Name', OriginalValue = OLD.Name, NewValue = NEW.Name, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.IsConcentrator != NEW.IsConcentrator THEN
			INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'IsConcentrator', OriginalValue = OLD.IsConcentrator, NewValue = NEW.IsConcentrator, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CompanyID != NEW.CompanyID THEN
			INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CompanyID', OriginalValue = OLD.CompanyID, NewValue = NEW.CompanyID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.VendorDeviceID != NEW.VendorDeviceID THEN
			INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'VendorDeviceID', OriginalValue = OLD.VendorDeviceID, NewValue = NEW.VendorDeviceID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Longitude != NEW.Longitude THEN
			INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Longitude', OriginalValue = OLD.Longitude, NewValue = NEW.Longitude, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Latitude != NEW.Latitude THEN
			INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Latitude', OriginalValue = OLD.Latitude, NewValue = NEW.Latitude, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.InterconnectionID != NEW.InterconnectionID THEN
			INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'InterconnectionID', OriginalValue = OLD.InterconnectionID, NewValue = NEW.InterconnectionID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Planned != NEW.Planned THEN
			INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Planned', OriginalValue = OLD.Planned, NewValue = NEW.Planned, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Desired != NEW.Desired THEN
			INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Desired', OriginalValue = OLD.Desired, NewValue = NEW.Desired, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.InProgress != NEW.InProgress THEN
			INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'InProgress', OriginalValue = OLD.InProgress, NewValue = NEW.InProgress, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedOn != NEW.CreatedOn THEN
			INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NEW.CreatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedBy != NEW.CreatedBy THEN
			INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NEW.CreatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedOn != NEW.UpdatedOn THEN
			INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NEW.UpdatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedBy != NEW.UpdatedBy THEN
			INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NEW.UpdatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;

    END$$

CREATE TRIGGER OtherDevice_AuditDelete AFTER DELETE ON OtherDevice
    FOR EACH ROW BEGIN

		INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Acronym', OriginalValue = OLD.Acronym, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Name', OriginalValue = OLD.Name, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'IsConcentrator', OriginalValue = OLD.IsConcentrator, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CompanyID', OriginalValue = OLD.CompanyID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'VendorDeviceID', OriginalValue = OLD.VendorDeviceID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Longitude', OriginalValue = OLD.Longitude, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Latitude', OriginalValue = OLD.Latitude, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'InterconnectionID', OriginalValue = OLD.InterconnectionID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Planned', OriginalValue = OLD.Planned, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Desired', OriginalValue = OLD.Desired, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'InProgress', OriginalValue = OLD.InProgress, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OtherDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
	
    END$$

CREATE TRIGGER OutputStream_AuditUpdate AFTER UPDATE ON OutputStream
    FOR EACH ROW BEGIN

		IF OLD.NodeID != NEW.NodeID THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NodeID', OriginalValue = OLD.NodeID, NewValue = NEW.NodeID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Acronym != NEW.Acronym THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Acronym', OriginalValue = OLD.Acronym, NewValue = NEW.Acronym, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Name != NEW.Name THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Name', OriginalValue = OLD.Name, NewValue = NEW.Name, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Type != NEW.Type THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Type', OriginalValue = OLD.Type, NewValue = NEW.Type, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.ConnectionString != NEW.ConnectionString THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ConnectionString', OriginalValue = OLD.ConnectionString, NewValue = NEW.ConnectionString, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.DataChannel != NEW.DataChannel THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'DataChannel', OriginalValue = OLD.DataChannel, NewValue = NEW.DataChannel, UpdatedBy = NEW.UpdatedBy;
		END IF;
		IF OLD.CommandChannel != NEW.CommandChannel THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CommandChannel', OriginalValue = OLD.CommandChannel, NewValue = NEW.CommandChannel, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.IDCode != NEW.IDCode THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'IDCode', OriginalValue = OLD.IDCode, NewValue = NEW.IDCode, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.AutoPublishConfigFrame != NEW.AutoPublishConfigFrame THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AutoPublishConfigFrame', OriginalValue = OLD.AutoPublishConfigFrame, NewValue = NEW.AutoPublishConfigFrame, UpdatedBy = NEW.UpdatedBy;
		END IF;
		IF OLD.AutoStartDataChannel != NEW.AutoStartDataChannel THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AutoStartDataChannel', OriginalValue = OLD.AutoStartDataChannel, NewValue = NEW.AutoStartDataChannel, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.NominalFrequency != NEW.NominalFrequency THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NominalFrequency', OriginalValue = OLD.NominalFrequency, NewValue = NEW.NominalFrequency, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.FramesPerSecond != NEW.FramesPerSecond THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'FramesPerSecond', OriginalValue = OLD.FramesPerSecond, NewValue = NEW.FramesPerSecond, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.LagTime != NEW.LagTime THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LagTime', OriginalValue = OLD.LagTime, NewValue = NEW.LagTime, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.LeadTime != NEW.LeadTime THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LeadTime', OriginalValue = OLD.LeadTime, NewValue = NEW.LeadTime, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UseLocalClockAsRealTime != NEW.UseLocalClockAsRealTime THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UseLocalClockAsRealTime', OriginalValue = OLD.UseLocalClockAsRealTime, NewValue = NEW.UseLocalClockAsRealTime, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.AllowSortsByArrival != NEW.AllowSortsByArrival THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AllowSortsByArrival', OriginalValue = OLD.AllowSortsByArrival, NewValue = NEW.AllowSortsByArrival, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.IgnoreBadTimestamps != NEW.IgnoreBadTimestamps THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'IgnoreBadTimestamps', OriginalValue = OLD.IgnoreBadTimestamps, NewValue = NEW.IgnoreBadTimestamps, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.TimeResolution != NEW.TimeResolution THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'TimeResolution', OriginalValue = OLD.TimeResolution, NewValue = NEW.TimeResolution, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.AllowPreemptivePublishing != NEW.AllowPreemptivePublishing THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AllowPreemptivePublishing', OriginalValue = OLD.AllowPreemptivePublishing, NewValue = NEW.AllowPreemptivePublishing, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.PerformTimestampReasonabilityCheck != NEW.PerformTimestampReasonabilityCheck THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'PerformTimestampReasonabilityCheck', OriginalValue = OLD.PerformTimestampReasonabilityCheck, NewValue = NEW.PerformTimestampReasonabilityCheck, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.DownsamplingMethod != NEW.DownsamplingMethod THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'DownsamplingMethod', OriginalValue = OLD.DownsamplingMethod, NewValue = NEW.DownsamplingMethod, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.DataFormat != NEW.DataFormat THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'DataFormat', OriginalValue = OLD.DataFormat, NewValue = NEW.DataFormat, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CoordinateFormat != NEW.CoordinateFormat THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CoordinateFormat', OriginalValue = OLD.CoordinateFormat, NewValue = NEW.CoordinateFormat, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CurrentScalingValue != NEW.CurrentScalingValue THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CurrentScalingValue', OriginalValue = OLD.CurrentScalingValue, NewValue = NEW.CurrentScalingValue, UpdatedBy = NEW.UpdatedBy;
		END IF;
		IF OLD.VoltageScalingValue != NEW.VoltageScalingValue THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'VoltageScalingValue', OriginalValue = OLD.VoltageScalingValue, NewValue = NEW.VoltageScalingValue, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.AnalogScalingValue != NEW.AnalogScalingValue THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AnalogScalingValue', OriginalValue = OLD.AnalogScalingValue, NewValue = NEW.AnalogScalingValue, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.DigitalMaskValue != NEW.DigitalMaskValue THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'DigitalMaskValue', OriginalValue = OLD.DigitalMaskValue, NewValue = NEW.DigitalMaskValue, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.LoadOrder != NEW.LoadOrder THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LoadOrder', OriginalValue = OLD.LoadOrder, NewValue = NEW.LoadOrder, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Enabled != NEW.Enabled THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Enabled', OriginalValue = OLD.Enabled, NewValue = NEW.Enabled, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedOn != NEW.CreatedOn THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NEW.CreatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
		IF OLD.CreatedBy != NEW.CreatedBy THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NEW.CreatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedOn != NEW.UpdatedOn THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NEW.UpdatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedBy != NEW.UpdatedBy THEN
			INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NEW.UpdatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;	

    END$$

CREATE TRIGGER OutputStream_AuditDelete AFTER DELETE ON OutputStream
    FOR EACH ROW BEGIN

		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NodeID', OriginalValue = OLD.NodeID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Acronym', OriginalValue = OLD.Acronym, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Name', OriginalValue = OLD.Name, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Type', OriginalValue = OLD.Type, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ConnectionString', OriginalValue = OLD.ConnectionString, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'DataChannel', OriginalValue = OLD.DataChannel, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CommandChannel', OriginalValue = OLD.CommandChannel, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'IDCode', OriginalValue = OLD.IDCode, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AutoPublishConfigFrame', OriginalValue = OLD.AutoPublishConfigFrame, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AutoStartDataChannel', OriginalValue = OLD.AutoStartDataChannel, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NominalFrequency', OriginalValue = OLD.NominalFrequency, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'FramesPerSecond', OriginalValue = OLD.FramesPerSecond, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LagTime', OriginalValue = OLD.LagTime, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LeadTime', OriginalValue = OLD.LeadTime, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UseLocalClockAsRealTime', OriginalValue = OLD.UseLocalClockAsRealTime, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AllowSortsByArrival', OriginalValue = OLD.AllowSortsByArrival, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'IgnoreBadTimestamps', OriginalValue = OLD.IgnoreBadTimestamps, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'TimeResolution', OriginalValue = OLD.TimeResolution, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AllowPreemptivePublishing', OriginalValue = OLD.AllowPreemptivePublishing, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'PerformTimestampReasonabilityCheck', OriginalValue = OLD.PerformTimestampReasonabilityCheck, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'DownsamplingMethod', OriginalValue = OLD.DownsamplingMethod, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'DataFormat', OriginalValue = OLD.DataFormat, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CoordinateFormat', OriginalValue = OLD.CoordinateFormat, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CurrentScalingValue', OriginalValue = OLD.CurrentScalingValue, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'VoltageScalingValue', OriginalValue = OLD.VoltageScalingValue, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AnalogScalingValue', OriginalValue = OLD.AnalogScalingValue, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'DigitalMaskValue', OriginalValue = OLD.DigitalMaskValue, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LoadOrder', OriginalValue = OLD.LoadOrder, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Enabled', OriginalValue = OLD.Enabled, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStream', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
	
    END$$

CREATE TRIGGER OutputStreamDevice_AuditUpdate AFTER UPDATE ON OutputStreamDevice
    FOR EACH ROW BEGIN
    
		IF OLD.NodeID != NEW.NodeID THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NodeID', OriginalValue = OLD.NodeID, NewValue = NEW.NodeID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.AdapterID != NEW.AdapterID THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AdapterID', OriginalValue = OLD.AdapterID, NewValue = NEW.AdapterID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.IDCode != NEW.IDCode THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'IDCode', OriginalValue = OLD.IDCode, NewValue = NEW.IDCode, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Acronym != NEW.Acronym THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Acronym', OriginalValue = OLD.Acronym, NewValue = NEW.Acronym, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.BpaAcronym != NEW.BpaAcronym THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'BpaAcronym', OriginalValue = OLD.BpaAcronym, NewValue = NEW.BpaAcronym, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Name != NEW.Name THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Name', OriginalValue = OLD.Name, NewValue = NEW.Name, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.PhasorDataFormat != NEW.PhasorDataFormat THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'PhasorDataFormat', OriginalValue = OLD.PhasorDataFormat, NewValue = NEW.PhasorDataFormat, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.FrequencyDataFormat != NEW.FrequencyDataFormat THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'FrequencyDataFormat', OriginalValue = OLD.FrequencyDataFormat, NewValue = NEW.FrequencyDataFormat, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.AnalogDataFormat != NEW.AnalogDataFormat THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AnalogDataFormat', OriginalValue = OLD.AnalogDataFormat, NewValue = NEW.AnalogDataFormat, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CoordinateFormat != NEW.CoordinateFormat THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CoordinateFormat', OriginalValue = OLD.CoordinateFormat, NewValue = NEW.CoordinateFormat, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.LoadOrder != NEW.LoadOrder THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LoadOrder', OriginalValue = OLD.LoadOrder, NewValue = NEW.LoadOrder, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Enabled != NEW.Enabled THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Enabled', OriginalValue = OLD.Enabled, NewValue = NEW.Enabled, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedOn != NEW.CreatedOn THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NEW.CreatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedBy != NEW.CreatedBy THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NEW.CreatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedOn != NEW.UpdatedOn THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NEW.UpdatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedBy != NEW.UpdatedBy THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NEW.UpdatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;

    END$$

CREATE TRIGGER OutputStreamDevice_AuditDelete AFTER DELETE ON OutputStreamDevice
    FOR EACH ROW BEGIN
    
		INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NodeID', OriginalValue = OLD.NodeID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AdapterID', OriginalValue = OLD.AdapterID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'IDCode', OriginalValue = OLD.IDCode, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Acronym', OriginalValue = OLD.Acronym, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'BpaAcronym', OriginalValue = OLD.BpaAcronym, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Name', OriginalValue = OLD.Name, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'PhasorDataFormat', OriginalValue = OLD.PhasorDataFormat, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'FrequencyDataFormat', OriginalValue = OLD.FrequencyDataFormat, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AnalogDataFormat', OriginalValue = OLD.AnalogDataFormat, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CoordinateFormat', OriginalValue = OLD.CoordinateFormat, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LoadOrder', OriginalValue = OLD.LoadOrder, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Enabled', OriginalValue = OLD.Enabled, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
	
    END$$

CREATE TRIGGER OutputStreamDeviceAnalog_AuditUpdate AFTER UPDATE ON OutputStreamDeviceAnalog
    FOR EACH ROW BEGIN
    
		IF OLD.NodeID != NEW.NodeID THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceAnalog', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NodeID', OriginalValue = OLD.NodeID, NewValue = NEW.NodeID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.OutputStreamDeviceID != NEW.OutputStreamDeviceID THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceAnalog', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'OutputStreamDeviceID', OriginalValue = OLD.OutputStreamDeviceID, NewValue = NEW.OutputStreamDeviceID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Label != NEW.Label THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceAnalog', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Label', OriginalValue = OLD.Label, NewValue = NEW.Label, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Type != NEW.Type THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceAnalog', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Type', OriginalValue = OLD.Type, NewValue = NEW.Type, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.ScalingValue != NEW.ScalingValue THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceAnalog', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ScalingValue', OriginalValue = OLD.ScalingValue, NewValue = NEW.ScalingValue, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.LoadOrder != NEW.LoadOrder THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceAnalog', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LoadOrder', OriginalValue = OLD.LoadOrder, NewValue = NEW.LoadOrder, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedOn != NEW.CreatedOn THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceAnalog', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NEW.CreatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedBy != NEW.CreatedBy THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceAnalog', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NEW.CreatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedOn != NEW.UpdatedOn THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceAnalog', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NEW.UpdatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedBy != NEW.UpdatedBy THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceAnalog', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NEW.UpdatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;

    END$$

CREATE TRIGGER OutputStreamDeviceAnalog_AuditDelete AFTER DELETE ON OutputStreamDeviceAnalog
    FOR EACH ROW BEGIN
    
		INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceAnalog', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NodeID', OriginalValue = OLD.NodeID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceAnalog', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'OutputStreamDeviceID', OriginalValue = OLD.OutputStreamDeviceID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceAnalog', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Label', OriginalValue = OLD.Label, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceAnalog', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Type', OriginalValue = OLD.Type, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceAnalog', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ScalingValue', OriginalValue = OLD.ScalingValue, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceAnalog', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LoadOrder', OriginalValue = OLD.LoadOrder, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceAnalog', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceAnalog', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceAnalog', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceAnalog', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;

    END$$

CREATE TRIGGER OutputStreamDeviceDigital_AuditUpdate AFTER UPDATE ON OutputStreamDeviceDigital
    FOR EACH ROW BEGIN

		IF OLD.NodeID != NEW.NodeID THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceDigital', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NodeID', OriginalValue = OLD.NodeID, NewValue = NEW.NodeID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.OutputStreamDeviceID != NEW.OutputStreamDeviceID THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceDigital', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'OutputStreamDeviceID', OriginalValue = OLD.OutputStreamDeviceID, NewValue = NEW.OutputStreamDeviceID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Label != NEW.Label THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceDigital', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Label', OriginalValue = OLD.Label, NewValue = NEW.Label, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.MaskValue != NEW.MaskValue THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceDigital', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'MaskValue', OriginalValue = OLD.MaskValue, NewValue = NEW.MaskValue, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.LoadOrder != NEW.LoadOrder THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceDigital', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LoadOrder', OriginalValue = OLD.LoadOrder, NewValue = NEW.LoadOrder, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedOn != NEW.CreatedOn THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceDigital', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NEW.CreatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedBy != NEW.CreatedBy THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceDigital', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NEW.CreatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedOn != NEW.UpdatedOn THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceDigital', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NEW.UpdatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedBy != NEW.UpdatedBy THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceDigital', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NEW.UpdatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;

    END$$

CREATE TRIGGER OutputStreamDeviceDigital_AuditDelete AFTER DELETE ON OutputStreamDeviceDigital
    FOR EACH ROW BEGIN

		INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceDigital', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NodeID', OriginalValue = OLD.NodeID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceDigital', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'OutputStreamDeviceID', OriginalValue = OLD.OutputStreamDeviceID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceDigital', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Label', OriginalValue = OLD.Label, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceDigital', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'MaskValue', OriginalValue = OLD.MaskValue, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceDigital', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LoadOrder', OriginalValue = OLD.LoadOrder, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceDigital', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceDigital', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceDigital', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDeviceDigital', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
	
    END$$

CREATE TRIGGER OutputStreamDevicePhasor_AuditUpdate AFTER UPDATE ON OutputStreamDevicePhasor
    FOR EACH ROW BEGIN

		IF OLD.NodeID != NEW.NodeID THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevicePhasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NodeID', OriginalValue = OLD.NodeID, NewValue = NEW.NodeID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.OutputStreamDeviceID != NEW.OutputStreamDeviceID THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevicePhasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'OutputStreamDeviceID', OriginalValue = OLD.OutputStreamDeviceID, NewValue = NEW.OutputStreamDeviceID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Label != NEW.Label THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevicePhasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Label', OriginalValue = OLD.Label, NewValue = NEW.Label, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Type != NEW.Type THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevicePhasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Type', OriginalValue = OLD.Type, NewValue = NEW.Type, UpdatedBy = NEW.UpdatedBy;
		END IF;
		
		IF OLD.Phase != NEW.Phase THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevicePhasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Phase', OriginalValue = OLD.Phase, NewValue = NEW.Phase, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.ScalingValue != NEW.ScalingValue THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevicePhasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ScalingValue', OriginalValue = OLD.ScalingValue, NewValue = NEW.ScalingValue, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.LoadOrder != NEW.LoadOrder THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevicePhasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LoadOrder', OriginalValue = OLD.LoadOrder, NewValue = NEW.LoadOrder, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedOn != NEW.CreatedOn THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevicePhasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NEW.CreatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedBy != NEW.CreatedBy THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevicePhasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NEW.CreatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedOn != NEW.UpdatedOn THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevicePhasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NEW.UpdatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedBy != NEW.UpdatedBy THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamDevicePhasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NEW.UpdatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;

    END$$

CREATE TRIGGER OutputStreamDevicePhasor_AuditDelete AFTER DELETE ON OutputStreamDevicePhasor
    FOR EACH ROW BEGIN

		INSERT INTO AuditLog SET TableName = 'OutputStreamDevicePhasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NodeID', OriginalValue = OLD.NodeID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDevicePhasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'OutputStreamDeviceID', OriginalValue = OLD.OutputStreamDeviceID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDevicePhasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Label', OriginalValue = OLD.Label, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDevicePhasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Type', OriginalValue = OLD.Type, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDevicePhasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Phase', OriginalValue = OLD.Phase, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDevicePhasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ScalingValue', OriginalValue = OLD.ScalingValue, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDevicePhasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'LoadOrder', OriginalValue = OLD.LoadOrder, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDevicePhasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDevicePhasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDevicePhasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamDevicePhasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
	
    END$$

CREATE TRIGGER OutputStreamMeasurement_AuditUpdate AFTER UPDATE ON OutputStreamMeasurement
    FOR EACH ROW BEGIN
    
		IF OLD.NodeID != NEW.NodeID THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NodeID', OriginalValue = OLD.NodeID, NewValue = NEW.NodeID, UpdatedBy = NEW.UpdatedBy;
		END IF;

		IF OLD.AdapterID != NEW.AdapterID THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AdapterID', OriginalValue = OLD.AdapterID, NewValue = NEW.AdapterID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.HistorianID != NEW.HistorianID THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'HistorianID', OriginalValue = OLD.HistorianID, NewValue = NEW.HistorianID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.PointID != NEW.PointID THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'PointID', OriginalValue = OLD.PointID, NewValue = NEW.PointID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.SignalReference != NEW.SignalReference THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'SignalReference', OriginalValue = OLD.SignalReference, NewValue = NEW.SignalReference, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedOn != NEW.CreatedOn THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NEW.CreatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedBy != NEW.CreatedBy THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NEW.CreatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedOn != NEW.UpdatedOn THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NEW.UpdatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedBy != NEW.UpdatedBy THEN
			INSERT INTO AuditLog SET TableName = 'OutputStreamMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NEW.UpdatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
		
    END$$

CREATE TRIGGER OutputStreamMeasurement_AuditDelete AFTER DELETE ON OutputStreamMeasurement
    FOR EACH ROW BEGIN
    
		INSERT INTO AuditLog SET TableName = 'OutputStreamMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'NodeID', OriginalValue = OLD.NodeID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'AdapterID', OriginalValue = OLD.AdapterID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'HistorianID', OriginalValue = OLD.HistorianID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'PointID', OriginalValue = OLD.PointID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'SignalReference', OriginalValue = OLD.SignalReference, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'OutputStreamMeasurement', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		
    END$$

CREATE TRIGGER Phasor_AuditUpdate AFTER UPDATE ON Phasor 
    FOR EACH ROW BEGIN

		IF OLD.DeviceID != NEW.DeviceID THEN
			INSERT INTO AuditLog SET TableName = 'Phasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'DeviceID', OriginalValue = OLD.DeviceID, NewValue = NEW.DeviceID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Label != NEW.Label THEN
			INSERT INTO AuditLog SET TableName = 'Phasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Label', OriginalValue = OLD.Label, NewValue = NEW.Label, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Type != NEW.Type THEN
			INSERT INTO AuditLog SET TableName = 'Phasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Type', OriginalValue = OLD.Type, NewValue = NEW.Type, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Phase != NEW.Phase THEN
			INSERT INTO AuditLog SET TableName = 'Phasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Phase', OriginalValue = OLD.Phase, NewValue = NEW.Phase, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.DestinationPhasorID != NEW.DestinationPhasorID THEN
			INSERT INTO AuditLog SET TableName = 'Phasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'DestinationPhasorID', OriginalValue = OLD.DestinationPhasorID, NewValue = NEW.DestinationPhasorID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.SourceIndex != NEW.SourceIndex THEN
			INSERT INTO AuditLog SET TableName = 'Phasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'SourceIndex', OriginalValue = OLD.SourceIndex, NewValue = NEW.SourceIndex, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedOn != NEW.CreatedOn THEN
			INSERT INTO AuditLog SET TableName = 'Phasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NEW.CreatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedBy != NEW.CreatedBy THEN
			INSERT INTO AuditLog SET TableName = 'Phasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NEW.CreatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedOn != NEW.UpdatedOn THEN
			INSERT INTO AuditLog SET TableName = 'Phasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NEW.UpdatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedBy != NEW.UpdatedBy THEN
			INSERT INTO AuditLog SET TableName = 'Phasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NEW.UpdatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
    END$$

CREATE TRIGGER Phasor_AuditDelete AFTER DELETE ON Phasor
    FOR EACH ROW BEGIN

		INSERT INTO AuditLog SET TableName = 'Phasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'DeviceID', OriginalValue = OLD.DeviceID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Phasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Label', OriginalValue = OLD.Label, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Phasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Type', OriginalValue = OLD.Type, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Phasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Phase', OriginalValue = OLD.Phase, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Phasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'DestinationPhasorID', OriginalValue = OLD.DestinationPhasorID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Phasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'SourceIndex', OriginalValue = OLD.SourceIndex, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Phasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Phasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Phasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Phasor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
	
    END$$

CREATE TRIGGER Vendor_AuditUpdate AFTER UPDATE ON Vendor
    FOR EACH ROW BEGIN

		IF OLD.Acronym != NEW.Acronym THEN
			INSERT INTO AuditLog SET TableName = 'Vendor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Acronym', OriginalValue = OLD.Acronym, NewValue = NEW.Acronym, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Name != NEW.Name THEN
			INSERT INTO AuditLog SET TableName = 'Vendor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Name', OriginalValue = OLD.Name, NewValue = NEW.Name, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.PhoneNumber != NEW.PhoneNumber THEN
			INSERT INTO AuditLog SET TableName = 'Vendor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'PhoneNumber', OriginalValue = OLD.PhoneNumber, NewValue = NEW.PhoneNumber, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.ContactEmail != NEW.ContactEmail THEN
			INSERT INTO AuditLog SET TableName = 'Vendor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ContactEmail', OriginalValue = OLD.ContactEmail, NewValue = NEW.ContactEmail, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Url != NEW.Url THEN
			INSERT INTO AuditLog SET TableName = 'Vendor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Url', OriginalValue = OLD.Url, NewValue = NEW.Url, UpdatedBy = NEW.UpdatedBy;
		END IF;

		IF OLD.CreatedOn != NEW.CreatedOn THEN
			INSERT INTO AuditLog SET TableName = 'Vendor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NEW.CreatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedBy != NEW.CreatedBy THEN
			INSERT INTO AuditLog SET TableName = 'Vendor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NEW.CreatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedOn != NEW.UpdatedOn THEN
			INSERT INTO AuditLog SET TableName = 'Vendor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NEW.UpdatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedBy != NEW.UpdatedBy THEN
			INSERT INTO AuditLog SET TableName = 'Vendor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NEW.UpdatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;

    END$$

CREATE TRIGGER Vendor_AuditDelete AFTER DELETE ON Vendor
    FOR EACH ROW BEGIN

		INSERT INTO AuditLog SET TableName = 'Vendor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Acronym', OriginalValue = OLD.Acronym, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Vendor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Name', OriginalValue = OLD.Name, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Vendor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'PhoneNumber', OriginalValue = OLD.PhoneNumber, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Vendor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'ContactEmail', OriginalValue = OLD.ContactEmail, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Vendor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Url', OriginalValue = OLD.Url, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Vendor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Vendor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Vendor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'Vendor', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
	
    END$$

CREATE TRIGGER VendorDevice_AuditUpdate AFTER UPDATE ON VendorDevice
    FOR EACH ROW BEGIN

		IF OLD.VendorID != NEW.VendorID THEN
			INSERT INTO AuditLog SET TableName = 'VendorDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'VendorID', OriginalValue = OLD.VendorID, NewValue = NEW.VendorID, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Name != NEW.Name THEN
			INSERT INTO AuditLog SET TableName = 'VendorDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Name', OriginalValue = OLD.Name, NewValue = NEW.Name, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Description != NEW.Description THEN
			INSERT INTO AuditLog SET TableName = 'VendorDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Description', OriginalValue = OLD.Description, NewValue = NEW.Description, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.Url != NEW.Url THEN
			INSERT INTO AuditLog SET TableName = 'VendorDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Url', OriginalValue = OLD.Url, NewValue = NEW.Url, UpdatedBy = NEW.UpdatedBy;
		END IF;

		IF OLD.CreatedOn != NEW.CreatedOn THEN
			INSERT INTO AuditLog SET TableName = 'VendorDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NEW.CreatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.CreatedBy != NEW.CreatedBy THEN
			INSERT INTO AuditLog SET TableName = 'VendorDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NEW.CreatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedOn != NEW.UpdatedOn THEN
			INSERT INTO AuditLog SET TableName = 'VendorDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NEW.UpdatedOn, UpdatedBy = NEW.UpdatedBy;
		END IF;
	
		IF OLD.UpdatedBy != NEW.UpdatedBy THEN
			INSERT INTO AuditLog SET TableName = 'VendorDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NEW.UpdatedBy, UpdatedBy = NEW.UpdatedBy;
		END IF;

    END$$

CREATE TRIGGER VendorDevice_AuditDelete AFTER DELETE ON VendorDevice
    FOR EACH ROW BEGIN

		INSERT INTO AuditLog SET TableName = 'VendorDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'VendorID', OriginalValue = OLD.VendorID, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'VendorDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Name', OriginalValue = OLD.Name, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'VendorDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Description', OriginalValue = OLD.Description, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'VendorDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'Url', OriginalValue = OLD.Url, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'VendorDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedOn', OriginalValue = OLD.CreatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'VendorDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'CreatedBy', OriginalValue = OLD.CreatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'VendorDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedOn', OriginalValue = OLD.UpdatedOn, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
		INSERT INTO AuditLog SET TableName = 'VendorDevice', PrimaryKeyColumn = 'ID', PrimaryKeyValue = OLD.ID, ColumnName = 'UpdatedBy', OriginalValue = OLD.UpdatedBy, NewValue = NULL, Deleted = '1', UpdatedBy = @context;
	
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
