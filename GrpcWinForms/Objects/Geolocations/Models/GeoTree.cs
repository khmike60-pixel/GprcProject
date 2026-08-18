using SmartGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Geolocations.Models
{
    public class GeoTree : SmartLib.ITreeData
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public int ParentId { get; set; } = 0;
        public string Code2 { get; set; } = string.Empty;
        public string NameLat {  get; set; } = string.Empty;
        public string PhoneCode { get; set; } = string.Empty;
        public bool Lock { get; set; } = false;
        public string JsonCode {  get; set; } = string.Empty;

        public string JsonCode2 { get { return CodeCountry2(JsonCode); } }
        public string JsonCode3 { get { return CodeCountry3(JsonCode); } }
        public string JsonDigit { get { return CodeCountryDigit(JsonCode); } }
        public string JsonSoato { get { return CodeSoato(JsonCode); } }


        public GeoTree() { }

        private string CodeCountry2(string json)
        {
            CountryCodes countryCodes = JsonSerializer.Deserialize<CountryCodes>(json);
            return countryCodes.Code2;
        }

        private string CodeCountry3(string json)
        {
            if (json.Equals(string.Empty)) return "";
            CountryCodes countryCodes = JsonSerializer.Deserialize<CountryCodes>(json);
            return countryCodes.Code3;
        }

        private string CodeCountryDigit(string json)
        {
            if (json.Equals(string.Empty)) return "";
            CountryCodes countryCodes = JsonSerializer.Deserialize<CountryCodes>(json);
            return countryCodes.CodeDigit;
        }

        private string CodeSoato(string json)
        {
            if (json.Equals(string.Empty)) return "";
            CountryCodes countryCodes = JsonSerializer.Deserialize<CountryCodes>(json);
            return countryCodes.Soato;
        }
    }

    public class CountryCodes
    {
        public string Code2 { get; set; } = string.Empty;
        public string Code3 {  get; set; } = string.Empty;
        public string CodeDigit {  get; set; } = string.Empty;
        public string Soato {  get; set; } = string.Empty;
    } 
}
