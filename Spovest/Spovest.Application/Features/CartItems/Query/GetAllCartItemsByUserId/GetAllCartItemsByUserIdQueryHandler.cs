using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Features.Players.Query.GetAllPlayersByTeamId;
using Spovest.Application.Features.Players.Query;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.CartItems.Query.GetAllCartItemsByUserId
{
    public class GetAllCartItemsByUserIdQueryHandler : IRequestHandler<GetAllCartItemsByUserIdQuery, IEnumerable<CartItemDto>>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public GetAllCartItemsByUserIdQueryHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<IEnumerable<CartItemDto>> Handle(GetAllCartItemsByUserIdQuery query, CancellationToken ct)
        {
            var data = await _cartItemRepository.GetAllCartItemsByUserIdAsync(query.userId);
            var result = data.Select(e => new CartItemDto
            {
                Id = e.Id,
                UserId = e.UserId,
                AppUser = e.AppUser,
                PlayerId = e.PlayerId,
                Player = e.Player,
                Quantity = e.Quantity,
                PriceAtAdd = e.PriceAtAdd,
            });

            return result ?? new List<CartItemDto>() { };
        }
    }
}
