using GrpcCommonNet.Library.Common;
using GrpcWinForms.Models;
using GrpcWinForms.Objects.Currencies.Presenters;
using GrpcWinForms.Objects.Currencies.Views;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Currencies.Forms
{
    public partial class RatesForm : Form, IRatesView
    {
        private BindingList<CurrencyRate> currencyRates;
        private BindingList<Rate> rates;
        private Loader loaderRates = new Loader();
        private int currentRow = -1;
        private readonly RatesPresenter _presenter;

        public RatesForm()
        {
            InitializeComponent();

            loaderRates.Parent = gridRates;
            loaderRates.Location = new Point(0, 0);
            loaderRates.Size = gridRates.Size;

            dateTimePickerDateRates.Value = DateTime.Now;

            _presenter = new RatesPresenter(this);
        }

        // IRatesView implementation
        public bool IncludeInvisible => checkIncludeInvisible.Checked;
        public string Abbrev => string.IsNullOrWhiteSpace(textAbbrev.Text) ? string.Empty : textAbbrev.Text;
        public DateTime DateRates => dateTimePickerDateRates.Value;

        public BindingList<CurrencyRate> CurrencyRates
        {
            get => currencyRates;
            set
            {
                currencyRates = value;
                gridCurrencies.DataSource = currencyRates;
            }
        }

        public BindingList<Rate> Rates
        {
            get => rates;
            set
            {
                rates = value;
                gridRates.DataSource = rates;
            }
        }

        public int RowSel => gridCurrencies.RowSel;

        public CurrencyRate GetSelectedCurrencyRate()
        {
            if (gridCurrencies.Row < gridCurrencies.Rows.Fixed) return null;
            return gridCurrencies.Rows[gridCurrencies.Row].DataSource as CurrencyRate;
        }

        public void ShowLoader() => loaderRates.ShowLoader();
        public void HideLoader() => loaderRates.HideLoader();

        public void ShowMessage(string text, string caption = "") => MessageBox.Show(this, text, caption);

        private async void RatesForm_Load(object sender, EventArgs e)
        {
            await _presenter.RefreshCurrencyRatesAsync();
        }

        private async void toolStripButtonCurrencies_Click(object sender, EventArgs e)
        {
            await _presenter.RefreshCurrencyRatesAsync();
        }

        private void gridCurrencies_GetUnboundValue(object sender, C1.Win.FlexGrid.UnboundValueEventArgs e)
        {
            CurrencyRate currencyRate = (CurrencyRate)(gridCurrencies.Rows[e.Row].DataSource);
            switch (gridCurrencies.Cols[e.Col].Name)
            {
                case "DecimalRate":
                    if (currencyRate.Rate == null) e.Value = null;
                    else
                        e.Value = (decimal)(currencyRate.Rate.Units / (Math.Pow(10, currencyRate.Rate.Scale)));
                    break;
                case "DateRate":
                    if (currencyRate.Rate == null) e.Value = null;
                    else
                        e.Value = currencyRate.Date.ToDateTime().ToLocalTime();
                    break;
            }
        }

        private async void gridCurrencies_AfterSelChange(object sender, C1.Win.FlexGrid.RangeEventArgs e)
        {
            if (gridCurrencies.RowSel == currentRow) return;
            currentRow = gridCurrencies.RowSel;
            if (gridCurrencies.RowSel <= gridCurrencies.Rows.Fixed - 1) return;
            await _presenter.RefreshRatesAsync();
        }

        private void gridRates_GetUnboundValue(object sender, C1.Win.FlexGrid.UnboundValueEventArgs e)
        {
            Rate rate = (Rate)(gridRates.Rows[e.Row].DataSource);
            switch (gridRates.Cols[e.Col].Name)
            {
                case "Rate":
                    if (rate.Rate_ == null) e.Value = null;
                    else e.Value = (decimal)(rate.Rate_.Units / (Math.Pow(10, rate.Rate_.Scale)));
                    break;
                case "DateRate":
                    DateTime date = rate.Date.ToDateTime();
                    e.Value = date;
                    break;
            }
        }

        private void gridCurrencies_AfterFreezeColumn(object sender, C1.Win.FlexGrid.RowColEventArgs e)
        {
            gridCurrencies.Cols["Name"].StarWidth = "*";
        }

        private void gridRates_AfterFreezeColumn(object sender, C1.Win.FlexGrid.RowColEventArgs e)
        {
            gridRates.Cols["DateRate"].StarWidth = "*";
            gridRates.Cols["Rate"].StarWidth = "*";
        }
    }
}