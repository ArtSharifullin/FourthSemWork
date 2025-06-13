using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spovest.Application.Interfaces.Repositories;
using Spovest.Persistence.Contexts;
using Spovest.Persistence.Repositories;

namespace Spovest.Persistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddRepositories();
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseNpgsql(connectionString,
                   builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddTransient<IPostRepository, PostRepository>()
                .AddTransient<ITeamRepository, TeamRepository>()
                .AddTransient<IPlayerRepository, PlayerRepository>()
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<IPriceRepository, PriceRepository>()
                .AddTransient<ISubscribtionRepository, SubscribtionRepository>()
                .AddTransient<ITransactionRepository, TransactionRepository>()
                .AddTransient<ICartItemRepository, CartItemRepository>()
                .AddTransient<IBalanceHistoryRepository, BalanceHistoryRepository>();


        }
    }
}
