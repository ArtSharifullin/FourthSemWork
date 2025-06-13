using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Spovest.Application.Interfaces.Repositories;
using Spovest.Domain.Entities;

namespace Spovest.Persistence.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IGenericRepository<Player> _repository;
        private readonly IGenericRepository<Team> _teamRepository;
        private readonly ILogger<PlayerRepository> _logger;

        public PlayerRepository(IGenericRepository<Player> repository, IGenericRepository<Team> teamRepository, ILogger<PlayerRepository> logger)
        {
            _repository = repository;
            _teamRepository = teamRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Player>> GetAllPlayersAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<IEnumerable<Player>> GetAllPlayersByTeamIdAsync(int teamId)
        {
            return await _repository.Entities
                .Where(x => x.TeamId == teamId)
                .ToListAsync();
        }

        public async Task<Player> GetPlayerByIdAsync(int playerId)
        {
            return await _repository.Entities.FirstOrDefaultAsync(x => x.Id == playerId);
        }
        public async Task<bool> CreatePlayerAsync(string Name, string TeamName, int Games, decimal Points, decimal Assists, decimal Rebounds, decimal Steals, decimal Minutes, decimal Ftps)
        {
            var IsPlayerExist = _repository.Entities.Any(x => x.Name == Name);
            if (IsPlayerExist) return false;
            var AnyTeams = await _teamRepository.Entities.AnyAsync(t => t.Name == TeamName);
            if (!AnyTeams) return false;

            var teamId = _teamRepository.Entities.FirstOrDefault(x => x.Name ==  TeamName).Id;
            var random = new Random();
            int randomNumber = random.Next(1, 6);
            int[] avatarNumbers = { 1, 2, 3, 5, 6 };
            int selectedNumber = avatarNumbers[random.Next(avatarNumbers.Length)];

            var player = new Player
            {
                Name = Name,
                TeamId = teamId,
                TeamName = TeamName,
                Img = $"/images/player_search/avatar_{selectedNumber}.png",
                Games = Games,
                Points = Points,
                Assists = Assists,
                Rebounds = Rebounds,
                Steals = Steals,
                Minutes = Minutes,
                Ftps = Ftps
            };

            await _repository.AddAsync(player);
            return true;
        }
        public async Task<bool> UpdatePlayerAsync(int Id, string? Name, string TeamName, int? Games, decimal? Points, decimal? Assists, decimal? Rebounds, decimal? Steals, decimal? Minutes, decimal? Ftps)
        {
            var playerExist = await _repository.Entities.AnyAsync(x => x.Id == Id);
            if (!playerExist) { return false; }
            var player = await _repository.Entities.FirstOrDefaultAsync(x => x.Id == Id);
            var teams = await _teamRepository.GetAllAsync();
            var teamExist = teams.Any(t => t.Name.Trim().Equals(TeamName.Trim(), StringComparison.OrdinalIgnoreCase));
            if (!teamExist) { return false; }
            var teamId = _teamRepository.Entities.FirstOrDefault(_ => _.Name == TeamName).Id;

            player.Name = Name ?? player.Name;
            player.TeamId = teamId;
            player.TeamName = TeamName ?? player.TeamName;
            player.Games = Games ?? player.Games;
            player.Points = Points ?? player.Points;
            player.Assists = Assists ?? player.Assists;
            player.Rebounds = Rebounds ?? player.Rebounds;
            player.Steals = Steals ?? player.Steals;
            player.Minutes = Minutes ?? player.Minutes;
            player.Ftps = Ftps ?? player.Ftps;

            try
            {
                await _repository.UpdateAsync(player);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при обновлении игрока с ID {PlayerId}", Id);
                return false;
            }
        }
        public async Task<bool> DeletePlayerAsync(int Id)
        {
            var player = await _repository.Entities.FirstOrDefaultAsync(x => x.Id == Id);
            if (player == null) { return false; }
            await _repository.DeleteAsync(player);
            return true;
        }
    }
}
