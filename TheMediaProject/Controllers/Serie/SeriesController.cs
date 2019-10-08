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
using TheMediaProject.Models.Movies;
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

        public IActionResult Create()
        {
            SeriesCreateViewModel model = new SeriesCreateViewModel();

            List<MovieGenreViewModel> movieGenreList = new List<MovieGenreViewModel>();

            foreach (var genre in _database.MovieGenres)
            {
                movieGenreList.Add(new MovieGenreViewModel { Name = genre.Name });
            }

            model.genreNames = movieGenreList;

            List<MovieArtistListViewModel> crewMembersList = new List<MovieArtistListViewModel>();

            foreach (var artist in _database.CrewMembers)
            {
                crewMembersList.Add(new MovieArtistListViewModel { ArtistName = artist.Name });
            }

            model.artistNames = crewMembersList;

            model.Episodes.Add(new EpisodeCreateViewModel());
            model.Episodes[0].ReleaseDate = DateTime.Now;

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(SeriesCreateViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }

            Series series = new Series()
            {
                Title = model.Title,
                Description = model.Description,
                Photo = model.Photo
            };

            _database.Series.Add(series);
            _database.SaveChanges();

            if (model.Genre != null)
            {
                string[] genres = model.Genre.Split(",");

                foreach (var genre in genres)
                {
                    MovieGenre movieGenre = _database.MovieGenres.FirstOrDefault(a => a.Name == genre);
                    _database.MovieGenreSeries.Add(new MovieGenreSeries { MovieGenreId = movieGenre.Id, SerieId = series.Id });
                }
            }


            _database.SaveChanges();

            if (model.Actors != null)
            {
                string[] actors = model.Actors.Split(",");

                foreach (var Actor in actors)
                {
                    CrewMember crewMember = new CrewMember();
                    if (!_database.CrewMembers.Any(a => a.Name == Actor))
                    {
                        crewMember.Name = Actor;
                        _database.CrewMembers.Add(crewMember);
                        _database.SaveChanges();
                    }
                    else
                    {
                        crewMember = _database.CrewMembers.FirstOrDefault(a => a.Name == Actor);
                    }

                    _database.SaveChanges();

                    SeriesCrewMember seriesCrewMember = new SeriesCrewMember()
                    {
                        SeriesId = series.Id,
                        CrewMemberId = crewMember.Id,
                        MemberRole = SeriesCrewMember.Role.Actor
                    };

                    _database.SeriesCrewMembers.Add(seriesCrewMember);

                }
            }

            _database.SaveChanges();

            if (model.Directors != null)
            {
                string[] directors = model.Directors.Split(",");

                foreach (var Director in directors)
                {
                    CrewMember crewMember = new CrewMember();
                    if (!_database.CrewMembers.Any(a => a.Name == Director))
                    {
                        crewMember.Name = Director;
                        _database.CrewMembers.Add(crewMember);
                        _database.SaveChanges();
                    }
                    else
                    {
                        crewMember = _database.CrewMembers.FirstOrDefault(a => a.Name == Director);
                    }


                    SeriesCrewMember seriesCrewMember = new SeriesCrewMember();

                    if (!_database.SeriesCrewMembers.Any(a => a.SeriesId == series.Id && a.CrewMemberId == crewMember.Id))
                    {
                        seriesCrewMember.SeriesId = series.Id;
                        seriesCrewMember.CrewMemberId = crewMember.Id;
                        seriesCrewMember.MemberRole = SeriesCrewMember.Role.Director;
                        _database.SeriesCrewMembers.Add(seriesCrewMember);
                    }
                    else
                    {
                        seriesCrewMember = _database.SeriesCrewMembers.First(a => a.SeriesId == series.Id && a.CrewMemberId == crewMember.Id);
                        seriesCrewMember.MemberRole = SeriesCrewMember.Role.Both;
                    }

                }
            }


            _database.SaveChanges();

            if(model.Episodes[0].Title != null)
            {
                series.ReleaseDate = model.Episodes[0].ReleaseDate;

                Season season = new Season
                {
                    SeriesId = series.Id,
                    SeasonNumber = 1
                };

                _database.Seasons.Add(season);
                _database.SaveChanges();

                foreach (var episodeItem in model.Episodes)
                {
                    Episode episode = new Episode
                    {
                        Title = episodeItem.Title,
                        Description = episodeItem.Description,
                        ReleaseDate = episodeItem.ReleaseDate,
                        SeasonId = season.Id,
                        PlayTime = new TimeSpan(episodeItem.PlayTimeHours, episodeItem.PlayTimeMinutes, 0)
                    };

                    _database.Episodes.Add(episode);
                    _database.SaveChanges();
                }
            }

            

            return RedirectToAction("Index");
        }

        public IActionResult View(int id)
        {


            Series series = _database.Series.FirstOrDefault(a => a.Id == id);

            List<MovieGenreSeries> movieGenreSeries = _database.MovieGenreSeries.Where(a => a.SerieId == id).ToList();
            List<MovieGenre> movieGenre = _database.MovieGenres.Where(a => movieGenreSeries.Any(b => b.MovieGenreId == a.Id)).ToList();
            List<MovieGenreViewModel> genreViewModels = new List<MovieGenreViewModel>();

            foreach (var item in movieGenre)
            {
                genreViewModels.Add(new MovieGenreViewModel { Name = item.Name });
            }

            List<SeriesCrewMember> seriesActors = _database.SeriesCrewMembers.Where(a => a.SeriesId == id && (a.MemberRole == SeriesCrewMember.Role.Actor || a.MemberRole == SeriesCrewMember.Role.Both)).ToList();
            List<CrewMember> Actors = _database.CrewMembers.Where(a => seriesActors.Any(b => b.CrewMemberId == a.Id)).ToList();
            List<MovieArtistListViewModel> artistViewModels = new List<MovieArtistListViewModel>();

            foreach (var item in Actors)
            {
                artistViewModels.Add(new MovieArtistListViewModel { ArtistName = item.Name });
            }

            List<SeriesCrewMember> seriesDirectors = _database.SeriesCrewMembers.Where(a => a.SeriesId == id && (a.MemberRole == SeriesCrewMember.Role.Director || a.MemberRole == SeriesCrewMember.Role.Both)).ToList();
            List<CrewMember> Directors = _database.CrewMembers.Where(a => seriesDirectors.Any(b => b.CrewMemberId == a.Id)).ToList();
            List<MovieArtistListViewModel> directorViewModels = new List<MovieArtistListViewModel>();

            foreach (var item in Directors)
            {
                directorViewModels.Add(new MovieArtistListViewModel { ArtistName = item.Name });
            }

            SeriesViewViewModel model = new SeriesViewViewModel()
            {
                Id = series.Id,
                Title = series.Title,
                Description = series.Description,
                ReleaseDate = series.ReleaseDate,
                Genre = genreViewModels,
                Actors = artistViewModels,
                Directors = directorViewModels
            };



            List<MovieGenreViewModel> movieGenreList = new List<MovieGenreViewModel>();

            foreach (var genre in _database.MovieGenres)
            {
                movieGenreList.Add(new MovieGenreViewModel { Name = genre.Name });
            }

            model.GenreNames = movieGenreList;

            List<MovieArtistListViewModel> crewMembersList = new List<MovieArtistListViewModel>();

            foreach (var artist in _database.CrewMembers)
            {
                crewMembersList.Add(new MovieArtistListViewModel { ArtistName = artist.Name });
            }

            model.CrewMemberNames = crewMembersList;


            foreach(var season in _database.Seasons.Where(a => a.SeriesId == id).ToList())
            {
                List<Episode> episodes = _database.Episodes.Where(a => a.SeasonId == season.Id).ToList();
                DateTime startDate = episodes[0].ReleaseDate;
                DateTime endDate = episodes[episodes.Count - 1].ReleaseDate;


                SeasonViewModel seasonVM = new SeasonViewModel
                {
                    Id = season.Id,
                    SeasonNumber = season.SeasonNumber,
                    Episodes = season.Episodes.Count(),
                    StartDate = startDate,
                    EndDate = endDate
                };

                model.Seasons.Add(seasonVM);
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Series seriesFromDb = _database.Series.First(a => a.Id == id);

            _database.Series.Remove(seriesFromDb);

            _database.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult AddSeason(int seriesId)
        {
            AddSeasonViewModel season = new AddSeasonViewModel();

            season.SeriesId = seriesId;

            return View(season);
        }

        [HttpPost]
        public IActionResult AddSeason(AddSeasonViewModel seasonVM, int seriesId)
        {
            Series series = _database.Series.FirstOrDefault(a => a.Id == seriesId);

            int seasonNumber = _database.Seasons.Where(a => a.SeriesId == seriesId).Count() + 1;

            Season season = new Season
            {
                SeasonNumber = seasonNumber,
                SeriesId = seriesId
            };

            _database.Seasons.Add(season);
            _database.SaveChanges();

            Episode episode = new Episode
            {
                Title = seasonVM.Episode.Title,
                Description = seasonVM.Episode.Description,
                ReleaseDate = seasonVM.Episode.ReleaseDate,
                SeasonId = season.Id,
                PlayTime = new TimeSpan(seasonVM.Episode.PlayTimeHours, seasonVM.Episode.PlayTimeMinutes, 0)
            };

            _database.Episodes.Add(episode);
            _database.SaveChanges();

            return RedirectToAction("View","Season", new { SeriesId = seriesId, SeasonId = season.Id });
        }
    }
}
