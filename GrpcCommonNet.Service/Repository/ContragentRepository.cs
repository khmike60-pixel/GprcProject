using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contragent;
using GrpcCommonNet.Service.Models;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing.Printing;
using static System.Net.Mime.MediaTypeNames;

public class ContragentRepository
{
    private readonly string _connectionString = "";
    private readonly ILogger<ContragentRepository> _logger;
/*    private readonly string sqlFields = @"
            s.ID_M_SUBJ , -- subject 0
            s.TYPE_SUBJ , -- subject 1
            s.TIN_SUBJ , -- subject 2
            s.TINEXT_SUBJ , -- subject 3
            s.MCODE_SUBJ , -- subject 4
            s.IS_COUNTER_SUBJ , -- subject 5            старый
            s.OldRfrId , -- subject 6                   старый
            s.ID_M_COUNTRY , -- subject 7               старый
            s.VISIBLE_IN_ANY_COUNTRY , -- subject 8     ???
            s.OldRfrOrgId , -- subject 9                старый
            s.IsCustom , -- subject 10                  старый
            s.IsExporter , -- subject 11                старый
            s.IsVendor , -- subject 12                  старый
            s.OldRfrId2 , -- subject 13                 старый
            s.OldOrgIds , -- subject 14                 старый
            s.OldPeopleIds , -- subject 15              старый
            s.OldOrgId1 , -- subject 16                 старый
            s.OldOrgId2 , -- subject 17                 старый
            s.OldOrgId3 , -- subject 18                 старый
            s.OldPeoplId1 , -- subject 19               старый
            s.OldPeoplId2 , -- subject 20               старый
            s.OldPeoplId3 , -- subject 21               старый
            s.RWSOrgId , -- subject 22
            s.RegNum , -- subject 23
            s.MicrosCode , -- subject 24
            s.MicrosCodeConfirm , -- subject 25
            s.CorrectINN , -- subject 26
            s.PIN_SUBJ , -- subject 27
            s.DisplayRegNumb , -- subject 28
            s.SPCShortName , -- subject 29
            s.SPCFullName , -- subject 30
            s.Status , -- subject 31
            s.Prefix , -- subject 32
            s.WhoSetStatus , -- subject 33
            s.WhenSetStatus , -- subject 34
            s.ID_M_GEOCOUNTRY , -- subject 35
            c.GeoLocation_Code2, -- geolocation country 36

            e.ID_M_ENT , -- entity 37
            e.ID_M_SUBJ , -- entity 38
            e.ID_M_COUNTRY_RSD , -- entity 39
            e.ID_M_COUNTRY , -- entity 40
            e.ID_M_GEO , -- entity 41
            e.DATE_BEG , -- entity 42
            e.NameOrg , -- entity 43
            e.Short , -- entity 44
            e.Address , -- entity 45
            e.Fax , -- entity 46
            e.EMail , -- entity 47
            e.Phone , -- entity 48
            e.OKONH , -- entity 49
            e.OKPO , -- entity 50
            e.Comment , -- entity 51
            e.Site , -- entity 52
            e.Prefix , -- entity 53
            e.IsActive , -- entity 54
            e.DClose , -- entity 55
            e.DOpen , -- entity 56
            e.KOPF , -- entity 57
            e.KFS , -- entity 58
            e.SOOGU , -- entity 58
            e.SOATO , -- entity 60
            e.TaxInspect , -- entity 61
            e.Deal , -- entity 62
            e.ZIP , -- entity 63
            e.ContName , -- entity 64
            e.ContPhone , -- entity 65
            e.ContPost , -- entity 66
            e.LatName , -- entity 67
            e.LatAddr , -- entity 68
            e.INNControl , -- entity 69
            e.FAddress , -- entity 70
            e.FPhone , -- entity 71
            e.IsCustom , -- entity 72
            e.KPP , -- entity 73
            e.OGRN , -- entity 74
            e.IsExporter , -- entity 75
            e.CurrencyKind , -- entity 76
            e.OKED , -- entity 77
            e.IsVendor , -- entity 78
            e.NDSRegNum , -- entity 79
            e.ID_M_GEOLOCATIONS , -- entity 80
            e.ID_M_GEOCOUNTRY , -- entity 81
            e.ID_M_GEOCOUNTRY_RSD , -- entity 82

            p.ID_M_PERSON , -- person 83
            p.ID_M_SUBJ , -- person 84
            p.DATE_BEG , -- person 85
            p.ID_M_COUNTRY , -- person 86
            p.ID_M_COUNTRY_RSD , -- person 87
            p.Name , -- person 88
            p.NameLatin , -- person 89
            p.Surname , -- person 90
            p.Firstname , -- person 91
            p.Patronymic , -- person 92
            p.Short , -- person 93
            p.BirthDay , -- person 94
            p.BirthPlace , -- person 95
            p.PassportSer , -- person 96
            p.PassportNumb , -- person 97
            p.PassportDate , -- person 98
            p.PassportHand , -- person 99
            p.PassportEnd , -- person 100
            p.Address , -- person 101
            p.ADDRESS_PASP_PERS , -- person 102
            p.ADDRESS_TMP_PERS , -- person 103
            p.Phone , -- person 104
            p.EMail , -- person 105
            p.Nation , -- person 106
            p.Sex , -- person 107
            p.Education , -- person 108
            p.EducCenter , -- person 109
            p.EducEnd , -- person 110
            p.EducKind , -- person 111
            p.DiplomSpec , -- person 112
            p.DiplomQual , -- person 113
            p.DiplomNumber , -- person 114
            p.DiplomDate , -- person 115
            p.DiplomFillDate , -- person 116
            p.MainSpec , -- person 117
            p.SpecServRecord , -- person 118
            p.AllServRecord , -- person 119
            p.LastWorkPlace , -- person 120
            p.WorkPhone , -- person 121
            p.DischDate , -- person 122
            p.FamilyState , -- person 123
            p.Child , -- person 124
            p.MilitaryGroup , -- person 125
            p.MilitaryCat , -- person 126
            p.MilitaryStruct , -- person 127
            p.MilitaryRecNumb , -- person 128
            p.MilitarySpec , -- person 129
            p.MilitaryRepair , -- person 130
            p.MilitaryDepart , -- person 131
            p.Rem , -- person 132
            p.AcadDegree , -- person 133
            p.AcadRank , -- person 134
            p.DATE_TMP_FROM_PERS , -- person 135
            p.DATE_TMP_TO_PERS , -- person 136
            p.ID_NATION , -- person 137
            p.DATE_OPEN_PCOMP , -- person 138
            p.DATE_CLOSE_PCOMP , -- person 139
            p.NUMB_GUV_PCOMP , -- person 140
            p.INPS , -- person 141
            p.PINFL , -- person 142
            p.ID_M_GEOCOUNTRY , -- person 143
            p.ID_M_GEOCOUNTRY_RSD  -- person 144";
-- Test
*/

