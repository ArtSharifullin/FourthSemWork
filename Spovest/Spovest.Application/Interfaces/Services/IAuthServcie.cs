using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spovest.Application.Interfaces.Services;

public interface IAuthService
{
    Task<bool> RegisterAsync(string firstname, string lastname, string email, string password);
    Task<bool> LoginAsync(string email, string password);
    Task<bool> LogoutAsync();
    Task<bool> RegisterOutAsync(string firstname, string lastname, string email, string password);
    Task<bool> RegOnlyAppUserAsync(string id, string firstname, string email, string password);
}
