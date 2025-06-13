using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spovest.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Spovest.Application.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetAllPlayersAsync();
        Task<IEnumerable<Player>> GetAllPlayersByTeamIdAsync(int teamId);
        Task<Player> GetPlayerByIdAsync(int playerId);
        Task<bool> CreatePlayerAsync(string Name, string TeamName, int Games, decimal Points, decimal Assists, decimal Rebounds, decimal Steals, decimal Minutes, decimal Ftps);
        Task<bool> UpdatePlayerAsync(int Id, string? Name, string? TeamName, int? Games, decimal? Points, decimal? Assists, decimal? Rebounds, decimal? Steals, decimal? Minutes, decimal? Ftps);
        Task<bool> DeletePlayerAsync(int Id);


    }
}
