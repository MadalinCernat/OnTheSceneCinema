using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OnTheSceneWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTheSceneWebApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IConfiguration _config;

        public MoviesController(ILogger<MoviesController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }
        public IActionResult Index()
        {
            var mainPageMovieOptions = new MainPageMovieOptions();

            _config.GetSection("MainPageMovie").Bind(mainPageMovieOptions);

            return View(mainPageMovieOptions);
        }
        public IActionResult List()
        {
            return View();
        }
    }
}
