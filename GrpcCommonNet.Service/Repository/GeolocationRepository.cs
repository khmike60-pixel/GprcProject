using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Geolocation;
using MySql.Data.MySqlClient;
using System.Data.Common;
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

    #region Методы получения  данных  о приложениях

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

    public async Task<List<Geolocation>> GetTreeGeoAsync(long id)
    {
        List<Geolocation> geoTree = new List<Geolocation>();
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = $@"SELECT * FROM global_db.geolocations g where g.GeoLocation_Id >= {id} order by g.GeoLocation_Names";
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

            string parentNames = String.Empty;
            string parentIds = String.Empty;

            // Определение родителя
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = $@"SELECT g.GeoLocation_Names, g.GeoLocation_Ids from global_db.geolocations g where g.GeoLocation_Id = {geolocation.ParentId}";
                using var rdr = await cmd.ExecuteReaderAsync();
                if (await rdr.ReadAsync())
                {
                    parentNames = rdr["GeoLocation_Names"] == DBNull.Value ? string.Empty : rdr["GeoLocation_Names"].ToString();
                    parentIds = rdr["GeoLocation_Ids"] == DBNull.Value ? string.Empty : rdr["GeoLocation_Ids"].ToString();
                }
            }
            // Вставляем данные
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = $@"
                INSERT INTO global_db.geolocations (
                    GeoLocation_ParentId, 
                    GeoLocation_IsCountry,
                    GeoLocation_Name, 
                    GeoLocation_Ids, GeoLocation_Names
                    )
                    VALUE (
                    IF(IFNULL(@ParentId,0)=0,null,@ParentId),
                    IF(IFNULL(@ParentId,0)=0,1,0),
                    @Name, 
                    @Ids, @parentNames);
                    
                UPDATE global_db.geolocations  
                    set 
                        GeoLocation_Ids = IF(IFNULL(GeoLocation_Ids,'')='',CONCAT(LAST_INSERT_ID()),CONCAT(GeoLocation_Ids,',',GeoLocation_Id)),
                        GeoLocation_Names = if(IFNULL(GeoLocation_Names,'')= '',GeoLocation_Name, CONCAT(GeoLocation_Names,' / ',GeoLocation_Name))
                    where GeoLocation_Id = LAST_INSERT_ID();
                SELECT * FROM global_db.geolocations g where g.GeoLocation_Id = LAST_INSERT_ID();";
                cmd.Parameters.AddWithValue("@ParentId", geolocation.ParentId);
                cmd.Parameters.AddWithValue("@Name", geolocation.Name);
                cmd.Parameters.AddWithValue("@Names", geolocation.Names);
                cmd.Parameters.AddWithValue("@Ids", parentIds);
                cmd.Parameters.AddWithValue("@parentNames", parentNames);

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
                cmd.Parameters.AddWithValue("@jsonCodes", geolocation.JsonCodes);
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
        geo.Ids = rdr["GeoLocation_Ids"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["GeoLocation_Ids"]);
        geo.Names = rdr["GeoLocation_Names"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["GeoLocation_Names"]);
        geo.Name = rdr["GeoLocation_Name"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["GeoLocation_Name"]);
        geo.IsCountry  = rdr["GeoLocation_IsCountry"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["GeoLocation_IsCountry"]);
        geo.Code2 = rdr["GeoLocation_Code2"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["GeoLocation_Code2"]);
        geo.NameLat = rdr["GeoLocation_NameLat"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["GeoLocation_NameLat"]);
        geo.PhoneCode = rdr["GeoLocation_PhoneCode"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["GeoLocation_PhoneCode"]);
        geo.JsonCodes = rdr["GeoLocation_JsonCodes"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["GeoLocation_JsonCodes"]);
        geo.Lock = rdr["GeoLocation_Lock"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["GeoLocation_Lock"]);

        return geo;
    }

    #endregion
}
