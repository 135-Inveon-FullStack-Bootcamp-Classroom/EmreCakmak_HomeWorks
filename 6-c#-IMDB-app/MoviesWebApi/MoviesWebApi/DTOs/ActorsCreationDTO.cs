using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApi.DTOs
{
    public class ActorsCreationDTO
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Biography { get; set; }
        public IFormFile Picture { get; set; }
    }
}
