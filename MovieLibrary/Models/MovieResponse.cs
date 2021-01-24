using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.Models
{
    public class MovieResponse
    {
        public List<Movie> Movies { get; set; }
        public List<DetailedMovie> DetailedMovies { get; set; }

    }
}
