using C1.Win.Input;
using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Currency;
using GrpcWinForms.Forms;
using GrpcWinForms.GrpcUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static C1.Util.Win.Win32;

namespace GrpcWinForms.Controls.CurrencyBox
{
    public partial class CurrencyBox : C1ComboBox
    {
        private Currency objectSelected = new Currency();
        private BindingList<Currency> currencies = new BindingList<Currency>();

        public Currency CurrencySelected { get => objectSelected; }

        public CurrencyBox()
        {
            InitializeComponent();
            SetupInit();

        }
        public CurrencyBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            SetupInit();
        }

        private void SetupInit()
        {
            ButtonsSettings.CustomButton.Icon = new C1.Framework.C1BitmapIcon(null, new Size(16, 16), Color.Transparent, Properties.Resources.icons8_multiply_16);
            ButtonsSettings.CustomButton.Visible = true;
            ButtonsSettings.ModalButton.Visible = true;

            ModalButtonClick += CurrencyBox_ModalButtonClick;
            DropDownButtonClick += CurrencyBox_DropDownButtonClick;
            SelectedIndexChanged += CurrencyBox_SelectedIndexChanged;

            AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteMode = AutoCompleteMode.Suggest;
        }

        private void CurrencyBox_DropDownButtonClick(object? sender, EventArgs e)
        {
            SetItemsDataSource();
        }

        // Загрузка данных
        public async Task<List<string>> LoadData()
        {
            ListCurrencyRequest request = new ListCurrencyRequest()
            {
                IncludeInvisible = false,
            };
            request.FieldMask = new FieldMask()
            { Paths = { "id", "abbrev", "name" } };

            ListCurrencyResponse response = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Currency.GetListCurrencyAsync(request).ResponseAsync
            );

            currencies = new BindingList<Currency>(response.Currencies);

            List<string> listCurrency = new List<string>();
            foreach (Currency currency in response.Currencies)
            {
                listCurrency.Add(currency.Abbrev);
            }

            return listCurrency;
        }

        // Установка ItemsDataSource
        public async void SetItemsDataSource()
        {
            if (currencies.Count == 0)
            {
                List<string> list = await LoadData();

                ItemsDataSource = list;
                AutoCompleteCustomSource.AddRange(list.ToArray());
                AutoCompleteMode = AutoCompleteMode.Suggest;
                AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoSuggestMode = AutoSuggestMode.Contains;
                DroppedDown = true;
            }
        }

        private void CurrencyBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            int row = SelectedIndex;
            if (row < 0 || row > currencies.Count) return;
            Currency currency = new Currency()
            { Id = currencies[row].Id, Abbrev = currencies[row].Abbrev };
        }

        private void CurrencyBox_ModalButtonClick(object sender, EventArgs e)
        {
            CurrenciesForm form = new CurrenciesForm();
            form.DialogMode = true;
            if (DialogResult.OK == form.ShowDialog())
            {
                objectSelected = form.SelectedItem;
                this.Text = CurrencySelected.Abbrev;

            }
        }

        private void CurrencyBox_Leave(object sender, EventArgs e)
        {

        }
    }
}
