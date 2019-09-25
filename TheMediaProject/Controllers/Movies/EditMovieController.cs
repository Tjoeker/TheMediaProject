using Microsoft.AspNetCore.Mvc;
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
    public class EditMovieController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<MovieController> _logger;
        private readonly ApplicationDbContext _database;

        public EditMovieController(IConfiguration configuration, ILogger<MovieController> logger, ApplicationDbContext database)
        {
            _configuration = configuration;
            _logger = logger;
            _database = database;
        }

        public IActionResult EditTitle(int id, MovieViewViewModel model)
        {
            Movie movie = _database.Movies.FirstOrDefault(a => a.Id == id);

            movie.Title = model.Title;

            _database.SaveChanges();

            return RedirectToAction("View","Movie",new {Id = id });
        }

        public IActionResult EditDescription(int id, MovieViewViewModel model)
        {
            Movie movie = _database.Movies.FirstOrDefault(a => a.Id == id);

            movie.Description = model.Description;

            _database.SaveChanges();

            return RedirectToAction("View", "Movie", new { Id = id });
        }

        public IActionResult EditPlayTime(int id, MovieViewViewModel model)
        {
            Movie movie = _database.Movies.FirstOrDefault(a => a.Id == id);

            movie.PlayTime = model.PlayTime;

            _database.SaveChanges();

            return RedirectToAction("View", "Movie", new { Id = id });
        }

        public IActionResult EditReleaseDate(int id, MovieViewViewModel model)
        {
            Movie movie = _database.Movies.FirstOrDefault(a => a.Id == id);

            movie.ReleaseDate = model.ReleaseDate;

            _database.SaveChanges();

            return RedirectToAction("View", "Movie", new { Id = id });
        }
    }
}
