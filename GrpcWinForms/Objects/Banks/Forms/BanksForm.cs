using C1.Win.FlexGrid;
using GrpcCommonNet.Library.Bank;
using GrpcCommonNet.Library.Common;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Objects.Banks.Presenters;
using GrpcWinForms.Objects.Banks.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Banks.Forms
{
    public partial class BanksForm : Form, IBanksView
    {
        private BindingList<Bank> banks = new BindingList<Bank>();
        private readonly BanksPresenter _presenter;

        public BanksForm()
        {
            InitializeComponent();
            _presenter = new BanksPresenter(this);
        }

        // IBanksView реализация
        public string ShortFilter => tShort.Text;

        public BindingList<Bank> Banks
        {
            get => banks;
            set
            {
                banks = value ?? new BindingList<Bank>();
                gridBanks.DataSource = banks;
            }
        }

        public int RowSel => gridBanks.RowSel;
        public int RowsFixed => gridBanks.Rows.Fixed;

        public IList<int> SelectedRows
        {
            get
            {
                var list = new List<int>();
                if (gridBanks.SelectedRows == null) return list;
                list.AddRange(gridBanks.SelectedRows);
                return list;
            }
        }

        public Bank GetBankAtRow(int row)
        {
            if (row < gridBanks.Rows.Fixed || row >= gridBanks.Rows.Count) return null;
            return gridBanks.Rows[row].DataSource as Bank;
        }

        public int GetIdAtRow(int row)
        {
            if (row < gridBanks.Rows.Fixed || row >= gridBanks.Rows.Count) return 0;
            return Convert.ToInt32(gridBanks.Rows[row]["Id"]);
        }

        public void BeginUpdate() => gridBanks.BeginUpdate();
        public void EndUpdate() => gridBanks.EndUpdate();

        public DialogResult ShowBankDialog(BankForm form) => form.ShowDialog();

        public void SetRow(int row) => gridBanks.Row = row;

        public void InsertBankAt(int index, Bank bank)
        {
            if (index < 0) index = 0;
            if (index > banks.Count) index = banks.Count;
            banks.Insert(index, bank);
        }

        public void ReplaceBankAt(int index, Bank bank)
        {
            if (index < 0 || index >= banks.Count) return;
            banks[index] = bank;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= banks.Count) return;
            banks.RemoveAt(index);
        }

        public void RemoveBanksByIds(IList<int> ids)
        {
            if (ids == null || ids.Count == 0) return;
            var toRemove = banks.Where(b => ids.Contains(b.Id)).ToList();
            foreach (var item in toRemove) banks.Remove(item);
        }

        public void ShowMessage(string text, string caption = "") => MessageBox.Show(text, caption);

        // События формы пересылают действия в презентер
        private async void BanksForm_Load(object sender, EventArgs e)
        {
            await _presenter.RefreshAsync();
        }

        private async void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            await _presenter.NewAsync();
        }

        private async void toolStripButtonDouble_Click(object sender, EventArgs e)
        {
            await _presenter.DuplicateAsync();
        }

        private async void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            await _presenter.EditAsync();
        }

        private async void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            await _presenter.DeleteAsync();
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            _ = _presenter.RefreshAsync();
        }

        private void smartGrid_GetUnboundValue(object sender, UnboundValueEventArgs e)
        {
            Bank _bank = gridBanks.Rows[e.Row].DataSource as Bank;
            if (e.Row < gridBanks.Rows.Fixed || e.Row >= gridBanks.Rows.Count || _bank == null)
                return;
            switch (gridBanks.Cols[e.Col].Name)
            {
                case "colCode2":
                    e.Value = _bank.Geolocation.Code2;
                    break;
            }
        }
    }
}