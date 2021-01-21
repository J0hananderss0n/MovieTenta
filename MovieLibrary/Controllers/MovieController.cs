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
    public class MovieController
    {
        static HttpClient client = new HttpClient();

        [HttpGet]
        [Route("/toplist")]
        public IEnumerable<Movie> Toplist(bool ascOrDesc = true)
        {
            GetMoviceService v = new GetMoviceService();
            return v.GetMovie(ascOrDesc);

        }

        [HttpGet]
        [Route("/movieById")]
        public Movie GetMovieById(string id, bool ascOrDesc = true)
        {

            GetMovieByIdService getMovieById = new GetMovieByIdService();
            var MoveById = getMovieById.GetMovieById(id, ascOrDesc);
            return MoveById;
        }
    }
}