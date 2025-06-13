using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Domain.Entities;

namespace Spovest.Application.Features.Players.Query.ConvertPlayersToPlayersDto
{
    public record ConvertPlayersToPlayersDtoQuery(IEnumerable<Player> players) : IRequest<IEnumerable<PlayersDto>>;
}
