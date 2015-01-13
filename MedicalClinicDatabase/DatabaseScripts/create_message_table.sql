CREATE TABLE CLINIC.MESSAGE
(
	ID           NUMBER (*,0) NOT NULL ,
	FROM_ID      NUMBER (*,0) NOT NULL ,
	TO_ID        NUMBER (*,0) NOT NULL ,
	MESSAGE      VARCHAR2 (1024 BYTE) ,
	CREATED_DATE DATE
);
CREATE UNIQUE INDEX CLINIC.MESSAGE_ID_PK ON CLINIC.MESSAGE ( ID ASC)
ALTER TABLE CLINIC.MESSAGE ADD CONSTRAINT MESSAGE_ID_PK PRIMARY KEY ( ID ) USING INDEX CLINIC.MESSAGE_ID_PK ;
ALTER TABLE CLINIC.MESSAGE ADD CONSTRAINT FROM_ID_PK FOREIGN KEY ( FROM_ID ) REFERENCES CLINIC.STAFF ( ID ) NOT DEFERRABLE ;
ALTER TABLE CLINIC.MESSAGE ADD CONSTRAINT TO_ID_FK FOREIGN KEY ( TO_ID ) REFERENCES CLINIC.STAFF ( ID ) NOT DEFERRABLE ;