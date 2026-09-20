using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Department;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Objects.Departaments.Forms;
using GrpcWinForms.Objects.Departaments.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Departaments.Presenters
{
    public class DepartamentsPresenter
    {
        private readonly IDepartamentsView _view;
        private BindingList<Department> _departments;

        public DepartamentsPresenter(IDepartamentsView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _view.LoadView += async (s, e) => await RefreshAsync();
        }

        public async Task RefreshAsync()
        {
            try
            {
                var request = new ListDepartmentRequest()
                {
                    DepartmentShort = _view.ShortFilter ?? string.Empty,
                    Symbol = "",
                    FieldMask = new Google.Protobuf.WellKnownTypes.FieldMask() { Paths = { "id", "name", "short", "symbol" } }
                };

                var response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Department.GetListDepartmentAsync(request).ResponseAsync);

                _departments = new BindingList<Department>(response.Departments);
                _view.Departments = _departments;
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при загрузке списка отделов: " + ex.Message);
            }
        }

        public async Task NewAsync()
        {
            try
            {
                using (var form = new DepartmentForm())
                {
                    if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

                    var request = new CreateDepartmentRequest { Department = form.Department };
                    var response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Department.CreateDepartmentAsync(request).ResponseAsync);

                    if (response.Result.Status != Status.Ok || response.Department == null)
                    {
                        _view.ShowMessage("Добавить данные не удалось.");
                        return;
                    }

                    int insertIndex = Math.Max(0, _view.RowSel - (/* rows.fixed */  _view.RowSel)); // keep compatibility
                    // prefer insert near current selection as before:
                    insertIndex = _view.RowSel - 1; // original used smartGrid1.RowSel - Rows.Fixed
                    if (insertIndex < 0) insertIndex = 0;

                    _view.InsertDepartmentAt(insertIndex, response.Department);
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при добавлении: " + ex.Message);
            }
        }

        public async Task DoubleAsync()
        {
            try
            {
                var department = _view.SelectedItem;
                if (department == null) return;

                department = new Department
                {
                    Name = department.Name + " 1",
                    Short = department.Short,
                    Symbol = department.Symbol,
                    Id = 0 // чтобы сервер создал новый
                };

                var request = new CreateDepartmentRequest { Department = department };
                var response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Department.CreateDepartmentAsync(request).ResponseAsync);

                if (response.Result.Status != Status.Ok || response.Department == null)
                {
                    _view.ShowMessage("Добавить данные не удалось.");
                    return;
                }

                int insertIndex = _view.RowSel - 1;
                if (insertIndex < 0) insertIndex = 0;
                _view.InsertDepartmentAt(insertIndex, response.Department);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при дублировании: " + ex.Message);
            }
        }

        public async Task EditAsync()
        {
            try
            {
                var current = _view.SelectedItem;
                if (current == null) return;

                using (var form = new DepartmentForm())
                {
                    form.Department = current;
                    if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

                    var request = new UpdateDepartmentRequest { Department = form.Department };
                    var response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Department.UpdateDepartmentAsync(request).ResponseAsync);

                    if (response.Result.Status != Status.Ok || response.Department == null)
                    {
                        _view.ShowMessage("Изменить данные не удалось.");
                        return;
                    }

                    int index = _view.RowSel - 1;
                    if (index < 0) index = 0;
                    _view.ReplaceDepartmentAt(index, response.Department);
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при изменении: " + ex.Message);
            }
        }

        public async Task DeleteAsync()
        {
            try
            {
                if (_view.SelectedRows == null || _view.SelectedRows.Count == 0)
                {
                    // Удаление одной записи
                    var sel = _view.SelectedItem;
                    if (sel == null) return;

                    var request = new DeleteDepartmentRequest { Id = sel.Id };
                    var response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Department.DeleteDepartmentAsync(request).ResponseAsync);

                    int index = _view.RowSel - 1;
                    if (response.Result.Status == Status.Ok)
                    {
                        _view.BeginUpdate();
                        _view.RemoveDepartmentAt(index);
                        _view.EndUpdate();
                    }
                    else
                    {
                        _view.ShowMessage("Ошибка при удалении: " + response.Result.Message);
                    }
                }
                else
                {
                    // Удаление множества
                    var ids = _view.SelectedRows.Select(i => i).ToList();
                    var idList = new List<int>();
                    foreach (var r in ids)
                    {
                        // предполагаем, что индекс строки соответствует индексу в списке (как раньше)
                        // если нет — логика может быть скорректирована
                        if (r - 1 >= 0 && r - 1 < _departments.Count)
                            idList.Add(_departments[r - 1].Id);
                    }

                    var request = new DeleteIdsDepartmentRequest();
                    request.Ids.AddRange(idList);

                    var response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Department.DeleteIdsDepartmentAsync(request).ResponseAsync);

                    var undelIds = response.UndeletedIds.Select(i => Convert.ToInt32(i)).ToList();

                    _view.BeginUpdate();
                    // Восстанавливаем список, удаляем те, что удалось
                    var remaining = _departments.Where(d => !response.UndeletedIds.Contains(d.Id)).ToList();
                    _view.Departments = new BindingList<Department>(remaining);
                    _view.EndUpdate();

                    if (response.Result.Status != Status.Ok)
                        _view.ShowMessage("Ошибка при удалении: " + response.Result.Message);
                    else if (response.UndeletedIds.Count > 0)
                        _view.ShowMessage("Данные, которые не удалось удалить остались выделенными.");
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при удалении: " + ex.Message);
            }
        }

        public void OnGridDoubleClick()
        {
            if (!_view.DialogMode)
            {
                // открыть редактирование
                _ = EditAsync();
                return;
            }

            var selected = _view.SelectedItem;
            if (selected == null) return;

            _view.SelectedItem = selected;
            _view.CloseWithOk();
        }
    }
}