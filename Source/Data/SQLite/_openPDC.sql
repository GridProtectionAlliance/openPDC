-- *******************************************************************************************
-- IMPORTANT NOTE: When making updates to this schema, please increment the version number!
-- *******************************************************************************************
CREATE VIEW LocalSchemaVersion AS
SELECT 1 AS VersionNumber;

CREATE TABLE DataAvailability(
	ID int PRIMARY KEY AUTOINCREMENT NOT NULL,
	GoodAvailableData DOUBLE NOT NULL,
	BadAvailableData DOUBLE NOT NULL,
	TotalAvailableData DOUBLE NOT NULL
);


CREATE TABLE AlarmDevice(
	ID int PRIMARY KEY AUTOINCREMENT NOT NULL,
	DeviceID int NULL,
	StateID int NULL,
	TimeStamp datetime NULL,
	DisplayData varchar(10) NULL,
	CONSTRAINT FK_AlarmDevice_Device FOREIGN KEY(DeviceID) REFERENCES Device (ID) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_AlarmDevice_AlarmState FOREIGN KEY(StateID) REFERENCES AlarmState (ID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE AlarmState(
	ID int PRIMARY KEY AUTOINCREMENT NOT NULL,
	State varchar(50) NULL,
	Color varchar(50) NULL,
);

INSERT INTO AlarmState (State, Color) VALUES ('Good', 'green');
INSERT INTO AlarmState (State, Color) VALUES ('Alarm', 'red');
INSERT INTO AlarmState (State, Color) VALUES ('Not Available', 'orange')
INSERT INTO AlarmState (State, Color) VALUES ('Bad Data', 'blue');
INSERT INTO AlarmState (State, Color) VALUES ('Bad Time', 'purple');
INSERT INTO AlarmState (State, Color) VALUES ('Out of Service', 'grey');