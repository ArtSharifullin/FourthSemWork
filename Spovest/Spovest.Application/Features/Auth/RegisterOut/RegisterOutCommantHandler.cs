using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Services;

namespace Spovest.Application.Features.Auth.RegisterOut
{
    public class RegisterOutCommantHandler : IRequestHandler<RegisterOutCommand, bool>
    {
        private readonly IAuthService _authService;

        public RegisterOutCommantHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<bool> Handle(RegisterOutCommand command, CancellationToken cancellationToken) =>
            await _authService.RegisterOutAsync(command.FirstName, command.LastName, command.Email, command.Password);
    }
}
