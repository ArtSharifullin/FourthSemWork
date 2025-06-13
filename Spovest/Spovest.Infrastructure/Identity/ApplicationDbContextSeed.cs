using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Spovest.Application.Features.Auth.RegOnlyAppUser;
using MediatR;

namespace Spovest.Infrastructure.Identity
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IMediator mediator)
        {
            // Create roles if they don't exist
            var roles = new[] { "User", "Manager", "Admin" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Create default admin user
            var adminEmail = "admin@spovest.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, "Admin123!");

                var command = new RegOnlyAppUserCommand
                {
                    id = adminUser.Id,
                    FirstName = "Admin",
                    Email = adminEmail,
                    Password = "Admin123!"
                };

                await mediator.Send(command);
                

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // Create default manager users
            var managerUsers = new[]
            {
                ("manager1@spovest.com", "Manager1!"),
                ("manager2@spovest.com", "Manager2!")
            };

            foreach (var (email, password) in managerUsers)
            {
                var managerUser = await userManager.FindByEmailAsync(email);

                if (managerUser == null)
                {
                    managerUser = new IdentityUser
                    {
                        UserName = email,
                        Email = email,
                        EmailConfirmed = true
                    };

                    var result = await userManager.CreateAsync(managerUser, password);

                    var command = new RegOnlyAppUserCommand
                    {
                        id = managerUser.Id,
                        FirstName = "Manager",
                        Email = email,
                        Password = password
                    };

                    await mediator.Send(command);

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(managerUser, "Manager");
                    }
                }
            }

            // Get all users and their roles in a single query
            var allUsers = await userManager.Users.ToListAsync();
            var userRoles = new Dictionary<string, List<string>>();

            foreach (var user in allUsers)
            {
                userRoles[user.Id] = (await userManager.GetRolesAsync(user)).ToList();
            }

            // Assign User role to users who don't have any role
            foreach (var user in allUsers)
            {
                if (!userRoles[user.Id].Any())
                {
                    await userManager.AddToRoleAsync(user, "User");
                }
            }
        }
    }
}
