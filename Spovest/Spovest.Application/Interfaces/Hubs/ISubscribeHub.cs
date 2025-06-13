using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spovest.Domain.Entities;

namespace Spovest.Application.Interfaces.Hubs
{
    public interface ISubscribeHub
    {
        Task ReceiveSubscribeUpdates(IEnumerable<AppUser> followers, IEnumerable<AppUser> following);
    }
}
