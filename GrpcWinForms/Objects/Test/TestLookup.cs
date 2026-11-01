using C1.Win.FlexGrid;
using C1.Win.Input;
using C1.Win.Input.MultiColumnCombo;
using C1.Win.TreeView;
using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contract;
using GrpcCommonNet.Library.Contragent;
using GrpcCommonNet.Library.Currency;
using GrpcCommonNet.Library.Department;
using GrpcCommonNet.Library.Geolocation;
using GrpcCommonNet.Proto.Utils;
using GrpcWinForms.Controls.CompanyDropDown;
using GrpcWinForms.Controls.PeriodControl;
using GrpcWinForms.Controls.TreeBox;
using GrpcWinForms.Controls.SmartBox;
using GrpcWinForms.Controls.TreeBox;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Objects.Contracts.Forms;
using GrpcWinForms.Objects.Contracts.Models;
using GrpcWinForms.Objects.Contragents.Forms;
using GrpcWinForms.Objects.Currencies.Views;
using GrpcWinForms.Objects.Departaments;
using GrpcWinForms.Objects.Departaments.Forms;
using GrpcWinForms.Objects.Stocks.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Currency = GrpcCommonNet.Library.Common.Currency;

namespace GrpcWinForms.Objects.Test
{
    public partial class TestLookup : Form
    {
        private C1TreeView tree = new C1TreeView();
        private StocksReposirory _reposirory;
        private List<GeoPlace> geoplaces = new();


        public TestLookup()
        {
            InitializeComponent();
            _reposirory = new StocksReposirory();
        }

        private void buttonCancel_Click(object sender, EventArgs e) // Cancel
        {
            MessageBox.Show(string.Join(Environment.NewLine,
                $"Склад : Id = {places.SelectedNode.Id}, Name = {places.SelectedNode.Name}"
                ));
        }

        private async void TestLookup_Load(object sender, EventArgs e)
        {
            try
            {

                Stock stock = new Stock()
                {
                    Id = 2,
                    Name = "Центральный офис",
                    Place = new Place
                    {
                        Id = 77,
                        Name = "Кичик Бешагач 86 (Центральный офис)"
                    }
                };

                StocksReposirory reposirory = new StocksReposirory();
                geoplaces = await StocksReposirory.GetGeoPlacesAsync(new Stock());


                List<TreeItem> items = new List<TreeItem>();
                foreach (GeoPlace g_place in geoplaces)
                {
                    items.Add(
                        new TreeItem()
                        {
                            Id = g_place.Id,
                            ParentId = g_place.ParentId,
                            Name = g_place.Place.Name
                        }
                    );

                }
                TreeItem treeItem = new TreeItem() { Id =  3, ParentId =  0, Name = "А. Каххара склад" };
                BindingInfo building = places.BuildTree(items);
                places.InitialNode  = items.FirstOrDefault(x => x.Id == treeItem.Id);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private BindingList<Company> LoadCompanies(string name)
        {
            SearchRequest searchRequest = new()
            {
                Search = name,
                Paging = new() { PageNumber = 1, PageSize = 10 },
                FieldMask = new() { Paths = { "id", "name", "taxno" } }
            };

            ListContragentResponse searchResponse = GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Contragent.SearchListContragentAsync(searchRequest).ResponseAsync).GetAwaiter().GetResult();

            BindingList<Company> _companies = new BindingList<Company>();
            foreach (Contragent item in searchResponse.Contragents)
            {
                _companies.Add(new Company()
                {
                    Id = item.Id,
                    Name = item.Name,
                    TaxNo = item.Taxno
                });
            }
            return _companies;
        }
               
    }

    public class CurrencyItemBox : IItemBox
    {
        public int Id { get; set; }
        public string Name { get; set ; }
    }

    public class TreeItem : ITreeData
    {
        public int Id { get ; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
    }

}
