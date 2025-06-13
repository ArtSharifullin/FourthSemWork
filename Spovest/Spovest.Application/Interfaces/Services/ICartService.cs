using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spovest.Domain.Entities;

namespace Spovest.Application.Interfaces.Services
{
    public interface ICartService
    {
        Task<bool> BuyAsync(int userId, int playerId, int q);
        Task<bool> SellAsync(int userId, int playerId, int q);
    }
}
