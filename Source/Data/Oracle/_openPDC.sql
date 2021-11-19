-- *******************************************************************************************
-- IMPORTANT NOTE: When making updates to this schema, please increment the version number!
-- *******************************************************************************************
CREATE VIEW LocalSchemaVersion AS
SELECT 3 AS VersionNumber
FROM dual;

CREATE TABLE DataAvailability(
	ID NUMBER NOT NULL,
	GoodAvailableData NUMBER NOT NULL,
	BadAvailableData NUMBER NOT NULL,
	TotalAvailableData NUMBER NOT NULL
);

CREATE UNIQUE INDEX IX_DataAvailability_ID ON DataAvailability (ID ASC) TABLESPACE openPDC_INDEX;

ALTER TABLE DataAvailability ADD CONSTRAINT PK_DataAvailability PRIMARY KEY (ID);

CREATE SEQUENCE SEQ_DataAvailability START WITH 1 INCREMENT BY 1;

CREATE TRIGGER AI_DataAvailability BEFORE INSERT ON DataAvailability
    FOR EACH ROW BEGIN SELECT SEQ_DataAvailability.nextval INTO :NEW.ID FROM dual;
END;
/