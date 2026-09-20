using GrpcWinForms.Objects.DocumentTypes.Views;
using GrpcWinForms.Models;
using GrpcWinForms.GrpcUtils;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.DocumentType;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GrpcWinForms.Objects.DocumentTypes.Models;

namespace GrpcWinForms.Objects.DocumentTypes.Presenters
{
    public class DocumentTypesPresenter
    {
        private readonly IDocumentTypesView _view;

        public DocumentTypesPresenter(IDocumentTypesView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public async Task RefreshAsync()
        {
            _view.BeginUpdate();
            try
            {
                var request = new DocumentTypeFilterRequest()
                {
                    Head = string.IsNullOrEmpty(_view.HeadCode) ? string.Empty : _view.HeadCode,
                    FieldMask = new FieldMask()
                };
                request.FieldMask.Paths.AddRange(new[] {
                    "id", "parent", "ids", "parents", "name", "code", "form", "currency_type", "data",
                    "country_currency_id", "view_master", "view_detail", "is_default", "approved", "kind_id", "is_contract"
                });

                ListDocumentTypeResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.DocumentType.GetBranchDocumentTypesAsync(request).ResponseAsync);

                var treeItems = new List<object>();
                foreach (var item in response.DocumentTypes)
                {
                    // Используем тот же DTO TreeDocumentType что и View ожидает (сериализуем в object чтобы избежать жесткой зависимости)
                    var tree = new TreeDocumentType()
                    {
                        Id = Convert.ToInt32(item.Id),
                        Name = item.Name,
                        Code = item.Code,
                        Form = item.Form,
                        ParentId = item.Code == _view.HeadCode ? 0 : item.Parent.Id,
                        Parent = item.Parent,
                        ParentIds = item.Ids,
                        ParentNames = item.Parents,
                        KindId = Convert.ToInt32(item.KindId),
                        IsDefault = item.IsDefault,
                        IsContract = item.IsContract,
                        Data = item.Data,
                        ViewMaster = item.ViewMaster,
                        ViewDetail = item.ViewDetail
                    };
                    treeItems.Add(tree);
                }

                _view.BuildTree(treeItems);

                // сконфигурируем уровни разворачивания
                int maxLevel = _view.GetDepth();
                _view.ConfigureLevels(maxLevel);
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
            // Получаем текущий выбранный узел, чтобы определить родителя
            var selected = _view.GetSelectedTreeItem() as TreeDocumentType;
            var form = new GrpcWinForms.Objects.DocumentTypes.Forms.DocumentTypeForm()
            {
                EditMode = true,
                DocumentType = new DocumentType()
                {
                    Name = "Новый тип документа",
                    Parent = selected == null ? null : new GrpcCommonNet.Library.Common.Tree { Id = selected.Id, Name = selected.Name }
                }
            };

            if (_view.ShowDocumentTypeDialog(form) != DialogResult.OK) return;

            try
            {
                var request = new CreateDocumentTypeRequest() { DocumentType = form.DocumentType };
                var response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.DocumentType.CreateDocumentTypeAsync(request).ResponseAsync);

                if (response.Result.Status != Status.Ok || response.DocumentType == null)
                {
                    _view.ShowMessage("Добавить данные не удалось.", "Ошибка");
                    return;
                }

                _view.InsertChildNode(response.DocumentType);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при создании: " + ex.Message, "Ошибка");
            }
        }

        public async Task EditAsync()
        {
            var selectedTree = _view.GetSelectedTreeItem() as TreeDocumentType;
            if (selectedTree == null) return;

            try
            {
                var requestById = new DocumentTypeRequest() { Id = selectedTree.Id };
                var responseById = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.DocumentType.GetDocumentTypeAsync(requestById).ResponseAsync);

                using var form = new GrpcWinForms.Objects.DocumentTypes.Forms.DocumentTypeForm()
                {
                    EditMode = true,
                    DocumentType = responseById.DocumentType
                };

                if (_view.ShowDocumentTypeDialog(form) != DialogResult.OK) return;

                var updateRequest = new UpdateDocumentTypeRequest() { DocumentType = form.DocumentType };
                var updateResponse = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.DocumentType.UpdateDocumentTypeAsync(updateRequest).ResponseAsync);

