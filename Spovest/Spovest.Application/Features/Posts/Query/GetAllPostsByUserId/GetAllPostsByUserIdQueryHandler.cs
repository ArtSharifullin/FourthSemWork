using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Features.Players.Query.GetAllPlayersByTeamId;
using Spovest.Application.Features.Players.Query;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Posts.Query.GetAllPostsByUserId
{
    public class GetAllPostsByUserIdQueryHandler : IRequestHandler<GetAllPostsByUserIdQuery, IEnumerable<PostsDto>>
    {
        private readonly IPostRepository _postRepository;

        public GetAllPostsByUserIdQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<PostsDto>> Handle(GetAllPostsByUserIdQuery query, CancellationToken ct)
        {
            var data = await _postRepository.GetAllPostsByUserIdAsync(query.id);
            var result = data.Select(e => new PostsDto
            {
                Id = e.Id,
                UserId = e.UserId,
                Title = e.Title,
                Content = e.Content,
                Img = e.Img,
            });

            return result ?? new List<PostsDto>() { };
        }
    }
}
