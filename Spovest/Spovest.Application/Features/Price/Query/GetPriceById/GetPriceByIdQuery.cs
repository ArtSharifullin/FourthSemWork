using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Spovest.Application.Features.Price.Query.GetPriceById
{
    public record GetPriceByIdQuery(int id) : IRequest<PriceDto>;
}
