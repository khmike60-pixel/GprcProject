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

        public static async Task<Currency> GetCurrencyByIdAsync(int id)
        {
            try
            {
                var request = new GetCurrencyRequest { Id = id };
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
    }
}
