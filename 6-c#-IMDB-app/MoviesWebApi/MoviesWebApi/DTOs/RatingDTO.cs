using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApi.DTOs
{
    public class RatingDTO
    {
        public int Rating { get; set; }
        public int MovieId { get; set; }
    }
}
