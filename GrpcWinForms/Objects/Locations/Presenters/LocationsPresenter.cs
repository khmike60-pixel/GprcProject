using C1.Win.FlexGrid;
using GrpcCommonNet.Library.Common;
using GrpcWinForms.Models;
using GrpcWinForms.Objects.Locations.Models;
using GrpcWinForms.Objects.Locations.Repositories;
using GrpcWinForms.Objects.Locations.Views;
using SmartLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILocations = GrpcWinForms.Objects.Locations.Views.ILocations;

namespace GrpcWinForms.Objects.Locations.Presenters
{
    public class LocationsPresenter
    {
        private readonly ILocations _view;
        
        public LocationsPresenter(ILocations view) 
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public async void Refresh()
        {
            try
            {
                Utils.SetBusy(true,_view.Grid);
                
                _view.Grid.BeginInit();

                List<Location> locations = new List<Location>();
                locations = await LocationsRepository.RefreshLocation(_view.Type, _view.TextString);
                List<TreeLocation> treeLocations = new List<TreeLocation>();
                foreach (Location location in locations)
                {
                    treeLocations.Add(new TreeLocation()
                    {
                        Id = location.Id,
                        ParentId = location.ParentId,
                        Name = location.Name,
                        Location = location
                    });
                }
                _view.Grid.BuildTree(treeLocations);

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Join(Environment.NewLine,
                    ""),
                    "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _view.Grid.EndInit();
                Utils.SetBusy(false,_view.Grid);
            }

        }

        public void New_Location()
        {

        }

        public async void Edit_Location()
        {
            if(_view.Grid.Row < _view.Grid.Rows.Fixed) return;
            // Меняем изображение
            LocationForm form = new() { CurrentLocation = _view.CurrentLocation };
            if (form.ShowDialog() == DialogResult.OK)
            {
                _view.CurrentLocation = await LocationsRepository.UpdateLocation(form.CurrentLocation);

                // Меняем коллекцию
                _view.Locations[_view.Grid.Row - _view.Grid.Rows.Fixed] = form.CurrentLocation;
            }
        }

        public void Delete_Location()
        {
        }

        public void Levels_Location()
        {
        }

        public void Path_Location(bool checked_btn)
        {
            if (!checked_btn)
            {
                _view.Grid.BeginUpdate();
                foreach (var row in _view.Grid.Rows.Cast<Row>())
                    if (row.IsNode) row.Visible = true;
                _view.Grid.EndUpdate();
            }
            else
            {
                IsolateCurrentBranch(_view.Grid);
            }

        }

        public void Double_Location()
        {

        }



        #region Внутренние методы  выделения ветки дерева
        private void IsolateCurrentBranch(SmartGrid grid)
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

        #endregion
    }
}