    private readonly string sqlFrom = @"
        from global_db.m_subject s
            left join global_db.geolocations c on s.ID_M_GEOCOUNTRY = c.GeoLocation_Id 
        LEFT JOIN global_db.m_entity e ON e.ID_M_ENT =
            (SELECT e2.ID_M_ENT
                FROM global_db.m_entity e2
                WHERE e2.ID_M_SUBJ = s.ID_M_SUBJ
                ORDER BY e2.DATE_BEG DESC
                LIMIT 1
            )
        LEFT JOIN global_db.m_person p ON p.ID_M_PERSON =
            (SELECT p2.ID_M_PERSON
                FROM global_db.m_person p2
                WHERE p2.ID_M_SUBJ = s.ID_M_SUBJ
                ORDER BY p2.DATE_BEG DESC
                LIMIT 1
            ) 
        ";

    private readonly string with = @"
        WITH 
            Entity AS (
                SELECT 
                    e1.*,
                    ROW_NUMBER() OVER (PARTITION BY e1.ID_M_SUBJ ORDER BY e1.DATE_BEG DESC) as rn
                FROM global_db.m_entity e1
                WHERE e1.DATE_BEG <= @target_date
            ),
            Person AS (
                SELECT 
                    p1.*,
                    ROW_NUMBER() OVER (PARTITION BY p1.ID_M_SUBJ ORDER BY p1.DATE_BEG DESC) as rn
                FROM global_db.m_person p1
                WHERE p1.DATE_BEG <= @target_date
            )
        ";

    public ContragentRepository(ILogger<ContragentRepository> logger, IConfiguration configuration)
    {
        _logger = logger;
        _connectionString = configuration.GetConnectionString("MySql");
    }

    #region Методы получения данных контрагента

    public async Task<Contragent> GetByIdAsync(long id, UserData userData)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = with + @"
                    SELECT 
                        s.*,
                        e.*,
                        p.*,
                        e.NameOrg as EntityName,
                        e.DATE_BEG as EntityActualDate,
                        p.Name as PersonName,
                        p.DATE_BEG as PersonActualDate,
	                    s.TIN_SUBJ,
	                    s.PIN_SUBJ,
                        c.Geolocation_Code2
                    FROM global_db.m_subject s
                        LEFT JOIN Entity e ON e.ID_M_SUBJ = s.ID_M_SUBJ AND e.rn = 1 AND s.TYPE_SUBJ = 0
                        LEFT JOIN Person p ON p.ID_M_SUBJ = s.ID_M_SUBJ AND p.rn = 1 AND s.TYPE_SUBJ = 1
                        LEFT JOIN global_db.Geolocations c ON c.GeoLocation_Id = s.ID_M_GEOCOUNTRY
                ";

            cmd.CommandText += $@"
                                where 1 = 1
                                and s.ID_M_SUBJ = {id};";
            cmd.Parameters.AddWithValue("@target_date", DateTime.Now);

