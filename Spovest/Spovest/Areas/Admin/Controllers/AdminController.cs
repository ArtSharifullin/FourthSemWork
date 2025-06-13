using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Spovest.Application.Features.Users.Query.GetAllUsers;
using Spovest.Areas.Admin.Models.Admin;
using Spovest.Application.Features.Transactions.Query.GetAllTransactions;
using Spovest.Application.Features.Balance.Query;
using Spovest.Application.Features.Balance.Query.GetAllBalanceHistory;

namespace Spovest.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminPolicy")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IMediator _mediator;

        public AdminController(
            ILogger<AdminController> logger, 
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var excludedIds = new List<int> { 1, 2, 3 };
            var usersQuery = new GetAllUsersQuery();
            var tempUsers = await _mediator.Send(usersQuery);
            var users = tempUsers.Where(t => !excludedIds.Contains(t.UserId));

            var transactionsQuery = new GetAllTransactionsQuery();
            var transactions = await _mediator.Send(transactionsQuery);

            var balanceHistoryQuery = new GetAllBalanceHistoryQuery();
            var balanceHistory = await _mediator.Send(balanceHistoryQuery);

            decimal currentBalance = users.Sum(x => x.Balance);
            var sortedTransactions = transactions.Where(t => t.CreatedDate.HasValue && !excludedIds.Contains(t.UserId)).OrderByDescending(t => t.CreatedDate).ToList();
            
            // Aggregate by date to avoid multiple points for the same day if many transactions
            var aggregatedBalanceHistory = balanceHistory
                .GroupBy(b => b.Date)
                .Select(g => new BalanceHistoryDto
                {
                    Date = g.Key,
                    TotalBalance = g.Last().TotalBalance // Take the last balance of the day
                })
                .OrderBy(b => b.Date)
                .ToList();

            var adminVM = new AdminVM
            {
                Users = users,
                BalanceHistory = aggregatedBalanceHistory,
                Transactions = sortedTransactions,
            };

            return View(adminVM);
        }
    }
}
