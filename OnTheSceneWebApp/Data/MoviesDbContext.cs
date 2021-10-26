using Microsoft.EntityFrameworkCore;
using OnTheSceneWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTheSceneWebApp.Data
{
    public class MoviesDbContext : DbContext
    {
        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<AvailableBookingModel> AvailableBookings { get; set; }
        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<ReservationModel> Reservations { get; set; }
        public DbSet<UniqueCode> UniqueCodes { get; set; }
        public DbSet<HoursModel> Hours { get; set; }
        public DbSet<ActorModel> Actors { get; set; }
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
        {

        }
    }
}
