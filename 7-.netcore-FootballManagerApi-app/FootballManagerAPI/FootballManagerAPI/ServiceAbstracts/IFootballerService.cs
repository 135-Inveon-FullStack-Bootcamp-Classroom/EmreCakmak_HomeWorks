using FootballManagerAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerAPI.ServiceAbstracts
{
    public interface IFootballerService
    {
        public Task<IEnumerable<Footballer>> GetAllAsync();
        public Task<Footballer> GetAsync(int id);
        public Task UpdateAsync(int id, Footballer footballer);
        public Task<Footballer> CreateAsync(Footballer footballer);
        public Task DeleteAsync(int id);
    }
}
