using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contragent;
using GrpcWinForms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.OurCompanies.Forms
{
    public partial class OurCompaniesForm : Form
    {
        private static ContragentServices.ContragentServicesClient _service;
        private Loader loaderContragent = new Loader();

        public OurCompaniesForm()
        {
            InitializeComponent();

            loaderContragent.Parent = smartGrid;
            loaderContragent.Size = smartGrid.Size;

            c1SplitterPanel2.Collapsed = true;
        }

        private void OurCompanies_Load(object sender, EventArgs e)
        {
            comboBoxType.SelectedIndex = 0;
            Refresh(sender, e);

        }

        private async Task<bool> Refresh(object sender, EventArgs e)
        {
            loaderContragent.ShowLoader();
            try
            {
                var type = comboBoxType.SelectedIndex == 0 ? ContragentTypeFilter.All :
                           comboBoxType.SelectedIndex == 1 ? ContragentTypeFilter.EntityFilter :
                           comboBoxType.SelectedIndex == 2 ? ContragentTypeFilter.PersonFilter : ContragentTypeFilter.UnknownFilter;

                ContragentFilterRequest request = new ContragentFilterRequest()
                {
                    TypeFilter = type,
                    Taxno = string.IsNullOrWhiteSpace(textBoxTaxno.Text) ? String.Empty : textBoxTaxno.Text,
                    Name = string.IsNullOrWhiteSpace(textBoxName.Text) ? String.Empty : textBoxName.Text,
                    //CountrySymbol = comboBoxCountry.SelectedValue.ToString() ?? String.Empty
                };
                request.FieldMask = new Google.Protobuf.WellKnownTypes.FieldMask()
                {
                    Paths = { "id", "name", "taxno", "type", "country_symbol" }
                };
                //CountListContragentResponse responseCount = await GrpcClients.GrpcClients.Contragent.CountListContragentAsync(request);

                //ListContragentResponse response = await GrpcClients.GrpcClients.Contragent.GetListContragentAsync(request);
                ListContragentResponse response = await GrpcClients.GrpcClients.Contragent.GetListOurCompanyAsync(request);


                BindingList<Contragent> contragents = new BindingList<Contragent>(response.Contragents);
                smartGrid.DataSource = contragents;
                loaderContragent.HideLoader();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                // test

            }
        }
    }
}
