using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Product;
using GrpcCommonNet.Proto.Utils;
using GrpcCommonNet.Service.Models;
using Microsoft.AspNetCore.Identity;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Data;
using System.Data.Common;
using System.Reflection.PortableExecutable;

namespace GrpcCommonNet.Service.Repository
{
    public class ProductRepository
    {
        private readonly string _connectionString = "";
        private readonly ILogger<ContragentRepository> _logger;
        private readonly string sqlTree =
            $@"
CREATE TEMPORARY TABLE IF NOT EXISTS Tmp (
	id int PRIMARY KEY
);

TRUNCATE TABLE Tmp;

-- Вставка уникальных значений из поля ids таблицы Products в таблицу Tmp
INSERT IGNORE INTO Tmp (id)
WITH RECURSIVE CteRecursiveIds (product_id, id_str, remainder) AS ( 
-- Базовый член: инициализация для каждой строки в Products
    SELECT
        P.MGoodGroupId product_id,
        SUBSTRING_INDEX(P.ParentIds, ',', 1) AS id_str,
        -- Остаток строки после первого числа
        SUBSTRING(P.ParentIds, LENGTH(SUBSTRING_INDEX(P.ParentIds, ',', 1)) + 2) AS remainder
    FROM global_db.rfr_goods_tree P
		LEFT JOIN global_db.good_trademarks TM ON TM.Id = P.GoodTrademarkId
 
    WHERE 1 = 1
		AND (REPLACE(TRIM(IFNULL(@_MCode, '')), '%', '') = ''
			OR P.MCode LIKE CONCAT('%',@_MCode,'%')
			OR P.Name LIKE CONCAT('%',@_MCode,'%'))
		AND (IFNULL(@_ProducerId, 0) = 0 OR P.ProducerId = @_ProducerId)
		AND (REPLACE(TRIM(IFNULL(@_ProducerGoodCode, '')), '%', '') = '' OR P.ProducerGoodCode LIKE CONCAT('%',@_ProducerGoodCode,'%'))
		AND (REPLACE(TRIM(IFNULL(@_OurGoodCode, '')), '%', '') = '' OR P.OurGoodCode LIKE CONCAT('%',@_OurGoodCode,'%'))
		AND (REPLACE(TRIM(IFNULL(@_GoodTradeMarkName, '')), '%', '') = '' OR TM.Name LIKE CONCAT('%',@_GoodTradeMarkName,'%'))
		AND (@_Act = 0
				OR (@_Act = 1  AND P.Card_Show_Flag = 0 )
				OR (@_Act = 2  AND P.Card_Show_Flag = 1 )
				OR (@_Act = 3  AND P.Card_Show_Flag = 2 )
         )
		and P.IsGoodKind = 1
    	and LENGTH(P.ParentIds) > 0
    UNION ALL
    -- Рекурсивный член: извлечение следующего числа
    SELECT
        C.product_id,
        SUBSTRING_INDEX(C.remainder, ',', 1) AS id_str,
        -- Новый остаток строки
        SUBSTRING(C.remainder, LENGTH(SUBSTRING_INDEX(C.remainder, ',', 1)) + 2) AS remainder
    FROM CteRecursiveIds C
    -- Условие продолжения рекурсии
    WHERE C.remainder != ''
)
-- Окончательный выбор уникальных значений для вставки
SELECT DISTINCT CAST(id_str AS UNSIGNED) AS id
FROM CteRecursiveIds
-- Если строка начинается с запятой или пуста после обработки (хотя WHERE P.ids > 0 уже помогает)
WHERE id_str REGEXP '^[0-9]+$'
ON DUPLICATE KEY UPDATE id = id; -- Используется IGNORE или ON DUPLICATE для обработки уникальности
";

        public ProductRepository(ILogger<ContragentRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("MySql");
        }

