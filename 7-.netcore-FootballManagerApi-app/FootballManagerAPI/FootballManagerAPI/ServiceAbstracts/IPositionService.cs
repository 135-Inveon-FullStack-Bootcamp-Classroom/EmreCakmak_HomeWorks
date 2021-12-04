using FootballManagerAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerAPI.ServiceAbstracts
{
    public interface IPositionService
    {
        public Task<IEnumerable<Position>> GetAllAsync();
        public Task<Position> GetAsync(int id);
        public Task UpdateAsync(int id, Position positions);
        public Task<Position> CreateAsync(Position positions);
        public Task DeleteAsync(int id);
    }
}
