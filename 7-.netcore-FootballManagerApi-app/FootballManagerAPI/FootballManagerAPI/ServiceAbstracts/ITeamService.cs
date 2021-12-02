using FootballManagerAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerAPI.ServiceAbstracts
{
    public interface ITeamService
    {
        public Task<IEnumerable<Team>> GetAllAsync();
        public Task<IEnumerable<Team>> GetAllWithFootballersAsync();
        public Task<Team> GetAsync(int id);
        public Task UpdateAsync(int id, Team team);
        public Task<Team> CreateAsync(Team team);
        public Task DeleteAsync(int id);
    }
}
