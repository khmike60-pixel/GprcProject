using C1.Framework;
using C1.Win.FlexGrid;
using Google.Protobuf.WellKnownTypes;
using GrapeCity.Documents.Common;
using Grpc.Core;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contract;
using GrpcCommonNet.Proto.Utils;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Models;
using GrpcWinForms.Objects.Contracts.ContractViews;
using GrpcWinForms.Objects.Contracts.Forms;
using GrpcWinForms.Objects.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static C1.Util.Win.Win32;
using Contract = GrpcCommonNet.Library.Contract.Contract;
using Line = GrpcCommonNet.Library.Contract.Line;
using Status = GrpcCommonNet.Library.Common.Status;

namespace GrpcWinForms.Objects.Contracts.ContractViews
{
    public partial class ContractSaleStandartForm : ContractFormClass
    {
        #region Свойства

        private Contract contract;
        private BindingList<Line> lines = new BindingList<Line>();
        private int currentRow = 0;

        //public bool CurrentMode = false;

        public Contract Contract { get => contract; set => contract = value; }

        #endregion


        #region Конструкторы  и заполнение данных
        public ContractSaleStandartForm()
        {
            InitializeComponent();
        }

        public ContractSaleStandartForm(Contract _contract)
        {
            InitializeComponent();
            contract = _contract;
        }

        private async void RefreshContractFull()
        {
            try
            {
                if (contract == null) return;
                if (this.contract.Id == 0)
                {
                    // Новый контракт?
                }
                else
                {
                    GetContractRequest requestContract = new GetContractRequest
                    {
                        ContractId = this.contract.Id
                    };
                    ContractResponse responseContract = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Contract.GetContractFullAsync(requestContract).ResponseAsync
                    );
                    contract = responseContract.Contract;
                }

                headContractControl.SetControls(contract);
                sumContractControl1.SetControls(contract);

                if (contract.Initiator == null) contract.Initiator = new Manager { Name = "" };
                if (contract.Executor == null) contract.Executor = new Manager { Name = "" };
                managerControl1.SetControl(contract);

                var properties = contract?.Data;
                if (properties != null)
                {
                    var _root = properties.Fields;
                    if (_root.Count != 0)
                    {
                        var firstName = properties.Fields.Keys.First();

                        var root = properties.Fields[firstName];

                        DataNode nodes = MyConvert.ProtoConverter.ToNodeTree(properties, firstName);
                        propertiesControl1.SetTreeNodes(nodes);
                    }
                }

                if (ViewMode == ViewMode.View)
                {
                    headContractControl.ReadOnly = managerControl1.ReadOnly =
                    sumContractControl1.ReadOnly = true;
                    buttonOk.Enabled = false;
                    toolStripButtonEdit.Enabled = true;
                    toolStripButtonNewLine.Enabled = false;
                    toolStripButtonDoubleLine.Enabled = false;
                    toolStripButtonEditLine.Enabled = false;
                    toolStripButtonDeleteLine.Enabled = false;
                    toolStripButtonSetupSpecification.Enabled = false;


                }
                if (ViewMode == ViewMode.Edit)
                {
                    headContractControl.ReadOnly = managerControl1.ReadOnly =
                    sumContractControl1.ReadOnly = false;
                    buttonOk.Enabled = true;
                    toolStripButtonEdit.Enabled = false;
                    toolStripButtonNewLine.Enabled = true;
                    toolStripButtonDoubleLine.Enabled = true;
                    toolStripButtonEditLine.Enabled = true;
                    toolStripButtonDeleteLine.Enabled = true;
                    toolStripButtonSetupSpecification.Enabled = true;
                }
                if (ViewMode == ViewMode.New)
                {
                    headContractControl.ReadOnly = managerControl1.ReadOnly =
                    sumContractControl1.ReadOnly = false;
                    buttonOk.Enabled = true;
                    toolStripButtonEdit.Enabled = true;
                    toolStripButtonNewLine.Enabled = true;
                    toolStripButtonDoubleLine.Enabled = true;
                    toolStripButtonEditLine.Enabled = true;
                    toolStripButtonDeleteLine.Enabled = true;
                    toolStripButtonSetupSpecification.Enabled = true;
                }

                lines = new BindingList<Line>(contract.Lines);
                smartGridLines1.DataSource = lines;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка в дополнительных параметрах");
            }

