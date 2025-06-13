using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Features.Players.Query;

namespace Spovest.Application.Features.CartItems.Query.GetAllPlayersInUserCart
{
    public record GetAllPlayersInUserCartQuery(int id) : IRequest<IEnumerable<PlayersDto>>;
}
