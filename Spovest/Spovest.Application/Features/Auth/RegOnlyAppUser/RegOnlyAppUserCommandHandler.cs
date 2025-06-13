using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Services;

namespace Spovest.Application.Features.Auth.RegOnlyAppUser
{
    public class RegOnlyAppUserCommandHandler : IRequestHandler<RegOnlyAppUserCommand, bool>
    {
        private readonly IAuthService _authService;

        public RegOnlyAppUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<bool> Handle(RegOnlyAppUserCommand command, CancellationToken cancellationToken) =>
            await _authService.RegOnlyAppUserAsync(command.id, command.FirstName, command.Email, command.Password);
    }
}
