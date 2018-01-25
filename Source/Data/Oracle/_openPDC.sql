-- *******************************************************************************************
-- IMPORTANT NOTE: When making updates to this schema, please increment the version number!
-- *******************************************************************************************
CREATE VIEW LocalSchemaVersion AS
SELECT 1 AS VersionNumber
FROM dual;


CREATE TABLE DataAvailability(
	ID NUMBER NOT NULL,
	GoodAvailableData NUMBER NOT NULL,
	BadAvailableData NUMBER NOT NULL,
	TotalAvailableData NUMBER NOT NULL,
);
ALTER TABLE DataAvailability ADD CONSTRAINT PK_DataAvailability PRIMARY KEY (ID);

CREATE SEQUENCE SEQ_DataAvailability START WITH 1 INCREMENT BY 1;

CREATE TRIGGER AI_DataAvailability BEFORE INSERT ON DataAvailability
    FOR EACH ROW BEGIN SELECT SEQ_DataAvailability.nextval INTO :NEW.ID FROM dual;
END;


CREATE TABLE AlarmState(
	ID NUMBER NOT NULL,
	State varchar(50) NULL,
	Color varchar(50) NULL,
);

ALTER TABLE AlarmState ADD CONSTRAINT PK_AlarmState PRIMARY KEY (ID);

CREATE SEQUENCE SEQ_AlarmState START WITH 1 INCREMENT BY 1;

CREATE TRIGGER AI_AlarmState BEFORE INSERT ON AlarmState
    FOR EACH ROW BEGIN SELECT SEQ_AlarmState.nextval INTO :NEW.ID FROM dual;
END;

INSERT INTO AlarmState (State, Color) VALUES ('Good', 'green');
INSERT INTO AlarmState (State, Color) VALUES ('Alarm', 'red');
INSERT INTO AlarmState (State, Color) VALUES ('Not Available', 'orange');
INSERT INTO AlarmState (State, Color) VALUES ('Bad Data', 'blue');
INSERT INTO AlarmState (State, Color) VALUES ('Bad Time', 'purple');
INSERT INTO AlarmState (State, Color) VALUES ('Out of Service', 'grey');

CREATE TABLE AlarmDevice(
	ID NUMBER IDENTITY(1,1) NOT NULL PRIMARY KEY,
	DeviceID NUMBER NULL,
	StateID NUMBER NULL,
	TimeStamp datetime NULL,
	DisplayData varchar(10) NULL
);

ALTER TABLE AlarmDevice ADD CONSTRAINT PK_AlarmDevice PRIMARY KEY (ID);
ALTER TABLE AlarmDevice ADD CONSTRAINT FK_AlarmDevice_Device FOREIGN KEY(DeviceID) REFERENCES Device(ID) ON DELETE CASCADE;
ALTER TABLE AlarmDevice ADD CONSTRAINT FK_AlarmDevice_State FOREIGN KEY(StateID) REFERENCES AlarmState(ID) ON DELETE CASCADE;

CREATE SEQUENCE SEQ_AlarmDevice START WITH 1 INCREMENT BY 1;

CREATE TRIGGER AI_AlarmDevice BEFORE INSERT ON AlarmDevice
    FOR EACH ROW BEGIN SELECT SEQ_AlarmDevice.nextval INTO :NEW.ID FROM dual;
END;
