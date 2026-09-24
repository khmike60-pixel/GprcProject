using GrpcCommonNet.Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.SalePurchaseTypes.Models
{
    public class RateRow
    {
        /// <summary>
        /// Id записи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Признак этапа проверки документа: [0] - не проверен ( ), [1] - проверен (V), [2] - утвержден (■)
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// Дата установки курсов
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Курс ЦБ основной валюты к валюте продажи (USD/UZS)
        /// </summary>
        public decimal CBRate { get; set; }

        // Курсы из JSON-объекта ===========

        /// <summary>
        /// Курс по индексу 0 для прайслиста
        /// </summary>
        public decimal Rate0_1 { get; set; }

        /// <summary>
        /// Курс по индексу 0 при конвертации
        /// </summary>
        public decimal Rate0_2 { get; set; }

        /// <summary>
        /// Курс по индексу 1 для прайслиста
        /// </summary>
        public decimal Rate1_1 { get; set; }

        /// <summary>
        /// Курс по индексу 1 при конвертации
        /// </summary>
        public decimal Rate1_2 { get; set; }

        /// <summary>
        /// Курс по индексу 2 для прайслиста
        /// </summary>
        public decimal Rate2_1 { get; set; }

        /// <summary>
        /// Курс о индексу 2 при конвертации
        /// </summary>
        public decimal Rate2_2 { get; set; }

        // =====================================

        /// <summary>
        /// Курс UZS/USD при выдаче
        /// </summary>
        public decimal? SalaryRate { get; set; }

        /// <summary>
        /// Коэффициент (%) при конвертации безнал. в нал. (резидент)
        /// </summary>
        public decimal? BankToCashRes { get; set; }

        /// <summary>
        /// Коэффициент (%) при конвертации безнал. в нал. (нерезидент)
        /// </summary>
        public decimal? BankToCashNonres { get; set; }

        /// <summary>
        /// Коэффициент (%) при конвертации нал. в безнал.
        /// </summary>
        public decimal? CashToBank { get; set; }

        /// <summary>
        /// НДС на указанную дату
        /// </summary>
        public decimal? Vat { get; set; }

        /// <summary>
        /// Накладные расходы
        /// </summary>
        public decimal? Oncost { get; set; }

        /// <summary>
        /// Максимальная рентабельность
        /// </summary>
        public decimal? MaxProfit { get; set; }

        /// <summary>
        /// Статус "Проверено"
        /// </summary>
        public int Checked { get; set; }

        /// <summary>
        /// Статус "Утверждено"
        /// </summary>
        public int Confirmed { get; set; }

        /// <summary>
        /// Id пользователя, который проверил
        /// </summary>
        public int? CheckerId { get; set; }

        /// <summary>
        /// Инициалы пользователя, который проверил
        /// </summary>
        public string CheckName { get; set; }

        /// <summary>
        /// ФИО пользователя, который проверил
        /// </summary>
        public string CheckUserName { get; set; }

        /// <summary>
        /// Дата проверки
        /// </summary>
        public DateTime? CheckDate { get; set; }

        /// <summary>
        /// Id пользователя, который утвердил
        /// </summary>
        public int? ConfirmerId { get; set; }

        /// <summary>
        /// Инициалы того, кто утвердил
        /// </summary>
        public string ConfName { get; set; }

        /// <summary>
        /// ФИО того, кто утвердил
        /// </summary>
        public string ConfUserName { get; set; }

        /// <summary>
        /// Дата утверждения
        /// </summary>
        public DateTime? ConfDate { get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }


    }
}
