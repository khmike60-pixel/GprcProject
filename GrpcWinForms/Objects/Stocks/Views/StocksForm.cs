using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Geolocation;
using GrpcWinForms.Objects.Currencies.Presenters;
using GrpcWinForms.Objects.Stocks.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Stocks.Views
{
    public partial class StocksForm : Form, IStocks
    {
        #region Объекты из интерфейса
        public BindingList<Stock> Stocks { get; set; }
        public BindingList<GeoPlace> GeoPlaces { get; set; }
        public int RowStock { get => gridStocks.Row; set => gridStocks.Row = value; }
        public int RowPlace { get => gridPlaces.Row; set => gridPlaces.Row = value; }
        public IList<int> SelectedRowsStock
        {
            get => gridStocks.SelectedRows;
            set { gridStocks.SelectedRows.Clear(); gridStocks.SelectedRows.AddRange(value); }
        }
        public IList<int> SelectedRowsPlace
        {
            get => gridPlaces.SelectedRows;
            set { gridPlaces.SelectedRows.Clear(); gridPlaces.SelectedRows.AddRange(value); }
        }
        public string NameText => txtName.Text;

        #endregion


        private readonly StocksPresenter _presenter;

        public StocksForm()
        {
            InitializeComponent();
            _presenter = new StocksPresenter(this);
        }

        private async void StocksForm_Load(object sender, EventArgs e)
        {
            await _presenter.RefreshStocks();
        }
    }
}
