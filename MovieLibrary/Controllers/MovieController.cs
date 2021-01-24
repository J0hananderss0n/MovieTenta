using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Models;
using MovieLibrary.Services;

namespace MovieLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {
        private readonly IMovieService movieService;
        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
        }        
        [HttpGet]
        [Route("/toplist")]
        public IEnumerable<Movie> Toplist(bool ascOrDesc = true)
        {
            var movies = movieService.GetMovies();
            return movieService.SortMovies(ascOrDesc, movies);
        }

        [HttpGet]
        [Route("/{id}")]
        public IActionResult GetMovieById(string id)
        {
            var movie = movieService.GetMovieById(id);  

            if(movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }
    }
}