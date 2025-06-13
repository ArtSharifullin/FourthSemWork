using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Features.Players.Query;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Price.Query.GetAllPricesByPlayerId
{
    public class GetAllPricesByPlayerIdQueryHandler : IRequestHandler<GetAllPricesByPlayerIdQuery, IEnumerable<PriceDto>>
    {
        private readonly IPriceRepository _priceRepository;

        public GetAllPricesByPlayerIdQueryHandler(IPriceRepository priceRepository)
        {
            _priceRepository = priceRepository;
        }

        public async Task<IEnumerable<PriceDto>> Handle(GetAllPricesByPlayerIdQuery query, CancellationToken ct)
        {
            var data = await _priceRepository.GetAllPricesByPlayerIdAsync(query.id);
            var result = data.Select(e => new PriceDto
            {
                Id = e.Id,
                PlayerId = e.PlayerId,
                Purchase_price = e.Purchase_price,
                Sale_price = e.Sale_price,
                Timestamp = e.Timestamp,
            });

            return result ?? new List<PriceDto>() { };
        }
    }
}
