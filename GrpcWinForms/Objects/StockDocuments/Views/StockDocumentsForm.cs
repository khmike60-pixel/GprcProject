using C1.Win.FlexGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.StockDocuments.Views
{
    public partial class StockDocumentsForm : Form
    {
        public StockDocumentsForm()
        {
            InitializeComponent();
        }

        private void gridStockOperation_Resize(object sender, EventArgs e)
        {
            // Проверяем, присутствует ли горизонтальный скроллбар в текущей маске видимости
            bool hasHorizontalScroll = (gridStockOperation.ScrollBarsVisible & ScrollBars.Horizontal) != 0;

            if (!hasHorizontalScroll)
            {
                // Нижний скроллбар исчез — все колонки полностью уместились на экране
                //if (gridStockOperation.Cols[6].StarWidth != "*") gridStockOperation.Cols[6].StarWidth = "*";
                //if (gridStockOperation.Cols[8].StarWidth != "*") gridStockOperation.Cols[8].StarWidth = "*";
            }

        }

        private void gridStockOperation_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void gridStockOperation_AfterResizeColumn(object sender, RowColEventArgs e)
        {

        }

        private void gridStockOperation_BeforeResizeColumn(object sender, RowColEventArgs e)
        {
            if (gridStockOperation.Cols[e.Col].StarWidth != "*") gridStockOperation.Cols[e.Col].StarWidth = "*";
        }
    }
}
