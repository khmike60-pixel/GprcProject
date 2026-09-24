    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.SalePurchaseType;
using GrpcCommonNet.Library.Common;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.GrpcClients;
using GrpcWinForms.Objects.SalePurchaseTypes.Views;
using GrpcWinForms.Objects.SalePurchaseTypes.Models;

namespace GrpcWinForms.Objects.SalePurchaseTypes.Presenters
{
    public class SalePurchaseRatesPresenter
    {
        private readonly ISalePurchaseRatesView _view;
        private BindingList<SalePurchaseGridRate> _rates = new BindingList<SalePurchaseGridRate>();

        public SalePurchaseRatesPresenter(ISalePurchaseRatesView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));

            // Подписываемся на события View
            _view.OnLoadAsync += HandleLoadAsync;
            _view.OnCommitEditAsync += HandleCommitEditAsync;
            _view.OnAppendAsync += HandleAppendAsync;
            _view.OnDeleteAsync += HandleDeleteAsync;
        }

        private async Task HandleLoadAsync(CancellationToken ct)
        {
            // Прочитать головную запись типа
            await RefreshAsync(ct).ConfigureAwait(false);
        }

        private async Task RefreshAsync(CancellationToken ct)
        {
            try
            {
                _view.SetBusy(true);

                var request = new ListSalePurchaseRateRequest();
                var response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.SalePurchaseType.ListSalePurchaseRateAsync(request).ResponseAsync
                ).ConfigureAwait(false);

                var list = new List<SalePurchaseGridRate>();
                if (response?.Rates != null)
                {
                    foreach (var r in response.Rates)
                    {
                        var a = r.Json.Fields;

                        list.Add(new SalePurchaseGridRate
                        {
                            Id = r.Id == 0 ? (int?)null : r.Id,
                            Date = r.Date?.ToDateTime().ToLocalTime() ?? DateTime.MinValue,
                            RatePL = 0,
                            RateConvert = 0
                        });
                    }
                }

                _rates = new BindingList<SalePurchaseGridRate>(list);
                _view.ShowRates(_rates);
            }
            catch (Exception ex)
            {
                _view.ShowError("Ошибка при получении курсов: " + ex.Message);
            }
            finally
            {
                _view.SetBusy(false);
            }
        }

        // Если view передаёт объект, реализующий ITrackChanges, сделаем частичное обновление FieldMask; иначе - полное обновление.
        private async Task HandleCommitEditAsync(SalePurchaseGridRate model, CancellationToken ct)
        {
            if (model == null) return;

            try
            {
                _view.SetBusy(true);

                // Создание если Id пустой
                if (model.Id == null || model.Id == 0)
                {
                    var created = await CreateRateAsync(model, ct).ConfigureAwait(false);
                    if (created != null) ReplaceOrAdd(model, created);
                    _view.ShowRates(_rates);
                    return;
                }

                // Попытка частичного обновления
                if (model is ITrackChanges track && !string.IsNullOrEmpty(track.ChangedPath))
                {
                    var updateReq = new UpdateSalePurchaseRateRequest
                    {
                        Rate = new SalePurchaseRate { Id = model.Id ?? 0 }
                    };
                    var mask = new FieldMask();

                    switch (track.ChangedPath)
                    {
                        case "Rate":
                            //updateReq.Rate.Rate = Convert.ToInt32(track.ChangedValue);
                            mask.Paths.Add("rate");
                            break;
                        case "Date":
                            var dt = (DateTime)track.ChangedValue;
                            updateReq.Rate.Date = Timestamp.FromDateTime(dt.ToUniversalTime());
                            mask.Paths.Add("date");
                            break;
                        case "CurrencyId":
                            //updateReq.Rate.CurrencyId = Convert.ToInt32(track.ChangedValue);
                            mask.Paths.Add("currency_id");
                            break;
                        default:
                            // если неизвестный путь — сделать полное обновление
                            await FullUpdate(model, ct).ConfigureAwait(false);
                            return;
                    }

                    //updateReq.UpdateMask = mask;

                    var resp = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.SalePurchaseType.UpdateSalePurchaseRateAsync(updateReq).ResponseAsync
                    ).ConfigureAwait(false);

                    if (resp?.Rate != null)
                    {
                        ApplyProtoToModel(resp.Rate);
                    }
                }
                else
                {
                    // Полное обновление
                    await FullUpdate(model, ct).ConfigureAwait(false);
                }

                _view.ShowRates(_rates);
            }
            catch (Exception ex)
            {
                _view.ShowError("Ошибка при сохранении: " + ex.Message);
            }
            finally
            {
                _view.SetBusy(false);
            }
        }

        private async Task FullUpdate(SalePurchaseGridRate model, CancellationToken ct)
        {
            var req = new UpdateSalePurchaseRateRequest
            {
                Rate = new SalePurchaseRate
                {
                    Id = model.Id ?? 0,
                    Date = Timestamp.FromDateTime(model.Date.ToUniversalTime())
                }
            };

            var resp = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.SalePurchaseType.UpdateSalePurchaseRateAsync(req).ResponseAsync
            ).ConfigureAwait(false);

            if (resp?.Rate != null)
            {
                ApplyProtoToModel(resp.Rate);
            }
        }

        private async Task HandleAppendAsync(SalePurchaseGridRate model, CancellationToken ct)
        {
            if (model == null) return;

            try
            {
                _view.SetBusy(true);
                var created = await CreateRateAsync(model, ct).ConfigureAwait(false);
                if (created != null) ReplaceOrAdd(model, created);
                _view.ShowRates(_rates);
            }
            catch (Exception ex)
            {
                _view.ShowError("Ошибка при создании: " + ex.Message);
            }
            finally
            {
                _view.SetBusy(false);
            }
        }

        private async Task<SalePurchaseGridRate> CreateRateAsync(SalePurchaseGridRate model, CancellationToken ct)
        {
            var req = new CreateSalePurchaseRateRequest
            {
                Rate = new SalePurchaseRate
                {
                    Date = Timestamp.FromDateTime(model.Date.ToUniversalTime())
                }
            };

            var resp = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.SalePurchaseType.CreateSalePurchaseRateAsync(req).ResponseAsync
            ).ConfigureAwait(false);

            if (resp?.Rate == null) return null;

            return new SalePurchaseGridRate
            {
                Id = resp.Rate.Id == 0 ? (int?)null : resp.Rate.Id,
                Date = resp.Rate.Date?.ToDateTime().ToLocalTime() ?? model.Date,
                RatePL = 0,
                RateConvert = 0
            };
        }

        private async Task HandleDeleteAsync(IReadOnlyList<int> ids, CancellationToken ct)
        {
            if (ids == null || ids.Count == 0) return;

            try
            {
                _view.SetBusy(true);

                var req = new DeleteSalePurchaseRateRequest();
                req.Ids.AddRange(ids);

                var resp = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.SalePurchaseType.DeleteSalePurchaseRateAsync(req).ResponseAsync
                ).ConfigureAwait(false);

                var undeleted = resp?.UndeletedIds?.ToList() ?? new List<int>();
                var toRemove = _rates.Where(r => r.Id.HasValue && !undeleted.Contains(r.Id.Value) && ids.Contains(r.Id.Value)).ToList();
                foreach (var r in toRemove) _rates.Remove(r);

                if (undeleted.Count > 0)
                    _view.ShowError("Некоторые элементы не удалось удалить: " + string.Join(", ", undeleted));

                _view.ShowRates(_rates);
            }
            catch (Exception ex)
            {
                _view.ShowError("Ошибка при удалении: " + ex.Message);
            }
            finally
            {
                _view.SetBusy(false);
            }
        }

        private void ReplaceOrAdd(SalePurchaseGridRate original, SalePurchaseGridRate created)
        {
            var existing = _rates.FirstOrDefault(r => ReferenceEquals(r, original));
            if (existing != null)
            {
                var idx = _rates.IndexOf(existing);
                _rates[idx] = created;
            }
            else
            {
                _rates.Add(created);
            }
        }

        private void ApplyProtoToModel(SalePurchaseRate proto)
        {
            var existing = _rates.FirstOrDefault(r => r.Id == proto.Id);
            if (existing != null)
            {
                existing.Date = proto.Date?.ToDateTime().ToLocalTime() ?? existing.Date;
                existing.RatePL = 0;
                existing.RateConvert = 0;
            }
        }
    }

    // Интерфейс для передачи информации о только что изменённом поле (опционально — View может передать Wrapper)
    public interface ITrackChanges
    {
        string ChangedPath { get; }
        object ChangedValue { get; }
    }
}