--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
PROCEDURE cwatis.GetSubjects()
BEGIN
  SELECT
    s.Subject_Id,
    ms.MCODE_SUBJ,
    mu.UserAbbrev,
    s.Subject_IsAdmin
  FROM right_subjects s
    LEFT JOIN subject_roles sr
      ON sr.Right_Subject_Id = s.Subject_Id
    LEFT JOIN refers.m_user mu
      ON mu.UserId = s.Subject_UserId
    LEFT JOIN refers.m_subject ms
      ON ms.ID_M_SUBJ = mu.ID_M_SUBJ;

END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
PROCEDURE cwatis.GetSubjectEditModel(IN _Id int(11))
BEGIN

  SELECT
    rs.Subject_Id AS Id,
    rs.Subject_UserId AS UserId,
    rs.Subject_IsAdmin AS IsAdmin
  FROM right_subjects rs
  WHERE rs.Subject_Id = _Id;
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
PROCEDURE cwatis.AddSubject(IN _Id int)
BEGIN
  DECLARE _AddedSubject int;

  INSERT INTO right_subjects (Subject_Id, Subject_UserId, Subject_IsAdmin)
    VALUES (NULL, _Id, 0);

  SET _AddedSubject = LAST_INSERT_ID();

  -- Добавление ролей по умолчанию
  IF EXISTS (SELECT
        *
      FROM roles
      WHERE Role_Default = 1) THEN
    INSERT INTO subject_roles
    SET Role_Id = (SELECT
            Role_Id
          FROM roles
          WHERE Role_Default = 1 LIMIT 1),
        Right_Subject_Id = _AddedSubject;
  END IF;

  -- Возвращение добавленной модели
  SELECT
    s.Subject_Id,
    ms.MCODE_SUBJ,
    mu.UserAbbrev,
    s.Subject_IsAdmin
  FROM right_subjects s
    LEFT JOIN subject_roles sr
      ON sr.Right_Subject_Id = s.Subject_Id
    LEFT JOIN refers.m_user mu
      ON mu.UserId = _Id
    LEFT JOIN refers.m_subject ms
      ON ms.ID_M_SUBJ = mu.ID_M_SUBJ
  WHERE s.Subject_Id = _AddedSubject;
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
PROCEDURE cwatis.EditSubject(IN _Id int, IN _IsAdmin tinyint(1))
BEGIN
  UPDATE right_subjects
  SET Subject_IsAdmin = _IsAdmin
  WHERE Subject_Id = _Id;
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
PROCEDURE cwatis.DeleteSubject(IN _Id int)
BEGIN
  DELETE
    FROM right_subjects
  WHERE Subject_Id = _Id;
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
PROCEDURE cwatis.GetSubjectRoles(IN _Id int)
BEGIN
  SELECT
    r.Role_Id,
    r.Role_Name,
    r.Role_Default,
    r.Role_Checked,
    r.Role_Approved,
    r.Role_CheckedBy,
    r.Role_ApprovedBy
  FROM subject_roles sr
    LEFT JOIN roles r
      ON r.Role_Id = sr.Role_Id
  WHERE sr.Right_Subject_Id = _Id AND sr.Role_Id IS NOT NULL;
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
PROCEDURE cwatis.AddSubjectRole(IN _Id int, IN _RoleId int)
BEGIN
  INSERT INTO subject_roles
  SET Right_Subject_Id = _Id,
      Role_Id = _RoleId;
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
PROCEDURE cwatis.DeleteSubjectRole(IN _Id int, IN _RoleId int)
BEGIN
  DELETE
    FROM subject_roles
  WHERE Right_Subject_Id = _Id
    AND Role_Id = _RoleId;
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
FUNCTION cwatis.IsSubjectExists(_Id int)
  RETURNS tinyint(1)
BEGIN

  DECLARE count int DEFAULT 0;

  SELECT
    COUNT(*) INTO count
  FROM right_subjects
  WHERE Subject_Id = _Id;

  RETURN count > 0;
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
FUNCTION cwatis.IsSubjectRoleExists(_SubjectId int, _RoleId int)
  RETURNS tinyint(1)
