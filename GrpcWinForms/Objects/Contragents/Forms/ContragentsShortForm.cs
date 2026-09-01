using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contract;
using GrpcCommonNet.Library.Contragent;
using GrpcWinForms.GrpcUtils;
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

namespace GrpcWinForms.Objects.Contragents.Forms
{
    public partial class ContragentsShortForm : Form
    {
        private Loader loaderContragent = new Loader();
        private Contragent selectedItem;

        public Contragent SelectedItem { get => selectedItem; }
        public ContragentTypeFilter TypeFilter { get; set; } = ContragentTypeFilter.All;
        public bool ContragentTypeEnable { get; set; } = true;
        public bool CheckedPrefixEnable { get; set; } = true;
        public bool CheckedPrefix { get => chkPrefix.Checked; set => chkPrefix.Checked = value; }

        public bool DialogMode { get; set; } = false;

        public ContragentsShortForm()
        {
            InitializeComponent();
        }

        private async void RefreshContragents()
        {
            loaderContragent.ShowLoader();
            try
            {
                ContragentTypeFilter type;
                if (comboBoxType.SelectedIndex == -1)
                    type = TypeFilter;
                else
                    type = comboBoxType.SelectedIndex <= 0 ? ContragentTypeFilter.All :
                           comboBoxType.SelectedIndex == 1 ? ContragentTypeFilter.EntityFilter :
                           comboBoxType.SelectedIndex == 2 ? ContragentTypeFilter.PersonFilter :
                           ContragentTypeFilter.UnknownFilter;
                comboBoxType.SelectedIndex = type == ContragentTypeFilter.All ? 0 :
                                             type == ContragentTypeFilter.EntityFilter ? 1 :
                                             type == ContragentTypeFilter.PersonFilter ? 2 : 3;

                comboBoxType.Enabled = ContragentTypeEnable;
                chkPrefix.Enabled = CheckedPrefixEnable;

                ContragentFilterRequest request = new ContragentFilterRequest()
                {
                    TypeFilter = type,
                    Taxno = string.IsNullOrWhiteSpace(textBoxTaxno.Text) ? String.Empty : textBoxTaxno.Text,
                    Name = string.IsNullOrWhiteSpace(textBoxName.Text) ? String.Empty : textBoxName.Text,
                    PrefixNotEmpty = chkPrefix.Checked,
                    Prefix = textBoxPrefix.Text
                    //CountrySymbol = comboBoxCountry.SelectedValue.ToString() ?? String.Empty
                };
                request.FieldMask = new Google.Protobuf.WellKnownTypes.FieldMask()
                {
                    Paths = { "id", "name", "taxno", "type", "prefix" }
                };
                //CountListContragentResponse responseCount = await GrpcRetry.CallAsync(() =>
                //    GrpcClients.GrpcClients.Contragent.CountListContragentAsync(request).ResponseAsync
                //);

                ListContragentResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Contragent.ShortListContragentAsync(request).ResponseAsync
                );


                BindingList<Contragent> contragents = new BindingList<Contragent>(response.Contragents);
                smartGrid1.DataSource = contragents;
                loaderContragent.HideLoader();
            }
            catch (Exception ex)
            {
                loaderContragent.HideLoader();
                MessageBox.Show(String.Join(Environment.NewLine, "Ошибка при получении контрагентов", ex.Message),
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ContragentsShortForm_Load(object sender, EventArgs e)
        {
            RefreshContragents();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshContragents();
        }

        private void smartGrid1_DoubleClick(object sender, EventArgs e)
        {
            if (DialogMode)
            {
                int row = smartGrid1.Row; 
                if (row < smartGrid1.Rows.Fixed) return;
                selectedItem = smartGrid1.Rows[row].DataSource as Contragent;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
