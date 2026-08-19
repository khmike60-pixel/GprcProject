using C1.Win.FlexGrid;
using GrpcCommonNet.Library.Bank;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Department;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Models;
using GrpcWinForms.Objects.Departaments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Banks.Forms
{
    public partial class BanksForm : Form
    {
        private BindingList<Bank> banks = new BindingList<Bank>();
        public BanksForm()
        {
            InitializeComponent();
        }

        public async void RefreshBanks()
        {
            BankFilterRequest request = new BankFilterRequest()
            {
                Name = tShort.Text,
                FieldMask = new Google.Protobuf.WellKnownTypes.FieldMask() { Paths = { "id", "name", "geolocation", "short", "bank_code" } }

            };

            ListBankResponse response = new ListBankResponse();
            response = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Bank.GetListBankAsync(request).ResponseAsync);

            banks = new BindingList<Bank>(response.Banks);

            smartGrid1.DataSource = banks;
        }

        private void BanksForm_Load(object sender, EventArgs e)
        {
            RefreshBanks();
        }

        private async void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            try
            {
                using (BankForm form = new BankForm())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {

                        CreateBankRequest request = new CreateBankRequest()
                        {
                            Bank = form.Bank
                        };
                        BankResponse response = await GrpcRetry.CallAsync(() =>
                            GrpcClients.GrpcClients.Bank.CreateBankAsync(request));
                        if (response.Result.Status != Status.Ok || response.Bank == null)
                        {
                            MessageBox.Show("Добавить данные не удалось.");
                            return;
                        }
                        else
                        {
                            int rowsel = smartGrid1.RowSel;
                            banks.Insert(smartGrid1.RowSel - smartGrid1.Rows.Fixed, response.Bank);
                            smartGrid1.Row = rowsel;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void toolStripButtonDouble_Click(object sender, EventArgs e)
        {
            Bank bank = new Bank();
            bank = smartGrid1.Rows[smartGrid1.Row].DataSource as Bank;
            CreateBankRequest request = new CreateBankRequest()
            {
                Bank = bank
            };
            bank.Name += " 1";

            BankResponse response = new BankResponse();
            response = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Bank.CreateBankAsync(request).ResponseAsync);

            if (response.Result.Status != Status.Ok || response.Bank == null)
            {
                MessageBox.Show("Добавить данные не удалось.");
                return;
            }
            else
            {
                int rowsel = smartGrid1.RowSel;
                banks.Insert(smartGrid1.RowSel - smartGrid1.Rows.Fixed, response.Bank);
                smartGrid1.Row = rowsel;
            }
        }

        private async void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            using (var form = new BankForm())
            {
                form.Bank = banks[smartGrid1.RowSel - smartGrid1.Rows.Fixed];

                if (form.ShowDialog() == DialogResult.OK)
                {
                    UpdateBankRequest request = new UpdateBankRequest
                    {
                        Bank = form.Bank
                    };

                    BankResponse response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Bank.UpdateBankAsync(request).ResponseAsync);
                    if (response.Result.Status != Status.Ok || response.Bank == null)
                    {
                        MessageBox.Show("Изменить данные не удалось.");
                        return;
                    }
                    else
                    {
                        int rowsel = smartGrid1.RowSel;
                        banks[rowsel - smartGrid1.Rows.Fixed] = response.Bank;
                    }

                }
            }
        }

        private async void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();
            List<int> oldList = new List<int>();
            List<int> newMarked = new List<int>();
            if (smartGrid1.SelectedRows.Count == 0)
            { // Удаляется одна запись
                DialogResult result = MessageBox.Show("Удалить текущую строку данных?", "Удаление", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    DeleteBankRequest request = new DeleteBankRequest()
                    {
                        Id = (int)smartGrid1.Rows[smartGrid1.RowSel]["Id"]
                    };
                    DeleteBankResponse response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Bank.DeleteBankAsync(request).ResponseAsync);
                    int i = smartGrid1.RowSel - smartGrid1.Rows.Fixed;
                    if (response.Result.Status == Status.Ok)
                    {
                        smartGrid1.BeginUpdate();
                        banks.RemoveAt(i);
                        smartGrid1.EndUpdate();
                    }
                    else
                        MessageBox.Show("Ошибка при удалении: " + response.Result.Message);
                }
            }
            else
            { // Был режим выделения

                DialogResult result = MessageBox.Show($"Вы отметили {smartGrid1.SelectedRows.Count} строк." + Environment.NewLine + "Удалить отмеченные строки?", "Удаление", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {

                    oldList.AddRange(smartGrid1.SelectedRows);
                    newMarked.AddRange(smartGrid1.SelectedRows);

                    foreach (var index in oldList) ids.Add(Convert.ToInt32(smartGrid1.Rows[index]["Id"]));

                    DeleteIdsBankRequest request = new DeleteIdsBankRequest();
                    request.Ids.AddRange(ids);

                    UndeleteIdsBankResponse response = new UndeleteIdsBankResponse();
                    response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Bank.DeleteIdsBankAsync(request).ResponseAsync);

                    List<int> undelIds = new List<int>();
                    foreach (var item in response.UndeletedIds) undelIds.Add(Convert.ToInt32(item));

                    smartGrid1.BeginUpdate();
                    List<int> testList = Utils.UndeleteList<Bank>((C1FlexGrid)smartGrid1, banks, undelIds, smartGrid1.SelectedRows, "Id");
                    smartGrid1.SelectedRows = testList;
                    smartGrid1.EndUpdate();

                    if (response.Result.Status != Status.Ok)
                        MessageBox.Show("Ошибка при удалении: " + response.Result.Message);
                    else if (response.UndeletedIds.Count > 0)
                        MessageBox.Show("Данные, которые не удалось удалить остались выделенными.");
                }
            }
            return;
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshBanks();
        }

        private void smartGrid_GetUnboundValue(object sender, UnboundValueEventArgs e)
        {
            Bank _bank = smartGrid1.Rows[e.Row].DataSource as Bank;
            if (e.Row < smartGrid1.Rows.Fixed || e.Row >= smartGrid1.Rows.Count || _bank == null)
                return;
            switch (smartGrid1.Cols[e.Col].Name)
            {
                case "colCode2":
                    e.Value = _bank.Geolocation.Code2;
                    break;
            }
        }
    }
}