BEGIN
  DECLARE count int DEFAULT 0;

  SELECT
    COUNT(*) INTO count
  FROM subject_roles
  WHERE Right_Subject_Id = _SubjectId
  AND Role_Id = _RoleId;

  RETURN count > 0;
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
PROCEDURE cwatis.GetSubjectRightsOverview(IN _SubjectId int(11))
BEGIN

  SELECT
    ro.Right_Object_Id,
    ro.Right_Object_ParentId,
    ro.Right_Object_IsGroup,
    ro.Right_Object_Code,
    ro.Right_Object_PathCode,
    ro.Right_Object_Name,
    ro.Right_Object_CheckAndApproveEnable,
    MAX(rr.Role_Right_CheckValue) AS CheckValue,
    MAX(rr.Role_Right_ApproveValue) AS ApproveValue,

    (SELECT Right_Values_ValueDisplayName
        FROM right_values
        WHERE Right_Values_Value = MAX(rr.Right_Values_Value)) AS Value
  FROM subject_roles sr
    LEFT JOIN roles r
      ON sr.Role_Id = r.Role_Id
    LEFT JOIN role_rights rr
      ON rr.Role_Id = r.Role_Id
    LEFT JOIN right_objects ro
      ON ro.Right_Object_Id = rr.Right_Object_Id
    LEFT JOIN right_values rv
        ON rv.Right_Values_Value = rr.Right_Values_Value
  WHERE sr.Right_Subject_Id = _SubjectId
  GROUP BY ro.Right_Object_Code
  ORDER BY ro.Right_Object_PathCode ASC;

END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
PROCEDURE cwatis.GetRoles()
BEGIN
  SELECT
    *
  FROM roles ORDER BY Role_Id ASC;
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
PROCEDURE cwatis.AddNewRole(IN _Name varchar(100))
  COMMENT 'Добавление новой роли'
BEGIN
  INSERT INTO roles
  SET Role_Name = _Name;

  SELECT
    *
  FROM roles
  WHERE Role_Id = LAST_INSERT_ID();
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER=`bookkeep`@`%` PROCEDURE `cwatis`.`EditRole`(IN _Id int, IN _Name varchar(100), IN _IsDefault tinyint(1), IN _IsChecked tinyint(1), IN _IsApproved tinyint(1), IN _UserId int(11))
    COMMENT 'Редактирование роли'
BEGIN
  UPDATE roles
  SET Role_Name = _Name,
      Role_Default = _IsDefault
  WHERE Role_Id = _Id;

  SELECT
    r.Role_Checked,
    r.Role_Approved,
    mu.UserAbbrev INTO @Checked, @Approved, @Abbrev
  FROM roles r
    LEFT JOIN refers.m_user mu
      ON mu.UserId = _UserId
  WHERE r.Role_Id = _Id;

  IF @Checked != _IsChecked THEN
    UPDATE roles
    SET Role_Checked = _IsChecked,
        Role_CheckedBy = @Abbrev
      WHERE Role_Id = _Id;
  END IF;

  IF @Approved != _IsApproved THEN
    UPDATE roles
    SET Role_Approved = _IsApproved,
        Role_ApprovedBy = @Abbrev
      WHERE Role_Id = _Id;
  END IF;
  
  select * from roles WHERE Role_Id = _Id;
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
PROCEDURE cwatis.DeleteRole(IN _Id int)
  COMMENT 'Удаление роли'
BEGIN
  DELETE
    FROM `roles`
  WHERE Role_Id = _Id;
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
PROCEDURE cwatis.CopyRoleRights(IN _SourceId int, IN _DestId int)
BEGIN

  INSERT INTO role_rights (Role_Id, Right_Object_Id, Right_Values_Value)
    SELECT
      _DestId AS Role_Id,
      Right_Object_Id,
      Right_Values_Value
    FROM role_rights
    WHERE Role_Id = _SourceId;

END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
FUNCTION cwatis.IsRoleExists(_Name varchar(100), _ExcludeId int)
  RETURNS tinyint(1)
BEGIN
  DECLARE count int DEFAULT 0;

  IF _ExcludeId != -1 THEN
    SELECT
      COUNT(*) INTO count
    FROM roles
    WHERE Role_Name = _Name
    AND Role_Id != _ExcludeId;
  ELSE
    SELECT
      COUNT(*) INTO count
    FROM roles
    WHERE Role_Name = _Name;
  END IF;

  RETURN count > 0;
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
FUNCTION cwatis.IsDefaultRoleExists(_ExcludeId int)
  RETURNS tinyint(1)
