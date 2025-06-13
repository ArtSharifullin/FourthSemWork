using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Features.Players.Query;
using Spovest.Application.Features.Teams.Query.GetTeamById;

namespace Spovest.Application.Features.Posts.Query.GetAllPostsByUserId
{
    public record GetAllPostsByUserIdQuery(int id) : IRequest<IEnumerable<PostsDto>>;
}
