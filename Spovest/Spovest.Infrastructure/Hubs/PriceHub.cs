using Microsoft.AspNetCore.SignalR;
using Spovest.Application.Interfaces.Hubs;
using Spovest.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spovest.Infrastructure.Hubs
{
    public class PriceHub : Hub<IPriceHub>
    {
        public async Task SendPriceUpdates(IEnumerable<PriceHistory> newPrices, IEnumerable<PriceHistory> oldPrices)
        {
            await Clients.All.ReceivePriceUpdates(newPrices, oldPrices);
        }
    }
} 