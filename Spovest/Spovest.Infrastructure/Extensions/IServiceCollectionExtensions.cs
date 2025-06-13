using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Spovest.Application.Interfaces.Services;
using Spovest.Infrastructure.Services;
using Spovest.Persistence.Contexts;
using SocialNetwork.Infrastructure.Services;

namespace Spovest.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddServices();
            services.AddHttpContextAccessor();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services
                .AddTransient<IMediator, Mediator>()
                .AddTransient<IAuthService, AuthService>()
                .AddTransient<ICurrentUserService, CurrentUserService>()
                .AddTransient<ICartService, CartService>()
                .AddTransient<IBalanceService, BalanceService>()
                .AddTransient<ISubscribeService, SubscribeService>()
                .AddTransient<IEmailService, EmailService>()
                .AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders(); 
        }
    }
}
