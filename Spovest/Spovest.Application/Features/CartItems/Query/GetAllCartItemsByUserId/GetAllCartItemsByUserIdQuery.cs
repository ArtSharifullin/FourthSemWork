using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Spovest.Application.Features.CartItems.Query.GetAllCartItemsByUserId
{
    public record GetAllCartItemsByUserIdQuery(int userId) : IRequest<IEnumerable<CartItemDto>>;
}
