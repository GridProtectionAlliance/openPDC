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

