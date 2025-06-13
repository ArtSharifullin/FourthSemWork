using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Players.Command.DeletePlayer
{
    public class DeletePlayerCommandHandler : IRequestHandler<DeletePlayerCommand, bool>
    {
        private readonly IPlayerRepository _playerRepository;
        public DeletePlayerCommandHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<bool> Handle(DeletePlayerCommand command, CancellationToken ct) =>
            await _playerRepository.DeletePlayerAsync(command.Id);
    }
}
