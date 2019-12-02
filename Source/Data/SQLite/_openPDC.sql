-- *******************************************************************************************
-- IMPORTANT NOTE: When making updates to this schema, please increment the version number!
-- *******************************************************************************************
CREATE VIEW LocalSchemaVersion AS
SELECT 3 AS VersionNumber;

CREATE TABLE DataAvailability(
	ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
	GoodAvailableData DOUBLE NOT NULL,
	BadAvailableData DOUBLE NOT NULL,
	TotalAvailableData DOUBLE NOT NULL
);

