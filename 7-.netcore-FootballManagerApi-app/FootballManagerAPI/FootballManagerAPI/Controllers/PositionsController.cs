using FootballManagerAPI.Entities;
using FootballManagerAPI.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PositionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Positions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Position>>> GetPositions()
        {
            var positions = await _unitOfWork.PositionService.GetAllAsync();
            return Ok(positions);
        }

        // GET: api/Positions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Position>> GetPositions(int id)
        {
            var positions = await _unitOfWork.PositionService.GetAsync(id);
            return Ok(positions);
        }

        // PUT: api/Positions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPositions(int id, Position positions)
        {
            await _unitOfWork.PositionService.UpdateAsync(id, positions);
            return Ok(positions.Id);
        }

        // POST: api/Positions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Position>> PostPositions(Position positions)
        {
            var created = await _unitOfWork.PositionService.CreateAsync(positions);
            return Ok(created);
        }

        // DELETE: api/Positions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePositions(int id)
        {
            await _unitOfWork.PositionService.DeleteAsync(id);
            return Ok();
        }
    }
}
