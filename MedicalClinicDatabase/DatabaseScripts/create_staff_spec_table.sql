CREATE TABLE STAFF_SPECIALIZATION 
(	
	ID NUMBER(11, 0) NOT NULL ENABLE, 
	MEDIC_ID NUMBER(11, 0) NOT NULL ENABLE, 
	SPECIALIZATION_ID NUMBER(11, 0) NOT NULL ENABLE, 
	CREATED_DATE DATE, 
	CONSTRAINT STAFFSPECIALIZATION_PK PRIMARY KEY (ID),
	CONSTRAINT MEDIC_ID_FK FOREIGN KEY (MEDIC_ID) REFERENCES STAFF (ID) ENABLE, 
	CONSTRAINT SPECIALIZATION_ID_FK FOREIGN KEY (SPECIALIZATION_ID) REFERENCES SPECIALIZATION (ID) ENABLE
);