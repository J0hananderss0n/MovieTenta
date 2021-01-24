using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieLibrary.Client
{
    public interface IMovieClient 
    {
        MovieResponse FetchMovies();
    }

    public class MovieClient : IMovieClient
    {
        static HttpClient client = new HttpClient();

        public MovieResponse FetchMovies()
        {
            var firstResponse = client.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/topp100.json").Result;
            var secondResponse = client.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/detailedMovies.json").Result;
            List<Movie> topp100List = JsonSerializer.Deserialize<List<Movie>>(new StreamReader(firstResponse.Content.ReadAsStream()).ReadToEnd());
            List<DetailedMovie> detailedmoviesList = JsonSerializer.Deserialize<List<DetailedMovie>>(new StreamReader(secondResponse.Content.ReadAsStream()).ReadToEnd());
            return new MovieResponse()
            {
                DetailedMovies = detailedmoviesList,
                Movies = topp100List
            };
        }
    }
}
