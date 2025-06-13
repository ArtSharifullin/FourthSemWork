using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Features.Players.Query;
using Spovest.Application.Features.Players.Query.GetAllPlayers;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.CartItems.Query.GetAllPlayersInUserCart
{
    public class GetAllPlayersInUserCartQueryHandler : IRequestHandler<GetAllPlayersInUserCartQuery, IEnumerable<PlayersDto>>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public GetAllPlayersInUserCartQueryHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<IEnumerable<PlayersDto>> Handle(GetAllPlayersInUserCartQuery query, CancellationToken ct)
        {
            var data = await _cartItemRepository.GetAllPlayersInUserCartAsync(query.id);
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
