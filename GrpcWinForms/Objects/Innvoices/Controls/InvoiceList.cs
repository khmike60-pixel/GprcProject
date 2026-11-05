using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Innvoices.Controls
{
    public partial class InvoiceList : UserControl
    {
        public InvoiceList()
        {
            InitializeComponent();
            Setup();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

        }

        private void Setup()
        {
            grid[0, 0] = grid[1, 0] = "...";
            grid[0, 1] = grid[1, 1] = "Id";
            grid[0, 2] = grid[1, 2] = "Статус";
            grid[0, 3] = grid[1, 3] = "Тип док.";
            grid[0, 4] = grid[1, 4] = "Дата";
            grid[0, 5] = grid[1, 5] = "Номер";
            grid[0, 6] = "Контрагент"; grid[1, 6] = "Покупатель";
            grid[0, 7] = "Контрагент"; grid[1, 7] = "Продавец";
            grid.Cols[6].StarWidth = grid.Cols[7].StarWidth = "*";
            grid[0, 8] = grid[1, 8] = "Сумма";
            grid[0, 9] = grid[1, 9] = "НДС";
            grid[0, 10] = grid[1, 10] = "Сумма с НДС";
            grid[0, 11] = "Ответственный"; grid[1, 11] = "Отдел";
            grid[0, 12] = "Ответственный"; grid[1, 12] = "Менеджер";
            grid[0, 13] = grid[1, 13] = "Комментарий";

        }
    }
}
