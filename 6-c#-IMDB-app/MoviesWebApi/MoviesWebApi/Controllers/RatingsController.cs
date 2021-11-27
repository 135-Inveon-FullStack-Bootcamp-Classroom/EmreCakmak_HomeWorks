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
    [Route("api/ratings")]
    [ApiController]
    public class RatingsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;

        public RatingsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RatingDTO ratingDTO)
        {
            var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "email").Value;
            var user = await userManager.FindByEmailAsync(email);
            var userId = user.Id;

            var currentRate = await context.Ratings
                .FirstOrDefaultAsync(x => x.MovieId == ratingDTO.MovieId && x.UserId == userId);

            if (currentRate == null)
            {
                var rating = new Rating();
                rating.MovieId = ratingDTO.MovieId;
                rating.Rate = ratingDTO.Rating;
                rating.UserId = userId;
                context.Add(rating);
            }
            else
            {
                currentRate.Rate = ratingDTO.Rating;
            }


            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
