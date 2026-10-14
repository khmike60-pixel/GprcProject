using C1.Win.FlexGrid;
using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Application;
using GrpcCommonNet.Library.Currency;
using GrpcCommonNet.Library.Common;
using GrpcWinForms.Models;
using GrpcWinForms.Objects.Applications.Forms;
using GrpcWinForms.Objects.Currencies.Forms;
using GrpcWinForms.Objects.Currencies.Views;
using GrpcWinForms.Objects.Currencies.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using GrpcWinForms.GrpcUtils;

namespace GrpcWinForms.Objects.Currencies.Forms
{
    public partial class CurrenciesForm : Form, ICurrenciesView
    {
        #region Свойства

        private BindingList<Currency> currencies;
        private Currency selectedItem = null;
        private readonly CurrenciesPresenter _presenter;

        public Currency SelectedItem { get { return selectedItem; } }
        public bool DialogMode { get; set; }

        // ICurrenciesView implementation
        public bool IncludeInvisible => checkIncludeInvisible.Checked;
        public string CurrencyAbbrev => textAbbrev.Text;
        BindingList<Currency> ICurrenciesView.Currencies { get => currencies; set { currencies = value; gridCurrencies.DataSource = currencies; } }
        public int RowSel => gridCurrencies.RowSel;
        public IList<int> SelectedRows
        {
            get
            {
                var list = new List<int>();
                foreach (var i in gridCurrencies.SelectedRows) list.Add(Convert.ToInt32(i));
                return list;
            }
            set
            {
                gridCurrencies.SelectedRows.Clear();
                foreach (var i in value) gridCurrencies.SelectedRows.Add(i);
            }
        }

        #endregion

        #region Конструкторы и метод формы Load
        public CurrenciesForm()
        {
            InitializeComponent();
            _presenter = new CurrenciesPresenter(this);
        }

        private async void CurrenciesForm_Load(object sender, EventArgs e)
        {
            await _presenter.RefreshAsync();
        }

        #endregion

        #region Обработчики событий элементов управления (кнопок)
        private async void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            await _presenter.RefreshAsync();
        }

        private async void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            await _presenter.NewAsync();
            gridCurrencies.Row -= 1;
        }

        private async void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            await _presenter.EditAsync();
        }

        private async void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            await _presenter.DeleteAsync();
        }

        #endregion

        #region Обработчики событий элементов управления (grid валют)
        private void gridCurrencies_AfterResizeColumn(object sender, RowColEventArgs e)
        {
            gridCurrencies.Cols["Name"].StarWidth = "*";
            var i = gridCurrencies.SelectedRows;
        }

        private void gridCurrencies_DoubleClick(object sender, EventArgs e)
        {
            _presenter.OnItemDoubleClicked();
        }

        #endregion

        // ICurrenciesView helper implementations
        public DialogResult ShowCurrencyDialog(Form form)
        {
            return form.ShowDialog(this);
        }

        public void ShowMessage(string text, string caption = "", MessageBoxButtons buttons = MessageBoxButtons.OK)
        {
            MessageBox.Show(text, caption, buttons);
        }

        public void CloseWithResult(Currency selected)
        {
            selectedItem = selected;
            DialogResult = DialogResult.OK;
            Close();
        }

        public void BeginUpdate()
        {
            gridCurrencies.BeginUpdate();
        }

        public void EndUpdate()
        {
            gridCurrencies.EndUpdate();
        }
    }
}