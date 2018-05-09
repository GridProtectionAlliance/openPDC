-- *******************************************************************************************
-- IMPORTANT NOTE: When making updates to this schema, please increment the version number!
-- *******************************************************************************************
CREATE VIEW LocalSchemaVersion AS
SELECT 1 AS VersionNumber;

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
	PRIMARY KEY(ID),
	FOREIGN KEY (DeviceID) REFERENCES Device(ID),
	FOREIGN KEY (StateID) REFERENCES AlarmState(ID)
);
