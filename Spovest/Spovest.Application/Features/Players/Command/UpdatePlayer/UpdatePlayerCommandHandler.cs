using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Players.Command.UpdatePlayer
{
    public class UpdatePlayerCommandHandler : IRequestHandler<UpdatePlayerCommand, bool>
    {
        private readonly IPlayerRepository _playerRepository;
        public UpdatePlayerCommandHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<bool> Handle(UpdatePlayerCommand command, CancellationToken ct) =>
            await _playerRepository.UpdatePlayerAsync(command.Id, command.Name, command.TeamName, command.Games, command.Points, command.Assists, command.Rebounds, command.Steals, command.Minutes, command.Ftps);
    }
}
