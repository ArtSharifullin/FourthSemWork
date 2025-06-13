using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Spovest.Application.Features.Price.Query.GetActualPriceByPlayerId
{
    public record GetActualPriceByPlayerIdQuery(int id) : IRequest<PriceDto>;
}
