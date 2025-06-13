using Spovest.Persistence.Extensions;
using Spovest.Application.Extensions;
using Spovest.Infrastructure.Extensions;
using Spovest.Infrastructure.Hubs;
using System.Text.Json.Serialization;
using Spovest.Infrastructure.Services;
using Spovest.Infrastructure.Settings;
using Spovest.Logging;
using Spovest.Extensions;
using Microsoft.AspNetCore.Identity;
using Spovest.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Spovest.Application.Interfaces.Hubs;

namespace Spovest;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.Configure<MinioSettings>(builder.Configuration.GetSection("MinioSettings"));
        builder.Services.AddSingleton<IMinioService, MinioService>();

        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Logging.AddDebug();
        builder.Logging.AddFile("logs/app-{Date}.txt");
        builder.Logging.SetMinimumLevel(LogLevel.Information);

        var sp = builder.Services.BuildServiceProvider();
        var minioService = sp.GetRequiredService<IMinioService>();
        builder.Logging.AddMinio(minioService);
        builder.Logging.SetMinimumLevel(LogLevel.Information);

        builder.Services.AddApplicationLayer();
        builder.Services.AddInfrastructureLayer();
        builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
        builder.Services.AddPersistenceLayer(builder.Configuration);
        builder.Services.AddHostedService<PriceUpdateService>();

        builder.Services.AddSignalR();

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddControllers().AddJsonOptions(options =>
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        // Настройка аутентификации
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = "Cookies";
            options.DefaultChallengeScheme = "Cookies";
        })
        .AddCookie("Cookies", options =>
        {
            options.LoginPath = "/Auth/Login";
            options.AccessDeniedPath = "/Auth/Login";
        });

        // Configure authorization policies
        builder.Services.AddAuthorization(options =>
        {
            // Admin policy - full access
            options.AddPolicy("AdminPolicy", policy =>
                policy.RequireRole("Admin"));

            // Manager policy - access to Courses and Groups
            options.AddPolicy("ManagerPolicy", policy =>
                policy.RequireRole("Manager", "Admin"));

            // User policy - no admin access
            options.AddPolicy("UserPolicy", policy =>
                policy.RequireRole("User", "Manager", "Admin"));
        });

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var mediator = services.GetRequiredService<IMediator>();
                await ApplicationDbContextSeed.SeedDefaultUserAsync(userManager, roleManager, mediator);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while seeding the database.");
            }
        }


        // Custom 404 handler for unauthorized access
        app.Use(async (context, next) =>
        {
            await next();

            if (context.Response.StatusCode == 401 || context.Response.StatusCode == 403)
            {
                context.Response.Redirect("/Error/NotFound");
            }
        });

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseStatusCodePagesWithReExecute("/Error/{0}");
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
        else
        {
            app.UseStatusCodePagesWithReExecute("/Error/{0}");
            app.UseExceptionHandler("/Error");
        }
        app.UseGlobalExceptionHandling();
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        // Настройка конечной точки SignalR с CORS
        app.UseCors(builder =>
        {
            builder.WithOrigins("https://localhost:5001", "http://localhost:5000")
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();
        });

        app.UseRequestLogging();
        app.UseUserActivityLogging();

        // Добавляем маршрут хаба SignalR
        app.MapHub<PriceHub>("/priceHub");
        app.MapHub<SubscribeHub>("/subscribeHub");
        app.MapHub<BalanceHub>("/balanceHub");

        app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
