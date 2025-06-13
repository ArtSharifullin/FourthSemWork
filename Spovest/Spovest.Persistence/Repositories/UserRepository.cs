using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spovest.Application.Interfaces.Repositories;
using Spovest.Domain.Entities;
using Spovest.Persistence.Contexts;

namespace Spovest.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IGenericRepository<AppUser> _repository;

        public UserRepository(IGenericRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AppUser>> GetAllUsersAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _repository.Entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateUserAsync(int Id, string? Name, string? Email, string? Password, string? Img, string? Country, decimal? Balance, bool? IsWithdrawBlocked)
        {
            var user = await _repository.Entities.FirstOrDefaultAsync(x => x.Id == Id);
            if (user == null) { return false; }

            user.Name = Name ?? user.Name;
            if (_repository.Entities.Any(x=>x.Email == Email && x.Email != user.Email)) { return false; }
            user.Email = Email ?? user.Email;
            user.Password = Password ?? user.Password;
            user.Img = Img ?? user.Img;
            user.Country = Country ?? user.Country;
            user.Balance = Balance ?? user.Balance;
            user.IsWithdrawBlocked = IsWithdrawBlocked ?? user.IsWithdrawBlocked;

            try
            {
                await _repository.UpdateAsync(user);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> RemoveUserAsync(int Id)
        {
            var user = await _repository.Entities.FirstOrDefaultAsync(x => x.Id == Id);
            if (user == null) { return false; }

            try
            {
                await _repository.DeleteAsync(user);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
