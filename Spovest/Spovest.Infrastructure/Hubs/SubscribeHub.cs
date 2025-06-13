using Microsoft.AspNetCore.SignalR;
using Spovest.Application.Interfaces.Hubs;
using Spovest.Domain.Entities;

namespace Spovest.Infrastructure.Hubs
{
    public class SubscribeHub : Hub<ISubscribeHub>
    {
        public async Task SendSubscribeUpdates(string userId, IEnumerable<AppUser> followers, IEnumerable<AppUser> following)
        {
            await Clients.User(userId).ReceiveSubscribeUpdates(followers, following);
        }
    }
}
