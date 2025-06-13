using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Posts.Command.Delete
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, bool>
    {
        private readonly IPostRepository _postRepository;
        public DeletePostCommandHandler(IPostRepository postRepository) { _postRepository = postRepository; }

        public async Task<bool> Handle(DeletePostCommand command, CancellationToken ct) =>
            await _postRepository.DeletePostAsync(command.id);
    }
}
