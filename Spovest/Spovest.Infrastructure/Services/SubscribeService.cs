using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Spovest.Application.Interfaces.Hubs;
using Spovest.Application.Interfaces.Repositories;
using Spovest.Application.Interfaces.Services;
using Spovest.Domain.Entities;
using Spovest.Infrastructure.Hubs;
using Spovest.Persistence.Contexts;

namespace Spovest.Infrastructure.Services
{
    public class SubscribeService : ISubscribeService
    {
        private readonly ApplicationDbContext _context;
        private readonly ISubscribtionRepository _subscribtionRepository;
        private readonly IHubContext<SubscribeHub, ISubscribeHub> _hubContext;

        public SubscribeService(ApplicationDbContext context, 
            ISubscribtionRepository subscribtionRepository, 
            IHubContext<SubscribeHub,ISubscribeHub> hubContext)
        {
            _context = context;
            _subscribtionRepository = subscribtionRepository;
            _hubContext = hubContext;
        }

        public async Task<bool> SubscribeAsync(int UserId, int FollowerId)
        {
            var user = _context.AppUsers.FirstOrDefault(x => x.Id == UserId);
            var follower = _context.AppUsers.FirstOrDefault(x => x.Id == FollowerId);

            var exsistingSubscribtion = await _subscribtionRepository.ExistingSubscriptionAsync(user, follower);

            if (exsistingSubscribtion != null)
            {
                return false;
            }
            _context.Subscriptions.Add(new Subscription
            {
                AppUserId = UserId,
                AppUser = user,
                FollowerId = follower.Id,
                Follower = follower
            });
            _context.SaveChanges();

            var followers1 = await _subscribtionRepository.GetAllFollowersAsync(UserId);
            var following1 = await _subscribtionRepository.GetAllFollowingAsync(UserId);
            var followers2 = await _subscribtionRepository.GetAllFollowersAsync(FollowerId);
            var following2 = await _subscribtionRepository.GetAllFollowingAsync(FollowerId);

            await _hubContext.Clients.User(user.IdentityId).ReceiveSubscribeUpdates(followers1, following1);
            await _hubContext.Clients.User(follower.IdentityId).ReceiveSubscribeUpdates(followers2, following2);

            return true;
        }
        public async Task<bool> UnsubscribeAsync(int UserId, int FollowerId)
        {
            var user = _context.AppUsers.FirstOrDefault(x => x.Id == UserId);
            var follower = _context.AppUsers.FirstOrDefault(x => x.Id == FollowerId);

            var exsistingSubscribtion = await _subscribtionRepository.ExistingSubscriptionAsync(user, follower);
            if (exsistingSubscribtion == null)
            {
                return false;
            }
            _context.Subscriptions.Remove(exsistingSubscribtion);
            _context.SaveChanges();

            var followers1 = await _subscribtionRepository.GetAllFollowersAsync(UserId);
            var following1 = await _subscribtionRepository.GetAllFollowingAsync(UserId);
            var followers2 = await _subscribtionRepository.GetAllFollowersAsync(FollowerId);
            var following2 = await _subscribtionRepository.GetAllFollowingAsync(FollowerId);

            await _hubContext.Clients.User(user.IdentityId).ReceiveSubscribeUpdates(followers1, following1);
            await _hubContext.Clients.User(follower.IdentityId).ReceiveSubscribeUpdates(followers2, following2);

            return true;
        }
    }
}