            //this.Text = $"Контракт № {contract.Number} от {contract.Date.ToDateTime().ToShortDateString()} (Id={ContractId})";
        }

        #endregion


        #region  Работа с вкладками

        // Нет ссылок, по-моему не  работает
        private void smartGridHistory_GetUnboundValue(object sender, C1.Win.FlexGrid.UnboundValueEventArgs e)
        {
            Contract _contract = (Contract)historyContractControl.smartGridHistory1.Rows[e.Row].DataSource;
            switch (historyContractControl.smartGridHistory1.Cols[e.Col].Name)
            {
                case "colDate":
                    {
                        e.Value = _contract.Date == null ? "" : _contract.Date.ToDateTime();
                        break;
                    }
                case "colAbbrev":
                    {
                        e.Value = _contract.Currency == null ? "" : _contract.Currency.Abbrev;
                        break;
                    }
                case "colSum":
                    {
                        e.Value = _contract.Sum == null || _contract.Sum.Units == 0 ? "" : MyConvert.ToDecimal(_contract.Sum);
                        break;
                    }
                case "colAmount":
                    {
                        e.Value = _contract.Amount == null || _contract.Amount.Units == 0 ? "" : MyConvert.ToDecimal(_contract.Amount);
                        break;
                    }
                case "colSumVat":
                    {
                        e.Value = _contract.SumVat == null || _contract.SumVat.Units == 0 ? "" : MyConvert.ToDecimal(_contract.SumVat);
                        break;
                    }
                case "colType":
                    {
                        if (_contract.RootId == 0)
                            e.Value = "Основной контракт";
                        else
                            e.Value = "Дополнительное соглашение";
                        break;
                    }
            }
        }


        #endregion


