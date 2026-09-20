using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Unit;
using GrpcWinForms.Forms;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Models;
using GrpcWinForms.Objects.Units.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Units.Presenters
{
    public class UnitsPresenter
    {
        private readonly IUnitsView _view;

        public UnitsPresenter(IUnitsView view)
        {
            _view = view;
        }

        public async Task<bool> RefreshUnitAsync()
        {
            try
            {
                ListUnitRequest request = new ListUnitRequest()
                {
                    Short = _view.FilterName,
                    IsArchive = _view.ShowAll ? true : false
                };
                ListUnitResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Unit.GetListUnitAsync(request).ResponseAsync);
                var list = new BindingList<Unit>(response.Units);
                _view.SetUnitsSource(list);
                return true;
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка получения данных: " + ex.Message);
                return false;
            }
        }

        public async Task<UnitResponse> CreateUnitAsync(Unit unit, int insertIndex)
        {
            try
            {
                CreateUnitRequest request = new CreateUnitRequest() { Unit = unit };
                UnitResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Unit.CreateUnitAsync(request).ResponseAsync);

                if (response.Result.Status == Status.Ok && response.Unit != null)
                {
                    _view.InsertAt(insertIndex, response.Unit);
                }
                else
                {
                    _view.ShowMessage("Добавить данные не удалось.");
                }

                return response;
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при добавлении: " + ex.Message);
                return null;
            }
        }

        public async Task<UnitResponse> UpdateUnitAsync(Unit unit, int index)
        {
            try
            {
                UpdateUnitRequest request = new UpdateUnitRequest() { Unit = unit };
                UnitResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Unit.UpdateUnitAsync(request).ResponseAsync);

                if (response.Result.Status == Status.Ok && response.Unit != null)
                {
                    _view.UpdateAt(index, response.Unit);
                }
                else
                {
                    _view.ShowMessage("Обновить данные не удалось.");
                }

                return response;
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при обновлении: " + ex.Message);
                return null;
            }
        }

        public async Task<DeleteUnitResponse> DeleteUnitAsync(int id, int removeAtIndex)
        {
            try
            {
                DeleteUnitRequest request = new DeleteUnitRequest() { Id = id };
                DeleteUnitResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Unit.DeleteUnitAsync(request).ResponseAsync);

                if (response.Result.Status == Status.Ok)
                {
                    _view.RemoveAt(removeAtIndex);
                }
                else
                {
                    _view.ShowMessage("Удалить данные не удалось.");
                }

                return response;
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при удалении: " + ex.Message);
                return null;
            }
        }

        public async Task<UndeleteIdsUnitResponse> DeleteIdsUnitAsync(List<int> ids)
        {
            try
            {
                DeleteIdsUnitRequest request = new DeleteIdsUnitRequest();
                request.Ids.AddRange(ids);

                var response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Unit.DeleteIdsUnitAsync(request).ResponseAsync);

                return response;
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при удалении: " + ex.Message);
                return null;
            }
        }
    }
}