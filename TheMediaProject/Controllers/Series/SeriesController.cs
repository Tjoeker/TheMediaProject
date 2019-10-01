using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheMediaProject.Data;

namespace TheMediaProject.Controllers.Series
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
            return View();
        }
    }
}
