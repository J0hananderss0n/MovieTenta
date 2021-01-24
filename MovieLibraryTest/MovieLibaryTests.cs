using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieLibrary.Client;
using MovieLibrary.Models;
using MovieLibrary.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace MovieLibraryTest
{
    [TestClass]
    public class MovieLibaryTests
    {
        [TestMethod]
        public void RemoveDublicatesTest()
        {
            var firstList = new List<Movie>()
            {
                new Movie
                {
                id = "1",
                title = "Harry potter",
                rated = "5"
                },
                new Movie
                {
                id = "2",
                title = "Eva och Adam",
                rated = "2"
                },
                new Movie
                {
                id = "3",
                title = "Forrest GUmp",
                rated = "10"
                },
            };
            var secondList = new List<DetailedMovie>()
            {
                new DetailedMovie
                {
                id = "1",
                title = "Starwars",
                imdbRating = "6"
                },
                new DetailedMovie
                {
                id = "2",
                title = "Harry potter",
                imdbRating = "2"
                },
                new DetailedMovie
                {
                id = "3",
                title = "Grown ups",
                imdbRating = "10"
                }
            };
            MovieService getMovieService = new MovieService(new MovieClient());
            var actual = getMovieService.RemoveDublicates(firstList, secondList);
            Assert.AreEqual(5, actual.Count());
            Assert.AreNotEqual(6, actual.Count());
        }
        [TestMethod]
        public void SortMovieListTest()
        {
            var movies = new List<Movie>()
            {
                new Movie
                {
                id = "1",
                title = "Harry potter",
                rated = "5"
                },
                new Movie
                {
                id = "3",
                title = "Eva och Adam",
                rated = "2"
                },
                new Movie
                {
                id = "2",
                title = "Forrest Gump",
                rated = "10"
                },

            };
            MovieService getMovieService = new MovieService(new MovieClient());
            var moviesSorted = getMovieService.SortMovies(false, movies);
            Assert.AreEqual("Forrest Gump", moviesSorted.FirstOrDefault().title);
            Assert.AreNotEqual("Eva och Adam", moviesSorted.FirstOrDefault().title);
        }
       
        
    }
}