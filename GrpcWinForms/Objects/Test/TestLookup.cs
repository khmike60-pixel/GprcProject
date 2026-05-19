using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contragent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Test
{
    public partial class TestLookup : Form
    {
        public TestLookup()
        {
            InitializeComponent();

            lookup.DataProvider =
                new ContragentLookupProvider();

            lookup.ValueSelected += (s, e) =>
            {
                Contragent contragent =
                    (Contragent)e.Tag;

                MessageBox.Show(contragent.Name);
            };
            this.Controls.Add(lookup);
        }
    }
    public class ContragentLookupProvider : ISmartLookupDataProvider<LookupItem>
    {
        public async Task<List<LookupItem>> SearchAsync(
            string text,
            int take = 20)
        {
            var request = new ContragentFilterRequest
            {
                Name = text,
                Paging = new Paging
                {
                    PageNumber = 1,
                    PageSize = take
                }
            };

            var response =
                await GrpcClients.GrpcClients.Contragent
                    .ShortListContragentAsync(request);

            return response.Contragents
                .Select(x => new LookupItem
                {
                    Value = x.Id,
                    DisplayText = x.Name,
                    Tag = x
                })
                .ToList();
        }
    }
}
