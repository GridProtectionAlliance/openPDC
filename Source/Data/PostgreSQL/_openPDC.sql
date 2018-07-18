-- *******************************************************************************************
-- IMPORTANT NOTE: When making updates to this schema, please increment the version number!
-- *******************************************************************************************
CREATE VIEW LocalSchemaVersion AS
SELECT 2 AS VersionNumber;

CREATE TABLE DataAvailability(
	ID SERIAL NOT NULL PRIMARY KEY,
	GoodAvailableData DOUBLE PRECISION NOT NULL,
	BadAvailableData DOUBLE PRECISION NOT NULL,
	TotalAvailableData DOUBLE PRECISION NOT NULL,
);

CREATE TABLE AlarmState(
	ID SERIAL NOT NULL PRIMARY KEY,
	State varchar(50) NULL,
	Color varchar(50) NULL,
);

INSERT INTO AlarmState(State, Color) VALUES('Good', 'green');
INSERT INTO AlarmState(State, Color) VALUES('Alarm', 'red');
INSERT INTO AlarmState(State, Color) VALUES('Not Available', 'orange');
INSERT INTO AlarmState(State, Color) VALUES('Bad Data', 'blue');
INSERT INTO AlarmState(State, Color) VALUES('Bad Time', 'purple');
INSERT INTO AlarmState(State, Color) VALUES('Out of Service', 'grey');

CREATE TABLE AlarmDevice(
	ID SERIAL NOT NULL PRIMARY KEY,
	DeviceID INTEGER NULL FOREIGN KEY REFERENCES Device(ID),
	StateID INTEGER NULL FOREIGN KEY REFERENCES AlarmState(ID),
	TimeStamp TIMESTAMP NULL,
	DisplayData varchar(10) NULL,
	CONSTRAINT FK_AlarmDevice_Device FOREIGN KEY(DeviceID) REFERENCES Device (ID) ON DELETE CASCADE,
    CONSTRAINT FK_AlarmDevice_AlarmState FOREIGN KEY(StateID) REFERENCES AlarmState (ID) ON DELETE CASCADE
);

CREATE VIEW AlarmDeviceStateView AS
SELECT AlarmDevice.ID, Device.Name, AlarmState.State, AlarmState.Color, AlarmDevice.DisplayData
FROM AlarmDevice
    INNER JOIN AlarmState ON AlarmDevice.StateID = AlarmState.ID
    INNER JOIN Device ON AlarmDevice.DeviceID = Device.ID;