using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Proto.Utils;
using GrpcWinForms.Objects.SalePurchaseTypes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.SalePurchaseTypes.Mapping
{
    internal class SalePurchaseRateToRateRowMapper 
    {
        public static RateRow Map(SalePurchaseRate salePurchaseRate)
        {
            RateRow rateRow = new RateRow();

            rateRow.Id = Convert.ToInt32(salePurchaseRate.Id);
            rateRow.Date = salePurchaseRate.Date.ToDateTime();
            rateRow.CBRate = 0;  // Дописать
            rateRow.Rate0_1 = 0;
            rateRow.Rate0_2 = 0;
            rateRow.Rate1_1 = 0;
            rateRow.Rate1_2 = 0;
            rateRow.Rate2_1 = 0;
            rateRow.Rate2_2 = 0;
            rateRow.SalaryRate = MyConvert.ToDecimal(salePurchaseRate.SalaryRate);
            rateRow.BankToCashRes = MyConvert.ToDecimal(salePurchaseRate.BankToCashRes);
            rateRow.BankToCashNonres = MyConvert.ToDecimal(salePurchaseRate.BankToCashNonres);
            rateRow.CashToBank = MyConvert.ToDecimal(salePurchaseRate.CashToBank);
            rateRow.Vat = MyConvert.ToDecimal(salePurchaseRate.Vat);
            rateRow.Oncost = MyConvert.ToDecimal(salePurchaseRate.OnCost);
            rateRow.MaxProfit = MyConvert.ToDecimal(salePurchaseRate.MaxProfit);

            rateRow.Checked = salePurchaseRate.MetaData?.ChekedBy == null ? 0 : 1;
            rateRow.CheckDate = salePurchaseRate.MetaData?.ChekedAt.ToDateTime();
            rateRow.CheckName = salePurchaseRate.MetaData?.ChekedBy;
            rateRow.CheckerId = salePurchaseRate.MetaData?.ChekedUserid;
            rateRow.Confirmed = salePurchaseRate.MetaData?.ConfirmedBy == null ? 0 : 1;
            rateRow.ConfDate = salePurchaseRate.MetaData?.ConfirmedAt.ToDateTime();
            rateRow.ConfName = salePurchaseRate.MetaData?.ConfirmedBy;
            rateRow.ConfirmerId = salePurchaseRate.MetaData?.ConfirmedUserid;

            rateRow.State = rateRow.Confirmed;



            return rateRow;

        }
    }
}
