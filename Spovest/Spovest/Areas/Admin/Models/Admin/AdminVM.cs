using Spovest.Application.Features.Users.Query;
using Spovest.Application.Features.Balance.Query;
using Spovest.Application.Features.Transactions.Query;

namespace Spovest.Areas.Admin.Models.Admin
{
    public class AdminVM
    {
        public IEnumerable<UserDto> Users { get; set; }
        public IEnumerable<BalanceHistoryDto> BalanceHistory { get; set; }
        public IEnumerable<TransactionDto> Transactions { get; set; }
    }
}
