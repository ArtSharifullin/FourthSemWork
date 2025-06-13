using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Price.Command.Create
{
    public class CreatePriceCommandHandler : IRequestHandler<CreatePriceCommand, bool>
    {
        private readonly IPriceRepository _priceRepository;
        public CreatePriceCommandHandler(IPriceRepository priceRepository) { _priceRepository = priceRepository; }

        public async Task<bool> Handle(CreatePriceCommand command, CancellationToken ct) =>
            await _priceRepository.CreatePriceAsync(command.playerId, command.pprice, command.sprice);
    }
}
