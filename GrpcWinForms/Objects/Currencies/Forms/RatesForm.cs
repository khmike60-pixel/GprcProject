using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Currency;
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

namespace GrpcWinForms.Objects.Currencies.Forms
{
    public partial class RatesForm : Form
    {
        private BindingList<CurrencyRate> currencyRates;
        private BindingList<Rate> rates;
        private Loader loaderRates = new Loader();

        public RatesForm()
        {
            InitializeComponent();

            loaderRates.Parent = smartGridRates;
            loaderRates.Location = new Point(0, 0);
            loaderRates.Size = smartGridRates.Size;

            dateTimePickerDateRates.Value = DateTime.Now;
        }

        private async Task<BindingList<CurrencyRate>> RefreshCurrencyRates(object sender, EventArgs e)
        {
            GetListCurrencyRateDateRequest request = new GetListCurrencyRateDateRequest()
            {
                IncludeInvisible = checkIncludeInvisible.Checked,
                Abbrev = string.IsNullOrWhiteSpace(textAbbrev.Text) ? String.Empty : textAbbrev.Text,
                Date = dateTimePickerDateRates.Value.ToLocalTime().ToUniversalTime().ToTimestamp()
            };

            GetListCurrencyRateDateResponse response = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Currency.GetListCurrencyRateDateAsync(request).ResponseAsync
            );

            currencyRates = new BindingList<CurrencyRate>(response.CurrencyRates);
            smartGrid.DataSource = currencyRates;
            return currencyRates;
        }

        private async Task<BindingList<Rate>> RefreshRates(object sender, EventArgs e)
        {
            loaderRates.ShowLoader();
            CurrencyRate currencyRate = (CurrencyRate)(smartGrid.Rows[smartGrid.Row].DataSource);
            ListCurrencyRateRequest request = new ListCurrencyRateRequest()
            {
                CurrencyId = currencyRate.Id,
                StartDate = Timestamp.FromDateTime(DateTime.UnixEpoch),
                EndDate = dateTimePickerDateRates.Value.ToLocalTime().ToUniversalTime().ToTimestamp()
            };

            ListCurrencyRateResponse response = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Currency.GetListCurrencyRateAsync(request).ResponseAsync
            );
            rates = new BindingList<Rate>(response.Rates);
            smartGridRates.DataSource = rates;
            loaderRates.HideLoader();
            return rates;
        }

        private async void RatesForm_Load(object sender, EventArgs e)
        {

            await RefreshCurrencyRates(sender, e);
        }

        private async void toolStripButtonCurrencies_Click(object sender, EventArgs e)
        {
            await RefreshCurrencyRates(sender, e);
        }


        private void smartGrid_GetUnboundValue(object sender, C1.Win.FlexGrid.UnboundValueEventArgs e)
        {
            CurrencyRate currencyRate = (CurrencyRate)(smartGrid.Rows[e.Row].DataSource);
            switch (smartGrid.Cols[e.Col].Name)
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
                    //                    e.Value = date;
                    break;
            }

        }

        private async void smartGrid_AfterSelChange(object sender, C1.Win.FlexGrid.RangeEventArgs e)
        {

            if (smartGrid.RowSel <= smartGrid.Rows.Fixed - 1) return;
            await RefreshRates(sender, e);

        }

        private void smartGridRates_GetUnboundValue(object sender, C1.Win.FlexGrid.UnboundValueEventArgs e)
        {
            Rate rate = (Rate)(smartGridRates.Rows[e.Row].DataSource);
            switch (smartGridRates.Cols[e.Col].Name)
            {
                case "Rate":
                    if (rate.Rate_ == null) e.Value = null;
                    e.Value = (decimal)(rate.Rate_.Units / (Math.Pow(10, rate.Rate_.Scale)));
                    break;
                case "DateRate":
                    DateTime date = rate.Date.ToDateTime();
                    e.Value = date;
                    break;
            }
        }

        private void smartGrid_AfterFreezeColumn(object sender, C1.Win.FlexGrid.RowColEventArgs e)
        {
            smartGrid.Cols["Name"].StarWidth = "*";
        }

        private void smartGridRates_AfterFreezeColumn(object sender, C1.Win.FlexGrid.RowColEventArgs e)
        {
            smartGridRates.Cols["DateRate"].StarWidth = "*";
            smartGridRates.Cols["Rate"].StarWidth = "*";
        }

        //#region LoaderControl

        //private PictureBox loaderControl;

        //private void InitLoader()
        //{
        //    // Инициализация контрола программно
        //    loaderControl = new PictureBox
        //    {
        //        Image = Properties.Resources.icons8_loader, // Ваш GIF из ресурсов
        //        SizeMode = PictureBoxSizeMode.CenterImage,
        //        BackColor = Color.Transparent, // Или Color.White, если нужно перекрыть фон
        //        Visible = false,
        //        Dock = DockStyle.Fill // Растягиваем на всю форму или поверх грида
        //    };

        //    // Добавляем поверх всех элементов
        //    this.Controls.Add(loaderControl);
        //    loaderControl.BringToFront();
        //}

        //// Методы управления
        //private void ShowLoader() => loaderControl.Visible = true;
        //private void HideLoader() => loaderControl.Visible = false;


        //#endregion
    }


}
