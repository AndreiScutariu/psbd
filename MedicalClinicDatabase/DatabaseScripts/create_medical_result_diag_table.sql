CREATE TABLE MEDICAL_RESULT_DIAGNOSTIC 
(	
	ID NUMBER(11,0) NOT NULL ENABLE, 
	DIAGNOSTIC_ID NUMBER(11, 0), 
	MEDICAL_RESULT_ID NUMBER(11, 0), 
	CONSTRAINT MEDICAL_RESULT_DIAGNOSTIC_PK PRIMARY KEY (ID),
	CONSTRAINT MEDICAL_RESULT_ID_FK FOREIGN KEY (MEDICAL_RESULT_ID) REFERENCES MEDICAL_RESULT (ID) ENABLE, 
	CONSTRAINT DIAGNOSTIC_ID_FK FOREIGN KEY (DIAGNOSTIC_ID) REFERENCES DIAGNOSTIC (ID) ENABLE
);