        #region  Методы получения дынных для дерева
        public async Task<List<CatalogLine>> TreeAsync(CatalogFilterRequest request, UserData userData)
        {
            List<CatalogLine> catalogLines = new List<CatalogLine>();
            try
            {
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = sqlTree;  // Получение временной таблицы Tmp с нужными id
                cmd.CommandText += $@"
                    select T.*, P.*
	                from global_db.rfr_goods_tree P
	                    left join Tmp T on T.id = P.MGoodGroupId
                    where 1 = 1
	                    and P.IsGood = 0 and P.IsWork = 0 and P.IsService = 0
	                    and id is not null
                    order by P.ParentMCodes ;
                ";

                cmd.Parameters.AddWithValue("@_MCode", request.Name);
                cmd.Parameters.AddWithValue("@_ID", request.Id);
                cmd.Parameters.AddWithValue("@_IsWork", (int)request.Type);
                cmd.Parameters.AddWithValue("@_TotalNotNull", null);
                cmd.Parameters.AddWithValue("@_ProducerGoodCode", request.ProducerCode);
                cmd.Parameters.AddWithValue("@_OurGoodCode", request.OurCode);
                cmd.Parameters.AddWithValue("@_GoodTradeMarkName", request.TrademarkName);
                cmd.Parameters.AddWithValue("@_Act", request.Actived);
                cmd.Parameters.AddWithValue("@_ShowAllTree", null);
                cmd.Parameters.AddWithValue("_ProducerId", null);

                using var rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    CatalogLine catalogLine = new CatalogLine();
                    catalogLine = CatalogLineFill(rdr);
                    catalogLines.Add(catalogLine);
                }
                return catalogLines;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в TreeAsync:", ex);
            }
        }
        #endregion

        #region Методы получение данных "товаров"
        public async Task<List<Product>> ListAsync(ProductFilterRequest request, UserData userData)
        {
            List<Product> products = new List<Product>();
            try
            {
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = sqlTree;         // Получение временной таблицы Tmp с нужными id
                cmd.CommandText += $@"
                    select P.*, TM.*
                    from global_db.rfr_goods_tree P
	                    LEFT JOIN global_db.good_trademarks TM ON TM.Id = P.GoodTrademarkId
                    where 1 = 1
	                    and (P.IsGood = 1 or P.IsWork = 1 or P.IsService = 1)
	                    AND (REPLACE(TRIM(IFNULL(@_MCode, '')), '%', '') = ''
		                    OR P.MCode LIKE CONCAT('%',@_MCode,'%')
		                    OR P.Name LIKE CONCAT('%',@_MCode,'%'))
	                    AND (IFNULL(@_ProducerId, 0) = 0 OR P.ProducerId = @_ProducerId)
	                    AND (REPLACE(TRIM(IFNULL(@_ProducerGoodCode, '')), '%', '') = '' OR P.ProducerGoodCode LIKE CONCAT('%',@_ProducerGoodCode,'%'))
	                    AND (REPLACE(TRIM(IFNULL(@_OurGoodCode, '')), '%', '') = '' OR P.OurGoodCode LIKE CONCAT('%',@_OurGoodCode,'%'))
	                    AND (REPLACE(TRIM(IFNULL(@_GoodTradeMarkName, '')), '%', '') = '' OR TM.Name LIKE CONCAT('%',@_GoodTradeMarkName,'%'))
	                    AND (@_Act = 0
		                    OR (@_Act = 1  AND P.Card_Show_Flag = 0 )
		                    OR (@_Act = 2  AND P.Card_Show_Flag = 1 )
		                    OR (@_Act = 3  AND P.Card_Show_Flag = 2 )
	                    )
                        order by P.ParentMCodes, P.Name;";
                cmd.Parameters.AddWithValue("@_MCode", request.NameCode);
                cmd.Parameters.AddWithValue("@_ID", 0);
                cmd.Parameters.AddWithValue("@_IsWork", 0);
                cmd.Parameters.AddWithValue("@_TotalNotNull", null);
                cmd.Parameters.AddWithValue("@_ProducerGoodCode", "");
                cmd.Parameters.AddWithValue("@_OurGoodCode", "");
                cmd.Parameters.AddWithValue("@_GoodTradeMarkName", "");
                cmd.Parameters.AddWithValue("@_Act", 0);
                cmd.Parameters.AddWithValue("@_ShowAllTree", null);
                cmd.Parameters.AddWithValue("_ProducerId", null);


                using var rdr = await cmd.ExecuteReaderAsync();
                DataTable schemaTable = rdr.GetSchemaTable();

                while (await rdr.ReadAsync())
                {
                    Product product = new Product();
                    product = ProductFill(rdr,  schemaTable);
                    products.Add(product);
                }
                return products;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в ListAsync:", ex);
            }
        }


