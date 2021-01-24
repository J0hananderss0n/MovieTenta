using MovieLibrary.Client;
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
    public interface IMovieService
    {
        IEnumerable<Movie> GetMovies();
        IEnumerable<Movie> SortMovies(bool isAscending, IEnumerable<Movie> list);
        List<Movie> RemoveDublicates(List<Movie> Movies, List<DetailedMovie> MovieDetailies);
        Movie GetMovieById(string Id);


    }
    public class MovieService : IMovieService
    {
        private readonly IMovieClient movieClient;
        public MovieService(IMovieClient movieClient)
        {
            this.movieClient = movieClient;
        }
        public IEnumerable<Movie> GetMovies()
        {
            var response = movieClient.FetchMovies();
            return RemoveDublicates(response.Movies, response.DetailedMovies);
        }
        public IEnumerable<Movie> SortMovies(bool isAscending, IEnumerable<Movie> list)
        {
            return isAscending ? list.OrderBy(x => double.Parse(x.rated)) : list.OrderByDescending(x => double.Parse(x.rated));
        }
        public List<Movie> RemoveDublicates(List<Movie> Movies, List<DetailedMovie> MovieDetailies)
        {
            foreach (var movieItems in MovieDetailies)
            {
                if (!Movies.Where(x => x.title == movieItems.title).Any())
                {
                    Movies.Add(new Movie()
                    {
                        id = movieItems.id,
                        title = movieItems.title,
                        rated = movieItems.imdbRating.ToString()
                    });
                }
            }
            return Movies;
        }
        public Movie GetMovieById(string Id)
        {
            var movies = GetMovies();
            return movies.Where(x => x.id == Id).FirstOrDefault();
        }
    }
}
