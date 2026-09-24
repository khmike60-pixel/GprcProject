using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GrpcWinForms.Objects.SalePurchaseTypes.Models;

namespace GrpcWinForms.Objects.SalePurchaseTypes.Services
{
    // Абстракция сервисного слоя для gRPC/репозитория — упростит тестирование презентера
    public interface ISalePurchaseRatesService
    {
        Task<IList<SalePurchaseGridRate>> GetRatesAsync(CancellationToken ct);
        Task<SalePurchaseGridRate> CreateRateAsync(SalePurchaseGridRate rate, CancellationToken ct);
        Task<SalePurchaseGridRate> UpdateRateAsync(SalePurchaseGridRate rate, CancellationToken ct);
        Task<IList<int>> DeleteRatesAsync(IList<int> ids, CancellationToken ct); // возвращает не удалённые Id
    }
}