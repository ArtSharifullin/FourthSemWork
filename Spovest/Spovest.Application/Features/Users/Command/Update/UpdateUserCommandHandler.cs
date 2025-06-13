using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Repositories;
using Spovest.Application.Interfaces.Services;

namespace Spovest.Application.Features.Users.Command.Add
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(UpdateUserCommand command, CancellationToken ct) =>
            await _userRepository.UpdateUserAsync(command.Id, command.Name, command.Email, command.Password, command.Img, command.Country, command.Balance, command.IsWithdrawBlocked);
    }
}