        #region Методы формы и кнопки формы
        private void ContractStandartForm_Load(object sender, EventArgs e)
        {
            RefreshContractFull();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                Contract oldContract = contract;
                // Сделать отдельный метод по обновлению контракта !!!!!

                // Обновление данных контракта на основе данных из headContractControl
                // Получаем выбранного покупателя из headContractControl
                if (headContractControl.companyBuyer.SelectedItem.Id != 0)
                    contract.Buyer = headContractControl.companyBuyer.SelectedCompany;

                // Получаем выбранного продавца из headContractControl
                if (headContractControl.companySeller.SelectedItem.Id != 0)
                    contract.Seller = headContractControl.companySeller.SelectedCompany;

                //if (headContractControl.comboBoxCurrency.SelectedIndex != 0)
                //    contract.Currency = headContractControl.comboBoxCurrency.SelectedItem.Id;    // Получаем выбранную валюту из headContractControl

                // Получаем номер контракта из headContractControl
                contract.Number = headContractControl.textBoxNumber.Text;

                // Получаем дату контракта из headContractControl
                contract.Date = headContractControl.dateEditStart.Value == DBNull.Value ?
                    null :
                    Convert.ToDateTime(headContractControl.dateEditStart.Value).ToUniversalTime().ToTimestamp();

                // Получаем дату окончания контракта из headContractControl
                contract.ExpirationDate = headContractControl.dateEditStop.Value == DBNull.Value ?
                    null :
                    Convert.ToDateTime(headContractControl.dateEditStop.Value).ToUniversalTime().ToTimestamp();
                contract.Currency = new Currency()
                {
                    Id = headContractControl.smartBoxCurrency.SelectedItemBox == null ? 0 : headContractControl.smartBoxCurrency.SelectedItemBox.Id,
                    Abbrev = headContractControl.smartBoxCurrency.SelectedItemBox == null ? "" : headContractControl.smartBoxCurrency.SelectedItemBox.Name
                };

                // Получаем наименование контракта из headContractControl

                // Обновление данных контракта на основе данных из sumContractControl1

                // Обновление данных контракта на основе данных из propertiesControl1

                // Обновление данных контракта на основе данных из smartGridLines1

                // Обновление данных контракта на основе данных из managerControl
                contract.Initiator = new Manager
                {
                    Id = managerControl1.smartBoxInitiator.SelectedItemBox.Id,
                    Name = managerControl1.smartBoxInitiator.SelectedItemBox.Name
                };
                contract.Executor = new Manager
                {
                    Id = managerControl1.smartBoxExecutor.SelectedItemBox.Id,
                    Name = managerControl1.smartBoxExecutor.SelectedItemBox.Name
                };
                contract.Metadata.CreateUserid = managerControl1.smartBoxCreator.SelectedItemBox.Id;
                contract.Metadata.CreateBy = managerControl1.smartBoxCreator.SelectedItemBox.Name;

                ContractRequest request = new ContractRequest()
                {
                    Contract = contract
                };

                ContractResponse response = new ContractResponse();
                if (ViewMode == ViewMode.Edit)  // Редактируем запись
                {
                    response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Contract.UpdateContractAsync(request).ResponseAsync
                    );
                }
                if (ViewMode == ViewMode.New)  // Создаем новый контракт
                {
                    response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Contract.CreateContractAsync(request).ResponseAsync
                    );
                }


                if (response.Result.Status != Status.Ok)
                {
                    contract = oldContract;
                    throw new InvalidOperationException($"Ошибка обновления / создания контракта: {response.Result.Message}");
                }
                contract = response.Contract;

                // Уведомляем всех подписчиков об изменении
                if (ViewMode == ViewMode.Edit)
                    ContractEventService.Instance.RaiseContractChanged(contract, ContractChangeType.Updated);
                if (ViewMode == ViewMode.New)
                    ContractEventService.Instance.RaiseContractChanged(contract, ContractChangeType.Created);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();
        }

        private async void c1DockingTab2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c1DockingTab2.SelectedIndex == 2)
            {
                historyContractControl.SetControl(contract);
            }
        }

        #endregion


        #region Методы smartGridLines

        private void smartGridLines1_OwnerDrawCell(object sender, C1.Win.FlexGrid.OwnerDrawCellEventArgs e)
        {
            int row = e.Row;
            Line line = smartGridLines1.Rows[row].DataSource as Line;
            // Получаем базовый стиль
            var baseStyle = e.Style ?? smartGridLines1.Styles.Normal;

            // Получаем базовый шрифт
            var baseFont = baseStyle?.Font ?? smartGridLines1.Font ?? SystemFonts.DefaultFont;

            if (!Validate(line))
            {
                // Добавляем Strikeout
                if ((baseFont.Style & FontStyle.Strikeout) != FontStyle.Strikeout)
                    e.Style.Font = new Font(baseFont.FontFamily, baseFont.Size, baseFont.Style | FontStyle.Strikeout);
                else
                    e.Style.Font = baseFont;
            }
            else
            {
                // Убираем Strikeout, если он был
                if ((baseFont.Style & FontStyle.Strikeout) == FontStyle.Strikeout)
                    e.Style.Font = new Font(baseFont.FontFamily, baseFont.Size, baseFont.Style & ~FontStyle.Strikeout);
                else
                    e.Style.Font = baseFont;
            }
        }

        private void smartGridLines_GetUnboundValue(object sender, C1.Win.FlexGrid.UnboundValueEventArgs e)
        {
            Line line = (Line)smartGridLines1.Rows[e.Row].DataSource;
            switch (smartGridLines1.Cols[e.Col].Name)
            {
                case "colUnitShort":
                    {
                        e.Value = line.Unit == null ? "" : line.Unit.Short;
                        break;
                    }
                case "colQty":
                    {
                        e.Value = line.Qty == null || line.Qty.Units == 0 ? "" : MyConvert.ToDecimal(line.Qty);
                        break;
                    }
                case "colPrice":
                    {
                        e.Value = line.Price == null || line.Price.Units == 0 ? "" : MyConvert.ToDecimal(line.Price);
                        break;
                    }
                case "colAmount":
                    {
                        e.Value = line.Amount == null || line.Amount.Units == 0 ? "" : MyConvert.ToDecimal(line.Amount);
                        break;
                    }
                case "colVatPrc":
                    {
                        e.Value = line.VatPrc == null || line.VatPrc.Units == 0 ? "" : MyConvert.ToDecimal(line.VatPrc);
                        break;
                    }
                case "colSumVat":
                    {
                        e.Value = line.SumVat == null || line.SumVat.Units == 0 ? "" : MyConvert.ToDecimal(line.SumVat);
                        break;
                    }
                case "colSum":
                    {
                        e.Value = line.Sum == null || line.Sum.Units == 0 ? "" : MyConvert.ToDecimal(line.Sum);
                        break;
                    }
            }
        }

        private void smartGridLines1_SetUnboundValue(object sender, UnboundValueEventArgs e)
        {
            try
            {
                int row = e.Row;
                switch (smartGridLines1.Cols[e.Col].Name)
                {
                    case "colQty":
                        lines[e.Row - smartGridLines1.Rows.Fixed].Qty = MyConvert.ToDecimalValue(Convert.ToDecimal(e.Value));
                        break;
                    case "colPrice":
                        lines[e.Row - smartGridLines1.Rows.Fixed].Price = MyConvert.ToDecimalValue(Convert.ToDecimal(e.Value));
                        break;
                    case "colAmount":
                        lines[e.Row - smartGridLines1.Rows.Fixed].Amount = MyConvert.ToDecimalValue(Convert.ToDecimal(e.Value));
                        break;
                    case "colVatPrc":
                        lines[e.Row - smartGridLines1.Rows.Fixed].VatPrc = MyConvert.ToDecimalValue(Convert.ToDecimal(e.Value));
                        break;
                    case "colSumVat":
                        lines[e.Row - smartGridLines1.Rows.Fixed].SumVat = MyConvert.ToDecimalValue(Convert.ToDecimal(e.Value));
                        break;
                    case "colSum":
                        lines[e.Row - smartGridLines1.Rows.Fixed].Sum = MyConvert.ToDecimalValue(Convert.ToDecimal(e.Value));
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Join(Environment.NewLine, "Ошибка при редактировании.",
                    ex.Message));
            }
        }

        private async void smartGridLines1_AfterEdit(object sender, RowColEventArgs e)
        {
            Line line = smartGridLines1.Rows[e.Row].DataSource as Line;
            UpdateContractLineRequest request = new UpdateContractLineRequest()
            { Line = line, FieldMask = new FieldMask { Paths = { } } };
            try
            {

                switch (smartGridLines1.Cols[e.Col].Name)
                {
                    case "Order":
                        line.Order = Convert.ToInt32(smartGridLines1[e.Row, e.Col]);
                        request.FieldMask.Paths.Add("order");
                        break;
                    case "Name":
                        line.Name = smartGridLines1[e.Row, e.Col].ToString();
                        request.FieldMask.Paths.Add("name");
                        break;
                    case "colQty":
                        line.Qty = MyConvert.ToDecimalValue(smartGridLines1[e.Row, e.Col].ToString());
                        request.FieldMask.Paths.Add("qty");
                        break;
                    case "colPrice":
                        line.Price = MyConvert.ToDecimalValue(smartGridLines1[e.Row, e.Col].ToString());
                        request.FieldMask.Paths.Add("price");
                        break;
                    case "colAmount":
                        line.Amount = MyConvert.ToDecimalValue(smartGridLines1[e.Row, e.Col].ToString());
                        request.FieldMask.Paths.Add("amount");
                        break;
                    case "colVatPrc":
                        request.FieldMask.Paths.Add("vat_prc");
                        break;
                    case "colSumVat":
                        request.FieldMask.Paths.Add("sum_vat");
                        break;
                    case "colSum":
                        request.FieldMask.Paths.Add("sum");
                        break;
                }

                request.Line = line;

                //  Обновляем строку контракта на сервере   
                ContractLineResponse response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Contract.UpdateContractLineAsync(request).ResponseAsync);
                if (response.Result.Status == Status.Ok)
                {
                    int updatedRow = e.Row - smartGridLines1.Rows.Fixed;
                    lines[updatedRow] = response.Line;
                }

                // Получаем обновленный контракт с сервера, чтобы обновить сумму контракта
                GetContractRequest contractRequest = new GetContractRequest() { ContractId = contract.Id };
                ContractResponse contractResponse = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Contract.GetContractAsync(contractRequest).ResponseAsync);
                if (contractResponse.Result.Status == Status.Ok)
                {
                    contract = contractResponse.Contract;
                    sumContractControl1.textBoxSumContract.Text = MyConvert.ToDecimal(contract.Sum).ToString();

                    // Уведомляем всех подписчиков об изменении контракта
                    ContractEventService.Instance.RaiseContractChanged(contract, ContractChangeType.Updated);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Join(Environment.NewLine, "Ошибка при редактировании.",
                    ex.Message));
            }
        }

        private void smartGridLines1_BeforeEdit(object sender, RowColEventArgs e)
        {
            Line line = smartGridLines1.Rows[e.Row].DataSource as Line;

            // Получаем базовый шрифт
            var baseFont = smartGridLines1.Styles.Normal.Font ?? smartGridLines1.Font ?? SystemFonts.DefaultFont;

            if (!Validate(line))
            {
                // Добавляем Strikeout
                if ((baseFont.Style & FontStyle.Strikeout) != FontStyle.Strikeout)
                    smartGridLines1.Rows[e.Row].Style.Font = new Font(baseFont.FontFamily, baseFont.Size, baseFont.Style | FontStyle.Strikeout);
            }
            else
            {
                // Убираем Strikeout, если он был
                if ((baseFont.Style & FontStyle.Strikeout) == FontStyle.Strikeout)
                    smartGridLines1.Rows[e.Row].Style.Font = new Font(baseFont.FontFamily, baseFont.Size, baseFont.Style & ~FontStyle.Strikeout);
            }
        }

        private void smartGridLines1_DoubleClick(object sender, EventArgs e)
        {
            int row = smartGridLines1.Row;
            if (row < smartGridLines1.Rows.Fixed || row >= smartGridLines1.Rows.Count) return;

        }

        private async void toolStripButtonNewLine_Click(object sender, EventArgs e)
        {
            try
            {
                CreateContractLineRequest request = new CreateContractLineRequest
                {
                    Line = new Line
                    {
                        ContractId = contract.Id,
                        PreviousId = null,
                        Product = null,
                        Unit = null,
                        //                    Order = 0,
                        Name = "Новая строка",
                        Qty = MyConvert.ToDecimalValue(1),
                        BasePrice = MyConvert.ToDecimalValue(0),
                        BaseDiscount = MyConvert.ToDecimalValue(0),
                        DiscountAdditional = MyConvert.ToDecimalValue(0),
                        Price = MyConvert.ToDecimalValue(0),
                        //                    Amount = MyConvert.ToDecimalValue(0),
                        IsVat = true,
                        VatPrc = MyConvert.ToDecimalValue(12),
                        //                    SumVat = MyConvert.ToDecimalValue(0),
                        //                    Sum = MyConvert.ToDecimalValue(0),
                        Comment = "",
                        RoundForLine = MyConvert.ToDecimalValue(0),
                        Specification = 1,
                        AddedFrom = "",
                        Metadata = new GrpcCommonNet.Library.Contract.Metadata
                        {
                            CreateUserid = 0,                                       // Должно заполнятся на службе
                            CreateBy = "",                                          // Должно заполнятся на службе
                            CreateAt = DateTime.Now.ToUniversalTime().ToTimestamp() // Должно заполнятся на службе 
                        },
                        Operation = "новая"
                    }
                };

                ContractLineResponse response = await GrpcRetry.Call(() =>
                    GrpcClients.GrpcClients.Contract.CreateContractLineAsync(request).ResponseAsync
                );

                if (response.Result.Status != Status.Ok)
                {
                    throw new InvalidOperationException($"Ошибка создания строки контракта: {response.Result.Message}");
                }

                lines.Add(response.Line);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Join(Environment.NewLine, "Ошибка при добавлении строки контракта",
                    ex.Message));
            }
        }

        /// <summary>
        /// Валидация строки. Пока реализована тольео смена стиля для удаленных записей
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private bool Validate(Line line)
        {
            if (line == null) return true;
            if (line.Operation == "удалена") return false;
            return true;
        }


        #endregion

        private void toolStripButtonSetupSpecification_Click(object sender, EventArgs e)
        {
            using (var setupSpecificationForm = new SetupSpecificationForm())
            {
                if (setupSpecificationForm.ShowDialog() == DialogResult.OK)
                {
                    var str = setupSpecificationForm.StringJson;
                    // Handle OK result if needed
                }
            }
        }


    }
}