                if (updateResponse.Result.Status != Status.Ok || updateResponse.DocumentType == null)
                {
                    _view.ShowMessage("Изменить данные не удалось.", "Ошибка");
                    return;
                }

                _view.ReplaceCurrentNode(updateResponse.DocumentType);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при обновлении: " + ex.Message, "Ошибка");
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

                    // ожидаем, что View знает как взять Id текущей строки при RemoveCurrentNode
                    // Presenter сначала вызывает удаление по GRPC, затем просит View удалить узел
                    var current = _view.GetSelectedTreeItem() as TreeDocumentType;
                    if (current == null) return;

                    var request = new DeleteDocumentTypeRequest { Id = current.Id };
                    var response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.DocumentType.DeleteDocumentTypeAsync(request).ResponseAsync);

                    if (response.Result.Status == Status.Ok)
                    {
                        _view.RemoveCurrentNode();
                    }
                    else
                    {
                        _view.ShowMessage("Ошибка при удалении: \nВероятно есть зависимые данные.\n" + response.Result.Message, "Ошибка");
                    }
                }
                else
                {
                    var dr = MessageBox.Show($"Вы отметили {_view.SelectedRows.Count} строк.\nУдалить отмеченные строки?", "Удаление", MessageBoxButtons.OKCancel);
                    if (dr != DialogResult.OK) return;

                    var ids = new List<int>();
                    foreach (var idx in _view.SelectedRows)
                    {
                        var treeItem = GetTreeItemByRowIndex(idx) as TreeDocumentType;
                        if (treeItem != null) ids.Add(treeItem.Id);
                    }

                    var request = new DeleteIdsDocumentTypeRequest();
                    request.Ids.AddRange(ids);

                    var response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.DocumentType.DeleteIdsDocumentTypeAsync(request).ResponseAsync);

                    if (response.Result.Status != Status.Ok)
                    {
                        _view.ShowMessage("Ошибка при удалении: " + response.Result.Message, "Ошибка");
                        // Выход; можно обновить полностью список указывая на необходимость Refresh
                        return;
                    }

                    // Удаляем узлы, которые успешно удалены
                    var undeleted = response.UndeletedIds;
                    var removed = ids.Except(undeleted).ToList();
                    _view.RemoveNodesByIds(removed);

                    if (undeleted.Count > 0)
                    {
                        _view.ShowMessage("Данные, которые не удалось удалить.\nНеудалённые строки остались выделенными.", "Внимание");
                    }
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при удалении: " + ex.Message, "Ошибка");
            }
        }

        // Перемещение узла (вызывается, когда View сообщает о Before/After move)
        public async Task<bool> MoveNodeAsync(int currentId, int newParentId)
        {
            try
            {
                var request = new MoveDocumentTypeRequest()
                {
                    Id = currentId,
                    NewParentId = newParentId
                };

                var response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.DocumentType.MoveDocumentTypeAsync(request).ResponseAsync);

                if (response.Result.Status != Status.Ok)
                {
                    _view.ShowMessage("Ошибка при перемещении: " + response.Result.Message, "Ошибка");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при перемещении: " + ex.Message, "Ошибка");
                return false;
            }
        }

        public void OnItemDoubleClicked()
        {
            if (!_view.DialogMode) return;

            var selected = _view.GetSelectedTreeItem() as DocumentType;
            if (selected == null)
            {
                // Возможно selected представлен как TreeDocumentType (минимальные поля)
                var tree = _view.GetSelectedTreeItem() as TreeDocumentType;
                if (tree == null) return;
                if (string.IsNullOrEmpty(tree.Form))
                {
                    _view.ShowMessage("Данный тип выбрать нельзя.", "Предупреждение");
                    return;
                }

                var dt = new DocumentType()
                {
                    Id = tree.Id,
                    Name = tree.Name,
                    Form = tree.Form
                };
                _view.CloseWithResult(dt);
                return;
            }

            _view.CloseWithResult(selected);
        }

        private object GetTreeItemByRowIndex(int rowIndex)
        {
            // Если View не предоставляет прямого доступа, Presenter пытается получить через GetSelectedTreeItem — но здесь View-метод ожидает номер строки
            // Для простоты Presenter оставляет эту мелкую работу View: View может игнорировать некорректные индексы
            return null;
        }
    }
}