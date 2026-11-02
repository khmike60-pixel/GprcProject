using C1.Win.FlexGrid;
using C1.Win.TreeView;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Geolocation;
using GrpcWinForms.Controls.TreeBox;
using GrpcWinForms.Objects.DocumentTypes.Models;
using GrpcWinForms.Objects.StockDocuments.Models;
using GrpcWinForms.Objects.StockDocuments.Presenters;
using GrpcWinForms.Objects.Stocks.Repositories;


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
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            if (Period == null)
            {
                Period = new PeriodBox();
                Period.Period.SetPeriod(DateTime.Now.AddDays(-90), DateTime.Now);
            }
        }

        private async void StockDocumentsForm_Load(object sender, EventArgs e)
        {
            // Фильтрация по типу документа
            if (Type == null) Type = new DocumentType() { Code = "WHDocuments" };
            List<TreeStockDocType> treeStockDocTypes = await _presenter.GetStockDocTypes(Type);
            tbType.BuildTree(treeStockDocTypes, false);
            tbType.InitialNode = new TreeStockDocType() { Id = 16, Name = "Складские документы" };    // Текущее значение
            tbType.DropDownWidth = 350;

            // Фильтрация по складам
            PlaceTo = new Place() { Id = -1 }; // Ограничение для складов (должно быть пусто)

            List<TreePlace> itemsTo  = await _presenter.GetPlace(PlaceTo);
            itemsTo.Insert(0, new TreePlace() { Name = "Отгрузка во вне", Id = -1, ParentId = 0 });
            tbPlaceTo.BuildTree(itemsTo, false); // Для отгрузки во вне корень в дереве не нужен
            TreePlace treeItemTo = new TreePlace() { Id = -1, Name = "Отгрузка во вне" }; // Текущее значение
            tbPlaceTo.InitialNode = treeItemTo;

            PlaceFrom = new Place() { Id = 4 }; // Ограничение по складу "А. Каххара, 19/21 (Полиграфия)"
            List<TreePlace> itemsFrom = await _presenter.GetPlace(PlaceFrom);
            tbPlaceFrom.BuildTree(itemsFrom); // Для фильтра по реальным местам хранения корень нужен
            TreePlace treeItemFrom = new TreePlace() { Id = 4, ParentId = 3, Name = "А. Каххара, 19/21 (Полиграфия)" }; // Текущее значение
            tbPlaceFrom.InitialNode = treeItemFrom;

            _presenter.LoadStockDocuments();
            gridStockOperation.DataSource = Operations;

        }
    }
}
