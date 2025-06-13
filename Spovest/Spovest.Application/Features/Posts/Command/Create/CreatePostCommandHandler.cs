using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Posts.Command.Create
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, bool>
    {
        private readonly IPostRepository _postRepository;
        public CreatePostCommandHandler(IPostRepository postRepository) { _postRepository = postRepository; }

        public async Task<bool> Handle(CreatePostCommand command, CancellationToken ct) =>
            await _postRepository.AddPostAsync(command.UserId, command.Title, command.Content, command.Img);
    }
}
