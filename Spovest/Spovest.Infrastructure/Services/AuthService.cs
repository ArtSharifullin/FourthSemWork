using Microsoft.AspNetCore.Identity;
using Spovest.Application.Interfaces.Repositories;
using Spovest.Application.Interfaces.Services;
using Spovest.Domain.Entities;
using Spovest.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spovest.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly ApplicationDbContext _context;
    private readonly IBalanceHistoryRepository _balanceHistoryRepository;

    public AuthService
        (UserManager<IdentityUser> userManager, 
        SignInManager<IdentityUser> signInManager, 
        ApplicationDbContext context,
        IBalanceHistoryRepository balanceHistoryRepository)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
        _balanceHistoryRepository = balanceHistoryRepository;
    }

    public async Task<bool> RegisterAsync(string firstname, string lastname, string email, string password)
    {
        var identityUser = new IdentityUser
        {
            UserName = email,
            Email = email,
        };

        var result = await _userManager.CreateAsync(identityUser, password);

        if (!result.Succeeded)
            return false;

        await _signInManager.SignInAsync(identityUser, isPersistent: false);

        // Создаем доменную сущность User
        var user = new AppUser
        {
            IdentityId = identityUser.Id,
            Name = $"{firstname} {lastname}",
            Email = email,
            Password = password,
            Img = "/images/user/profile-sm.png",
            Country = "Россия",
            Balance = 500,
        };

        var totalBalance = await _balanceHistoryRepository.GetLastTotalBalance();
        _context.BalanceHistory.Add(new BalanceHistory
        {
            Date = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
            TotalBalance = totalBalance + 500,
        });
        await _context.AppUsers.AddAsync(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RegisterOutAsync(string firstname, string lastname, string email, string password)
    {
        var identityUser = new IdentityUser
        {
            UserName = email,
            Email = email,
        };

        var result = await _userManager.CreateAsync(identityUser, password);

        if (!result.Succeeded)
            return false;

        

        // Создаем доменную сущность User
        var user = new AppUser
        {
            IdentityId = identityUser.Id,
            Name = $"{firstname} {lastname}",
            Email = email,
            Password = password,
            Img = "/images/user/profile-sm.png",
            Country = "Россия",
            Balance = 500,
        };

        var totalBalance = await _balanceHistoryRepository.GetLastTotalBalance();
        _context.BalanceHistory.Add(new BalanceHistory
        {
            Date = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
            TotalBalance = totalBalance + 500,
        });

        await _context.AppUsers.AddAsync(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RegOnlyAppUserAsync(string id, string firstname, string email, string password)
    {
        var identityUser = await _userManager.FindByIdAsync(id);

        if (identityUser == null) return false;

        // Создаем доменную сущность User
        var user = new AppUser
        {
            IdentityId = identityUser.Id,
            Name = firstname,
            Email = email,
            Password = password,
            Img = "/images/user/profile-sm.png",
            Country = "Россия",
            Balance = 500,
        };
        var totalBalance = await _balanceHistoryRepository.GetLastTotalBalance();
        _context.BalanceHistory.Add(new BalanceHistory
        {
            Date = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
            TotalBalance = totalBalance + 500,
        });
        await _context.AppUsers.AddAsync(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> LoginAsync(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return false;

        var result = await _signInManager.PasswordSignInAsync(user, password, false, false);

        return result.Succeeded ? true :
        false;
    }

    public async Task<bool> LogoutAsync()
    {
        try
        {
            await _signInManager.SignOutAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
