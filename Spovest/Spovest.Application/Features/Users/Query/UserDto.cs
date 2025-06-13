using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spovest.Domain.Entities;

namespace Spovest.Application.Features.Users.Query
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string IdentityId { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public decimal Balance { get; set; }
        public bool IsWithdrawBlocked { get; set; }
    }
}
