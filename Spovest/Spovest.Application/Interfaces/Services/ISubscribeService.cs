using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spovest.Domain.Entities;

namespace Spovest.Application.Interfaces.Services
{
    public interface ISubscribeService
    {
        Task<bool> SubscribeAsync(int UserId, int FollowerId);
        Task<bool> UnsubscribeAsync(int UserId, int FollowerId);
    }
}
