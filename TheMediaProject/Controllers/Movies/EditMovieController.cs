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

            string playTime = model.PlayTime.ToString();

            string[] playTimeDivided = playTime.Split(":");

            movie.PlayTime = new TimeSpan(Convert.ToInt16(playTimeDivided[0]), Convert.ToInt16(playTimeDivided[1]), 0);

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

        public IActionResult EditGenre(int id, MovieViewViewModel model)
        {
            Movie movie = _database.Movies.FirstOrDefault(a => a.Id == id);

            List<MovieGenreMovie> movieGenreMovies = _database.MovieGenreMovies.Where(a => a.MovieId == id).ToList();
            _database.MovieGenreMovies.RemoveRange(movieGenreMovies);
            _database.SaveChanges();

            if (model.GenreString != null)
            {
                string[] genres = model.GenreString.Split(",");

                foreach (var genre in genres)
                {
                    MovieGenre movieGenre = _database.MovieGenres.FirstOrDefault(a => a.Name == genre);
                    _database.MovieGenreMovies.Add(new MovieGenreMovie { MovieGenreId = movieGenre.Id, MovieId = movie.Id });
                }
            }


            _database.SaveChanges();


            return RedirectToAction("View", "Movie", new { Id = id });
        }

        public IActionResult EditActors(int id, MovieViewViewModel model)
        {
            Movie movie = _database.Movies.FirstOrDefault(a => a.Id == id);

            List<MovieCrewMember> ActorsFromDatabase = _database.MovieCrewMember.Where(a => a.MovieId == id && a.MemberRole == MovieCrewMember.Role.Actor).ToList();
            _database.MovieCrewMember.RemoveRange(ActorsFromDatabase);
            _database.SaveChanges();

            if (model.ActorsString != null)
            {
                string[] actors = model.ActorsString.Split(",");

                foreach (var actorString in actors)
                {
                    CrewMember actor = _database.CrewMembers.FirstOrDefault(a => a.Name == actorString);
                    _database.MovieCrewMember.Add(new MovieCrewMember { CrewMemberId = actor.Id, MovieId = movie.Id, MemberRole = MovieCrewMember.Role.Actor });
                }
            }


            _database.SaveChanges();


            return RedirectToAction("View", "Movie", new { Id = id });
        }
    }
}
