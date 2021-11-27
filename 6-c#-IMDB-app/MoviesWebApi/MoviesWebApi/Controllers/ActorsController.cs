using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesWebApi.DTOs;
using MoviesWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApi.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public ActorsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
           
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ActorDTO>> Get(int id)
        {
            var actor = await context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            if (actor == null)
            {
                return NotFound();
            }
            return mapper.Map<ActorDTO>(actor);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ActorsCreationDTO actorCreationDTO)
        {
            var actor = mapper.Map<Actor>(actorCreationDTO);
            context.Actors.Add(actor);
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var actor = await context.Actors.FirstOrDefaultAsync(x => x.Id == Id);
            if (actor == null)
                return NotFound();
            context.Actors.Remove(actor);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
