using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApi.DTOs
{
    public class MovieCreationDTO
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Trailer { get; set; }
        public bool InTheaters { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<int> GenresIds { get; set; }
        public List<int> MovieTheatersIds { get; set; }
        public List<MoviesActorsCreationDTO> Actors { get; set; }
    }
}
