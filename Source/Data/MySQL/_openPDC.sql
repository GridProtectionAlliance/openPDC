-- *******************************************************************************************
-- IMPORTANT NOTE: When making updates to this schema, please increment the version number!
-- *******************************************************************************************
CREATE VIEW LocalSchemaVersion AS
SELECT 3 AS VersionNumber;

CREATE TABLE DataAvailability(
	ID int AUTO_INCREMENT NOT NULL,
	GoodAvailableData float NOT NULL,
	BadAvailableData float NOT NULL,
	TotalAvailableData float NOT NULL,
	PRIMARY KEY(ID)
);

CREATE TABLE AlarmState(
	ID int AUTO_INCREMENT NOT NULL,
	State varchar(50) NULL,
	Color varchar(50) NULL,
	PRIMARY KEY(ID)
);

CREATE TABLE AlarmDevice(
	ID int AUTO_INCREMENT NOT NULL,
	DeviceID int NULL,
	StateID int NULL,
	TimeStamp datetime NULL,
	DisplayData varchar(10) NULL,
	PRIMARY KEY(ID)
);

ALTER TABLE AlarmDevice
ADD CONSTRAINT FK_AlarmDevice_Device
FOREIGN KEY(DeviceID) REFERENCES Device(ID)
ON DELETE CASCADE
ON UPDATE CASCADE;

ALTER TABLE AlarmDevice
ADD CONSTRAINT FK_AlarmDevice_AlarmState
FOREIGN KEY(StateID) REFERENCES AlarmState(ID)
ON DELETE CASCADE
ON UPDATE CASCADE;

CREATE VIEW AlarmDeviceStateView AS
SELECT AlarmDevice.ID, Device.Name, AlarmState.State, AlarmState.Color, AlarmDevice.DisplayData
FROM AlarmDevice
    INNER JOIN AlarmState ON AlarmDevice.StateID = AlarmState.ID
    INNER JOIN Device ON AlarmDevice.DeviceID = Device.ID;