CREATE DEFINER=`bookkeep`@`%` PROCEDURE `global_db`.`iu_m_entity_NEW`(INOUT _ID_M_ENT int, IN _ID_M_SUBJ int, IN _TIN_SUBJ varchar(10),
                                                     IN _TINEXT_SUBJ varchar(10), IN _MCODE_SUBJ varchar(30),
                                                     IN _ID_M_COUNTRY int, IN _ID_M_GEOCOUNTRY int,
                                                     IN _ID_M_COUNTRY_RSD int, IN _ID_M_GEOCOUNTRY_RSD int,
                                                     IN _DATE_BEG date, IN _NameOrg varchar(100),
                                                     IN _NameOrgEng varchar(100), IN _Short varchar(40),
                                                     IN _Prefix varchar(30), IN _Address varchar(100),
                                                     IN _Fax varchar(60), IN _EMail varchar(100),
                                                     IN _Phone varchar(100), IN _OKONH varchar(5), IN _OKPO varchar(8),
                                                     IN _Comment varchar(100), IN _Site varchar(100),
                                                     IN _Deal varchar(100), IN _SOOGU varchar(5), IN _SOATO varchar(11),
                                                     IN _KFS varchar(3), IN _KOPF varchar(3), IN _ID_M_GEO int,
                                                     IN _ID_M_GEOLOCATIONS int, IN _Post varchar(50),
                                                     IN _HeadName varchar(100), IN _AccounterName varchar(100),
                                                     IN _OnBase text, IN _SignatoryHeadId int,
                                                     IN _SignatoryAccounterId int, IN _INNControl bit,
                                                     IN _FAddress varchar(100), IN _FAddressEng varchar(100),
                                                     IN _FPhone varchar(100), IN _IsCustom bit, IN _KPP varchar(9),
                                                     IN _OKED varchar(10), IN _UserId int, IN _NDSRegNum varchar(12),
                                                     IN _MicrosCode varchar(30), IN _MicrosCodeConfirm int,
                                                     IN _RegNum varchar(15), IN _DisplayRegNumb varchar(14),
                                                     IN _DOpen datetime)
BEGIN -- 17.06.2021, АКА. Добавлен _DisplayRegNumb
  DECLARE signatoryCount int;
  DECLARE _CountryName varchar(255);
  -- DECLARE _NewCountryName varchar(255);
  SET signatoryCount = 0;

  IF EXISTS (SELECT
        *
      FROM global_db.m_subject 
      WHERE MCODE_SUBJ = _MCODE_SUBJ
      AND TYPE_SUBJ = 0
      AND ID_M_SUBJ <> IFNULL(_ID_M_SUBJ, 0)) THEN
    SET @msg = CONCAT('Юр. лицо с внутр. наим. ', _MCODE_SUBJ, ' уже существует!');
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = @msg;
  END IF;

  IF IFNULL(TRIM(_TIN_SUBJ), '') <> ''
    AND EXISTS (SELECT
        *
      FROM global_db.m_subject 
      WHERE TIN_SUBJ LIKE _TIN_SUBJ
      AND IFNULL(TINEXT_SUBJ, '') LIKE IFNULL(_TINEXT_SUBJ, '') -- вот внизу  поставил свою Javlon.Abdurasulov 05.02.25
      AND  ( IFNULL(ID_M_GEOCOUNTRY, 0) = IFNULL(_ID_M_GEOCOUNTRY, 0) )
      AND ID_M_SUBJ <> IFNULL(_ID_M_SUBJ, 0)) THEN
    SELECT
      CONCAT(GeoLocation_Name, ' (', GeoLocation_Code2, ')') INTO _CountryName
    FROM global_db.geolocations
    WHERE GeoLocation_Id = _ID_M_GEOCOUNTRY;
    /*
    SELECT
      CONCAT(Name, ' (', Code2, ')') INTO _CountryName
    FROM m_country
    WHERE ID_M_COUNTRY = _ID_M_COUNTRY;
    SELECT
      CONCAT(GeoLocation_Name, ' (', GeoLocation_Code2, ')') INTO _NewCountryName
    FROM global_db.geolocations
    WHERE GeoLocation_Id = _ID_M_GEOCOUNTRY;*/
    -- SET @msg = CONCAT('Юр. лицо с ИНН "', _TIN_SUBJ, '" зарег. в стране "', IFNULL(_CountryName, 'Неизвестно'),'", "',IFNULL(_NewCountryName, 'Неизвестно'), '" уже существует!');
    SET @msg = CONCAT('Юр. лицо с ИНН "', _TIN_SUBJ, '" зарег. в стране "', IFNULL(_CountryName, 'Неизвестно'),'" уже существует!');
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = @msg;
  END IF;

  IF IFNULL(TRIM(_MicrosCode), '') <> ''
    AND EXISTS (SELECT
        *
      FROM global_db.m_subject 
      WHERE TRIM(MicrosCode) = TRIM(_MicrosCode)
      AND ID_M_SUBJ <> IFNULL(_ID_M_SUBJ, 0)) THEN
    SET @msg = CONCAT('Юр. лицо с Кодом идент. с RWS "', _MicrosCode, '" уже существует!');
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = @msg;
  END IF;

  IF IFNULL(TRIM(_RegNum), '') <> ''
    AND EXISTS (SELECT
        *
      FROM global_db.m_subject 
      WHERE TRIM(RegNum) = TRIM(_RegNum)
      AND ID_M_SUBJ <> IFNULL(_ID_M_SUBJ, 0)) THEN
    SET @msg = CONCAT('Юр. лицо с Регистр. номером "', _RegNum, '" уже существует!');
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = @msg;
  END IF;

  START TRANSACTION;
    IF IFNULL(_ID_M_SUBJ, 0) = 0 THEN
      INSERT INTO global_db.m_subject (TYPE_SUBJ, TIN_SUBJ, TINEXT_SUBJ, MCODE_SUBJ, MicrosCode, MicrosCodeConfirm, RegNum, DisplayRegNumb)
        VALUES (0, _TIN_SUBJ, _TINEXT_SUBJ, _MCODE_SUBJ, _MicrosCode, _MicrosCodeConfirm, _RegNum, _DisplayRegNumb);
      SELECT
        LAST_INSERT_ID() INTO _ID_M_SUBJ;
