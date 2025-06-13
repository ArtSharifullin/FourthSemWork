using Spovest.Application.Features.Users.Query;

namespace Spovest.Areas.Admin.Models.Users
{
    public class UsersVM
    {
        public IEnumerable<UserDto> Users { get; set; }
    }
}
