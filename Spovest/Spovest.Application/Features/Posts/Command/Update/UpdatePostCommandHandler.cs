using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Posts.Command.Update
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, bool>
    {
        private readonly IPostRepository _postRepository;
        public UpdatePostCommandHandler(IPostRepository postRepository) { _postRepository = postRepository; }

        public async Task<bool> Handle(UpdatePostCommand command, CancellationToken ct) =>
            await _postRepository.UpdatePostAsync(command.Id, command.Title, command.Content, command.Img);
    }
}
