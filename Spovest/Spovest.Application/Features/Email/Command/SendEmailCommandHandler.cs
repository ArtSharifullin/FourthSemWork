using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Spovest.Application.Interfaces.Services;

namespace Spovest.Application.Features.Email.Command
{
    public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand, bool>
    {
        private readonly IEmailService _emailService;
        public SendEmailCommandHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task<bool> Handle(SendEmailCommand command, CancellationToken cancellationToken) =>
            await _emailService.SendEmailAsync(command.FullName, command.Email, command.Subject, command.Body);
    }
}
