using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieLibrary.Services
{
    public class GetMovieByIdService
    {
        static HttpClient client = new HttpClient();

        public Movie GetMovieById(string Id, bool ascOrDesc)
        {
            GetMoviceService Movies = new GetMoviceService();

            var movies = Movies.GetMovie(ascOrDesc);

            var getMovieById = movies.Where(x => x.id == Id).FirstOrDefault();

            return getMovieById;
        }
    }
}
