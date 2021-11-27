using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApi.DTOs
{
    //This used for Multi selected list control UI binding
    public class MoviePostGetDTO
    {
        public List<GenreDTO> Genres { get; set; }
    }
}
