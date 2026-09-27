using GrpcCommonNet.Library.Common;
using GrpcWinForms.Objects.Geolocations.GeoForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.SalePurchaseTypes.Forms
{
    public partial class SalePurchaseTypeForm : Form
    {


        public SalePurchaseTypeForm()
        {
            InitializeComponent();
        }

        private void cbCountry_ModalButtonClick(object sender, EventArgs e)
        {
            using (GeolocationsForm geolocationForm = new GeolocationsForm())
            {

                if (geolocationForm.DialogResult == DialogResult.OK)
                { 
                    Geolocation country = geolocationForm.SelectedItem as Geolocation;

                }
            }
        }
    }
}
