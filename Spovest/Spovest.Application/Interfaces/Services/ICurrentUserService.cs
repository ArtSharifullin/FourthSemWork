using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Spovest.Domain.Entities;

namespace Spovest.Application.Interfaces.Services
{
    public interface ICurrentUserService
    {
        ClaimsPrincipal User { get; }
        Task<AppUser> GetCurrentAppUser();
        Task<IdentityUser> GetCurrentIdentityUser();
    }
} 