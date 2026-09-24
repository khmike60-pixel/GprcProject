using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GrpcWinForms.Objects.SalePurchaseTypes.Models;

namespace GrpcWinForms.Objects.SalePurchaseTypes.Services
{
    // Абстракция сервисного слоя для gRPC/репозитория — упростит тестирование презентера
    public interface ISalePurchaseRatesService
    {
        Task<IList<RateRow>> GetRatesAsync(CancellationToken ct);
        Task<RateRow> CreateRateAsync(RateRow rate, CancellationToken ct);
        Task<RateRow> UpdateRateAsync(RateRow rate, CancellationToken ct);
        Task<IList<int>> DeleteRatesAsync(IList<int> ids, CancellationToken ct); // возвращает не удалённые Id
    }
}