using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheMediaProject.Data;
using TheMediaProject.Domain.Movies;
using TheMediaProject.Domain.Movies.Serie;
using TheMediaProject.Models.Serie;

namespace TheMediaProject.Controllers.Serie
{
    public class EditSeriesController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EditSeriesController> _logger;
        private readonly ApplicationDbContext _database;

        public EditSeriesController(IConfiguration configuration, ILogger<EditSeriesController> logger, ApplicationDbContext database)
        {
            _configuration = configuration;
            _logger = logger;
            _database = database;
        }

        public IActionResult EditTitle(int id, SeriesViewViewModel model)
        {
            Series series = _database.Series.FirstOrDefault(a => a.Id == id);

            series.Title = model.Title;

            _database.SaveChanges();

            return RedirectToAction("View", "Series", new { Id = id });
        }

        public IActionResult EditDescription(int id, SeriesViewViewModel model)
        {
            Series series = _database.Series.FirstOrDefault(a => a.Id == id);

            series.Description = model.Description;

            _database.SaveChanges();

            return RedirectToAction("View", "Series", new { Id = id });
        }

        public IActionResult EditReleaseDate(int id, SeriesViewViewModel model)
        {
            Series series = _database.Series.FirstOrDefault(a => a.Id == id);

            series.ReleaseDate = model.ReleaseDate;

            _database.SaveChanges();

            return RedirectToAction("View", "Series", new { Id = id });
        }

        public IActionResult EditGenre(int id, SeriesViewViewModel model)
        {
            Series series = _database.Series.FirstOrDefault(a => a.Id == id);

            List<MovieGenreSeries> movieGenreSeries = _database.MovieGenreSeries.Where(a => a.SerieId == id).ToList();
            _database.MovieGenreSeries.RemoveRange(movieGenreSeries);
            _database.SaveChanges();

            if (model.GenreString != null)
            {
                string[] genres = model.GenreString.Split(",");

                foreach (var genre in genres)
                {
                    MovieGenre movieGenre = _database.MovieGenres.FirstOrDefault(a => a.Name == genre);
                    _database.MovieGenreSeries.Add(new MovieGenreSeries { MovieGenreId = movieGenre.Id, SerieId = series.Id });
                }
            }


            _database.SaveChanges();


            return RedirectToAction("View", "Series", new { Id = id });
        }

        public IActionResult EditActors(int id, SeriesViewViewModel model)
        {
            Series series = _database.Series.FirstOrDefault(a => a.Id == id);

            List<SeriesCrewMember> ActorsFromDatabase = _database.SeriesCrewMembers.Where(a => a.SeriesId == id && a.MemberRole == SeriesCrewMember.Role.Actor).ToList();
            _database.SeriesCrewMembers.RemoveRange(ActorsFromDatabase);

            List<SeriesCrewMember> BothFromDatabase = _database.SeriesCrewMembers.Where(a => a.SeriesId == id && a.MemberRole == SeriesCrewMember.Role.Both).ToList();

            foreach (var both in BothFromDatabase)
            {
                both.MemberRole = SeriesCrewMember.Role.Director;
            }

            _database.SaveChanges();

            if (model.ActorsString != null)
            {
                string[] actors = model.ActorsString.Split(",&nbsp;");

                foreach (var actorString in actors)
                {
                    CrewMember crewMember = new CrewMember();

                    if (!_database.CrewMembers.Any(a => a.Name == actorString))
                    {
                        crewMember.Name = actorString;
                        _database.CrewMembers.Add(crewMember);
                        _database.SaveChanges();
                    }
                    else
                    {
                        crewMember = _database.CrewMembers.FirstOrDefault(a => a.Name == actorString);
                    }

                    _database.SaveChanges();

                    SeriesCrewMember seriesCrewMember = new SeriesCrewMember();

                    if (!_database.SeriesCrewMembers.Any(a => a.SeriesId == series.Id && a.CrewMemberId == crewMember.Id))
                    {

                        seriesCrewMember.SeriesId = series.Id;
                        seriesCrewMember.CrewMemberId = crewMember.Id;
                        seriesCrewMember.MemberRole = SeriesCrewMember.Role.Actor;
                    }
                    else
                    {
                        seriesCrewMember.MemberRole = SeriesCrewMember.Role.Both;
                    }


                    _database.SeriesCrewMembers.Add(seriesCrewMember);
                }
            }


            _database.SaveChanges();


            return RedirectToAction("View", "Series", new { Id = id });
        }

        public IActionResult EditDirectors(int id, SeriesViewViewModel model)
        {
            Series series = _database.Series.FirstOrDefault(a => a.Id == id);

            List<SeriesCrewMember> DirectorsFromDatabase = _database.SeriesCrewMembers.Where(a => a.SeriesId == id && a.MemberRole == SeriesCrewMember.Role.Director).ToList();
            _database.SeriesCrewMembers.RemoveRange(DirectorsFromDatabase);

            List<SeriesCrewMember> BothFromDatabase = _database.SeriesCrewMembers.Where(a => a.SeriesId == id && a.MemberRole == SeriesCrewMember.Role.Both).ToList();

            foreach (var both in BothFromDatabase)
            {
                both.MemberRole = SeriesCrewMember.Role.Actor;
            }

            _database.SaveChanges();

            if (model.ActorsString != null)
            {
                string[] directors = model.DirectorsString.Split(",&nbsp;");

                foreach (var directorString in directors)
                {
                    CrewMember crewMember = new CrewMember();

                    if (!_database.CrewMembers.Any(a => a.Name == directorString))
                    {
                        crewMember.Name = directorString;
                        _database.CrewMembers.Add(crewMember);
                        _database.SaveChanges();
                    }
                    else
                    {
                        crewMember = _database.CrewMembers.FirstOrDefault(a => a.Name == directorString);
                    }

                    _database.SaveChanges();

                    SeriesCrewMember seriesCrewMember = new SeriesCrewMember();

                    if (!_database.SeriesCrewMembers.Any(a => a.SeriesId == series.Id && a.CrewMemberId == crewMember.Id))
                    {

                        seriesCrewMember.SeriesId = series.Id;
                        seriesCrewMember.CrewMemberId = crewMember.Id;
                        seriesCrewMember.MemberRole = SeriesCrewMember.Role.Director;
                    }
                    else
                    {
                        seriesCrewMember.MemberRole = SeriesCrewMember.Role.Both;
                    }


                    _database.SeriesCrewMembers.Add(seriesCrewMember);
                }
            }


            _database.SaveChanges();


            return RedirectToAction("View", "Series", new { Id = id });
        }
    }
}
