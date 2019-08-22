-- *******************************************************************************************
-- IMPORTANT NOTE: When making updates to this schema, please increment the version number!
-- *******************************************************************************************
CREATE VIEW [dbo].[LocalSchemaVersion] AS
SELECT 3 AS VersionNumber
GO

CREATE TABLE DataAvailability(
	ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	GoodAvailableData FLOAT NOT NULL,
	BadAvailableData FLOAT NOT NULL,
	TotalAvailableData FLOAT NOT NULL,
)
GO

CREATE TABLE AlarmState(
	ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	State VARCHAR(50) NULL,
	Color VARCHAR(50) NULL,
)
GO

CREATE TABLE AlarmDevice(
	ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	DeviceID INT NULL,
	StateID INT NULL,
	TimeStamp DATETIME NULL,
	DisplayData VARCHAR(10) NULL
)
GO

ALTER TABLE AlarmDevice
ADD CONSTRAINT [FK_AlarmDevice_Device]
FOREIGN KEY(DeviceID) REFERENCES Device(ID)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE AlarmDevice
ADD CONSTRAINT [FK_AlarmDevice_AlarmState]
FOREIGN KEY(StateID) REFERENCES AlarmState(ID)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

CREATE VIEW AlarmDeviceStateView AS
SELECT AlarmDevice.ID, Device.Name, AlarmState.State, AlarmState.Color, AlarmDevice.DisplayData
FROM AlarmDevice
    INNER JOIN AlarmState ON AlarmDevice.StateID = AlarmState.ID
    INNER JOIN Device ON AlarmDevice.DeviceID = Device.ID
GO
