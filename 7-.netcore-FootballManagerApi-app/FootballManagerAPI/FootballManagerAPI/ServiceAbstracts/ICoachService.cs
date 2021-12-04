using FootballManagerAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerAPI.ServiceAbstracts
{
    public interface ICoachService
    {
        public Task<IEnumerable<Coach>> GetAllAsync();
        public Task<Coach> GetAsync(int id);
        public Task UpdateAsync(int id, Coach footballer);
        public Task<Coach> CreateAsync(Coach footballer);
        public Task DeleteAsync(int id);
    }
}
