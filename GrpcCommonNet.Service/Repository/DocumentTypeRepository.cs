using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.DocumentType;
using GrpcCommonNet.Library.Product;
using GrpcCommonNet.Proto.Utils;
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
                        t.*, p.DocumentType_Name as ParentName
                    FROM cwatis.documenttypes t
                        left join cwatis.documenttypes p on p.documenttype_id = t.parentid
                    WHERE t.documenttype_id = @id;
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

        public async Task<List<DocumentType>> GetBranchAsync(string head)
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
                _logger.LogError(ex, "Error in GetBranchAsync: " + ex.Message);
                throw;
            }

        }

        public async Task<DocumentType> CreateDocumentTypeAsync(DocumentType documentType)
        {
            try
            {
                DocumentType docType = new DocumentType();
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = $@"
                    INSERT into cwatis.documenttypes (
                        DocumentType_Name,
                        ParentId,
                        DocumentType_Code, 
                        DocumentType_Form, 
                        KindId,  
                        ContractCurrencyType_Id,
                        rfr_countryCurr_Id,
                        ViewMaster, ViewDetail,
                        DocumentType_IsDefault, 
                        Approved_UserId,
                        Approved_By, 
                        Approved_Date)
                    Values (
                        @DocumentType_Name,
                        @ParentId,
                        @DocumentType_Code, 
                        @DocumentType_Form, 
                        @KindId,  
                        @ContractCurrencyType_Id,
                        @rfr_countryCurr_Id,
                        @ViewMaster, ViewDetail,
                        @DocumentType_IsDefault, 
                        @Approved_UserId,
                        @Approved_By, 
                        @Approved_Date
                    );
                    select t.*, p.DocumentType_Name as ParentName
                    from cwatis.DocumentTypes t 
                        left join cwatis.DocumentTypes p on p.DocumentType_Id = t.ParentId
                    where t.DocumentType_Id = LAST_INSERT_ID();
                ";

                cmd.Parameters.AddWithValue("DocumentType_Name", documentType.Name);
                cmd.Parameters.AddWithValue("ParentId", documentType.Parent.Id );
                cmd.Parameters.AddWithValue("DocumentType_Code", documentType.Code);
                cmd.Parameters.AddWithValue("DocumentType_Form", documentType.Form);
                cmd.Parameters.AddWithValue("KindId", documentType.KindId == 0? null: documentType.KindId);
                cmd.Parameters.AddWithValue("ContractCurrencyType_Id", documentType.CurrencyType);
                cmd.Parameters.AddWithValue("DocumentType_Data", documentType.Data);
                cmd.Parameters.AddWithValue("rfr_countryCurr_Id", documentType.CountryCurrencyId == 0? null : documentType.CountryCurrencyId);
                cmd.Parameters.AddWithValue("ViewMaster", documentType.ViewMaster);
                cmd.Parameters.AddWithValue("ViewDetail", documentType.ViewDetail);
                cmd.Parameters.AddWithValue("DocumentType_IsDefault", documentType.IsDefault);
                cmd.Parameters.AddWithValue("Approved_UserId", documentType.Approved == null? null : documentType.Approved.Id == 0? null : documentType.Approved.Id);
                cmd.Parameters.AddWithValue("Approved_By", documentType.Approved == null ? null : documentType.Approved.Symbol);
                cmd.Parameters.AddWithValue("Approved_Date", documentType.Approved == null ? null : documentType.Approved.Date);

                using var rdr = await cmd.ExecuteReaderAsync();

                if (await rdr.ReadAsync())
                {
                    docType = FillDocType(rdr);
                    return docType;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CreateDocumentTypeAsync: " + ex.Message);
                throw;
            }
            return null;
        }

        public async Task<DocumentType> UpdateDocumentTypeAsync(DocumentType documentType)
        {
            try
            {
                DocumentType docType = new DocumentType();
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = $@"
                    UPDATE cwatis.documenttypes t
                    SET 
                        t.DocumentType_Name = @DocumentType_Name,
                        t.ParentId = @ParentId,
                        t.DocumentType_Code = @DocumentType_Code, 
                        t.DocumentType_Form = @DocumentType_Form, 
                        t.KindId = @KindId,  
                        t.ContractCurrencyType_Id = @ContractCurrencyType_Id,
                        t.rfr_countryCurr_Id = @rfr_countryCurr_Id,
                        t.ViewMaster = @ViewMaster, ViewDetail = @ViewDetail,
                        -- t.DocumentType_IsDefault = @DocumentType_IsDefault, 
                        t.Approved_UserId = @Approved_UserId,
                        t.Approved_By = @Approved_By, 
                        t.Approved_Date = @Approved_Date
                    where t.DocumentType_Id = @DocumentType_Id;
                    select t.*, p.DocumentType_Name as ParentName
                    from cwatis.DocumentTypes t 
                        left join cwatis.DocumentTypes p on p.DocumentType_Id = t.ParentId
                    where t.DocumentType_Id = @DocumentType_Id;
                ";

                cmd.Parameters.AddWithValue("DocumentType_Id", documentType.Id);
                cmd.Parameters.AddWithValue("DocumentType_Name", documentType.Name);
                cmd.Parameters.AddWithValue("ParentId", documentType.Parent.Id);
                cmd.Parameters.AddWithValue("DocumentType_Code", documentType.Code);
                cmd.Parameters.AddWithValue("DocumentType_Form", documentType.Form);
                cmd.Parameters.AddWithValue("KindId", documentType.KindId == 0? null : documentType.KindId);
                cmd.Parameters.AddWithValue("ContractCurrencyType_Id", documentType.CurrencyType == 0 ? null : documentType.CurrencyType);
                cmd.Parameters.AddWithValue("DocumentType_Data", documentType.Data);
                cmd.Parameters.AddWithValue("rfr_countryCurr_Id", documentType.CountryCurrencyId == 0 ? null : documentType.CountryCurrencyId);
                cmd.Parameters.AddWithValue("ViewMaster", documentType.ViewMaster);
                cmd.Parameters.AddWithValue("ViewDetail", documentType.ViewDetail);
                cmd.Parameters.AddWithValue("DocumentType_IsDefault", documentType.IsDefault);
                cmd.Parameters.AddWithValue("Approved_UserId", documentType.Approved == null? null : documentType.Approved.Id);
                cmd.Parameters.AddWithValue("Approved_By", documentType.Approved == null ? null : documentType.Approved.Symbol);
                cmd.Parameters.AddWithValue("Approved_Date", documentType.Approved == null ? null : documentType.Approved.Date);

                using var rdr = await cmd.ExecuteReaderAsync();

                if (await rdr.ReadAsync())
                {
                    docType = FillDocType(rdr);
                    return docType;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateDocumentTypeAsync: " + ex.Message);
                throw;
            }
            return null;
        }

        public async Task<DocumentType> MoveDocumentTypeAsync(int id, int newParentId)
        {
            try
            {
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = $@"
                    UPDATE cwatis.documenttypes t
                    SET 
                        t.ParentId = @NewParentId
                    where t.DocumentType_Id = @DocumentType_Id;
                    select t.*, p.DocumentType_Name as ParentName
                    from cwatis.DocumentTypes t 
                        left join cwatis.DocumentTypes p on p.DocumentType_Id = t.ParentId
                    where t.DocumentType_Id = @DocumentType_Id;
                ";
                cmd.Parameters.AddWithValue("DocumentType_Id", id);
                cmd.Parameters.AddWithValue("NewParentId", newParentId);
                var rdr = await cmd.ExecuteReaderAsync();
                if (await rdr.ReadAsync())
                {
                    DocumentType docType = FillDocType(rdr);
                    return docType;
                }
                else return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in MoveDocumentTypeAsync: " + ex.Message);
                throw;
            }
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            try
            {
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"DELETE FROM cwatis.documenttypes t WHERE t.DocumentType_Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);
                var rowsAffected = await cmd.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в DeleteByIdAsync: " + ex.Message);
            }

        }

        public async Task<List<int>> DeleteIdsAsync(IEnumerable<int> ids)
        {
            try
            {
                var deleted = new List<int>();
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = conn.CreateCommand();
                // Build parameters
                var idx = 0;
                var parts = new List<string>();
                foreach (var id in ids)
                {
                    var pname = "@id" + idx++;
                    parts.Add(pname);
                    cmd.Parameters.AddWithValue(pname, id);
                }
                if (parts.Count == 0) return deleted;
                cmd.CommandText =
                   $"DELETE IGNORE FROM cwatis.documenttypes t WHERE t.DocumentType_Id IN ({string.Join(',', parts)}); " +
                   $"SELECT GROUP_CONCAT(t.DocumentType_Id) FROM cwatis.documenttypes t WHERE t.DocumentType_Id IN ({string.Join(',', parts)}); ";

                var rdr = await cmd.ExecuteReaderAsync();

                var listAffected = rdr.Read() ? rdr.GetValue(0) : String.Empty;

                string[] numberStrings = { };
                List<int> Affected = new List<int>();

                if (listAffected != null && !listAffected.ToString().Equals(String.Empty))
                {
                    numberStrings = ((string)listAffected).Split(',');
                    Affected = numberStrings.Select(s => int.Parse(s.Trim())).ToList();
                }

                return Affected;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в DeleteIdsAsync: " + ex.Message);
            }
        }

        #endregion

        #region внутренние методы

        private DocumentType FillDocType(DbDataReader rdr)
        {
            DocumentType docType = new DocumentType();
            docType.Id = rdr["DocumentType_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["DocumentType_id"]);
            docType.Parent = new Tree();
            docType.Parent.Id = rdr["ParentId"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["ParentId"]);
            docType.Parent.Name = rdr["ParentName"] == DBNull.Value ? "" : rdr["ParentName"].ToString();
            docType.Ids = rdr["Ids"] == DBNull.Value ? "" : rdr["Ids"].ToString() ?? "";
            docType.Parents = rdr["Parents"] == DBNull.Value ? "" : rdr["Parents"].ToString() ?? "";
            docType.Name = rdr["DocumentType_Name"] == DBNull.Value ? "" : rdr["DocumentType_Name"].ToString() ?? "";
            docType.Code = rdr["DocumentType_Code"] == DBNull.Value ? "" : rdr["DocumentType_Code"].ToString() ?? "";
            docType.Form = rdr["DocumentType_Form"] == DBNull.Value ? "" : rdr["DocumentType_Form"].ToString() ?? "";
            docType.CurrencyType = rdr["ContractCurrencyType_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["ContractCurrencyType_id"]);
            docType.CountryCurrencyId = rdr["rfr_countryCurr_Id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["rfr_countryCurr_Id"]);
            docType.ViewMaster = rdr["ViewMaster"] == DBNull.Value ? "" : rdr["ViewMaster"].ToString() ?? "";
            docType.ViewDetail = rdr["ViewDetail"] == DBNull.Value ? "" : rdr["ViewDetail"].ToString() ?? "";

            var _data = MyConvert.JsonToStruct(rdr["DocumentType_Data"] == DBNull.Value ? null : rdr["DocumentType_Data"].ToString());
            docType.Data = _data;
            docType.IsDefault = rdr["DocumentType_IsDefault"] == DBNull.Value ? false : Convert.ToBoolean(rdr["DocumentType_IsDefault"]); 



            return docType;

        }

        #endregion
    }
}
