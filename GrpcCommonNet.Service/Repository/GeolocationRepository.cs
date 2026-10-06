using Google.Protobuf;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Geolocation;
using GrpcCommonNet.Service.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

public class GeolocationRepository
{
    private readonly string _connectionString;
    private readonly ILogger<GeolocationRepository> _logger;

    public GeolocationRepository(ILogger<GeolocationRepository> logger, IConfiguration configuration)
    {
        _logger = logger;
        _connectionString = configuration.GetConnectionString("MySql");
    }

    #region Методы получения  данных 

    public async Task<Geolocation?> GetByIdAsync(long id)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = $@"SELECT * FROM global_db.geolocations g where g.GeoLocation_Id = {id}";
            using var rdr = await cmd.ExecuteReaderAsync();
            Geolocation geo = new Geolocation();
            if (await rdr.ReadAsync())
                geo = Fill(rdr);
            return geo;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в GetByIdAsync: " + ex.Message);
        }
    }

    public async Task<List<Geolocation>> GetTreeGeoAsync(TreeGeoRequest request, UserData userData)
    {
        List<Geolocation> geoTree = new List<Geolocation>();
        try
        {
            bool onlyCountry = false;
            if (request.GeoType != null && request.GeoType == GeoType.Country) onlyCountry = true;
            
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = 
                $@"
                    SELECT 
                        g.* , p.GeoLocation_Name as ParentName
                    FROM global_db.geolocations g 
                        left join global_db.geolocations p on p.GeoLocation_Id = g.Geolocation_ParentId
                    where 1 = 1
                        and if({onlyCountry}, if(g.GeoLocation_IsCountry = 1, true, false), true)
                        and g.GeoLocation_Names like CONCAT('%', @name, '%')
                    order by g.GeoLocation_Names
                ";
            cmd.Parameters.AddWithValue("@name", request.Name);

            using var rdr = await cmd.ExecuteReaderAsync();
            while (await rdr.ReadAsync())
            {
                geoTree.Add(Fill(rdr));
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в GetTreeGeoAsync: " + ex.Message);
        }

        return geoTree;
    }

    public async Task<List<Geolocation>> GetListCountryAsync(string name = "")
    {
        List<Geolocation> geoTree = new List<Geolocation>();
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = $@"
                SELECT * FROM global_db.geolocations g 
                where 1 = 1 
                    and g.GeoLocation_IsCountry = 1 
                    and g.g.GeoLocation_Name like CONCAT('%',@name,'%')
                order by g.GeoLocation_Names";
            cmd.Parameters.AddWithValue("@name", name);

            using var rdr = await cmd.ExecuteReaderAsync();
            while (await rdr.ReadAsync())
            {
                geoTree.Add(Fill(rdr));
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в GetListCountryAsync: " + ex.Message);
        }
        return geoTree;
    }

    public async Task<Geolocation> CreateGelocationAsync(Geolocation geolocation)
    {
        Geolocation geo = new Geolocation();
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            // Вставляем данные
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = $@"
                INSERT INTO global_db.geolocations 
                (
                    GeoLocation_Name, 
                    GeoLocation_NameLat,
                    GeoLocation_MCode,
                    GeoLocation_ParentId, 
                    GeoLocation_IsCountry,
                    GeoLocation_Code2, 
                    GeoLocation_JsonCodes,
                    GeoLocation_PhoneCode
                )
                VALUE (
                    @Name,                     
                    @NameLat,
                    @MCode,
                    IF(IFNULL(@ParentId,0)=0,null,@ParentId),
                    @IsCountry,
                    @Code2,
                    @JsonCode,
                    @PhoneCode
                );

                with Parent as
                (
	                select p.Geolocation_Ids as Ids, p.Geolocation_Names as Names, p.Geolocation_id as Id
	                from global_db.geolocations g
                		left join global_db.geolocations p on p.Geolocation_Id = g.Geolocation_ParentId
	                where g.Geolocation_Id = LAST_INSERT_ID()
                )
                update global_db.geolocations g
	                join Parent as p on p.Id = Geolocation_ParentId
                set g.Geolocation_Ids   = CONCAT(IF(p.Ids   is null,'',CONCAT(p.Ids,    ',')), Geolocation_Id),
	                g.Geolocation_Names = CONCAT(IF(p.Names is null,'',CONCAT(p.Names,' / ')), Geolocation_Name)
                where g.GeoLocation_Id = LAST_INSERT_ID();
                    
                SELECT * FROM global_db.geolocations g where g.GeoLocation_Id = LAST_INSERT_ID();
                ";

                cmd.Parameters.AddWithValue("@Name", geolocation.Name);
                cmd.Parameters.AddWithValue("@NameLat", geolocation.NameLat);
                cmd.Parameters.AddWithValue("@MCode", geolocation.Name );
                cmd.Parameters.AddWithValue("@ParentId", geolocation.ParentId);
                cmd.Parameters.AddWithValue("@IsCountry", geolocation.IsCountry);
                cmd.Parameters.AddWithValue("@Code2", geolocation.IsCountry == 1? geolocation.Code2: "");

                // Записываем Json
                var jsonValue = geolocation.CountryJson ?? geolocation.CountryJson;
                var parameter = new MySqlParameter("@JsonCode", MySqlDbType.JSON);
                parameter.Value = (object)jsonValue ?? DBNull.Value;
                cmd.Parameters.Add(parameter);

                cmd.Parameters.AddWithValue("@PhoneCode", geolocation.PhoneCode);

                using var rdr = await cmd.ExecuteReaderAsync();
                do
                {
                    if (await rdr.ReadAsync())
                    {
                        geo = Fill(rdr);
                        break;
                    }
                } while (await rdr.NextResultAsync());

            }
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в CreateGelocationAsync: " + ex.Message);
        }

        return geo;
    }

    public async Task<Geolocation> UpdateGeolocationAsync(Geolocation geolocation)
    {
        Geolocation geo = new Geolocation();
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            string new_parent_names_path = String.Empty;
            string new_parent_ids_path = String.Empty;

            // Определение нового родителя
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = $@"SELECT g.GeoLocation_Names, g.GeoLocation_Ids from global_db.geolocations g where g.GeoLocation_Id = {geolocation.ParentId}";
                using var rdr = await cmd.ExecuteReaderAsync();
                if (await rdr.ReadAsync())
                {
                    new_parent_names_path = rdr["GeoLocation_Names"] == DBNull.Value ? string.Empty : rdr["GeoLocation_Names"].ToString();
                    new_parent_ids_path = rdr["GeoLocation_Ids"] == DBNull.Value ? string.Empty : rdr["GeoLocation_Ids"].ToString();
                }
            }
            // Обновляем даные 
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = $@"
                WITH RECURSIVE Subtree AS (
                -- Базовый случай: сам перемещаемый узел
                    SELECT
                        t.Geolocation_Id id,
                        t.Geolocation_ParentId parent_id,
                        t.Geolocation_Name as old_name,
                        @new_node_name AS new_name, -- Используем новое заданное имя
                -- Формируем новый путь ID: путь_нового_родителя + ',' + id
                        if(IFNULL(@new_parent_id,0) = 0, @moved_node_id, CONCAT(@new_parent_ids_path, ',', CAST(t.Geolocation_id AS CHAR))) AS new_ids_path,
                -- Формируем новый путь ИМЕН: путь_нового_родителя_имен + ',' + новое_имя
                        if(IFNULL(@new_parent_id,0) = 0, t.Geolocation_Name, CONCAT(@new_parent_names_path, ' / ', @new_node_name)) AS new_names_path
                        FROM
                            global_db.geolocations t
                        WHERE
                            t.Geolocation_Id = @moved_node_id

                    UNION ALL

                -- Рекурсивная часть: все потомки
                    SELECT
                        g.Geolocation_id,
                        g.Geolocation_parentid,
                        g.Geolocation_name AS old_name,
                        g.Geolocation_name AS new_name, -- Для потомков имя не меняется, берем текущее
                        -- Используем путь ID родителя из предыдущего шага CTE
                        CONCAT(s.new_ids_path, ',', CAST(g.Geolocation_id AS CHAR)) AS new_ids_path,
                -- Используем путь ИМЕН родителя из предыдущего шага CTE
                        CONCAT(s.new_names_path, ' / ', g.Geolocation_name) AS new_names_path
                        FROM
                            global_db.geolocations g
                            INNER JOIN
                                Subtree s ON g.Geolocation_parentid = s.id
                )
                -- 3. Обновляем таблицу, используя данные из CTE
                UPDATE global_db.geolocations AS g
                    JOIN Subtree AS s ON g.Geolocation_id = s.id
                    SET
                        g.Geolocation_ids = s.new_ids_path,
                        g.Geolocation_names = s.new_names_path,
                -- Обновляем собственное имя (только для корневого узла перемещения, если оно новое)
                        g.Geolocation_name = s.new_name,
                -- Обновляем parent_id для корневого узла перемещаемого поддерева
                        g.Geolocation_parentid = CASE WHEN g.Geolocation_id = @moved_node_id THEN @new_parent_id ELSE g.Geolocation_parentid END
                    WHERE
                        g.Geolocation_Id IN (SELECT id FROM Subtree);
    
                select * from global_db.geolocations AS g where g.GeoLocation_Id = @moved_node_id;";

                cmd.Parameters.AddWithValue("@new_parent_names_path", new_parent_names_path);
                cmd.Parameters.AddWithValue("@new_parent_ids_path", new_parent_ids_path);

                cmd.Parameters.AddWithValue("@moved_node_id", geolocation.Id);
                cmd.Parameters.AddWithValue("@new_parent_id", geolocation.ParentId > 0 ? geolocation.ParentId : null);
                cmd.Parameters.AddWithValue("@new_node_name", geolocation.Name);

                cmd.Parameters.AddWithValue("@code2", geolocation.Code2);
                cmd.Parameters.AddWithValue("@nameLat", geolocation.NameLat);

                if (geolocation.CountryJson != null)
                    cmd.Parameters.AddWithValue("@jsonCodes", geolocation.CountryJson);
                else if (geolocation.RegionJson != null)
                    cmd.Parameters.AddWithValue("@jsonCodes", geolocation.RegionJson);
                else
                    cmd.Parameters.AddWithValue("@jsonCodes", string.Empty);


                cmd.Parameters.AddWithValue("@phoneCode", geolocation.PhoneCode);
                cmd.Parameters.AddWithValue("@lock", geolocation.Lock);

                using var rdr = await cmd.ExecuteReaderAsync();
                if (await rdr.ReadAsync())
                {
                    geo = Fill(rdr);
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в CreateGelocationAsync: " + ex.Message);
        }

        return geo;

    }

    #endregion

    #region  Внутренние методы
    public Geolocation Fill(DbDataReader rdr)
    {
        Geolocation geo = new Geolocation();

        geo.Id = Convert.ToInt32(rdr["GeoLocation_Id"]);
        
        geo.ParentId = rdr["GeoLocation_ParentId"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["GeoLocation_ParentId"]);
        geo.Parent = new Geolocation()
        {
            ParentId = geo.ParentId
        };
        geo.Parent.Name = rdr["ParentName"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["ParentName"]);
        geo.Ids = rdr["GeoLocation_Ids"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["GeoLocation_Ids"]);
        geo.Names = rdr["GeoLocation_Names"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["GeoLocation_Names"]);
        geo.Name = rdr["GeoLocation_Name"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["GeoLocation_Name"]);
        geo.IsCountry  = rdr["GeoLocation_IsCountry"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["GeoLocation_IsCountry"]);
        geo.Code2 = rdr["GeoLocation_Code2"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["GeoLocation_Code2"]);
        geo.NameLat = rdr["GeoLocation_NameLat"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["GeoLocation_NameLat"]);
        geo.PhoneCode = rdr["GeoLocation_PhoneCode"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["GeoLocation_PhoneCode"]);

        int geoOrdinal = rdr.GetOrdinal("GeoLocation_JsonCodes");

        // Создаем один экземпляр парсера gRPC с флагом игнорирования неизвестных полей (на случай будущих изменений JSON)
        var grpcJsonParser = new JsonParser(JsonParser.Settings.Default.WithIgnoreUnknownFields(true));

        if (geo.IsCountry == 1)
        {
            geo.CountryJson = rdr.IsDBNull(geoOrdinal)
                ? null
                : grpcJsonParser.Parse<CountryJson>(rdr.GetString(geoOrdinal));
        }
        else if (geo.IsCountry == 0)
        {
            geo.RegionJson = rdr.IsDBNull(geoOrdinal)
                ? null
                : grpcJsonParser.Parse<RegionJson>(rdr.GetString(geoOrdinal));
        }
        else
        {
            geo.CountryJson = null;
        }

        geo.Lock = rdr["GeoLocation_Lock"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["GeoLocation_Lock"]);

        return geo;
    }

    #endregion


    #region Тестовый пример обновления в иерархии

    public async Task UpdateGeoLocationWithChildrenAsync(int geoLocationId, string newIds, string newNames)
    {
        using var connection = new MySqlConnection(_connectionString);
        await connection.OpenAsync();

        // Запускаем транзакцию, чтобы оба обновления выполнились как неделимая операция
        using var transaction = await connection.BeginTransactionAsync(IsolationLevel.RepeatableRead);

        try
        {
            // ШАГ 1: Получаем СТАРЫЕ значения (аналог OLD в триггере)
            string selectSql = @"
            SELECT GeoLocation_Ids, GeoLocation_Names 
            FROM geolocations 
            WHERE GeoLocation_Id = @id 
            FOR UPDATE;"; // FOR UPDATE блокирует строку от изменений другими пользователями

            string oldIds = "";
            string oldNames = "";

            using (var selectCmd = new MySqlCommand(selectSql, connection, transaction))
            {
                selectCmd.Parameters.AddWithValue("@id", geoLocationId);
                using var reader = await selectCmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    oldIds = reader.GetString("GeoLocation_Ids");
                    oldNames = reader.GetString("GeoLocation_Names");
                }
                else
                {
                    throw new Exception($"Локация с ID {geoLocationId} не найдена.");
                }
            }

            // ШАГ 2: Обновляем целевую запись (то, что запускало триггер)
            string updateCurrentSql = @"
            UPDATE geolocations 
            SET GeoLocation_Ids = @newIds, 
                GeoLocation_Names = @newNames 
            WHERE GeoLocation_Id = @id;";

            using (var cmd1 = new MySqlCommand(updateCurrentSql, connection, transaction))
            {
                cmd1.Parameters.AddWithValue("@id", geoLocationId);
                cmd1.Parameters.AddWithValue("@newIds", newIds);
                cmd1.Parameters.AddWithValue("@newNames", newNames);
                await cmd1.ExecuteNonQueryAsync();
            }

            // ШАГ 3: Каскадно обновляем дочерние записи (код из вашего триггера)
            string updateChildrenSql = @"
            UPDATE geolocations
            SET GeoLocation_Ids = REPLACE(GeoLocation_Ids, @oldIds, @newIds),
                GeoLocation_Names = REPLACE(GeoLocation_Names, @oldNames, @newNames)
            WHERE LOCATE(CONCAT(',', GeoLocation_Id, ','), CONCAT(',', GeoLocation_Ids, ',')) > 0
              AND GeoLocation_Id <> @id;";

            using (var cmd2 = new MySqlCommand(updateChildrenSql, connection, transaction))
            {
                cmd2.Parameters.AddWithValue("@id", geoLocationId);
                cmd2.Parameters.AddWithValue("@oldIds", oldIds);
                cmd2.Parameters.AddWithValue("@newIds", newIds);
                cmd2.Parameters.AddWithValue("@oldNames", oldNames);
                cmd2.Parameters.AddWithValue("@newNames", newNames);

                await cmd2.ExecuteNonQueryAsync();
            }

            // Если всё прошло успешно — фиксируем транзакцию в БД
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            // Если произошла ошибка (сбой сети, deadlock и т.д.) — откатываем все изменения
            await transaction.RollbackAsync();
            // Логируем ошибку или пробрасываем её выше
            Console.WriteLine($"Ошибка при обновлении геолокаций: {ex.Message}");
            throw;
        }
    }


    #endregion
}
