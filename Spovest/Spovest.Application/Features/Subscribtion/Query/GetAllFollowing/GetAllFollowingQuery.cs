using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Features.Users.Query;
using Spovest.Domain.Entities;

namespace Spovest.Application.Features.Subscribtion.Query.GetAllFollowing
{
    public record GetAllFollowingQuery(int userId) : IRequest<IEnumerable<UserDto>>;
}
