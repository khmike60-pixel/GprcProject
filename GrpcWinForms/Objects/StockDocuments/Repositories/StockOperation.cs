using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.StockDocuments.Repositories
{
    public class StockOperation
    {
        int Id {  get; set; }

        [Display(Name = "Тип операции", ShortName = "Тип")]
        int TypeOperation {  get; set; }
        [Display(Name = "Грузоотправитель", ShortName = "Кто")]
        int Consigner { get; set; }
        [Display(Name = "Грузополучатель", ShortName = "Кому")]
        int Consignee { get; set; }
        [Display(Name = "Склад получатель", ShortName = "На склад")]
        int ToStock {  get; set; }
        [Display(Name = "Склад отправитель", ShortName = "Со склада")]
        int FromStock { get; set; }
        [Display(Name = "Сумма отгрузки", ShortName = "Отгружено")]
        decimal SumOut { get; set; }
        [Display(Name = "Сумма поступления", ShortName = "Получено")]
        decimal SumInp {  get; set; }
    }

    public class Stock
    {
        int Id { get; set; }
        string Name { get; set; }
        int ParentId { get; set; }
    }
}
