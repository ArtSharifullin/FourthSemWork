using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Features.Players.Query.GetAllPlayers;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Players.Query.GetAllPlayersByTeamId
{
    public class GetAllPlayersByTeamIdQueryHandler : IRequestHandler<GetAllPlayersByTeamIdQuery, IEnumerable<PlayersDto>>
    {
        private readonly IPlayerRepository _playerRepository;

        public GetAllPlayersByTeamIdQueryHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<IEnumerable<PlayersDto>> Handle(GetAllPlayersByTeamIdQuery query, CancellationToken ct)
        {
            var data = await _playerRepository.GetAllPlayersByTeamIdAsync(query.teamId);
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