BEGIN
  DECLARE count int DEFAULT 0;

  IF _ExcludeId != -1 THEN
    SELECT
      COUNT(*) INTO count
    FROM roles
    WHERE Role_Default = 1
    AND Role_Id != _ExcludeId;
  ELSE
    SELECT
      COUNT(*) INTO count
    FROM roles
    WHERE Role_Default = 1;
  END IF;

  RETURN count > 0;
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
PROCEDURE cwatis.GetRoleRights(IN _Id int)
BEGIN
  IF EXISTS (SELECT
        *
      FROM roles
      WHERE Role_Id = _Id) = TRUE THEN
    SELECT
      ro.Right_Object_Id,
      ro.Right_Object_ParentId,
      ro.Right_Object_IsGroup,
      ro.Right_Object_Code,
      ro.Right_Object_PathCode,
      ro.Right_Object_Name,
      ro.Right_Object_CheckAndApproveEnable,
      IFNULL(rr.Role_Right_CheckValue, 0) AS CheckValue,
      IFNULL(rr.Role_Right_ApproveValue, 0) AS ApproveValue,
      IFNULL(rv.Right_Values_ValueDisplayName, (SELECT
          Right_Values_ValueDisplayName
        FROM right_values
        WHERE Right_Values_Value = 0)) AS Value
    FROM right_objects ro
      LEFT JOIN role_rights rr
        ON rr.Right_Object_Id = ro.Right_Object_Id
        AND rr.Role_Id = _Id
      LEFT JOIN right_values rv
        ON rv.Right_Values_Value = rr.Right_Values_Value
    ORDER BY ro.Right_Object_PathCode ASC;
  END IF;
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
PROCEDURE cwatis.GetRightValues()
BEGIN
  SELECT
    *
  FROM right_values;
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
PROCEDURE cwatis.EditRoleRight(IN _RoleId int, IN _RightId int, IN _CheckValue tinyint(1), IN _ApproveValue tinyint(1), IN _Value int)
BEGIN
  DECLARE _Ids varchar(1000);

  -- Обновляем указанную запись
  IF _Value != 0
    OR _CheckValue
    OR _ApproveValue THEN

    INSERT INTO role_rights
    SET Role_Id = _RoleId,
        Right_Object_Id = _RightId,
        Role_Right_CheckValue = _CheckValue,
        Role_Right_ApproveValue = _ApproveValue,
        Right_Values_Value = _Value ON DUPLICATE KEY UPDATE Role_Right_CheckValue = _CheckValue,
    Role_Right_ApproveValue = _ApproveValue, Right_Values_Value = _Value;
  ELSE
    DELETE
      FROM role_rights
    WHERE Role_Id = _RoleId
      AND Right_Object_Id = _RightId;
  END IF;

  -- Получаем текущее значение объекта роли.    
  SELECT
    ro.Right_Object_ParentIds INTO _Ids
  FROM right_objects ro
  WHERE ro.Right_Object_Id = _RightId;

  -- Если у объекта права есть потомки, добавляем или обновляем их значения
  INSERT INTO role_rights (Role_Id, Right_Object_Id, Right_Values_Value, Role_Right_CheckValue, Role_Right_ApproveValue)
    SELECT
      _RoleId,
      ro.Right_Object_Id,
      _Value,
      0,
      0
    FROM right_objects ro
    WHERE ro.Right_Object_ParentIds LIKE CONCAT(_Ids, '%') ON DUPLICATE KEY UPDATE Right_Values_Value = _Value;

END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
PROCEDURE cwatis.GetRightObjects()
BEGIN
  SELECT
    *
  FROM right_objects ro
  ORDER BY ro.Right_Object_PathCode ASC;
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
PROCEDURE cwatis.AddRightObject(IN _ParentId int, IN _Name varchar(1000), IN _Code varchar(100))
BEGIN
  INSERT INTO right_objects
  SET Right_Object_ParentId = _ParentId,
      Right_Object_Name = _Name,
      Right_Object_Code = _Code;
  
  CALL SetParentsIds4RightObjects(LAST_INSERT_ID());

  SELECT
    *
  FROM right_objects
  WHERE Right_Object_Id = LAST_INSERT_ID();
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
PROCEDURE cwatis.EditRightObject(IN _Id int, IN _ParentId int, IN _Name varchar(100), IN _Code varchar(100), IN _CheckAndApproveEnable tinyint(1))
BEGIN
  UPDATE right_objects
  SET Right_Object_ParentId = _ParentId,
      Right_Object_Name = _Name,
      Right_Object_Code = _Code,
      Right_Object_CheckAndApproveEnable = _CheckAndApproveEnable
  WHERE Right_Object_Id = _Id;

  CALL SetParentsIds4RightObjects(_Id);
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
PROCEDURE cwatis.DeleteRightObject(IN _Id int)
BEGIN
  DELETE
    FROM right_objects
  WHERE Right_Object_Id = _Id
    OR Right_Object_ParentId = _Id;
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
PROCEDURE cwatis.MoveRightObject(IN _Id int, IN _ParentId int)
BEGIN
  UPDATE right_objects ro
  SET ro.Right_Object_ParentId = _ParentId
  WHERE ro.Right_Object_Id = _Id;
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
FUNCTION cwatis.IsRightObjectNameExists(_Name varchar(100), _ExcludeId int)
  RETURNS tinyint(1)
BEGIN
  DECLARE count int DEFAULT 0;

  IF _ExcludeId != -1 THEN
    SELECT
      COUNT(*) INTO count
    FROM right_objects
    WHERE Right_Object_Name = _Name
    AND Right_Object_Id != _ExcludeId;
  ELSE
    SELECT
      COUNT(*) INTO count
    FROM right_objects
    WHERE Right_Object_Name = _Name;
  END IF;

  RETURN count > 0;
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
FUNCTION cwatis.IsRightObjectCodeExists(_Code VARCHAR(100), _ExcludeId int)
  RETURNS tinyint(1)
