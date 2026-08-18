
using C1.Win.FlexGrid;
using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Application;
using GrpcCommonNet.Library.Currency;
using GrpcCommonNet.Library.Common;
using GrpcWinForms.Models;
using GrpcWinForms.Objects.Applications.Forms;
using GrpcWinForms.Objects.Currencies.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using GrpcWinForms.GrpcUtils;

namespace GrpcWinForms.Forms
{
    public partial class CurrenciesForm : Form
    {
        private BindingList<Currency> currencies;

        public CurrenciesForm()
        {
            InitializeComponent();
        }

        private async void CurrenciesForm_Load(object sender, EventArgs e)
        {
            RefreshCurrency(sender, e);
        }

        private async void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshCurrency(sender, e);
        }

        private async void RefreshCurrency(object sender, EventArgs e)
        {
            ListCurrencyRequest request = new ListCurrencyRequest()
            {
                IncludeInvisible = checkIncludeInvisible.Checked,
                CurrencyAbbrev = string.IsNullOrWhiteSpace(textAbbrev.Text) ? String.Empty : textAbbrev.Text,
            };
            request.FieldMask = new FieldMask();
            request.FieldMask.Paths.Add("name");
            request.FieldMask.Paths.Add("code");
            request.FieldMask.Paths.Add("id");
            request.FieldMask.Paths.Add("abbrev");
            request.FieldMask.Paths.Add("order_number");
            request.FieldMask.Paths.Add("is_visible");

            ListCurrencyResponse response = await GrpcRetry.CallAsync(()=>
                GrpcClients.GrpcClients.Currency.GetListCurrencyAsync(request).ResponseAsync
            );
            currencies = new BindingList<Currency>(response.Currencies);
            smartGrid1.DataSource = currencies;

        }

        private async void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            using (var form = new CurrencyForm())
            {
                form.IsNew = true;
                form.Currency = new Currency();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    CreateCurrencyRequest request = new CreateCurrencyRequest
                    {
                        Currency = form.Currency
                    };

                    CurrencyResponse response = await GrpcRetry.CallAsync(()=>
                        GrpcClients.GrpcClients.Currency.CreateCurrencyAsync(request).ResponseAsync
                    );
                    if (response.Result.Status != Status.Ok || response.Currency == null)
                    {
                        MessageBox.Show("Добавить данные не удалось.");
                        return;
                    }
                    else
                    {
                        int rowsel = smartGrid1.RowSel;
                        currencies.Insert(smartGrid1.RowSel - smartGrid1.Rows.Fixed, response.Currency);
                        smartGrid1.Row = rowsel;
                    }

                }
            }
        }

        private async void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            using (var form = new CurrencyForm())
            {
                form.IsNew = false;
                form.Currency = currencies[smartGrid1.RowSel - smartGrid1.Rows.Fixed];

                if (form.ShowDialog() == DialogResult.OK)
                {
                    UpdateCurrencyRequest request = new UpdateCurrencyRequest
                    {
                        Currency = form.Currency
                    };

                    CurrencyResponse response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Currency.UpdateCurrencyAsync(request).ResponseAsync
                    );
                    if (response.Result.Status != Status.Ok || response.Currency == null)
                    {
                        MessageBox.Show("Изменить данные не удалось.");
                        return;
                    }
                    else
                    {
                        int rowsel = smartGrid1.RowSel;
                        currencies[rowsel - smartGrid1.Rows.Fixed] = response.Currency;
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
                    DeleteCurrencyRequest request = new DeleteCurrencyRequest()
                    {
                        Id = (int)smartGrid1.Rows[smartGrid1.RowSel]["Id"]
                    };
                    DeleteCurrencyResponse response = await GrpcRetry.CallAsync(() => 
                        GrpcClients.GrpcClients.Currency.DeleteCurrencyAsync(request).ResponseAsync
                    );
                    int i = smartGrid1.RowSel - smartGrid1.Rows.Fixed;
                    if (response.Result.Status == Status.Ok)
                    {
                        smartGrid1.BeginUpdate();
                        currencies.RemoveAt(i);
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

                    DeleteIdsCurrencyRequest request = new DeleteIdsCurrencyRequest();
                    request.Ids.AddRange(ids);

                    UndeletedIdsCurrencyResponse response = new UndeletedIdsCurrencyResponse();
                    response = await GrpcRetry.CallAsync(() => 
                        GrpcClients.GrpcClients.Currency.DeleteIdsCurrencyAsync(request).ResponseAsync
                    );

                    List<int> undelIds = new List<int>();
                    foreach (var item in response.UndeletedIds) undelIds.Add(Convert.ToInt32(item));

                    smartGrid1.BeginUpdate();
                    List<int> testList = Utils.UndeleteList<Currency>((C1FlexGrid)smartGrid1, currencies, undelIds, smartGrid1.SelectedRows, "Id");
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

        private void smartGrid_AfterResizeColumn(object sender, RowColEventArgs e)
        {
            smartGrid1.Cols["Name"].StarWidth = "*";
        }

    }
}
