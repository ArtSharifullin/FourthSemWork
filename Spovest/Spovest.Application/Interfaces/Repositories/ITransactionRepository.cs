using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spovest.Domain.Entities;
using Spovest.Domain.Entities.Enums;

namespace Spovest.Application.Interfaces.Repositories
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetAllTransactionsAsync();
        Task<IEnumerable<Transaction>> GetAllTransactionsByUserIdAsync(int id);
        Task<IEnumerable<Transaction>> GetAllTransactionsByTypeAsync(string type);
        Task<IEnumerable<Transaction>> GetAllTransactionsByUserIdAndTypeAsync(int id, string type);
    }
}
