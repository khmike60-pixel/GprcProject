using C1.Win.FlexGrid;
using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Product;
using GrpcWinForms.Models;
using SmartGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Products.ProductsForm
{
    public partial class ProductsForm : Form
    {
        private Loader loaderCatalog = new Loader();
        private BindingList<CatalogLine> catalogLines;
        private int maxLevel = 0;


        public ProductsForm()
        {
            InitializeComponent();
            loaderCatalog.Parent = smartGrid;
            loaderCatalog.Size = smartGrid.Size;


        }

        public async void RefreshProducts()
        {
            loaderCatalog.ShowLoader();
            try
            {
                smartGrid.BeginUpdate();

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

                // Добавляет root - строку
                TreeCatalog root = new TreeCatalog() { Id = -1, Name = "Все" };
                treeCatalogs.Add(root);

                foreach (var item in response.Catalog)
                {
                    treeCatalogs.Add(new TreeCatalog()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        ParentId = item.ParentId == 0 ? -1 : Convert.ToInt32(item.ParentId),
                        ParentIds = item.ParentIds,
                        ParentNames = item.ParentNames,
                        //IsProductKind = item.IsProductKind,
                        //IsList = item.IsList
                    });
                }

                var catalog = treeCatalogs.AsEnumerable();

                smartGrid.BuildTree(catalog);

                // Находим максимальный уровень среди всех строк, которые являются узлами
                toolStripButtonLevels.DropDownItems.Clear();
                int maxLevel = smartGrid.GetDepth();

                for (int i = 1; i <= maxLevel; i++)
                {
                    var levelItem = new ToolStripMenuItem($"Уровень {i}");
                    int level = i; // Локальная копия для замыкания
                    levelItem.Click += (s, e) =>
                    {
                        smartGrid.BeginUpdate();
                        smartGrid.ExpandByLevel(level);
                        //if (toolStripButtonPath.Checked) toolStripButtonPath.Checked = false;
                        smartGrid.EndUpdate();
                    };
                    toolStripButtonLevels.DropDownItems.Add(levelItem);
                }
                toolStripButtonLevels.Click += (s, e) =>
                {
                    smartGrid.BeginUpdate();
                    smartGrid.ExpandByLevel(1);
                    smartGrid.EndUpdate();
                };

                //smartGrid.Footers.Descriptions[0].Aggregates[0].Expression = "Count([Id])";
                smartGrid.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loaderCatalog.HideLoader();
        }

        private async void ProductsForm_Load(object sender, EventArgs e)
        {
            RefreshProducts();
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshProducts();
        }

        private void toolStripButtonPath_Click(object sender, EventArgs e)
        {
            if (!toolStripButtonPath.Checked)
            {
                smartGrid.BeginUpdate();
                foreach (var row in smartGrid.Rows.Cast<Row>())
                    if (row.IsNode) row.Visible = true;
                smartGrid.EndUpdate();
            }
            else
            {
                IsolateCurrentBranch(smartGrid);
            }

        }

        private void IsolateCurrentBranch(SmartGrid.SmartGrid grid)
        {
            if (grid.Row < grid.Rows.Fixed) return;

            Node selectedNode = grid.Rows[grid.Row].Node;
            if (selectedNode == null) return;

            grid.BeginUpdate();
            try
            {
                // Используем HashSet для индексов строк (самый быстрый способ в .NET 8)
                var visibleRowIndices = new HashSet<int>();

                // 1. Добавляем индекс текущей строки
                visibleRowIndices.Add(selectedNode.Row.Index);

                // 2. Добавляем индексы всех предков (вверх)
                Node parent = selectedNode.Parent;
                while (parent != null)
                {
                    visibleRowIndices.Add(parent.Row.Index);
                    parent = parent.Parent;
                }

                // 3. Добавляем индексы всех потомков (вниз)
                AddChildrenRowIndices(selectedNode, visibleRowIndices);

                // 4. Проходим по всем строкам и меняем видимость
                for (int i = grid.Rows.Fixed; i < grid.Rows.Count; i++)
                {
                    // Теперь сравниваем целые числа (индексы), это сработает на 100%
                    grid.Rows[i].Visible = visibleRowIndices.Contains(i);
                }
            }
            finally
            {
                grid.EndUpdate();
            }
        }

        private void AddChildrenRowIndices(Node node, HashSet<int> indices)
        {
            foreach (Node child in node.Nodes)
            {
                indices.Add(child.Row.Index);
                if (child.Nodes.Length > 0)
                {
                    AddChildrenRowIndices(child, indices);
                }
            }
        }

    }

    public class TreeCatalog : ITreeData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public string ParentIds { get; set; }
        public string ParentNames { get; set; }
        public bool IsProductKind { get; set; }
        public bool IsList { get; set; }
    }
}
