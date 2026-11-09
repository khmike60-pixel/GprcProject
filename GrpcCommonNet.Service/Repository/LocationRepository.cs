using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Location;
using GrpcCommonNet.Service.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;
using System.Xml.Linq;

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

                // Процедур обновления
                using (MySqlCommand command = new MySqlCommand("global_db.Location_update", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_code", request.Location.Id);
                    command.Parameters.AddWithValue("@p_target_parentId", request.Location.ParentId);
                    command.Parameters.AddWithValue("@p_new_name", request.Location.Name);
                    command.Parameters.AddWithValue("@p_new_name", request.Location.Data);
                    
                    using (var rdr = await command.ExecuteReaderAsync())
                    {
                        if (await rdr.ReadAsync())
                        {
                            if (request.FieldMask == null || request.FieldMask.Paths.Count == 0)
                                location = FillLocation(rdr);
                            else
                                request.FieldMask.Merge(FillLocation(rdr), location);
                        }
                    }
                }
                return location;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в GetLocationAsync: " + ex.Message);
            }
        }

        public async Task<List<int>> DeleteLocationAsync(DeleteLocationRequest  request, UserData userData)
        {
            try
            {
                List<int> undeletedIds = new();

                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $@"
                    DELETE IGNORE FROM global_db.geolocations 
                    WHERE FIND_IN_SET(GeoLocation_Id, @p_ids_list) > 0;

                    SELECT 
                        g.GeoLocation_Id
                    FROM global_db.geolocations g
                    WHERE FIND_IN_SET(g.GeoLocation_Id, @p_ids_list) > 0
                    Order by g.GeoLocation_Names
                    ;";

                    string p_ids_list = string.Empty;
                    foreach (int id in request.Ids)
                    {
                        if (string.IsNullOrEmpty(p_ids_list))
                            p_ids_list += id.ToString();
                        else
                            p_ids_list += "," + id.ToString();
                    }

                    cmd.Parameters.AddWithValue("@p_ids_list", p_ids_list);

                    using var rdr = await cmd.ExecuteReaderAsync();
                    while (await rdr.ReadAsync())
                    {
                        undeletedIds.Add(
                            rdr["GeoLocation_Id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["GeoLocation_Id"])
                            );
                    }
                }

                return undeletedIds;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в DeleteLocationAsync: " + ex.Message);
            }

        }

        public async Task<Location> CreateLocationAsync(CreateLocationRequest request, UserData userData)
        {
            try
            {
                Location location = new();

                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();

                // Процедур создания
                using (MySqlCommand command = new MySqlCommand("global_db.Location_Insert", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_parent_id", request.Location.ParentId);
                    command.Parameters.AddWithValue("@p_name", request.Location.Name);
                    command.Parameters.AddWithValue("@p_type", request.Location.Type);
                    command.Parameters.AddWithValue("@p_data", request.Location.Data);

                    using (var rdr = await command.ExecuteReaderAsync())
                    {
                        if (await rdr.ReadAsync())
                        {
                            location = FillLocation(rdr);
                        }
                    }
                }

                return location ;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в CreateLocationAsync: " + ex.Message);
            }

        }

        #endregion

        #region Метод маппинга
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
        #endregion
    }
}
