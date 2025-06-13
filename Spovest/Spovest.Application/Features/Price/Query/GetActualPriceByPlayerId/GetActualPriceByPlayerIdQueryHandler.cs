using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Features.Price.Query.GetAllPrices;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Price.Query.GetActualPriceByPlayerId
{
    public class GetActualPriceByPlayerIdQueryHandler : IRequestHandler<GetActualPriceByPlayerIdQuery, PriceDto>
    {
        private readonly IPriceRepository _priceRepository;

        public GetActualPriceByPlayerIdQueryHandler(IPriceRepository priceRepository)
        {
            _priceRepository = priceRepository;
        }

        public async Task<PriceDto> Handle(GetActualPriceByPlayerIdQuery query, CancellationToken ct)
        {
            var data = await _priceRepository.GetActualPriceByPlayerIdAsync(query.id);
            var result = new PriceDto
            {
                Id = data.Id,
                PlayerId = data.PlayerId,
                Purchase_price = data.Purchase_price,
                Sale_price = data.Sale_price,
                Timestamp = data.Timestamp,
            };

            return result ?? new PriceDto() { };
        }
    }
}
