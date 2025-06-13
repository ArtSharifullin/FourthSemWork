using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Features.Posts.Query.GetAllPostsByUserId;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Posts.Query.GetAllPosts
{
    public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, IEnumerable<PostsDto>>
    {
        private readonly IPostRepository _postRepository;

        public GetAllPostsQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<PostsDto>> Handle(GetAllPostsQuery query, CancellationToken ct)
        {
            var data = await _postRepository.GetAllPostsAsync();
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
