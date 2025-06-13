using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spovest.Domain.Entities;

namespace Spovest.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetAllUsersAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<bool> UpdateUserAsync(int Id, string? Name, string? Email, string? Password, string? Img, string? Country, decimal? Balance, bool? IsWithdrawBlocked);
        Task<bool> RemoveUserAsync(int Id);
    }
}
