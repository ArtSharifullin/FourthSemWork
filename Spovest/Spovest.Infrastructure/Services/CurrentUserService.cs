using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Spovest.Application.Interfaces.Repositories;
using Spovest.Application.Interfaces.Services;
using Spovest.Domain.Entities;
using Spovest.Persistence.Repositories;
using System.Security.Claims;

namespace SocialNetwork.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserRepository _userRepository;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;

        public async Task<AppUser> GetCurrentAppUser()
        {
            var identityUser = await _userManager.GetUserAsync(User);
            if (identityUser == null)
            {
                return null;
            }

            var currentAppUsers = await _userRepository.GetAllUsersAsync();
            var curAppUser = currentAppUsers.FirstOrDefault(u => u.IdentityId == identityUser.Id);

            return curAppUser ?? new AppUser();
        }

        public async Task<IdentityUser> GetCurrentIdentityUser()
        {
            var identityUser = await _userManager.GetUserAsync(User);
            if (identityUser == null)
            {
                return null;
            }

            return identityUser;
        }
    }
} 