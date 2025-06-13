using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spovest.Domain.Entities;

namespace Spovest.Application.Interfaces.Repositories
{
    public interface ICartItemRepository
    {
        Task<IEnumerable<CartItem>> GetAllCartItemsByUserIdAsync(int userId);
        Task<IEnumerable<Player>> GetAllPlayersInUserCartAsync(int userId);
        Task<IEnumerable<CartItem>> GetAllCartItemsAsync();

    }
}
