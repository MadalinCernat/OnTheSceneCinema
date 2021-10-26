using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OnTheSceneWebApp.Models;
using OnTheSceneWebApp.Services;
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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly CrudOperations _db;

        public MoviesController(ILogger<MoviesController> logger, IConfiguration config, RoleManager<IdentityRole> roleManager, CrudOperations db)
        {
            _logger = logger;
            _config = config;
            _roleManager = roleManager;
            _db = db;
        }
        public async Task<IActionResult> AddRole(string role)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
            return Json(_roleManager.Roles);
        }
        public IActionResult Index()
        {
            var mainPageMovieOptions = new MainPageMovieOptions();

            _config.GetSection("MainPageMovie").Bind(mainPageMovieOptions);
            return View(mainPageMovieOptions);
        }
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateMovie()
        {
            return View(new MovieModel { DateReleased = DateTime.Now.Date, CreateDate = DateTime.Now.Date, LastUpdated = DateTime.Now.Date });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateMovie(MovieModel model)
        {
            await _db.CreateMovie(model);
            return View();
        }
    }
}
