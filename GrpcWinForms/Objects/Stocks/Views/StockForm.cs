using GrpcCommonNet.Library.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Stocks.Views
{
    public partial class StockForm : Form, IStock
    {
        private Stock _stock = new();
        public StockForm()
        {
            InitializeComponent();
        }

        public string NameStock { get => txtNameStock.Text; }
        public int PlaceId { get; }
        public Stock Stock { get => _stock; set => _stock = value; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void StockForm_Load(object sender, EventArgs e)
        {
            txtNameStock.Text = _stock.Name;
            sbPlace.Text = _stock.Place?.Name;

        }
    }
}
