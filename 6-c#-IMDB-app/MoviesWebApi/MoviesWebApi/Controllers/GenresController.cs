using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Route("api/genres")]
    [ApiController]
    public class GenresController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("all")]//api/genres/all
        [AllowAnonymous]//Allow all user to authorize this method
        public async Task<ActionResult<List<GenreDTO>>> Get()
        {
            var genres = await context.Genres.OrderBy(x => x.Name).ToListAsync();
            return mapper.Map<List<GenreDTO>>(genres);
        }
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<GenreDTO>> Get(int Id)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(x => x.Id == Id);
            if (genre == null)
                return NotFound();
            return mapper.Map<GenreDTO>(genre);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GenreCreationDTO genreCreationDTO)
        {
            var genre = mapper.Map<Genre>(genreCreationDTO);
            context.Genres.Add(genre);
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(x => x.Id == Id);
            if (genre == null)
                return NotFound();
            context.Genres.Remove(genre);
            await context.SaveChangesAsync();
            return NoContent();

        }
    }
}