--       CALL refers.add_m_rec_info(_ID_M_SUBJ, 'm_subject', 'CREATE', _UserId); 
#          CALL global_db.add_rec_info(_ID_M_SUBJ, 'm_subject', 'CREATE', _UserId); 
    ELSE
      UPDATE global_db.m_subject 
      SET TIN_SUBJ = _TIN_SUBJ,
          TINEXT_SUBJ = _TINEXT_SUBJ,
          MCODE_SUBJ = _MCODE_SUBJ,
          MicrosCode = _MicrosCode,
          MicrosCodeConfirm = _MicrosCodeConfirm,
          RegNum = _RegNum,
          DisplayRegNumb = _DisplayRegNumb,
          NDSRegNum=_NDSRegNum
      WHERE ID_M_SUBJ = _ID_M_SUBJ;
--       CALL refers.add_m_rec_info(_ID_M_SUBJ, 'm_subject', 'EDIT', _UserId); 
#          CALL global_db.add_rec_info(_ID_M_SUBJ, 'm_subject', 'EDIT', _UserId); 
    END IF;

    SELECT
      ID_M_ENT INTO _ID_M_ENT
    FROM global_db.m_entity
    WHERE ID_M_SUBJ = _ID_M_SUBJ
    AND DATE_BEG = _DATE_BEG;

    IF IFNULL(_ID_M_ENT, 0) = 0 THEN
      INSERT INTO global_db.m_entity (NameOrg, LatName, Short, Prefix, Address, Fax, EMail, DATE_BEG, ID_M_SUBJ,
      Phone, OKONH, OKPO, Comment, Site, Deal, SOOGU, SOATO,
      KFS, KOPF,  ID_M_GEOCOUNTRY_RSD,ID_M_GEOCOUNTRY, ID_M_GEO,ID_M_GEOLOCATIONS, INNControl, FAddress, LatAddr,
      FPhone, IsCustom, KPP, OKED,   DOpen)
        VALUES (_NameOrg, _NameOrgEng, _Short, _Prefix, _Address, _Fax, _EMail, _DATE_BEG, _ID_M_SUBJ, _Phone, _OKONH, _OKPO, _Comment, _Site, _Deal, _SOOGU, _SOATO, _KFS, _KOPF, IF(_ID_M_GEOCOUNTRY_RSD=0,Null,_ID_M_GEOCOUNTRY_RSD), IF(_ID_M_GEOCOUNTRY=0,Null,_ID_M_GEOCOUNTRY),_ID_M_GEO,IF(_ID_M_GEOLOCATIONS=0,Null,_ID_M_GEOLOCATIONS), _INNControl, _FAddress, _FAddressEng, _FPhone, _IsCustom, _KPP, _OKED, _DOpen);
      SELECT
        LAST_INSERT_ID() INTO _ID_M_ENT;
#          CALL global_db.add_rec_info(_ID_M_ENT, 'm_entity', 'CREATE', _UserId); 
    ELSE
      UPDATE global_db.m_entity
      SET NameOrg = _NameOrg,
          LatName = _NameOrgEng,
          Short = _Short,
          Prefix = _Prefix,
          Address = _Address,
          Fax = _Fax,
          EMail = _EMail,
          Phone = _Phone,
          DATE_BEG = _DATE_BEG,
          OKONH = _OKONH,
          OKPO = _OKPO,
          Comment = _Comment,
          Site = _Site,
          Deal = _Deal,
          SOOGU = _SOOGU,
          SOATO = _SOATO,
          KFS = _KFS,
          KOPF = _KOPF,
          ID_M_GEOCOUNTRY = IF(_ID_M_GEOCOUNTRY=0,Null,_ID_M_GEOCOUNTRY),
          ID_M_GEOCOUNTRY_RSD = IF(_ID_M_GEOCOUNTRY_RSD=0,Null,_ID_M_GEOCOUNTRY_RSD),
          ID_M_GEO = _ID_M_GEO,
          ID_M_GEOLOCATIONS = If(_ID_M_GEOLOCATIONS=0,Null,_ID_M_GEOLOCATIONS),
          INNControl = _INNControl,
          FAddress = _FAddress,
          LatAddr = _FAddressEng,
          FPhone = _FPhone,
          IsCustom = _IsCustom,
          KPP = _KPP,
          OKED = _OKED,
          DOpen = _DOpen
      WHERE ID_M_ENT = _ID_M_ENT;
