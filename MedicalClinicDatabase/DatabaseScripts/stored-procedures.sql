CREATE OR REPLACE
PROCEDURE DELETE_USER
( 
  user_id IN NUMBER
) AS
BEGIN
  DELETE FROM STAFF 
  WHERE ID = user_id;
END DELETE_USER;


create or replace PROCEDURE CONFIRM_USER_SPECIALIZATION
( 
  user_id IN NUMBER,
  spec_id IN NUMBER
) AS
BEGIN
  UPDATE STAFF_SPECIALIZATION
  SET CONFIRMED = 1
  WHERE MEDIC_ID = user_id AND SPECIALIZATION_ID = spec_id;
END CONFIRM_USER_SPECIALIZATION;


CREATE OR REPLACE
PROCEDURE ADD_MESSAGE
( 
  user_id IN NUMBER,
  toId IN NUMBER,
  message IN MESSAGE.MESSAGE%TYPE
) AS
BEGIN
  insert into MESSAGE (ID, FROM_ID, TO_ID, MESSAGE, CREATED_DATE) 
  values (DEFAULT_SEQ.NEXTVAL, user_id, toId, message, SYSDATE);
END ADD_MESSAGE;

create or replace package clinicpck is
  invalid_user exception;
  pragma exception_init (invalid_user, -2222);
 
  cursor SPECIALIZATION_CURSOR(v_id STAFF.ID%TYPE) is
    select SPECIALIZATION_ID
    from STAFF_SPECIALIZATION
    where MEDIC_ID = v_id;
    
  cursor STAFF_CURSOR(v_specId STAFF_SPECIALIZATION.SPECIALIZATION_ID%TYPE) is
    select st.ID
    from STAFF st
    join STAFF_SPECIALIZATION ss
    on st.ID = ss.MEDIC_ID
    where ss.SPECIALIZATION_ID = v_specId;

  procedure delete_user_sp( v_userId in STAFF.ID%TYPE);
end clinicpck;

create or replace package body clinicpck is
  procedure delete_user_sp ( v_userId in STAFF.ID%TYPE)
  is
    v_newUserId STAFF.ID%TYPE;
    v_tempSpecId STAFF_SPECIALIZATION.SPECIALIZATION_ID%TYPE;
  begin
    if v_userId is null then
      raise invalid_user;
    end if;
    
    open SPECIALIZATION_CURSOR(v_userId);
    
    loop
      fetch SPECIALIZATION_CURSOR into v_tempSpecId;
        
        open STAFF_CURSOR(v_tempSpecId);
          loop
            fetch STAFF_CURSOR into v_newUserId;
               if v_newUserId != v_userId then
                  if v_newUserId is not null then
                     exit;
                  end if;
               end if;
            exit when STAFF_CURSOR%notfound;
          end loop;  
        close STAFF_CURSOR;
        
      exit when SPECIALIZATION_CURSOR%notfound;
    end loop;
    
    close SPECIALIZATION_CURSOR;
    
    dbms_output.put_line(v_newUserId);
    
    if v_newUserId is not null then
      update APPOINTMENT set USER_ID = v_newUserId where USER_ID = v_userId;
      delete from MESSAGE where TO_ID = v_userId;
      delete from MESSAGE where FROM_ID = v_userId;
      delete from STAFF_SPECIALIZATION where MEDIC_ID = v_userId;
      delete from STAFF where ID = v_userId;
    end if;
  
  end delete_user_sp;

end clinicpck; 

