-- *******************************************************************************************
-- IMPORTANT NOTE: When making updates to this schema, please increment the version number!
-- *******************************************************************************************
CREATE VIEW LocalSchemaVersion AS
SELECT 2 AS VersionNumber;

CREATE TABLE DataAvailability(
	ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
	GoodAvailableData DOUBLE NOT NULL,
	BadAvailableData DOUBLE NOT NULL,
	TotalAvailableData DOUBLE NOT NULL
);

CREATE TABLE AlarmState(
	ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
	State VARCHAR(50) NULL,
	Color VARCHAR(50) NULL
);

CREATE TABLE AlarmDevice(
	ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
	DeviceID INTEGER NULL,
	StateID INTEGER NULL,
	TimeStamp DATETIME NULL,
	DisplayData VARCHAR(10) NULL,
	CONSTRAINT FK_AlarmDevice_Device FOREIGN KEY(DeviceID) REFERENCES Device (ID) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_AlarmDevice_AlarmState FOREIGN KEY(StateID) REFERENCES AlarmState (ID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE VIEW AlarmDeviceStateView AS
SELECT AlarmDevice.ID, Device.Name, AlarmState.State, AlarmState.Color, AlarmDevice.DisplayData
FROM AlarmDevice
    INNER JOIN AlarmState ON AlarmDevice.StateID = AlarmState.ID
    INNER JOIN Device ON AlarmDevice.DeviceID = Device.ID;