#        CALL global_db.add_rec_info(_ID_M_ENT, 'm_entity', 'EDIT', _UserId); 
    END IF;
    --
    --   SELECT Count(ID_ENT_SIGN) INTO signatoryCount FROM m_entity_signing WHERE ID_M_SUBJ=_ID_M_SUBJ;
    --   IF IFNULL(signatoryCount,0)=0 THEN
    --     IF (LENGTH(_Headname)>0 AND _Headname IS NOT NULL) THEN
    --       INSERT INTO m_entity_signing
    --         (TYPE_SIGN, POST_SIGN, NAME_SIGN, ONBASE_SIGN, IS_MAIN_SIGN, ID_M_SUBJ)
    --         VALUES (0, _Post, _Headname, _OnBase, 1, _ID_M_SUBJ);
    --       SELECT LAST_INSERT_ID() INTO _SignatoryHeadId;
    --       CALL add_m_rec_info(_SignatoryHeadId, 'm_entity_signing', 'CREATE', _UserId);
    --     END IF;
    --     IF (LENGTH(_AccounterName)>0 AND _AccounterName IS NOT NULL) THEN
    --       INSERT INTO m_entity_signing
    --         (TYPE_SIGN, POST_SIGN, NAME_SIGN, ONBASE_SIGN, IS_MAIN_SIGN, ID_M_SUBJ)
    --         VALUES (1, _Post, _Headname, _OnBase, 1, _ID_M_SUBJ);
    --       SELECT LAST_INSERT_ID() INTO _SignatoryAccounterId;
    --       CALL add_m_rec_info(_SignatoryAccounterId, 'm_entity_signing', 'CREATE', _UserId);
    --     END IF;
    --   ELSE
    IF IFNULL(_SignatoryHeadId, 0) > 0 THEN
      UPDATE global_db.m_entity_signing
      SET IS_MAIN_SIGN = 0
      WHERE ID_M_SUBJ = _ID_M_SUBJ
      AND TYPE_SIGN = 0
      AND IS_MAIN_SIGN = 1;
      UPDATE global_db.m_entity_signing
      SET IS_MAIN_SIGN = 1,
          POST_SIGN = _Post,
          ONBASE_SIGN = _OnBase,
          NAME_SIGN = _Headname
      WHERE ID_ENT_SIGN = _SignatoryHeadId;
      -- CALL refers.add_m_rec_info(_SignatoryHeadId, 'm_entity_signing', 'EDIT', _UserId);
            -- CALL refers.add_m_rec_info(_SignatoryHeadId, 'm_entity_signing', 'EDIT', _UserId);
    --     ELSE
    --       SELECT ID_ENT_SIGN INTO _SignatoryHeadId FROM m_entity_signing
    --         WHERE ID_M_SUBJ=_ID_M_SUBJ AND TYPE_SIGN=0 AND IS_MAIN_SIGN=1 LIMIT 1;
    --       UPDATE m_entity_signing
    --         SET POST_SIGN=_Post, ONBASE_SIGN=_OnBase, NAME_SIGN=_Headname
    --         WHERE ID_ENT_SIGN=_SignatoryHeadId;
    --       CALL add_m_rec_info(_SignatoryHeadId, 'm_entity_signing', 'EDIT', _UserId);
    END IF;

    IF IFNULL(_SignatoryAccounterId, 0) > 0 THEN
      UPDATE global_db.m_entity_signing
      SET IS_MAIN_SIGN = 0
      WHERE ID_M_SUBJ = _ID_M_SUBJ
      AND TYPE_SIGN = 1
      AND IS_MAIN_SIGN = 1;
      UPDATE global_db.m_entity_signing
      SET IS_MAIN_SIGN = 1,
          NAME_SIGN = _AccounterName
      WHERE ID_ENT_SIGN = _SignatoryAccounterId;
      -- CALL refers.add_m_rec_info(_SignatoryAccounterId, 'm_entity_signing', 'EDIT', _UserId);
    --     ELSE
    --       SELECT ID_ENT_SIGN INTO _SignatoryAccounterId FROM m_entity_signing
    --         WHERE ID_M_SUBJ=_ID_M_SUBJ AND TYPE_SIGN=1 AND IS_MAIN_SIGN=1 LIMIT 1;
    --       UPDATE m_entity_signing
    --         SET NAME_SIGN=_AccounterName
    --         WHERE ID_ENT_SIGN=_SignatoryAccounterId;
    --       CALL add_m_rec_info(_SignatoryAccounterId, 'm_entity_signing', 'EDIT', _UserId);
    END IF;
    SET _ID_M_ENT = _ID_M_SUBJ;
  COMMIT;
END
