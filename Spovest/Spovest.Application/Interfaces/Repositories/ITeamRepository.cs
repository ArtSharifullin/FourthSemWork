using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spovest.Domain.Entities;

namespace Spovest.Application.Interfaces.Repositories
{
    public interface ITeamRepository
    {
        Task<Team> GetTeamByIdAsync(int teamId);
        Task<IEnumerable<Team>> GetAllTeamsAsync();

        Task<bool> CreateTeamAsync(string teamName, string img);
        Task<bool> DeleteTeamAsync(int id);
        Task<bool> UpdateTeamAsync(int id, string teamName, string img);



    }
}
