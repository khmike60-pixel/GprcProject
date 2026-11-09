CREATE DEFINER=`bookkeep`@`%` PROCEDURE `global_db`.`Location_Insert`(
    IN p_parent_id INT,          -- идентификатор родителя (может быть NULL или 0 для корня)
    IN p_name VARCHAR(255),      -- наименование новой локации
    IN p_data JSON               -- дополнительные данные в формате JSON
)
    MODIFIES SQL DATA
BEGIN
    DECLARE v_new_id INT;

    -- 1. Вставляем запись с базовыми параметрами. 
    -- Если p_parent_id передан как 0, преобразуем его в NULL (для корневых элементов)
    INSERT INTO geolocations (
        GeoLocation_ParentId, 
        GeoLocation_Name, 
        Geolocation_Data
    )
    VALUES (
        IF(p_parent_id = 0, NULL, p_parent_id), 
        p_name, 
        p_data
    );

    -- 2. Получаем автоматически сгенерированный ID только что вставленной записи
    SET v_new_id = LAST_INSERT_ID();

    -- 3. Формируем пути Ids и Names на основе родительских данных и обновляем запись.
    -- Используем CONCAT_WS и TRIM(BOTH), чтобы пути не содержали лишних знаков по краям
    UPDATE geolocations t
    LEFT JOIN geolocations p ON t.GeoLocation_ParentId = p.GeoLocation_Id
    SET 
        t.GeoLocation_Ids = TRIM(BOTH ',' FROM CONCAT_WS(',', NULLIF(p.GeoLocation_Ids, ''), v_new_id)),
        t.GeoLocation_Names = TRIM(BOTH ' / ' FROM CONCAT_WS(' / ', NULLIF(p.GeoLocation_Names, ''), t.GeoLocation_Name))
    WHERE t.GeoLocation_Id = v_new_id;

    -- 4. Возвращаем бэкенду полную созданную запись с уже выстроенными путями
    SELECT * 
    FROM geolocations 
    WHERE GeoLocation_Id = v_new_id;

END
