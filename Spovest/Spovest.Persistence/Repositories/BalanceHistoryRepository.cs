using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spovest.Application.Interfaces.Repositories;
using Spovest.Domain.Entities;
using Spovest.Persistence.Contexts;

namespace Spovest.Persistence.Repositories
{
    public class BalanceHistoryRepository : IBalanceHistoryRepository
    {
        private readonly IGenericRepository<BalanceHistory> _repository;

        public BalanceHistoryRepository(IGenericRepository<BalanceHistory> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<BalanceHistory>> GetAllAsync()
        {
            return await _repository.Entities.ToListAsync();
        }
        public async Task<decimal> GetLastTotalBalance()
        {
            var anyHistory = await _repository.Entities.AnyAsync();
            if (anyHistory)
            {
                var bh = await _repository.Entities.OrderBy(x=>x.Date).LastAsync();
                return bh.TotalBalance;
            }
            return 0;
        }
    }
}
