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
    public class SeasonController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<SeriesController> _logger;
        private readonly ApplicationDbContext _database;

        public SeasonController(IConfiguration configuration, ILogger<SeriesController> logger, ApplicationDbContext database)
        {
            _configuration = configuration;
            _logger = logger;
            _database = database;
        }

        public IActionResult View(int seriesId, int seasonId)
        {
            Season season = _database.Seasons.FirstOrDefault(a => a.SeriesId == seriesId && a.Id == seasonId);
            Series series = _database.Series.FirstOrDefault(a => a.Id == seriesId);
            List<Season> otherSeasons = _database.Seasons.Where(a => a.SeriesId == seriesId).ToList();
            List<Episode> episodes = _database.Episodes.Where(a => a.SeasonId == seasonId).ToList();

            SeasonDetailViewModel seasonDetail = new SeasonDetailViewModel()
            {
                SeriesTitle = series.Title,
                SeasonId = seasonId,
                SeriesId = seriesId,
                SeasonNumber = season.SeasonNumber
            };

            int episodenumber = 1;
            episodes.OrderBy(a => a.ReleaseDate);

            seasonDetail.Episodes = new List<EpisodeViewModel>();

            foreach (var episode in episodes)
            {
                EpisodeViewModel episodeVM = new EpisodeViewModel
                {
                    EpisodeNumber = episodenumber,
                    Description = episode.Description,
                    PlayTime = episode.PlayTime,
                    ReleaseDate = episode.ReleaseDate,
                    Title = episode.Title
                };

                seasonDetail.Episodes.Add(episodeVM);
                episodenumber++;
            }

            seasonDetail.Episodes.Add(new EpisodeViewModel { ReleaseDate = DateTime.Now});

            foreach (var seasonItem in otherSeasons)
            {
                List<Episode> episodeItems = _database.Episodes.Where(a => a.SeasonId == seasonItem.Id).ToList();
                DateTime startDate = episodeItems[0].ReleaseDate;
                DateTime endDate = episodeItems[episodeItems.Count - 1].ReleaseDate;


                SeasonViewModel seasonVM = new SeasonViewModel
                {
                    Id = seasonItem.Id,
                    SeasonNumber = seasonItem.SeasonNumber,
                    Episodes = seasonItem.Episodes.Count(),
                    StartDate = startDate,
                    EndDate = endDate
                };

                seasonDetail.Seasons.Add(seasonVM);
            }

            return View(seasonDetail);
        }

        [HttpPost]
        public IActionResult View(SeasonDetailViewModel episodeVM, int seriesId, int seasonId)
        {
            int index = episodeVM.Episodes.Count - 1;
            EpisodeViewModel newEpisode = episodeVM.Episodes[index];

            Episode episode = new Episode
            {
                Title = newEpisode.Title,
                Description = newEpisode.Description,
                PlayTime = new TimeSpan(newEpisode.PlayTimeHours, newEpisode.PlayTimeMinutes, 0),
                ReleaseDate = newEpisode.ReleaseDate,
                SeasonId = seasonId
            };

            _database.Episodes.Add(episode);
            _database.SaveChanges();

            return RedirectToAction("View", new { SeriesId = seriesId, SeasonId = seasonId });
        }
    }
}
