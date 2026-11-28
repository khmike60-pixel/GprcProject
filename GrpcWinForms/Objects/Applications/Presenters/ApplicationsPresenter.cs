using GrpcWinForms.Objects.Applications.Repositories;
using GrpcWinForms.Objects.Applications.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = GrpcCommonNet.Library.Common.Application;

namespace GrpcWinForms.Objects.Applications.Presenters
{
    public class ApplicationsPresenter
    {
        private readonly IApplicationsView _view;
        private readonly IApplicationsRepository _repository;

        public ApplicationsPresenter(IApplicationsView view)
            : this(view, new ApplicationsRepository())
        {
        }

        public ApplicationsPresenter(IApplicationsView view, IApplicationsRepository repository)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task RefreshAsync()
        {
            _view.BeginUpdate();
            try
            {
                // TODO: одна и та же строка передаётся как фильтр по имени, базе и продукту.
                // Уточнить, как сервер объединяет условия (И / ИЛИ).
                string filter = _view.NameFilter ?? string.Empty;
                List<Application> applications = await _repository.GetApplicationsAsync(filter, filter, filter);

                _view.Applications = new BindingList<Application>(applications);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при получении данных: " + ex.Message, "Ошибка");
            }
            finally
            {
                _view.EndUpdate();
            }
        }

        public async Task NewAsync()
        {
            try
            {
                using var form = new Forms.ApplicationForm() { IsTypeInsert = true };
                if (_view.ShowApplicationDialog(form) != DialogResult.OK) return;

                Application application = await _repository.CreateApplicationAsync(form.Application);

                if (application.Id == 0)
                {
                    _view.ShowMessage("Не удалось создать запись.", "Ошибка");
                    return;
                }
                int insertIndex = Math.Max(0, _view.RowSel - _view.RowsFixed);
                _view.InsertApplicationAt(insertIndex, application);
                _view.SetRow(_view.RowSel);
            }
            catch (Exception ex)
            {
                _view.ShowMessage(ex.Message, "Ошибка");
            }
        }

        public async Task EditAsync()
        {
            try
            {
                var app = _view.GetApplicationAtRow(_view.RowSel);
                if (app == null) return;

                using var form = new Forms.ApplicationForm() { IsTypeInsert = false, Application = app };
                if (_view.ShowApplicationDialog(form) != DialogResult.OK) return;

                Application application = await _repository.UpdateApplicationAsync(form.Application);

                if (application == null)
                {
                    _view.ShowMessage("Изменить данные не удалось.", "Ошибка");
                    return;
                }

                int idx = _view.RowSel - _view.RowsFixed;
                _view.ReplaceApplicationAt(idx, application);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при изменении: " + ex.Message, "Ошибка");
            }
        }

        public async Task DeleteAsync()
        {
            try
            {
                IList<int> selectedRows = _view.SelectedRows;

                if (selectedRows == null || selectedRows.Count == 0)
                    await DeleteCurrentRowAsync();
                else
                    await DeleteSelectedRowsAsync(selectedRows);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при удалении: " + ex.Message, "Ошибка");
            }
        }

        private async Task DeleteCurrentRowAsync()
        {
            if (!_view.Confirm("Удалить текущую строку данных?", "Удаление")) return;

            int id = _view.GetIdAtRow(_view.RowSel);
            await _repository.DeleteApplicationAsync(id);

            _view.RemoveAt(_view.RowSel - _view.RowsFixed);
        }

        private async Task DeleteSelectedRowsAsync(IList<int> selectedRows)
        {
            if (!_view.Confirm($"Вы отметили {selectedRows.Count} строк.\nУдалить отмеченные строки?", "Удаление")) return;

            List<int> ids = selectedRows.Select(row => _view.GetIdAtRow(row)).ToList();
            List<int> undeletedIds = await _repository.DeleteApplicationsAsync(ids);

            List<int> removedIds = ids.Except(undeletedIds).ToList();
            _view.RemoveApplicationsByIds(removedIds);

            if (undeletedIds.Count > 0)
            {
                _view.ShowMessage("Данные, которые не удалось удалить остались выделенными.", "Внимание");
            }
        }
    }
}
