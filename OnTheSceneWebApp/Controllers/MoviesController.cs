using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OnTheSceneWebApp.Data;
using OnTheSceneWebApp.Models;
using OnTheSceneWebApp.ViewModels;
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
        private readonly MoviesDbContext _dbContext;

        public MoviesController(ILogger<MoviesController> logger, IConfiguration config, RoleManager<IdentityRole> roleManager, MoviesDbContext dbContext)
        {
            _logger = logger;
            _config = config;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }
        private async Task<IActionResult> AddRole(string role)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
            return Json(_roleManager.Roles);
        }
        [HttpGet]
        public IActionResult Index()
        {
            var mainPageMovieOptions = new MainPageMovieOptions();

            _config.GetSection("MainPageMovie").Bind(mainPageMovieOptions);
            return View(mainPageMovieOptions);
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var availableBookings = new List<AvailableBookingModel>();
            var movies = new List<MovieModel>();
            var halls = new List<CinemaHall>();
            var hours = new List<HoursModel>();

            using (_dbContext)
            {
                availableBookings = await _dbContext.AvailableBookings.ToListAsync();
                movies = await _dbContext.Movies.ToListAsync();
                halls = await _dbContext.CinemaHalls.ToListAsync();
                hours = await _dbContext.Hours.ToListAsync();
            }

            List<AvailableBookingViewModel> model = new();
            foreach(var ab in availableBookings)
            {
                var movie = movies.Where(m => m.Id == ab.MovieId).FirstOrDefault();
                var hall = halls.Where(h => h.Id == ab.CinemaHallId).FirstOrDefault();
                var hoursAvailable = hours.Where(ho => ho.AvailableBookingModelId == ab.Id).ToList();
                model.Add(new AvailableBookingViewModel { AvailableBookingId = ab.Id, Movie = movie, Hours = ab.HoursAvailable, CinemaHall = hall, Date = ab.Date });
            }
            return View(model);
        }

        #region Create Movie
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateMovie()
        {
            return View(new MovieModel { DateReleased = DateTime.Now.Date});
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateMovie(MovieModel model)
        {
            if(ModelState.IsValid)
            {
                using (_dbContext)
                {
                    await _dbContext.Movies.AddAsync(model);
                    await _dbContext.SaveChangesAsync();
                }
            }    
            return View();
        }
        #endregion


        #region Create Available Booking

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAvailableBooking()
        {
            List<MovieModel> movies = new();
            List<CinemaHall> halls = new();
            using(_dbContext)
            {
                movies = await _dbContext.Movies.ToListAsync();
                halls = await _dbContext.CinemaHalls.ToListAsync();
            }    

            var titleIdList = new List<MovieTitleId>();

            foreach (var movie in movies)
            {
                titleIdList.Add(new MovieTitleId { Id = movie.Id, Title = movie.Title });
            }

            return View(
                new CreateAvailableBookingViewModel { 
                    AvailableBooking = new AvailableBookingModel {Date=DateTime.Today}, TitleId = titleIdList, Halls = halls } );
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateAvailableBooking(CreateAvailableBookingViewModel model)
        {
            List<MovieModel> movies = new();
            List<CinemaHall> halls = new();
            
            //Add the available booking to db
            //Populate movies and halls lists
            if (ModelState.IsValid)
            {
                using(_dbContext)
                {
                    movies = await _dbContext.Movies.ToListAsync();
                    halls = await _dbContext.CinemaHalls.ToListAsync();
                    await _dbContext.AvailableBookings.AddAsync(model.AvailableBooking);
                    await _dbContext.SaveChangesAsync();
                }
            }

            //Make the TitleId model
            var titleIdList = new List<MovieTitleId>();
            foreach (var movie in movies)
            {
                titleIdList.Add(new MovieTitleId { Id = movie.Id, Title = movie.Title });
            }

            return View(
                new CreateAvailableBookingViewModel
                {
                    AvailableBooking = new AvailableBookingModel
                    {
                    Date=DateTime.Today
                    },
                    TitleId = titleIdList,
                    Halls = halls
                });
        }


        #endregion


        #region Book

        public async Task<IActionResult> BookMovie(int id, int hourId)
        {
            List<AvailableBookingModel> availableBookings;
            List<MovieModel> movies;
            List<HoursModel> hours;

            using (_dbContext)
            {
                availableBookings = await _dbContext.AvailableBookings.ToListAsync();
                movies = await _dbContext.Movies.ToListAsync();
                hours = await _dbContext.Hours.ToListAsync();
            }
            
            var availableBooking = availableBookings.Where(x => x.Id == id).FirstOrDefault();
            var movie = movies.Where(x=>x.Id == availableBooking.MovieId).FirstOrDefault();
            //hours = hours.Where(x => x.Id == availableBooking.Id).ToList();
            //availableBooking.HoursAvailable = hours;

            var model = new BookMovieViewModel
            {
                Movie = movie,
                AvailableBooking = availableBooking,
                HourId = hourId
            };
            return View(model);
        }


        #endregion


    }
}
