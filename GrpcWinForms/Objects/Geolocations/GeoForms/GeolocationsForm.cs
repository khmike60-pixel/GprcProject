using C1.Win.FlexGrid;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Geolocation;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Models;
using GrpcWinForms.Objects.Currencies.Presenters;
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
        #region Свойства формы
        private BindingList<Geolocation> geo;
        private Loader loader = new Loader();
        private Geolocation selectedItem = null;

        public Geolocation SelectedItem { get { return selectedItem; } }
        public bool DialogMode { get; set; }
        public GeoType GeoType { get; set; } = GeoType.All;

        #endregion


        #region Конструктор, основной Refresh и метод Load
        public GeolocationsForm()
        {
            InitializeComponent();

            loader.Parent = gridGeo;
            loader.Size = gridGeo.Size;

            gridGeo.AllowNodeMove = true;
        }

        private async void RefreshGeoTree()
        {
            try
            {
                loader.ShowLoader();

                TreeGeoRequest request = new TreeGeoRequest()
                {
                    Id = 0,
                    Name = textBoxGeoName.Text,
                    GeoType = GeoType
                };

                TreeGeoResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Geolocation.GetTreeGeoAsync(request).ResponseAsync);
                geo = new BindingList<Geolocation>(response.Geolocations);
                List<GeoTree> geoTree = new List<GeoTree>();

                foreach (var item in response.Geolocations)
                    geoTree.Add(new GeoTree()
                    {
                        Id = Convert.ToInt32(item.Id),
                        Name = item.Name,
                        ParentId = item.ParentId,
                        Parent = item.Parent,
                        Code2 = item.Code2,
                        //JsonCode = item.JsonCodes,
                        Lock = item.Lock == 0 ? false : true,
                        PhoneCode = item.PhoneCode
                    });

                var g = geoTree.AsEnumerable();
                gridGeo.BeginUpdate();
                gridGeo.BuildTree(g);

                // Находим максимальный уровень среди всех строк, которые являются узлами
                int maxLevel = gridGeo.GetDepth();

                for (int i = 1; i <= maxLevel; i++)
                {
                    var levelItem = new ToolStripMenuItem($"Уровень {i}");
                    int level = i; // Локальная копия для замыкания
                    levelItem.Click += (s, e) =>
                    {
                        gridGeo.BeginUpdate();
                        gridGeo.ExpandByLevel(level);
                        gridGeo.EndUpdate();
                    };
                    toolStripSplitButtonLevels.DropDownItems.Clear();
                    toolStripSplitButtonLevels.DropDownItems.Add(levelItem);
                }

                toolStripSplitButtonLevels.Click += (s, e) =>
                {
                    gridGeo.BeginUpdate();
                    gridGeo.ExpandByLevel(1);
                    gridGeo.EndUpdate();
                };

                gridGeo.EndUpdate();
                loader.HideLoader();

            }
            catch (Exception ex)
            {
                gridGeo.EndUpdate();
                loader.HideLoader();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void GeolocationsForm_Load(object sender, EventArgs e)
        {
            RefreshGeoTree();

        }

        #endregion


        #region События кнопок

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            int row = gridGeo.Row;
            if (row < gridGeo.Rows.Fixed) return;
            Node node = gridGeo.Rows[row].Node;
            GeoTree geoItem = node.Key as GeoTree;
            Geolocation newGeo = null;

            using (GeolocationForm geoForm = new GeolocationForm())
            {
                geoForm.ModeEdit = Views.ModeEdit.Add;
                geoForm.Geolocation = new Geolocation()
                {
                    Parent = new Geolocation()
                    {
                        Id =  geoItem.Id,
                        Name = geoItem.Name,
                        IsCountry = geoItem.IsCountry
                        
                    }
                };

                if (geoForm.ShowDialog() == DialogResult.OK)
                {
                    newGeo = geoForm.Geolocation;
                }
            }
            if (newGeo == null) return;
            gridGeo.BeginUpdate();
            gridGeo.Rows[row].Node.AddNode(NodeTypeEnum.FirstChild, newGeo.Name, new GeoTree()
            {
                Id = newGeo.Id,
                Name = newGeo.Name,
                ParentId = newGeo.ParentId,
                IsCountry = newGeo.IsCountry,
                Code2 = newGeo.Code2,
                PhoneCode = newGeo.PhoneCode,
                Lock = newGeo.Lock == 0 ? false : true
            }, null);
            gridGeo.Row += 1;
            gridGeo.EndUpdate();
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            int row = gridGeo.Row;
            if (row < gridGeo.Rows.Fixed) return;
            Node node = gridGeo.Rows[row].Node;
            GeoTree geoItem = node.Key as GeoTree;
            Geolocation newGeo = null;

            using (GeolocationForm geoForm = new GeolocationForm())
            {
                geoForm.ModeEdit = Views.ModeEdit.Edit;
                geoForm.Geolocation = new Geolocation()
                {
                    Id = geoItem.Id,
                    Name = geoItem.Name,
                    NameLat = geoItem.NameLat,
                    ParentId = geoItem.ParentId,
                    Parent = geoItem.Parent,
                    IsCountry = geoItem.IsCountry,
                    Code2 = geoItem.Code2,
                    PhoneCode = geoItem.PhoneCode,
                    Lock = geoItem.Lock ? 1 : 0
                };
                if (geoForm.Geolocation.IsCountry == 1)
                {
                    geoForm.Geolocation.CountryJson = new CountryJson();
                    geoForm.Geolocation.CountryJson.Code2 = geoItem.JsonCode2;
                    geoForm.Geolocation.CountryJson.Code3 = geoItem.JsonCode3;
                    geoForm.Geolocation.CountryJson.CodeDigit = geoItem.JsonDigit;
                }
                else
                {
                    geoForm.Geolocation.RegionJson = new RegionJson();
                    geoForm.Geolocation.RegionJson.Code2 = geoItem.JsonCode2;
                    geoForm.Geolocation.RegionJson.SOATO = geoItem.JsonSoato;
                }

                if (geoForm.ShowDialog() == DialogResult.OK)
                {
                    newGeo = geoForm.Geolocation;
                }
            }
            if (newGeo == null) return;
            gridGeo[row, "Name"] = newGeo.Name;
            gridGeo[row, "Code2"] = newGeo.Code2;

        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonPath_Click(object sender, EventArgs e)
        {
            if (!toolStripButtonPath.Checked)
            {
                gridGeo.BeginUpdate();
                foreach (var row in gridGeo.Rows.Cast<Row>())
                    if (row.IsNode) row.Visible = true;
                gridGeo.EndUpdate();
            }
            else
            {
                IsolateCurrentBranch(gridGeo);
            }

        }


        private void IsolateCurrentBranch(SmartLib.SmartGrid grid)
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

        private async void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshGeoTree();

        }


        #endregion


        #region События грида

        private void smartGrid_AfterResizeColumn(object sender, C1.Win.FlexGrid.RowColEventArgs e)
        {
            gridGeo.Cols["Name"].StarWidth = "*";
        }

        private void smartGrid1_DoubleClick(object sender, EventArgs e)
        {
            int row = gridGeo.Row;
            if (row < gridGeo.Rows.Fixed) return;
            if (DialogMode)
            {
                selectedItem = gridGeo.Rows[gridGeo.Row].DataSource as Geolocation;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void gridGeo_Move(object sender, EventArgs e)
        {

        }

        #endregion

    }

}
