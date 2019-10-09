using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheMediaProject.Data;
using TheMediaProject.Domain.Movies.Serie;
using TheMediaProject.Models.Serie;

namespace TheMediaProject.Controllers.Serie
{
    public class EditEpisodeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EditEpisodeController> _logger;
        private readonly ApplicationDbContext _database;

        public EditEpisodeController(IConfiguration configuration, ILogger<EditEpisodeController> logger, ApplicationDbContext database)
        {
            _configuration = configuration;
            _logger = logger;
            _database = database;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult EditTitle(int episodeId, int seasonId, EpisodeViewModel model)
        {
            Episode episode = _database.Episodes.FirstOrDefault(a => a.Id == episodeId);

            episode.Title = model.Title;

            _database.SaveChanges();

            return RedirectToAction("View", "Series", new { Id = seasonId });
        }
    }
}
