using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spovest.Application.Interfaces.Repositories;
using Spovest.Domain.Entities;
using Spovest.Domain.Entities.Enums;

namespace Spovest.Persistence.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IGenericRepository<Transaction> _repository;

        public TransactionRepository(IGenericRepository<Transaction> repository)
        {
            _repository = repository;
        }
        
        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsByUserIdAsync(int id)
        {
            return await _repository.Entities.Where(x => x.UserId == id).ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsByTypeAsync(string type)
        {
            var t = GetOperationType(type);
            return await _repository.Entities.Where(x => x.OperationType == t).ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsByUserIdAndTypeAsync(int id, string type)
        {
            var t = GetOperationType(type);
            return await _repository.Entities.Where(x => x.UserId == id && x.OperationType == t).ToListAsync();
        }

        private OperationType GetOperationType(string type)
        {
            switch (type)
            {
                case "buy":
                    return OperationType.Buy;
                case "sell":
                    return OperationType.Sell;
                case "refill":
                    return OperationType.Refill;
                case "withdraw":
                    return OperationType.Withdraw;
                default:
                    throw new ArgumentException($"Неизвестный тип операции: {type}");
            }   
        }
    }
}
