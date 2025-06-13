using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Spovest.Application.Features.Posts.Query.GetPostById
{
    public record GetPostByIdQuery(int id) : IRequest<PostsDto>;
}
