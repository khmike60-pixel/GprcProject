using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Geolocation;
using GrpcWinForms.Objects.Currencies.Presenters;
using GrpcWinForms.Objects.Stocks.Models;
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
        private BindingList<Stock> stocks = new BindingList<Stock>();
        private List<TreePlace> places = new List<TreePlace>();
        private readonly StocksPresenter _presenter;
        private int currentRow = 0;


        #region Объекты из интерфейса
        public BindingList<Stock> Stocks
        {
            get => stocks;
            set { stocks = value ?? new BindingList<Stock>(); gridStocks.DataSource = stocks; }
        }
        public List<TreePlace> Places
        {
            get => places;
            set
            {
                places = value ?? new List<TreePlace>();
                gridPlaces.BuildTree(places, false);
            }
        }
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


        public StocksForm()
        {
            InitializeComponent();
            _presenter = new StocksPresenter(this);
        }

        private async void StocksForm_Load(object sender, EventArgs e)
        {
            await _presenter.RefreshStocks();
            gridStocks.DataSource = Stocks;
        }

        private void gridStocks_GetUnboundValue(object sender, C1.Win.FlexGrid.UnboundValueEventArgs e)
        {
            int index = e.Row - gridStocks.Rows.Fixed;
            if (index < 0 || index >= Stocks.Count) return;

            Stock stock = gridStocks.Rows[e.Row].DataSource as Stock;
            switch (gridStocks.Cols[e.Col].Name)
            {
                case "GeoName":
                    e.Value = stock.Place.Name; break;
            }
        }

        private async void tsbRefreshStock_Click(object sender, EventArgs e) // кнопка Refresh складов
        {
            gridStocks.BeginUpdate();
            await _presenter.RefreshStocks();
            gridStocks.EndUpdate();
        }

        private async void gridStocks_AfterSelChange(object sender, C1.Win.FlexGrid.RangeEventArgs e)
        {
            if (currentRow == RowStock) return;
            if (RowStock < gridStocks.Rows.Fixed) return;
            currentRow = RowStock;

            Stock stock = gridStocks.Rows[RowStock].DataSource as Stock;
            gridPlaces.BeginUpdate();
            await _presenter.RefreshPlaces(stock);
            gridPlaces.EndUpdate();
        }

        private async void tsbNewStock_Click(object sender, EventArgs e) // Кнопка Новый склад
        {
            StockForm stockForm = new() { Stock = new() };
            if (stockForm.ShowDialog() == DialogResult.OK)
            {
                await _presenter.AddEditStock(stockForm.Stock);
            }
        }

        private async void tsbDeleteStock_Click(object sender, EventArgs e)   // Кнопка удалить склад или помеченные склады
        {
            await _presenter.DeleteStock(SelectedRowsStock);
        }

        private async void tsbRefreshPlace_Click(object sender, EventArgs e)
        {
            if (RowStock < gridStocks.Rows.Fixed) return;

            Stock stock = gridStocks.Rows[RowStock].DataSource as Stock;
            gridPlaces.BeginUpdate();
            await _presenter.RefreshPlaces(stock);
            gridPlaces.EndUpdate();

        }

        private async void tsbEditStock_Click(object sender, EventArgs e)
        {
            Stock stock = gridStocks.Rows[RowStock].DataSource as Stock;
            StockForm stockForm = new() { Stock = stock };
            if (stockForm.ShowDialog() == DialogResult.OK)
            {
                await _presenter.AddEditStock(stockForm.Stock);
            }
        }
    }
}
