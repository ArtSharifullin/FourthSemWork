using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Services;

namespace Spovest.Application.Features.Balance.Refill
{
    public class RefillCommandHandler : IRequestHandler<RefillCommand, bool>
    {
        private readonly IBalanceService _balanceService;
        public RefillCommandHandler(IBalanceService balanceService) { _balanceService = balanceService; }

        public async Task<bool> Handle(RefillCommand command, CancellationToken cancellationToken) =>
            await _balanceService.RefillAsync(command.userId);
    }
}
