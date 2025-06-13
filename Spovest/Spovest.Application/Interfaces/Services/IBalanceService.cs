using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spovest.Domain.Entities;

namespace Spovest.Application.Interfaces.Services
{
    public interface IBalanceService
    {
        Task<bool> PlusAsync(int userId, decimal q);
        Task<bool> RefillAsync(int userId);
        Task<bool> MinusAsync(int userId, decimal q);
        Task<bool> WithdrawAsync(int userId);
    }
}
