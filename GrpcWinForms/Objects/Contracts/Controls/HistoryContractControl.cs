using GrpcCommonNet.Library.Contract;
using GrpcCommonNet.Proto.Utils;
using GrpcWinForms.Objects.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Contract = GrpcCommonNet.Library.Contract.Contract;

namespace GrpcWinForms.Objects.Contracts.Controls
{
    public partial class HistoryContractControl : UserControl
    {
        private Contract contract;

        public Contract Contract { get => contract; }
        
        public HistoryContractControl()
        {
            InitializeComponent();
        }

        public void SetControl(Contract _contract)
        {
            contract = _contract;
        }

        private void smartGridHistory1_DoubleClick(object sender, EventArgs e)
        {
            int row = smartGridHistory1.Row;
            if (row < smartGridHistory1.Rows.Fixed || row > smartGridHistory1.Rows.Count - smartGridHistory1.Footers.Descriptions.Count)
                return;

            Contract viewContract = smartGridHistory1.Rows[row].DataSource as Contract;

            ViewContract view = new ViewContract(viewContract);
            view.Show();

        }

        private void smartGridHistory1_GetUnboundValue(object sender, C1.Win.FlexGrid.UnboundValueEventArgs e)
        {
            var col = smartGridHistory1.Cols[e.Col];

            Contract _contract = smartGridHistory1.Rows[e.Row].DataSource as Contract;
            //if (contract == null) return;
            switch (smartGridHistory1.Cols[e.Col].Name)
            {
                case "colNumber":
                    e.Value = _contract.RootId == 0? "Первичный контракт № " + _contract.Number : "Допсоглашение № " + _contract.Number;
                    break;
                case "colDate":
                    e.Value = _contract.Date.ToDateTime();
                    break;
                case "colCurrency":
                    e.Value = _contract.Currency?.Abbrev;
                    break;
                case "colSum":
                    e.Value = MyConvert.ToDecimal(_contract.Sum);
                    break;
                case "colAmount":
                    e.Value = MyConvert.ToDecimal(_contract.Amount);
                    break;
                case "colSumVat":
                    e.Value = MyConvert.ToDecimal(_contract.SumVat);
                    break;
                case "colType":
                    e.Value = _contract.TypeContract?.Name;
                    break;
            }
        }
    }
}
