using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Price.Query.GetPriceById
{
    public class GetPriceByIdQueryHandler : IRequestHandler<GetPriceByIdQuery, PriceDto>
    {
        private readonly IPriceRepository _priceRepository;

        public GetPriceByIdQueryHandler(IPriceRepository priceRepository)
        {
            _priceRepository = priceRepository;
        }

        public async Task<PriceDto> Handle(GetPriceByIdQuery query, CancellationToken ct)
        {
            var data = await _priceRepository.GetPriceByIdAsync(query.id);
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
