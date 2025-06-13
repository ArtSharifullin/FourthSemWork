using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Features.Posts.Query.GetAllPosts;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Posts.Query.GetPostById
{
    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, PostsDto>
    {
        private readonly IPostRepository _postRepository;

        public GetPostByIdQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<PostsDto> Handle(GetPostByIdQuery query, CancellationToken ct)
        {
            var data = await _postRepository.GetPostByIdAsync(query.id);
            var result =  new PostsDto
            {
                Id = data.Id,
                UserId = data.UserId,
                Title = data.Title,
                Content = data.Content,
                Img = data.Img,
            };

            return result ?? new PostsDto();
        }
    }
}
