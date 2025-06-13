using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Services;

namespace Spovest.Application.Features.Cart.Sell
{
    public class SellCommandHandler : IRequestHandler<SellCommand, bool>
    {
        private readonly ICartService _cartService;

        public SellCommandHandler(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<bool> Handle(SellCommand command, CancellationToken cancellationToken) =>
            await _cartService.SellAsync(command.userId, command.PlayerId, command.Q);
    }
}
