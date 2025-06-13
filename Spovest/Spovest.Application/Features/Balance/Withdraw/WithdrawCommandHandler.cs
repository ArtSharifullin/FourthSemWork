using MediatR;
using Spovest.Application.Interfaces.Services;

namespace Spovest.Application.Features.Balance.Withdraw
{
    public class WithdrawCommandHandler : IRequestHandler<WithdrawCommand,bool>
    {
        private readonly IBalanceService _balanceService;
        public WithdrawCommandHandler(IBalanceService balanceService) { _balanceService = balanceService; }

        public async Task<bool> Handle(WithdrawCommand command, CancellationToken cancellationToken) =>
            await _balanceService.WithdrawAsync(command.userId);
    }
}