        #endregion

        #region  Внутренние методы

        private CatalogLine CatalogLineFill(DbDataReader rdr)
        {
            CatalogLine catalogLine = new CatalogLine();
            catalogLine.Id = rdr["MGoodGroupId"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["MGoodGroupId"]);
            catalogLine.ParentId = rdr["ParentId"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["ParentId"]);
            catalogLine.ParentIds = rdr["ParentIds"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["ParentIds"]);
            catalogLine.Name = rdr["MCode"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["MCode"]);
            catalogLine.ParentNames = rdr["ParentMCodes"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["ParentMCodes"]);
            //catalogLine.IsProductKind = rdr["IsGoodKind"] == DBNull.Value ? false : Convert.ToBoolean(rdr["IsGoodKind"]);

            return catalogLine;
        }

        private Product ProductFill(DbDataReader rdr, DataTable  schema)
        {
            Product product = new Product();

            product.Id = rdr["MGoodGroupId"] == null ? 0 : Convert.ToInt32(rdr["MGoodGroupId"]);
            product.Name = rdr["MCode"] == null ? string.Empty : Convert.ToString(rdr["MGoodGroupId"]);
            product.ParentId = rdr["ParentId"] == null ? 0 : Convert.ToInt32(rdr["ParentId"]);
            product.ParentIds = rdr["ParentIds"] == null ? string.Empty : Convert.ToString(rdr["ParentIds"]);
            product.ParentIds = rdr["ParentMCodes"] == null ? string.Empty : Convert.ToString(rdr["ParentMCodes"]);
            //product.IsProductKind = rdr["IsGoodKind"] == null ? false : Convert.ToBoolean(rdr["IsGoodKind"]);
            //product.IsList = rdr["IsGood"] == null ? false : Convert.ToBoolean(rdr["IsGood"]);
            if (rdr["IsService"] != null && Convert.ToBoolean(rdr["IsService"]) == true) 
                product.Type = TypeProduct.Service;
            else 
                product.Type = TypeProduct.Goods;
            product.UnitId = rdr["UnitId"] == null ? 0 : Convert.ToInt64(rdr["UnitId"]);
            product.ProducerCode  = rdr["ProducerGoodCode"] == null ? string.Empty : Convert.ToString(rdr["ProducerGoodCode"]);
            product.OurCode = rdr["OurGoodCode"] == null ? string.Empty : Convert.ToString(rdr["OurGoodCode"]);
            product.NameOur = rdr["Name"] == null ? string.Empty : Convert.ToString(rdr["Name"]);
            product.NamePricelist = rdr["PLName"] == null ? string.Empty : Convert.ToString(rdr["PLName"]);
            
            decimal units = rdr["QtyForPrice_Purchase_Global"] == null ? 0 : Convert.ToDecimal(rdr["QtyForPrice_Purchase_Global"]);
            int scale = (int)schema.Rows[16]["NumericScale"];
            product.PurchaseQty = rdr["QtyForPrice_Purchase_Global"] == null ? 
                MyConvert.ToDecimalValue(0, scale) : 
                MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["QtyForPrice_Purchase_Global"]), scale); 

            return product;
        }

        #endregion

    }
}
