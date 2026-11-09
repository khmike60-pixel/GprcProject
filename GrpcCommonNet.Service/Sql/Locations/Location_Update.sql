CREATE DEFINER=`bookkeep`@`%` PROCEDURE `global_db`.`Location_Update`(
    IN p_id INT,				-- идентификатор редактируемой записи
    IN p_target_parentId INT,	-- идентификатор нового родителя
    IN p_new_name VARCHAR(255),	-- новое имя записи
    IN p_data VARCHAR(500)		-- дополнительное поле 
)
    MODIFIES SQL DATA
BEGIN
    -- Переменные для хранения старых значений на случай валидации
    DECLARE v_current_parentId INT;
    DECLARE v_is_loop INT DEFAULT 0;

    -- Извлекаем текущего родителя для проверки
    SELECT GeoLocation_ParentId INTO v_current_parentId
    FROM geolocations
    WHERE GeoLocation_Id = p_id;

    -- =========================================================================
    -- ИСПРАВЛЕННАЯ ВАЛИДАЦИЯ: Проверка на циклы через рекурсивный подъем вверх
    -- =========================================================================
    IF p_target_parentId IS NOT NULL AND p_target_parentId <> 0 AND p_target_parentId <> COALESCE(v_current_parentId, 0) THEN
        -- 1. Проверка: Нельзя назначить запись родителем самой себе
        IF p_id = p_target_parentId THEN
            SIGNAL SQLSTATE '45000' 
            SET MESSAGE_TEXT = 'Ошибка: Нельзя назначить локацию родителем самой себе.';
        END IF;

        -- 2. Проверка: Поднимаемся от нового родителя к корню. 
        -- Если по пути встретим p_id — значит, новый родитель является потомком текущего узла.
        WITH RECURSIVE parent_search AS (
            -- Якорь: начинаем с нового целевого родителя
            SELECT GeoLocation_Id, GeoLocation_ParentId
            FROM geolocations
            WHERE GeoLocation_Id = p_target_parentId
            
            UNION ALL
            
            -- Шаг: поднимаемся к его родителю
            SELECT p.GeoLocation_Id, p.GeoLocation_ParentId
            FROM geolocations p
            INNER JOIN parent_search ps ON ps.GeoLocation_ParentId = p.GeoLocation_Id
        )
        SELECT COUNT(*) INTO v_is_loop
        FROM parent_search
        WHERE GeoLocation_Id = p_id;

        -- Если нашли совпадение, значит это незаконная циклическая ссылка (петля)
        IF v_is_loop > 0 THEN
            SIGNAL SQLSTATE '45000' 
            SET MESSAGE_TEXT = 'Ошибка: Новый родитель является потомком обновляемой локации. Это вызовет закольцовывание дерева.';
        END IF;
    END IF;

    -- =========================================================================
    -- ШАГ 1: Обновление базовых полей самой изменяемой записи
    -- =========================================================================
    UPDATE geolocations
    SET 
        GeoLocation_ParentId = CASE 
            WHEN p_target_parentId IS NULL OR p_target_parentId = 0 THEN GeoLocation_ParentId 
            ELSE p_target_parentId 
        END,
        GeoLocation_Name = CASE 
            WHEN p_new_name IS NULL OR p_new_name = '' THEN GeoLocation_Name 
            ELSE p_new_name 
        END,
        Geolocation_Data = CASE 
            WHEN p_data IS NULL OR p_data = '' THEN Geolocation_Data
            ELSE p_data
        END
    WHERE GeoLocation_Id = p_id;

    -- =========================================================================
    -- ШАГ 2: Подготовка путей НОВОГО родителя
    -- =========================================================================
    SET @parent_ids = '';
    SET @parent_names = '';

    SELECT 
        COALESCE(p.GeoLocation_Ids, ''), 
        COALESCE(p.GeoLocation_Names, '')
    INTO @parent_ids, @parent_names
    FROM geolocations t
    LEFT JOIN geolocations p ON t.GeoLocation_ParentId = p.GeoLocation_Id
    WHERE t.GeoLocation_Id = p_id;

    -- =========================================================================
    -- ШАГ 3: Рекурсивный пересчет путей (Ids и Names) для записи и ее потомков
    -- =========================================================================
    WITH RECURSIVE hierarchy AS (
        -- Якорь: вычисляем путь для стартового изменяемого элемента
        SELECT 
            t.GeoLocation_Id,
            t.GeoLocation_ParentId,
            TRIM(BOTH ',' FROM CONCAT_WS(',', NULLIF(@parent_ids, ''), t.GeoLocation_Id)) AS New_Ids,
            -- Обратите внимание: TRIM удаляет одиночные пробелы и слэши по краям ' / '
            TRIM(BOTH ' / ' FROM CONCAT_WS(' / ', NULLIF(@parent_names, ''), t.GeoLocation_Name)) AS New_Names
        FROM geolocations t
        WHERE t.GeoLocation_Id = p_id
        
        UNION ALL
        
        -- Шаг рекурсии: спускаемся ко всем детям по цепочке вниз
        SELECT 
            child.GeoLocation_Id,
            child.GeoLocation_ParentId,
            TRIM(BOTH ',' FROM CONCAT_WS(',', parent.New_Ids, child.GeoLocation_Id)) AS New_Ids,
            TRIM(BOTH ' / ' FROM CONCAT_WS(' / ', parent.New_Names, child.GeoLocation_Name)) AS New_Names
        FROM geolocations child
        INNER JOIN hierarchy parent ON child.GeoLocation_ParentId = parent.GeoLocation_Id
    )
    -- Массово обновляем рассчитанные пути во всей ветке таблицы
    UPDATE geolocations g
    INNER JOIN hierarchy h ON g.GeoLocation_Id = h.GeoLocation_Id
    SET 
        g.GeoLocation_Ids = h.New_Ids,
        g.GeoLocation_Names = h.New_Names;
        
    -- Возвращаем итоговое состояние отредактированной записи
    SELECT * FROM geolocations g
    WHERE g.GeoLocation_Id = p_id;

END