using C1.Win.FlexGrid;
using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Product;
using GrpcCommonNet.Proto.Utils;
using GrpcWinForms.Models;
using GrpcWinForms.Objects.Products.ProductsForm;
using SmartGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.ContractTypes.Forms
{
    public partial class ContractTypesForm : Form
    {
        private Loader loaderComtractTypes = new Loader();
        private BindingList<ContractType> contractTypes;
        private int maxLevel = 0;
        public ContractTypesForm()
        {
            InitializeComponent();
            loaderComtractTypes.Parent = smartGridContractTypes;
            loaderComtractTypes.Size = smartGridContractTypes.Size;
        }

        public async void RefreshContractTypes()
        {
            loaderComtractTypes.ShowLoader();
            try
            {
                smartGridContractTypes.BeginUpdate();
                List<ContractType> treeContractTypes = new List<ContractType>();
                /*
                CatalogFilterRequest request = new CatalogFilterRequest()
                {
                    Id = 0
                };
                request.FieldMask = new FieldMask();
                request.FieldMask.Paths.Add("id");
                request.FieldMask.Paths.Add("name");
                request.FieldMask.Paths.Add("parent_id");
                request.FieldMask.Paths.Add("parent_ids");
                request.FieldMask.Paths.Add("parent_names");
                request.FieldMask.Paths.Add("is_product_kind");
                request.FieldMask.Paths.Add("is_list");

                TreeCatalogResponse response = await GrpcClients.GrpcClients.Product.TreeCatalogAsync(request);

                List<TreeCatalog> treeCatalogs = new List<TreeCatalog>();

                foreach (var item in response.Catalog)
                {
                    treeCatalogs.Add(new TreeCatalog()
                    {
                        Id = Convert.ToInt32(item.Id),
                        Name = item.Name,
                        ParentId = Convert.ToInt32(item.ParentId),
                        ParentIds = item.ParentIds,
                        ParentNames = item.ParentNames,
                        //IsProductKind = item.IsProductKind,
                        //IsList = item.IsList
                    });
                }
                */
                IEnumerable<ContractType> tree = treeContractTypes.AsEnumerable();

                //smartGridContractTypes.BuildTree(tree);

                // Находим максимальный уровень среди всех строк, которые являются узлами
                int maxLevel = smartGridContractTypes.GetDepth();

                for (int i = 1; i <= maxLevel; i++)
                {
                    var levelItem = new ToolStripMenuItem($"Уровень {i}");
                    int level = i; // Локальная копия для замыкания
                    levelItem.Click += (s, e) =>
                    {
                        smartGridContractTypes.BeginUpdate();
                        smartGridContractTypes.ExpandByLevel(level);
                        //if (toolStripButtonPath.Checked) toolStripButtonPath.Checked = false;
                        smartGridContractTypes.EndUpdate();
                    };
                    //                    toolStripButtonLevels.DropDownItems.Add(levelItem);
                }
                smartGridContractTypes.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loaderComtractTypes.HideLoader();
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshContractTypes();
        }

        private void ContractTypesForm_Load(object sender, EventArgs e)
        {
            RefreshContractTypes();
        }
    }


    // Временный класс - потом удалить
    class ContractType
    {
        public int Id;
        public int Parent;
        public int DocumentTypeId;
        public int KindId;
        public int ContractCurrencyTypeId;
        public string Name;
        public string Code;
        public bool isLeaf;
    }
}
