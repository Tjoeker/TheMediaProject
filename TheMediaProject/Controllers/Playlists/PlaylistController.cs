using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TheMediaProject.Data;
using TheMediaProject.Domain.Movies;
using TheMediaProject.Domain.Playlists;
using TheMediaProject.Models.Movies;
using TheMediaProject.Models.Playlist;

namespace TheMediaProject.Controllers.Playlists
{
    public class PlaylistController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<PlaylistController> _logger;
        private readonly ApplicationDbContext _database;

        public PlaylistController(IConfiguration configuration, ILogger<PlaylistController> logger, ApplicationDbContext database)
        {
            _configuration = configuration;
            _logger = logger;
            _database = database;
        }

        [Authorize]
        public IActionResult Index()
        {
            List<Playlist> Playlists = _database.Playlists.Where(a => a.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();

            PlaylistIndexViewModel playlistVM = new PlaylistIndexViewModel();

            foreach (var playlist in Playlists)
            {

                PlaylistListViewModel playlistLVM = new PlaylistListViewModel
                {
                    Title = playlist.Title,
                    Id = playlist.PlaylistId
                };

                playlistVM.Playlists.Add(playlistLVM);
            }

            return View(playlistVM);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Index(PlaylistIndexViewModel playlistVM)
        {
            Playlist playlist = new Playlist()
            {
                Title = playlistVM.Title,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            _database.Playlists.Add(playlist);
            _database.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Detail(int id)
        {
            Playlist playlist = _database.Playlists.FirstOrDefault(a => a.PlaylistId == id);
            List<PlaylistItem> playlistMovieItems = _database.PlaylistItems.Where(a => a.ItemType == PlaylistItem.MediaType.Movie && a.PlaylistId == id).ToList();

            PlaylistDetailViewModel playlistDVM = new PlaylistDetailViewModel();

            playlistDVM.Title = playlist.Title;
            playlistDVM.PlaylistId = id;

            foreach(var item in playlistMovieItems)
            {
                Movie movie = _database.Movies.FirstOrDefault(a => item.MediaId == a.Id);

                playlistDVM.Movies.Add(new MovieViewViewModel
                {
                    Id = item.MediaId,
                    Title = movie.Title,
                    ReleaseDate = movie.ReleaseDate
                });
            }

            return View(playlistDVM);
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            Playlist playlist = _database.Playlists.FirstOrDefault(a => a.PlaylistId == id);

            _database.Playlists.Remove(playlist);
            _database.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult AddItem(MovieViewViewModel model, int mediaId, string type)
        {
            int playlistId = _database.Playlists.FirstOrDefault(a => a.Title == model.PlaylistString).PlaylistId;


            PlaylistItem playlistItem = new PlaylistItem
            {
                MediaId = mediaId,
                PlaylistId = playlistId
            };

            if(type == "Movie")
            {
                playlistItem.ItemType = PlaylistItem.MediaType.Movie;
            }
            else if(type == "Series")
            {
                playlistItem.ItemType = PlaylistItem.MediaType.Series;
            }

            _database.PlaylistItems.Add(playlistItem);
            _database.SaveChanges();

            return RedirectToAction("View","Movie", new { Id = mediaId });
        }

        [Authorize]
        public IActionResult DeleteItem(int id, int playlistId)
        {
            PlaylistItem playlistItem = _database.PlaylistItems.FirstOrDefault(a => a.Id == id);

            _database.PlaylistItems.Remove(playlistItem);
            _database.SaveChanges();

            return RedirectToAction("Detail", new { Id = playlistId });
        }


    }
}
