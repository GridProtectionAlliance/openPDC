-- *******************************************************************************************
-- IMPORTANT NOTE: When making updates to this schema, please increment the version number!
-- *******************************************************************************************
CREATE VIEW LocalSchemaVersion AS
SELECT 3 AS VersionNumber;

CREATE TABLE DataAvailability(
	ID SERIAL NOT NULL PRIMARY KEY,
	GoodAvailableData DOUBLE PRECISION NOT NULL,
	BadAvailableData DOUBLE PRECISION NOT NULL,
	TotalAvailableData DOUBLE PRECISION NOT NULL
);

