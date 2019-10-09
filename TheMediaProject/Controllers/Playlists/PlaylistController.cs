using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TheMediaProject.Data;
using TheMediaProject.Domain.Playlists;
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

        public IActionResult Index()
        {
            List<Playlist> Playlists = _database.Playlists.Where(a => a.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();

            PlaylistIndexViewModel playlistVM = new PlaylistIndexViewModel();

            foreach (var item in Playlists)
            {
                playlistVM.Titles.Add(item.Title);
            }

            return View(playlistVM);
        }

        [HttpPost]
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

        public IActionResult Detail()
        {
            return View();
        }


    }
}
