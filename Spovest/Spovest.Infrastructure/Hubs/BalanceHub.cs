using Microsoft.AspNetCore.SignalR;
using Spovest.Application.Interfaces.Hubs;
using Spovest.Domain.Entities;

namespace Spovest.Infrastructure.Hubs
{
    public class BalanceHub : Hub<IBalanceHub>
    {
        public async Task SendBalanceUpdates(IEnumerable<BalanceHistory> balanceHistory)
        {
            await Clients.All.ReceivePriceUpdates(balanceHistory);
        }
    }
} 