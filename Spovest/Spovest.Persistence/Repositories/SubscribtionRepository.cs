using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spovest.Application.Interfaces.Repositories;
using Spovest.Domain.Entities;

namespace Spovest.Persistence.Repositories
{
    public class SubscribtionRepository : ISubscribtionRepository
    {
        private readonly IGenericRepository<Subscription> _repository;

        public SubscribtionRepository(IGenericRepository<Subscription> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AppUser>> GetAllFollowersAsync(int userId)
        {
            return await _repository.Entities.Where(x => x.AppUserId == userId).Select(x => x.Follower).OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<IEnumerable<AppUser>> GetAllFollowingAsync(int userId)
        {
            return await _repository.Entities.Where(x => x.FollowerId == userId).Select(x => x.AppUser).OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<IEnumerable<Subscription>> GetAllSubscribtionAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<Subscription> ExistingSubscriptionAsync(AppUser user, AppUser follower)
        {
            var IsExist = await _repository.Entities.AnyAsync(x => x.AppUser == user && x.Follower == follower);

            if (IsExist)
            {
                return await _repository.Entities.FirstOrDefaultAsync(x => x.AppUser == user && x.Follower == follower);
            }
            return null;
        }
    }
}
