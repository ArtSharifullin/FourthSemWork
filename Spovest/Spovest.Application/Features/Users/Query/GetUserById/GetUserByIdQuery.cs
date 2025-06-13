using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Spovest.Application.Features.Users.Query.GetUserById
{
    public record GetUserByIdQuery(int id) : IRequest<UserDto>;
}
