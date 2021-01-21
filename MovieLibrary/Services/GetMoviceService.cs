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
    public class GetMoviceService
    {
        static HttpClient client = new HttpClient();
        public List<Movie> SortedMovieList = new List<Movie>();


        public IEnumerable<Movie> GetMovie(bool ascOrDec)
        {
            var firstResponse = client.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/topp100.json").Result;
            var secondResponse = client.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/detailedMovies.json").Result;
            List<Movie> FirstMoveDetails = JsonSerializer.Deserialize<List<Movie>>(new StreamReader(firstResponse.Content.ReadAsStream()).ReadToEnd());
            List<DetailedMovie> SecondMoveDetailsApiList = JsonSerializer.Deserialize<List<DetailedMovie>>(new StreamReader(secondResponse.Content.ReadAsStream()).ReadToEnd());
            var movies = new List<Movie>();
            foreach (var movieItems in SecondMoveDetailsApiList)
            {
                movies.Add(new Movie()
                {
                    id = movieItems.id,
                    title = movieItems.title,
                    rated = movieItems.imdbRating.ToString()
                });
            }
            var MoveListWithOutduplicates = FirstMoveDetails.Union(movies).ToList();
            SortedMovieList = SortMovies(ascOrDec, MoveListWithOutduplicates);
            return SortedMovieList;
        }
        private List<Movie> SortMovies(bool ascOrDesc, List<Movie> movie)
        {
            if (ascOrDesc)
            {
                movie.OrderBy(x => x.rated);
            }
            else
            {
                movie.OrderByDescending(x => x.rated);
            }
            return movie;
        }
        
    }
}
