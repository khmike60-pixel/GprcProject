using C1.Win.FlexGrid;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contragent;
using SmartGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Contragents.Components
{
    public partial class TestForm : Form
    {

        public TestForm()
        {
            InitializeComponent();

            lookup.DataProviderAsync = SearchCustomers;
            lookup.Columns.Add(new LookupColumn
            {
                Name = "id",
                Caption = "ID",
                Width = 60
            });

            lookup.Columns.Add(new LookupColumn
            {
                Name = "name",
                Caption = "Customer",
                Width = 250
            });

        }

        private void TestForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selected Id = " + lookup.SelectedValue);
        }

        private async Task<IEnumerable<LookupRow>> SearchCustomers(string text)
        {
            try
            {
                var type = ContragentTypeFilter.All;

                ContragentFilterRequest request = new ContragentFilterRequest()
                {
                    TypeFilter = type,
                    Name = text
                };
                request.FieldMask = new Google.Protobuf.WellKnownTypes.FieldMask()
                {
                    Paths = { "id", "name" }
                };
                ListContragentResponse response = await GrpcClients.GrpcClients.Contragent.ShortListContragentAsync(request);

                List<LookupRow> rows = new List<LookupRow>();
                foreach (var r in response.Contragents)
                {
                        LookupRow row = new LookupRow();
                        row.Values = new Dictionary<string, object>();
                        row.Values["id"]    = r.Id;
                        row.Values["name"] = r.Name;
                        rows.Add(row);
                }
                return rows;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
    }

}
