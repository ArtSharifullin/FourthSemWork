using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spovest.Application.Features.Players.Query;
using Spovest.Application.Interfaces.Repositories;
using Spovest.Domain.Entities;

namespace Spovest.Persistence.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly IGenericRepository<CartItem> _repository;

        public CartItemRepository(IGenericRepository<CartItem> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CartItem>> GetAllCartItemsByUserIdAsync(int userId)
        {
            return await _repository.Entities
                .Include(x => x.Player)
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.Quantity)
                .ToListAsync();
        }

        public async Task<IEnumerable<Player>> GetAllPlayersInUserCartAsync(int userId)
        {
            return await _repository.Entities.Where(x =>x.UserId == userId).Select(x => x.Player).ToListAsync();
        }
        public async Task<IEnumerable<CartItem>> GetAllCartItemsAsync()
        {
            return await _repository.Entities.ToListAsync();
        }
    }
}
