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
    public class CoachesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoachesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Coaches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coach>> GetCoach(int id)
        {
            var coach = await _unitOfWork.CoachService.GetAsync(id);
            return Ok(coach);
        }

        // POST: api/Coaches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Coach>> PostCoach(Coach coach)
        {
            var created = await _unitOfWork.CoachService.CreateAsync(coach);
            return Ok(created);
        }

        // PUT: api/Coaches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoach(int id, Coach coach)
        {
            await _unitOfWork.CoachService.UpdateAsync(id, coach);
            return Ok(coach.Id);
        }

        // DELETE: api/Coaches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoach(int id)
        {
            await _unitOfWork.CoachService.DeleteAsync(id);
            return Ok();
        }
    }
}
