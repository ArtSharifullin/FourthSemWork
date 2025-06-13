using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Features.Players.Query.GetAllPlayers;

namespace Spovest.Application.Features.Players.Query.GetAllPlayersByTeamId
{
    public record GetAllPlayersByTeamIdQuery(int teamId) : IRequest<IEnumerable<PlayersDto>>;
}
