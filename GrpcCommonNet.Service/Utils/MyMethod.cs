using System.Data.Common;

namespace GrpcCommonNet.Service.Utils
{
    public static class MyMethod
    {
        public static bool HasColumn(DbDataReader reader, string columnName)
        {
            bool result = true;
            try
            {
                int i = reader.GetOrdinal(columnName);
                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }
    }
}
