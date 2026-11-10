CREATE DEFINER=`bookkeep`@`%` PROCEDURE `cwatis`.`Contract_Tree_Get`(
	in _Start DATE, 
	in _End DATE, 
	in _WithAgreement bool, 
	in _BuyerId int,
	in _SellerId int
)
begin
	
	WITH RECURSIVE contract_tree AS (
		-- Базовый уровень: корневые контракты (contract_rootid IS NULL)
		SELECT 
			c.contract_id AS node_id,
			c.contract_rootid AS parent_id,
			c.contract_date,
			c.contract_number,
			c.contract_DocName,
			c.contract_BuyerId, 
			c.contract_BuyerName, 
			c.contract_SellerId, 
			c.contract_SellerName,
			c.DocumentType_Id, 
			dt.DocumentType_Code,
			dt.DocumentType_Name,
			dt.DocumentType_Form,
			dt.IsContract,
			c.CurrencyId,
			cu.Abbrev,
			c.sum, 
			c.amount, 
			c.sumvat,
			c.contract_consigneeId, 
			c.contract_consigneeName,
			c.contract_shipperId, 
			c.contract_shipperName,
			c.contract_data, 
			c.ProjectTypes,
			c.Contract_State,
			0 AS tree_level,
			c.contract_id AS root_id,
			c.contract_date AS root_date,
			CAST(c.contract_id AS CHAR(1000)) AS path
		FROM cwatis.contracts c
		LEFT JOIN cwatis.DocumentTypes dt ON c.DocumentType_Id = dt.DocumentType_Id
		LEFT JOIN global_db.rfr_currency cu ON cu.CurrencyId = c.CurrencyId
		WHERE c.contract_rootid IS NULL
			AND c.contract_Date >= _Start 
			AND c.contract_Date <= _End
		
		UNION ALL
		
		-- Рекурсивный уровень: дочерние документы
		SELECT 
			c.contract_id AS node_id,
			c.contract_rootid AS parent_id,
			c.contract_date,
			c.contract_number,
			c.contract_DocName,
			c.contract_BuyerId, 
			c.contract_BuyerName, 
			c.contract_SellerId, 
			c.contract_SellerName,
			c.DocumentType_Id, 
			dt.DocumentType_Code,
			dt.DocumentType_Name,
			dt.DocumentType_Form,
			dt.IsContract,
			c.CurrencyId,
			cu.Abbrev,
			c.sum, 
			c.amount, 
			c.sumvat,
			c.contract_consigneeId, 
			c.contract_consigneeName,
			c.contract_shipperId, 
			c.contract_shipperName,
			c.contract_data, 
			c.ProjectTypes,
			c.Contract_State,
			ct.tree_level + 1 AS tree_level,
			ct.root_id,
			ct.root_date,
			CONCAT(ct.path, '/', c.contract_id) AS path
		FROM contract_tree ct
		INNER JOIN cwatis.contracts c ON c.contract_rootid = ct.node_id
		LEFT JOIN cwatis.DocumentTypes dt ON c.DocumentType_Id = dt.DocumentType_Id
		LEFT JOIN global_db.rfr_currency cu ON cu.CurrencyId = c.CurrencyId
		WHERE ct.tree_level < 10
	),
	-- Определяем типы документов
	typed_tree AS (
		SELECT 
			ct.*,
			CASE 
				-- 1. frame_root: IsContract = false, корневой, есть дети
				WHEN ct.IsContract = 0 
					AND ct.tree_level = 0 
					AND EXISTS (SELECT 1 FROM contract_tree ct2 WHERE ct2.parent_id = ct.node_id)
				THEN 'frame_root'
				
				-- 2. first_contract: IsContract = true, есть дети (независимо от уровня)
				WHEN ct.IsContract = 1 
					AND EXISTS (SELECT 1 FROM contract_tree ct2 WHERE ct2.parent_id = ct.node_id)
				THEN 'first_contract'
				
				-- 3. agreement: есть родитель, который является first_contract
				WHEN ct.parent_id IS NOT NULL 
					AND EXISTS (
						SELECT 1 FROM contract_tree ct2 
						WHERE ct2.node_id = ct.parent_id 
							AND ct2.IsContract = 1
							AND EXISTS (SELECT 1 FROM contract_tree ct3 WHERE ct3.parent_id = ct2.node_id)
					)
				THEN 'agreement'
				
				-- 4. contract_without_agreements: нет детей
				WHEN NOT EXISTS (SELECT 1 FROM contract_tree ct2 WHERE ct2.parent_id = ct.node_id)
				THEN 'contract_without_agreements'
				
				-- 5. Если ничего не подошло
				ELSE 'contract_without_agreements'
			END AS node_type
		FROM contract_tree ct
	),
	-- Находим последнее допсоглашение (agreement) для каждого first_contract
	last_agreements AS (
		SELECT 
			td1.node_id AS first_contract_id,
			td1.root_id,
			td1.root_date,
			td1.parent_id AS first_parent_id,
			td1.contract_date AS first_contract_date,
			td1.contract_number AS first_contract_number,
			td1.contract_DocName AS first_contract_DocName,
			td1.contract_BuyerId AS first_BuyerId,
			td1.contract_BuyerName AS first_BuyerName,
			td1.contract_SellerId AS first_SellerId,
			td1.contract_SellerName AS first_SellerName,
			td1.DocumentType_Id AS first_DocumentType_Id,
			td1.DocumentType_Code AS first_DocumentType_Code,
			td1.DocumentType_Name AS first_DocumentType_Name,
			td1.DocumentType_Form AS first_DocumentType_Form,
			td1.IsContract AS first_IsContract,
			td1.CurrencyId AS first_CurrencyId,
			td1.Abbrev AS first_Abbrev,
			td1.sum AS first_sum,
			td1.amount AS first_amount,
			td1.sumvat AS first_sumvat,
			td1.contract_consigneeId AS first_consigneeId,
			td1.contract_consigneeName AS first_consigneeName,
			td1.contract_shipperId AS first_shipperId,
			td1.contract_shipperName AS first_shipperName,
			td1.contract_data AS first_contract_data,
			td1.ProjectTypes AS first_ProjectTypes,
			td1.Contract_State AS first_Contract_State,
			td1.path AS first_path,
			td1.tree_level AS first_tree_level,
			MAX(td2.contract_date) AS last_agreement_date,
			(SELECT td3.node_id 
			 FROM typed_tree td3 
			 WHERE td3.root_id = td1.root_id 
			   AND td3.node_type = 'agreement'
			   AND td3.parent_id = td1.node_id
			 ORDER BY td3.contract_date DESC, td3.node_id DESC 
			 LIMIT 1) AS last_agreement_id,
			-- Данные последнего допсоглашения для суммы
			(SELECT td3.sum 
			 FROM typed_tree td3 
			 WHERE td3.root_id = td1.root_id 
			   AND td3.node_type = 'agreement'
			   AND td3.parent_id = td1.node_id
			 ORDER BY td3.contract_date DESC, td3.node_id DESC 
			 LIMIT 1) AS last_agreement_sum,
			(SELECT td3.amount 
			 FROM typed_tree td3 
			 WHERE td3.root_id = td1.root_id 
			   AND td3.node_type = 'agreement'
			   AND td3.parent_id = td1.node_id
			 ORDER BY td3.contract_date DESC, td3.node_id DESC 
			 LIMIT 1) AS last_agreement_amount,
			(SELECT td3.sumvat 
			 FROM typed_tree td3 
			 WHERE td3.root_id = td1.root_id 
			   AND td3.node_type = 'agreement'
			   AND td3.parent_id = td1.node_id
			 ORDER BY td3.contract_date DESC, td3.node_id DESC 
			 LIMIT 1) AS last_agreement_sumvat
		FROM typed_tree td1
		INNER JOIN typed_tree td2 ON td1.root_id = td2.root_id
		where 1 = 1 
			and td1.node_type = 'first_contract'
			AND td2.node_type = 'agreement'
			AND td2.parent_id = td1.node_id
		GROUP BY td1.node_id, td1.root_id, td1.root_date,
			td1.parent_id,
			td1.contract_date, td1.contract_number,
			td1.contract_DocName,
			td1.contract_BuyerId, td1.contract_BuyerName,
			td1.contract_SellerId, td1.contract_SellerName,
			td1.DocumentType_Id, td1.DocumentType_Code,
			td1.DocumentType_Name, td1.DocumentType_Form,
			td1.IsContract, td1.CurrencyId, td1.Abbrev,
			td1.sum, td1.amount, td1.sumvat,
			td1.contract_consigneeId, td1.contract_consigneeName,
			td1.contract_shipperId, td1.contract_shipperName,
			td1.contract_data, td1.ProjectTypes,
			td1.Contract_State, td1.path, td1.tree_level
	),
	expanded AS (
		-- 1. FRAME_ROOT - рамочные контракты
		SELECT 
			td.node_id * 1000 + 1 AS node_id,
			NULL AS parent_node_id,
			0 AS tree_level,
			td.root_id AS root_group_id,
			td.root_date,
			'frame_root' AS node_type,
			td.node_id AS contract_id,
			td.parent_id AS contract_rootid,
			td.contract_date,
			td.contract_number,
			td.contract_DocName,
			td.contract_BuyerId, 
			td.contract_BuyerName, 
			td.contract_SellerId, 
			td.contract_SellerName,
			td.DocumentType_Id,
			td.DocumentType_Code,
			td.DocumentType_Name,
			td.DocumentType_Form,
			td.IsContract,
			td.CurrencyId,
			td.Abbrev,
			td.sum, 
			td.amount, 
			td.sumvat,
			td.contract_consigneeId, 
			td.contract_consigneeName,
			td.contract_shipperId, 
			td.contract_shipperName,
			td.contract_data, 
			td.ProjectTypes,
			td.Contract_State,
			td.path,
			td.tree_level AS original_level,
			td.root_id AS sort_id,
			td.contract_date AS sort_date
		FROM typed_tree td
		WHERE 1 = 1 
			and td.node_type = 'frame_root'
--			AND _WithAgreement = 1
		
		UNION ALL
		
		-- 2. ROOT - последнее допсоглашение с данными first_contract
		SELECT 
			la.last_agreement_id * 1000 + 2 AS node_id,
			CASE 
				-- Если first_contract имеет родителя (рамочный контракт)
				WHEN la.first_parent_id IS NOT NULL 
					AND EXISTS (SELECT 1 FROM typed_tree td WHERE td.node_id = la.first_parent_id AND td.node_type = 'frame_root')
				THEN la.first_parent_id * 1000 + 1
				-- Если first_contract не имеет родителя (корневой)
				ELSE NULL
			END AS parent_node_id,
			1 AS tree_level,
			la.root_id AS root_group_id,
			la.root_date,
			'root' AS node_type,
			la.last_agreement_id AS contract_id,
			la.first_contract_id AS contract_rootid,
			la.first_contract_date AS contract_date,
			la.first_contract_number AS contract_number,
			la.first_contract_DocName AS contract_DocName,
			la.first_BuyerId AS contract_BuyerId,
			la.first_BuyerName AS contract_BuyerName,
			la.first_SellerId AS contract_SellerId,
			la.first_SellerName AS contract_SellerName,
			la.first_DocumentType_Id AS DocumentType_Id,
			la.first_DocumentType_Code AS DocumentType_Code,
			la.first_DocumentType_Name AS DocumentType_Name,
			la.first_DocumentType_Form AS DocumentType_Form,
			la.first_IsContract AS IsContract,
			la.first_CurrencyId AS CurrencyId,
			la.first_Abbrev AS Abbrev,
			-- Сумма из последнего допсоглашения
			la.last_agreement_sum AS sum,
			la.last_agreement_amount AS amount,
			la.last_agreement_sumvat AS sumvat,
			la.first_consigneeId AS contract_consigneeId,
			la.first_consigneeName AS contract_consigneeName,
			la.first_shipperId AS contract_shipperId,
			la.first_shipperName AS contract_shipperName,
			la.first_contract_data AS contract_data,
			la.first_ProjectTypes AS ProjectTypes,
			la.first_Contract_State AS Contract_State,
			la.first_path AS path,
			la.first_tree_level AS original_level,
			la.root_id AS sort_id,
			la.last_agreement_date AS sort_date
		FROM last_agreements la
		WHERE 1 = 1
--			and _WithAgreement = 1
			AND la.last_agreement_id IS NOT NULL
		
		UNION ALL
		
		-- 3. AGREEMENT - все допсоглашения (tree_level = 2, как у first_contract)
		SELECT 
			td.node_id * 1000 + 3 AS node_id,
			la.last_agreement_id * 1000 + 2 AS parent_node_id,
			2 AS tree_level,  -- Исправлено: теперь 2, как у first_contract
			td.root_id AS root_group_id,
			td.root_date,
			'agreement' AS node_type,
			td.node_id AS contract_id,
			td.parent_id AS contract_rootid,
			td.contract_date,
			td.contract_number,
			td.contract_DocName,
			td.contract_BuyerId, 
			td.contract_BuyerName, 
			td.contract_SellerId, 
			td.contract_SellerName,
			td.DocumentType_Id,
			td.DocumentType_Code,
			td.DocumentType_Name,
			td.DocumentType_Form,
			td.IsContract,
			td.CurrencyId,
			td.Abbrev,
			td.sum, 
			td.amount, 
			td.sumvat,
			td.contract_consigneeId, 
			td.contract_consigneeName,
			td.contract_shipperId, 
			td.contract_shipperName,
			td.contract_data, 
			td.ProjectTypes,
			td.Contract_State,
			td.path,
			td.tree_level AS original_level,
			td.root_id AS sort_id,
			td.contract_date AS sort_date
		FROM typed_tree td
		INNER JOIN last_agreements la ON td.root_id = la.root_id AND td.parent_id = la.first_contract_id
		WHERE 1 = 1
			and td.node_type = 'agreement'
--			AND _WithAgreement = 1
		
		UNION ALL
		
		-- 4. FIRST_CONTRACT - самостоятельный контракт (tree_level = 2)
		SELECT 
			td.node_id * 1000 + 4 AS node_id,
			la.last_agreement_id * 1000 + 2 AS parent_node_id,
			2 AS tree_level,  -- Исправлено: теперь 2
			td.root_id AS root_group_id,
			td.root_date,
			'first_contract' AS node_type,
			td.node_id AS contract_id,
			td.parent_id AS contract_rootid,
			td.contract_date,
			td.contract_number,
			td.contract_DocName,
			td.contract_BuyerId, 
			td.contract_BuyerName, 
			td.contract_SellerId, 
			td.contract_SellerName,
			td.DocumentType_Id,
			td.DocumentType_Code,
			td.DocumentType_Name,
			td.DocumentType_Form,
			td.IsContract,
			td.CurrencyId,
			td.Abbrev,
			td.sum, 
			td.amount, 
			td.sumvat,
			td.contract_consigneeId, 
			td.contract_consigneeName,
			td.contract_shipperId, 
			td.contract_shipperName,
			td.contract_data, 
			td.ProjectTypes,
			td.Contract_State,
			td.path,
			td.tree_level AS original_level,
			td.root_id AS sort_id,
			td.contract_date AS sort_date
		FROM typed_tree td
		INNER JOIN last_agreements la ON td.node_id = la.first_contract_id
		WHERE 1 = 1
			and td.node_type = 'first_contract'
--			AND _WithAgreement = 1
		
		UNION ALL
		
		-- 5. CONTRACT_WITHOUT_AGREEMENTS - документы без детей
		SELECT 
			td.node_id * 1000 + 5 AS node_id,
			CASE 
				WHEN td.parent_id IS NOT NULL THEN td.parent_id * 1000 + 1
				ELSE NULL
			END AS parent_node_id,
			CASE 
				WHEN td.parent_id IS NOT NULL THEN 1
				ELSE 0
			END AS tree_level,
			td.root_id AS root_group_id,
			td.root_date,
			'contract_without_agreements' AS node_type,
			td.node_id AS contract_id,
			td.parent_id AS contract_rootid,
			td.contract_date,
			td.contract_number,
			td.contract_DocName,
			td.contract_BuyerId, 
			td.contract_BuyerName, 
			td.contract_SellerId, 
			td.contract_SellerName,
			td.DocumentType_Id,
			td.DocumentType_Code,
			td.DocumentType_Name,
			td.DocumentType_Form,
			td.IsContract,
			td.CurrencyId,
			td.Abbrev,
			td.sum, 
			td.amount, 
			td.sumvat,
			td.contract_consigneeId, 
			td.contract_consigneeName,
			td.contract_shipperId, 
			td.contract_shipperName,
			td.contract_data, 
			td.ProjectTypes,
			td.Contract_State,
			td.path,
			td.tree_level AS original_level,
			CASE 
				WHEN td.parent_id IS NOT NULL THEN td.parent_id
				ELSE td.node_id
			END AS sort_id,
			td.contract_date AS sort_date
		FROM typed_tree td
		where 1= 1
			and td.node_type = 'contract_without_agreements'
--			AND _WithAgreement = 1
	)
	SELECT 
		node_id,
		parent_node_id,
		tree_level,
		node_type,
		root_group_id,
		root_date,
		sort_id,
		sort_date,
		path,
		original_level,
		contract_id,
		contract_rootid,
		contract_date,
		contract_number,
		contract_DocName,
		contract_BuyerId, 
		contract_BuyerName, 
		contract_SellerId, 
		contract_SellerName,
		DocumentType_Id,
		DocumentType_Code,
		DocumentType_Name,
		DocumentType_Form,
		IsContract,
		CurrencyId,
		Abbrev,
		sum, 
		amount, 
		sumvat,
		contract_consigneeId, 
		contract_consigneeName,
		contract_shipperId, 
		contract_shipperName,
		contract_data, 
		ProjectTypes,
		Contract_State
	FROM expanded
	where 1 = 1
		and (_WithAgreement = 1 or node_type in ('contract_without_agreements', 'frame_root', 'root'))
		and (ifnull(_BuyerId, 0) = 0 or _BuyerId = contract_BuyerId)
		and (ifnull(_SellerId, 0) = 0 or _SellerId = contract_SellerId)
	ORDER BY 
		root_date DESC,
		sort_id,
		tree_level,
		sort_date DESC;
	
END