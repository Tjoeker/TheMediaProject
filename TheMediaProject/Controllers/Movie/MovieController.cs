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
                //List<string> genreName = new List<string>();
                //foreach (var genre in movie.GenreId)
                //{
                //    MovieGenre item = genres.FirstOrDefault(a => a.Id == genre);
                //    genreName.Add(item.Name);

                //}

                model.MovieListItems.Add(new MovieListItemViewModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    ReleaseDate = movie.ReleaseDate,
                    PlayTime = movie.PlayTime,
                    //Genre = genreName,
                    Description = movie.Description,
                    Photo = movie.Photo
                });

            }

            return View(model);
        }

        public IActionResult Create()
        {
            MovieCreateViewModel model = new MovieCreateViewModel();

            List<MovieArtistListViewModel> crewMembersList = new List<MovieArtistListViewModel>();
            

            foreach(var artist in _database.CrewMembers)
            {
                crewMembersList.Add(new MovieArtistListViewModel { ArtistName = artist.Name });
            }

            model.artistNames = crewMembersList;

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(MovieCreateViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }

            List<MovieGenre> movieGenres = _database.MovieGenres.ToList();
            List<int> genreList = new List<int>();

            //foreach(var genre in model.Genre)
            //{
            //    MovieGenre movieGenre = movieGenres.Single(a => a.Name == genre);
            //    genreList.Add(movieGenre.Id);
            //}

            Movie movie = new Movie()
            {
                Title = model.Title,
                Description = model.Description,
                PlayTime = new TimeSpan(model.PlayTimeHours,model.PlayTimeMinutes,0),
                ReleaseDate = model.ReleaseDate,
                Photo = model.Photo,
                GenreId = genreList
            };

            _database.Movies.Add(movie);
            _database.SaveChanges();

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


                MovieCrewMember movieCrewMember = new MovieCrewMember()
                {
                    MovieId = movie.Id,
                    CrewMemberId = crewMember.Id,
                    MemberRole = MovieCrewMember.Role.Director
                };

                _database.MovieCrewMember.Add(movieCrewMember);
            }

            _database.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
