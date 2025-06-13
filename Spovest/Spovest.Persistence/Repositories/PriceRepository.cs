using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spovest.Application.Interfaces.Repositories;
using Spovest.Domain.Entities;

namespace Spovest.Persistence.Repositories
{
    public class PriceRepository : IPriceRepository
    {
        private readonly IGenericRepository<PriceHistory> _repository;

        public PriceRepository(IGenericRepository<PriceHistory> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PriceHistory>> GetAllPricesByPlayerIdAsync(int id)
        {
            return await _repository.Entities.Where(x => x.PlayerId == id).OrderByDescending(x => x.Timestamp).ToListAsync();
        }

        public async Task<PriceHistory> GetActualPriceByPlayerIdAsync(int id)
        {
            return await _repository.Entities.Where(x => x.PlayerId == id).OrderByDescending(x => x.Timestamp).FirstAsync();
        }

        public async Task<IEnumerable<PriceHistory>> GetAllPricesAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<PriceHistory> GetPriceByIdAsync(int id)
        {
            return await _repository.Entities.FirstOrDefaultAsync(x=> x.Id == id);
        }


        public async Task<bool> CreatePriceAsync(int playerId, decimal pprice, decimal sprice)
        {
            var price = new PriceHistory
            {
                PlayerId = playerId,
                Purchase_price = pprice,
                Sale_price = sprice,
                Timestamp = DateTime.UtcNow
            };
            await _repository.AddAsync(price);
            return true;
        }
        public async Task<bool> DeletePriceAsync(int id)
        {
            var existingPrice = _repository.Entities.FirstOrDefault(x => x.Id == id);
            if (existingPrice == null) { return false; }
            await _repository.DeleteAsync(existingPrice);
            return true;
        }
        public async Task<bool> UpdatePriceAsync(int id, int playerId, decimal pprice, decimal sprice)
        {
            var existingPrice = _repository.Entities.FirstOrDefault(x => x.Id == id);
            if (existingPrice == null) { return false; }

            existingPrice.PlayerId = playerId;
            existingPrice.Purchase_price = pprice;
            existingPrice.Sale_price = sprice;
            existingPrice.Timestamp = DateTime.UtcNow;

            await _repository.UpdateAsync(existingPrice);
            return true;
        }
    }
}
