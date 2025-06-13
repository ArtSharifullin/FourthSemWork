using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spovest.Application.Interfaces.Repositories;
using Spovest.Domain.Entities;

namespace Spovest.Persistence.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly IGenericRepository<Team> _repository;

        public TeamRepository(IGenericRepository<Team> repository)
        {
            _repository = repository;
        }

        public async Task<Team> GetTeamByIdAsync(int teamId)
        {
            return await _repository.Entities.FirstOrDefaultAsync(x => x.Id == teamId);
        }

        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<bool> CreateTeamAsync(string teamName, string img)
        {
            var IsTeamExist = await _repository.Entities.AnyAsync(x => x.Name == teamName);
            if (IsTeamExist) { return false; }
            var team = new Team
            {
                Name = teamName,
                Img = img
            };
            await _repository.AddAsync(team);
            return true;
        }
        public async Task<bool> DeleteTeamAsync(int id)
        {
            var existingTeam = await GetTeamByIdAsync(id);
            if (existingTeam == null) { return false; }
            await _repository.DeleteAsync(existingTeam);
            return true;
        }
        public async Task<bool> UpdateTeamAsync(int id, string teamName, string img)
        {
            var existingTeam = await GetTeamByIdAsync(id);
            if (existingTeam == null) { return false; }
            existingTeam.Name = teamName ?? existingTeam.Name;
            existingTeam.Img = img ?? existingTeam.Img;
            await _repository.UpdateAsync(existingTeam);
            return true;
        }

    }
}