            using var rdr = await cmd.ExecuteReaderAsync();
            Contragent contragent = new Contragent();
            if (await rdr.ReadAsync())
            {
                contragent = new Contragent();
                contragent = ContragentFill(rdr);

                switch (contragent.Type)
                {
                    case ContragentType.Entity:
                        contragent.Entity = new Entity();
                        contragent.Entity = EntityFill(rdr);
                        break;
                    case ContragentType.Person:
                        contragent.Person = new Person();
                        contragent.Person = PersonFill(rdr);
                        break;
                }
            }
            return contragent;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в GetListAsync:", ex);
        }
    }

    public async Task<List<Contragent>> ListAsync(
        string contragentName,
        string contragentTaxno,
        ContragentTypeFilter contragentTypeFilter,
        string countrySymbol,
        int? pageNumber, int? pageSize,
        UserData userData)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();

            string _contragentFilter = string.Empty;
            switch (contragentTypeFilter)
            {
                case ContragentTypeFilter.EntityFilter:
                    _contragentFilter = "0";
                    break;
                case ContragentTypeFilter.PersonFilter:
                    _contragentFilter = "1";
                    break;
                case ContragentTypeFilter.UnknownFilter:
                    _contragentFilter = "2,3";
                    break;
                case ContragentTypeFilter.All:
                default:
                    _contragentFilter = "0,1,2,3";
                    break;
            }

            cmd.CommandText = with + @"
                    SELECT 
                        s.*,
                        e.*,
                        p.*,
                        e.NameOrg as EntityName,
                        e.DATE_BEG as EntityActualDate,
                        p.Name as PersonName,
                        p.DATE_BEG as PersonActualDate,
	                    s.TIN_SUBJ,
	                    s.PIN_SUBJ,
                        c.Geolocation_Code2
                    FROM global_db.m_subject s
                        LEFT JOIN Entity e ON e.ID_M_SUBJ = s.ID_M_SUBJ AND e.rn = 1 AND s.TYPE_SUBJ = 0
                        LEFT JOIN Person p ON p.ID_M_SUBJ = s.ID_M_SUBJ AND p.rn = 1 AND s.TYPE_SUBJ = 1
                        LEFT JOIN global_db.Geolocations c ON c.GeoLocation_Id = s.ID_M_GEOCOUNTRY
                ";
            cmd.CommandText += $@"
                                WHERE 1 = 1
                                    AND (@contragentName is null or @contragentName = '' or s.MCODE_SUBJ LIKE CONCAT('%',@contragentName,'%'))
                                    AND (@contragentTaxno is null or @contragentTaxno = '' or s.TIN_SUBJ LIKE CONCAT('%',@contragentTaxno,'%') OR s.PIN_SUBJ LIKE CONCAT('%',@contragentTaxno,'%'))
                                    AND (s.TYPE_SUBJ in ({_contragentFilter}))
                                    AND (@countrySymbol is null or @countrySymbol = '' or c.GeoLocation_Code2 LIKE CONCAT('%',@countrySymbol,'%')) ";

            cmd.Parameters.AddWithValue("@contragentName", contragentName);
            cmd.Parameters.AddWithValue("@contragentTaxno", contragentTaxno);
            cmd.Parameters.AddWithValue("@countrySymbol", countrySymbol);
            cmd.Parameters.AddWithValue("@target_date", DateTime.Now);
            if (pageNumber != null && pageNumber > 0)
            {
                cmd.CommandText += " LIMIT @offset, @pageSize";
                cmd.Parameters.AddWithValue("@offset", (pageNumber - 1) * pageSize);
                cmd.Parameters.AddWithValue("@pageSize", pageSize);
            }
            using var rdr = await cmd.ExecuteReaderAsync();
            List<Contragent> contragents = new List<Contragent>();

            while (await rdr.ReadAsync())
            {
                Contragent contragent = new Contragent();
                contragent = ContragentFill(rdr);

                switch (contragent.Type)
                {
                    case ContragentType.Person:
                        contragent.Person = new Person();
                        contragent.Person = PersonFill(rdr);
                        break;
                    case ContragentType.Entity:
                        contragent.Entity = new Entity();
                        contragent.Entity = EntityFill(rdr);
                        break;
                }
                contragents.Add(contragent);
            }
            return contragents;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в GetListAsync: " + ex.Message);
        }
    }

    public async Task<List<Contragent>> ShortListAsync( string contragentName, string contragentTaxno,
        ContragentTypeFilter contragentTypeFilter, string countrySymbol, bool prefixNotEmpty, string prefix, int? pageNumber, int? pageSize,
        UserData userData)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();

            string _contragentFilter = string.Empty;
            switch (contragentTypeFilter)
            {
                case ContragentTypeFilter.EntityFilter:
                    _contragentFilter = "0";
                    break;
                case ContragentTypeFilter.PersonFilter:
                    _contragentFilter = "1";
                    break;
                case ContragentTypeFilter.UnknownFilter:
                    _contragentFilter = "2,3";
                    break;
                case ContragentTypeFilter.All:
                default:
                    _contragentFilter = "0,1,2,3";
                    break;
            }

            cmd.CommandText = with + @"
                    SELECT 
                        s.*,
