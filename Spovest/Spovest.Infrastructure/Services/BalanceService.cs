using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spovest.Application.Interfaces.Repositories;
using Spovest.Application.Interfaces.Services;
using Spovest.Domain.Entities;
using Spovest.Domain.Entities.Enums;
using Spovest.Persistence.Contexts;
using Microsoft.AspNetCore.SignalR;
using Spovest.Application.Interfaces.Hubs;
using Spovest.Infrastructure.Hubs;
using Spovest.Application.Features.Balance.Query;

namespace Spovest.Infrastructure.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly ApplicationDbContext _context;
        private readonly IBalanceHistoryRepository _balanceHistoryRepository;
        private readonly IHubContext<BalanceHub, IBalanceHub> _balanceHub;

        public BalanceService(
            ApplicationDbContext context, 
            IBalanceHistoryRepository balanceHistoryRepository,
            IHubContext<BalanceHub, IBalanceHub> balanceHub)
        {
            _context = context;
            _balanceHistoryRepository = balanceHistoryRepository;
            _balanceHub = balanceHub;
        }

        private async Task SendBalanceUpdate(IEnumerable<BalanceHistory> balanceHistory)
        {
            await _balanceHub.Clients.All.ReceivePriceUpdates(balanceHistory.OrderByDescending(x => x.Date).Take(20).OrderBy(x => x.Date));
        }

        public async Task<bool> PlusAsync(int userId, decimal q)
        {
            try
            {
                var user = _context.AppUsers.FirstOrDefault(x => x.Id == userId);
                if (user == null) { return false; }
                var totalBalance = await _balanceHistoryRepository.GetLastTotalBalance();
                user.Balance += q;
                _context.AppUsers.Update(user);
                
                var balanceHistory = new BalanceHistory
                {
                    Date = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                    TotalBalance = totalBalance + q,
                };
                _context.BalanceHistory.Add(balanceHistory);
                _context.SaveChanges();
                var balanceAllHistory = await _balanceHistoryRepository.GetAllAsync();
                await SendBalanceUpdate(balanceAllHistory);
                return true;
            }
            catch (Exception ex) 
            { 
                return false;
            }
        }

        public async Task<bool> RefillAsync(int userId)
        {
            try
            {
                var user = _context.AppUsers.FirstOrDefault(x => x.Id == userId);
                if (user == null) { return false; }
                var totalBalance = await _balanceHistoryRepository.GetLastTotalBalance();
                _context.Transactions.Add(new Transaction
                {
                    UserId = user.Id,
                    OperationType = OperationType.Refill,
                    Cost = 100,
                    CreatedDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)
                });

                var balanceHistory = new BalanceHistory
                {
                    Date = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                    TotalBalance = totalBalance + 100,
                };
                _context.BalanceHistory.Add(balanceHistory);
                user.Balance += 100;
                _context.AppUsers.Update(user);
                _context.SaveChanges();

                var balanceAllHistory = await _balanceHistoryRepository.GetAllAsync();
                await SendBalanceUpdate(balanceAllHistory);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> MinusAsync(int userId, decimal q)
        {
            try
            {
                var user = _context.AppUsers.FirstOrDefault(x => x.Id == userId);
                if (user == null) { return false; }
                var totalBalance = await _balanceHistoryRepository.GetLastTotalBalance();
                
                if (user.Balance < q)
                {
                    return false;
                }
                user.Balance -= q;

                var balanceHistory = new BalanceHistory
                {
                    Date = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                    TotalBalance = totalBalance - q,
                };
                _context.BalanceHistory.Add(balanceHistory);
                _context.AppUsers.Update(user);
                _context.SaveChanges();

                var balanceAllHistory = await _balanceHistoryRepository.GetAllAsync();
                await SendBalanceUpdate(balanceAllHistory);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> WithdrawAsync(int userId)
        {
            try
            {
                var user = _context.AppUsers.FirstOrDefault(x => x.Id == userId);
                if (user == null) { return false; }
                if (user.Balance <= 0)
                {
                    return false;
                }
                if (user.IsWithdrawBlocked)
                {
                    return false;
                }
                var totalBalance = await _balanceHistoryRepository.GetLastTotalBalance();
                var cost = user.Balance;
                user.Balance = 0;

                _context.Transactions.Add(new Transaction
                {
                    UserId = user.Id,
                    OperationType = OperationType.Withdraw,
                    Cost = cost,
                    CreatedDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)
                });

                var balanceHistory = new BalanceHistory
                {
                    Date = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                    TotalBalance = totalBalance - cost,
                };
                _context.BalanceHistory.Add(balanceHistory);
                _context.AppUsers.Update(user);
                _context.SaveChanges();

                var balanceAllHistory = await _balanceHistoryRepository.GetAllAsync();
                await SendBalanceUpdate(balanceAllHistory);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