BEGIN
  DECLARE count int DEFAULT 0;

  IF _ExcludeId != -1 THEN
    SELECT
      COUNT(*) INTO count
    FROM right_objects
    WHERE Right_Object_Code = _Code
    AND Right_Object_Id != _ExcludeId;
  ELSE
    SELECT
      COUNT(*) INTO count
    FROM right_objects
    WHERE Right_Object_Code = _Code;
  END IF;

  RETURN count > 0;
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
FUNCTION cwatis.IsRightObjectHasForeignKey(_Id int)
  RETURNS tinyint(1)
BEGIN
  DECLARE count int DEFAULT 0;

  SELECT
    COUNT(*) INTO count
  FROM role_rights
  WHERE Right_Object_Id = _Id;

  RETURN count > 0;
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
FUNCTION cwatis.IsRightObjectHasChilds(_Id int)
  RETURNS tinyint(1)
BEGIN
  DECLARE count int DEFAULT 0;

  SELECT
    COUNT(*) INTO count
  FROM right_objects ro
  WHERE ro.Right_Object_ParentId = _Id;

  RETURN count > 0;
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
PROCEDURE cwatis.GetRightValue(IN _SubjectId int, IN _ObjectName varchar(255))
BEGIN
  SELECT
    MAX(rr.Right_Values_Value) AS Value,
    MAX(rr.Role_Right_CheckValue) AS CanCheck,
    MAX(rr.Role_Right_ApproveValue) AS CanApprove
  FROM subject_roles sr
    LEFT JOIN roles r
      ON sr.Role_Id = r.Role_Id
    LEFT JOIN role_rights rr
      ON rr.Role_Id = r.Role_Id
    LEFT JOIN right_objects ro
      ON ro.Right_Object_Id = rr.Right_Object_Id
  WHERE sr.Right_Subject_Id = _SubjectId
  AND ro.Right_Object_Code = _ObjectName;
END
--------------------------------------------------

--------------------------------------------------
CREATE DEFINER = 'bookkeep'@'%'
PROCEDURE cwatis.SetParentsIds4RightObjects(IN _RightObject_Id int)
BEGIN
  DECLARE _pIds text;
  DECLARE _PMCodes text;
  DECLARE _pid int;
  DECLARE _PMCode varchar(100);
  DECLARE _All bit;

  START TRANSACTION;

    SET _All = IF(_RightObject_Id IS NULL, 1, 0);

    IF _All THEN
      SELECT
        Right_Object_Id INTO _RightObject_Id
      FROM right_objects
      WHERE Right_Object_Id > IFNULL(_RightObject_Id, 0) LIMIT 1;
    END IF;

    WHILE _RightObject_Id IS NOT NULL DO
      SET _pIds = '';
      SET _PMCodes = '';
      SET _pid = _RightObject_Id;
      SET _PMCode = (SELECT
          Right_Object_Name
        FROM right_objects
        WHERE Right_Object_Id = _pid);
      WHILE IFNULL(_pid, 0) > 0 DO
        SET _pIds = CONCAT(_pid, ',', _pIds);
        SET _PMCodes = CONCAT(IFNULL(_PMCode, ""), '   /   ', IFNULL(_PMCodes, ""));
        SELECT
          Right_Object_ParentId INTO _pid
        FROM right_objects
        WHERE Right_Object_Id = _pid;
        SELECT
          Right_Object_Name INTO _PMCode
        FROM right_objects
        WHERE Right_Object_Id = _pid;
      END WHILE;

      IF LENGTH(_pIds) > 0 THEN
        SET _pIds = LEFT(_pIds, CHAR_LENGTH(_pIds) - 1);
        SET _PMCodes = LEFT(_PMCodes, CHAR_LENGTH(_PMCodes) - 1);
      END IF;

      UPDATE right_objects
      SET Right_Object_ParentIds = _pIds,
          Right_Object_PathCode = _PMCodes
      WHERE Right_Object_Id = _RightObject_Id;


      IF _All THEN
        IF NOT EXISTS (SELECT
              Right_Object_Id
            FROM right_objects
            WHERE Right_Object_Id > IFNULL(_RightObject_Id, 0) LIMIT 1) THEN
          SET _RightObject_Id = NULL;
        ELSE
          SELECT
            Right_Object_Id INTO _RightObject_Id
          FROM right_objects
          WHERE Right_Object_Id > IFNULL(_RightObject_Id, 0) LIMIT 1;
        END IF;
      ELSE
        SET _RightObject_Id = NULL;
      END IF;
    END WHILE;

  COMMIT;
END
--------------------------------------------------
