using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Price.Command.Update
{
    public class UpdatePriceCommandHandler : IRequestHandler<UpdatePriceCommand, bool>
    {
        private readonly IPriceRepository _priceRepository;
        public UpdatePriceCommandHandler(IPriceRepository priceRepository) { _priceRepository = priceRepository; }

        public async Task<bool> Handle(UpdatePriceCommand command, CancellationToken ct) =>
            await _priceRepository.UpdatePriceAsync(command.id, command.playerId, command.pprice, command.sprice);
    }
}
