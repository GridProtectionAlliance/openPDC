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
