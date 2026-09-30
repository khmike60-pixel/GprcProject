using GrpcCommonNet.Library.Common;
using GrpcWinForms.Objects.Currencies.Presenters;
using GrpcWinForms.Objects.Geolocations.Presenters;
using GrpcWinForms.Objects.Geolocations.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Geolocations.GeoForms
{
    public partial class GeolocationForm : Form, IGeolocation
    {
        private readonly GeolocationPresenter _presenter;
        public Geolocation GeoParentObject { get; set; }

        #region Поля формы

        public string GeoName { get => txtName.Text; set => txtName.Text = value; }
        public string GeoNameLat { get => txtNameLat.Text; set => txtNameLat.Text = value; }
        public string GeoParentName { get => txtParent.Text; set => txtParent.Text = value; }
        public bool GeoIsCountry { get => chkIsCountry.Checked; set => chkIsCountry.Checked = value; }
        public string GeoCode2 { get => txtCode2.Text; set => txtCode2.Text = value; }
        public string GeoCode3 { get => txtCode3.Text; set => txtCode3.Text = value; }
        public string GeoDigit { get => txtCodeDig.Text; set => txtCodeDig.Text = value; }
        public string GeoPhone { get => txtPhone.Text; set => txtPhone.Text = value; }

        #endregion

        private Geolocation geolocation { get; set; } = new Geolocation();

        public Geolocation Geolocation { get => geolocation; set => geolocation = value; }

        #region Вызываемые события 

        public event Func<Task> OnClick_OkAsync;

        #endregion


        public GeolocationForm()
        {
            InitializeComponent();
            _presenter = new GeolocationPresenter(this);

        }

        private async void btnOk_Click(object sender, EventArgs e)
        {
            OnClick_OkAsync?.Invoke();
            if (Geolocation != null)
                this.DialogResult = DialogResult.OK;
            else 
                MessageBox.Show("Добавление документа не удалось");

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GeolocationForm_Load(object sender, EventArgs e)
        {
            GeoParentName = GeoParentObject.Name;
            GeoIsCountry = GeoParentObject.Id == 0 ? true : false;
        }
    }
}
