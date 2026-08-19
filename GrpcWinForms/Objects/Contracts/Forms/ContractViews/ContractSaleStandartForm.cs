using C1.Framework;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contract;
using GrpcCommonNet.Proto.Utils;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Models;
using GrpcWinForms.Objects.Contracts.Forms.ContractViews;
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
using Status = GrpcCommonNet.Library.Common.Status;

namespace GrpcWinForms.Objects.Contracts.Forms.ContractViews
{ 
    public partial class ContractSaleStandartForm : ContractFormClass
    {        
        //private int contractId = 0;
        //public int ContractId
        //{
        //    get { return contractId; }
        //    set { contractId = value; }
        //}
        private Contract contract;



        public ContractSaleStandartForm()
        {
            InitializeComponent();

            //smartGridLines1.Headers = new string[]
            //{
            //    "Id\tНомер\tНаименование\tЕд.изм.\tКол-во\tРеализация\tРеализация\tНДС\tНДС\tСумма с НДС",
            //    "Id\tНомер\tНаименование\tЕд.изм.\tКол-во\tЦена\tСумма\t(%)\tСумма\tСумма с НДС",
            //    "Id\tНомер\tНаименование\tЕд.изм.\tКол-во\tЦена\tСумма\t(%)\tСумма\tСумма с НДС"
            //};

        }

        public ContractSaleStandartForm(int id)
        {
            InitializeComponent();
            ContractId = id;
        }

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

        private void ContractStandartForm_Load(object sender, EventArgs e)
        {
            RefreshContractFull();
        }

        // Обновление контракта делается одним запросом - быстрее.
        private async void RefreshContractFull()
        {
            try
            {
                if (this.ContractId == 0)
                {
                    return;
                }
                GetContractRequest requestContract = new GetContractRequest { ContractId = this.ContractId };
                ContractResponse responseContract = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Contract.GetContractFullAsync(requestContract).ResponseAsync
                );
                contract = responseContract.Contract;
                headContractControl.SetControls(contract);
                sumContractControl1.SetControls(contract);
                managerControl1.SetControl(contract);
                var properties = contract.Data;
                if (properties != null)
                {
                    var _root = properties.Fields;
                    var firstName = properties.Fields.Keys.First();

                    var root = properties.Fields[firstName];

                    DataNode nodes = MyConvert.ProtoConverter.ToNodeTree(properties, firstName);
                    propertiesControl1.SetTreeNodes(nodes);
                }
                smartGridLines1.DataSource = contract.Lines;
            }
            catch
            {
                MessageBox.Show("Ошибка в дополнительных параметрах");
            }

            this.Text = $"Контракт № {contract.Number} от {contract.Date.ToDateTime().ToShortDateString()} (Id={ContractId})";
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
                    DateTime.MinValue.ToTimestamp() :
                    Convert.ToDateTime(headContractControl.dateEditStart.Value).ToTimestamp();

                // Получаем дату окончания контракта из headContractControl
                contract.ExpirationDate = headContractControl.dateEditStop.Value == DBNull.Value ?
                    DateTime.MinValue.ToUniversalTime().ToTimestamp() :
                    Convert.ToDateTime(headContractControl.dateEditStop.Value).ToUniversalTime().ToTimestamp();

                // Получаем наименование контракта из headContractControl

                // Обновление данных контракта на основе данных из sumContractControl1

                // Обновление данных контракта на основе данных из propertiesControl1

                // Обновление данных контракта на основе данных из smartGridLines1

                // Обновление данных контракта на основе данных из managerControl
                //contract.Manager = managerControl1.SelectedManager; // Получаем выбранного менеджера из managerControl

                UpdateContractRequest request = new UpdateContractRequest()
                {
                    Contract = contract
                };
                ContractResponse response = new ContractResponse();
                response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Contract.UpdateContractAsync(request).ResponseAsync
                );
                if (response.Result.Status != Status.Ok)
                {
                    contract = oldContract;
                    throw new InvalidOperationException($"Ошибка обновления контракта: {response.Result.Message}");
                }
                contract = response.Contract;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // Вызываем событие, если кто-то на него подписан
            OnContractChanged(contract);
            //MessageBox.Show("Данные будут записаны");
            Close();
        }
    }

    public class Specification
    {
        public int Order { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
    }
}
