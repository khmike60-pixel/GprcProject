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
using GrpcWinForms.Objects.SalePurchaseTypes.Mapping;

namespace GrpcWinForms.Objects.SalePurchaseTypes.Presenters
{
    public class SalePurchaseRatesPresenter
    {
        private readonly ISalePurchaseRatesView _view;
        private BindingList<RateRow> _rates = new BindingList<RateRow>();

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

                var requestType = new SalePurchaseTypeRequest() { Id = 1 };
                var responseType = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.SalePurchaseType.GetSalePurchaseTypeAsync(requestType).ResponseAsync
                ).ConfigureAwait(false);

                if (responseType.Result.Status == Status.Ok)
                {
                    _view.CountryCode = responseType.SalePurchaseType.Country.Code2;
                    _view.CurrencyCode = responseType.SalePurchaseType.Currency.Abbrev;
                }
                else return;

                var request = new ListSalePurchaseRateRequest()
                {
                    DateStart = _view.DateStart.ToUniversalTime().ToTimestamp(),
                    DateEnd = _view.DateEnd.ToUniversalTime().ToTimestamp(),
                    SalePurchaseType = new SalePurchaseType() { Id = _view.SalePurchaseTypeId }
                };

                var response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.SalePurchaseType.ListSalePurchaseRateAsync(request).ResponseAsync
                ).ConfigureAwait(false);

                var list = new List<RateRow>();
                if (response?.Rates != null)
                {
                    foreach (var r in response.Rates)
                    {
                        var a = r.Json.Fields;
                        RateRow row = new RateRow();
                        row = SalePurchaseRateToRateRowMapper.Map(r);
                        list.Add(row);
                    }
                }

                _rates = new BindingList<RateRow>(list);
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
        private async Task HandleCommitEditAsync(RateRow model, CancellationToken ct)
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
                        Rate = new SalePurchaseRate { Id = model.Id }
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

        private async Task FullUpdate(RateRow model, CancellationToken ct)
        {
            var req = new UpdateSalePurchaseRateRequest
            {
                Rate = new SalePurchaseRate
                {
                    Id = model.Id,
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

        private async Task HandleAppendAsync(RateRow model, CancellationToken ct)
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

        private async Task<RateRow> CreateRateAsync(RateRow model, CancellationToken ct)
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

            RateRow rateRow = SalePurchaseRateToRateRowMapper.Map(resp.Rate);
            return rateRow;
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
                //var toRemove = _rates.Where(r => r.Id..HasValue && !undeleted.Contains(r.Id.Value) && ids.Contains(r.Id.Value)).ToList();
                //foreach (var r in toRemove) _rates.Remove(r);

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

        private void ReplaceOrAdd(RateRow original, RateRow created)
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
                existing = SalePurchaseRateToRateRowMapper.Map(proto);
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