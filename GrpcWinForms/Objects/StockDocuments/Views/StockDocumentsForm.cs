using C1.Win.FlexGrid;
using GrpcCommonNet.Library.Common;
using GrpcWinForms.Objects.StockDocuments.Repositories;
using SmartLib;
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
    public partial class StockDocumentsForm : Form, IStockDocuments
    {
        #region Общие Свойства интерфейса
        public bool DialogMode { get; set; }

        public BindingList<StockOperation> Operations { get;set;}
        public int Row { get; set; }
        public IList<int> SelectedRows { get; set; }

        #endregion

        #region Свойства зоны фильтрации
        public PeriodBox Period { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Contragent ContragentTo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Contragent ContragentFrom { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Stock Stock { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DocumentType Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Number { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #endregion

        public StockDocumentsForm()
        {
            InitializeComponent();
        }




    }
}
