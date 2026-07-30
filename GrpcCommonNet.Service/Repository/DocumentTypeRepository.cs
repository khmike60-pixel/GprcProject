using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Service.Models;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace GrpcCommonNet.Service.Repository
{
    public class DocumentTypeRepository
    {
        private readonly string _connectionString = "";
        private readonly ILogger<DocumentTypeRepository> _logger;

        public DocumentTypeRepository(ILogger<DocumentTypeRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("MySql");
        }

        #region Методы работы с типами документов
        
        public async Task<DocumentType> GetByIdAsync(int id)
        {
            try
            {
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = $@"
                    Select 
                        *
                    FROM cwatis.documenttypes d
                    WHERE d.documenttype_id = @id;
                ";
                cmd.Parameters.AddWithValue("id", id);   
                using var rdr = await cmd.ExecuteReaderAsync();

                DocumentType docType = new DocumentType();
                if (await rdr.ReadAsync())
                {
                    docType = FillDocType(rdr);
                }
                return docType;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetByIdAsync: " + ex.Message);
                throw;

            }
        }

        public async Task<List<DocumentType>> GetBranch(string head)
        {
            try
            {
                List<DocumentType> docTypes = new List<DocumentType>();
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = new MySqlCommand("cwatis.DocumentType_GetBranch",conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Code", head);

                using var rdr = await cmd.ExecuteReaderAsync();

                while (await rdr.ReadAsync())
                    docTypes.Add(FillDocType(rdr));

                return docTypes;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetIeararAsync: " + ex.Message);
                throw;
            }

        }

        #endregion

        #region внутренние методы

        private DocumentType FillDocType(DbDataReader rdr)
        {
            DocumentType docType = new DocumentType();
            docType.Id = rdr["DocumentType_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["DocumentType_id"]);
            docType.Parent = rdr["ParentId"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["ParentId"]);
            docType.Ids = rdr["Ids"] == DBNull.Value ? "" : rdr["Ids"].ToString() ?? "";
            docType.Parents = rdr["Parents"] == DBNull.Value ? "" : rdr["Parents"].ToString() ?? "";
            docType.Code = rdr["DocumentType_Code"] == DBNull.Value ? "" : rdr["DocumentType_Code"].ToString() ?? "";
            docType.CurrencyType = rdr["ContractCurrencyType_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["ContractCurrencyType_id"]);
            docType.CountryCurrencyId = rdr["rfr_countryCurr_Id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["rfr_countryCurr_Id"]);
            docType.ViewMaster = rdr["ViewMaster"] == DBNull.Value ? "" : rdr["ViewMaster"].ToString() ?? "";
            docType.ViewDetail = rdr["ViewDetail"] == DBNull.Value ? "" : rdr["ViewDetail"].ToString() ?? "";
            docType.Data = Google.Protobuf.WellKnownTypes.Struct.Parser.ParseJson(rdr["DocumentType_Data"].ToString() ?? "");
            docType.IsDefault = rdr["DocumentType_IsDefault"] == DBNull.Value ? false : Convert.ToBoolean(rdr["DocumentType_IsDefault"]); 



            return docType;

        }

        #endregion
    }
}
