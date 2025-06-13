using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Spovest.Application.Features.Auth.RegOnlyAppUser
{
    public class RegOnlyAppUserCommand : IRequest<bool>
    {
        public required string id { get; set; }
        public required string FirstName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
