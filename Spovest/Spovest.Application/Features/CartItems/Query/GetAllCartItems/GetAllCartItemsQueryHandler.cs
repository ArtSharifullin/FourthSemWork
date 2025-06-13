using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.CartItems.Query.GetAllCartItems
{
    public class GetAllCartItemsQueryHandler : IRequestHandler<GetAllCartItemsQuery, IEnumerable<CartItemDto>>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public GetAllCartItemsQueryHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<IEnumerable<CartItemDto>> Handle(GetAllCartItemsQuery query, CancellationToken ct)
        {
            var data = await _cartItemRepository.GetAllCartItemsAsync();
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
