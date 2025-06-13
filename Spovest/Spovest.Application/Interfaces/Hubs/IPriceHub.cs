using System.Collections.Generic;
using System.Threading.Tasks;
using Spovest.Domain.Entities;

namespace Spovest.Application.Interfaces.Hubs
{
    /// <summary>
    /// Интерфейс для клиентских методов хаба
    /// </summary>
    public interface IPriceHub
    {
        Task ReceivePriceUpdates(IEnumerable<PriceHistory> newPrices, IEnumerable<PriceHistory> oldPrices);
    }
} 