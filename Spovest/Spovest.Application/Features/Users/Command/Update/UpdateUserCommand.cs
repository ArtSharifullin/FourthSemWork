using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Spovest.Application.Features.Users.Command.Add
{
    public class UpdateUserCommand() : IRequest<bool>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Country { get; set; }
        public string? Img { get; set; }
        public decimal? Balance { get; set; }
        public bool? IsWithdrawBlocked { get; set; }
    }
}
