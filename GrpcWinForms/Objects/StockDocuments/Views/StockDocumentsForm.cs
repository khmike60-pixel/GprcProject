using C1.Win.FlexGrid;
using C1.Win.TreeView;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Geolocation;
using GrpcWinForms.Controls.TreeBox;
using GrpcWinForms.Objects.StockDocuments.Presenters;
using GrpcWinForms.Objects.Stocks.Repositories;
using GrpcWinForms.Objects.Test;


//using GrpcWinForms.Objects.StockDocuments.Repositories;
using SmartLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.StockDocuments.Views
{
    public partial class StockDocumentsForm : Form, IStockDocuments
    {
        private StockDocumentsPresenter _presenter;


        #region Общие Свойства интерфейса
        public bool DialogMode { get; set; }
        public BindingList<StockOperation> Operations { get; set; }
        public int Row { get; set; }
        public IList<int> SelectedRows { get; set; }

        #endregion

        #region Свойства зоны фильтрации
        public PeriodBox Period { get; set; }
        public Contragent ContragentTo { get; set; }
        public Contragent ContragentFrom { get; set; }
        public TreeBox StockTo { get; set; }
        public Stock StockFrom { get; set; }
        public DocumentType Type { get; set; }
        public string Number { get; set; }
        Stock IStockDocuments.StockTo { get; set; }
        public Place PlaceTo { get; set; }
        public Place PlaceFrom { get; set; }

        #endregion

        public StockDocumentsForm()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            _presenter = new StockDocumentsPresenter(this);
            Setup();

        }

        private void Setup()
        {

        }

        private async void StockDocumentsForm_Load(object sender, EventArgs e)
        {
            List<TreeItem> itemsTo  = await _presenter.GetPlaceTo();
            tbPlaceTo.BuildTree(itemsTo);
            TreeItem treeItemTo = new TreeItem() { Id = 3, ParentId = 0, Name = "А. Каххара склад" };
            tbPlaceTo.InitialNode = treeItemTo;

            List<TreeItem> itemsFrom = await _presenter.GetPlaceFrom();
            tbPlaceFrom.BuildTree(itemsFrom);
            TreeItem treeItemFrom = new TreeItem() { Id = 4, ParentId = 3, Name = "А. Каххара, 19/21 (Полиграфия)" };
            tbPlaceFrom.InitialNode = treeItemFrom;

        }
    }
}
