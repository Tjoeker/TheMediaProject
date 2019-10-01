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

            IEnumerable<Movie> movies = _database.Movies.ToList();
            IEnumerable<MovieGenreMovie> movieGenreMoviesFromDatabase = _database.MovieGenreMovies.ToList();
            List<MovieGenreMovie> movieGenreMovies = new List<MovieGenreMovie>();
            

            List<MovieGenre> genresFromDatabase = _database.MovieGenres.ToList();
            
            

            foreach (var movie in movies)
            {
                List<string> genres = new List<string>();
                movieGenreMovies = movieGenreMoviesFromDatabase.Where(a => a.MovieId == movie.Id).ToList();

                genres.Clear();
                if(movieGenreMovies != null)
                foreach(var genreId in movieGenreMovies)
                {
                    MovieGenre genre = genresFromDatabase.FirstOrDefault(a => a.Id == genreId.MovieGenreId);
                    genres.Add(genre.Name);
                }

                model.MovieListItems.Add(new MovieListItemViewModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    ReleaseDate = movie.ReleaseDate,
                    PlayTime = movie.PlayTime,
                    Genre = genres,
                    Description = movie.Description,
                    Photo = movie.Photo
                });

            }

            return View(model);
        }

        public IActionResult Create()
        {
            MovieCreateViewModel model = new MovieCreateViewModel();

            List<MovieGenreViewModel> movieGenreList = new List<MovieGenreViewModel>();

            foreach(var genre in _database.MovieGenres)
            {
                movieGenreList.Add(new MovieGenreViewModel { Name = genre.Name });
            }

            model.genreNames = movieGenreList;

            List<MovieArtistListViewModel> crewMembersList = new List<MovieArtistListViewModel>();
            
            foreach(var artist in _database.CrewMembers)
            {
                crewMembersList.Add(new MovieArtistListViewModel { ArtistName = artist.Name });
            }

            model.artistNames = crewMembersList;

            model.ReleaseDate = DateTime.Now;

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(MovieCreateViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }

            Movie movie = new Movie()
            {
                Title = model.Title,
                Description = model.Description,
                PlayTime = new TimeSpan(model.PlayTimeHours,model.PlayTimeMinutes,0),
                ReleaseDate = model.ReleaseDate,
                Photo = model.Photo
            };

            _database.Movies.Add(movie);
            _database.SaveChanges();

            if(model.Genre != null)
            {
                string[] genres = model.Genre.Split(",");

                foreach (var genre in genres)
                {
                    MovieGenre movieGenre = _database.MovieGenres.FirstOrDefault(a => a.Name == genre);
                    _database.MovieGenreMovies.Add(new MovieGenreMovie { MovieGenreId = movieGenre.Id, MovieId = movie.Id });
                }
            }
            

            _database.SaveChanges();

            if(model.Actors != null)
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

                    MovieCrewMember movieCrewMember = new MovieCrewMember()
                    {
                        MovieId = movie.Id,
                        CrewMemberId = crewMember.Id,
                        MemberRole = MovieCrewMember.Role.Actor
                    };

                    _database.MovieCrewMember.Add(movieCrewMember);

                }
            }

            _database.SaveChanges();
            
            if(model.Directors != null)
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


                    MovieCrewMember movieCrewMember = new MovieCrewMember();

                    if (!_database.MovieCrewMember.Any(a => a.MovieId == movie.Id && a.CrewMemberId == crewMember.Id))
                    {

                        movieCrewMember.MovieId = movie.Id;
                        movieCrewMember.CrewMemberId = crewMember.Id;
                        movieCrewMember.MemberRole = MovieCrewMember.Role.Director;
                        _database.MovieCrewMember.Add(movieCrewMember);
                    }
                    else
                    {
                        movieCrewMember = _database.MovieCrewMember.First(a => a.MovieId == movie.Id && a.CrewMemberId == crewMember.Id);
                        movieCrewMember.MemberRole = MovieCrewMember.Role.Both;
                    }


                    
                }
            }
            

            _database.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult View(int id)
        {
            

            Movie movie = _database.Movies.FirstOrDefault(a => a.Id == id);

            List<MovieGenreMovie> movieGenreMovie = _database.MovieGenreMovies.Where(a => a.MovieId == id).ToList();
            List<MovieGenre> movieGenre = _database.MovieGenres.Where(a => movieGenreMovie.Any(b => b.MovieGenreId == a.Id)).ToList();
            List<MovieGenreViewModel> genreViewModels = new List<MovieGenreViewModel>();

            foreach(var item in movieGenre)
            {
                genreViewModels.Add(new MovieGenreViewModel { Name = item.Name });
            }

            List<MovieCrewMember> movieActors = _database.MovieCrewMember.Where(a => a.MovieId == id && (a.MemberRole == MovieCrewMember.Role.Actor || a.MemberRole == MovieCrewMember.Role.Both)).ToList();
            List<CrewMember> Actors = _database.CrewMembers.Where(a => movieActors.Any(b => b.CrewMemberId == a.Id)).ToList();
            List<MovieArtistListViewModel> artistViewModels = new List<MovieArtistListViewModel>();

            foreach(var item in Actors)
            {
                artistViewModels.Add(new MovieArtistListViewModel { ArtistName = item.Name });
            }
            
            List<MovieCrewMember> movieDirectors = _database.MovieCrewMember.Where(a => a.MovieId == id && (a.MemberRole == MovieCrewMember.Role.Director || a.MemberRole == MovieCrewMember.Role.Both)).ToList();
            List<CrewMember> Directors = _database.CrewMembers.Where(a => movieDirectors.Any(b => b.CrewMemberId == a.Id)).ToList();
            List<MovieArtistListViewModel> directorViewModels = new List<MovieArtistListViewModel>();

            foreach(var item in Directors)
            {
                directorViewModels.Add(new MovieArtistListViewModel { ArtistName = item.Name });
            }

            MovieViewViewModel model = new MovieViewViewModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                PlayTime = movie.PlayTime,
                ReleaseDate = movie.ReleaseDate,
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

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Movie movieFromDb = _database.Movies.First(a => a.Id == id);

            _database.Movies.Remove(movieFromDb);

            _database.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
