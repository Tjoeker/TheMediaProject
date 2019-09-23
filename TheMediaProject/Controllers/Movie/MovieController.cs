using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheMediaProject.Data;
using TheMediaProject.Domain.Movies;
using TheMediaProject.Models.Movies;

namespace TheMediaProject.Controllers.Movies
{
    public class MovieController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<MovieController> _logger;
        private readonly ApplicationDbContext _database;

        public MovieController(IConfiguration configuration, ILogger<MovieController> logger, ApplicationDbContext database)
        {
            _configuration = configuration;
            _logger = logger;
            _database = database;
        }

        public IActionResult Index()
        {
            MovieIndexViewModel model = new MovieIndexViewModel();

            IEnumerable<Movie> movies = _database.Movies/*.Include(a => a.Genre)*/.ToList();
            

            List<MovieGenre> genres = _database.MovieGenres.ToList();


            foreach (var movie in movies)
            {
                List<string> genreName = new List<string>();
                foreach (var genre in movie.Genre)
                {
                    MovieGenre item = genres.FirstOrDefault(a => a.Id == genre.Id);
                    genreName.Add(item.Name);

                }

                model.MovieListItems.Add(new MovieListItemViewModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    ReleaseDate = movie.ReleaseDate,
                    PlayTime = movie.PlayTime,
                    Genre = genreName,
                    Description = movie.Description,
                    Photo = movie.Photo
                });

            }

            return View(model);
        }
    }
}
