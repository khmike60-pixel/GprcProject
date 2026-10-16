using GrpcCommonNet.Library.Application;
using GrpcCommonNet.Library.Common;
using GrpcWinForms.GrpcUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = GrpcCommonNet.Library.Common.Application;
using GrpcWinForms.Objects.Applications.Views.Interfaces;
using GrpcWinForms.Objects.Applications.Repositories;

namespace GrpcWinForms.Objects.Applications.Presenters
{
    public class ApplicationsPresenter
    {
        private readonly IApplicationsView _view;
        private readonly ApplicationsRepository _repository = new ApplicationsRepository();

        public ApplicationsPresenter(IApplicationsView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public async Task RefreshAsync()
        {
            _view.BeginUpdate();
            try
            { 
                List<Application> applications = await _repository.GetApplicationsAsync(
                    _view.NameFilter ?? string.Empty, 
                    _view.NameFilter ?? string.Empty, 
                    _view.NameFilter ?? string.Empty);

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
                
                if (application.Id == 0 )
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
                if (_view.SelectedRows == null || _view.SelectedRows.Count == 0)
                {
                    var dr = MessageBox.Show("Удалить текущую строку данных?", "Удаление", MessageBoxButtons.OKCancel);
                    if (dr != DialogResult.OK) return;

                    int id = _view.GetIdAtRow(_view.RowSel);
                    var request = new DeleteApplicationRequest { Id = id };
                    var response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Application.DeleteApplicationAsync(request).ResponseAsync);

                    int i = _view.RowSel - _view.RowsFixed;
                    if (response.Result.Status == Status.Ok)
                    {
                        _view.RemoveAt(i);
                    }
                    else
                    {
                        _view.ShowMessage("Ошибка при удалении: " + response.Result.Message, "Ошибка");
                    }
                }
                else
                {
                    var dr = MessageBox.Show($"Вы отметили {_view.SelectedRows.Count} строк.\nУдалить отмеченные строки?", "Удаление", MessageBoxButtons.OKCancel);
                    if (dr != DialogResult.OK) return;

                    var ids = new List<int>();
                    foreach (var idx in _view.SelectedRows) ids.Add(_view.GetIdAtRow(idx));

                    List<int> undeletedIds = await _repository.DeleteApplicationsAsync(ids);

                    var undeleted = undeletedIds.Select(i => Convert.ToInt32(i)).ToList();
                    var removed = ids.Except(undeleted).ToList();
                    _view.RemoveApplicationsByIds(removed);

                    if (undeleted.Count > 0)
                    {
                        _view.ShowMessage("Данные, которые не удалось удалить остались выделенными.", "Внимание");
                    }
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при удалении: " + ex.Message, "Ошибка");
            }
        }
    }
}