using C1.Win.FlexGrid;
using GrpcCommonNet.Library.SalePurchaseType;
using GrpcWinForms.Objects.SalePurchaseTypes.Models;
using GrpcWinForms.Objects.SalePurchaseTypes.Presenters;
using GrpcWinForms.Objects.SalePurchaseTypes.Services;
using GrpcWinForms.Objects.SalePurchaseTypes.Views;
using SmartLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.SalePurchaseTypes.Forms
{
    public partial class SalePurchaseRatesForm : Form, ISalePurchaseRatesView
    {
        private readonly SalePurchaseRatesPresenter _presenter;

        #region Вызываемые события
        public event Func<CancellationToken, Task> OnLoadAsync;
        public event Func<RateRow, CancellationToken, Task> OnCommitEditAsync;
        public event Func<IReadOnlyList<int>, CancellationToken, Task> OnDeleteAsync;
        public event Func<RateRow, CancellationToken, Task> OnAppendAsync;

        #endregion

        #region Объекты формы

        public int TypeId => cbName.SelectedIndex;
        public DateTime DateStart => periodBox.Period.From;
        public DateTime DateEnd => periodBox.Period.To;
        public string CountryCode { get; set; }
        public string CurrencyCode { get; set;  }

        public int SalePurchaseTypeId { get; } = 1;

        public BindingSource RatesBindingSource { get; } = new BindingSource();
        public SmartGrid Grid => gridRates;

        #endregion



        public SalePurchaseRatesForm()
        {
            InitializeComponent();
            
            _presenter = _presenter = new SalePurchaseRatesPresenter(this);

            // Привязка binding source
            gridRates.DataSource = RatesBindingSource;

            // Подписываем событие загрузки формы
            this.Load += async (s, e) =>
            {
                if (OnLoadAsync != null) await OnLoadAsync(CancellationToken.None);
            };

            // Подписка на завершение редактирования ячейки/строки
            gridRates.AfterEdit += GridSalePurchaseRates_AfterEdit;

            // Кнопка удаления (если есть тулбар)
            btnDelete.Click += async (s, e) =>
            {
                var ids = new List<int>();
                foreach (int r in gridRates.SelectedRows)
                {
                    if (r < gridRates.Rows.Fixed) continue;
                    var item = gridRates.Rows[r].DataSource as RateRow;
                    if (item?.Id != null) ids.Add(item.Id);
                }
                if (OnDeleteAsync != null) await OnDeleteAsync(ids, CancellationToken.None);
            };

            btnNew.Click += async (s, e) =>
            {
                var item = new RateRow();
                if (gridRates.Row > gridRates.Rows.Fixed) 
                    item = gridRates.Rows[gridRates.Row].DataSource as RateRow;
                if (item == null) return;
                if (OnAppendAsync != null) await OnAppendAsync(item, CancellationToken.None);
            };
        }

        private async void GridSalePurchaseRates_AfterEdit(object sender, RowColEventArgs e)
        {
            try
            {
                if (e.Row < gridRates.Rows.Fixed) return;
                var item = gridRates.Rows[e.Row].DataSource as RateRow;
                if (item == null) return;

                // При inline-редактировании передаём модель в презентер, который сам решит create/update
                if (OnCommitEditAsync != null) await OnCommitEditAsync(item, CancellationToken.None);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        public void SetBusy(bool busy)
        {
            if (InvokeRequired) Invoke(new Action(() => SetBusy(busy)));
            else
            {
                Cursor = busy ? Cursors.WaitCursor : Cursors.Default;
                toolStrip1.Enabled = !busy;
            }
        }

        public void ShowError(string message)
        {
            if (InvokeRequired) Invoke(new Action(() => ShowError(message)));
            else MessageBox.Show(this, message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowRates(BindingList<RateRow> rates)
        {
            if (InvokeRequired) Invoke(new Action(() => ShowRates(rates)));
            else RatesBindingSource.DataSource = rates;
        }
    }
}