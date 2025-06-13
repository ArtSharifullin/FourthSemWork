using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Features.Players.Query.GetAllPlayers;
using Spovest.Application.Features.Players.Query;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Balance.Query.GetLastTotalBalance
{
    public class GetLastTotalBalanceQueryHandler : IRequestHandler<GetLastTotalBalanceQuery, decimal>
    {
        private readonly IBalanceHistoryRepository _historyRepository;

        public GetLastTotalBalanceQueryHandler(IBalanceHistoryRepository historyRepository) { _historyRepository = historyRepository; }

        public async Task<decimal> Handle(GetLastTotalBalanceQuery query, CancellationToken ct)
        {
            var data = await _historyRepository.GetLastTotalBalance();
            return data;
        }
    }
}
