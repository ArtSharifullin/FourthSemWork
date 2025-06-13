using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Spovest.Application.Features.Posts.Query.GetAllPosts
{
    public record GetAllPostsQuery : IRequest<IEnumerable<PostsDto>>;
}
