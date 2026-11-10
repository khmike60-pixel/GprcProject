CREATE DEFINER=`bookkeep`@`%` PROCEDURE `cwatis`.`DocumentType_GetBranch`(in Code VARCHAR(250))
begin
	DECLARE  Id INT;

	-- 1. Находим ID элемента по его текстовому коду
    SELECT t.`DocumentType_Id` INTO Id
    FROM cwatis.`documenttypes` t
    WHERE 1 = 1
    	and (IFNULL(Code, "") = "" OR t.`DocumentType_Code` = Code) -- Замените на ваше точное название поля кода, если оно отличается
    limit 1;

    -- 2. Если код найден, выбираем всю ветку. Если код "" или null, то весь список 
    select
      	t.*, p.DocumentType_Name as ParentName
    FROM cwatis.`documenttypes` t
    	left join cwatis.`documenttypes` p on p.DocumentType_Id = t.ParentId 
    where 1 = 1
    	and ((ifNULL(Code,"") = "" OR t.`DocumentType_Code` = Code)
    		or (ifNULL(Id,0) = 0 or FIND_IN_SET(CAST(Id AS CHAR), t.`ids`))) > 0
    ORDER BY t.Parents ASC;
END