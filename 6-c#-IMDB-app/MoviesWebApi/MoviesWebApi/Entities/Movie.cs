using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApi.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool InTheaters { get; set; }
        public List<MoviesGenres> MoviesGenres { get; set; } 
        public List<MoviesActors> MoviesActors { get; set; } 
    }
}
