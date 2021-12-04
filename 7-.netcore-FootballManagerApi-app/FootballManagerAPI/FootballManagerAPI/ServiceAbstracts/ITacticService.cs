using FootballManagerAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerAPI.ServiceAbstracts
{
    public interface ITacticService
    {
        public Task<IEnumerable<Tactic>> GetAllAsync();
        public Task<Tactic> GetAsync(int id);
        public Task UpdateAsync(int id, Tactic tactic);
        public Task<Tactic> CreateAsync(Tactic team);
        public Task DeleteAsync(int id);
    }
}
