using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Features.Players.Query.GetAllPlayers;
using Spovest.Application.Features.Players.Query.GetPlayerById;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Players.Query.GetPlayerById
{
    public class GetPlayerByIdQueryHandler : IRequestHandler<GetPlayerByIdQuery, PlayersDto>
    {
        private readonly IPlayerRepository _playerRepository;

        public GetPlayerByIdQueryHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<PlayersDto> Handle(GetPlayerByIdQuery query, CancellationToken ct)
        {
            var data = await _playerRepository.GetPlayerByIdAsync(query.id);
            
            if (data == null)
            {
                return null;
            }

            return new PlayersDto
            {
                Id = data.Id,
                TeamId = data.TeamId,
                TeamName = data.TeamName,
                Name = data.Name,
                Img = data.Img,
                Games = data.Games,
                Points = data.Points,
                Assists = data.Assists,
                Rebounds = data.Rebounds,
                Steals = data.Steals,
                Minutes = data.Minutes,
                Ftps = data.Ftps,
            };
        }
    }
}
