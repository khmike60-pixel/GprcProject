using GrpcCommonNet.Library.Common;
using GrpcWinForms.Objects.Locations.Models;
using GrpcWinForms.Objects.Locations.Presenters;
using SmartLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Locations.Views
{
    public partial class LocationsForm : Form, ILocations
    {
        private LocationsPresenter _presenter;

        public bool DialogMode { get; set; }
        public Location CurrentLocation 
        {
            get 
            {
                if (grid.Row < grid.Rows.Fixed) return null;
                TreeLocation treeItem = grid.Rows[grid.Row].Node.Key as TreeLocation;
                return treeItem.Location;
            }
            set
            { 
                if(grid.Row < grid.Rows.Fixed) return;
                grid.Rows[grid.Row].Node.Key = value;
                grid.Rows[grid.Row].Node.Data  =  value.Name;
                grid[grid.Row, grid.Tree.Column] = value.Name;
            }
        }

        public BindingList<Location> Locations { get; set; }

        public LocationType Type =>
            cbType.SelectedIndex == 0 ? LocationType.LocationCountry :
            cbType.SelectedIndex == 1 ? LocationType.LocationCity :
            LocationType.LocationPlace;

        public SmartGrid Grid { get => grid; set => grid = value; }

        public string TextString => txtName.Text;

        public LocationsForm()
        {
            InitializeComponent();
            _presenter = new LocationsPresenter(this);
        }

        private void LocationsForm_Load(object sender, EventArgs e)
        {
            _presenter.Refresh();
            Level();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _presenter.Refresh();
            Level();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (grid.Row < grid.Rows.Fixed) return;
            
            _presenter.New_Location();
        }

        private void btnDouble_Click(object sender, EventArgs e)
        {
            _presenter.Double_Location();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (CurrentLocation == null) return;

            _presenter.Edit_Location();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _presenter.Delete_Location();
        }

        private void btnLevels_Click(object sender, EventArgs e)
        {
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            _presenter.Path_Location(btnPath.Checked);
        }

        private void Level()
        {
            // Находим максимальный уровень среди всех строк, которые являются узлами
            int maxLevel = grid.GetDepth()+1;
            btnLevels.DropDownItems.Clear();

            for (int i = 0; i <= maxLevel; i++)
            {
                var levelItem = new ToolStripMenuItem($"Уровень {i}");
                int level = i; // Локальная копия для замыкания
                levelItem.Click += (s, e) =>
                {
                    grid.BeginUpdate();
                    grid.ExpandByLevel(level);
                    grid.EndUpdate();
                };
                btnLevels.DropDownItems.Add(levelItem);
            }
        }
    }
}
