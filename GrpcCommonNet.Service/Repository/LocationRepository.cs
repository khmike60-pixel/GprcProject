using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Location;
using GrpcCommonNet.Service.Models;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace GrpcCommonNet.Service.Repository
{
    public class LocationRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<LocationRepository> _logger;

        public LocationRepository(ILogger<LocationRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("MySql");
        }

        #region Методы работы с Location (страны, города, регионы, ..., склады, ..., полки

        public async Task<Location> GetLocationAsync(LocationRequest request, UserData userData)
        {
            try
            {
                Location location = new Location();

                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = $@"SELECT * FROM global_db.geolocations g where g.GeoLocation_Id = {request.Id}";
                using var rdr = await cmd.ExecuteReaderAsync();

                request.FieldMask.Merge(FillLocation(rdr), location);

                return location;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в GetLocationAsync: " + ex.Message);
            }
        }

        public async Task<List<Location>> ListLocationAsync(ListLocationRequest request, UserData userData)
        {
            try
            {
                List<Location> locations = new List<Location>();

                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $@"
                with recursive matched as (
		            select
			            g.`GeoLocation_Id`,
			            g.`GeoLocation_ParentId`
		            from global_db.geolocations g
		            where 1 = 1
			            and g.Geolocation_Type = @type
			            and g.`GeoLocation_Name` like CONCAT('%', @string, '%')
                ),
                ancestors as (
	                select
			            m.`GeoLocation_Id` as id,
			            m.`GeoLocation_ParentId` as pid
		            from matched m
		            union
		            select
			            g.`GeoLocation_Id`,
			            g.`GeoLocation_ParentId`
		            from global_db.geolocations g
			            inner join ancestors a on FIND_IN_SET(g.`GeoLocation_Id`, a.pid)
		            where
			            a.pid is not null
	            ),
	            result_ids as (
		            select
			            distinct id
            		from ancestors
	            )
                select
	                g.*
                from global_db.geolocations g
                    inner join result_ids r on r.id = g.`GeoLocation_Id`
                where 1 = 1
	                or (@type = 0 and g.`Geolocation_Type` = 0)
	                or (@type = 1 and g.`Geolocation_Type` >= 1)
	                or (@type = 2 and g.`Geolocation_Type` >= 2)
                order by g.`GeoLocation_Names`;                
                ";


                    int? type =
                        request.Type == LocationType.LocationCountry ? 0 :
                        request.Type == LocationType.LocationCity ? 1 :
                        request.Type == LocationType.LocationPlace ? 2 :
                        null;

                    cmd.Parameters.AddWithValue("@string", request.Name);
                    cmd.Parameters.AddWithValue("@type", type);
                    //                cmd.Parameters.AddWithValue("@locationId", request.Location.Id);

                    using var rdr = await cmd.ExecuteReaderAsync();
                    while (await rdr.ReadAsync())
                    {
                        Location location_origin = FillLocation(rdr);
                        Location location = new();
                        if (request.FieldMask != null && request.FieldMask.Paths.Count != 0)
                        {
                            request.FieldMask.Merge(location_origin, location);
                        }
                        else location = location_origin;
                        locations.Add(location);
                    }
                }

                return locations;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в ListLocationAsync: " + ex.Message);
            }
        }

        public async Task<Location> UpdateLocationAsync(UpdateLocationRequest request,UserData userData)
        {
            try
            {
                Location location = new();

                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();

                string new_parent_names_path = String.Empty;
                string new_parent_ids_path = String.Empty;

                // Определение нового родителя
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = 
                        $@"SELECT g.GeoLocation_Names, g.GeoLocation_Ids from global_db.geolocations g 
                        where g.GeoLocation_Id = {request.Location.ParentId}";
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
                        g.Geolocation_parentid = CASE WHEN g.Geolocation_id = @moved_node_id THEN @new_parent_id ELSE g.Geolocation_parentid END,
                        g.Geolocation_NameLat = @NameLat,
                        g.Geolocation_Data  = @data
                    WHERE
                        g.Geolocation_Id IN (SELECT id FROM Subtree);
    
                select * from global_db.geolocations AS g where g.GeoLocation_Id = @moved_node_id;";

                    cmd.Parameters.AddWithValue("@new_parent_names_path", new_parent_names_path);
                    cmd.Parameters.AddWithValue("@new_parent_ids_path", new_parent_ids_path);

                    cmd.Parameters.AddWithValue("@moved_node_id", request.Location.Id);
                    cmd.Parameters.AddWithValue("@new_parent_id", request.Location.ParentId > 0 ? request.Location.ParentId : null);
                    cmd.Parameters.AddWithValue("@new_node_name", request.Location.Name);
                    cmd.Parameters.AddWithValue("@NameLat", request.Location.NameLat);
                    cmd.Parameters.AddWithValue("@data", JsonFormatter.Default.Format(request.Location.Data));

                    using var rdr = await cmd.ExecuteReaderAsync();


                    if (await rdr.ReadAsync())
                    {
                        if(request.FieldMask == null || request.FieldMask.Paths.Count == 0 )
                            location =  FillLocation(rdr);
                        else
                            request.FieldMask.Merge(FillLocation(rdr),location);
                    }
                }
                return location;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в GetLocationAsync: " + ex.Message);
            }
        }


        #endregion


        public Location FillLocation(DbDataReader rdr)
        {
            Location location = new();

            location.Id = Convert.ToInt32(rdr["GeoLocation_Id"]);

            location.ParentId = rdr["GeoLocation_ParentId"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["GeoLocation_ParentId"]);
            location.Parent = new Location()
            {
                Id = location.ParentId
            };
            location.Ids = rdr["GeoLocation_Ids"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["GeoLocation_Ids"]);
            location.Names = rdr["GeoLocation_Names"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["GeoLocation_Names"]);
            location.Name = rdr["GeoLocation_Name"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["GeoLocation_Name"]);
            location.NameLat = rdr["GeoLocation_NameLat"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["GeoLocation_NameLat"]);

            int type = rdr["GeoLocation_Type"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["GeoLocation_Type"]);
            switch (type)
            {
                case 0: location.Type = LocationType.LocationCountry; break;
                case 1: location.Type = LocationType.LocationCity; break;
                case 2: location.Type = LocationType.LocationPlace; break;
            }

            string jsonString = rdr["GeoLocation_Data"] == DBNull.Value ? "{}" : rdr["GeoLocation_Data"].ToString();
            location.Data = JsonParser.Default.Parse<Struct>(jsonString);

            return location;
        }

    }
}
