using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spovest.Domain.Entities;

namespace Spovest.Application.Interfaces.Repositories
{
    public interface IBalanceHistoryRepository
    {
        Task<IEnumerable<BalanceHistory>> GetAllAsync();
        Task<decimal> GetLastTotalBalance();
    }
}
