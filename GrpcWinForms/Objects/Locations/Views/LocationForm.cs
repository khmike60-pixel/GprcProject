using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcWinForms.Objects.Locations.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Locations.Views
{
    public partial class LocationForm : Form, ILocation
    {
        private const string _country = "Страна";
        private const string _city = "Регион или город";
        private const string _place = "Место расположения";

        public Location CurrentLocation { get; set; }

        public LocationType Type { get; }
        public Location LocationParent
        {
            get
            {
                if (CurrentLocation.Parent == null || CurrentLocation.Parent.Id == 0)
                    return null;
                else
                    return CurrentLocation.Parent;
            }
        }
        public string LocationName { get => txtName.Text; set => txtName.Text = value; }
        public string LocationParentName { get => txtParent.Text; set => txtParent.Text = value; }
        public LocationType LocationType
        {
            get {
                switch (CurrentLocation.Type)
                {
                    case GrpcCommonNet.Library.Common.LocationType.LocationCountry:
                        txtType.Text = _country;
                        break;
                    case GrpcCommonNet.Library.Common.LocationType.LocationCity:
                        txtType.Text = _city;
                        break;
                    case GrpcCommonNet.Library.Common.LocationType.LocationPlace:
                        txtType.Text = _place;
                        break;
                    default:
                        txtType.Text = _country;
                        break;
                }
                return CurrentLocation.Type;
            }
            set  
            {
                switch (value)
                {
                    case GrpcCommonNet.Library.Common.LocationType.LocationCountry:
                        txtType.Text = _country;
                        break;
                    case GrpcCommonNet.Library.Common.LocationType.LocationCity:
                        txtType.Text = _city;
                        break;
                    case GrpcCommonNet.Library.Common.LocationType.LocationPlace:
                        txtType.Text = _place;
                        break;
                    default:
                        txtType.Text = _country;
                        break;
                }
            }
        }
        public string LocationCode2 { get => txtCode2.Text; set => txtCode2.Text = value; }
        public string LocationCode3 { get => txtCode3.Text; set => txtCode3.Text = value; }
        public string LocationCodeDigit { get => txtCodeDig.Text; set => txtCodeDig.Text = value; }
        public string LocationSOATO { get => txtCode3.Text; set => txtCode3.Text = value; }
        public string LocationPhoneCode { get => txtPhone.Text; set => txtPhone.Text = value; }
        public string LocationNameLat { get => txtNameLat.Text; set => txtNameLat.Text = value; }
        public string LocationTypeString 
        { get
            {
                switch (CurrentLocation.Type)
                {
                    case GrpcCommonNet.Library.Common.LocationType.LocationCountry:
                        txtParent.Text = _country;
                        break;
                    case GrpcCommonNet.Library.Common.LocationType.LocationCity:
                        txtParent.Text = _city;
                        break;
                    case GrpcCommonNet.Library.Common.LocationType.LocationPlace:
                        txtParent.Text = _place;
                        break;
                    default:
                        txtParent.Text = _country;
                        break;
                }
                return txtParent.Text;
            }
            set 
            {
                switch (value)
                {

                }
            }

        }

        public LocationForm()
        {
            InitializeComponent();
        }

        private void LocationForm_Load(object sender, EventArgs e)
        {
            try
            {
                LocationName = CurrentLocation.Name;
                LocationNameLat = CurrentLocation.NameLat;
                LocationParentName = CurrentLocation.Names;
                LocationType = CurrentLocation.Type;

                string jsonString = JsonFormatter.Default.Format(CurrentLocation.Data);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true }; // Стандартный сериализатор нечувствительный к регистру

                LocationType type = CurrentLocation.Type;
                switch (type)
                {
                    case LocationType.LocationCountry:
                        lblCode2.Text = "Код страны (2 симв.):"; lblCode2.Visible = true; txtCode2.Enabled = true;
                        lblCode3.Text = "Код страны (3 симв.):"; lblCode3.Visible = true; txtCode3.Enabled = true;
                        lblCodeDigit.Text = "Код страны (числ.)"; lblCodeDigit.Visible = true; txtCodeDig.Enabled = true; txtCodeDig.Visible = true;
                        lblPhone.Text = "Телефонный код:"; lblPhone.Visible = true; txtPhone.Enabled = true;


                        CountryLocation country = JsonSerializer.Deserialize<CountryLocation>(jsonString, options);
                        txtCode2.Text = country.Code2?.ToString();
                        txtCode3.Text = country.Code3?.ToString();
                        txtCodeDig.Text = country.CodeDigit?.ToString();
                        txtPhone.Text = country.PhoneCode?.ToString();

                        break;
                    case LocationType.LocationCity:
                        lblCode2.Text = "Код страны (2 симв.):"; lblCode2.Visible = true; txtCode2.Enabled = true;
                        lblCode3.Text = "Код региона:"; lblCode3.Visible = true; txtCode3.Enabled = true;
                        lblCodeDigit.Text = ""; lblCodeDigit.Visible = false; txtCodeDig.Enabled = false; txtCodeDig.Visible = false;
                        lblPhone.Text = "Телефонный код:"; lblPhone.Visible = true; txtPhone.Enabled = true;

                        CityLocation city = JsonSerializer.Deserialize<CityLocation>(jsonString, options);
                        txtCode2.Text = city.Code2?.ToString();
                        txtCode3.Text = city.SOATO?.ToString();
                        txtPhone.Text = city.PhoneCode?.ToString();

                        break;
                    case LocationType.LocationPlace:
                        lblCode2.Text = ""; lblCode2.Visible = false; txtCode2.Enabled = false;
                        lblCode3.Text = ""; lblCode3.Visible = false; txtCode3.Enabled = false;
                        lblCodeDigit.Text = ""; lblCodeDigit.Visible = false; txtCodeDig.Enabled = false; txtCodeDig.Visible = false;
                        lblPhone.Text = "Телефонный код:"; lblPhone.Visible = true; txtPhone.Enabled = true;

                        PlaceLocation place = JsonSerializer.Deserialize<PlaceLocation>(jsonString, options);
                        txtPhone.Text = place.PhoneCode?.ToString();
                        lblPhone.Text = "Телефонный код:"; lblPhone.Visible = true; txtPhone.Enabled = true;

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при заполнении формы");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.OK;
            Location location = new()
            {
                Name = txtName.Text,
                NameLat = txtNameLat.Text,
                ParentId = CurrentLocation.ParentId,
                Parent = CurrentLocation.Parent,
                Type = CurrentLocation.Type,
                Data = new()
            };
            // Сериализуем класс в JSON-строку (желательно в camelCase)
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string jsonString = "";

            switch (CurrentLocation.Type)
            {
                case LocationType.LocationCountry:
                    CountryLocation country = new CountryLocation()
                    {
                        Code2 = txtCode2.Text,
                        Code3 = txtCode3.Text,
                        CodeDigit = txtCodeDig.Text,
                        PhoneCode = txtPhone.Text
                    };
                    jsonString = JsonSerializer.Serialize(country, options);
                    break;
                case LocationType.LocationCity:
                    CityLocation city = new CityLocation()
                    {
                        Code2 = txtCode2.Text,
                        SOATO = txtCode3.Text,
                        PhoneCode = txtPhone.Text
                    };
                    jsonString = JsonSerializer.Serialize(city, options);
                    break;
                case LocationType.LocationPlace:
                    PlaceLocation place = new PlaceLocation()
                    {
                        PhoneCode = txtPhone.Text
                    };
                    jsonString = JsonSerializer.Serialize(place, options);
                    break;
            }
            location.Data = JsonParser.Default.Parse<Struct>(jsonString);
            CurrentLocation = location;
            Close();

        }
    }
}
