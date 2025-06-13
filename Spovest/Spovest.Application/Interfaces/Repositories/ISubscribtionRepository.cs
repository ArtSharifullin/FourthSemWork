using Spovest.Domain.Entities;

namespace Spovest.Application.Interfaces.Repositories
{
    public interface ISubscribtionRepository 
    {
        Task<IEnumerable<AppUser>> GetAllFollowersAsync(int userId);
        Task<IEnumerable<AppUser>> GetAllFollowingAsync(int userId);
        Task<IEnumerable<Subscription>> GetAllSubscribtionAsync();
        Task<Subscription> ExistingSubscriptionAsync(AppUser user, AppUser follower);
    }
}
