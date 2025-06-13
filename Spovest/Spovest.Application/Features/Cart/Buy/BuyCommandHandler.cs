using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Features.Balance.Refill;
using Spovest.Application.Interfaces.Services;

namespace Spovest.Application.Features.Cart.Buy
{
    public class BuyCommandHandler : IRequestHandler<BuyCommand, bool>
    {
        private readonly ICartService _cartService;

        public BuyCommandHandler(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<bool> Handle(BuyCommand command, CancellationToken cancellationToken) =>
            await _cartService.BuyAsync(command.userId, command.PlayerId, command.Q);
    }
}
