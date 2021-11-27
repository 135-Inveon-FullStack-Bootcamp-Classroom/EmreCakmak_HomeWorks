using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public MoviesController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            Console.WriteLine("MoviesController Constructor Method");
            _dbContext = dbContext;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<MovieDTO>> Get(int id)
        {
            var movie = await _dbContext.Movies
                .Include(x => x.MoviesGenres).ThenInclude(x => x.Genre)
                .Include(x => x.MoviesActors).ThenInclude(x => x.Actor)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            var averageVote = 0.0;
            var userVote = 0;

            if (await _dbContext.Ratings.AnyAsync(x => x.MovieId == id))
            {
                averageVote = await _dbContext.Ratings.Where(x => x.MovieId == id)
                    .AverageAsync(x => x.Rate);
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "email").Value;
                    var user = await _userManager.FindByEmailAsync(email);
                    var userId = user.Id;

                    var ratingDb = await _dbContext.Ratings.FirstOrDefaultAsync(x => x.MovieId == id && x.UserId == userId);
                    if (ratingDb != null)
                    {
                        userVote = ratingDb.Rate;
                    }

                }
            }

            var dto = _mapper.Map<MovieDTO>(movie);
            dto.AverageVote = averageVote;
            dto.UserVote = userVote;
            dto.Actors = dto.Actors.OrderBy(x => x.Order).ToList();
            return dto;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromForm] MovieCreationDTO movieCreationDTO)
        {
            var movie = _mapper.Map<Movie>(movieCreationDTO);
            AnnotateActorsOrder(movie);
            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();
            return movie.Id;
        }
        private void AnnotateActorsOrder(Movie movie)
        {
            if (movie.MoviesActors != null)
            {
                for (int i = 0; i < movie.MoviesActors.Count; i++)
                {
                    movie.MoviesActors[i].Order = i;
                }
            }
        }
        [HttpGet("PostGet")]
        public async Task<ActionResult<MoviePostGetDTO>> PostGet()
        {
            var genres = await _dbContext.Genres.OrderBy(x => x.Name).ToListAsync();

            var genresDTO = _mapper.Map<List<GenreDTO>>(genres);

            return new MoviePostGetDTO() { Genres = genresDTO };
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<LandingPageDTO>> Get()
        {
            var top = 6;
            var today = DateTime.Today;

            var upcomingReleases = await _dbContext.Movies
                .Where(x => x.ReleaseDate > today)
                .OrderBy(x => x.ReleaseDate)
                .Take(top)
                .ToListAsync();

            var inTheaters = await _dbContext.Movies
                .Where(x => x.InTheaters)
                .OrderBy(x => x.ReleaseDate)
                .Take(top)
                .ToListAsync();

            var landingPageDTO = new LandingPageDTO();
            landingPageDTO.UpcomingReleases = _mapper.Map<List<MovieDTO>>(upcomingReleases);
            landingPageDTO.InTheaters = _mapper.Map<List<MovieDTO>>(inTheaters);

            return landingPageDTO;
        }
        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var movie = await _dbContext.Movies.FirstOrDefaultAsync(x => x.Id == Id);
            if (movie == null)
                return NotFound();
            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

    }
}