--                        e.*,
--                        p.*,
                        e.NameOrg as EntityName,
                        e.DATE_BEG as EntityActualDate,
                        p.Name as PersonName,
                        p.DATE_BEG as PersonActualDate,
	                    s.TIN_SUBJ,
	                    s.PIN_SUBJ,
                        c.Geolocation_Code2
                    FROM global_db.m_subject s
                        LEFT JOIN Entity e ON e.ID_M_SUBJ = s.ID_M_SUBJ AND e.rn = 1 AND s.TYPE_SUBJ = 0
                        LEFT JOIN Person p ON p.ID_M_SUBJ = s.ID_M_SUBJ AND p.rn = 1 AND s.TYPE_SUBJ = 1
                        LEFT JOIN global_db.Geolocations c ON c.GeoLocation_Id = s.ID_M_GEOCOUNTRY
                ";
            cmd.CommandText += $@"
                                WHERE 1 = 1
                                    AND (@contragentName is null or @contragentName = '' or s.MCODE_SUBJ LIKE CONCAT('%',@contragentName,'%'))
                                    AND (@contragentTaxno is null or @contragentTaxno = '' or s.TIN_SUBJ LIKE CONCAT('%',@contragentTaxno,'%') OR s.PIN_SUBJ LIKE CONCAT('%',@contragentTaxno,'%'))
                                    AND (s.TYPE_SUBJ in ({_contragentFilter}))
                                    AND (@countrySymbol is null or @countrySymbol = '' or c.GeoLocation_Code2 LIKE CONCAT('%',@countrySymbol,'%')) 
                                    AND (@prefixNotEmpty = 0 or (s.Prefix is not null and s.Prefix <> '')) 
                                    AND (ifnull(@prefix,'') = '' or s.Prefix like CONCAT('%',@prefix,'%'))"
                                    ;

            cmd.CommandText += $@"
                                ORDER BY s.MCODE_SUBJ ";

            cmd.Parameters.AddWithValue("@contragentName", contragentName);
            cmd.Parameters.AddWithValue("@contragentTaxno", contragentTaxno);
            cmd.Parameters.AddWithValue("@countrySymbol", countrySymbol);
            cmd.Parameters.AddWithValue("@target_date", DateTime.Now);
            cmd.Parameters.AddWithValue("@prefixNotEmpty", prefixNotEmpty);
            cmd.Parameters.AddWithValue("@prefix", prefix);
            if (pageNumber != null && pageNumber > 0)
            {
                cmd.CommandText += " LIMIT @offset, @pageSize";
                cmd.Parameters.AddWithValue("@offset", (pageNumber - 1) * pageSize);
                cmd.Parameters.AddWithValue("@pageSize", pageSize);
            }
            using var rdr = await cmd.ExecuteReaderAsync();
            List<Contragent> contragents = new List<Contragent>();

            while (await rdr.ReadAsync())
            {
                Contragent contragent = new Contragent();
                contragent = ContragentFill(rdr);

                //switch (contragent.Type)
                //{
                //    case ContragentType.Person:
                //        contragent.Person = new Person();
                //        contragent.Person = PersonFill(rdr);
                //        break;
                //    case ContragentType.Entity:
                //        contragent.Entity = new Entity();
                //        contragent.Entity = EntityFill(rdr);
                //        break;
                //}
                contragents.Add(contragent);
            }
            return contragents;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в GetListAsync: " + ex.Message);
        }
    }

    public List<Contragent> SearchList(string searchText, int? pageNumber, int? pageSize, 
        UserData userData)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();
            using var cmd = conn.CreateCommand();

            string _contragentFilter = string.Empty;

            cmd.CommandText = @"
                    SELECT 
                        s.ID_M_SUBJ Id,
                        s.MCODE_SUBJ Name,
                        IF(s.TYPE_SUBJ = 0, s.TIN_SUBJ, IF(s.TYPE_SUBJ = 1, s.PIN_SUBJ, '')) as TaxNo
                    FROM global_db.m_subject s ";
            cmd.CommandText += $@"
                    WHERE 1 = 1
                        AND (
                            s.MCODE_SUBJ LIKE CONCAT('%',@contragentName,'%')
                            OR
                            s.TIN_SUBJ LIKE CONCAT('%',@contragentTaxno,'%') 
                            OR 
                            s.PIN_SUBJ LIKE CONCAT('%',@contragentTaxno,'%')
                        ) ";

            cmd.CommandText += $@"
                                ORDER BY s.MCODE_SUBJ ";

            cmd.Parameters.AddWithValue("@contragentName", searchText);
            cmd.Parameters.AddWithValue("@contragentTaxno", searchText);
            if (pageNumber != null && pageNumber > 0)
            {
                cmd.CommandText += " LIMIT @offset, @pageSize";
                cmd.Parameters.AddWithValue("@offset", (pageNumber - 1) * pageSize);
                cmd.Parameters.AddWithValue("@pageSize", pageSize);
            }
            using var rdr = cmd.ExecuteReader();
            List<Contragent> contragents = new List<Contragent>();

            while (rdr.Read())
            {
                Contragent contragent = ContragentSearchFill(rdr);
                contragents.Add(contragent);
            }
            return contragents;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в SearchList: " + ex.Message);
        }
    }


    public async Task<long> CountAllAsync(
        string contragentName,
        string contragentTaxno,
        ContragentTypeFilter contragentTypeFilter,
        string countrySymbol,
        UserData userData)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();

            string _contragentFilter = string.Empty;
            switch (contragentTypeFilter)
            {
                case ContragentTypeFilter.EntityFilter:
                    _contragentFilter = "0";
                    break;
                case ContragentTypeFilter.PersonFilter:
                    _contragentFilter = "1";
                    break;
                case ContragentTypeFilter.UnknownFilter:
                    _contragentFilter = "2,3";
                    break;
                case ContragentTypeFilter.All:
                default:
                    _contragentFilter = "0,1,2,3";
                    break;
            }

            cmd.CommandText = with + @"
                    SELECT 
                        COUNT(*)
                    FROM global_db.m_subject s
                        LEFT JOIN Entity e ON e.ID_M_SUBJ = s.ID_M_SUBJ AND e.rn = 1 AND s.TYPE_SUBJ = 0
                        LEFT JOIN Person p ON p.ID_M_SUBJ = s.ID_M_SUBJ AND p.rn = 1 AND s.TYPE_SUBJ = 1
                        LEFT JOIN global_db.Geolocations c ON c.GeoLocation_Id = s.ID_M_GEOCOUNTRY
                ";
            cmd.CommandText += $@"
                                WHERE 1 = 1
                                    AND (@contragentName is null or @contragentName = '' or s.MCODE_SUBJ LIKE CONCAT('%',@contragentName,'%'))
                                    AND (@contragentTaxno is null or @contragentTaxno = '' or s.TIN_SUBJ LIKE CONCAT('%',@contragentTaxno,'%') OR s.PIN_SUBJ LIKE CONCAT('%',@contragentTaxno,'%'))
                                    AND (s.TYPE_SUBJ in ({_contragentFilter}))
                                    AND (@countrySymbol is null or @countrySymbol = '' or c.GeoLocation_Code2 LIKE CONCAT('%',@countrySymbol,'%')) ";

            cmd.Parameters.AddWithValue("@contragentName", contragentName);
            cmd.Parameters.AddWithValue("@contragentTaxno", contragentTaxno);
            cmd.Parameters.AddWithValue("@countrySymbol", countrySymbol);
            cmd.Parameters.AddWithValue("@target_date", DateTime.Now);

            var count = await cmd.ExecuteScalarAsync();
            return Convert.ToInt64(count);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в CountAllAsync: " + ex.Message);
        }
    }

    public async Task<Contragent> CreateAsync(Contragent contragent, UserData userData)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            switch (contragent.Type)
            {
                case ContragentType.Entity:
                    cmd.CommandText = "global_db.iu_m_entity_new";
                    int entId = 0;
                    cmd.Parameters.AddWithValue("_ID_M_ENT", entId);

                    MySqlParameter inpoutId = new MySqlParameter("_ID_M_SUBJ", MySqlDbType.Int32);
                    inpoutId.Direction = ParameterDirection.InputOutput;
                    inpoutId.Value = contragent.Id;     // 0 - создается новое ЮЛ 
                    cmd.Parameters.Add(inpoutId);

                    cmd.Parameters.AddWithValue("_TIN_SUBJ", (int)contragent.Type);
                    cmd.Parameters.AddWithValue("_TINEXT_SUBJ", contragent.Taxno)  ;
                    cmd.Parameters.AddWithValue("_MCODE_SUBJ" , contragent.Name);
                    cmd.Parameters.AddWithValue("_ID_M_COUNTRY", contragent.CountryId);
                    cmd.Parameters.AddWithValue("_ID_M_GEOCOUNTRY", contragent.Entity.EntityGeocountryId);
                    cmd.Parameters.AddWithValue("_ID_M_COUNTRY_RSD", 0);
                    cmd.Parameters.AddWithValue("_ID_M_GEOCOUNTRY_RSD", contragent.Entity.EntityGeocountryIdRsd);
                    cmd.Parameters.AddWithValue("_DATE_BEG", contragent.Entity.EntityDateActualized);
                    cmd.Parameters.AddWithValue("_NameOrg", contragent.Entity.EntityName);
                    cmd.Parameters.AddWithValue("_NameOrgEng", contragent.Entity.EntityLatName);
                    cmd.Parameters.AddWithValue("_Short" , contragent.Entity.EntityShort);
                    cmd.Parameters.AddWithValue("_Prefix", contragent.Prefix);
                    cmd.Parameters.AddWithValue("_Address", contragent.Entity.EntityAddress);
                    cmd.Parameters.AddWithValue("_Fax", "");
                    cmd.Parameters.AddWithValue("_EMail", contragent.Entity.EntityEmail);
                    cmd.Parameters.AddWithValue("_Phone", contragent.Entity.EntityPhone);
                    cmd.Parameters.AddWithValue("_OKONH", contragent.Entity.EntityOkonh);
                    cmd.Parameters.AddWithValue("_OKPO", contragent.Entity.EnityOkpo);
                    cmd.Parameters.AddWithValue("_Comment", contragent.Entity.EnityComment);
                    cmd.Parameters.AddWithValue("_Site", contragent.Entity.EnitySite);
                    cmd.Parameters.AddWithValue("_Deal", 0);
                    cmd.Parameters.AddWithValue("_SOOGU", contragent.Entity.EntitySoogu);
                    cmd.Parameters.AddWithValue("_SOATO", contragent.Entity.EntitySoato);
                    cmd.Parameters.AddWithValue("_KFS", contragent.Entity.EntityKfs);
                    cmd.Parameters.AddWithValue("_KOPF", contragent.Entity.EntityKopf);
                    cmd.Parameters.AddWithValue("_ID_M_GEO", contragent.Entity.EntityGeolocationId);
                    cmd.Parameters.AddWithValue("_ID_M_GEOLOCATIONS", 0);
                    cmd.Parameters.AddWithValue("_Post", contragent.Entity.EntityContactorPosition);
                    cmd.Parameters.AddWithValue("_HeadName", "");
                    cmd.Parameters.AddWithValue("_AccounterName", "");
                    cmd.Parameters.AddWithValue("_OnBase", "");
                    cmd.Parameters.AddWithValue("_SignatoryHeadId", 0);
                    cmd.Parameters.AddWithValue("_SignatoryAccounterId", 0);
                    cmd.Parameters.AddWithValue("_INNControl", "");
                    cmd.Parameters.AddWithValue("_FAddress", contragent.Entity.EntityFactAddress);
                    cmd.Parameters.AddWithValue("_FAddressEng", "");
                    cmd.Parameters.AddWithValue("_FPhone", contragent.Entity.EntityFactAddress);
                    cmd.Parameters.AddWithValue("_IsCustom", "");
                    cmd.Parameters.AddWithValue("_KPP", contragent.Entity.EntityKpp);
                    cmd.Parameters.AddWithValue("_OGRN", contragent.Entity.EntityOgrn);
                    cmd.Parameters.AddWithValue("_OKED", contragent.Entity.ClearEntityOked);
                    cmd.Parameters.AddWithValue("_UserId", 0);
                    cmd.Parameters.AddWithValue("_NDSRegNum", contragent.Entity.EntityVatNumber);
                    cmd.Parameters.AddWithValue("_MicrosCode", contragent.Entity);
                    cmd.Parameters.AddWithValue("_MicrosCodeConfirm", "");
                    cmd.Parameters.AddWithValue("_RegNum", "");
                    cmd.Parameters.AddWithValue("_DisplayRegNumb", "");
                    cmd.Parameters.AddWithValue("_DOpen", contragent.Entity.EntityDateOpen);

                    break;
                case ContragentType.Person:
                    cmd.CommandText = "";

                    cmd.Parameters.AddWithValue("@date_actialized", DateTime.UnixEpoch);
                    break;
                default:
                    // Может что-то и понадобиться
                    break;
            }

            var rdr = await cmd.ExecuteReaderAsync();


            if (await rdr.ReadAsync())
            {
                return new Contragent
                {
                    Id = rdr.IsDBNull(0) ? 0 : rdr.GetInt32(0),
                    Name = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1),
                    CountryId = rdr.IsDBNull(4) ? 0 : rdr.GetInt32(4),
                    Prefix = rdr.IsDBNull(5) ? string.Empty : rdr.GetString(5)
                };
            }
            else
                return new Contragent { };
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в CreateAsync: " + ex.Message);
        }
    }

    public async Task<Contragent> UpdateAsync(Contragent contragent, UserData userData)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = $@"UPDATE global_db.m_subject SET
                                    MCODE_SUBJ = @contragentName, 
                                    TYPE_SUBJ = @contragentType, 
                                    TIN_SUBJ = @contragentTaxno, 
                                    PIN_SUBJ = @countryId, 
                                    ID_M_COUNTRY = @countryId, 
                                    PREFIX = @prefix
                                WHERE ID_M_SUBJ = {contragent.Id};";

            switch (contragent.Type)
            {
                case ContragentType.Entity:
                    cmd.CommandText = $@"
                            INSERT INTO global_db.m_entity (
                                MCODE_SUBJ = @contragentName, 
                                TYPE_SUBJ = @contragentType, 
                                TIN_SUBJ = @contragentTaxno, 
                                PIN_SUBJ = @countryId, 
                                ID_M_COUNTRY = @countryId, 
                                PREFIX = @prefix
                            WHERE ID_M_SUBJ = {contragent.Id};";

                    break;
                case ContragentType.Person:
                    break;
                default:
                    break;
            }

            cmd.CommandText += $@"SELECT * FROM global_db.m_subject s
                                WHERE ID_M_SUBJ = {contragent.Id};";


            cmd.Parameters.AddWithValue("@contragentName", contragent.Name);
            cmd.Parameters.AddWithValue("@contragentType", (int)contragent.Type);
            cmd.Parameters.AddWithValue("@contragentTaxno", contragent.Taxno);
            cmd.Parameters.AddWithValue("@countryId", contragent.CountryId);
            cmd.Parameters.AddWithValue("@prefix", contragent.Prefix);
            var rdr = await cmd.ExecuteReaderAsync();
            if (await rdr.ReadAsync())
            {
                return new Contragent
                {
                    Id = rdr.IsDBNull(0) ? 0 : rdr.GetInt32(0),
                    Name = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1),
                    CountryId = rdr.IsDBNull(4) ? 0 : rdr.GetInt32(4),
                    Prefix = rdr.IsDBNull(5) ? string.Empty : rdr.GetString(5)
                };
            }
            else
                return new Contragent { };
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в UpdateAsync: " + ex.Message);
        }





        // Implementation for updating an existing contragent in the database
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(long contragentId, UserData userData)
    {
        // Implementation for deleting a contragent from the database
        throw new NotImplementedException();
    }

    public async Task<List<int>> DeleteIdsAsync(List<int> list, UserData userData)
    {
        // Implementation for checking if a contragent tax number is unique in the database
        throw new NotImplementedException();
    }

    #endregion

    #region Методы работы со своими организациями

    public async Task<Contragent> GetOurCompanyAsync(int id, UserData userData)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = with + @"
                    SELECT 
                        s.*,
                        e.*,
                        p.*,
                        e.NameOrg as EntityName,
                        e.DATE_BEG as EntityActualDate,
                        p.Name as PersonName,
                        p.DATE_BEG as PersonActualDate,
	                    s.TIN_SUBJ,
	                    s.PIN_SUBJ,
                        c.Geolocation_Code2
                    FROM global_db.m_subject s
                        LEFT JOIN Entity e ON e.ID_M_SUBJ = s.ID_M_SUBJ AND e.rn = 1 AND s.TYPE_SUBJ = 0
                        LEFT JOIN Person p ON p.ID_M_SUBJ = s.ID_M_SUBJ AND p.rn = 1 AND s.TYPE_SUBJ = 1
                        LEFT JOIN global_db.Geolocations c ON c.GeoLocation_Id = s.ID_M_GEOCOUNTRY
                        RIGHT JOIN refers.m_oursubject oc ON oc.ID_M_SUBJ = s.ID_M_SUBJ
                ";

            cmd.CommandText += $@"
                                where 1 = 1
                                and oc.ID_M_SUBJ = {id};";
            cmd.Parameters.AddWithValue("@target_date", DateTime.Now);

            using var rdr = await cmd.ExecuteReaderAsync();
            Contragent contragent = new Contragent();
            if (await rdr.ReadAsync())
            {
                contragent = new Contragent();
                contragent = ContragentFill(rdr);

                switch (contragent.Type)
                {
                    case ContragentType.Entity:
                        contragent.Entity = new Entity();
                        contragent.Entity = EntityFill(rdr);
                        break;
                    case ContragentType.Person:
                        contragent.Person = new Person();
                        contragent.Person = PersonFill(rdr);
                        break;
                }
            }
            return contragent;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в GeOurCompanyAsync:", ex);
        }
    }

    public async Task<List<Contragent>> ListOurCompanyAsync(
        string contragentName,
        string contragentTaxno,
        ContragentTypeFilter contragentTypeFilter,
        string countrySymbol,
        int? pageNumber, int? pageSize,
        UserData userData)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();

            string _contragentFilter = string.Empty;
            switch (contragentTypeFilter)
            {
                case ContragentTypeFilter.EntityFilter:
                    _contragentFilter = "0";
                    break;
                case ContragentTypeFilter.PersonFilter:
                    _contragentFilter = "1";
                    break;
                case ContragentTypeFilter.UnknownFilter:
                    _contragentFilter = "2,3";
                    break;
                case ContragentTypeFilter.All:
                default:
                    _contragentFilter = "0,1,2,3";
                    break;
            }

            cmd.CommandText = with + @"
                    SELECT 
                        s.*,
                        e.*,
                        p.*,
                        e.NameOrg as EntityName,
                        e.DATE_BEG as EntityActualDate,
                        p.Name as PersonName,
                        p.DATE_BEG as PersonActualDate,
                        s.TIN_SUBJ,
                        s.PIN_SUBJ,
                        c.Geolocation_Code2
                    FROM global_db.m_subject s
                        LEFT JOIN Entity e ON e.ID_M_SUBJ = s.ID_M_SUBJ AND e.rn = 1 AND s.TYPE_SUBJ = 0
                        LEFT JOIN Person p ON p.ID_M_SUBJ = s.ID_M_SUBJ AND p.rn = 1 AND s.TYPE_SUBJ = 1
                        LEFT JOIN global_db.Geolocations c ON c.GeoLocation_Id = s.ID_M_GEOCOUNTRY
                        RIGHT JOIN refers.m_oursubject oc ON oc.ID_M_SUBJ = s.ID_M_SUBJ
                ";

            cmd.CommandText += $@"
                                WHERE 1 = 1
                                    AND (@contragentName is null or @contragentName = '' or s.MCODE_SUBJ LIKE CONCAT('%',@contragentName,'%'))
                                    AND (@contragentTaxno is null or @contragentTaxno = '' or s.TIN_SUBJ LIKE CONCAT('%',@contragentTaxno,'%') OR s.PIN_SUBJ LIKE CONCAT('%',@contragentTaxno,'%'))
                                    AND (s.TYPE_SUBJ in ({_contragentFilter}))
                                    AND (@countrySymbol is null or @countrySymbol = '' or c.GeoLocation_Code2 LIKE CONCAT('%',@countrySymbol,'%')) ";

            cmd.CommandText += $@"
                                ORDER BY s.MCODE_SUBJ ";

            cmd.Parameters.AddWithValue("@contragentName", contragentName);
            cmd.Parameters.AddWithValue("@contragentTaxno", contragentTaxno);
            cmd.Parameters.AddWithValue("@countrySymbol", countrySymbol);
            cmd.Parameters.AddWithValue("@target_date", DateTime.Now);
            if (pageNumber != null && pageNumber > 0)
            {
                cmd.CommandText += " LIMIT @offset, @pageSize";
                cmd.Parameters.AddWithValue("@offset", (pageNumber - 1) * pageSize);
                cmd.Parameters.AddWithValue("@pageSize", pageSize);
            }
            
            
            using var rdr = await cmd.ExecuteReaderAsync();
            List<Contragent> contragents = new List<Contragent>();

            while (await rdr.ReadAsync())
            {
                Contragent contragent = new Contragent();
                contragent = ContragentFill(rdr);

                //switch (contragent.Type)
                //{
                //    case ContragentType.Person:
                //        contragent.Person = new Person();
                //        contragent.Person = PersonFill(rdr);
                //        break;
                //    case ContragentType.Entity:
                //        contragent.Entity = new Entity();
                //        contragent.Entity = EntityFill(rdr);
                //        break;
                //}
                contragents.Add(contragent);
            }
            return contragents;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в ListOurCompanyAsync:", ex);
        }
    }

    #endregion

    #region Внутренние методы
    private Entity EntityFill(System.Data.Common.DbDataReader rdr)
    {
        Entity entity = new Entity();

        entity.EntityId = rdr["ID_M_ENT"] == DBNull.Value  ? 0 : Convert.ToInt32(rdr["ID_M_ENT"]);
        entity.EntityDateActualized = rdr["DATE_BEG"] == DBNull.Value ? new Timestamp { } : Timestamp.FromDateTime(Convert.ToDateTime(rdr["DATE_BEG"]).ToLocalTime().ToUniversalTime());
        entity.EntityPrefix = rdr["Prefix"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["Prefix"]);
        entity.EntityVatNumber = rdr["NDSRegNum"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["NDSRegNum"]);
        entity.EntityTaxInspect = rdr["TaxInspect"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["TaxInspect"]);
        entity.EntityTaxnoControl = rdr["INNControl"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["INNControl"]);
        entity.EntityCurrencyKind = rdr["CurrencyKind"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["CurrencyKind"]);

        entity.EnityComment = rdr["Comment"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["Comment"]);

        entity.EntityName = rdr["NameOrg"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["NameOrg"]);
        entity.EntityShort = rdr["Short"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["Short"]);
        entity.EntityAddress = rdr["Address"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["Address"]);
        entity.EntityPhone = rdr["Phone"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["Phone"]);
        entity.EntityEmail = rdr["EMail"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["EMail"]);
        entity.EnitySite = rdr["Site"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["Site"]);
        entity.EntityZip = rdr["ZIP"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["ZIP"]);
        //entity.EntityFax = rdr["Fax"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["Fax"]);
        entity.EntityLatName = rdr["LatName"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["LatName"]);
        entity.EntityLatAddress = rdr["LatAddr"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["LatAddr"]);
        entity.EntityFactAddress = rdr["FAddress"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["FAddress"]);
        entity.EntityFactPhone = rdr["FPhone"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["FPhone"]);

        entity.EntityContactor = rdr["ContName"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["ContName"]);
        entity.EntityContactorPhone = rdr["ContPhone"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["ContPhone"]);
        entity.EntityContactorPosition = rdr["ContPost"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["ContPost"]);

        entity.EntitySoato = rdr["SOATO"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["SOATO"]);
        entity.EntityOkonh = rdr["OKONH"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["OKONH"]);
        entity.EntityOgrn = rdr["OGRN"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["OGRN"]);
        entity.EntityKpp = rdr["KPP"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["KPP"]);
        entity.EnityOkpo = rdr["OKPO"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["OKPO"]);
        entity.EntityKopf = rdr["KOPF"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["KOPF"]);
        entity.EntitySoogu = rdr["SOOGU"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["SOOGU"]);
        entity.EntityOked = rdr["OKED"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["OKED"]);
        entity.EntityKfs = rdr["KFS"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["KFS"]);

        //entity.EnityIsExporter = rdr["IsExporter"] == DBNull.Value ? false : Convert.ToBoolean(rdr["IsExporter"]);
        entity.EntityIsCustom = rdr["IsCustom"] == DBNull.Value ? false : Convert.ToBoolean(rdr["IsCustom"]);
        //entity.EntityIsVendor = rdr["IsVendor"] == DBNull.Value ? false : Convert.ToBoolean(rdr["IsVendor"]);
        entity.EntityDeal = rdr["Deal"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["Deal"]);

        entity.EntityDateOpen = rdr["DOpen"] == DBNull.Value ? new Timestamp { } : Timestamp.FromDateTime(Convert.ToDateTime(rdr["DOpen"]).ToLocalTime().ToUniversalTime());
        entity.EntityDateClosed = rdr["DClose"] == DBNull.Value ? new Timestamp { } : Timestamp.FromDateTime(Convert.ToDateTime(rdr["DClose"]).ToLocalTime().ToUniversalTime());
        entity.EntityIsActive = rdr["IsActive"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["IsActive"]);

        entity.EntityGeocountryId = rdr["ID_M_GEOCOUNTRY"] == DBNull.Value ? 0 : Convert.ToInt64(rdr["ID_M_GEOCOUNTRY"]);
        entity.EntityGeocountryIdRsd = rdr["ID_M_GEOCOUNTRY_RSD"] == DBNull.Value ? 0 : Convert.ToInt64(rdr["ID_M_GEOCOUNTRY_RSD"]);
        entity.EntityGeolocationId = rdr["ID_M_GEO"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["ID_M_GEO"]);

        return entity;
    }

    private Person PersonFill(System.Data.Common.DbDataReader rdr)
    {
        Person person = new Person();
        person.PersonId = rdr["ID_M_PERSON"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["ID_M_PERSON"]);
        person.PersonDateActualized = rdr["DATE_BEG"] == DBNull.Value ? new Timestamp { } : Timestamp.FromDateTime(Convert.ToDateTime(rdr["DATE_BEG"]).ToLocalTime().ToUniversalTime());
        person.PersonTaxno = rdr["PINFL"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["PINFL"]);
        person.PersonInps = rdr["INPS"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["INPS"]);

        person.PersonSex = rdr["Sex"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["Sex"]);
        person.PersonName = rdr["Name"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["Name"]);
        person.PersonFirstName = rdr["Firstname"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["Firstname"]);
        person.PersonSurname = rdr["Surname"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["Surname"]);
        person.PersonPatronymic = rdr["Patronymic"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["Patronymic"]);
        person.PersonLatName = rdr["NameLatin"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["NameLatin"]);
        person.PersonShort = rdr["Short"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["Short"]);
        person.PersonBirthDate = rdr["BirthDay"] == DBNull.Value ? new Timestamp { } : Timestamp.FromDateTime(Convert.ToDateTime(rdr["BirthDay"]).ToLocalTime().ToUniversalTime());
        person.PersonBirthPlace = rdr["BirthPlace"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["BirthPlace"]);
        person.PersonFamilyState = rdr["FamilyState"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["FamilyState"]);

        person.PersonPassportNumber = rdr["PassportNumb"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["PassportNumb"]);
        person.PersonPassportSeries = rdr["PassportSer"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["PassportSer"]);
        person.PersonPassportDateIssue = rdr["PassportDate"] == DBNull.Value ? new Timestamp { } : Timestamp.FromDateTime(Convert.ToDateTime(rdr["PassportDate"]).ToLocalTime().ToUniversalTime());
        person.PersonPassportIssuedBy = rdr["PassportHand"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["PassportHand"]);
        person.PersonPassportDateExpired = rdr["PassportEnd"] == DBNull.Value ? new Timestamp { } : Timestamp.FromDateTime(Convert.ToDateTime(rdr["PassportEnd"]).ToLocalTime().ToUniversalTime());

        person.PersonAddressRegistration = rdr["Address"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["Address"]);
        person.PersonAddressResidence = rdr["ADDRESS_TMP_PERS"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["ADDRESS_TMP_PERS"]);

        person.PersonPhone = rdr["Phone"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["Phone"]);
        person.PersonEmail = rdr["EMail"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["EMail"]);
        person.PersonNationality = rdr["Nation"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["Nation"]);

        person.PersonEducation = rdr["Education"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["Education"]);
        person.PersonEducationInstitution = rdr["EducCenter"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["EducCenter"]);
        person.PersonEducationEndDate = rdr["EducEnd"] == DBNull.Value ? new Timestamp { } : Timestamp.FromDateTime(Convert.ToDateTime(rdr["EducEnd"]).ToLocalTime().ToUniversalTime());
        person.PersonEducationKind = rdr["EducKind"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["EducKind"]);
        person.PersonDiplomNumber = rdr["DiplomNumber"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["DiplomNumber"]);
        person.PersonDiplomDateIssue = rdr["DiplomDate"] == DBNull.Value ? new Timestamp { } : Timestamp.FromDateTime(Convert.ToDateTime(rdr["DiplomDate"]).ToLocalTime().ToUniversalTime());
        person.PersonDiplomaSpeciality = rdr["DiplomSpec"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["DiplomSpec"]);
        person.PersonDiplomaQualification = rdr["DiplomQual"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["DiplomQual"]);
        person.PersonMainProfession = rdr["MainSpec"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["MainSpec"]);
        person.PersonLastWorkPlace = rdr["LastWorkPlace"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["LastWorkPlace"]);
        person.PersonDischDate = rdr["DischDate"] == DBNull.Value ? new Timestamp { } : Timestamp.FromDateTime(Convert.ToDateTime(rdr["DischDate"]).ToLocalTime().ToUniversalTime());

        person.PersonPhone = rdr["WorkPhone"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["WorkPhone"]);

        person.PersonGeocuntryId = rdr["ID_M_GEOCOUNTRY"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["ID_M_GEOCOUNTRY"]);
        person.PersonGeocountryIdRsd = rdr["ID_M_GEOCOUNTRY_RSD"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["ID_M_GEOCOUNTRY_RSD"]);

        person.PersonComment = rdr["Rem"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["Rem"]);

        return person;  
    }

    private Contragent ContragentFill(DbDataReader rdr)
    {
        Contragent contragent = new Contragent();
        contragent.Id = rdr["ID_M_SUBJ"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["ID_M_SUBJ"]);
        contragent.Name = rdr["MCODE_SUBJ"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["MCODE_SUBJ"]);
        int type = rdr["TYPE_SUBJ"] == DBNull.Value ? 2 : Convert.ToInt32(rdr["TYPE_SUBJ"]);
        switch (type)
        {
            case 0:
                contragent.Type = ContragentType.Entity;
                contragent.Taxno = rdr["TIN_SUBJ"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["TIN_SUBJ"]);
                break;
            case 1:
                contragent.Type = ContragentType.Person;
                contragent.Taxno = rdr["PIN_SUBJ"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["PIN_SUBJ"]);
                break;
            default:
                contragent.Type = ContragentType.Unknown;
                break;
        }
        contragent.Prefix = rdr["Prefix"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["Prefix"]);
        contragent.CountrySymbol = rdr["GeoLocation_Code2"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["GeoLocation_Code2"]);
        contragent.CountryId = rdr["ID_M_GEOCOUNTRY"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["ID_M_GEOCOUNTRY"]);

        // s.RWSOrgId , -- subject 22
        // s.RegNum , -- subject 23
        // s.MicrosCode , -- subject 24
        // s.MicrosCodeConfirm , -- subject 25
        // s.SPCShortName , -- subject 29
        // s.SPCFullName , -- subject 30
        // s.Status , -- subject 31
        // s.WhoSetStatus , -- subject 33
        // s.WhenSetStatus , -- subject 34

        return contragent;
    }

    private Contragent ContragentSearchFill(DbDataReader rdr)
    {
        Contragent contragent = new Contragent();
        contragent.Id   = rdr["Id"]     == DBNull.Value ? 0 : Convert.ToInt32(rdr["Id"]);
        contragent.Name = rdr["Name"]   == DBNull.Value ? string.Empty : Convert.ToString(rdr["Name"]);
        contragent.Taxno= rdr["TaxNo"]  == DBNull.Value ? string.Empty : Convert.ToString(rdr["TaxNo"]);
        return contragent;  
    }


    #endregion
}