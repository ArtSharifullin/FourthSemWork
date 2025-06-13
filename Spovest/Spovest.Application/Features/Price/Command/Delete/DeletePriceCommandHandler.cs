using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Price.Command.Delete
{
    public class DeletePriceCommandHandler : IRequestHandler<DeletePriceCommand, bool>
    {
        private readonly IPriceRepository _priceRepository;
        public DeletePriceCommandHandler(IPriceRepository priceRepository) { _priceRepository = priceRepository; }

        public async Task<bool> Handle(DeletePriceCommand command, CancellationToken ct) =>
            await _priceRepository.DeletePriceAsync(command.id);
    }
}
