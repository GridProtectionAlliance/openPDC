-- *******************************************************************************************
-- IMPORTANT NOTE: When making updates to this schema, please increment the version number!
-- *******************************************************************************************
CREATE VIEW [dbo].[LocalSchemaVersion] AS
SELECT 1 AS VersionNumber
GO

CREATE TABLE DataAvailability(
	ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	GoodAvailableData float NOT NULL,
	BadAvailableData float NOT NULL,
	TotalAvailableData float NOT NULL,
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

CREATE TABLE AlarmState(
	ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	State varchar(50) NULL,
	Color varchar(50) NULL,
)

GO

INSERT AlarmState (State, Color) VALUES ('Good', 'green')
GO
INSERT AlarmState (State, Color) VALUES ('Alarm', 'red')
GO
INSERT AlarmState (State, Color) VALUES ('Not Available', 'orange')
GO
INSERT AlarmState (State, Color) VALUES ('Bad Data', 'blue')
GO
INSERT AlarmState (State, Color) VALUES ('Bad Time', 'purple')
GO
INSERT AlarmState (State, Color) VALUES ('Out of Service', 'grey')
GO
