using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace GrpcCommonNet.Proto.Utils
{
    public static class MyConvert 
    {
        public static Decimal ToDecimal(DecimalValue value)
        {
            if (value == null) return 0;
            return (decimal)(value.Units / Math.Pow(10,value.Scale));
        }

        public static DecimalValue ToDecimalValue(decimal? value, int scale)
        {
            if (value == null) 
                return new DecimalValue { Units = 0, Scale = scale };
            return new DecimalValue{ Units = (long)((double)value * Math.Pow(10, scale)), Scale = scale };    
        }

        public static DecimalValue ToDecimalValueField(DbDataReader rdr, string fieldName, DataTable? schema = null)
        {
            if (string.IsNullOrEmpty(fieldName)) return new DecimalValue { };
            if (schema == null) schema = rdr.GetSchemaTable();
            
            for (int i = 0; i < schema.Rows.Count; i++) 
            {
                DataRow row = schema.Rows[i];
                if (row["ColumnName"].ToString() == fieldName)
                {
                    if (rdr[i] == null) break;
                    int scale = Convert.ToInt32(row["NumericScale"].ToString());
                    return new DecimalValue { Units = (long)(rdr.GetDouble(i) * Math.Pow(10, scale)), Scale = scale};
                }
            }
            return new DecimalValue { };
        }

        public static class ProtoConverter
        {
            public static DataNode ToNodeTree(Struct str, string rootName = "Root")
            {
                var root = new DataNode { Name = rootName };
                foreach (var field in str.Fields)
                {
                    root.Children.Add(ProcessValue(field.Key, field.Value));
                }
                return root;
            }

            private static DataNode ProcessValue(string name, Value value)
            {
                var node = new DataNode { Name = name };

                switch (value.KindCase)
                {
                    case Value.KindOneofCase.StructValue:
                        foreach (var field in value.StructValue.Fields)
                            node.Children.Add(ProcessValue(field.Key, field.Value));
                        break;

                    case Value.KindOneofCase.ListValue:
                        int index = 0;
                        foreach (var item in value.ListValue.Values)
                            node.Children.Add(ProcessValue($"[{index++}]", item));
                        break;

                    default:
                        // String, Number, Bool, NullValue
                        node.Value = value.KindCase switch
                        {
                            Value.KindOneofCase.StringValue => value.StringValue,
                            Value.KindOneofCase.NumberValue => value.NumberValue,
                            Value.KindOneofCase.BoolValue => value.BoolValue,
                            Value.KindOneofCase.NullValue => null,
                            _ => null
                        };
                        break;
                }

                return node;
            }
        }

    }

    public class DataNode
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public List<DataNode> Children { get; set; } = new();

        // Вспомогательное свойство для проверки, лист это или ветка
        public bool IsLeaf => Children.Count == 0;
    }
}
