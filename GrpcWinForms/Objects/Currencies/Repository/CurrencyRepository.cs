using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Currency;
using GrpcWinForms.GrpcUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Currencies.Repository
{
    public class CurrencyRepository
    {
        /// <summary>
        /// Получить список валют из gRPC сервиса
        /// </summary>
        /// <param name="includeInvisible">Включая невидимые валюты</param>
        /// <param name="currencyAbbrev">Фильтр по аббревиатуре валюты</param>
        /// <returns></returns>
        public static async Task<BindingList<Currency>> GetCurrenciesAsync(bool includeInvisible, string currencyAbbrev)
        {
            try
            {
                var request = new ListCurrencyRequest
                {
                    IncludeInvisible = includeInvisible,
                    CurrencyAbbrev = string.IsNullOrWhiteSpace(currencyAbbrev) ? string.Empty : currencyAbbrev,
                    FieldMask = new FieldMask()
                };
                request.FieldMask.Paths.Add("name");
                request.FieldMask.Paths.Add("code");
                request.FieldMask.Paths.Add("id");
                request.FieldMask.Paths.Add("abbrev");
                request.FieldMask.Paths.Add("order_number");
                request.FieldMask.Paths.Add("is_visible");
                ListCurrencyResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Currency.GetListCurrencyAsync(request).ResponseAsync
                );
                return new BindingList<Currency>(response.Currencies);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении списка валют: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Получить валюту по ID из gRPC сервиса
        /// </summary>
        /// <param name="id">ID валюты</param>
        /// <returns>Валюта</returns>
        /// <exception cref="Exception"></exception>
        public static async Task<Currency> GetCurrencyByIdAsync(int id)
        {
            try
            {
                var request = new CurrencyRequest { Id = id };
                CurrencyResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Currency.GetCurrencyAsync(request).ResponseAsync
                );
                if (response.Result.Status != Status.Ok || response.Currency == null)
                {
                    throw new Exception("Не удалось получить данные валюты.");
                }
                return response.Currency;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении валюты по ID: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Создать новую валюту
        /// </summary>
        /// <param name="currency">Валюта для создания</param>
        /// <returns>Созданная валюта</returns>
        /// <exception cref="Exception"></exception>
        public static async Task<Currency> CreateCurrencyAsync(Currency currency)
        {
            try
            {
                var request = new CreateCurrencyRequest { Currency = currency };
                CurrencyResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Currency.CreateCurrencyAsync(request).ResponseAsync
                );
                if (response.Result.Status != Status.Ok || response.Currency == null)
                {
                    throw new Exception("Не удалось создать валюту.");
                }
                return response.Currency;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при создании валюты: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Обновить существующую валюту
        /// </summary>
        /// <param name="currency">Валюта для обновления</param>
        /// <returns>Обновленная валюта</returns>
        /// <exception cref="Exception"></exception>
        public static async Task<Currency> UpdateCurrencyAsync(Currency currency)
        {
            try
            {
                var request = new UpdateCurrencyRequest { Currency = currency };
                CurrencyResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Currency.UpdateCurrencyAsync(request).ResponseAsync
                );
                if (response.Result.Status != Status.Ok || response.Currency == null)
                {
                    throw new Exception("Не удалось обновить валюту.");
                }
                return response.Currency;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при обновлении валюты: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Удалить валюту по ID
        /// </summary>
        /// <param name="id">ID валюты для удаления</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<bool> DeleteCurrencyAsync(int id)
        {
            try
            {
                var request = new DeleteCurrencyRequest { Id = id };
                DeleteCurrencyResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Currency.DeleteCurrencyAsync(request).ResponseAsync
                );
                if (response.Result.Status != Status.Ok)
                {
                    throw new Exception("Не удалось удалить валюту.");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при удалении валюты: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Удалить несколько валют по списку ID
        /// </summary>
        /// <param name="ids">Список ID валют для удаления</param>
        /// <returns>Список ID валют, которые не удалось удалить</returns>
        /// <exception cref="Exception"></exception>
        public static async Task<List<int>> DeleteCurrenciesAsync(List<int> ids)
        {
            try
            {
                DeleteIdsCurrencyRequest request = new DeleteIdsCurrencyRequest();
                request.Ids.AddRange(ids);
                UndeletedIdsCurrencyResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Currency.DeleteIdsCurrencyAsync(request).ResponseAsync
                );
                if (response.Result.Status != Status.Ok)
                {
                    throw new Exception("Не удалось удалить валюты.");
                }
                return response.UndeletedIds.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при удалении валют: {ex.Message}", ex);
            }
        }

    }
}
