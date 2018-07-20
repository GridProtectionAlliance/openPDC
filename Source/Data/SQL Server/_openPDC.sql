-- *******************************************************************************************
-- IMPORTANT NOTE: When making updates to this schema, please increment the version number!
-- *******************************************************************************************
CREATE VIEW [dbo].[LocalSchemaVersion] AS
SELECT 2 AS VersionNumber
GO

CREATE TABLE DataAvailability(
	ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	GoodAvailableData float NOT NULL,
	BadAvailableData float NOT NULL,
	TotalAvailableData float NOT NULL,
)
GO

CREATE TABLE AlarmState(
	ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	State varchar(50) NULL,
	Color varchar(50) NULL,
)
GO

CREATE TABLE AlarmDevice(
	ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	DeviceID int NULL FOREIGN KEY REFERENCES Device(ID),
	StateID int NULL FOREIGN KEY REFERENCES AlarmState(ID),
	TimeStamp datetime NULL,
	DisplayData varchar(10) NULL
)
GO

CREATE VIEW AlarmDeviceStateView AS
SELECT AlarmDevice.ID, Device.Name, AlarmState.State, AlarmState.Color, AlarmDevice.DisplayData
FROM AlarmDevice
    INNER JOIN AlarmState ON AlarmDevice.StateID = AlarmState.ID
    INNER JOIN Device ON AlarmDevice.DeviceID = Device.ID
GO
