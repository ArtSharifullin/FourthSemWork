using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Balance.Query.GetAllBalanceHistory
{
    public class GetAllBalanceHistoryQueryHandler : IRequestHandler<GetAllBalanceHistoryQuery, IEnumerable<BalanceHistoryDto>>
    {
        private readonly IBalanceHistoryRepository _historyRepository;

        public GetAllBalanceHistoryQueryHandler(IBalanceHistoryRepository historyRepository) { _historyRepository = historyRepository; }

        public async Task<IEnumerable<BalanceHistoryDto>> Handle(GetAllBalanceHistoryQuery query, CancellationToken ct)
        {
            var data = await _historyRepository.GetAllAsync();
            var result = data.OrderByDescending(x => x.Date).Take(20).Select(x => new BalanceHistoryDto
            {
                Id = x.Id,
                Date = x.Date,
                TotalBalance = x.TotalBalance,
            }).OrderBy(x => x.Date);

            return result;
        }
    }
}
