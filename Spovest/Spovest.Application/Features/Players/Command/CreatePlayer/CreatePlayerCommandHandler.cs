using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Repositories;

namespace Spovest.Application.Features.Players.Command.CreatePlayer
{
    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, bool>
    {
        private readonly IPlayerRepository _playerRepository;
        public CreatePlayerCommandHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<bool> Handle(CreatePlayerCommand command, CancellationToken ct) =>
            await _playerRepository.CreatePlayerAsync(command.Name, command.TeamName, command.Games, command.Points, command.Assists, command.Rebounds, command.Steals, command.Minutes, command.Ftps);
    }
}
