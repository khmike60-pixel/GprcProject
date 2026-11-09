CREATE DEFINER=`bookkeep`@`%` PROCEDURE `global_db`.`Location_Delete_List`(
    IN p_ids_list VARCHAR(4000) -- Строка с ID через запятую, например: '566,571,580'
)
    MODIFIES SQL DATA
BEGIN
    -- 1. Пытаемся удалить записи из списка. 
    -- Если у записи есть зависимые дети, FOREIGN KEY заблокирует удаление конкретной строки, 
    -- а ключевое слово IGNORE позволит процедуре не упасть и продолжить работу.
    DELETE IGNORE FROM geolocations 
    WHERE FIND_IN_SET(GeoLocation_Id, p_ids_list) > 0;

    -- 2. Возвращаем набор данных, которые НЕ удалось удалить (они всё еще остались в таблице)
    SELECT 
        g.GeoLocation_Id,
        g.GeoLocation_Name,
        g.GeoLocation_Names
    FROM geolocations g
    WHERE FIND_IN_SET(g.GeoLocation_Id, p_ids_list) > 0;

END
