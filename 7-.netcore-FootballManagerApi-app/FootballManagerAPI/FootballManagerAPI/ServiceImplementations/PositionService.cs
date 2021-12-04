using FootballManagerAPI.Data;
using FootballManagerAPI.Entities;
using FootballManagerAPI.ServiceAbstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerAPI.ServiceImplementations
{
    public class PositionService : IPositionService
    {
        private readonly ApplicationDbContext _context;
        public PositionService(ApplicationDbContext context)
        {

            _context = context;
        }

        public async Task<Position> CreateAsync(Position position)
        {
            _context.Positions.Add(position);
            await _context.SaveChangesAsync();

            return position;
        }

        public async Task DeleteAsync(int id)
        {
            var position = await _context.Positions.FindAsync(id);
            if (position == null)
            {
                throw new Exception("Pozisyon Bulunamadı");
            }

            _context.Positions.Remove(position);
            await _context.SaveChangesAsync();


        }

        public async Task<IEnumerable<Position>> GetAllAsync()
        {
            return await _context.Positions.ToListAsync();
        }

        public async Task<Position> GetAsync(int id)
        {
            var positions = await _context.Positions.FindAsync(id);
            return positions;
        }

        public async Task UpdateAsync(int id, Position position)
        {
            if (id != position.Id)
            {
                throw new Exception("IDler uyuşmadı");
            }

            _context.Entry(position).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PositionExists(id))
                {
                    throw new Exception("Pozisyon Yok");
                }
                else
                {
                    throw;
                }
            }


        }

        private bool PositionExists(int id)
        {
            return _context.Positions.Any(e => e.Id == id);
        }
    }
}
