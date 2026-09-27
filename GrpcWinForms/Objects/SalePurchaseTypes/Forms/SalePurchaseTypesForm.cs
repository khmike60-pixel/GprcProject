using C1.Win.FlexGrid;
using GrpcCommonNet.Library.Common;
using GrpcWinForms.Objects.Currencies.Presenters;
using GrpcWinForms.Objects.Currencies.Views;
using GrpcWinForms.Objects.SalePurchaseTypes.Models;
using GrpcWinForms.Objects.SalePurchaseTypes.Presenters;
using GrpcWinForms.Objects.SalePurchaseTypes.Views;
using SmartLib;
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
    public partial class SalePurchaseTypesForm : Form, ISalePurchaseTypesView
    {
        private readonly SalePurchaseTypesPresenter _presenter;
        private int _row = 0;

        public bool DialogMode = false;

        private List<int> selectedIds = [];
        List<int> ISalePurchaseTypesView.SelectedIds { get => selectedIds; set => selectedIds = value; }

        private BindingList<SalePurchaseType> _types = [];
        BindingList<SalePurchaseType> ISalePurchaseTypesView.SalePurchaseTypes
        { get => _types; set { _types = value; gridSalePurchaseTypes.DataSource = _types; } }

        private BindingList<CurrencyUsing> _currencies = [];
        BindingList<CurrencyUsing> ISalePurchaseTypesView.Currencies
        { get => _currencies; set { _currencies = value; gridSalePurchaseCurrencies.DataSource = _currencies; } }

        public SmartGrid GridTypes { get => gridSalePurchaseTypes; set => gridSalePurchaseTypes = value; }
        public SmartGrid GridCurrencies { get => gridSalePurchaseCurrencies; set => gridSalePurchaseCurrencies = value; }

        #region Вызываемые события для типов продаж
        public event Func<CancellationToken, Task> OnLoadTypesAsync;
        public event Func<IReadOnlyList<int>, CancellationToken, Task> OnDeleteTypesAsync;
        public event Func<SalePurchaseType, CancellationToken, Task> OnAppendTypesAsync;
        public event Func<CancellationToken, Task> OnRefreshTypesAsync;

        #endregion

        #region Вызываемые события для используемых валют
        public event Func<CancellationToken, Task> OnLoadCurrenciesAsync;
        public event Func<IReadOnlyList<int>, CancellationToken, Task> OnDeleteCurrenciesAsync;
        public event Func<CurrencyUsing, CancellationToken, Task> OnAppendCurrenciesAsync;
        public event Func<CancellationToken, Task> OnRefreshCurrenciesAsync;

        #endregion


        #region Конструктор
        public SalePurchaseTypesForm()
        {
            InitializeComponent();
            _presenter = new SalePurchaseTypesPresenter(this);
        }

        #endregion


        #region Основные методы
        private async void SalePurchaseTypesForm_Load(object sender, EventArgs e)
        {
            _types = await _presenter.RefreshSalePurchaseTypesAsync();
            gridSalePurchaseTypes.DataSource = _types;
        }

        private async void gridSalePurchaseTypes_RowColChange(object sender, EventArgs e)
        {
            int row = gridSalePurchaseTypes.Row;
            if (row < gridSalePurchaseTypes.Rows.Fixed) return;
            if (row != _row) { _row = row; }

            SalePurchaseType _type = gridSalePurchaseTypes.Rows[row].DataSource as SalePurchaseType;
            _currencies = await _presenter.RefreshSalePurchaseCurrenciesAsync(_type);
            gridSalePurchaseCurrencies.DataSource = _currencies;
        }

        private void gridSalePurchaseTypes_GetUnboundValue(object sender, UnboundValueEventArgs e)
        {
            string field = gridSalePurchaseTypes.Cols[e.Col].Name;
            SalePurchaseType type = gridSalePurchaseTypes.Rows[e.Row].DataSource as SalePurchaseType;
            try
            {
                switch (field)
                {
                    case "Name":
                        e.Value = type.Name;
                        break;
                    case "Confirmed":
                        e.Value = type.Confirmed;
                        break;
                    case "Id":
                        e.Value = type.Id;
                        break;
                    case "CountryCode":
                        e.Value = type.Country.Code2;
                        break;
                    case "colCurrency":
                        e.Value = type.Currency.Abbrev;
                        break;
                    case "colCurrencyMain":
                        e.Value = type.CurrencyMain.Abbrev;
                        break;
                    case "colCurrencySalary":
                        e.Value = type.CurrencySalary.Abbrev;
                        break;
                    case "colCurrencyCross":
                        e.Value = type.CurrencyCross.Abbrev;
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            SalePurchaseType item = new SalePurchaseType();
            if (gridSalePurchaseTypes.Row >= gridSalePurchaseTypes.Rows.Fixed)
                item = gridSalePurchaseTypes.Rows[gridSalePurchaseTypes.Row].DataSource as SalePurchaseType;
            if (item == null) return;
            if (OnAppendTypesAsync != null) await OnAppendTypesAsync(item, CancellationToken.None);

        }

        private async void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            await _presenter.OnClick_DeleteAsync(gridSalePurchaseTypes.SelectedRows);

        }

        #endregion

    }
}
