using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Players.Query.ConvertPlayersToPlayersDto
{
    public class ConvertPlayersToPlayersDtoQueryHandler : IRequestHandler<ConvertPlayersToPlayersDtoQuery, IEnumerable<PlayersDto>>
    {
        public async Task<IEnumerable<PlayersDto>> Handle(ConvertPlayersToPlayersDtoQuery query, CancellationToken ct)
        {
            var data = query.players;
            var result = data.Select(e => new PlayersDto
            {
                Id = e.Id,
                TeamId = e.TeamId,
                TeamName = e.TeamName,
                Name = e.Name,
                Img = e.Img,
                Games = e.Games,
                Points = e.Points,
                Assists = e.Assists,
                Rebounds = e.Rebounds,
                Steals = e.Steals,
                Minutes = e.Minutes,
                Ftps = e.Ftps,
            });

            return result ?? new List<PlayersDto>() { };
        }
    }
}
