using MediatR;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Players.Query.GetAllPlayers
{
    public class GetAllPlayersQueryHandler : IRequestHandler<GetAllPlayersQuery, IEnumerable<PlayersDto>>
    {
        private readonly IPlayerRepository _playerRepository;

        public GetAllPlayersQueryHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<IEnumerable<PlayersDto>> Handle(GetAllPlayersQuery query, CancellationToken ct)
        {
            var data = await _playerRepository.GetAllPlayersAsync();
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
