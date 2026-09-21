using GrpcCommonNet.Library.Common;
using GrpcWinForms.Objects.Currencies.Presenters;
using GrpcWinForms.Objects.Currencies.Views;
using GrpcWinForms.Objects.SalePurchaseTypes.Models;
using GrpcWinForms.Objects.SalePurchaseTypes.Presenters;
using GrpcWinForms.Objects.SalePurchaseTypes.Views;
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
        public bool DialogMode = false;
        private object selectedItem = new object();
        private readonly SalePurchaseTypePresenter _presenter;
        private int _row = 0;
        private BindingList<SalePurchaseType> _types = [];
        private BindingList<SalePurchaseCurrency> _currencies = [];


        BindingList<SalePurchaseType> ISalePurchaseTypesView.SalePurchaseTypes
        { get => _types; set { _types = value; gridSalePurchaseTypes.DataSource = _types; } }
        BindingList<SalePurchaseCurrency> ISalePurchaseTypesView.SalePurchaseCurrencies
        { get => _currencies; set { _currencies = value; gridSalePurchaseCurrencies.DataSource = _currencies; } }

        public SalePurchaseTypesForm()
        {
            InitializeComponent();
            _presenter = new SalePurchaseTypePresenter(this);
        }

        private async void SalePurchaseTypesForm_Load(object sender, EventArgs e)
        {
            await _presenter.RefreshSalePurchaseTypesAsync();
        }

        private async void gridSalePurchaseTypes_RowColChange(object sender, EventArgs e)
        {
            int row = gridSalePurchaseTypes.Row;
            if (row < gridSalePurchaseTypes.Rows.Fixed) return;
            if (row != _row) { _row = row; }
            SalePurchaseType _type = gridSalePurchaseTypes.Rows[row].DataSource as SalePurchaseType;
            await _presenter.RefreshSalePurchaseCurrenciesAsync(_type);
        }
    }
}
