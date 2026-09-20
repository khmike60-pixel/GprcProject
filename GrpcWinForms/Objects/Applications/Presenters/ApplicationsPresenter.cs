using GrpcCommonNet.Library.Application;
using GrpcCommonNet.Library.Common;
using GrpcWinForms.Objects.Applications.Views;
using GrpcWinForms.GrpcUtils;
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

        public ApplicationsPresenter(IApplicationsView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public async Task RefreshAsync()
        {
            _view.BeginUpdate();
            try
            {
                var request = new ApplicationFilterRequest()
                {
                    Name = _view.NameFilter ?? string.Empty,
                    Product = _view.NameFilter ?? string.Empty,
                    Db = _view.NameFilter ?? string.Empty
                };

                var response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Application.GetListApplicationAsync(request).ResponseAsync);

                _view.Applications = new BindingList<Application>(response.Applications);
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

                var request = new CreateApplicationRequest
                {
                    Name = form.Application.Name,
                    Db = form.Application.Db,
                    Product = form.Application.Product
                };

                var response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Application.CreateApplicationAsync(request).ResponseAsync);

                if (response.Result.Status != Status.Ok || response.Application == null)
                {
                    _view.ShowMessage("Добавить данные не удалось.", "Ошибка");
                    return;
                }

                int insertIndex = Math.Max(0, _view.RowSel - _view.RowsFixed);
                _view.InsertApplicationAt(insertIndex, response.Application);
                _view.SetRow(_view.RowSel);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при создании: " + ex.Message, "Ошибка");
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

                var request = new UpdateApplicationRequest
                {
                    Id = form.Application.Id,
                    Name = form.Application.Name,
                    Db = form.Application.Db,
                    Product = form.Application.Product
                };

                var response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Application.UpdateApplicationAsync(request).ResponseAsync);

                if (response.Application == null)
                {
                    _view.ShowMessage("Изменить данные не удалось.", "Ошибка");
                    return;
                }

                int idx = _view.RowSel - _view.RowsFixed;
                _view.ReplaceApplicationAt(idx, response.Application);
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

                    var request = new DeleteIdsApplicationRequest();
                    request.Ids.AddRange(ids);

                    var response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Application.DeleteIdsApplicationAsync(request).ResponseAsync);

                    if (response.Result.Status != Status.Ok)
                    {
                        _view.ShowMessage("Ошибка при удалении: " + response.Result.Message, "Ошибка");
                        return;
                    }

                    var undeleted = response.UndeletedIds.Select(i => Convert.ToInt32(i)).ToList();
                    var removed = ids.Except(undeleted).ToList();
                    _view.RemoveApplicationsByIds(removed);

                    if (undeleted.Count > 0)
                        _view.ShowMessage("Данные, которые не удалось удалить остались выделенными.", "Внимание");
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при удалении: " + ex.Message, "Ошибка");
            }
        }
    }
}