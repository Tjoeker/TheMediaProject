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
    public class SeriesController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<SeriesController> _logger;
        private readonly ApplicationDbContext _database;

        public SeriesController(IConfiguration configuration, ILogger<SeriesController> logger, ApplicationDbContext database)
        {
            _configuration = configuration;
            _logger = logger;
            _database = database;
        }

        public IActionResult Index()
        {
            SeriesIndexViewModel model = new SeriesIndexViewModel();
            

            IEnumerable<Series> series = _database.Series.ToList();
            IEnumerable<MovieGenreSeries> movieGenreSeriesFromDatabase = _database.MovieGenreSeries.ToList();
            List<MovieGenreSeries> movieGenreSeries = new List<MovieGenreSeries>();


            List<MovieGenre> genresFromDatabase = _database.MovieGenres.ToList();



            foreach (var serie in series)
            {
                List<string> genres = new List<string>();
                movieGenreSeries = movieGenreSeriesFromDatabase.Where(a => a.SerieId == serie.Id).ToList();

                genres.Clear();
                if (movieGenreSeries != null)
                    foreach (var genreId in movieGenreSeries)
                    {
                        MovieGenre genre = genresFromDatabase.FirstOrDefault(a => a.Id == genreId.MovieGenreId);
                        genres.Add(genre.Name);
                    }
                
                model.SeriesListItems.Add(new SeriesListItemViewModel
                {
                    Id = serie.Id,
                    Title = serie.Title,
                    ReleaseDate = serie.ReleaseDate,
                    Genre = genres,
                    Description = serie.Description,
                    Photo = serie.Photo
                });

            }

            return View(model);
        }
    }
}
