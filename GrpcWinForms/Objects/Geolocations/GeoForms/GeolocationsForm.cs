using C1.Win.FlexGrid;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Geolocation;
using GrpcWinForms.Models;
using GrpcWinForms.Objects.Geolocations.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Geolocations.GeoForms
{
    public partial class GeolocationsForm : Form
    {
        private BindingList<Geolocation> geo;
        private Loader loader = new Loader();


        public GeolocationsForm()
        {
            InitializeComponent();

            loader.Parent = smartGrid;
            loader.Size = smartGrid.Size;

        }

        private async void RefreshGeoTree()
        {
            try
            {
                loader.ShowLoader();

                TreeGeoRequest request = new TreeGeoRequest()
                {
                    Id = 0,
                    Name = textBoxGeoName.Text
                };

                TreeGeoResponse response = await GrpcClients.GrpcClients.Geolocation.GetTreeGeoAsync(request);
                geo = new BindingList<Geolocation>(response.Geolocations);
                List<GeoTree> geoTree = new List<GeoTree>();
                foreach (var item in response.Geolocations)
                    geoTree.Add(new GeoTree()
                    {
                        Id = Convert.ToInt32(item.Id),
                        Name = item.Name,
                        ParentId = Convert.ToInt32(item.ParentId),
                        Code2 = item.Code2,
                        JsonCode = item.JsonCodes,
                        Lock = item.Lock == 0 ? false : true,
                        PhoneCode = item.PhoneCode
                    });

                var g = geoTree.AsEnumerable();
                smartGrid.BeginUpdate();
                smartGrid.BuildTree(g);

                // Находим максимальный уровень среди всех строк, которые являются узлами
                int maxLevel = smartGrid.GetDepth();

                for (int i = 1; i <= maxLevel; i++)
                {
                    var levelItem = new ToolStripMenuItem($"Уровень {i}");
                    int level = i; // Локальная копия для замыкания
                    levelItem.Click += (s, e) =>
                    {
                        smartGrid.BeginUpdate();
                        smartGrid.ExpandByLevel(level);
                        smartGrid.EndUpdate();
                    };
                    toolStripSplitButtonLevels.DropDownItems.Add(levelItem);
                }

                smartGrid.EndUpdate();
                loader.HideLoader();

            }
            catch (Exception ex)
            {
                smartGrid.EndUpdate();
                loader.HideLoader();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void GeolocationsForm_Load(object sender, EventArgs e)
        {
            RefreshGeoTree();

        }

        private async void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshGeoTree();

        }

        private void smartGrid_AfterResizeColumn(object sender, C1.Win.FlexGrid.RowColEventArgs e)
        {
            smartGrid.Cols["Name"].StarWidth = "*";
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
}
