using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Currency;
using GrpcCommonNet.Proto.Utils;
using GrpcWinForms.Models;
using GrpcWinForms.Objects.Currencies.Presenters;
using GrpcWinForms.Objects.Currencies.Views.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Currencies.Views
{
    public partial class RatesForm : Form, IRatesView
    {
        private BindingList<CurrencyRate> currencyRates;
        private BindingList<Rate> rates;
        private int currentRow = -1;
        private readonly RatesPresenter _presenter;

        public RatesForm()
        {
            InitializeComponent();

            dateTimePickerDateRates.Value = DateTime.Now;

            _presenter = new RatesPresenter(this);
        }

        // IRatesView свойства
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
        public int RowCol => gridRates.Row - gridRates.Rows.Fixed;
        public int Row { get => gridRates.Row; set => gridRates.Row = value; }

        public List<Rate> SelectedRates
        {
            get
            {
                List<Rate> rates = new List<Rate>();
                foreach (var row in gridRates.SelectedRows)
                {
                    Rate item = gridRates.Rows[row].DataSource as Rate;
                    rates.Add(item);
                }
                return rates;
            }
        }
        public List<int> SelectedRows
        {
            get => gridRates.SelectedRows;
            set => gridRates.SelectedRows = value;
        }

        // IRatesView методы
        public CurrencyRate GetSelectedCurrencyRate()
        {
            if (gridCurrencies.Row < gridCurrencies.Rows.Fixed) return null;
            return gridCurrencies.Rows[gridCurrencies.Row].DataSource as CurrencyRate;
        }

        public Rate GetSelectedRate()
        {
            if (gridRates.Row < gridCurrencies.Rows.Fixed) return null;
            return gridRates.Rows[gridRates.Row].DataSource as Rate;
        }

        public int GetRateId(int index)
        {
            if (index < gridRates.Rows.Fixed) return 0;
            Rate rate = gridRates.Rows[index].DataSource as Rate;
            return rate.RateId;
        }

        public void SetBusy(bool busy)
        {
            Cursor = busy ? Cursors.WaitCursor : Cursors.Default;
            gridCurrencies.Enabled = !busy;
            gridRates.Enabled = !busy;
            toolStripRates.Enabled = !busy;
        }

        public void ShowMessage(string text, string caption = "") => MessageBox.Show(this, text, caption);

        #region События формы
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

        private async void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            gridRates.Select();
            await _presenter.NewAsync();
            gridRates.Row--;

        }

        private void gridRates_BeforeEdit(object sender, C1.Win.FlexGrid.RowColEventArgs e)
        {
            if (gridRates.Cols[e.Col].Name == "Id") return;
            var i = 0;
        }

        private void gridRates_AfterEdit(object sender, C1.Win.FlexGrid.RowColEventArgs e)
        {
        }

        #endregion

        private void gridRates_CellChanged(object sender, C1.Win.FlexGrid.RowColEventArgs e)
        {
        }

        private void gridRates_LeaveEdit(object sender, C1.Win.FlexGrid.RowColEventArgs e)
        {
            Rate rate = gridRates.Rows[e.Row].DataSource as Rate;
            switch (gridRates.Cols[e.Col].Name)
            {
                case "DateRate":
                    rate.Date = Convert.ToDateTime(gridRates.Editor.Text).ToUniversalTime().ToTimestamp();
                    break;
                case "Rate":
                    rate.Rate_ = MyConvert.ToDecimalValue(Convert.ToDecimal(gridRates.Editor.Text));
                    break;
            }
            _presenter.EditAsync(rate);
        }

        private void toolStripButtonRefreshRates_Click(object sender, EventArgs e)
        {
            _presenter.RefreshRatesAsync();
        }
    }
}